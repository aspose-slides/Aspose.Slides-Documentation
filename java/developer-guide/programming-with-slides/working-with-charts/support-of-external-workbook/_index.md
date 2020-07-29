---
title: Support of External Workbook
type: docs
weight: 40
url: /java/support-of-external-workbook/
---

{{% alert color="primary" %}} 

Aspose.Slides for Java for 19.4 supports external workbooks as a data source for charts.

{{% /alert %}} 
## **Create External Workbook**
This article demonstrates how to create an external workbook from scratch using Aspose.Slides for Java. **IChartData.readWorkbookStream()** and **IChartData.setExternalWorkbook()** methods can be used to create an external workbook from scratch or to make an internal workbook external.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateExternalWorkbook-CreateExternalWorkbook.java" >}}


## **Set External Workbook**
Using Aspose.Slides for Java, an external workbook can be assigned to a chart as a data source. For this purpose **IChartData.setExternalWorkbook** method has been added.

**setExternalWorkbook()** method can be also used to update a path to the external workbook if it has been moved. Workbooks placed on remote resources unavailable for data editing but still can be assigned as an external data source. If the relative path was provided for an external workbook, it converts to full path automatically.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SetExternalWorkbook-SetExternalWorkbook.java" >}}

The **setExternalWorkbook(String *workbookPath*, boolean *updateChartData*)** method has been added with **updateChartData** parameter.

The **updateChartData** parameter defines whether an excel workbook will be loaded or not. If the value is ***false*** only the workbook path will be updated. Chart data will not be loaded and updated from the target workbook. This is useful when the target workbook does not yet exist or is not available. If the value is **true** chart data will be updated from the target workbook as the **setExternalWorkbook(System::String)** method does.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SetExternalWorkbookWithUpdateChartData-SetExternalWorkbookWithUpdateChartData.java" >}}
## **Edit Chart Data**
Using Aspose.Slides for Java, Chart data in external workbooks can be edited the same way it works for internal workbooks. If external workbook cannot be loaded an exception is thrown.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EditChartDatainExternalWorkbook-EditChartDatainExternalWorkbook.java" >}}




