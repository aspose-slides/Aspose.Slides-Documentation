---
title: Customize Chart Legends in Presentations with Python
linktitle: Chart Legend
type: docs
url: /python-net/chart-legend/
keywords:
- chart legend
- legend position
- font size
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Customize chart legends with Aspose.Slides for Python via .NET to optimize PowerPoint and OpenDocument presentations with tailored legend formatting."
---

## **Overview**

Aspose.Slides for Python provides full control over chart legends so you can make data labels clear and presentation-ready. You can show or hide the legend, choose its position on the slide, and adjust layout to prevent overlap with the plot area. The API lets you style text and markers, fine-tune padding and background, and format borders and fills to match your theme. Developers can also access individual legend entries to rename or filter them, ensuring only the most relevant series are displayed. With these capabilities, your charts remain readable, consistent, and aligned with your presentation’s design standards.

## **Legend Positioning**

Using Aspose.Slides, you can quickly control where the chart legend appears and how it fits your slide layout. Learn how to place the legend precisely.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to the slide.
1. Add a chart to the slide.
1. Set the legend properties.
1. Save the presentation as a PPTX file.

In the example below, we set the position and size of the chart legend:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Get a reference to the slide.
    slide = presentation.slides[0]

    # Add a clustered column chart to the slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Set the legend properties.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Save the presentation to disk.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Set the Legend Font Size**

A chart’s legend should be as readable as the data it explains. This section shows how to adjust the legend’s font size so you can match your presentation’s typography and improve accessibility.

1. Instantiate the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Create a chart.
1. Set the font size.
1. Save the presentation to disk.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Set the Font Size for a Legend Entry**

Aspose.Slides lets you fine-tune the appearance of chart legends by formatting individual entries. The example below shows how to target a specific legend item and set its properties without changing the rest of the legend.

1. Instantiate the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Create a chart.
1. Access a legend entry.
1. Set the entry properties.
1. Save the presentation to disk.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Yes. Use the non-overlay mode ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`); in this case, the plot area will shrink to accommodate the legend.

**Can I make multi-line legend labels?**

Yes. Long labels wrap automatically when space is insufficient; forced line breaks are supported via newline characters in the series name.

**How do I make the legend follow the presentation theme’s color scheme?**

Do not set explicit colors/fills/fonts for the legend or its text. They will then inherit from the theme and update correctly when the design changes.
