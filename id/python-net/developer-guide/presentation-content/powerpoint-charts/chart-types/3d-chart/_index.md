---
title: Sesuaikan Diagram 3D dalam Presentasi dengan Python
linktitle: Diagram 3D
type: docs
url: /id/python-net/3d-chart/
keywords:
- diagram 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Buat diagram 3D dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via .NET. Atur rotasi, proporsi tinggi, kedalaman diagram, dan jarak antar seri dengan contoh Python."
---
## **Ikhtisar**

Aspose.Slides for Python via .NET memungkinkan Anda menyesuaikan tampilan diagram 3D melalui properti [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/). Artikel ini menunjukkan cara mengatur rotasi, proporsi tinggi, kedalaman, sumbu sudut kanan, dan jarak antar seri, kemudian menyimpan presentasi dalam format PPTX.

## **Atur Rotasi dan Kedalaman Diagram 3D**

Contoh di bawah ini membuat sebuah [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dan menggunakan [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) untuk menambahkan diagram kolom 3D bertumpuk ke slide pertama. Ia mengganti seri dan kategori default dengan dua seri yang masing‑masing berisi tiga nilai. Indeks lembar kerja `0` mengidentifikasi lembar data pertama diagram; baris `0` berisi nama seri, dan kolom `0` berisi label kategori.

Properti [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) dan [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) mengatur rotasi diagram menjadi 40 dan 270 derajat masing‑masing. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) menetapkan kedalaman menjadi 150% dari lebarnya, sementara [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) mengaktifkan sumbu sudut kanan alih‑alih perspektif. Presentasi yang dihasilkan berisi diagram yang telah diisi dengan pengaturan tampilan 3D ini.

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

## **Terapkan Isian Gambar pada Permukaan Diagram 3D**

Anda dapat mengisi [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/), dan [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) diagram 3D secara terpisah. Atur [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) permukaan menjadi `PICTURE` dan tentukan gambar. Agar satu salinan gambar menutupi seluruh permukaan, atur baik [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) maupun [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) menjadi `STRETCH`.

Simpan [arrow.png](arrow.png) di direktori kerja. Contoh ini memutar diagram dan menaikkan nilai maksimum pada sumbu vertikal sehingga lantai terlihat di antara kolom. Ia menggandakan slide dua kali, lalu menerapkan panah pada permukaan yang berbeda di setiap slide. Ketiga diagram berbagi data, sudut pandang, dan latar belakang yang sama.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint menampilkan tiga slide sebagai berikut.

| Dinding samping | Dinding belakang | Lantai |
| --- | --- | --- |
| ![Panah mengarah ke dalam diagram sepanjang dinding samping](side-wall.png) | ![Panah mengarah kanan melintasi dinding belakang](back-wall.png) | ![Panah mengarah kanan melintasi lantai di antara kolom](floor.png) |

## **Sesuaikan Proporsi Tinggi Diagram 3D**

Gunakan [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) untuk menetapkan tinggi diagram 3D sebagai persentase lebar diagram. Ini mengubah proporsi adegan 3D tanpa mengubah ukuran objek diagram pada slide.

Contoh berikut membuat diagram [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) dengan data default: tiga seri dan empat kategori. Ia menyimpan tiga presentasi dengan proporsi tinggi 50 %, 100 %, dan 200 %. Posisi, lebar, dan tinggi diagram tetap tetap. Data, rotasi, kedalaman, jarak seri, dan pemformatan identik di ketiga file; hanya persentase tinggi yang berubah.

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

Gambar berikut diekspor dari presentasi yang dihasilkan menggunakan Microsoft PowerPoint. Persentase yang lebih kecil menghasilkan adegan yang lebih datar, sementara persentase yang lebih besar menghasilkan adegan yang lebih tinggi dalam objek diagram yang sama. PowerPoint juga dapat menyesuaikan interval tanda sumbu dan penempatan label agar pas dengan adegan.

| Tinggi: 50% | Tinggi: 100% | Tinggi: 200% |
| --- | --- | --- |
| ![Diagram kolom 3D dengan tinggi diatur 50 persen dari lebarnya](height_percent_50.png) | ![Diagram kolom 3D dengan tinggi diatur 100 persen dari lebarnya](height_percent_100.png) | ![Diagram kolom 3D dengan tinggi diatur 200 persen dari lebarnya](height_percent_200.png) |

Properti‑properti ini mengontrol aspek yang berbeda dari diagram:

| Properti | Efek |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Tinggi adegan 3D sebagai persentase dari lebarnya. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Tinggi objek diagram pada slide, dalam poin. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Kedalaman adegan 3D sebagai persentase dari lebarnya. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |

Pengaturan tinggi memengaruhi diagram kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta diagram garis, area, pai, dan permukaan 3D. Perbandingan di atas menggunakan tipe `COLUMN_3D` yang terverifikasi. Pengaturan ini tidak mengubah tampilan diagram 2D `CLUSTERED_COLUMN` atau diagram `BUBBLE_WITH_3D`; nama‑nama tersebut merupakan anggota enumerasi [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Untuk pengaturan tampilan diagram lainnya, lihat [Chart Formatting](/slides/id/python-net/chart-formatting/).

## **Sesuaikan Celah Antar Seri**

Gunakan [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) untuk mengendalikan jarak antar seri data sepanjang sumbu kedalaman diagram 3D, dinyatakan sebagai persentase lebar penanda. Gunakan nilai dari **0 sampai 500**, termasuk: `0` menghilangkan celah, sedangkan nilai yang lebih besar meningkatkan jarak. Dengan kedalaman diagram tetap, meningkatkan celah membuat penanda lebih tipis sepanjang sumbu kedalaman.

Akses grup melalui [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). Pengaturan ini berlaku untuk setiap seri dalam grup tersebut, bukan hanya seri yang digunakan untuk mengaksesnya. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) bersifat baca‑saja dan mencerminkan pengaturan grup induk.

Pengaturan ini memengaruhi diagram kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta diagram garis dan area 3D. Penampilan tergantung pada apakah seri disusun dalam kedalaman, berkelompok, atau ditumpuk. Untuk perbandingan yang jelas tentang celah antar seri terpisah, gunakan `ChartType.COLUMN_3D` dari enumerasi [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Properti‑properti ini mengontrol aspek yang berbeda dari diagram:

| Properti | Efek |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Jarak antar kelompok batang atau kolom berdekatan, sebagai persentase lebar batang atau kolom. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Kedalaman keseluruhan diagram, sebagai persentase lebar diagram. |

Contoh mandiri berikut menggunakan data diagram default, yang berisi tiga seri dan empat kategori. Ia menyimpan dua presentasi dengan data, rotasi, lebar celah, dan kedalaman diagram yang identik; hanya kedalaman celah yang berubah.

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

Gambar berikut diekspor dari presentasi yang dihasilkan menggunakan Microsoft PowerPoint.

| Kedalaman celah: 0% | Kedalaman celah: 500% |
| --- | --- |
| ![Diagram kolom 3D tanpa celah antar seri sepanjang sumbu kedalaman](gap_depth_0.png) | ![Diagram kolom 3D dengan celah 500 persen antar seri sepanjang sumbu kedalaman](gap_depth_500.png) |

## **Ubah Tipe Seri 3D dan Bentuk Batang**

Dalam diagram silinder berkelompok, seri pertama dimulai dengan batang silinder. Contoh ini membaca [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) dan [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) sebelum dan sesudah setiap perubahan.

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

| Ubah pada seri pertama | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Buat diagram | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Setel `type` menjadi `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Setel `bar_3d_shape` menjadi `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Mengatur bentuk menjadi `BOX` juga mengubah tipe seri menjadi `CLUSTERED_COLUMN_3D`. Jika kode Anda bercabang berdasarkan tipe seri, bacalah `series.type` setelah mengubah bentuk. Nilai yang di‑cache sebelum penetapan masih akan memilih cabang `CLUSTERED_CONE`.

![Perbandingan PowerPoint menunjukkan seri pertama sebagai silinder, kerucut, dan kolom persegi panjang dari kiri ke kanan](series-shapes.png)

## **FAQ**

**Jenis diagram apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari diagram kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100 % Stacked Column 3D, serta tipe 3D terkait yang diungkapkan melalui enumerasi [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) dalam referensi API versi yang Anda instal.

**Bisakah saya mendapatkan gambar raster dari diagram 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor diagram ke gambar dengan [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) atau [render seluruh slide](/slides/id/python-net/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda memerlukan pratinjau raster atau ingin menyematkan diagram ke dalam dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja pembuatan dan rendering diagram 3D yang besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil terbaik, batasi efek 3D, hindari tekstur berat pada dinding dan area plot, kurangi jumlah titik data per seri bila memungkinkan, dan render ke ukuran output yang sesuai (resolusi dan dimensi) untuk memenuhi kebutuhan tampilan atau cetak target.