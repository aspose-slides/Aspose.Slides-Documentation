---
title: Buat Thumbnail Bentuk Presentasi dalam PHP
linktitle: Thumbnail Bentuk
type: docs
weight: 70
url: /id/php-java/create-shape-thumbnails/
keywords:
- thumbnail bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- batas visual
- batas bentuk
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Hasilkan thumbnail bentuk berkualitas tinggi dari slide PowerPoint dengan Aspose.Slides untuk PHP via Java – dengan mudah buat dan ekspor thumbnail presentasi."
---
## **Pendahuluan**

Aspose.Slides digunakan untuk membuat file presentasi di mana setiap halaman adalah slide. Slide tersebut dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun terkadang, pengembang mungkin perlu melihat gambar bentuk secara terpisah dalam penampil gambar. Dalam kasus seperti itu, Aspose.Slides membantu Anda menghasilkan gambar mini (thumbnail) dari bentuk slide. Cara menggunakan fitur ini dijelaskan dalam artikel ini.

Artikel ini menjelaskan cara menghasilkan thumbnail slide dengan berbagai cara:

- Menghasilkan thumbnail bentuk di dalam slide.
- Menghasilkan thumbnail bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.
- Menghasilkan thumbnail bentuk dalam batas tampilan bentuk.

## **Buat Thumbnail Bentuk dari Slide**
Untuk menghasilkan thumbnail bentuk dari slide mana saja menggunakan Aspose.Slides untuk PHP melalui Java, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
1. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage) dari slide yang direferensikan dengan skala default.
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.

Contoh kode ini menunjukkan cara menghasilkan thumbnail bentuk dari slide:

```php
  # Instansiasi kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Buat gambar skala penuh
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Simpan gambar ke disk dalam format PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Buat Thumbnail dengan Faktor Skala yang Ditentukan Pengguna**
Untuk menghasilkan thumbnail bentuk dari slide menggunakan Aspose.Slides untuk PHP melalui Java, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
1. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage) dari slide yang direferensikan dengan dimensi yang ditentukan pengguna.
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.

Contoh kode ini menunjukkan cara menghasilkan thumbnail bentuk berdasarkan faktor skala yang ditentukan:

```php
  # Instansiasi kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Buat gambar skala penuh
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Simpan gambar ke disk dalam format PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Buat Thumbnail Penampilan Bentuk Berbasis Batas**
Metode ini untuk membuat thumbnail bentuk memungkinkan pengembang menghasilkan thumbnail dalam batas penampilan bentuk. Metode ini mempertimbangkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan thumbnail bentuk slide dalam batas penampilannya, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
1. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.
1. Dapatkan gambar thumbnail dari slide yang direferensikan dengan batas bentuk sebagai penampilan.
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.

Contoh kode ini didasarkan pada langkah-langkah di atas:

```php
  # Instansiasi kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Buat gambar skala penuh
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Simpan gambar ke disk dalam format PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dapatkan Batas Visual Aktual Sebuah Bentuk**

Batas frame dari [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/)—`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()`, dan `Shape::getHeight()`—menggambarkan persegi panjang yang disimpan dalam model presentasi. Konten yang sebenarnya dirender dapat melampaui frame tersebut atau menempati persegi panjang lain yang sejajar sumbu. Rotasi, garis tepi, anak panah, tata letak dan overflow teks, geometri SmartArt yang dihasilkan, serta efek rendering lainnya dapat mengubah area yang ditempati.

Gunakan [Shape::getVisualBounds](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getVisualBounds) untuk menghitung area yang ditempati tersebut tanpa membuat gambar. Metode ini mengembalikan sebuah [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) dalam koordinat slide. Persegi panjang yang dikembalikan tidak dipotong ke slide, sehingga koordinatnya dapat menjadi negatif ketika konten melampaui asal slide.

Contoh berikut mengambil dan membandingkan batas frame dan visual:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

Rectangle2D.Float yang sama dapat digunakan untuk menyelaraskan bentuk-bentuk di sekitarnya ke tepi kiri, kanan, atas, atau bawah; menyediakan ruang yang cukup dalam tata letak yang dihasilkan; atau mendeteksi konten di luar wilayah yang diizinkan. Batas visual terutama berguna untuk SmartArt, kotak teks, panah, gambar, bentuk yang diputar, dan grup bentuk, di mana frame yang disimpan mungkin tidak mewakili hasil rendering penuh.

Gunakan [Shape::getVisualBounds](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getVisualBounds) ketika Anda memerlukan koordinat untuk tata letak atau validasi dan tidak memerlukan bitmap. Gunakan [Shape::getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage) ketika Anda perlu merender bentuk. Dengan [ShapeThumbnailBounds](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` mengatur ukuran gambar dari batas bentuk, termasuk pengaturan outline, sementara `ShapeThumbnailBounds::Appearance` mengatur ukuran berdasarkan penampilan bentuk dan membatasi hasil ke batas slide. Sebaliknya, `Shape::getVisualBounds` hanya mengembalikan persegi panjang yang dihitung dan tidak memotongnya ke slide.

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan thumbnail bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/php-java/aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [ditgekspor sebagai SVG vektor](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/writeassvg/) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender thumbnail?**

`Shape` menggunakan geometri bentuk; `Appearance` memperhitungkan [visual effects](/slides/id/php-java/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah tetap akan dirender sebagai thumbnail?**

Bentuk tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan slideshow tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah grup bentuk, bagan, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Objek apa pun yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/)) dapat disimpan sebagai thumbnail atau sebagai SVG.

**Apakah font yang terpasang pada sistem memengaruhi kualitas thumbnail untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/php-java/custom-font/) (atau [mengonfirmasi substitusi font](/slides/id/php-java/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan reflow teks.