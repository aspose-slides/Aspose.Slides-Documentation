---
title: Sesuaikan Grafik 3D dalam Presentasi dengan Python
linktitle: Grafik 3D
type: docs
url: /id/python-net/3d-chart/
keywords:
- grafik 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Buat grafik 3D dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via .NET. Atur rotasi, proporsi tinggi, kedalaman grafik, dan jarak antar seri dengan contoh Python."
---
## **Gambaran Umum**

Aspose.Slides untuk Python via .NET memungkinkan Anda menyesuaikan tampilan grafik 3D melalui properti [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/). Artikel ini menunjukkan cara mengatur rotasi, proporsi tinggi, kedalaman, sumbu sudut kanan, dan jarak antar seri, kemudian menyimpan presentasi dalam format PPTX.

## **Menetapkan Rotasi dan Kedalaman Grafik 3D**

Contoh di bawah membuat sebuah [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dan menggunakan [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) untuk menambahkan grafik kolom 3D bertumpuk ke slide pertama. Ia mengganti seri dan kategori default dengan dua seri yang masing‑masing berisi tiga nilai. Indeks lembar kerja `0` mengidentifikasi lembar data pertama grafik; baris `0` berisi nama seri, dan kolom `0` berisi label kategori.

Properti [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) dan [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) mengatur rotasi grafik menjadi 40 dan 270 derajat secara berurutan. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) menetapkan kedalaman menjadi 150 % dari lebarnya, sementara [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) mengaktifkan sumbu sudut kanan alih‑alih perspektif. Presentasi yang dihasilkan berisi grafik yang telah diisi dengan pengaturan tampilan 3D ini.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Proporsi Tinggi Grafik 3D**

Gunakan [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) untuk mengatur tinggi grafik 3D sebagai persentase lebarannya. Ini mengubah proporsi adegan 3D tanpa mengubah ukuran objek grafik pada slide.

Contoh berikut membuat grafik [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) dengan data default: tiga seri dan empat kategori. Ia menyimpan tiga presentasi dengan proporsi tinggi 50 %, 100 %, dan 200 %. Posisi, lebar, dan tinggi grafik tetap tetap. Data, rotasi, kedalaman, jarak seri, dan pemformatan identik di ketiga file; hanya persentase tinggi yang berubah.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Gambar‑gambar berikut diekspor dari presentasi yang dihasilkan menggunakan Microsoft PowerPoint. Persentase yang lebih kecil menghasilkan adegan yang lebih datar, sedangkan persentase yang lebih besar menghasilkan adegan yang lebih tinggi dalam objek grafik yang sama. PowerPoint juga dapat menyesuaikan interval tick sumbu dan penempatan label agar sesuai dengan adegan.

| Tinggi: 50% | Tinggi: 100% | Tinggi: 200% |
| --- | --- | --- |
| ![grafik kolom 3D dengan tinggi diatur menjadi 50 persen dari lebarnya](height_percent_50.png) | ![grafik kolom 3D dengan tinggi diatur menjadi 100 persen dari lebarnya](height_percent_100.png) | ![grafik kolom 3D dengan tinggi diatur menjadi 200 persen dari lebarnya](height_percent_200.png) |

Properti‑properti ini mengontrol aspek yang berbeda dari grafik:

| Properti | Efek |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Tinggi adegan 3D sebagai persentase dari lebarnya. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Tinggi objek grafik pada slide, dalam poin. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Kedalaman adegan 3D sebagai persentase dari lebarnya. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |

Pengaturan tinggi memengaruhi grafik kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramid, serta grafik garis, area, pai, dan permukaan 3D. Perbandingan di atas menggunakan tipe `COLUMN_3D` yang telah diverifikasi. Pengaturan ini tidak mengubah tampilan grafik 2D `CLUSTERED_COLUMN` atau grafik `BUBBLE_WITH_3D`; nama‑nama ini merupakan anggota enumerasi [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Untuk pengaturan tampilan grafik lainnya, lihat [Chart Formatting](/slides/id/python-net/chart-formatting/).

## **Menyesuaikan Jarak Antara Seri**

Gunakan [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) untuk mengontrol jarak antar seri data sepanjang sumbu kedalaman grafik 3D, dinyatakan sebagai persentase lebar penanda. Gunakan nilai **0 sampai 500**, inklusif: `0` menghilangkan jarak, sedangkan nilai yang lebih besar meningkatkan spasi. Dengan kedalaman grafik yang tetap, meningkatkan jarak membuat penanda menjadi lebih tipis sepanjang sumbu kedalaman.

Akses grup melalui [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Pengaturan ini berlaku untuk setiap seri dalam grup tersebut, bukan hanya seri yang digunakan untuk mengaksesnya. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) bersifat read‑only dan mencerminkan pengaturan grup induk.

Pengaturan ini memengaruhi grafik kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramid, serta grafik garis dan area 3D. Penampilan tergantung pada apakah seri diatur dalam kedalaman, dikelompokkan, atau ditumpuk. Untuk perbandingan yang jelas tentang jarak antar seri terpisah, gunakan `ChartType.COLUMN_3D` dari enumerasi [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Properti‑properti ini mengontrol aspek yang berbeda dari grafik:

| Properti | Efek |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Jarak antar kumpulan batang atau kolom yang berdekatan, sebagai persentase lebar batang atau kolom. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Kedalaman keseluruhan grafik, sebagai persentase lebar grafik. |

Contoh mandiri berikut menggunakan data grafik default, yang berisi tiga seri dan empat kategori. Ia menyimpan dua presentasi dengan data, rotasi, lebar jarak, dan kedalaman grafik yang identik; hanya kedalaman jarak yang berubah.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Gambar‑gambar berikut diekspor dari presentasi yang dihasilkan menggunakan Microsoft PowerPoint.

| Kedalaman jarak: 0% | Kedalaman jarak: 500% |
| --- | --- |
| ![grafik kolom 3D tanpa jarak antar seri sepanjang sumbu kedalaman](gap_depth_0.png) | ![grafik kolom 3D dengan jarak 500 persen antar seri sepanjang sumbu kedalaman](gap_depth_500.png) |

## **Mengubah Tipe Seri 3D dan Bentuk Batang**

Dalam grafik silinder berkelompok, seri pertama dimulai dengan batang silinder. Contoh ini membaca [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) dan [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) sebelum dan sesudah setiap perubahan.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Ubah ke seri pertama | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Buat grafik | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Setel `type` ke `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Setel `bar_3d_shape` ke `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Menetapkan bentuk menjadi `BOX` juga mengubah tipe seri menjadi `CLUSTERED_COLUMN_3D`. Jika kode Anda bercabang berdasarkan tipe seri, baca `series.type` setelah mengubah bentuk. Nilai yang di‑cache sebelum penugasan masih akan memilih cabang `CLUSTERED_CONE`.

![perbandingan PowerPoint yang menampilkan seri pertama sebagai silinder, kerucut, dan kolom persegi panjang dari kiri ke kanan](series-shapes.png)

## **FAQ**

**Tipe grafik apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari grafik kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100 % Stacked Column 3D, serta tipe 3D terkait yang diekspos melalui enumerasi [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Untuk daftar yang tepat dan terkini, periksa anggota [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) dalam referensi API versi yang Anda instal.

**Bisakah saya mendapatkan gambar raster grafik 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor grafik ke gambar dengan [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) atau [merender seluruh slide](/slides/id/python-net/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda membutuhkan pratinjau raster atau ingin menyematkan grafik ke dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa bagus kinerja pembuatan dan rendering grafik 3D besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil terbaik, minimalkan efek 3D, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke output berukuran sesuai (resolusi dan dimensi) untuk mencocokkan tampilan atau kebutuhan cetak target.