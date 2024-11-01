---
title: Working Solution for Chart Resizing in PPTX
type: docs
weight: 40
url: /java/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

It has been observed that Excel Charts embedded as OLE in a PowerPoint Presentation through Aspose components are resized to an unidentified scale after first time activation. This behavior creates a considerable visual difference of the presentation between pre and post chart activation states. Aspose team with the help of Microsoft team has investigated this issue in detail and found the solution to this issue. This article covers the reasons and the solution to this issue.

{{% /alert %}} 
## **Background**
In [previous article](/slides/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) , we have explained how to create an Excel Chart using Aspose.Cells for Java and further embed this chart in a PowerPoint Presentation using Aspose.Slides for Java. In order to accommodate the [object changed issue](/slides/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/) , we assigned the chart image to the Chart OLE Object Frame. In the output presentation, when we double click the OLE Object Frame showing the Chart Image, the Excel Chart is activated. The end users can make any desired changes in the actual Excel Workbook and then return to the concerned Slide by clicking outside the activated Excel Workbook. The size of the OLE Object Frame will change when the user gets back to the slide. The resizing factor will be different for different sizes of OLE Object Frame and embedded Excel Workbook.
## **Cause of Resizing**
Since the Excel Workbook has its own window size, it tries to retain its original size on first time activation. On the other hand, the OLE Object Frame will have its own size. According to Microsoft, on activation of the Excel Workbook, Excel and PowerPoint negotiate the size and ensure it is in the correct proportions as part of the embedding operation. Based on the differences in the Excel Windows size and OLE Object Frame size / position, the resizing takes place.
## **Working Solution**
There are two possible scenarios for creation of the PowerPoint Presentations using Aspose.Slides for Java.**Scenario 1:** Create the presentation based on an existing template**Scenario 2:** Create the presentation from scratch.The solution that we will provide here will be valid for both scenarios. The base of all the solution approaches will be same. That is: **Embedded OLE Object Window size should be the same as that of the OLE Object Frame** **in the PowerPoint Slide** . Now, we will discuss the two approaches of the solution.
## **First Approach**
In this approach, we will learn how to set the window size of the embedded Excel Workbook equivalent to the size of the OLE Object Frame in the PowerPoint Slide.**Scenario 1**Suppose, we have defined a template and desire to create the presentations based on this template. Let us say there is some shape at index 2 in the template where we want to place an OLE Frame carrying an embedded Excel Workbook. In this scenario, the size of the OLE Object Frame will be considered as predefined (which is the size of the shape at index 2 in the template). All we have to do: set the window size of the Workbook equal to the size of the Shape. The following code snippet will serve this purpose:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}





**Scenario 2
**Let us say, we want to create a presentation from scratch and desire an OLE Object Frame of any size with an embedded Excel Workbook. In the following code snippet, we have created an OLE Object Frame with 4 inch height and 9.5 inch width in the slide at x-axis=0.5 inch and y-axis=1 inch. Further, we have set the equivalent Excel Workbook window size, that is: height 4 inch and width 9.5 inch.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}


## **Second Approach**
In this approach, we will learn how to set the chart size present in the embedded Excel Workbook equivalent to the size of the OLE Object Frame in the PowerPoint Slide. This approach is useful when the size of the chart up-front is known and will never change.**Scenario 1**Suppose, we have defined a template and desire to create the presentations based on this template. Let us say there is some shape at index 2 in the template where we want to place an OLE Frame carrying an embedded Excel Workbook. In this scenario, the size of the OLE Frame will be considered as predefined (which is the size of the shape at index 2 in the template). All we have to do: set the size of the chart in the Workbook equal to the size of the shape. The following code snippet will serve this purpose:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**Scenario 2**: Let us say, we want to create a presentation from scratch and desire an OLE Object Frame of any size with an embedded Excel Workbook. In the following code snippet, we have created an OLE Object Frame with 4 inch height and 9.5 inch width in the slide at x-axis=0.5 inch and y-axis=1 inch. Further, we have set the equivalent Chart size, that is: height 4 inch and width 9.5 inch.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **Conclusion**
{{% alert color="primary" %}} 

There are two approaches to fix the chart resizing issue. The selection of the appropriate approach depends upon the requirement and the use case. Both approaches work in the same way whether the presentations are created from a template or create from scratch. Also, there is no limit of the OLE Object Frame size in the solution.

{{% /alert %}}
