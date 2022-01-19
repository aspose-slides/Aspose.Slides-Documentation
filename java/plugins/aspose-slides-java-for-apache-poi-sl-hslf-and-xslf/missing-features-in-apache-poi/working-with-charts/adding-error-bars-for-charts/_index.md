---
title: Adding Error Bars for Charts using Aspose.Slides
type: docs
weight: 20
url: /java/adding-error-bars-for-charts-using-aspose-slides/
---

## **Aspose.Slides - Adding Error Bars for Charts**
Aspose.Slides for Java provides a simple API for managing error bar values.

The sample code applies when using a custom value type. To specify a value, use theErrorBarCustomValues property of a specific data point in the DataPoints collection of series:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Add a bubble chart on desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

**Java**

{{< highlight java >}}

 //Creating empty presentation

Presentation pres = new Presentation();

//Creating a bubble chart

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

//Adding Error bars and setting its format

IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();

IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

errBarX.setVisible(true);

errBarY.setVisible(true);

errBarX.setValueType((byte)ErrorBarValueType.Fixed);

errBarX.setValue(0.1f);

errBarY.setValueType((byte)ErrorBarValueType.Percentage);

errBarY.setValue(5);

errBarX.setType((byte)ErrorBarType.Plus);

errBarY.getFormat().getLine().setWidth(2.0f);

errBarX.setEndCap(true);

//Saving presentation

pres.save(dataDir + "AsposeErrorBars.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/charts/errorbarsforcharts/AsposeErrorBarsForCharts.java)

{{% alert color="primary" %}} 

For more details, visit [Adding Error Bars For Charts](/slides/java/adding-error-bars-for-charts-using-aspose-slides/).

{{% /alert %}}
