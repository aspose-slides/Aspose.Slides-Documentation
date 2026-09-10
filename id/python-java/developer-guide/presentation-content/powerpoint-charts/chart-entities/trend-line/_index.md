---
title: Tambahkan Garis Tren ke Diagram Presentasi di Python
linktitle: Garis Tren
type: docs
url: /id/python-java/trend-line/
keywords:
- diagram
- garis tren
- garis tren eksponensial
- garis tren linear
- garis tren logaritmik
- garis tren rata-rata bergerak
- garis tren polinomial
- garis tren pangkat
- garis tren khusus
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Tambahkan dan sesuaikan garis tren secara cepat dalam diagram PowerPoint dengan Aspose.Slides untuk Python via Java — panduan praktis untuk menarik perhatian audiens Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linear, logaritmik, rata‑rata bergerak, polinomial, dan pangkat.

Artikel ini juga menjelaskan cara menambahkan garis khusus ke diagram dengan menyisipkan bentuk garis, dan menyertakan FAQ singkat mengenai nilai proyeksi garis tren maju dan mundur serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan saat merender diagram sebagai gambar.

## **Menambahkan Garis Tren**

Aspose.Slides for Python via Java menyediakan API sederhana untuk mengelola berbagai garis tren diagram:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan diagram dengan data default dan tipe yang diinginkan (contoh ini menggunakan [ChartType.ClusteredColumn](https://reference.aspose.com/slides/id/python-java/aspose.slides/charttype/#ClusteredColumn)).
4. Tambahkan garis tren eksponensial ke seri diagram 1.
5. Tambahkan garis tren linear ke seri diagram 1.
6. Tambahkan garis tren logaritmik ke seri diagram 2.
7. Tambahkan garis tren rata‑rata bergerak ke seri diagram 2.
8. Tambahkan garis tren polinomial ke seri diagram 3.
9. Tambahkan garis tren pangkat ke seri diagram 3.
10. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

Kode berikut membuat diagram dengan garis tren.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Buat sebuah instance dari kelas Presentation.
presentation = Presentation()
try:
    # Buat diagram kolom berkelompok.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Tambahkan garis tren eksponensial ke seri diagram 1.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Tambahkan garis tren linear ke seri diagram 1.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Tambahkan garis tren logaritmik ke seri diagram 2.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Tambahkan garis tren rata-rata bergerak ke seri diagram 2.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Tambahkan garis tren polinomial ke seri diagram 3.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Tambahkan garis tren pangkat ke seri diagram 3.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Simpan presentasi.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menambahkan Garis Kustom**

Aspose.Slides for Python via Java menyediakan API sederhana untuk menambahkan garis kustom ke diagram. Untuk menambahkan garis biasa ke diagram pada slide yang dipilih, ikuti langkah‑langkah berikut:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
- Dapatkan referensi ke slide berdasarkan indeksnya.
- Buat diagram baru menggunakan metode [addChart](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addChart) dari kelas [ShapeCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/) .
- Tambahkan bentuk garis menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addAutoShape) dengan [ShapeType.Line](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#Line) .
- Atur warna garis bentuk tersebut.
- Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

Kode berikut membuat diagram dengan garis kustom.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Buat sebuah instance dari kelas Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apa arti 'forward' dan 'backward' pada sebuah garis tren?**

Mereka adalah panjang garis tren yang diproyeksikan maju atau mundur: untuk diagram sebar (XY), panjang diukur dalam satuan sumbu; untuk diagram non‑sebar, panjang diukur dalam jumlah kategori. Hanya nilai non‑negatif yang diperbolehkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide menjadi gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/id/python-java/render-a-slide-as-an-svg-image/) dan merender diagram menjadi gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi tersebut. Sebuah metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/python-java/create-shape-thumbnails/) itu sendiri.