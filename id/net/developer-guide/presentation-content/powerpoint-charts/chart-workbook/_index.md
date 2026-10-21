---
title: Mengelola Workbook Diagram dalam Presentasi di .NET
linktitle: Workbook Diagram
type: docs
weight: 70
url: /id/net/chart-workbook/
keywords:
- workbook diagram
- data diagram
- sel workbook
- label data
- lembar kerja
- sumber data
- workbook eksternal
- data eksternal
- cache diagram
- pemulihan workbook
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan Aspose.Slides untuk .NET: kelola workbook diagram dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran workbook, menggunakan sel workbook sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan jenis sumber data untuk nilai diagram.

Artikel ini juga mencakup penggunaan workbook eksternal sebagai sumber data diagram. Contoh-contoh memperlihatkan cara membuat dan menetapkan workbook eksternal, mengambil jalur workbook eksternal yang terhubung ke diagram, dan mengedit data diagram ketika workbook tersedia.

Untuk sel workbook yang mewakili data yang hilang, lihat [Control the Display of Empty Cells](/slides/id/net/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan diagram garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) untuk mengontrol apakah diagram memplot data dari baris dan kolom lembar kerja yang tersembunyi. Atur ke `true` untuk memplot hanya sel yang terlihat, atau `false` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemetaan diagram; tidak menyembunyikan atau menampilkan baris atau kolom lembar kerja.

[Presentasi contoh](hidden-source-data.pptx) berisi diagram kolom sebagai bentuk pertama pada slide pertama. Lembar kerja yang disematkan, `Sheet1`, berisi rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C disembunyikan, namun sel‑selnya tetap berisi nilai.

| Baris lembar kerja | A: Bulan | B: Retail | C: Wholesale (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (baris tersembunyi) | Februari | 40 | 60 |
| 4 | Maret | 20 | 50 |

Akses sel sumber melalui [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) dan baca [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) untuk memeriksa status tersembunyinya. Properti ini hanya‑baca. Pada file ini, B2 terlihat, B3 termasuk dalam baris tersembunyi, dan C2 termasuk dalam kolom tersembunyi; contoh mencetak `False`, `True`, dan `True` secara berurutan.

Untuk contoh ini, segarkan data diagram setelah mengubah pengaturan pemetaan: pertahankan workbook yang disematkan dengan [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) dan muat ulang dengan [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Saat menyertakan semua sel, juga gunakan [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) untuk memulihkan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk menyegarkan data diagram yang di‑cache dalam contoh ini serta label kategori.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // Segarkan data diagram dari workbook yang disematkan.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Pulihkan rentang sumber lengkap, termasuk kategori tersembunyi.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Contoh menyimpan dua versi presentasi: satu hanya dengan nilai Retail yang terlihat (10 dan 20), dan satu lagi dengan semua enam nilai. Gambar di bawah dirender dari presentasi yang disimpan setelah dibuka kembali; kedua file mempertahankan pengaturan pemetaan yang ditetapkan. Baris 3 dan kolom C tetap tersembunyi dalam kedua workbook yang disematkan.

| Hanya sel yang terlihat (`true`) | Semua sel (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Sel tersembunyi yang berisi nilai berbeda dari sel kosong. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) mengontrol bagaimana nilai yang hilang ditampilkan; tidak menambahkan atau menghapus data sumber yang tersembunyi. Lihat [Control the Display of Empty Cells](/slides/id/net/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Dapatkan Rentang Data Grafik**

Sebelum memperbarui data workbook dalam presentasi yang ada, periksa rentang sumber untuk mengidentifikasi sel lembar kerja mana yang digunakan masing‑masing diagram. Metode [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) mengembalikan rentang data saat ini sebagai formula yang memenuhi kualifikasi lembar kerja, seperti `Sheet1!$A$1:$D$5`. Di sini, `Sheet1` adalah nama lembar kerja, `!` memisahkannya dari rentang sel, dan `$A$1:$D$5` menunjukkan sel A1 sampai D5, termasuk. Tanda dolar menandakan referensi baris dan kolom absolut.

Metode ini membaca rentang saat ini tanpa mengubah diagram atau workbook‑nya. Jika diagram tidak menggunakan workbook sebagai sumber data, metode ini melemparkan [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Untuk informasi lebih lanjut, lihat [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Contoh ini membuka presentasi dan memeriksa bentuk‑bentuk langsung pada setiap slide untuk diagram. Contoh mencetak nama tiap diagram dan rentang sumbernya. Jika sebuah diagram tidak menggunakan workbook, contoh mencetak pesan dan melanjutkan ke diagram berikutnya.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **Baca dan Tulis Data Diagram dari Workbook**

Aspose.Slides for .NET menyediakan metode [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) dan [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) yang memungkinkan Anda membaca dan menulis workbook data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau memiliki struktur serupa dengan sumbernya.

Contoh ini menggunakan presentasi dengan diagram sebagai bentuk pertama pada slide pertama. Contoh membaca workbook yang disematkan ke dalam aliran, menghapus seri dan kategori yang ada, dan menulis kembali workbook yang sama. Perubahan tetap berada di memori; contoh tidak menyimpan presentasi.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Validasi Tata Letak Grafik Setelah Modifikasi Workbook**

Ketika Anda mengganti workbook yang disematkan dengan yang telah dimodifikasi, diagram tetap mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) gagal dengan kesalahan indeks‑luar‑batas. Hapus seri dan kategori yang ada sebelum menulis kembali workbook yang diperbarui ke diagram. Contoh ini menggunakan diagram yang merupakan bentuk pertama pada slide pertama. Komentar menandai tempat dimana penyuntingan workbook akan dilakukan; contoh yang dapat dijalankan menulis kembali workbook asli dan memvalidasi tata letak di memori.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // Modifikasi aliran workbook di sini, misalnya, menggunakan Aspose.Cells.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Mengosongkan koleksi menghapus referensi data usang sebelum workbook ditulis kembali. Bangun kembali pemetaan seri dan kategori yang diperlukan untuk workbook yang diperbarui sebelum menggunakan diagram.

## **Atur Format Angka Kustom untuk Sel Workbook**

Gunakan [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) untuk mengontrol bagaimana nilai numerik muncul dalam workbook yang disematkan pada diagram. Misalnya, sebuah laporan mungkin memerlukan tingkat konversi ditampilkan sebagai persentase dengan empat tempat desimal dan koefisien ditampilkan dengan lima tempat desimal. Jaga kedua nilai tetap numerik agar tetap tersedia untuk perhitungan dan pemetaan diagram.

Format angka mengubah tampilan, bukan nilai yang disimpan. Format `0.0000%` menampilkan `0.125` sebagai `12.5000%`; tidak menggantikan angka yang disimpan dengan `12.5`. Demikian pula, `0.00000` menampilkan `0.1234567` sebagai `0.12346` tanpa membulatkan nilai yang disimpan. Jika format kustom berupa string kosong (`""`), [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) digunakan sebagai gantinya.

Contoh berikut membuat diagram kolom dan mengakses sel‑nya melalui [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). Pada lembar kerja 0, B2 berisi tingkat konversi dan C2 berisi koefisien. Kedua sel menyuplai nilai diagram. Contoh juga mengaktifkan label nilai yang terhubung ke format sumber.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

Format sel workbook terpisah dari format yang ditetapkan langsung pada sumbu diagram atau label data. Dalam contoh ini, setiap label menampilkan nilai sel sumber karena [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) diaktifkan, dan mengikuti format angka sumber karena [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) bernilai `true`. Setelah menyimpan dan membuka kembali presentasi, label menampilkan `12.5000%` dan `0.12346`, seperti terlihat di bawah. Sumbu vertikal menggunakan [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) miliknya sendiri `0.00`, dengan [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) disetel `false`.

Untuk memformat label data secara independen, setel flag tautan sumbernya ke `false` dan tetapkan [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/). Ini tidak mengubah format sel workbook. Misalnya, format label independen `0.00` menampilkan nilai pertama sebagai `0.13`, sementara B2 tetap menampilkan `12.5000%`. Lihat [Chart Data Labels](/slides/id/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) untuk pemformatan label langsung.

Gambar di bawah dirender dari presentasi yang disimpan setelah dibuka kembali:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **Atur Sel Workbook sebagai Label Data Diagram**

Anda dapat menggunakan teks dari sel workbook sebagai label data diagram.

Contoh ini menambahkan diagram gelembung dengan data default ke slide pertama dari presentasi yang ada. Contoh menggunakan sel A10:A12 pada lembar kerja 0 untuk tiga label pertama pada seri pertama, mengaktifkan label dari sel, dan menyimpan presentasi yang diperbarui.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **Kelola Lembar Kerja**

Properti [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) menyediakan akses ke lembar kerja dalam workbook diagram. Contoh ini membuat diagram pai dengan data default dan mencetak nama setiap lembar kerja ke konsol.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **Tentukan Jenis Sumber Data**

Contoh ini membuat diagram kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; nama kedua menggunakan sel C1 pada lembar kerja 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) memilih sumber untuk setiap nama. Contoh menyimpan presentasi dengan nama seri yang diperbarui.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Deteksi Format Workbook Tertanam yang Tidak Didukung**

Aspose.Slides tidak mendukung format workbook Excel biner (.xlsb) yang dapat tertanam pada beberapa diagram. Anda dapat menggunakan properti [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) pada [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan diagram‑diagram tersebut. Contoh ini memeriksa bentuk‑bentuk pada slide pertama dari presentasi yang ada, melewatkan bentuk non‑diagram, dan mencetak pesan diagnostik untuk setiap diagram dengan workbook .xlsb yang tertanam.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Baca atau ubah data workbook diagram yang didukung di sini.
}
```

## **Workbook Eksternal**

Aspose.Slides mendukung penggunaan workbook eksternal sebagai sumber data untuk diagram.

### **Buat Workbook Eksternal**

Gunakan [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) dan [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) untuk mengekspor workbook diagram yang disematkan ke file dan menautkan diagram ke workbook eksternal tersebut.

Contoh ini membuat diagram pai dengan data default dan mengekspor workbook‑nya. Contoh menutup aliran output sebelum menetapkan workbook eksternal sebagai sumber data diagram, lalu menyimpan presentasi yang ditautkan.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **Atur Workbook Eksternal**

Dengan menggunakan metode [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/), Anda dapat menetapkan workbook eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke workbook eksternal (jika workbook tersebut dipindahkan).

Meskipun Anda tidak dapat menyunting data dalam workbook yang disimpan di lokasi remote atau sumber daya, Anda tetap dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika jalur relatif untuk workbook eksternal diberikan, jalur tersebut akan dikonversi menjadi jalur penuh secara otomatis.

Contoh ini menggunakan workbook eksternal yang lembar kerjanya bernama `Sheet1` berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh membuat diagram pai, menautkan workbook, dan menggunakan [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Contoh menyimpan presentasi dengan diagram yang ditautkan.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

Parameter `updateChartData` pada [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) mengontrol apakah workbook dimuat.

* Ketika `updateChartData` bernilai `false`, hanya jalur workbook yang diperbarui. Data diagram tidak dimuat atau diperbarui dari workbook target, sehingga workbook dapat tidak tersedia.
* Ketika `updateChartData` bernilai `true`, data diagram diperbarui dari workbook target.

Contoh berikut menetapkan URL placeholder dengan `updateChartData` disetel ke `false`. Contoh mempertahankan data default diagram pai dan menyimpan presentasi tanpa memuat workbook yang tidak tersedia.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **Dapatkan Jalur Workbook Sumber Data Eksternal dari Diagram**

Untuk mengidentifikasi workbook yang ditautkan ke diagram, periksa apakah diagram menggunakan sumber data eksternal dan ambil jalur workbook‑nya.

Contoh ini memeriksa bentuk pertama pada slide pertama dari presentasi yang memiliki workbook eksternal yang ditautkan. Jika bentuk tersebut adalah diagram yang ditautkan ke workbook eksternal, contoh mencetak [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) ke konsol. Kemudian contoh menyimpan salinan presentasi.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **Edit Data Diagram**

Anda dapat menyunting data dalam workbook eksternal dengan cara yang sama seperti mengubah isi workbook internal. Ketika workbook eksternal tidak dapat dimuat, sebuah pengecualian akan dilemparkan.

Contoh ini menggunakan diagram yang merupakan bentuk pertama pada slide pertama dan ditautkan ke workbook eksternal yang dapat diakses. Contoh menetapkan nilai berbasis sel untuk titik data pertama pada seri pertama menjadi 100 dan menyimpan presentasi yang diperbarui. Menyunting nilai sel dapat memperbarui file XLSX eksternal yang ditautkan, jadi gunakan salinan jika Anda perlu mempertahankan workbook asli.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Pulihkan Workbook dari Cache Diagram**

Jika sebuah diagram menggunakan workbook eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi workbook diagram dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), konfigurasikan [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), dan atur [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) ke `true` sebelum membuka presentasi.

Contoh C# berikut memulihkan data workbook untuk diagram yang merupakan bentuk pertama pada slide pertama dan merujuk ke workbook eksternal yang tidak tersedia. Contoh mengakses data yang dipulihkan melalui [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) dan [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // Baca atau ubah data workbook yang dipulihkan di sini.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Jika workbook eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides melemparkan [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Aktifkan pemulihan hanya ketika menggunakan data diagram yang di‑cache merupakan fallback yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada workbook eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah diagram terhubung ke workbook eksternal atau yang disematkan?**

Ya. Diagram memiliki [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) dan [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); jika sumbernya adalah workbook eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal yang digunakan.

**Apakah jalur relatif ke workbook eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Presentasi menyimpan jalur absolut dalam file PPTX, sehingga memindahkan workbook mungkin memerlukan pembaruan tautan.

**Bisakah saya menggunakan workbook yang terletak di sumber daya/jaringan?**

Ya, workbook semacam itu dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan workbook remote secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Menyunting data diagram berbasis sel juga dapat memperbarui file XLSX lokal yang ditautkan. Gunakan salinan workbook jika yang asli harus tetap tidak berubah.

**Bagaimana jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan sebelumnya atau menyiapkan salinan yang didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/net/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa diagram merujuk ke workbook eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram pada pemuatan data berikutnya.