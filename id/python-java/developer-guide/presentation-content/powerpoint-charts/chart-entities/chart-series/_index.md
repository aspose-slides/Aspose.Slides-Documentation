---
title: Mengelola Seri Data Bagan dalam Presentasi di Python
linktitle: Seri Data
type: docs
url: /id/python-java/chart-series/
keywords:
- seri bagan
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
description: "Pelajari cara mengelola seri bagan, titik data, sel buku kerja, pemformatan, tumpang tindih, lebar celah, dan nilai negatif dalam presentasi dengan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Sebuah bagan dapat menyimpan nilai yang dipetakan di sel buku kerja atau langsung sebagai literal numerik. Sebuah [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) mewakili satu set nilai yang terkait, dan setiap [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) mewakili satu titik dalam seri tersebut. Objek [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) menyediakan label atau nilai pengelompokan yang dibagikan oleh seri. Pada bagan yang dibuat dengan data default, nama seri, kategori, dan nilai titik menggunakan objek [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) dari buku kerja bagan.

Untuk bagan kategori tipikal, buku kerja default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel‑sel sisanya untuk nilai seri. Indeks worksheet, baris, dan kolom yang diteruskan ke [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) bersifat berbasis nol. Tata letak ini berguna ketika Anda membuat bagan dengan data default, tetapi jangan mengasumsikan bahwa setiap bagan yang ada menggunakannya. Untuk presentasi yang dimuat, periksa sel‑sel yang dirujuk oleh seri, kategori, dan titik data sebelum mengubah nilai buku kerja.

Pengaturan bagan memiliki tiga lingkup yang berbeda:

- Pengaturan tingkat seri, seperti [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), menyediakan tampilan default untuk semua titik dalam satu seri.
- Pengaturan titik data, seperti [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), mengganti tampilan seri untuk satu titik.
- Pengaturan grup berlaku untuk seri yang kompatibel yang berada dalam satu [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/). Akses grup melalui [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) ketika Anda perlu mengatur opsi seperti overlap atau lebar celah.

Ketika tidak ada isian titik atau seri yang eksplisit diatur, gaya dan tema bagan menentukan tampilan otomatis. Ketika format seri dan titik keduanya ada, format titik memiliki prioritas untuk titik tersebut.

![seri-grafik-powerpoint](chart-series-powerpoint.png)

## **Setel Nilai Seri Menggunakan Literal Numerik**

Gunakan literal numerik ketika nilai seri berasal dari data aplikasi atau perhitungan dan tidak memerlukan referensi sel worksheet. Panggil [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) dengan [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) sebelum menugaskan hasil [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) setiap titik melalui [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble).

Pengaturan koleksi mengontrol tipe sumber semua nilai titik dalam seri tersebut. Metode [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) setiap nilai titik melaporkan tipe yang dipilih; ubah melalui pengaturan koleksi. Dengan `Worksheet`, gunakan [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) untuk mengakses sel yang dirujuk. Dengan `DoubleLiterals`, gunakan [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) atau `setAsLiteralDouble` untuk membaca atau menulis angka secara langsung.

Contoh berikut membuat bagan kolom dengan seri dan kategori default, kemudian menugaskan nilai yang dihitung 10, 20, dan seterusnya ke titik‑titik yang ada pada seri pertamanya. Ia menyimpan presentasi, membukanya kembali, dan mencetak nilai yang disimpan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

Tipe sumber nilai titik terpisah dari [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType), yang mengidentifikasi konfigurasi buku kerja internal atau eksternal bagan. Menggunakan literal numerik tidak secara otomatis menghapus buku kerja yang disematkan. Pada contoh ini, buku kerja tetap tersedia untuk label kategori, nama seri, dan seri lainnya. Lihat [Chart Workbook](/slides/id/python-java/chart-workbook/) untuk manajemen buku kerja.

Untuk bagan sebar dan gelembung, gunakan [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) dan [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) untuk memilih sumber bagi [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) dan [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue). Bagan gelembung juga menggunakan [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) untuk [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize). Atur setiap sumber yang berlaku ke `DoubleLiterals` sebelum menugaskan angka melalui metode `setAsLiteralDouble` nilai tersebut.

## **Setel Overlap Seri Bagan**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) melaporkan seberapa banyak batang atau kolom saling tumpang tindih pada bagan 2D, dari –100 hingga 100 persen. Itu merupakan proyeksi baca‑saja dari pengaturan pada grup seri induk. Gunakan [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe bagan yang menampilkan batang atau kolom berkelompok; tidak memengaruhi grup seri yang tidak terkait dalam bagan kombinasi.

Contoh berikut mengatur overlap untuk grup yang berisi seri pertama:

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

    # Bagan baru berisi contoh seri, kategori, dan nilai.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Overlap seri](series_overlap.png)

## **Ubah Warna Isian Seri**

Gunakan [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) untuk mengatur isian default bagi seluruh seri. Jika sebuah titik sudah memiliki isian eksplisit, pengaturan [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) menimpa isian seri untuk titik tersebut.

Contoh berikut menerapkan isian biru solid pada seri pertama:

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

![Warna seri](series_color.png)

## **Ubah Nama Seri**

Nama seri disimpan dalam buku kerja data bagan dan biasanya ditampilkan dalam legenda. Pada buku kerja default yang dibuat untuk bagan kolom berkelompok, sel B1 berada pada baris 0, kolom 1 dan berisi nama seri pertama. Variabel bernama dalam contoh berikut membuat struktur tersebut eksplisit:

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

Anda juga dapat memperbarui sel yang sudah dirujuk oleh [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName). Pendekatan ini menghindari asumsi baris dan kolom tertentu dalam bagan yang ada:

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

![Nama seri](series_name.png)

### **Buat Seri dengan Nama dari Beberapa Sel**

Nama seri komposit berguna ketika nama produk dan periode pelaporan disimpan di sel buku kerja terpisah. Misalnya, Anda dapat menggabungkan `Product A` di B1 dan `2026` di C1 menjadi satu nama seri sambil menjaga kedua bagian tetap terhubung ke sel sumbernya.

Gunakan [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) untuk mengambil rentang nama, lalu berikan koleksi itu ke [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add). Argumen `skipHiddenCells` mengontrol apakah sel tersembunyi disertakan: `True` mengecualikannya, sementara `False` menyertakannya. Contoh ini menggunakan `False` untuk menyertakan setiap sel dalam rentang nama.

Contoh berikut membuat presentasi dengan satu seri dan dua titik data. Sel B1:C1 hanya menyediakan nama seri; A2:A3 menyediakan label kategori, dan B2:B3 menyediakan nilai numerik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Dua sel ini menyediakan nama seri.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # Sel terpisah menyediakan kategori dan titik data numerik.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nama seri yang dihasilkan adalah `Product A 2026`, dengan spasi antara dua nilai sel. Legenda menampilkan ini sebagai satu entri untuk kedua kolom. Gambar di bawah menggambarkan hasilnya:

![Bagan kolom dengan nilai Utara dan Selatan serta nama seri komposit Product A 2026 dalam legenda](composite_series_name.png)

## **Dapatkan Warna Isian Seri Otomatis**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) mengembalikan warna yang dihitung dari indeks seri dan gaya bagan. Ini adalah warna yang digunakan ketika isian seri tidak didefinisikan secara eksplisit. Memanggil metode tersebut hanya membaca warna yang dihitung; tidak menetapkan isian baru.

Contoh berikut mencetak warna otomatis setiap seri default:

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

Output contoh untuk gaya bagan default:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Warna tepatnya bergantung pada gaya dan tema bagan.

## **Setel Warna Isian Invers untuk Seri Bagan**

Untuk seri batang, kolom, dan gelembung, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) dapat menampilkan nilai negatif dengan isian yang berbeda. Setel isian seri reguler ke solid, aktifkan inversi, dan berikan warna nilai negatif melalui [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Angka negatif tetap tidak berubah di buku kerja; hanya warna tampilan yang berubah.

Contoh berikut menggantikan data bagan default dengan satu seri. Baris worksheet 0 berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

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

![Warna isian solid terbalik](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Pada contoh berikut, inversi dinonaktifkan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik tersebut juga diberikan nilai negatif sehingga efeknya terlihat:

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

Untuk membuat satu titik kosong tanpa menghapus titik lain, setel sel buku kerja yang mendasarinya ke `None`. Untuk bagan kolom, nilai yang dipetakan tersedia melalui [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue). Titik data tetap berada pada posisi kategori yang sama, tetapi bagan memperlakukan nilainya sebagai kosong sesuai pengaturan nilai kosong bagan.

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

Bagan sebar menggunakan sel X dan Y terpisah, dan bagan gelembung juga menggunakan sel ukuran. Bersihkan hanya sel yang mewakili nilai yang ingin Anda hapus. Jangan panggil [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) ketika Anda ingin mempertahankan titik lain, karena metode tersebut menghapus semua titik data dari koleksi.

## **Kendalikan Tampilan Sel Kosong**

Sel tersembunyi yang berisi nilai merupakan kasus terpisah dari sel kosong. Untuk menyertakan atau mengecualikan data dari baris dan kolom worksheet yang tersembunyi, lihat [Include Data from Hidden Rows and Columns](/slides/id/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Sel buku kerja kosong mewakili data yang hilang; sel yang berisi `0` mewakili nilai numerik yang diketahui. Panggil [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) dengan `None` untuk membuat sel kosong. Nilai numerik nol tetap nol terlepas dari pengaturan sel kosong.

Gunakan [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) untuk memilih bagaimana bagan menampilkan sel kosong. Pengaturan ini berlaku untuk seluruh bagan. Ia mengubah cara kekosongan diplot, tanpa mengisi sel buku kerja kosong dengan nol atau nilai interpolasi.

Contoh mandiri berikut membuat bagan garis dengan satu seri, mengosongkan nilai untuk Hari 3, dan menyimpan bagan yang sama dengan setiap mode. Tidak diperlukan berkas masukan. [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) menggunakan worksheet 0, kolom 0 untuk label kategori, dan kolom 1 untuk nilai; baris 0 memuat nama seri. Data akhir adalah `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

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

    # Biarkan Hari 3 benar-benar kosong, sambil mempertahankan kategorinya dan titik datanya.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Setiap berkas output menyimpan mode yang ditetapkan sebelum penyimpanan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, dan `empty_cells_Span.pptx`. Untuk menyimpan hanya satu versi, tetapkan mode yang diinginkan dan simpan presentasi sekali saja alih‑alih mengulangi semua mode.

Perbandingan di bawah menampilkan data yang sama dalam ketiga berkas. Hari 3 kosong di buku kerja pada setiap kasus:

![Bagan garis dengan data identik: Gap memutus garis pada Hari 3, Zero menurunkan garis ke nol, dan Span menghubungkan Hari 2 ke Hari 4.](display_blanks_as.png)

Efek visual tergantung pada tipe bagan. Bagan garis memudahkan perbandingan ketiga mode. Bagan batang dan kolom tidak memiliki garis untuk menghubungkan kategori yang hilang, sehingga `Span` tidak dapat menghasilkan segmen penghubung seperti di atas; kolom yang hilang dan kolom dengan tinggi nol dapat terlihat serupa. Demikian juga, bagan sebar dengan penanda saja tidak memiliki garis penghubung. Jangan mengharapkan tiga hasil berbeda untuk setiap tipe bagan; periksa output untuk tipe yang Anda gunakan.

## **Setel Lebar Celah Seri**

Lebar celah adalah ruang antar klaster batang atau kolom yang berdekatan, dinyatakan sebagai persentase lebar batang atau kolom. Seperti overlap, ia menjadi milik grup seri induk, bukan satu seri. Panggil [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) sekali untuk grup tersebut. Nilai yang lebih besar menciptakan ruang lebih luas antar klaster; nilai yang lebih kecil membuat mereka lebih rapat.

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

![Lebar celah](gap_width.png)

## **Tanya Jawab**

**Tipe bagan apa yang mendukung data seri?**

Semua tipe bagan yang diwakili oleh enumerasi [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) menggunakan data bagan, tetapi seri‑serinya tidak semuanya memiliki struktur nilai atau pengaturan yang sama. Misalnya, bagan kategori menggunakan kategori dan nilai, bagan sebar menggunakan nilai X dan Y, dan bagan gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe seri. Opsi seperti overlap dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri bagan?**

Sebuah [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) berisi seri yang kompatibel yang berbagi pengaturan plotting tingkat grup. Bagan kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup yang diakses melalui satu seri tidak selalu mengubah setiap seri dalam bagan.

**Apakah bagan yang baru dibuat berisi data default?**

Ya. Secara default, [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) membuat contoh seri, kategori, dan nilai. Anda dapat mengedit sel‑sel tersebut atau mengosongkan kedua koleksi seri dan kategori sebelum menambahkan set data yang sepenuhnya kustom. Sebuah overload juga dapat membuat bagan tanpa data default.

**Bagaimana objek bagan terhubung ke sel buku kerja?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam sebuah [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/). Mengubah sel yang dirujuk memperbarui elemen bagan yang bersangkutan. Ketika Anda membangun data kustom, jaga agar baris kategori dan baris nilai‑seri tetap selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara mengosongkan satu titik tanpa seluruh seri?**

Setel sel nilai yang relevan ke `None` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) hanya ketika Anda bermaksud menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri sehingga nilai‑nya tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya bergantung pada tipe bagan dan nilai yang dikonfigurasi melalui [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs). Bagan yang didukung dapat menampilkan kosong sebagai celah, sebagai nilai nol, atau dengan menghubungkan titik‑titik tetangga. Pilih pengaturan yang sesuai dengan makna data yang hilang dalam presentasi Anda. Lihat [Control the Display of Empty Cells](#control-the-display-of-empty-cells) untuk contoh lengkap dan perbandingan visual.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, panggil [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) dan setel warna yang dikembalikan oleh [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Anda dapat menimpa perilaku untuk titik individual dengan [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Metode‑metode ini memengaruhi pemformatan, bukan nilai numerik yang disimpan.

**Pengaturan mana yang menang ketika seri dan titik keduanya diformat?**

Pemformatan titik data eksplisit memiliki prioritas untuk titik tersebut. Titik‑titik lain terus menggunakan format seri eksplisit atau, bila format seri tidak didefinisikan, gaya dan tema bagan otomatis. Pengaturan grup seperti overlap dan lebar celah mengontrol tata letak dan bukan penimpaan pemformatan tingkat titik.

**Apakah ada batas jumlah seri yang dapat dimiliki bagan?**

Aspose.Slides tidak memberlakukan batas tetap terpisah untuk jumlah seri. Pada praktiknya, batas dipengaruhi oleh batasan berkas presentasi, memori yang tersedia, waktu rendering, dan keterbacaan bagan.

**Apa yang harus diubah ketika kolom terlalu berdekatan atau terlalu berjauhan?**

Panggil [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) pada grup seri induk yang sesuai. Tingkatkan nilai untuk memperlebar ruang antar klaster, atau turunkan nilai untuk mendekatkan klaster.