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
description: "Ekspor slide PowerPoint sebagai gambar SVG di PHP dan kendalikan font, teks, gambar, ID, serta acara dengan Aspose.Slides."
---
## **Gambaran Umum**

SVG adalah format gambar berbasis XML yang dapat diskalakan dan cocok untuk penerbitan web, penampil slide, alur kerja aksesibilitas, serta pemrosesan otomatis pasca produksi. Aspose.Slides mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol bagaimana teks, font, gambar, dan elemen SVG dituliskan.

Gunakan [SVGOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di semua browser, atau siap untuk penggunaan interaktif.

## **Ekspor Slide sebagai SVG**

Buat sebuah [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/), pilih sebuah slide, dan tulis ke aliran dengan [Slide.writeAsSvg](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#writeAsSvg). Contoh berikut mengekspor setiap slide dalam sebuah presentasi sebagai file SVG terpisah.

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

Nama file menggunakan [Slide.getSlideNumber](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getSlideNumber) bukan indeks perulangan. Anda juga dapat mengekspor sebuah shape individual dengan [Shape.writeAsSvg](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#writeAsSvg) ketika penampil slide atau halaman web hanya membutuhkan shape tersebut.

## **Konfigurasi Output SVG**

[SVGOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/) mengontrol rendering SVG. Untuk bingkai teks, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#setUseFrameSize) menyertakan bingkai teks dalam area rendering, dan [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#setUseFrameRotation) menentukan apakah rotasi bingkai diterapkan. Atur [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) ke `true` ketika teks harus dirender tanpa ligatur.

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

## **Kontrol Teks dan Font**

### **Vektorisasi Semua Teks**

Atur [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#setVectorizeText) ke `true` untuk menulis semua teks slide sebagai grafis vektor. Ini menghilangkan ketergantungan pada font dan membuat hasil visual lebih konsisten di semua browser, namun teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih `AddLinksToFontFiles` untuk merujuk file font terpisah, `Embed` untuk menyertakan data font dalam SVG, atau `Vectorize` untuk merender hanya teks yang menggunakan font eksternal sebagai grafis. Verifikasi lisensi font sebelum menyematkan font.

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

Gunakan [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#setPicturesCompression) untuk mengurangi resolusi gambar tersemat, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) untuk menghilangkan area sumber yang dipotong, dan [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#setJpegQuality) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran file dengan mengorbankan ketelitian gambar atau data gambar yang dipertahankan.

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

## **Berikan ID Stabil pada Shape dan Teks**

Berikan callback pemformatan ke [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#setShapeFormattingController) untuk menetapkan [SvgShape.setId](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgshape/#setId) bagi setiap shape SVG. Callback juga dapat menetapkan nilai [SvgTSpan.setId](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgtspan/#setId) pada elemen `tspan` teks.

PhpJavaBridge tidak dapat memanggil callback PHP dari `writeAsSvg` saat berjalan dalam mode aliran. Tempatkan logika pemformatan dalam kelas pembantu Java kecil, kompilasi, dan tambahkan file JAR yang dihasilkan ke classpath bridge. Pembantu dapat menggunakan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getOfficeInteropShapeId), yang stabil selama masa hidup shape, serta counter yang dapat diulang untuk span teksnya. Lihat [implementasi Java dari `StableSvgIdController`](/slides/id/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) untuk kode pembantu.

Setelah menambahkan kelas `com.example.slides.StableSvgIdController` yang telah dikompilasi ke classpath bridge, buat instansinya dari PHP dan tetapkan ke `SVGOptions`:

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

## **Tambahkan Penangkap Acara SVG**

Dalam callback pemformatan, panggil [SvgShape.setEventHandler](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgshape/#setEventHandler) dengan nilai [SvgEvent](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgevent/) untuk menambahkan penangkap acara JavaScript ke sebuah shape yang diekspor. Tetapkan callback dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#setShapeFormattingController) dan definisikan fungsi JavaScript di halaman atau dokumen SVG yang menampung hasil.

Seperti halnya ID stabil, terapkan callback dalam pembantu Java ketika PhpJavaBridge menggunakan mode aliran. [Implementasi Java dari `SvgEventController`](/slides/id/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) menetapkan ID dan penangkap `OnClick` ke shape bernama `ActionButton`. Kompilasi pembantu tersebut, tambahkan ke classpath bridge sebagai `com.example.slides.SvgEventController`, dan gunakan dari PHP seperti berikut:

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

Halaman host dapat mendefinisikan fungsi JavaScript yang direferensikan oleh penangkap. Penetapan ID dan penangkap acara memungkinkan penampil slide, peningkatan aksesibilitas, dan alur kerja SVG interaktif lainnya.

## **FAQ**

**Kapan saya harus menggunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#setVectorizeText) alih-alih [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgexternalfontshandling/)?**

Gunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgoptions/#setVectorizeText) ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/id/php-java/aspose.slides/svgexternalfontshandling/) ketika hanya teks yang menggunakan font eksternal yang harus dikonversi menjadi grafis.

**Apa cara terbaik untuk memperkecil ukuran SVG?**

Mulailah dengan mengompres gambar tersemat, menghapus area gambar yang dipotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena resolusi gambar yang lebih rendah, kualitas JPEG yang lebih rendah, dan teks yang vektorisasi masing‑masing memiliki kompromi kualitas dan ukuran yang berbeda.

**Apakah saya dapat memodifikasi elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui callback pemformatan, kemudian pilih elemen SVG yang cocok dalam alat pasca‑pemrosesan atau skrip peramban Anda.