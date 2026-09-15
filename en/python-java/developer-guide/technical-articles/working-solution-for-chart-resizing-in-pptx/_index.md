---
title: Working Solution for Chart Resizing in PPTX
type: docs
weight: 40
url: /python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- chart resizing
- Excel chart
- OLE object
- embed chart
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Fix unexpected chart resizing in PPTX when using embedded Excel OLE objects with Aspose.Slides for Python via Java. Learn two methods with code to keep sizes consistent."
---

## **Background**

It has been observed that Excel charts embedded as OLE objects in a PowerPoint presentation through Aspose components are resized to an unspecified scale after their first activation. This behavior causes a noticeable visual difference in the presentation between the pre- and post-activation states of the chart. The Aspose team has investigated the issue in detail and has found a solution. This article describes the causes of the problem and the corresponding fix.

In the [previous article](/slides/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for Python via Java and embed it in a PowerPoint presentation using Aspose.Slides for Python via Java. To address the [object preview issue](/slides/python-java/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. End users can make any desired changes in the underlying Excel workbook and then return to the corresponding slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **Cause of Resizing**

Because the Excel workbook has its own window size, it tries to retain its original size on its first activation. The OLE object frame, however, has its own size. According to Microsoft, when the Excel workbook is activated, Excel and PowerPoint negotiate the size and maintain the correct proportions as part of the embedding process. Depending on the differences between the Excel window size and the OLE object frame’s size or position, resizing occurs.

## **Working Solution**

There are two possible scenarios for creating PowerPoint presentations using Aspose.Slides for Python via Java.

**Scenario 1:** Create a presentation based on an existing template.

**Scenario 2:** Create a presentation from scratch.

The solution we provide here applies to both scenarios. The basis of all solution approaches is the same: **the embedded OLE object’s window size should match the OLE object frame in the PowerPoint slide**. We will now discuss the two approaches to this solution.

## **First Approach**

In this approach, we will learn how to set the window size of the embedded Excel workbook so that it matches the size of the OLE object frame in the PowerPoint slide.

**Scenario 1**

Suppose we have defined a template and want to create presentations based on it. Assume there is a shape at index 2 in the template where we want to place an OLE frame containing an embedded Excel workbook. In this scenario, the size of the OLE object frame is predefined—it matches the size of the shape at index 2 in the template. All we need to do is set the workbook’s window size equal to that shape’s size. The following code snippet serves this purpose:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Load the Excel workbook containing the chart.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Set the workbook window size in inches (PowerPoint uses 72 points per inch).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Save the workbook to a memory stream.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Create an OLE object frame with the embedded Excel data.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**

Let’s say we want to create a presentation from scratch and include an OLE object frame of any size with an embedded Excel workbook. In the following code snippet, we create an OLE object frame 4 inches high and 9.5 inches wide at x = 0.5 inches and y = 1 inch on the slide. We then set the Excel workbook window to the same size—4 inches high and 9.5 inches wide.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Load the Excel workbook containing the chart.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 inches (4 * 72).
    desired_width = 684  # 9.5 inches (9.5 * 72).

    # Define the chart size with a window.
    chart.setSizeWithWindow(True)

    # Set the workbook window size in inches (PowerPoint uses 72 points per inch).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Save the workbook to a memory stream.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Create an OLE object frame with the embedded Excel data.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Second Approach**

In this approach, we will learn how to set the size of the chart in the embedded Excel workbook to match the size of the OLE object frame in the PowerPoint slide. This approach is useful when the chart size is known up front and will never change.

**Scenario 1**

Suppose we have defined a template and want to create presentations based on it. Assume there is a shape at index 2 in the template where we intend to place an OLE frame containing an embedded Excel workbook. In this scenario, the OLE frame size is predefined—matching the size of the shape at index 2 in the template. All we need to do is set the chart size in the workbook to equal the shape’s size. The following code snippet serves this purpose:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Load the Excel workbook containing the chart.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Define the chart size without a window.
    chart.setSizeWithWindow(False)

    # Set the chart size in pixels (Excel uses 96 pixels per inch).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Define the chart print size.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Save the workbook to a memory stream.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Create an OLE object frame with the embedded Excel data.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**:

Suppose we want to create a presentation from scratch and include an OLE object frame of any size with an embedded Excel workbook. In the following code snippet, we create an OLE object frame with a height of 4 inches and a width of 9.5 inches on the slide at x = 0.5 inches and y = 1 inch. We also set the corresponding chart size to the same dimensions: a height of 4 inches and a width of 9.5 inches.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Load the Excel workbook containing the chart.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 inches (4 * 72).
    desired_width = 684  # 9.5 inches (9.5 * 72).

    # Define the chart size without a window.
    chart.setSizeWithWindow(False)

    # Set the chart size in pixels (Excel uses 96 pixels per inch).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Save the workbook to a memory stream.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Create an OLE object frame with the embedded Excel data.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Conclusion**

There are two approaches to fixing the chart-resizing issue. The choice of approach depends on the requirements and the use case. Both approaches work the same way whether the presentations are created from a template or created from scratch. Also, there is no limit to the size of the OLE object frame in this solution.

## **FAQ**

**Why does my embedded Excel chart change size after activating it in PowerPoint?**

This happens because Excel tries to restore the original window size when first activated, whereas the OLE object frame in PowerPoint has its own dimensions. PowerPoint and Excel negotiate the size to maintain aspect ratio, which can cause the resizing.

**Is it possible to prevent this resizing issue entirely?**

Yes. By matching the Excel workbook window size or chart size to the OLE object frame size before embedding, you can keep the chart sizes consistent.

**Which approach should I take, setting the workbook window size or setting the chart size?**

Use **Approach 1 (window size)** if you want to maintain the workbook's aspect ratio and possibly allow resizing later.
Use **Approach 2 (chart size)** if the chart dimensions are fixed and will not change after embedding.

**Will these methods work with both template-based presentations and new presentations?**

Yes. Both approaches work the same for presentations created from templates and from scratch.

**Is there a limit to the size of the OLE object frame?**

No. You can set the OLE frame to any size as long as it scales appropriately to the workbook or chart size.

**Can I use these methods with charts created in other spreadsheet programs?**

The examples are designed for Excel charts created with Aspose.Cells, but the principles apply to other OLE-compatible spreadsheet programs as long as they support similar sizing options.

## **Related Sections**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
