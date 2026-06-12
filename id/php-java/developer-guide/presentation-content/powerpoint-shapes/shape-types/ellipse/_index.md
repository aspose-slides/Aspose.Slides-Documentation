---
title: Menambahkan Elips ke Presentasi dalam PHP
linktitle: Elips
type: docs
weight: 30
url: /id/php-java/ellipse/
keywords:
- elips
- bentuk
- tambahkan elips
- buat elips
- gambar elips
- elips terformat
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara membuat, memformat, dan memanipulasi bentuk elips di Aspose.Slides untuk PHP via Java pada presentasi PPT dan PPTX — contoh kode disertakan."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara menambahkan bentuk elips ke slide PowerPoint dengan menggunakan Aspose.Slides. Artikel ini mencakup pembuatan elips sederhana, pembuatan elips yang diformat, dan menyimpan presentasi yang diperbarui sebagai file PPTX. Artikel ini juga membahas pertanyaan terkait seperti mengatur posisi dan ukuran elips, mengontrol urutan tumpukan, dan menerapkan efek animasi.

## **Buat Elips**

Untuk menambahkan elips sederhana ke slide yang dipilih dalam presentasi, silakan ikuti langkah-langkah di bawah ini:

- Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Indeksnya.
- Tambahkan AutoShape tipe Ellipse menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addAutoShape) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/).
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah menambahkan elips ke slide pertama

```php
  # Membuat instance kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Tambahkan AutoShape tipe elips
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Tulis file PPTX ke disk
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Buat Elips yang Diformat**

Untuk menambahkan elips yang diformat lebih baik ke sebuah slide, silakan ikuti langkah-langkah di bawah ini:

- Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Indeksnya.
- Tambahkan AutoShape tipe Ellipse menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addAutoShape) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/).
- Setel Tipe Isi (Fill Type) Elips menjadi Solid.
- Setel Warna Elips menggunakan metode `SolidFillColor::setColor` yang disediakan oleh objek [FillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/) yang terkait dengan objek [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/).
- Setel Warna garis Elips.
- Setel Lebar garis Elips.
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah menambahkan elips yang diformat ke slide pertama presentasi.

```php
  # Membuat instance kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Tambahkan AutoShape tipe elips
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Terapkan beberapa format ke bentuk elips
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Terapkan beberapa format ke garis Elips
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Tulis file PPTX ke disk
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tanya Jawab**

**Bagaimana cara mengatur posisi dan ukuran tepat sebuah elips relatif terhadap satuan slide?**

Koordinat dan ukuran biasanya ditentukan **dalam poin**. Untuk hasil yang dapat diprediksi, dasar perhitungan Anda pada ukuran slide dan konversikan milimeter atau inci yang diperlukan ke poin sebelum menetapkan nilai.

**Bagaimana saya dapat menempatkan elips di atas atau di bawah objek lain (mengontrol urutan tumpukan)?**

Sesuaikan urutan gambar objek dengan membawanya ke depan atau mengirimnya ke belakang. Ini memungkinkan elips menutupi objek lain atau memperlihatkan yang berada di bawahnya.

**Bagaimana cara saya menganimasikan penampilan atau penekanan sebuah elips?**

[Terapkan](/slides/id/php-java/shape-animation/) efek masuk, penekanan, atau keluar pada bentuk, dan konfigurasikan pemicu serta timing untuk mengatur kapan dan bagaimana animasi diputar.