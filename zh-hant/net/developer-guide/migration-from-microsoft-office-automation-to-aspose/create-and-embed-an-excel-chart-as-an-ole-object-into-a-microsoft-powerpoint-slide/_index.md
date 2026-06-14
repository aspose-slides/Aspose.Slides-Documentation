---
title: 使用 VSTO 與 Aspose.Slides for .NET 建立並嵌入 Excel 圖表作為 OLE 物件
linktitle: 建立並嵌入 Excel 圖表作為 OLE 物件
type: docs
weight: 70
url: /zh-hant/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- 建立圖表
- 嵌入 Excel 圖表
- OLE 物件
- 遷移
- VSTO
- Office 自動化
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "將 Microsoft Office 自動化遷移至 Aspose.Slides for .NET，並在 C# 中將 Excel 圖表作為 OLE 物件嵌入 PowerPoint (PPT、PPTX) 投影片。"
---
{{% alert color="primary" %}} 
圖表是資料的視覺化呈現，且廣泛用於簡報投影片中。本文將示範如何使用 [VSTO](/slides/zh-hant/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) 以及 [Aspose.Slides for .NET](/slides/zh-hant/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) 程式化地建立 Excel 圖表並將其作為 OLE 物件嵌入 PowerPoint 投影片。
{{% /alert %}} 
## **Creating and Embedding an Excel Chart**
以下兩個程式碼範例篇幅較長且相當詳細，因為要說明的工作較為複雜。您需要建立 Microsoft Excel 活頁簿、建立圖表，接著再建立 Microsoft PowerPoint 簡報，將圖表嵌入其中。OLE 物件會保留指向原始文件的連結，使用者雙擊嵌入的檔案時會啟動該檔案及其應用程式。
## **VSTO Example**
使用 VSTO 時，會執行以下步驟：

1. 建立 Microsoft Excel ApplicationClass 物件的實例。
1. 建立一個僅包含一個工作表的新活頁簿。
1. 在工作表上新增圖表。
1. 儲存活頁簿。
1. 開啟包含圖表資料工作表的 Excel 活頁簿。
1. 取得該工作表的 ChartObjects 集合。
1. 取得要複製的圖表。
1. 建立 Microsoft PowerPoint 簡報。
1. 為簡報新增一張空白投影片。
1. 將 Excel 工作表中的圖表複製到剪貼簿。
1. 將圖表貼上至 PowerPoint 簡報。
1. 調整圖表在投影片上的位置。
1. 儲存簡報。

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
    // 宣告一個用於 Excel ApplicationClass 實例的變數。
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // 為 Workbooks.Open 方法的參數宣告變數。
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // 為 Chart.ChartWizard 方法宣告變數。
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // 建立 Excel ApplicationClass 物件的實例。
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // 建立一個包含 1 個工作表的新活頁簿。
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // 更改工作表的名稱。
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // 在工作表中插入圖表資料。
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    北美  1.5     2       1.5     2.5
        //     3    南美  2       1.75    2       2
        //     4    歐洲      2.25    2       2.5     2
        //     5    亞洲        2.5     2.5     2       2.75

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

        // 取得包含圖表資料的範圍。
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // 取得工作表的 ChartObjects 集合。
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // 向集合中新增圖表。
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // 建立資料的新圖表。
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // 儲存活頁簿。
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
            // 關閉 Excel。
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // 宣告變數以保存對 PowerPoint 物件的參考。
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // 宣告變數以保存對 Excel 物件的參考。
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
        // 建立 PowerPoint 實例。
        powerpointApplication = new pptNS.ApplicationClass();

        // 建立 Excel 實例。
        excelApplication = new xlNS.ApplicationClass();

        // 開啟包含圖表資料工作表的 Excel 活頁簿。
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // 取得包含圖表的工作表。
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // 取得工作表的 ChartObjects 集合。
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // 取得要複製的圖表。
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // 建立 PowerPoint 簡報。
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // 在簡報中新增一張空白投影片。
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // 將圖表從 Excel 工作表複製到剪貼簿。
        existingChartObject.Copy();

        // 將圖表貼上至 PowerPoint 簡報。
        shapeRange = pptSlide.Shapes.Paste();

        // 設定圖表在投影片上的位置。
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // 儲存簡報。
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // 釋放 PowerPoint 投影片物件。
        shapeRange = null;
        pptSlide = null;

        // 關閉並釋放 Presentation 物件。
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // 退出 PowerPoint 並釋放 ApplicationClass 物件。
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // 釋放 Excel 物件。
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // 關閉並釋放 Excel 活頁簿物件。
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // 退出 Excel 並釋放 ApplicationClass 物件。
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
使用 Aspose.Slides for .NET 時，會執行以下步驟：

1. 使用 Aspose.Cells for .NET 建立活頁簿。
1. 建立 Microsoft Excel 圖表。
1. 設定 Excel 圖表的 OLE 大小。
1. 取得圖表的影像。
1. 使用 Aspose.Slides for .NET 將 Excel 圖表作為 OLE 物件嵌入 PPTX 簡報。
1. 以第 3 步取得的影像取代物件變更後的影像，以解決物件變更問題。
1. 以 PPTX 格式將輸出簡報寫入磁碟。

```c#
//步驟 - 1: 使用 Aspose.Cells 建立 Excel 圖表
//--------------------------------------------------
//Create a workbook
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Add an excel chart
//加入 Excel 圖表
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Step - 2: Set the OLE size of the chart. using Aspose.Cells
//-----------------------------------------------------------
//設定圖表的 OLE 大小，使用 Aspose.Cells
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Step - 3: Get the image of the chart with Aspose.Cells
//-----------------------------------------------------------
//取得圖表的影像，使用 Aspose.Cells
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Save the workbook to stream
MemoryStream wbStream = wb.SaveToStream();
//Step - 4  AND 5
//-----------------------------------------------------------
//步驟 - 4  以及 5
//Step - 4: Embed the chart as an OLE object inside .ppt presentation using Aspose.Slides
//-----------------------------------------------------------
//步驟 - 4: 使用 Aspose.Slides 將圖表作為 OLE 物件嵌入 .ppt 簡報
//Step - 5: Replace the object changed image with the image obtained in step 3 to cater Object Changed Issue
//-----------------------------------------------------------
//步驟 - 5: 用第 3 步取得的影像取代因物件變更問題而產生的影像
//Create a presentation
//建立簡報
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Add the workbook on slide
//在投影片上加入活頁簿
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Step - 6: Write the output presentation on disk
//-----------------------------------------------------------
//步驟 - 6: 將輸出簡報寫入磁碟
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
    //儲存格名稱陣列
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //儲存格資料陣列
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //新增工作表以填入資料至儲存格
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //將資料填入 DataSheet
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //新增圖表工作表
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //在 ChartSheet 中加入圖表，資料序列取自 DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //將 ChartSheet 設為使用中的工作表
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```