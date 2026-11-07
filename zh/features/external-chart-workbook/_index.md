---
title: 将图表链接到外部工作簿
description: 将图表数据链接到外部工作簿并刷新。
type: docs
url: /zh/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **概述**

将图表指向外部工作簿，而不是将所有源数据嵌入到演示文稿中。您可以设置工作簿路径，并选择是否从该文件更新图表。保存的图表还可以携带缓存的显示数据。

## **使用示例**

此 C# 示例使用 Aspose.Slides for .NET。创建一个有效的销售工作簿，North = 55、South = 40，并将其写入与输出文件同目录下的 sales.xlsx。将图表的 North 值重置为 20，然后将图表链接到工作簿的绝对路径并刷新：North 再次变为 55。显式范围包括标题行和两行数据。重新打开或更新链接的图表时，请保留 sales.xlsx 可用；演示文稿不会嵌入此外部文件。无需输入文件。它会保存 *external-chart-workbook.pptx* 和 *external-chart-workbook.png*。使用[安装指南](/slides/zh/net/installation/)安装库。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **常见问题**

### **当链接的文件缺失时，我能读取所有缓存值吗？**

Aspose.Slides for .NET 26.11 可在不打开链接工作簿的情况下[直接读取存储的图表值](/slides/zh/net/chart-workbook/#read-cached-chart-values-without-a-workbook)。这包括普通值、X/Y 值、气泡大小和类别值（在存在这些缓存时）。缓存数据可能缺失或过时；它并非完整的工作簿。要从源刷新仍需可用的受支持工作簿。对于其他 SDK 和版本，请查看相应的图表指南。

### **如果外部工作簿被移动会怎样？**

将图表的外部工作簿路径更新为新位置，并确保该文件在演示文稿处理的任何位置均可用。缺失时不要依赖缓存数据进行完整的数据访问操作。

### **链接时，我能选择是否刷新缓存的图表数据吗？**

可以。设置链接时选择是否更新图表数据。刷新需要可用的受支持工作簿；跳过刷新仅记录链接，而不从该文件读取新值。

## **指南**

- [在 .NET 中管理演示文稿中的图表工作簿](/slides/zh/net/chart-workbook/)

相关功能： [使用数据填充可编辑图表](/slides/zh/features/chart-data-binding/).