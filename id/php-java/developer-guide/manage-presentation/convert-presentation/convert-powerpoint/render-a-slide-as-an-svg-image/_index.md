---
title: Render Slide Presentasi sebagai Gambar SVG di PHP
linktitle: Slide ke SVG
type: docs
weight: 50
url: /id/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint ke SVG
- presentasi ke SVG
- slide ke SVG
- PPT ke SVG
- PPTX ke SVG
- opsi ekspor SVG
- SVG interaktif
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Ekspor slide PowerPoint sebagai gambar SVG di PHP dan kontrol font, teks, gambar, ID, serta event dengan Aspose.Slides."
---
## **Ringkasan**

SVG adalah format gambar berbasis XML yang dapat diskalakan yang bekerja dengan baik untuk penerbitan web, penampil slide, alur kerja aksesibilitas, dan pemrosesan pasca otomatis. Aspose.Slides mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol bagaimana teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di semua peramban, atau siap untuk penggunaan interaktif.

## **Ekspor Slide sebagai SVG**

Buat sebuah [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), pilih sebuah slide, dan tulis ke aliran dengan [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). Contoh berikut mengekspor setiap slide dalam presentasi sebagai file SVG terpisah.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Nama file menggunakan [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) bukan indeks perulangan. Anda juga dapat mengekspor sebuah bentuk individual dengan [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) ketika penampil slide atau halaman web hanya memerlukan bentuk tersebut.

## **Konfigurasikan Output SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) mengontrol rendering SVG. Untuk bingkai teks, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) menyertakan bingkai teks dalam area rendering, dan [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) menentukan apakah rotasi bingkai diterapkan. Atur [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) ke `true` ketika teks harus dirender tanpa ligatur.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Kontrol Pemotongan Ujung Garis pada Kepala Panah**

SVG 1.1 tidak memiliki pengaturan inset penanda untuk menentukan di mana sebuah garis harus berhenti di bawah kepala panah. Secara bawaan, Aspose.Slides memendekkan garis yang diekspor sehingga goresannya tidak menonjol melalui penanda. Panggil [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) dengan `true` untuk menggambar goresan sampai ke titik akhir asli garis. Pengaturan ini hanya memengaruhi output SVG. Garis tetap pada posisi dan panjangnya di slide.

Contoh menggambar kepala panah segitiga dan berlian pada garis lebar 2 dan 10 poin. Contoh tersebut mengekspor slide yang sama dua kali, hanya mengubah opsi pemotongan.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

Perbandingan menunjukkan kepala panah segitiga pada garis 10‑poin. Dengan pemotongan diaktifkan, ujungnya tajam. Dengan pemotongan dinonaktifkan, goresan menonjol melalui sisi miring penanda dan meninggalkan ujung datar.

![Segitiga 10-point yang diperbesar dengan ujung tajam ketika pemotongan diaktifkan dan ujung datar ketika pemotongan dinonaktifkan](line-end-cropping.png)

Pada garis lain dari contoh, goresan yang menonjol kurang terlihat pada segitiga 2‑poin. Berlian berisi menutupi ujung goresan pada kedua lebar.

## **Kontrol Teks dan Font**

Saat mengekspor slide ke SVG, Anda dapat mengontrol apakah teks tetap berupa teks atau diubah menjadi grafik vektor, serta bagaimana font eksternal disertakan atau dirujuk. Opsi berikut membantu menyeimbangkan konsistensi visual, pilihan teks, dan ketergantungan font dalam SVG yang diekspor.

### **Vektorisasi Semua Teks**

Atur [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) ke `true` untuk menulis semua teks slide sebagai grafik vektor. Ini menghilangkan ketergantungan font dan menjadikan hasil visual lebih konsisten di semua peramban, tetapi teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Pilih Cara Penanganan Font Eksternal**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih `AddLinksToFontFiles` untuk merujuk file font terpisah, `Embed` untuk menyertakan data font dalam SVG, atau `Vectorize` untuk merender hanya teks yang menggunakan font eksternal sebagai grafik. Verifikasi lisensi font sebelum menyematkan font.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Kurangi Ukuran Gambar Tersemat**

Gunakan [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) untuk mengurangi resolusi gambar tersemat, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) untuk menghilangkan area sumber yang dipotong, dan [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran berkas dengan mengorbankan ketajaman gambar atau data gambar yang dipertahankan.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Kontrol Resolusi Rasterisasi Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) menetapkan batas resolusi bawah untuk merasterkan metafile selama ekspor SVG. Gunakan untuk menyeimbangkan detail dan ukuran berkas ketika gambar EMF atau WMF dirasterkan. Ini tidak mendefinisikan DPI global untuk SVG atau memaksa setiap objek pada slide menjadi gambar raster.

Unduh [metafile-rasterization.pptx](metafile-rasterization.pptx), yang berisi gambar EMF dengan garis diagonal berjarak rapat. Contoh berikut mengekspor slide pertama dengan tiga resolusi rasterisasi melalui [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Semua pengaturan ekspor lainnya tetap identik sehingga hasil dapat dibandingkan.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

Dalam output, EMF menjadi satu PNG tersemat di setiap SVG. Pengukuran berikut untuk presentasi yang disediakan; bukan rumus umum untuk mengonversi DPI ke dimensi piksel.

| Rasterisasi Metafile DPI | Dimensi PNG Tersemat | Ukuran file SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Perbandingan di bawah menunjukkan area yang sama dari raster tersemat pada ukuran tampilan yang diperbesar. Garis diagonal menunjukkan pikselasi yang terlihat pada 72 DPI dan tepi yang lebih halus pada resolusi lebih tinggi, sementara berkas SVG bertambah. Meningkatkan nilai tidak selalu memperbaiki setiap detail atau mengubah setiap gambar yang diekspor.

![Detail garis diagonal yang diperbesar pada 72, 150, dan 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) mengontrol pengurangan resolusi gambar dan dapat menyamarkan efek perubahan resolusi rasterisasi metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) mengontrol kualitas enkoding JPEG, bukan resolusi rasterisasi metafile.

## **Tetapkan ID Stabil untuk Bentuk dan Teks**

Sediakan callback pemformatan ke [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) untuk mengatur [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) bagi setiap bentuk SVG. Callback juga dapat mengatur nilai [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) pada elemen `tspan` teks.

PhpJavaBridge tidak dapat memanggil callback PHP dari `writeAsSvg` ketika berjalan dalam mode aliran. Letakkan logika pemformatan dalam kelas bantu Java kecil, kompilasi, dan tambahkan berkas JAR yang dihasilkan ke classpath bridge. Pembantu dapat menggunakan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId), yang stabil selama masa hidup bentuk, dan penghitung berulang untuk span teksnya. Lihat [Java implementation of `StableSvgIdController`](/slides/id/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) untuk kode pembantu.

Setelah menambahkan kelas yang telah dikompilasi `com.example.slides.StableSvgIdController` ke classpath bridge, buat instance dari PHP dan tetapkan ke `SVGOptions`:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Tambahkan Penangan Acara SVG**

Dalam callback pemformatan, panggil [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) dengan nilai [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) untuk menambahkan penangan acara JavaScript ke bentuk yang diekspor. Tetapkan callback dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) dan definisikan fungsi JavaScript di halaman atau dokumen SVG yang menampung hasil.

Seperti pada ID stabil, implementasikan callback dalam pembantu Java ketika PhpJavaBridge menggunakan mode aliran. [Java implementation of `SvgEventController`](/slides/id/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) menetapkan ID dan penangan `OnClick` ke bentuk bernama `ActionButton`. Kompilasi pembantu tersebut, tambahkan ke classpath bridge sebagai `com.example.slides.SvgEventController`, dan gunakan dari PHP seperti berikut:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

Halaman host dapat mendefinisikan fungsi JavaScript yang dirujuk oleh penangan. Penetapan ID dan penangan acara memungkinkan penampil slide, peningkatan aksesibilitas, dan alur kerja SVG interaktif lainnya.

## **FAQ**

**Kapan saya harus menggunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) alih-alih [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

Gunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) ketika hanya teks yang menggunakan font eksternal yang harus diubah menjadi grafik.

**Apa cara terbaik untuk membuat SVG lebih kecil?**

Mulailah dengan mengompres gambar tersemat, menghapus area gambar yang dipotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena resolusi gambar yang lebih rendah, kualitas JPEG yang lebih rendah, dan teks yang divisualisasikan masing‑masing memiliki kompromi kualitas dan ukuran yang berbeda.

**Bisakah saya mengubah elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui callback pemformatan, lalu pilih elemen SVG yang sesuai dalam alat pasca‑pemrosesan atau skrip peramban Anda.