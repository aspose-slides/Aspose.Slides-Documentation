---
title: 工作表尺寸调整的可行解决方案
type: docs
weight: 20
url: /zh/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 预览图像
- 图像调整大小
- Excel
- 工作表
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "修复演示文稿中 Excel 工作表 OLE 尺寸调整问题：提供两种保持对象框一致的方法——缩放框架或工作表——适用于 PPT 和 PPTX 格式。"
---
{{% alert color="info" title="Note" %}}

已观察到，通过 Aspose 组件在 PowerPoint 演示文稿中嵌入为 OLE 对象的 Excel 工作表，在首次激活后会被调整到未指定的比例。此行为导致 OLE 对象在激活前后呈现出明显的视觉差异。我们已对该问题进行了深入调查并提供了解决方案，详见本文。

{{% /alert %}}

## **背景**

在文章 [管理 OLE](/slides/zh/python-java/manage-ole/) 中，我们说明了如何使用 Aspose.Slides for Python via Java 向 PowerPoint 演示文稿添加 OLE 框。为了解决 [对象预览问题](/slides/zh/python-java/object-preview-issue-when-adding-oleobjectframe/)，我们将所选工作表区域的图像分配给 OLE 对象框。输出的演示文稿中，双击显示工作表图像的 OLE 对象框时，会激活 Excel 工作簿。最终用户可以对实际的 Excel 工作簿进行任意修改，然后通过单击激活的 Excel 工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化，调整比例取决于 OLE 对象框和嵌入的 Excel 工作簿的大小。

## **调整大小的原因**

由于 Excel 工作簿有其自身的窗口大小，首次激活时它会尝试保持原始大小。另一方面，OLE 对象框也有自己的尺寸。根据 Microsoft 的说明，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。尺寸调整基于 Excel 窗口大小与 OLE 对象框的大小和位置之间的差异。

## **可行的解决方案**

有两种可能的解决方案可避免尺寸调整效果。

- 在 PowerPoint 演示文稿中将 OLE 框的尺寸缩放到与所需行列数的高度和宽度匹配。
- 保持 OLE 框尺寸不变，缩放参与的行和列的大小，使其适应所选的 OLE 框尺寸。

### **缩放 OLE 框大小**

在此方法中，我们将学习如何将嵌入的 Excel 工作簿的 OLE 框大小设置为与工作表中参与的行和列的累计大小匹配。

假设我们有一个模板 Excel 表，需要将其作为 OLE 框添加到演示文稿中。在此场景下，OLE 对象框的大小首先依据工作簿中参与的行高和列宽的累计值进行计算。然后，我们将 OLE 框的大小设置为该计算值。为了避免 PowerPoint 中 OLE 框出现红色 “EMBEDDED OLE OBJECT” 提示，我们还会捕获工作簿中所需行列的图像，并将其设为 OLE 框的占位图像。

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

    # 设置工作簿在 PowerPoint 中作为 OLE 对象使用时的显示大小。
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

### **缩放单元格范围大小**

在此方法中，我们将学习如何将参与的行高和列宽缩放到自定义的 OLE 框大小。

同样假设我们有一个模板 Excel 表，需要将其作为 OLE 框添加到演示文稿中。此时，我们先设置 OLE 框的尺寸，然后将参与 OLE 框区域的行和列的大小进行缩放，以匹配该尺寸。随后我们将工作簿保存到流中以应用更改，并将其转换为字节数组以供添加到 OLE 框。为了避免 PowerPoint 中 OLE 框出现红色 “EMBEDDED OLE OBJECT” 提示，我们同样会捕获工作簿中所需行列的图像，并将其设为 OLE 框的占位图像。

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

    # 设置工作簿在 PowerPoint 中作为 OLE 对象使用时的显示大小。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # 将单元格范围缩放以适应框架大小。
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

## **结论**

{{% alert color="info" title="Note" %}} 

解决工作表尺寸调整问题有两种方法。具体选择哪种方法取决于实际需求和使用场景。无论演示文稿是基于模板创建还是从空白开始，两种方法的工作方式相同。此外，此方案对 OLE 对象框的大小没有限制。

{{% /alert %}}

## **常见问答**

**为什么嵌入的 Excel 工作表在 PowerPoint 中首次激活时会改变大小？**

这是因为 Excel 在激活时会尝试保持原始窗口大小，而 PowerPoint 中的 OLE 对象框拥有自己的尺寸。PowerPoint 和 Excel 会协商尺寸以保持纵横比，导致尺寸调整。

**是否可以完全防止此尺寸调整问题？**

可以。通过将 OLE 框缩放到匹配 Excel 单元格范围的大小，或将单元格范围缩放到所需的 OLE 框大小，均可避免不必要的尺寸调整。

**应该使用哪种缩放方式：OLE 框缩放还是单元格范围缩放？**

如果希望保持原始的 Excel 行列尺寸，请选择 **OLE 框缩放**。如果希望在演示文稿中拥有固定的 OLE 框尺寸，请选择 **单元格范围缩放**。

**这些解决方案在基于模板的演示文稿中也有效吗？**

有效。两种解决方案均适用于基于模板创建的演示文稿以及从头创建的演示文稿。

**使用这些方法时 OLE 框的大小有限制吗？**

没有限制。只要相应地设置比例，OLE 对象框可以任意大小。

**是否有办法避免 PowerPoint 中的 “EMBEDDED OLE OBJECT” 占位文本？**

可以。通过对目标 Excel 单元格范围进行快照并将其设置为 OLE 框的占位图像，您可以显示自定义预览图像，以取代默认的占位文本。

## **相关文章**

[在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象](/slides/zh/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)