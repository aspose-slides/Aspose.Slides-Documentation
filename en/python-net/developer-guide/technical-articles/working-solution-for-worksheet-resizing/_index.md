---
title: Working Solution for Worksheet Resizing
type: docs
weight: 40
url: /python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- preview image
- image resizing
- Excel
- worksheet
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Fix Excel worksheet OLE resizing in presentations: two ways to keep object frames consistent—scale the frame or the sheet—across the PPT and PPTX formats."
---

{{% alert color="info" title="Note" %}}

Excel worksheets embedded as OLE objects in a PowerPoint presentation using Aspose components may resize unexpectedly after their first activation. This behavior creates a noticeable visual difference between the OLE object before and after activation. This article explains the issue and describes two ways to address it.

{{% /alert %}} 

## **Background**

In the article [Manage OLE](/slides/python-net/manage-ole/), we explained how to add an OLE frame to a PowerPoint presentation using Aspose.Slides for Python via .NET. To address the [object preview issue](/slides/python-net/object-preview-issue-when-adding-oleobjectframe/), we assigned an image of the selected worksheet area to the OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the worksheet image, the Excel workbook is activated. End users can make any desired changes to the actual Excel workbook and then return to the slide by clicking outside the activated Excel workbook. The size of the OLE object frame will change when the user returns to the slide. The resizing factor will vary depending on the size of the OLE object frame and the embedded Excel workbook. 

## **Cause of Resizing**

Since the Excel workbook has its own window size, it tries to retain its original size upon first activation. On the other hand, the OLE object frame has its own size. According to Microsoft, when the Excel workbook is activated, Excel and PowerPoint negotiate the size to ensure it maintains the correct proportions as part of the embedding process. The resizing occurs based on the differences between the Excel window size and the OLE object frame's size and position.

## **Working Solution**

There are two possible solutions to avoid the resizing effect.

- Scale the OLE frame in the PowerPoint presentation to match the total height and width of the selected rows and columns.
- Keep the OLE frame size constant and scale the selected rows and columns to fit within it.

### **Scale the OLE Frame Size**

This approach sets the OLE frame size to match the total height and width of the selected rows and columns in the embedded Excel worksheet.

The example loads an existing Excel workbook and selects the first 10 rows and 13 columns of its first worksheet using zero-based indices. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) defines the displayed range. The preview is rendered at 96 DPI, and its pixel dimensions are converted to points using 72 points per inch. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) embeds the modified workbook in a frame with those dimensions. The preview is assigned through [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) to replace the "EMBEDDED OLE OBJECT" placeholder in the saved presentation.

The preview helper sets [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) to the selected range and removes margins, headers, and footers. With [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) enabled, [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) renders the range as a PNG image. The helper rewinds the image stream before returning it for use in the presentation.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

The complete example below combines the helpers with workbook embedding and saves the presentation as `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Get the width and height of the OLE image in points.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # We need to use the modified workbook.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Add the OLE image to the presentation resources.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Create the OLE object frame.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Scale the Cell Range Size**

This approach scales the heights of the selected rows and the widths of the selected columns to match a custom OLE frame size.

The example loads an existing Excel workbook and selects the first 10 rows and 13 columns of its first worksheet using zero-based indices. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) defines the displayed range, and the helper below scales that range to fit a frame 400 points wide and 100 points high. After saving the modified workbook to a stream, [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) embeds it at the specified size. A preview rendered at 96 DPI is assigned through [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), so the saved presentation displays the selected cells instead of the default placeholder.

The scaling helper calculates separate width and height ratios for the selected range, preserving the relative widths of its columns and the relative heights of its rows. It converts the calculated dimensions from points to inches before applying them with [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) and [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). The selected range must have nonzero width and height.

```py
import aspose.cells as cells

# <param name="width">The expected width of the cell range in points.</param>
# <param name="height">The expected height of the cell range in points.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

This preview helper renders the resized range using [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). It limits [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) to that range, removes margins, headers, and footers, and returns a PNG stream positioned at its beginning.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

The complete example below combines the helpers with workbook embedding and saves the presentation as `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">The expected width of the cell range in points.</param>
# <param name="height">The expected height of the cell range in points.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Scale the cell range to fit the frame size.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # We need to use the modified workbook.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Add the OLE image to the presentation resources.
            ole_image = presentation.images.add_image(image_stream)

            # Create the OLE object frame.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Conclusion**

{{% alert color="info" title="Note" %}}

There are two approaches to fix the worksheet resizing issue. Choose the approach that best fits your requirements and use case. Both approaches work the same way, whether the presentations are created from a template or from scratch. Additionally, there is no limit on the size of the OLE object frame in this solution.

{{% /alert %}}

## **FAQ**

**Why does an embedded Excel worksheet change size when first activated in PowerPoint?**

This happens because Excel tries to maintain the original window size when activated, while the OLE object frame in PowerPoint has its own dimensions. PowerPoint and Excel negotiate the size to maintain the aspect ratio, which can cause the resizing.

**Is it possible to prevent this resizing issue entirely?**

Yes. By scaling the OLE frame to fit the Excel cell range size or scaling the cell range to fit the desired OLE frame size, you can prevent unwanted resizing.

**Which scaling method should I use, OLE frame scaling or cell range scaling?**

Select **OLE frame scaling** if you want to maintain the original Excel row and column sizes. Select **cell range scaling** if you want a fixed size for the OLE frame in your presentation.

**Will these solutions work if my presentation is based on a template?**

Yes. Both solutions work for presentations created from templates and from scratch.

**Is there a limit to the size of the OLE frame when using these methods?**

No. You can make the OLE object frame any size as long as you set the scale appropriately.

**Is there a way to avoid the "EMBEDDED OLE OBJECT" placeholder text in PowerPoint?**

Yes. By taking a snapshot of the target Excel cell range and setting it as the OLE frame's placeholder image, you can display a custom preview image in place of the default placeholder.
