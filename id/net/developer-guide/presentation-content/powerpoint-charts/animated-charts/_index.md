---
title: Animasi Diagram PowerPoint di .NET
linktitle: Diagram Animasi
type: docs
weight: 80
url: /id/net/animated-charts/
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
- .NET
- C#
- Aspose.Slides
description: "Buat diagram animasi yang menakjubkan di .NET dengan Aspose.Slides. Tingkatkan presentasi dengan visual dinamis dalam file PPT dan PPTX—mulai sekarang."
---
## **Pendahuluan**

Aspose.Slides for .NET mendukung animasi elemen diagram. **Series**, **Categories**, **Series Elements**, **Categories Elements** dapat dianimasikan dengan metode [ISequence.AddEffect](https://reference.aspose.com/slides/id/net/aspose.slides.animation/isequence/methods/addeffect) dan dua enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/effectchartmajorgroupingtype) serta [EffectChartMinorGroupingType](https://reference.aspose.com/slides/id/net/aspose.slides.animation/effectchartminorgroupingtype).

## **Animasi Seri Diagram**
Jika Anda ingin menganimasikan seri diagram, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi seri.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami menganimasikan seri diagram.

```c#
// Instansiasi kelas Presentation yang mewakili file presentasi 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Dapatkan referensi objek diagram
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animasi seri
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
    EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 0,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 1,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 2,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 3,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tulis presentasi yang telah dimodifikasi ke disk 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```

## **Animasi Kategori Diagram**
Jika Anda ingin menganimasikan kategori diagram, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi kategori.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami menganimasikan kategori diagram.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Dapatkan referensi objek diagram
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animasi elemen kategori
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tulis file presentasi ke disk
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Animasi pada Elemen Seri**
Jika Anda ingin menganimasikan elemen seri, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi elemen seri.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami telah menganimasikan elemen seri.

```c#
// Muat presentasi
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Dapatkan referensi objek diagram
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animasi elemen seri
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tulis file presentasi ke disk 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
```

## **Animasi pada Elemen Kategori**
Jika Anda ingin menganimasikan elemen kategori, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi elemen kategori.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami telah menganimasikan elemen kategori.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Dapatkan referensi objek diagram
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Animasi elemen kategori
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tulis file presentasi ke disk
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah tipe efek yang berbeda (misalnya entrance, emphasis, exit) didukung untuk diagram seperti pada bentuk biasa?**

Ya. Diagram diperlakukan sebagai bentuk, sehingga mendukung tipe efek animasi standar, termasuk entrance, emphasis, dan exit, dengan kontrol penuh melalui timeline slide dan urutan animasi.

**Bisakah saya menggabungkan animasi diagram dengan transisi slide?**

Ya. [Transitions](/slides/id/net/slide-transition/) diterapkan pada slide, sementara efek animasi diterapkan pada objek di slide. Anda dapat menggunakan keduanya dalam satu presentasi dan mengontrolnya secara terpisah.

**Apakah animasi diagram tetap terjaga saat disimpan ke PPTX?**

Ya. Saat Anda [save to PPTX](/slides/id/net/save-presentation/), semua efek animasi dan urutannya tetap terjaga karena menjadi bagian dari model animasi native presentasi.

**Bisakah saya membaca animasi diagram yang ada dalam presentasi dan memodifikasinya?**

Ya. [API](https://reference.aspose.com/slides/id/net/aspose.slides.animation/) menyediakan akses ke timeline slide, urutan, dan efek, memungkinkan Anda memeriksa animasi diagram yang ada dan menyesuaikannya tanpa harus membuat semuanya kembali dari awal.

**Bisakah saya menghasilkan video yang mencakup animasi diagram menggunakan Aspose.Slides?**

Ya. Anda dapat [export a presentation to video](/slides/id/net/convert-powerpoint-to-video/) sambil mempertahankan animasi, mengatur timing dan pengaturan ekspor lainnya sehingga klip yang dihasilkan menampilkan pemutaran animasi yang tepat.