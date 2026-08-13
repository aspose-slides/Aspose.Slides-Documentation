---
title: Kelola Seri Data Bagan dalam Presentasi di .NET
linktitle: Seri Data
type: docs
url: /id/net/chart-series/
keywords:
- seri bagan
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
description: "Pelajari cara mengelola seri bagan, titik data, sel buku kerja, pemformatan, tumpang tindih, lebar celah, dan nilai negatif dalam presentasi dengan C#."
---
## **Gambaran Umum**

Sebuah bagan menyimpan data yang digambarkan dalam buku kerja data bagan. Sebuah [IChartSeries](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/) mewakili satu set nilai terkait, dan setiap [IChartDataPoint](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/) dalam seri mengacu pada satu atau beberapa sel buku kerja. Objek [IChartCategory](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartcategory/) menyediakan label atau nilai pengelompokan yang dibagi oleh seri. Oleh karena itu nama seri, kategori, dan nilai titik terhubung ke objek [IChartDataCell](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/) bukan hanya disimpan sebagai teks tampilan.

Untuk bagan kategori tipikal, buku kerja default menggunakan baris 0 untuk nama seri, kolom 0 untuk nama kategori, dan sel-sel lainnya untuk nilai seri. Indeks lembar kerja, baris, dan kolom yang diteruskan ke [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/getcell/) bersifat berbasis nol. Tata letak ini berguna saat Anda membuat bagan dengan data default, namun jangan mengasumsikan bahwa setiap bagan yang ada menggunakannya. Untuk presentasi yang dimuat, periksa sel-sel yang dirujuk oleh seri, kategori, dan titik data sebelum mengubah nilai buku kerja.

Pengaturan bagan memiliki tiga ruang lingkup berbeda:

- Pengaturan tingkat seri, seperti [IChartSeries.Format](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/format/), menyediakan tampilan default untuk semua titik dalam satu seri.
- Pengaturan titik data, seperti [IChartDataPoint.Format](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/format/), menimpa tampilan seri untuk satu titik.
- Pengaturan grup berlaku untuk seri yang kompatibel yang termasuk dalam [IChartSeriesGroup](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseriesgroup/) yang sama. Akses grup melalui [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/parentseriesgroup/) ketika Anda perlu mengatur opsi seperti overlap atau lebar celah.

Jika tidak ada isian titik atau seri yang eksplisit, gaya bagan dan tema menentukan tampilan otomatis. Jika format seri dan titik keduanya ada, format titik memiliki prioritas untuk titik tersebut.

![seri-bagan-powerpoint](chart-series-powerpoint.png)

## **Atur Overlap Seri Bagan**

[IChartSeries.Overlap](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/overlap/) melaporkan seberapa banyak batang atau kolom saling tumpang tindih dalam bagan 2D, dari -100 hingga 100 persen. Ini merupakan proyeksi baca-saja dari pengaturan pada grup seri induk. Atur [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseriesgroup/overlap/) untuk memperbarui setiap seri yang kompatibel dalam grup tersebut. Opsi ini berlaku untuk tipe bagan yang menampilkan batang atau kolom yang dikelompokkan; tidak memengaruhi grup seri yang tidak terkait dalam bagan kombinasi.

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

// Bagan baru berisi seri contoh, kategori, dan nilai.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Hasil:

![Overlap seri](series_overlap.png)

## **Ubah Warna Isian Seri**

Gunakan [IChartSeries.Format](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/format/) untuk mengatur isian default untuk seluruh seri. Jika sebuah titik sudah memiliki isian eksplisit, pengaturan [IChartDataPoint.Format](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/format/)nya menimpa isian seri untuk titik tersebut.

Contoh berikut menerapkan isian biru solid pada seri pertama:

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

Nama seri disimpan dalam buku kerja data bagan dan biasanya ditampilkan di legenda. Dalam buku kerja default yang dibuat untuk bagan kolom berkelompok, sel B1 berada pada baris 0, kolom 1 dan berisi nama seri pertama. Konstanta bernama dalam contoh berikut menjelaskan struktur tersebut secara eksplisit:

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

Anda juga dapat memperbarui sel yang sudah dirujuk oleh [IChartSeries.Name](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/name/). Pendekatan ini menghindari asumsi baris dan kolom tertentu pada bagan yang sudah ada:

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

## **Dapatkan Warna Isian Seri Otomatis**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) mengembalikan warna yang dihitung dari indeks seri dan gaya bagan. Ini adalah warna yang digunakan ketika isian seri tidak didefinisikan secara eksplisit. Memanggil metode ini membaca warna yang dihitung; tidak menetapkan isian baru.

Contoh berikut mencetak warna otomatis setiap seri default:

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

Contoh output untuk gaya bagan default:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Warna tepat tergantung pada gaya bagan dan tema.

## **Atur Warna Isian Terbalik untuk Seri Bagan**

Untuk seri batang, kolom, dan gelembung, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/invertifnegative/) dapat menampilkan nilai negatif dengan isian berbeda. Atur isian seri biasa menjadi solid, aktifkan inversi, dan tetapkan warna nilai negatif melalui [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Angka negatif tetap tidak berubah dalam buku kerja; hanya warna tampilan mereka yang berubah.

Contoh berikut menggantikan data bagan default dengan satu seri. Baris 0 lembar kerja berisi nama seri, kolom 0 berisi nama kategori, dan kolom 1 berisi nilai:

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

![Warna isian solid terbalik](inverted_solid_fill_color.png)

Anda dapat mengaktifkan inversi untuk satu titik melalui [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Dalam contoh berikut, inversi dinonaktifkan untuk seri dan diaktifkan hanya untuk titik yang dipilih. Titik tersebut juga diberi nilai negatif agar efeknya terlihat:

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

Untuk membuat satu titik kosong tanpa menghapus titik lain, atur sel buku kerja yang mendasarinya menjadi `null`. Untuk bagan kolom, nilai yang digambarkan tersedia melalui [IChartDataPoint.YValue](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/yvalue/). Titik data tetap berada pada posisi kategori yang sama, tetapi bagan memperlakukan nilainya sebagai kosong sesuai dengan pengaturan nilai kosong bagan.

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

Bagan sebar menggunakan sel X dan Y terpisah, dan bagan gelembung juga menggunakan sel ukuran. Hapus hanya sel yang mewakili nilai yang ingin Anda hapus. Jangan panggil [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapointcollection/clear/) ketika Anda ingin mempertahankan titik lain, karena metode tersebut menghapus setiap titik data dari koleksi.

## **Atur Lebar Celah Seri**

Lebar celah adalah ruang antara kelompok batang atau kolom yang berdekatan, diekspresikan sebagai persentase dari lebar batang atau kolom. Seperti overlap, lebar celah merupakan milik grup seri induk bukan satu seri. Atur [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) sekali untuk grup. Nilai yang lebih besar menciptakan lebih banyak ruang antar kelompok; nilai yang lebih kecil membuatnya lebih padat.

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

## **Tanya Jawab**

**Jenis bagan apa yang mendukung seri data?**

Semua jenis bagan yang diwakili oleh enumerasi [ChartType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/charttype/) menggunakan data bagan, namun seri mereka tidak semuanya memiliki struktur nilai atau pengaturan yang sama. Misalnya, bagan kategori menggunakan kategori dan nilai, bagan sebar menggunakan nilai X dan Y, dan bagan gelembung menambahkan ukuran gelembung. Gunakan metode pembuatan titik data yang sesuai dengan tipe seri. Opsi seperti overlap dan lebar celah hanya berlaku untuk grup batang atau kolom yang kompatibel.

**Apa itu grup seri bagan?**

Sebuah [IChartSeriesGroup](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseriesgroup/) berisi seri yang kompatibel yang berbagi pengaturan plot tingkat grup. Sebuah bagan kombinasi dapat berisi lebih dari satu grup, sehingga mengubah grup yang diakses melalui satu seri tidak selalu mengubah setiap seri dalam bagan.

**Apakah bagan yang baru dibuat berisi data default?**

Ya. Secara default, [IShapeCollection.AddChart](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addchart/) membuat seri contoh, kategori, dan nilai. Anda dapat mengedit sel-sel tersebut atau membersihkan koleksi seri dan kategori sebelum menambahkan kumpulan data yang sepenuhnya khusus. Sebuah overload juga dapat membuat bagan tanpa data default.

**Bagaimana objek bagan terhubung ke sel buku kerja?**

Nama seri, label kategori, dan nilai titik data merujuk ke sel dalam [IChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/). Mengubah sel yang dirujuk memperbarui elemen bagan yang bersesuaian. Saat Anda membuat data khusus, pastikan baris kategori dan baris nilai seri selaras sehingga tiap titik dipetakan di bawah kategori yang dimaksud.

**Bagaimana cara menghapus satu titik alih-alih seluruh seri?**

Atur sel nilai yang relevan menjadi `null` untuk mempertahankan posisi kategori titik sebagai titik kosong. Gunakan [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapointcollection/clear/) hanya ketika Anda berniat menghapus semua titik dari seri tersebut. Jika Anda juga menghapus kategori, perbarui setiap seri sehingga nilai mereka tetap selaras dengan koleksi kategori.

**Bagaimana titik kosong ditampilkan?**

Hasilnya tergantung pada tipe bagan dan [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/displayblanksas/). Bagan yang didukung dapat menampilkan kosong sebagai celah, sebagai nilai nol, atau dengan menghubungkan titik-titik tetangga. Pilih pengaturan yang sesuai dengan makna data yang hilang dalam presentasi Anda.

**Bagaimana nilai negatif diformat?**

Untuk seri batang, kolom, dan gelembung yang didukung, aktifkan [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/invertifnegative/) dan atur [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Anda dapat menimpa perilaku untuk titik individual dengan [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Properti ini memengaruhi pemformatan, bukan nilai numerik yang disimpan.

**Pemformatan mana yang menang ketika baik seri maupun titik diformat?**

Pemformatan titik data eksplisit memiliki prioritas untuk titik tersebut. Titik lain terus menggunakan format seri eksplisit atau, ketika format seri tidak ditentukan, gaya dan tema bagan otomatis. Properti grup seperti overlap dan lebar celah mengontrol tata letak dan bukan penimpaan pemformatan tingkat titik.

**Apakah ada batas berapa banyak seri yang dapat dimiliki sebuah bagan?**

Aspose.Slides tidak memberlakukan batas jumlah seri yang tetap secara terpisah. Dalam praktiknya, batasan file presentasi, memori yang tersedia, waktu rendering, dan keterbacaan bagan menentukan batas yang berguna.

**Apa yang harus diubah ketika kolom terlalu berdekatan atau terlalu jauh?**

Atur [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) pada grup seri induk yang sesuai. Tingkatkan nilai untuk memperlebar ruang antara kelompok, atau kurangi untuk mendekatkan kelompok.