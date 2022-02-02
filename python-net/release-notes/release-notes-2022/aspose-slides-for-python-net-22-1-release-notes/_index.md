---
title: Aspose.Slides for Python 22.1 Release Notes
type: docs
weight: 100
url: /python-net/aspose-slides-for-python-net-22-1-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for Python via .NET 22.1](https://pypi.org/project/Aspose.Slides/22.1/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|**Related Documentation**|
| :- | :- | :- | :- |
|SLIDESPYNET-3|[Use Aspose.Slides for Net 22.1 features](/slides/net/aspose-slides-for-net-22-1-release-notes/)|Enhancement| |


## **Public API Changes**

### `NONE` member have been added to TimeUnitType enumeration ###

A new *NONE* member have been added to [TimeUnitType](/slides/python-net/api-reference/aspose.slides.charts/timeunittype/) enumeration. This member indicates that no unit should be set for the appropriate unit scale.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 10, 10, 400, 300, True)
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.NONE
    pres.save("chart.pptx", slides.export.SaveFormat.PPTX)
```