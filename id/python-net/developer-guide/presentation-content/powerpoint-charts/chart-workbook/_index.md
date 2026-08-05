---
title: Kelola Buku Kerja Bagan dalam Presentasi dengan Python
linktitle: Buku Kerja Bagan
type: docs
weight: 70
url: /id/python-net/chart-workbook/
keywords:
- buku kerja bagan
- data bagan
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- cache bagan
- pemulihan buku kerja
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Python via .NET: kelola buku kerja bagan secara mudah di format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja bagan di Aspose.Slides. Ini menunjukkan cara membaca dan menulis data bagan melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data bagan, mengakses koleksi lembar kerja, dan menentukan jenis sumber data untuk nilai bagan.

Artikel ini juga mencakup bekerja dengan buku kerja eksternal sebagai sumber data bagan. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mengambil path buku kerja eksternal yang terhubung ke sebuah bagan, dan mengedit data bagan ketika buku kerja tersedia.

## **Membaca dan Menulis Data Bagan dari Buku Kerja**

Aspose.Slides menyediakan metode untuk membaca dan menulis buku kerja data bagan (yang berisi data bagan yang diedit dengan Aspose.Cells). **Catatan:** Data bagan harus diatur dengan cara yang sama atau memiliki struktur yang mirip dengan sumber.

The following Python code demonstrates a sample operation:

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

## **Menetapkan Sel WorkBook sebagai Label Data Bagan**

Kadang-kadang Anda memerlukan label bagan yang diambil langsung dari sel di buku kerja data yang mendasarinya. Aspose.Slides memungkinkan Anda mengikat label data ke sel buku kerja tertentu sehingga teks label selalu mencerminkan nilai sel tersebut. Contoh di bawah ini menunjukkan cara mengaktifkan label nilai-dari-sel dan mengarahkan label yang dipilih ke sel khusus di buku kerja bagan.

1. Buat sebuah instance dari kelas [Presentation](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeks.
3. Tambahkan bagan gelembung dengan data contoh.
4. Akses seri bagan.
5. Gunakan sel buku kerja sebagai label data.
6. Simpan presentasi.

Kode Python berikut menunjukkan cara menetapkan sel buku kerja sebagai label data bagan:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Membuat instance kelas Presentation yang mewakili file presentasi.
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

Kode Python berikut menunjukkan cara menggunakan properti `worksheets` untuk mengakses koleksi worksheet:

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

## **Menentukan Jenis Sumber Data**

Kode Python berikut menunjukkan cara menentukan jenis sumber data:

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

## **Mendeteksi Format Buku Kerja Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja biner Excel (.xlsb) yang dapat tersemat dalam beberapa bagan. Anda dapat menggunakan properti `embedded_workbook_type` pada [ChartData](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan bagan tersebut.

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
            # Buku kerja tersemat berada dalam format .xlsb, yang tidak didukung.
            continue

        # Baca atau ubah data buku kerja bagan di sini.
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung penggunaan buku kerja eksternal sebagai sumber data untuk bagan.

### **Menetapkan Buku Kerja Eksternal**

Dengan menggunakan metode [ChartData.set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/), Anda dapat menetapkan buku kerja eksternal ke sebuah bagan sebagai sumber datanya. Metode ini juga dapat memperbarui path ke buku kerja eksternal jika telah dipindahkan.

Meskipun Anda tidak dapat mengedit data dalam buku kerja yang disimpan di lokasi atau sumber daya jarak jauh, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika Anda memberikan path relatif untuk buku kerja eksternal, path tersebut secara otomatis dikonversi menjadi path lengkap.

Kode Python berikut menunjukkan cara menetapkan buku kerja eksternal:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parameter `update_chart_data` pada metode [set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/) menentukan apakah buku kerja Excel akan dimuat.

- Ketika `update_chart_data` disetel ke `False`, hanya path buku kerja yang diperbarui; data bagan tidak dimuat atau disegarkan dari buku kerja target. Gunakan pengaturan ini ketika buku kerja target tidak ada atau tidak tersedia.
- Ketika `update_chart_data` disetel ke `True`, data bagan dimuat dan diperbarui dari buku kerja target.

### **Membuat Buku Kerja Eksternal**

Dengan menggunakan metode [read_workbook_stream](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan [set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/), Anda dapat membuat buku kerja eksternal dari awal atau mengonversi buku kerja internal menjadi eksternal.

Kode Python berikut mendemonstrasikan proses pembuatan buku kerja eksternal:

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

### **Mendapatkan Path Buku Kerja Sumber Data Eksternal untuk sebuah Bagan**

Kadang-kadang data bagan terhubung ke buku kerja Excel eksternal alih-alih data tersemat dalam presentasi. Dengan Aspose.Slides, Anda dapat memeriksa sumber data bagan dan, jika itu adalah buku kerja eksternal, membaca path lengkap buku kerja tersebut.

1. Buat sebuah instance dari kelas [Presentation](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Dapatkan referensi ke shape bagan.
4. Dapatkan sumber ([ChartDataSourceType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatasourcetype/)) yang mewakili sumber data bagan.
5. Periksa apakah jenis sumber cocok dengan jenis sumber data buku kerja eksternal.

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

### **Mengedit Data Bagan**

Anda dapat mengedit data dalam buku kerja eksternal dengan cara yang sama seperti mengedit data dalam buku kerja internal. Jika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Memulihkan Buku Kerja dari Cache Bagan**

Jika sebuah bagan menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat membangun kembali buku kerja bagan dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/), lalu aktifkan [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/id/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) melalui [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/spreadsheet_options/) sebelum membuka presentasi.

Contoh Python berikut membuka sebuah presentasi yang bagannya merujuk ke buku kerja eksternal yang tidak tersedia dan mengakses data yang dipulihkan melalui [Chart.chart_data](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/chart_data/) dan [ChartData.chart_data_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Baca atau ubah data buku kerja yang dipulihkan di sini.
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika penggunaan data bagan yang di‑cache merupakan alternatif yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah bagan tertentu terhubung ke buku kerja eksternal atau tersemat?**

Ya. Sebuah bagan memiliki [data source type](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/data_source_type/) dan [path to an external workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca path lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah path relatif ke buku kerja eksternal didukung, dan bagaimana mereka disimpan?**

Ya. Jika Anda menentukan path relatif, itu secara otomatis dikonversi menjadi path absolut. Ini memudahkan portabilitas proyek; namun, perlu diingat bahwa presentasi akan menyimpan path absolut dalam file PPTX.

**Apakah saya dapat menggunakan buku kerja yang terletak pada sumber daya/jaringan bersama?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, mengedit buku kerja jarak jauh secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan sebuah [link ke file eksternal](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/external_workbook_path/) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak diubah saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi password?**

Aspose.Slides tidak menerima password saat membuat tautan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/python-net/)) dan menautkan ke salinan tersebut.

**Apakah beberapa bagan dapat merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap bagan menyimpan tautannya masing‑masing. Jika semua mengarah ke file yang sama, memperbarui file tersebut akan tercermin di setiap bagan pada next load data.