---
title: Mengonversi Slide PowerPoint ke PNG dalam PHP
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
description: "Mengonversi presentasi PowerPoint menjadi gambar PNG berkualitas tinggi dengan cepat menggunakan Aspose.Slides untuk PHP via Java, memastikan hasil yang tepat dan otomatis."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke gambar PNG menggunakan Aspose.Slides. Artikel ini menunjukkan cara memuat file presentasi dalam format seperti PPT, PPTX, dan ODP, merender slide sebagai gambar, dan menyimpan hasilnya dalam format PNG.

Artikel ini juga menunjukkan cara menyesuaikan gambar PNG yang dihasilkan dengan mengatur nilai skala atau menentukan lebar dan tinggi yang diinginkan.

## **Konversi PowerPoint ke PNG**

Ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Dapatkan objek slide dari koleksi [Presentation.getSlides()](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSlides) pada kelas [Slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/).
3. Gunakan metode [Slide.getImage()](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getImage) untuk mendapatkan thumbnail setiap slide.
4. Gunakan metode [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/#save) untuk menyimpan thumbnail slide ke format PNG.

Kode PHP berikut menunjukkan cara mengonversi presentasi PowerPoint ke PNG:
```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Konversi PowerPoint ke PNG dengan Dimensi Kustom**

Jika Anda ingin memperoleh file PNG dengan skala tertentu, Anda dapat mengatur nilai `desiredX` dan `desiredY`, yang menentukan dimensi thumbnail yang dihasilkan.

Kode ini menunjukkan operasi yang dijelaskan:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Konversi PowerPoint ke PNG dengan Ukuran Kustom**

Jika Anda ingin memperoleh file PNG dengan ukuran tertentu, Anda dapat memberikan argumen `width` dan `height` yang Anda inginkan untuk `ImageSize`.

Kode ini menunjukkan cara mengonversi PowerPoint ke PNG sambil menentukan ukuran gambar:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Bagaimana saya dapat mengekspor hanya bentuk tertentu (misalnya grafik atau gambar) alih‑alih seluruh slide?**

Aspose.Slides mendukung [generating thumbnails for individual shapes](/slides/id/php-java/create-shape-thumbnails/); Anda dapat merender sebuah bentuk menjadi gambar PNG.

**Apakah konversi paralel didukung pada server?**

Ya, tetapi [don’t share](/slides/id/php-java/multithreading/) satu instance presentasi di seluruh thread. Gunakan instance terpisah per thread atau proses.

**Apa batasan versi percobaan saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan memberlakukan [other restrictions](/slides/id/php-java/licensing/) hingga lisensi diterapkan.