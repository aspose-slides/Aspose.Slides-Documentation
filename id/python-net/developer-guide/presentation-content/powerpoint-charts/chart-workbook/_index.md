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
description: "Temukan Aspose.Slides untuk Python via .NET: kelola buku kerja bagan dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja bagan di Aspose.Slides. Ini menunjukkan cara membaca dan menulis data bagan melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data bagan, mengakses koleksi lembar kerja, dan menentukan tipe sumber data untuk nilai bagan.

Ini juga mencakup cara bekerja dengan buku kerja eksternal sebagai sumber data bagan. Contoh-contoh memperlihatkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke bagan, dan menyunting data bagan ketika buku kerja tersedia.

Untuk sel buku kerja yang mewakili data yang hilang, lihat [Kontrol Penampilan Sel Kosong](/slides/id/python-net/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan diagram garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) untuk mengatur apakah bagan memplot data dari baris dan kolom lembar kerja yang tersembunyi. Atur menjadi `True` untuk memplot hanya sel yang terlihat, atau `False` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemplotan bagan; tidak menyembunyikan atau menampilkan baris atau kolom lembar kerja.

Unduh [hidden-source-data.pptx](hidden-source-data.pptx) dan letakkan di direktori kerja. Slide pertama berisi diagram kolom sebagai bentuk pertama. Lembar kerja tertanam, `Sheet1`, berisi rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C disembunyikan, tetapi sel‑selnya masih berisi nilai.

| Baris Lembar Kerja | A: Bulan | B: Ritel | C: Grosir (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (baris tersembunyi) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Akses sel sumber melalui [ChartData.chart_data_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) dan baca [ChartDataCell.is_hidden](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatacell/is_hidden/) untuk memeriksa status tersembunyi mereka. Properti ini hanya dapat dibaca. Dalam file ini, B2 terlihat, B3 termasuk dalam baris tersembunyi, dan C2 termasuk dalam kolom tersembunyi; contoh mencetak `False`, `True`, dan `True` secara berurutan.

Untuk contoh ini, segarkan data bagan setelah mengubah pengaturan pemplotan: pertahankan buku kerja tertanam dengan [read_workbook_stream](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan muat ulang dengan [write_workbook_stream](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Saat menyertakan semua sel, juga gunakan [set_range](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_range/) untuk mengembalikan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk menyegarkan data bagan yang di‑cache dalam contoh ini dan label kategori.

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

            # Segarkan data bagan dari buku kerja yang tertanam.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Pulihkan rentang sumber lengkap, termasuk kategori tersembunyi.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Contoh menyimpan `hidden_cells_True.pptx` hanya dengan nilai Ritel yang terlihat (10 dan 20), dan `hidden_cells_False.pptx` dengan semua enam nilai. Gambar di bawah dihasilkan dari presentasi yang disimpan setelah dibuka kembali; kedua file mempertahankan pengaturan pemplotan yang ditetapkan. Baris 3 dan kolom C tetap tersembunyi di kedua buku kerja tertanam.

| Hanya sel terlihat (`True`) | Semua sel (`False`) |
| --- | --- |
| ![Hanya sel terlihat: nilai Ritel 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Ritel dan Grosir untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sel tersembunyi yang berisi nilai berbeda dari sel kosong. [Chart.display_blanks_as](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/display_blanks_as/) mengontrol cara nilai yang hilang ditampilkan; tidak menambah atau mengeluarkan data sumber yang tersembunyi. Lihat [Kontrol Penampilan Sel Kosong](/slides/id/python-net/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Baca dan Tulis Data Bagan dari Buku Kerja**

Aspose.Slides for Python via .NET menyediakan metode [read_workbook_stream](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan [write_workbook_stream](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) yang memungkinkan Anda membaca dan menulis buku kerja data bagan (yang berisi data bagan yang disunting dengan Aspose.Cells). **Catatan** bahwa data bagan harus diatur dengan cara yang sama atau memiliki struktur serupa dengan sumbernya.

Contoh ini membuka `chart.pptx`, yang harus berisi bagan sebagai bentuk pertama pada slide pertama. Ia membaca buku kerja tertanam ke dalam aliran, mengosongkan seri dan kategori yang ada, dan menulis buku kerja yang sama kembali. Perubahan tetap berada di memori; contoh tidak menyimpan presentasi.

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

### **Validasi Tata Letak Bagan Setelah Modifikasi Buku Kerja**

Saat Anda mengganti buku kerja tertanam dengan yang telah dimodifikasi, bagan tetap mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [Chart.validate_chart_layout](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/validate_chart_layout/) gagal dengan kesalahan indeks di luar jangkauan. Kosongkan seri dan kategori yang ada sebelum menulis buku kerja yang diperbarui kembali ke bagan. Contoh ini memerlukan `chart.pptx` dengan bagan sebagai bentuk pertama pada slide pertama. Komentar menandai tempat penyuntingan buku kerja; contoh yang dapat dijalankan menulis buku kerja asli kembali dan memvalidasi tata letak di memori.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Ubah aliran buku kerja di sini, misalnya, menggunakan Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Mengosongkan koleksi menghilangkan referensi data lama sebelum buku kerja ditulis kembali. Bangun kembali pemetaan seri dan kategori yang diperlukan untuk buku kerja yang diperbarui sebelum menggunakan bagan.

## **Atur Sel Buku Kerja sebagai Label Data Bagan**

Anda dapat menggunakan teks dari sel buku kerja sebagai label data bagan. Langkah‑langkah berikut menunjukkan cara menautkan label dalam bagan gelembung ke sel dalam buku kerja datanya.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
2. Akses slide pertama berdasarkan indeks berbasis nol.
3. Tambahkan bagan gelembung dengan data default.
4. Akses seri bagan.
5. Atur sel buku kerja sebagai label data.
6. Simpan presentasi.

Contoh ini membuka `chart2.pptx`, yang harus berisi setidaknya satu slide, dan menambahkan bagan gelembung dengan data default. Ia menggunakan sel A10:A12 pada lembar kerja 0 untuk tiga label pertama dalam seri pertama, mengaktifkan label dari sel, dan menyimpan hasilnya ke `resultchart.pptx`.

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

Properti [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) menyediakan akses ke lembar kerja dalam buku kerja bagan. Contoh ini membuat bagan pai dengan data default dan mencetak setiap nama lembar kerja ke konsol.

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

## **Tentukan Tipe Sumber Data**

Contoh ini membuat bagan kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; nama kedua menggunakan sel C1 pada lembar kerja 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datasourcetype/) memilih sumber untuk masing‑masing nama. Hasil disimpan ke `pres.pptx`.

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

Aspose.Slides tidak mendukung format buku kerja Excel biner (.xlsb) yang dapat tertanam dalam beberapa bagan. Anda dapat menggunakan properti [embedded_workbook_type](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) pada [ChartData](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewati bagan‑bagan tersebut. Contoh ini memeriksa bentuk‑bentuk pada slide pertama `sample.pptx`, melewati bentuk yang bukan bagan, dan mencetak pesan diagnostik untuk setiap bagan dengan buku kerja .xlsb tertanam.

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

        # Baca atau ubah data buku kerja bagan yang didukung di sini.
```

## **Buku Kerja Eksternal**

Aspose.Slides mendukung penggunaan buku kerja eksternal sebagai sumber data untuk bagan.

### **Buat Buku Kerja Eksternal**

Gunakan [read_workbook_stream](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan [set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/) untuk mengekspor buku kerja bagan tertanam ke file dan menautkan bagan ke buku kerja eksternal tersebut.

Contoh ini membuat bagan pai dengan data default, menulis buku kerjanya ke `externalWorkbook1.xlsx`, dan menutup aliran output sebelum menetapkan file sebagai sumber data bagan. Ia menyimpan presentasi yang ditautkan ke `externalWorkbook.pptx`.

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

### **Atur Buku Kerja Eksternal**

Dengan metode [set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/), Anda dapat menetapkan buku kerja eksternal ke bagan sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut telah dipindahkan).

Meskipun Anda tidak dapat menyunting data dalam buku kerja yang disimpan di lokasi remote atau sumber daya, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal diberikan, jalur tersebut secara otomatis diubah menjadi jalur lengkap.

Contoh ini memerlukan `externalWorkbook.xlsx` di direktori kerja. Lembar kerja bernama `Sheet1` harus berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh membuat bagan pai, menautkan buku kerja, dan menggunakan [set_range](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_range/) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Hasil disimpan ke `Presentation_with_externalWorkbook.pptx`.

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

Parameter `update_chart_data` pada metode [set_external_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/set_external_workbook/) mengontrol apakah buku kerja dimuat.

* Ketika `update_chart_data` bernilai `False`, hanya jalur buku kerja yang diperbarui. Data bagan tidak dimuat atau diperbarui dari buku kerja target, sehingga buku kerja dapat tidak tersedia.
* Ketika `update_chart_data` bernilai `True`, data bagan diperbarui dari buku kerja target.

Contoh berikut menetapkan URL placeholder dengan `update_chart_data` disetel ke `False`. Ia mempertahankan data default bagan pai dan menyimpan presentasi tanpa memuat buku kerja yang tidak tersedia.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Dapatkan Jalur Buku Kerja Sumber Data Eksternal dari Bagan**

Untuk mengidentifikasi buku kerja yang ditautkan ke bagan, pertama periksa apakah bagan menggunakan sumber data eksternal. Jika ya, Anda dapat mengambil jalur buku kerja dengan mengikuti langkah‑langkah berikut.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
2. Akses slide pertama berdasarkan indeks berbasis nol.
3. Periksa bahwa bentuk pertama adalah bagan.
4. Baca tipe sumber data bagan.
5. Jika sumbernya adalah buku kerja eksternal, baca jalurnya.

Contoh ini membuka `externalWorkbook.pptx`, yang dibuat pada contoh sebelumnya, dan memeriksa bentuk pertama pada slide pertama. Jika itu adalah bagan yang ditautkan ke buku kerja eksternal, contoh mencetak [external_workbook_path](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ke konsol. Kemudian ia menyimpan salinan presentasi ke `Result.pptx`.

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

### **Sunting Data Bagan**

Anda dapat menyunting data dalam buku kerja eksternal dengan cara yang sama seperti mengubah isi buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Contoh ini memerlukan `presentation.pptx` dengan bagan sebagai bentuk pertama pada slide pertama dan buku kerja eksternal yang dapat diakses. Ia mengatur nilai sel pertama pada titik data pertama dalam seri pertama menjadi 100 dan menyimpan presentasi ke `presentation_out.pptx`. Menyunting nilai sel dapat memperbarui file XLSX eksternal yang ditautkan, jadi gunakan salinan jika Anda perlu mempertahankan buku kerja asli.

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

### **Pulihkan Buku Kerja dari Cache Bagan**

Jika sebuah bagan menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat membangun kembali buku kerja bagan dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/), konfigurasikan [spreadsheet_options](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/spreadsheet_options/), dan setel [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/id/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) ke `True` sebelum membuka presentasi.

Contoh Python berikut membuka `presentation.pptx`, yang bentuk pertama pada slide pertama harus berupa bagan yang merujuk ke buku kerja eksternal yang tidak tersedia, dan mengakses data yang dipulihkan melalui [Chart.chart_data](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/chart_data/) dan [ChartData.chart_data_workbook](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # Baca atau ubah data buku kerja yang dipulihkan di sini.
    else:
        print("The first shape is not a chart.")
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika menggunakan data bagan yang di‑cache merupakan solusi yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dilakukan pada buku kerja eksternal setelah presentasi terakhir kali diperbarui.

## **Tanya Jawab**

**Apakah saya dapat menentukan apakah bagan tertentu terhubung ke buku kerja eksternal atau tertanam?**

Ya. Sebuah bagan memiliki [tipe sumber data](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/data_source_type/) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis diubah menjadi jalur absolut. Presentasi menyimpan jalur absolut dalam file PPTX, sehingga memindahkan buku kerja mungkin memerlukan pembaruan tautan.

**Apakah saya dapat menggunakan buku kerja yang berada di sumber daya/jaringan bersama?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan buku kerja remote secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Menyunting data bagan yang didukung sel dapat juga memperbarui file XLSX lokal yang ditautkan. Gunakan salinan buku kerja jika yang asli harus tetap tidak berubah.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat membuat tautan. Pendekatan umum adalah menghapus perlindungan sebelumnya atau menyiapkan salinan yang didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa bagan merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap bagan menyimpan tautannya masing‑masing. Jika semua bagan menunjuk ke file yang sama, pembaruan file tersebut akan tercermin di setiap bagan pada saat data dimuat kembali.