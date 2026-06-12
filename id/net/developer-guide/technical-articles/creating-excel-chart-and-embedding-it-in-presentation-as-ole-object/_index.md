---
title: Membuat Bagan Excel dan Menyematkannya dalam Presentasi sebagai Objek OLE
type: docs
weight: 50
url: /id/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Bagan Excel
- menyematkan bagan
- objek OLE
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Membuat bagan Excel dan menyematkannya sebagai objek OLE dalam presentasi PowerPoint dan OpenDocument dengan C#/.NET. Panduan langkah demi langkah dengan contoh kode."
---
## **Latar Belakang**

Di PowerPoint, penggunaan bagan yang dapat diedit untuk menampilkan data secara grafis adalah praktik umum. Aspose mendukung pembuatan bagan Excel dengan Aspose.Cells untuk .NET, dan bagan tersebut kemudian dapat disematkan sebagai objek OLE dalam slide PowerPoint melalui Aspose.Slides untuk .NET. Artikel ini mencakup langkah‑langkah yang diperlukan dan menyediakan contoh kode C# untuk membuat bagan Excel dan menyematkannya sebagai objek OLE dalam presentasi PowerPoint menggunakan Aspose.Cells dan Aspose.Slides.

## **Langkah yang Diperlukan**

Urutan langkah‑langkah berikut diperlukan untuk membuat dan menyematkan bagan Excel sebagai objek OLE dalam slide PowerPoint:

1. Buat bagan Excel menggunakan Aspose.Cells.
1. Atur ukuran OLE bagan Excel menggunakan Aspose.Cells.
1. Dapatkan gambar bagan Excel dengan Aspose.Cells.
1. Sematkan bagan Excel sebagai objek OLE dalam presentasi PPTX menggunakan Aspose.Slides.
1. Ganti gambar "EMBEDDED OLE OBJECT" dengan gambar yang diperoleh pada langkah 3 untuk mengatasi [masalah pratinjau objek](/slides/id/net/object-preview-issue-when-adding-oleobjectframe/).
1. Simpan presentasi ke disk dalam format PPTX.

## **Implementasi Langkah yang Diperlukan**

Implementasi C# dari langkah‑langkah di atas adalah sebagai berikut:

```cs
// Step - 1: Buat bagan Excel menggunakan Aspose.Cells.
// ---------------------------------------------------
// Buat workbook.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Tambahkan bagan Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Step - 2: Atur ukuran OLE bagan menggunakan Aspose.Cells.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Step - 3: Dapatkan gambar bagan dengan Aspose.Cells.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Simpan workbook ke stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Step - 4 AND 5
// ==============
 // Step - 4: Sematkan bagan sebagai objek OLE di dalam presentasi .ppt menggunakan Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Step - 5: Ganti gambar "EMBEDDED OLE OBJECT" dengan gambar yang diperoleh pada langkah 3 untuk mengatasi Object Preview Issue.
// --------------------------------------------------------------------------------------------------------------------
 // Create a presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // Tambahkan workbook ke slide.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Step - 6: Simpan presentasi output ke disk.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // Array nama sel.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Array data sel.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Tambahkan lembar kerja baru untuk mengisi sel dengan data.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // Isi lembar data dengan data.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // Tambahkan lembar bagan.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // Tambahkan bagan ke lembar bagan dengan seri data dari lembar data.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // Atur lembar bagan sebagai lembar aktif.
    workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
    return chartSheetIndex;
}
```

```cs
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] oleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(oleData, 0, oleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	    imageStream.Position = 0;
        IPPImage ppImage = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

Presentasi yang dibuat dengan metode di atas akan berisi bagan Excel sebagai objek OLE yang dapat diaktifkan dengan mengklik dua kali frame objek OLE.

## **Kesimpulan**

Dengan menggunakan Aspose.Cells untuk .NET bersama dengan Aspose.Slides untuk .NET, kita dapat membuat bagan Excel apa pun yang didukung oleh Aspose.Cells dan menyematkan bagan tersebut sebagai objek OLE dalam slide PowerPoint. Ukuran OLE bagan Excel juga dapat ditentukan. Pengguna akhir kemudian dapat mengedit bagan Excel seperti objek OLE lainnya.

## **Bagian‑Bagian Terkait**

- [Solusi Kerja untuk Mengubah Ukuran Bagan di PPTX](/slides/id/net/working-solution-for-chart-resizing-in-pptx/)
- [Masalah Pratinjau Objek saat Menambahkan OleObjectFrame](/slides/id/net/object-preview-issue-when-adding-oleobjectframe/)
- [Perbarui Objek OLE secara Otomatis Menggunakan Add‑In PowerPoint](/slides/id/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)