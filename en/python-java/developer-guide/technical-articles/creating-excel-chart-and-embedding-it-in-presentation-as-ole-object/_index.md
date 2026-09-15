---
title: Create Excel Charts and Embed Them in Presentations as OLE Objects
type: docs
weight: 30
url: /python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel chart
- embed chart
- OLE object
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Create Excel charts and embed them as OLE objects in PowerPoint and OpenDocument presentations with Python. Step-by-step guide with code samples."
---

## **Background**

In PowerPoint, using editable charts to display data graphically is a common practice. Aspose supports creating Excel charts with Aspose.Cells for Python via Java, and these charts can then be embedded as OLE objects in PowerPoint slides through Aspose.Slides for Python via Java. This article covers the necessary steps and provides a Python code sample for creating an Excel chart and embedding it as an OLE object in a PowerPoint presentation using Aspose.Cells and Aspose.Slides.

## **Required Steps**

The following sequence of steps is required to create and embed an Excel chart as an OLE object in a PowerPoint slide:

1. Create an Excel chart using Aspose.Cells.
1. Set the OLE size of the Excel chart using Aspose.Cells.
1. Get an image of the Excel chart with Aspose.Cells.
1. Embed the Excel chart as an OLE object in a PPTX presentation using Aspose.Slides.
1. Replace the "EMBEDDED OLE OBJECT" image with the image obtained in step 3 to address the [object preview issue](/slides/python-java/object-preview-issue-when-adding-oleobjectframe/).
1. Save the presentation to disk in PPTX format.

## **Implementation of the Required Steps**

The Python implementation of the above steps is as follows:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # An array of cell names.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # An array of cell data.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Add a new worksheet to populate cells with data.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Populate the data sheet with data.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Add a chart sheet.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Add a chart to the chart sheet with data series from the data sheet.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Set the chart sheet as the active sheet.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Describe the workbook as embedded OLE data.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Create a workbook.
workbook = Workbook()

# Add an Excel chart.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Set the OLE size of the chart.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Get the chart image and save it to a stream.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Save the workbook to a stream.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Create a presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Add the workbook to a slide.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Save the presentation to disk.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The presentation created by the above method will contain the Excel chart as an OLE object that can be activated by double-clicking the OLE object frame.

## **Conclusion**

By using Aspose.Cells for Python via Java together with Aspose.Slides for Python via Java, we can create any Excel chart supported by Aspose.Cells and embed the chart as an OLE object in a PowerPoint slide. The OLE size of the Excel chart can also be defined. End users can then edit the Excel chart like any other OLE object.

## **Related Sections**

- [Working Solution for Chart Resizing in PPTX](/slides/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **FAQ**

**Which libraries are used to create and embed the Excel chart?**

Aspose.Cells for Python via Java creates the Excel chart, and Aspose.Slides for Python via Java embeds it as an OLE object in a PowerPoint slide.

**How can users edit the embedded Excel chart?**

Users can double-click the OLE object frame to activate the chart and edit it like any other OLE object.

**How is the default OLE object preview replaced?**

The example obtains an image of the Excel chart with Aspose.Cells and uses it to replace the "EMBEDDED OLE OBJECT" image.
