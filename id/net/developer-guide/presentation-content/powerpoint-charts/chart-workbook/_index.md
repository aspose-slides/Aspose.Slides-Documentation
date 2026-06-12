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
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan Aspose.Slides untuk .NET: kelola buku kerja diagram dengan mudah di format PowerPoint dan OpenDocument untuk menyederhanakan data presentasi Anda."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan buku kerja diagram di Aspose.Slides. Artikel ini menunjukkan cara membaca dan menulis data diagram melalui aliran buku kerja, menggunakan sel buku kerja sebagai label data diagram, mengakses koleksi lembar kerja, dan menentukan jenis sumber data untuk nilai diagram.

Artikel ini juga membahas cara bekerja dengan buku kerja eksternal sebagai sumber data diagram. Contoh-contoh menunjukkan cara membuat dan menetapkan buku kerja eksternal, mengambil jalur buku kerja eksternal yang terhubung ke sebuah diagram, dan mengedit data diagram ketika buku kerja tersedia.

## **Membaca dan Menulis Data Diagram dari Buku Kerja**

Aspose.Slides menyediakan metode [ReadWorkbookStream](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/readworkbookstream/) dan [WriteWorkbookStream](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/writeworkbookstream/) yang memungkinkan Anda membaca dan menulis buku kerja data diagram (yang berisi data diagram yang disunting dengan Aspose.Cells). **Catatan** bahwa data diagram harus diatur dengan cara yang sama atau harus memiliki struktur yang mirip dengan sumber.

Kode C# ini menunjukkan operasi contoh:
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

## **Menetapkan Sel Buku Kerja sebagai Label Data Diagram**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan diagram Bubble dengan beberapa data.
4. Akses seri diagram.
5. Setel sel buku kerja sebagai label data.
6. Simpan presentasi.

Kode C# ini menunjukkan cara menetapkan sel buku kerja sebagai label data diagram:
```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Membuat instance kelas presentasi yang merepresentasikan file presentasi 

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

## **Tentukan Jenis Sumber Data**

Kode C# ini menunjukkan cara menentukan jenis untuk sumber data:
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

Aspose.Slides tidak mendukung format buku kerja biner Excel (.xlsb) yang dapat tersemat dalam beberapa diagram. Anda dapat menggunakan properti `EmbeddedWorkbookType` pada [IChartData](https://reference.aspose.com/slides/id/net/aspose.slides.charts/ichartdata/) bersama dengan enumerasi [WorkbookType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/workbooktype/) untuk mendeteksi format yang tidak didukung dan melewatkan diagram‑diagram tersebut.
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
            // Buku kerja tersemat berformat .xlsb, yang tidak didukung.
            continue;
        }

        // Baca atau ubah data buku kerja diagram di sini.
    }
}
```

## **Buku Kerja Eksternal**
{{% alert color="primary" %}} 
Pada [Aspose.Slides 19.4](https://docs.aspose.com/slides/id/net/aspose-slides-for-net-19-4-release-notes/) kami menambahkan dukungan untuk buku kerja eksternal sebagai sumber data untuk diagram.
{{% /alert %}} 

### **Buat Buku Kerja Eksternal**
Dengan menggunakan metode **`ReadWorkbookStream`** dan **`SetExternalWorkbook`**, Anda dapat membuat buku kerja eksternal dari awal atau mengubah buku kerja internal menjadi eksternal.

Kode C# ini menunjukkan proses pembuatan buku kerja eksternal:
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

### **Tetapkan Buku Kerja Eksternal**
Dengan menggunakan metode **`SetExternalWorkbook`**, Anda dapat menetapkan buku kerja eksternal ke diagram sebagai sumber datanya. Metode ini juga dapat digunakan untuk memperbarui jalur ke buku kerja eksternal (jika buku kerja tersebut telah dipindahkan).

Meskipun Anda tidak dapat mengedit data dalam buku kerja yang disimpan di lokasi atau sumber daya jarak jauh, Anda masih dapat menggunakan buku kerja tersebut sebagai sumber data eksternal. Jika jalur relatif untuk buku kerja eksternal diberikan, jalur tersebut secara otomatis akan dikonversi menjadi jalur lengkap.

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

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
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

Anda dapat mengedit data dalam buku kerja eksternal dengan cara yang sama seperti Anda mengubah isi buku kerja internal. Ketika buku kerja eksternal tidak dapat dimuat, sebuah pengecualian akan dilempar.

Kode C# ini adalah implementasi dari proses yang dijelaskan:
```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah saya dapat menentukan apakah diagram tertentu terhubung ke buku kerja eksternal atau tersemat?**

Ya. Sebuah diagram memiliki [jenis sumber data](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/datasourcetype/) dan [jalur ke buku kerja eksternal](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/externalworkbookpath/); jika sumbernya merupakan buku kerja eksternal, Anda dapat membaca jalur lengkap untuk memastikan file eksternal sedang digunakan.

**Apakah jalur relatif ke buku kerja eksternal didukung, dan bagaimana mereka disimpan?**

Ya. Jika Anda menentukan jalur relatif, jalur tersebut secara otomatis akan dikonversi menjadi jalur absolut. Ini memudahkan portabilitas proyek; namun, perlu diingat bahwa presentasi akan menyimpan jalur absolut dalam file PPTX.

**Apakah saya dapat menggunakan buku kerja yang berada pada sumber daya/jaringan bersama?**

Ya, buku kerja tersebut dapat digunakan sebagai sumber data eksternal. Namun, penyuntingan buku kerja jarak jauh secara langsung dari Aspose.Slides tidak didukung—mereka hanya dapat digunakan sebagai sumber.

**Apakah Aspose.Slides menimpa file XLSX eksternal saat menyimpan presentasi?**

Tidak. Presentasi menyimpan sebuah [tautan ke file eksternal](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chartdata/externalworkbookpath/) dan menggunakannya untuk membaca data. File eksternal itu sendiri tidak diubah ketika presentasi disimpan.

**Apa yang harus saya lakukan jika file eksternal dilindungi password?**

Aspose.Slides tidak menerima password saat membuat tautan. Pendekatan umum adalah menghapus perlindungan terlebih dahulu atau menyiapkan salinan yang sudah didekripsi (misalnya, menggunakan [Aspose.Cells](/cells/net/)) dan menautkan ke salinan tersebut.

**Apakah beberapa diagram dapat merujuk ke buku kerja eksternal yang sama?**

Ya. Setiap diagram menyimpan tautannya masing‑masing. Jika semua diagram menunjuk ke file yang sama, memperbarui file tersebut akan tercermin pada setiap diagram pada saat data dimuat berikutnya.