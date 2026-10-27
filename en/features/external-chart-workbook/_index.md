---
title: Link charts to external workbooks
description: Link chart data to an external workbook and refresh it.
type: docs
url: /features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---

## **Overview**

Point a chart at an external workbook instead of keeping all its source data embedded in the presentation. You can set the workbook path and choose whether to update the chart from that file. The saved chart can also carry cached display data.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Create a valid sales workbook with North = 55 and South = 40 and write it as sales.xlsx beside the output. Reset the chart's North value to 20, then link the chart to the workbook's absolute path and refresh: North becomes 55 again. The explicit range covers the header and two data rows. Keep sales.xlsx available when reopening or updating the linked chart; the presentation does not embed this external file. No input file is needed. It saves *external-chart-workbook.pptx* and *external-chart-workbook.png*. Install the library using the [installation guide](/slides/net/installation/).

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

## **FAQ**

### **Can I read every cached value when the linked file is missing?**

The data-access API has limitations without the external workbook. Keep the linked file available when your workflow needs to read or update its values.

### **What happens if the external workbook is moved?**

Update the chart's external workbook path to its new location, and make that file available wherever the presentation is processed. Do not rely on cached data for full data-access operations when it is missing.

### **Can I choose whether to refresh cached chart data when linking?**

Yes. Choose whether to update chart data when setting the link. Refreshing requires an available supported workbook; skipping refresh records the link without reading new values from that file.

## **Guides**

- [Manage Chart Workbooks in Presentations in .NET](/slides/net/chart-workbook/)

Related feature: [Fill editable charts with data](/slides/features/chart-data-binding/).
