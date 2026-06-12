---
title: Mengelola Tag dan Data Khusus dalam Presentasi Menggunakan PHP
linktitle: Tag dan Data Khusus
type: docs
weight: 300
url: /id/php-java/managing-tags-and-custom-data/
keywords:
- properti dokumen
- tag
- data khusus
- tambahkan tag
- nilai pasangan
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara menambah, membaca, memperbarui, dan menghapus tag & data khusus di Aspose.Slides untuk PHP via Java, dengan contoh untuk presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara Aspose.Slides bekerja dengan tag dan data khusus dalam presentasi PowerPoint. Secara singkat dijabarkan bagaimana data disimpan dalam file PPTX, dicatat bahwa data spesifik presentasi dapat ada sebagai tag dan bagian XML khusus, serta dijelaskan bahwa tag merupakan pasangan string kunci‑nilai.

Artikel ini juga menunjukkan cara membaca nilai tag dan cara menambahkan tag ke presentasi, slide individu, atau shape. Selain itu, artikel mencakup tugas manajemen tag umum seperti menghapus semua tag, menghapus tag berdasarkan nama, dan mengambil daftar nama tag.

## **Penyimpanan Data dalam File Presentasi**

File PPTX—item dengan ekstensi .pptx—disimpan dalam format PresentationML, yang merupakan bagian dari spesifikasi Office Open XML. Format Office Open XML mendefinisikan struktur data yang terkandung dalam presentasi.

Dengan *slide* sebagai salah satu elemen dalam presentasi, sebuah *slide part* berisi konten satu slide. Sebuah slide part diperbolehkan memiliki hubungan eksplisit ke banyak bagian—seperti User Defined Tags—yang didefinisikan oleh ISO/IEC 29500.

Data khusus (spesifik untuk sebuah presentasi) atau pengguna dapat ada sebagai tag ([TagCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/)) dan CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 

Tag pada dasarnya adalah nilai pasangan kunci‑string. 

{{% /alert %}} 

## **Dapatkan Nilai Tag**

Dalam slides, sebuah tag berkorespondensi dengan metode [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#getKeywords) dan [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#setKeywords). Kode contoh ini menunjukkan cara mendapatkan nilai tag dengan Aspose.Slides untuk PHP via Java untuk [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation):

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menambahkan Tag ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan tag ke presentasi. Sebuah tag biasanya terdiri dari dua item:

- nama properti khusus - `MyTag` 
- nilai properti khusus - `My Tag Value`

Jika Anda perlu mengklasifikasikan beberapa presentasi berdasarkan aturan atau properti tertentu, maka Anda dapat memanfaatkan penambahan tag ke presentasi tersebut. Misalnya, jika ingin mengkategorikan atau mengelompokkan semua presentasi dari negara-negara Amerika Utara, Anda dapat membuat tag Amerika Utara dan kemudian menetapkan negara‑negara terkait (AS, Meksiko, dan Kanada) sebagai nilainya.

Kode contoh ini menunjukkan cara menambahkan tag ke sebuah [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) menggunakan Aspose.Slides untuk PHP via Java:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Tag juga dapat diatur untuk [Slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Atau setiap [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) individu:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Batasan**

Tag yang ditambahkan melalui koleksi tag data khusus dengan `getCustomData()->getTags()` hanya disimpan di dalam file PowerPoint. Tag tersebut **tidak** dipindahkan ke struktur tag PDF ketika presentasi diekspor ke PDF. Akibatnya, pengenal khusus yang ditetapkan sebagai tag tidak dapat diambil dari PDF yang ditandai.

**Solusi alternatif**: Anda dapat menyimpan pengenal khusus dalam **Alt Text** objek (misalnya, `$shape->setAlternativeText("MyId")`). Setelah diekspor ke PDF, Alt Text mungkin muncul dalam struktur tag PDF.

## **FAQ**

**Apakah saya dapat menghapus semua tag dari presentasi, slide, atau shape dalam satu operasi?**

Ya. [Koleksi tag](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/) mendukung operasi [clear](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/clear/) yang menghapus semua pasangan kunci‑nilai sekaligus.

**Bagaimana cara menghapus satu tag berdasarkan namanya tanpa iterasi seluruh koleksi?**

Gunakan operasi [remove(name)](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/remove/) pada [kumpulan tag](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/) untuk menghapus tag berdasarkan kuncinya.

**Bagaimana saya dapat mengambil daftar lengkap nama tag untuk analisis atau penyaringan?**

Gunakan [getNamesOfTags](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/getnamesoftags/) pada [kumpulan tag](https://reference.aspose.com/slides/id/php-java/aspose.slides/tagcollection/); metode ini mengembalikan array semua nama tag.