---
title: 创建 Excel 图表并将其嵌入到演示文稿中作为 OLE 对象
type: docs
weight: 50
url: /net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

在 PowerPoint 幻灯片中，使用可编辑图表来图形化显示数据是一项常见活动。Aspose 提供了使用 Aspose.Cells for .NET 创建 Excel 图表的支持，并且这些图表可以通过 Aspose.Slides for .NET 作为 OLE 对象嵌入到 PowerPoint 幻灯片中。本文涵盖了使用 Aspose.Cells for .NET 和 Aspose.Slides for .NET 在 C# 和 VB.NET 中创建和嵌入 MS Excel 图表作为 OLE 对象到 PowerPoint 演示文稿中的必要步骤及其实现。

{{% /alert %}} 
## **必要步骤**
以下步骤序列是将 Excel 图表作为 OLE 对象嵌入到 PowerPoint 幻灯片中所需的：

1. 使用 Aspose.Cells for .NET 创建 Excel 图表。
2. 使用 Aspose.Cells for .NET 设置 Excel 图表的 OLE 大小。
3. 使用 Aspose.Cells for .NET 获取 Excel 图表的图像。
4. 使用 Aspose.Slides for .NET 将 Excel 图表作为 OLE 对象嵌入到 PPTX 演示文稿中。
5. 用第 3 步中获得的图像替换对象更改的图像，以解决对象更改问题。
6. 将输出演示文稿以 PPTX 格式写入磁盘。

## **必要步骤的实现**
上述步骤在 C# 和 Visual Basic 中的实现如下：

```c#
//步骤 - 1：使用 Aspose.Cells 创建 Excel 图表
//--------------------------------------------------
//创建一个工作簿
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//添加一个 Excel 图表
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//步骤 - 2：使用 Aspose.Cells 设置图表的 OLE 大小
//-----------------------------------------------------------  
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//步骤 - 3：使用 Aspose.Cells 获取图表的图像
//-----------------------------------------------------------  
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//将工作簿保存到流中
MemoryStream wbStream = wb.SaveToStream();
//步骤 - 4 和 5
//-----------------------------------------------------------  
//步骤 - 4：使用 Aspose.Slides 将图表作为 OLE 对象嵌入到 .ppt 演示文稿中
//-----------------------------------------------------------  
//步骤 - 5：用第 3 步中获得的图像替换对象更改的图像，以解决对象更改问题
//-----------------------------------------------------------  
//创建演示文稿
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//将工作簿添加到幻灯片
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//步骤 - 6：将输出演示文稿写入磁盘
//-----------------------------------------------------------  
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
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
    //添加新的工作表来填充单元格数据
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //用数据填充 DataSheet
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //添加一个图表工作表
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //在 ChartSheet 中添加一个图表，数据系列来自 DataSheet
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

```c#
static void AddExcelChartInPresentation(Presentation pres, ISlide sld, Stream wbStream, Bitmap imgChart)
{
    float oleWidth = pres.SlideSize.Size.Width;
    float oleHeight = pres.SlideSize.Size.Height;

    byte[] chartOleData = new byte[wbStream.Length];
    wbStream.Position = 0;
    wbStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oof = sld.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        imgChart.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	imageStream.Position = 0;
        IPPImage ppImage = pres.Images.AddImage(imageStream);

        oof.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

{{% alert color="primary" %}} 

通过上述方法创建的演示文稿将携带 Excel 图表作为 OLE 对象，可以通过双击 OLE 对象框来激活。

{{% /alert %}} 
## **结论**
{{% alert color="primary" %}} 

通过使用 Aspose.Cells for .NET 和 Aspose.Slides for .NET，我们可以创建任何由 Aspose.Cells for .NET 支持的 Excel 图表，并将创建的图表嵌入到 PowerPoint 幻灯片中的 OLE 对象中。Excel 图表的 OLE 大小也可以定义。最终用户可以像其他 OLE 对象一样进一步编辑 Excel 图表。

{{% /alert %}} 
## **相关部分**
[图表调整大小的工作解决方案](/slides/net/working-solution-for-chart-resizing-in-pptx/)[对象更改问题](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)