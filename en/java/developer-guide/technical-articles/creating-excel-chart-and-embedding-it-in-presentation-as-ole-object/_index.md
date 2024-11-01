---
title: Creating Excel Chart and Embedding it in Presentation as OLE Object
type: docs
weight: 30
url: /java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

In PowerPoint Slides, the use of editable chats for graphical display of the data is a common activity. Aspose provides the support of creating the Excel Charts with the use of Aspose.Cells for Java and further these charts can be embedded as an OLE Object in the PowerPoint Slide through Aspose.Slides for Java. This article covers the required steps along with the implementation in Java to create and embed an MS Excel Chart as an OLE Object in PowerPoint presentation by using Aspose.Cells for Java and Aspose.Slides for Java.

{{% /alert %}} 
## **Required Steps**
Following sequence of steps is required to create and embed an Excel Chart as an OLE Object in the PowerPoint Slide:# Create an Excel Chart using Aspose.Cells for Java.# Set the OLE size of the Excel Chart. using Aspose.Cells for Java.# Get the image of the Excel Chart with Aspose.Cells for Java.# Embed the Excel Chart as an OLE Object inside PPTX presentation using Aspose.Slides for Java.# Replace the object changed image with the image obtained in step 3 to cater Object Changed Issue# Save the output presentation to disk in PPTX format
## **Implementation of the Required Steps**
The implementation of the above steps in Java is as under:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}

{{% alert color="primary" %}} 

The presentation created through above method, will carry the Excel chart as OLE Object that can be activated by double clicking the OLE Object Frame.

{{% /alert %}} 
## **Conclusion**
{{% alert color="primary" %}} 

By using Aspose.Cells for Java along with Aspose.Slides for Java, we can create any of the Excel Charts as supported by Aspose.Cells for Java and embed the created chart as an OLE Object in a PowerPoint Slide. The OLE Size of the Excel Chart can also be defined. The end users can further edit the Excel Chart like any other OLE Object.

{{% /alert %}} 
## **Related Sections**
[Working Solution for Chart Resizing](/slides/java/working-solution-for-chart-resizing-in-pptx/)

[Object Changed Issue](/slides/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
