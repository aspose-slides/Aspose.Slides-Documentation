---
title: Menambahkan Garis Tren ke Diagram Presentasi di .NET
linktitle: Garis Tren
type: docs
url: /id/net/trend-line/
keywords:
- diagram
- garis tren
- garis tren eksponensial
- garis tren linear
- garis tren logaritmik
- garis tren rata‑rata bergerak
- garis tren polinomial
- garis tren pangkat
- garis tren khusus
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tambahkan dan sesuaikan garis tren dengan cepat dalam diagram PowerPoint menggunakan Aspose.Slides untuk .NET — panduan praktis untuk menarik perhatian audiens Anda."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menambahkan garis tren ke diagram presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuat diagram, menambahkan garis tren ke seri diagram, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linear, logaritmik, rata‑rata bergerak, polinomial, dan pangkat.

Artikel ini juga menjelaskan cara menambahkan garis khusus ke diagram dengan menyisipkan bentuk garis, serta menyertakan FAQ singkat tentang nilai proyeksi garis tren ke depan dan ke belakang serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan saat merender diagram sebagai gambar.

## **Menambahkan Garis Tren**

Gunakan [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) untuk menambahkan garis tren ke seri diagram, memilih jenisnya dengan [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). Contoh ini membuat diagram kolom berkelompok dengan data default dan menambahkan dua garis tren ke masing‑masing dari tiga serinya.

Garis tren eksponensial menyembunyikan persamaan dan nilai R‑squared melalui [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) dan [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), sementara garis tren linear berwarna merah. Garis tren logaritmik menggunakan [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) untuk label khusus. Rata‑rata bergerak menggunakan [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) tiga titik data dan [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/) khusus.

Garis tren polinomial memiliki [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) tiga dan memperluas satu kategori ke depan melalui [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). Garis tren pangkat memperluas satu kategori ke belakang melalui [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **Mengatur Intersep Garis Tren**

Gunakan [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) untuk menetapkan nilai Y intersep garis tren pada X = 0. Pengaturan ini didukung untuk garis tren linear, eksponensial, dan polinomial.

Sebagai contoh, model biaya produksi mungkin perlu dimulai dengan biaya tetap yang diketahui sebesar 100, meskipun pengukuran pada volume produksi non‑nol menunjukkan garis dasar yang berbeda. Untuk garis tren linear, menetapkan intersep memaksa persamaan `y = ax + b` menjadi `b = 100`; kemiringan dipasang ke data dengan kendala tersebut. Ini tidak sekadar memindahkan garis yang sudah terpasang. Pengaturan perpotongan sumbu mengontrol dimana sumbu diagram bertemu, bukan koefisien garis tren yang dipasang.

Contoh berikut membuat diagram sebar (XY) dengan volume produksi 1 sampai 4 dan biaya 170, 200, 230, dan 260. Diagram disimpan dengan intersep otomatis default, kemudian intersep diatur ke 100, dan disimpan PPTX kedua. Kedua file hanya berbeda pada pengaturan intersep. Garis tren menampilkan persamaannya dan memperpanjang kembali hingga X = 0.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

Dengan perhitungan otomatis, data ini menghasilkan `y = 30x + 140`. Menetapkan intersep menjadi 100 menghasilkan kira‑kira `y = 43.33x + 100`: nilai terpasang pada nol cocok dengan basis yang diketahui, sementara garis tidak lagi melewati setiap titik data.

| Intersep otomatis | Intersep tetap 100 |
| --- | --- |
| ![Garis tren linear dengan intercept yang dihitung otomatis sebesar 140](intercept-automatic.png) | ![Garis tren linear dengan intercept tetap sebesar 100](intercept-fixed.png) |

Kedua gambar menggunakan data dan skala sumbu yang sama. Garis tren diperpanjang kembali hingga X = 0 untuk memperlihatkan intersepnya.

Secara bawaan, properti berisi `double.NaN`, yang mewakili intersep yang tidak ditentukan bukan nol. Intersep kemudian dihitung secara otomatis dari data.

## **Menambahkan Garis Khusus**

Garis khusus adalah bentuk yang digambar di atas diagram, bukan garis tren yang dihitung dari data seri. Contoh ini menggunakan [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) untuk menambahkan garis horizontal ke slide di atas diagram. Posisi garis ditentukan dalam koordinat slide, diukur dalam poin, sehingga mulai dari tepi kiri diagram dan berada setengah tinggi diagram. Lebarnya cocok dengan lebar diagram. [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) memberi garis warna merah solid.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apa arti 'forward' dan 'backward' pada sebuah garis tren?**

Kedua nilai tersebut merupakan panjang garis tren yang diproyeksikan ke depan/ke belakang: untuk diagram sebar (XY) — dalam satuan sumbu; untuk diagram non‑sebar — dalam jumlah kategori. Hanya nilai non‑negatif yang diizinkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide menjadi gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/net/convert-powerpoint-to-pdf/) atau [SVG](/slides/id/net/render-a-slide-as-an-svg-image/) dan merender diagram ke gambar; garis tren, sebagai bagian dari diagram, dipertahankan selama operasi tersebut. Sebuah metode juga tersedia untuk [mengekspor gambar diagram](/slides/id/net/create-shape-thumbnails/).