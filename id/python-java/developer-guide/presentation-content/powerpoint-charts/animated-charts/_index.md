---
title: Animasi Diagram PowerPoint dalam Python via Java
linktitle: Diagram Animasi
type: docs
weight: 80
url: /id/python-java/animated-charts/
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
- Python
- Java
- Aspose.Slides
description: "Buat diagram animasi yang menakjubkan dalam Python via Java dengan Aspose.Slides. Tingkatkan presentasi dengan visual dinamis di file PPT dan PPTX—mulai sekarang."
---
## **Pendahuluan**

Aspose.Slides untuk Python via Java mendukung animasi elemen diagram. **Series**, **Categories**, **Series Elements**, dan **Category Elements** dapat dianimasikan menggunakan metode [Sequence.addEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/#addEffect) dan dua enumerasi: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/id/python-java/aspose.slides/effectchartmajorgroupingtype/) dan [EffectChartMinorGroupingType](https://reference.aspose.com/slides/id/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Animasi Seri Diagram**

Jika Anda ingin memberi animasi pada seri diagram, tulis kode sesuai langkah-langkah berikut:

1. Muat presentasi.
1. Dapatkan referensi ke objek diagram.
1. Animasi seri.
1. Tuliskan file presentasi ke disk.

Contoh berikut memberi animasi pada seri diagram. Diagram dalam file contoh memiliki tiga seri, jadi satu efek ditambahkan untuk setiap indeks dari 0 hingga 2. Aspose.Slides tidak memeriksa indeks terhadap data diagram, dan efek yang ditambahkan untuk seri yang tidak ada tetap ditulis ke file tetapi tidak menghasilkan animasi—pertahankan indeks di bawah jumlah seri dalam diagram Anda sendiri.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Muat presentasi.
presentation = Presentation("ExistingChart.pptx")
try:
    # Dapatkan referensi ke objek diagram.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animasi elemen diagram.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Tulis presentasi yang dimodifikasi ke disk.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animasi Kategori Diagram**

Jika Anda ingin memberi animasi pada kategori diagram, tulis kode sesuai langkah-langkah berikut:

1. Muat presentasi.
1. Dapatkan referensi ke objek diagram.
1. Animasi kategori.
1. Tuliskan file presentasi ke disk.

Contoh berikut memberi animasi pada kategori diagram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Muat presentasi.
presentation = Presentation("ExistingChart.pptx")
try:
    # Dapatkan referensi ke objek diagram.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animasi elemen diagram.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Tulis presentasi yang dimodifikasi ke disk.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animasi dalam Elemen Seri**

Jika Anda ingin memberi animasi pada elemen seri, tulis kode sesuai langkah-langkah berikut:

1. Muat presentasi.
1. Dapatkan referensi ke objek diagram.
1. Animasi elemen seri.
1. Tuliskan file presentasi ke disk.

Contoh berikut memberi animasi pada elemen seri.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Muat presentasi.
presentation = Presentation("ExistingChart.pptx")
try:
    # Dapatkan referensi ke objek diagram.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animasi elemen diagram.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Tulis presentasi yang dimodifikasi ke disk.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animasi dalam Elemen Kategori**

Jika Anda ingin memberi animasi pada elemen kategori, tulis kode sesuai langkah-langkah berikut:

1. Muat presentasi.
1. Dapatkan referensi ke objek diagram.
1. Animasi elemen kategori.
1. Tuliskan file presentasi ke disk.

Contoh berikut memberi animasi pada elemen kategori.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Muat presentasi.
presentation = Presentation("ExistingChart.pptx")
try:
    # Dapatkan referensi ke objek diagram.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animasi elemen diagram.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Tulis presentasi yang dimodifikasi ke disk.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah tipe efek yang berbeda (mis., entrance, emphasis, exit) didukung untuk diagram seperti pada bentuk biasa?**

Ya. Diagram diperlakukan sebagai bentuk, sehingga mendukung tipe efek animasi standar, termasuk entrance, emphasis, dan exit, dengan kontrol penuh melalui timeline slide dan urutan animasi.

**Bisakah saya menggabungkan animasi diagram dengan transisi slide?**

Ya. [Transitions](/slides/id/python-java/slide-transition/) diterapkan pada slide, sementara efek animasi diterapkan pada objek di slide. Anda dapat menggunakan keduanya bersamaan dalam presentasi yang sama dan mengendalikannya secara independen.

**Apakah animasi diagram dipertahankan saat menyimpan ke PPTX?**

Ya. Saat Anda [save to PPTX](/slides/id/python-java/save-presentation/), semua efek animasi dan urutannya dipertahankan karena merupakan bagian dari model animasi native presentasi.

**Bisakah saya membaca animasi diagram yang ada dari sebuah presentasi dan memodifikasinya?**

Ya. API menyediakan akses ke timeline slide, urutan, dan efek, memungkinkan Anda memeriksa animasi diagram yang ada dan menyesuaikannya tanpa harus membuat semuanya kembali dari awal.

**Bisakah saya menghasilkan video yang mencakup animasi diagram menggunakan Aspose.Slides?**

Ya. Anda dapat [export a presentation to video](/slides/id/python-java/convert-powerpoint-to-video/) sambil mempertahankan animasi, mengatur waktu dan pengaturan ekspor lainnya sehingga klip yang dihasilkan mencerminkan pemutaran animasi.