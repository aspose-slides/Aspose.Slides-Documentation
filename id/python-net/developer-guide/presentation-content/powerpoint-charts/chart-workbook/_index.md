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
- cache diagram
- pemulihan buku kerja
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Temukan Aspose.Slides untuk Python via .NET: kelola buku kerja diagram secara mudah di format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Ini menunjukkan cara membaca dan menulis data diagram melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan tipe sumber data untuk nilai diagram.

Artikel ini juga mencakup cara bekerja dengan buku kerja eksternal sebagai sumber data diagram. Contoh-contoh memperlihatkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang ditautkan ke diagram, serta menyunting data diagram ketika buku kerja tersedia.

Untuk sel buku kerja yang mewakili data yang hilang, lihat [Mengontrol Tampilan Sel Kosong](/slides/id/python-net/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan diagram garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) untuk mengontrol apakah diagram memplot data dari baris dan kolom lembar kerja yang tersembunyi. Atur ke `True` untuk memplot hanya sel yang terlihat, atau `False` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemetaan diagram; tidak menyembunyikan atau menampilkan kembali baris atau kolom lembar kerja.

[Presentasi contoh](hidden-source-data.pptx) berisi diagram kolom sebagai bentuk pertama pada slide pertama. Lembar kerja tersemat, `Sheet1`, berisi rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C tersembunyi, tetapi sel‑selnya masih berisi nilai.

| Baris lembar kerja | A: Bulan | B: Ritel | C: Grosir (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (baris tersembunyi) | Februari | 40 | 60 |
| 4 | Maret | 20 | 50 |

Akses sel sumber melalui [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) dan baca [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) untuk memeriksa status tersembunyi mereka. Properti ini hanya baca. Pada file ini, B2 terlihat, B3 termasuk dalam baris tersembunyi, dan C2 termasuk dalam kolom tersembunyi; contoh mencetak `False`, `True`, dan `True` masing‑masing.

Untuk contoh ini, segarkan data diagram setelah mengubah pengaturan pemetaan: pertahankan buku kerja tersemat dengan [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan muat kembali dengan [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Saat menyertakan semua sel, gunakan juga [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) untuk mengembalikan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk menyegarkan data diagram yang di‑cache dalam contoh ini serta label kategori.

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

            # Segarkan data diagram dari buku kerja yang tersemat.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Kembalikan rentang sumber lengkap, termasuk kategori tersembunyi.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Contoh menyimpan dua versi presentasi: satu hanya dengan nilai Ritel yang terlihat (10 dan 20), dan satu lagi dengan semua enam nilai. Gambar di bawah dirender dari presentasi yang disimpan setelah dibuka kembali; kedua berkas mempertahankan pengaturan pemetaan yang ditetapkan. Baris 3 dan kolom C tetap tersembunyi di kedua buku kerja tersemat.

| Hanya sel terlihat (`True`) | Semua sel (`False`) |
| --- | --- |
| ![Hanya sel terlihat: nilai Ritel 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Ritel dan Grosir untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sel tersembunyi yang berisi nilai berbeda dari sel kosong. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) mengontrol bagaimana nilai yang hilang ditampilkan; tidak menyertakan atau mengecualikan data sumber yang tersembunyi. Lihat [Mengontrol Tampilan Sel Kosong](/slides/id/python-net/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Dapatkan Rentang Data Diagram**

Sebelum memperbarui data buku kerja dalam presentasi yang ada, periksa rentang sumber untuk mengidentifikasi sel lembar kerja mana yang digunakan tiap diagram. Metode [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) mengembalikan rentang data saat ini sebagai formula yang memenuhi lembar kerja, misalnya `Sheet1!$A$1:$D$5`. Di sini, `Sheet1` adalah nama lembar kerja, `!` memisahkannya dari rentang sel, dan `$A$1:$D$5` mengidentifikasi sel A1 sampai D5, inklusif. Tanda dolar menandakan referensi baris dan kolom absolut.

Metode ini membaca rentang saat ini tanpa mengubah diagram atau bukunya. Jika diagram tidak menggunakan buku kerja sebagai sumber data, metode akan melempar pengecualian. Untuk informasi lebih lanjut, lihat [Referensi API ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Contoh ini membuka sebuah presentasi dan memeriksa bentuk‑bentuk langsung pada tiap slide untuk diagram. Ia mencetak nama tiap diagram serta rentang sumbernya. Jika rentang tidak dapat diambil, ia mencetak pesan diagnostik dan melanjutkan ke diagram berikutnya.

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

Aspose.Slides for Python via .NET menyediakan metode [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) yang memungkinkan Anda membaca dan menulis buku kerja data diagram (yang berisi data diagram yang disunting dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau harus memiliki struktur yang mirip dengan sumber.

Contoh ini menggunakan presentasi dengan diagram sebagai bentuk pertama pada slide pertama. Ia membaca buku kerja tersemat ke dalam aliran, menghapus seri dan kategori yang ada, dan menulis kembali buku kerja yang sama. Perubahan tetap berada di memori; contoh tidak menyimpan presentasi.

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

Saat Anda mengganti buku kerja tersemat dengan yang sudah dimodifikasi, diagram tetap mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) gagal dengan kesalahan indeks di luar jangkauan. Hapus seri dan kategori yang ada sebelum menulis kembali buku kerja yang diperbarui ke diagram. Contoh ini menggunakan diagram yang merupakan bentuk pertama pada slide pertama. Komentar menandai tempat penyuntingan buku kerja akan dilakukan; contoh yang dapat dijalankan menulis kembali buku kerja asli dan memvalidasi tata letak di memori.

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

Mengosongkan koleksi menghilangkan referensi data usang sebelum buku kerja ditulis kembali. Bangun kembali pemetaan seri dan kategori yang diperlukan untuk buku kerja yang diperbarui sebelum menggunakan diagram.

## **Atur Format Angka Kustom untuk Sel Buku Kerja**

Gunakan [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) untuk mengontrol bagaimana nilai numerik tampil dalam buku kerja tersemat diagram. Misalnya, sebuah laporan mungkin memerlukan tingkat konversi yang ditampilkan sebagai persentase dengan empat tempat desimal dan koefisien yang ditampilkan dengan lima tempat desimal. Simpan kedua nilai sebagai numerik sehingga tetap tersedia untuk perhitungan dan pemetaan diagram.

Format angka mengubah tampilan, bukan nilai yang disimpan. Format `0.0000%` menampilkan `0.125` sebagai `12.5000%`; tidak menggantikan angka yang disimpan dengan `12.5`. Demikian pula, `0.00000` menampilkan `0.1234567` sebagai `0.12346` tanpa membulatkan nilai yang disimpan. Jika format kustom berupa string kosong (`""`), [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) digunakan sebagai gantinya.

Contoh berikut membuat diagram kolom dan mengakses sel‑nya melalui [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). Pada lembar kerja 0, B2 berisi tingkat konversi dan C2 berisi koefisien. Kedua sel menyediakan nilai diagram. Contoh juga mengaktifkan label nilai yang ditautkan ke format sumber.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

Format sel buku kerja terpisah dari format yang diterapkan langsung pada sumbu diagram atau label data. Pada contoh ini, setiap label menampilkan nilai sel sumbernya karena [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) diaktifkan, dan mengikuti format angka sumber karena [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) bernilai `True`. Setelah menyimpan dan membuka kembali presentasi, label menampilkan `12.5000%` dan `0.12346`, seperti ditunjukkan di bawah. Sumbu vertikal menggunakan [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) miliknya sendiri yaitu `0.00`, dengan [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) disetel ke `False`.

Untuk memformat label data secara independen, atur flag tautan sumbernya ke `False` dan tetapkan [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/). Ini tidak mengubah format sel buku kerja. Misalnya, format label independen `0.00` menampilkan nilai pertama sebagai `0.13`, sementara B2 masih menampilkan `12.5000%`. Lihat [Label Data Diagram](/slides/id/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) untuk pemformatan label langsung.

Gambar di bawah dirender dari presentasi yang disimpan setelah dibuka kembali:

![Diagram kolom dengan label terhubung ke sumber yang menampilkan 12.5000% dan 0.12346 serta sumbu numerik yang diformat secara independen.](custom-cell-formats.png)

## **Atur Sel Buku Kerja sebagai Label Data Diagram**

Anda dapat menggunakan teks dari sel buku kerja sebagai label data diagram.

Contoh ini menambahkan diagram gelembung dengan data default ke slide pertama dari presentasi yang ada. Ia menggunakan sel A10:A12 pada lembar kerja 0 untuk tiga label pertama pada seri pertama, mengaktifkan label dari sel, dan menyimpan presentasi yang diperbarui.

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

Properti [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) menyediakan akses ke lembar kerja dalam buku kerja diagram. Contoh ini membuat diagram lingkaran dengan data default dan mencetak nama tiap lembar kerja ke konsol.

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

Contoh ini membuat diagram kolom 3D dengan data default dan mengatur dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; yang kedua menggunakan sel C1 pada lembar kerja 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) memilih sumber untuk tiap nama. Contoh menyimpan presentasi dengan nama seri yang diperbarui.

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

## **Deteksi Format Buku Kerja Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja Excel biner (.xlsb) yang dapat tersemat dalam beberapa diagram. Anda dapat menggunakan properti [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) pada [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan diagram‑diagram tersebut. Contoh ini memeriksa bentuk‑bentuk pada slide pertama dari presentasi yang ada, melewatkan bentuk non‑diagram, dan mencetak pesan diagnostik untuk tiap diagram dengan buku kerja .xlsb yang tersemat.

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

Gunakan [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) dan [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) untuk mengekspor buku kerja diagram tersemat ke file dan menautkan diagram ke buku kerja eksternal tersebut.

Contoh ini membuat diagram lingkaran dengan data default dan mengekspor buku kerjanya. Ia menutup aliran keluaran sebelum menetapkan buku kerja eksternal sebagai sumber data diagram, lalu menyimpan presentasi yang ditautkan.

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

Dengan menggunakan metode [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), Anda dapat menetapkan buku kerja eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut dipindahkan).

Meskipun Anda tidak dapat menyunting data dalam buku kerja yang disimpan di lokasi atau sumber daya remote, Anda masih dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif ke buku kerja eksternal diberikan, jalur itu secara otomatis dikonversi ke jalur penuh.

Contoh ini menggunakan buku kerja eksternal yang lembar kerjanya bernama `Sheet1` berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh membuat diagram lingkaran, menautkan buku kerja, dan menggunakan [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Ia menyimpan presentasi dengan diagram yang ditautkan.

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

Parameter `update_chart_data` pada metode [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) mengontrol apakah buku kerja dimuat.

* Ketika `update_chart_data` bernilai `False`, hanya jalur buku kerja yang diperbarui. Data diagram tidak dimuat atau diperbarui dari buku kerja target, sehingga buku kerja dapat tidak tersedia.
* Ketika `update_chart_data` bernilai `True`, data diagram diperbarui dari buku kerja target.

Contoh berikut menetapkan URL placeholder dengan `update_chart_data` disetel ke `False`. Ia mempertahankan data default diagram lingkaran dan menyimpan presentasi tanpa memuat buku kerja yang tidak tersedia.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Dapatkan Jalur Buku Kerja Sumber Data Eksternal dari Diagram**

Untuk mengidentifikasi buku kerja yang ditautkan ke diagram, periksa apakah diagram menggunakan sumber data eksternal dan ambil jalur bukunya.

Contoh ini memeriksa bentuk pertama pada slide pertama dari sebuah presentasi dengan buku kerja eksternal yang ditautkan. Jika itu diagram yang ditautkan ke buku kerja eksternal, contoh mencetak [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ke konsol. Ia kemudian menyimpan salinan presentasi.

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

Anda dapat menyunting data dalam buku kerja eksternal dengan cara yang sama seperti melakukan perubahan pada isi buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, pengecualian akan dilempar.

Contoh ini menggunakan diagram yang merupakan bentuk pertama pada slide pertama dan ditautkan ke buku kerja eksternal yang dapat diakses. Ia mengatur nilai sel pertama pada titik data pertama seri pertama menjadi 100 dan menyimpan presentasi yang diperbarui. Menyunting nilai sel dapat memperbarui berkas XLSX eksternal yang ditautkan, jadi gunakan salinan jika Anda perlu menjaga buku kerja asli tetap tidak berubah.

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

Jika sebuah diagram menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat membangun kembali buku kerja diagram dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), konfigurasikan [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), dan setel [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) ke `True` sebelum membuka presentasi.

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

        # Baca atau ubah data buku kerja yang dipulihkan di sini.
    else:
        print("The first shape is not a chart.")
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar pengecualian. Aktifkan pemulihan hanya ketika penggunaan data diagram yang di‑cache merupakan solusi yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir kali diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah diagram tertentu terhubung ke workbook eksternal atau tersemat?**

Ya. Sebuah diagram memiliki [tipe sumber data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) dan [jalur ke workbook eksternal](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); jika sumbernya adalah workbook eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke workbook eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi ke jalur absolut. Presentasi menyimpan jalur absolut dalam berkas PPTX, sehingga memindahkan workbook mungkin memerlukan pembaruan tautan.

**Dapatkah saya menggunakan workbook yang berada pada sumber daya atau share jaringan?**

Ya, workbook tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan workbook remote langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Menyunting data diagram yang didukung sel dapat memperbarui berkas XLSX lokal yang ditautkan. Gunakan salinan workbook jika yang asli harus tetap tidak berubah.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus proteksi sebelumnya atau menyiapkan salinan yang didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa diagram merujuk ke workbook eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada tiap diagram saat data dimuat kembali.