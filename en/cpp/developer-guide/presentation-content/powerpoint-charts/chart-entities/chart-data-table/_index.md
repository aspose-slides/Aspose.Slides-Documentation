---
title: Customize Chart Data Tables in Presentations Using С++
linktitle: Data Table
type: docs
url: /cpp/chart-data-table/
keywords:
- chart data
- data table
- font properties
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Customize chart data tables in С++ for PPT and PPTX with Aspose.Slides to boost efficiency and appeal in presentations."
---

## **Set Font Properties for a Chart Data Table**
Aspose.Slides for C++ allows to change font properties for a chart data table. 

1. Instantiate [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class object.
1. Add chart on the slide.
1. Set chart table.
1. Set font height.
1. Save modified presentation.

Below sample example is given. 

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Can I show small legend keys next to the values in the chart’s data table?**

Yes. The data table supports [legend keys](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datatable/set_showlegendkey/), and you can turn them on or off.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Yes. Aspose.Slides renders the chart as part of the slide, so the exported [PDF](/slides/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/cpp/convert-powerpoint-to-html/)/[image](/slides/cpp/convert-powerpoint-to-png/) includes the chart with its data table.

**Are data tables supported for charts that come from a template file?**

Yes. For any chart loaded from an existing presentation or template, you can check and change whether a data table [is shown](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/set_hasdatatable/) using the chart’s properties.

**How can I quickly find which charts in a file have the data table enabled?**

Inspect each chart’s property that indicates whether the data table [is shown](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_hasdatatable/) and iterate through the slides to identify the charts where it is enabled.
