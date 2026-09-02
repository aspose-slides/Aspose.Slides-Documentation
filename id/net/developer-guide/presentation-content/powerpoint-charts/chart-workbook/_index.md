---
title: Kelola Buku Kerja Diagram dalam Presentasi di .NET
linktitle: Buku Kerja Diagram
type: docs
weight: 70
url: /id/net/chart-workbook/
keywords:
- buku kerja diagram
- data diagram
- sel buku kerja
- label data
- lembar kerja
- sumber data
- buku kerja eksternal
- data eksternal
- cache diagram
- pemulihan buku kerja
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan Aspose.Slides untuk .NET: kelola buku kerja diagram dengan mudah dalam format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Ringkasan**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan tipe sumber data untuk nilai diagram.

Artikel ini juga mencakup cara bekerja dengan buku kerja eksternal sebagai sumber data diagram. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke diagram, serta mengedit data diagram ketika buku kerja tersedia.

## **Baca dan Tulis Data Diagram dari Buku Kerja**
Aspose.Slides menyediakan metode [ReadWorkbookStream](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/readworkbookstream/) dan [WriteWorkbookStream](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/writeworkbookstream/) yang memungkinkan Anda membaca dan menulis buku kerja data diagram (yang berisi data diagram yang diedit dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau harus memiliki struktur yang mirip dengan sumbernya.

```c#
using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

## **Setel Sel WorkBook sebagai Label Data Diagram**
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram Bubble dengan beberapa data.
4. Akses seri diagram.
5. Setel sel buku kerja sebagai label data.
6. Simpan presentasi.

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Menginstansiasi kelas presentasi yang mewakili file presentasi 

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Kelola Lembar Kerja**

Kode C# ini menunjukkan operasi di mana properti [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) digunakan untuk mengakses koleksi lembar kerja:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Tentukan Tipe Sumber Data**

Kode C# ini menunjukkan cara menentukan tipe untuk sumber data:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Deteksi Format Buku Kerja Tersemat yang Tidak Didukung**

Aspose.Slides tidak mendukung format buku kerja biner Excel (.xlsb) yang dapat tersemat di beberapa diagram. Anda dapat menggunakan properti `EmbeddedWorkbookType` pada [IChartData](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewati diagram-diagram tersebut.

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // Buku kerja tersemat berada dalam format .xlsb, yang tidak didukung.
            continue;
        }

        // Baca atau ubah data buku kerja diagram di sini.
    }
}
```

## **Buku Kerja Eksternal**

{{% alert color="primary" %}} 
Pada [Aspose.Slides 19.4](https://docs.aspose.com/slides/id/net/aspose-slides-for-net-19-4-release-notes/), kami menambahkan dukungan untuk buku kerja eksternal sebagai sumber data bagi diagram.
{{% /alert %}} 

### **Buat Buku Kerja Eksternal**
Dengan menggunakan metode **`ReadWorkbookStream`** dan **`SetExternalWorkbook`**, Anda dapat membuat buku kerja eksternal dari awal atau mengubah buku kerja internal menjadi eksternal.

```c#
using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **Setel Buku Kerja Eksternal**
Dengan menggunakan metode **`SetExternalWorkbook`**, Anda dapat menetapkan buku kerja eksternal ke sebuah diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam buku kerja yang disimpan di lokasi atau sumber daya jarak jauh, Anda tetap dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal diberikan, jalur tersebut secara otomatis akan diubah menjadi jalur lengkap.

Kode C# ini menunjukkan cara menetapkan buku kerja eksternal:

```c#
// Jalur ke direktori dokumen.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

Parameter `ChartData` (di bawah metode `SetExternalWorkbook`) digunakan untuk menentukan apakah buku kerja Excel akan dimuat atau tidak. 

* Ketika nilai `ChartData` diatur ke `false`, hanya jalur buku kerja yang diperbarui—data diagram tidak akan dimuat atau diperbarui dari buku kerja target. Anda mungkin ingin menggunakan pengaturan ini ketika buku kerja target tidak ada atau tidak tersedia. 
* Ketika nilai `ChartData` diatur ke `true`, data diagram diperbarui dari buku kerja target.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Dapatkan Jalur Buku Kerja Sumber Data Eksternal dari Sebuah Diagram**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya.
3. Buat objek untuk bentuk diagram.
4. Buat objek untuk tipe sumber (`ChartDataSourceType`) yang mewakili sumber data diagram.
5. Tentukan kondisi yang relevan berdasarkan tipe sumber yang sama dengan tipe sumber data buku kerja eksternal.

Kode C# ini menunjukkan operasi tersebut:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Menyimpan presentasi
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Edit Data Diagram**

Anda dapat mengedit data dalam buku kerja eksternal dengan cara yang sama seperti mengubah isi buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Kode C# ini merupakan implementasi dari proses yang dijelaskan:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Pulihkan Buku Kerja dari Cache Diagram**

Jika sebuah diagram menggunakan buku kerja eksternal yang hilang atau tidak tersedia, Aspose.Slides dapat membangun kembali buku kerja diagram dari data yang di-cache dalam presentasi. Buat [LoadOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/), konfigurasikan [SpreadsheetOptions](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/spreadsheetoptions/), dan setel [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/id/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) ke `true` sebelum membuka presentasi.

Contoh C# berikut membuka sebuah presentasi yang diagramnya merujuk ke buku kerja eksternal yang tidak tersedia dan mengakses data yang dipulihkan melalui [IChart.ChartData](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichart/chartdata/) dan [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

Jika buku kerja eksternal tidak tersedia dan pemulihan dinonaktifkan, Aspose.Slides akan melempar `InvalidOperationException`. Aktifkan pemulihan hanya ketika penggunaan data diagram yang di-cache merupakan alternatif yang dapat diterima, karena cache mungkin tidak berisi perubahan yang dibuat pada buku kerja eksternal setelah presentasi terakhir diperbarui.

## **FAQ**

**Apakah saya dapat menentukan apakah sebuah diagram tertentu terhubung ke buku kerja eksternal atau tersemat?**

Ya. Sebuah diagram memiliki [tipe sumber data](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/datasourcetype/) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/externalworkbookpath/); jika sumbernya adalah buku kerja eksternal, Anda dapat membaca jalur lengkap untuk memastikan sebuah file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana mereka disimpan?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis akan diubah menjadi jalur absolut. Ini memudahkan portabilitas proyek; namun, perlu diingat bahwa presentasi akan menyimpan jalur absolut dalam file PPTX.

**Apakah saya dapat menggunakan buku kerja yang terletak di sumber daya/jaringan bersama?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan buku kerja jarak jauh langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan sebuah [tautan ke file eksternal](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/externalworkbookpath/) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak diubah saat presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi kata sandi?**

Aspose.Slides tidak menerima kata sandi saat menautkan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang telah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/net/)) dan menautkan ke salinan tersebut.

**Apakah beberapa diagram dapat merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semuanya mengarah ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram pada kali berikutnya data dimuat.