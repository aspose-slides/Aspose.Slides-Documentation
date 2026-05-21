---
title: 在 .NET 中管理演示文稿的图表工作簿
linktitle: 图表工作簿
type: docs
weight: 70
url: /zh/net/chart-workbook/
keywords:
- 图表工作簿
- 图表数据
- 工作簿单元格
- 数据标签
- 工作表
- 数据源
- 外部工作簿
- 外部数据
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "发现 Aspose.Slides for .NET：轻松在 PowerPoint 和 OpenDocument 格式中管理图表工作簿，简化演示文稿数据。"
---
## **概述**

本文介绍了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据，使用工作簿单元格作为图表数据标签，访问工作表集合，以及为图表值指定数据源类型。

它还涵盖了将外部工作簿用作图表数据源的操作。示例演示了如何创建和分配外部工作簿，获取链接到图表的外部工作簿的路径，以及在工作簿可用时编辑图表数据。

## **从工作簿读取和写入图表数据**
Aspose.Slides 提供了 [ReadWorkbookStream](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/readworkbookstream/) 和 [WriteWorkbookStream](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 方法，允许您读取和写入图表数据工作簿（包含使用 Aspose.Cells 编辑的图表数据）。**注意**，图表数据必须以相同的方式组织，或具有与源相似的结构。

下面的 C# 代码演示了一个示例操作：

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

## **将工作簿单元格设置为图表数据标签**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有一些数据的气泡图。
1. 访问图表系列。
1. 将工作簿单元格设置为数据标签。
1. 保存演示文稿。

下面的 C# 代码展示了如何将工作簿单元格设置为图表数据标签：

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// 实例化一个表示演示文稿文件的 Presentation 类 

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

## **管理工作表**

下面的 C# 代码演示了使用 [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) 属性访问工作表集合的操作：

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **指定数据源类型**

下面的 C# 代码展示了如何为数据源指定类型：

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

## **检测不受支持的嵌入式工作簿格式**

Aspose.Slides 不支持某些图表中可能嵌入的 Excel 二进制工作簿（.xlsb）格式。您可以在 [IChartData](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/) 上使用 `EmbeddedWorkbookType` 属性，并结合 [WorkbookType](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/workbooktype/) 枚举来检测不受支持的格式并跳过这些图表。

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
            // 嵌入式工作簿为 .xlsb 格式，不受支持。
            continue;
        }

        // 在此读取或修改图表工作簿数据。
    }
}
```

## **外部工作簿**
{{% alert color="primary" %}} 
在 [Aspose.Slides 19.4](https://docs.aspose.com/slides/zh/net/aspose-slides-for-net-19-4-release-notes/) 中，我们实现了对外部工作簿作为图表数据源的支持。
{{% /alert %}} 

### **创建外部工作簿**
使用 **`ReadWorkbookStream`** 和 **`SetExternalWorkbook`** 方法，您可以从头创建外部工作簿，或将内部工作簿转换为外部工作簿。

下面的 C# 代码演示了外部工作簿的创建过程：

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

### **设置外部工作簿**
使用 **`SetExternalWorkbook`** 方法，您可以将外部工作簿分配给图表作为其数据源。该方法还可用于更新外部工作簿的路径（如果后者已被移动）。

虽然您无法编辑存储在远程位置或资源中的工作簿数据，但仍可以将此类工作簿用作外部数据源。如果提供了外部工作簿的相对路径，它会自动转换为完整路径。

下面的 C# 代码展示了如何设置外部工作簿：

```c#
// 文档目录的路径。
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

`SetExternalWorkbook` 方法下的 `ChartData` 参数用于指定是否加载 Excel 工作簿。

* 当 `ChartData` 值设为 `false` 时，仅更新工作簿路径——图表数据不会从目标工作簿加载或更新。当目标工作簿不存在或不可用时，您可能需要使用此设置。 
* 当 `ChartData` 值设为 `true` 时，图表数据会从目标工作簿更新。 

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **获取图表的外部数据源工作簿路径**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 创建图表形状的对象。
1. 创建一个表示图表数据源的源 (`ChartDataSourceType`) 类型的对象。
1. 根据源类型与外部工作簿数据源类型相同，指定相关条件。

下面的 C# 代码演示了此操作：

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
    
    // 保存演示文稿
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **编辑图表数据**

您可以像修改内部工作簿内容一样编辑外部工作簿中的数据。当外部工作簿无法加载时，会抛出异常。

下面的 C# 代码实现了上述过程：

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **常见问题**

**我可以判断特定图表是链接到外部工作簿还是嵌入式工作簿吗？**

可以。图表具有 [data source type](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/datasourcetype/) 和 [path to an external workbook](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/externalworkbookpath/); 如果源是外部工作簿，您可以读取完整路径以确保使用的是外部文件。

**是否支持外部工作簿的相对路径，它们是如何存储的？**

是的。如果指定相对路径，它会自动转换为绝对路径。这对于项目的可移植性很方便；但请注意，演示文稿会在 PPTX 文件中存储绝对路径。

**我可以使用位于网络资源/共享上的工作簿吗？**

可以，这些工作簿可以用作外部数据源。不过，Aspose.Slides 不支持直接编辑远程工作簿——它们只能作为数据源使用。

**Aspose.Slides 在保存演示文稿时会覆盖外部 XLSX 吗？**

不会。演示文稿存储了一个指向外部文件的 [link to the external file](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/externalworkbookpath/)，并在读取数据时使用它。保存演示文稿时不会修改外部文件本身。

**如果外部文件受密码保护，我该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是预先移除保护或准备一个已解密的副本（例如，使用 [Aspose.Cells](/cells/net/)），并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表都存储自己的链接。如果它们都指向同一个文件，更新该文件后，下次加载数据时会在每个图表中体现。