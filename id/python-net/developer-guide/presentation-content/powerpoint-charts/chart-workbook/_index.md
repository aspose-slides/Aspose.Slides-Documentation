---
title: Kelola Buku Kerja Grafik dalam Presentasi dengan Python
linktitle: Buku Kerja Grafik
type: docs
weight: 70
url: /id/python-net/chart-workbook/
keywords:
- buku kerja grafik
- data grafik
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- cache grafik
- pemulihan buku kerja
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Python via .NET: kelola buku kerja grafik dalam format PowerPoint dan OpenDocument dengan mudah untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja grafik di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data grafik melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data grafik, mengakses koleksi lembar kerja, dan menentukan jenis sumber data untuk nilai grafik.

Artikel ini juga mencakup kerja dengan buku kerja eksternal sebagai sumber data grafik. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke grafik, dan mengedit data grafik ketika buku kerja tersedia.

Untuk sel buku kerja yang mewakili data yang hilang, lihat [Kontrol Tampilan Sel Kosong](/slides/id/python-net/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan grafik garis dari mode tampilan yang tersedia.

## **Baca dan Tulis Data Grafik dari Buku Kerja**

Aspose.Slides menyediakan metode untuk membaca dan menulis buku kerja data grafik (yang berisi data grafik yang diedit dengan Aspose.Cells). **Catatan:** Data grafik harus diatur dengan cara yang sama atau memiliki struktur serupa dengan sumbernya.

Kode Python berikut menunjukkan contoh operasi:

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

### **Validasi Tata Letak Grafik Setelah Modifikasi Buku Kerja**

Saat Anda mengganti buku kerja tersemat dengan yang telah dimodifikasi, grafik akan mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [IChart.validate_chart_layout](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/ichart/validate_chart_layout/) gagal dengan kesalahan indeks di luar jangkauan. Bersihkan seri dan kategori yang ada sebelum menulis kembali buku kerja yang diperbarui ke grafik.

```python
# Setelah memodifikasi aliran buku kerja (mis., menggunakan Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Hapus referensi data yang ada.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Membersihkan koleksi memastikan bahwa struktur data grafik konsisten dengan buku kerja baru, sehingga `validate_chart_layout` dapat selesai tanpa error.

## **Tetapkan Sel Buku Kerja sebagai Label Data Grafik**

Terkadang Anda memerlukan label grafik yang berasal langsung dari sel di buku kerja data yang mendasarinya. Aspose.Slides memungkinkan Anda mengikat label data ke sel buku kerja tertentu sehingga teks label selalu mencerminkan nilai sel. Contoh di bawah ini menunjukkan cara mengaktifkan label nilai-dari-sel dan menunjuk label yang dipilih ke sel kustom dalam buku kerja grafik.

1. Buat instance kelas [Presentation](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeks.
1. Tambahkan grafik gelembung dengan data contoh.
1. Akses seri grafik.
1. Gunakan sel buku kerja sebagai label data.
1. Simpan presentasi.

Kode Python berikut menunjukkan cara menetapkan sel buku kerja sebagai label data grafik:

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

Aspose.Slides tidak mendukung format buku kerja biner Excel (.xlsb) yang dapat tersemat dalam beberapa grafik. Anda dapat menggunakan properti `embedded_workbook_type` pada [ChartData](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/) bersama enumerasi [WorkbookType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan grafik tersebut.

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

        # Baca atau ubah data buku kerja grafik di sini.
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung penggunaan buku kerja eksternal sebagai sumber data untuk grafik.

### **Tetapkan Buku Kerja Eksternal**

Dengan menggunakan metode [ChartData.set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/), Anda dapat menetapkan buku kerja eksternal ke grafik sebagai sumber datanya. Metode ini juga dapat memperbarui jalur ke buku kerja eksternal jika buku kerja dipindahkan.

Meskipun Anda tidak dapat mengedit data di buku kerja yang disimpan di lokasi atau sumber daya jarak jauh, Anda masih dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika Anda memberikan jalur relatif untuk buku kerja eksternal, jalur tersebut secara otomatis dikonversi menjadi jalur lengkap.

Kode Python berikut menunjukkan cara menetapkan buku kerja eksternal:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Berikan False sehingga hanya jalur yang disimpan: buku kerja target tidak perlu ada terlebih dahulu.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parameter `update_chart_data` pada metode [set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/) menentukan apakah buku kerja Excel akan dimuat.

- Ketika `update_chart_data` diatur ke `False`, hanya jalur buku kerja yang diperbarui; data grafik tidak dimuat atau disegarkan dari buku kerja target. Gunakan pengaturan ini ketika buku kerja target tidak ada atau tidak tersedia.
- Ketika `update_chart_data` diatur ke `True` (bawaan), data grafik dimuat dan diperbarui dari buku kerja target. Jika buku kerja tersebut tidak dapat dibuka, akan muncul pengecualian dengan pesan "External workbook is not available".

### **Buat Buku Kerja Eksternal**

Dengan menggunakan metode [read_workbook_stream](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan [set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/), Anda dapat membuat buku kerja eksternal dari awal atau mengonversi buku kerja internal menjadi eksternal.

Kode Python ini mendemonstrasikan proses pembuatan buku kerja eksternal:

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

### **Dapatkan Jalur Buku Kerja Sumber Data Eksternal untuk Grafik**

Terkadang data grafik terhubung ke buku kerja Excel eksternal alih-alih data tersemat presentasi. Dengan Aspose.Slides, Anda dapat memeriksa sumber data grafik dan, jika itu adalah buku kerja eksternal, membaca jalur lengkap buku kerja tersebut.

1. Buat instance kelas [Presentation](https://docs.aspose.com/slides/id/python-net/api-reference/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Dapatkan referensi ke bentuk grafik.
1. Peroleh sumber ([ChartDataSourceType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatasourcetype/)) yang mewakili sumber data grafik.
1. Periksa apakah jenis sumber cocok dengan jenis sumber buku kerja eksternal.

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

### **Edit Data Grafik**

Anda dapat mengedit data di buku kerja eksternal dengan cara yang sama seperti mengedit data di buku kerja internal. Jika buku kerja eksternal tidak dapat dimuat, akan muncul pengecualian.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Pulihkan Buku Kerja dari Cache Grafik**

Jika sebuah grafik menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi buku kerja grafik dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/), lalu aktifkan [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/id/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) melalui [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/spreadsheet_options/) sebelum membuka presentasi.

Contoh Python berikut membuka presentasi yang grafiknya merujuk ke buku kerja eksternal yang tidak tersedia dan mengakses data yang dipulihkan melalui [Chart.chart_data](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/chart_data/) dan [ChartData.chart_data_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Baca atau ubah data buku kerja yang dipulihkan di sini.
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan menghasilkan pengecualian. Aktifkan pemulihan hanya ketika penggunaan data grafik yang di‑cache merupakan solusi cadangan yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah grafik tertentu terhubung ke buku kerja eksternal atau tersemat?**

Ya. Grafik memiliki [data source type](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/data_source_type/) dan [path to an external workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Hal ini memudahkan portabilitas proyek; namun, perlu diketahui bahwa presentasi akan menyimpan jalur absolut dalam file PPTX.

**Bisakah saya menggunakan buku kerja yang berada di sumber daya/jaringan bersama?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan langsung buku kerja jarak jauh melalui Aspose.Slides tidak didukung—buku kerja hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Hanya jika Anda mengedit data grafik. Presentasi menyimpan [link to the external file](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/external_workbook_path/) dan menggunakannya untuk membaca data, sehingga membuka dan menyimpan presentasi tidak mengubah buku kerja. Namun, nilai yang Anda ubah melalui data grafik (lihat [Edit Chart Data](#edit-chart-data) di atas) akan ditulis kembali ke buku kerja eksternal saat presentasi disimpan—kerjakan pada salinan jika file asli harus tetap tidak berubah.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat melakukan penautan. Pendekatan umum adalah menghapus perlindungan sebelumnya atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/python-net/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa grafik merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap grafik menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin di setiap grafik pada pemuatan data berikutnya.