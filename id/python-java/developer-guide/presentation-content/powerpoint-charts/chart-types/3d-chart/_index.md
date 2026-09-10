---
title: Sesuaikan Grafik 3D dalam Presentasi Menggunakan Python
linktitle: Grafik 3D
type: docs
url: /id/python-java/3d-chart/
keywords:
- grafik 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan grafik 3-D di Aspose.Slides untuk Python via Java, dengan dukungan file PPT dan PPTX—tingkatkan presentasi Anda hari ini."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan grafik 3D di Aspose.Slides dengan mengonfigurasi pengaturan [Rotation3D](https://reference.aspose.com/slides/id/python-java/aspose.slides/rotation3d/) seperti [setRotationX](https://reference.aspose.com/slides/id/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/id/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/id/python-java/aspose.slides/rotation3d/#setDepthPercents), dan [setRightAngleAxes](https://reference.aspose.com/slides/id/python-java/aspose.slides/rotation3d/#setRightAngleAxes). Artikel ini melalukan pembuatan presentasi, menambahkan grafik 3D dengan data default, menerapkan pengaturan tampilan 3D yang diperlukan, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Atur Rotasi X, Rotasi Y, dan Kedalaman Grafik 3D**
Aspose.Slides untuk Python via Java menyediakan API sederhana untuk mengatur properti ini. Contoh berikut menunjukkan cara mengatur rotasi X, rotasi Y, dan kedalaman grafik 3D.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Akses slide pertama.
1. Tambahkan grafik dengan data default.
1. Atur properti rotasi 3D.
1. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Akses slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan diagram dengan data default.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Atur indeks lembar kerja data diagram.
    default_worksheet_index = 0

    # Dapatkan workbook data diagram.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Tambahkan seri.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Tambahkan kategori.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Atur properti rotasi 3D.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Akses seri diagram kedua.
    series = chart.getChartData().getSeries().get_Item(1)

    # Isi data seri.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Simpan presentasi.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Jenis grafik apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari diagram kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100% Stacked Column 3D, serta tipe 3D terkait yang diungkapkan melalui kelas [ChartType](https://reference.aspose.com/slides/id/python-java/aspose.slides/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/id/python-java/aspose.slides/charttype/) dalam referensi API versi yang Anda instal.

**Apakah saya dapat memperoleh gambar raster dari grafik 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor diagram ke gambar melalui [chart API](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage) atau [render the entire slide](/slides/id/python-java/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda membutuhkan pratinjau pixel-perfect atau ingin menyematkan diagram ke dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja saat membangun dan merender grafik 3D besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil terbaik, pertahankan efek 3D seminimal mungkin, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke output dengan ukuran yang sesuai (resolusi dan dimensi) untuk mencocokkan tampilan atau kebutuhan cetak target.