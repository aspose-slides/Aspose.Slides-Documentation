---
title: Chart Legend
type: docs
url: /net/chart-legend/
---

## **Legend Positioning**
In order to set the legend properties. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Get reference of the slide.
- Adding a chart on slide.
- Setting the properties of legend.
- Write the presentation as a PPTX file.

In the example given below, we have set the position and size for Chart legend.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();

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
presentation.Save(dataDir + "Legend_out.pptx", SaveFormat.Pptx);
```



## **Set Font Size of Legend**
The Aspose.Slides for .NET lets developers allow to set font size of legend. Please follow the steps below: 

- Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Creating the default chart.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();

using (Presentation pres = new Presentation(dataDir+"test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;

	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

	chart.Axes.VerticalAxis.MinValue = -5;

	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;

	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save(dataDir+"output.pptx", SaveFormat.Pptx);
}
```


## **Set Font Size of Individual Legend**
The Aspose.Slides for .NET lets developers allow to set font size of individual legend entries. Please follow the steps below: 

- Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Creating the default chart.
- Access legend entry.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

```c#
string dataDir = RunExamples.GetDataDir_Charts();
using (Presentation pres = new Presentation(dataDir+"test.pptx"))
       {
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;

	tf.PortionFormat.FontHeight = 20;

	tf.PortionFormat.FontItalic = NullableBool.True;

	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;

	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	pres.Save(dataDir+"output.pptx", SaveFormat.Pptx);

}
```

