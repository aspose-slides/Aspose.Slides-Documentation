---
title: Mengonversi Slide PowerPoint ke PNG dalam JavaScript
linktitle: PowerPoint ke PNG
type: docs
weight: 30
url: /id/nodejs-java/convert-powerpoint-to-png/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke gambar PNG berkualitas tinggi dalam JavaScript dengan cepat menggunakan Aspose.Slides untuk Node.js, memastikan hasil yang tepat dan otomatis."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi slide presentasi menjadi gambar PNG menggunakan Aspose.Slides untuk Node.js via Java. Anda dapat memuat presentasi dalam format seperti PPT, PPTX, dan ODP, merender setiap slide, dan menyimpannya sebagai gambar PNG terpisah.

Contoh di bawah ini menunjukkan cara merender dengan skala default, meningkatkan skala, menentukan dimensi output dalam piksel, dan memilih gaya render gradien.

## **Mengonversi PowerPoint ke PNG**

Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) dan akses slidenya melalui koleksi [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides). Contoh tersebut merender setiap slide dengan [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) tanpa parameter untuk membuat thumbnail. Kemudian memanggil [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) dengan [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) untuk menyimpan setiap slide yang dirender sebagai gambar PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Catatan" %}}
Overload [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) tanpa parameter merender pada skala 0.2. Misalnya, slide berukuran 720 × 540 poin menghasilkan thumbnail 144 × 108 piksel. Untuk mengontrol dimensi output, gunakan overload dengan faktor skala atau ukuran gambar eksplisit yang ditunjukkan di bawah.
{{% /alert %}}

## **Mengonversi PowerPoint ke PNG dengan Dimensi Kustom**

Berikan faktor skala horizontal dan vertikal ke [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) untuk mengontrol dimensi hasil render. Pada contoh ini, kedua faktor adalah 2, sehingga slide berukuran 720 × 540 poin menghasilkan gambar 1440 × 1080 piksel. Faktor skala yang sama mempertahankan rasio aspek slide. Setiap gambar disimpan dalam format PNG dengan [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Mengonversi PowerPoint ke PNG dengan Ukuran Kustom**

Untuk menentukan dimensi output dalam piksel, berikan ukuran ke [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) alih-alih faktor skala. Contoh ini merender setiap slide pada 960 × 720 piksel dan menyimpan hasilnya dengan [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Pilih dimensi yang sesuai dengan rasio aspek slide untuk menghindari pemanjangan gambar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Pilih Gaya Render Gradien**

Misalkan sebuah slide berisi isian gradien, tetapi transisi dalam PNG yang diekspor tampak lebih terang atau berbeda dari yang Anda lihat di PowerPoint. Anda dapat menggunakan metode [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) yang diwarisi dari [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) untuk memilih cara gradien dirender.

Unduh [gradient-styles.pptx](gradient-styles.pptx) dan letakkan di direktori kerja aplikasi. Slide pertamanya berisi dua gradien linear: cyan ke oranye di bagian atas dan biru ke kuning di bagian bawah. Setiap gradien memiliki dua titik henti, pada 0% dan 100%.

Contoh berikut memuat presentasi ini dan merender slide pertama yang sama dalam kedua mode dengan [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

| Default | PowerPointUI |
| --- | --- |
| ![Gradien cyan-ke-oranye dan biru-ke-kuning yang dirender dengan Default](gradient-Default.png) | ![Gradien yang sama dirender dengan PowerPointUI](gradient-PowerPointUI.png) |

Dalam contoh ini, `Default` menghasilkan warna antara yang lebih terang, sementara `PowerPointUI` menghasilkan warna antara yang lebih gelap. Perbedaannya tergantung pada warna dan titik henti dalam gradien.

Pilih `Default` ketika output standar Aspose.Slides memenuhi kebutuhan Anda. Coba `PowerPointUI` bila prioritas Anda adalah mencocokkan tampilan di PowerPoint. Bandingkan kedua output dengan hasil yang Anda inginkan; tidak ada mode yang secara universal lebih baik.

## **FAQ**

**Bagaimana saya dapat mengekspor bentuk tertentu, seperti diagram atau gambar, alih-alih seluruh slide?**

Aspose.Slides mendukung [pembuatan thumbnail untuk bentuk individu](/slides/id/nodejs-java/create-shape-thumbnails/), memungkinkan Anda merender sebuah bentuk sebagai gambar PNG.

**Apakah konversi paralel didukung di server?**

Ya. Gunakan instance presentasi terpisah untuk setiap thread atau proses; [jangan bagikan satu instance di antara thread](/slides/id/nodejs-java/multithreading/).

**Apa saja keterbatasan evaluasi saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan menerapkan [pembatasan lain](/slides/id/nodejs-java/licensing/) sampai lisensi diterapkan.