---
title: Updating Existing Chart using Aspose.Slides
type: docs
weight: 70
url: /java/updating-existing-chart-using-aspose-slides/
---

## **Aspose.Slides - Updating Existing Chart**
Aspose.Slides for Java also facilitates developers to update PowerPoint charts generated through Aspose.Slides or PowerPoint.

Aspose.Slides for Java has provided the simplest API to update charts in an easiest way. To update a chart in a slide:

- Open an instance of Presentation class containing chart
- Obtain the reference of a slide by using its Index
- Traverse through all shapes to find desired chart
- Access the chart data worksheet
- Modify the chart data series data by changing series values
- Adding a new series and populating data inside it
- Write the modified presentation as a PPTX file

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents PPTX file

Presentation pres = new Presentation("data/AsposeChart.pptx");

//Access first slide

ISlide sld = pres.getSlides().get_Item(0);

// Add chart with default data

IChart chart = (IChart)sld.getShapes().get_Item(0);

//Setting the index of chart data sheet

int defaultWorksheetIndex = 0;

//Getting the chart data worksheet

IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

//Changing chart Category Name

fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");

fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");


//Take first chart series

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

//Now updating series data

fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");//modifying series name

series.getDataPoints().get_Item(0).getValue().setData (90);

series.getDataPoints().get_Item(1).getValue().setData ( 123);

series.getDataPoints().get_Item(2).getValue().setData ( 44);

//Take Second chart series

series = chart.getChartData().getSeries().get_Item(1);

//Now updating series data

fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");//modifying series name

series.getDataPoints().get_Item(0).getValue().setData (23);

series.getDataPoints().get_Item(1).getValue().setData ( 67);

series.getDataPoints().get_Item(2).getValue().setData ( 99);


//Now, Adding a new series

chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

//Take 3rd chart series

series = chart.getChartData().getSeries().get_Item(2);

//Now populating series data

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

chart.setType(ChartType.ClusteredCylinder);

// Save presentation with chart

pres.save(dataDir + "AsposeChartModified.pptx", SaveFormat.Pptx);


{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/charts/updatecharts/AsposeUpdateExistingChart.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/charts/updatecharts/AsposeUpdateExistingChart.java)

{{% alert color="primary" %}} 

For more details, visit [Updating an Existing Chart](http://docs.aspose.com:8082/docs/display/slidesjava/Updating+an+Existing+Chart).

{{% /alert %}}
