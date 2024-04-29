---
title: Working Solution for Worksheet Resizing
type: docs
weight: 20
url: /java/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

It has been observed that Excel Worksheets embedded as OLE in a PowerPoint Presentation through Aspose components are resized to an unidentified scale after first time activation. This behavior creates a considerable visual difference of the presentation between pre and post chart activation states. We have investigated this issue in detail and found the solution to this issue that has been covered in this article.

{{% /alert %}} 
## **Background**
In [Adding Ole Frames article](), we have explained how to add an Ole Frame in presentation in a PowerPoint Presentation using Aspose.Slides for Java. In order to accommodate the [object changed issue](/slides/java/object-changed-issue-when-adding-oleobjectframe/), we assigned the worksheet image of selected area to the Chart OLE Object Frame. In the output presentation, when we double click the OLE Object Frame showing the worksheet Image, the Excel Chart is activated. The end users can make any desired changes in the actual Excel Workbook and then return to the concerned Slide by clicking outside the activated Excel Workbook. The size of the OLE Object Frame will change when the user gets back to the slide. The resizing factor will be different for different sizes of OLE Object Frame and embedded Excel Workbook.
## **Cause of Resizing**
Since the Excel Workbook has its own window size, it tries to retain its original size on first time activation. On the other hand, the OLE Object Frame will have its own size. According to Microsoft, on activation of the Excel Workbook, Excel and PowerPoint negotiate the size and ensure it is in the correct proportions as part of the embedding operation. Based on the differences in the Excel Windows size and OLE Object Frame size / position, the resizing takes place.
## **Working Solution**
There are two possible solutions to avoid the re-sizing effect.* Scale the Ole frame size in PPT to match the size in terms of height/width of desired number of rows/columns in Ole Frame* Keeping the Ole frame size constant and scale the size of participating rows/columns to get fit in selected Ole frame size
## **Scale Ole frame size to Worksheet's selected rows/ columns size**
In this approach, we will learn how to set the Ole frame size of the embedded Excel Workbook equivalent to the cumulative size of number of participating rows and columns in Excel Worksheet.
## **Example**
Suppose, we have defined a template excel sheet and and desire to add that to presentation as Ole frame. In this scenario, the size of the OLE Object Frame will be calculated first based on cumulative rows height and columns widths of participating workbook's rows and columns respectively. Then we will set the size of Ole frame to that calculated value. In order to avoid the red **Embedded Object** message for Ole frame in PowerPoint we will also get the image of desired portions of rows and columns in Workbook and set that as Ole frame image.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}






## **Scale worksheet's row height and column width according to Ole Frame size**
In this approach, we will learn how to scale the heights of participating rows and width of participating column in accordance with custom set ole frame size
## **Example**
Suppose, we have defined a template excel sheet and and desire to add that to presentation as Ole frame. In this scenario, we will set the size of Ole frame and scale the size of rows and columns participating in Ole Frame area. We will then save the workbook in stream to save changes and convert that to byte array for adding it in Ole frame. In order to avoid the red **Embedded Object** message for Ole frame in PowerPoint we will also get the image of desired portions of rows and columns in Workbook and set that as Ole frame image.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **Conclusion**
{{% alert color="primary" %}} 

There are two approaches to fix the worksheet resizing issue. The selection of the appropriate approach depends upon the requirement and the use case. Both approaches work in the same way whether the presentations are created from a template or create from scratch. Also, there is no limit of the OLE Object Frame size in the solution.

{{% /alert %}}
