---
title: Adding Chart Series Overlap for Charts in Python
type: docs
weight: 10
url: /java/adding-chart-series-overlap-for-charts-in-python/
---

## **Aspose.Slides - Adding Chart Series Overlap for Charts**
To Add Chart Series Overlap for Charts using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Instantiate Presentation class that represents the presentation file

pres = self.Presentation()

\# Adding chart

chartType = self.ChartType

chart = pres.getSlides().get_Item(0).getShapes().addChart(chartType.ClusteredColumn, 50, 50, 600, 400, True)

series = chart.getChartData().getSeries()

if (series.get_Item(0).getOverlap() == 0):

\# Setting series overlap

    series . get_Item(0) . getParentSeriesGroup().setOverlap(-30)


\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "Overlap.pptx", save_format.Pptx)

print "Added chart series overlap for charts, please check the output file."

{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
