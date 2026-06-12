---
title: Ekspor Presentasi ke HTML dengan Gambar yang Ditautkan Secara Eksternal
type: docs
weight: 100
url: /id/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- ekspor PowerPoint
- ekspor OpenDocument
- ekspor presentasi
- ekspor slide
- ekspor PPT
- ekspor PPTX
- ekspor ODP
- PowerPoint ke HTML
- OpenDocument ke HTML
- presentasi ke HTML
- slide ke HTML
- PPT ke HTML
- PPTX ke HTML
- ODP ke HTML
- gambar tertaut
- gambar tertaut secara eksternal
- sumber daya tertaut
- sumber daya eksternal
- PHP
- Aspose.Slides
description: "Ekspor presentasi PowerPoint dan OpenDocument ke HTML dalam PHP via Java menggunakan Aspose.Slides dengan gambar serta sumber daya lain disimpan sebagai file tertaut eksternal."
---
## **Ikhtisar**

Secara default, Aspose.Slides mengekspor presentasi ke file HTML yang berdiri sendiri. Gambar dan sumber daya lainnya ditulis langsung ke dalam HTML, biasanya sebagai data Base64. Ini nyaman ketika Anda membutuhkan satu file yang dapat dipindahkan, tetapi tidak selalu menjadi format terbaik untuk situs web, CMS, atau alur konversi sisi server.

Gunakan sumber daya yang ditautkan secara eksternal ketika Anda ingin:

- mengurangi ukuran dokumen HTML;
- menyimpan gambar, font, audio, atau video secara terpisah di browser atau CDN;
- memeriksa, mengganti, mengompres, atau memproses lanjutan sumber daya yang dihasilkan setelah ekspor;
- mempertahankan struktur output lebih mirip dengan apa yang diharapkan aplikasi web.

Untuk alur kerja konversi HTML secara umum, lihat [Konversi Presentasi PowerPoint ke HTML](/slides/id/php-java/convert-powerpoint-to-html/). Artikel ini berfokus pada bagian penautan sumber daya dalam ekspor.

## **Cara Kerja Ekspor Sumber Daya yang Ditautkan**

[HtmlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/) dapat menggunakan kontroler link/embed khusus saat Aspose.Slides mengekspor presentasi ke HTML. Dalam PHP via Java, skenario ini biasanya diimplementasikan dengan kelas pembantu Java kecil. Kompilasikan pembantu tersebut, tambahkan ke classpath PHP Java Bridge, dan buat instansinya dari PHP dengan `new Java(...)`.

Kelas pembantu menentukan, sumber daya per sumber daya, apakah pengekspor menyematkan data dalam HTML atau menyimpannya secara eksternal dan menulis tautan. Ia membutuhkan tiga metode callback:

- `ExternalResourceController.getObjectStoringLocation` menentukan apakah sebuah sumber daya harus ditautkan atau disematkan.
- `ExternalResourceController.getUrl` mengembalikan URL yang akan ditulis ke HTML yang dihasilkan atau ke sumber daya tertaut lainnya.
- `ExternalResourceController.saveExternal` menulis data sumber daya tertaut ke disk atau ke target penyimpanan lain.

Jalur sistem file dan URL browser adalah hal yang terpisah. Misalnya, contoh di bawah menulis file sumber daya ke `html-output/assets` di disk, sementara HTML berisi URL relatif seperti `assets/resource-1.svg`. Browser menyelesaikan URL tersebut relatif terhadap file yang berisi tautan. Oleh karena itu, tautan dari `presentation.html` ke file SVG menggunakan `assets/resource-1.svg`, sementara tautan dari file SVG tersebut ke gambar yang disimpan di folder `assets` yang sama menggunakan `resource-4.jpg`.

## **Buat Kelas Pembantu Java**

Buat kelas Java seperti `com.example.slides.ExternalResourceController`, kompilasikan dengan Aspose.Slides untuk Java pada classpath, dan buat kelas atau JAR yang telah dikompilasi tersedia untuk PHP Java Bridge.

Pembantu di bawah ini menautkan sumber daya gambar, font, audio, video, dan CSS umum ketika Aspose.Slides menyediakan atau dapat menyimpulkan ekstensi file yang aman. Sumber daya yang tidak dikenali tetap disematkan.

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **Ekspor HTML dengan Sumber Daya yang Ditautkan**

Kode PHP berikut membuat direktori output, menyimpan file HTML di sana, dan menyimpan sumber daya tertaut dalam subdirektori `assets`. Ia menggabungkan [HtmlOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideimageformat/), dan [SaveFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/) untuk ekspor.

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Setelah ekspor, folder output memiliki struktur berikut:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

File yang tepat bergantung pada konten presentasi dan opsi ekspor. Misalnya, gambar raster biasanya diekspor sebagai JPEG atau PNG. Aspose.Slides mungkin memilih codec gambar yang berbeda dari yang digunakan dalam presentasi sumber ketika hal itu menghasilkan file yang lebih kecil atau lebih cocok. Gambar dengan transparansi diekspor sebagai PNG.

## **Memilih URL untuk Penyebaran**

Contoh ini menggunakan awalan URL relatif: `assets/`. Jika `presentation.html` dibuka dari `html-output/presentation.html`, browser memuat `html-output/assets/resource-1.svg`.

Ketika satu sumber daya tertaut merujuk ke sumber daya tertaut lain, contoh menggunakan parameter `referrer` dalam `ExternalResourceController.getUrl` dan mengembalikan hanya nama file. Misalnya, jika `resource-1.svg` dan `resource-4.jpg` keduanya berada di folder `assets`, file SVG harus merujuk ke `resource-4.jpg`, bukan ke `assets/resource-4.jpg`.

Gunakan awalan URL yang berbeda ketika file disebarkan di tempat lain:

- Gunakan `assets/` ketika direktori aset berada di samping file HTML.
- Gunakan `../assets/` ketika direktori aset satu tingkat di atas file HTML.
- Gunakan `https://cdn.example.com/presentations/job-123/assets/` ketika file diunggah ke CDN atau server file statis.

URL yang dikembalikan oleh `ExternalResourceController.getUrl` harus cocok dengan lokasi akhir file yang ditulis oleh `ExternalResourceController.saveExternal`. Dalam aplikasi server, gunakan direktori output unik atau awalan penyimpanan objek untuk setiap pekerjaan konversi guna menghindari penimpaan file dari ekspor lain.

## **Kapan Harus Menyematkan Sebagai Ganti**

HTML yang disematkan dengan Base64 masih berguna ketika output harus berupa satu file, seperti lampiran email, pratinjau offline, atau dokumen yang akan dipindahkan tanpa folder aset pendukung. Sumber daya yang ditautkan lebih cocok ketika HTML akan disajikan oleh aplikasi web, disimpan dalam CMS, dioptimalkan oleh pipeline build, atau di-cache oleh browser secara terpisah dari HTML.

## **FAQ**

**Bisakah saya mengeksternalisasi hanya gambar dan membiarkan sumber daya lain tetap disematkan?**

Ya. Pada `ExternalResourceController.getObjectStoringLocation`, kembalikan nilai `Link` dari [LinkEmbedDecision](https://reference.aspose.com/slides/id/php-java/aspose.slides/linkembeddecision/) hanya untuk tipe konten yang ingin Anda simpan sebagai file terpisah, dan kembalikan nilai `Embed` untuk semua yang lainnya.

**Mengapa ekstensi gambar yang diekspor berbeda dari presentasi sumber?**

Aspose.Slides dapat melakukan enkode ulang gambar raster selama ekspor HTML untuk memperbaiki ukuran atau kompatibilitas browser. Misalnya, gambar dari file sumber dapat ditulis sebagai JPEG atau PNG tergantung pada hasil render.

**Apakah URL relatif tetap berfungsi setelah saya memindahkan file HTML?**

URL relatif hanya berfungsi ketika struktur folder relatif yang sama dipertahankan. Jika HTML merujuk ke `assets/resource-1.png`, folder `assets` harus tetap berada di samping file HTML kecuali Anda menghasilkan awalan URL yang berbeda.

**Haruskah aplikasi server menggunakan kembali folder output yang sama?**

Tidak. Gunakan direktori output unik atau awalan penyimpanan untuk setiap pekerjaan konversi. Hal ini menghindari bentrok nama file dan mencegah satu ekspor menimpa sumber daya yang dihasilkan oleh ekspor lain.