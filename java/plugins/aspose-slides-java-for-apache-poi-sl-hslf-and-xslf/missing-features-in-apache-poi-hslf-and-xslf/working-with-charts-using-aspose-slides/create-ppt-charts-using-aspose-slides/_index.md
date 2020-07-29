---
title: Create PPT Charts using Aspose.Slides
type: docs
weight: 30
url: /java/create-ppt-charts-using-aspose-slides/
---

## **Aspose.Slides - Create PPT Charts**
Aspose.Slides for Java has provided the simplest API for creating charts in an easy way. To create a chart in a slide, please follow the steps below:

1. Create an instance of the Presentation class.
1. Obtain the reference of a slide by index.
1. Add chart with default data along with desired type.
1. Add a chart title.
1. Access the chart data worksheet.
1. Clear all the default series and categories.
1. Add new series and categories.
1. Add new chart data for chart series.
1. Add fill color for chart series.
1. Adding chart series labels.
1. Write the modified presentation as a PPTX file.

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents PPTX file

Presentation pres = new Presentation();

//Access first slide

ISlide sld = pres.getSlides().get_Item(0);

// Add chart with default data

IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Setting chart Title

//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";

chart.getChartTitle().addTextFrameForOverriding("Sample Title");

chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);

chart.getChartTitle().setHeight (20);

chart.hasTitle(true);

//Set first series to Show Values

chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue( true);

//Setting the index of chart data sheet

int defaultWorksheetIndex = 0;

//Getting the chart data worksheet

IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

//Delete default generated series and categories

chart.getChartData().getSeries().clear();

chart.getChartData().getCategories().clear();

int s = chart.getChartData().getSeries().size();

s = chart.getChartData().getCategories().size();

//Adding new series

chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());

chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());

//Adding new categories

chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));

chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));

chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Take first chart series

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

//Now populating series data

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

//Setting fill color for series

series.getFormat().getFill().setFillType(FillType.Solid);

series.getFormat().getFill().getSolidFillColor().setColor (Color.RED);


//Take second chart series

series = chart.getChartData().getSeries().get_Item(1);

//Now populating series data

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));

//Setting fill color for series

series.getFormat().getFill().setFillType (FillType.Solid);

series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);

//create custom labels for each of categories for new series

//first label will be show Category name

IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();

lbl.getDataLabelFormat().setShowCategoryName(true);

lbl = series.getDataPoints().get_Item(1).getLabel();

lbl.getDataLabelFormat().setShowSeriesName(true);

//Show value for third label

lbl = series.getDataPoints().get_Item(2).getLabel();

lbl.getDataLabelFormat().setShowValue(true);

lbl.getDataLabelFormat().setShowSeriesName(true);

lbl.getDataLabelFormat().setSeparator ("/");

//Save presentation with chart

pres.save(dataDir + "AsposeChart.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/charts/createcharts/AsposeCharts.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/charts/createcharts/AsposeCharts.java)

{{% alert color="primary" %}} 

For more details, visit [Creating a Chart from Scratch](/slides/java/creating-and-updating-chart-in-a-slide/#creatingandupdatingchartinaslide-createachartfromscratch).

{{% /alert %}}
