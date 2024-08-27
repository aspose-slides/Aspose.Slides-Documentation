---
title: Create and Embed an Excel Chart as an OLE Object into a Microsoft PowerPoint Slide
type: docs
weight: 70
url: /net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 Charts are visual representations of your data and widely used in presentation slides. This article will show you the code to create and embed an Excel Chart as an OLE Object in the PowerPoint Slide programmatically by using [VSTO](/slides/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) and [Aspose.Slides for .NET](/slides/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Creating and Embedding an Excel Chart**
The two code examples below are long and detailed because the task they're describing is involved. You create a Microsoft Excel workbook, create a chart and then create the Microsoft PowerPoint presentation that you'll embed the chart into. OLE objects contain links to the original document so a user that double-clicks the embedded file will launch the file and it's application.
## **VSTO Example**
Using VSTO, the following steps are performed:

1. Create an instance of the Microsoft Excel ApplicationClass object.
1. Create a new workbook with one sheet in it.
1. Add chart to the sheet.
1. Save the workbook.
1. Open the Excel workbook containing the worksheet with the chart data.
1. Get the ChartObjects collection for the sheet.
1. Get the chart to copy.
1. Create a Microsoft PowerPoint presentation.
1. Add a blank slide to the presentation.
1. Copy the chart from the Excel worksheet to the clipboard.
1. Paste the chart into the PowerPoint presentation.
1. Position the chart on the slide.
1. Save the presentation.

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
    // Declare a variable for the Excel ApplicationClass instance.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Declare variables for the Workbooks.Open method parameters.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Declare variables for the Chart.ChartWizard method.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Create an instance of the Excel ApplicationClass object.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Create a new workbook with 1 sheet in it.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Change the name of the sheet.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Insert some data for the chart into the sheet.
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

        // Get the range holding the chart data.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Get the ChartObjects collection for the sheet.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Add a Chart to the collection.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Create a new chart of the data.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Save the workbook.
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
            // Close Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Declare variables to hold references to PowerPoint objects.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Declare variables to hold references to Excel objects.
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
        // Create an instance of PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Create an instance Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Open the Excel workbook containing the worksheet with the chart data.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Get the worksheet that contains the chart.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Get the ChartObjects collection for the sheet.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Get the chart to copy.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Create a PowerPoint presentation.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Add a blank slide to the presentation.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Copy the chart from the Excel worksheet to the clipboard.
        existingChartObject.Copy();

        // Paste the chart into the PowerPoint presentation.
        shapeRange = pptSlide.Shapes.Paste();

        // Position the chart on the slide.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Save the presentation.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Release the PowerPoint slide object.
        shapeRange = null;
        pptSlide = null;

        // Close and release the Presentation object.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Quit PowerPoint and release the ApplicationClass object.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Release the Excel objects.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Close and release the Excel Workbook object.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Quit Excel and release the ApplicationClass object.
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




## **Aspose.Slides for .NET Example**
Using Aspose.Slides for .NET, the following steps are performed:

1. Create a workbook using Aspose.Cells for .NET.
1. Create a Microsoft Excel chart.
1. Set the OLE size of the Excel Chart.
1. Get an image of the chart.
1. Embed the Excel chart as an OLE Object inside PPTX presentation using Aspose.Slides for .NET.
1. Replace the object changed image with the image obtained in step 3 to cater for the object changed issue.
1. Write the output presentation to disk in PPTX format.



```c#
//Step - 1: Create an excel chart using Aspose.Cells
//--------------------------------------------------
//Create a workbook
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Add an excel chart
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Step - 2: Set the OLE size of the chart. using Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Step - 3: Get the image of the chart with Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Save the workbook to stream
MemoryStream wbStream = wb.SaveToStream();
//Step - 4  AND 5
//-----------------------------------------------------------
//Step - 4: Embed the chart as an OLE object inside .ppt presentation using Aspose.Slides
//-----------------------------------------------------------
//Step - 5: Replace the object changed image with the image obtained in step 3 to cater Object Changed Issue
//-----------------------------------------------------------
//Create a presentation
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Add the workbook on slide
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Step - 6: Write the output presentation on disk
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
    //Array of cell names
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Array of cell data
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Add a new worksheet to populate cells with data
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Populate DataSheet with data
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Add a chart sheet
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Add a chart in ChartSheet with data series from DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Set ChartSheet an active sheet
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```

