---
title: Format Presentation Charts in .NET
linktitle: Chart Formatting
type: docs
weight: 60
url: /net/chart-formatting/
keywords:
- format chart
- chart formatting
- chart entity
- chart properties
- chart settings
- chart options
- font properties
- rounded border
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn chart formatting in Aspose.Slides for .NET and elevate your PowerPoint presentation with professional, eye-catching styling."
---

## **Format Chart Entities**
Aspose.Slides for .NET lets developers add custom charts to their slides from scratch. This article explains how to format different chart entities including chart category and value axis.

Aspose.Slides for .NET provides a simple API for managing different chart entities and formatting them using custom values:

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

```c#
// Instantiating presentation// Instantiating presentation
Presentation pres = new Presentation();

// Accessing the first slide
ISlide slide = pres.Slides[0];

// Adding the sample chart
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Setting Chart Titile
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Major grid lines format for value axis
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Setting Minor grid lines format for value axis
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting value axis number format
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Setting chart maximum, minimum values
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Setting Value Axis Text Properties
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Setting value axis title
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Setting value axis line format : Now Obselete
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Setting Major grid lines format for Category axis
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Setting Minor grid lines format for Category axis
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting Category Axis Text Properties
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Setting Category Titile
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting category axis lable position
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Setting category axis lable rotation angle
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Setting Legends Text Properties
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Set show chart legends without overlapping chart

chart.Legend.Overlay = true;
            
// Ploting first series on secondary value axis
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Setting chart back wall color
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```



## **Set Font Properties for a Chart**
Aspose.Slides for .NET provides support for setting the font related properties for the chart. Please follow the steps below for setting the font properties for chart.

- Instantiate Presentation class object.
- Add chart on the slide.
- Set font height.
- Save modified presentation.

Below sample example is given.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```




## **Set the Numeric Format**
Aspose.Slides for .NET provides a simple API for managing chart data format:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).
1. Set the preset number format from the possible preset values.
1. Traverse through the chart data cell in every chart series and set the chart data number format.
1. Save the presentation.
1. Set the custom number format.
1. Traverse through chart data cell inside every chart series and setting a different chart data number format.
1. Save the presentation.

```c#
// Instantiate the presentation// Instantiate the presentation
Presentation pres = new Presentation();

// Access the first presentation slide
ISlide slide = pres.Slides[0];

// Adding a defautlt clustered column chart
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Accessing the chart series collection
IChartSeriesCollection series = chart.ChartData.Series;

// Setting the preset number format
// Traverse through every chart series
foreach (ChartSeries ser in series)
{
    // Traverse through every data cell in series
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Setting the number format
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Saving presentation
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
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
Aspose.Slides for .NET provides support for setting chart area. **IChart.HasRoundedCorners** and **Chart.HasRoundedCorners** properties have been added in Aspose.Slides. 

1. Instantiate `Presentation` class object.
1. Add chart on the slide.
1. Set fill type and fill color of chart
1. Set round corner property True.
1. Save modified presentation.

 Below sample example is given. 

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Can I set semi-transparent fills for columns/areas while keeping the border opaque?**

Yes. Fill transparency and the outline are configured separately. This is useful for improving the readability of the grid and data in dense visualizations.

**How can I deal with data labels when they overlap?**

Reduce the font size, disable nonessential label components (for example, categories), set the label offset/position, show labels only for selected points if necessary, or switch the format to "value + legend".

**Can I apply gradient or pattern fills to series?**

Yes. Both solid and gradient/pattern fills are typically available. In practice, use gradients sparingly and avoid combinations that reduce contrast with the grid and text.
