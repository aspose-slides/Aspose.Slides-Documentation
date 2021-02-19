---
title: Chart Workbook
type: docs
weight: 70
url: /java/chart-workbook/
---


{{% alert color="primary" %}} 

Aspose.Slides for Java for 19.4 supports external workbooks as a data source for charts.

{{% /alert %}} 

## **Create Workbook**
This article demonstrates how to create an external workbook from scratch using Aspose.Slides for Java. **IChartData.readWorkbookStream()** and **IChartData.setExternalWorkbook()** methods can be used to create an external workbook from scratch or to make an internal workbook external.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateExternalWorkbook-CreateExternalWorkbook.java" >}}


## **Set Workbook**
Using Aspose.Slides for Java, an external workbook can be assigned to a chart as a data source. For this purpose **IChartData.setExternalWorkbook** method has been added.

**setExternalWorkbook()** method can be also used to update a path to the external workbook if it has been moved. Workbooks placed on remote resources unavailable for data editing but still can be assigned as an external data source. If the relative path was provided for an external workbook, it converts to full path automatically.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SetExternalWorkbook-SetExternalWorkbook.java" >}}

The **setExternalWorkbook(String *workbookPath*, boolean *updateChartData*)** method has been added with **updateChartData** parameter.

The **updateChartData** parameter defines whether an excel workbook will be loaded or not. If the value is ***false*** only the workbook path will be updated. Chart data will not be loaded and updated from the target workbook. This is useful when the target workbook does not yet exist or is not available. If the value is **true** chart data will be updated from the target workbook as the **setExternalWorkbook(System::String)** method does.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SetExternalWorkbookWithUpdateChartData-SetExternalWorkbookWithUpdateChartData.java" >}}



## **Get Workbook Path**
Aspose.Slides for Java provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Create object for chart shape
1. Create object for source type of ChartDataSourceType which represents data source of the chart.
1. If Source Type is equal to external workbook the get chart external data source workbook path.

In the example given below, we have set the label distance from category axis.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-DataSourceTypePropertyAdded-DataSourceTypePropertyAdded.java" >}}







## **Set Chart Data from Workbook**
A new property has been added to set chart data from workbook. Now Aspose.Slides does allow ReadWorkbookStream() and WrtiteWorkbookStream() methods to read and write chart data workbooks containing chart data edited using Aspose.Cells. However, the chart data needs to be organized in same way or of similar type as of source type. Below sample example is given.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SetChartDataFromWorkBook-SetChartDataFromWorkBook.java" >}}


## **Edit Chart Data in Workbook**
Using Aspose.Slides for Java, Chart data in external workbooks can be edited the same way it works for internal workbooks. If external workbook cannot be loaded an exception is thrown.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EditChartDatainExternalWorkbook-EditChartDatainExternalWorkbook.java" >}}

