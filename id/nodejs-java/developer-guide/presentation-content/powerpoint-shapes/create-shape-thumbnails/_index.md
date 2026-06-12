---
title: Buat Thumbnail Bentuk Presentasi dalam JavaScript
linktitle: Thumbnail Bentuk
type: docs
weight: 70
url: /id/nodejs-java/create-shape-thumbnails/
keywords:
- thumbnail bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Hasilkan thumbnail bentuk berkualitas tinggi dari slide PowerPoint dengan JavaScript dan Aspose.Slides untuk Node.js – dengan mudah buat dan ekspor thumbnail presentasi."
---
## **Pendahuluan**

Aspose.Slides digunakan untuk membuat file presentasi di mana setiap halaman adalah slide. Slide ini dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun terkadang, pengembang mungkin perlu melihat gambar bentuk secara terpisah di penampil gambar. Dalam kasus seperti itu, Aspose.Slides membantu Anda menghasilkan gambar mini (thumbnail) dari bentuk slide. Cara menggunakan fitur ini dijelaskan dalam artikel ini.  
Artikel ini menjelaskan cara menghasilkan thumbnail slide dengan cara berbeda:

- Menghasilkan thumbnail bentuk di dalam slide.  
- Menghasilkan thumbnail bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.  
- Menghasilkan thumbnail bentuk dalam batas tampilan bentuk.  

## **Menghasilkan Thumbnail Bentuk dari Slide**
Untuk menghasilkan thumbnail bentuk dari slide apa pun menggunakan Aspose.Slides untuk Node.js via Java, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).  
1. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.  
1. Dapatkan gambar thumbnail bentuk dengan [Get the shape thumbnail image](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getImage--) dari slide yang direferensikan pada skala default.  
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.  

Kode contoh berikut menunjukkan cara menghasilkan thumbnail bentuk dari slide:

```javascript
// Instansiasi kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Buat gambar skala penuh
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Simpan gambar ke disk dalam format PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menghasilkan Thumbnail Bentuk dengan Faktor Skala yang Ditentukan Pengguna**
Untuk menghasilkan thumbnail bentuk dari slide menggunakan Aspose.Slides untuk Node.js via Java, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).  
1. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.  
1. Dapatkan gambar thumbnail bentuk dengan [Get the shape thumbnail image](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) dari slide yang direferensikan dengan dimensi yang ditentukan pengguna.  
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.  

Kode contoh berikut menunjukkan cara menghasilkan thumbnail bentuk berdasarkan faktor skala yang ditentukan:

```javascript
// Instansiasi kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Buat gambar skala penuh
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Simpan gambar ke disk dalam format PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menghasilkan Thumbnail Bentuk dalam Batas**
Metode ini memungkinkan pengembang menghasilkan thumbnail dalam batas tampilan bentuk, memperhitungkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan thumbnail bentuk slide dalam batas tampilannya, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).  
1. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.  
1. Dapatkan gambar thumbnail dari slide yang direferensikan dengan batas bentuk sebagai tampilan.  
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.  

Kode contoh berikut didasarkan pada langkah-langkah di atas:

```javascript
// Instansiasi kelas Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Buat gambar skala penuh
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Simpan gambar ke disk dalam format PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan thumbnail bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [diexport sebagai SVG vektor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/writeassvg/) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender thumbnail?**

`Shape` menggunakan geometri bentuk; `Appearance` memperhitungkan [visual effects](/slides/id/nodejs-java/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah masih akan dirender sebagai thumbnail?**

Bentuk yang tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan slideshow tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah bentuk grup, diagram, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Setiap objek yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartart/)) dapat disimpan sebagai thumbnail atau sebagai SVG.

**Apakah font yang diinstal di sistem memengaruhi kualitas thumbnail untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/nodejs-java/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/nodejs-java/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan aliran ulang teks.