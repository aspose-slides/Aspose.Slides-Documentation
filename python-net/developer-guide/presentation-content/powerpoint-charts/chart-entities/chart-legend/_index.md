---
title: Chart Legend
type: docs
url: /python-net/chart-legend/
keywords: "Chart legend, legend font size, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Set positioning and font size for chart legend in PowerPoint presentations in Python"
---

## **Legend Positioning**
In order to set the legend properties. Please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
- Get reference of the slide.
- Adding a chart on slide.
- Setting the properties of legend.
- Write the presentation as a PPTX file.

In the example given below, we have set the position and size for Chart legend.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:

    # Get reference of the slide
    slide = presentation.slides[0]

    # Add a clustered column chart on the slide
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Set Legend Properties
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Write presentation to disk
    presentation.save("Legend_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Font Size of Legend**
The Aspose.Slides for Python via .NET lets developers allow to set font size of legend. Please follow the steps below: 

- Instantiate `Presentation` class.
- Creating the default chart.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.legend.text_format.portion_format.font_height = 20
	chart.axes.vertical_axis.is_automatic_min_value = False
	chart.axes.vertical_axis.min_value = -5
	chart.axes.vertical_axis.is_automatic_max_value = False
	chart.axes.vertical_axis.max_value = 10

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Set Font Size of Individual Legend**
The Aspose.Slides for Python via .NET lets developers allow to set font size of individual legend entries. Please follow the steps below: 

- Instantiate `Presentation` class.
- Creating the default chart.
- Access legend entry.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw
 
 
with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	tf = chart.legend.entries[1].text_format

	tf.portion_format.font_bold = 1
	tf.portion_format.font_height = 20
	tf.portion_format.font_italic = 1
	tf.portion_format.fill_format.fill_type = slides.FillType.SOLID 
	tf.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

