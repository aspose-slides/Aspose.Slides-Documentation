---
title: 工作表大小调整的工作方案
type: docs
weight: 20
url: /zh/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 预览图像
- 图像大小调整
- Excel
- 工作表
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "在演示文稿中修复 Excel 工作表 OLE 大小调整问题：提供两种方法保持对象框一致——缩放框架或工作表——适用于 PPT 和 PPTX 格式。"
---
{{% alert color="info" title="Note" %}}

使用 Aspose 组件将 Excel 工作表作为 OLE 对象嵌入 PowerPoint 演示文稿后，在首次激活后可能出现意外的大小调整。此行为导致 OLE 对象在激活前后出现明显的视觉差异。本文解释了该问题并描述了解决的两种方法。

{{% /alert %}}

## **Background**

在文章[管理 OLE](/slides/zh/python-java/manage-ole/)中，我们解释了如何使用 Aspose.Slides for Python via Java 向 PowerPoint 演示文稿添加 OLE 框。为了解决[对象预览问题](/slides/zh/python-java/object-preview-issue-when-adding-oleobjectframe/) ，我们将所选工作表区域的图像分配给 OLE 对象框。在输出的演示文稿中，双击显示工作表图像的 OLE 对象框时，Excel 工作簿会被激活。最终用户可以对实际的 Excel 工作簿进行任意更改，然后通过单击激活的 Excel 工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。调整大小的因素取决于 OLE 对象框的尺寸以及嵌入的 Excel 工作簿的大小。

## **Cause of Resizing**

由于 Excel 工作簿拥有自己的窗口大小，它在首次激活时会尝试保持原始尺寸。另一方面，OLE 对象框也有自己的大小。根据 Microsoft 的说法，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。大小调整是基于 Excel 窗口尺寸与 OLE 对象框的尺寸和位置之间的差异而发生的。

## **Working Solution**

有两种可能的解决方案可避免此大小调整效果。

- 将 PowerPoint 演示文稿中的 OLE 框缩放至匹配所选行和列的总体高度和宽度。
- 保持 OLE 框尺寸不变，并将所选行和列缩放以适应其内部。

### **Scale the OLE Frame Size**

此方法将 OLE 框的尺寸设置为匹配嵌入的 Excel 工作表中所选行和列的总体高度和宽度。

示例加载现有的 Excel 工作簿，并使用从零开始的索引选择其第一个工作表的前 10 行和 13 列。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) 定义了显示的范围。预览以 96 DPI 渲染，其像素尺寸使用每英寸 72 点转换为点数。[ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) 将修改后的工作簿嵌入具有这些尺寸的框中。通过 [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 将预览分配为替换已保存演示文稿中“EMBEDDED OLE OBJECT”占位符的图片。

预览助手将 [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) 设置为所选范围，并去除页边距、页眉和页脚。启用 [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) 后，[SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) 将该范围渲染为 PNG 图像。该助手返回包含 PNG 图像的新输入流，并将其定位在开头，以便在演示文稿中使用。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # 设置工作簿作为 PowerPoint 中 OLE 对象使用时的显示尺寸。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # 获取 OLE 图像的宽度和高度（单位为点）。
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # 使用已修改的工作簿。
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # 将 OLE 图像添加到演示文稿资源中。
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # 创建 OLE 对象框。
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **Scale the Cell Range Size**

此方法将所选行的高度和所选列的宽度缩放，以匹配自定义的 OLE 框尺寸。

示例加载现有的 Excel 工作簿，并使用从零开始的索引选择其第一个工作表的前 10 行和 13 列。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) 定义了显示范围，scale_cell_range 助手将该范围缩放以适应宽度为 400 点、高度为 100 点的框。将修改后的工作簿保存到流后，[ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) 按指定大小嵌入其中。通过 [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 将以 96 DPI 渲染的预览分配，使已保存的演示文稿显示所选单元格而非默认占位符。

缩放助手为所选范围计算宽度和高度的独立比例，保持列的相对宽度和行的相对高度。在使用 [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) 和 [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch) 应用之前，将计算得到的尺寸从点转换为英寸。所选范围的宽度和高度必须均非零。

此预览助手使用 [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) 渲染已调整大小的范围。它将 [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) 限定为该范围，去除页边距、页眉和页脚，并返回定位在开头的 PNG 流。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # 单元格范围的预期宽度和高度以点为单位。
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # 在 PowerPoint 中将工作簿用作 OLE 对象时设置显示尺寸。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # 将单元格范围缩放以适应框架尺寸。
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # 使用已修改的工作簿。
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # 将 OLE 图像添加到演示文稿资源中。
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # 创建 OLE 对象框。
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **Conclusion**

{{% alert color="info" title="Note" %}} 

有两种方法可以解决工作表大小调整问题。请选择最符合您需求和使用场景的方法。无论演示文稿是基于模板还是从头创建，两种方法的工作方式相同。此外，在此解决方案中对 OLE 对象框的大小没有限制。

{{% /alert %}}

## **FAQ**

**Why does an embedded Excel worksheet change size when first activated in PowerPoint?**

这是因为 Excel 在激活时尝试保持原始窗口大小，而 PowerPoint 中的 OLE 对象框具有自己的尺寸。PowerPoint 与 Excel 会协商尺寸以保持纵横比，这可能导致大小调整。

**Is it possible to prevent this resizing issue entirely?**

是的。通过将 OLE 框缩放以适应 Excel 单元格范围的尺寸，或将单元格范围缩放以适应所需的 OLE 框尺寸，您可以防止不必要的大小调整。

**Which scaling method should I use, OLE frame scaling or cell range scaling?**

如果您希望保持原始的 Excel 行列尺寸，请选择**OLE 框缩放**。如果您希望在演示文稿中拥有固定大小的 OLE 框，请选择**单元格范围缩放**。

**Will these solutions work if my presentation is based on a template?**

是的。两种解决方案均适用于基于模板创建的演示文稿以及从头创建的演示文稿。

**Is there a limit to the size of the OLE frame when using these methods?**

没有。只要适当设置缩放，OLE 对象框可以设置为任意大小。

**Is there a way to avoid the "EMBEDDED OLE OBJECT" placeholder text in PowerPoint?**

是的。通过对目标 Excel 单元格范围进行快照并将其设置为 OLE 框的占位符图像，您可以在默认占位符位置显示自定义预览图像。

## **Related Articles**

[在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象](/slides/zh/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 加载项自动更新 OLE 对象](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)