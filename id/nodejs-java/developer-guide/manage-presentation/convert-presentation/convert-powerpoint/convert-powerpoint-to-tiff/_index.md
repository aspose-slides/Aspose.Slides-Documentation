---
title: Mengonversi Presentasi PowerPoint ke TIFF dengan JavaScript
titlelink: PowerPoint ke TIFF
type: docs
weight: 90
url: /id/nodejs-java/convert-powerpoint-to-tiff/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mudah mengonversi presentasi PowerPoint (PPT, PPTX) ke gambar TIFF berkualitas tinggi menggunakan Aspose.Slides untuk Node.js, dengan contoh kode JavaScript."
---
## **Pendahuluan**

TIFF (**Tagged Image File Format**) adalah format gambar raster lossless yang banyak digunakan, dikenal karena kualitasnya yang luar biasa dan preservasi detail grafis. Desainer, fotografer, dan desktop publisher sering memilih TIFF untuk mempertahankan lapisan, akurasi warna, dan pengaturan asli pada gambar mereka.

Dengan menggunakan Aspose.Slides, Anda dapat dengan mudah mengonversi slide PowerPoint Anda (PPT, PPTX) dan slide OpenDocument (ODP) langsung menjadi gambar TIFF berkualitas tinggi, memastikan presentasi Anda mempertahankan fidelitas visual maksimum.

## **Mengonversi Presentasi ke TIFF**

Dengan menggunakan metode [save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/), Anda dapat dengan cepat mengonversi seluruh presentasi PowerPoint ke TIFF. Gambar TIFF yang dihasilkan sesuai dengan ukuran slide default.

Kode JavaScript ini menunjukkan cara mengonversi presentasi PowerPoint ke TIFF:

```js
// Instansiasi kelas Presentation yang mewakili file presentasi (PPT, PPTX, ODP, dll).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Simpan presentasi sebagai TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Mengonversi Presentasi ke TIFF Hitam-putih**

Metode [setBwConversionMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) pada kelas [TiffOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/) memungkinkan Anda menentukan algoritma yang digunakan saat mengonversi slide atau gambar berwarna menjadi TIFF hitam-putih. Perlu dicatat bahwa pengaturan ini hanya berlaku ketika metode [setCompressionType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) disetel ke `CCITT4` atau `CCITT3`.

Misalkan kita memiliki file "sample.pptx" dengan slide berikut:

![Sebuah slide presentasi](slide_black_and_white.png)

Kode JavaScript ini menunjukkan cara mengonversi slide berwarna menjadi TIFF hitam-putih:

```js
let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![TIFF Hitam-putih](TIFF_black_and_white.png)

## **Mengonversi Presentasi ke TIFF dengan Ukuran Kustom**

Jika Anda memerlukan gambar TIFF dengan dimensi tertentu, Anda dapat mengatur nilai yang diinginkan menggunakan metode yang tersedia di [TiffOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/). Misalnya, metode [setImageSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/#setImageSize) memungkinkan Anda menentukan ukuran gambar yang dihasilkan.

Kode JavaScript ini menunjukkan cara mengonversi presentasi PowerPoint menjadi gambar TIFF dengan ukuran kustom:

```js
// Instansiasi kelas Presentation yang mewakili file presentasi (PPT, PPTX, ODP, dll).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Setel jenis kompresi.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
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

    // Setel DPI gambar.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Setel ukuran gambar.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Simpan presentasi sebagai TIFF dengan ukuran yang ditentukan.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Mengonversi Presentasi ke TIFF dengan Format Piksel Gambar Kustom**

Dengan menggunakan metode [setPixelFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) dari kelas [TiffOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tiffoptions/), Anda dapat menentukan format piksel yang Anda inginkan untuk gambar TIFF yang dihasilkan.

Kode JavaScript ini menunjukkan cara mengonversi presentasi PowerPoint menjadi gambar TIFF dengan format piksel kustom:

```js
// Instansiasi kelas Presentation yang mewakili file presentasi (PPT, PPTX, ODP, dll).
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat berisi nilai-nilai berikut (seperti yang tercantum dalam dokumentasi):
        Format1bppIndexed - 1 bit per piksel, terindeks.
        Format4bppIndexed - 4 bit per piksel, terindeks.
        Format8bppIndexed - 8 bit per piksel, terindeks.
        Format24bppRgb    - 24 bit per piksel, RGB.
        Format32bppArgb   - 32 bit per piksel, ARGB.
    */

    /// Simpan presentasi sebagai TIFF dengan ukuran gambar yang ditentukan.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Lihat [konverter PowerPoint ke Poster GRATIS](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online) Aspose.
{{% /alert %}}

## **Tanya Jawab**

**Apakah saya dapat mengonversi slide individual alih-alih seluruh presentasi PowerPoint ke TIFF?**  
Ya. Aspose.Slides memungkinkan Anda mengonversi slide individual dari presentasi PowerPoint dan OpenDocument menjadi gambar TIFF secara terpisah.

**Apakah ada batasan jumlah slide saat mengonversi presentasi ke TIFF?**  
Tidak, Aspose.Slides tidak memberlakukan batasan apa pun pada jumlah slide. Anda dapat mengonversi presentasi dengan ukuran berapa pun ke format TIFF.

**Apakah animasi dan efek transisi PowerPoint tetap terjaga saat mengonversi slide ke TIFF?**  
Tidak, TIFF adalah format gambar statis. Oleh karena itu, animasi dan efek transisi tidak dipertahankan; hanya snapshot statis dari slide yang diekspor.