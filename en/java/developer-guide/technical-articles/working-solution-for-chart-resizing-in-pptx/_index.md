---
title: Working Solution for Chart Resizing in PPTX
type: docs
weight: 40
url: /java/working-solution-for-chart-resizing-in-pptx/
keywords:
- chart resizing
- Excel chart
- OLE object
- embed chart
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Fix unexpected chart resizing in PPTX when using embedded Excel OLE objects with Aspose.Slides for Java. Learn two methods with code to keep sizes consistent."
---

## **Background**

It has been observed that Excel charts embedded as OLE objects in a PowerPoint presentation through Aspose components are resized to an unspecified scale after their first activation. This behavior causes a noticeable visual difference in the presentation between the pre- and post-activation states of the chart. The Aspose team has investigated the issue in detail and has found a solution. This article describes the causes of the problem and the corresponding fix.

In the [previous article](/slides/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for Java and embed it in a PowerPoint presentation using Aspose.Slides for Java. To address the [object preview issue](/slides/java/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. End users can make any desired changes in the underlying Excel workbook and then return to the corresponding slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **Cause of Resizing**

Because the Excel workbook has its own window size, it tries to retain its original size on its first activation. The OLE object frame, however, has its own size. According to Microsoft, when the Excel workbook is activated, Excel and PowerPoint negotiate the size and maintain the correct proportions as part of the embedding process. Depending on the differences between the Excel window size and the OLE object frame’s size or position, resizing occurs.

## **Working Solution**

There are two possible scenarios for creating PowerPoint presentations using Aspose.Slides for Java.

**Scenario 1:** Create a presentation based on an existing template.

**Scenario 2:** Create a presentation from scratch.

The solution we provide here applies to both scenarios. The basis of all solution approaches is the same: **the embedded OLE object’s window size should match the OLE object frame in the PowerPoint slide**. We will now discuss the two approaches to this solution.

## **First Approach**

In this approach, we will learn how to set the window size of the embedded Excel workbook so that it matches the size of the OLE object frame in the PowerPoint slide.

**Scenario 1**

Suppose we have defined a template and want to create presentations based on it. Assume there is a shape at index 2 in the template where we want to place an OLE frame containing an embedded Excel workbook. In this scenario, the size of the OLE object frame is predefined—it matches the size of the shape at index 2 in the template. All we need to do is set the workbook’s window size equal to that shape’s size. The following code snippet serves this purpose:

```java
// Set the window width of the workbook in inches (divided by 576 as PowerPoint uses 576 pixels per inch).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Set the window height of the workbook in inches.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Save the workbook to a memory stream.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Create an OLE object frame with the embedded Excel data.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**

Let’s say we want to create a presentation from scratch and include an OLE object frame of any size with an embedded Excel workbook. In the following code snippet, we create an OLE object frame 4 inches high and 9.5 inches wide at x = 0.5 inches and y = 1 inch on the slide. We then set the Excel workbook window to the same size—4 inches high and 9.5 inches wide.

```java
// Our desired height.
int desiredHeight = 288; // 4 inch (4 * 72)
 
// Our desired width.
int desiredWidth = 684; // 9.5 inch (9.5 * 72)
 
// Define the chart size with a window.
chart.setSizeWithWindow(true);
 
// Set the window width of the workbook in inches (divided by 576 as PowerPoint uses 576 pixels per inch).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Set the window height of the workbook in inches.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Save the workbook to a memory stream.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Create an OLE object frame with the embedded Excel data.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Second Approach**

In this approach, we will learn how to set the size of the chart in the embedded Excel workbook to match the size of the OLE object frame in the PowerPoint slide. This approach is useful when the chart size is known up front and will never change.

**Scenario 1**

Suppose we have defined a template and want to create presentations based on it. Assume there is a shape at index 2 in the template where we intend to place an OLE frame containing an embedded Excel workbook. In this scenario, the OLE frame size is predefined—matching the size of the shape at index 2 in the template. All we need to do is set the chart size in the workbook to equal the shape’s size. The following code snippet serves this purpose:

```java
// Define the chart size without a window.
chart.setSizeWithWindow(false);
 
// Set the chart width in pixels (multiply by 96 as Excel uses 96 pixels per inch).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Set the chart height in pixels.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Define the chart print size.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Save the workbook to a memory stream.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Create an OLE object frame with the embedded Excel data.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**:

Suppose we want to create a presentation from scratch and include an OLE object frame of any size with an embedded Excel workbook. In the following code snippet, we create an OLE object frame with a height of 4 inches and a width of 9.5 inches on the slide at x = 0.5 inches and y = 1 inch. We also set the corresponding chart size to the same dimensions: a height of 4 inches and a width of 9.5 inches.

```java
// Our desired height.
int desiredHeight = 288; // 4 inch (4 * 72)
 
// Our desired width.
int desiredWidth = 684; // 9.5 inch (9.5 * 72)
 
// Define the chart size without a window.
chart.setSizeWithWindow(false);
 
// Set the chart width in pixels (multiply by 96 as Excel uses 96 pixels per inch).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Set the chart height in pixels.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Save the workbook to a memory stream.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Create an OLE object frame with the embedded Excel data.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Conclusion**

There are two approaches to fixing the chart-resizing issue. The choice of approach depends on the requirements and the use case. Both approaches work the same way whether the presentations are created from a template or created from scratch. Also, there is no limit to the size of the OLE object frame in this solution.

## **Related Sections**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
