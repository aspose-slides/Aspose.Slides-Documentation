---
title: Buat Diagram Menggunakan VSTO dan Aspose.Slides untuk .NET
linktitle: Buat Diagram
type: docs
weight: 80
url: /id/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- buat diagram
- migrasi
- VSTO
- otomasi Office
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengotomatisasi pembuatan diagram PowerPoint dalam C#. Panduan langkah demi langkah ini menunjukkan mengapa Aspose.Slides untuk .NET merupakan alternatif yang lebih cepat dan lebih kuat dibandingkan Microsoft.Office.Interop."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara membuat dan menyesuaikan diagram dalam presentasi Microsoft PowerPoint secara programatis menggunakan C#. Dengan Aspose.Slides untuk .NET, Anda dapat mengotomatisasi pembuatan diagram profesional berbasis data tanpa bergantung pada Microsoft Office atau perpustakaan Interop. API menyediakan serangkaian fitur lengkap untuk membuat diagram kolom, diagram lingkaran, diagram garis, dan lainnya — semuanya dengan kontrol penuh atas tampilan, data, dan tata letak. Baik Anda membuat laporan, dasbor, atau presentasi bisnis, Aspose.Slides membantu Anda menyajikan visualisasi berkualitas tinggi langsung dari aplikasi .NET Anda.

## **Contoh VSTO**

Bagian ini menunjukkan cara membuat diagram dalam presentasi Microsoft PowerPoint menggunakan **VSTO (Visual Studio Tools for Office)**. Dengan VSTO, Anda dapat menghasilkan dan menyesuaikan diagram secara programatis dengan menggabungkan otomasi PowerPoint dan Excel. Contoh yang disediakan memperlihatkan cara menambahkan **diagram kolom klaster 3D**, mengisi data dari lembar kerja Excel, menyesuaikan format dan tata letak, serta menyimpan presentasi akhir — semuanya dari dalam aplikasi .NET.

1. Buat instance presentasi Microsoft PowerPoint.
1. Tambahkan slide kosong ke presentasi.
1. Tambahkan diagram kolom klaster 3D dan akses diagram tersebut.
1. Buat instance workbook Microsoft Excel baru dan muat data diagram.
1. Akses lembar kerja data diagram menggunakan instance workbook Excel.
1. Tentukan rentang data diagram di lembar kerja dan hapus seri 2 serta 3 dari diagram.
1. Modifikasi data kategori diagram di lembar kerja data diagram.
1. Modifikasi data seri 1 di lembar kerja data diagram.
1. Akses judul diagram dan atur properti terkait font.
1. Akses sumbu nilai diagram dan atur satuan utama, satuan minor, nilai maksimum, dan nilai minimum.
1. Akses sumbu kedalaman (seri) diagram dan hapus — hanya satu seri yang digunakan dalam contoh ini.
1. Atur sudut rotasi diagram pada arah X dan Y.
1. Simpan presentasi.
1. Tutup instance Microsoft Excel dan PowerPoint.

```c#
EnsurePowerPointIsRunning(true, true);

// Membuat instance objek slide.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Mengakses slide presentasi pertama.
objSlide = objPres.Slides[1];

// Memilih slide pertama dan mengatur tata letaknya.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Menambahkan diagram default ke slide.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Mengakses diagram yang ditambahkan.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Mengakses data diagram.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Membuat instance workbook Excel untuk bekerja dengan data diagram.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Mengakses lembar kerja data untuk diagram.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Menetapkan rentang data untuk diagram.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Menerapkan rentang yang ditentukan ke tabel data diagram.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Menetapkan nilai untuk kategori dan data seri masing‑masing.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Set the chart title.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Mengakses sumbu nilai diagram.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Menetapkan nilai untuk satuan sumbu.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Mengakses sumbu kedalaman diagram.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Menetapkan rotasi diagram.
ppChart.Rotation = 20;   // Nilai Y
ppChart.Elevation = 15;  // Nilai X
ppChart.RightAngleAxes = false;

// Menyimpan presentasi sebagai file PPTX.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Menutup workbook dan presentasi.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // Coba mengakses properti Name. Jika melempar pengecualian, mulai instance PowerPoint baru.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation digunakan untuk memastikan bahwa presentasi dimuat.
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // blnAddSlide digunakan untuk memastikan ada setidaknya satu slide dalam presentasi.
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```

Hasilnya:

![The chart created using VSTO](chart-created-using-VSTO.png)

## **Contoh Aspose.Slides untuk .NET**

Contoh berikut menunjukkan cara membuat diagram sederhana dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET. Kode ini memperlihatkan cara menambahkan **diagram kolom klaster 3D**, mengisi data contoh, dan menyesuaikan tampilannya. Dengan beberapa baris kode, Anda dapat menghasilkan diagram secara dinamis dan mengintegrasikannya ke dalam presentasi tanpa menggunakan Microsoft Office.

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide pertama.
1. Tambahkan diagram kolom klaster 3D dan akses diagram tersebut.
1. Akses data diagram.
1. Hapus Seri 2 dan Seri 3 yang tidak digunakan.
1. Modifikasi kategori diagram dengan memperbarui label.
1. Perbarui nilai Seri 1.
1. Akses judul diagram dan atur properti fontnya.
1. Konfigurasikan sumbu nilai diagram, termasuk satuan utama, satuan minor, nilai maksimum, dan nilai minimum.
1. Atur sudut rotasi diagram pada sumbu X dan Y.
1. Simpan presentasi dalam format PPTX.

```cs
// Buat presentasi kosong.
using (Presentation presentation = new Presentation())
{
    // Akses slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan diagram default.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Dapatkan data diagram.
    IChartData chartData = chart.ChartData;

    // Hapus seri default tambahan.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Ubah nama kategori diagram.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Atur indeks lembar kerja data diagram.
    int worksheetIndex = 0;

    // Dapatkan workbook data diagram.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Ubah nilai seri diagram.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Atur judul diagram.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Atur opsi sumbu.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Atur rotasi diagram.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Simpan presentasi sebagai file PPTX.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The chart created using Aspose.Slides for .NET](chart-created-using-aspose-slides.png)

## **Tanya Jawab**

**Apakah saya dapat membuat tipe diagram lain seperti diagram lingkaran, garis, atau batang dengan Aspose.Slides?**

Ya. Aspose.Slides untuk .NET mendukung berbagai [tipe diagram](/slides/id/net/create-chart/), termasuk diagram lingkaran, diagram garis, diagram batang, plot sebar, diagram gelembung, dan lainnya. Anda dapat menentukan tipe diagram yang diinginkan menggunakan enumerasi [ChartType](https://reference.aspose.com/slides/id/net/aspose.slides.charts/charttype/) saat menambahkan diagram.

**Apakah saya dapat menerapkan gaya atau tema khusus pada diagram?**

Ya. Anda dapat menyesuaikan tampilan diagram sepenuhnya, termasuk warna, font, isian, garis tepi, garis kisi, dan tata letak. Namun, menerapkan tema Office persis seperti yang terlihat di PowerPoint memerlukan penyesuaian gaya secara manual.

**Apakah saya dapat mengekspor diagram sebagai gambar terpisah dari slide?**

Ya, Aspose.Slides memungkinkan Anda mengekspor bentuk apa pun — termasuk diagram — sebagai gambar terpisah (misalnya PNG, JPEG) menggunakan metode `GetImage` pada [shape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/).