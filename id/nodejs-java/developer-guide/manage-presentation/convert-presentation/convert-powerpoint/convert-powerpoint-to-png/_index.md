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
description: "Mengonversi presentasi PowerPoint menjadi gambar PNG berkualitas tinggi dalam JavaScript dengan cepat menggunakan Aspose.Slides untuk Node.js, memastikan hasil yang tepat dan otomatis."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke gambar PNG menggunakan Aspose.Slides. Ini menunjukkan cara memuat file presentasi dalam format seperti PPT, PPTX, dan ODP, merender slide sebagai gambar, dan menyimpan hasilnya dalam format PNG.

Artikel ini juga mendemonstrasikan cara menyesuaikan gambar PNG yang dihasilkan dengan mengatur nilai skala atau menentukan lebar dan tinggi yang diinginkan.

## **Konversi PowerPoint ke PNG**

Ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan objek slide dari koleksi yang dikembalikan oleh metode [Presentation.getSlides()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getSlides--) pada kelas [Slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Slide).
3. Gunakan metode [Slide.getImage()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Slide) untuk mendapatkan thumbnail untuk setiap slide.
4. Gunakan [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/#save) untuk menyimpan thumbnail slide ke format PNG.

Kode JavaScript berikut menunjukkan cara mengonversi presentasi PowerPoint ke PNG:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konversi PowerPoint ke PNG dengan Dimensi Kustom**

Jika Anda ingin memperoleh file PNG dengan skala tertentu, Anda dapat mengatur nilai `desiredX` dan `desiredY`, yang menentukan dimensi thumbnail yang dihasilkan. 

Kode JavaScript berikut mendemonstrasikan operasi tersebut:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konversi PowerPoint ke PNG dengan Ukuran Kustom**

Jika Anda ingin memperoleh file PNG dengan ukuran tertentu, Anda dapat memberikan argumen `width` dan `height` yang diinginkan untuk `ImageSize`. 

Kode berikut menunjukkan cara mengonversi PowerPoint ke PNG sambil menentukan ukuran gambar: 

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Bagaimana cara mengekspor hanya bentuk tertentu (misalnya, diagram atau gambar) bukan seluruh slide?**

Aspose.Slides mendukung [pembuatan thumbnail untuk bentuk individu](/slides/id/nodejs-java/create-shape-thumbnails/); Anda dapat merender bentuk ke gambar PNG.

**Apakah konversi paralel didukung di server?**

Ya, tetapi [jangan bagikan](/slides/id/nodejs-java/multithreading/) satu instance presentasi di antara thread. Gunakan instance terpisah per thread atau proses.

**Apa batasan versi percobaan saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan menerapkan [pembatasan lain](/slides/id/nodejs-java/licensing/) sampai lisensi diterapkan.