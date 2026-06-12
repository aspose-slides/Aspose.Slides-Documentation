---
title: Ekspor Presentasi ke HTML dengan Gambar Tertaut Secara Eksternal
type: docs
weight: 100
url: /id/java/exporting-presentations-to-html-with-externally-linked-images/
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
- Java
- Aspose.Slides
description: "Ekspor presentasi PowerPoint dan OpenDocument ke HTML dalam Java menggunakan Aspose.Slides dengan gambar dan sumber daya lainnya disimpan sebagai file tertaut eksternal."
---
## **Ikhtisar**

Secara bawaan, Aspose.Slides mengekspor presentasi ke file HTML yang berdiri sendiri. Gambar dan sumber daya lainnya ditulis langsung ke dalam HTML, biasanya sebagai data Base64. Ini memudahkan saat Anda membutuhkan satu file yang dapat dipindahkan, tetapi tidak selalu menjadi format terbaik untuk situs web, CMS, atau pipeline konversi sisi server.

Gunakan sumber daya yang ditautkan secara eksternal ketika Anda ingin:

- mengurangi ukuran dokumen HTML;
- menyimpan gambar, font, audio, atau video secara terpisah di browser atau CDN;
- memeriksa, mengganti, mengompres, atau memproses lanjutan sumber daya yang dihasilkan setelah ekspor;
- mempertahankan struktur output lebih mendekati apa yang diharapkan aplikasi web.

Untuk alur kerja konversi HTML umum, lihat [Konversi Presentasi PowerPoint ke HTML](/slides/id/java/convert-powerpoint-to-html/). Artikel ini berfokus pada bagian penautan sumber daya dari ekspor.

## **Cara Kerja Ekspor Sumber Daya yang Ditautkan**

[ILinkEmbedController](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) memungkinkan aplikasi Anda memutuskan, sumber daya per sumber daya, apakah pengekspor menyematkan data dalam HTML atau menyimpannya secara eksternal dan menulis tautan.

Antarmuka memiliki tiga metode:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) menentukan apakah sebuah sumber daya harus ditautkan atau disematkan.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) mengembalikan URL yang akan ditulis ke HTML yang dihasilkan atau ke sumber daya tertaut lainnya.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) menulis data sumber daya tertaut ke disk atau ke target penyimpanan lainnya.

Jalur sistem file dan URL browser adalah hal yang terpisah. Misalnya, contoh di bawah menulis file sumber daya ke `html-output/assets` di disk, sementara HTML berisi URL relatif seperti `assets/resource-1.svg`. Browser menyelesaikan URL tersebut relatif terhadap file yang berisi tautan. Oleh karena itu, tautan dari `presentation.html` ke file SVG memakai `assets/resource-1.svg`, sedangkan tautan dari file SVG itu ke gambar yang disimpan di folder `assets` yang sama memakai `resource-4.jpg`.

## **Ekspor HTML dengan Sumber Daya Tertaut**

Contoh Java berikut membuat direktori output, menyimpan file HTML di sana, dan menyimpan sumber daya tertaut di subdirektori `assets`. Kontroler menautkan gambar, font, audio, video, dan sumber daya CSS umum ketika Aspose.Slides menyediakan atau dapat menyimpulkan ekstensi file yang aman. Sumber daya yang tidak dikenali tetap disematkan.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void main(String[] args) throws IOException {
        Path inputFilePath = Paths.get("presentation.pptx");
        Path outputDirectory = Paths.get("html-output");
        String assetDirectoryName = "assets";
        Path assetDirectory = outputDirectory.resolve(assetDirectoryName);

        Files.createDirectories(outputDirectory);
        Files.createDirectories(assetDirectory);

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFilePath.toString());
        try {
            Path htmlFilePath = outputDirectory.resolve("presentation.html");
            presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final Path assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

        private ExternalResourceController(Path assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            try {
                Files.createDirectories(assetDirectory);
                Path filePath = assetDirectory.resolve(fileName);
                Files.write(filePath, entityData);
            } catch (IOException exception) {
                throw new IllegalStateException("Failed to save external resource " + resourceId + ".", exception);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().isEmpty()) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.isEmpty()) {
                return null;
            }

            for (int index = 0; index < extensionCharacters.length(); index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
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

File yang tepat bergantung pada konten presentasi dan opsi ekspor. Misalnya, gambar raster biasanya diekspor sebagai JPEG atau PNG. Aspose.Slides dapat memilih codec gambar yang berbeda dari yang digunakan dalam presentasi sumber ketika itu menghasilkan file yang lebih kecil atau lebih cocok. Gambar dengan transparansi diekspor sebagai PNG.

## **Memilih URL untuk Penyebaran**

Contoh menggunakan prefiks URL relatif: `assets/`. Jika `presentation.html` dibuka dari `html-output/presentation.html`, browser memuat `html-output/assets/resource-1.svg`.

Ketika satu sumber daya tertaut merujuk ke sumber daya tertaut lainnya, contoh menggunakan parameter `referrer` dalam [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) dan mengembalikan hanya nama file. Misalnya, jika `resource-1.svg` dan `resource-4.jpg` keduanya berada di folder `assets`, file SVG harus merujuk ke `resource-4.jpg`, bukan ke `assets/resource-4.jpg`.

Gunakan prefiks URL yang berbeda ketika file disebarkan di tempat lain:

- Gunakan `assets/` ketika direktori aset berada di samping file HTML.
- Gunakan `../assets/` ketika direktori aset berada satu tingkat di atas file HTML.
- Gunakan `https://cdn.example.com/presentations/job-123/assets/` ketika file diunggah ke CDN atau server file statis.

URL yang dikembalikan oleh [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) harus cocok dengan lokasi akhir penyebaran file yang ditulis oleh [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/). Pada aplikasi server, gunakan direktori output unik atau prefiks penyimpanan objek untuk setiap pekerjaan konversi agar tidak menimpa file dari ekspor lain.

## **Kapan Harus Menyematkan Sebaliknya**

HTML Base64 yang disematkan masih berguna ketika output harus berupa satu file, seperti lampiran email, pratinjau offline, atau dokumen yang akan dipindahkan tanpa folder aset pendukung. Sumber daya tertaut lebih cocok ketika HTML akan disajikan oleh aplikasi web, disimpan di CMS, dioptimalkan oleh pipeline build, atau di-cache oleh browser secara independen dari HTML.

## **FAQ**

**Apakah saya dapat mengeksternalisasi hanya gambar dan tetap menyematkan sumber daya lain?**

Ya. Pada [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/), kembalikan `LinkEmbedDecision.Link` hanya untuk tipe konten yang ingin Anda simpan sebagai file terpisah, dan kembalikan `LinkEmbedDecision.Embed` untuk semua yang lainnya.

**Mengapa ekstensi gambar yang diekspor berbeda dari presentasi sumber?**

Aspose.Slides dapat mengkode ulang kembali gambar raster selama ekspor HTML untuk memperbaiki ukuran atau kompatibilitas browser. Misalnya, gambar dari file sumber mungkin ditulis sebagai JPEG atau PNG tergantung pada hasil render yang diinginkan.

**Apakah URL relatif tetap berfungsi setelah saya memindahkan file HTML?**

URL relatif hanya berfungsi ketika struktur folder relatif yang sama dipertahankan. Jika HTML merujuk ke `assets/resource-1.png`, folder `assets` harus tetap berada di samping file HTML kecuali Anda menghasilkan prefiks URL yang berbeda.

**Haruskah aplikasi server menggunakan kembali folder output yang sama?**

Tidak. Gunakan direktori output unik atau prefiks penyimpanan untuk setiap pekerjaan konversi. Ini mencegah bentrok nama file dan menghindari satu ekspor menimpa sumber daya yang dihasilkan oleh ekspor lain.