---
title: Chart Workbook
type: docs
weight: 70
url: /net/chart-workbook/
---

## **Chart Workbook**
### **Set Chart Data from Workbook**
A new property has been added to set chart data from workbook. Now Aspose.Slides does allow ReadWorkbookStream() and WrtiteWorkbookStream() methods to read and write chart data workbooks containing chart data edited using Aspose.Cells. However, the chart data needs to be organized in same way or of similar type as of source type. Below sample example is given.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-SetChartDataFromWorkBook-SetChartDataFromWorkBook.cs" >}}
### **Set WorkBook Cell as Chart DataLabel**
Aspose.Slides for .NET provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the Bubble type.
1. Accessing the chart series.
1. Setting Workbook cell as data label.
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-UsingWorkBookChartcellAsDatalabel-UsingWorkBookChartcellAsDatalabel.cs" >}}
### **Get Chart External Data Source Workbook Path**
Aspose.Slides for .NET provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Create object for chart shape
1. Create object for source type of ChartDataSourceType which represents data source of the chart.
1. If Source Type is equal to external workbook the get chart external data source workbook path.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-DataSourceTypePropertyAdded-DataSourceTypePropertyAdded.cs" >}}


## **External Workbook**
{{% alert color="primary" %}} 
Aspose.Slides for .NET for 19.4 supports external workbooks as a data source for charts.
{{% /alert %}} 
### **Create External Workbook**
This article demonstrates how to create an external workbook from scratch using Aspose.Slides for .NET. **IChartData.ReadWorkbookStream()** and **IChartData.SetExternalWorkbook()** methods can be used to create an external workbook from scratch or to make an internal workbook external.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Charts-CreateExternalWorkbook-CreateExternalWorkbook.cs" >}}


### **Set External Workbook**
Using Aspose.Slides for .NET, an external workbook can be assigned to a chart as a data source. For this purpose **IChartData.SetExternalWorkbook** method has been added.

**SetExternalWorkbook()** method can be also used to update a path to the external workbook if it has been moved. Workbooks placed on remote resources unavailable for data editing but still can be assigned as an external data source. If the relative path was provided for an external workbook, it converts to full path automatically.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Charts-SetExternalWorkbook-SetExternalWorkbook.cs" >}}

The **SetExternalWorkbook(System::String workbookPath, bool updateChartData)** method has been added with **updateChartData** parameter to the **ChartData** and **IChartData** classes.

The **updateChartData** parameter defines whether an excel workbook will be loaded or not. If the value is ***false*** only the workbook path will be updated. Chart data will not be loaded and updated from the target workbook. This is useful when the target workbook does not yet exist or is not available. If the value is **true** chart data will be updated from the target workbook as the **SetExternalWorkbook(System::String)** method does.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Charts-SetExternalWorkbookWithUpdateChartData-SetExternalWorkbookWithUpdateChartData.cs" >}}
### **Edit Chart Data**
Using Aspose.Slides for .NET, Chart data in external workbooks can be edited the same way it works for internal workbooks. If external workbook cannot be loaded an exception is thrown.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Charts-EditChartDatainExternalWorkbook-EditChartDatainExternalWorkbook.cs" >}}




