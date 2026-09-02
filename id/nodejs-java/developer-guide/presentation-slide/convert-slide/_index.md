---
title: Mengonversi Slide Presentasi menjadi Gambar dalam JavaScript
linktitle: Slide ke Gambar
type: docs
weight: 35
url: /id/nodejs-java/convert-slide/
keywords:
- konversi slide
- ekspor slide
- slide ke gambar
- simpan slide sebagai gambar
- slide ke EMF
- slide ke PNG
- slide ke JPEG
- slide ke bitmap
- slide ke TIFF
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi slide dari presentasi PPT, PPTX, dan ODP ke PNG, JPEG, GIF, TIFF, EMF, dan format gambar lainnya dalam JavaScript dengan Aspose.Slides."
---
## **Pendahuluan**

Aspose.Slides for Node.js via Java dapat merender slide individual dari presentasi PowerPoint dan OpenDocument sebagai PNG, JPEG, GIF, TIFF, dan format gambar lainnya.

Untuk mengonversi slide menjadi gambar, ikuti langkah-langkah berikut:

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Pilih slide yang ingin Anda render.
3. Jika diperlukan, konfigurasikan rendering dengan kelas [RenderingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/renderingoptions/) atau [TiffOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/).
4. Panggil metode [Slide.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#getImage). Metode ini mengembalikan objek [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/).
5. Panggil metode [IImage.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/#save) dan tentukan format output dengan nilai [ImageFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imageformat/).

## **Konversi Slide ke Gambar PNG**

Konversi paling sederhana menggunakan pengaturan rendering default. Objek [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/) yang dihasilkan dapat diproses dalam memori atau disimpan ke file.

Contoh JavaScript berikut merender slide pertama dan menyimpannya sebagai gambar PNG:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konversi Slide ke Gambar dengan Ukuran Kustom**

Gunakan overload [Slide.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#getImage) yang menerima nilai `java.awt.Dimension` untuk merender slide dengan dimensi piksel yang tepat.

Contoh berikut membuat gambar JPEG berukuran 1820 × 1040:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konversi Slide dengan Catatan dan Komentar ke Gambar**

Secara default, gambar slide tidak menyertakan catatan atau komentar. Berikan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notescommentslayoutingoptions/) ke metode [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) untuk mengontrol dimana catatan dan komentar ditampilkan.

Contoh berikut menempatkan catatan yang dipotong di bawah slide dan komentar di sebelah kanannya:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Untuk konversi slide ke gambar, jangan memberikan [BottomFull](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notespositions/) ke metode [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Catatan dapat berisi lebih banyak teks daripada ukuran gambar tetap dapat menampungnya. Gunakan [BottomTruncated](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/notespositions/) sebagai gantinya.
{{% /alert %}}

## **Konversi Slide ke Gambar dengan Opsi TIFF**

Kelas [TiffOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/) memungkinkan Anda mengontrol ukuran, resolusi, dan properti lain dari gambar TIFF yang dirender.

Contoh berikut merender slide pertama sebagai gambar TIFF 2160 × 2880 dengan 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Dukungan TIFF tidak dijamin pada versi Java sebelum JDK 9.
{{% /alert %}}

## **Konversi Semua Slide ke Gambar**

Iterasikan koleksi slide untuk mengonversi seluruh presentasi menjadi serangkaian gambar. Slide tersembunyi termasuk kecuali Anda secara eksplisit melewatkannya.

Contoh berikut merender setiap slide sebagai gambar JPEG dengan faktor skala horizontal dan vertikal 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Buat Output Enhanced Metafile**

Enhanced Metafile (EMF) berguna ketika grafik berbasis vektor harus dipertukarkan dengan Microsoft Office atau aplikasi Windows lain yang mendukung metafile Windows. Tidak seperti gambar berbasis piksel, EMF dapat mempertahankan operasi gambar vektor yang dapat diskalakan tanpa kehilangan ketajaman yang sama. Namun, EMF terutama merupakan format kompatibilitas untuk aplikasi dengan dukungan metafile Windows, bukan format pertukaran universal. Selain itu, konten slide yang kompleks, seperti gambar bitmap dan beberapa efek, dapat disimpan sebagai elemen raster di dalam kontainer metafile vektor.

### **Ekspor Slide ke EMF**

Metode [Slide.writeAsEmf](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#writeAsEmf) menulis slide ke aliran target dalam format EMF. Contoh berikut memuat presentasi, memilih slide pertama, dan menuliskannya ke aliran file EMF:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Pemanggil memiliki aliran yang diberikan ke [Slide.writeAsEmf](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#writeAsEmf) dan bertanggung jawab untuk menutupnya, seperti ditunjukkan di atas.

### **Konversi Gambar SVG ke EMF dan Tambahkan ke Presentasi**

Gunakan [SvgImage.writeAsEmf](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/svgimage/#writeAsEmf) untuk mengonversi konten SVG ke EMF. Byte hasil dapat ditambahkan ke presentasi melalui [ImageCollection.addImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagecollection/#addImage) dan ditempatkan pada slide dengan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

Contoh berikut membuat [SvgImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/svgimage/) dari markup SVG, mengonversinya menjadi EMF dalam memori, menyisipkan metafile pada slide pertama, dan menyimpan presentasi:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/svgimage/#writeAsEmf) tidak mengambil kepemilikan aliran tujuan. `java.io.ByteArrayOutputStream` menyimpan semua data yang dihasilkan dalam memori, jadi tidak diperlukan reset posisi sebelum memanggil `toByteArray`. Array byte yang dikembalikan tetap valid setelah aliran ditutup.

Generasi EMF tersedia pada sistem operasi yang didukung oleh Aspose.Slides for Node.js via Java yang dipilih serta konfigurasi JDK, tetapi rendering dapat berbeda antar platform ketika font atau dependensi grafis tidak tersedia. Instal font yang digunakan oleh konten sumber atau konfigurasikan substitusi yang sesuai, ikuti [platform requirements](/slides/id/nodejs-java/system-requirements/) untuk Aspose.Slides for Node.js via Java, dan validasi hasilnya di aplikasi yang mengonsumsi EMF target. Aplikasi Linux dan macOS sering memiliki dukungan terbatas atau tidak konsisten untuk menampilkan dan mengedit metafile Windows.

## **Rendering Emoji Berwarna**

{{% alert title="Note" color="info" %}}
Untuk merender emoji berwarna dengan benar saat mengonversi slide presentasi ke gambar, font emoji yang digunakan dalam presentasi harus diinstal dan tersedia pada sistem yang melakukan konversi. Misalnya, jika presentasi menggunakan **Segoe UI Emoji** dan font ini tidak ada, emoji dapat muncul dalam monokrom pada gambar output.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung render slide dengan animasi?**

Tidak. Metode [Slide.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#getImage) merender gambar statis slide dan tidak mengekspor animasi.

**Apakah slide tersembunyi dapat diekspor sebagai gambar?**

Ya. Slide tersembunyi dapat dirender seperti slide biasa. Sertakan mereka dalam loop pemrosesan, seperti yang ditunjukkan pada contoh di atas.

**Apakah bayangan dan efek lain dipertahankan dalam gambar slide?**

Ya. Aspose.Slides merender bayangan, transparansi, dan efek grafis lain yang didukung dalam gambar slide.