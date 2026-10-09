---
title: Kelola Workbook Grafik dalam Presentasi di .NET
linktitle: Workbook Grafik
type: docs
weight: 70
url: /id/net/chart-workbook/
keywords:
- workbook grafik
- data grafik
- sel workbook
- label data
- lembar kerja
- sumber data
- workbook eksternal
- data eksternal
- cache grafik
- pemulihan workbook
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan Aspose.Slides untuk .NET: kelola workbook grafik dalam format PowerPoint dan OpenDocument dengan mudah untuk menyederhanakan data presentasi Anda."
---
## **Ringkasan**

Artikel ini menjelaskan cara bekerja dengan workbook grafik di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data grafik melalui stream workbook, menggunakan sel workbook sebagai label data grafik, mengakses koleksi worksheet, dan menentukan tipe sumber data untuk nilai grafik.

Artikel ini juga mencakup penggunaan workbook eksternal sebagai sumber data grafik. Contoh-contoh memperlihatkan cara membuat dan menetapkan workbook eksternal, mengambil jalur workbook eksternal yang terhubung ke grafik, dan mengedit data grafik ketika workbook tersedia.

Untuk sel workbook yang mewakili data yang hilang, lihat [Kontrol Tampilan Sel Kosong](/slides/id/net/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan grafik garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) untuk mengontrol apakah grafik memplot data dari baris dan kolom worksheet yang tersembunyi. Setel ke `true` untuk memplot hanya sel yang terlihat, atau `false` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemetaan grafik; tidak menyembunyikan atau menampilkan kembali baris atau kolom worksheet.

[presentasi contoh](hidden-source-data.pptx) berisi grafik kolom sebagai bentuk pertama pada slide pertama. Worksheet yang disematkan, `Sheet1`, berisi rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C tersembunyi, tetapi sel‑selnya tetap berisi nilai.

| Baris worksheet | A: Bulan | B: Eceran | C: Grosir (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (baris tersembunyi) | Februari | 40 | 60 |
| 4 | Maret | 20 | 50 |

Akses sel sumber melalui [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) dan baca [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) untuk memeriksa status tersembunyi mereka. Properti ini hanya dapat dibaca. Dalam file ini, B2 terlihat, B3 termasuk dalam baris tersembunyi, dan C2 termasuk dalam kolom tersembunyi; contoh mencetak `False`, `True`, dan `True` masing‑masing.

Untuk contoh ini, segarkan data grafik setelah mengubah pengaturan plot: pertahankan workbook yang disematkan dengan [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) dan muat kembali dengan [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Saat menyertakan semua sel, juga gunakan [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) untuk mengembalikan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk menyegarkan data grafik yang di‑cache dalam contoh ini dan label kategori.

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

        // Segarkan data grafik dari workbook yang disematkan.
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

Contoh menyimpan dua versi presentasi: satu dengan hanya nilai Eceran yang terlihat (10 dan 20), dan satu lagi dengan semua enam nilai. Gambar di bawah dirender dari presentasi yang disimpan setelah dibuka kembali; kedua file mempertahankan pengaturan plot yang ditetapkan. Baris 3 dan kolom C tetap tersembunyi di kedua workbook yang disematkan.

| Hanya sel terlihat (`true`) | Semua sel (`false`) |
| --- | --- |
| ![Hanya sel terlihat: nilai Eceran 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Eceran dan Grosir untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sel tersembunyi yang berisi nilai berbeda dari sel kosong. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) mengontrol bagaimana nilai yang hilang ditampilkan; tidak menyertakan atau mengecualikan data sumber yang tersembunyi. Lihat [Kontrol Tampilan Sel Kosong](/slides/id/net/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Ambil Rentang Data Grafik**

Sebelum memperbarui data workbook dalam presentasi yang ada, periksa rentang sumber untuk mengidentifikasi sel worksheet mana yang digunakan setiap grafik. Metode [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) mengembalikan rentang data saat ini sebagai formula yang memenuhi worksheet, seperti `Sheet1!$A$1:$D$5`. Di sini, `Sheet1` adalah nama worksheet, `!` memisahkannya dari rentang sel, dan `$A$1:$D$5` mengidentifikasi sel A1 sampai D5, inklusif. Tanda dolar menunjukkan referensi baris dan kolom absolut.

Metode ini membaca rentang saat ini tanpa mengubah grafik atau workbook‑nya. Jika grafik tidak menggunakan workbook sebagai sumber data, metode akan menimbulkan [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Untuk informasi lebih lanjut, lihat [Referensi API ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Contoh ini membuka presentasi dan memeriksa bentuk‑bentuk secara langsung pada tiap slide untuk grafik. Ia mencetak nama setiap grafik dan rentang sumbernya. Jika grafik tidak menggunakan workbook, ia mencetak pesan dan melanjutkan ke grafik berikutnya.

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

## **Baca dan Tulis Data Grafik dari Workbook**

Aspose.Slides untuk .NET menyediakan metode [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) dan [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) yang memungkinkan Anda membaca dan menulis workbook data grafik (yang berisi data grafik yang diedit dengan Aspose.Cells). **Catatan** bahwa data grafik harus diatur dengan cara yang sama atau memiliki struktur serupa dengan sumbernya.

Contoh ini menggunakan presentasi dengan grafik sebagai bentuk pertama pada slide pertama. Ia membaca workbook yang disematkan ke dalam stream, menghapus seri dan kategori yang ada, dan menulis kembali workbook yang sama. Perubahan tetap di memori; contoh tidak menyimpan presentasi.

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

Saat Anda mengganti workbook yang disematkan dengan yang telah dimodifikasi, grafik tetap mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) gagal dengan kesalahan indeks di luar jangkauan. Hapus seri dan kategori yang ada sebelum menulis kembali workbook yang diperbarui ke grafik. Contoh ini menggunakan grafik yang merupakan bentuk pertama pada slide pertama. Komentar menandai tempat pengeditan workbook akan terjadi; contoh yang dapat dijalankan menulis kembali workbook asli dan memvalidasi tata letak di memori.

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

Mengosongkan koleksi menghapus referensi data lama sebelum workbook ditulis kembali. Bangun kembali semua pemetaan seri dan kategori yang diperlukan untuk workbook yang diperbarui sebelum menggunakan grafik.

## **Tetapkan Sel Workbook sebagai Label Data Grafik**

Anda dapat menggunakan teks dari sel workbook sebagai label data grafik.

Contoh ini menambahkan grafik gelembung dengan data default ke slide pertama dari presentasi yang ada. Ia menggunakan sel A10:A12 pada worksheet 0 untuk tiga label pertama pada seri pertama, mengaktifkan label dari sel, dan menyimpan presentasi yang diperbarui.

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

## **Kelola Worksheet**

Properti [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) menyediakan akses ke worksheet dalam workbook grafik. Contoh ini membuat grafik pai dengan data default dan mencetak setiap nama worksheet ke konsol.

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

## **Tentukan Tipe Sumber Data**

Contoh ini membuat grafik kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; nama kedua menggunakan sel C1 pada worksheet 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) memilih sumber untuk tiap nama. Contoh menyimpan presentasi dengan nama seri yang diperbarui.

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

Aspose.Slides tidak mendukung format workbook Excel biner (.xlsb) yang dapat tertanam dalam beberapa grafik. Anda dapat menggunakan properti [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) pada [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan grafik tersebut. Contoh ini memeriksa bentuk‑bentuk pada slide pertama dari presentasi yang ada, melewatkan bentuk non‑grafik, dan mencetak pesan diagnostik untuk setiap grafik dengan workbook .xlsb tertanam.

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

    // Baca atau ubah data workbook grafik yang didukung di sini.
}
```

## **Workbook Eksternal**

Aspose.Slides mendukung penggunaan workbook eksternal sebagai sumber data untuk grafik.

### **Buat Workbook Eksternal**

Gunakan [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) dan [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) untuk mengekspor workbook grafik yang tertanam ke file dan menautkan grafik ke workbook eksternal tersebut.

Contoh ini membuat grafik pai dengan data default dan mengekspor workbook‑nya. Ia menutup stream output sebelum menetapkan workbook eksternal sebagai sumber data grafik, lalu menyimpan presentasi yang ditautkan.

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

### **Tetapkan Workbook Eksternal**

Dengan menggunakan metode [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/), Anda dapat menetapkan workbook eksternal ke grafik sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke workbook eksternal (jika workbook tersebut telah dipindahkan).

Meskipun Anda tidak dapat menyunting data dalam workbook yang disimpan di lokasi atau sumber daya remote, Anda masih dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika jalur relatif untuk workbook eksternal disediakan, jalur tersebut secara otomatis dikonversi ke jalur lengkap.

Contoh ini menggunakan workbook eksternal yang worksheet‑nya bernama `Sheet1` berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh membuat grafik pai, menautkan workbook, dan menggunakan [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Ia menyimpan presentasi dengan grafik yang ditautkan.

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

Parameter `updateChartData` pada metode [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) mengontrol apakah workbook dimuat.

* Ketika `updateChartData` bernilai `false`, hanya jalur workbook yang diperbarui. Data grafik tidak dimuat atau diperbarui dari workbook target, sehingga workbook dapat tidak tersedia.
* Ketika `updateChartData` bernilai `true`, data grafik diperbarui dari workbook target.

Contoh berikut menetapkan URL placeholder dengan `updateChartData` disetel ke `false`. Ia mempertahankan data default grafik pai dan menyimpan presentasi tanpa memuat workbook yang tidak tersedia.

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

### **Dapatkan Jalur Workbook Sumber Data Eksternal dari Grafik**

Untuk mengidentifikasi workbook yang ditautkan ke grafik, periksa apakah grafik menggunakan sumber data eksternal dan ambil jalur workbook‑nya.

Contoh ini memeriksa bentuk pertama pada slide pertama dari presentasi dengan workbook eksternal yang ditautkan. Jika itu adalah grafik yang ditautkan ke workbook eksternal, contoh mencetak [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) ke konsol. Kemudian ia menyimpan salinan presentasi.

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

### **Sunting Data Grafik**

Anda dapat menyunting data dalam workbook eksternal dengan cara yang sama seperti mengubah konten workbook internal. Ketika workbook eksternal tidak dapat dimuat, pengecualian akan dilempar.

Contoh ini menggunakan grafik yang merupakan bentuk pertama pada slide pertama dan ditautkan ke workbook eksternal yang dapat diakses. Ia menetapkan nilai sel pertama pada poin data pertama dalam seri pertama menjadi 100 dan menyimpan presentasi yang diperbarui. Menyunting nilai sel dapat memperbarui file XLSX eksternal yang ditautkan, jadi gunakan salinan bila Anda perlu mempertahankan workbook asli.

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

### **Pulihkan Workbook dari Cache Grafik**

Jika grafik menggunakan workbook eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi workbook grafik dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), konfigurasikan [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), dan setel [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) ke `true` sebelum membuka presentasi.

Contoh C# berikut memulihkan data workbook untuk grafik yang merupakan bentuk pertama pada slide pertama dan merujuk ke workbook eksternal yang tidak tersedia. Ia mengakses data yang dipulihkan melalui [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) dan [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

Jika workbook eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides melempar [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Aktifkan pemulihan hanya ketika menggunakan data grafik yang di‑cache dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada workbook eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah grafik tertentu ditautkan ke workbook eksternal atau tertanam?**

Ya. Sebuah grafik memiliki [tipe sumber data](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) dan [jalur ke workbook eksternal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); jika sumbernya adalah workbook eksternal, Anda dapat membaca jalur lengkapnya untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke workbook eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi ke jalur absolut. Presentasi menyimpan jalur absolut dalam file PPTX, sehingga memindahkan workbook mungkin memerlukan pembaruan tautan.

**Dapatkah saya menggunakan workbook yang terletak pada sumber daya/jaringan bersama?**

Ya, workbook tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan workbook remote secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [tautan ke file eksternal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Menyunting data grafik yang berbasis sel juga dapat memperbarui file XLSX lokal yang ditautkan. Gunakan salinan workbook jika yang asli harus tetap tidak berubah.

**Apa yang harus saya lakukan jika file eksternal dilindungi sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan sebelumnya atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](https://reference.aspose.com/cells/net/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa grafik merujuk ke workbook eksternal yang sama?**

Ya. Setiap grafik menyimpan tautannya sendiri. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap grafik pada saat data dimuat berikutnya.