---
title: Kelola Seri Data Diagram dalam Presentasi di Python
linktitle: Seri Data
type: docs
url: /id/python-java/chart-series/
keywords:
- seri diagram
- tumpang tindih seri
- warna seri
- nama seri
- titik data
- sel buku kerja
- celah seri
- nilai negatif
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara mengelola seri diagram, titik data, sel buku kerja, pemformatan, tumpang tindih, lebar celah, dan nilai negatif dalam presentasi dengan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Diagram menyimpan data yang dipetakan dalam buku kerja data diagram. Sebuah [ChartSeries](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/) mewakili satu set nilai terkait, dan setiap [ChartDataPoint](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatapoint/) dalam seri mengacu pada satu atau lebih sel buku kerja. Objek [ChartCategory](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartcategory/) menyediakan label atau nilai pengelompokan yang dibagikan oleh seri. Nama seri, kategori, dan nilai titik karena itu terhubung ke objek [ChartDataCell](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/) bukan hanya disimpan sebagai teks tampilan.

Untuk diagram kategori tipikal, buku kerja default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel‑sel sisanya untuk nilai seri. Indeks worksheet, baris, dan kolom yang diberikan ke [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/#getCell) berbasis nol. Tata letak ini berguna ketika Anda membuat diagram dengan data default, tetapi jangan mengasumsikan bahwa setiap diagram yang ada menggunakannya. Untuk presentasi yang dimuat, periksa sel‑sel yang dirujuk oleh seri, kategori, dan titik data sebelum mengubah nilai buku kerja.

Pengaturan diagram memiliki tiga cakupan berbeda:

- Pengaturan tingkat Seri, seperti [ChartSeries.getFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/#getFormat), menyediakan tampilan default untuk semua titik dalam satu seri.
- Pengaturan titik data, seperti [ChartDataPoint.getFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatapoint/#getFormat), menggantikan tampilan seri untuk satu titik.
- Pengaturan grup berlaku untuk seri yang kompatibel yang berada dalam satu [ChartSeriesGroup](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/). Akses grup melalui [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/#getParentSeriesGroup) ketika Anda perlu mengatur opsi seperti tumpang tindih atau lebar celah.

Ketika tidak ada pengisian titik atau seri yang eksplisit diatur, gaya dan tema diagram menentukan tampilan otomatis. Ketika format seri dan titik keduanya ada, format titik memiliki prioritas untuk titik tersebut.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Atur Tumpang Tindih Seri Diagram**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/#getOverlap) melaporkan seberapa banyak batang atau kolom tumpang tindih dalam diagram 2D, dari -100 hingga 100 persen. Ini merupakan proyeksi baca‑saja dari pengaturan pada grup seri induk. Gunakan [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/#setOverlap) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe diagram yang menampilkan batang atau kolom bergrup; tidak memengaruhi grup seri yang tidak terkait dalam diagram kombinasi.

Contoh berikut mengatur tumpang tindih untuk grup yang berisi seri pertama:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Diagram baru berisi seri contoh, kategori, dan nilai.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![The series overlap](series_overlap.png)

## **Ubah Warna Isi Seri**

Gunakan [ChartSeries.getFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/#getFormat) untuk mengatur isi default untuk seluruh seri. Jika sebuah titik sudah memiliki isi eksplisit, pengaturan [ChartDataPoint.getFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatapoint/#getFormat) menggantikan isi seri untuk titik tersebut.

Contoh berikut menerapkan isi biru padat pada seri pertama:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![The color of the series](series_color.png)

## **Ubah Nama Seri**

Nama seri disimpan dalam buku kerja data diagram dan biasanya ditampilkan di legenda. Dalam buku kerja default yang dibuat untuk diagram kolom berkelompok, sel B1 berada pada baris 0, kolom 1 dan berisi nama seri pertama. Variabel bernama dalam contoh berikut membuat struktur itu eksplisit:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Anda juga dapat memperbarui sel yang sudah dirujuk oleh [ChartSeries.getName](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/#getName). Pendekatan ini menghindari asumsi baris dan kolom tertentu dalam diagram yang ada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![The series name](series_name.png)

## **Dapatkan Warna Isi Seri Otomatis**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) mengembalikan warna yang dihitung dari indeks seri dan gaya diagram. Ini adalah warna yang digunakan ketika isi seri tidak didefinisikan secara eksplisit. Memanggil metode membaca warna yang dihitung; tidak menetapkan isi baru.

Contoh berikut mencetak warna otomatis masing‑masing seri default:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Contoh output untuk gaya diagram default:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Warna tepat bergantung pada gaya dan tema diagram.

## **Atur Warna Isi Terbalik untuk Seri Diagram**

Untuk seri batang, kolom, dan gelembung, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/#setInvertIfNegative) dapat menampilkan nilai negatif dengan isi yang berbeda. Atur isi seri reguler menjadi padat, aktifkan inversi, dan tetapkan warna nilai negatif melalui [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Angka negatif tetap tidak berubah dalam buku kerja; hanya warna tampilan yang berubah.

Contoh berikut menggantikan data diagram default dengan satu seri. Baris worksheet 0 berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![The inverted solid fill color](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Dalam contoh berikut, inversi dinonaktifkan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik tersebut juga diberikan nilai negatif sehingga efeknya terlihat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bersihkan Nilai Titik Data Tertentu**

Agar satu titik menjadi kosong tanpa menghapus titik lain, atur sel buku kerja yang mendasarinya menjadi `None`. Untuk diagram kolom, nilai yang dipetakan tersedia melalui [ChartDataPoint.getValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatapoint/#getValue). Titik data tetap pada posisi kategori yang sama, tetapi diagram memperlakukan nilainya sebagai kosong sesuai pengaturan nilai kosong diagram.

Contoh berikut membersihkan hanya titik kedua dalam seri pertama:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Diagram sebar menggunakan sel X dan Y terpisah, dan diagram gelembung juga menggunakan sel ukuran. Hapus hanya sel yang mewakili nilai yang ingin Anda hapus. Jangan memanggil [ChartDataPointCollection.clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatapointcollection/#clear) ketika Anda ingin mempertahankan titik lain, karena metode itu menghapus setiap titik data dari koleksi.

## **Kendalikan Tampilan Sel Kosong**

Sel tersembunyi yang berisi nilai merupakan kasus terpisah dari sel kosong. Untuk menyertakan atau mengecualikan data dari baris dan kolom worksheet yang tersembunyi, lihat [Include Data from Hidden Rows and Columns](/slides/id/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Sel workbook kosong mewakili data yang hilang; sel yang berisi `0` mewakili nilai numerik yang diketahui. Panggil [ChartDataCell.setValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatacell/#setValue) dengan `None` untuk membuat sel kosong. Angka nol numerik tetap nol terlepas dari pengaturan sel kosong.

Gunakan [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#setDisplayBlanksAs) untuk memilih bagaimana diagram menampilkan sel kosong. Pengaturan ini berlaku untuk seluruh diagram. Ia mengubah cara kosong dipetakan, tanpa mengisi sel workbook kosong dengan nol atau nilai interpolasi.

Contoh mandiri berikut membuat diagram garis dengan satu seri, mengosongkan nilai untuk Hari 3, dan menyimpan diagram yang sama dengan setiap mode. Tidak diperlukan file input. [ChartDataWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/) menggunakan worksheet 0, kolom 0 untuk label kategori, dan kolom 1 untuk nilai; baris 0 memuat nama seri. Data akhir adalah `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Biarkan Hari 3 benar-benar kosong, sambil mempertahankan kategori dan titik datanya.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Setiap file output menyimpan mode yang ditetapkan sebelum penyimpanan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, dan `empty_cells_Span.pptx`. Untuk menyimpan hanya satu versi, tetapkan mode yang diinginkan dan simpan presentasi sekali saja alih‑alih mengulangi mode.

Perbandingan di bawah menunjukkan data yang sama dalam ketiga file. Hari 3 kosong dalam workbook pada setiap kasus:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Efek yang terlihat tergantung pada tipe diagram. Diagram garis memudahkan perbandingan ketiga mode. Diagram batang dan kolom tidak memiliki garis untuk menghubungkan kategori yang hilang, sehingga `Span` tidak dapat menghasilkan segmen penghubung yang ditunjukkan di atas; kolom yang hilang dan kolom dengan tinggi nol juga dapat terlihat serupa. Demikian pula, diagram sebar dengan hanya penanda tidak memiliki garis penghubung. Jangan mengharapkan tiga hasil berbeda untuk setiap tipe diagram; periksa output untuk tipe yang Anda gunakan.

## **Atur Lebar Celah Seri**

Lebar celah adalah ruang antara kelompok batang atau kolom yang berdekatan, dinyatakan sebagai persentase lebar batang atau kolom. Seperti tumpang tindih, lebar ini milik grup seri induk, bukan satu seri. Panggil [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/#setGapWidth) sekali untuk grup. Nilai yang lebih besar membuat ruang antar‑kelompok lebih lebar; nilai yang lebih kecil membuatnya lebih padat.

Contoh berikut mengubah lebar celah dan menyimpan hanya presentasi akhir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![The gap width](gap_width.png)

## **FAQ**

**Tipe diagram apa yang mendukung data seri?**

Semua tipe diagram yang direpresentasikan oleh enumerasi [ChartType](https://reference.aspose.com/slides/id/python-java/aspose.slides/charttype/) menggunakan data diagram, tetapi seri mereka tidak semua memiliki struktur nilai atau pengaturan yang sama. Misalnya, diagram kategori menggunakan kategori dan nilai, diagram sebar menggunakan nilai X dan Y, dan diagram gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang cocok dengan tipe seri. Opsi seperti tumpang tindih dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri diagram?**

[ChartSeriesGroup](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/) berisi seri yang kompatibel yang berbagi pengaturan plotting tingkat grup. Diagram kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup yang dicapai melalui satu seri tidak selalu mengubah setiap seri dalam diagram.

**Apakah diagram yang baru dibuat berisi data default?**

Ya. Secara default, [ShapeCollection.addChart](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addChart) membuat seri contoh, kategori, dan nilai. Anda dapat mengedit sel‑sel tersebut atau mengosongkan koleksi seri dan kategori sebelum menambahkan set data yang sepenuhnya kustom. Overload juga dapat membuat diagram tanpa data default.

**Bagaimana objek diagram terhubung ke sel workbook?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam [ChartDataWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/). Mengubah sel yang dirujuk memperbarui elemen diagram yang bersangkutan. Saat Anda membangun data kustom, pertahankan baris kategori dan baris nilai seri tetap selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara menghapus satu titik saja, bukan seluruh seri?**

Atur sel nilai yang relevan menjadi `None` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [ChartDataPointCollection.clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatapointcollection/#clear) hanya ketika Anda bermaksud menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri agar nilai mereka tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe diagram dan nilai yang dikonfigurasi melalui [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#setDisplayBlanksAs). Diagram yang didukung dapat menampilkan kosong sebagai celah, sebagai nilai nol, atau dengan menghubungkan titik tetangga. Pilih pengaturan yang sesuai dengan makna data yang hilang dalam presentasi Anda. Lihat [Control the Display of Empty Cells](#control-the-display-of-empty-cells) untuk contoh lengkap dan perbandingan visual.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, panggil [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/#setInvertIfNegative) dan atur warna yang dikembalikan oleh [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Anda dapat menimpa perilaku untuk titik individu dengan [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Metode‑metode ini memengaruhi pemformatan, bukan nilai numerik yang disimpan.

**Format mana yang menang ketika seri dan titik keduanya diformat?**

Pemformatan titik data eksplisit memiliki prioritas untuk titik itu. Titik lain terus menggunakan format seri eksplisit atau, ketika format seri tidak didefinisikan, gaya dan tema diagram otomatis. Pengaturan grup seperti tumpang tindih dan lebar celah mengontrol tata letak dan bukan penimpaan format tingkat titik.

**Apakah ada batas berapa banyak seri yang dapat dimiliki diagram?**

Aspose.Slides tidak memberlakukan batas tetap terpisah untuk jumlah seri. Dalam praktiknya, batas file presentasi, memori yang tersedia, waktu rendering, dan keterbacaan diagram menentukan batas yang berguna.

**Apa yang harus diubah ketika kolom terlalu berdekatan atau terlalu jauh?**

Panggil [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartseriesgroup/#setGapWidth) pada grup seri induk yang tepat. Tingkatkan nilai untuk memperlebar ruang antar‑kelompok, atau turunkan nilai untuk mendekatkan kelompok.