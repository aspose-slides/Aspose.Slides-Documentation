---
title: Kelola Label Data Grafik dalam Presentasi di .NET
linktitle: Label Data
type: docs
url: /id/net/chart-data-label/
keywords:
- grafik
- label data
- presisi data
- persentase
- jarak label
- posisi label
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara menambahkan dan memformat label data grafik dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET agar slide lebih menarik."
---
## **Pendahuluan**

Label data menampilkan informasi tentang seri grafik dan titik data individual, membantu pembaca mengidentifikasi nilai dan memahami grafik. Artikel ini menjelaskan cara memformat nilai, menampilkan persentase, membaca teks label, mengontrol label di luar nilai maksimum sumbu, menyesuaikan jarak label sumbu kategori, dan memposisikan label grafik lingkaran.

## **Mengatur Presisi Data pada Label Data Grafik**

Gunakan [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) untuk memformat nilai seri. Contoh ini membuat grafik garis dengan data default, menampilkan tabel datanya, dan mengaktifkan label nilai untuk seri pertama. Format `#,##0.00` menampilkan pemisah ribuan dan dua tempat desimal tanpa mengubah nilai sebenarnya.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

## **Menampilkan Persentase sebagai Label**

Untuk grafik kolom bertumpuk, hitung setiap nilai sebagai persentase dari total kategori dan tetapkan teks ke [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). Contoh ini menggunakan data grafik default dan menampilkan persentase dengan dua tempat desimal dalam font 8 poin. Kategori dengan total nol dilewati untuk menghindari pembagian dengan nol. Hitung ulang teks label khusus jika data grafik berubah.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Menetapkan Tanda Persentase pada Label Data Grafik**

Ketika nilai disimpan sebagai pecahan, gunakan [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) untuk menampilkan persentase. Atur [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) ke `false` untuk menerapkan format label secara independen dari sel sumber.

Contoh ini membuat grafik kolom 100% bertumpuk dengan seri merah dan biru pada empat kategori. Setiap pasangan nilai berjumlah 1. Format label `0.0%` menampilkan 0,30 sebagai 30,0%, sementara sumbu vertikal menggunakan dua tempat desimal. Kedua seri menggunakan teks label berwarna putih berukuran 10 poin.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Membaca Teks Aktual dari Label Data**

Gunakan [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) untuk mengambil teks yang dihasilkan oleh pengaturan label data. Ini berguna saat mengekstrak label untuk laporan, mencari konten presentasi, atau memvalidasi grafik yang dihasilkan. Pada contoh di bawah, format [label data](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) default menggabungkan nama kategori, nama seri, dan nilai. Satu titik memformat nilainya sebagai persentase, dan yang lain menggunakan teks khusus dari [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

Angka yang disimpan dalam titik data tetap `0.75`, meskipun labelnya menampilkan `75%` bersama nama kategori dan seri. Teks khusus menggantikan teks label yang dihasilkan. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) mengembalikan string label yang dihasilkan dalam kedua kasus. Periksa [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) secara terpisah, seperti yang ditunjukkan di atas, ketika Anda hanya ingin mengekstrak label yang terlihat.

## **Mengontrol Label Data di Luar Nilai Maksimum Sumbu**

Ketika Anda membatasi rentang sumbu secara manual, beberapa titik data mungkin melebihi nilai maksimum. Gunakan [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) untuk mengontrol apakah label data mereka ditampilkan. Pengaturan ini mengubah visibilitas label; tidak mengubah rentang sumbu atau nilai data yang mendasarinya.

Contoh di bawah membuat grafik kolom berkelompok 2D dengan nilai 60 dan 120. Ia mengatur [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) ke `false` dan [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) ke 100 pada sumbu vertikal. Slide pertama mengizinkan label di luar maksimum; salinan slide tersebut menonaktifkannya. Kedua slide disimpan dalam `DataLabelsOverMaximum.pptx`.

Aktifkan label nilai dengan [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Pengaturan tingkat grafik tidak mengaktifkan tampilan nilai secara otomatis atau menggantikan tampilan nilai yang dinonaktifkan pada label individual. Contoh ini mengaktifkan nilai untuk seluruh seri dan menggunakan [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) untuk menempatkan label di ujung luar masing‑masing kolom.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

Gambar berikut menunjukkan slide yang disimpan dan dirender oleh Microsoft PowerPoint. Dengan `true`, label **120** terlihat pada batas atas; dengan `false`, label tersebut disembunyikan. Label **60** tetap terlihat, nilai maksimum sumbu tetap **100**, dan titik data kedua tetap **120** dalam kedua kasus.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}

Contoh ini menggunakan grafik kolom 2D dengan sumbu nilai. Grafik tanpa sumbu nilai, seperti grafik lingkaran dan donat, tidak memiliki nilai maksimum sumbu untuk dibatasi dengan cara ini.

{{% /alert %}}

## **Mengatur Jarak Label dari Sumbu**

Gunakan [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) untuk mengontrol jarak antara label sumbu kategori dan sumbu. Nilainya adalah persentase dari ukuran font maksimum label sumbu. Contoh ini membuat grafik kolom berkelompok dan mengatur offset label sumbu horizontal ke 500. Pengaturan ini memengaruhi label sumbu kategori, bukan label yang terpasang pada titik data individual.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Menyesuaikan Posisi Label**

Pada grafik lingkaran, sesuaikan posisi label data untuk memperbaiki jarak dan memberi ruang bagi garis penunjuk.

Contoh ini menampilkan nilai titik data pertama, menempatkan labelnya di luar irisan, dan menyesuaikan offset [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) dan [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). Offset ini relatif terhadap lebar dan tinggi grafik masing‑masing.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Memformat Garis Penunjuk**

Ketika label grafik lingkaran berada di luar irisan, garis penunjuk membantu pembaca mencocokkan setiap nilai dengan irisan yang tepat. Warna yang kontras dan garis yang sedikit lebih tebal dapat membuat koneksi ini lebih mudah diikuti, sementara transparansi dan gaya garis putus‑putus menjaga garis tetap tidak mengganggu secara visual.

Gunakan [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) untuk memformat garis penunjuk pada tingkat koleksi label data seri. Pengaturan di `series.Labels.LeaderLinesFormat.Line` berlaku untuk seluruh koleksi, bukan untuk label individual.

Contoh ini membuat grafik lingkaran dengan data default, menampilkan nilai di luar irisan, dan mengaktifkan [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). Ia memindahkan dua label lebih jauh dari irisan mereka menggunakan offset [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) dan [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/), yang dinyatakan sebagai pecahan dari lebar dan tinggi grafik. Tidak diperlukan presentasi masukan.

[FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) garis mengatur warna biru solid dengan nilai alfa 191 dari 255, memberikan transparansi sekitar 25%. [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) mengatur ketebalan menjadi 2 poin, dan [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) membuat garis menjadi putus‑putus.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// Pindahkan dua label lebih jauh dari irisan mereka.
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

Mengaktifkan garis penunjuk tidak menjamin bahwa garis akan muncul untuk setiap label. Visibilitas tergantung pada penempatan label dan perilaku tata letak grafik. Pada contoh ini, dua label yang dipindahkan memiliki garis penunjuk yang terlihat; label yang tetap dekat dengan irisan tidak memerlukannya.

Gambar berikut menunjukkan file `FormattedLeaderLines.pptx` yang disimpan dan dirender dengan Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **Menambahkan Beberapa Baris Label Data di Atas Grafik Kolom**

Contoh ini membuat grafik kolom dengan dua baris label data di atas area plot. Seri A menampilkan kolom yang terlihat, sementara Seri B dan Seri C menyediakan label tambahan. Kolom mereka disembunyikan dengan menghapus isian dan garis tepi. Properti [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) menyelaraskan ketiga seri dengan pusat kategori yang sama.

Pengaturan [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) menyisakan ruang untuk baris label. Setelah [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) menghitung posisi default, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) dan [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) mempertahankan penyelarasan horizontal dan menerapkan offset vertikal untuk menata label dalam dua baris. Angka tetap menjadi label data yang terhubung ke nilai seri; hanya judul baris yang berupa bentuk teks terpisah.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // Sembunyikan kolom B dan C, tetapi pertahankan label data mereka.
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// Selaraskan ketiga seri dengan pusat kategori yang sama.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Gunakan lebih sedikit garis kisi untuk contoh kompak ini.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Sediakan ruang di atas area plot untuk dua baris label data.
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // Pertahankan posisi horizontal default. Y adalah offset dari
        // posisi label default, yang dinyatakan sebagai fraksi tinggi grafik.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Hanya judul baris yang merupakan bentuk teks terpisah.
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **FAQ**

**Bagaimana cara mencegah label data saling bertumpuk pada grafik yang padat?**

Gabungkan penempatan label otomatis, garis penunjuk, dan ukuran font yang lebih kecil; jika perlu, sembunyikan beberapa bidang (misalnya, kategori) atau tampilkan label hanya untuk nilai ekstrem atau titik kunci.

**Bagaimana cara menonaktifkan label hanya untuk nilai nol, negatif, atau kosong?**

Saring titik data sebelum mengaktifkan label dan matikan tampilan untuk nilai 0, nilai negatif, atau nilai yang hilang sesuai aturan yang ditentukan.

**Bagaimana cara memastikan gaya label konsisten saat mengekspor ke PDF/gambar?**

Tetapkan secara eksplisit keluarga dan ukuran font serta verifikasi bahwa font tersedia di lingkungan rendering untuk menghindari fallback.