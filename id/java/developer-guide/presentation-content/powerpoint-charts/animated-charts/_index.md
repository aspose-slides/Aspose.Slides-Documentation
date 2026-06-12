---
title: "Animasi Grafik PowerPoint di Java"
linktitle: "Grafik Beranimasi"
type: docs
weight: 80
url: /id/java/animated-charts/
keywords:
- "grafik"
- "grafik beranimasi"
- "animasi grafik"
- "seri grafik"
- "kategori grafik"
- "elemen seri"
- "elemen kategori"
- "menambah efek"
- "tipe efek"
- "PowerPoint"
- "presentasi"
- "Java"
- "Aspose.Slides"
description: "Buat grafik beranimasi yang menakjubkan di Java dengan Aspose.Slides. Tingkatkan presentasi dengan visual dinamis dalam file PPT dan PPTX—mulailah sekarang."
---
## **Pendahuluan**

Aspose.Slides for Java mendukung animasi elemen grafik. **Series**, **Categories**, **Series Elements**, **Categories Elements** dapat dianimasikan dengan metode [ISequence.addEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) dan dua enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/id/java/com.aspose.slides/EffectChartMajorGroupingType) serta [EffectChartMinorGroupingType](https://reference.aspose.com/slides/id/java/com.aspose.slides/EffectChartMinorGroupingType).

## **Animasi Seri Grafik**
Jika Anda ingin menganimasikan seri grafik, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek grafik.
1. Animasi seri.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami menganimasikan seri grafik.

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Dapatkan referensi objek chart
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

    // Tulis presentasi yang dimodifikasi ke disk
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animasi Kategori Grafik**
Jika Anda ingin menganimasikan kategori grafik, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek grafik.
1. Animasi kategori.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami menganimasikan kategori grafik.

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
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
Jika Anda ingin menganimasikan elemen seri, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek grafik.
1. Animasi elemen seri.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami telah menganimasikan elemen seri.

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Dapatkan referensi objek chart
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
Jika Anda ingin menganimasikan elemen kategori, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek grafik.
1. Animasi elemen kategori.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami telah menganimasikan elemen kategori.

```java
// Membuat instance kelas Presentation yang mewakili file presentasi
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Dapatkan referensi objek chart
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

**Apakah berbagai jenis efek (mis., entrance, emphasis, exit) didukung untuk grafik seperti pada bentuk biasa?**

Ya. Grafik diperlakukan sebagai bentuk, jadi ia mendukung jenis efek animasi standar, termasuk entrance, emphasis, dan exit, dengan kontrol penuh melalui timeline slide dan urutan animasi.

**Bisakah saya menggabungkan animasi grafik dengan transisi slide?**

Ya. [Transitions](/slides/id/java/slide-transition/) berlaku untuk slide, sedangkan efek animasi berlaku untuk objek pada slide. Anda dapat menggunakan keduanya bersama dalam presentasi yang sama dan mengontrolnya secara terpisah.

**Apakah animasi grafik tetap dipertahankan saat menyimpan ke PPTX?**

Ya. Ketika Anda [save to PPTX](/slides/id/java/save-presentation/), semua efek animasi dan urutannya dipertahankan karena menjadi bagian dari model animasi native presentasi.

**Bisakah saya membaca animasi grafik yang ada dari sebuah presentasi dan memodifikasinya?**

Ya. API menyediakan akses ke timeline slide, urutan, dan efek, memungkinkan Anda memeriksa animasi grafik yang ada dan menyesuaikannya tanpa harus membuat semuanya kembali dari awal.

**Bisakah saya menghasilkan video yang mencakup animasi grafik menggunakan Aspose.Slides?**

Ya. Anda dapat [export a presentation to video](/slides/id/java/convert-powerpoint-to-video/) sambil mempertahankan animasi, mengonfigurasi waktu dan pengaturan ekspor lainnya sehingga klip yang dihasilkan mencerminkan pemutaran animasi.