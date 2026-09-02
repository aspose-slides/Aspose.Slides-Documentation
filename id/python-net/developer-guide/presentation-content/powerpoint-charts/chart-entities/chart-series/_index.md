---
title: Kelola Seri Data Diagram dalam Presentasi dengan Python
linktitle: Seri Data
type: docs
url: /id/python-net/chart-series/
keywords:
- seri diagram
- tumpang tindih seri
- warna seri
- warna kategori
- nama seri
- titik data
- celah seri
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengelola seri diagram, titik data, sel workbook, pemformatan, tumpang tindih, lebar celah, dan nilai negatif dalam presentasi dengan Python."
---
## **Gambaran Umum**

Sebuah diagram menyimpan data yang dipetakan dalam sebuah workbook data diagram. Sebuah [ChartSeries](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/) mewakili satu set nilai terkait, dan setiap [ChartDataPoint](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/) dalam seri mengacu pada satu atau beberapa sel workbook. Objek [ChartCategory](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartcategory/) menyediakan label atau nilai pengelompokan yang dibagikan oleh seri. Nama seri, kategori, dan nilai titik oleh karena itu terhubung ke objek [ChartDataCell](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatacell/) bukan hanya disimpan sebagai teks tampilan.

Untuk diagram kategori tipikal, workbook default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel‑sel sisanya untuk nilai seri. Indeks lembar kerja, baris, dan kolom yang diteruskan ke [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) bersifat berbasis nol. Tata letak ini berguna ketika Anda membuat diagram dengan data default, tetapi jangan berasumsi bahwa setiap diagram yang ada menggunakannya. Untuk presentasi yang dimuat, periksa sel‑sel yang dirujuk oleh seri, kategori, dan titik data sebelum mengubah nilai workbook.

Pengaturan diagram memiliki tiga ruang lingkup berbeda:

- Pengaturan tingkat seri, seperti [ChartSeries.format](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/format/), memberikan tampilan default untuk semua titik dalam satu seri.
- Pengaturan titik data, seperti [ChartDataPoint.format](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/format/), menimpa tampilan seri untuk satu titik.
- Pengaturan grup berlaku untuk seri yang kompatibel yang berada dalam satu [ChartSeriesGroup](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseriesgroup/). Akses grup melalui [ChartSeries.parent_series_group](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/parent_series_group/) ketika Anda perlu mengatur opsi seperti tumpang tindih atau lebar celah.

Ketika tidak ada isian titik atau seri yang eksplisit, gaya dan tema diagram menentukan tampilan otomatis. Ketika kedua format seri dan titik ada, format titik memiliki prioritas untuk titik tersebut.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Atur Tumpang Tindih Seri Diagram**

[ChartSeries.overlap](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/overlap/) melaporkan seberapa banyak batang atau kolom saling tumpang tindih dalam diagram 2D, dari -100 sampai 100 persen. Ini adalah proyeksi baca‑saja dari pengaturan pada grup seri induk. Atur [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseriesgroup/overlap/) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe diagram yang menampilkan batang atau kolom berkelompok; tidak memengaruhi grup seri yang tidak terkait dalam diagram kombinasi.

Contoh berikut mengatur tumpang tindih untuk grup yang berisi seri pertama:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Diagram baru berisi contoh seri, kategori, dan nilai.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![Tumpang tindih seri](series_overlap.png)

## **Ubah Warna Isi Seri**

Gunakan [ChartSeries.format](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/format/) untuk mengatur isian default bagi seluruh seri. Jika sebuah titik sudah memiliki isian eksplisit, pengaturan [ChartDataPoint.format](https://reference.aspose.com/slides/id/python-net/aspose.slides.chats.chartdatapoint/format/) menimpa isian seri untuk titik tersebut.

Contoh berikut menerapkan isian biru padat pada seri pertama:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![Warna seri](series_color.png)

## **Ubah Nama Seri**

Nama seri disimpan dalam workbook data diagram dan biasanya ditampilkan dalam legenda. Pada workbook default yang dibuat untuk diagram kolom berkelompok, sel B1 berada di baris 0, kolom 1 dan berisi nama seri pertama. Konstanta bernama dalam contoh berikut membuat struktur tersebut eksplisit:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Anda juga dapat memperbarui sel yang sudah dirujuk oleh [ChartSeries.name](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/name/). Pendekatan ini menghindari asumsi baris dan kolom tertentu dalam diagram yang ada:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![Nama seri](series_name.png)

## **Dapatkan Warna Isi Seri Otomatis**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) mengembalikan warna yang dihitung dari indeks seri dan gaya diagram. Ini adalah warna yang digunakan ketika isian seri tidak didefinisikan secara eksplisit. Memanggil metode ini hanya membaca warna yang dihitung; tidak menetapkan isian baru.

Contoh berikut mencetak warna otomatis untuk setiap seri default:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Output contoh untuk gaya diagram default:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Warna tepatnya tergantung pada gaya dan tema diagram.

## **Atur Warna Isi Terbalik untuk Seri Diagram**

Untuk seri batang, kolom, dan gelembung, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/invert_if_negative/) dapat menampilkan nilai negatif dengan isian berbeda. Atur isian seri reguler menjadi padat, aktifkan inversi, dan tetapkan warna nilai negatif melalui [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Angka negatif tetap tidak berubah dalam workbook; hanya warna tampilan yang berubah.

Contoh berikut mengganti data diagram default dengan satu seri. Baris lembar kerja 0 berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![Warna isi padat terbalik](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Pada contoh berikut, inversi dinonaktifkan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik tersebut juga diberikan nilai negatif agar efeknya terlihat:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Bersihkan Nilai Titik Data Spesifik**

Untuk mengosongkan satu titik tanpa menghapus titik lain, setel sel workbook yang mendasarinya ke `None`. Untuk diagram kolom, nilai yang dipetakan tersedia melalui [ChartDataPoint.value](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/value/). Titik data tetap berada pada posisi kategori yang sama, tetapi diagram memperlakukan nilainya sebagai kosong sesuai pengaturan nilai kosong diagram.

Contoh berikut hanya membersihkan titik kedua dalam seri pertama:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

Diagram sebar menggunakan sel X dan Y terpisah, dan diagram gelembung juga menggunakan sel ukuran. Bersihkan hanya sel yang mewakili nilai yang ingin Anda hapus. Jangan panggil [ChartDataPointCollection.clear](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapointcollection/clear/) ketika Anda ingin mempertahankan titik lain, karena metode tersebut menghapus semua titik data dari koleksi.

## **Atur Lebar Celah Seri**

Lebar celah adalah ruang antara klaster batang atau kolom yang berdekatan, dinyatakan sebagai persentase lebar batang atau kolom. Seperti tumpang tindih, ini milik grup seri induk bukan satu seri. Setel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) sekali untuk grup. Nilai yang lebih besar menghasilkan lebih banyak ruang antara klaster; nilai yang lebih kecil membuatnya lebih padat.

Contoh berikut mengubah lebar celah dan menyimpan hanya presentasi akhir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![Lebar celah](gap_width.png)

## **FAQ**

**Tipe diagram mana yang mendukung seri data?**

Semua tipe diagram yang diwakili oleh enumerasi [ChartType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/charttype/) menggunakan data diagram, tetapi seri mereka tidak semuanya memiliki struktur nilai atau pengaturan yang sama. Misalnya, diagram kategori menggunakan kategori dan nilai, diagram sebar menggunakan nilai X dan Y, dan diagram gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe seri. Opsi seperti tumpang tindih dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri diagram?**

Sebuah [ChartSeriesGroup](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseriesgroup/) berisi seri yang kompatibel yang berbagi pengaturan plot tingkat grup. Diagram kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup yang dicapai melalui satu seri tidak selalu mengubah setiap seri dalam diagram.

**Apakah diagram yang baru dibuat berisi data default?**

Ya. Secara default, [ShapeCollection.add_chart](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_chart/) membuat seri contoh, kategori, dan nilai. Anda dapat menyunting sel‑sel tersebut atau mengosongkan koleksi seri dan kategori sebelum menambahkan satu set data yang sepenuhnya kustom. Overload juga dapat membuat diagram tanpa data default.

**Bagaimana objek diagram terhubung ke sel workbook?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam sebuah [ChartDataWorkbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/). Mengubah sel yang dirujuk memperbarui elemen diagram yang bersangkutan. Saat Anda membangun data kustom, jaga agar baris kategori dan baris nilai seri tetap selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara mengosongkan satu titik alih‑alih seluruh seri?**

Setel sel nilai yang relevan ke `None` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [ChartDataPointCollection.clear](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapointcollection/clear/) hanya ketika Anda ingin menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri supaya nilainya tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe diagram dan [Chart.display_blanks_as](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/display_blanks_as/). Diagram yang didukung dapat menampilkan kosong sebagai celah, sebagai nilai nol, atau dengan menghubungkan titik‑titik tetangga. Pilih pengaturan yang sesuai dengan makna data yang hilang dalam presentasi Anda.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, aktifkan [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/invert_if_negative/) dan setel [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Anda dapat menimpa perilaku untuk titik individual dengan [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Properti ini memengaruhi pemformatan, bukan nilai numerik yang disimpan.

**Format mana yang menang ketika baik seri maupun titik diformat?**

Pemformatan titik data eksplisit memiliki prioritas untuk titik tersebut. Titik lain tetap menggunakan format seri eksplisit atau, bila format seri tidak didefinisikan, gaya dan tema diagram otomatis. Properti grup seperti tumpang tindih dan lebar celah mengontrol tata letak dan bukan penimpaan pemformatan tingkat titik.

**Apakah ada batas berapa banyak seri yang dapat dimiliki sebuah diagram?**

Aspose.Slides tidak memberlakukan batas tetap terpisah untuk jumlah seri. Pada praktiknya, batas dipengaruhi oleh batasan berkas presentasi, memori yang tersedia, waktu rendering, dan keterbacaan diagram.

**Apa yang harus diubah ketika kolom terlalu berdekatan atau terlalu jauh?**

Setel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) pada grup seri induk yang tepat. Tingkatkan nilai untuk memperlebar ruang antara klaster, atau turunkan nilai untuk mendekatkan klaster satu sama lain.