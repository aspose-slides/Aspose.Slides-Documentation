---
title: Mengelola Seri Data Diagram dalam Presentasi dengan Python
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
## **Ringkasan**

Sebuah diagram menyimpan data yang dipetakan dalam workbook data diagram. Sebuah [ChartSeries](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/) mewakili satu set nilai terkait, dan setiap [ChartDataPoint](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/) dalam seri mengacu pada satu atau beberapa sel workbook. Objek [ChartCategory](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartcategory/) menyediakan label atau nilai pengelompokan yang dibagikan oleh seri. Nama seri, kategori, dan nilai titik oleh karena itu terhubung ke objek [ChartDataCell](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatacell/) bukan hanya disimpan sebagai teks tampilan.

Untuk diagram kategori tipikal, workbook default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel‑sel lainnya untuk nilai seri. Indeks lembar kerja, baris, dan kolom yang diteruskan ke [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) bersifat berbasis nol. Tata letak ini berguna ketika Anda membuat diagram dengan data default, tetapi jangan mengasumsikan bahwa setiap diagram yang ada menggunakannya. Untuk presentasi yang dimuat, periksa sel‑sel yang dirujuk oleh seri, kategori, dan titik data sebelum mengubah nilai workbook.

Pengaturan diagram memiliki tiga lingkup yang berbeda:

- Pengaturan pada level seri, seperti [ChartSeries.format](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/format/), menyediakan tampilan default untuk semua titik dalam satu seri.
- Pengaturan titik data, seperti [ChartDataPoint.format](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/format/), menggantikan tampilan seri untuk satu titik.
- Pengaturan grup berlaku untuk seri yang kompatibel yang berada dalam satu [ChartSeriesGroup](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseriesgroup/). Akses grup melalui [ChartSeries.parent_series_group](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/parent_series_group/) ketika Anda perlu menetapkan opsi seperti overlap atau lebar celah.

Ketika tidak ada isian titik atau seri yang eksplisit, gaya dan tema diagram menentukan tampilan otomatis. Ketika format seri dan titik keduanya ada, format titik memiliki prioritas untuk titik tersebut.

![seri-diagram-powerpoint](chart-series-powerpoint.png)

## **Atur Overlap Seri Diagram**

[ChartSeries.overlap](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/overlap/) melaporkan seberapa banyak batang atau kolom saling tumpang tindih dalam diagram 2D, dari –100 hingga 100 persen. Ini merupakan proyeksi baca‑saja dari pengaturan pada grup seri induk. Tetapkan [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseriesgroup/overlap/) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe diagram yang menampilkan batang atau kolom yang dikelompokkan; tidak memengaruhi grup seri yang tidak terkait dalam diagram kombinasi.

Contoh berikut mengatur overlap untuk grup yang berisi seri pertama:

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

![Overlap seri](series_overlap.png)

## **Ubah Warna Isian Seri**

Gunakan [ChartSeries.format](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/format/) untuk menetapkan isian default bagi seluruh seri. Jika suatu titik sudah memiliki isian eksplisit, pengaturan [ChartDataPoint.format](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/format/) akan menggantikan isian seri untuk titik tersebut.

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

Nama seri disimpan dalam workbook data diagram dan biasanya ditampilkan di legenda. Dalam workbook default yang dibuat untuk diagram kolom berkelompok, sel B1 berada pada baris 0, kolom 1 dan berisi nama seri pertama. Konstanta bernama dalam contoh berikut membuat struktur tersebut eksplisit:

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

Anda juga dapat memperbarui sel yang sudah dirujuk oleh [ChartSeries.name](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/name/). Pendekatan ini menghindari asumsi tentang baris dan kolom tertentu dalam diagram yang ada:

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

## **Dapatkan Warna Isian Seri Otomatis**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) mengembalikan warna yang dihitung dari indeks seri dan gaya diagram. Ini adalah warna yang digunakan ketika isian seri tidak didefinisikan secara eksplisit. Memanggil metode ini hanya membaca warna yang dihitung; tidak menetapkan isian baru.

Contoh berikut mencetak warna otomatis setiap seri default:

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

Contoh output untuk gaya diagram default:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Warna yang tepat bergantung pada gaya dan tema diagram.

## **Atur Warna Isian Terbalik untuk Seri Diagram**

Untuk seri batang, kolom, dan gelembung, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/invert_if_negative/) dapat menampilkan nilai negatif dengan isian yang berbeda. Tetapkan isian seri reguler menjadi padat, aktifkan inversi, dan tetapkan warna nilai negatif melalui [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Angka negatif tetap tidak berubah dalam workbook; hanya warna tampilannya yang berubah.

Contoh berikut mengganti data diagram default dengan satu seri. Baris worksheet 0 berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

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

![Warna isian padat terbalik](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Pada contoh berikut, inversi dinonaktifkan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik tersebut juga diberikan nilai negatif sehingga efeknya terlihat:

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

## **Bersihkan Nilai Titik Data Tertentu**

Untuk menjadikan satu titik kosong tanpa menghapus titik‑titik lainnya, tetapkan sel workbook yang mendasarinya menjadi `None`. Untuk diagram kolom, nilai yang dipetakan tersedia melalui [ChartDataPoint.value](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/value/). Titik data tetap pada posisi kategori yang sama, tetapi diagram memperlakukan nilainya sebagai kosong sesuai pengaturan nilai kosong diagram.

Contoh berikut membersihkan hanya titik kedua dalam seri pertama:

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

Diagram sebar menggunakan sel X dan Y terpisah, dan diagram gelembung juga menggunakan sel ukuran. Hapus hanya sel yang mewakili nilai yang ingin Anda hapus. Jangan panggil [ChartDataPointCollection.clear](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapointcollection/clear/) ketika Anda ingin mempertahankan titik‑titik lain, karena metode itu menghapus semua titik data dari koleksi.

## **Kendalikan Tampilan Sel Kosong**

Sel tersembunyi yang berisi nilai adalah kasus terpisah dari sel kosong. Untuk memasukkan atau mengecualikan data dari baris dan kolom worksheet yang tersembunyi, lihat [Include Data from Hidden Rows and Columns](/slides/id/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Sebuah sel workbook kosong mewakili data yang hilang; sel yang berisi `0` mewakili nilai numerik yang diketahui. Tetapkan [ChartDataCell.value](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatacell/value/) menjadi `None` untuk menjadikan sel kosong. Angka nol tetap nol terlepas dari pengaturan sel kosong.

Gunakan [Chart.display_blanks_as](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/display_blanks_as/) untuk memilih bagaimana diagram menampilkan sel kosong. Pengaturan ini berlaku untuk seluruh diagram. Ia mengubah cara kosong dipetakan, tanpa mengisi sel workbook kosong dengan nol atau nilai interpolasi.

Contoh mandiri berikut membuat diagram garis dengan satu seri, mengosongkan nilai untuk Hari 3, dan menyimpan diagram yang sama dengan setiap mode. Tidak diperlukan file masukan. [ChartDataWorkbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/) menggunakan worksheet 0, kolom 0 untuk label kategori, dan kolom 1 untuk nilai; baris 0 memuat nama seri. Data akhir adalah `10, 20, empty, 30, 40`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Biarkan Hari 3 benar-benar kosong, sambil mempertahankan kategorinya dan titik datanya.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Setiap file output menyimpan mode yang ditetapkan sebelum penyimpanan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, dan `empty_cells_Span.pptx`. Untuk menyimpan hanya satu versi, tetapkan mode yang diinginkan dan simpan presentasi sekali saja alih‑alih mengulangi mode.

Perbandingan di bawah memperlihatkan data yang sama dalam ketiga file. Hari 3 kosong dalam workbook pada setiap kasus:

![Diagram garis dengan data identik: Gap memutus garis pada Hari 3, Zero menurunkan garis ke nol, dan Span menghubungkan Hari 2 ke Hari 4.](display_blanks_as.png)

Efek yang terlihat bergantung pada tipe diagram. Diagram garis memudahkan perbandingan ketiga mode. Diagram batang dan kolom tidak memiliki garis untuk menghubungkan kategori yang hilang, sehingga `SPAN` tidak dapat menghasilkan segmen penghubung seperti di atas; kolom yang hilang dan kolom dengan tinggi nol juga dapat tampak serupa. Demikian pula, diagram sebar dengan hanya penanda tidak memiliki garis penghubung. Jangan mengharapkan tiga hasil berbeda untuk setiap tipe diagram; periksa output untuk tipe yang Anda gunakan.

## **Atur Lebar Celah Seri**

Lebar celah adalah ruang antara kumpulan batang atau kolom yang berdekatan, dinyatakan dalam persentase lebar batang atau kolom. Seperti overlap, lebar celah termasuk dalam grup seri induk, bukan pada satu seri. Tetapkan [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) sekali untuk grup. Nilai yang lebih besar menciptakan lebih banyak ruang antara kumpulan; nilai yang lebih kecil membuatnya lebih rapat.

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

Semua tipe diagram yang direpresentasikan oleh enumerasi [ChartType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/charttype/) menggunakan data diagram, tetapi seri‑serinya tidak semuanya memiliki struktur nilai atau pengaturan yang sama. Misalnya, diagram kategori menggunakan kategori dan nilai, diagram sebar menggunakan nilai X dan Y, dan diagram gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe seri. Opsi seperti overlap dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri diagram?**

Sebuah [ChartSeriesGroup](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseriesgroup/) berisi seri yang kompatibel yang berbagi pengaturan plot pada level grup. Diagram kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup yang diakses melalui satu seri tidak selalu mengubah setiap seri dalam diagram.

**Apakah diagram yang baru dibuat berisi data default?**

Ya. Secara default, [ShapeCollection.add_chart](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_chart/) membuat contoh seri, kategori, dan nilai. Anda dapat menyunting sel‑sel tersebut atau mengosongkan koleksi seri dan kategori sebelum menambahkan kumpulan data yang sepenuhnya kustom. Salah satu overload juga dapat membuat diagram tanpa data default.

**Bagaimana objek diagram terhubung ke sel workbook?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam sebuah [ChartDataWorkbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/). Mengubah sel yang dirujuk memperbarui elemen diagram yang bersesuaian. Saat Anda membangun data kustom, pertahankan baris kategori dan baris nilai seri tetap selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara membersihkan satu titik saja bukan seluruh seri?**

Tetapkan sel nilai yang relevan menjadi `None` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [ChartDataPointCollection.clear](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapointcollection/clear/) hanya ketika Anda bermaksud menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri agar nilainya tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe diagram dan [Chart.display_blanks_as](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/display_blanks_as/). Diagram yang didukung dapat menampilkan kosong sebagai celah, nilai nol, atau dengan menghubungkan titik‑titik tetangga. Pilih pengaturan yang sesuai dengan makna data yang hilang dalam presentasi Anda. Lihat [Kendalikan Tampilan Sel Kosong](#control-the-display-of-empty-cells) untuk contoh lengkap dan perbandingan visual.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, aktifkan [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/invert_if_negative/) dan tetapkan [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Anda dapat mengganti perilaku untuk titik individu dengan [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Properti‑properti ini memengaruhi format, bukan nilai numerik yang disimpan.

**Format mana yang menang ketika baik seri maupun titik diformat?**

Format titik data eksplisit memiliki prioritas untuk titik tersebut. Titik‑titik lain terus menggunakan format seri eksplisit atau, ketika format seri tidak didefinisikan, gaya dan tema diagram otomatis. Properti grup seperti overlap dan lebar celah mengontrol tata letak dan bukan penggantian format pada level titik.

**Apakah ada batas berapa banyak seri yang dapat dimiliki sebuah diagram?**

Aspose.Slides tidak memberlakukan batas tetap terpisah untuk jumlah seri. Dalam praktiknya, batas file presentasi, memori yang tersedia, waktu render, dan keterbacaan diagram menentukan batas yang berguna.

**Apa yang harus diubah ketika kolom terlalu berdekatan atau terlalu jauh?**

Tetapkan [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) pada grup seri induk yang sesuai. Tingkatkan nilai untuk memperlebar ruang antara kumpulan, atau turunkan nilai untuk mendekatkan kumpulan.