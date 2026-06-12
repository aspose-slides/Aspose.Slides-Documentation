---
title: Optimalkan Perhitungan Diagram untuk Presentasi dalam Python
linktitle: Perhitungan Diagram
type: docs
weight: 50
url: /id/python-net/chart-calculations/
keywords:
- perhitungan diagram
- elemen diagram
- posisi elemen
- posisi aktual
- elemen anak
- elemen induk
- nilai diagram
- nilai aktual
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Memahami perhitungan diagram, pembaruan data, dan kontrol presisi dalam Aspose.Slides untuk Python via .NET untuk PPT, PPTX, dan ODP, dengan contoh kode praktis."
---
## **Gambaran Umum**

Aspose.Slides menyediakan API untuk bekerja dengan perhitungan diagram dan data tata letak dalam presentasi. Artikel ini menunjukkan cara mengambil nilai aktual elemen diagram, termasuk posisi dan ukuran nyata elemen yang mengimplementasikan `ActualLayout` serta nilai aktual sumbu diagram. Artikel ini juga menjelaskan bahwa nilai-nilai tersebut diisi setelah validasi tata letak diagram.

Selain itu, artikel ini menunjukkan cara mendapatkan posisi aktual elemen diagram induk dan cara menyembunyikan komponen diagram seperti judul, sumbu, legenda, dan garis kisi. Bersama-sama, contoh-contoh ini membantu Anda memeriksa informasi tata letak diagram dan mengendalikan visibilitas elemen diagram dalam presentasi PowerPoint secara programatis.

## **Hitung Nilai Aktual Elemen Diagram**
Aspose.Slides untuk Python via .NET menyediakan API sederhana untuk mendapatkan properti ini. Ini akan membantu Anda menghitung nilai aktual elemen diagram. Nilai aktual mencakup posisi elemen yang mewarisi kelas [IActualLayout](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/iactuallayout/) (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) dan nilai aktual sumbu (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **Hitung Posisi Aktual Elemen Diagram Induk**
Aspose.Slides untuk Python via .NET menyediakan API sederhana untuk mendapatkan properti ini. Properti IActualLayout memberikan informasi tentang posisi aktual elemen diagram induk. Perlu memanggil metode IChart.ValidateChartLayout() terlebih dahulu untuk mengisi properti dengan nilai aktual.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **Sembunyikan Informasi dari Diagram**
Topik ini membantu Anda memahami cara menyembunyikan informasi dari diagram. Menggunakan Aspose.Slides untuk Python via .NET Anda dapat menyembunyikan **Judul, Sumbu Vertikal, Sumbu Horizontal** dan **Garis Kisi** dari diagram. Contoh kode di bawah menunjukkan cara menggunakan properti ini.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Menyembunyikan Judul diagram
    chart.has_title = False

    # Menyembunyikan sumbu Nilai
    chart.axes.vertical_axis.is_visible = False

    # Visibilitas Sumbu Kategori
    chart.axes.horizontal_axis.is_visible = False

    # Menyembunyikan Legenda
    chart.has_legend = False

    # Menyembunyikan Garis Kisi Utama
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Mengatur warna garis seri
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah workbook Excel eksternal dapat digunakan sebagai sumber data, dan bagaimana hal itu memengaruhi perhitungan ulang?**

Ya. Diagram dapat merujuk ke workbook eksternal: ketika Anda menghubungkan atau menyegarkan sumber eksternal, rumus dan nilai diambil dari workbook tersebut, dan diagram mencerminkan pembaruan selama operasi buka/edit. API memungkinkan Anda [menentukan workbook eksternal](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/) path dan mengelola data yang ditautkan.

**Apakah saya dapat menghitung dan menampilkan garis tren tanpa harus mengimplementasikan regresi sendiri?**

Ya. [Garis Tren](/slides/id/python-net/trend-line/) (linear, eksponensial, dan lainnya) ditambahkan dan diperbarui oleh Aspose.Slides; parameter mereka dihitung ulang dari data seri secara otomatis, sehingga Anda tidak perlu mengimplementasikan perhitungan sendiri.

**Jika sebuah presentasi memiliki beberapa diagram dengan tautan eksternal, dapatkah saya mengontrol workbook mana yang digunakan setiap diagram untuk nilai yang dihitung?**

Ya. Setiap diagram dapat merujuk ke [workbook eksternal](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/) miliknya sendiri, atau Anda dapat membuat/mengganti workbook eksternal per diagram secara independen dari yang lainnya.