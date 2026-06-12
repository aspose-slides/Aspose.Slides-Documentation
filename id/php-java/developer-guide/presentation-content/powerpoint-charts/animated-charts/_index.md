---
title: Animasi Diagram PowerPoint di PHP
linktitle: Diagram Animasi
type: docs
weight: 80
url: /id/php-java/animated-charts/
keywords:
- diagram
- diagram animasi
- animasi diagram
- seri diagram
- kategori diagram
- elemen seri
- elemen kategori
- tambahkan efek
- tipe efek
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat diagram animasi yang menakjubkan dengan Aspose.Slides untuk PHP via Java. Tingkatkan presentasi dengan visual dinamis dalam file PPT dan PPTX — mulailah sekarang."
---
## **Pendahuluan**

Aspose.Slides for PHP via Java mendukung animasi elemen diagram. **Seri**, **Kategori**, **Elemen Seri**, **Elemen Kategori** dapat dianimasikan dengan metode [Sequence::addEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/sequence/#addEffect) dan dua enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/id/php-java/aspose.slides/EffectChartMajorGroupingType) dan [EffectChartMinorGroupingType](https://reference.aspose.com/slides/id/php-java/aspose.slides/EffectChartMinorGroupingType).

## **Animasi Seri Diagram**
Jika Anda ingin menganimasikan seri diagram, tulis kode sesuai langkah-langkah berikut:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi seri.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami menganimasikan seri diagram.

```php
  # Membuat instance kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Dapatkan referensi objek diagram
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animasi seri
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Tulis presentasi yang telah dimodifikasi ke disk
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animasi Kategori Diagram**
Jika Anda ingin menganimasikan kategori diagram, tulis kode sesuai langkah-langkah berikut:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi kategori.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami menganimasikan kategori diagram.

```php
  # Membuat instance kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animasi pada Elemen Seri**
Jika Anda ingin menganimasikan elemen seri, tulis kode sesuai langkah-langkah berikut:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi elemen seri.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami telah menganimasikan elemen seri.

```php
  # Membuat instance kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Mendapatkan referensi objek diagram
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Menganimasikan elemen seri
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Menulis file presentasi ke disk
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animasi pada Elemen Kategori**
Jika Anda ingin menganimasikan elemen kategori, tulis kode sesuai langkah-langkah berikut:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi elemen kategori.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami telah menganimasikan elemen kategori.

```php
  # Membuat instance kelas Presentation yang mewakili file presentasi
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Mendapatkan referensi objek diagram
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Menganimasikan elemen kategori
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Menulis file presentasi ke disk
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah jenis efek yang berbeda (mis., masuk, penekanan, keluar) didukung untuk diagram seperti pada bentuk biasa?**

Ya. Diagram diperlakukan sebagai bentuk, sehingga mendukung jenis efek animasi standar, termasuk masuk, penekanan, dan keluar, dengan kontrol penuh melalui garis waktu slide dan urutan animasi.

**Bisakah saya menggabungkan animasi diagram dengan transisi slide?**

Ya. [Transitions](/slides/id/php-java/slide-transition/) diterapkan pada slide, sementara efek animasi diterapkan pada objek di slide. Anda dapat menggunakan keduanya bersamaan dalam satu presentasi dan mengontrolnya secara terpisah.

**Apakah animasi diagram dipertahankan saat menyimpan ke PPTX?**

Ya. Saat Anda [save to PPTX](/slides/id/php-java/save-presentation/), semua efek animasi dan urutannya dipertahankan karena menjadi bagian dari model animasi native presentasi.

**Bisakah saya membaca animasi diagram yang ada dari sebuah presentasi dan memodifikasinya?**

Ya. API menyediakan akses ke garis waktu slide, urutan, dan efek, memungkinkan Anda untuk memeriksa animasi diagram yang ada dan menyesuaikannya tanpa harus membuat semuanya kembali dari awal.

**Bisakah saya menghasilkan video yang menyertakan animasi diagram menggunakan Aspose.Slides?**

Ya. Anda dapat [export a presentation to video](/slides/id/php-java/convert-powerpoint-to-video/) sambil mempertahankan animasi, mengatur waktu dan pengaturan ekspor lainnya sehingga klip yang dihasilkan mencerminkan pemutaran animasi.