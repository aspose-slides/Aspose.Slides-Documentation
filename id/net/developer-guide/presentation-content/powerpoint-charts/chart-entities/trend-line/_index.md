---
title: Menambahkan Garis Tren ke Bagan Presentasi di .NET
linktitle: Garis Tren
type: docs
url: /id/net/trend-line/
keywords:
- bagan
- garis tren
- garis tren eksponensial
- garis tren linear
- garis tren logaritmik
- garis tren rata-rata bergerak
- garis tren polinomial
- garis tren pangkat
- garis tren kustom
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tambahkan dan sesuaikan garis tren pada bagan PowerPoint dengan Aspose.Slides untuk .NET secara cepat — panduan praktis untuk melibatkan audiens Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan garis tren ke bagan presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuat bagan, menambahkan garis tren ke seri bagan, dan bekerja dengan beberapa jenis garis tren, termasuk eksponensial, linear, logaritmik, rata‑rata bergerak, polinomial, dan pangkat.

Artikel ini juga menjelaskan cara menambahkan garis kustom ke bagan dengan menyisipkan bentuk garis, dan menyertakan FAQ singkat tentang nilai proyeksi garis tren maju dan mundur serta apakah garis tren dipertahankan saat mengekspor ke PDF atau SVG dan saat merender bagan sebagai gambar.

## **Menambahkan Garis Tren**
Aspose.Slides for .NET menyediakan API sederhana untuk mengelola berbagai Garis Tren Bagan:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Tambahkan bagan dengan data default beserta tipe yang diinginkan (contoh ini menggunakan ChartType.ClusteredColumn).
1. Menambahkan garis tren eksponensial untuk seri bagan 1.
1. Menambahkan garis tren linear untuk seri bagan 1.
1. Menambahkan garis tren logaritmik untuk seri bagan 2.
1. Menambahkan garis tren rata‑rata bergerak untuk seri bagan 2.
1. Menambahkan garis tren polinomial untuk seri bagan 3.
1. Menambahkan garis tren pangkat untuk seri bagan 3.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

Kode berikut digunakan untuk membuat bagan dengan Garis Tren.

```c#
// Membuat presentasi kosong
Presentation pres = new Presentation();

// Membuat bagan kolom berkelompok
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Menambahkan garis tren eksponensial untuk seri bagan 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Menambahkan garis tren linear untuk seri bagan 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Menambahkan garis tren logaritmik untuk seri bagan 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Menambahkan garis tren rata‑rata bergerak untuk seri bagan 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Menambahkan garis tren polinomial untuk seri bagan 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Menambahkan garis tren pangkat untuk seri bagan 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Menyimpan presentasi
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **Menambahkan Garis Kustom**
Aspose.Slides for .NET menyediakan API sederhana untuk menambahkan garis kustom dalam bagan. Untuk menambahkan garis polos sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah berikut:

- Buat sebuah instance dari kelas Presentation
- Dapatkan referensi slide dengan menggunakan Index-nya
- Buat bagan baru menggunakan metode AddChart yang disediakan oleh objek Shapes
- Tambahkan AutoShape tipe Line menggunakan metode AddAutoShape yang disediakan oleh objek Shapes
- Atur warna (Color) garis bentuk.
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX

Kode berikut digunakan untuk membuat bagan dengan Garis Kustom.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apa arti 'forward' dan 'backward' pada garis tren?**

Itu adalah panjang garis tren yang diproyeksikan ke depan/belakang: untuk chart scatter (XY) — dalam satuan sumbu; untuk chart non‑scatter — dalam jumlah kategori. Hanya nilai non‑negatif yang diizinkan.

**Apakah garis tren akan dipertahankan saat mengekspor presentasi ke PDF atau SVG, atau saat merender slide menjadi gambar?**

Ya. Aspose.Slides mengonversi presentasi ke [PDF](/slides/id/net/convert-powerpoint-to-pdf/)/[SVG](/slides/id/net/render-a-slide-as-an-svg-image/) dan merender bagan menjadi gambar; garis tren, sebagai bagian dari bagan, dipertahankan selama operasi tersebut. Sebuah metode juga tersedia untuk [export an image of the chart](/slides/id/net/create-shape-thumbnails/) itu sendiri.