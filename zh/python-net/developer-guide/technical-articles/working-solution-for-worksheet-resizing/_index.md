---
title: 工作表调整大小的可行解决方案
type: docs
weight: 40
url: /zh/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 预览图像
- 图像大小调整
- Excel
- 工作表
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "修复演示文稿中 Excel 工作表 OLE 调整大小的问题：提供两种方法保持对象框一致——缩放框架或工作表——适用于 PPT 和 PPTX 格式。"
---
{{% alert color="info" title="Note" %}}

使用 Aspose 组件将 Excel 工作表作为 OLE 对象嵌入 PowerPoint 演示文稿后，在首次激活后可能会意外调整大小。此行为导致 OLE 对象在激活前后的视觉差异明显。本文解释了此问题并描述了解决的两种方法。

{{% /alert %}} 

## **背景**

在文章[管理 OLE](/slides/zh/python-net/manage-ole/)中，我们解释了如何使用 Aspose.Slides for Python via .NET 向 PowerPoint 演示文稿添加 OLE 框。为了解决[对象预览问题](/slides/zh/python-net/object-preview-issue-when-adding-oleobjectframe/)，我们为 OLE 对象框分配了所选工作表区域的图像。在输出的演示文稿中，双击显示工作表图像的 OLE 对象框时，Excel 工作簿会被激活。最终用户可以对实际的 Excel 工作簿进行任意更改，然后通过单击激活的 Excel 工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。调整大小的因素取决于 OLE 对象框的大小和嵌入的 Excel 工作簿的大小。

## **调整大小的原因**

由于 Excel 工作簿有自己的窗口大小，它在首次激活时会尝试保持原始大小。另一方面，OLE 对象框有自己的尺寸。根据 Microsoft 的说法，当 Excel 工作簿被激活时，Excel 和 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。调整大小基于 Excel 窗口尺寸与 OLE 对象框的尺寸和位置之间的差异而产生。

## **工作解决方案**

有两种可能的解决方案可避免调整大小的效果。

- 将 PowerPoint 演示文稿中的 OLE 框缩放，以匹配所选行列的总高度和宽度。  
- 保持 OLE 框尺寸不变，并将所选行列缩放以适应其内部。

### **缩放 OLE 框大小**

此方法将 OLE 框尺寸设置为匹配嵌入的 Excel 工作表中所选行列的总高度和宽度。

示例加载现有 Excel 工作簿，并使用从零开始的索引选择其第一个工作表的前 10 行和 13 列。[WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) 定义要显示的范围。预览以 96 DPI 渲染，其像素尺寸使用每英寸 72 点转换为点。[ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) 将修改后的工作簿嵌入具有这些尺寸的框中。预览通过 [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) 分配，以替换已保存演示文稿中的 "EMBEDDED OLE OBJECT" 占位符。

预览帮助程序将 [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) 设置为所选范围，并移除页边距、页眉和页脚。启用 [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) 后，[SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) 将范围渲染为 PNG 图像。帮助程序在返回用于演示文稿之前会倒回图像流。

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

下面的完整示例将帮助程序与工作簿嵌入结合，并将演示文稿保存为 `output.pptx`。

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

    # 设置工作簿文件在 PowerPoint 中作为 OLE 对象使用时的显示尺寸。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # 获取 OLE 图像的宽度和高度（单位：点）。
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # 我们需要使用修改后的工作簿。
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # 将 OLE 图像添加到演示文稿资源中。
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # 创建 OLE 对象框。
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **缩放单元格范围大小**

此方法缩放所选行的高度和所选列的宽度，以匹配自定义 OLE 框尺寸。

示例加载现有 Excel 工作簿，并使用从零开始的索引选择其第一个工作表的前 10 行和 13 列。[WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) 定义要显示的范围，下面的帮助程序将该范围缩放以适应宽度为 400 点、高度为 100 点的框。将修改后的工作簿保存到流后，[ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) 按指定尺寸嵌入其中。以 96 DPI 渲染的预览通过 [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) 分配，使已保存的演示文稿显示所选单元格而非默认占位符。

缩放帮助程序为所选范围计算单独的宽度比和高度比，保留其列的相对宽度和行的相对高度。它在使用 [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) 和 [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/) 之前，将计算出的尺寸从点转换为英寸。所选范围的宽度和高度必须为非零。

```py
import aspose.cells as cells

# <param name="width">预期的单元格范围宽度（单位：点）。</param>
# <param name="height">预期的单元格范围高度（单位：点）。</param>
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

此预览帮助程序使用 [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) 渲染已调整大小的范围。它将 [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) 限制为该范围，移除页边距、页眉和页脚，并返回定位在起始位置的 PNG 流。

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

下面的完整示例将帮助程序与工作簿嵌入结合，并将演示文稿保存为 `output.pptx`。

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">预期的单元格范围宽度（单位：点）。</param>
# <param name="height">预期的单元格范围高度（单位：点）。</param>
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

    # 设置工作簿文件在 PowerPoint 中作为 OLE 对象使用时的显示尺寸。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # 将单元格范围缩放以适应框架尺寸。
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # 我们需要使用修改后的工作簿。
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # 将 OLE 图像添加到演示文稿资源中。
            ole_image = presentation.images.add_image(image_stream)

            # 创建 OLE 对象框。
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **结论**

{{% alert color="info" title="Note" %}}

有两种方法可解决工作表调整大小问题。请选择最符合您需求和使用场景的方法。两种方法的工作方式相同，无论演示文稿是基于模板创建还是从零开始创建。此外，此方案对 OLE 对象框的大小没有限制。

{{% /alert %}}

## **常见问题**

**为什么嵌入的 Excel 工作表在 PowerPoint 中首次激活时会改变大小？**

由于 Excel 在激活时尝试保持原始窗口尺寸，而 PowerPoint 中的 OLE 对象框拥有自己的尺寸。PowerPoint 与 Excel 会协商尺寸以保持纵横比，这可能导致调整大小。

**是否可以完全防止此调整大小问题？**

可以。通过将 OLE 框缩放以适应 Excel 单元格范围的尺寸，或将单元格范围缩放以适应所需的 OLE 框尺寸，均可防止不必要的调整。

**我应该使用哪种缩放方法，OLE 框缩放还是单元格范围缩放？**

如果希望保持 Excel 原始行列尺寸，请选择 **OLE 框缩放**。如果希望演示文稿中的 OLE 框保持固定尺寸，请选择 **单元格范围缩放**。

**如果我的演示文稿基于模板，这些解决方案是否有效？**

有效。两种解决方案均适用于基于模板创建的演示文稿和从头创建的演示文稿。

**使用这些方法时 OLE 框的大小是否有限制？**

没有。只要适当设置比例，OLE 对象框可以任意大小。

**是否有办法避免 PowerPoint 中的 "EMBEDDED OLE OBJECT" 占位符文本？**

可以。通过对目标 Excel 单元格范围进行快照并将其设置为 OLE 框的占位符图像，您可以在默认占位符位置显示自定义预览图像。