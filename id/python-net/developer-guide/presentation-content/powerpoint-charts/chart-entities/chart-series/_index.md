---
title: Kelola Seri Data Bagan dalam Presentasi dengan Python
linktitle: Seri Data
type: docs
url: /id/python-net/chart-series/
keywords:
- seri bagan
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
description: "Pelajari cara mengelola seri bagan, titik data, sel workbook, pemformatan, tumpang tindih, lebar celah, dan nilai negatif dalam presentasi dengan Python."
---
## **Gambaran Umum**

Bagan dapat menyimpan nilai yang dipetakan dalam sel workbook atau langsung sebagai literal numerik. Sebuah [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) mewakili satu set nilai terkait, dan setiap [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) mewakili satu titik dalam seri tersebut. Objek [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) menyediakan label atau nilai pengelompokan yang dibagikan oleh seri. Pada bagan yang dibuat dengan data default, nama seri, kategori, dan nilai titik menggunakan objek [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) dari workbook bagan.

Untuk bagan kategori tipikal, workbook default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel-sel lainnya untuk nilai seri. Indeks worksheet, baris, dan kolom yang diberikan ke [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) berbasis nol. Tata letak ini berguna ketika Anda membuat bagan dengan data default, tetapi jangan mengasumsikan bahwa setiap bagan yang ada menggunakannya. Untuk presentasi yang dimuat, inspeksi sel-sel yang dirujuk oleh seri, kategori, dan titik data sebelum mengubah nilai workbook.

Pengaturan bagan memiliki tiga ruang lingkup berbeda:

- Pengaturan pada tingkat seri, seperti [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), menyediakan tampilan default untuk semua titik dalam satu seri.
- Pengaturan titik data, seperti [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), menggantikan tampilan seri untuk satu titik.
- Pengaturan grup diterapkan pada seri yang kompatibel yang termasuk dalam [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) yang sama. Akses grup melalui [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) ketika Anda perlu mengatur opsi seperti overlap atau lebar celah.

Ketika tidak ada isian titik atau seri yang eksplisit, gaya bagan dan tema menentukan tampilan otomatis. Ketika format seri dan titik keduanya ada, format titik memiliki prioritas untuk titik tersebut.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Atur Nilai Seri Menggunakan Literal Numerik**

Gunakan literal numerik ketika nilai seri berasal dari data aplikasi atau perhitungan dan tidak memerlukan referensi sel worksheet. Tetapkan [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) ke [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) sebelum menetapkan [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) setiap titik melalui [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/).

Pengaturan koleksi mengendalikan tipe sumber semua nilai titik dalam seri tersebut. Setiap titik memiliki [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) yang melaporkan tipe yang dipilih; ubah melalui pengaturan koleksi. Dengan `WORKSHEET`, gunakan [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) untuk mengakses sel yang dirujuk. Dengan `DOUBLE_LITERALS`, gunakan `as_literal_double` untuk membaca atau menulis angka secara langsung.

Contoh berikut membuat bagan kolom dengan seri dan kategori default, kemudian menetapkan nilai yang dihitung 10, 20, dan seterusnya ke titik yang ada pada seri pertama. Ia menyimpan presentasi, membuka kembali, dan mencetak nilai yang disimpan.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

Tipe sumber nilai titik terpisah dari [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), yang mengidentifikasi konfigurasi workbook internal atau eksternal bagan. Menggunakan literal numerik tidak secara otomatis menghapus workbook yang tersemat. Pada contoh ini, workbook tetap tersedia untuk label kategori, nama seri, dan seri lainnya. Lihat [Chart Workbook](/slides/id/python-net/chart-workbook/) untuk manajemen workbook.

Untuk bagan pencar dan gelembung, tetapkan [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) dan [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) untuk memilih sumber [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) dan [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/). Bagan gelembung juga menggunakan [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) untuk [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/). Tetapkan setiap sumber yang berlaku ke `DOUBLE_LITERALS` sebelum menetapkan angka melalui properti `as_literal_double` nilai tersebut.

## **Atur Overlap Seri Bagan**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) melaporkan seberapa banyak batang atau kolom tumpang tindih dalam bagan 2D, dari -100 hingga 100 persen. Ini merupakan proyeksi hanya-baca dari pengaturan pada grup seri induk. Tetapkan [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe bagan yang menampilkan batang atau kolom berkelompok; tidak memengaruhi grup seri yang tidak terkait dalam bagan kombinasi.

Contoh berikut mengatur overlap untuk grup yang berisi seri pertama:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Bagan baru berisi contoh seri, kategori, dan nilai.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Overlap seri](series_overlap.png)

## **Ubah Warna Isian Seri**

Gunakan [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) untuk mengatur isian default untuk seluruh seri. Jika sebuah titik sudah memiliki isian eksplisit, pengaturan [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) menggantikan isian seri untuk titik tersebut.

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

Hasil:

![Warna seri](series_color.png)

## **Ubah Nama Seri**

Nama seri disimpan dalam workbook data bagan dan biasanya ditampilkan di legenda. Dalam workbook default yang dibuat untuk bagan kolom berkelompok, sel B1 berada pada baris 0, kolom 1 dan berisi nama seri pertama. Konstanta bernama dalam contoh berikut membuat struktur tersebut eksplisit:

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

Anda juga dapat memperbarui sel yang sudah dirujuk oleh [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/). Pendekatan ini menghindari asumsi baris dan kolom tertentu dalam bagan yang ada:

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

Hasil:

![Nama seri](series_name.png)

### **Buat Seri dengan Nama dari Beberapa Sel**

Nama seri komposit berguna ketika nama produk dan periode pelaporan disimpan dalam sel workbook terpisah. Misalnya, Anda dapat menggabungkan `Product A` di B1 dan `2026` di C1 menjadi satu nama seri sambil menjaga kedua bagian tetap terhubung ke sel sumbernya.

Gunakan [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) untuk mengambil rentang nama, lalu berikan koleksi tersebut ke [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). Argumen `skip_hidden_cells` mengendalikan apakah sel tersembunyi disertakan: `True` mengecualikannya, sementara `False` menyertakannya. Contoh ini menggunakan `False` untuk menyertakan semua sel dalam rentang nama.

Contoh berikut membuat presentasi dengan satu seri dan dua titik data. Sel B1:C1 hanya menyediakan nama seri; A2:A3 menyediakan label kategori, dan B2:B3 menyediakan nilai numerik.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Kedua sel ini menyediakan nama seri.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Sel terpisah menyediakan kategori dan titik data numerik.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

Nama seri yang dihasilkan adalah `Product A 2026`, dengan spasi antara dua nilai sel. Legenda menampilkan ini sebagai satu entri untuk kedua kolom. Gambar di bawah dirender dari presentasi yang disimpan:

![Bagan kolom dengan nilai Utara dan Selatan serta nama seri komposit Product A 2026 di legenda](composite_series_name.png)

## **Dapatkan Warna Isian Seri Otomatis**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) mengembalikan warna yang dihitung dari indeks seri dan gaya bagan. Ini adalah warna yang digunakan ketika isian seri tidak didefinisikan secara eksplisit. Memanggil metode ini membaca warna yang dihitung; tidak menetapkan isian baru.

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

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Warna tepat tergantung pada gaya bagan dan tema.

## **Atur Warna Isian Terbalik untuk Seri Bagan**

Untuk seri batang, kolom, dan gelembung, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) dapat menampilkan nilai negatif dengan isian yang berbeda. Tetapkan isian seri reguler ke padat, aktifkan inversi, dan tetapkan warna nilai negatif melalui [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Angka negatif tetap tidak berubah dalam workbook; hanya warna tampilan mereka yang berubah.

Contoh berikut mengganti data bagan default dengan satu seri. Baris worksheet 0 berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

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

Hasil:

![Warna isian padat terbalik](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Dalam contoh berikut, inversi dinonaktifkan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik tersebut juga diberikan nilai negatif sehingga efeknya terlihat:

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

Untuk membuat satu titik kosong tanpa menghapus titik lainnya, setel sel workbook pendukungnya ke `None`. Untuk bagan kolom, nilai yang dipetakan tersedia melalui [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). Titik data tetap pada posisi kategori yang sama, tetapi bagan memperlakukan nilainya sebagai kosong sesuai dengan pengaturan nilai kosong bagan.

Contoh berikut menghapus hanya titik kedua dalam seri pertama:

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

Bagan pencar menggunakan sel X dan Y terpisah, dan bagan gelembung juga menggunakan sel ukuran. Hapus hanya sel yang mewakili nilai yang ingin Anda hilangkan. Jangan panggil [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) ketika Anda ingin mempertahankan titik lainnya, karena metode tersebut menghapus semua titik data dari koleksi.

## **Kendalikan Tampilan Sel Kosong**

Sel tersembunyi yang berisi nilai merupakan kasus terpisah dari sel kosong. Untuk menyertakan atau mengecualikan data dari baris dan kolom worksheet tersembunyi, lihat [Include Data from Hidden Rows and Columns](/slides/id/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Sel workbook kosong mewakili data yang hilang; sel yang berisi `0` mewakili nilai numerik yang diketahui. Setel [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) ke `None` agar sel menjadi kosong. Nol numerik tetap nol terlepas dari pengaturan sel kosong.

Gunakan [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) untuk memilih bagaimana bagan menampilkan sel kosong. Pengaturan ini berlaku untuk seluruh bagan. Ini mengubah cara kekosongan dipetakan, tanpa mengisi sel workbook kosong dengan nol atau nilai interpolasi.

Contoh mandiri berikut membuat bagan garis dengan satu seri, menghapus nilai untuk Hari 3, dan menyimpan bagan yang sama dengan setiap mode. Tidak diperlukan file input. [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) menggunakan worksheet 0, kolom 0 untuk label kategori, dan kolom 1 untuk nilai; baris 0 memuat nama seri. Data akhir adalah `10, 20, empty, 30, 40`.

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

    # Biarkan Hari 3 benar-benar kosong, sambil mempertahankan kategori dan titik datanya.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Setiap file output menyimpan mode yang ditetapkan sebelum disimpan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, dan `empty_cells_Span.pptx`. Untuk menyimpan hanya satu versi, tetapkan mode yang diinginkan dan simpan presentasi sekali saja alih-alih iterasi melalui mode.

Perbandingan di bawah menampilkan data yang sama di ketiga file. Hari 3 kosong dalam workbook pada setiap kasus:

![Bagan garis dengan data identik: Gap memutus garis pada Hari 3, Zero menurunkan garis ke nol, dan Span menghubungkan Hari 2 ke Hari 4.](display_blanks_as.png)

Efeknya tergantung pada tipe bagan. Bagan garis memudahkan perbandingan ketiga mode. Bagan batang dan kolom tidak memiliki garis untuk menghubungkan kategori yang hilang, sehingga `SPAN` tidak dapat menghasilkan segmen penghubung seperti di atas; kolom yang hilang dan kolom dengan tinggi nol juga dapat terlihat serupa. Demikian pula, bagan pencar dengan hanya penanda tidak memiliki garis penghubung. Jangan mengharapkan tiga hasil berbeda untuk setiap tipe bagan; periksa output untuk tipe yang Anda gunakan.

## **Atur Lebar Celah Seri**

Lebar celah adalah ruang antara klaster batang atau kolom yang berdekatan, dinyatakan sebagai persentase lebar batang atau kolom. Seperti overlap, ia termasuk dalam grup seri induk bukan pada satu seri. Tetapkan [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) sekali untuk grup. Nilai yang lebih besar menciptakan lebih banyak ruang antara klaster; nilai yang lebih kecil membuatnya lebih padat.

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

Hasil:

![Lebar celah](gap_width.png)

## **FAQ**

**Jenis bagan apa yang mendukung data seri?**

Semua jenis bagan yang diwakili oleh enumerasi [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) menggunakan data bagan, tetapi seri mereka tidak semuanya memiliki struktur nilai atau pengaturan yang sama. Misalnya, bagan kategori menggunakan kategori dan nilai, bagan pencar menggunakan nilai X dan Y, dan bagan gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe seri. Opsi seperti overlap dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri bagan?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) berisi seri yang kompatibel yang berbagi pengaturan plot tingkat grup. Bagan kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup yang diakses melalui satu seri tidak selalu mengubah semua seri dalam bagan.

**Apakah bagan yang baru dibuat berisi data default?**

Ya. Secara default, [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) membuat contoh seri, kategori, dan nilai. Anda dapat mengedit sel-sel tersebut atau mengosongkan koleksi seri dan kategori sebelum menambahkan set data yang sepenuhnya kustom. Overload juga dapat membuat bagan tanpa data default.

**Bagaimana objek bagan terhubung ke sel workbook?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Mengubah sel yang dirujuk memperbarui elemen bagan yang bersangkutan. Saat Anda membangun data kustom, jaga agar baris kategori dan baris nilai seri tetap selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara menghapus satu titik bukan seluruh seri?**

Setel sel nilai yang relevan ke `None` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) hanya ketika Anda berniat menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri sehingga nilainya tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe bagan dan [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). Bagan yang didukung dapat menampilkan kekosongan sebagai celah, sebagai nilai nol, atau dengan menghubungkan titik-titik tetangga. Pilih pengaturan yang sesuai dengan makna data yang hilang dalam presentasi Anda. Lihat [Control the Display of Empty Cells](#control-the-display-of-empty-cells) untuk contoh lengkap dan perbandingan visual.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, aktifkan [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) dan setel [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Anda dapat mengganti perilaku untuk titik individual dengan [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Properti ini memengaruhi format, bukan nilai numerik yang disimpan.

**Format mana yang diutamakan ketika baik seri maupun titik diformat?**

Format titik data yang eksplisit memiliki prioritas untuk titik tersebut. Titik lainnya terus menggunakan format seri yang eksplisit atau, bila format seri tidak ditentukan, gaya dan tema bagan otomatis. Properti grup seperti overlap dan lebar celah mengendalikan tata letak dan bukan merupakan penimpaan format tingkat titik.

**Apakah ada batas berapa banyak seri yang dapat dimiliki sebuah bagan?**

Aspose.Slides tidak memberlakukan batas tetap jumlah seri. Dalam praktiknya, batasan file presentasi, memori tersedia, waktu rendering, dan keterbacaan bagan menentukan batas yang berguna.

**Apa yang harus diubah ketika kolom terlalu berdekatan atau terlalu jauh terpisah?**

Setel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) pada grup seri induk yang sesuai. Tingkatkan nilai untuk memperlebar ruang antara klaster, atau turunkan untuk mendekatkan klaster.