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

## **Set Font Properties for Chart Data Table**
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
