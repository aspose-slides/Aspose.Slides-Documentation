---
title: Adding Chart Trend Lines using Aspose.Slides
type: docs
weight: 10
url: /java/adding-chart-trend-lines-using-aspose-slides/
---

## **Aspose.Slides - Adding Chart Trend Lines**
Aspose.Slides for Java provides a simple API for managing different chart Trend Lines:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example usesChartType.ClusteredColumn).
1. Adding exponential trend line for chart series 1.
1. Adding linear trend line for chart series 1.
1. Adding logarithmic trend line for chart series 2.
1. Adding moving average trend line for chart series 2.
1. Adding polynomial trend line for chart series 3.
1. Adding power trend line for chart series 3.
1. Write the modified presentation to a PPTX file.

**Java**

{{< highlight java >}}

 //Creating empty presentation//Creating empty presentation

Presentation pres = new Presentation();

//Creating a clustered column chart

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

//Adding potential trend line for chart series 1

ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);

tredLinep.setDisplayEquation(false);

tredLinep.setDisplayRSquaredValue(false);

//Adding Linear trend line for chart series 1

ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);

tredLineLin.setTrendlineType(TrendlineType.Linear);

tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);

tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);


//Adding Logarithmic trend line for chart series 2

ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);

tredLineLog.setTrendlineType(TrendlineType.Logarithmic);

tredLineLog.addTextFrameForOverriding("New log trend line");

//Adding MovingAverage trend line for chart series 2

ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);

tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);

tredLineMovAvg.setPeriod((byte)3);

tredLineMovAvg.setTrendlineName("New TrendLine Name");

//Adding Polynomial trend line for chart series 3

ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);

tredLinePol.setTrendlineType(TrendlineType.Polynomial);

tredLinePol.setForward(1);

tredLinePol.setOrder ((byte)3);

//Adding Power trend line for chart series 3

ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);

tredLinePower.setTrendlineType(TrendlineType.Power);

tredLinePower.setBackward(1);

//Saving presentation

pres.save(dataDir + "AsposeChartTrendLines.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/charts/charttrendlines/AsposeAddChartTrendLines.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/charts/charttrendlines/AsposeAddChartTrendLines.java)

{{% alert color="primary" %}} 

For more details, visit [Adding Chart Trend Lines](/slides/java/adding-chart-trend-lines-in-aspose-slides/).

{{% /alert %}}
