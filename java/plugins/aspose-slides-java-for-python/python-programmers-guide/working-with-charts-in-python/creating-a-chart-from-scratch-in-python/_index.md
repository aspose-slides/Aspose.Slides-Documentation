---
title: Creating a Chart from Scratch in Python
type: docs
weight: 40
url: /java/creating-a-chart-from-scratch-in-python/
---

## **Aspose.Slides - Creating a Chart from Scratch**
To Create a Chart from Scratch using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

```

 def create_normal_chart(self):

\# Instantiate Presentation class that represents the presentation file

pres = self.Presentation()

\# Access first slide

sld = pres.getSlides().get_Item(0)

\# Add chart with default data

chartTye = self.ChartType

chart = sld.getShapes().addChart(chartTye.ClusteredColumn, 0, 0, 500, 500)

\# Setting chart Title

\# chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title"

chart.getChartTitle().addTextFrameForOverriding("Sample Title")

nullableBool = self.NullableBool()

chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(nullableBool.True)

chart.getChartTitle().setHeight (20)

chart.hasTitle(True)

\# Set first series to Show Values

chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

\# Setting the index of chart data sheet

defaultWorksheetIndex = 0

\# Getting the chart data worksheet

fact = chart.getChartData().getChartDataWorkbook()

\# Delete default generated series and categories

chart.getChartData().getSeries().clear()

chart.getChartData().getCategories().clear()

s = chart.getChartData().getSeries().size()

s = chart.getChartData().getCategories().size()

\# Adding self.series

chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType())

chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType())

\# Adding self.categories

chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))

chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))

chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

\# Take first chart series

series = chart.getChartData().getSeries().get_Item(0)

\# Now populating series data

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20))

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50))

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30))

\# Setting fill color for series

fillType=self.FillType()

color=self.Color()

series.getFormat().getFill().setFillType(fillType.Solid)

series.getFormat().getFill().getSolidFillColor().setColor(color.RED)


\# Take second chart series

series = chart.getChartData().getSeries().get_Item(1)

\# Now populating series data

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30))

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10))

series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60))

\# Setting fill color for series

fillType=self.FillType()

color=self.Color()

series.getFormat().getFill().setFillType(fillType.Solid)

series.getFormat().getFill().getSolidFillColor().setColor(color.GREEN)

\# create custom labels for each of categories for self.series

\# first label will be show Category name

lbl = series.getDataPoints().get_Item(0).getLabel()

lbl.getDataLabelFormat().setShowCategoryName(True)

lbl = series.getDataPoints().get_Item(1).getLabel()

lbl.getDataLabelFormat().setShowSeriesName(True)

\# Show value for third label

lbl = series.getDataPoints().get_Item(2).getLabel()

lbl.getDataLabelFormat().setShowValue(True)

lbl.getDataLabelFormat().setShowSeriesName(True)

lbl.getDataLabelFormat().setSeparator ("/")

\# Save presentation with chart

saveFormat = self.SaveFormat

pres.save(self.dataDir + "NormalChart.pptx", saveFormat.Pptx)

print "Created normal chart, please check the output file."

def create_scatter_chart(self):

pres = self.Presentation

slide = pres.getSlides().get_Item(0)

chartType=self.ChartType()

\# Creating the default chart

chart = slide.getShapes().addChart(chartType.ScatterWithSmoothLines, 0, 0, 400, 400)

\# Getting the default chart data worksheet index

defaultWorksheetIndex = 0

\# Getting the chart data worksheet

fact = chart.getChartData().getChartDataWorkbook()

\# Delete demo series

chart.getChartData().getSeries().clear()

\# Add self.series

chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType())

chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType())

\# Take first chart series

series = chart.getChartData().getSeries().get_Item(0)

\# Add self.point (1:3) there.

series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3))

\# Add self.point (2:10)

series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10))

\# Edit the type of series

chartType=self.ChartType()

series.setType(chartType.ScatterWithStraightLinesAndMarkers)

\# Changing the chart series marker

markerStyleType=self.MarkerStyleType()

series.getMarker().setSize(10)

series.getMarker().setSymbol(markerStyleType.Star)

\# Take second chart series

series = chart.getChartData().getSeries().get_Item(1)

\# Add self.point (5:2) there.

series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2))

\# Add self.point (3:1)

series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1))

\# Add self.point (2:2)

series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2))

\# Add self.point (5:1)

series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1))

\# Changing the chart series marker

markerStyleType1=self.MarkerStyleType()

series.getMarker().setSize(10)

series.getMarker().setSymbol(markerStyleType1.Circle)

save_format = self.SaveFormat

pres.save(self.dataDir + "AsposeScatterChart.pptx", save_format.Pptx)

print "Created scatter chart, please check the output file."

```
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
