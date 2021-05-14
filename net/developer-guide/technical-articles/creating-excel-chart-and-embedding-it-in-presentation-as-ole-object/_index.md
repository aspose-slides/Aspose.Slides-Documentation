---
title: Creating Excel Chart and Embedding it in Presentation as OLE Object
type: docs
weight: 50
url: /net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

In PowerPoint Slides, the use of editable chats for graphical display of the data is a common activity. Aspose provides the support of creating the Excel Charts with the use of Aspose.Cells for .NET and further these charts can be embedded as an OLE Object in the PowerPoint Slide through Aspose.Slides for .NET. This article covers the required steps along with the implementation in C# and VB.NET to create and embed an MS Excel Chart as an OLE Object in PowerPoint presentation by using Aspose.Cells for .NET and Aspose.Slides for .NET.

{{% /alert %}} 
## **Required Steps**
Following sequence of steps is required to create and embed an Excel Chart as an OLE Object in the PowerPoint Slide:

1. Create an Excel Chart using Aspose.Cells for .NET.# Set the OLE size of the Excel Chart. using Aspose.Cells for .NET.# Get the image of the Excel Chart with Aspose.Cells for .NET.# Embed the Excel Chart as an OLE Object inside PPTX presentation using Aspose.Slides for .NET.# Replace the object changed image with the image obtained in step 3 to cater Object Changed Issue# Write the output presentation to disk in PPTX format
## **Implementation of the Required Steps**
The implementation of the above steps in C# and Visual Basic is as under:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.cs" >}}





{{% alert color="primary" %}} 

The presentation created through above method, will carry the Excel chart as OLE Object that can be activated by double clicking the OLE Object Frame.

{{% /alert %}} 
## **Conclusion**
{{% alert color="primary" %}} 

By using Aspose.Cells for .NET along with Aspose.Slides for .NET, we can create any of the Excel Charts as supported by Aspose.Cells for .NET and embed the created chart as an OLE Object in a PowerPoint Slide. The OLE Size of the Excel Chart can also be defined. The end users can further edit the Excel Chart like any other OLE Object.

{{% /alert %}} 
## **Related Sections**
[Working Solution for Chart Resizing](/slides/net/working-solution-for-chart-resizing-in-pptx/)[Object Changed Issue](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
