---
title: Buat atau Perbarui Grafik Presentasi PowerPoint di .NET
linktitle: Buat atau Perbarui Grafik
type: docs
weight: 10
url: /id/net/create-chart/
keywords:
- menambahkan grafik
- membuat grafik
- mengedit grafik
- mengubah grafik
- memperbarui grafik
- grafik scatter
- grafik pie
- grafik garis
- grafik tree map
- grafik saham
- grafik box and whisker
- grafik funnel
- grafik sunburst
- grafik histogram
- grafik radar
- grafik multi kategori
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat dan sesuaikan grafik dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET. Tambahkan, format, dan edit grafik dengan contoh kode praktis dalam C#."
---
## **Ikhtisar**

Artikel ini memberikan panduan komprehensif tentang cara membuat dan menyesuaikan grafik menggunakan Aspose.Slides untuk .NET. Anda akan belajar cara menambahkan grafik secara programatik ke slide, mengisi data, dan menerapkan berbagai opsi pemformatan untuk memenuhi kebutuhan desain spesifik Anda. Sepanjang artikel, contoh kode yang mendetail menggambarkan setiap langkah, mulai dari menginisialisasi presentasi dan objek grafik hingga mengonfigurasi seri, sumbu, dan legenda. Dengan mengikuti panduan ini, Anda akan memperoleh pemahaman solid tentang cara mengintegrasikan pembuatan grafik dinamis ke dalam aplikasi .NET Anda, menyederhanakan proses pembuatan presentasi berbasis data.

## **Membuat Grafik**

Grafik membantu orang dengan cepat memvisualisasikan data dan memperoleh wawasan yang mungkin tidak langsung terlihat dari tabel atau spreadsheet.

**Mengapa Membuat Grafik?**

Dengan menggunakan grafik, Anda dapat:

* menggabungkan, memadatkan, atau menyimpulkan sejumlah besar data pada satu slide dalam presentasi;
* menampilkan pola dan tren dalam data;
* menentukan arah dan momentum data seiring waktu atau terhadap satuan ukuran tertentu;
* mengidentifikasi outlier, penyimpangan, deviasi, kesalahan, dan data yang tidak masuk akal;
* mengkomunikasikan atau menyajikan data yang kompleks.

Di PowerPoint, Anda dapat membuat grafik melalui fungsi *Insert*, yang menyediakan templat untuk merancang banyak jenis grafik. Dengan Aspose.Slides, Anda dapat membuat grafik reguler (berdasarkan tipe grafik populer) maupun grafik khusus.

{{% alert color="info" %}} 
Gunakan enumerasi [ChartType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/charttype/) di dalam namespace [Aspose.Slides.Charts](https://reference.aspose.com/slides/id/net/aspose.slides.charts/). Nilai‑nilai dalam enumerasi ini sesuai dengan berbagai tipe grafik.
{{% /alert %}} 

### **Membuat Grafik Kolom Berkelompok**

Bagian ini menjelaskan cara membuat grafik kolom berkelompok menggunakan Aspose.Slides untuk .NET. Anda akan belajar menginisialisasi presentasi, menambahkan grafik, dan menyesuaikan elemennya seperti judul, data, seri, kategori, dan gaya. Ikuti langkah‑langkah di bawah ini untuk melihat bagaimana grafik kolom berkelompok standar dihasilkan:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Tambahkan grafik dengan beberapa data dan tentukan tipe `ChartType.ClusteredColumn`.
1. Tambahkan judul ke grafik.
1. Akses worksheet data grafik.
1. Hapus semua seri dan kategori default.
1. Tambahkan seri dan kategori baru.
1. Tambahkan data grafik baru untuk seri grafik.
1. Terapkan warna isian pada seri grafik.
1. Tambahkan label pada seri grafik.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat grafik kolom berkelompok:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Instansiasikan kelas Presentation.
using (Presentation presentation = new Presentation())
{
    // Akses slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan grafik kolom berkelompok dengan data defaultnya.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Atur judul grafik.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Atur indeks lembar data grafik.
    int worksheetIndex = 0;

    // Dapatkan workbook data grafik.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Hapus seri dan kategori yang dihasilkan secara default.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Tambahkan seri baru.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Tambahkan kategori baru.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Dapatkan seri grafik pertama.
    IChartSeries series = chart.ChartData.Series[0];

    // Isi data seri.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Atur warna isian untuk seri.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Dapatkan seri grafik kedua.
    series = chart.ChartData.Series[1];

    // Isi data seri.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Atur warna isian untuk seri.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Atur label pertama untuk menampilkan nama kategori.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Atur seri untuk menampilkan nilai pada label ketiga.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Simpan presentasi ke disk sebagai file PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The Clustered Column chart](clustered_column_chart.png)

### **Membuat Grafik Scatter**

Grafik scatter (juga dikenal sebagai scatter plot atau grafik x‑y) sering digunakan untuk memeriksa pola atau menunjukkan korelasi antara dua variabel.

Gunakan grafik scatter ketika:

* Anda memiliki data numerik berpasangan.
* Anda memiliki dua variabel yang berpasangan dengan baik.
* Anda ingin menentukan apakah dua variabel tersebut saling berhubungan.
* Anda memiliki variabel independen yang memiliki banyak nilai untuk variabel dependen.

Kode C# ini menunjukkan cara membuat grafik scatter dengan serangkaian penanda yang berbeda:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Instansiasikan kelas Presentation.
using (Presentation presentation = new Presentation())
{
    // Akses slide pertama.
    ISlide slide = presentation.Slides[0];

    // Buat grafik scatter default.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Atur indeks lembar data grafik.
    int worksheetIndex = 0;

    // Dapatkan workbook data grafik.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Hapus seri default.
    chart.ChartData.Series.Clear();

    // Tambahkan seri baru.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // Dapatkan seri grafik pertama.
    IChartSeries series = chart.ChartData.Series[0];

    // Tambahkan titik baru (1:3) ke seri.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Tambahkan titik baru (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // Ubah tipe seri.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // Ubah penanda seri grafik.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // Dapatkan seri grafik kedua.
    series = chart.ChartData.Series[1];

    // Tambahkan titik baru (5:2) ke seri grafik.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Tambahkan titik baru (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Tambahkan titik baru (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Tambahkan titik baru (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Ubah penanda seri grafik.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Simpan presentasi ke disk sebagai file PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The Scatter chart](scatter_chart.png)

### **Membuat Grafik Pie**

Grafik pie paling cocok untuk menunjukkan hubungan bagian‑dengan‑keseluruhan dalam data, terutama ketika data berisi label kategorikal dengan nilai numerik. Namun, bila data Anda memiliki banyak bagian atau label, Anda mungkin ingin mempertimbangkan menggunakan grafik batang sebagai gantinya.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Tambahkan grafik dengan data default dan tentukan tipe `ChartType.Pie`.
1. Akses workbook data grafik ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
1. Hapus seri dan kategori default.
1. Tambahkan seri dan kategori baru.
1. Tambahkan data grafik baru untuk seri grafik.
1. Tambahkan titik baru untuk grafik dan terapkan warna khusus pada sektor grafik pie.
1. Atur label untuk seri.
1. Aktifkan garis penunjuk (leader lines) untuk label seri.
1. Atur sudut rotasi untuk grafik pie.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat grafik pie:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Instansiasikan kelas Presentation.
using (Presentation presentation = new Presentation())
{
    // Akses slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan grafik dengan data defaultnya.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Atur judul grafik.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Atur seri pertama untuk menampilkan nilai.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Atur indeks lembar data grafik.
    int worksheetIndex = 0;

    // Dapatkan workbook data grafik.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Hapus seri dan kategori yang dihasilkan secara default.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Tambahkan kategori baru.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Tambahkan seri baru.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Isi data seri.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Atur warna sektor.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Atur batas sektor.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Atur batas sektor.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Atur batas sektor.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // Buat label khusus untuk setiap kategori dalam seri baru.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // Atur seri untuk menampilkan garis penunjuk pada grafik.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Atur sudut rotasi untuk sektor grafik pie.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Simpan presentasi ke disk sebagai file PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The Pie chart](pie_chart.png)

### **Membuat Grafik Garis**

Grafik garis (juga dikenal sebagai line graph) paling cocok digunakan ketika Anda ingin menunjukkan perubahan nilai seiring waktu. Dengan grafik garis, Anda dapat membandingkan sejumlah besar data sekaligus, melacak perubahan dan tren seiring waktu, menyoroti anomali dalam seri data, dan lain‑lain.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Tambahkan grafik dengan data default dan tentukan tipe `ChartType.Line`.
1. Akses workbook data grafik ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
1. Hapus seri dan kategori default.
1. Tambahkan seri dan kategori baru.
1. Tambahkan data grafik baru untuk seri grafik.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat grafik garis:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Secara default, titik pada grafik garis dihubungkan oleh garis lurus kontinu. Jika Anda ingin titik‑titik tersebut dihubungkan oleh garis putus‑putus, Anda dapat menentukan tipe dash yang diinginkan seperti berikut:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    foreach (IChartSeries series in lineChart.ChartData.Series)
    {
        series.Format.Line.DashStyle = LineDashStyle.Dash;
    }
}
```

Hasilnya:

![The Line chart](line_chart.png)

### **Membuat Grafik Tree Map**

Grafik tree map paling cocok untuk data penjualan ketika Anda ingin menunjukkan ukuran relatif kategori data dan dengan cepat menarik perhatian ke item yang menjadi kontributor besar dalam setiap kategori.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Tambahkan grafik dengan data default dan tentukan tipe `ChartType.Treemap`.
1. Akses workbook data grafik ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
1. Hapus seri dan kategori default.
1. Tambahkan seri dan kategori baru.
1. Tambahkan data grafik baru untuk seri grafik.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat grafik tree map:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Cabang 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Cabang 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The Treemap chart](treemap_chart.png)

### **Membuat Grafik Saham**

Grafik saham digunakan untuk menampilkan data keuangan seperti harga pembukaan, tertinggi, terendah, dan penutupan, membantu menganalisis tren pasar dan volatilitas. Grafik ini memberikan wawasan penting tentang kinerja saham, membantu investor dan analis membuat keputusan yang tepat.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Tambahkan grafik dengan data default dan tentukan tipe `ChartType.OpenHighLowClose`.
1. Akses workbook data grafik ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
1. Hapus seri dan kategori default.
1. Tambahkan seri dan kategori baru.
1. Tambahkan data grafik baru untuk seri grafik.
1. Tentukan format HiLowLines.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat grafik saham:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The Stock chart](stock_chart.png)

### **Membuat Grafik Box and Whisker**

Grafik Box and Whisker digunakan untuk menampilkan distribusi data dengan merangkum ukuran statistik utama, seperti median, kuartil, dan kemungkinan outlier. Grafik ini sangat berguna dalam analisis data eksploratori dan studi statistik untuk dengan cepat memahami variabilitas data dan mengidentifikasi anomali.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Tambahkan grafik dengan data default dan tentukan tipe `ChartType.BoxAndWhisker`.
1. Akses workbook data grafik ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
1. Hapus seri dan kategori default.
1. Tambahkan seri dan kategori baru.
1. Tambahkan data grafik baru untuk seri grafik.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat grafik box and whisker:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **Membuat Grafik Funnel**

Grafik funnel digunakan untuk memvisualisasikan proses yang melibatkan tahapan berurutan, di mana volume data berkurang saat bergerak dari satu langkah ke langkah berikutnya. Grafik ini sangat membantu untuk menganalisis tingkat konversi, mengidentifikasi bottleneck, dan melacak efisiensi proses penjualan atau pemasaran.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Tambahkan grafik dengan data default dan tentukan tipe `ChartType.Funnel`.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat grafik funnel:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The Funnel chart](funnel_chart.png)

### **Membuat Grafik Sunburst**

Grafik sunburst digunakan untuk memvisualisasikan data hierarkis, menampilkan level sebagai cincin konsentrik. Grafik ini membantu menggambarkan hubungan bagian‑dengan‑keseluruhan dan ideal untuk merepresentasikan kategori bersarang serta sub‑kategori dalam format yang jelas dan kompak.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Tambahkan grafik dengan data default dan tentukan tipe `ChartType.Sunburst`.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat grafik sunburst:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Cabang 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Cabang 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The Sunburst chart](sunburst_chart.png)

### **Membuat Grafik Histogram**

Grafik histogram digunakan untuk merepresentasikan distribusi data numerik dengan mengelompokkan nilai ke dalam rentang atau bin. Grafik ini sangat berguna untuk mengidentifikasi pola data seperti frekuensi, kemiringan, dan penyebaran, serta mendeteksi outlier dalam kumpulan data.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Tambahkan grafik dengan beberapa data dan tentukan tipe `ChartType.Histogram`.
1. Akses workbook data grafik ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
1. Hapus seri dan kategori default.
1. Tambahkan seri dan kategori baru.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat grafik histogram:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The Histogram chart](histogram_chart.png)

### **Membuat Grafik Radar**

Grafik radar digunakan untuk menampilkan data multivariat dalam format dua dimensi, memungkinkan perbandingan beberapa variabel secara simultan. Grafik ini sangat berguna untuk mengidentifikasi pola, kekuatan, dan kelemahan di antara berbagai metrik atau atribut kinerja.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Tambahkan grafik dengan beberapa data dan tentukan tipe `ChartType.Radar`.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat grafik radar:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The Radar chart](radar_chart.png)

### **Membuat Grafik Multi‑Kategori**

Grafik multi‑kategori digunakan untuk menampilkan data yang melibatkan lebih dari satu pengelompokan kategorikal, memungkinkan Anda membandingkan nilai di beberapa dimensi sekaligus. Grafik ini sangat membantu ketika Anda perlu menganalisis tren dan hubungan dalam kumpulan data yang kompleks dan berlapis.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Tambahkan grafik dengan data default dan tentukan tipe `ChartType.ClusteredColumn`.
1. Akses workbook data grafik ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)).
1. Hapus seri dan kategori default.
1. Tambahkan seri dan kategori baru.
1. Tambahkan data grafik baru untuk seri grafik.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara membuat grafik multi‑kategori:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // Tambahkan sebuah seri.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // Simpan presentasi dengan grafik.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The multi category chart](multi_category_chart.png)

### **Membuat Grafik Peta**

Grafik peta digunakan untuk memvisualisasikan data geografis dengan memetakan informasi ke lokasi tertentu seperti negara, provinsi, atau kota. Grafik ini sangat berguna untuk menganalisis tren regional, data demografis, dan distribusi spasial secara jelas dan menarik secara visual.

Kode C# ini menunjukkan cara membuat grafik peta:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The Map chart](map_chart.png)

{{% alert color="info" %}} 
Gambar di atas menunjukkan presentasi yang disimpan dibuka di PowerPoint. Aspose.Slides menulis grafik peta dan datanya dengan benar, tetapi tidak menggambar grafik peta secara langsung: ketika slide yang berisi grafik peta dirender menjadi gambar atau dikonversi ke PDF atau SVG, area grafik muncul kosong. Bentuk lain pada slide yang sama tidak terpengaruh.
{{% /alert %}} 

### **Membuat Grafik Kombinasi**

Grafik kombinasi (atau combo chart) menggabungkan dua atau lebih tipe grafik dalam satu grafik. Grafik ini memungkinkan Anda menyoroti, membandingkan, atau memeriksa perbedaan antara dua atau lebih set data, membantu mengidentifikasi hubungan di antara mereka.

![The combination chart](combination_chart.png)

Kode C# berikut menunjukkan cara membuat grafik kombinasi seperti yang ditampilkan di atas dalam presentasi PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Mengatur judul grafik
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Mengatur legenda grafik
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // Menghapus seri dan kategori yang dihasilkan secara default
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Menambahkan kategori baru
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // Tambahkan seri pertama
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // Mengatur sumbu horizontal
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // Mengatur sumbu vertikal
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Mengatur warna garis kisi utama vertikal
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // Mengatur sumbu horizontal sekunder
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // Mengatur sumbu vertikal sekunder
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Memperbarui Grafik**

Aspose.Slides untuk .NET memungkinkan Anda memperbarui grafik PowerPoint dengan memodifikasi data, pemformatan, dan gaya grafik. Fungsionalitas ini menyederhanakan proses menjaga presentasi tetap terkini dengan konten dinamis dan memastikan grafik mencerminkan data serta standar visual terkini.

1. Instansiasikan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang mewakili presentasi yang berisi grafik.
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Telusuri semua shape untuk menemukan grafik.
1. Akses worksheet data grafik.
1. Modifikasi seri data grafik dengan mengubah nilai seri.
1. Tambahkan seri baru dan isi datanya.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara memperbarui grafik:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Instansiasikan kelas Presentation yang mewakili file PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Akses slide pertama.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Atur indeks lembar data grafik.
            int worksheetIndex = 0;

            // Dapatkan workbook data grafik.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Ubah nama kategori grafik.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Dapatkan seri grafik pertama.
            IChartSeries series = chart.ChartData.Series[0];

            // Perbarui data seri.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Memodifikasi nama seri.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // Dapatkan seri grafik kedua.
            series = chart.ChartData.Series[1];

            // Perbarui data seri.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Memodifikasi nama seri.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Tambahkan seri baru.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Isi data seri.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // Simpan presentasi dengan grafik.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **Menetapkan Rentang Data untuk Grafik**

Aspose.Slides untuk .NET menyediakan fleksibilitas untuk menentukan rentang data spesifik dari lembar kerja sebagai sumber data grafik Anda. Ini berarti Anda dapat memetakan bagian lembar kerja langsung ke grafik, memungkinkan kontrol atas sel mana yang berkontribusi pada seri dan kategori grafik. Sebagai hasilnya, Anda dapat dengan mudah memperbarui dan menyinkronkan grafik dengan perubahan data terbaru di lembar kerja, memastikan presentasi PowerPoint Anda mencerminkan informasi yang akurat dan terkini.

1. Instansiasikan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) yang mewakili presentasi yang berisi grafik.
1. Dapatkan referensi ke slide menggunakan indeksnya.
1. Telusuri semua shape untuk menemukan grafik.
1. Akses data grafik dan tetapkan rentangnya.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# ini menunjukkan cara menetapkan rentang data untuk grafik:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Instansiasikan kelas Presentation yang mewakili file PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Akses slide pertama.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **Menggunakan Penanda Default dalam Grafik**

Ketika Anda menggunakan penanda default dalam grafik, setiap seri grafik secara otomatis mendapatkan simbol penanda default yang berbeda.

Kode C# ini menunjukkan cara mengatur penanda seri grafik secara otomatis:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // Isi data seri.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Tipe grafik apa yang didukung oleh Aspose.Slides untuk .NET?

Aspose.Slides untuk .NET mendukung beragam tipe grafik, termasuk bar, line, pie, area, scatter, histogram, radar, dan banyak lagi. Fleksibilitas ini memungkinkan Anda memilih tipe grafik yang paling sesuai untuk kebutuhan visualisasi data Anda.

### Bagaimana cara menambahkan grafik baru ke slide?

Untuk menambahkan grafik, pertama buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation), ambil slide yang diinginkan menggunakan indeksnya, lalu panggil metode untuk menambahkan grafik, dengan menentukan tipe grafik dan data awal. Proses ini mengintegrasikan grafik secara langsung ke dalam presentasi Anda.

### Bagaimana saya dapat memperbarui data yang ditampilkan dalam grafik?

Anda dapat memperbarui data grafik dengan mengakses workbook datanya ([IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/)), menghapus seri dan kategori default, lalu menambahkan data khusus Anda. Ini memungkinkan Anda menyegarkan grafik secara programatik agar mencerminkan data terbaru.

### Apakah memungkinkan untuk menyesuaikan tampilan grafik?

Ya, Aspose.Slides untuk .NET menyediakan opsi kustomisasi yang luas. Anda dapat memodifikasi warna, font, label, legenda, dan elemen pemformatan lainnya untuk menyesuaikan tampilan grafik dengan persyaratan desain spesifik Anda.