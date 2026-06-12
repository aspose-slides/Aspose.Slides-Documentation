---
title: Konversi Presentasi PowerPoint ke SWF Flash di PHP
linktitle: PowerPoint ke SWF
type: docs
weight: 80
url: /id/php-java/convert-powerpoint-to-swf-flash/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke SWF
- presentasi ke SWF
- slide ke SWF
- PPT ke SWF
- PPTX ke SWF
- PowerPoint ke Flash
- presentasi ke Flash
- slide ke Flash
- PPT ke Flash
- PPTX ke Flash
- simpan PPT sebagai SWF
- simpan PPTX sebagai SWF
- ekspor PPT ke SWF
- ekspor PPTX ke SWF
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Konversi PowerPoint (PPT/PPTX) ke SWF Flash di PHP dengan Aspose.Slides. Contoh kode langkah demi langkah, output berkualitas cepat, tanpa otomatisasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke SWF dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyimpan presentasi sebagai file SWF dengan metode [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/save/) dan cara mengkonfigurasi ekspor dengan [SwfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/swfoptions/), termasuk pengaturan penampil serta tata letak catatan atau komentar.

## **Konversi Presentasi ke Flash**

Metode [save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/save/) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dapat digunakan untuk mengkonversi seluruh presentasi menjadi dokumen **SWF**. Contoh berikut menunjukkan cara mengkonversi presentasi menjadi dokumen **SWF** dengan menggunakan opsi yang disediakan oleh kelas [SWFOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/swfoptions/). Anda juga dapat menyertakan komentar dalam SWF yang dihasilkan dengan menggunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/notescommentslayoutingoptions/).

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Menyimpan presentasi
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat menyertakan slide tersembunyi dalam SWF?**

Ya. Aktifkan slide tersembunyi menggunakan metode [setShowHiddenSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/swfoptions/setshowhiddenslides/) di [SwfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/swfoptions/). Secara default, slide tersembunyi tidak diekspor.

**Bagaimana saya dapat mengontrol kompresi dan ukuran akhir SWF?**

Gunakan metode [setCompressed](https://reference.aspose.com/slides/id/php-java/aspose.slides/swfoptions/setcompressed/) dan [adjust JPEG quality](https://reference.aspose.com/slides/id/php-java/aspose.slides/swfoptions/setjpegquality/) untuk menyeimbangkan ukuran file dan kualitas gambar.

**Apa fungsi 'setViewerIncluded', dan kapan saya harus menonaktifkannya?**

[setViewerIncluded](https://reference.aspose.com/slides/id/php-java/aspose.slides/swfoptions/setviewerincluded/) menambahkan UI pemutar tersemat (kontrol navigasi, panel, pencarian). Nonaktifkan jika Anda berencana menggunakan pemutar sendiri atau membutuhkan bingkai SWF murni tanpa UI.

**Apa yang terjadi jika font sumber tidak ada pada mesin ekspor?**

Aspose.Slides akan menggantikan font yang Anda tentukan melalui [setDefaultRegularFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) di [SwfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/swfoptions/) untuk menghindari fallback yang tidak diinginkan.