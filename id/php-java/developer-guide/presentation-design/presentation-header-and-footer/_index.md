---
title: Kelola Header dan Footer Presentasi di PHP
linktitle: Header dan Footer
type: docs
weight: 140
url: /id/php-java/presentation-header-and-footer/
keywords:
- header
- teks header
- footer
- teks footer
- atur header
- atur footer
- handout
- catatan
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Gunakan Aspose.Slides untuk PHP via Java untuk menambahkan dan menyesuaikan header serta footer pada presentasi PowerPoint dan OpenDocument agar terlihat profesional."
---
## **Overview**

Aspose.Slides memungkinkan Anda mengelola pengaturan header dan footer dalam presentasi PowerPoint. Header dan footer ditangani pada tingkat master presentasi, dan API menyediakan metode untuk mengatur teks footer, mengubah visibilitas footer, dan memperbarui teks header pada slide catatan master.

Anda juga dapat mengelola header dan footer untuk slide handout dan catatan. Ini mencakup mengubah visibilitas dan teks placeholder header, footer, nomor slide, dan tanggal‑waktu untuk master catatan, semua slide catatan anak, atau slide catatan individual.

## **Kelola Header dan Footer dalam Presentasi**

Catatan pada slide tertentu dapat dihapus seperti yang ditunjukkan pada contoh di bawah ini:

```php
  # Muat Presentasi
  $pres = new Presentation("headerTest.pptx");
  try {
    # Mengatur Footer
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Mengakses dan Memperbarui Header
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Simpan presentasi
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Kelola Header dan Footer pada Slide Handout dan Catatan**
Aspose.Slides untuk PHP via Java mendukung Header dan Footer pada slide Handout dan catatan. Silakan ikuti langkah‑langkah berikut:

- Muat sebuah [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) yang berisi video.
- Ubah pengaturan Header dan Footer untuk master catatan dan semua slide catatan.
- Atur placeholder Footer pada slide catatan master dan semua anak menjadi terlihat.
- Atur placeholder Tanggal dan waktu pada slide catatan master dan semua anak menjadi terlihat.
- Ubah pengaturan Header dan Footer hanya untuk slide catatan pertama.
- Atur notes slide Header placeholder visible.
- Tetapkan teks pada placeholder Header slide catatan.
- Tetapkan teks pada placeholder Date-time slide catatan.
- Tulis file presentasi yang telah dimodifikasi.

Cuplikan kode disediakan dalam Contoh di bawah.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Ubah pengaturan Header dan Footer untuk master catatan dan semua slide catatan
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// membuat slide catatan master dan semua placeholder Footer anak terlihat

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// membuat slide catatan master dan semua placeholder Header anak terlihat

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// membuat slide catatan master dan semua placeholder SlideNumber anak terlihat

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// membuat slide catatan master dan semua placeholder Tanggal dan waktu anak terlihat

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// mengatur teks ke slide catatan master dan semua placeholder Header anak

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// mengatur teks ke slide catatan master dan semua placeholder Footer anak

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// mengatur teks ke slide catatan master dan semua placeholder Tanggal dan waktu anak

    }
    # Ubah pengaturan Header dan Footer hanya untuk slide catatan pertama
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// membuat placeholder Header slide catatan ini terlihat

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// membuat placeholder Footer slide catatan ini terlihat

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// membuat placeholder SlideNumber slide catatan ini terlihat

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// membuat placeholder Date-time slide catatan ini terlihat

      $headerFooterManager->setHeaderText("New header text");// mengatur teks ke placeholder Header slide catatan

      $headerFooterManager->setFooterText("New footer text");// mengatur teks ke placeholder Footer slide catatan

      $headerFooterManager->setDateTimeText("New date and time text");// mengatur teks ke placeholder Date-time slide catatan

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat menambahkan "header" ke slide reguler?**

Di PowerPoint, "Header" hanya ada untuk catatan dan handout; pada slide reguler, elemen yang didukung adalah footer, tanggal/waktu, dan nomor slide. Pada Aspose.Slides hal ini sama: header hanya untuk Notes/Handout, dan pada slide—Footer/DateTime/SlideNumber.

**Bagaimana jika tata letak tidak memiliki area footer—apakah saya dapat "mengaktifkan" visibilitasnya?**

Ya. Periksa visibilitas melalui pengelola header/footer dan aktifkan jika diperlukan. Indikator dan metode API ini dirancang untuk kasus ketika placeholder tidak ada atau tersembunyi.

**Bagaimana cara membuat nomor slide dimulai dari nilai selain 1?**

Atur [first slide number](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/setfirstslidenumber/) presentasi; setelah itu, semua penomoran dihitung ulang. Misalnya, Anda dapat memulai dari 0 atau 10, dan menyembunyikan nomor pada slide judul.

**Apa yang terjadi pada header/footer saat mengekspor ke PDF/gambar/HTML?**

Mereka dirender sebagai elemen teks biasa dari presentasi. Artinya, jika elemen tersebut terlihat pada slide/halaman catatan, mereka juga akan muncul dalam format output bersama dengan konten lainnya.