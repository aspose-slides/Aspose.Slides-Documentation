---
title: Kelola Label Data Diagram dalam Presentasi dengan Python
linktitle: Label Data
type: docs
url: /id/python-net/chart-data-label/
keywords:
- diagram
- label data
- presisi data
- persentase
- jarak label
- lokasi label
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menambahkan dan memformat label data diagram dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python melalui .NET untuk slide yang lebih menarik."
---
## **Gambaran Umum**

Label data pada diagram menampilkan detail tentang seri data diagram atau titik data individu. Mereka memungkinkan pembaca dengan cepat mengidentifikasi seri data dan juga membuat diagram lebih mudah dipahami. Di Aspose.Slides untuk Python, Anda dapat mengaktifkan, menyesuaikan, dan memformat label data untuk diagram apa pun—memilih apa yang ditampilkan (nilai, persentase, nama seri atau kategori), di mana menempatkan label, dan bagaimana tampilannya (font, format nomor, pemisah, garis penghubung, dan lainnya). Artikel ini menjelaskan API penting dan contoh yang Anda perlukan untuk menambahkan label yang jelas dan informatif ke diagram Anda.

## **Atur Presisi Label Data**

Label data diagram sering menampilkan nilai numerik yang memerlukan presisi konsisten. Bagian ini menunjukkan cara mengontrol jumlah angka desimal untuk label data di Aspose.Slides dengan menerapkan format angka yang sesuai.

Contoh Python berikut menunjukkan cara mengatur presisi numerik untuk label data diagram:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Tampilkan Persentase sebagai Label**

Dengan Aspose.Slides, Anda dapat menampilkan persentase sebagai label data pada diagram. Contoh di bawah menghitung bagian masing-masing titik dalam kategorinya dan memformat label untuk menampilkan persentase.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Buat instansi dari kelas Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Simpan presentasi yang berisi diagram.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Tampilkan Tanda Persen pada Label Data Diagram**

Bagian ini menunjukkan cara menampilkan persentase dalam label data diagram dan menyertakan tanda persen menggunakan Aspose.Slides. Anda akan belajar cara mengaktifkan nilai persentase untuk seluruh seri atau titik tertentu (ideal untuk diagram pai, donat, dan diagram bertumpuk 100%) serta cara mengontrol pemformatan melalui opsi label atau format angka khusus.

Contoh Python berikut menunjukkan cara menambahkan tanda persen ke label data diagram:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Buat sebuah instance dari kelas Presentation.
with slides.Presentation() as presentation:

    # Dapatkan referensi slide berdasarkan indeks.
    slide = presentation.slides[0]

    # Buat chart PercentsStackedColumn pada slide.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Dapatkan workbook data chart.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Tambahkan seri baru.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Atur warna isi seri.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Atur properti format label.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Tambahkan seri baru.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Atur tipe isi dan warna.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Simpan presentasi.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Jarak Label dari Sumbu**

Bagian ini menunjukkan cara mengontrol jarak antara label data dan sumbu diagram di Aspose.Slides. Menyesuaikan offset ini membantu mencegah tumpang tindih dan meningkatkan keterbacaan dalam visual yang padat.

Kode Python berikut menunjukkan cara mengatur jarak label dari sumbu kategori saat bekerja dengan diagram berbasis sumbu:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Buat instance dari kelas Presentation.
with slides.Presentation() as presentation:
    # Dapatkan referensi slide.
    slide = presentation.slides[0]

    # Buat chart kolom terkelompok pada slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Atur jarak label dari sumbu kategori (horizontal).
    chart.axes.horizontal_axis.label_offset = 500

    # Simpan presentasi.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Sesuaikan Posisi Label**

Saat Anda membuat diagram yang tidak menggunakan sumbu, seperti diagram pai, label data mungkin terlalu dekat dengan tepi. Dalam kasus tersebut, sesuaikan posisi label agar garis penghubung terlihat jelas.

Kode Python berikut menunjukkan cara menyesuaikan posisi label pada diagram pai:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Posisi label berubah](changed_label_position.png)

## **FAQ**

**Bagaimana saya dapat mencegah label data saling tumpang tindih pada diagram yang padat?**  
Gabungkan penempatan label otomatis, garis penghubung, dan ukuran font yang lebih kecil; jika perlu, sembunyikan beberapa bidang (misalnya, kategori) atau tampilkan label hanya untuk titik ekstrim/kunci.

**Bagaimana saya dapat menonaktifkan label hanya untuk nilai nol, negatif, atau kosong?**  
Tapis titik data sebelum mengaktifkan label dan matikan tampilan untuk nilai 0, nilai negatif, atau nilai yang hilang sesuai aturan yang ditentukan.

**Bagaimana saya dapat memastikan gaya label yang konsisten saat mengekspor ke PDF/gambar?**  
Tetapkan font (keluarga, ukuran) secara eksplisit dan pastikan font tersedia di sisi rendering untuk menghindari fallback.