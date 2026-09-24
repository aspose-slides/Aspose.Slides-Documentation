---
title: Mengelola Seri Data Diagram dalam Presentasi di .NET
linktitle: Seri Data
type: docs
url: /id/net/chart-series/
keywords:
- seri diagram
- overlap seri
- warna seri
- warna kategori
- nama seri
- titik data
- celah seri
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengelola seri diagram, titik data, sel workbook, pemformatan, overlap, lebar celah, dan nilai negatif dalam presentasi dengan C#."
---
## **Gambaran Umum**

Diagram menyimpan data yang dipetakan dalam workbook data diagram. Sebuah [IChartSeries](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/) mewakili satu set nilai terkait, dan setiap [IChartDataPoint](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/) dalam seri mengacu pada satu atau beberapa sel workbook. Objek [IChartCategory](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartcategory/) menyediakan label atau nilai pengelompokan yang dibagikan oleh seri. Karena itu nama seri, kategori, dan nilai titik terhubung ke objek [IChartDataCell](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/) alih‑alih disimpan hanya sebagai teks tampilan.

Untuk diagram kategori tipikal, workbook default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel‑sel lainnya untuk nilai seri. Indeks worksheet, baris, dan kolom yang diberikan ke [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/getcell/) bersifat berbasis nol. Tata letak ini berguna ketika Anda membuat diagram dengan data default, tetapi jangan berasumsi bahwa setiap diagram yang sudah ada menggunakannya. Untuk presentasi yang dimuat, periksa sel‑sel yang dirujuk oleh seri, kategori, dan titik data sebelum mengubah nilai workbook.

Pengaturan diagram memiliki tiga ruang lingkup yang berbeda:

- Pengaturan tingkat seri, seperti [IChartSeries.Format](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/format/), menyediakan tampilan default untuk semua titik dalam satu seri.
- Pengaturan titik data, seperti [IChartDataPoint.Format](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/format/), menggantikan tampilan seri untuk satu titik.
- Pengaturan grup berlaku untuk seri yang kompatibel dan termasuk dalam satu [IChartSeriesGroup](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseriesgroup/). Akses grup melalui [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/parentseriesgroup/) ketika Anda perlu mengatur opsi seperti overlap atau lebar celah.

Ketika tidak ada pengisian titik atau seri yang eksplisit, gaya dan tema diagram menentukan tampilan otomatis. Ketika format seri dan titik keduanya ada, format titik memiliki prioritas untuk titik tersebut.

![seri-diagram-powerpoint](chart-series-powerpoint.png)

## **Atur Overlap Seri Diagram**

[IChartSeries.Overlap](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/overlap/) melaporkan seberapa banyak batang atau kolom saling tumpang tindih dalam diagram 2D, dari –100 hingga 100 persen. Ini merupakan proyeksi baca‑saja dari pengaturan pada grup seri induk. Atur [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseriesgroup/overlap/) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe diagram yang menampilkan batang atau kolom berkelompok; tidak memengaruhi grup seri yang tidak terkait dalam diagram kombinasi.

Contoh berikut mengatur overlap untuk grup yang berisi seri pertama:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Diagram baru berisi contoh seri, kategori, dan nilai.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Hasil:

![Overlap seri](series_overlap.png)

## **Ubah Warna Isi Seri**

Gunakan [IChartSeries.Format](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/format/) untuk mengatur isi default bagi seluruh seri. Jika sebuah titik sudah memiliki isi eksplisit, pengaturan [IChartDataPoint.Format](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/format/) akan menggantikan isi seri untuk titik tersebut.

Contoh berikut menerapkan isi biru padat pada seri pertama:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

Hasil:

![Warna seri](series_color.png)

## **Ubah Nama Seri**

Nama seri disimpan dalam workbook data diagram dan biasanya ditampilkan pada legenda. Dalam workbook default yang dibuat untuk diagram kolom berkelompok, sel B1 berada di baris 0, kolom 1 dan berisi nama seri pertama. Konstanta bernama dalam contoh berikut membuat struktur tersebut eksplisit:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Anda juga dapat memperbarui sel yang sudah dirujuk oleh [IChartSeries.Name](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/name/). Pendekatan ini menghindari asumsi baris dan kolom tertentu dalam diagram yang sudah ada:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Hasil:

![Nama seri](series_name.png)

## **Dapatkan Warna Isi Seri Otomatis**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) mengembalikan warna yang dihitung dari indeks seri dan gaya diagram. Ini adalah warna yang digunakan ketika isi seri tidak didefinisikan secara eksplisit. Memanggil metode ini membaca warna yang dihitung; tidak menetapkan isi baru.

Contoh berikut mencetak warna otomatis masing‑masing seri default:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Contoh output untuk gaya diagram default:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Warna yang tepat tergantung pada gaya dan tema diagram.

## **Atur Warna Isi Terbalik untuk Seri Diagram**

Untuk seri batang, kolom, dan gelembung, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/invertifnegative/) dapat menampilkan nilai negatif dengan isi berbeda. Atur isi seri reguler menjadi padat, aktifkan pembalikan, dan tetapkan warna nilai negatif melalui [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Angka negatif tetap tidak berubah dalam workbook; hanya warna tampilannya yang berubah.

Contoh berikut menggantikan data diagram default dengan satu seri. Baris worksheet 0 berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

Hasil:

![Warna isi padat terbalik](inverted_solid_fill_color.png)

Anda dapat mengaktifkan pembalikan untuk satu titik melalui [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Pada contoh berikut, pembalikan dinonaktifkan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik tersebut juga diberikan nilai negatif agar efeknya terlihat:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Bersihkan Nilai Titik Data Tertentu**

Agar satu titik menjadi kosong tanpa menghapus titik lain, atur sel workbook yang mendasarinya ke `null`. Untuk diagram kolom, nilai yang dipetakan tersedia melalui [IChartDataPoint.YValue](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/yvalue/). Titik data tetap berada pada posisi kategori yang sama, tetapi diagram memperlakukan nilainya sebagai kosong sesuai dengan pengaturan nilai‑kosong diagram.

Contoh berikut membersihkan hanya titik kedua dalam seri pertama:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Diagram sebar menggunakan sel X dan Y terpisah, dan diagram gelembung juga menggunakan sel ukuran. Hanya bersihkan sel yang mewakili nilai yang ingin Anda hapus. Jangan memanggil [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapointcollection/clear/) ketika Anda ingin mempertahankan titik lain, karena metode tersebut menghapus semua titik data dari koleksi.

## **Kendalikan Tampilan Sel Kosong**

Sel workbook kosong mewakili data yang hilang; sel yang berisi `0` mewakili nilai numerik yang diketahui. Atur [IChartDataCell.Value](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/value/) ke `null` untuk membuat sel kosong. Nol numerik tetap nol terlepas dari pengaturan sel kosong.

Gunakan [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/displayblanksas/) untuk memilih cara diagram menampilkan sel kosong. Pengaturan ini berlaku untuk seluruh diagram. Ia mengubah cara kosong dipetakan, tanpa mengisi sel workbook yang kosong dengan nol atau nilai interpolasi.

Contoh mandiri berikut membuat diagram garis dengan satu seri, membersihkan nilai untuk Hari 3, dan menyimpan diagram yang sama dengan tiap mode. Tidak diperlukan file masukan. [IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/) menggunakan worksheet 0, kolom 0 untuk label kategori, dan kolom 1 untuk nilai; baris 0 menyimpan nama seri. Data akhir adalah `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Setiap file output menyimpan mode yang ditetapkan sebelum disimpan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, dan `empty_cells_Span.pptx`. Untuk menyimpan hanya satu versi, tetapkan mode yang diinginkan dan simpan presentasi sekali saja alih‑alih mengulangi seluruh mode.

Perbandingan di bawah memperlihatkan data yang sama dalam ketiga file. Hari 3 kosong dalam workbook pada setiap kasus:

![Diagram garis dengan data identik: Gap memutus garis pada Hari 3, Zero menurunkan garis ke nol, dan Span menghubungkan Hari 2 ke Hari 4.](display_blanks_as.png)

Efek yang terlihat tergantung pada tipe diagram. Diagram garis memudahkan perbandingan ketiga mode. Diagram batang dan kolom tidak memiliki garis untuk menghubungkan kategori yang hilang, sehingga `Span` tidak dapat menghasilkan segmen penghubung seperti di atas; kolom yang hilang dan kolom dengan tinggi nol bisa terlihat serupa. Begitu pula diagram sebar dengan hanya penanda tidak memiliki garis penghubung. Jangan mengharapkan tiga hasil yang berbeda untuk setiap tipe diagram; periksa output untuk tipe yang Anda gunakan.

## **Atur Lebar Celah Seri**

Lebar celah adalah ruang antara klaster batang atau kolom yang berdekatan, dinyatakan sebagai persentase lebar batang atau kolom. Seperti overlap, lebar celah termasuk dalam grup seri induk, bukan pada satu seri. Atur [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) sekali untuk grup. Nilai yang lebih besar menciptakan lebih banyak ruang antar‑klaster; nilai yang lebih kecil membuatnya lebih rapat.

Contoh berikut mengubah lebar celah dan menyimpan hanya presentasi akhir:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

Hasil:

![Lebar celah](gap_width.png)

## **FAQ**

**Tipe diagram apa yang mendukung seri data?**

Semua tipe diagram yang diwakili oleh enumerasi [ChartType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/charttype/) menggunakan data diagram, tetapi serinya tidak semuanya memiliki struktur nilai atau pengaturan yang sama. Misalnya, diagram kategori menggunakan kategori dan nilai, diagram sebar menggunakan nilai X dan Y, dan diagram gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe serinya. Opsi seperti overlap dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri diagram?**

Sebuah [IChartSeriesGroup](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseriesgroup/) berisi seri yang kompatibel dan berbagi pengaturan plotting level grup. Diagram kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup yang dicapai melalui satu seri tidak selalu mengubah semua seri dalam diagram.

**Apakah diagram yang baru dibuat berisi data default?**

Ya. Secara default, [IShapeCollection.AddChart](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addchart/) membuat seri, kategori, dan nilai contoh. Anda dapat menyunting sel‑sel tersebut atau membersihkan koleksi seri serta kategori sebelum menambahkan kumpulan data yang sepenuhnya khusus. Overload lain juga dapat membuat diagram tanpa data default.

**Bagaimana objek diagram terhubung ke sel workbook?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam sebuah [IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/). Mengubah sel yang dirujuk memperbarui elemen diagram yang bersangkutan. Saat Anda membangun data khusus, jaga agar baris kategori dan baris nilai seri tetap selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara membersihkan satu titik tanpa menghapus seluruh seri?**

Atur sel nilai yang relevan ke `null` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapointcollection/clear/) hanya ketika Anda ingin menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri agar nilai mereka tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe diagram dan [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/displayblanksas/). Diagram yang didukung dapat menampilkan kosong sebagai celah, sebagai nilai nol, atau dengan menghubungkan titik‑titik tetangga. Pilih pengaturan yang sesuai dengan arti data yang hilang dalam presentasi Anda. Lihat **Kendalikan Tampilan Sel Kosong** untuk contoh lengkap dan perbandingan visual.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, aktifkan [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/invertifnegative/) dan tetapkan [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Anda dapat mengganti perilaku untuk titik individu dengan [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Properti‑properti ini memengaruhi pemformatan, bukan nilai numerik yang disimpan.

**Format mana yang menang ketika baik seri maupun titik diformat?**

Pemformatan titik data eksplisit memiliki prioritas untuk titik tersebut. Titik lain tetap menggunakan format seri eksplisit atau, bila format seri tidak didefinisikan, gaya dan tema diagram otomatis. Properti grup seperti overlap dan lebar celah mengatur tata letak dan bukan pemformatan tingkat titik.

**Apakah ada batas berapa banyak seri yang dapat dimiliki sebuah diagram?**

Aspose.Slides tidak memberlakukan batas tetap terpisah untuk jumlah seri. Pada praktiknya, batas ditentukan oleh kendala file presentasi, memori yang tersedia, waktu render, dan keterbacaan diagram.

**Apa yang harus diubah ketika kolom terlalu berdekatan atau terlalu jauh?**

Atur [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) pada grup seri induk yang sesuai. Tingkatkan nilai untuk memperlebar ruang antar‑klaster, atau turunkan nilai untuk mendekatkan klaster.