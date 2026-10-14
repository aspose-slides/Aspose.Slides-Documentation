---
title: Sesuaikan Diagram Lingkaran dalam Presentasi dengan Python
linktitle: Diagram Lingkaran
type: docs
url: /id/python-net/pie-chart/
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
- Aspose.Slides
description: "Buat dan sesuaikan diagram lingkaran di Python dengan Aspose.Slides. Konfigurasikan plot sekunder, tampilkan label data, dan terapkan warna irisan otomatis di PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menggunakan diagram lingkaran di Aspose.Slides. Artikel ini menunjukkan cara mengonfigurasi opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie, serta cara mengaktifkan pewarnaan irisan otomatis untuk diagram lingkaran standar.

Contoh-contoh berfokus pada tugas penyesuaian diagram seperti menambahkan diagram ke slide, menyesuaikan pengaturan seri dan label, mengganti data diagram bawaan dengan kategori dan nilai khusus, serta menyimpan presentasi yang telah diperbarui.

## **Opsi Plot Sekunder untuk Diagram Pie of Pie dan Bar of Pie**

Aspose.Slides for Python via .NET mendukung opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie. Opsi-opsi ini mengontrol ukuran plot sekunder dan cara titik data dibagi antara kedua plot.

Contoh berikut membuat diagram Pie of Pie dalam presentasi baru dan menampilkan nilai titik data sebagai label. Properti [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) mengatur ukuran plot sekunder menjadi 149% dari plot utama. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) memilih pemisahan berbasis persentase, dan [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) mengatur ambang batas menjadi 53%.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Tampilkan nilai dan konfigurasikan plot sekunder.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Pilih Kategori untuk Plot Sekunder**

Gunakan pemisahan khusus ketika Anda ingin mengelompokkan kategori tertentu dalam plot sekunder terlepas dari nilai persentasenya. Misalnya, laporan penjualan dapat menampilkan Online dan Events bersama sehingga pembaca dapat membandingkan dua saluran ini, meskipun mereka masing‑masing menyumbang 35% dan 10% dari total penjualan.

Atur [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) ke [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) dan pilih titik melalui [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). Metode [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) pada koleksi menerima indeks berbasis nol dalam seri atau objek titik data. Dalam contoh ini, indeks 1 memilih Online, dan titik pada indeks 3 memilih Events. Partners juga ditambahkan sementara, lalu dikeluarkan menggunakan [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Ganti data bawaan dengan penjualan per saluran.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Pilih Online berdasarkan indeks nol‑berdasarnya dan Events berdasarkan objek titik datanya.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Kecualikan Partners dari pilihan tanpa menghapus data sumbernya.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) dan Events (10) muncul sebagai irisan terpisah di plot sekunder. Di plot utama, keduanya direpresentasikan oleh satu irisan gabungan dengan nilai 45, bersama dengan Retail (40) dan Partners (15). Menghapus Partners dari pilihan khusus menjaga irisan tersebut di plot utama; ini tidak menghapus kategori atau nilainya dari data sumber diagram.

Gambar berikut menunjukkan presentasi yang disimpan di PowerPoint:

![Diagram Pie of Pie dengan Online dan Events di plot sekunder dan nilai gabungan mereka sebesar 45 di plot utama](pie_of_pie_custom.png)

## **Atur Warna Irisan Diagram Lingkaran Otomatis**

Aspose.Slides for Python via .NET dapat secara otomatis menetapkan warna yang berbeda untuk setiap irisan diagram lingkaran. Contoh berikut membuat diagram lingkaran dengan judul terpusat dan mengganti data bawaan dengan tiga kategori kuartalan serta nilainya. Properti [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) menampilkan nilai 20, 50, dan 30 sebagai label, sedangkan [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) mengaktifkan warna yang berbeda untuk setiap irisan.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Tambahkan judul diagram yang dipusatkan.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Ganti data bawaan menggunakan lembar kerja pertama.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Tampilkan nilai dan tetapkan warna berbeda pada irisan.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah variasi Pie of Pie dan Bar of Pie didukung?**

Ya, perpustakaan [mendukung](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) plot sekunder untuk diagram lingkaran, termasuk tipe Pie of Pie dan Bar of Pie.

**Bisakah saya mengekspor hanya diagram sebagai gambar (misalnya, PNG)?**

Ya, Anda dapat [mengekspor diagram itu sendiri sebagai gambar](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (seperti PNG) tanpa mengekspor seluruh presentasi.