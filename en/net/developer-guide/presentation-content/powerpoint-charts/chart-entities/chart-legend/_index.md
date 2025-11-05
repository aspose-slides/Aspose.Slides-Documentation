---
title: Chart Legend
type: docs
url: /net/chart-legend/
keywords: "Chart legend, legend font size, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Set positioning and font size for chart legend in PowerPoint presentations in C# or .NET"
---

## **Legend Positioning**
In order to set the legend properties. Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- Get reference of the slide.
- Adding a chart on slide.
- Setting the properties of legend.
- Write the presentation as a PPTX file.

In the example given below, we have set the position and size for Chart legend.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();

// Get reference of the slide
ISlide slide = presentation.Slides[0];

// Add a clustered column chart on the slide
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Set Legend Properties
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Write presentation to disk
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```



## **Set Font Size of Legend**
The Aspose.Slides for .NET lets developers allow to set font size of legend. Please follow the steps below: 

- Instantiate `Presentation` class.
- Creating the default chart.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Set Font Size of Individual Legend**
The Aspose.Slides for .NET lets developers allow to set font size of individual legend entries. Please follow the steps below: 

- Instantiate `Presentation` class.
- Creating the default chart.
- Access legend entry.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Yes. Use the non-overlay mode ([Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) = `false`); in this case, the plot area will shrink to accommodate the legend.

**Can I make multi-line legend labels?**

Yes. Long labels wrap automatically when space is insufficient; forced line breaks are supported via newline characters in the series name.

**How do I make the legend follow the presentation theme’s color scheme?**

Do not set explicit colors/fills/fonts for the legend or its text. They will then inherit from the theme and update correctly when the design changes.
