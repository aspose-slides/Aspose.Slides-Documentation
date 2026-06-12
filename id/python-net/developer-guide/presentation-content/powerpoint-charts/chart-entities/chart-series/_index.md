---
title: Kelola Seri Data Diagram di Python
linktitle: Seri Data
type: docs
url: /id/python-net/chart-series/
keywords:
- seri diagram
- tumpang tindih seri
- warna seri
- warna kategori
- nama seri
- titik data
- celah seri
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengelola seri data diagram di Python untuk PowerPoint (PPT/PPTX) dengan contoh kode praktis dan praktik terbaik untuk meningkatkan presentasi data Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan peran [ChartSeries](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/) dalam Aspose.Slides untuk Python, dengan fokus pada bagaimana data disusun dan divisualisasikan dalam presentasi. Objek‑objek ini menyediakan elemen dasar yang mendefinisikan sekumpulan titik data, kategori, dan parameter tampilan individual dalam sebuah diagram. Dengan bekerja dengan [ChartSeries](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/), pengembang dapat mengintegrasikan sumber data yang mendasari secara mulus dan mempertahankan kontrol penuh atas bagaimana informasi ditampilkan, menghasilkan presentasi yang dinamis dan berbasis data yang jelas menyampaikan wawasan serta analisis.

Sebuah seri adalah baris atau kolom angka yang dipetakan dalam diagram.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Mengatur Overlap Seri**

Properti [ChartSeries.overlap](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/overlap/) mengontrol cara batang dan kolom saling tumpang tindih dalam diagram 2D dengan menentukan rentang dari -100 hingga 100. Karena properti ini terkait dengan grup seri bukan seri diagram individu, properti ini bersifat hanya-baca pada tingkat seri. Untuk mengonfigurasi nilai overlap, gunakan properti `parent_series_group.overlap` yang dapat dibaca/ditulis, yang menerapkan overlap yang ditentukan ke semua seri dalam grup tersebut.

Berikut contoh Python yang menunjukkan cara membuat presentasi, menambahkan diagram kolom berkelompok, mengakses seri diagram pertama, mengatur nilai overlap, dan kemudian menyimpan hasilnya sebagai file PPTX:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tambahkan diagram kolom berkelompok dengan data default.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Atur tumpang tindih seri.
        series.parent_series_group.overlap = series_overlap

    # Simpan file presentasi ke disk.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The series overlap](series_overlap.png)

## **Ubah Warna Isian Seri**

Aspose.Slides memudahkan penyesuaian warna isian seri diagram, memungkinkan Anda menyoroti titik data tertentu dan membuat diagram yang menarik secara visual. Hal ini dicapai melalui objek [Format](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/format/) yang mendukung berbagai tipe isian, konfigurasi warna, dan opsi penataan lanjutan lainnya. Setelah menambahkan diagram ke slide dan mengakses seri yang diinginkan, cukup dapatkan seri tersebut dan terapkan warna isian yang tepat. Selain isian padat, Anda juga dapat memanfaatkan isian gradasi atau pola untuk fleksibilitas desain yang lebih tinggi. Setelah Anda mengatur warna sesuai kebutuhan, simpan presentasi untuk menyelesaikan tampilan yang diperbarui.

Contoh kode Python berikut menunjukkan cara mengubah warna seri pertama:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tambahkan diagram kolom berkelompok dengan data default.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Atur warna seri pertama.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Simpan file presentasi ke disk.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The color of the series](series_color.png)

## **Mengganti Nama Seri**

Aspose.Slides menawarkan cara sederhana untuk memodifikasi nama seri diagram, sehingga memudahkan pelabelan data secara jelas dan bermakna. Dengan mengakses sel worksheet yang relevan dalam data diagram, pengembang dapat menyesuaikan bagaimana data ditampilkan. Modifikasi ini sangat berguna ketika nama seri perlu diperbarui atau diperjelas berdasarkan konteks data. Setelah mengganti nama seri, presentasi dapat disimpan untuk mempertahankan perubahan.

Berikut potongan kode Python yang mendemonstrasikan proses ini.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tambahkan diagram kolom berkelompok dengan data default.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Atur nama seri pertama.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Simpan file presentasi ke disk.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Contoh kode Python berikut menunjukkan cara alternatif untuk mengubah nama seri:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tambahkan diagram kolom berkelompok dengan data default.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Atur nama seri pertama.
    series.name.as_cells[0].value = series_name

    # Simpan file presentasi ke disk.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```

Hasilnya:

![The series name](series_name.png)

## **Mendapatkan Warna Isian Otomatis Seri**

Aspose.Slides untuk Python memungkinkan Anda mendapatkan warna isian otomatis untuk seri diagram dalam area plot. Setelah membuat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/), Anda dapat memperoleh referensi ke slide yang diinginkan berdasarkan indeks, kemudian menambahkan diagram dengan tipe pilihan Anda (seperti `ChartType.CLUSTERED_COLUMN`). Dengan mengakses seri dalam diagram, Anda dapat memperoleh warna isian otomatis.

Kode Python di bawah ini menjelaskan proses tersebut secara detail.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tambahkan diagram kolom berkelompok dengan data default.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Dapatkan warna isian seri.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```

Contoh Output:

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Menetapkan Warna Isian Terbalik untuk Seri**

Ketika seri data Anda berisi nilai positif dan negatif, mewarnai setiap kolom atau batang dengan warna yang sama dapat membuat diagram sulit dibaca. Aspose.Slides untuk Python memungkinkan Anda menetapkan warna isian terbalik—sebuah isian terpisah yang diterapkan secara otomatis pada titik data yang berada di bawah nol—sehingga nilai negatif langsung terlihat. Pada bagian ini Anda akan belajar cara mengaktifkan opsi tersebut, memilih warna yang cocok, dan menyimpan presentasi yang telah diperbarui.

Contoh kode berikut mendemonstrasikan operasi ini:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Tambahkan kategori baru.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Tambahkan seri baru.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Isi data seri.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Atur pengaturan warna untuk seri.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The inverted solid fill color](inverted_solid_fill_color.png)

Anda dapat membalikkan warna isian untuk satu titik data saja, bukan seluruh seri. Cukup akses `ChartDataPoint` yang diinginkan dan atur properti `invert_if_negative`‑nya ke `True`.

Contoh kode berikut menunjukkan cara melakukannya:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Menghapus Data untuk Titik Data Tertentu**

Kadang‑kadang diagram berisi nilai uji, outlier, atau entri usang yang perlu dihapus tanpa harus membangun ulang seluruh seri. Aspose.Slides untuk Python memungkinkan Anda menargetkan titik data mana saja berdasarkan indeks, mengosongkan isinya, dan langsung memperbarui plot sehingga titik yang tersisa bergeser dan sumbu secara otomatis menyesuaikan skala.

Contoh kode berikut mendemonstrasikan operasi tersebut:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Lebar Celah Seri**

Lebar celah mengontrol jumlah ruang kosong antara kolom atau batang yang berdekatan—celah yang lebih lebar menekankan kategori individu, sementara celah yang lebih sempit menghasilkan tampilan yang lebih padat dan kompak. Melalui Aspose.Slides untuk Python Anda dapat menyetel parameter ini untuk seluruh seri, mencapai keseimbangan visual yang tepat sesuai kebutuhan presentasi tanpa mengubah data yang mendasarinya.

Contoh kode berikut menunjukkan cara mengatur lebar celah untuk sebuah seri:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Buat presentasi kosong.
with slides.Presentation() as presentation:

    # Akses slide pertama.
    slide = presentation.slides[0]

    # Tambahkan diagram dengan data default.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Simpan presentasi ke disk.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # Atur nilai gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Simpan presentasi ke disk.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The gap width](gap_width.png)

## **FAQ**

**Apakah ada batasan jumlah seri yang dapat dimiliki satu diagram?**

Aspose.Slides tidak menetapkan batas tetap pada jumlah seri yang Anda tambahkan. Batas praktis ditentukan oleh keterbacaan diagram dan memori yang tersedia bagi aplikasi Anda.

**Bagaimana jika kolom dalam sebuah klaster terlalu berdekatan atau terlalu jauh?**

Sesuaikan pengaturan [gap_width](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/gap_width/) untuk seri tersebut (atau grup seri induknya). Meningkatkan nilai akan memperlebar ruang antar kolom, sementara mengurangi nilai akan mendekatkan mereka.