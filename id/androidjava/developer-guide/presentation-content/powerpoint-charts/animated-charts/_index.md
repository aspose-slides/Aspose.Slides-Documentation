---
title: Animasi Diagram PowerPoint di Android
linktitle: Diagram Teranimasi
type: docs
weight: 80
url: /id/androidjava/animated-charts/
keywords:
- diagram
- diagram teranimasi
- animasi diagram
- seri diagram
- kategori diagram
- elemen seri
- elemen kategori
- menambahkan efek
- tipe efek
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buat diagram teranimasi yang menakjubkan dalam Java dengan Aspose.Slides untuk Android. Tingkatkan presentasi dengan visual dinamis dalam file PPT dan PPTX—mulailah sekarang."
---
## **Pendahuluan**

Aspose.Slides for Android via Java mendukung animasi elemen diagram. **Series**, **Categories**, **Series Elements**, **Categories Elements** dapat dianimasikan dengan [ISequence.addEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) method dan dua enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/EffectChartMajorGroupingType) dan [EffectChartMinorGroupingType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/EffectChartMinorGroupingType).

## **Animasi Seri Diagram**
Jika Anda ingin menganimasi seri diagram, tulis kode sesuai langkah-langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi seri.
1. Tuliskan file presentasi ke disk.

Pada contoh di bawah, kami menganimasi seri diagram.

```java
// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Dapatkan referensi objek diagram
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animasi seri
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tuliskan presentasi yang dimodifikasi ke disk
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animasi Kategori Diagram**
Jika Anda ingin menganimasi kategori diagram, tulis kode sesuai langkah-langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi Kategori.
1. Tuliskan file presentasi ke disk.

Pada contoh di bawah, kami menganimasi kategori diagram.

```java
// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animasi pada Elemen Seri**
Jika Anda ingin menganimasi elemen seri, tulis kode sesuai langkah-langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi elemen seri.
1. Tuliskan file presentasi ke disk.

Pada contoh di bawah, kami telah menganimasi elemen seri.

```java
// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Dapatkan referensi objek diagram
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animasi elemen seri
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tulis file presentasi ke disk 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animasi pada Elemen Kategori**
Jika Anda ingin menganimasi elemen kategori, tulis kode sesuai langkah-langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi elemen kategori.
1. Tuliskan file presentasi ke disk.

Pada contoh di bawah, kami telah menganimasi elemen kategori.

```java
// Instansiasi kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Dapatkan referensi objek diagram
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Animasi elemen kategori
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tulis file presentasi ke disk
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah tipe efek yang berbeda (mis., entrance, emphasis, exit) didukung untuk diagram seperti pada bentuk biasa?**

Ya. Diagram diperlakukan sebagai bentuk, sehingga mendukung tipe efek animasi standar, termasuk entrance, emphasis, dan exit, dengan kontrol penuh melalui timeline slide dan urutan animasi.

**Apakah saya dapat menggabungkan animasi diagram dengan transisi slide?**

Ya. [Transitions](/slides/id/androidjava/slide-transition/) diterapkan pada slide, sementara efek animasi diterapkan pada objek di slide. Anda dapat menggunakan keduanya bersama dalam presentasi yang sama dan mengontrolnya secara independen.

**Apakah animasi diagram dipertahankan saat menyimpan ke PPTX?**

Ya. Ketika Anda [save to PPTX](/slides/id/androidjava/save-presentation/), semua efek animasi dan urutannya dipertahankan karena merupakan bagian dari model animasi asli presentasi.

**Apakah saya dapat membaca animasi diagram yang ada dari presentasi dan memodifikasinya?**

Ya. API memberikan akses ke timeline slide, urutan, dan efek, memungkinkan Anda memeriksa animasi diagram yang ada dan menyesuaikannya tanpa harus membuat semuanya dari awal.

**Apakah saya dapat menghasilkan video yang menyertakan animasi diagram menggunakan Aspose.Slides?**

Ya. Anda dapat [export a presentation to video](/slides/id/androidjava/convert-powerpoint-to-video/) sambil mempertahankan animasi, mengonfigurasi waktu dan pengaturan ekspor lainnya sehingga klip yang dihasilkan mencerminkan pemutaran animasi.