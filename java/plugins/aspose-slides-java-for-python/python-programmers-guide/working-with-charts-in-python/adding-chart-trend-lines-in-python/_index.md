---
title: Adding Chart Trend Lines in Python
type: docs
weight: 20
url: /java/adding-chart-trend-lines-in-python/
---

## **Aspose.Slides - Adding Chart Trend Lines**
To Add Chart Trend Lines using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Creating empty presentation

pres =self.Presentation()

\# Creating a clustered column chart

chartType=self.ChartType

chart = pres.getSlides().get_Item(0).getShapes().addChart(chartType.ClusteredColumn, 20, 20, 500, 400)

\# Adding ponential trend line for chart series 1

trendlineType=self.TrendlineType()

tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(trendlineType.Exponential)

tredLinep.setDisplayEquation(False)

tredLinep.setDisplayRSquaredValue(False)

\# Adding Linear trend line for chart series 1

fillType=self.FillType()

color=self.Color()

tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(trendlineType.Linear)

tredLineLin.setTrendlineType(trendlineType.Linear)

tredLineLin.getFormat().getLine().getFillFormat().setFillType(fillType.Solid)

tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(color.RED)


\# Adding Logarithmic trend line for chart series 2

tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(trendlineType.Logarithmic)

tredLineLog.setTrendlineType(trendlineType.Logarithmic)

tredLineLog.addTextFrameForOverriding("self.log trend line")

\# Adding MovingAverage trend line for chart series 2

tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(trendlineType.MovingAverage)

tredLineMovAvg.setTrendlineType(trendlineType.MovingAverage)

tredLineMovAvg.setPeriod(3)

tredLineMovAvg.setTrendlineName("self.TrendLine Name")

\# Adding Polynomial trend line for chart series 3

tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(trendlineType.Polynomial)

tredLinePol.setTrendlineType(trendlineType.Polynomial)

tredLinePol.setForward(1)

tredLinePol.setOrder(3)

\# Adding Power trend line for chart series 3

tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(trendlineType.Power)

tredLinePower.setTrendlineType(trendlineType.Power)

tredLinePower.setBackward(1)

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "ChartTrendLines.pptx", save_format.Pptx)

print "Done with chart trend lines, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
