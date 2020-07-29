---
title: Setting Pie Chart Sector Colors in Aspose.Slides
type: docs
weight: 30
url: /java/setting-pie-chart-sector-colors-in-aspose-slides/
---

## **Aspose.Slides - Setting Pie Chart Sector Colors**
Aspose.Slides for Java provides a simple API for creating and filling pie charts in an easy way. To create a chart on a slide:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Pie).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Add new points for charts and add custom colors for the pie chart's sectors.
1. Set labels for series.
1. Set leader lines for series labels.
1. Set the rotation angle for pie chart slides.
1. Write the modified presentation to a PPTX file

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents PPTX file

Presentation pres = new Presentation();

//Access first slide

ISlide sld = pres.getSlides().get_Item(0);

// Add chart with default data

IChart chart = sld.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

//Setting chart Title

chart.getChartTitle().addTextFrameForOverriding("Sample Title");

chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);

chart.getChartTitle().setHeight(20);

chart.hasTitle(true);

//Set first series to Show Values

chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

//Setting the index of chart data sheet

int defaultWorksheetIndex = 0;

//Getting the chart data worksheet

IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

//Delete default generated series and categories

chart.getChartData().getSeries().clear();

chart.getChartData().getCategories().clear();

//Adding new categories

chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));

chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));

chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

//Adding new series

IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

//Now populating series data

series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));

series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));

series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));


//Not working in new version

//Adding new points and setting sector color

//series.IsColorVaried = true;

chart.getChartData().getSeriesGroups().get_Item(0).isColorVaried(true);

IChartDataPoint point = series.getDataPoints().get_Item(0);

point.getFormat().getFill().setFillType(FillType.Solid);

point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);

//Setting Sector border

point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);

point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

point.getFormat().getLine().setWidth(3.0);

point.getFormat().getLine().setStyle(LineStyle.ThinThick);

point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);


IChartDataPoint point1 = series.getDataPoints().get_Item(1);

point1.getFormat().getFill().setFillType (FillType.Solid);

point1.getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.Brown));

//Setting Sector border

point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);

point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

point1.getFormat().getLine().setWidth(3.0);

point1.getFormat().getLine().setStyle(LineStyle.Single);

point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);

IChartDataPoint point2 = series.getDataPoints().get_Item(2);

point2.getFormat().getFill().setFillType(FillType.Solid);

point2.getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.Coral));

//Setting Sector border

point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);

point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

point2.getFormat().getLine().setWidth(2.0);

point2.getFormat().getLine().setStyle(LineStyle.ThinThin);

point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);


//Create custom labels for each of categories for new series

IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();

// lbl.ShowCategoryName = true;

lbl1.getDataLabelFormat().setShowValue(true);


IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();

lbl2.getDataLabelFormat().setShowValue (true);

lbl2.getDataLabelFormat().setShowLegendKey(true);

lbl2.getDataLabelFormat().setShowPercentage(true);

IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();

lbl3.getDataLabelFormat().setShowSeriesName(true);

lbl3.getDataLabelFormat().setShowPercentage (true);


//Showing Leader Lines for Chart

series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);

//Setting Rotation Angle for Pie Chart Sectors

chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);

// Save presentation with chart

pres.save(dataDir + "AsposePieChart.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Setting Pie Chart Sector Colors](http://docs.aspose.com:8082/docs/display/slidesjava/Setting+Pie+Chart+Sector+Colors).

{{% /alert %}}
