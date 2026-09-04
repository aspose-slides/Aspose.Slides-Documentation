---
title: Kelola Properti Presentasi di PHP
linktitle: Properti Presentasi
type: docs
weight: 70
url: /id/php-java/presentation-properties/
keywords:
- Properti PowerPoint
- Properti presentasi
- Properti dokumen
- Properti bawaan
- Properti khusus
- Properti tingkat lanjut
- Kelola properti
- Modifikasi properti
- Metadata dokumen
- Sunting metadata
- Bahasa pemeriksaan
- Bahasa default
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kuasai properti presentasi di Aspose.Slides for PHP via Java dan permudah pencarian, branding, serta alur kerja pada file PowerPoint dan OpenDocument Anda."
---
## **Pendahuluan**

Aspose.Slides mendukung dua jenis properti dokumen: **Built-in** dan **Custom**. Kedua jenis properti ini dapat dengan mudah diakses dan dikelola menggunakan API Aspose.Slides.

Aspose.Slides memungkinkan Anda bekerja dengan properti dokumen presentasi melalui kelas [DocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/) . Sebuah instance dari kelas ini dikembalikan oleh metode [Presentation::getDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getDocumentProperties) . Contoh-contoh berikut menunjukkan cara membaca, memodifikasi, dan mengelola properti tersebut.

{{% alert color="info" title="Note" %}}
Harap perhatikan bahwa field **Application** dan **AppVersion** tidak dapat dimodifikasi. Aspose.Slides menulis ulang mereka pada setiap penyimpanan, sehingga presentasi yang disimpan selalu melaporkan "Aspose.Slides for PHP via Java" dan versi perpustakaan yang menghasilkan. Nilai apa pun yang diberikan ke `setNameOfApplication` akan diabaikan saat presentasi ditulis.
{{% /alert %}} 

## **Kelola Properti Presentasi**

Microsoft PowerPoint menyediakan fitur untuk menambahkan beberapa properti ke file presentasi. Properti dokumen ini memungkinkan informasi berguna disimpan bersama dengan dokumen (file presentasi). Ada dua jenis properti dokumen sebagai berikut

- Properti yang Didefinisikan Sistem (Built-in)
- Properti yang Didefinisikan Pengguna (Custom)

Properti **Built-in** berisi informasi umum tentang dokumen seperti judul dokumen, nama penulis, statistik dokumen, dan sebagainya. Properti **Custom** adalah properti yang didefinisikan oleh pengguna sebagai pasangan **Name/Value**, di mana baik nama maupun nilai ditentukan oleh pengguna. Dengan menggunakan Aspose.Slides for PHP via Java, pengembang dapat mengakses dan memodifikasi nilai properti built-in maupun custom.

## **Properti Dokumen di PowerPoint**

Microsoft PowerPoint 2007 memungkinkan pengelolaan properti dokumen file presentasi. Yang perlu Anda lakukan adalah mengklik ikon Office dan kemudian menu **Prepare | Properties | Advanced Properties** pada Microsoft PowerPoint 2007 seperti yang ditampilkan di bawah ini:

|**Memilih item menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Setelah Anda memilih item menu **Advanced Properties**, sebuah dialog akan muncul yang memungkinkan Anda mengelola properti dokumen file PowerPoint seperti yang ditampilkan pada gambar di bawah ini:

|**Dialog Properti**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Dalam **Dialog Properti** di atas, Anda dapat melihat bahwa terdapat banyak halaman tab seperti **General**, **Summary**, **Statistics**, **Contents**, dan **Custom**. Semua halaman tab ini memungkinkan konfigurasi berbagai jenis informasi yang terkait dengan file PowerPoint. Tab **Custom** digunakan untuk mengelola properti custom dari file PowerPoint.

### Bekerja dengan Properti Dokumen Menggunakan Aspose.Slides for PHP via Java

Seperti yang telah kami jelaskan sebelumnya, Aspose.Slides for PHP via Java mendukung dua jenis properti dokumen, yaitu properti **Built-in** dan **Custom**. Jadi, pengembang dapat mengakses kedua jenis properti tersebut dengan menggunakan API Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java menyediakan kelas [DocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties) yang merepresentasikan properti dokumen yang terkait dengan file presentasi melalui properti **Presentation.DocumentProperties**.

Pengembang dapat menggunakan properti **DocumentProperties** yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation) untuk mengakses properti dokumen file presentasi seperti dijelaskan di bawah ini:

## **Baca Properti Publik dari Presentasi yang Terenkripsi**

Password pembuka biasanya melindungi baik konten presentasi maupun properti dokumen. Ketika sebuah presentasi dienkripsi dengan memberikan `false` ke [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), properti dokumennya tetap publik. Aplikasi kemudian dapat memberikan `true` ke [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) dan membaca metadata publik tanpa menyediakan password pembuka.

Opsi document-properties-only mengontrol apa yang dimuat Aspose.Slides; opsi ini tidak mendekripsi apa pun. Jika properti termasuk dalam enkripsi, memuatnya tanpa password akan gagal. Jika presentasi tidak dienkripsi, opsi ini diabaikan dan seluruh presentasi dimuat.

Contoh berikut memverifikasi mode pemuatan melalui [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) dan kemudian membaca properti built-in melalui [Presentation::getDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

Dalam mode ini, konten slide tidak dimuat. Slide, master, layout, shape, media, dan objek presentasi lainnya tidak tersedia. Aplikasi harus selalu memeriksa [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/id/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) sebelum melakukan operasi yang memerlukan model objek presentasi lengkap.

{{% alert color="warning" title="Warning" %}}
Metadata publik dapat mengekspos nama penulis, judul, subjek, kata kunci, informasi perusahaan, komentar, dan nilai custom. Enkripsikan properti sensitif bersama dengan presentasi. Biarkan tetap publik hanya ketika proses pengindeksan, klasifikasi, pencarian, atau sistem manajemen dokumen memiliki kebutuhan khusus untuk mengaksesnya tanpa password.
{{% /alert %}}

## **Perbarui Properti dari Presentasi yang Terenkripsi**

Untuk file PPTX yang terenkripsi, sebuah presentasi yang dimuat dalam mode document-properties-only dimaksudkan untuk membaca metadata publik. Aspose.Slides tidak dapat menyimpan properti yang berubah dari objek metadata-only tersebut karena properti publik harus tetap konsisten dengan data yang bersesuaian di dalam presentasi yang terenkripsi. Oleh karena itu, memperbarui properti tersebut memerlukan password pembuka yang tepat dan pemuatan lengkap.

Contoh berikut membuka presentasi dengan [LoadOptions::setPassword](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setPassword), memperbarui properti built-in publik, dan menyimpan hasilnya. Kemudian menggunakan [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#isEncrypted) untuk memverifikasi bahwa enkripsi tetap terjaga dan membuka kembali metadata publik tanpa password untuk memverifikasi nilai baru:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Jika sebuah aplikasi tidak diizinkan untuk mendekripsi atau memuat konten presentasi, maka harus memperlakukan properti publik dari file PPTX yang terenkripsi sebagai read-only.

## **Akses Properti Built-in**

Properti ini yang diekspos oleh objek [DocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties) meliputi: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Apakah dibagikan antara produsen yang berbeda?), **PresentationFormat**, **Subject**, dan **Title**

```php
  # Membuat instance kelas Presentation yang merepresentasikan presentasi
  $pres = new Presentation("Presentation.pptx");
  try {
    # Membuat referensi ke objek IDocumentProperties yang terkait dengan Presentation
    $dp = $pres->getDocumentProperties();
    # Tampilkan properti built-in
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

## **Modifikasi Properti Built-in**

Memodifikasi properti built-in dari file presentasi semudah mengaksesnya. Anda cukup menetapkan nilai string ke properti yang diinginkan dan nilai properti tersebut akan diubah. Pada contoh di bawah, kami menunjukkan cara memodifikasi properti dokumen built-in dari file presentasi menggunakan Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Buat referensi ke objek IDocumentProperties yang terkait dengan Presentation
    $dp = $pres->getDocumentProperties();
    # Atur properti built-in
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Simpan presentasi Anda ke file
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Contoh ini memodifikasi properti built-in dari presentasi yang dapat dilihat seperti di bawah ini:

|**Properti dokumen Built-in setelah modifikasi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Tambahkan Properti Dokumen Custom**

Aspose.Slides for PHP via Java juga memungkinkan pengembang menambahkan nilai custom untuk properti Dokumen presentasi. Contoh diberikan di bawah yang menunjukkan cara mengatur properti custom untuk sebuah presentasi.

```php
  $pres = new Presentation();
  try {
    # Mengambil Properti Dokumen
    $dProps = $pres->getDocumentProperties();
    # Menambahkan properti Kustom
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Mengambil nama properti pada indeks tertentu
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Menghapus properti terpilih
    $dProps->removeCustomProperty($getPropertyName);
    # Menyimpan presentasi
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Properti Dokumen Custom Ditambahkan**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Akses dan Modifikasi Properti Custom**

Aspose.Slides for PHP via Java juga memungkinkan pengembang mengakses nilai properti custom. Contoh diberikan di bawah yang menunjukkan cara Anda dapat mengakses dan memodifikasi semua properti custom untuk sebuah presentasi.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Buat referensi ke objek DocumentProperties yang terkait dengan Presentation
    $dp = $pres->getDocumentProperties();
    # Akses dan modifikasi properti kustom
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Tampilkan nama dan nilai properti kustom
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Modifikasi nilai properti kustom
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Simpan presentasi Anda ke file
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Contoh ini memodifikasi properti custom dari [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentasi. Gambar berikut menunjukkan properti custom presentasi sebelum dan sesudah modifikasi:

|**Properti Custom sebelum Modifikasi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Properti Custom setelah Modifikasi**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Properti Dokumen Tingkat Lanjut**

{{% alert color="info" title="Note" %}}
Metode baru [readDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties), dan [writeBindedPresentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) telah ditambahkan ke [PresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo), logika setter properti [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/id/php-java/aspose.slides/documentproperties/#setLastSavedTime) telah diubah.
{{% /alert %}} 

Dua metode baru [readDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) dan [updateDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) telah ditambahkan ke kelas [PresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/PresentationInfo) . Mereka menyediakan akses cepat ke properti dokumen dan memungkinkan mengubah serta memperbarui properti tanpa memuat seluruh presentasi.

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

Ada cara lain untuk menggunakan properti dari suatu presentasi tertentu sebagai template untuk memperbarui properti di presentasi lain:

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

Template baru dapat dibuat dari awal dan kemudian digunakan untuk memperbarui beberapa presentasi:

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

## **Atur Bahasa Pemeriksaan**

Aspose.Slides menyediakan properti LanguageId (yang diekspos oleh kelas PortionFormat) untuk memungkinkan Anda mengatur bahasa pemeriksaan untuk dokumen PowerPoint. Bahasa pemeriksaan adalah bahasa yang digunakan untuk memeriksa ejaan dan tata bahasa di PowerPoint.

Kode PHP ini menunjukkan cara mengatur bahasa pemeriksaan untuk PowerPoint: xxx Mengapa LanguageId tidak ada pada kelas Java PortionFormat?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// atur Id bahasa pemeriksaan

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

Coba aplikasi online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/id/metadata) untuk melihat cara bekerja dengan properti dokumen via API Aspose.Slides:

[![Lihat & Edit Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/id/metadata)

## **FAQ**

**Bagaimana saya dapat menghapus properti built-in dari sebuah presentasi?**

Properti built-in adalah bagian integral dari presentasi dan tidak dapat dihapus sepenuhnya. Namun, Anda dapat mengubah nilainya atau mengosongkannya jika diizinkan oleh properti tertentu.

**Apa yang terjadi jika saya menambahkan properti custom yang sudah ada?**

Jika Anda menambahkan properti custom yang sudah ada, nilai yang ada akan ditimpa dengan nilai baru. Anda tidak perlu menghapus atau memeriksa properti tersebut sebelumnya, karena Aspose.Slides secara otomatis memperbarui nilai properti.

**Apakah saya dapat mengakses properti presentasi tanpa memuat seluruh presentasi?**

Ya. Gunakan [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationfactory/) lalu [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentationinfo/#readDocumentProperties) untuk membaca metadata dokumen yang disimpan tanpa membuat instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) . Lihat [Build a Lightweight Presentation Inventory](/slides/id/php-java/examine-presentation/) untuk contoh pelaporan lengkap dan batasan khusus format.

**Apakah saya dapat membaca properti publik dari presentasi yang terenkripsi tanpa password pembukanya?**

Ya. Enkripsi properti dokumen harus dimatikan sebelum presentasi dienkripsi, dan presentasi harus dimuat dalam mode document-properties-only.

**Apakah saya dapat memperbarui file PPTX yang terenkripsi dalam mode document-properties-only?**

Tidak. Data properti publik dan terenkripsi harus tetap konsisten, sehingga memperbarui file PPTX yang terenkripsi memerlukan pemuatan lengkap presentasi dengan password pembuka yang benar.