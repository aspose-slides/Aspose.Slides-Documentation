---
title: Kelola Properti Presentasi dalam PHP
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/php-java/presentation-properties/
keywords:
- properti PowerPoint
- properti presentasi
- properti dokumen
- properti bawaan
- properti kustom
- properti lanjutan
- kelola properti
- modifikasi properti
- metadata dokumen
- edit metadata
- bahasa proofing
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kuasai properti presentasi dalam Aspose.Slides untuk PHP via Java dan permudah pencarian, branding, serta alur kerja dalam file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides mendukung dua jenis properti dokumen: **Bawaan** dan **Kustom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui kelas [DocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/) . Sebuah instance kelas ini dikembalikan oleh metode [Presentation::getDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getDocumentProperties) . Contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti-properti tersebut.

{{% alert color="primary" %}} 
Harap dicatat bahwa bidang **Application** dan **Producer** tidak dapat diubah, karena bidang tersebut akan selalu menampilkan "Aspose Ltd." dan "Aspose.Slides for PHP via Java x.x.x".
{{% /alert %}} 

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan beberapa properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama dokumen (file presentasi). Ada dua jenis properti dokumen sebagai berikut

- Properti yang Ditentukan Sistem (Bawaan)
- Properti yang Ditentukan Pengguna (Kustom)

Properti **Bawaan** berisi informasi umum tentang dokumen seperti judul dokumen, nama penulis, statistik dokumen, dan sebagainya. Properti **Kustom** adalah properti yang didefinisikan oleh pengguna sebagai pasangan **Nama/Nilai**, di mana nama dan nilai ditentukan oleh pengguna. Menggunakan Aspose.Slides for PHP via Java, pengembang dapat mengakses dan memodifikasi nilai properti bawaan maupun properti kustom.

## **Properti Dokumen di PowerPoint**

Microsoft PowerPoint 2007 memungkinkan pengelolaan properti dokumen file presentasi. Yang perlu Anda lakukan hanyalah mengklik ikon Office dan selanjutnya **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007 seperti yang ditunjukkan di bawah:

|**Memilih menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Setelah Anda memilih menu **Advanced Properties**, sebuah dialog akan muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint seperti yang ditunjukkan pada gambar berikut:

|**Dialog Properti**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Pada **Dialog Properti** di atas, Anda dapat melihat banyak tab seperti **General**, **Summary**, **Statistics**, **Contents**, dan **Custom**. Semua tab ini memungkinkan konfigurasi berbagai jenis informasi terkait file PowerPoint. Tab **Custom** digunakan untuk mengelola properti kustom file PowerPoint.

### Bekerja dengan Properti Dokumen Menggunakan Aspose.Slides for PHP via Java

Seperti yang dijelaskan sebelumnya, Aspose.Slides for PHP via Java mendukung dua jenis properti dokumen, yaitu properti **Bawaan** dan **Kustom**. Jadi, pengembang dapat mengakses kedua jenis properti tersebut dengan menggunakan API Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java menyediakan kelas [DocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties) yang mewakili properti dokumen yang terkait dengan file presentasi melalui properti **Presentation.DocumentProperties**.

Pengembang dapat menggunakan properti **DocumentProperties** yang diekspor oleh objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation) untuk mengakses properti dokumen file presentasi seperti dijelaskan di bawah:

## **Akses Properti Bawaan**

Properti yang diekspor oleh objek [DocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties) meliputi: **Creator** (Penulis), **Description**, **Keywords**, **Created** (Tanggal Pembuatan), **Modified** (Tanggal Modifikasi), **Printed** (Tanggal Cetak Terakhir), **LastModifiedBy**, **Keywords**, **SharedDoc** (Apakah dibagikan antara produsen yang berbeda?), **PresentationFormat**, **Subject**, dan **Title**

```php
  # Membuat instance kelas Presentation yang mewakili presentasi
  $pres = new Presentation("Presentation.pptx");
  try {
    # Membuat referensi ke objek IDocumentProperties yang terkait dengan Presentation
    $dp = $pres->getDocumentProperties();
    # Menampilkan properti bawaan
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modifikasi Properti Bawaan**

Memodifikasi properti bawaan file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti akan dimodifikasi. Pada contoh di bawah, kami mendemonstrasikan cara memodifikasi properti dokumen bawaan file presentasi menggunakan Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Membuat referensi ke objek IDocumentProperties yang terkait dengan Presentation
    $dp = $pres->getDocumentProperties();
    # Mengatur properti bawaan
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Simpan presentasi Anda ke sebuah file
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Contoh ini memodifikasi properti bawaan presentasi yang dapat dilihat seperti berikut:

|**Properti dokumen bawaan setelah modifikasi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Menambahkan Properti Dokumen Kustom**

Aspose.Slides for PHP via Java juga memungkinkan pengembang menambahkan nilai kustom untuk properti dokumen presentasi. Contoh di bawah menunjukkan cara mengatur properti kustom untuk sebuah presentasi.

```php
  $pres = new Presentation();
  try {
    # Mendapatkan Properti Dokumen
    $dProps = $pres->getDocumentProperties();
    # Menambahkan properti Kustom
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Mendapatkan nama properti pada indeks tertentu
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Menghapus properti yang dipilih
    $dProps->removeCustomProperty($getPropertyName);
    # Menyimpan presentasi
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Properti Dokumen Kustom Ditambahkan**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Akses dan Modifikasi Properti Kustom**

Aspose.Slides for PHP via Java juga memungkinkan pengembang mengakses nilai properti kustom. Contoh di bawah menunjukkan cara mengakses dan memodifikasi semua properti kustom untuk sebuah presentasi.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Membuat referensi ke objek DocumentProperties yang terkait dengan Presentation
    $dp = $pres->getDocumentProperties();
    # Mengakses dan memodifikasi properti kustom
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Menampilkan nama dan nilai properti kustom
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Memodifikasi nilai properti kustom
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Simpan presentasi Anda ke sebuah file
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Contoh ini memodifikasi properti kustom dari [PPTX](https://docs.fileformat.com/presentation/pptx/) presentasi. Gambar berikut menunjukkan properti kustom presentasi sebelum dan sesudah modifikasi:

|**Properti Kustom Sebelum Modifikasi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Properti Kustom Setelah Modifikasi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Properti Dokumen Lanjutan**

{{% alert color="primary" %}} 
Metode baru [readDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), dan [writeBindedPresentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) telah ditambahkan ke [PresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo), logika setter properti [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#setLastSavedTime) telah diubah.
{{% /alert %}} 

Dua metode baru [readDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) dan [updateDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) telah ditambahkan ke kelas [PresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo). Mereka menyediakan akses cepat ke properti dokumen dan memungkinkan mengubah serta memperbarui properti tanpa memuat seluruh presentasi.

Skenario tipikal memuat properti, mengubah beberapa nilai, dan memperbarui dokumen dapat diimplementasikan dengan cara berikut:

```php
  # baca info presentasi
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # dapatkan properti saat ini
  $props = $info->readDocumentProperties();
  # atur nilai baru untuk bidang Author dan Title
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # perbarui presentasi dengan nilai baru
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Ada cara lain untuk menggunakan properti sebuah presentasi tertentu sebagai templat untuk memperbarui properti pada presentasi lain:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

Templat baru dapat dibuat dari awal dan kemudian digunakan untuk memperbarui beberapa presentasi:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **Atur Bahasa Proofing**

Aspose.Slides menyediakan properti LanguageId (diekspos oleh kelas PortionFormat) untuk memungkinkan Anda mengatur bahasa proofing untuk dokumen PowerPoint. Bahasa proofing adalah bahasa yang akan diperiksa ejaan dan tata bahasanya dalam PowerPoint.

Kode PHP ini menunjukkan cara mengatur bahasa proofing untuk PowerPoint: xxx Mengapa LanguageId tidak ada pada kelas Java PortionFormat?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// atur Id bahasa proofing

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Atur Bahasa Default**

Kode PHP ini menunjukkan cara mengatur bahasa default untuk seluruh presentasi PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Menambahkan bentuk persegi panjang baru dengan teks
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Memeriksa bahasa bagian pertama
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Contoh Langsung**

Coba aplikasi online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen melalui API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **FAQ**

**Bagaimana cara menghapus properti bawaan dari sebuah presentasi?**

Properti bawaan merupakan bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau menetapkannya menjadi kosong jika properti tersebut mengizinkannya.

**Apa yang terjadi jika saya menambahkan properti kustom yang sudah ada?**

Jika Anda menambahkan properti kustom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut terlebih dahulu, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Dapatkah saya mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya, Anda dapat mengakses properti presentasi tanpa memuat seluruh presentasi dengan menggunakan metode `getPresentationInfo` dari kelas [PresentationFactory](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/) . Kemudian, manfaatkan metode `readDocumentProperties` yang disediakan oleh kelas [PresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/) untuk membaca properti secara efisien, menghemat memori dan meningkatkan kinerja.