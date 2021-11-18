---
title: Chart Data Table
type: docs
url: /pythonnet/chart-data-table/
keywords: "Font properties, chart data table, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Set font properties for chart database table in PowerPoint presentations in Python"
---

## **Set Font Properties for Chart Data Table**
Aspose.Slides for Python via .NET provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class object.
1. Add chart on the slide.
1. set chart table.
1. Set font height.
1. Save modified presentation.

 Below sample example is given. 

```py
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

