---
title: Sesuaikan Diagram Lingkaran dalam Presentasi Menggunakan Python via Java
linktitle: Diagram Lingkaran
type: docs
url: /id/python-java/pie-chart/
keywords:
- diagram lingkaran
- kelola diagram
- sesuaikan diagram
- opsi diagram
- pengaturan diagram
- opsi plot
- warna irisan
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan diagram lingkaran di Python via Java dengan Aspose.Slides, dapat diekspor ke PowerPoint, meningkatkan cara Anda bercerita dengan data dalam hitungan detik."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan diagram lingkaran di Aspose.Slides. Artikel ini menunjukkan cara mengonfigurasi opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie, serta cara mengaktifkan pewarnaan irisan otomatis untuk diagram lingkaran standar.

Contoh-contoh berfokus pada langkah-langkah kustomisasi diagram secara praktis seperti menambahkan diagram ke slide, menyesuaikan pengaturan seri dan label, mengganti data diagram default dengan kategori dan nilai khusus, serta menyimpan presentasi yang diperbarui.

## **Opsi Plot Kedua untuk Diagram Pie of Pie dan Bar of Pie**

Aspose.Slides for Python via Java mendukung opsi plot kedua untuk diagram Pie of Pie dan Bar of Pie. Bagian ini menunjukkan cara menentukan opsi tersebut menggunakan Aspose.Slides. Ikuti langkah-langkah berikut:

1. Buat instance objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Tambahkan diagram ke slide.
1. Tentukan opsi plot kedua diagram.
1. Tuliskan presentasi ke disk.

Contoh berikut mengatur properti yang berbeda dari diagram Pie of Pie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Buat sebuah instance dari kelas Presentation.
presentation = Presentation()
try:
    # Tambahkan diagram ke slide.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Atur properti yang berbeda.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Simpan presentasi ke disk.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Atur Pewarnaan Irisan Diagram Lingkaran Otomatis**

Aspose.Slides for Python via Java menyediakan API sederhana untuk mengatur pewarnaan irisan diagram lingkaran otomatis. Contoh berikut menunjukkan cara menerapkan pengaturan ini.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Akses slide pertama.
1. Tambahkan diagram dengan data default.
1. Atur judul diagram.
1. Atur indeks lembar kerja data diagram.
1. Dapatkan workbook data diagram.
1. Hapus seri dan kategori default.
1. Tambahkan kategori baru.
1. Tambahkan seri baru.
1. Atur seri baru untuk menampilkan nilai.
1. Tuliskan presentasi yang dimodifikasi ke file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Buat sebuah instance dari kelas Presentation.
presentation = Presentation()
try:
    # Tambahkan diagram dengan data default.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Atur judul diagram.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Atur indeks lembar kerja data diagram.
    default_worksheet_index = 0

    # Dapatkan workbook data diagram.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Hapus seri dan kategori default.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Tambahkan kategori baru.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Tambahkan seri baru.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Isi data seri.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Atur seri baru untuk menampilkan nilai.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah variasi 'Pie of Pie' dan 'Bar of Pie' didukung?**

Ya, perpustakaan [mendukung](https://reference.aspose.com/slides/id/python-java/aspose.slides/charttype/) plot sekunder untuk diagram lingkaran, termasuk tipe 'Pie of Pie' dan 'Bar of Pie'.

**Bisakah saya mengekspor hanya diagram sebagai gambar (misalnya, PNG)?**

Ya, Anda dapat [mengekspor diagram itu sendiri sebagai gambar](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage) (seperti PNG) tanpa seluruh presentasi.