---
title: Sesuaikan Diagram 3D dalam Presentasi Menggunakan Python
linktitle: Diagram 3D
type: docs
url: /id/python-java/3d-chart/
keywords:
- diagram 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat diagram 3D dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via Java. Sesuaikan rotasi, proporsi tinggi, kedalaman diagram, dan jarak antar seri dengan contoh Python."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java memungkinkan Anda menyesuaikan tampilan diagram 3D melalui metode [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D). Artikel ini menunjukkan cara mengatur rotasi, proporsi tinggi, kedalaman, sumbu sudut kanan, dan jarak antar seri, kemudian menyimpan presentasi dalam format PPTX.

## **Mengatur Rotasi dan Kedalaman Diagram 3D**

Contoh di bawah membuat sebuah [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) dan menggunakan [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) untuk menambahkan diagram kolom 3D bertumpuk pada slide pertama. Ia menggantikan seri dan kategori default dengan dua seri yang masing‑masing berisi tiga nilai. Indeks lembar kerja `0` mengidentifikasi lembar data pertama diagram; baris `0` berisi nama seri, dan kolom `0` berisi label kategori.

Metode [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) dan [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) mengatur rotasi diagram menjadi 40 dan 270 derajat, masing‑masing. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) menetapkan kedalamannya menjadi 150 % dari lebar, sedangkan [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) mengaktifkan sumbu sudut kanan alih‑alih perspektif. Presentasi yang dihasilkan berisi diagram yang sudah diisi dengan pengaturan tampilan 3D ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menerapkan Isi Gambar pada Permukaan Diagram 3D**

Diagram 3D memiliki tiga permukaan yang dapat diisi secara terpisah: [dinding samping](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall), [dinding belakang](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall), dan [lantai](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor). Atur [tipe isi](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) permukaan menjadi `Picture` dan beri gambar. Setel baik [mode isi gambar](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) maupun [tipe gambar](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) permukaan menjadi `Stretch` agar satu salinan gambar menutupi seluruh permukaan.

Simpan [arrow.png](arrow.png) di direktori kerja. Contoh ini memutar diagram dan meningkatkan nilai maksimum pada sumbu vertikal sehingga lantai terlihat di antara kolom. Kemudian contoh ini menggandakan slide dua kali dan menerapkan panah ke permukaan yang berbeda pada setiap slide. Ketiga diagram menjaga data, sudut pandang, dan latar belakang yang sama.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Microsoft PowerPoint menampilkan tiga slide sebagai berikut.

| Dinding samping | Dinding belakang | Lantai |
| --- | --- | --- |
| ![Panah menunjuk ke dalam diagram di dinding samping](side-wall.png) | ![Panah menunjuk ke kanan melintasi dinding belakang](back-wall.png) | ![Panah menunjuk ke kanan melintasi lantai di antara kolom](floor.png) |

## **Mengatur Proporsi Tinggi Diagram 3D**

Gunakan [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) untuk mengatur tinggi diagram 3D sebagai persentase lebar. Ini mengubah proporsi adegan 3D tanpa mengubah ukuran objek diagram pada slide.

Contoh berikut membuat diagram [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) dengan data default: tiga seri dan empat kategori. Ia menyimpan tiga presentasi dengan proporsi tinggi 50 %, 100 %, dan 200 %. Posisi, lebar, dan tinggi diagram tetap tetap. Data, rotasi, kedalaman, jarak antar seri, dan pemformatan identik pada ketiga file; hanya persentase tinggi yang berubah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gambar berikut menggambarkan pengaturan tinggi yang sama pada contoh .NET yang setara dan diekspor menggunakan Microsoft PowerPoint. Persentase yang lebih kecil menghasilkan adegan yang lebih datar, sementara persentase yang lebih besar menghasilkan adegan yang lebih tinggi dalam objek diagram yang sama. PowerPoint juga dapat menyesuaikan interval tanda pada sumbu dan penempatan label agar sesuai dengan adegan.

| Tinggi: 50% | Tinggi: 100% | Tinggi: 200% |
| --- | --- | --- |
| ![Diagram kolom 3D dengan tinggi 50 % dari lebarnya](height_percent_50.png) | ![Diagram kolom 3D dengan tinggi 100 % dari lebarnya](height_percent_100.png) | ![Diagram kolom 3D dengan tinggi 200 % dari lebarnya](height_percent_200.png) |

Metode‑metode ini mengontrol aspek berbeda dari diagram:

| Metode | Efek |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Tinggi adegan 3D sebagai persentase lebar. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Tinggi objek diagram pada slide, dalam poin. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Kedalaman adegan 3D sebagai persentase lebar. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |

Pengaturan tinggi memengaruhi diagram kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta diagram garis, area, pai, dan permukaan 3D. Perbandingan di atas menggunakan tipe `Column3D` yang telah diverifikasi. Pengaturan ini tidak mengubah tampilan diagram `ClusteredColumn` 2D atau diagram `BubbleWith3D`; nama‑nama tersebut merupakan anggota kelas [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Untuk pengaturan tampilan diagram lain, lihat [Chart Formatting](/slides/id/python-java/chart-formatting/).

## **Mengatur Jarak Antar Seri**

Gunakan [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) untuk mengontrol jarak antar seri data sepanjang sumbu kedalaman diagram 3D, dinyatakan sebagai persentase lebar penanda. Gunakan nilai antara **0 hingga 500**, inklusif: `0` menghilangkan celah, sedangkan nilai yang lebih besar meningkatkan jarak. Dengan kedalaman diagram tetap, meningkatkan celah membuat penanda menjadi lebih tipis sepanjang sumbu kedalaman.

Akses grup melalui [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). Pengaturan ini berlaku untuk setiap seri dalam grup tersebut, bukan hanya seri yang digunakan untuk mengaksesnya. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) mengembalikan celah kedalaman dan mencerminkan pengaturan grup induk.

Pengaturan ini memengaruhi diagram kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta diagram garis dan area 3D. Penampilan tergantung pada apakah seri diatur dalam kedalaman, berkelompok, atau bertumpuk. Untuk perbandingan jelas tentang celah antar seri terpisah, gunakan `ChartType.Column3D` dari kelas [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/).

Metode‑metode ini mengontrol aspek berbeda dari diagram:

| Metode | Efek |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Jarak antar seri sepanjang sumbu kedalaman, sebagai persentase lebar penanda. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Jarak antar klaster batang atau kolom yang berdekatan, sebagai persentase lebar batang atau kolom. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Kedalaman keseluruhan diagram, sebagai persentase lebar diagram. |

Contoh mandiri berikut menggunakan data diagram default, yang berisi tiga seri dan empat kategori. Ia menyimpan dua presentasi dengan data, rotasi, lebar celah, dan kedalaman diagram yang identik; hanya kedalaman celah yang berubah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gambar berikut menggambarkan pengaturan kedalaman celah yang sama pada contoh .NET yang setara dan diekspor menggunakan Microsoft PowerPoint.

| Kedalaman celah: 0% | Kedalaman celah: 500% |
| --- | --- |
| ![Diagram kolom 3D tanpa celah antar seri sepanjang sumbu kedalaman](gap_depth_0.png) | ![Diagram kolom 3D dengan celah 500 % antar seri sepanjang sumbu kedalaman](gap_depth_500.png) |

## **Mengubah Tipe Seri 3D dan Bentuk Batang**

Pada diagram silinder berkelompok, seri pertama dimulai dengan bentuk batang silinder. Contoh mencetak nilai integer yang dikembalikan oleh [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) dan [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) sebelum dan sesudah setiap perubahan. Tabel memberikan nama konstanta yang bersesuaian.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Perubahan pada seri pertama | Tipe seri | Bentuk batang |
| --- | --- | --- |
| Membuat diagram | `ClusteredCylinder` | `Cylinder` |
| Mengatur tipe seri menjadi `ClusteredCone` | `ClusteredCone` | `Cone` |
| Mengatur bentuk batang menjadi `Box` | `ClusteredColumn3D` | `Box` |

Mengatur bentuk menjadi `Box` juga mengubah tipe seri menjadi `ClusteredColumn3D`. Jika kode Anda bercabang berdasarkan tipe seri, panggil `series.getType()` setelah mengubah bentuk. Nilai yang disimpan sebelumnya sebelum penetapan masih akan memilih cabang `ClusteredCone`.

![Perbandingan PowerPoint yang menunjukkan seri pertama sebagai silinder, kerucut, dan kolom persegi panjang dari kiri ke kanan](series-shapes.png)

## **FAQ**

**Jenis diagram apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari diagram kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100 % Stacked Column 3D, serta tipe 3D terkait yang tersedia melalui kelas [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) dalam referensi API versi yang Anda instal.

**Bisakah saya mendapatkan gambar raster dari diagram 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor diagram ke gambar dengan [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) atau [merender seluruh slide](/slides/id/python-java/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda memerlukan pratinjau raster atau ingin menyisipkan diagram ke dalam dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja pembuatan dan render diagram 3D yang besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil optimal, pertahankan efek 3D seminimal mungkin, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke ukuran output yang sesuai (resolusi dan dimensi) untuk mencocokkan tampilan atau kebutuhan cetak target.