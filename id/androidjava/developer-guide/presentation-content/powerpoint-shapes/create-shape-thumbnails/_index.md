---
title: Membuat Thumbnail Bentuk Presentasi di Android
linktitle: Thumbnail Bentuk
type: docs
weight: 70
url: /id/androidjava/create-shape-thumbnails/
keywords:
- thumbnail bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- batas visual
- batas bentuk
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Hasilkan thumbnail bentuk berkualitas tinggi dari slide PowerPoint dengan Aspose.Slides untuk Android via Java - dengan mudah membuat dan mengekspor thumbnail presentasi."
---
## **Pendahuluan**

Aspose.Slides for Android via Java dapat digunakan untuk membuat file presentasi di mana setiap halaman berkorespondensi dengan satu slide. Slide dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun, kadang‑kadang pengembang perlu melihat gambar bentuk secara terpisah di penampil gambar. Dalam kasus tersebut, Aspose.Slides for Android via Java membantu mereka menghasilkan gambar thumbnail dari bentuk slide.

Dalam topik ini, kami akan menunjukkan cara menghasilkan thumbnail slide dalam berbagai situasi:

- Menghasilkan thumbnail bentuk di dalam slide.
- Menghasilkan thumbnail bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.
- Menghasilkan thumbnail bentuk dalam batas tampilan bentuk.

## **Menghasilkan Thumbnail Bentuk dari Slide**
Untuk menghasilkan thumbnail bentuk dari slide mana pun menggunakan Aspose.Slides for Android via Java, lakukan hal berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Dapatkan referensi slide mana pun menggunakan ID atau indeksnya.
1. [Dapatkan gambar thumbnail bentuk](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#getImage--) dari slide yang direferensikan dengan skala default.
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.

Contoh kode ini menunjukkan cara menghasilkan thumbnail bentuk dari slide:

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Membuat gambar dengan skala penuh
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Menyimpan gambar ke disk dalam format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menghasilkan Thumbnail dengan Faktor Skala yang Didefinisikan Pengguna**
Untuk menghasilkan thumbnail bentuk slide menggunakan Aspose.Slides for Android via Java, lakukan hal berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Dapatkan referensi slide mana pun menggunakan ID atau indeksnya.
1. [Dapatkan gambar thumbnail bentuk](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) dari slide yang direferensikan dengan dimensi yang ditentukan pengguna.
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.

Contoh kode ini menunjukkan cara menghasilkan thumbnail bentuk berdasarkan faktor skala yang ditentukan:

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Membuat gambar dengan skala penuh
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Menyimpan gambar ke disk dalam format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Membuat Thumbnail Tampilan Bentuk Berdasarkan Batas**
Metode pembuatan thumbnail bentuk ini memungkinkan pengembang untuk menghasilkan thumbnail dalam batas tampilan bentuk. Metode ini memperhitungkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan thumbnail bentuk slide dalam batas tampilannya, lakukan hal berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Dapatkan referensi slide mana pun menggunakan ID atau indeksnya.
1. Dapatkan gambar thumbnail dari slide yang direferensikan dengan batas bentuk sebagai tampilan.
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.

Contoh kode berikut didasarkan pada langkah‑langkah di atas:

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Membuat gambar dengan skala penuh
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Menyimpan gambar ke disk dalam format PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mendapatkan Batas Visual Aktual Sebuah Bentuk**

Properti bingkai dari [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/)—metode `getX()`, `getY()`, `getWidth()`, dan `getHeight()`—menjelaskan persegi panjang yang disimpan dalam model presentasi. Konten yang sebenarnya dirender dapat melampaui bingkai tersebut atau menempati persegi panjang berorientasi sumbu yang berbeda. Rotasi, outline, ujung panah, tata letak teks dan overflow, geometri SmartArt yang dihasilkan, serta efek rendering lainnya dapat mengubah area yang ditempati.

Gunakan [Shape.getVisualBounds](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getVisualBounds--) untuk menghitung area yang ditempati tanpa membuat gambar. Metode ini mengembalikan objek [RectF](https://developer.android.com/reference/android/graphics/RectF) dalam koordinat slide. Persegi panjang yang dikembalikan tidak dipotong ke slide, sehingga koordinatnya dapat menjadi negatif ketika konten meluas di luar asal slide.

[Shape.getVisualBounds](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getVisualBounds--) saat ini belum dideklarasikan oleh antarmuka [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/). Oleh karena itu, pertahankan bentuk yang diambil dari koleksi bentuk slide sebagai nilai antarmuka dan lakukan cast hanya saat memanggil metode tersebut.

Contoh berikut mengambil dan membandingkan batas bingkai serta batas visual:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

[RectF](https://developer.android.com/reference/android/graphics/RectF) yang sama dapat digunakan untuk menyelaraskan bentuk‑bentuk tetangga ke tepi kiri, kanan, atas, atau bawahnya; menyediakan ruang yang cukup dalam tata letak yang dihasilkan; atau mendeteksi konten di luar wilayah yang diizinkan. Batas visual sangat berguna untuk SmartArt, kotak teks, panah, gambar, bentuk yang diputar, dan grup bentuk, di mana bingkai yang disimpan mungkin tidak merepresentasikan hasil render penuh.

Gunakan [Shape.getVisualBounds](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getVisualBounds--) ketika Anda memerlukan koordinat untuk tata letak atau validasi dan tidak memerlukan bitmap. Gunakan [IShape.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#getImage--) ketika Anda perlu merender bentuk. Dengan [ShapeThumbnailBounds](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` mengukur gambar dari batas bentuk, termasuk pengaturan outline, sementara `ShapeThumbnailBounds.Appearance` mengukurnya dari tampilan bentuk dan membatasi hasil ke batas slide. Sebaliknya, [Shape.getVisualBounds](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getVisualBounds--) hanya mengembalikan persegi panjang yang dihitung dan tidak memotongnya ke slide.

## **Tanya Jawab**

**Format gambar apa yang dapat digunakan saat menyimpan thumbnail bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imageformat/), dan format lainnya. Bentuk juga dapat [diekspor sebagai vektor SVG](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender thumbnail?**

`Shape` menggunakan geometri bentuk; `Appearance` memperhitungkan [efek visual](/slides/id/androidjava/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah tetap akan dirender sebagai thumbnail?**

Bentuk yang tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan slideshow tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah bentuk grup, diagram, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Objek apa pun yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/smartart/)) dapat disimpan sebagai thumbnail atau sebagai SVG.

**Apakah font yang diinstal pada sistem memengaruhi kualitas thumbnail untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/androidjava/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/androidjava/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan perubahan tata letak teks.