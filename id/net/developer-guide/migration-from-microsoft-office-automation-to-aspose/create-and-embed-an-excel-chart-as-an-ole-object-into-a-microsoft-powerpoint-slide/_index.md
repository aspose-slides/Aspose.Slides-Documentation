---
title: Membuat dan Menyematkan Grafik Excel sebagai OLE Object Menggunakan VSTO dan Aspose.Slides untuk .NET
linktitle: Membuat dan Menyematkan Grafik Excel sebagai OLE Object
type: docs
weight: 70
url: /id/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- membuat grafik
- menyematkan grafik Excel
- objek OLE
- migrasi
- VSTO
- otomatisasi Office
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Migrasi dari otomatisasi Microsoft Office ke Aspose.Slides untuk .NET dan sematkan grafik Excel sebagai objek OLE ke dalam slide PowerPoint (PPT, PPTX) menggunakan C#."
---
{{% alert color="primary" %}} 

Grafik adalah representasi visual data Anda dan banyak digunakan dalam slide presentasi. Artikel ini akan menunjukkan kode untuk membuat dan menyematkan Grafik Excel sebagai OLE Object dalam Slide PowerPoint secara programatis dengan menggunakan [VSTO](/slides/id/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) dan [Aspose.Slides for .NET](/slides/id/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Membuat dan Menyematkan Grafik Excel**
Dua contoh kode di bawah ini panjang dan terperinci karena tugas yang mereka jelaskan cukup kompleks. Anda membuat workbook Microsoft Excel, membuat grafik, lalu membuat presentasi Microsoft PowerPoint yang akan Anda sematkan grafik tersebut. OLE object berisi tautan ke dokumen asli sehingga pengguna yang mengklik ganda file yang disematkan akan meluncurkan file dan aplikasinya.
## **Contoh VSTO**
Menggunakan VSTO, langkah‑langkah berikut dilakukan:

1. Buat instance objek Microsoft Excel ApplicationClass.  
2. Buat workbook baru dengan satu lembar di dalamnya.  
3. Tambahkan grafik ke lembar.  
4. Simpan workbook.  
5. Buka workbook Excel yang berisi worksheet dengan data grafik.  
6. Dapatkan koleksi ChartObjects untuk lembar.  
7. Dapatkan grafik yang akan disalin.  
8. Buat presentasi Microsoft PowerPoint.  
9. Tambahkan slide kosong ke presentasi.  
10. Salin grafik dari worksheet Excel ke clipboard.  
11. Tempel grafik ke dalam presentasi PowerPoint.  
12. Atur posisi grafik pada slide.  
13. Simpan presentasi.  

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
    // Mendeklarasikan variabel untuk instance Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Mendeklarasikan variabel untuk parameter metode Workbooks.Open.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Mendeklarasikan variabel untuk metode Chart.ChartWizard.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Membuat instance objek Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Membuat workbook baru dengan 1 lembar di dalamnya.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Mengubah nama lembar.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Menyisipkan beberapa data untuk grafik ke dalam lembar.
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

        // Mendapatkan rentang yang berisi data grafik.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Mendapatkan koleksi ChartObjects untuk lembar.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Menambahkan Grafik ke dalam koleksi.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Membuat grafik baru dari data.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Menyimpan workbook.
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
            // Menutup Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Mendeklarasikan variabel untuk menyimpan referensi ke objek PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Mendeklarasikan variabel untuk menyimpan referensi ke objek Excel.
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
        // Membuat instance PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Membuat instance Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Membuka workbook Excel yang berisi worksheet dengan data grafik.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Mendapatkan worksheet yang berisi grafik.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Mendapatkan koleksi ChartObjects untuk lembar.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Mendapatkan grafik yang akan disalin.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Membuat presentasi PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Menambahkan slide kosong ke presentasi.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Menyalin grafik dari worksheet Excel ke clipboard.
        existingChartObject.Copy();

        // Menempelkan grafik ke dalam presentasi PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // Menentukan posisi grafik pada slide.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Menyimpan presentasi.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Melepaskan objek slide PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // Menutup dan melepaskan objek Presentation.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Keluar dari PowerPoint dan melepaskan objek ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Melepas objek Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Menutup dan melepaskan objek Workbook Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Keluar dari Excel dan melepaskan objek ApplicationClass.
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




## **Contoh Aspose.Slides untuk .NET**
Menggunakan Aspose.Slides untuk .NET, langkah‑langkah berikut dilakukan:

1. Buat workbook menggunakan Aspose.Cells untuk .NET.  
2. Buat grafik Microsoft Excel.  
3. Atur ukuran OLE dari grafik Excel.  
4. Dapatkan gambar dari grafik.  
5. Sematkan grafik Excel sebagai OLE Object di dalam presentasi PPTX menggunakan Aspose.Slides untuk .NET.  
6. Ganti gambar objek yang berubah dengan gambar yang diperoleh pada langkah 3 untuk mengatasi masalah perubahan objek.  
7. Tuliskan presentasi output ke disk dalam format PPTX.  

```c#
//Langkah - 1: Buat grafik Excel menggunakan Aspose.Cells
//--------------------------------------------------
//Buat workbook
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Tambahkan grafik Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Langkah - 2: Atur ukuran OLE grafik menggunakan Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Langkah - 3: Dapatkan gambar grafik dengan Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Simpan workbook ke stream
MemoryStream wbStream = wb.SaveToStream();
//Langkah - 4  DAN 5
//-----------------------------------------------------------
//Langkah - 4: Sematkan grafik sebagai objek OLE di dalam presentasi .ppt menggunakan Aspose.Slides
//-----------------------------------------------------------
//Langkah - 5: Ganti gambar objek yang berubah dengan gambar yang diperoleh pada langkah 3 untuk mengatasi masalah Object Changed
//-----------------------------------------------------------
//Buat presentasi
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Tambahkan workbook pada slide
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Langkah - 6: Tulis presentasi output ke disk
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
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
    //Tambahkan lembar grafik
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Tambahkan grafik di ChartSheet dengan rangkaian data dari DataSheet
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