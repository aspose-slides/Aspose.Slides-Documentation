---
title: Customize Chart Legends in Presentations Using Python
linktitle: Chart Legend
type: docs
url: /python-java/chart-legend/
keywords:
- chart legend
- legend position
- font size
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Customize chart legends with Aspose.Slides for Python via Java to optimize PowerPoint presentations with tailored legend formatting."
---

## **Overview**

Aspose.Slides provides options for customizing chart legends in PowerPoint presentations. This article shows how to position and size a legend, set the font size for the whole legend, and apply formatting to an individual legend entry.

It also covers several related behaviors in the FAQ, including using non-overlay mode so the plot area makes room for the legend, allowing long legend labels to wrap or use line breaks, and letting legend formatting inherit from the presentation theme when explicit text and fill settings are not applied.

## **Legend Positioning**

To set the legend properties, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get a reference to the slide.
1. Add a chart to the slide.
1. Set the legend properties.
1. Save the presentation as a PPTX file.

The following example sets the position and size of a chart legend.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Create an empty presentation.
presentation = Presentation()
try:
    # Get a reference to the slide.
    slide = presentation.getSlides().get_Item(0)

    # Add a clustered column chart to the slide.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Set the legend properties.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Save the presentation to disk.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set the Font Size of a Legend**

Aspose.Slides for Python via Java allows you to set the font size of a legend. Follow these steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Create the default chart.
1. Set the font size.
1. Set the minimum axis value.
1. Set the maximum axis value.
1. Save the presentation to disk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Create an empty presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set the Font Size of an Individual Legend Entry**

Aspose.Slides for Python via Java allows you to set the font size of individual legend entries. Follow these steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Create the default chart.
1. Access a legend entry.
1. Set the font size.
1. Save the presentation to disk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Create an empty presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Yes. Use [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) with `False` to enable non-overlay mode; in this case, the plot area will shrink to accommodate the legend.

**Can I make multi-line legend labels?**

Yes. Long labels wrap automatically when space is insufficient; forced line breaks are supported via newline characters in the series name.

**How do I make the legend follow the presentation theme’s color scheme?**

Do not set explicit colors, fills, or fonts for the legend or its text. They will then inherit from the theme and update correctly when the design changes.
