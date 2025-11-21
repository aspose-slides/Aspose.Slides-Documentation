---
title: 使用 VSTO 和 Aspose.Slides for .NET 将 Excel 图表创建并嵌入为 OLE 对象
linktitle: 创建并嵌入 Excel 图表为 OLE 对象
type: docs
weight: 70
url: /zh/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- 创建图表
- 嵌入 Excel 图表
- OLE 对象
- 迁移
- VSTO
- Office 自动化
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "从 Microsoft Office 自动化迁移到 Aspose.Slides for .NET，并在 C# 中将 Excel 图表作为 OLE 对象嵌入 PowerPoint（PPT、PPTX）幻灯片。"
---

{{% alert color="primary" %}} 

图表是您数据的可视化表示，且在演示幻灯片中被广泛使用。本文将展示如何使用[VSTO](/slides/zh/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/)和[Aspose.Slides for .NET](/slides/zh/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/)以编程方式在 PowerPoint 幻灯片中创建并嵌入 Excel 图表作为 OLE 对象的代码。

{{% /alert %}} 
## **创建并嵌入 Excel 图表**
下面的两个代码示例篇幅较长且细节丰富，因为它们描述的任务比较复杂。您需要创建一个 Microsoft Excel 工作簿，生成图表，然后创建要嵌入该图表的 Microsoft PowerPoint 演示文稿。OLE 对象包含指向原始文档的链接，因此双击嵌入的文件的用户会启动该文件及其应用程序。

## **VSTO 示例**
使用 VSTO 时，执行以下步骤：

1. 创建 Microsoft Excel ApplicationClass 对象的实例。  
2. 创建仅包含一个工作表的新工作簿。  
3. 向工作表添加图表。  
4. 保存工作簿。  
5. 打开包含图表数据的 Excel 工作簿。  
6. 获取工作表的 ChartObjects 集合。  
7. 获取要复制的图表。  
8. 创建 Microsoft PowerPoint 演示文稿。  
9. 向演示文稿添加空白幻灯片。  
10. 将 Excel 工作表中的图表复制到剪贴板。  
11. 将图表粘贴到 PowerPoint 演示文稿中。  
12. 在幻灯片上定位图表。  
13. 保存演示文稿。  

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
    // 声明一个变量用于 Excel ApplicationClass 实例。
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // 声明 Workbooks.Open 方法参数的变量。
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // 声明 Chart.ChartWizard 方法的变量。
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // 创建 Excel ApplicationClass 对象的实例。
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // 创建一个包含 1 张工作表的新工作簿。
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // 更改工作表的名称。
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // 向工作表插入图表所需的数据。
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

        // 获取包含图表数据的范围。
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // 获取工作表的 ChartObjects 集合。
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // 向集合中添加图表。
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // 基于数据创建新图表。
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // 保存工作簿。
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
            // 关闭 Excel。
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // 声明变量以保存对 PowerPoint 对象的引用。
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // 声明变量以保存对 Excel 对象的引用。
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
        // 创建 PowerPoint 实例。
        powerpointApplication = new pptNS.ApplicationClass();

        // 创建 Excel 实例。
        excelApplication = new xlNS.ApplicationClass();

        // 打开包含图表数据工作表的 Excel 工作簿。
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // 获取包含图表的工作表。
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // 获取工作表的 ChartObjects 集合。
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // 获取要复制的图表。
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // 创建 PowerPoint 演示文稿。
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // 向演示文稿添加空白幻灯片。
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // 将图表从 Excel 工作表复制到剪贴板。
        existingChartObject.Copy();

        // 将图表粘贴到 PowerPoint 演示文稿中。
        shapeRange = pptSlide.Shapes.Paste();

        // 在幻灯片上定位图表。
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // 保存演示文稿。
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // 释放 PowerPoint 幻灯片对象。
        shapeRange = null;
        pptSlide = null;

        // 关闭并释放 Presentation 对象。
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // 退出 PowerPoint 并释放 ApplicationClass 对象。
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // 释放 Excel 对象。
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // 关闭并释放 Excel 工作簿对象。
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // 退出 Excel 并释放 ApplicationClass 对象。
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


## **Aspose.Slides for .NET 示例**
使用 Aspose.Slides for .NET 时，执行以下步骤：

1. 使用 Aspose.Cells for .NET 创建工作簿。  
2. 创建 Microsoft Excel 图表。  
3. 设置 Excel 图表的 OLE 大小。  
4. 获取图表的图像。  
5. 使用 Aspose.Slides for .NET 将 Excel 图表作为 OLE 对象嵌入 PPTX 演示文稿。  
6. 用第 3 步获得的图像替换对象更改后的图像，以解决对象更改问题。  
7. 将输出演示文稿以 PPTX 格式写入磁盘。  

```c#
//步骤 - 1: 使用 Aspose.Cells 创建 Excel 图表
//--------------------------------------------------
//创建工作簿
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//添加 Excel 图表
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//步骤 - 2: 使用 Aspose.Cells 设置图表的 OLE 大小
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//步骤 - 3: 使用 Aspose.Cells 获取图表的图像
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Save the workbook to stream
MemoryStream wbStream = wb.SaveToStream();
//步骤 - 4 和 5
//-----------------------------------------------------------
//步骤 - 4: 使用 Aspose.Slides 将图表作为 OLE 对象嵌入 .ppt 演示文稿
//-----------------------------------------------------------
//步骤 - 5: 用步骤 3 获得的图像替换对象更改后的图像，以解决对象更改问题
//-----------------------------------------------------------
//创建演示文稿
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//在幻灯片上添加工作簿
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//步骤 - 6: 将输出演示文稿写入磁盘
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
static int AddExcelChartInWorkbook(Aspense.Cells.Workbook wb, int chartRows, int chartCols)
{
    //单元格名称数组
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //单元格数据数组
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //添加一个新工作表以填充单元格数据
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //使用数据填充 DataSheet
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //添加图表工作表
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //在 ChartSheet 中添加图表，数据系列来自 DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //将 ChartSheet 设置为活动工作表
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```
