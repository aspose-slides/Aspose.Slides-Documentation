---
title: Kelola Objek Tinta Presentasi dalam JavaScript
linktitle: Kelola Tinta
type: docs
weight: 95
url: /id/nodejs-java/manage-ink/
keywords:
- tinta
- objek tinta
- jejak tinta
- kelola tinta
- gambar tinta
- menggambar
- ekspor tinta
- rendering tinta
- sembunyikan tinta
- InkOptions
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola objek tinta PowerPoint, edit jejak dan properti kuas, serta kontrol tampilan tinta selama ekspor PDF, HTML, SVG, TIFF, dan gambar dengan Aspose.Slides untuk Node.js melalui Java."
---
## **Pendahuluan**

PowerPoint menyediakan fitur tinta yang memungkinkan Anda menggambar goresan bebas. Tinta dapat digunakan untuk menyorot objek lain, menunjukkan hubungan dan proses, serta menarik perhatian ke item tertentu pada slide.

Aspose.Slides menyediakan tipe yang diperlukan untuk bekerja dengan objek tinta. Misalnya, kelas [Ink](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ink/) merepresentasikan objek tinta pada slide.

## **Perbedaan antara Objek Biasa dan Objek Tinta**

Objek pada slide PowerPoint biasanya direpresentasikan oleh objek shape. Dalam bentuk paling sederhana, shape adalah kontainer yang menentukan area objek itu sendiri (bingkainya) bersama properti seperti ukuran kontainer, bentuk, dan latar belakang. Untuk informasi lebih lanjut, lihat [Shape Layout Format](https://docs.aspose.com/slides/id/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Namun, ketika PowerPoint menangani objek tinta, ia mengabaikan semua properti bingkai objek (kontainer) kecuali ukurannya. Ukuran area kontainer ditentukan oleh metode standar [Shape.getWidth](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getWidth--) dan [Shape.getHeight](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getHeight--).

![ink_powerpoint1](ink_powerpoint1.png)

## **Jejak Tinta**

Jejak tinta adalah elemen dasar yang digunakan untuk merekam lintasan pena saat pengguna menulis tinta digital. Jejak menyimpan urutan titik yang terhubung.

Bentuk enkoding paling sederhana menentukan koordinat X dan Y setiap titik sampel. Ketika semua titik yang terhubung dirender, mereka menghasilkan gambar seperti ini:

![ink_powerpoint2](ink_powerpoint2.png)

## **Properti Kuas untuk Menggambar**

Kuas digunakan untuk menggambar garis yang menghubungkan titik-titik pada jejak tinta. Kuas memiliki warna dan ukuran masing-masing, yang direpresentasikan oleh metode [InkBrush.getColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkbrush/#getColor--) dan [InkBrush.getSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkbrush/#getSize--).

### **Atur Warna Kuas Tinta**

Kode JavaScript ini menunjukkan cara mengatur warna kuas tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Atur Ukuran Kuas Tinta**

Kode JavaScript ini menunjukkan cara mengatur ukuran kuas tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Secara umum, lebar dan tinggi kuas tidak cocok, sehingga PowerPoint tidak menampilkan ukuran kuas (bagian data yang bersangkutan berwarna abu-abu). Ketika lebar dan tinggi kuas cocok, PowerPoint menampilkan ukurannya seperti ini:

![ink_powerpoint3](ink_powerpoint3.png)

Untuk kejelasan, mari tingkatkan tinggi objek tinta dan tinjau dimensi penting:

![ink_powerpoint4](ink_powerpoint4.png)

Kontainer (bingkai) tidak memperhitungkan ukuran kuas—ia selalu mengasumsikan ketebalan garis nol (lihat gambar sebelumnya).

Oleh karena itu, untuk menentukan area yang terlihat dari seluruh objek tinta, ukuran kuas pada jejak‑jejaknya harus diperhitungkan. Di sini, objek target (jejak teks tulisan tangan) telah diskalakan ke ukuran kontainer (bingkai). Ketika ukuran kontainer berubah, ukuran kuas tetap konstan, dan sebaliknya.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint menggunakan perilaku serupa untuk objek teks:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrol Tampilan Tinta selama Ekspor dan Rendering**

Aspose.Slides menyediakan kelas [InkOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkoptions/) untuk mengendalikan bagaimana objek tinta tampil dalam output yang diekspor atau dirender. Anda dapat menggunakan propertinya untuk menyembunyikan tinta sepenuhnya atau mengubah cara operasi mask kuas tinta diinterpretasikan.

Ink options tersedia melalui opsi ekspor atau rendering untuk beberapa tipe output:

| Output | Properti opsi tinta |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

Metode [InkOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkoptions/) berikut mengekspos dua pengaturan yang sama:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkoptions/#getHideInk--) menentukan apakah objek tinta termasuk dalam output. Nilai defaultnya adalah `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) menentukan apakah operasi mask diinterpretasikan sebagai opacity saat merender kuas tinta. Nilai defaultnya adalah `true`; panggil [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) dengan `false` untuk menggunakan operasi ROP sebagai gantinya.

### **Sembunyikan Objek Tinta dalam Output PDF**

Secara default, objek tinta tetap terlihat selama ekspor. Untuk membuat output bersih tanpa anotasi tulisan tangan atau konten tinta lainnya, panggil [InkOptions.setHideInk](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) dengan `true`.

Contoh JavaScript berikut mengekspor presentasi ke PDF sambil menyembunyikan semua objek tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Sembunyikan Objek Tinta saat Merender Slide sebagai Gambar**

Untuk menyembunyikan objek tinta saat merender slide sebagai gambar bitmap, konfigurasikan [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) dan berikan opsi rendering ke [Slide.getImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-).

Contoh JavaScript berikut merender slide pertama sebagai gambar PNG tanpa objek tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Kontrol Rendering Mask Tinta**

Pengaturan [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) mengontrol bagaimana operasi mask diinterpretasikan saat merender kuas tinta. Nilai defaultnya adalah `true`, yang menggunakan opacity. Untuk menggunakan operasi ROP sebagai gantinya, panggil [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) dengan `false`.

Contoh JavaScript berikut mengekspor slide ke SVG dan menggunakan rendering berbasis ROP untuk operasi mask tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

Pengaturan yang sama dapat diterapkan melalui [TiffOptions.getInkOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) saat mengekspor presentasi atau merender slide ke TIFF.

### **Pilih untuk Menyembunyikan atau Mempertahankan Tinta**

Ketika Anda memerlukan versi bersih dari presentasi beranotasi untuk distribusi tanpa tanda ulasan, panggil [InkOptions.setHideInk](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) dengan `true` selama ekspor.

Biarkan [InkOptions.getHideInk](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkoptions/#getHideInk--) pada nilai defaultnya `false` ketika anotasi tinta merupakan bagian dari konten yang diinginkan, seperti komentar ulasan, catatan tulisan tangan, penyorotan, atau gambar yang harus tetap terlihat dalam hasil yang diekspor. Hal ini memungkinkan aplikasi menghasilkan output ulasan dan final terpisah dari presentasi yang sama tanpa mengubah objek tinta sumber.

## **Tanya Jawab**

**Dapatkah saya mengubah warna atau ukuran goresan tinta yang ada?**

Ya. Dapatkan jejak dari [Ink.getTraces](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ink/#getTraces--) lalu ubah [InkTrace.getBrush](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inktrace/#getBrush--). Panggil [InkBrush.setColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) atau [InkBrush.setSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) untuk mengubah kuas.

**Apakah menyembunyikan tinta mengubah presentasi sumber?**

Tidak. Memanggil [InkOptions.setHideInk](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) hanya memengaruhi hasil yang dirender atau diekspor; ia tidak menghapus atau mengubah objek tinta dalam presentasi sumber.

**Format ekspor mana yang mendukung opsi tinta?**

Anda dapat mengonfigurasi opsi tinta untuk PDF, HTML, SVG, TIFF, dan gambar slide bitmap melalui opsi ekspor atau rendering yang bersesuaian yang ditunjukkan di atas.

**Bacaan Lanjutan**

* Untuk membaca tentang shape secara umum, lihat bagian [PowerPoint Shapes](https://docs.aspose.com/slides/id/nodejs-java/powerpoint-shapes/).
* Untuk informasi lebih lanjut tentang nilai efektif, lihat [Shape Effective Properties](https://docs.aspose.com/slides/id/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
* Untuk detail tentang ekspor PDF, lihat [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/id/nodejs-java/convert-powerpoint-to-pdf/).
* Untuk detail tentang ekspor HTML, lihat [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/id/nodejs-java/convert-powerpoint-to-html/).
* Untuk detail tentang ekspor SVG, lihat [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/id/nodejs-java/render-a-slide-as-an-svg-image/).
* Untuk detail tentang ekspor TIFF, lihat [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/id/nodejs-java/convert-powerpoint-to-tiff/).
* Untuk detail tentang rendering slide ke gambar, lihat [Convert Presentation Slides to Images](https://docs.aspose.com/slides/id/nodejs-java/convert-slide/).