---
title: Kelola Buku Kerja Diagram dalam Presentasi dengan Python
linktitle: Buku Kerja Diagram
type: docs
weight: 70
url: /id/python-net/chart-workbook/
keywords:
- buku kerja diagram
- data diagram
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Python via .NET: kelola buku kerja diagram dalam format PowerPoint dan OpenDocument secara mudah untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan jenis sumber data untuk nilai diagram. Artikel ini juga mencakup kerja dengan buku kerja eksternal sebagai sumber data diagram. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke diagram, dan mengedit data diagram ketika buku kerja tersedia.

## **Baca dan Tulis Data Diagram dari Buku Kerja**

Aspose.Slides menyediakan metode untuk membaca dan menulis buku kerja data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan:** Data diagram harus diatur dengan cara yang sama atau memiliki struktur yang mirip dengan sumber.

Kode Python berikut menunjukkan operasi contoh:

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

## **Tetapkan Sel WorkBook sebagai Label Data Diagram**

Kadang-kadang Anda membutuhkan label diagram yang berasal langsung dari sel dalam buku kerja data yang mendasarinya. Aspose.Slides memungkinkan Anda mengaitkan label data ke sel buku kerja tertentu sehingga teks label selalu mencerminkan nilai sel. Contoh di bawah ini menunjukkan cara mengaktifkan label nilai-dari-sel dan mengarahkan label yang dipilih ke sel khusus dalam buku kerja diagram.

1. Buat sebuah instance dari kelas [Presentation](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeks.
3. Tambahkan diagram gelembung dengan data contoh.
4. Akses seri diagram.
5. Gunakan sel buku kerja sebagai label data.
6. Simpan presentasi.

Kode Python berikut menunjukkan cara menetapkan sel buku kerja sebagai label data diagram:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Buat instance kelas Presentation yang mewakili file presentasi.
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

## **Kelola Lembar Kerja**

Kode Python berikut menunjukkan cara menggunakan properti `worksheets` untuk mengakses koleksi lembar kerja:

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

## **Tentukan Jenis Sumber Data**

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

## **Deteksi Format Buku Kerja Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja biner Excel (.xlsb) yang dapat tersemat dalam beberapa diagram. Anda dapat menggunakan properti `embedded_workbook_type` pada [ChartData](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewati diagram tersebut.

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

        # Baca atau modifikasi data buku kerja diagram di sini.
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung penggunaan buku kerja eksternal sebagai sumber data untuk diagram.

### **Tetapkan Buku Kerja Eksternal**

Dengan menggunakan metode [ChartData.set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/), Anda dapat menetapkan buku kerja eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat memperbarui jalur ke buku kerja eksternal jika telah dipindahkan. Meskipun Anda tidak dapat mengedit data dalam buku kerja yang disimpan di lokasi atau sumber daya jarak jauh, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika Anda memberikan jalur relatif untuk buku kerja eksternal, jalur tersebut secara otomatis diubah menjadi jalur lengkap.

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

Parameter `update_chart_data` dari metode [set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/) menentukan apakah buku kerja Excel akan dimuat.
- Ketika `update_chart_data` disetel ke `False`, hanya jalur buku kerja yang diperbarui; data diagram tidak dimuat atau disegarkan dari buku kerja target. Gunakan pengaturan ini ketika buku kerja target tidak ada atau tidak tersedia.
- Ketika `update_chart_data` disetel ke `True`, data diagram dimuat dan diperbarui dari buku kerja target.

### **Buat Buku Kerja Eksternal**

Dengan menggunakan metode [read_workbook_stream](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan [set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/), Anda dapat membuat buku kerja eksternal dari awal atau mengonversi buku kerja internal menjadi eksternal.

Kode Python ini menunjukkan proses pembuatan buku kerja eksternal:

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

### **Dapatkan Jalur Buku Kerja Sumber Data Eksternal untuk Diagram**

Kadang-kadang data diagram terhubung ke buku kerja Excel eksternal bukan ke data tersemat dalam presentasi. Dengan Aspose.Slides, Anda dapat memeriksa sumber data diagram dan, jika itu buku kerja eksternal, membaca jalur lengkap buku kerja tersebut.

1. Buat sebuah instance dari kelas [Presentation](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Dapatkan referensi ke bentuk diagram.
4. Dapatkan sumber ([ChartDataSourceType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatasourcetype/)) yang mewakili sumber data diagram.
5. Periksa apakah jenis sumber cocok dengan jenis sumber data buku kerja eksternal.

Kode Python berikut menunjukkan operasi tersebut:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Edit Data Diagram**

Anda dapat mengedit data dalam buku kerja eksternal dengan cara yang sama seperti mengedit data dalam buku kerja internal. Jika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah diagram tertentu terhubung ke buku kerja eksternal atau tersemat?**

Ya. Diagram memiliki [jenis sumber data](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/data_source_type/) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana mereka disimpan?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis diubah menjadi jalur absolut. Ini memudahkan portabilitas proyek; namun, perlu diketahui bahwa presentasi akan menyimpan jalur absolut dalam file PPTX.

**Apakah saya dapat menggunakan buku kerja yang terletak pada sumber daya/jaringan bersama?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, mengedit buku kerja jarak jauh secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/external_workbook_path/) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak diubah saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan sebelumnya atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/python-net/)) dan menautkan ke salinan tersebut.

**Apakah beberapa diagram dapat merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing-masing. Jika semuanya mengarah ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram saat data dimuat kembali.