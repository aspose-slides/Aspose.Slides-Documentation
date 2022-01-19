---
title: Setting Number Format for Chart Data Cell using Aspose.Slides
type: docs
weight: 50
url: /java/setting-number-format-for-chart-data-cell-using-aspose-slides/
---

## **Aspose.Slides - Setting Number Format for Chart Data Cell**
Aspose.Slides for Java provides a simple API for managing chart data format:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example usesChartType.ClusteredColumn).
1. Set the preset number format from the possible preset values.
1. Traverse through the chart data cell in every chart series and set the chart data number format.
1. Save the presentation.
1. Set the custom number format.
1. Traverse through chart data cell inside every chart series and setting a different chart data number format.
1. Save the presentation.

**Java**

{{< highlight java >}}

 // Instantiate the presentation//Instantiate the presentation

Presentation pres = new Presentation();

// Access the first presentation slide

ISlide slide = pres.getSlides().get_Item(0);

// Adding a defautlt clustered column chart

IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Accessing the chart series collection

IChartSeriesCollection series = chart.getChartData().getSeries();

// Setting the preset number format

// Traverse through every chart series

for (IChartSeries ser : series)

{

    // Traverse through every data cell in series

    for (IChartDataPoint cell : ser.getDataPoints())

    {

	// Setting the number format

	cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%

    }

}

// Saving presentation

pres.save(dataDir + "AsposePresetNumberFormat.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/charts/numberformatforchartdatacell/AsposeNumberFormatForChartDataCell.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/charts/numberformatforchartdatacell/AsposeNumberFormatForChartDataCell.java)

{{% alert color="primary" %}} 

For more details, visit [Setting Number Format For Chart Data Cell](http://www.aspose.com/docs/display/slidesjava/Setting+Number+Format+for+Chart+Data+Cell).

{{% /alert %}}
