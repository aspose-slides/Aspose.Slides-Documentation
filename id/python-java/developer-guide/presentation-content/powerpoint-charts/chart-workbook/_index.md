---
title: Mengelola Workbook Grafik dalam Presentasi menggunakan Python via Java
linktitle: Workbook Grafik
type: docs
weight: 70
url: /id/python-java/chart-workbook/
keywords:
- workbook grafik
- data grafik
- sel workbook
- label data
- lembar kerja
- sumber data
- workbook eksternal
- data eksternal
- cache grafik
- pemulihan workbook
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Python via Java: kelola workbook grafik dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan workbook grafik di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data grafik melalui aliran workbook, menggunakan sel workbook sebagai label data grafik, mengakses koleksi lembar kerja, dan menentukan tipe sumber data untuk nilai grafik.

Ini juga mencakup penggunaan workbook eksternal sebagai sumber data grafik. Contoh-contoh menunjukkan cara membuat dan menetapkan workbook eksternal, mengambil jalur workbook eksternal yang terhubung ke grafik, serta mengedit data grafik saat workbook tersedia.

Untuk sel workbook yang mewakili data yang hilang, lihat [Mengontrol Tampilan Sel Kosong](/slides/id/python-java/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan grafik garis mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) untuk mengontrol apakah grafik memplot data dari baris dan kolom lembar kerja yang disembunyikan. Atur ke `True` untuk memplot hanya sel yang terlihat, atau `False` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemplotan grafik; tidak menyembunyikan atau menampilkan kembali baris atau kolom lembar kerja.

Presentasi contoh [presentasi contoh](hidden-source-data.pptx) berisi grafik kolom sebagai bentuk pertama pada slide pertama. Worksheet yang disematkan, `Sheet1`, berisi rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C disembunyikan, tetapi sel‑nya masih berisi nilai.

| Baris worksheet | A: Bulan | B: Ritel | C: Grosir (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (baris tersembunyi) | Februari | 40 | 60 |
| 4 | Maret | 20 | 50 |

Akses sel sumber melalui [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) dan baca [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) untuk memeriksa status tersembunyi mereka. Metode ini melaporkan status tersembunyi tanpa mengubahnya. Dalam contoh ini, B2 terlihat, B3 termasuk dalam baris tersembunyi, dan C2 termasuk dalam kolom tersembunyi; contoh mencetak `False`, `True`, dan `True` masing‑masing.

Untuk contoh ini, segarkan data grafik setelah mengubah pengaturan pemplotan: pertahankan workbook yang disematkan dengan [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) dan muat kembali dengan [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Saat menyertakan semua sel, juga gunakan [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) untuk mengembalikan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk menyegarkan cache data grafik dan label kategori pada contoh ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Segarkan data grafik dari workbook yang disematkan.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Kembalikan rentang sumber lengkap, termasuk kategori yang tersembunyi.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Contoh menyimpan dua versi presentasi: satu hanya dengan nilai Ritel yang terlihat (10 dan 20), dan satu lagi dengan semua enam nilai. Gambar di bawah mengilustrasikan dua mode pemplotan. Baris 3 dan kolom C tetap tersembunyi pada kedua workbook yang disematkan.

| Hanya sel terlihat (`True`) | Semua sel (`False`) |
| --- | --- |
| ![Hanya sel terlihat: nilai Ritel 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Ritel dan Grosir untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sebuah sel tersembunyi yang berisi nilai berbeda dari sel kosong. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) mengontrol bagaimana nilai yang hilang ditampilkan; tidak menyertakan atau mengecualikan data sumber yang tersembunyi. Lihat [Mengontrol Tampilan Sel Kosong](/slides/id/python-java/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Mengambil Rentang Data Grafik**

Sebelum memperbarui data workbook dalam presentasi yang ada, periksa rentang sumber untuk mengidentifikasi sel worksheet mana yang digunakan setiap grafik. Metode [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) mengembalikan rentang data saat ini sebagai rumus yang memenuhi kualifikasi worksheet, misalnya `Sheet1!$A$1:$D$5`. Di sini, `Sheet1` adalah nama worksheet, `!` memisahkannya dari rentang sel, dan `$A$1:$D$5` mengidentifikasi sel A1 sampai D5, termasuk. Tanda dolar menunjukkan referensi baris dan kolom absolut.

Metode ini membaca rentang saat ini tanpa mengubah grafik atau workbook‑nya. Jika grafik tidak menggunakan workbook sebagai sumber data, metode ini akan melempar `InvalidOperationException`. Untuk informasi lebih lanjut, lihat [Referensi API ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Contoh ini membuka presentasi dan memeriksa bentuk‑bentuk secara langsung pada setiap slide untuk grafik. Ia mencetak nama setiap grafik dan rentang sumbernya. Jika sebuah grafik tidak menggunakan workbook, ia mencetak pesan dan melanjutkan ke grafik berikutnya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Membaca dan Menulis Data Grafik dari Workbook**

Aspose.Slides untuk Python melalui Java menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) dan [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) yang memungkinkan Anda membaca dan menulis workbook data grafik (yang berisi data grafik yang diedit dengan Aspose.Cells). **Catatan** bahwa data grafik harus diatur dengan cara yang sama atau harus memiliki struktur yang mirip dengan sumber.

Contoh ini menggunakan presentasi dengan grafik sebagai bentuk pertama pada slide pertama. Ia membaca workbook yang disematkan ke dalam array byte, menghapus seri dan kategori yang ada, dan menulis kembali workbook yang sama. Perubahan tetap berada dalam memori; contoh tidak menyimpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Validasi Tata Letak Grafik Setelah Modifikasi Workbook**

Saat Anda mengganti workbook yang disematkan dengan versi yang dimodifikasi, grafik tetap mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) gagal dengan kesalahan indeks di luar jangkauan. Hapus seri dan kategori yang ada sebelum menulis kembali workbook yang diperbarui ke grafik. Contoh ini menggunakan grafik yang merupakan bentuk pertama pada slide pertama. Komentar menandai tempat dimana pengeditan workbook akan terjadi; contoh yang dapat dijalankan menulis kembali workbook asli dan memvalidasi tata letak dalam memori.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Ubah byte workbook di sini, misalnya, menggunakan Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Menghapus koleksi menghilangkan referensi data usang sebelum workbook ditulis kembali. Bangun kembali pemetaan seri dan kategori yang diperlukan untuk workbook yang diperbarui sebelum menggunakan grafik.

## **Menetapkan Format Angka Kustom untuk Sel Workbook**

Gunakan [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) untuk mengontrol bagaimana nilai numerik ditampilkan dalam workbook grafik yang disematkan. Misalnya, sebuah laporan mungkin memerlukan tingkat konversi ditampilkan sebagai persentase dengan empat tempat desimal dan koefisien ditampilkan dengan lima tempat desimal. Jaga kedua nilai tetap numerik agar tetap tersedia untuk perhitungan dan pemplotan grafik.

Format angka mengubah tampilan, bukan nilai yang disimpan. Format `0.0000%` menampilkan `0.125` sebagai `12.5000%`; tidak menggantikan angka yang disimpan dengan `12.5`. Demikian pula, `0.00000` menampilkan `0.1234567` sebagai `0.12346` tanpa membulatkan nilai yang disimpan. Jika format kustom berupa string kosong (`""`), format yang dikembalikan oleh [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) akan digunakan.

Contoh berikut membuat grafik kolom dan mengakses sel‑nya melalui [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook). Pada worksheet 0, B2 berisi tingkat konversi dan C2 berisi koefisien. Kedua sel menyediakan nilai grafik. Contoh juga mengaktifkan label nilai yang ditautkan ke format sumber.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Format sel workbook terpisah dari format yang diterapkan langsung pada sumbu grafik atau label data. Dalam contoh ini, setiap label menampilkan nilai sel sumbernya karena [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) diatur ke `True`, dan mengikuti format angka sumber karena [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) diatur ke `True`. Setelah menyimpan dan membuka kembali presentasi, label menampilkan `12.5000%` dan `0.12346`, seperti yang terlihat di bawah. Sumbu vertikal menggunakan format angka tersendiri, ditetapkan dengan [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) sebagai `0.00`, dengan [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) diatur ke `False`.

Untuk memformat label data secara independen, atur flag tautan ke sumber menjadi `False` dan tetapkan format dengan [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat). Ini tidak mengubah format sel workbook. Misalnya, format label independen `0.00` menampilkan nilai pertama sebagai `0.13`, sementara B2 tetap menampilkan `12.5000%`. Lihat [Label Data Grafik](/slides/id/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) untuk memformat label secara langsung.

Gambar di bawah dirender dari presentasi yang disimpan setelah dibuka kembali:

![Grafik kolom dengan label terhubung ke sumber yang menampilkan 12.5000% dan 0.12346 serta sumbu numerik yang diformat secara independen.](custom-cell-formats.png)

## **Menetapkan Sel Workbook sebagai Label Data Grafik**

Anda dapat menggunakan teks dari sel workbook sebagai label data grafik.

Contoh ini menambahkan grafik gelembung dengan data default ke slide pertama presentasi yang ada. Ia menggunakan sel A10:A12 pada worksheet 0 untuk tiga label pertama pada seri pertama, mengaktifkan label dari sel, dan menyimpan presentasi yang diperbarui.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengelola Lembar Kerja**

Metode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) menyediakan akses ke lembar kerja dalam workbook grafik. Contoh ini membuat grafik pai dengan data default dan mencetak nama setiap lembar kerja ke konsol.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Menentukan Tipe Sumber Data**

Nilai titik seri juga dapat disimpan langsung sebagai literal numerik. Lihat [Set Series Values Using Numeric Literals](/slides/id/python-java/chart-series/#set-series-values-using-numeric-literals) untuk contoh lengkap yang menyimpan dan membacanya. Tipe sumber nilai titik terpisah dari konfigurasi workbook internal atau eksternal grafik; penggunaan literal numerik tidak, dengan sendirinya, menghapus workbook yang disematkan.

Contoh ini membuat grafik kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; yang kedua menggunakan sel C1 pada worksheet 0. Enum [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) memilih sumber untuk setiap nama. Contoh menyimpan presentasi dengan nama seri yang diperbarui.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mendeteksi Format Workbook Tertanam yang Tidak Didukung**

Aspose.Slides tidak mendukung format workbook Excel biner (.xlsb) yang dapat disematkan dalam beberapa grafik. Anda dapat menggunakan metode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) pada [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) bersama dengan enum [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan grafik tersebut. Contoh ini memeriksa bentuk pada slide pertama presentasi yang ada, melewatkan bentuk non‑grafik, dan mencetak pesan diagnostik untuk setiap grafik dengan workbook .xlsb yang disematkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Baca atau ubah data workbook grafik yang didukung di sini.
finally:
    presentation.dispose()
```

## **Workbook Eksternal**

Aspose.Slides mendukung penggunaan workbook eksternal sebagai sumber data untuk grafik.

### **Membuat Workbook Eksternal**

Gunakan [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) dan [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) untuk mengekspor workbook grafik yang disematkan ke file dan menautkan grafik ke workbook eksternal tersebut.

Contoh ini membuat grafik pai dengan data default dan mengekspor workbook‑nya. Ia menyelesaikan penulisan file sebelum menetapkan workbook eksternal sebagai sumber data grafik, lalu menyimpan presentasi yang ditautkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Menetapkan Workbook Eksternal**

Dengan menggunakan metode [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), Anda dapat menetapkan workbook eksternal ke grafik sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke workbook eksternal (jika workbook tersebut dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam workbook yang disimpan di lokasi remote atau sumber daya, Anda masih dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika jalur relatif untuk workbook eksternal diberikan, jalur tersebut secara otomatis dikonversi menjadi jalur penuh.

Contoh ini menggunakan workbook eksternal yang lembar kerjanya bernama `Sheet1` berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh membuat grafik pai, menautkan workbook, dan menggunakan [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Ia menyimpan presentasi dengan grafik yang ditautkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Parameter `updateChartData` pada metode [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) mengontrol apakah workbook dimuat.

* Ketika `updateChartData` bernilai `False`, hanya jalur workbook yang diperbarui. Data grafik tidak dimuat atau diperbarui dari workbook target, sehingga workbook dapat tidak tersedia.  
* Ketika `updateChartData` bernilai `True`, data grafik diperbarui dari workbook target.

Contoh berikut menetapkan URL placeholder dengan `updateChartData` disetel ke `False`. Ia mempertahankan data default grafik pai dan menyimpan presentasi tanpa memuat workbook yang tidak tersedia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Mendapatkan Jalur Workbook Sumber Data Eksternal dari Grafik**

Untuk mengidentifikasi workbook yang ditautkan ke grafik, periksa apakah grafik menggunakan sumber data eksternal dan ambil jalur workbook‑nya.

Contoh ini memeriksa bentuk pertama pada slide pertama presentasi dengan workbook eksternal yang ditautkan. Jika itu adalah grafik yang ditautkan ke workbook eksternal, contoh mencetak [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ke konsol. Kemudian ia menyimpan salinan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Mengedit Data Grafik**

Anda dapat mengedit data dalam workbook eksternal dengan cara yang sama seperti mengubah isi workbook internal. Ketika workbook eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Contoh ini menggunakan grafik yang merupakan bentuk pertama pada slide pertama dan ditautkan ke workbook eksternal yang dapat diakses. Ia menetapkan nilai berbasis sel untuk titik data pertama pada seri pertama menjadi 100 dan menyimpan presentasi yang diperbarui. Mengedit nilai sel dapat memperbarui file XLSX eksternal yang ditautkan, jadi gunakan salinan jika Anda perlu mempertahankan workbook asli.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Memulihkan Workbook dari Cache Grafik**

Jika sebuah grafik menggunakan workbook eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi workbook grafik dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), panggil [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), dan setel [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) ke `True` sebelum membuka presentasi.

Contoh Python berikut memulihkan data workbook untuk grafik yang merupakan bentuk pertama pada slide pertama dan merujuk ke workbook eksternal yang tidak tersedia. Ia mengakses data yang dipulihkan melalui [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) dan [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Baca atau ubah data workbook yang dipulihkan di sini.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Jika workbook eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika penggunaan data grafik yang di‑cache merupakan alternatif yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada workbook eksternal setelah presentasi terakhir diperbarui.

## **Tanya Jawab**

**Apakah saya dapat menentukan apakah grafik tertentu terhubung ke workbook eksternal atau tersemat?**

Ya. Sebuah grafik memiliki [tipe sumber data](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) dan [jalur ke workbook eksternal](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); jika sumbernya adalah workbook eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke workbook eksternal didukung, dan bagaimana mereka disimpan?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Presentasi menyimpan jalur absolut dalam file PPTX, sehingga memindahkan workbook mungkin memerlukan pembaruan tautan.

**Bisakah saya menggunakan workbook yang terletak di sumber daya/jaringan bersama?**

Ya, workbook semacam itu dapat digunakan sebagai sumber data eksternal. Namun, mengedit workbook remote secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan sebuah [tautan ke file eksternal](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Mengedit data grafik berbasis sel juga dapat memperbarui file XLSX lokal yang ditautkan. Gunakan salinan workbook jika file asli harus tetap tidak berubah.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa grafik merujuk pada workbook eksternal yang sama?**

Ya. Setiap grafik menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap grafik pada kali berikutnya data dimuat.