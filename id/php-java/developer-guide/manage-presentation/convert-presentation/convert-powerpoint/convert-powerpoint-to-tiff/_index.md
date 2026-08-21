---
title: Mengonversi Presentasi PowerPoint ke TIFF dalam PHP
titlelink: PowerPoint ke TIFF
type: docs
weight: 90
url: /id/php-java/convert-powerpoint-to-tiff/
keywords:
- konversi PowerPoint
- konversi OpenDocument
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke TIFF
- presentasi ke TIFF
- slide ke TIFF
- PPT ke TIFF
- PPTX ke TIFF
- simpan PPT sebagai TIFF
- simpan PPTX sebagai TIFF
- ekspor PPT ke TIFF
- ekspor PPTX ke TIFF
- PHP
- Aspose.Slides
description: "Pelajari cara mengonversi presentasi PowerPoint (PPT, PPTX) menjadi gambar TIFF berkualitas tinggi menggunakan Aspose.Slides untuk PHP via Java, dengan contoh kode."
---
## **Pendahuluan**

TIFF (Tagged Image File Format) adalah format gambar raster lossless yang banyak digunakan, dikenal karena kualitas luar biasa dan preservasi detail grafis. Desainer, fotografer, dan penerbit desktop sering memilih TIFF untuk mempertahankan lapisan, akurasi warna, dan pengaturan asli pada gambar mereka.

Dengan Aspose.Slides, Anda dapat dengan mudah mengonversi slide PowerPoint (PPT, PPTX) dan slide OpenDocument (ODP) secara langsung menjadi gambar TIFF berkualitas tinggi, memastikan presentasi Anda mempertahankan fidelitas visual maksimal. 

## **Mengonversi Presentasi ke TIFF**

Dengan menggunakan metode [save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/), Anda dapat dengan cepat mengonversi seluruh presentasi PowerPoint menjadi TIFF. Gambar TIFF yang dihasilkan sesuai dengan ukuran slide default.

Kode ini menunjukkan cara mengonversi presentasi PowerPoint menjadi TIFF:

```php
// Instansiasi kelas Presentation yang mewakili file presentasi (PPT, PPTX, ODP, dll.).
$presentation = new Presentation("presentation.pptx");
try {
    // Simpan presentasi sebagai TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **Mengonversi Presentasi ke TIFF Hitam-putih**

Metode [setBwConversionMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/#setBwConversionMode) dalam kelas [TiffOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/) memungkinkan Anda menentukan algoritma yang digunakan saat mengonversi slide atau gambar berwarna menjadi TIFF hitam-putih. Perhatikan bahwa pengaturan ini hanya berlaku ketika metode [setCompressionType](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/#getCompressionType) disetel ke `CCITT4` atau `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/#setBwConversionMode) adalah pengaturan tingkat ekspor yang memilih algoritma konversi piksel untuk seluruh gambar TIFF. Untuk menentukan bagaimana bentuk individu terlihat ketika mode tampilan hitam-putih aktif, gunakan [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#setBlackWhiteMode). Lihat [Control Black-and-White Rendering for Shapes](/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) untuk contoh.
{{% /alert %}}

Misalkan kita memiliki file "sample.pptx" dengan slide berikut:

![Sebuah slide presentasi](slide_black_and_white.png)

Kode ini menunjukkan cara mengonversi slide berwarna menjadi TIFF hitam-putih:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![TIFF Hitam-putih](TIFF_black_and_white.png)

## **Mengonversi Presentasi ke TIFF dengan Ukuran Kustom**

Jika Anda memerlukan gambar TIFF dengan dimensi tertentu, Anda dapat menetapkan nilai yang diinginkan menggunakan metode yang tersedia di [TiffOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/). Misalnya, metode [setImageSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/#getImageSize) memungkinkan Anda menentukan ukuran gambar yang dihasilkan.

Kode ini menunjukkan cara mengonversi presentasi PowerPoint menjadi gambar TIFF dengan ukuran kustom:

```php
// Instansiasi kelas Presentation yang mewakili file presentasi (PPT, PPTX, ODP, dll).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Tentukan jenis kompresi.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Jenis kompresi:
        Default - Menentukan skema kompresi default (LZW).
        None - Menentukan tidak ada kompresi.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Kedalaman tergantung pada jenis kompresi dan tidak dapat diatur secara manual.

    // Tentukan DPI gambar.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Tentukan ukuran gambar.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Simpan presentasi sebagai TIFF dengan ukuran yang ditentukan.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **Mengonversi Presentasi ke TIFF dengan Format Piksel Gambar Kustom**

Dengan menggunakan metode [setPixelFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/#getPixelFormat) dari kelas [TiffOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/tiffoptions/), Anda dapat menentukan format piksel yang Anda inginkan untuk gambar TIFF yang dihasilkan.

Kode ini menunjukkan cara mengonversi presentasi PowerPoint menjadi gambar TIFF dengan format piksel kustom:

```php
// Instansiasi kelas Presentation yang mewakili file presentasi (PPT, PPTX, ODP, dll).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat berisi nilai-nilai berikut (seperti yang tercantum dalam dokumentasi):
        Format1bppIndexed - 1 bit per piksel, diindeks.
        Format4bppIndexed - 4 bit per piksel, diindeks.
        Format8bppIndexed - 8 bit per piksel, diindeks.
        Format24bppRgb    - 24 bit per piksel, RGB.
        Format32bppArgb   - 32 bit per piksel, ARGB.
    */

    // Simpan presentasi sebagai TIFF dengan ukuran gambar yang ditentukan.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="info" %}}
Lihat [konverter PowerPoint ke Poster GRATIS](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online) dari Aspose.
{{% /alert %}}

## **FAQ**

**Bisakah saya mengonversi slide individu alih-alih seluruh presentasi PowerPoint ke TIFF?**

Ya. Aspose.Slides memungkinkan Anda mengonversi slide individu dari presentasi PowerPoint dan OpenDocument menjadi gambar TIFF secara terpisah.

**Apakah ada batasan jumlah slide saat mengonversi presentasi ke TIFF?**

Tidak, Aspose.Slides tidak memberlakukan batasan apa pun pada jumlah slide. Anda dapat mengonversi presentasi dengan ukuran berapa pun ke format TIFF.

**Apakah animasi dan efek transisi PowerPoint dipertahankan saat mengonversi slide ke TIFF?**

Tidak, TIFF adalah format gambar statis. Oleh karena itu, animasi dan efek transisi tidak dipertahankan; hanya snapshot statis slide yang diekspor.