---
title: Kustomisasi Titik Data pada Diagram Treemap dan Sunburst di Python
linktitle: Titik Data pada Diagram Treemap dan Sunburst
type: docs
url: /id/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- diagram treemap
- diagram sunburst
- diagram hierarkis
- titik data
- label data
- warna cabang
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara membuat data hierarkis dan menyesuaikan tingkat, label, serta warna pada diagram Treemap dan Sunburst dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Diagram Treemap dan Sunburst menampilkan jenis data hierarkis yang sama, tetapi menggunakan tata letak yang berbeda. Treemap menggambar hierarki sebagai persegi panjang bersarang yang area‑nya mewakili nilai daun. Sunburst menggambarnya sebagai cincin konsentrik: grup tingkat atas berada di dekat pusat, dan kategori daun berada di cincin luar.

Di Aspose.Slides for Python via .NET, setiap nilai numerik adalah sebuah [ChartDataPoint](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/). Koleksi [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) menyediakan akses ke daun dan grup induknya. Artikel ini menjelaskan pemetaan tersebut dan menunjukkan cara membuat serta memformat kedua jenis diagram dari data contoh yang sama.

![Diagram Treemap dengan cabang Consumer dan Business](treemap-hierarchy.png)

![Diagram Sunburst dengan hierarki Consumer dan Business yang sama](sunburst-hierarchy.png)

## **Memahami Kategori, Titik Data, dan Tingkat**

Contoh yang digunakan di bawah memiliki tiga tingkat kategori dan satu seri numerik:

| Cabang | Batang | Daun | Pendapatan |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Setiap baris membuat satu kategori daun dan satu titik data. Tingkat pengelompokan kategori menggambarkan jalur dari daun tersebut ke induknya. Untuk baris pertama, jalurnya adalah `Consumer > Computers > Laptops`.

Indeks dalam [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) berjalan dari daun ke atas:

| `data_point_levels` indeks | Tingkat Logis | Representasi Treemap | Representasi Sunburst |
| ---: | --- | --- | --- |
| `0` | Daun | Persegi panjang nilai | Segmen cincin luar |
| `1` | Batang | Persegi panjang induk atau header | Segmen cincin tengah |
| `2` | Cabang | Persegi panjang tingkat atas atau header | Segmen cincin dalam |

Urutan ini sama untuk kedua jenis diagram meskipun tata letak visualnya berbeda. Sebuah segmen induk dibagi oleh beberapa daun. Untuk memformatnya, gunakan tingkat yang sesuai dari titik data pertama dalam grup tersebut. Misalnya, cabang `Consumer` dimulai dengan titik `Laptops`, sementara batang `Software` dimulai dengan titik `Licenses`. Menyimpan referensi ke titik‑titik itu lebih jelas dan lebih aman daripada menggunakan ekspresi yang tidak dijelaskan seperti `data_points[0]` atau `data_points[6]`.

## **Buat dan Sesuaikan Kedua Jenis Diagram**

Contoh lengkap berikut membuat Treemap pada slide pertama dan Sunburst pada slide kedua. Contoh ini membangun hierarki, menampilkan nilai untuk `Tablets`, menerapkan warna tetap pada tingkat yang dipilih, memformat label cabang, dan menyimpan presentasi.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Tambahkan kategori daun. Item pengelompokan hanya diatur saat grup baru dimulai; kategori berikutnya tetap berada dalam grup tersebut hingga item lain diatur.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Tampilkan kategori dan nilai pada daun Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Format cabang Consumer melalui daun pertama dalam cabang tersebut.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Format batang Software melalui daun pertama dalam batang tersebut.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout memengaruhi label induk Treemap; Sunburst menggunakan segmen cincin.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

Sel sel kategori dan sel nilai menggunakan baris worksheet yang sama, sehingga posisi koleksi mereka tetap selaras. Ketika Anda bekerja dengan diagram yang sudah ada alih‑alih membuat yang baru, periksa baris‑baris kategori terlebih dahulu dan simpan referensi bernama ke titik data serta tingkat yang ingin Anda format.

## **Perilaku dan Pertimbangan Praktis**

### **Perbedaan Treemap dan Sunburst**

- Treemap menggunakan area untuk menyampaikan nilai dan persegi panjang bersarang untuk menyampaikan hierarki. Properti [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/parent_label_layout/) mengontrol cara label induk muncul pada tipe diagram ini.
- Sunburst menggunakan sudut untuk menyampaikan nilai dan kedalaman cincin untuk menyampaikan hierarki. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartseries/parent_label_layout/) tidak mengontrol label cincinnya.
- Kedua tipe diagram menggunakan tingkat pengelompokan kategori yang sama dan urutan daun‑ke‑induk yang sama dalam `data_point_levels`, sehingga kode pembuatan data dan pemformatan tingkat dapat dipakai bersama.
- Nilai induk dihitung dari daun‑daun keturunan. Jangan menambahkan titik numerik terpisah untuk cabang atau batang.

### **Pengurutan dan Urutan Segmen**

Mesin tata letak diagram menentukan penempatan akhir persegi panjang dan segmen cincin. Susun baris‑baris kategori yang berhubungan bersama sebelum menambahkannya, tetapi jangan bergantung pada posisi persegi panjang atau sudut mulai tertentu. Jika urutan membawa makna, sertakan dalam label atau gunakan tipe diagram dengan sumbu kategori yang eksplisit.

### **Tema dan Warna Tetap**

Tingkat diagram yang belum diformat mewarisi warna dari tema presentasi. Contoh ini menggunakan isian RGB eksplisit untuk output yang dapat diprediksi. Jika diagram harus mengikuti perubahan tema, gunakan warna skema alih‑alih nilai RGB tetap dan hindari menimpa setiap tingkat. Juga periksa kontras label setelah mengubah isian cabang atau batang.

### **Label dan Ruang Tersedia**

PowerPoint dapat menyembunyikan atau memotong label ketika segmen terlalu kecil. Memperbesar ukuran diagram, mempersingkat nama kategori, atau menampilkan lebih sedikit bidang label biasanya menghasilkan tampilan yang lebih jelas. Sebuah label dapat menggabungkan nama kategori, nama seri, dan nilai melalui [DataLabelFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabelformat/), tetapi mengaktifkan setiap bidang sering membuat diagram hierarki sulit dibaca.

### **Ekspor dan Rendering**

Menyimpan ke PPTX menjaga diagram tetap dapat diedit. Ketika Aspose.Slides merender presentasi ke PDF atau gambar, isian dan pengaturan label yang didukung dirender bersama diagram. Substitusi font dan perbedaan kecil dalam ruang tata letak yang tersedia dapat mengubah pembungkus baris atau visibilitas label, jadi instal font yang diperlukan dan verifikasi target ekspor penting.

## **FAQ**

**Mengapa mengubah tingkat induk memengaruhi beberapa daun?**

Sebuah cabang atau batang adalah segmen visual yang dibagi. [ChartDataPointLevel](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chartdatapointlevel/) dapat diakses melalui daun keturunan, tetapi pemformatannya berlaku untuk segmen induk yang dibagi, bukan hanya untuk daun tersebut.

**Mengapa label data tidak muncul?**

Pertama aktifkan bidang‑bidang yang diperlukan pada objek [DataLabelFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/datalabelformat/) label. Kemudian periksa apakah segmen memiliki ruang yang cukup. Tata letak label induk Treemap, dimensi diagram, panjang label, ukuran font, dan jumlah bidang yang diaktifkan semuanya memengaruhi apakah label dapat ditampilkan.

**Apakah saya dapat mengatur urutan atau koordinat tepat segmen?**

Anda dapat mengontrol urutan baris sumber dan menjaga tiap grup berurutan, tetapi tidak dapat menentukan persegi panjang Treemap atau sudut Sunburst secara tepat. Mesin tata letak diagram menghitungnya dari hierarki, nilai, dan ruang yang tersedia.

**Mengapa warna berubah setelah tema presentasi berubah?**

Isian berbasis tema dirancang mengikuti palet presentasi. Terapkan warna RGB eksplisit pada tingkat yang harus tetap tetap, atau pertahankan warna skema ketika penyesuaian ke tema baru diinginkan.

**Apakah pemformatan khusus akan dipertahankan dalam ekspor PDF dan gambar?**

Ya, isian diagram yang didukung dan pengaturan label disertakan selama proses rendering. Untuk hasil yang konsisten di seluruh sistem, sediakan font yang diperlukan dan uji ukuran ekspor akhir karena penyesuaian label bergantung pada tata letak.

## **Lihat Juga**

- [Buat diagram Treemap](/slides/id/python-net/create-chart/#create-tree-map-charts)
- [Buat diagram Sunburst](/slides/id/python-net/create-chart/#create-sunburst-charts)
- [Ekspor diagram presentasi](/slides/id/python-net/export-chart/)
- [Kelola tema presentasi](/slides/id/python-net/presentation-theme/)