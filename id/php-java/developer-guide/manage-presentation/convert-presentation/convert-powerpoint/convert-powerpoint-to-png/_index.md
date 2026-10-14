---
title: Konversi Slide PowerPoint ke PNG dalam PHP
linktitle: PowerPoint ke PNG
type: docs
weight: 30
url: /id/php-java/convert-powerpoint-to-png/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke PNG
- presentasi ke PNG
- slide ke PNG
- PPT ke PNG
- PPTX ke PNG
- simpan PPT sebagai PNG
- simpan PPTX sebagai PNG
- ekspor PPT ke PNG
- ekspor PPTX ke PNG
- PHP
- Aspose.Slides
description: "Konversi presentasi PowerPoint menjadi gambar PNG berkualitas tinggi dengan cepat menggunakan Aspose.Slides untuk PHP melalui Java, memastikan hasil yang tepat dan otomatis."
---
## **Ringkasan**

Artikel ini menjelaskan cara mengonversi slide presentasi menjadi gambar PNG menggunakan Aspose.Slides untuk PHP melalui Java. Anda dapat memuat presentasi dalam format seperti PPT, PPTX, dan ODP, merender setiap slide, dan menyimpannya sebagai gambar PNG terpisah.

Contoh di bawah ini menunjukkan cara merender dengan skala default, meningkatkan skala, menentukan dimensi output dalam piksel, dan memilih gaya render gradien.

## **Konversi PowerPoint ke PNG**

Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) dan akses slide-nya melalui koleksi [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides). Contoh ini merender setiap slide dengan [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) tanpa parameter untuk membuat thumbnail. Selanjutnya memanggil [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) dengan [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) untuk menyimpan setiap slide yang dirender sebagai gambar PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Overload [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) tanpa parameter merender dengan skala 0,2. Misalnya, slide berukuran 720 × 540 poin menghasilkan thumbnail 144 × 108 piksel. Untuk mengontrol dimensi output, gunakan overload dengan faktor skala atau ukuran gambar eksplisit yang ditunjukkan di bawah.
{{% /alert %}}

## **Konversi PowerPoint ke PNG dengan Dimensi Kustom**

Berikan faktor skala horizontal dan vertikal ke [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) untuk mengontrol dimensi yang dirender. Pada contoh ini, kedua faktor adalah 2, sehingga slide berukuran 720 Г— 540 poin menghasilkan gambar 1440 Г— 1080 piksel. Faktor skala yang sama mempertahankan rasio aspek slide. Setiap gambar disimpan dalam format PNG dengan [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Konversi PowerPoint ke PNG dengan Ukuran Kustom**

Untuk menentukan dimensi output dalam piksel, berikan ukuran ke [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) alih-alih faktor skala. Contoh ini merender setiap slide pada 960 Г— 720 piksel dan menyimpan hasilnya dengan [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Pilih dimensi yang sesuai dengan rasio aspek slide untuk menghindari gambar terdistorsi.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Pilih Gaya Render Gradien**

Misalkan sebuah slide berisi isian gradien, tetapi transisi pada PNG yang diekspor terlihat lebih terang atau berbeda dari yang Anda lihat di PowerPoint. Anda dapat menggunakan metode [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) yang diwarisi oleh [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) untuk memilih cara gradien dirender.

Unduh [gradient-styles.pptx](gradient-styles.pptx) dan letakkan di direktori kerja aplikasi. Slide pertamanya berisi dua gradien linier: cyan ke oranye di bagian atas dan biru ke kuning di bagian bawah. Setiap gradien memiliki dua titik henti, pada 0% dan 100%.

Contoh berikut memuat presentasi ini dan merender slide pertama yang sama dalam kedua mode dengan [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Gambar di bawah ini menunjukkan output dari slide yang sama, dengan kedua gradien di setiap gambar:

| Default | PowerPointUI |
| --- | --- |
| ![Gradien cyan-ke-oranye dan biru-ke-kuning dirender dengan Default](gradient-Default.png) | ![Gradien yang sama dirender dengan PowerPointUI](gradient-PowerPointUI.png) |

Pada contoh ini, `Default` menghasilkan warna perantara yang lebih terang, sedangkan `PowerPointUI` menghasilkan warna perantara yang lebih gelap. Perbedaannya bergantung pada warna dan titik henti pada gradien.

Pilih `Default` ketika output standar Aspose.Slides memenuhi kebutuhan Anda. Coba `PowerPointUI` ketika prioritas Anda adalah mencocokkan tampilan di PowerPoint. Bandingkan kedua output dengan hasil yang diinginkan; tidak ada mode yang secara universal lebih baik.

## **FAQ**

**Bagaimana saya dapat mengekspor bentuk tertentu, seperti diagram atau gambar, alih-alih seluruh slide?**

Aspose.Slides mendukung [pembuatan thumbnail untuk bentuk individu](/slides/id/php-java/create-shape-thumbnails/), memungkinkan Anda merender sebuah bentuk sebagai gambar PNG.

**Apakah konversi paralel didukung pada server?**

Ya. Gunakan instance presentasi terpisah untuk setiap thread atau proses; [jangan berbagi satu instance di antara thread](/slides/id/php-java/multithreading/).

**Apa batasan evaluasi saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan menerapkan [pembatasan lain](/slides/id/php-java/licensing/) sampai lisensi diterapkan.