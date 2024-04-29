---
title: Create and Embed an Excel Chart as an OLE Object into a Microsoft PowerPoint Slide
type: docs
weight: 60
url: /java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 Charts are visual representations of your data and widely used in presentation slides. This article will show you the code to create and embed an Excel Chart as an OLE Object in the PowerPoint Slide programmatically by using [VSTO](/slides/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) and [Aspose.Slides for PHP via Java](/slides/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Creating and Embedding an Excel Chart**
The two code examples below are long and detailed because the task they're describing is involved. You create a Microsoft Excel workbook, create a chart and then create the Microsoft PowerPoint presentation that you'll embed the chart into. OLE objects contain links to the original document so a user that double-clicks the embedded file will launch the file and it's application.
### **VSTO Example**
Using VSTO, the following steps are performed:

1. Create an instance of the Microsoft Excel ApplicationClass object.
1. Create a new workbook with one sheet in it.
1. Add chart to the sheet.
1. Save the workbook.
1. Open the Excel workbook containing the worksheet with the chart data.
1. Get the ChartObjects collection for the sheet.
1. Get the chart to copy.
1. Create a Microsoft PowerPoint presentation.
1. Add a blank slide to the presentation.
1. Copy the chart from the Excel worksheet to the clipboard.
1. Paste the chart into the PowerPoint presentation.
1. Position the chart on the slide.
1. Save the presentation.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for PHP via Java Example**
Using Aspose.Slides for .NET, the following steps are performed:

1. Create a workbook using Aspose.Cells for Java.
1. Create a Microsoft Excel chart.
1. Set the OLE size of the Excel Chart.
1. Get an image of the chart.
1. Embed the Excel chart as an OLE Object inside PPTX presentation using Aspose.Slides for PHP via Java.
1. Replace the object changed image with the image obtained in step 3 to cater for the object changed issue.
1. Write the output presentation to disk in PPTX format.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}
