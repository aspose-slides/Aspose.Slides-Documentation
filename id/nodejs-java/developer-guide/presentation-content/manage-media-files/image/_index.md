---
title: Optimalkan Manajemen Gambar dalam Presentasi Menggunakan JavaScript
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/nodejs-java/image/
keywords:
- tambahkan gambar
- tambahkan foto
- tambahkan bitmap
- ganti gambar
- ganti foto
- dari web
- latar belakang
- tambahkan PNG
- tambahkan JPG
- tambahkan SVG
- sumber daya SVG eksternal
- penyelesai SVG
- gambar SVG tertaut
- font SVG
- tambahkan EMF
- tambahkan WMF
- tambahkan TIFF
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Permudah manajemen gambar dalam PowerPoint dan OpenDocument dengan Aspose.Slides untuk Node.js via Java, mengoptimalkan kinerja dan mengotomatisasi alur kerja Anda."
---
## **Pendahuluan**

Gambar membuat presentasi lebih menarik dan visual. Di Microsoft PowerPoint, Anda dapat menyisipkan gambar ke slide dari file, internet, atau sumber lain. Demikian pula, Aspose.Slides memungkinkan Anda menambahkan gambar ke slide presentasi dengan beberapa cara.

{{% alert  title="Tip" color="primary" %}} 

Aspose menyediakan konverter gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan Anda cepat membuat presentasi dari gambar. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Jika Anda ingin menambahkan gambar sebagai bingkai gambar—khususnya jika Anda berencana mengubah ukurannya, menerapkan efek, atau menggunakan opsi pemformatan standar lainnya—lihat [Bingkai Gambar](/slides/id/nodejs-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Anda dapat mengonversi gambar dari satu format ke format lain. Lihat halaman berikut: konversi [gambar ke JPG](https://products.aspose.com/slides/id/nodejs-java/conversion/image-to-jpg/), [JPG ke gambar](https://products.aspose.com/slides/id/nodejs-java/conversion/jpg-to-image/), [JPG ke PNG](https://products.aspose.com/slides/id/nodejs-java/conversion/jpg-to-png/), [PNG ke JPG](https://products.aspose.com/slides/id/nodejs-java/conversion/png-to-jpg/), [PNG ke SVG](https://products.aspose.com/slides/id/nodejs-java/conversion/png-to-svg/), dan [SVG ke PNG](https://products.aspose.com/slides/id/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides mendukung gambar dalam format populer seperti JPEG, PNG, BMP, GIF, dan lainnya. 

## **Menambahkan Gambar yang Disimpan Secara Lokal ke Slide**

Anda dapat menambahkan satu atau beberapa gambar yang disimpan di komputer Anda ke slide presentasi. Kode contoh JavaScript berikut menunjukkan cara menambahkan gambar ke slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Menambahkan Gambar dari Web ke Slide**

Jika gambar yang ingin Anda tambahkan ke slide tidak disimpan di komputer Anda, Anda dapat menambahkannya langsung dari web. 

Kode contoh JavaScript berikut menunjukkan cara menambahkan gambar dari web ke slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Menambahkan Gambar ke Slide Master**

Slide master menyimpan dan mengontrol informasi seperti tema dan tata letak untuk slide yang menggunakan master tersebut. Saat Anda menambahkan gambar ke slide master, gambar akan muncul di setiap slide yang didasarkan pada master itu. 

Kode contoh JavaScript berikut menunjukkan cara menambahkan gambar ke slide master:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Menambahkan Gambar sebagai Latar Belakang Slide**

Anda dapat menggunakan gambar sebagai latar belakang untuk satu atau lebih slide. Untuk detailnya, lihat *[Mengatur Gambar sebagai Latar Belakang untuk Slide](/slides/id/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Menambahkan SVG ke Presentasi**

Konten SVG dapat ditambahkan ke presentasi menggunakan kelas [SvgImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/svgimage/). Objek gambar SVG yang dihasilkan kemudian dapat ditambahkan ke koleksi gambar presentasi dan digunakan untuk membuat bingkai gambar.

Kode contoh JavaScript berikut mengimpor string SVG yang berdiri sendiri. Semua gambar, gaya, dan sumber daya lain yang digunakan oleh SVG ini disematkan langsung dalam konten SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengimpor Konten SVG dengan Sumber Daya Eksternal**

File SVG yang diekspor dari alat desain, editor diagram, sistem ikon, dan pipeline web dapat merujuk pada sumber daya yang disimpan di luar dokumen SVG. Misalnya, SVG dapat berisi tautan gambar seperti `images/photo.png`, nilai CSS `url(...)`, atau URL font.

Untuk mengimpor konten SVG semacam itu, sediakan penyelesai sumber daya eksternal dan berikan bersama URI dasar ke konstruktor [SvgImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/svgimage/) yang sesuai. URI dasar mengidentifikasi lokasi dokumen SVG dan digunakan untuk menyelesaikan tautan relatif.

Kelas `SvgImage` menyediakan akses ke informasi tentang SVG yang diimpor:

- `getSvgContent()` mengembalikan markup SVG sebagai string.
- `getSvgData()` mengembalikan konten SVG sebagai array byte.
- `getBaseUri()` mengembalikan URI dasar yang digunakan untuk tautan relatif.
- `getExternalResourceResolver()` mengembalikan penyelesai yang ditetapkan ke gambar SVG.

### **Menerapkan Penyelesai Sumber Daya Eksternal**

Penyelesai memiliki dua metode:

- `resolveUri` menggabungkan URI dasar dan tautan sumber daya relatif serta mengembalikan URI absolut. Kembalikan `null` bila tautan tidak dapat diselesaikan atau tidak diizinkan.
- `getEntity` mengembalikan aliran Java yang dapat dibaca untuk URI sumber daya absolut. Kembalikan `null` bila sumber daya tidak ada, diblokir, atau tidak tersedia. Aliran cadangan juga dapat dikembalikan bila diperlukan.

Helper berikut membuat penyelesai yang memuat sumber daya tertaut hanya dari direktori lokal yang diizinkan. Sumber daya jaringan dan jalur di luar direktori yang diizinkan diblokir. Gambar cadangan opsional dikembalikan untuk tautan gambar yang tidak terpecahkan.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Penyelesai ini sengaja memungkinkan hanya file lokal.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Gunakan fallback hanya untuk sumber daya gambar. Mengembalikan aliran gambar
                // untuk font atau stylesheet yang hilang tidak akan valid.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Menyelesaikan Sumber Daya Tertaut Selama Impor SVG**

Asumsikan bahwa `assets/diagram.svg` berisi referensi relatif seperti:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Contoh JavaScript berikut memberikan URI file SVG sebagai URI dasar dan menyediakan penyelesai khusus. Penyelesai mengubah tautan gambar relatif menjadi URI absolut dan mengembalikan aliran yang berisi sumber daya tertaut sementara Aspose.Slides memproses SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// URI dasar mewakili lokasi dokumen SVG.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage mengekspos konten sumber, data biner, URI dasar, dan penyelesai.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kelas `SvgImage` juga menyediakan overload yang menerima data SVG sebagai array byte, serta metode pabrik berbasis aliran, bersama dengan penyelesai sumber daya eksternal dan URI dasar.

{{% alert title="Important" color="warning" %}}

Penyelesai sumber daya membuat sumber daya eksternal tersedia saat Aspose.Slides memproses dan merender SVG. Ia tidak mengubah markup SVG asli atau secara otomatis menyematkan sumber daya yang telah diselesaikan ke dalamnya.

Ketika gambar SVG ditambahkan ke koleksi gambar presentasi, file PPTX dapat berisi representasi SVG asli serta gambar raster cadangan. Sumber daya tertaut dapat muncul dalam gambar cadangan yang dihasilkan sementara tautan relatif seperti `images/photo.png` tetap tidak berubah dalam SVG yang disimpan. Aplikasi yang merender representasi SVG asli mungkin mengabaikan konten tertaut ketika sumber daya eksternal asli tidak tersedia.

{{% /alert %}}

### **Membuat Gambar SVG Portabel**

Untuk membuat gambar SVG yang tidak bergantung pada file eksternal, jadikan SVG berdiri sendiri sebelum membuat `SvgImage`. Misalnya, ganti URL gambar tertaut dengan URI `data:` yang berisi data gambar:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Setelah semua sumber daya yang diperlukan disematkan dalam konten SVG, buat `SvgImage`, tambahkan ke koleksi gambar presentasi, dan sisipkan ke dalam bingkai gambar seperti pada contoh sebelumnya.

### **Menangani Sumber Daya yang Hilang atau Diblokir**

Kembalikan `null` dari `resolveUri` bila URI sumber daya tidak valid, dilarang, atau tidak dapat diselesaikan. Kembalikan `null` dari `getEntity` bila sumber daya tidak dapat dibaca. Aspose.Slides melanjutkan pemrosesan SVG tanpa sumber daya tersebut bila memungkinkan.

Aliran cadangan dapat dikembalikan untuk sumber daya yang hilang, tetapi isinya harus cocok dengan tipe sumber daya yang diminta. Misalnya, kembalikan aliran gambar hanya untuk gambar yang hilang, bukan untuk font atau stylesheet.

{{% alert title="Security" color="warning" %}}

Jangan menyelesaikan jalur file arbitrer atau URL jaringan tanpa batas dari file SVG yang tidak terpercaya. Batasi skema, direktori, dan host yang diizinkan. Untuk sumber daya jaringan, terapkan batas waktu koneksi, batas ukuran respons, dan validasi konten.

{{% /alert %}}

## **Mengonversi SVG menjadi Sekelompok Bentuk**

Aspose.Slides dapat mengonversi SVG menjadi sekumpulan bentuk, mirip dengan fungsi yang ada di PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Fungsionalitas ini disediakan oleh overload metode [addGroupShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) pada kelas [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection) yang menerima objek gambar SVG sebagai argumen pertama.

Kode contoh JavaScript berikut menunjukkan cara menggunakan metode ini untuk mengonversi file SVG menjadi sekumpulan bentuk:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Nama file SVG sumber.
const svgFileName = "sample.svg";

// Nama file presentasi output.
const outPptxPath = "presentation.pptx";

// Membuat presentasi baru.
const presentation = new aspose.slides.Presentation();
try {
    // Membaca konten file SVG.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Membuat objek SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Mendapatkan ukuran slide.
    const slideSize = presentation.getSlideSize().getSize();

    // Mengonversi gambar SVG menjadi grup bentuk dan menskalakan ke ukuran slide.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Menyimpan presentasi dalam format PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menambahkan Gambar sebagai EMF ke Slide**

Aspose.Slides untuk Node.js via Java memungkinkan Anda menghasilkan gambar EMF dari lembar kerja Excel dengan Aspose.Cells dan menambahkannya ke slide presentasi.

Kode contoh JavaScript berikut menunjukkan cara melakukannya:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Menyimpan workbook ke aliran.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Tambahkan file apa adanya sehingga gambar tetap vektor EMF dan tidak di‑rasterkan.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Mengganti Gambar dalam Koleksi Gambar**

Aspose.Slides memungkinkan Anda mengganti gambar yang disimpan dalam koleksi gambar presentasi, termasuk gambar yang digunakan oleh bentuk slide. Bagian ini menjelaskan beberapa cara memperbarui gambar dalam koleksi. Anda dapat mengganti gambar menggunakan data byte mentah, instance [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/), atau gambar lain yang sudah ada dalam koleksi.

Ikuti langkah‑langkah berikut:

1. Muat file presentasi yang berisi gambar menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Muat gambar baru dari file ke dalam array byte.
3. Ganti gambar target dengan gambar baru menggunakan array byte.
4. Pada pendekatan kedua, muat gambar ke dalam objek [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/) dan ganti gambar target dengan objek tersebut.
5. Pada pendekatan ketiga, ganti gambar target dengan gambar yang sudah ada dalam koleksi gambar presentasi.
6. Tulis kembali presentasi yang telah dimodifikasi sebagai file PPTX.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Buat instance kelas Presentation yang mewakili file presentasi.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Cara pertama.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Cara kedua.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // Cara ketiga.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Simpan presentasi ke file.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Dengan konverter gratis Aspose [Text to GIF](https://products.aspose.app/slides/id/text-to-gif), Anda dapat dengan mudah menganimasikan teks dan membuat GIF dari teks. 

{{% /alert %}}

## **FAQ**

**Apakah resolusi gambar asli tetap utuh setelah penyisipan?**

Ya. Piksel sumber dipertahankan, tetapi penampilan akhir tergantung pada cara [gambar](/slides/id/nodejs-java/picture-frame/) diubah skalanya pada slide dan kompresi yang diterapkan saat penyimpanan.

**Apa cara terbaik untuk mengganti logo yang sama di puluhan slide sekaligus?**

Letakkan logo pada slide master atau layout dan ganti dalam koleksi gambar presentasi—perubahan akan menyebar ke semua elemen yang menggunakan sumber daya tersebut.

**Bisakah SVG yang disisipkan diubah menjadi bentuk yang dapat diedit?**

Ya. Anda dapat mengonversi SVG menjadi grup bentuk, setelah itu bagian individu dapat diedit dengan properti bentuk standar.

**Bagaimana cara mengatur gambar sebagai latar belakang untuk beberapa slide sekaligus?**

[Tetapkan gambar sebagai latar belakang](/slides/id/nodejs-java/presentation-background/) pada slide master atau layout yang relevan—setiap slide yang menggunakan master/layout tersebut akan mewarisi latar belakang.

**Bagaimana cara mencegah presentasi menjadi terlalu besar karena banyak gambar?**

Gunakan satu sumber gambar secara ulang alih-alih duplikat, pilih resolusi yang wajar, terapkan kompresi saat penyimpanan, dan simpan grafis berulang pada master bila sesuai.