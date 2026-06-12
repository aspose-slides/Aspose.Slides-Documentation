---
title: Menambahkan Persegi Panjang ke Presentasi dalam PHP
linktitle: Persegi Panjang
type: docs
weight: 80
url: /id/php-java/rectangle/
keywords:
- menambahkan persegi panjang
- membuat persegi panjang
- bentuk persegi panjang
- persegi panjang sederhana
- persegi panjang terformat
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Tingkatkan presentasi PowerPoint Anda dengan menambahkan persegi panjang menggunakan Aspose.Slides untuk PHP melalui Java — dengan mudah merancang dan memodifikasi bentuk secara programatis."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara menambahkan bentuk persegi panjang ke slide PowerPoint menggunakan Aspose.Slides. Artikel ini mencakup pembuatan persegi panjang sederhana, pembuatan persegi panjang yang diformat, dan menyimpan presentasi yang diperbarui sebagai file PPTX.

Anda juga akan melihat cara menerapkan pemformatan persegi panjang dasar, seperti warna isi solid, warna garis, dan lebar garis. Selain itu, FAQ artikel mengarahkan ke tugas‑tugas terkait persegi panjang, termasuk sudut melengkung, isi gambar, efek visual, hyperlink, kunci bentuk, opsi ekspor, dan properti efektif.

## **Menambahkan Persegi Panjang ke Slide**
Untuk menambahkan persegi panjang sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) tipe Rectangle menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addAutoShape) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/).
- Tuliskan presentasi yang dimodifikasi sebagai file PPTX.

Pada contoh di bawah, kami telah menambahkan persegi panjang sederhana ke slide pertama presentasi.

```php
  # Instansiasi kelas Presentation yang mewakili PPTX
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Tambahkan AutoShape tipe elips
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Tuliskan file PPTX ke disk
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menambahkan Persegi Panjang yang Diformat ke Slide**
Untuk menambahkan persegi panjang yang diformat ke slide, ikuti langkah‑langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) tipe Rectangle menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addAutoShape) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/).
- Setel [Fill Type](https://reference.aspose.com/slides/id/php-java/aspose.slides/FillType) Persegi Panjang ke Solid.
- Setel Warna Persegi Panjang menggunakan metode [ColorFormat::setColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/colorformat/#setColor) yang disediakan oleh objek [FillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/) yang terkait dengan objek [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/).
- Setel Warna garis Persegi Panjang.
- Setel Lebar garis Persegi Panjang.
- Tuliskan presentasi yang dimodifikasi sebagai file PPTX.

Langkah‑langkah di atas diimplementasikan dalam contoh di bawah.

```php
  # Instansiasi kelas Presentation yang mewakili PPTX
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Tambahkan AutoShape tipe elips
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Terapkan beberapa pemformatan pada bentuk elips
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Terapkan beberapa pemformatan pada garis Elips
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Tuliskan file PPTX ke disk
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Bagaimana cara menambahkan persegi panjang dengan sudut melengkung?**

Gunakan [shape type](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapetype/) dengan sudut melengkung dan sesuaikan radius sudut dalam properti bentuk; pembulatan juga dapat diterapkan per sudut melalui penyesuaian geometri.

**Bagaimana cara mengisi persegi panjang dengan gambar (tekstur)?**

Pilih [fill type](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) gambar, berikan sumber gambar, dan konfigurasikan [mode stretching/tiling](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillmode/).

**Apakah persegi panjang dapat memiliki bayangan dan glow?**

Ya. [Outer/inner shadow, glow, and soft edges](/slides/id/php-java/shape-effect/) tersedia dengan parameter yang dapat disesuaikan.

**Bisakah saya mengubah persegi panjang menjadi tombol dengan hyperlink?**

Ya. [Assign a hyperlink](/slides/id/php-java/manage-hyperlinks/) ke klik bentuk (melompat ke slide, file, alamat web, atau email).

**Bagaimana saya dapat melindungi persegi panjang dari pemindahan dan perubahan?**

Gunakan kunci bentuk: Anda dapat melarang pemindahan, pengubahan ukuran, pemilihan, atau pengeditan teks untuk menjaga tata letak.

**Bisakah saya mengonversi persegi panjang menjadi gambar raster atau SVG?**

Ya. Anda dapat [render the shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage) menjadi gambar dengan ukuran/skal tertentu atau [export it as SVG](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/writeassvg/) untuk penggunaan vektor.

**Bagaimana cara cepat mendapatkan properti aktual (efektif) dari persegi panjang dengan mempertimbangkan tema dan pewarisan?**

[Gunakan properti efektif bentuk](/slides/id/php-java/shape-effective-properties/): API mengembalikan nilai yang dihitung yang memperhitungkan gaya tema, tata letak, dan pengaturan lokal, mempermudah analisis pemformatan.