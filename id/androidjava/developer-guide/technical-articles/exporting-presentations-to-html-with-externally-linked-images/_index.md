---
title: Ekspor Presentasi ke HTML dengan Gambar yang Ditautkan Secara Eksternal
type: docs
weight: 100
url: /id/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- gambar terhubung
- gambar terhubung secara eksternal
- sumber daya terhubung
- sumber daya eksternal
- Android
- Java
- Aspose.Slides
description: "Ekspor presentasi PowerPoint dan OpenDocument ke HTML di Android melalui Java menggunakan Aspose.Slides dengan gambar dan sumber daya lainnya disimpan sebagai file yang ditautkan secara eksternal."
---
## **Ikhtisar**

Secara default, Aspose.Slides mengekspor presentasi ke file HTML yang berdiri sendiri. Gambar dan sumber daya lain ditulis langsung ke dalam HTML, biasanya sebagai data Base64. Ini nyaman ketika Anda membutuhkan satu file yang dapat dipindahkan, tetapi tidak selalu menjadi format terbaik untuk tampilan web, CMS, atau pipeline konversi sisi server yang kemudian menerbitkan output.

Gunakan sumber daya yang ditautkan secara eksternal ketika Anda ingin:

- mengurangi ukuran dokumen HTML;
- menyimpan gambar, font, audio, atau video secara terpisah dalam browser atau CDN;
- memeriksa, mengganti, mengompres, atau memproses lanjutan sumber daya yang dihasilkan setelah ekspor;
- menjaga struktur output lebih dekat dengan yang diharapkan aplikasi web.

Untuk alur kerja konversi HTML umum, lihat [Convert PowerPoint Presentations to HTML](/slides/id/androidjava/convert-powerpoint-to-html/). Artikel ini fokus pada bagian penautan sumber daya dari ekspor.

## **Cara Kerja Ekspor Sumber Daya yang Ditautkan**

[ILinkEmbedController](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilinkembedcontroller/) memungkinkan aplikasi Anda memutuskan, sumber daya per sumber daya, apakah pengekspor menyematkan data dalam HTML atau menyimpannya secara eksternal dan menulis tautan.

Antarmuka memiliki tiga metode:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilinkembedcontroller/) memutuskan apakah sebuah sumber daya harus ditautkan atau disematkan.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilinkembedcontroller/) mengembalikan URL yang akan ditulis ke HTML yang dihasilkan atau ke sumber daya tertaut lainnya.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilinkembedcontroller/) menulis data sumber daya tertaut ke disk atau ke target penyimpanan lainnya.

Path sistem file dan URL browser adalah hal yang terpisah. Misalnya, contoh di bawah menulis file sumber daya ke `html-output/assets` dalam penyimpanan file aplikasi, sementara HTML berisi URL relatif seperti `assets/resource-1.svg`. Browser menyelesaikan URL tersebut relatif terhadap file yang berisi tautan. Karena itu, tautan dari `presentation.html` ke file SVG menggunakan `assets/resource-1.svg`, sementara tautan dari file SVG tersebut ke gambar yang disimpan di folder `assets` yang sama menggunakan `resource-4.jpg`.

## **Ekspor HTML dengan Sumber Daya yang Ditautkan**

Contoh Android Java berikut membuat direktori output, menyimpan file HTML di sana, dan menyimpan sumber daya tertaut dalam subdirektori `assets`. Berikan direktori milik aplikasi seperti `context.getFilesDir()` sebagai `applicationFilesDirectory`. Kode ini menghindari API `java.nio.file`, sehingga tetap kompatibel dengan Android `minSdk` 19.

Pengontrol menautkan sumber daya gambar, font, audio, video, dan CSS umum ketika Aspose.Slides menyediakan atau dapat menyimpulkan ekstensi file yang aman. Sumber daya yang tidak dikenali tetap disematkan.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
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
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
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

File yang tepat bergantung pada konten presentasi dan opsi ekspor. Misalnya, gambar raster biasanya diekspor sebagai JPEG atau PNG. Aspose.Slides dapat memilih codec gambar yang berbeda dari yang digunakan dalam presentasi sumber bila hal itu menghasilkan file yang lebih kecil atau lebih cocok. Gambar dengan transparansi diekspor sebagai PNG.

## **Memilih URL untuk Penyebaran**

Contoh menggunakan awalan URL relatif: `assets/`. Jika `presentation.html` dibuka dari `html-output/presentation.html`, browser memuat `html-output/assets/resource-1.svg`.

Ketika satu sumber daya tertaut merujuk ke sumber daya tertaut lain, contoh menggunakan parameter `referrer` dalam [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilinkembedcontroller/) dan mengembalikan hanya nama file. Misalnya, jika `resource-1.svg` dan `resource-4.jpg` keduanya berada di folder `assets`, file SVG harus merujuk ke `resource-4.jpg`, bukan ke `assets/resource-4.jpg`.

Gunakan awalan URL yang berbeda ketika file disebarkan di tempat lain:

- Gunakan `assets/` ketika direktori aset berada di sebelah file HTML.
- Gunakan `../assets/` ketika direktori aset satu tingkat di atas file HTML.
- Gunakan `https://cdn.example.com/presentations/job-123/assets/` ketika file diunggah ke CDN atau server file statis.

URL yang dikembalikan oleh [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilinkembedcontroller/) harus cocok dengan lokasi akhir file yang ditulis oleh [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilinkembedcontroller/). Pada aplikasi Android, gunakan penyimpanan khusus aplikasi, direktori cache, atau direktori yang diperoleh melalui Storage Access Framework sesuai alur kerja penerbitan Anda. Pada aplikasi server, gunakan direktori output unik atau awalan penyimpanan objek untuk setiap pekerjaan konversi agar tidak menimpa file dari ekspor lain.

## **Kapan Harus Menyematkan Sebaliknya**

HTML Base64 yang disematkan masih berguna ketika output harus berupa satu file, seperti lampiran email, pratinjau offline, atau dokumen yang akan dipindahkan tanpa folder aset pendukung. Sumber daya tertaut lebih cocok ketika HTML akan disajikan oleh aplikasi web, disimpan di CMS, dioptimalkan oleh pipeline build, atau di-cache oleh browser secara independen dari HTML.

## **FAQ**

**Bisakah saya mengeksternalisasi hanya gambar dan menjaga sumber daya lain tetap disematkan?**  
Ya. Dalam [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilinkembedcontroller/), kembalikan `Link` dari [LinkEmbedDecision](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/linkembeddecision/) hanya untuk tipe konten yang ingin Anda simpan sebagai file terpisah, dan kembalikan `Embed` untuk semua yang lainnya.

**Mengapa ekstensi gambar yang diekspor berbeda dari presentasi sumber?**  
Aspose.Slides dapat melakukan enkoding ulang gambar raster selama ekspor HTML untuk memperbaiki ukuran atau kompatibilitas browser. Misalnya, gambar dari file sumber dapat ditulis sebagai JPEG atau PNG tergantung pada hasil render yang diinginkan.

**Apakah URL relatif tetap berfungsi setelah saya memindahkan file HTML?**  
URL relatif hanya berfungsi bila struktur folder relatif yang sama dipertahankan. Jika HTML merujuk ke `assets/resource-1.png`, folder `assets` harus tetap berada di sebelah file HTML kecuali Anda menghasilkan awalan URL yang berbeda.

**Bisakah saya menulis sumber daya ke penyimpanan eksternal publik pada Android?**  
Ya, jika aplikasi Anda memiliki destinasi yang valid dan model izin yang sesuai untuk versi Android target. Untuk HTML yang dihasilkan dan hanya digunakan oleh aplikasi Anda, file khusus aplikasi atau direktori cache biasanya lebih sederhana. Untuk output yang terlihat oleh pengguna, gunakan lokasi yang dipilih pengguna atau pendekatan penyimpanan lain yang sesuai dengan aplikasi Anda.

**Haruskah aplikasi server menggunakan kembali folder output yang sama?**  
Tidak. Gunakan direktori output unik atau awalan penyimpanan untuk setiap pekerjaan konversi. Ini menghindari tabrakan nama file dan mencegah satu ekspor menimpa sumber daya yang dihasilkan oleh ekspor lain.