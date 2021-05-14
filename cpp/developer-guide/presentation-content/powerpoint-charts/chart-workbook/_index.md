---
title: Chart Workbook
type: docs
weight: 70
url: /cpp/chart-workbook/
---

## **Chart Workbook**
### **Set WorkBook Cell as Chart DataLabel**
Aspose.Slides for C++ provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the Bubble type.
1. Accessing the chart series.
1. Setting Workbook cell as data label.
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Charts-UsingWorkBookChartcellAsDatalabel-UsingWorkBookChartcellAsDatalabel.cs" >}}


### **Get Chart External Data Source Workbook Path**
Aspose.Slides for C++ provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Create object for chart shape
1. Create object for source type of ChartDataSourceType which represents data source of the chart.
1. If Source Type is equal to external workbook the get chart external data source workbook path.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Charts-DataSourceTypePropertyAdded-DataSourceTypePropertyAdded.cs" >}}


## **External Workbook**
{{% alert color="primary" %}} 

Aspose.Slides for C++ for 19.4 supports external workbooks as a data source for charts.

{{% /alert %}} 

### **Create External Workbook**
This article demonstrates how to create an external workbook from scratch using Aspose.Slides. **ReadWorkbookStream()** and **SetExternalWorkbook()** methods can be used to create an external workbook from scratch or to make an internal workbook external.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CreateExternalWorkbook-CreateExternalWorkbook.cpp" >}}


### **Set External Workbook**
Using Aspose.Slides, an external workbook can be assigned to a chart as a data source. For this purpose **SetExternalWorkbook()** method has been added.

**SetExternalWorkbook()** method can be also used to update a path to the external workbook if it has been moved. Workbooks placed on remote resources unavailable for data editing but still can be assigned as an external data source. If the relative path was provided for an external workbook, it converts to full path automatically.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetExternalWorkbook-SetExternalWorkbook.cpp" >}}



The **SetExternalWorkbook(System::String workbookPath, bool updateChartData)** method has been added with **updateChartData** parameter to the **ChartData** and **IChartData** classes.

The **updateChartData** parameter defines whether an excel workbook will be loaded or not. If the value is ***false*** only the workbook path will be updated. Chart data will not be loaded and updated from the target workbook. This is useful when the target workbook does not yet exist or is not available. If the value is **true** chart data will be updated from the target workbook as the **SetExternalWorkbook(System::String)** method does.


### **Edit Chart Data**
Using Aspose.Slides, Chart data in external workbooks can be edited the same way it works for internal workbooks. If external workbook cannot be loaded an exception is thrown.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-EditChartDatainExternalWorkbook-EditChartDatainExternalWorkbook.cpp" >}}



