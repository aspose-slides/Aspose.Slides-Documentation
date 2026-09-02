---
title: Kelola Workbook Diagram dalam Presentasi dengan Python
linktitle: Workbook Diagram
type: docs
weight: 70
url: /id/python-net/chart-workbook/
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
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Python melalui .NET: kelola workbook diagram dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan workbook diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran workbook, menggunakan sel workbook sebagai label data diagram, mengakses koleksi worksheet, dan menentukan tipe sumber data untuk nilai diagram.

Artikel ini juga membahas penggunaan workbook eksternal sebagai sumber data diagram. Contoh-contoh memperlihatkan cara membuat dan menetapkan workbook eksternal, mengambil jalur workbook eksternal yang terhubung ke diagram, serta mengedit data diagram ketika workbook tersedia.

## **Membaca dan Menulis Data Diagram dari Workbook**

Aspose.Slides menyediakan metode untuk membaca dan menulis workbook data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan:** Data diagram harus diatur dengan cara yang sama atau memiliki struktur yang mirip dengan sumber.

Kode Python berikut mendemonstrasikan operasi contoh:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **Validasi Tata Letak Diagram Setelah Modifikasi Workbook**

Saat Anda mengganti workbook yang disematkan dengan workbook yang dimodifikasi, diagram tetap mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [IChart.validate_chart_layout](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichart/validate_chart_layout/) gagal dengan error indeks di luar jangkauan. Hapus seri dan kategori yang ada sebelum menulis workbook yang diperbarui kembali ke diagram.

```python
# Setelah memodifikasi aliran workbook (misalnya menggunakan Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Hapus referensi data yang ada.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Mengosongkan koleksi memastikan bahwa struktur data diagram konsisten dengan workbook baru, sehingga `validate_chart_layout` dapat selesai tanpa error.

## **Menetapkan Sel Workbook sebagai Label Data Diagram**

Terkadang Anda memerlukan label diagram yang berasal langsung dari sel di workbook data yang mendasarinya. Aspose.Slides memungkinkan Anda mengikat label data ke sel workbook tertentu sehingga teks label selalu mencerminkan nilai sel. Contoh di bawah menunjukkan cara mengaktifkan label nilai-dari-sel dan mengarahkan label yang dipilih ke sel khusus di workbook diagram.

1. Buat instance kelas [Presentation](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeks.
3. Tambahkan diagram gelembung dengan data contoh.
4. Akses seri diagram.
5. Gunakan sel workbook sebagai label data.
6. Simpan presentasi.

Kode Python berikut menunjukkan cara menetapkan sel workbook sebagai label data diagram:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instansiasi kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengelola Worksheet**

Kode Python berikut mendemonstrasikan cara menggunakan properti `worksheets` untuk mengakses koleksi worksheet:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Menentukan Tipe Sumber Data**

Kode Python berikut menunjukkan cara menentukan tipe sumber data:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Mendeteksi Format Workbook Tertanam yang Tidak Didukung**

Aspose.Slides tidak mendukung format workbook Excel biner (.xlsb) yang dapat tertanam di beberapa diagram. Anda dapat menggunakan properti `embedded_workbook_type` pada [ChartData](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/) bersama enumerasi [WorkbookType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan diagram tersebut.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # Workbook tertanam dalam format .xlsb, yang tidak didukung.
            continue

        # Baca atau ubah data workbook diagram di sini.
```

## **Workbook Eksternal**

Aspose.Slides mendukung penggunaan workbook eksternal sebagai sumber data untuk diagram.

### **Menetapkan Workbook Eksternal**

Dengan menggunakan metode [ChartData.set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/), Anda dapat menetapkan workbook eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat memperbarui jalur ke workbook eksternal jika telah dipindahkan.

Meskipun Anda tidak dapat mengedit data di workbook yang disimpan di lokasi atau sumber daya remote, Anda tetap dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika Anda memberikan jalur relatif untuk workbook eksternal, jalur tersebut secara otomatis dikonversi menjadi jalur lengkap.

Kode Python berikut menunjukkan cara menetapkan workbook eksternal:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Berikan False sehingga hanya jalur yang disimpan: workbook target tidak perlu ada dulu.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parameter `update_chart_data` pada metode [set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/) menentukan apakah workbook Excel akan dimuat.

- Ketika `update_chart_data` disetel ke `False`, hanya jalur workbook yang diperbarui; data diagram tidak dimuat atau disegarkan dari workbook target. Gunakan pengaturan ini ketika workbook target tidak ada atau tidak tersedia.
- Ketika `update_chart_data` disetel ke `True` (nilai default), data diagram dimuat dan diperbarui dari workbook target. Jika workbook tersebut tidak dapat dibuka, akan dilemparkan pengecualian dengan pesan "External workbook is not available".

### **Membuat Workbook Eksternal**

Dengan menggunakan metode [read_workbook_stream](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan [set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/), Anda dapat membuat workbook eksternal dari awal atau mengonversi workbook internal menjadi eksternal.

Kode Python ini mendemonstrasikan proses pembuatan workbook eksternal:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Mengambil Jalur Workbook Sumber Data Eksternal untuk Diagram**

Terkadang data diagram terhubung ke workbook Excel eksternal alih-alih data tertanam dalam presentasi. Dengan Aspose.Slides, Anda dapat memeriksa sumber data diagram dan, jika itu adalah workbook eksternal, membaca jalur lengkap workbook tersebut.

1. Buat instance kelas [Presentation](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Dapatkan referensi ke shape diagram.
4. Peroleh sumber ([ChartDataSourceType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatasourcetype/)) yang mewakili sumber data diagram.
5. Periksa apakah tipe sumber cocok dengan tipe sumber workbook eksternal.

Kode Python berikut mendemonstrasikan operasi tersebut:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Mengedit Data Diagram**

Anda dapat mengedit data di workbook eksternal dengan cara yang sama seperti mengedit data di workbook internal. Jika workbook eksternal tidak dapat dimuat, pengecualian akan dilemparkan.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Memulihkan Workbook dari Cache Diagram**

Jika sebuah diagram menggunakan workbook eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat membangun kembali workbook diagram dari data yang di-cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/), lalu aktifkan [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) melalui [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/spreadsheet_options/) sebelum membuka presentasi.

Contoh Python berikut membuka presentasi yang diagramnya merujuk ke workbook eksternal yang tidak tersedia dan mengakses data yang dipulihkan melalui [Chart.chart_data](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/chart_data/) dan [ChartData.chart_data_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Baca atau ubah data workbook yang dipulihkan di sini.
```

Jika workbook eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melemparkan pengecualian. Aktifkan pemulihan hanya ketika menggunakan data diagram yang di-cache dapat diterima sebagai alternatif, karena cache mungkin tidak berisi perubahan yang dibuat pada workbook eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah diagram tertentu terhubung ke workbook eksternal atau tertanam?**

Ya. Diagram memiliki [data source type](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/data_source_type/) dan [path to an external workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jika sumbernya adalah workbook eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke workbook eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Ini memudahkan portabilitas proyek; namun, perlu diketahui bahwa presentasi akan menyimpan jalur absolut dalam file PPTX.

**Dapatkah saya menggunakan workbook yang terletak di sumber daya/jaringan bersama?**

Ya, workbook tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan workbook remote secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Hanya jika Anda mengedit data diagram. Presentasi menyimpan [link to the external file](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/external_workbook_path/) dan menggunakannya untuk membaca data, sehingga membuka dan menyimpan presentasi tidak mengubah workbook. Namun, nilai yang Anda ubah melalui data diagram (lihat **Edit Chart Data** di atas) akan ditulis kembali ke workbook eksternal saat presentasi disimpan—kerjakan pada salinan jika file asli harus tetap utuh.

**Bagaimana jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat membuat tautan. Pendekatan umum adalah menghapus proteksi sebelumnya atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/python-net/)) dan menautkan ke salinan tersebut.

**Apakah beberapa diagram dapat merujuk ke workbook eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing-masing. Jika semuanya mengarah ke file yang sama, pembaruan file tersebut akan tercermin pada masing‑masing diagram ketika data dimuat kembali.