---
title: "Menambahkan Bentuk Garis ke Presentasi di PHP"
linktitle: "Garis"
type: docs
weight: 50
url: /id/php-java/Line/
keywords:
  - garis
  - membuat garis
  - menambahkan garis
  - garis polos
  - mengkonfigurasi garis
  - menyesuaikan garis
  - gaya dash
  - kepala panah
  - PowerPoint
  - presentasi
  - PHP
  - Aspose.Slides
description: "Pelajari cara memanipulasi format garis dalam presentasi PowerPoint dengan Aspose.Slides untuk PHP via Java. Temukan properti, metode, dan contoh."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menambahkan bentuk garis ke slide PowerPoint secara programatis. Artikel ini menunjukkan cara membuat garis sederhana dan cara menyesuaikan garis sehingga muncul sebagai panah.

Anda akan mempelajari cara menambahkan bentuk garis ke slide, menyesuaikan tampilan visualnya, dan menyimpan presentasi yang diperbarui. Contoh-contoh berfokus pada pengaturan format garis praktis seperti gaya, lebar, pola dash, opsi kepala panah, dan warna isi.

## **Buat Garis Sederhana**

Untuk menambahkan garis sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah di bawah ini:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan AutoShape tipe Line menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addAutoShape) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/).
- Tuliskan presentasi yang dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah menambahkan garis ke slide pertama presentasi.

```php
  # Membuat instance kelas PresentationEx yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Tambahkan AutoShape tipe garis
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Simpan PPTX ke Disk
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Buat Garis Berbentuk Panah**

Aspose.Slides untuk PHP via Java juga memungkinkan pengembang mengkonfigurasi beberapa properti garis agar tampak lebih menarik. Mari coba mengkonfigurasi beberapa properti garis agar terlihat seperti panah. Ikuti langkah-langkah di bawah ini:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan AutoShape tipe Line menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addAutoShape) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/).
- Atur [Line Style](https://reference.aspose.com/slides/id/php-java/aspose.slides/LineStyle) ke salah satu gaya yang disediakan oleh Aspose.Slides untuk PHP via Java.
- Atur Width garis.
- Atur [Dash Style](https://reference.aspose.com/slides/id/php-java/aspose.slides/LineDashStyle) garis ke salah satu gaya yang disediakan oleh Aspose.Slides untuk PHP via Java.
- Atur [Arrow Head Style](https://reference.aspose.com/slides/id/php-java/aspose.slides/LineArrowheadStyle) dan [Length](https://reference.aspose.com/slides/id/php-java/aspose.slides/LineArrowheadLength) titik awal garis.
- Atur [Arrow Head Style](https://reference.aspose.com/slides/id/php-java/aspose.slides/LineArrowheadStyle) dan [Length](https://reference.aspose.com/slides/id/php-java/aspose.slides/LineArrowheadLength) titik akhir garis.
- Tuliskan presentasi yang dimodifikasi sebagai file PPTX.

```php
  # Membuat instance kelas PresentationEx yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Tambahkan AutoShape tipe garis
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Terapkan beberapa format pada garis
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Simpan PPTX ke Disk
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat mengubah garis biasa menjadi konektor sehingga ia "menempel" pada bentuk?**

Tidak. Garis biasa (sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) dengan tipe [Line](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapetype/)) tidak secara otomatis menjadi konektor. Untuk membuatnya menempel pada bentuk, gunakan tipe [Connector](https://reference.aspose.com/slides/id/php-java/aspose.slides/connector/) khusus dan [API yang sesuai](/slides/id/php-java/connector/) untuk koneksi.

**Apa yang harus saya lakukan jika properti garis diwarisi dari tema dan sulit menentukan nilai akhir?**

[Baca properti efektif](/slides/id/php-java/shape-effective-properties/) melalui `LineFormatEffectiveData`/`LineFillFormatEffectiveData`—ini sudah memperhitungkan pewarisan dan gaya tema.

**Apakah saya dapat mengunci garis agar tidak dapat diedit (dipindahkan, diubah ukurannya)?**

Ya. Bentuk menyediakan [lock objects](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/getautoshapelock/) yang memungkinkan Anda melarang operasi pengeditan.