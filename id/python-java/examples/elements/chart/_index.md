---
title: Grafik
type: docs
weight: 60
url: /id/python-java/examples/elements/chart/
keywords:
- grafik
- menambah grafik
- mengakses grafik
- menghapus grafik
- memperbarui grafik
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat, akses, hapus, dan perbarui grafik dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via Java."
---
Artikel ini menunjukkan cara menambah, mengakses, menghapus, dan memperbarui grafik dalam sebuah presentasi menggunakan **Aspose.Slides for Python via Java**.

Instal paket seperti dijelaskan pada [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan. Jalankan contoh penambahan terlebih dahulu untuk membuat `chart.pptx` bagi contoh lainnya.

## **Tambah Grafik**

Tambahkan diagram area ke slide pertama dan simpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan diagram area ke slide pertama.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Akses Grafik**

Temukan grafik pertama dalam koleksi bentuk pada slide pertama.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Akses grafik pertama pada slide.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **Hapus Grafik**

Hapus grafik pertama dari slide dan simpan presentasi yang telah dimodifikasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Temukan dan hapus grafik pertama pada slide.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perbarui Data Grafik**

Tampilkan judul grafik, ubah teksnya, dan simpan presentasi yang telah diperbarui.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Temukan grafik pertama pada slide.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Tampilkan judul grafik dan ubah teksnya.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```