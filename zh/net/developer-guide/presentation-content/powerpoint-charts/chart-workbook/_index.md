---
title: 图表工作簿
type: docs
weight: 70
url: /zh/net/chart-workbook/
keywords: "图表工作簿, 图表数据, PowerPoint演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "C#或.NET中的PowerPoint演示文稿中的图表工作簿"
---

## **从工作簿设置图表数据**
Aspose.Slides提供了[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/)和[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/)方法，允许您读取和写入图表数据工作簿（包含用Aspose.Cells编辑的图表数据）。 **注意**：图表数据必须以相同的方式组织或具有与源相似的结构。

以下C#代码演示了一个示例操作：

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
1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加一个带有一些数据的气泡图。
4. 访问图表系列。
5. 将工作簿单元格设置为数据标签。
6. 保存演示文稿。

以下C#代码展示了如何将工作簿单元格设置为图表数据标签：

```c#
string lbl0 = "标签 0 单元格值";
string lbl1 = "标签 1 单元格值";
string lbl2 = "标签 2 单元格值";

// 实例化表示演示文稿文件的演示文稿类 

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

以下C#代码演示了使用[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets)属性访问工作表集合的操作：

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

以下C#代码展示了如何为数据源指定一个类型：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "字面字符串";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "新单元格");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **外部工作簿**

{{% alert color="primary" %}} 
在[Aspose.Slides 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/)中，我们实现了对外部工作簿作为图表数据源的支持。
{{% /alert %}} 

### **创建外部工作簿**
使用**`ReadWorkbookStream`**和**`SetExternalWorkbook`**方法，您可以从头开始创建外部工作簿或将内部工作簿变为外部的。

以下C#代码演示了外部工作簿创建过程：

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
使用**`SetExternalWorkbook`**方法，您可以将外部工作簿指定为图表的数据源。此方法也可用于更新外部工作簿的路径（如果后者已被移动）。

尽管您无法编辑存储在远程位置或资源中的工作簿中的数据，但您仍然可以将这些工作簿用作外部数据源。如果提供了外部工作簿的相对路径，它会自动转换为完整路径。

以下C#代码展示了如何设置外部工作簿：

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

`SetExternalWorkbook`方法下的`ChartData`参数用于指定是否加载Excel工作簿。

* 当`ChartData`值设置为`false`时，仅更新工作簿路径——不会从目标工作簿加载或更新图表数据。在目标工作簿不存在或不可用的情况下，您可能希望使用此设置。 
* 当`ChartData`值设置为`true`时，图表数据将从目标工作簿更新。

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **获取图表外部数据源工作簿路径**

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)类的实例。
2. 通过其索引获取幻灯片的引用。
3. 为图表形状创建对象。
4. 为表示图表数据源的源（`ChartDataSourceType`）类型创建对象。
5. 根据源类型与外部工作簿数据源类型相同的相关条件进行指定。

以下C#代码演示了该操作：

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

您可以以与内部工作簿中的内容相同的方式编辑外部工作簿中的数据。当无法加载外部工作簿时，将抛出异常。

以下C#代码是所述过程的实现：

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```