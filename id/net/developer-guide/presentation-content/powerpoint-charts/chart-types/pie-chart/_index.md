---
title: Sesuaikan Diagram Lingkaran dalam Presentasi di .NET
linktitle: Diagram Lingkaran
type: docs
url: /id/net/pie-chart/
keywords:
- diagram lingkaran
- kelola diagram
- kustomisasi diagram
- opsi diagram
- pengaturan diagram
- opsi plot
- warna irisan
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat dan sesuaikan diagram lingkaran di .NET dengan Aspose.Slides. Konfigurasikan plot sekunder, tampilkan label data, dan terapkan warna irisan otomatis di PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan diagram lingkaran di Aspose.Slides. Artikel ini menunjukkan cara mengonfigurasi opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie, serta cara mengaktifkan pewarnaan irisan otomatis untuk diagram lingkaran standar.

Contoh-contoh berfokus pada tugas penyesuaian diagram seperti menambahkan diagram ke slide, menyesuaikan pengaturan seri dan label, mengganti data diagram bawaan dengan kategori dan nilai khusus, serta menyimpan presentasi yang diperbarui.

## **Opsi Plot Sekunder untuk Diagram Pie of Pie dan Bar of Pie**

Aspose.Slides for .NET mendukung opsi plot sekunder untuk diagram Pie of Pie dan Bar of Pie. Opsi-opsi ini mengontrol ukuran plot sekunder dan cara titik data dibagi antara dua plot.

Contoh berikut membuat diagram Pie of Pie dalam presentasi baru dan menampilkan nilai titik data sebagai label. Properti [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) mengatur ukuran plot sekunder menjadi 149% dari plot utama. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) memilih pemisahan berbasis persentase, dan [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) mengatur ambang batas menjadi 53%.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Pilih Kategori untuk Plot Sekunder**

Gunakan pemisahan kustom ketika Anda ingin mengelompokkan kategori tertentu dalam plot sekunder tanpa mempedulikan nilai persentasenya. Misalnya, laporan penjualan mungkin menampilkan Online dan Events bersama-sama sehingga pembaca dapat membandingkan dua saluran ini, meskipun mereka menyumbang 35% dan 10% dari total penjualan.

Setel [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) ke [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) dan pilih titik melalui [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). Metode [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) pada koleksi menerima baik indeks berbasis nol dalam seri maupun objek titik data. Dalam contoh ini, indeks 1 memilih Online, dan titik pada indeks 3 memilih Events. Partners juga ditambahkan sementara, kemudian dikeluarkan menggunakan [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Ganti data default dengan penjualan per saluran.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Pilih Online berdasarkan indeks nol dan Events berdasarkan objek titik data.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Kecualikan Partners dari pemilihan tanpa menghapus data sumbernya.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) dan Events (10) muncul sebagai irisan terpisah di plot sekunder. Di plot utama, mereka diwakili oleh satu irisan gabungan dengan nilai 45, bersama dengan Retail (40) dan Partners (15). Menghapus Partners dari pilihan kustom mempertahankannya di plot utama; itu tidak menghapus kategori atau nilainya dari data sumber diagram.

Gambar berikut menunjukkan presentasi yang disimpan di PowerPoint:

![Diagram Pie of Pie dengan Online dan Events di plot sekunder dan nilai gabungan mereka 45 di plot utama](pie_of_pie_custom.png)

## **Atur Warna Irisan Diagram Lingkaran Otomatis**

Aspose.Slides for .NET dapat secara otomatis menetapkan warna berbeda ke irisan diagram lingkaran. Contoh berikut membuat diagram lingkaran dengan judul terpusat dan mengganti data bawaan dengan tiga kategori kuartalan serta nilai-nilainya. Properti [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) menampilkan nilai 20, 50, dan 30 sebagai label, sementara [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) mengaktifkan warna yang berbeda untuk setiap irisan.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Tambahkan judul diagram yang dipusatkan.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Ganti data default menggunakan lembar kerja pertama.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Tampilkan nilai dan tetapkan warna berbeda untuk setiap irisan.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **Tanya Jawab**

**Apakah variasi Pie of Pie dan Bar of Pie didukung?**

Ya, perpustakaan [mendukung](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) plot sekunder untuk diagram lingkaran, termasuk tipe Pie of Pie dan Bar of Pie.

**Apakah saya dapat mengekspor hanya diagram sebagai gambar (misalnya, PNG)?**

Ya, Anda dapat [mengekspor diagram itu sendiri sebagai gambar](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (seperti PNG) tanpa mengekspor seluruh presentasi.