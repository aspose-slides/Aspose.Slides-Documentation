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
- 图表缓存
- 工作簿恢复
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET：轻松管理 PowerPoint 和 OpenDocument 格式中的图表工作簿，以简化演示文稿数据。"
---
## **概述**

本文介绍了在 Aspose.Slides 中使用图表工作簿的方式。它展示了如何通过工作簿流读取和写入图表数据、将工作簿单元格用作图表数据标签、访问工作表集合以及为图表值指定数据源类型。

此外，还涉及了使用外部工作簿作为图表数据源的情况。示例演示了如何创建并分配外部工作簿、获取链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

对于表示缺失数据的工作簿单元格，请参阅[控制空单元格的显示](/slides/zh/net/chart-series/)，了解空单元格与零的区别以及可用显示模式的折线图比较。

## **从工作簿读取和写入图表数据**
Aspose.Slides 提供了[ReadWorkbookStream](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/readworkbookstream/)和[WriteWorkbookStream](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/writeworkbookstream/)方法，允许您读取和写入包含使用 Aspose.Cells 编辑的图表数据的工作簿。**注意**，图表数据必须以相同方式组织或具有类似于源的结构。

下面的 C# 代码演示了一个示例操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

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

### **在修改工作簿后验证图表布局**

当您用已修改的工作簿替换嵌入式工作簿时，图表会保留其原有的系列和类别集合。这种不匹配可能导致[IChart.ValidateChartLayout](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichart/validatechartlayout/)因索引超出范围而失败。在将更新后的工作簿写回图表之前，请先清除现有的系列和类别。

```csharp
// 在修改工作簿流后（例如，使用 Aspose.Cells）
using var updatedWorkbook = chartData.ReadWorkbookStream();

// 清除现有的数据引用。
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

清除集合可确保图表数据结构与新工作簿保持一致，从而使 `ValidateChartLayout` 能够顺利完成而不会报错。

## **将工作簿单元格设为图表数据标签**
1. 创建一个[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/)类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个带有数据的气泡图。  
1. 访问图表系列。  
1. 将工作簿单元格设为数据标签。  
1. 保存幻灯片。

下面的 C# 代码展示了如何将工作簿单元格设为图表数据标签：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

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

下面的 C# 代码演示了使用[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets)属性访问工作表集合的操作：

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

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
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

Aspose.Slides 不支持某些图表中可以嵌入的 Excel 二进制工作簿（.xlsb）格式。您可以结合在[IChartData](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/)上的`EmbeddedWorkbookType`属性和[WorkbookType](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/workbooktype/)枚举来检测不受支持的格式并跳过相应的图表。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

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

Aspose.Slides 支持将外部工作簿用作图表的数据源。

### **创建外部工作簿**

使用**`ReadWorkbookStream`**和**`SetExternalWorkbook`**方法，您可以从头创建外部工作簿，或将内部工作簿设为外部工作簿。

下面的 C# 代码演示了外部工作簿的创建过程：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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
使用**`SetExternalWorkbook`**方法，您可以将外部工作簿分配给图表作为其数据源。该方法还可用于更新外部工作簿的路径（如果工作簿已被移动）。

虽然无法编辑存储在远程位置或资源中的工作簿数据，但仍然可以将这些工作簿用作外部数据源。如果提供了外部工作簿的相对路径，系统会自动将其转换为完整路径。

下面的 C# 代码展示了如何设置外部工作簿：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **获取图表的外部数据源工作簿路径**

1. 创建一个[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/)类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 为图表形状创建对象。  
1. 为表示图表数据源的源(`ChartDataSourceType`)类型创建对象。  
1. 根据源类型与外部工作簿数据源类型相同的条件指定相关条件。

下面的 C# 代码演示了该操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

您可以像编辑内部工作簿内容一样编辑外部工作簿中的数据。如果无法加载外部工作簿，将抛出异常。

下面的 C# 代码实现了上述过程：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **从图表缓存中恢复工作簿**

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿中缓存的数据重建图表工作簿。创建[LoadOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/)，配置其[SpreadsheetOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/spreadsheetoptions/)，并在打开演示文稿之前将[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/)设为 `true`。

以下 C# 示例打开了一个图表引用不可用外部工作簿的演示文稿，并通过[IChart.ChartData](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichart/chartdata/)和[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/chartdataworkbook/)访问恢复的数据：

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// 在此读取或修改恢复的工作簿数据。
```

如果外部工作簿不可用且未启用恢复，Aspose.Slides 将抛出 `InvalidOperationException`。只有在接受使用缓存的图表数据作为后备方案时才启用恢复，因为缓存可能不包含对外部工作簿的后续更改。

## **常见问题解答**

**我能否判断特定图表是链接到外部工作簿还是嵌入式工作簿？**

可以。图表具有[data source type](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/datasourcetype/)和[external workbook path](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/externalworkbookpath/)；如果源是外部工作簿，您可以读取完整路径以确认正在使用外部文件。

**是否支持外部工作簿的相对路径，且它们是如何存储的？**

支持。如果您指定相对路径，系统会自动将其转换为绝对路径。这对项目可移植性很有帮助；但请注意，演示文稿会在 PPTX 文件中存储绝对路径。

**可以使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可用作外部数据源。不过，Aspose.Slides 不支持直接编辑远程工作簿——它们只能用作数据源。

**在保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**

不会。演示文稿只存储[外部文件的链接](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/externalworkbookpath/)，并在读取数据时使用该链接。保存演示文稿时不会修改外部文件本身。

**如果外部文件受密码保护该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是事先移除保护或准备一个已解密的副本（例如使用[Aspose.Cells](/cells/net/)），并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表都会存储自己的链接。如果它们指向同一文件，更新该文件后，下次加载数据时所有图表都会反映此更改。