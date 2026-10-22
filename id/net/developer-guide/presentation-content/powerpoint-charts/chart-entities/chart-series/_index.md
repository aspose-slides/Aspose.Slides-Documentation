---
title: Kelola Seri Data Diagram dalam Presentasi di .NET
linktitle: Seri Data
type: docs
url: /id/net/chart-series/
keywords:
- seri diagram
- tumpang tindih seri
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
description: "Pelajari cara mengelola seri diagram, titik data, sel workbook, pemformatan, tumpang tindih, lebar celah, dan nilai negatif dalam presentasi dengan C#."
---
## **Gambaran Umum**

Sebuah diagram dapat menyimpan nilai yang dipetakan dalam sel workbook atau langsung sebagai literal numerik. Sebuah [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) mewakili satu set nilai terkait, dan setiap [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) mewakili satu titik dalam seri tersebut. Objek [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) menyediakan label atau nilai pengelompokan yang dibagikan oleh seri. Pada diagram yang dibuat dengan data bawaan, nama seri, kategori, dan nilai titik menggunakan objek [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) dari workbook diagram.

Untuk diagram kategori tipikal, workbook bawaan menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel‑sel sisanya untuk nilai seri. Indeks lembar kerja, baris, dan kolom yang diteruskan ke [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) bersifat berbasis nol. Tata letak ini berguna saat Anda membuat diagram dengan data bawaan, tetapi jangan mengasumsikan bahwa setiap diagram yang ada menggunakannya. Untuk presentasi yang dimuat, periksa sel yang direferensikan oleh seri, kategori, dan titik data sebelum mengubah nilai workbook.

Pengaturan diagram memiliki tiga lingkup yang berbeda:

- Pengaturan tingkat seri, seperti [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), menyediakan tampilan bawaan untuk semua titik dalam satu seri.
- Pengaturan titik data, seperti [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), menggantikan tampilan seri untuk satu titik.
- Pengaturan grup berlaku untuk seri yang kompatibel yang termasuk dalam satu [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/). Akses grup melalui [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) ketika Anda perlu mengatur opsi seperti tumpang tindih atau lebar celah.

Ketika tidak ada pengisian titik atau seri yang ditetapkan secara eksplisit, gaya dan tema diagram menentukan tampilan otomatis. Ketika baik format seri maupun titik hadir, format titik memiliki prioritas untuk titik tersebut.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Menetapkan Nilai Seri Menggunakan Literal Numerik**

Gunakan literal numerik ketika nilai seri berasal dari data atau perhitungan aplikasi dan tidak memerlukan referensi sel lembar kerja. Atur [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) ke [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) sebelum menetapkan [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) setiap titik melalui [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/).

Pengaturan koleksi mengontrol tipe sumber semua nilai titik dalam seri tersebut. Setiap titik melaporkan tipe yang dipilih melalui [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/); ubah melalui pengaturan koleksi. Dengan `Worksheet`, gunakan [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) untuk mengakses sel yang direferensikan. Dengan `DoubleLiterals`, gunakan `AsLiteralDouble` untuk membaca atau menulis angka secara langsung.

Contoh berikut membuat diagram kolom dengan seri dan kategori bawaan, lalu menetapkan nilai terhitung 10, 20, dan seterusnya ke titik yang ada pada seri pertamanya. Diagram disimpan, dibuka kembali, dan nilai yang tersimpan dicetak.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

Tipe sumber nilai titik terpisah dari [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/), yang mengidentifikasi konfigurasi workbook internal atau eksternal diagram. Menggunakan literal numerik tidak secara otomatis menghapus workbook yang disematkan. Pada contoh ini, workbook tetap tersedia untuk label kategori, nama seri, dan seri lainnya. Lihat [Chart Workbook](/slides/id/net/chart-workbook/) untuk manajemen workbook.

Untuk diagram sebar dan gelembung, atur [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) dan [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) untuk memilih sumber [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) dan [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Diagram gelembung juga menggunakan [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) untuk [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). Tetapkan setiap sumber yang relevan ke `DoubleLiterals` sebelum menetapkan angka melalui properti `AsLiteralDouble` nilai tersebut.

## **Mengatur Tumpang Tindih Seri Diagram**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) melaporkan seberapa banyak batang atau kolom tumpang tindih dalam diagram 2D, dari -100 hingga 100 persen. Nilai ini bersifat baca‑saja dan merupakan proyeksi pengaturan pada grup seri induk. Atur [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe diagram yang menampilkan batang atau kolom yang dikelompokkan; tidak memengaruhi grup seri yang tidak terkait dalam diagram kombinasi.

Contoh berikut mengatur tumpang tindih untuk grup yang berisi seri pertama:

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

Hasilnya:

![The series overlap](series_overlap.png)

## **Mengubah Warna Isi Seri**

Gunakan [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) untuk menetapkan isi bawaan bagi seluruh seri. Jika sebuah titik sudah memiliki isi eksplisit, pengaturan [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) akan menggantikan isi seri untuk titik tersebut.

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

Hasilnya:

![The color of the series](series_color.png)

## **Mengubah Nama Seri**

Nama seri disimpan dalam workbook data diagram dan biasanya ditampilkan di legenda. Pada workbook bawaan yang dibuat untuk diagram kolom terkelompok, sel B1 berada pada baris 0, kolom 1 dan berisi nama seri pertama. Konstanta bernama dalam contoh berikut menjelaskan struktur tersebut secara eksplisit:

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

Anda juga dapat memperbarui sel yang sudah direferensikan oleh [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/). Pendekatan ini menghindari asumsi tentang baris dan kolom tertentu dalam diagram yang ada:

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

Hasilnya:

![The series name](series_name.png)

### **Membuat Seri dengan Nama dari Beberapa Sel**

Nama seri gabungan berguna ketika nama produk dan periode pelaporan disimpan di sel workbook terpisah. Misalnya, Anda dapat menggabungkan `Product A` di B1 dan `2026` di C1 menjadi satu nama seri sambil mempertahankan kedua bagian tetap terhubung ke sel sumbernya.

Gunakan [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) untuk mengambil rentang nama, kemudian berikan koleksi tersebut ke [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). Argumen `skipHiddenCells` mengontrol apakah sel tersembunyi disertakan: `true` mengecualikannya, sementara `false` menyertakannya. Contoh ini menggunakan `false` untuk menyertakan setiap sel dalam rentang nama.

Contoh berikut membuat presentasi dengan satu seri dan dua titik data. Sel B1:C1 hanya menyediakan nama seri; A2:A3 menyediakan label kategori, dan B2:B3 menyediakan nilai numerik.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Dua sel ini menyediakan nama seri.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Separate cells supply the categories and numeric data points.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

Nama seri yang dihasilkan adalah `Product A 2026`, dengan spasi di antara dua nilai sel. Legenda menampilkan ini sebagai satu entri untuk kedua kolom. Gambar di bawah dirender dari presentasi yang disimpan:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Mendapatkan Warna Isi Seri Otomatis**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) mengembalikan warna yang dihitung dari indeks seri dan gaya diagram. Inilah warna yang digunakan ketika isi seri belum didefinisikan secara eksplisit. Memanggil metode ini hanya membaca warna yang dihitung; tidak menetapkan isi baru.

Contoh berikut mencetak warna otomatis untuk setiap seri bawaan:

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

Contoh output untuk gaya diagram bawaan:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Warna tepatnya bergantung pada gaya dan tema diagram.

## **Mengatur Warna Isi Terbalik untuk Seri Diagram**

Untuk seri batang, kolom, dan gelembung, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) dapat menampilkan nilai negatif dengan isi yang berbeda. Atur isi seri reguler menjadi padat, aktifkan inversi, dan tetapkan warna nilai negatif melalui [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Angka negatif tetap tidak berubah di workbook; hanya warna tampilannya yang berubah.

Contoh berikut menggantikan data diagram bawaan dengan satu seri. Baris lembar kerja 0 berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

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

Hasilnya:

![The inverted solid fill color](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Pada contoh berikut, inversi dinonaktifkan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik tersebut juga diberikan nilai negatif agar efeknya terlihat:

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

## **Menghapus Nilai Titik Data Spesifik**

Untuk membuat satu titik kosong tanpa menghapus titik lainnya, setel sel workbook yang mendasarinya ke `null`. Untuk diagram kolom, nilai yang dipetakan tersedia melalui [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Titik data tetap berada pada posisi kategori yang sama, tetapi diagram memperlakukan nilainya sebagai kosong menurut pengaturan nilai kosong diagram.

Contoh berikut mengosongkan hanya titik kedua pada seri pertama:

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

Diagram sebar menggunakan sel X dan Y terpisah, dan diagram gelembung juga menggunakan sel ukuran. Hapus hanya sel yang mewakili nilai yang ingin Anda hilangkan. Jangan panggil [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) ketika Anda ingin mempertahankan titik lainnya, karena metode itu menghapus semua titik data dari koleksi.

## **Mengontrol Tampilan Sel Kosong**

Sel tersembunyi yang berisi nilai merupakan kasus terpisah dari sel kosong. Untuk menyertakan atau mengecualikan data dari baris dan kolom lembar kerja yang tersembunyi, lihat [Include Data from Hidden Rows and Columns](/slides/id/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Sel workbook kosong mewakili data yang hilang; sel yang berisi `0` mewakili nilai numerik yang diketahui. Setel [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) ke `null` untuk membuat sel kosong. Nol numerik tetap nol terlepas dari pengaturan sel kosong.

Gunakan [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) untuk memilih cara diagram menampilkan sel kosong. Pengaturan ini berlaku untuk seluruh diagram. Ia mengubah cara kosong dipetakan, tanpa mengisi sel workbook kosong dengan nol atau nilai interpolasi.

Contoh mandiri berikut membuat diagram garis dengan satu seri, mengosongkan nilai untuk Hari 3, dan menyimpan diagram yang sama dengan setiap mode. Tidak diperlukan file masukan. [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) menggunakan lembar kerja 0, kolom 0 untuk label kategori, dan kolom 1 untuk nilai; baris 0 menyimpan nama seri. Data akhir adalah `10, 20, empty, 30, 40`.

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

// Biarkan Hari 3 benar-benar kosong, sambil mempertahankan kategorinya dan titik datanya.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Setiap file output menyimpan mode yang ditetapkan sebelum penyimpanan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, dan `empty_cells_Span.pptx`. Untuk menyimpan hanya satu versi, tetapkan mode yang diinginkan dan simpan presentasi sekali saja alih‑alih mengulangi semua mode.

Perbandingan di bawah memperlihatkan data yang sama dalam ketiga file. Hari 3 kosong di workbook pada semua kasus:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Efek yang terlihat bergantung pada tipe diagram. Diagram garis memudahkan perbandingan ketiga mode. Diagram batang dan kolom tidak memiliki garis untuk menghubungkan antar kategori yang hilang, sehingga `Span` tidak dapat menghasilkan segmen penghubung seperti di atas; kolom yang hilang dan kolom dengan tinggi nol dapat tampak serupa. Demikian pula, diagram sebar dengan hanya penanda tidak memiliki garis penghubung. Jangan mengharapkan tiga hasil berbeda untuk setiap tipe diagram; periksa output untuk tipe yang Anda gunakan.

## **Mengatur Lebar Celah Seri**

Lebar celah adalah ruang antar klaster batang atau kolom yang berdekatan, dinyatakan sebagai persentase lebar batang atau kolom. Seperti tumpang tindih, lebar celah merupakan properti grup seri induk, bukan satu seri. Atur [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) sekali untuk grup. Nilai yang lebih besar menciptakan lebih banyak ruang antar klaster; nilai yang lebih kecil membuatnya lebih padat.

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

Hasilnya:

![The gap width](gap_width.png)

## **FAQ**

**Tipe diagram apa yang mendukung seri data?**

Semua tipe diagram yang diwakili oleh enumerasi [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) menggunakan data diagram, tetapi struktur nilai atau pengaturannya tidak semuanya sama. Misalnya, diagram kategori menggunakan kategori dan nilai, diagram sebar menggunakan nilai X dan Y, dan diagram gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe seri. Opsi seperti tumpang tindih dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri diagram?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) berisi seri yang kompatibel yang berbagi pengaturan plotting tingkat grup. Diagram kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup melalui satu seri tidak selalu mengubah semua seri dalam diagram.

**Apakah diagram yang baru dibuat berisi data bawaan?**

Ya. Secara default, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) membuat contoh seri, kategori, dan nilai. Anda dapat menyunting sel‑sel tersebut atau mengosongkan koleksi seri dan kategori sebelum menambahkan himpunan data khusus sepenuhnya. Overload lain juga dapat membuat diagram tanpa data bawaan.

**Bagaimana objek diagram terhubung ke sel workbook?**

Nama seri, label kategori, dan nilai titik data mereferensikan sel dalam [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Mengubah sel yang direferensikan memperbarui elemen diagram yang bersangkutan. Saat Anda membangun data khusus, pastikan baris kategori dan baris nilai seri selaras sehingga setiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara mengosongkan satu titik tanpa menghapus seluruh seri?**

Setel sel nilai yang relevan ke `null` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) hanya ketika Anda bermaksud menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri agar nilai mereka tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe diagram dan [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Diagram yang didukung dapat menampilkan kosong sebagai celah, nilai nol, atau dengan menghubungkan titik tetangga. Pilih pengaturan yang sesuai dengan makna data yang hilang dalam presentasi Anda. Lihat [Control the Display of Empty Cells](#control-the-display-of-empty-cells) untuk contoh lengkap dan perbandingan visual.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, aktifkan [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) dan tetapkan [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Anda dapat mengganti perilaku untuk titik individu dengan [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Properti ini memengaruhi pemformatan, bukan nilai numerik yang disimpan.

**Format mana yang menang ketika seri dan titik keduanya diformat?**

Pemformatan titik data eksplisit memiliki prioritas untuk titik tersebut. Titik lain terus menggunakan format seri eksplisit atau, bila format seri tidak didefinisikan, gaya dan tema diagram otomatis. Properti grup seperti tumpang tindih dan lebar celah mengontrol tata letak dan bukan merupakan override pemformatan tingkat titik.

**Apakah ada batas berapa banyak seri yang dapat dimiliki diagram?**

Aspose.Slides tidak memberlakukan batas tetap terpisah untuk jumlah seri. Pada praktiknya, batas dipengaruhi oleh batasan file presentasi, memori yang tersedia, waktu rendering, dan keterbacaan diagram.

**Apa yang harus diubah ketika kolom terlalu berdekatan atau terlalu jauh?**

Atur [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) pada grup seri induk yang relevan. Naikkan nilai untuk memperlebar ruang antar klaster, atau turunkan nilai untuk mendekatkan klaster.