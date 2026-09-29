---
title: Kelola Workbook Diagram dalam Presentasi di .NET
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
description: "Temukan Aspose.Slides untuk .NET: dengan mudah kelola workbook diagram di format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan workbook diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran workbook, menggunakan sel workbook sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan tipe sumber data untuk nilai diagram.

Artikel ini juga mencakup penggunaan workbook eksternal sebagai sumber data diagram. Contoh-contoh menunjukkan cara membuat dan menetapkan workbook eksternal, mengambil jalur workbook eksternal yang terhubung ke diagram, dan mengedit data diagram ketika workbook tersedia.

Untuk sel workbook yang mewakili data yang hilang, lihat [Control the Display of Empty Cells](/slides/id/net/chart-series/) untuk perbedaan antara sel kosong dan nol, serta perbandingan diagram garis dari mode tampilan yang tersedia.

## **Sertakan Data dari Baris dan Kolom Tersembunyi**

Gunakan [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) untuk mengontrol apakah diagram memplot data dari baris dan kolom lembar kerja yang tersembunyi. Atur ke `true` untuk memplot hanya sel yang terlihat, atau `false` untuk menyertakan sel yang terlihat dan tersembunyi. Pengaturan ini mengontrol pemetaan diagram; tidak menyembunyikan atau menampilkan kembali baris atau kolom lembar kerja.

Unduh [hidden-source-data.pptx](hidden-source-data.pptx) dan letakkan di direktori kerja. Slide pertama berisi diagram kolom sebagai bentuk pertama. Lembar kerja tertanam, `Sheet1`, berisi rentang sumber berikut, `A1:C4`. Baris 3 dan kolom C tersembunyi, tetapi sel‑selnya masih berisi nilai.

| Baris lembar kerja | A: Bulan | B: Retail | C: Grosir (kolom tersembunyi) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (baris tersembunyi) | Februari | 40 | 60 |
| 4 | Maret | 20 | 50 |

Akses sel sumber melalui [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/chartdataworkbook/) dan baca [IChartDataCell.IsHidden](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdatacell/ishidden/) untuk memeriksa status tersembunyi mereka. Properti ini hanya‑baca. Dalam file ini, B2 terlihat, B3 berada di baris tersembunyi, dan C2 berada di kolom tersembunyi; contoh mencetak `False`, `True`, dan `True` secara berurutan.

Untuk contoh ini, segarkan data diagram setelah mengubah pengaturan pemetaan: pertahankan workbook tertanam dengan [ReadWorkbookStream](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/readworkbookstream/) dan muat kembali dengan [WriteWorkbookStream](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Saat menyertakan semua sel, gunakan juga [SetRange](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/setrange/) untuk mengembalikan rentang lengkap, termasuk kategori Februari yang tersembunyi. Mengubah flag saja tidak cukup untuk menyegarkan data diagram dan label kategori yang di‑cache dalam contoh ini.

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

        // Segarkan data diagram dari workbook yang tertanam.
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

Contoh menyimpan `hidden_cells_True.pptx` hanya dengan nilai Retail yang terlihat (10 dan 20), dan `hidden_cells_False.pptx` dengan semua enam nilai. Gambar di bawah dirender dari presentasi yang disimpan setelah dibuka kembali; kedua file mempertahankan pengaturan pemetaan yang ditetapkan. Baris 3 dan kolom C tetap tersembunyi di kedua workbook tertanam.

| Hanya sel yang terlihat (`true`) | Semua sel (`false`) |
| --- | --- |
| ![Hanya sel yang terlihat: nilai Retail 10 dan 20 untuk Januari dan Maret.](hidden_cells_True.png) | ![Semua sel: nilai Retail dan Grosir untuk Januari, Februari, dan Maret.](hidden_cells_False.png) |

Sel tersembunyi yang berisi nilai berbeda dari sel kosong. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/displayblanksas/) mengontrol cara nilai yang hilang ditampilkan; tidak menyertakan atau mengecualikan data sumber yang tersembunyi. Lihat [Control the Display of Empty Cells](/slides/id/net/chart-series/#control-the-display-of-empty-cells) untuk contoh.

## **Baca dan Tulis Data Diagram dari Workbook**

Aspose.Slides untuk .NET menyediakan metode [ReadWorkbookStream](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/readworkbookstream/) dan [WriteWorkbookStream](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/writeworkbookstream/) yang memungkinkan Anda membaca dan menulis workbook data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** data diagram harus diatur dengan cara yang sama atau memiliki struktur serupa dengan sumbernya.

Contoh ini membuka `chart.pptx`, yang harus berisi diagram sebagai bentuk pertama pada slide pertamanya. Contoh ini membaca workbook tertanam ke dalam aliran, mengosongkan seri dan kategori yang ada, dan menulis kembali workbook yang sama. Perubahan tetap dalam memori; contoh tidak menyimpan presentasi.

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

### **Validasi Tata Letak Diagram Setelah Modifikasi Workbook**

Ketika Anda mengganti workbook tertanam dengan yang telah dimodifikasi, diagram mempertahankan koleksi seri dan kategori aslinya. Ketidaksesuaian ini dapat menyebabkan [IChart.ValidateChartLayout](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/validatechartlayout/) gagal dengan kesalahan indeks di luar jangkauan. Hapus seri dan kategori yang ada sebelum menulis kembali workbook yang diperbarui ke diagram. Contoh ini membutuhkan `chart.pptx` dengan diagram sebagai bentuk pertama pada slide pertamanya. Komentar menandai tempat penyuntingan workbook; contoh yang dapat dijalankan menulis kembali workbook asli dan memvalidasi tata letak di memori.

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

    // Ubah aliran workbook di sini, misalnya, menggunakan Aspose.Cells.

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

Mengosongkan koleksi menghilangkan referensi data usang sebelum workbook ditulis kembali. Bangun kembali pemetaan seri dan kategori yang diperlukan untuk workbook yang diperbarui sebelum menggunakan diagram.

## **Tetapkan Sel Workbook sebagai Label Data Diagram**

Anda dapat menggunakan teks dari sel workbook sebagai label data diagram. Langkah‑langkah berikut menunjukkan cara menautkan label dalam diagram gelembung ke sel di workbook datanya.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Akses slide pertama berdasarkan indeks berbasis nol.
3. Tambahkan diagram gelembung dengan data default.
4. Akses seri diagram.
5. Tetapkan sel workbook sebagai label data.
6. Simpan presentasi.

Contoh ini membuka `chart2.pptx`, yang harus berisi setidaknya satu slide, dan menambahkan diagram gelembung dengan data default. Contoh ini menggunakan sel A10:A12 pada lembar kerja 0 untuk tiga label pertama dalam seri pertama, mengaktifkan label dari sel, dan menyimpan hasilnya ke `resultchart.pptx`.

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

Properti [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/worksheets/) menyediakan akses ke lembar kerja dalam workbook diagram. Contoh ini membuat diagram lingkaran dengan data default dan mencetak setiap nama lembar kerja ke konsol.

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

Contoh ini membuat diagram kolom 3D dengan data default dan menetapkan dua nama seri menggunakan sumber data yang berbeda. Nama pertama menggunakan literal string; nama kedua menggunakan sel C1 pada lembar kerja 0. Enumerasi [DataSourceType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/datasourcetype/) memilih sumber untuk setiap nama. Hasil disimpan ke `pres.pptx`.

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

Aspose.Slides tidak mendukung format workbook Excel biner (.xlsb) yang dapat tertanam dalam beberapa diagram. Anda dapat menggunakan properti [EmbeddedWorkbookType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) pada [IChartData](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan diagram‑diagram tersebut. Contoh ini memeriksa bentuk pada slide pertama `sample.pptx`, melewatkan bentuk bukan diagram, dan mencetak pesan diagnostik untuk setiap diagram dengan workbook .xlsb tertanam.

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

    // Baca atau modifikasi data workbook diagram yang didukung di sini.
}
```

## **Workbook Eksternal**

Aspose.Slides mendukung penggunaan workbook eksternal sebagai sumber data untuk diagram.

### **Buat Workbook Eksternal**

Gunakan [ReadWorkbookStream](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/readworkbookstream/) dan [SetExternalWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/setexternalworkbook/) untuk mengekspor workbook diagram tertanam ke file dan menautkan diagram ke workbook eksternal tersebut.

Contoh ini membuat diagram lingkaran dengan data default, menulis workbook‑nya ke `externalWorkbook1.xlsx`, dan menutup aliran output sebelum menetapkan file tersebut sebagai sumber data diagram. Contoh ini menyimpan presentasi yang ditautkan ke `externalWorkbook.pptx`.

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

Dengan metode [SetExternalWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/setexternalworkbook/), Anda dapat menetapkan workbook eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke workbook eksternal (jika workbook tersebut dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam workbook yang disimpan di lokasi remote atau sumber daya, Anda tetap dapat menggunakan workbook tersebut sebagai sumber data eksternal. Jika jalur relatif untuk workbook eksternal diberikan, jalur tersebut secara otomatis dikonversi ke jalur penuh.

Contoh ini memerlukan `externalWorkbook.xlsx` di direktori kerja. Lembar kerja bernama `Sheet1` harus berisi nama seri di B1, nama kategori di A2:A4, dan nilai numerik di B2:B4. Contoh ini membuat diagram lingkaran, menautkan workbook, dan menggunakan [SetRange](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/setrange/) untuk memetakan A1:B4 ke satu seri dan tiga kategori. Hasil disimpan ke `Presentation_with_externalWorkbook.pptx`.

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

Parameter `updateChartData` pada [SetExternalWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/setexternalworkbook/) mengontrol apakah workbook dimuat.

* Ketika `updateChartData` bernilai `false`, hanya jalur workbook yang diperbarui. Data diagram tidak dimuat atau diperbarui dari workbook target, sehingga workbook dapat tidak tersedia.
* Ketika `updateChartData` bernilai `true`, data diagram diperbarui dari workbook target.

Contoh berikut menetapkan URL placeholder dengan `updateChartData` diset ke `false`. Contoh ini mempertahankan data default diagram lingkaran dan menyimpan presentasi tanpa memuat workbook yang tidak tersedia.

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

Untuk mengidentifikasi workbook yang ditautkan ke diagram, pertama periksa apakah diagram menggunakan sumber data eksternal. Jika ya, Anda dapat mengambil jalur workbook dengan mengikuti langkah‑langkah berikut.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Akses slide pertama berdasarkan indeks berbasis nol.
3. Periksa bahwa bentuk pertama adalah diagram.
4. Baca tipe sumber data diagram.
5. Jika sumbernya adalah workbook eksternal, baca jalurnya.

Contoh ini membuka `externalWorkbook.pptx`, yang dibuat pada contoh sebelumnya, dan memeriksa bentuk pertama pada slide pertama. Jika bentuk tersebut adalah diagram yang ditautkan ke workbook eksternal, contoh mencetak [ExternalWorkbookPath](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/externalworkbookpath/) ke konsol. Kemudian contoh menyimpan salinan presentasi ke `Result.pptx`.

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

### **Sunting Data Diagram**

Anda dapat menyunting data dalam workbook eksternal dengan cara yang sama seperti mengubah isi workbook internal. Ketika workbook eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Contoh ini memerlukan `presentation.pptx` dengan diagram sebagai bentuk pertama pada slide pertama serta workbook eksternal yang dapat diakses. Contoh ini menetapkan nilai berbasis sel pada titik data pertama dalam seri pertama menjadi 100 dan menyimpan presentasi ke `presentation_out.pptx`. Menyunting nilai sel dapat memperbarui file XLSX eksternal yang ditautkan, jadi gunakan salinan jika Anda perlu mempertahankan workbook asli.

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

Jika sebuah diagram menggunakan workbook eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat merekonstruksi workbook diagram dari data yang di‑cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/), konfigurasikan [SpreadsheetOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/spreadsheetoptions/), dan setel [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/id/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) ke `true` sebelum membuka presentasi.

Contoh C# berikut membuka `presentation.pptx`, yang bentuk pertama pada slide pertamanya harus berupa diagram yang merujuk ke workbook eksternal yang tidak tersedia, dan mengakses data yang dipulihkan melalui [IChart.ChartData](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/chartdata/) dan [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

Jika workbook eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Aktifkan pemulihan hanya ketika penggunaan data diagram yang di‑cache merupakan solusi yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada workbook eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah diagram tertentu terhubung ke workbook eksternal atau tertanam?**

Ya. Diagram memiliki [data source type](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/datasourcetype/) dan [path to an external workbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/externalworkbookpath/); jika sumbernya adalah workbook eksternal, Anda dapat membaca jalur lengkapnya untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke workbook eksternal didukung, dan bagaimana cara penyimpanannya?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis dikonversi menjadi jalur absolut. Presentasi menyimpan jalur absolut di dalam file PPTX, jadi memindahkan workbook mungkin memerlukan pembaruan tautan.

**Apakah saya dapat menggunakan workbook yang berada di sumber daya/jaringan bersama?**

Ya, workbook semacam itu dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan workbook remote langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Presentasi menyimpan [link to the external file](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/externalworkbookpath/). Menyunting data diagram yang berbasis sel juga dapat memperbarui file XLSX lokal yang ditautkan. Gunakan salinan workbook jika file asli harus tetap tidak berubah.

**Apa yang harus saya lakukan jika file eksternal dilindungi sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang sudah didekripsi (misalnya dengan [Aspose.Cells](https://reference.aspose.com/cells/net/)) dan menautkan ke salinan tersebut.

**Dapatkah beberapa diagram merujuk ke workbook eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semuanya menunjuk ke file yang sama, memperbarui file tersebut akan tercermin di setiap diagram pada saat data dimuat kembali.