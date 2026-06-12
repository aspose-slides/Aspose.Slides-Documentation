---
title: Buat Gambar Miniatur Bentuk Presentasi di Android
linktitle: Miniatur Bentuk
type: docs
weight: 70
url: /id/androidjava/create-shape-thumbnails/
keywords:
- miniatur bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Hasilkan miniatur bentuk berkualitas tinggi dari slide PowerPoint dengan Aspose.Slides untuk Android via Java – dengan mudah buat dan ekspor miniatur presentasi."
---
## **Pendahuluan**

Aspose.Slides for Android via Java dapat digunakan untuk membuat file presentasi di mana setiap halaman sesuai dengan sebuah slide. Slide dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun, terkadang pengembang perlu melihat gambar bentuk secara terpisah dalam penampil gambar. Dalam kasus seperti itu, Aspose.Slides for Android via Java membantu mereka menghasilkan gambar miniatur bentuk slide.

Dalam topik ini, kami akan menunjukkan cara menghasilkan gambar miniatur slide dalam berbagai situasi:

- Menghasilkan gambar miniatur bentuk di dalam slide.
- Menghasilkan gambar miniatur bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.
- Menghasilkan gambar miniatur bentuk dalam batas tampilan bentuk.

## **Hasilkan Gambar Miniatur Bentuk dari Slide**
Untuk menghasilkan gambar miniatur bentuk dari slide mana pun menggunakan Aspose.Slides for Android via Java, lakukan hal berikut:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Dapatkan referensi slide mana pun menggunakan ID atau indeksnya.
1. Dapatkan [gambar miniatur bentuk](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#getImage--) dari slide yang direferensikan pada skala default.
1. Simpan gambar miniatur dalam format gambar pilihan Anda.

Contoh kode ini menunjukkan cara menghasilkan gambar miniatur bentuk dari slide:

```java
// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Buat gambar skala penuh
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Simpan gambar ke disk dalam format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hasilkan Gambar Miniatur dengan Faktor Skala yang Ditentukan Pengguna**
Untuk menghasilkan gambar miniatur bentuk dari slide menggunakan Aspose.Slides for Android via Java, lakukan hal berikut:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Dapatkan referensi slide mana pun menggunakan ID atau indeksnya.
1. Dapatkan [gambar miniatur bentuk](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) dari slide yang direferensikan dengan dimensi yang ditentukan pengguna.
1. Simpan gambar miniatur dalam format gambar pilihan Anda.

Contoh kode ini menunjukkan cara menghasilkan gambar miniatur bentuk berdasarkan faktor skala yang ditentukan:

```java
// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Buat gambar skala penuh
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Simpan gambar ke disk dalam format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Buat Gambar Miniatur Penampilan Bentuk Berbasis Batas**
Metode ini untuk membuat gambar miniatur bentuk memungkinkan pengembang menghasilkan gambar miniatur dalam batas penampilan bentuk. Metode ini memperhitungkan semua efek bentuk. Gambar miniatur bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan gambar miniatur bentuk slide dalam batas penampilannya, lakukan hal berikut:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Dapatkan referensi slide mana pun menggunakan ID atau indeksnya.
1. Dapatkan gambar miniatur dari slide yang direferensikan dengan batas bentuk sebagai penampilan.
1. Simpan gambar miniatur dalam format gambar pilihan Anda.

Contoh kode ini didasarkan pada langkah-langkah di atas:

```java
// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Buat gambar skala penuh
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Simpan gambar ke disk dalam format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan gambar miniatur bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [diekspor sebagai SVG vektor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender gambar miniatur?**

`Shape` menggunakan geometri bentuk; `Appearance` memperhitungkan [efek visual](/slides/id/androidjava/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah masih akan dirender sebagai gambar miniatur?**

Bentuk yang tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan slideshow tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah bentuk grup, diagram, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Setiap objek yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/smartart/)) dapat disimpan sebagai gambar miniatur atau sebagai SVG.

**Apakah font yang terpasang di sistem memengaruhi kualitas gambar miniatur untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/androidjava/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/androidjava/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan perubahan aliran teks.