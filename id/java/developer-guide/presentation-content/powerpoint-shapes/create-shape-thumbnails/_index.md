---
title: Buat Thumbnail Bentuk Presentasi dalam Java
linktitle: Thumbnail Bentuk
type: docs
weight: 70
url: /id/java/create-shape-thumbnails/
keywords:
- thumbnail bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- batas visual
- batas bentuk
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Hasilkan thumbnail bentuk berkualitas tinggi dari slide PowerPoint dengan Aspose.Slides untuk Java – dengan mudah membuat dan mengekspor thumbnail presentasi."
---
## **Pendahuluan**

Aspose.Slides for Java dapat digunakan untuk membuat file presentasi di mana setiap halaman sesuai dengan satu slide. Slide dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun, pengembang kadang‑kadang perlu melihat gambar bentuk secara terpisah di penampil gambar. Dalam kasus seperti itu, Aspose.Slides for Java membantu mereka menghasilkan gambar mini dari bentuk slide.

Artikel ini menjelaskan cara menghasilkan thumbnail slide dengan berbagai cara:

- Menghasilkan thumbnail bentuk di dalam slide.
- Menghasilkan thumbnail bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.
- Menghasilkan thumbnail bentuk dalam batas tampilan bentuk.

## **Hasilkan Thumbnail Bentuk dari Slide**
Untuk menghasilkan thumbnail bentuk dari slide mana pun menggunakan Aspose.Slides for Java, lakukan hal berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
1. Dapatkan referensi dari slide mana pun menggunakan ID atau indeksnya.
1. Dapatkan [gambar thumbnail bentuk](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getImage--) dari slide yang direferensikan dengan skala default.
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Membuat gambar skala penuh
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
Untuk menghasilkan thumbnail bentuk dari slide menggunakan Aspose.Slides for Java, lakukan hal berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
1. Dapatkan referensi dari slide mana pun menggunakan ID atau indeksnya.
1. Dapatkan [gambar thumbnail bentuk](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getImage-int-float-float-) dari slide yang direferensikan dengan dimensi yang ditentukan pengguna.
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Membuat gambar skala penuh
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
Metode ini untuk membuat thumbnail bentuk memungkinkan pengembang menghasilkan thumbnail dalam batas tampilan bentuk. Metode ini mempertimbangkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan thumbnail dari bentuk slide dalam batas tampilannya, lakukan hal berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
1. Dapatkan referensi dari slide mana pun menggunakan ID atau indeksnya.
1. Dapatkan gambar thumbnail dari slide yang direferensikan dengan batas bentuk sebagai tampilan.
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Membuat gambar skala penuh
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

## **Dapatkan Batas Visual Aktual dari Sebuah Bentuk**

Properti bingkai dari [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/)—metode `getX()`, `getY()`, `getWidth()`, dan `getHeight()`—menggambarkan persegi panjang yang disimpan dalam model presentasi. Konten yang sebenarnya dirender dapat melampaui bingkai tersebut atau menempati persegi panjang lain yang sejajar sumbu. Rotasi, outline, ujung panah, tata letak teks dan overflow, geometri SmartArt yang dihasilkan, serta efek rendering lainnya dapat mengubah area yang ditempati.

Gunakan [Shape.getVisualBounds](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getVisualBounds--) untuk menghitung area yang ditempati tanpa membuat gambar. Metode ini mengembalikan [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) dalam koordinat slide. Persegi panjang yang dikembalikan tidak dipotong oleh slide, sehingga koordinatnya dapat menjadi negatif ketika konten melampaui asal slide.

[Shape.getVisualBounds](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getVisualBounds--) saat ini belum dideklarasikan oleh antarmuka [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/). Oleh karena itu, pertahankan bentuk yang diperoleh dari koleksi bentuk slide sebagai nilai antarmuka dan lakukan cast hanya saat memanggil metode tersebut.

Contoh berikut mendapatkan dan membandingkan bingkai serta batas visual:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Rectangle2D.Float yang sama dapat digunakan untuk menyelaraskan bentuk berdekatan ke tepi kiri, kanan, atas, atau bawahnya; menyediakan ruang yang cukup dalam tata letak yang dihasilkan; atau mendeteksi konten di luar wilayah yang diizinkan. Batas visual sangat berguna untuk SmartArt, kotak teks, panah, gambar, bentuk yang diputar, dan bentuk grup, di mana bingkai yang disimpan mungkin tidak mewakili hasil render penuh.

Gunakan [Shape.getVisualBounds](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getVisualBounds--) ketika Anda memerlukan koordinat untuk tata letak atau validasi dan tidak memerlukan bitmap. Gunakan [IShape.getImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/#getImage--) ketika Anda perlu merender bentuk. Dengan [ShapeThumbnailBounds](https://reference.aspose.com/slides/id/java/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` mengatur ukuran gambar dari batas bentuk, termasuk pengaturan outline, sementara `ShapeThumbnailBounds.Appearance` mengatur ukuran dari tampilan bentuk dan membatasi hasil ke batas slide. Sebaliknya, [Shape.getVisualBounds](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getVisualBounds--) hanya mengembalikan persegi panjang yang dihitung dan tidak memotongnya ke slide.

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan thumbnail bentuk?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/java/com.aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [diekspor sebagai SVG vektor](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender thumbnail?**  
`Shape` menggunakan geometri bentuk; `Appearance` memperhitungkan [efek visual](/slides/id/java/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah masih akan dirender sebagai thumbnail?**  
Bentuk yang tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan slideshow tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah bentuk grup, diagram, SmartArt, dan objek kompleks lainnya didukung?**  
Ya. Setiap objek yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/java/com.aspose.slides/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/smartart/)) dapat disimpan sebagai thumbnail atau sebagai SVG.

**Apakah font yang diinstal pada sistem memengaruhi kualitas thumbnail untuk bentuk teks?**  
Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/java/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/java/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan aliran ulang teks.