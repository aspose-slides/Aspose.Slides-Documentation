---
title: Buat Thumbnail Bentuk Presentasi di PHP
linktitle: Thumbnail Bentuk
type: docs
weight: 70
url: /id/php-java/create-shape-thumbnails/
keywords:
- thumbnail bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Hasilkan thumbnail bentuk berkualitas tinggi dari slide PowerPoint dengan Aspose.Slides untuk PHP via Java – dengan mudah membuat dan mengekspor thumbnail presentasi."
---
## **Pendahuluan**

Aspose.Slides digunakan untuk membuat file presentasi di mana setiap halaman adalah slide. Slide ini dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun terkadang, pengembang mungkin perlu melihat gambar bentuk secara terpisah di penampil gambar. Dalam kasus seperti itu, Aspose.Slides membantu Anda menghasilkan gambar mini thumbnail dari bentuk slide. Cara menggunakan fitur ini dijelaskan dalam artikel ini.

Artikel ini menjelaskan cara menghasilkan thumbnail slide dengan berbagai cara:

- Menghasilkan thumbnail bentuk di dalam slide.
- Menghasilkan thumbnail bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.
- Menghasilkan thumbnail bentuk dalam batas tampilan bentuk.

## **Hasilkan Thumbnail Bentuk dari Slide**
Untuk menghasilkan thumbnail bentuk dari slide mana pun menggunakan Aspose.Slides untuk PHP via Java, lakukan hal berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
2. Dapatkan referensi dari slide mana pun menggunakan ID atau indeksnya.
3. [Dapatkan gambar thumbnail bentuk](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage) dari slide yang direferensikan pada skala default.
4. Simpan gambar thumbnail dalam format gambar pilihan Anda.

Kode contoh ini menunjukkan cara menghasilkan thumbnail bentuk dari slide:

```php
  # Membuat instance kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Membuat gambar skala penuh
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

## **Hasilkan Thumbnail dengan Faktor Skala yang Ditentukan Pengguna**
Untuk menghasilkan thumbnail bentuk dari slide menggunakan Aspose.Slides untuk PHP via Java, lakukan hal berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
2. Dapatkan referensi dari slide mana pun menggunakan ID atau indeksnya.
3. [Dapatkan gambar thumbnail bentuk](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage) dari slide yang direferensikan dengan dimensi yang ditentukan pengguna.
4. Simpan gambar thumbnail dalam format gambar pilihan Anda.

Kode contoh ini menunjukkan cara menghasilkan thumbnail bentuk berdasarkan faktor skala yang ditentukan:

```php
  # Membuat instance kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Membuat gambar skala penuh
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Menyimpan gambar ke disk dalam format PNG
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

## **Buat Thumbnail Tampilan Bentuk Berbasis Batas**
Metode ini untuk membuat thumbnail bentuk memungkinkan pengembang menghasilkan thumbnail dalam batas tampilan bentuk. Metode ini memperhitungkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan thumbnail bentuk slide dalam batas tampilannya, lakukan hal berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
2. Dapatkan referensi dari slide mana pun menggunakan ID atau indeksnya.
3. Dapatkan gambar thumbnail dari slide yang direferensikan dengan batas bentuk sebagai tampilan.
4. Simpan gambar thumbnail dalam format gambar pilihan Anda.

Kode contoh ini didasarkan pada langkah-langkah di atas:

```php
  # Membuat instance kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Membuat gambar skala penuh
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Menyimpan gambar ke disk dalam format PNG
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

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan thumbnail bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/php-java/aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [dieksport sebagai SVG vektor](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/writeassvg/) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender thumbnail?**

`Shape` menggunakan geometri bentuk; `Appearance` memperhitungkan [efek visual](/slides/id/php-java/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah itu tetap akan dirender sebagai thumbnail?**

Bentuk yang tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan slideshow tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah bentuk grup, diagram, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Setiap objek yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/php-java/aspose.slides/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartart/)) dapat disimpan sebagai thumbnail atau sebagai SVG.

**Apakah font yang diinstal pada sistem memengaruhi kualitas thumbnail untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/php-java/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/php-java/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan perataan ulang teks.