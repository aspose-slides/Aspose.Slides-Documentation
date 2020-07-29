---
title: Setting the Label Distance From Category Axis in Python
type: docs
weight: 80
url: /java/setting-the-label-distance-from-category-axis-in-python/
---

## **Aspose.Slides - Setting the Label Distance From Category Axis**
For Setting the Label Distance From Category Axis using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 # Instantiate Presentation class that represents the presentation file

pres = self.Presentation()

\# Access first slide

sld = pres.getSlides().get_Item(0)

\# Adding a chart on slide

chartType=self.ChartType

ch = sld.getShapes().addChart(chartType.ClusteredColumn, 20, 20, 500, 300)

\# Setting the position of label from axis

ch.getAxes().getHorizontalAxis().setLabelOffset(500)

\# Saving the presentation

save_format = self.SaveFormat

pres.save(self.dataDir + "Position.pptx", save_format.Pptx)

print "Set label distance, please check the output file."


{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavajython.codeplex.com/releases/view/620122)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Jython-v1.0)
