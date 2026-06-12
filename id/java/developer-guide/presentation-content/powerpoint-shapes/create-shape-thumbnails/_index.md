---
title: Buat Thumbnail Bentuk Presentasi di Java
linktitle: Thumbnail Bentuk
type: docs
weight: 70
url: /id/java/create-shape-thumbnails/
keywords:
- thumbnail bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Hasilkan thumbnail bentuk berkualitas tinggi dari slide PowerPoint dengan Aspose.Slides for Java – dengan mudah membuat dan mengekspor thumbnail presentasi."
---
## **Pendahuluan**

Aspose.Slides for Java dapat digunakan untuk membuat file presentasi di mana setiap halaman berkorespondensi dengan satu slide. Slide dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun, pengembang kadang perlu melihat gambar bentuk secara terpisah di penampil gambar. Dalam kasus seperti itu, Aspose.Slides for Java membantu mereka menghasilkan gambar miniatur (thumbnail) dari bentuk slide.

Artikel ini menjelaskan cara menghasilkan thumbnail slide dengan berbagai cara:

- Menghasilkan thumbnail bentuk di dalam slide.
- Menghasilkan thumbnail bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.
- Menghasilkan thumbnail bentuk dalam batas tampilan bentuk.

## **Hasilkan Thumbnail Bentuk dari Slide**
Untuk menghasilkan thumbnail bentuk dari slide apa pun menggunakan Aspose.Slides for Java, lakukan langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
2. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.
3. [Dapatkan gambar thumbnail bentuk](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShape#getImage--) dari slide yang direferensikan dengan skala default.
4. Simpan gambar thumbnail dalam format gambar pilihan Anda.

```java
// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Buat gambar dengan skala penuh
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

## **Hasilkan Thumbnail dengan Faktor Skala yang Ditentukan Pengguna**
Untuk menghasilkan thumbnail bentuk slide menggunakan Aspose.Slides for Java, lakukan langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
2. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.
3. [Dapatkan gambar thumbnail bentuk](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShape#getImage-int-float-float-) dari slide yang direferensikan dengan dimensi yang ditentukan pengguna.
4. Simpan gambar thumbnail dalam format gambar pilihan Anda.

```java
// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Buat gambar dengan skala penuh
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

## **Buat Thumbnail Tampilan Bentuk Berbasis Batas**
Metode ini untuk membuat thumbnail bentuk memungkinkan pengembang menghasilkan thumbnail dalam batas tampilan bentuk. Metode ini mempertimbangkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan thumbnail bentuk slide dalam batas tampilannya, lakukan langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
2. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.
3. Dapatkan gambar thumbnail dari slide yang direferensikan dengan batas bentuk sebagai tampilan.
4. Simpan gambar thumbnail dalam format gambar pilihan Anda.

```java
// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Buat gambar dengan skala penuh
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

**Format gambar apa yang dapat digunakan saat menyimpan thumbnail bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/java/com.aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [diekspor sebagai SVG vektor](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender thumbnail?**

`Shape` menggunakan geometri bentuk; `Appearance` mempertimbangkan [efek visual](/slides/id/java/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah masih akan dirender sebagai thumbnail?**

Sebuah bentuk tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi mempengaruhi tampilan slideshow tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah bentuk grup, diagram, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Setiap objek yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/java/com.aspose.slides/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/smartart/)) dapat disimpan sebagai thumbnail atau sebagai SVG.

**Apakah font yang diinstal sistem memengaruhi kualitas thumbnail untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/java/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/java/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan reflow teks.