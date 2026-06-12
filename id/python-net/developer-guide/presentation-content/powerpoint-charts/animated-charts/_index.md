---
title: Animasi Diagram PowerPoint di Python
linktitle: Diagram Beranimasi
type: docs
weight: 80
url: /id/python-net/animated-charts/
keywords:
- diagram
- diagram beranimasi
- animasi diagram
- seri diagram
- kategori diagram
- elemen seri
- elemen kategori
- menambahkan efek
- tipe efek
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Buat diagram beranimasi yang menakjubkan di Python dengan Aspose.Slides. Tingkatkan presentasi dengan visual dinamis dalam file PPT, PPTX, dan ODP—mulai sekarang."
---
## **Pendahuluan**

Aspose.Slides for Python via .NET mendukung animasi elemen diagram. **Series**, **Categories**, **Series Elements**, **Categories Elements** dapat dianimasikan dengan metode [ISequence.add_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/isequence/) dan dua enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) serta [EffectChartMinorGroupingType](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effectchartminorgroupingtype/).

## **Animasi Seri Diagram**
Jika Anda ingin menganimasikan seri diagram, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasikan seri.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami menganimasikan seri diagram.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi 
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Dapatkan referensi objek diagram
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animasikan seri
    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectType.FADE, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectChartMajorGroupingType.BY_SERIES, 0, 
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 1,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 2,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 3,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Simpan presentasi yang telah dimodifikasi ke disk 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animasi Kategori Diagram**
Jika Anda ingin menganimasikan kategori diagram, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi Kategori.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami menganimasikan kategori diagram.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Dapatkan referensi objek diagram
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animasikan elemen kategori
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Simpan file presentasi ke disk
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animasi pada Elemen Seri**
Jika Anda ingin menganimasikan elemen seri, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi elemen seri.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami telah menganimasikan elemen‑elemen seri.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# Memuat presentasi
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Dapatkan referensi objek diagram
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animasikan elemen seri
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Simpan file presentasi ke disk 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animasi pada Elemen Kategori**
Jika Anda ingin menganimasikan elemen kategori, tulis kode sesuai langkah‑langkah di bawah ini:

1. Muat presentasi.
1. Dapatkan referensi objek diagram.
1. Animasi elemen kategori.
1. Tulis file presentasi ke disk.

Pada contoh di bawah, kami telah menganimasikan elemen‑elemen kategori.

```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Dapatkan referensi objek diagram
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # Animasikan elemen kategori
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # Simpan file presentasi ke disk
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah tipe efek yang berbeda (mis., entrance, emphasis, exit) didukung untuk diagram seperti pada bentuk biasa?**

Ya. Diagram diperlakukan sebagai bentuk, sehingga mendukung tipe efek animasi standar, termasuk entrance, emphasis, dan exit, dengan kontrol penuh melalui timeline slide dan urutan animasi.

**Apakah saya dapat menggabungkan animasi diagram dengan transisi slide?**

Ya. [Transitions](/slides/id/python-net/slide-transition/) berlaku pada slide, sementara efek animasi berlaku pada objek di dalam slide. Anda dapat menggunakan keduanya bersama‑sama dalam satu presentasi dan mengontrolnya secara independen.

**Apakah animasi diagram dipertahankan saat menyimpan ke PPTX?**

Ya. Saat Anda [save to PPTX](/slides/id/python-net/save-presentation/), semua efek animasi dan urutannya dipertahankan karena menjadi bagian dari model animasi native presentasi.

**Apakah saya dapat membaca animasi diagram yang ada dari sebuah presentasi dan memodifikasinya?**

Ya. [API](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/) menyediakan akses ke timeline slide, urutan, dan efek, memungkinkan Anda memeriksa animasi diagram yang ada dan menyesuaikannya tanpa harus membuat semuanya kembali dari awal.

**Apakah saya dapat menghasilkan video yang mencakup animasi diagram menggunakan Aspose.Slides for Python via .NET?**

Ya. Anda dapat [export a presentation to video](/slides/id/python-net/convert-powerpoint-to-video/) sambil mempertahankan animasi, mengatur timing dan pengaturan ekspor lainnya sehingga klip yang dihasilkan mencerminkan pemutaran yang dianimasikan.