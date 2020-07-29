---
title: Adding Error Bars for Charts in Python
type: docs
weight: 30
url: /java/adding-error-bars-for-charts-in-python/
---

## **Aspose.Slides - Adding Error Bars for Charts**
To Add Error Bars for Charts using **Aspose.Slides Java for Python**. Here you can see example code.

**Python Code**

{{< highlight python >}}

 def add_fixed_error_bar_value(self):

pres = self.Presentation()

\# Creating a bubble chart

chartType=self.ChartType

chart = pres.getSlides().get_Item(0).getShapes().addChart(chartType.Bubble, 50, 50, 400, 300, True)

\# Adding Error bars and setting its format

error_bar_x = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat()

error_bar_y = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat()



#error_bar_x.isVisible(True)

#error_bar_y.isVisible(True)

errorBarValueType = self.ErrorBarValueType()

errorBarType = self.ErrorBarType()

error_bar_x.setValueType(errorBarValueType.Fixed)

error_bar_x.setValue(0.1)

error_bar_y.setValueType(errorBarValueType.Percentage)

error_bar_y.setValue(5)

error_bar_x.setType(errorBarType.Plus)

error_bar_y.getFormat().getLine().setWidth(2.0)

#error_bar_x.hasEndCap(True)

\# Save presentation with chart

save_format = self.SaveFormat

pres.save(self.dataDir + "ErrorBar.pptx", save_format.Pptx)

print "Added fixed error bar value for chart, please check the output file."

def add_custom_error_bar_value(self):



pres = self.Presentation()

slide = pres.getSlides().get_Item(0)

\# Creating a bubble chart

chartType = self.ChartType()

chart = pres.getSlides().get_Item(0).getShapes().addChart(chartType.Bubble, 50, 50, 400, 300, True)

\# Adding custom Error bars and setting its format

error_bar_value_type = self.ErrorBarValueType()

series = chart.getChartData().getSeries().get_Item(0)

error_bar_x = series.getErrorBarsXFormat()

error_bar_y = series.getErrorBarsYFormat()

#error_bar_x.isVisible(True)

#error_bar_y.isVisible(True)

error_bar_x.setValueType(error_bar_value_type.Custom)

error_bar_y.setValueType(error_bar_value_type.Custom)

#Accessing chart series data point and setting error bars values for individual point

data_source_type = self.DataSourceType()

points = series.getDataPoints()

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(data_source_type.DoubleLiterals)

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(data_source_type.DoubleLiterals)

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(data_source_type.DoubleLiterals)

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(data_source_type.DoubleLiterals)

\# Setting error bars for chart series points

i = 0

while (i < points.size()):

    points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1)

    points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1)

    points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1)

    points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1)

    i+=1


save_format = self.SaveFormat

pres.save(self.dataDir + "ErrorBarsCustomValues.pptx", save_format.Pptx)

print "Added custom error bars values for chart, please check the output file."


{{< /highlight >}}
## **Download Running Code**
Download running code from any of the below mentioned social coding sites:

- [CodePlex](https://asposeslidesjavapython.codeplex.com/releases/view/620922)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Python-v1.0)
