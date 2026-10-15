---
title: Sesuaikan Sumbu Grafik dalam Presentasi dengan Python
linktitle: Sumbu Grafik
type: docs
url: /id/python-net/chart-axis/
keywords:
- sumbu grafik
- sumbu vertikal
- sumbu horizontal
- sesuaikan sumbu
- manipulasi sumbu
- kelola sumbu
- properti sumbu
- nilai maksimum
- nilai minimum
- garis sumbu
- format tanggal
- judul sumbu
- posisi sumbu
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Temukan cara menggunakan Aspose.Slides untuk Python melalui .NET untuk menyesuaikan sumbu grafik dalam presentasi PowerPoint dan OpenDocument untuk laporan dan visualisasi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan sumbu grafik dengan Aspose.Slides untuk Python melalui .NET. Ini mencakup nilai sumbu yang dihitung, menukar baris dan kolom grafik, visibilitas sumbu, interval label kategori dan tanda centang, kategori tanggal serta pemformatannya, rotasi judul, penempatan sumbu, unit tampilan, dan skala logaritmik.

## **Get the Max Values on the Vertical Axis on Charts**

Buat sebuah [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dan tambahkan diagram area dengan data default. Panggil [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) sebelum membaca nilai sumbu yang dihitung sehingga tata letak diagram terbaru.

Baca [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) dan [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) untuk batas sumbu, serta [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) dan [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) untuk interval tanda centang. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) dan [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) menyediakan skala satuan waktu, yang relevan untuk sumbu tanggal. Contoh menyimpan nilai‑nilai ini dalam variabel lokal dan menyimpan diagram.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Swap the Data between Axes**

Gunakan [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) untuk menukar peran seri dan kategori dalam data diagram. Setiap kategori sebelumnya menjadi seri, dan setiap seri sebelumnya menjadi kategori. Ini mengubah cara data dikelompokkan; tidak menukar sumbu horizontal dan vertikal. Contoh menggunakan [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) untuk mengikat data default ke `Sheet1!A1:D5`, termasuk baris header dan kolom kategori, sebelum menukar baris dan kolom. Diagram yang disimpan memiliki empat seri dan tiga kategori.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Reverse the Plotting Order of an Axis**

Gunakan [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) untuk membalikkan sumbu kategori atau nilai. Misalnya, diagram batang horizontal dapat menampilkan tahapan proyek dari atas ke bawah dalam urutan yang sama dengan lembar kerja: Perencanaan, Pengembangan, Pengujian. Membalikkan sumbu mengubah arah plot; tidak menyortir atau mengatur ulang data buku kerja. Sebagai perbandingan, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) menukar peran seri dan kategori.

Contoh berikut membuat diagram batang horizontal dengan tiga tahapan dan satu seri. Ia menyimpan presentasi dengan tiga slide: urutan normal, kategori terbalik, dan nilai terbalik. Setiap salinan menggunakan set data yang sama, dan hanya satu sumbu yang dibalik pada setiap salinan.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # Slide 2: tampilkan kategori pertama di bagian atas.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Pertahankan sumbu nilai horizontal di bagian bawah.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Slide 3: balikkan hanya skala numerik horizontal.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Membalikkan sumbu juga dapat memindahkan sumbu yang tegak lurus ke sisi berlawanan dari plot. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) mengendalikan di mana sumbu lain melintasi sumbu yang sedang dikonfigurasi. Pada slide 2, mengaturnya ke `MAXIMUM` pada sumbu kategori yang dibalik menjaga sumbu nilai horizontal di bagian bawah. Untuk titik pertemuan tertentu, gunakan [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Periksa pengaturan pertemuan saat mengubah arah, terutama bila diagram sudah memiliki titik pertemuan khusus. Atur kembali `is_plot_order_reversed` ke `False` untuk mengembalikan arah plot normal; pengaturan pertemuan bersifat terpisah.

| Urutan normal (slide 1) | Kategori terbalik (slide 2) | Nilai terbalik (slide 3) |
| --- | --- | --- |
| ![Diagram batang horizontal dengan urutan sumbu kategori dan nilai normal](axis-order-normal.png) | ![Diagram batang horizontal dengan kategori ditampilkan dari atas ke bawah](axis-order-categories-reversed.png) | ![Diagram batang horizontal dengan sumbu nilai terbalik dan nol di kanan](axis-order-values-reversed.png) |
| Kategori berjalan dari bawah ke atas; nilai meningkat dari kiri ke kanan. | Perencanaan, Pengembangan, dan Pengujian berjalan dari atas ke bawah. Nilai dan urutan baris buku kerja tidak berubah. | Kategori mempertahankan urutan normal; nilai meningkat dari kanan ke kiri. Sumbu kategori melintasi pada nol di kanan. |

## **Disable the Vertical Axis for Line Charts**

Setel [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) ke `False` pada sumbu vertikal untuk menyembunyikannya. Contoh membuat diagram garis dengan data default dan menyimpannya dengan sumbu vertikal tersembunyi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Disable the Horizontal Axis for Line Charts**

Setel [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) ke `False` pada sumbu horizontal untuk menyembunyikannya. Contoh membuat diagram garis dengan data default dan menyimpannya dengan sumbu horizontal tersembunyi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Change a Category Axis**

Setel [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) untuk memilih sumbu kategori tanggal atau teks. Contoh ini memerlukan `ExistingChart.pptx`, dengan diagram sebagai bentuk pertama pada slide pertama dan sel kategori berisi nilai tanggal Excel numerik. Ia mengubah sumbu horizontal menjadi sumbu tanggal. Mengatur [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) ke `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) ke `1`, dan [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) ke bulan menempatkan tanda utama pada interval satu bulan.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Control Category Axis Label Intervals**

Ketika diagram memiliki banyak kategori, kurangi jumlah label sumbu yang terlihat tanpa menghapus kategori atau titik data. Setel [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) ke `False`, lalu atur [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) ke interval kategori yang diinginkan. Untuk kategori teks dalam urutan normal, penghitungan dimulai dari kategori pertama:

| Interval | Label yang ditampilkan dalam contoh |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, … Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, … Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, … Kategori 22 |

Interval `3` menampilkan setiap label ketiga, menyisakan dua label tersembunyi di antara label yang ditampilkan. Ini tidak menghapus kolom yang bersangkutan. Penempatan otomatis memilih interval berdasarkan ruang yang tersedia; tidak selalu menampilkan setiap label.

Tanda centang memiliki kontrol terpisah. Setel [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) ke `False` dan gunakan [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) untuk mengatur intervalnya. Misalnya, `1` mempertahankan tanda centang pada setiap interval kategori sementara label hanya muncul setiap kategori ketiga. Setel [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) ke gaya yang terlihat sehingga Anda dapat melihat hasilnya. Mengembalikan properti otomatis‑spacing mana pun ke `True` membiarkan diagram memilih interval tersebut kembali.

Contoh mandiri berikut membuat 24 kategori dan satu seri, lalu menyimpan tiga slide dalam `CategoryAxisIntervals.pptx`: penempatan otomatis, penempatan label manual dengan tanda centang independen, dan pemulihan penempatan otomatis. Kedua salinan mempertahankan data diagram asli. Tidak diperlukan presentasi input. Teks label horizontal memudahkan melihat perbedaan kepadatan.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Slide 2: tampilkan setiap label ketiga, tetapi tetap pertahankan tanda centang untuk setiap kategori.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Slide 3: biarkan diagram memilih kedua interval lagi.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Jarak otomatis (slide 1):** Pada render ini, setiap label kategori kedua ditampilkan dan dibungkus menjadi dua baris. Hasil otomatis dapat bervariasi tergantung ukuran diagram, font, dan renderer.

![Jarak otomatis label kategori dengan semua 24 kolom terlihat](category-axis-automatic.png)

**Jarak manual (slide 2):** Setiap label ketiga ditampilkan pada satu baris, sementara tanda centang tetap pada setiap interval kategori. Semua 24 kolom, termasuk yang tanpa label, tetap terlihat dengan nilai yang sama. Slide 3 mengembalikan tampilan otomatis yang ditunjukkan di atas.

![Interval label kategori manual tiga dengan semua 24 kolom terlihat](category-axis-manual.png)

### **Choose the Correct Axis and Interval**

Gunakan interval hitung kategori ini untuk sumbu kategori teks, seperti sumbu kategori pada diagram kolom, garis, area, atau batang. Pada diagram kolom, ia adalah sumbu horizontal. Pada diagram batang horizontal, sumbu kategori berada vertikal, sehingga terapkan pengaturan ini pada [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Penempatan jarak tanda centang juga berlaku untuk sumbu seri pada diagram yang memilikinya.

Jangan gunakan penempatan label kategori untuk mengatur skala numerik sumbu nilai. Pada sumbu nilai, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) menentukan perbedaan nilai: misalnya, unit utama `10` menghasilkan tanda pada 0, 10, 20, dan seterusnya ketika sumbu mulai dari nol. Interval label kategori `3` menghitung posisi kategori, terlepas dari nilai datanya. Diagram sebar dan gelembung menggunakan sumbu nilai, bukan sumbu kategori teks. Untuk sumbu tanggal, gunakan unit utama dan skala berbasis waktu seperti dijelaskan pada [Change a Category Axis](#change-a-category-axis).

## **Set the Date Format for Category Axis Values**

Contoh mengganti data diagram default dengan empat nilai tahunan. Tanggal disimpan sebagai nomor seri OLE Automation di lembar kerja pertama (indeks `0`). Setel [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) ke sumbu tanggal, nonaktifkan [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/), dan tetapkan `yyyy` ke [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) sehingga label kategori menampilkan tahun empat digit terlepas dari pemformatan sel.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Set a Rotation Angle for a Chart Axis Title**

Aktifkan [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) pada sumbu vertikal, berikan teks judul, dan setel [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) untuk memutar judul. Sudut diukur dalam derajat; contoh ini menyimpan diagram kolom dengan judul sumbu nilai berputar 90 derajat.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Set the Axis Position on a Category or Value Axis**

Gunakan [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) untuk mengendalikan apakah sumbu nilai melintasi sumbu kategori di antara kategori atau pada tanda kategori. Properti ini berlaku untuk sumbu kategori. Contoh mengaturnya ke `True` pada sumbu kategori horizontal diagram kolom dan menyimpan hasilnya.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Set the Display Unit on a Chart Value Axis**

Setel [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) untuk menskalakan label pada sumbu nilai tanpa mengubah data dasar. Dengan [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) diatur ke `MILLIONS`, nilai 60.000.000 ditampilkan sebagai 60. Contoh membuat diagram kolom dan menerapkan unit tampilan jutaan pada sumbu vertikalnya.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Configure a Logarithmic Value Axis**

Sumbu nilai logaritmik berguna ketika nilai positif mencakup beberapa orde besaran. Misalnya, sebuah layanan mungkin menerima 10, 100, 1.000, 10.000, dan 100.000 permintaan selama lima periode. Pada skala linear, nilai kecil muncul berdekatan di dekat nol. Skala logaritmik membuat pertumbuhan relatif mereka lebih mudah dibandingkan: jarak yang sama mewakili rasio yang sama, bukan selisih yang sama.

Setel [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) ke `True` pada sumbu nilai dan gunakan [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) untuk memilih basis. Ini mengubah cara nilai yang ada ditampilkan; tidak mengubah data atau menambah garis tren logaritmik. Garis tren merupakan fitur terpisah yang merepresentasikan hubungan yang dipasangkan pada data.

### **Choose the Value Axis and Base**

Untuk diagram garis atau kolom, sumbu nilai adalah [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Untuk diagram batang horizontal, itu adalah [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Diagram sebar dan gelembung memiliki dua sumbu nilai, jadi pilih sumbu horizontal untuk nilai X, sumbu vertikal untuk nilai Y, atau keduanya. Jangan terapkan skala logaritmik pada sumbu kategori.

Basis logaritmik default adalah `10`. Untuk diagram PPTX, gunakan basis antara `2` hingga `1000`, inklusif; basis pecahan seperti `2.5` juga didukung. Dengan basis `10`, pangkat berurutan seperti 10, 100, 1.000, dan 10.000 berjarak sama.

### **Compare Linear and Logarithmic Scaling**

Contoh mandiri berikut membuat diagram garis dengan lima hitungan permintaan pada slide pertama, lalu menggandakan slide tersebut dan mengaktifkan sumbu nilai logaritmik basis‑10 pada slide kedua. Kedua slide mempertahankan data yang sama.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Pertahankan slide pertama linear dan ubah hanya skala sumbu nilai salinan.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Skala linear (slide 1):** Jarak vertikal yang sama mewakili perbedaan yang sama dalam hitungan permintaan. Nilai terbesar mendominasi diagram, menyulitkan membedakan nilai kecil.

![Diagram garis di PowerPoint menampilkan lima hitungan permintaan pada sumbu nilai linear](value-axis-linear.png)

**Skala logaritmik (slide 2):** Jarak vertikal yang sama mewakili rasio yang sama. Setiap periode memiliki sepuluh kali lipat permintaan dibandingkan periode sebelumnya, sehingga titik‑titik membentuk garis naik lurus pada skala logaritmik basis‑10. Label sumbu tetap menampilkan hitungan permintaan asli.

![Lima hitungan permintaan yang sama di PowerPoint pada sumbu nilai logaritmik basis‑10](value-axis-logarithmic.png)

### **Handle Zero and Negative Values**

Skala logaritmik hanya dapat menampilkan nilai yang benar‑benar positif. Periksa data sebelum mengaktifkannya. Jika nol atau nilai negatif memiliki makna, pertahankan skala linear atau tampilkan secara terpisah. Jika mengeluarkan nilai‑nilai tersebut tepat untuk analisis, jelaskan penghapusan tersebut. Jangan diam‑diam menggantinya dengan angka positif kecil, karena hal itu mengubah makna data. Setiap minimum atau maksimum yang dikonfigurasi secara manual untuk sumbu logaritmik juga harus positif.

## **FAQ**

**Bagaimana cara mengatur nilai di mana satu sumbu memotong sumbu lainnya (pertemuan sumbu)?**

Gunakan [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) untuk memilih perilaku pertemuan. Untuk menentukan nilai pertemuan numerik, setel [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Pengaturan ini memungkinkan Anda memindahkan pertemuan sumbu ke garis dasar yang sesuai.

**Bagaimana cara memposisikan label tanda centang relatif terhadap sumbu?**

Setel [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) menggunakan [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO`, atau `NONE`. Untuk mengendalikan tanda centang itu sendiri, gunakan [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) atau [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); ini terpisah dari penempatan label.