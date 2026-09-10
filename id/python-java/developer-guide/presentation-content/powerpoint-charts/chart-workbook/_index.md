---
title: Mengelola Workbook Diagram dalam Presentasi Menggunakan Python via Java
linktitle: Workbook Diagram
type: docs
weight: 70
url: /id/python-java/chart-workbook/
keywords:
- workbook diagram
- data diagram
- sel workbook
- label data
- lembar kerja
- sumber data
- workbook eksternal
- data eksternal
- cache diagram
- pemulihan workbook
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Python via Java: dengan mudah mengelola workbook diagram dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan workbook diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran workbook, menggunakan sel workbook sebagai label data diagram, mengakses koleksi worksheet, dan menentukan jenis sumber data untuk nilai diagram.

Artikel ini juga membahas cara bekerja dengan workbook eksternal sebagai sumber data diagram. Contoh-contoh menunjukkan cara membuat dan menetapkan workbook eksternal, mengambil jalur workbook eksternal yang terhubung ke diagram, dan mengedit data diagram ketika workbook tersedia.

## **Baca dan Tulis Data Diagram dari Workbook**
Aspose.Slides menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#readWorkbookStream) dan [writeWorkbookStream](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#writeWorkbookStream) yang memungkinkan Anda untuk membaca dan menulis workbook data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau harus memiliki struktur yang mirip dengan sumber.

Kode Python berikut menunjukkan contoh operasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Validasi Tata Letak Diagram Setelah Modifikasi Workbook**

Ketika Anda mengganti workbook yang disematkan dengan yang telah dimodifikasi, diagram tetap mempertahankan kumpulan seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [Chart.validateChartLayout](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#validateChartLayout) melemparkan `ArgumentOutOfRangeException` (parameter: index). Untuk menghindari pengecualian, bersihkan seri dan kategori yang ada **sebelum** menulis kembali workbook yang diperbarui ke diagram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Baca workbook setelah memodifikasinya (mis., menggunakan Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Hapus referensi data yang ada.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Membersihkan koleksi memastikan bahwa struktur data diagram sesuai dengan workbook baru, sehingga [validateChartLayout](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#validateChartLayout) dapat selesai tanpa kesalahan.

## **Atur Sel Workbook sebagai Label Data Diagram**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram Bubble dengan beberapa data.
4. Akses seri diagram.
5. Setel sel workbook sebagai label data.
6. Simpan presentasi.

Kode Python berikut menunjukkan cara mengatur sel workbook sebagai label data diagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
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

## **Kelola Worksheet**

Kode Python berikut menunjukkan operasi di mana metode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/#getWorksheets) digunakan untuk mengakses koleksi worksheet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Tentukan Jenis Sumber Data**

Kode Python berikut menunjukkan cara menentukan jenis untuk sumber data:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Deteksi Format Workbook Tertanam yang Tidak Didukung**

Aspose.Slides tidak mendukung format workbook biner Excel (.xlsb) yang dapat disematkan dalam beberapa diagram. Anda dapat menggunakan metode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) pada [ChartData](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/python-java/aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan diagram tersebut.

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
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Workbook yang disematkan berada dalam format .xlsb, yang tidak didukung.
            continue
        # Baca atau modifikasi data workbook diagram di sini.
finally:
    presentation.dispose()
```

### **Buat Workbook Eksternal**

Dengan menggunakan metode [readWorkbookStream](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#readWorkbookStream) dan [setExternalWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#setExternalWorkbook), Anda dapat membuat workbook eksternal dari awal atau menjadikan workbook internal menjadi eksternal.

Kode Python berikut menunjukkan proses pembuatan workbook eksternal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tetapkan Workbook Eksternal**

Dengan menggunakan metode [setExternalWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#setExternalWorkbook), Anda dapat menetapkan workbook eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke workbook eksternal (jika workbook tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam workbook yang disimpan di lokasi atau sumber daya jarak jauh, Anda masih dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika jalur relatif untuk workbook eksternal diberikan, jalur tersebut secara otomatis dikonversi menjadi jalur penuh.

Kode Python berikut menunjukkan cara menetapkan workbook eksternal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Parameter kedua (`bool`) dari metode [setExternalWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#setExternalWorkbook) digunakan untuk menentukan apakah workbook Excel akan dimuat atau tidak. 
* Ketika nilainya diatur ke `False`, hanya jalur workbook yang diperbarui—data diagram tidak akan dimuat atau diperbarui dari workbook target. Anda mungkin ingin menggunakan pengaturan ini ketika workbook target tidak ada atau tidak tersedia. 
* Ketika nilainya diatur ke `True`, data diagram diperbarui dari workbook target.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dapatkan Jalur Workbook Sumber Data Eksternal dari Diagram**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
2. Dapatkan referensi slide melalui indeksnya.
3. Buat objek untuk bentuk diagram.
4. Buat objek untuk tipe sumber ([ChartDataSourceType](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatasourcetype/)) yang mewakili sumber data diagram.
5. Tentukan kondisi yang relevan berdasarkan tipe sumber yang sama dengan tipe sumber data workbook eksternal.

Kode Python berikut menunjukkan operasi tersebut:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Edit Data Diagram**

Anda dapat mengedit data di workbook eksternal dengan cara yang sama seperti Anda mengubah isi workbook internal. Ketika workbook eksternal tidak dapat dimuat, pengecualian akan dilempar.

Kode Python berikut merupakan implementasi dari proses yang dijelaskan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Pulihkan Workbook dari Cache Diagram**

Jika sebuah diagram menggunakan workbook eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat membangun kembali workbook diagram dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/), konfigurasikan dengan [SpreadsheetOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/spreadsheetoptions/), dan panggil [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/id/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) dengan `True` sebelum membuka presentasi.

Contoh Python berikut membuka presentasi yang diagramnya merujuk ke workbook eksternal yang tidak tersedia dan mengakses data yang dipulihkan melalui [Chart.getChartData](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#getChartData) dan [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Baca atau modifikasi data workbook yang dipulihkan di sini.
finally:
    presentation.dispose()
```

Jika workbook eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika penggunaan data diagram yang di‑cache dapat diterima sebagai alternatif, karena cache mungkin tidak berisi perubahan yang dilakukan pada workbook eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah diagram tertentu terhubung ke workbook eksternal atau yang tertanam?**  
Ya. Sebuah diagram memiliki [jenis sumber data](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getDataSourceType) dan [jalur ke workbook eksternal](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); jika sumbernya adalah workbook eksternal, Anda dapat membaca jalur lengkap untuk memastikan bahwa file eksternal sedang digunakan.

**Apakah jalur relatif ke workbook eksternal didukung, dan bagaimana mereka disimpan?**  
Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Ini memudahkan portabilitas proyek; namun, perlu diketahui bahwa presentasi akan menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) di dalam file PPTX.

**Apakah saya dapat menggunakan workbook yang terletak di sumber daya/sistem berbagi jaringan?**  
Ya, workbook tersebut dapat digunakan sebagai sumber data eksternal. Namun, mengedit workbook jarak jauh secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**  
Tidak. Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak diubah ketika presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**  
Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/python-java/)) dan menautkan ke salinan tersebut.

**Apakah beberapa diagram dapat merujuk ke workbook eksternal yang sama?**  
Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin di setiap diagram pada saat data dimuat berikutnya.