---
title: Menambahkan Garis Tren ke Diagram Presentasi dalam Python
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
- garis tren daya
- garis tren kustom
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Tambahkan dan sesuaikan garis tren dengan cepat pada diagram PowerPoint menggunakan Aspose.Slides untuk Python via Java — panduan praktis untuk menarik perhatian audiens Anda."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linear, logaritmik, rata‑rata bergerak, polinomial, dan daya.

Selain itu, dijelaskan cara menambahkan garis kustom ke diagram dengan menyisipkan bentuk garis, serta menyertakan FAQ singkat tentang nilai proyeksi garis tren ke depan dan ke belakang serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan saat merender diagram sebagai gambar.

## **Menambahkan Garis Tren**

Gunakan [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) untuk menambahkan garis tren ke seri diagram, memilih tipenya dengan [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). Contoh ini membuat diagram kolom terkelompok dengan data default dan menambahkan dua garis tren ke masing‑masing dari tiga serinya.

Garis tren eksponensial menyembunyikan persamaan dan nilai R‑squared melalui [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) dan [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue), sementara garis tren linear berwarna merah. Garis tren logaritmik menggunakan [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) untuk label kustom. Rata‑rata bergerak menggunakan [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) tiga titik data dan [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName) kustom.

Garis tren polinomial memiliki urutan tiga, diatur melalui [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) dan memperluas satu kategori ke depan melalui [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). Garis tren daya memperluas satu kategori ke belakang melalui [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengatur Intersep Garis Tren**

Gunakan [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) untuk menetapkan nilai Y garis tren pada X = 0. Pengaturan ini didukung untuk garis tren linear, eksponensial, dan polinomial.

Sebagai contoh, model biaya produksi mungkin perlu dimulai dengan biaya tetap yang diketahui sebesar 100, bahkan ketika pengukuran pada volume produksi selain nol menunjukkan baseline yang berbeda. Untuk garis tren linear, menetapkan intersep membatasi persamaan `y = ax + b` menjadi `b = 100`; kemiringan dipasang ke data dengan batasan tersebut. Ini tidak sekadar memindahkan garis yang sudah dipasang. Pengaturan perpotongan sumbu mengontrol di mana sumbu diagram bertemu, bukan koefisien garis tren yang dipasang.

Contoh berikut membuat diagram sebar (XY) dengan volume produksi dari 1 sampai 4 dan biaya 170, 200, 230, dan 260. Diagram disimpan dengan intersep otomatis default, kemudian intersep diubah menjadi 100, dan disimpan PPTX kedua. Kedua berkas hanya berbeda pada pengaturan intersep. Garis tren menampilkan persamaannya dan memperpanjang kembali ke X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dengan perhitungan otomatis, data ini menghasilkan `y = 30x + 140`. Menetapkan intersep menjadi 100 menghasilkan kira‑kira `y = 43.33x + 100`: nilai yang dipasang pada nol cocok dengan baseline yang diketahui, sementara garis tidak lagi melewati setiap titik data.

| Intersep otomatis | Intersep tetap 100 |
| --- | --- |
| ![Garis tren linear dengan intersep yang dihitung otomatis sebesar 140](intercept-automatic.png) | ![Garis tren linear dengan intersep tetap sebesar 100](intercept-fixed.png) |

Kedua gambar menggunakan data dan skala sumbu yang sama. Garis tren diperpanjang kembali ke X = 0 untuk menunjukkan intersepsnya.

Secara default, [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) mengembalikan `NaN`, yang mewakili intersep yang tidak ditentukan bukan nol. Intersep kemudian dihitung secara otomatis dari data.

## **Menambahkan Garis Kustom**

Garis kustom adalah bentuk yang digambar di atas diagram, bukan garis tren yang dihitung dari data seri. Contoh ini menggunakan [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) untuk menambahkan garis horizontal ke slide di atas diagram. Posisi garis ditentukan dalam koordinat slide, diukur dalam poin, sehingga mulai dari tepi kiri diagram dan berada setengah tinggi diagram. Lebarnya cocok dengan lebar diagram. Metode [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) memberikan akses ke pemformatan garis yang digunakan untuk menerapkan warna merah solid.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apa arti 'forward' dan 'backward' pada sebuah garis tren?**

Ini adalah panjang garis tren yang diproyeksikan ke depan/ke belakang: untuk diagram sebar (XY) — dalam satuan sumbu; untuk diagram non‑sebar — dalam jumlah kategori. Hanya nilai non‑negatif yang diperbolehkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide menjadi gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/) atau [SVG](/slides/id/python-java/render-a-slide-as-an-svg-image/) dan merender diagram ke gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi tersebut. Metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/python-java/create-shape-thumbnails/) itu sendiri.