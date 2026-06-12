---
title: Menyematkan Font dalam Presentasi Menggunakan PHP
linktitle: Menyematkan Font
type: docs
weight: 40
url: /id/php-java/embedded-font/
keywords:
- menambahkan font
- menyematkan font
- penyematan font
- mengambil font yang disematkan
- menambahkan font yang disematkan
- menghapus font yang disematkan
- mengompres font yang disematkan
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Menyematkan font TrueType dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk PHP via Java, memastikan rendering yang akurat di semua platform."
---
## **Pendahuluan**

**Embedded fonts in PowerPoint** berguna ketika Anda ingin presentasi Anda tampil dengan benar saat dibuka di sistem atau perangkat apa pun. Jika Anda menggunakan font pihak ketiga atau non‑standar karena berkreasi dengan pekerjaan Anda, maka Anda memiliki alasan lebih untuk menyematkan font Anda. Sebaliknya (tanpa font yang disematkan), teks atau angka pada slide Anda, tata letak, gaya, dll. dapat berubah atau menjadi kotak‑kotak yang membingungkan. 

Kelas [FontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontsManager), kelas [FontData](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontdata/) dan kelas [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/) berisi sebagian besar metode yang Anda perlukan untuk bekerja dengan font yang disematkan dalam presentasi PowerPoint.

## **Dapatkan dan Hapus Font yang Disematkan**

Aspose.Slides menyediakan metode [getEmbeddedFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (yang dipaparkan oleh kelas [FontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontsManager)) untuk memungkinkan Anda memperoleh (atau mengetahui) font yang disematkan dalam sebuah presentasi. Untuk menghapus font, metode [removeEmbeddedFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (yang dipaparkan oleh kelas yang sama) digunakan.

Kode PHP berikut menunjukkan cara mendapatkan dan menghapus font yang disematkan dari sebuah presentasi:

```php
  # Membuat objek Presentation yang mewakili file presentasi
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Merender slide yang berisi bingkai teks yang menggunakan "FunSized" yang disematkan
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Menyimpan gambar ke disk dalam format JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Mendapatkan semua font yang disematkan
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Mencari font "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Menghapus font "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Merender presentasi; "Calibri" font diganti dengan yang sudah ada
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Menyimpan gambar ke disk dalam format JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Menyimpan presentasi tanpa font "Calibri" yang disematkan ke disk
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tambahkan Font yang Disematkan**

Dengan menggunakan kelas [EmbedFontCharacters](https://reference.aspose.com/slides/id/php-java/aspose.slides/embedfontcharacters/) dan dua overload dari metode [addEmbeddedFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#addEmbeddedFont), Anda dapat memilih aturan (penyematan) yang diinginkan untuk menyematkan font dalam sebuah presentasi. Kode PHP berikut menunjukkan cara menyematkan dan menambahkan font ke sebuah presentasi:

```php
  # Memuat presentasi
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # Menyimpan presentasi ke disk
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kompres Font yang Disematkan**

Agar Anda dapat mengompres font yang disematkan dalam sebuah presentasi dan mengurangi ukuran berkasnya, Aspose.Slides menyediakan metode [compressEmbeddedFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#compressEmbeddedFonts) (yang dipaparkan oleh kelas [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/)).

Kode PHP berikut menunjukkan cara mengompres font PowerPoint yang disematkan:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa font tertentu dalam presentasi masih akan digantikan selama rendering meskipun telah disematkan?**

Periksa [informasi substitusi](/slides/id/php-java/font-substitution/) di manajer font dan [aturan fallback/substitusi](/slides/id/php-java/fallback-font/): jika font tidak tersedia atau dibatasi, fallback akan digunakan.

**Apakah layak menyematkan font "system" seperti Arial/Calibri?**

Biasanya tidak—font tersebut hampir selalu tersedia. Namun untuk portabilitas penuh dalam lingkungan "tipis" (Docker, server Linux tanpa font yang terpasang sebelumnya), menyematkan font sistem dapat menghilangkan risiko substitusi yang tidak terduga.