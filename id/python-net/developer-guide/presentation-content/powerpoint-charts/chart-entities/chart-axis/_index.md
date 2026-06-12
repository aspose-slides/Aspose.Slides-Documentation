---
title: Sesuaikan Sumbu Diagram dalam Presentasi dengan Python
linktitle: Sumbu Diagram
type: docs
url: /id/python-net/chart-axis/
keywords:
- sumbu diagram
- sumbu vertikal
- sumbu horizontal
- sesuaikan sumbu
- manipulasi sumbu
- kelola sumbu
- properti sumbu
- nilai maksimum
- nilai minimum
- garis sumbu
- format tanggal
- judul sumbu
- posisi sumbu
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Temukan cara menggunakan Aspose.Slides untuk Python via .NET untuk menyesuaikan sumbu diagram dalam presentasi PowerPoint dan OpenDocument untuk laporan dan visualisasi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan sumbu diagram di Aspose.Slides. Ini menunjukkan cara mendapatkan nilai sumbu yang sebenarnya, menukar data antara sumbu, menyembunyikan sumbu vertikal atau horizontal untuk diagram garis, mengubah tipe sumbu kategori, mengatur format tanggal untuk nilai sumbu kategori, memutar judul sumbu, mengatur posisi sumbu, dan menampilkan label satuan pada sumbu nilai.

## **Mendapatkan Nilai Maksimum pada Sumbu Vertikal di Diagram**
Aspose.Slides for Python via .NET memungkinkan Anda memperoleh nilai minimum dan maksimum pada sumbu vertikal. Ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Akses slide pertama.
1. Tambahkan diagram dengan data default.
1. Dapatkan nilai maksimum aktual pada sumbu.
1. Dapatkan nilai minimum aktual pada sumbu.
1. Dapatkan satuan utama aktual pada sumbu.
1. Dapatkan satuan minor aktual pada sumbu.
1. Dapatkan skala satuan utama aktual pada sumbu.
1. Dapatkan skala satuan minor aktual pada sumbu.

Kode contoh—implementasi langkah‑langkah di atas—menunjukkan cara mendapatkan nilai yang diperlukan dalam Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Menyimpan presentasi
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Menukar Data antara Sumbu**
Aspose.Slides memungkinkan Anda dengan cepat menukar data antara sumbu—data yang ditampilkan pada sumbu vertikal (sumbu y) dipindahkan ke sumbu horizontal (sumbu x) dan sebaliknya.

Kode Python berikut menunjukkan cara melakukan penukaran data antara sumbu pada diagram:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Membuat presentasi kosong
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Mengganti baris dan kolom
    chart.chart_data.switch_row_column()
            
    # Menyimpan presentasi
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Menonaktifkan Sumbu Vertikal untuk Diagram Garis**

Kode Python berikut menunjukkan cara menyembunyikan sumbu vertikal untuk diagram garis:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Menonaktifkan Sumbu Horizontal untuk Diagram Garis**

Kode ini menunjukkan cara menyembunyikan sumbu horizontal untuk diagram garis:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengubah Sumbu Kategori**

Dengan properti **CategoryAxisType**, Anda dapat menentukan tipe sumbu kategori yang diinginkan (**date** atau **text**). Kode Python berikut mendemonstrasikan operasinya:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Menetapkan Format Tanggal untuk Nilai Sumbu Kategori**
Aspose.Slides for Python via .NET memungkinkan Anda menetapkan format tanggal untuk nilai sumbu kategori. Operasi ini ditunjukkan dalam kode Python berikut:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Menetapkan Sudut Rotasi untuk Judul Sumbu Diagram**
Aspose.Slides for Python via .NET memungkinkan Anda menetapkan sudut rotasi untuk judul sumbu diagram. Kode Python berikut mendemonstrasikan operasinya:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Menetapkan Posisi Sumbu pada Sumbu Kategori atau Nilai**
Aspose.Slides for Python via .NET memungkinkan Anda menetapkan posisi sumbu pada sumbu kategori atau nilai. Kode Python berikut menunjukkan cara melakukannya:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengaktifkan Label Unit Tampilan pada Sumbu Nilai Diagram**
Aspose.Slides for Python via .NET memungkinkan Anda mengkonfigurasi diagram untuk menampilkan label unit pada sumbu nilai diagram. Kode Python berikut mendemonstrasikan operasinya:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bagaimana cara menetapkan nilai di mana satu sumbu memotong sumbu lainnya (crossing sumbu)?**

Sumbu menyediakan [crossing setting](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/axis/cross_type/): Anda dapat memilih untuk memotong pada nol, pada kategori/nilai maksimum, atau pada nilai numerik tertentu. Ini berguna untuk menggeser sumbu X ke atas atau ke bawah atau untuk menekankan garis dasar.

**Bagaimana cara memposisikan label tick relatif terhadap sumbu (di samping, di luar, di dalam)?**

Atur [label position](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/axis/major_tick_mark/) ke "cross", "outside", atau "inside". Ini memengaruhi keterbacaan dan membantu menghemat ruang, terutama pada diagram kecil.