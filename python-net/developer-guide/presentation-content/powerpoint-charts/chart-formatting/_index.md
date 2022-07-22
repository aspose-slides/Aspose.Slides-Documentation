---
title: Chart Formatting
type: docs
weight: 60
url: /python-net/chart-formatting/
keywords: "Chart entities, chart properties, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Format chart entities in PowerPoint presentations in Python"
---

## **Format Chart Entities**
Aspose.Slides for Python via .NET lets developers add custom charts to their slides from scratch. This article explains how to format different chart entities including chart category and value axis.

Aspose.Slides for Python via .NET provides a simple API for managing different chart entities and formatting them using custom values:

1. Create an instance of the **Presentation** class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (in this example we will use ChartType.LineWithMarkers).
1. Access the chart Value Axis and set the following properties:
   1. Setting **Line format** for Value Axis Major Grid lines
   1. Setting **Line format** for Value Axis Minor Grid lines
   1. Setting **Number Format** for Value Axis
   1. Setting **Min, Max, Major and Minor units** for Value Axis
   1. Setting **Text Properties** for Value Axis data
   1. Setting **Title** for Value Axis
   1. Setting **Line Format** for Value Axis
1. Access the chart Category Axis and set the following properties:
   1. Setting **Line format** for Category Axis Major Grid lines
   1. Setting **Line format** for Category Axis Minor Grid lines
   1. Setting **Text Properties** for Category Axis data
   1. Setting **Title** for Category Axis
   1. Setting **Label Positioning** for Category Axis
   1. Setting **Rotation Angle** for Category Axis labels
1. Access the chart Legend and set the **Text Properties** for them
1. Set show chart Legends without overlapping chart
1. Access the chart **Secondary Value Axis** and set the following properties:
   1. Enable the Secondary **Value Axis**
   1. Setting **Line Format** for Secondary Value Axis
   1. Setting **Number Format** for Secondary Value Axis
   1. Setting **Min, Max, Major and Minor units** for Secondary Value Axis
1. Now plot the first chart series on Secondary Value Axis
1. Set the chart back wall fill color
1. Set the chart plot area fill color
1. Write the modified presentation to a PPTX file

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiating presentation
with slides.Presentation() as pres:

    # Accessing the first slide
    slide = pres.slides[0]

    # Adding the sample chart
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Setting Chart Titile
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chartTitle = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chartTitle.text = "Sample Chart"
    chartTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chartTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chartTitle.portion_format.font_height = 20
    chartTitle.portion_format.font_bold = 1
    chartTitle.portion_format.font_italic = 1

    # Setting Major grid lines format for value axis
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Setting Minor grid lines format for value axis
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Setting value axis number format
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Setting chart maximum, minimum values
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Setting Value Axis Text Properties
    txtVal = chart.axes.vertical_axis.text_format.portion_format
    txtVal.font_bold = 1
    txtVal.font_height = 16
    txtVal.font_italic = 1
    txtVal.fill_format.fill_type = slides.FillType.SOLID 
    txtVal.fill_format.solid_fill_color.color = draw.Color.dark_green
    txtVal.latin_font = slides.FontData("Times New Roman")

    # Setting value axis title
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    valtitle = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    valtitle.text = "Primary Axis"
    valtitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    valtitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    valtitle.portion_format.font_height = 20
    valtitle.portion_format.font_bold = 1
    valtitle.portion_format.font_italic = 1

    # Setting Major grid lines format for Category axis
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Setting Minor grid lines format for Category axis
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Setting Category Axis Text Properties
    txtCat = chart.axes.horizontal_axis.text_format.portion_format
    txtCat.font_bold = 1
    txtCat.font_height = 16
    txtCat.font_italic = 1
    txtCat.fill_format.fill_type = slides.FillType.SOLID 
    txtCat.fill_format.solid_fill_color.color = draw.Color.blue
    txtCat.latin_font = slides.FontData("Arial")

    # Setting Category Titile
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    catTitle = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    catTitle.text = "Sample Category"
    catTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    catTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    catTitle.portion_format.font_height = 20
    catTitle.portion_format.font_bold = 1
    catTitle.portion_format.font_italic = 1

    # Setting category axis lable position
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Setting category axis lable rotation angle
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Setting Legends Text Properties
    txtleg = chart.legend.text_format.portion_format
    txtleg.font_bold = 1
    txtleg.font_height = 16
    txtleg.font_italic = 1
    txtleg.fill_format.fill_type = slides.FillType.SOLID 
    txtleg.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Set show chart legends without overlapping chart

    chart.legend.overlay = True
                
    # Setting chart back wall color
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red
    # Setting Plot area color
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Save Presentation
    pres.save("FormattedChart_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Font Properties for Chart**
Aspose.Slides for Python via .NET provides support for setting the font related properties for the chart. Please follow the steps below for setting the font properties for chart.

- Instantiate Presentation class object.
- Add chart on the slide.
- Set font height.
- Save modified presentation.

Below sample example is given.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    pres.save("FontPropertiesForChart.pptx", slides.export.SaveFormat.PPTX)
```




## **Set Format of Numerics**
Aspose.Slides for Python via .NET provides a simple API for managing chart data format:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).
1. Set the preset number format from the possible preset values.
1. Traverse through the chart data cell in every chart series and set the chart data number format.
1. Save the presentation.
1. Set the custom number format.
1. Traverse through chart data cell inside every chart series and setting a different chart data number format.
1. Save the presentation.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instantiate the presentation# Instantiate the presentation
with slides.Presentation() as pres:
    # Access the first presentation slide
    slide = pres.slides[0]

    # Adding a defautlt clustered column chart
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Accessing the chart series collection
    series = chart.chart_data.series

    # Setting the preset number format
    # Traverse through every chart series
    for ser in series:
        # Traverse through every data cell in series
        for cell in ser.data_points:
            # Setting the number format
            cell.value.as_cell.preset_number_format = 10 #0.00%

    # Saving presentation
    pres.save("PresetNumberFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

The possible preset number format values along with their preset index and that can be used are given below:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Set Chart Area Rounded Borders**
Aspose.Slides for Python via .NET provides support for setting chart area. **IChart.HasRoundedCorners** and **Chart.HasRoundedCorners** properties have been added in Aspose.Slides. 

1. Instantiate `Presentation` class object.
1. Add chart on the slide.
1. Set fill type and fill color of chart
1. Set round corner property True.
1. Save modified presentation.

 Below sample example is given. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("out.pptx", slides.export.SaveFormat.PPTX)
```

