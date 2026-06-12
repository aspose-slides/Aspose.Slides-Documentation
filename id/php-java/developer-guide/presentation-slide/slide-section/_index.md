---
title: Kelola Bagian Slide dalam Presentasi dengan PHP
linktitle: Bagian Slide
type: docs
weight: 90
url: /id/php-java/slide-section/
keywords:
- buat bagian
- tambahkan bagian
- edit bagian
- ubah bagian
- nama bagian
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Permudah pengelolaan bagian slide di PowerPoint dan OpenDocument dengan Aspose.Slides untuk PHP via Java — bagi, ganti nama, dan urutkan kembali untuk mengoptimalkan alur kerja PPTX dan ODP."
---
## **Pendahuluan**

Dengan Aspose.Slides for PHP via Java, Anda dapat mengatur Presentasi PowerPoint menjadi beberapa bagian. Anda dapat membuat bagian yang berisi slide tertentu.

Anda mungkin ingin membuat bagian dan menggunakannya untuk mengatur atau membagi slide dalam sebuah presentasi menjadi bagian logis dalam situasi berikut:

- Ketika Anda mengerjakan presentasi besar bersama orang lain atau tim—dan Anda perlu menugaskan slide tertentu kepada rekan atau anggota tim. 
- Ketika Anda menangani presentasi yang berisi banyak slide—dan Anda kesulitan mengelola atau mengedit isinya sekaligus.

Idealnya, Anda harus membuat sebuah bagian yang berisi slide serupa—slide tersebut memiliki kesamaan atau dapat dikelompokkan berdasarkan suatu aturan—dan memberi nama bagian yang menggambarkan slide di dalamnya. 

## **Membuat Bagian dalam Presentasi**

Untuk menambahkan bagian yang akan berisi slide dalam sebuah presentasi, Aspose.Slides for PHP via Java menyediakan metode [addSection()](https://reference.aspose.com/slides/id/php-java/aspose.slides/sectioncollection/#addSection) yang memungkinkan Anda menentukan nama bagian yang ingin dibuat serta slide tempat bagian tersebut dimulai.

Contoh kode berikut menunjukkan cara membuat bagian dalam sebuah presentasi :

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 akan berakhir pada newSlide2 dan setelahnya section2 akan dimulai

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengubah Nama Bagian**

Setelah Anda membuat bagian dalam presentasi PowerPoint, Anda mungkin memutuskan untuk mengubah namanya. 

Contoh kode berikut menunjukkan cara mengubah nama bagian dalam sebuah presentasi menggunakan Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah bagian tetap dipertahankan saat disimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, sehingga pengelompokan bagian hilang saat disimpan ke .ppt.

**Apakah seluruh bagian dapat disembunyikan?**

Tidak. Hanya slide individu yang dapat disembunyikan. Sebuah bagian sebagai entitas tidak memiliki status “tersembunyi”.

**Apakah saya dapat dengan cepat menemukan sebuah bagian berdasarkan slide, dan sebaliknya, menemukan slide pertama dari sebuah bagian?**

Ya. Sebuah bagian didefinisikan secara unik oleh slide pembukanya; dengan sebuah slide Anda dapat menentukan bagian mana yang dimilikinya, dan untuk sebuah bagian Anda dapat mengakses slide pertamanya.