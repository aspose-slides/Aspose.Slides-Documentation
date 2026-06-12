---
title: Menambahkan Garis Tren ke Diagram Presentasi di Python
linktitle: Garis Tren
type: docs
url: /id/python-net/trend-line/
keywords:
- diagram
- garis tren
- garis tren eksponensial
- garis tren linear
- garis tren logaritmik
- garis tren rata-rata bergerak
- garis tren polinomial
- garis tren pangkat
- garis tren kustom
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Tambahkan dan sesuaikan garis tren dengan cepat dalam diagram PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET — panduan praktis dan contoh kode untuk meningkatkan akurasi peramalan serta menarik perhatian audiens Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi menggunakan Aspose.Slides. Ini menunjukkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linear, logaritmik, rata-rata bergerak, polinomial, dan pangkat.

Artikel ini juga menjelaskan cara menambahkan garis khusus ke diagram dengan menyisipkan bentuk garis, dan menyertakan FAQ singkat tentang nilai proyeksi garis tren maju dan mundur serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan ketika merender diagram sebagai gambar.

## **Tambahkan Garis Tren**
Aspose.Slides for Python via .NET menyediakan API sederhana untuk mengelola Berbagai Garis Tren diagram:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan diagram dengan data default bersama tipe yang diinginkan (contoh ini menggunakan ChartType.CLUSTERED_COLUMN).
1. Menambahkan garis tren eksponensial untuk seri diagram 1.
1. Menambahkan garis tren linear untuk seri diagram 1.
1. Menambahkan garis tren logaritmik untuk seri diagram 2.
1. Menambahkan garis tren rata-rata bergerak untuk seri diagram 2.
1. Menambahkan garis tren polinomial untuk seri diagram 3.
1. Menambahkan garis tren pangkat untuk seri diagram 3.
1. Simpan presentasi yang telah dimodifikasi ke file PPTX.

Kode berikut digunakan untuk membuat diagram dengan Garis Tren.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat presentasi kosong
with slides.Presentation() as pres:

    # Membuat diagram kolom berkelompok
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Menambahkan garis tren eksponensial untuk seri diagram 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Menambahkan garis tren Linear untuk seri diagram 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Menambahkan garis tren Logaritmik untuk seri diagram 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Menambahkan garis tren Rata-rata Bergerak untuk seri diagram 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Menambahkan garis tren Polinomial untuk seri diagram 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Menambahkan garis tren Pangkat untuk seri diagram 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Menyimpan presentasi
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Tambahkan Garis Kustom**
Aspose.Slides for Python via .NET menyediakan API sederhana untuk menambahkan garis kustom pada diagram. Untuk menambahkan garis lurus sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah di bawah ini:

- Buat instance kelas Presentation
- Dapatkan referensi slide dengan menggunakan Indexnya
- Buat diagram baru menggunakan metode AddChart yang disediakan oleh objek Shapes
- Tambahkan AutoShape tipe Line menggunakan metode AddAutoShape yang disediakan oleh objek Shapes
- Atur Color garis bentuk.
- Simpan presentasi yang telah dimodifikasi sebagai file PPTX

Kode berikut digunakan untuk membuat diagram dengan Garis Kustom.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apa arti 'forward' dan 'backward' untuk sebuah garis tren?**

Mereka adalah panjang garis tren yang diproyeksikan maju/mundur: untuk diagram scatter (XY) — dalam satuan sumbu; untuk diagram non-scatter — dalam jumlah kategori. Hanya nilai non-negatif yang diperbolehkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide menjadi gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/id/python-net/render-a-slide-as-an-svg-image/) dan merender diagram ke gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi tersebut. Metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/python-net/create-shape-thumbnails/) itu sendiri.