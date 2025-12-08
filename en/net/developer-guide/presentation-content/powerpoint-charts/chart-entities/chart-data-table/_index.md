---
title: Customize Chart Data Tables in Presentations in .NET
linktitle: Data Table
type: docs
url: /net/chart-data-table/
keywords:
- chart data
- data table
- font properties
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Customize chart data tables in .NET for PPT and PPTX with Aspose.Slides to boost efficiency and appeal in presentations."
---

## **Set Font Properties for a Chart Data Table**
Aspose.Slides for .NET provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class object.
1. Add chart on the slide.
1. set chart table.
1. Set font height.
1. Save modified presentation.

 Below sample example is given. 

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Can I show small legend keys next to the values in the chart’s data table?**

Yes. The data table supports [legend keys](https://reference.aspose.com/slides/net/aspose.slides.charts/datatable/showlegendkey/), and you can turn them on or off.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Yes. Aspose.Slides renders the chart as part of the slide, so the exported [PDF](/slides/net/convert-powerpoint-to-pdf/)/[HTML](/slides/net/convert-powerpoint-to-html/)/[image](/slides/net/convert-powerpoint-to-png/) includes the chart with its data table.

**Are data tables supported for charts that come from a template file?**

Yes. For any chart loaded from an existing presentation or template, you can check and change whether a data table [is shown](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) using the chart’s properties.

**How can I quickly find which charts in a file have the data table enabled?**

Inspect each chart’s property that indicates whether the data table [is shown](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) and iterate through the slides to identify the charts where it is enabled.
