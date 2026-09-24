---
title: Mengelola Buku Kerja Diagram dalam Presentasi Menggunakan Python via Java
linktitle: Buku Kerja Diagram
type: docs
weight: 70
url: /id/python-java/chart-workbook/
keywords:
- buku kerja diagram
- data diagram
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- cache diagram
- pemulihan buku kerja
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Python via Java: kelola buku kerja diagram dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan jenis sumber data untuk nilai diagram.

Artikel ini juga mencakup penggunaan buku kerja eksternal sebagai sumber data diagram. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke diagram, serta mengedit data diagram ketika buku kerja tersedia.

Untuk sel buku kerja yang mewakili data yang hilang, lihat [Control the Display of Empty Cells](/slides/id/python-java/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan diagram garis dari mode tampilan yang tersedia.

## **Baca dan Tulis Data Diagram dari Buku Kerja**

Aspose.Slides menyediakan metode [readWorkbookStream](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#readWorkbookStream) dan [writeWorkbookStream](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#writeWorkbookStream) yang memungkinkan Anda membaca dan menulis buku kerja data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau memiliki struktur yang mirip dengan sumbernya.

Kode Python ini mendemonstrasikan operasi contoh:

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

### **Validasi Tata Letak Diagram Setelah Modifikasi Buku Kerja**

Ketika Anda mengganti buku kerja tertanam dengan yang sudah dimodifikasi, diagram tetap mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [Chart.validateChartLayout](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#validateChartLayout) melempar `ArgumentOutOfRangeException` (parameter: index). Untuk menghindari pengecualian, bersihkan seri dan kategori yang ada **sebelum** menulis kembali buku kerja yang diperbarui ke diagram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Baca buku kerja setelah memodifikasinya (mis., menggunakan Aspose.Cells).
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

Membersihkan koleksi memastikan struktur data diagram selaras dengan buku kerja baru, sehingga [validateChartLayout](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#validateChartLayout) dapat selesai tanpa kesalahan.

## **Atur Sel Buku Kerja sebagai Label Data Diagram**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Dapatkan referensi slide melalui indeksnya.
1. Tambahkan diagram gelembung dengan beberapa data.
1. Akses seri diagram.
1. Atur sel buku kerja sebagai label data.
1. Simpan presentasi.

Kode Python ini menunjukkan cara mengatur sel buku kerja sebagai label data diagram:

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

## **Kelola Lembar Kerja**

Kode Python ini mendemonstrasikan operasi di mana metode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdataworkbook/#getWorksheets) digunakan untuk mengakses koleksi lembar kerja:

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

Kode Python ini menunjukkan cara menentukan jenis untuk sebuah sumber data:

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

## **Deteksi Format Buku Kerja Tertanam yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja biner Excel (.xlsb) yang dapat tertanam di beberapa diagram. Anda dapat menggunakan metode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) pada [ChartData](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/python-java/aspose.slides/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan diagram tersebut.

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
            # Buku kerja tertanam berada dalam format .xlsb, yang tidak didukung.
            continue
        # Baca atau ubah data buku kerja diagram di sini.
finally:
    presentation.dispose()
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung penggunaan buku kerja eksternal sebagai sumber data untuk diagram.

### **Buat Buku Kerja Eksternal**

Dengan menggunakan metode [readWorkbookStream](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#readWorkbookStream) dan [setExternalWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#setExternalWorkbook), Anda dapat membuat buku kerja eksternal dari awal atau menjadikan buku kerja internal menjadi eksternal.

Kode Python ini mendemonstrasikan proses pembuatan buku kerja eksternal:

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

### **Atur Buku Kerja Eksternal**

Dengan menggunakan metode [setExternalWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#setExternalWorkbook), Anda dapat menetapkan buku kerja eksternal ke sebuah diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam buku kerja yang disimpan di lokasi atau sumber daya jauh, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal diberikan, jalur tersebut secara otomatis dikonversi menjadi jalur lengkap.

Kode Python ini menunjukkan cara mengatur buku kerja eksternal:

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

Parameter (`bool`) kedua dari metode [setExternalWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#setExternalWorkbook) digunakan untuk menentukan apakah buku kerja Excel akan dimuat atau tidak.

* Ketika nilainya disetel ke `False`, hanya jalur buku kerja yang diperbarui — data diagram tidak akan dimuat atau diperbarui dari buku kerja target. Anda mungkin ingin menggunakan pengaturan ini ketika buku kerja target tidak ada atau tidak tersedia.
* Ketika nilainya disetel ke `True`, data diagram diperbarui dari buku kerja target.

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

### **Dapatkan Jalur Buku Kerja Sumber Data Eksternal dari Diagram**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Dapatkan referensi slide melalui indeksnya.
1. Buat objek untuk bentuk diagram.
1. Buat objek untuk tipe sumber ([ChartDataSourceType](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdatasourcetype/)) yang mewakili sumber data diagram.
1. Tentukan kondisi yang relevan berdasarkan tipe sumber yang sama dengan tipe sumber data buku kerja eksternal.

Kode Python ini mendemonstrasikan operasi tersebut:

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

Anda dapat mengedit data dalam buku kerja eksternal dengan cara yang sama seperti mengubah isi buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Kode Python ini adalah implementasi proses yang dijelaskan:

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

### **Pulihkan Buku Kerja dari Cache Diagram**

Jika sebuah diagram menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi buku kerja diagram dari data yang disimpan dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/loadoptions/), konfigurasikan dengan [SpreadsheetOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/spreadsheetoptions/), dan panggil [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/id/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) dengan `True` sebelum membuka presentasi.

Contoh Python berikut membuka presentasi yang diagramnya merujuk ke buku kerja eksternal yang tidak tersedia dan mengakses data yang dipulihkan melalui [Chart.getChartData](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/#getChartData) dan [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Baca atau ubah data buku kerja yang dipulihkan di sini.
finally:
    presentation.dispose()
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika penggunaan data diagram yang disimpan dalam cache dapat diterima sebagai alternatif, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir kali diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah diagram tertentu terhubung ke buku kerja eksternal atau tertanam?**

Ya. Sebuah diagram memiliki [jenis sumber data](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getDataSourceType) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana mereka disimpan?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Hal ini memudahkan portabilitas proyek; namun, perlu diketahui bahwa presentasi akan menyimpan jalur absolut dalam file PPTX.

**Apakah saya dapat menggunakan buku kerja yang berada di sumber daya/jaringan bersama?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan buku kerja jauh secara langsung dari Aspose.Slides tidak didukung — mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/id/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak dimodifikasi saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat membuat tautan. Pendekatan umum adalah menghapus perlindungan sebelumnya atau menyiapkan salinan yang sudah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/python-java/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa diagram merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram pada saat berikutnya data dimuat.