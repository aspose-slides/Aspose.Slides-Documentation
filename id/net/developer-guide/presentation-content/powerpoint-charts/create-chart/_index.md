---
title: Buat atau Perbarui Grafik Presentasi PowerPoint di .NET
linktitle: Buat atau Perbarui Grafik
type: docs
weight: 10
url: /id/net/create-chart/
keywords:
- tambah grafik
- buat grafik
- edit grafik
- ubah grafik
- perbarui grafik
- grafik sebar
- grafik pai
- grafik garis
- grafik peta pohon
- grafik saham
- grafik kotak dan whisker
- grafik corong
- grafik sunburst
- grafik histogram
- grafik radar
- grafik multi‑kategori
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat dan sesuaikan grafik dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET. Tambahkan, format, dan edit grafik dengan contoh kode praktis dalam C#."
---
## **Gambaran Umum**

Artikel ini menyediakan panduan lengkap tentang cara membuat dan menyesuaikan grafik menggunakan Aspose.Slides untuk .NET. Anda akan mempelajari cara menambahkan grafik secara programatis ke slide, mengisinya dengan data, dan menerapkan berbagai opsi pemformatan untuk memenuhi kebutuhan desain spesifik Anda. Sepanjang artikel, contoh kode terperinci mengilustrasikan setiap langkah, mulai dari inisialisasi presentasi dan objek grafik hingga konfigurasi seri, sumbu, dan legenda. Dengan mengikuti panduan ini, Anda akan memperoleh pemahaman yang kuat tentang cara mengintegrasikan pembuatan grafik dinamis ke dalam aplikasi .NET Anda, mempermudah proses pembuatan presentasi berbasis data.

## **Membuat Grafik**

Grafik membantu orang dengan cepat memvisualisasikan data dan memperoleh wawasan yang mungkin tidak langsung terlihat dari tabel atau spreadsheet.

**Mengapa Membuat Grafik?**

Dengan grafik, Anda dapat:

* menggabungkan, memadatkan, atau merangkum sejumlah besar data pada satu slide dalam presentasi;
* menampilkan pola dan tren dalam data;
* menilai arah dan momentum data seiring waktu atau terhadap satuan pengukuran tertentu;
* menemukan nilai outlier, penyimpangan, kesalahan, dan data yang tidak masuk akal;
* menyampaikan atau mempresentasikan data yang kompleks.

Di PowerPoint, Anda dapat membuat grafik melalui fungsi *Insert*, yang menyediakan templat untuk merancang berbagai jenis grafik. Menggunakan Aspose.Slides, Anda dapat membuat grafik reguler (berdasarkan jenis grafik populer) dan grafik khusus.

{{% alert color="info" title="Note" %}}
Gunakan enumerasi [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) di dalam namespace [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/). Nilai‑nilai dalam enumerasi ini berkorespondensi dengan berbagai jenis grafik.
{{% /alert %}}

### **Membuat Grafik Kolom Berkelompok**

Contoh ini menggunakan [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) untuk membuat grafik kolom berkelompok yang membandingkan dua seri pada tiga kategori. Seri‑serinya menggunakan isian merah dan hijau, dan label individu menampilkan nama kategori, nama seri, serta nilai. Indeks lembar kerja 0 mengacu pada lembar pertama dalam buku kerja grafik yang disematkan.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series[0];

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

series = chart.ChartData.Series[1];

valueCell = workbook.GetCell(worksheetIndex, 1, 2, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 2, 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 2, 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

var label = series.DataPoints[0].Label;
label.DataLabelFormat.ShowCategoryName = true;

label = series.DataPoints[1].Label;
label.DataLabelFormat.ShowSeriesName = true;

label = series.DataPoints[2].Label;
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.ShowSeriesName = true;
label.DataLabelFormat.Separator = "/";

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Grafik Kolom Berkelompok](clustered_column_chart.png)

### **Membuat Grafik Sebar**

Grafik sebar (juga dikenal sebagai scatter plot atau grafik x‑y) sering digunakan untuk memeriksa pola atau menunjukkan korelasi antara dua variabel.

Gunakan grafik sebar ketika:

* Anda memiliki data numerik berpasangan.
* Anda memiliki dua variabel yang saling terkait.
* Anda ingin menentukan apakah dua variabel tersebut berhubungan.
* Anda memiliki variabel independen yang memiliki banyak nilai untuk satu variabel dependen.

Contoh ini memplot dua set nilai x‑y. Seri pertama menggunakan garis lurus dengan penanda bintang, sementara seri kedua menggunakan garis halus dengan penanda lingkaran; keduanya menggunakan [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) sebesar 10. Properti [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/) mengontrol bentuk penanda.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 1, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 1, 3, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var series = chart.ChartData.Series[0];

var xValueCell = workbook.GetCell(worksheetIndex, 2, 1, 1);
var yValueCell = workbook.GetCell(worksheetIndex, 2, 2, 3);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 1, 2);
yValueCell = workbook.GetCell(worksheetIndex, 3, 2, 10);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

series = chart.ChartData.Series[1];

xValueCell = workbook.GetCell(worksheetIndex, 2, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 2, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 3, 3);
yValueCell = workbook.GetCell(worksheetIndex, 3, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 4, 3, 2);
yValueCell = workbook.GetCell(worksheetIndex, 4, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 5, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 5, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Grafik Sebar](scatter_chart.png)

### **Membuat Grafik Pai**

Grafik pai paling cocok untuk menunjukkan hubungan bagian‑dengan‑keseluruhan dalam data, terutama ketika data berisi label kategori dengan nilai numerik. Namun, bila data Anda memiliki banyak bagian atau label, pertimbangkan menggunakan grafik batang sebagai gantinya.

Contoh ini membuat grafik pai dengan tiga nilai kuartalan. Setiap irisan memiliki isian dan tepi khusus, dan label menampilkan kombinasi nilai, persentase, serta informasi seri yang berbeda. Properti [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/) mengatur irisan pertama untuk memulai pada 180 derajat.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var categoryCell = workbook.GetCell(0, 1, 0, "1st Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "2nd Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "3rd Qtr");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForPieSeries(valueCell);

chart.ChartData.SeriesGroups[0].IsColorVaried = true;

var firstSlice = series.DataPoints[0];
firstSlice.Format.Fill.FillType = FillType.Solid;
firstSlice.Format.Fill.SolidFillColor.Color = Color.Cyan;

firstSlice.Format.Line.FillFormat.FillType = FillType.Solid;
firstSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
firstSlice.Format.Line.Width = 3.0;
firstSlice.Format.Line.Style = LineStyle.ThinThick;
firstSlice.Format.Line.DashStyle = LineDashStyle.LargeDash;

var secondSlice = series.DataPoints[1];
secondSlice.Format.Fill.FillType = FillType.Solid;
secondSlice.Format.Fill.SolidFillColor.Color = Color.Brown;

secondSlice.Format.Line.FillFormat.FillType = FillType.Solid;
secondSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
secondSlice.Format.Line.Width = 3.0;
secondSlice.Format.Line.Style = LineStyle.Single;
secondSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

var thirdSlice = series.DataPoints[2];
thirdSlice.Format.Fill.FillType = FillType.Solid;
thirdSlice.Format.Fill.SolidFillColor.Color = Color.Coral;

thirdSlice.Format.Line.FillFormat.FillType = FillType.Solid;
thirdSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
thirdSlice.Format.Line.Width = 2.0;
thirdSlice.Format.Line.Style = LineStyle.ThinThin;
thirdSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

var firstLabel = series.DataPoints[0].Label;
firstLabel.DataLabelFormat.ShowValue = true;

var secondLabel = series.DataPoints[1].Label;
secondLabel.DataLabelFormat.ShowValue = true;
secondLabel.DataLabelFormat.ShowLegendKey = true;
secondLabel.DataLabelFormat.ShowPercentage = true;

var thirdLabel = series.DataPoints[2].Label;
thirdLabel.DataLabelFormat.ShowSeriesName = true;
thirdLabel.DataLabelFormat.ShowPercentage = true;

series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

presentation.Save("PieChart.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Grafik Pai](pie_chart.png)

Untuk meningkatkan keterbacaan label di luar pai, lihat [Format Leader Lines](/slides/id/net/chart-data-label/#format-leader-lines) untuk contoh yang menempatkan label dan menyesuaikan warna, lebar, transparansi, serta gaya garis.

### **Membuat Grafik Garis**

Grafik garis (juga dikenal sebagai line graph) paling cocok untuk situasi di mana Anda ingin memperlihatkan perubahan nilai seiring waktu. Dengan grafik garis, Anda dapat membandingkan sejumlah besar data sekaligus, melacak perubahan dan tren seiring waktu, menyoroti anomali dalam seri data, dan lain‑lain.

Contoh ini menggunakan [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) untuk membuat grafik garis dengan seri dan kategori default, kemudian menyimpan presentasi sebagai PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

Secara default, titik‑titik pada grafik garis dihubungkan oleh garis lurus kontinu. Jika Anda ingin titik‑titik tersebut dihubungkan oleh garis putus‑putus, atur [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) ke nilai dari [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

foreach (var series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Hasilnya:

![Grafik Garis](line_chart.png)

### **Membuat Grafik Peta Pohon**

Grafik peta pohon paling cocok untuk data penjualan ketika Anda ingin memperlihatkan ukuran relatif kategori data dan dengan cepat menarik perhatian ke item yang menjadi kontributor besar dalam tiap kategori.

Contoh ini membuat peta pohon dengan delapan daun yang dikelompokkan menjadi empat batang dan dua cabang. Metode [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) menetapkan batang pada tingkat pengelompokan 1 dan cabang pada tingkat 2. Nilai‑nilai menentukan ukuran relatif persegi panjang, sementara label kategori dan label induk yang tumpang tindih mengidentifikasi hierarki.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Cabang 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Cabang 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Treemap);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);

series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

presentation.Save("Treemap.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Grafik Peta Pohon](treemap_chart.png)

### **Membuat Grafik Air Terjun**

Grafik air terjun menunjukkan bagaimana perubahan positif dan negatif berkontribusi pada nilai akhir. Misalnya, rincian profit dapat dimulai dengan pendapatan, dikurangi biaya, dan ditambah pendapatan lain. Kolom perubahan melayang di antara nilai berjalan sebelumnya dan nilai baru, sedangkan kolom total memperluas dari nol hingga nilai terakumulasi.

Contoh berikut menggunakan jumlah dalam ribuan dolar AS:

| Kategori | Nilai Workbook | Jenis Kolom |
| --- | ---: | --- |
| Pendapatan | 1000 | Peningkatan |
| Harga Pokok Penjualan | -400 | Penurunan |
| Laba Kotor | 600 | Total Interim |
| Beban Operasional | -200 | Penurunan |
| Pendapatan Lain | 50 | Peningkatan |
| Laba Bersih | 450 | Total Akhir |

Untuk menandai titik sebagai total interim atau final, atur properti [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/) menjadi `true`. Isi sel workbook titik tersebut dengan jumlah terakumulasi yang sebenarnya: `600` untuk laba kotor (`1000 - 400`) dan `450` untuk laba bersih (`600 - 200 + 50`). Properti ini menandai kolom sebagai total; ia tidak menghitung atau mengisi nilai sel. Jangan gunakan nol sebagai placeholder atau memberikan perubahan lain untuk titik total. Kolom total menampilkan nilai terakumulasi tanpa menambahkannya lagi ke nilai berjalan.

Contoh C# lengkap ini membuat grafik menggunakan anggota `Waterfall` dari [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/), mengosongkan data default, dan mengisi buku kerja yang disematkan. Indeks lembar kerja `0` memilih lembar pertama; kolom A berisi nama kategori dan kolom B berisi nilai. Setiap sel nilai ditambahkan dengan [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/). Indeks‑indeks titik berbasis nol `2` dan `5` mengidentifikasi total interim dan final. Mengaktifkan [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) menampilkan jumlah pada kolom. Tidak diperlukan presentasi atau buku kerja input.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Waterfall, 20, 20, 680, 200);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Profit breakdown (USD thousands)");
chart.ChartTitle.Overlay = false;
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

workbook.Clear(worksheetIndex);

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Profit");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Waterfall);
var categories = new[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
var values = new double[] { 1000, -400, 600, -200, 50, 450 };

for (var i = 0; i < categories.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categories[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForWaterfallSeries(valueCell);
}

// Titik ketiga dan keenam mewakili total, bukan perubahan tambahan.
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

Atur properti [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) pada level seri menjadi `true` untuk menampilkan garis yang menghubungkan kolom berurutan dan memudahkan pelacakan nilai berjalan. Untuk menyembunyikan garis tersebut, ganti penugasan dalam contoh dengan `series.ShowConnectorLines = false;` sebelum menyimpan. Ini hanya mengubah visibilitas garis, bukan data atau total.

Presentasi yang disimpan menampilkan laba kotor 600 dan laba bersih 450, dengan kedua total dihitung dari nol:

![Grafik Air Terjun yang menampilkan pendapatan, biaya, laba kotor 600, dan laba bersih 450, dengan label nilai dan garis penghubung](waterfall_chart.png)

### **Membuat Grafik Saham**

Grafik saham digunakan untuk menampilkan data keuangan seperti harga pembukaan, tertinggi, terendah, dan penutupan, membantu menganalisis tren pasar dan volatilitas. Grafik ini memberikan wawasan penting tentang kinerja saham, membantu investor dan analis membuat keputusan yang tepat.

Contoh ini membuat grafik Open‑High‑Low‑Close dengan empat seri dalam urutan tersebut dan tiga kategori. Properti [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) mengaktifkan bar naik/turun, dan [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) mengontrol garis high‑low yang menunjukkan rentang harga, sementara garis seri individual dan garis kisi horizontal minor disembunyikan.

Manajer [UpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/updownbars/) mengekspos objek [UpBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/upbarsformat/) dan [DownBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/downbarsformat/) terpisah. Gunakan properti [Fill](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/fill/) dan [Line](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/line/) masing‑masing objek untuk mengatur isian dan outline secara independen. Contoh ini menggunakan bar hijau dengan outline hijau tua untuk interval naik dan bar oranye‑merah dengan outline merah tua untuk interval turun.

Berikan nilai numerik untuk semua empat seri pada tiap kategori, dengan High dan Low melingkupi Open dan Close. Bar membandingkan Close dengan Open **dalam kategori yang sama**, bukan dengan kategori sebelumnya: A turun dari 72 ke 25, sementara B naik dari 25 ke 38 dan C naik dari 38 ke 50. Nilai Open dan Close yang sama menghasilkan interval yang tidak terisi terlihat. Bar naik/turun melintasi Open‑Close; garis high‑low melintasi Low‑High. Bar‑bar ini merupakan bagian dari grup seri dan bukan seri grafik batang biasa.

Pemformatan ini juga berlaku untuk grafik [Line and LineWithMarkers](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) yang berisi setidaknya dua seri dalam grup yang sama dan nilai numerik yang bersesuaian untuk tiap kategori. Untuk grafik garis non‑stacked ini, bar naik/turun membandingkan seri pertama dan terakhir: nilai akhir yang lebih tinggi menghasilkan bar naik, dan nilai akhir yang lebih rendah menghasilkan bar turun. Membalik urutan seri membalik klasifikasinya. Contoh di bawah menggunakan [OpenHighLowClose](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/); jangan berasumsi bahwa varian saham, garis‑stacked, atau 3D lainnya menggunakan susunan data atau interpretasi interval yang sama.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, false);

var workbook = chart.ChartData.ChartDataWorkbook;

var categoryCell = workbook.GetCell(0, 1, 0, "A");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "B");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "C");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Open");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 2, "High");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 3, "Low");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 4, "Close");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);

var series = chart.ChartData.Series[0];
var valueCell = workbook.GetCell(0, 1, 1, 72);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 1, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 1, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[1];
valueCell = workbook.GetCell(0, 1, 2, 172);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[2];
valueCell = workbook.GetCell(0, 1, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 3, 13);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[3];
valueCell = workbook.GetCell(0, 1, 4, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 4, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 4, 50);
series.DataPoints.AddDataPointForStockSeries(valueCell);

var upDownBars = chart.ChartData.SeriesGroups[0].UpDownBars;
upDownBars.HasUpDownBars = true;

upDownBars.UpBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Fill.SolidFillColor.Color = Color.LimeGreen;
upDownBars.UpBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkGreen;
upDownBars.UpBarsFormat.Line.Width = 2;

upDownBars.DownBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Fill.SolidFillColor.Color = Color.OrangeRed;
upDownBars.DownBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkRed;
upDownBars.DownBarsFormat.Line.Width = 2;

chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

Hasil, diekspor dari PowerPoint:

![Grafik Saham dengan interval turun oranye‑merah untuk A dan interval naik hijau untuk B dan C](stock_chart.png)

### **Membuat Grafik Kotak‑dan‑Whisker**

Grafik kotak‑dan‑whisker digunakan untuk menampilkan distribusi data dengan merangkum ukuran statistik utama, seperti median, kuartil, dan potensi outlier. Grafik ini sangat berguna dalam analisis data eksploratori dan studi statistik untuk dengan cepat memahami variabilitas data dan mengidentifikasi anomali.

Contoh ini membuat grafik kotak‑dan‑whisker dari enam nilai. Properti [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) memilih perhitungan kuartil eksklusif. Contoh ini juga mengaktifkan garis rata‑rata, penanda rata‑rata, titik dalam, dan titik outlier.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

series.QuartileMethod = QuartileMethodType.Exclusive;
series.ShowMeanLine = true;
series.ShowMeanMarkers = true;
series.ShowInnerPoints = true;
series.ShowOutlierPoints = true;

var valueCell = workbook.GetCell(0, "B1", 15);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 41);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 10);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 23);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);

presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
```

### **Membuat Grafik Corong**

Grafik corong digunakan untuk memvisualisasikan proses yang melibatkan tahap berurutan, di mana volume data berkurang seiring progres dari satu langkah ke langkah berikutnya. Grafik ini sangat membantu untuk menganalisis tingkat konversi, mengidentifikasi bottleneck, dan melacak efisiensi proses penjualan atau pemasaran.

Contoh ini menggunakan [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) untuk menambahkan grafik corong ke slide pertama dari presentasi yang sudah ada. Grafik tersebut menggantikan data default dengan enam kategori dan nilai mulai dari 50 hingga 500, kemudian menyimpan presentasi yang telah diperbarui. Presentasi input harus berisi setidaknya satu slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Funnel);

var valueCell = workbook.GetCell(0, "B1", 50);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 100);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 200);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 300);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 400);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 500);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);

presentation.Save("Funnel.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Grafik Corong](funnel_chart.png)

### **Membuat Grafik Sunburst**

Grafik sunburst digunakan untuk memvisualisasikan data hierarkis, menampilkan level sebagai cincin konsentris. Grafik ini membantu menggambarkan hubungan bagian‑dengan‑keseluruhan dan ideal untuk merepresentasikan kategori bersarang serta subkategori dalam format yang jelas dan kompak.

Contoh ini membuat grafik sunburst dengan delapan daun yang dikelompokkan menjadi empat batang dan dua cabang. Metode [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) menetapkan batang pada tingkat pengelompokan 1 dan cabang pada tingkat 2. Label kategori mengidentifikasi segmen, dan nilai menentukan ukuran relatifnya.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Cabang 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Cabang 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Sunburst);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);

presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Grafik Sunburst](sunburst_chart.png)

### **Membuat Grafik Histogram**

Grafik histogram menunjukkan bagaimana nilai numerik terdistribusi di antara interval (bin). Untuk laporan bulanan tentang waktu pemrosesan pesanan, gunakan lebar bin dan ambang batas yang sama untuk menjaga konsistensi interval dan memudahkan perbandingan distribusi.

Atur [AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/aggregationtype/) pada sumbu horizontal ke mode dari [AxisAggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axisaggregationtype/). [BinWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/binwidth/) hanya berlaku untuk `ByBinWidth`; [NumberOfBins](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberofbins/) hanya berlaku untuk `ByNumberOfBins`. Gunakan `Automatic` agar grafik memilih bin secara otomatis.

#### **Gunakan Lebar Bin Tetap**

Contoh ini mengelompokkan waktu pemrosesan ke dalam interval 10‑menit, dengan bin terpisah untuk waktu ≤10 menit dan >40 menit. Aktifkan bin‑bin ini dengan [IsUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isunderflowbin/) dan [IsOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isoverflowbin/). Saat menyediakan ambang batas eksplisit untuk [UnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/underflowbin/) dan [OverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/overflowbin/), atur [IsAutomaticUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticunderflowbin/) dan [IsAutomaticOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticoverflowbin/) menjadi `false`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByBinWidth;
axis.BinWidth = 10;
axis.IsUnderflowBin = true;
axis.IsAutomaticUnderflowBin = false;
axis.UnderflowBin = 10;
axis.IsOverflowBin = true;
axis.IsAutomaticOverflowBin = false;
axis.OverflowBin = 40;

presentation.Save("Histogram-bin-width.pptx", SaveFormat.Pptx);
```

Presentasi yang ditampilkan di PowerPoint memperlihatkan jumlah bin **3, 4, 4, 4, dan 2**. Bin underflow mencakup `5, 10, 10`, sehingga ambangnya inklusif. Bin overflow hanya mencakup `41, 50`, sehingga ambangnya eksklusif; kedua nilai sama dengan `40` tetap berada di interval sebelumnya. Bin interior berisi nilai yang lebih besar dari batas bawah dan kurang dari atau sama dengan batas atas.

![Histogram dengan bin 10‑menit dan ambang underflow serta overflow yang eksplisit](histogram_bin_width.png)

#### **Tentukan Jumlah Bin**

Untuk tingkat detail tetap alih‑alih interval tetap, minta lima bin untuk data yang sama. Contoh ini menonaktifkan bin underflow dan overflow. Grafik menentukan lebar dari rentang data, sehingga batas dapat berubah antar laporan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByNumberOfBins;
axis.NumberOfBins = 5;

presentation.Save("Histogram-bin-count.pptx", SaveFormat.Pptx);
```

Lima bin memiliki jumlah **4, 4, 4, 4, dan 1**. Bandingkan distribusi ini dengan hasil lebar‑bin tetap di atas: nilai input identik, namun batasnya berbeda.

![Histogram dengan lima bin yang dihitung dari data yang sama](histogram_bin_count.png)

### **Membuat Grafik Radar**

Grafik radar digunakan untuk menampilkan data multivariat dalam format dua dimensi, memungkinkan perbandingan beberapa variabel secara simultan. Grafik ini sangat berguna untuk mengidentifikasi pola, kekuatan, dan kelemahan di antara beberapa metrik atau atribut kinerja.

Contoh ini menggunakan [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) untuk membuat grafik radar dengan seri dan kategori default, kemudian menyimpan presentasi sebagai PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);

presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Grafik Radar](radar_chart.png)

### **Membuat Grafik Multi‑Kategori**

Grafik multi‑kategori digunakan untuk menampilkan data yang melibatkan lebih dari satu pengelompokan kategori, memungkinkan Anda membandingkan nilai di beberapa dimensi secara simultan. Grafik ini sangat membantu ketika Anda perlu menganalisis tren dan hubungan dalam dataset berlapis kompleks.

Contoh ini membuat grafik kolom berkelompok dengan delapan kategori yang diatur dalam empat pasang. Metode [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) memberi setiap pasang label bersama pada tingkat pengelompokan 1, menghasilkan sumbu kategori dengan label individu dan grup.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var worksheetIndex = 0;

var categoryCell = workbook.GetCell(0, "c2", "A");
var category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group1");
categoryCell = workbook.GetCell(0, "c3", "B");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c4", "C");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group2");
categoryCell = workbook.GetCell(0, "c5", "D");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c6", "E");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group3");
categoryCell = workbook.GetCell(0, "c7", "F");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c8", "G");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group4");
categoryCell = workbook.GetCell(0, "c9", "H");
category = chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, "D1", "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

var valueCell = workbook.GetCell(worksheetIndex, "D2", 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D3", 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D4", 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D5", 40);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D6", 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D7", 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D8", 70);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D9", 80);
series.DataPoints.AddDataPointForBarSeries(valueCell);

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Grafik Multi‑Kategori](multi_category_chart.png)

#### **Hapus Label Kuartal**

Unduh [quarters.pptx](quarters.pptx) dan letakkan di direktori kerja. Grafiknya menampilkan sembilan bulan dan satu seri penjualan dengan nilai 10 hingga 18. Sumbu kategori memiliki tiga label kuartal: Q1 mencakup Jan‑Mar, Q2 mencakup Apr‑Jun, dan Q3 mencakup Jul‑Sep.

April adalah kategori keempat dan yang secara eksplisit diatur Q2. Panggil [DeleteGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/deletegroupingitem/) pada koleksi [GroupingLevels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/groupinglevels/) April. Tingkat tersebut relatif terhadap April: tingkat 1 adalah kuartalnya, dan tingkat 0 adalah bulan itu sendiri. Metode ini tidak dapat menghapus kategori daun pada tingkat 0.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (var presentation = new Presentation("quarters.pptx"))
{
    var chart = (IChart)presentation.Slides[0].Shapes[0];
    var april = chart.ChartData.Categories[3];
    april.GroupingLevels.DeleteGroupingItem(1);

    presentation.Save("quarters-updated.pptx", SaveFormat.Pptx);
}

using var reopened = new Presentation("quarters-updated.pptx");
var updatedChart = (IChart)reopened.Slides[0].Shapes[0];
var data = updatedChart.ChartData;

Console.WriteLine(string.Join(", ", data.Categories.Select(month => month.AsCell.Value)));
Console.WriteLine(string.Join(", ", data.Series[0].DataPoints.Select(point => point.Value.Data)));
```

Grafik yang dibuka kembali mencetak bulan asli (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) dan nilai penjualan (`10, 11, 12, 13, 14, 15, 16, 17, 18`) dalam urutan yang sama. Buka `quarters-updated.pptx` di PowerPoint untuk membandingkan label sumbu. Label Q2 dan batas grup sebelum April menghilang, sehingga Q1 mencakup Januari hingga Juni. Q3 tetap dimulai pada Juli.

![Label kuartal sebelum dan sesudah penghapusan. Di kiri, Q2 mencakup April hingga Juni. Di kanan, Q1 mencakup Januari hingga Juni.](quarter-label-comparison.png)

### **Membuat Grafik Peta**

Grafik peta digunakan untuk memvisualisasikan data geografis dengan memetakan informasi ke lokasi spesifik seperti negara, provinsi, atau kota. Grafik ini sangat berguna untuk menganalisis tren regional, data demografis, dan distribusi spasial secara jelas dan menarik secara visual.

Contoh ini menggunakan [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) untuk membuat grafik peta dengan data geografis default dan menyimpannya untuk dilihat di PowerPoint.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);

presentation.Save("mapChart.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Grafik Peta](map_chart.png)

{{% alert color="info" title="Note" %}}
Gambar di atas menunjukkan presentasi yang disimpan dibuka di PowerPoint. Aspose.Slides menulis grafik peta dan datanya dengan benar, tetapi tidak menggambar grafik peta sendiri: ketika slide yang berisi grafik peta dirender menjadi gambar atau dikonversi ke PDF atau SVG, area grafik muncul kosong. Bentuk lain pada slide yang sama tidak terpengaruh.
{{% /alert %}}

### **Membuat Grafik Kombinasi**

Grafik kombinasi (atau combo chart) menggabungkan dua atau lebih jenis grafik dalam satu grafik. Grafik ini memungkinkan Anda menyoroti, membandingkan, atau memeriksa perbedaan antara dua atau lebih set data, membantu mengidentifikasi hubungan antar‑nya.

![Grafik Kombinasi](combination_chart.png)

Contoh ini menggabungkan dua seri kolom berkelompok dengan satu seri garis pada empat kategori. Kolom menggunakan sumbu vertikal utama, sementara [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) menempatkan garis pada sumbu vertikal sekunder di kanan. Fungsi pembantu mengonfigurasi judul, legenda, label sumbu, dan garis kisi.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

CreateComboChart();

static void CreateComboChart()
{
    using var presentation = new Presentation();
    var chart = CreateChartWithFirstSeries(presentation.Slides[0]);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
}

static IChart CreateChartWithFirstSeries(ISlide slide)
{
    var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    var portionFormat = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    var worksheetIndex = 0;

    var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 4, 0, "Category 4");
    chart.ChartData.Categories.Add(categoryCell);

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
    var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 4.3);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 1, 2.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 1, 3.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 1, 4.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);

    return chart;
}

static void AddSecondSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 2, 2.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 2, 4.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 2, 1.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 2, 2.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

static void AddThirdSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Line);

    var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 3, 3.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 3, 5.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);

    series.PlotOnSecondAxis = true;
}

static void SetPrimaryAxesFormat(IChart chart)
{
    var horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    var verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    var majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

static void SetSecondaryAxesFormat(IChart chart)
{
    var secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    var secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    var titlePortionFormat = axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Memperbarui Grafik**

Aspose.Slides untuk .NET memungkinkan Anda memperbarui grafik PowerPoint dengan memodifikasi data grafik, pemformatan, dan gaya. Fungsionalitas ini menyederhanakan proses menjaga presentasi tetap terbaru dengan konten dinamis dan memastikan grafik secara akurat mencerminkan data serta standar visual saat ini.

Contoh ini memperbarui grafik bernama "My chart" pada slide pertama dari presentasi yang sudah ada. Contoh ini memerlukan dua seri kolom dengan tiga titik data masing‑masing, dengan label kategori di kolom A dan nama seri di baris pertama lembar kerja pertama. Contoh ini menggunakan [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) untuk mengubah sel workbook, memperbarui nilai seri, menambahkan seri ketiga, dan mengubah grafik menjadi silinder berkelompok melalui [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        var worksheetIndex = 0;

        var workbook = chart.ChartData.ChartDataWorkbook;

        workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
        workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

        var series = chart.ChartData.Series[0];

        workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1");
        series.DataPoints[0].Value.Data = 90;
        series.DataPoints[1].Value.Data = 123;
        series.DataPoints[2].Value.Data = 44;

        series = chart.ChartData.Series[1];

        workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2");
        series.DataPoints[0].Value.Data = 23;
        series.DataPoints[1].Value.Data = 67;
        series.DataPoints[2].Value.Data = 99;

        var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
        series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

        var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 20);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 2, 3, 50);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 3, 3, 30);
        series.DataPoints.AddDataPointForBarSeries(valueCell);

        chart.Type = ChartType.ClusteredCylinder;
    }
}

presentation.Save("AsposeChartModified.pptx", SaveFormat.Pptx);
```

## **Menetapkan Rentang Data untuk Grafik**

Untuk memeriksa rentang yang sudah digunakan oleh grafik yang ada, lihat [Retrieve a Chart's Data Range](/slides/id/net/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides untuk .NET menyediakan fleksibilitas untuk menentukan rentang data spesifik dari lembar kerja sebagai sumber data grafik Anda. Ini berarti Anda dapat secara langsung memetakan sebagian lembar kerja ke grafik, memungkinkan Anda mengontrol sel‑sel mana yang berkontribusi pada seri dan kategori grafik. Akibatnya, Anda dapat dengan mudah memperbarui dan menyinkronkan grafik dengan perubahan data terbaru di lembar kerja, memastikan presentasi PowerPoint Anda mencerminkan informasi yang akurat dan terkini.

Contoh ini menggunakan [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) untuk menetapkan sumber data grafik bernama "My chart" pada slide pertama dari presentasi yang ada ke `Sheet1!A1:B4`. Buku kerja grafik harus berisi lembar tersebut dan rentang terisi dengan judul seri pada baris pertama, label kategori di kolom A, dan tiga nilai di kolom B.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        chart.ChartData.SetRange("Sheet1!A1:B4");
    }
}

presentation.Save("SetDataRange.pptx", SaveFormat.Pptx);
```

## **Menggunakan Penanda Bawaan dalam Grafik**

Ketika Anda menggunakan penanda bawaan dalam grafik, setiap seri grafik secara otomatis mendapatkan simbol penanda bawaan yang berbeda.

Contoh ini menggunakan [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) untuk membuat grafik dengan dua seri garis dan legenda. Pengaturan [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/) mempertahankan simbol penanda yang ditetapkan secara otomatis. Seri pertama mencakup nilai negatif dan nilai yang hilang, direpresentasikan oleh `null`, sementara seri kedua memiliki nilai untuk setiap kategori.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(0, 1, 0, "C1");
chart.ChartData.Categories.Add(categoryCell);
var valueCell = workbook.GetCell(0, 1, 1, 24);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 2, 0, "C2");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 2, 1, 23);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 3, 0, "C3");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 3, 1, -10);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 4, 0, "C4");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 4, 1, null);
series.DataPoints.AddDataPointForLineSeries(valueCell);

seriesNameCell = workbook.GetCell(0, 0, 2, "Series 2");
var secondSeries = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

valueCell = workbook.GetCell(0, 1, 2, 30);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 10);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 60);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 4, 2, 40);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);

chart.HasLegend = true;
chart.Legend.Overlay = false;

presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Jenis grafik apa yang didukung oleh Aspose.Slides untuk .NET?**

Aspose.Slides untuk .NET mendukung berbagai jenis grafik, termasuk bar, line, pie, area, scatter, histogram, radar, dan banyak lagi. Fleksibilitas ini memungkinkan Anda memilih jenis grafik yang paling sesuai untuk kebutuhan visualisasi data Anda.

**Bagaimana cara menambahkan grafik baru ke slide?**

Untuk menambahkan grafik, pertama buat instance kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), ambil slide yang diinginkan menggunakan indeksnya, lalu panggil metode untuk menambahkan grafik, dengan menentukan jenis grafik dan data awal. Proses ini mengintegrasikan grafik langsung ke dalam presentasi Anda.

**Bagaimana saya dapat memperbarui data yang ditampilkan dalam grafik?**

Anda dapat memperbarui data grafik dengan mengakses buku data grafiknya ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)), membersihkan seri dan kategori default, kemudian menambahkan data khusus Anda. Hal ini memungkinkan Anda memperbarui grafik secara programatis agar mencerminkan data terbaru.

**Apakah mungkin menyesuaikan tampilan grafik?**

Ya, Aspose.Slides untuk .NET menyediakan opsi penyesuaian yang luas. Anda dapat memodifikasi warna, font, label, legenda, dan elemen pemformatan lainnya untuk menyesuaikan tampilan grafik dengan kebutuhan desain spesifik Anda.

Fitur terkait: [Create editable charts](/slides/id/features/create-charts/).