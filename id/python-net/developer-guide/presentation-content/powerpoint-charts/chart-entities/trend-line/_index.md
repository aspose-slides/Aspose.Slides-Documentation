---
title: Menambahkan Garis Tren ke Diagram Presentasi dalam Python
linktitle: Garis Tren
type: docs
url: /id/python-net/trend-line/
keywords:
- diagram
- garis tren
- garis tren eksponensial
- garis tren linear
- garis tren logaritmik
- garis tren rata‑rata bergerak
- garis tren polinomial
- garis tren daya
- garis tren kustom
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Dengan cepat menambahkan dan menyesuaikan garis tren pada diagram PowerPoint dengan Aspose.Slides untuk Python melalui .NET — panduan praktis untuk menarik perhatian audiens Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linear, logaritmik, rata‑rata bergerak, polinomial, dan daya.

Ini juga menjelaskan cara menambahkan garis kustom ke diagram dengan menyisipkan bentuk garis, dan menyertakan FAQ singkat tentang nilai proyeksi garis tren maju dan mundur serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan saat merender diagram sebagai gambar.

## **Menambahkan Garis Tren**

Gunakan [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) untuk menambahkan garis tren ke seri diagram, memilih tipenya dengan [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). Contoh ini membuat diagram kolom berkelompok dengan data default dan menambahkan dua garis tren ke masing‑masing tiga serinya.

Garis tren eksponensial menyembunyikan persamaannya dan nilai R‑squared melalui [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) dan [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), sedangkan garis tren linear berwarna merah. Garis tren logaritmik menggunakan [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) untuk label khusus. Rata‑rata bergerak menggunakan [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) tiga data poin dan [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/) khusus.

Garis tren polinomial memiliki [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) tiga dan memperluas satu kategori ke depan melalui [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). Garis tren daya memperluas satu kategori ke belakang melalui [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Intersep Garis Tren**

Gunakan [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) untuk menetapkan nilai Y garis tren pada X = 0. Pengaturan ini didukung untuk garis tren linear, eksponensial, dan polinomial.

Sebagai contoh, model biaya produksi mungkin harus dimulai dengan biaya tetap yang diketahui sebesar 100, bahkan ketika pengukuran pada volume produksi yang tidak nol menunjukkan baseline yang berbeda. Untuk garis tren linear, menetapkan intersep membatasi persamaan `y = ax + b` menjadi `b = 100`; kemiringan dipasang ke data dengan batasan tersebut. Ini tidak sekadar memindahkan garis yang sudah dipasang. Pengaturan perpotongan sumbu mengontrol dimana sumbu diagram bertemu, bukan koefisien dari garis tren yang dipasang.

Contoh berikut membuat diagram sebar (XY) dengan volume produksi dari 1 hingga 4 dan biaya 170, 200, 230, dan 260. Diagram tersebut disimpan dengan intersep otomatis default, kemudian intersep diatur menjadi 100, dan menyimpan PPTX kedua. Kedua file hanya berbeda pada pengaturan intersep. Garis tren menampilkan persamaannya dan memperpanjang kembali ke X = 0.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

Dengan perhitungan otomatis, data ini menghasilkan `y = 30x + 140`. Menetapkan intersep menjadi 100 menghasilkan kira‑kira `y = 43.33x + 100`: nilai yang dipasang pada nol cocok dengan baseline yang diketahui, sedangkan garis tidak lagi melewati setiap titik data.

| Intersep otomatis | Intersep tetap 100 |
| --- | --- |
| ![Garis tren linear dengan intersep yang dihitung otomatis sebesar 140](intercept-automatic.png) | ![Garis tren linear dengan intersep tetap 100](intercept-fixed.png) |

Kedua gambar menggunakan data dan skala sumbu yang sama. Garis tren diperpanjang kembali ke X = 0 untuk menampilkan intercept mereka.

Secara default, properti berisi `float("nan")`, yang mewakili intersep yang tidak ditentukan bukan nol. Intersep kemudian dihitung secara otomatis dari data.

## **Menambahkan Garis Kustom**

Garis kustom adalah bentuk yang digambar di atas diagram, bukan garis tren yang dihitung dari data seri. Contoh ini menggunakan [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) untuk menambahkan garis horizontal ke slide di atas diagram. Posisi garis ditentukan dalam koordinat slide, diukur dalam poin, sehingga mulai dari tepi kiri diagram dan berada di tengah tinggi diagram. Lebarnya sama dengan lebar diagram. [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) memberikan garis warna merah solid.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**What do 'forward' and 'backward' mean for a trend line?**

Mereka adalah panjang garis tren yang diproyeksikan maju/mundur: untuk diagram sebar (XY) — dalam satuan sumbu; untuk diagram non‑sebar — dalam jumlah kategori. Hanya nilai non‑negatif yang diizinkan.

**Will the trend line be preserved when exporting the presentation to PDF or SVG, or when rendering a slide to an image?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/) atau [SVG](/slides/id/python-net/render-a-slide-as-an-svg-image/) dan merender diagram menjadi gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi tersebut. Sebuah metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/python-net/create-shape-thumbnails/) itu sendiri.