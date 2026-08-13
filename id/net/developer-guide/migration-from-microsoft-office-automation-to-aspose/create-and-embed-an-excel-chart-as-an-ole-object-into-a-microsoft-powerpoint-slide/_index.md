---
title: Buat dan Sisipkan Diagram Excel sebagai Objek OLE Menggunakan VSTO dan Aspose.Slides untuk .NET
linktitle: Buat dan Sisipkan Diagram Excel sebagai Objek OLE
type: docs
weight: 70
url: /id/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- buat diagram
- sisipkan diagram Excel
- objek OLE
- migrasi
- VSTO
- otomasi Office
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Migrasi dari otomasi Microsoft Office ke Aspose.Slides untuk .NET dan sisipkan diagram Excel sebagai objek OLE ke dalam slide PowerPoint (PPT, PPTX) menggunakan C#."
---
{{% alert color="info" %}} 

Diagram adalah representasi visual dari data Anda dan banyak digunakan dalam slide presentasi. Artikel ini akan menunjukkan kode untuk membuat dan menyisipkan Diagram Excel sebagai Objek OLE dalam Slide PowerPoint secara programatis dengan menggunakan [VSTO](/slides/id/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) dan [Aspose.Slides for .NET](/slides/id/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Membuat dan Menyisipkan Diagram Excel**
Contoh kode di bawah ini panjang dan detail karena tugas yang dijelaskan melibatkan beberapa langkah. Anda membuat buku kerja Microsoft Excel, membuat diagram, lalu membuat presentasi Microsoft PowerPoint yang akan menyisipkan diagram tersebut. Objek OLE berisi tautan ke dokumen asli sehingga pengguna yang mengklik dua kali file yang disisipkan akan meluncurkan file dan aplikasinya.
## **Contoh VSTO**
Dengan menggunakan VSTO, langkah-langkah berikut dilakukan:

1. Buat instance objek Microsoft Excel ApplicationClass.
1. Buat buku kerja baru dengan satu lembar di dalamnya.
1. Tambahkan diagram ke lembar.
1. Simpan buku kerja.
1. Buka buku kerja Excel yang berisi lembar kerja dengan data diagram.
1. Dapatkan koleksi ChartObjects untuk lembar.
1. Dapatkan diagram yang akan disalin.
1. Buat presentasi Microsoft PowerPoint.
1. Tambahkan slide kosong ke presentasi.
1. Salin diagram dari lembar kerja Excel ke clipboard.
1. Tempel diagram ke dalam presentasi PowerPoint.
1. Posisikan diagram pada slide.
1. Simpan presentasi.

```c#
CreateNewChartInExcel();
UseCopyPaste();
```

```c#
static void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)
{
    targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);
}
```

```c#
static void CreateNewChartInExcel()
{
    // Deklarasikan variabel untuk instance Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Deklarasikan variabel untuk parameter metode Workbooks.Open.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Deklarasikan variabel untuk metode Chart.ChartWizard.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Buat instance objek Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Buat buku kerja baru dengan 1 lembar di dalamnya.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Ubah nama lembar.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Sisipkan beberapa data untuk diagram ke dalam lembar.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    N. America  1.5     2       1.5     2.5
        //     3    S. America  2       1.75    2       2
        //     4    Europe      2.25    2       2.5     2
        //     5    Asia        2.5     2.5     2       2.75

        SetCellValue(targetSheet, "A2", "N. America");
        SetCellValue(targetSheet, "A3", "S. America");
        SetCellValue(targetSheet, "A4", "Europe");
        SetCellValue(targetSheet, "A5", "Asia");

        SetCellValue(targetSheet, "B1", "Q1");
        SetCellValue(targetSheet, "B2", 1.5);
        SetCellValue(targetSheet, "B3", 2);
        SetCellValue(targetSheet, "B4", 2.25);
        SetCellValue(targetSheet, "B5", 2.5);

        SetCellValue(targetSheet, "C1", "Q2");
        SetCellValue(targetSheet, "C2", 2);
        SetCellValue(targetSheet, "C3", 1.75);
        SetCellValue(targetSheet, "C4", 2);
        SetCellValue(targetSheet, "C5", 2.5);

        SetCellValue(targetSheet, "D1", "Q3");
        SetCellValue(targetSheet, "D2", 1.5);
        SetCellValue(targetSheet, "D3", 2);
        SetCellValue(targetSheet, "D4", 2.5);
        SetCellValue(targetSheet, "D5", 2);

        SetCellValue(targetSheet, "E1", "Q4");
        SetCellValue(targetSheet, "E2", 2.5);
        SetCellValue(targetSheet, "E3", 2);
        SetCellValue(targetSheet, "E4", 2);
        SetCellValue(targetSheet, "E5", 2.75);

        // Dapatkan rentang yang berisi data diagram.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Dapatkan koleksi ChartObjects untuk lembar.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Tambahkan Diagram ke dalam koleksi.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Buat diagram baru dari data.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Simpan buku kerja.
        newWorkbook.SaveAs(paramWorkbookPath, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, xlNS.XlSaveAsAccessMode.xlNoChange, paramMissing, paramMissing, paramMissing, paramMissing, paramMissing);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        if (excelApplication != null)
        {
            // Tutup Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Deklarasikan variabel untuk menyimpan referensi ke objek PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Deklarasikan variabel untuk menyimpan referensi ke objek Excel.
    xlNS.ApplicationClass excelApplication = null;
    xlNS.Workbook excelWorkBook = null;
    xlNS.Worksheet targetSheet = null;
    xlNS.ChartObjects chartObjects = null;
    xlNS.ChartObject existingChartObject = null;

    string paramPresentationPath = Application.StartupPath + @"\ChartTest.pptx";
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    try
    {
        // Buat sebuah instance PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Buat sebuah instance Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Buka buku kerja Excel yang berisi lembar kerja dengan data diagram.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Dapatkan lembar kerja yang berisi diagram.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Dapatkan koleksi ChartObjects untuk lembar.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Dapatkan diagram yang akan disalin.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Buat sebuah presentasi PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Tambahkan slide kosong ke presentasi.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Salin diagram dari lembar kerja Excel ke clipboard.
        existingChartObject.Copy();

        // Tempel diagram ke dalam presentasi PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // Posisi diagram pada slide.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Simpan presentasi.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Lepaskan objek slide PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // Tutup dan lepaskan objek Presentation.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Keluar dari PowerPoint dan lepaskan objek ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Lepaskan objek Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Tutup dan lepaskan objek Workbook Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Keluar dari Excel dan lepaskan objek ApplicationClass.
        if (excelApplication != null)
        {
            excelApplication.Quit();
            excelApplication = null;
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
```




## **Contoh Aspose.Slides for .NET**
Dengan menggunakan Aspose.Slides for .NET, langkah-langkah berikut dilakukan:

1. Buat buku kerja menggunakan Aspose.Cells for .NET.
1. Buat diagram Microsoft Excel.
1. Atur ukuran OLE dari Diagram Excel.
1. Dapatkan gambar diagram.
1. Sisipkan diagram Excel sebagai Objek OLE dalam presentasi PPTX menggunakan Aspose.Slides for .NET.
1. Ganti gambar objek yang berubah dengan gambar yang diperoleh pada langkah 3 untuk mengatasi masalah perubahan objek.
1. Tulis presentasi output ke disk dalam format PPTX.



```c#
using System.Drawing;
using Aspose.Slides;

//Langkah - 1: Buat diagram Excel menggunakan Aspose.Cells
//--------------------------------------------------
//Buat sebuah workbook
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Tambahkan diagram Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Langkah - 2: Atur ukuran OLE diagram. menggunakan Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Langkah - 3: Dapatkan gambar diagram dengan Aspose.Cells
//-----------------------------------------------------------
MemoryStream chartImageStream = new MemoryStream();
wb.Worksheets[chartSheetIndex].Charts[0].ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
Bitmap imgChart = new Bitmap(chartImageStream);
//Simpan workbook ke stream
MemoryStream wbStream = wb.SaveToStream();
//Langkah - 4  DAN 5
//-----------------------------------------------------------
//Langkah - 4: Sisipkan diagram sebagai objek OLE di dalam presentasi .ppt menggunakan Aspose.Slides
//-----------------------------------------------------------
//Langkah - 5: Ganti gambar objek yang berubah dengan gambar yang diperoleh pada langkah 3 untuk mengatasi masalah Object Changed
//-----------------------------------------------------------
//Buat sebuah presentasi
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Tambahkan workbook ke slide
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Langkah - 6: Tulis presentasi output ke disk
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] chartOleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	imageStream.Position = 0;
        IPPImage image = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = image;
    }
}
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //Array nama sel
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Array data sel
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Tambahkan lembar kerja baru untuk mengisi sel dengan data
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Isi DataSheet dengan data
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Tambahkan lembar diagram
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Tambahkan diagram di ChartSheet dengan rangkaian data dari DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Setel ChartSheet sebagai lembar aktif
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```