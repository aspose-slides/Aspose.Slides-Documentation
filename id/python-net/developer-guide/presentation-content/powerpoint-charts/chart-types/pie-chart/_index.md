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
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara membuat dan menyesuaikan diagram lingkaran di Python dengan Aspose.Slides, dapat diekspor ke PowerPoint dan OpenDocument, meningkatkan penceritaan data Anda dalam hitungan detik."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan diagram lingkaran (pie chart) di Aspose.Slides. Artikel ini menunjukkan cara mengonfigurasi opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie, serta cara mengaktifkan pewarnaan otomatis irisan pada diagram lingkaran standar.

Contoh-contoh berfokus pada langkah-langkah praktis kustomisasi diagram seperti menambahkan diagram ke slide, menyesuaikan pengaturan seri dan label, mengganti data diagram default dengan kategori dan nilai khusus, dan menyimpan presentasi yang telah diperbarui.

## **Opsi Plot Kedua untuk Diagram Pie of Pie dan Bar of Pie**
Aspose.Slides for Python via .NET kini mendukung opsi plot kedua untuk diagram Pie of Pie atau Bar of Pie. Pada topik ini, kita akan melihat contoh cara Menentukan opsi-opsi ini menggunakan Aspose.Slides. Untuk menentukan properti-propertinya, ikuti langkah-langkah di bawah ini:

1. Instansiasi objek kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Tambahkan diagram pada slide.
3. Tentukan opsi plot kedua dari diagram.
4. Tulis presentasi ke disk.

Pada contoh di bawah, kami telah mengatur properti yang berbeda dari diagram Pie of Pie.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Buat instance dari kelas Presentation
with slides.Presentation() as presentation:
    # Tambahkan diagram pada slide
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Atur properti yang berbeda
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Simpan presentasi ke disk
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Atur Warna Irisan Diagram Pie Otomatis**
Aspose.Slides for Python via .NET menyediakan API sederhana untuk mengatur warna otomatis irisan diagram lingkaran. Kode contoh menerapkan pengaturan properti yang disebutkan di atas.

1. Buat instance dari kelas Presentation.
2. Akses slide pertama.
3. Tambahkan diagram dengan data default.
4. Atur Judul diagram.
5. Atur seri pertama untuk Menampilkan Nilai.
6. Atur indeks lembar data diagram.
7. Dapatkan worksheet data diagram.
8. Hapus seri dan kategori yang dihasilkan secara default.
9. Tambahkan kategori baru.
10. Tambahkan seri baru.

Tulis presentasi yang telah dimodifikasi ke file PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili file PPTX
with slides.Presentation() as presentation:
	# Akses slide pertama
	slide = presentation.slides[0]

	# Tambahkan diagram dengan data default
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Mengatur Judul diagram
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Atur seri pertama untuk Menampilkan Nilai
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Mengatur indeks lembar data diagram
	defaultWorksheetIndex = 0

	# Mendapatkan worksheet data diagram
	fact = chart.chart_data.chart_data_workbook

	# Hapus seri dan kategori yang dihasilkan secara default
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Menambahkan kategori baru
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Menambahkan seri baru
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Sekarang mengisi data seri
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah variasi 'Pie of Pie' dan 'Bar of Pie' didukung?**

Ya, pustaka ini [mendukung](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/charttype/) plot sekunder untuk diagram lingkaran, termasuk tipe 'Pie of Pie' dan 'Bar of Pie'.

**Bisakah saya mengekspor hanya diagramnya sebagai gambar (misalnya PNG)?**

Ya, Anda dapat [mengekspor diagram itu sendiri sebagai gambar](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/get_image/) (seperti PNG) tanpa seluruh presentasi.