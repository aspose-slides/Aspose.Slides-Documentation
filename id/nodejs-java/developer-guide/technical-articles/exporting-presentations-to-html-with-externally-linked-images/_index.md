---
title: Ekspor Presentasi ke HTML dengan Gambar yang Ditautkan Secara Eksternal
type: docs
weight: 100
url: /id/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
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
- gambar yang ditautkan
- gambar yang ditautkan secara eksternal
- sumber daya yang ditautkan
- sumber daya eksternal
- JavaScript
- Node.js
- Aspose.Slides
description: "Ekspor presentasi PowerPoint dan OpenDocument ke HTML dalam JavaScript menggunakan Aspose.Slides untuk Node.js via Java dengan gambar dan sumber daya lainnya disimpan sebagai berkas eksternal yang ditautkan."
---
## **Gambaran Umum**

Secara default, Aspose.Slides mengekspor presentasi ke file HTML yang berdiri sendiri. Gambar dan sumber daya lain ditulis langsung ke dalam HTML, biasanya sebagai data Base64. Ini memudahkan ketika Anda memerlukan satu file yang dapat dipindahkan, tetapi tidak selalu menjadi format terbaik untuk situs web, CMS, atau alur kerja konversi sisi server.

Gunakan sumber daya yang ditautkan secara eksternal ketika Anda ingin:

- mengurangi ukuran dokumen HTML;
- menyimpan gambar, font, audio, atau video secara terpisah di browser atau CDN;
- memeriksa, mengganti, mengompresi, atau memproses lanjutan sumber daya yang dihasilkan setelah ekspor;
- menjaga struktur output lebih mirip dengan yang diharapkan oleh aplikasi web.

Untuk alur kerja konversi HTML secara umum, lihat [Convert PowerPoint Presentations to HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/). Artikel ini fokus pada bagian penautan sumber daya dalam proses ekspor.

## **Bagaimana Ekspor Sumber Daya yang Ditautkan Bekerja**

Proxy Java untuk [ILinkEmbedController](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) memungkinkan aplikasi Anda memutuskan, sumber daya per sumber daya, apakah pengekspor menanamkan data ke dalam HTML atau menyimpannya secara eksternal dan menulis tautan.

Pengontrol memiliki tiga metode:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) menentukan apakah suatu sumber daya harus ditautkan atau disematkan.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) mengembalikan URL yang akan ditulis ke HTML yang dihasilkan atau ke sumber daya terhubung lainnya.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) menulis data sumber daya yang ditautkan ke disk atau ke target penyimpanan lainnya.

Jalur sistem file dan URL browser merupakan hal yang terpisah. Misalnya, contoh di bawah menulis file sumber daya ke `html-output/assets` di disk, sementara HTML berisi URL relatif seperti `assets/resource-1.svg`. Browser menyelesaikan URL tersebut relatif terhadap file yang berisi tautan. Oleh karena itu, tautan dari `presentation.html` ke file SVG menggunakan `assets/resource-1.svg`, sementara tautan dari file SVG tersebut ke gambar yang disimpan di folder `assets` yang sama menggunakan `resource-4.jpg`.

## **Ekspor HTML dengan Sumber Daya yang Ditautkan**

Contoh JavaScript berikut membuat direktori output, menyimpan file HTML di sana, dan menyimpan sumber daya yang ditautkan di subdirektori `assets`. Pengontrol menautkan sumber daya gambar, font, audio, video, dan CSS yang umum ketika Aspose.Slides menyediakan atau dapat menyimpulkan ekstensi berkas yang aman. Sumber daya yang tidak dikenali tetap disematkan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
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

Berkas yang tepat bergantung pada konten presentasi dan opsi ekspor. Misalnya, gambar raster biasanya diekspor sebagai JPEG atau PNG. Aspose.Slides dapat memilih codec gambar yang berbeda dari yang digunakan dalam presentasi sumber ketika hal itu menghasilkan berkas yang lebih kecil atau lebih cocok. Gambar dengan transparansi diekspor sebagai PNG.

## **Memilih URL untuk Penyebaran**

Contoh tersebut menggunakan prefiks URL relatif: `assets/`. Jika `presentation.html` dibuka dari `html-output/presentation.html`, browser memuat `html-output/assets/resource-1.svg`.

Ketika satu sumber daya yang ditautkan merujuk ke sumber daya yang ditautkan lainnya, contoh menggunakan parameter `referrer` dalam [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) dan mengembalikan hanya nama berkas. Misalnya, jika `resource-1.svg` dan `resource-4.jpg` keduanya berada di folder `assets`, file SVG harus merujuk ke `resource-4.jpg`, bukan ke `assets/resource-4.jpg`.

Gunakan prefiks URL yang berbeda ketika berkas disebarkan ke tempat lain:

- Gunakan `assets/` ketika direktori aset berada di samping file HTML.
- Gunakan `../assets/` ketika direktori aset berada satu tingkat di atas file HTML.
- Gunakan `https://cdn.example.com/presentations/job-123/assets/` ketika berkas diunggah ke CDN atau server berkas statis.

URL yang dikembalikan oleh [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/) harus cocok dengan lokasi akhir penyebaran berkas yang ditulis oleh [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/). Pada aplikasi server, gunakan direktori output unik atau prefiks penyimpanan objek untuk setiap pekerjaan konversi guna menghindari penimpaan berkas dari ekspor lain.

## **Kapan Harus Menyematkan Sebagai Ganti**

HTML Base64 yang disematkan masih berguna ketika output harus berupa satu berkas, seperti lampiran email, pratinjau offline, atau dokumen yang akan dipindahkan tanpa folder aset pendukung. Sumber daya yang ditautkan lebih cocok ketika HTML akan disajikan oleh aplikasi web, disimpan dalam CMS, dioptimalkan oleh pipeline build, atau di-cache oleh browser secara independen dari HTML.

## **FAQ**

**Apakah saya dapat mengeksternalisasi hanya gambar dan tetap menyematkan sumber daya lainnya?**

Ya. Dalam [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinkembedcontroller/), kembalikan `LinkEmbedDecision.Link` hanya untuk tipe konten yang ingin Anda simpan sebagai berkas terpisah, dan kembalikan `LinkEmbedDecision.Embed` untuk semuanya yang lain.

**Mengapa ekstensi gambar yang diekspor berbeda dari presentasi sumber?**

Aspose.Slides dapat meng-encode ulang gambar raster selama ekspor HTML untuk memperbaiki ukuran atau kompatibilitas browser. Misalnya, gambar dari berkas sumber dapat ditulis sebagai JPEG atau PNG tergantung pada hasil render.

**Apakah URL relatif tetap berfungsi setelah saya memindahkan file HTML?**

URL relatif hanya berfungsi ketika struktur folder relatif yang sama dipertahankan. Jika HTML merujuk ke `assets/resource-1.png`, folder `assets` harus tetap berada di samping file HTML kecuali Anda menghasilkan prefiks URL yang berbeda.

**Haruskah aplikasi server menggunakan kembali folder output yang sama?**

Tidak. Gunakan direktori output unik atau prefiks penyimpanan untuk setiap pekerjaan konversi. Hal ini menghindari bentrok nama berkas dan mencegah satu ekspor menimpa sumber daya yang dihasilkan oleh ekspor lain.