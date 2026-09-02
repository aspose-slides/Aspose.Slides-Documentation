---
title: Kelola Objek Tinta Presentasi di PHP
linktitle: Kelola Tinta
type: docs
weight: 95
url: /id/php-java/manage-ink/
keywords:
- tinta
- objek tinta
- jejak tinta
- kelola tinta
- gambar tinta
- menggambar
- ekspor tinta
- render tinta
- sembunyikan tinta
- InkOptions
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Kelola objek tinta PowerPoint, edit jejak dan properti kuas, serta kontrol tampilan tinta selama ekspor PDF, HTML, SVG, TIFF, dan gambar dengan Aspose.Slides untuk PHP via Java."
---
## **Pendahuluan**

PowerPoint menyediakan fitur tinta yang memungkinkan Anda menggambar goresan bebas. Tinta dapat digunakan untuk menyorot objek lain, menunjukkan koneksi dan proses, serta menarik perhatian pada item tertentu di slide.

Aspose.Slides menyediakan tipe yang diperlukan untuk bekerja dengan objek tinta. Misalnya, kelas [Ink](https://reference.aspose.com/slides/id/php-java/aspose.slides/ink/) mewakili objek tinta pada slide.

## **Perbedaan antara Objek Biasa dan Objek Tinta**

Objek pada slide PowerPoint biasanya direpresentasikan oleh objek [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) . Dalam bentuk paling sederhana, sebuah shape adalah kontainer yang mendefinisikan area objek itu sendiri (frame-nya) bersama properti seperti ukuran kontainer, bentuk, dan latar belakang. Untuk informasi lebih lanjut, lihat [Shape Layout Format](https://docs.aspose.com/slides/id/php-java/shape-manipulations/#access-layout-formats-for-shape).

Namun, ketika PowerPoint menangani objek tinta, ia mengabaikan semua properti frame objek (kontainer) kecuali ukurannya. Ukuran area kontainer ditentukan oleh metode standar [Shape.getWidth](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getWidth) dan [Shape.getHeight](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Jejak Tinta**

Jejak tinta adalah elemen dasar yang digunakan untuk merekam lintasan pena saat pengguna menulis tinta digital. Sebuah jejak menyimpan urutan titik yang terhubung.

Bentuk enkoding paling sederhana menentukan koordinat X dan Y setiap titik sampel. Ketika semua titik terhubung dirender, mereka menghasilkan gambar seperti ini:

![ink_powerpoint2](ink_powerpoint2.png)

## **Properti Kuas untuk Menggambar**

Kuas digunakan untuk menggambar garis yang menghubungkan titik-titik jejak tinta. Kuas memiliki warna dan ukuran sendiri, yang direpresentasikan oleh metode [InkBrush.getColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkbrush/#getColor) dan [InkBrush.getSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkbrush/#getSize).

### **Atur Warna Kuas Tinta**

Kode PHP berikut menunjukkan cara mengatur warna kuas tinta:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Atur Ukuran Kuas Tinta**

Kode PHP berikut menunjukkan cara mengatur ukuran kuas tinta:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

Umumnya, lebar dan tinggi sebuah kuas tidak sama, sehingga PowerPoint tidak menampilkan ukuran kuas (bagian data yang bersangkutan berwarna abu-abu). Ketika lebar dan tinggi kuas sama, PowerPoint menampilkan ukurannya seperti ini:

![ink_powerpoint3](ink_powerpoint3.png)

Untuk kejelasan, mari tingkatkan tinggi objek tinta dan tinjau dimensi penting:

![ink_powerpoint4](ink_powerpoint4.png)

Kontainer (frame) tidak memperhitungkan ukuran kuas—selalu mengasumsikan bahwa ketebalan garis adalah nol (lihat gambar sebelumnya).

Oleh karena itu, untuk menentukan area yang terlihat dari seluruh objek tinta, ukuran kuas dari jejaknya harus diperhitungkan. Di sini, objek target (jejak teks tulisan tangan) telah diskalakan ke ukuran kontainer (frame). Ketika ukuran kontainer berubah, ukuran kuas tetap konstan, dan sebaliknya.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint menggunakan perilaku serupa untuk objek teks:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrol Penampilan Tinta Selama Ekspor dan Rendering**

Aspose.Slides menyediakan kelas [InkOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkoptions/) untuk mengontrol bagaimana objek tinta muncul dalam output yang diekspor atau dirender. Anda dapat menggunakan properti-propertinya untuk menyembunyikan tinta sepenuhnya atau mengubah cara operasi mask kuas tinta diinterpretasikan.

Opsi tinta tersedia melalui opsi ekspor atau rendering untuk beberapa jenis output:

| Output | Properti opsi tinta |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/renderingoptions/#getInkOptions) |

Metode [InkOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkoptions/) berikut mengekspos dua pengaturan yang sama:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkoptions/#getHideInk) menentukan apakah objek tinta disertakan dalam output. Nilai defaultnya adalah `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) menentukan apakah operasi mask diinterpretasikan sebagai opasitas saat merender kuas tinta. Nilai defaultnya adalah `true`; panggil [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) dengan `false` untuk menggunakan operasi ROP sebagai gantinya.

### **Sembunyikan Objek Tinta dalam Output PDF**

Secara default, objek tinta tetap terlihat selama ekspor. Untuk membuat output bersih tanpa anotasi tulisan tangan atau konten tinta lainnya, panggil [InkOptions.setHideInk](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkoptions/#setHideInk) dengan `true`.

Contoh PHP berikut mengekspor presentasi ke PDF sambil menyembunyikan semua objek tinta:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Sembunyikan Objek Tinta Saat Merender Slide sebagai Gambar**

Untuk menyembunyikan objek tinta saat merender slide sebagai gambar bitmap, konfigurasikan [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/renderingoptions/#getInkOptions) dan berikan opsi rendering ke [Slide.getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getImage).

Contoh PHP berikut merender slide pertama sebagai gambar PNG tanpa objek tinta:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Kontrol Rendering Mask Tinta**

Pengaturan [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) mengontrol bagaimana operasi mask diinterpretasikan saat merender kuas tinta. Nilai defaultnya adalah `true`, yang menggunakan opasitas. Untuk menggunakan operasi ROP sebagai gantinya, panggil [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) dengan `false`.

Contoh PHP berikut mengekspor slide ke SVG dan menggunakan rendering berbasis ROP untuk operasi mask tinta:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Pengaturan yang sama dapat diterapkan melalui [TiffOptions.getInkOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/#getInkOptions) saat mengekspor presentasi atau merender slide ke TIFF.

### **Pilih untuk Menyembunyikan atau Mempertahankan Tinta**

Ketika Anda memerlukan versi bersih dari presentasi beranotasi untuk distribusi tanpa tanda ulasan, panggil [InkOptions.setHideInk](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkoptions/#setHideInk) dengan `true` selama ekspor.

Biarkan [InkOptions.getHideInk](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkoptions/#getHideInk) pada nilai defaultnya `false` ketika anotasi tinta merupakan bagian dari konten yang diinginkan, seperti komentar ulasan, catatan tulisan tangan, penyorotan, atau gambar yang harus tetap terlihat dalam hasil ekspor. Ini memungkinkan aplikasi menghasilkan output ulasan dan final terpisah dari presentasi yang sama tanpa memodifikasi objek tinta sumber.

## **FAQ**

**Apakah saya dapat mengubah warna atau ukuran goresan tinta yang ada?**

Ya. Dapatkan jejak dari [Ink.getTraces](https://reference.aspose.com/slides/id/php-java/aspose.slides/ink/#getTraces), kemudian ubah [InkTrace.getBrush](https://reference.aspose.com/slides/id/php-java/aspose.slides/inktrace/#getBrush). Panggil [InkBrush.setColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkbrush/#setColor) atau [InkBrush.setSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkbrush/#setSize) untuk mengubah kuas.

**Apakah menyembunyikan tinta mengubah presentasi sumber?**

Tidak. Memanggil [InkOptions.setHideInk](https://reference.aspose.com/slides/id/php-java/aspose.slides/inkoptions/#setHideInk) hanya memengaruhi hasil yang dirender atau diekspor; tidak menghapus atau memodifikasi objek tinta dalam presentasi sumber.

**Format ekspor mana yang mendukung opsi tinta?**

Anda dapat mengonfigurasi opsi tinta untuk PDF, HTML, SVG, TIFF, dan gambar slide bitmap melalui opsi ekspor atau rendering yang bersangkutan seperti yang ditunjukkan di atas.

**Bacaan Lanjutan**

* Untuk membaca tentang shape secara umum, lihat bagian [PowerPoint Shapes](https://docs.aspose.com/slides/id/php-java/powerpoint-shapes/).
* Untuk informasi lebih lanjut tentang nilai efektif, lihat [Shape Effective Properties](https://docs.aspose.com/slides/id/php-java/shape-effective-properties/#get-effective-font-height-value).
* Untuk detail ekspor PDF, lihat [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/id/php-java/convert-powerpoint-to-pdf/).
* Untuk detail ekspor HTML, lihat [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/id/php-java/convert-powerpoint-to-html/).
* Untuk detail ekspor SVG, lihat [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/id/php-java/render-a-slide-as-an-svg-image/).
* Untuk detail ekspor TIFF, lihat [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/id/php-java/convert-powerpoint-to-tiff/).
* Untuk detail rendering slide-ke-gambar, lihat [Convert Presentation Slides to Images](https://docs.aspose.com/slides/id/php-java/convert-slide/).