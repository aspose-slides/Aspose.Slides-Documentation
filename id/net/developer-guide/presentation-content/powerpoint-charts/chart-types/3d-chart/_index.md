---
title: Sesuaikan Diagram 3D dalam Presentasi di .NET
linktitle: Diagram 3D
type: docs
url: /id/net/3d-chart/
keywords:
- diagram 3D
- rotasi
- kedalaman
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat diagram 3D dalam presentasi PowerPoint dengan Aspose.Slides untuk .NET. Atur rotasi, proporsi tinggi, kedalaman diagram, dan jarak antar seri dengan contoh C#."
---
## **Ikhtisar**

Aspose.Slides for .NET memungkinkan Anda menyesuaikan tampilan diagram 3D melalui properti [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/). Artikel ini menunjukkan cara menyesuaikan rotasi, proporsi tinggi, kedalaman, sumbu sudut kanan, dan jarak antar seri, kemudian menyimpan presentasi dalam format PPTX.

## **Atur Rotasi dan Kedalaman Diagram 3D**

Contoh di bawah ini membuat sebuah [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) dan menggunakan [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) untuk menambahkan diagram kolom 3D bertumpuk ke slide pertama. Ia mengganti seri dan kategori bawaan dengan dua seri yang masing‑masing berisi tiga nilai. Indeks lembar kerja `0` menunjukkan lembar data pertama diagram; baris `0` berisi nama seri, dan kolom `0` berisi label kategori.

Properti [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) dan [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) mengatur rotasi diagram menjadi 40 dan 270 derajat masing‑masing. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) menetapkan kedalamannya menjadi 150 % dari lebarnya, sementara [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) mengaktifkan sumbu sudut kanan alih‑alih perspektif. Presentasi yang dihasilkan berisi diagram yang telah diisi dengan pengaturan tampilan 3D ini.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Terapkan Isi Gambar pada Permukaan Diagram 3D**

Diagram 3D memiliki tiga permukaan yang dapat Anda isi secara independen: [dinding samping](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), [dinding belakang](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/), dan [lantai](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). Atur [tipe isi](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) permukaan yang dipilih menjadi `Picture` dan berikan gambar. Atur baik [mode isi gambar](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) maupun [tipe gambar](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) permukaan menjadi `Stretch` agar satu salinan gambar menutupi seluruh permukaan.

Simpan [arrow.png](arrow.png) di direktori kerja. Contoh ini memutar diagram dan meningkatkan nilai maksimum pada sumbu vertikal sehingga lantai terlihat di antara kolom. Kemudian contoh ini menggandakan slide dua kali sebelum menerapkan panah ke permukaan yang berbeda pada setiap slide. Ketiga diagram mempertahankan data, sudut pandang, dan latar belakang yang sama.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

Microsoft PowerPoint menampilkan ketiga slide sebagai berikut.

| Dinding samping | Dinding belakang | Lantai |
| --- | --- | --- |
| ![Panah menunjuk ke dalam diagram di sepanjang dinding samping](side-wall.png) | ![Panah menunjuk ke kanan melintasi dinding belakang](back-wall.png) | ![Panah menunjuk ke kanan melintasi lantai di antara kolom](floor.png) |

## **Sesuaikan Proporsi Tinggi Diagram 3D**

Gunakan [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) untuk menetapkan tinggi diagram 3D sebagai persentase lebar. Ini mengubah proporsi adegan 3D tanpa mengubah ukuran objek diagram pada slide.

Contoh berikut membuat diagram [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) dengan data bawaan: tiga seri dan empat kategori. Ia menyimpan tiga presentasi dengan proporsi tinggi 50 %, 100 %, dan 200 %. Posisi, lebar, dan tinggi diagram tetap tetap. Data, rotasi, kedalaman, jarak antar seri, dan format identik di ketiga file; hanya persentase tinggi yang berubah.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

Gambar berikut diekspor dari presentasi yang dihasilkan menggunakan Microsoft PowerPoint. Persentase yang lebih kecil menghasilkan adegan yang lebih datar, sementara persentase yang lebih besar menghasilkan adegan yang lebih tinggi dalam objek diagram yang sama. PowerPoint juga dapat menyesuaikan interval tanda sumbu dan penempatan label agar sesuai dengan adegan.

| Tinggi: 50% | Tinggi: 100% | Tinggi: 200% |
| --- | --- | --- |
| ![Diagram kolom 3D dengan tinggi 50 % dari lebarnya](height_percent_50.png) | ![Diagram kolom 3D dengan tinggi 100 % dari lebarnya](height_percent_100.png) | ![Diagram kolom 3D dengan tinggi 200 % dari lebarnya](height_percent_200.png) |

Properti‑properti ini mengontrol aspek yang berbeda dari diagram:

| Properti | Efek |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Tinggi adegan 3D sebagai persentase lebar. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Tinggi objek diagram pada slide, dalam poin. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Kedalaman adegan 3D sebagai persentase lebar. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Jarak antar seri pada sumbu kedalaman, sebagai persentase lebar penanda. |

Pengaturan tinggi memengaruhi diagram kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta diagram garis, area, pai, dan permukaan 3D. Perbandingan di atas menggunakan tipe terverifikasi `Column3D`. Pengaturan ini tidak mengubah tampilan diagram 2D `ClusteredColumn` atau diagram `BubbleWith3D`; nama‑nama tersebut merupakan anggota enumerasi [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Untuk pengaturan tampilan diagram lainnya, lihat [Chart Formatting](/slides/id/net/chart-formatting/).

## **Sesuaikan Jarak Antara Seri**

Gunakan [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) untuk mengontrol jarak antar seri data pada sumbu kedalaman diagram 3D, dinyatakan sebagai persentase lebar penanda. Gunakan nilai antara **0 hingga 500**, inklusif: `0` menghilangkan celah, sementara nilai yang lebih besar meningkatkan jarak. Dengan kedalaman diagram tetap, meningkatkan celah membuat penanda menjadi lebih tipis pada sumbu kedalaman.

Akses grup melalui [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Pengaturan ini berlaku untuk setiap seri dalam grup tersebut, bukan hanya seri yang digunakan untuk mengaksesnya. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) hanya dapat dibaca dan mencerminkan pengaturan grup induk.

Pengaturan ini memengaruhi diagram kolom dan batang 3D, termasuk varian silinder, kerucut, dan piramida, serta diagram garis dan area 3D. Penampilan bergantung pada apakah seri diatur dalam kedalaman, berkelompok, atau ditumpuk. Untuk perbandingan jelas tentang celah antar seri terpisah, gunakan `ChartType.Column3D` dari enumerasi [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Properti‑properti ini mengontrol aspek yang berbeda dari diagram:

| Properti | Efek |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Jarak antar seri pada sumbu kedalaman, sebagai persentase lebar penanda. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Jarak antar grup batang atau kolom yang berdekatan, sebagai persentase lebar batang atau kolom. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Kedalaman total diagram, sebagai persentase lebar diagram. |

Contoh mandiri berikut menggunakan data diagram bawaan, yang berisi tiga seri dan empat kategori. Ia menyimpan dua presentasi dengan data, rotasi, lebar celah, dan kedalaman diagram yang identik; hanya kedalaman celah yang berubah.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

Gambar berikut diekspor dari presentasi yang dihasilkan menggunakan Microsoft PowerPoint.

| Kedalaman celah: 0% | Kedalaman celah: 500% |
| --- | --- |
| ![Diagram kolom 3D tanpa celah antar seri pada sumbu kedalaman](gap_depth_0.png) | ![Diagram kolom 3D dengan celah 500 % antar seri pada sumbu kedalaman](gap_depth_500.png) |

## **Ubah Tipe Seri 3D dan Bentuk Batang**

Pada diagram silinder berkelompok, seri pertama dimulai dengan bentuk batang silinder. Contoh ini membaca [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) dan [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) sebelum dan sesudah setiap perubahan.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| Perubahan pada seri pertama | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Buat diagram | `ClusteredCylinder` | `Cylinder` |
| Atur `Type` menjadi `ClusteredCone` | `ClusteredCone` | `Cone` |
| Atur `Bar3DShape` menjadi `Box` | `ClusteredColumn3D` | `Box` |

Mengatur bentuk menjadi `Box` juga mengubah tipe seri menjadi `ClusteredColumn3D`. Jika kode Anda bercabang berdasarkan tipe seri, bacalah `series.Type` setelah mengubah bentuk. Nilai yang dicache sebelum penugasan masih akan memilih cabang `ClusteredCone`.

![Perbandingan PowerPoint menampilkan seri pertama sebagai silinder, kerucut, dan kolom persegi panjang dari kiri ke kanan](series-shapes.png)

## **FAQ**

**Jenis diagram apa yang mendukung mode 3D di Aspose.Slides?**

Aspose.Slides mendukung varian 3D dari diagram kolom, termasuk Column 3D, Clustered Column 3D, Stacked Column 3D, dan 100 % Stacked Column 3D, serta tipe 3D terkait yang diekspos melalui enumerasi [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Untuk daftar yang tepat dan terbaru, periksa anggota [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) dalam referensi API versi yang Anda instal.

**Bisakah saya mendapatkan gambar raster diagram 3D untuk laporan atau web?**

Ya. Anda dapat mengekspor diagram ke gambar dengan [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) atau [render seluruh slide](/slides/id/net/convert-powerpoint-to-png/) ke format seperti PNG atau JPEG. Ini berguna ketika Anda memerlukan pratinjau raster atau ingin menyematkan diagram ke dokumen, dasbor, atau halaman web tanpa memerlukan PowerPoint.

**Seberapa baik kinerja pembuatan dan rendering diagram 3D yang besar?**

Kinerja tergantung pada volume data dan kompleksitas visual. Untuk hasil optimal, pertahankan efek 3D seminimal mungkin, hindari tekstur berat pada dinding dan area plot, batasi jumlah titik data per seri bila memungkinkan, dan render ke ukuran output yang sesuai (resolusi dan dimensi) untuk mencocokkan tampilan atau kebutuhan cetak target.