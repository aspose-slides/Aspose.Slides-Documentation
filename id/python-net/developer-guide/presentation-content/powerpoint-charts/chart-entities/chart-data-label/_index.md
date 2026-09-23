---
title: Kelola Label Data Grafik dalam Presentasi dengan Python
linktitle: Label Data
type: docs
url: /id/python-net/chart-data-label/
keywords:
- grafik
- label data
- presisi data
- persentase
- jarak label
- lokasi label
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menambahkan dan memformat label data grafik dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python via .NET untuk slide yang lebih menarik."
---
## **Pendahuluan**

Label data menampilkan informasi tentang seri grafik dan titik data individual, membantu pembaca mengidentifikasi nilai dan memahami grafik. Artikel ini menjelaskan cara memformat nilai, menampilkan persentase, membaca teks label, menyesuaikan jarak label sumbu kategori, dan memposisikan label pada grafik pai.

## **Atur Presisi Data pada Label Data Grafik**

Gunakan [number_format_of_values](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/number_format_of_values/) untuk memformat nilai seri. Contoh ini membuat grafik garis dengan data default, menampilkan tabel data, dan mengaktifkan label nilai untuk seri pertama. Format `#,##0.00` menampilkan pemisah ribuan dan dua tempat desimal tanpa mengubah nilai dasarnya.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tampilkan Persentase sebagai Label**

Untuk grafik kolom bertumpuk, hitung setiap nilai sebagai persentase dari total kategori dan tetapkan teks ke [text_frame_for_overriding](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Contoh ini menggunakan data grafik default dan menampilkan persentase dengan dua tempat desimal dalam font 8 poin. Kategori dengan total nol dilewati untuk menghindari pembagian dengan nol. Hitung ulang teks label khusus jika data grafik berubah.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Tanda Persentase dengan Label Data Grafik**

Ketika nilai disimpan sebagai pecahan, gunakan [number_format](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabelformat/number_format/) untuk menampilkan persentase. Atur [is_number_format_linked_to_source](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) ke `False` untuk menerapkan format label secara independen dari sel sumber.

Contoh ini membuat grafik kolom bertumpuk 100% dengan seri merah dan biru pada empat kategori. Setiap pasangan nilai menjumlahkan menjadi 1. Format label `0.0%` menampilkan 0.30 sebagai 30.0%, sementara sumbu vertikal menggunakan dua tempat desimal. Kedua seri menggunakan teks label putih berukuran 10 poin.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Baca Teks Aktual dari Label Data**

Gunakan [get_actual_label_text](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) untuk mengambil teks yang dihasilkan oleh pengaturan label data. Ini berguna saat mengekstrak label untuk laporan, mencari konten presentasi, atau memvalidasi grafik yang dihasilkan. Pada contoh di bawah, [format label data](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabelformat/) default menggabungkan setiap nama kategori, nama seri, dan nilai. Satu titik memformat nilainya sebagai persentase, dan titik lain menggunakan teks khusus dari [text_frame_for_overriding](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

Angka yang disimpan dalam titik data tetap `0.75`, bahkan ketika labelnya menampilkan `75%` bersama nama kategori dan seri. Teks khusus menggantikan teks label yang dihasilkan. [get_actual_label_text](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) mengembalikan string label yang dihasilkan dalam kedua kasus. Periksa [is_visible](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabel/is_visible/) secara terpisah, seperti yang ditunjukkan di atas, ketika Anda ingin mengekstrak hanya label yang terlihat.

## **Atur Jarak Label dari Sumbu**

Gunakan [label_offset](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/axis/label_offset/) untuk mengontrol jarak antara label sumbu kategori dan sumbu. Nilainya adalah persentase dari ukuran font maksimum label sumbu. Contoh ini membuat grafik kolom berkelompok dan mengatur offset label sumbu horizontal menjadi 500. Pengaturan ini memengaruhi label sumbu kategori, bukan label yang terpasang pada titik data individual.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sesuaikan Lokasi Label**

Pada grafik pai, sesuaikan posisi label data untuk memperbaiki jarak dan memberi ruang bagi garis penunjuk.

Contoh ini menampilkan nilai titik data pertama, menempatkan labelnya di luar irisan, dan menyesuaikan offset [x](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabel/x/) dan [y](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabel/y/). Offset ini relatif terhadap lebar dan tinggi grafik, masing-masing.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Grafik pai dengan posisi label data yang disesuaikan](pie-chart-adjusted-label.png)

## **FAQ**

**Bagaimana saya dapat mencegah label data tumpang tindih pada grafik yang padat?**

Gabungkan penempatan label otomatis, garis penunjuk, dan ukuran font yang lebih kecil; jika diperlukan, sembunyikan beberapa bidang (misalnya, kategori) atau tampilkan label hanya untuk nilai ekstrem atau poin kunci.

**Bagaimana saya dapat menonaktifkan label hanya untuk nilai nol, negatif, atau kosong?**

Saring titik data sebelum mengaktifkan label dan matikan tampilan untuk nilai 0, nilai negatif, atau nilai kosong sesuai dengan aturan yang ditentukan.

**Bagaimana saya dapat memastikan gaya label yang konsisten saat mengekspor ke PDF/gambar?**

Tetapkan secara eksplisit keluarga font dan ukuran, serta verifikasi bahwa font tersedia di lingkungan rendering untuk menghindari fallback.