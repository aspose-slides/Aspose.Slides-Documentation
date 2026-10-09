---
title: Mengelola Buku Kerja Diagram dalam Presentasi dengan Python
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
- cache diagram
- pemulihan buku kerja
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Python via .NET: kelola buku kerja diagram dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Ini menunjukkan cara membaca dan menulis data diagram melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan jenis sumber data untuk nilai diagram.

Artikel ini juga mencakup cara bekerja dengan buku kerja eksternal sebagai sumber data diagram. Contohnya memperlihatkan cara membuat dan menetapkan buku kerja eksternal, mengambil path buku kerja eksternal yang terhubung ke diagram, dan mengedit data diagram ketika buku kerja tersedia.

Untuk sel buku kerja yang mewakili data yang hilang, lihat [Mengontrol Tampilan Sel Kosong](/slides/id/python-net/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan diagram garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) untuk mengontrol apakah diagram memplot data dari baris dan kolom lembar kerja yang tersembunyi. Atur ke `True` untuk memplot hanya sel yang terlihat, atau `False` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemetaan diagram; tidak menyembunyikan atau menampilkan kembali baris atau kolom lembar kerja.

[Presentasi contoh](hidden-source-data.pptx) berisi diagram kolom sebagai bentuk pertama pada slide pertama. Lembar kerja tertanam, `Sheet1`, berisi rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C tersembunyi, tetapi sel‑selnya masih berisi nilai.

| Baris Lembar Kerja | A: Bulan | B: Ritel | C: Grosir (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (baris tersembunyi) | Februari | 40 | 60 |
| 4 | Maret | 20 | 50 |

Akses sel sumber melalui [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) dan baca [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) untuk memeriksa status tersembunyi mereka. Properti ini hanya dapat dibaca. Pada file ini, B2 terlihat, B3 termasuk dalam baris tersembunyi, dan C2 termasuk dalam kolom tersembunyi; contoh mencetak `False`, `True`, dan `True` secara berurutan.

Untuk contoh ini, segarkan data diagram setelah mengubah pengaturan plotting: pertahankan buku kerja tertanam dengan [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan muat kembali dengan [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Saat menyertakan semua sel, gunakan juga [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) untuk memulihkan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk menyegarkan data diagram dan label kategori yang di‑cache dalam contoh ini.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Segarkan data diagram dari buku kerja yang tertanam.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Pulihkan rentang sumber lengkap, termasuk kategori tersembunyi.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Contoh menyimpan dua versi presentasi: satu dengan hanya nilai Ritel yang terlihat (10 dan 20), dan satu lagi dengan semua enam nilai. Gambar di bawah dirender dari presentasi yang disimpan setelah dibuka kembali; kedua file mempertahankan pengaturan plotting yang ditetapkan. Baris 3 dan kolom C tetap tersembunyi di kedua buku kerja tertanam.

| Hanya sel terlihat (`True`) | Semua sel (`False`) |
| --- | --- |
| ![Hanya sel terlihat: nilai Ritel 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Ritel dan Grosir untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sel tersembunyi yang berisi nilai berbeda dari sel kosong. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) mengontrol bagaimana nilai yang hilang ditampilkan; tidak menambahkan atau mengecualikan data sumber yang tersembunyi. Lihat [Mengontrol Tampilan Sel Kosong](/slides/id/python-net/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Dapatkan Rentang Data Diagram**

Sebelum memperbarui data buku kerja dalam presentasi yang ada, periksa rentang sumber untuk mengidentifikasi sel lembar kerja mana yang digunakan setiap diagram. Metode [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) mengembalikan rentang data saat ini sebagai formula yang memenuhi syarat lembar kerja, seperti `Sheet1!$A$1:$D$5`. Di sini, `Sheet1` adalah nama lembar kerja, `!` memisahkannya dari rentang sel, dan `$A$1:$D$5` mengidentifikasi sel A1 sampai D5, inklusif. Tanda dolar menunjukkan referensi baris dan kolom absolut.

Metode ini membaca rentang saat ini tanpa mengubah diagram atau buku kerjanya. Jika diagram tidak menggunakan buku kerja sebagai sumber datanya, metode ini akan melemparkan eksepsi. Untuk informasi lebih lanjut, lihat [Referensi API ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Contoh ini membuka presentasi dan memeriksa bentuk‑bentuk langsung pada setiap slide untuk diagram. Ia mencetak nama setiap diagram dan rentang sumbernya. Jika rentang tidak dapat diambil, ia mencetak pesan diagnostik dan melanjutkan ke diagram berikutnya.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Baca dan Tulis Data Diagram dari Buku Kerja**

Aspose.Slides for Python via .NET menyediakan metode [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) yang memungkinkan Anda membaca dan menulis buku kerja data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diorganisir dengan cara yang sama atau harus memiliki struktur yang mirip dengan sumbernya.

Contoh ini menggunakan presentasi dengan diagram sebagai bentuk pertama pada slide pertama. Ia membaca buku kerja tertanam ke dalam aliran, menghapus seri dan kategori yang ada, dan menulis kembali buku kerja yang sama. Perubahan tetap berada di memori; contoh tidak menyimpan presentasi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Validasi Tata Letak Diagram Setelah Modifikasi Buku Kerja**

Ketika Anda mengganti buku kerja tertanam dengan yang telah dimodifikasi, diagram tetap mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) gagal dengan kesalahan indeks keluar‑batas. Hapus seri dan kategori yang ada sebelum menulis kembali buku kerja yang diperbarui ke diagram. Contoh ini menggunakan diagram yang merupakan bentuk pertama pada slide pertama. Komentar menandai tempat pengeditan buku kerja akan terjadi; contoh yang dapat dijalankan menulis kembali buku kerja asli dan memvalidasi tata letak di memori.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Modifikasi aliran buku kerja di sini, misalnya, menggunakan Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Menghapus koleksi menghilangkan referensi data usang sebelum buku kerja ditulis kembali. Bangun kembali pemetaan seri dan kategori yang diperlukan untuk buku kerja yang diperbarui sebelum menggunakan diagram.

## **Setel Sel Buku Kerja sebagai Label Data Diagram**

Anda dapat menggunakan teks dari sel buku kerja sebagai label data diagram.

Contoh ini menambahkan diagram gelembung dengan data default ke slide pertama presentasi yang ada. Ia menggunakan sel A10:A12 pada lembar kerja 0 untuk tiga label pertama dalam seri pertama, mengaktifkan label dari sel, dan menyimpan presentasi yang diperbarui.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Kelola Lembar Kerja**

Properti [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) menyediakan akses ke lembar kerja dalam buku kerja diagram. Contoh ini membuat diagram pai dengan data default dan mencetak setiap nama lembar kerja ke konsol.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Tentukan Jenis Sumber Data**

Contoh ini membuat diagram kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; nama kedua menggunakan sel C1 pada lembar kerja 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) memilih sumber untuk setiap nama. Contoh menyimpan presentasi dengan nama seri yang diperbarui.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Deteksi Format Buku Kerja Tertanam yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja Excel biner (.xlsb) yang dapat tertanam dalam beberapa diagram. Anda dapat menggunakan properti [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) pada [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan diagram‑diagram tersebut. Contoh ini memeriksa bentuk‑bentuk pada slide pertama presentasi yang ada, melewatkan bentuk yang bukan diagram, dan mencetak pesan diagnostik untuk setiap diagram dengan buku kerja .xlsb tertanam.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Baca atau ubah data buku kerja diagram yang didukung di sini.
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung penggunaan buku kerja eksternal sebagai sumber data untuk diagram.

### **Buat Buku Kerja Eksternal**

Gunakan [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) untuk mengekspor buku kerja diagram tertanam ke sebuah file dan menautkan diagram ke buku kerja eksternal tersebut.

Contoh ini membuat diagram pai dengan data default dan mengekspor buku kerjanya. Ia menutup aliran output sebelum menetapkan buku kerja eksternal sebagai sumber data diagram, kemudian menyimpan presentasi yang ditautkan.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Setel Buku Kerja Eksternal**

Dengan menggunakan metode [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), Anda dapat menetapkan buku kerja eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui path ke buku kerja eksternal (jika buku kerja tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam buku kerja yang disimpan di lokasi atau sumber daya remote, Anda masih dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika path relatif untuk buku kerja eksternal diberikan, secara otomatis akan dikonversi menjadi path lengkap.

Contoh ini menggunakan buku kerja eksternal yang lembar kerjanya bernama `Sheet1` berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh membuat diagram pai, menautkan buku kerja, dan menggunakan [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Ia menyimpan presentasi dengan diagram yang ditautkan.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

Parameter `update_chart_data` pada [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) mengontrol apakah buku kerja dimuat.

* Ketika `update_chart_data` bernilai `False`, hanya path buku kerja yang diperbarui. Data diagram tidak dimuat atau diperbarui dari buku kerja target, sehingga buku kerja dapat tidak tersedia.
* Ketika `update_chart_data` bernilai `True`, data diagram diperbarui dari buku kerja target.

Contoh berikut menetapkan URL placeholder dengan `update_chart_data` diset ke `False`. Ia mempertahankan data default diagram pai dan menyimpan presentasi tanpa memuat buku kerja yang tidak tersedia.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Dapatkan Path Buku Kerja Sumber Data Eksternal dari Diagram**

Untuk mengidentifikasi buku kerja yang ditautkan ke diagram, periksa apakah diagram menggunakan sumber data eksternal dan ambil path buku kerjanya.

Contoh ini memeriksa bentuk pertama pada slide pertama presentasi dengan buku kerja eksternal yang ditautkan. Jika itu adalah diagram yang terhubung ke buku kerja eksternal, contoh mencetak [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ke konsol. Kemudian ia menyimpan salinan presentasi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Edit Data Diagram**

Anda dapat mengedit data dalam buku kerja eksternal dengan cara yang sama seperti mengubah isi buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, sebuah eksepsi akan dilemparkan.

Contoh ini menggunakan diagram yang merupakan bentuk pertama pada slide pertama dan terhubung ke buku kerja eksternal yang dapat diakses. Ia menetapkan nilai berbasis sel untuk titik data pertama dalam seri pertama menjadi 100 dan menyimpan presentasi yang diperbarui. Mengedit nilai sel dapat memperbarui file XLSX eksternal yang ditautkan, jadi gunakan salinan jika Anda perlu mempertahankan buku kerja asli.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Pulihkan Buku Kerja dari Cache Diagram**

Jika diagram menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat membangun kembali buku kerja diagram dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), konfigurasikan [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), dan setel [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) ke `True` sebelum membuka presentasi.

Contoh Python berikut memulihkan data buku kerja untuk diagram yang merupakan bentuk pertama pada slide pertama dan merujuk ke buku kerja eksternal yang tidak tersedia. Ia mengakses data yang dipulihkan melalui [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) dan [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Baca atau ubah data workbook yang dipulihkan di sini.
    else:
        print("The first shape is not a chart.")
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melemparkan eksepsi. Aktifkan pemulihan hanya ketika menggunakan data diagram yang di‑cache merupakan alternatif yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir kali diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah diagram tertentu terhubung ke buku kerja eksternal atau tertanam?**

Ya. Diagram memiliki [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) dan [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca path lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah path relatif ke buku kerja eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan path relatif, secara otomatis akan dikonversi menjadi path absolut. Presentasi menyimpan path absolut dalam file PPTX, sehingga memindahkan buku kerja mungkin memerlukan pembaruan tautan.

**Dapatkah saya menggunakan buku kerja yang berada di sumber daya/jaringan bersama?**

Ya, buku kerja semacam itu dapat digunakan sebagai sumber data eksternal. Namun, mengedit buku kerja remote secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [link ke file eksternal](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Mengedit data diagram berbasis sel juga dapat memperbarui file XLSX lokal yang ditautkan. Gunakan salinan buku kerja jika yang asli harus tetap tidak berubah.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus proteksi terlebih dahulu atau menyiapkan salinan yang didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa diagram merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin di setiap diagram pada saat data dimuat selanjutnya.