---
title: "Bentuk Presentasi Grup di PHP"
linktitle: "Grup Bentuk"
type: docs
weight: 40
url: /id/php-java/group/
keywords:
- "bentuk grup"
- "grup bentuk"
- "tambahkan grup"
- "teks alternatif"
- "PowerPoint"
- "presentasi"
- "PHP"
- "Aspose.Slides"
description: "Pelajari cara mengelompokkan dan memisahkan bentuk dalam deck PowerPoint menggunakan Aspose.Slides untuk PHP via Java — panduan cepat langkah demi langkah dengan kode gratis."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan bentuk grup di Aspose.Slides. Ini menunjukkan cara menambahkan bentuk grup ke slide, menempatkan bentuk di dalamnya, dan menyimpan presentasi yang telah diperbarui. Artikel ini juga memperlihatkan cara mengakses bentuk yang disimpan di dalam grup dan membaca nilai `AlternativeText`‑nya. Selain itu, artikel ini secara singkat membahas kemampuan bentuk grup terkait seperti grup bertingkat, urutan‑z, dan opsi penguncian.

## **Tambahkan Bentuk Grup**
Aspose.Slides mendukung kerja dengan bentuk grup pada slide. Fitur ini membantu pengembang membuat presentasi yang lebih kaya. Aspose.Slides untuk PHP via Java mendukung penambahan atau akses bentuk grup. Anda dapat menambahkan bentuk ke bentuk grup yang telah ditambahkan untuk mengisinya atau mengakses properti apa pun dari bentuk grup. Untuk menambahkan bentuk grup ke slide menggunakan Aspose.Slides untuk PHP via Java:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
1. Dapatkan referensi slide dengan menggunakan Indeksnya.
1. Tambahkan bentuk grup ke slide.
1. Tambahkan bentuk‑bentuk ke bentuk grup yang telah ditambahkan.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Contoh di bawah ini menambahkan bentuk grup ke slide.

```php
  # Instansiasi kelas Presentation
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Mengakses koleksi bentuk slide
    $slideShapes = $sld->getShapes();
    # Menambahkan bentuk grup ke slide
    $groupShape = $slideShapes->addGroupShape();
    # Menambahkan bentuk di dalam bentuk grup yang ditambahkan
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Menambahkan bingkai bentuk grup
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Menulis file PPTX ke disk
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Akses Properti AltText**
Topik ini menunjukkan langkah‑langkah sederhana, lengkap dengan contoh kode, untuk menambahkan bentuk grup dan mengakses properti AltText dari bentuk grup pada slide. Untuk mengakses AltText dari bentuk grup di slide menggunakan Aspose.Slides untuk PHP via Java:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) yang mewakili file PPTX.
1. Dapatkan referensi slide dengan menggunakan Indeksnya.
1. Akses koleksi bentuk pada slide.
1. Akses bentuk grup.
1. Akses properti [Alternative Text](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getAlternativeText).

Contoh di bawah ini mengakses teks alternatif dari bentuk grup.

```php
  # Instansiasi kelas Presentation yang mewakili file PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Dapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Mengakses koleksi bentuk slide
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Mengakses bentuk grup.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Mengakses properti AltText
          echo($shape2->getAlternativeText());
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

**Apakah pengelompokan bersarang (sebuah grup di dalam grup) didukung?**

Ya. [GroupShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/groupshape/) memiliki metode [getParentGroup](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getparentgroup/) yang secara langsung menunjukkan dukungan hierarki (sebuah grup dapat menjadi anak dari grup lain).

**Bagaimana saya mengontrol urutan‑z grup relatif terhadap objek lain pada slide?**

Gunakan metode [getZOrderPosition](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getzorderposition/) pada [GroupShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/groupshape/) untuk memeriksa posisinya dalam tumpukan tampilan.

**Apakah saya dapat mencegah pemindahan/penyuntingan/pemecahan grup?**

Ya. Bagian penguncian grup tersedia melalui [GroupShapeLock](https://reference.aspose.com/slides/id/php-java/aspose.slides/groupshape/getgroupshapelock/), yang memungkinkan Anda membatasi operasi pada objek tersebut.