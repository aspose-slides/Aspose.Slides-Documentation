---
title: 工作表缩放的可行解决方案
type: docs
weight: 40
url: /zh/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 预览图像
- 图像缩放
- Excel
- 工作表
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "在演示文稿中修复 Excel 工作表 OLE 缩放问题：通过两种方式保持对象框一致——缩放框或工作表——适用于 PPT 和 PPTX 格式。"
---

{{% alert color="primary" %}} 

已经观察到，通过 Aspose 组件将 Excel 工作表作为 OLE 对象嵌入 PowerPoint 演示文稿后，在第一次激活后会被缩放到未知的比例。此行为导致 OLE 对象在激活前后的视觉效果出现显著差异。我们已对该问题进行了深入调查并提供了解决方案，详见本文。

{{% /alert %}} 

## **背景**

在文章 [Manage OLE](/slides/zh/python-net/manage-ole/) 中，我们说明了如何使用 Aspose.Slides for Python via .NET 向 PowerPoint 演示文稿添加 OLE 框。为了解决 [object preview issue](/slides/zh/python-net/object-preview-issue-when-adding-oleobjectframe/)，我们为 OLE 对象框分配了所选工作表区域的图像。在输出的演示文稿中，双击显示工作表图像的 OLE 对象框时，会激活 Excel 工作簿。最终用户可以对实际的 Excel 工作簿进行任意更改，然后点击激活的 Excel 工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。缩放因子取决于 OLE 对象框和嵌入的 Excel 工作簿的大小。

## **缩放原因**

由于 Excel 工作簿拥有自己的窗口大小，它在第一次激活时会尝试保持原始尺寸。另一方面，OLE 对象框也有自己的尺寸。根据 Microsoft 的说法，当 Excel 工作簿被激活时，Excel 和 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。缩放是基于 Excel 窗口尺寸与 OLE 对象框尺寸和位置之间的差异产生的。

## **可行解决方案**

有两种可能的解决方案可以避免缩放效果。

- 在 PowerPoint 演示文稿中缩放 OLE 框尺寸，使其匹配 OLE 框中所需的行数和列数的高度和宽度。
- 保持 OLE 框尺寸不变，缩放参与的行和列的大小，以适应选定的 OLE 框尺寸。

### **缩放 OLE 框尺寸**

在此方法中，我们将学习如何将嵌入的 Excel 工作簿的 OLE 框尺寸设置为与工作表中参与的行和列的累计尺寸相匹配。

假设我们有一个模板 Excel 表，并希望将其作为 OLE 框添加到演示文稿中。在此场景下，OLE 对象框的尺寸首先根据工作簿中参与的行高和列宽的累计值进行计算。然后，我们将把 OLE 框的尺寸设置为该计算值。为避免 PowerPoint 中 OLE 框出现红色 “EMBEDDED OLE OBJECT” 提示，我们还将捕获工作簿中所需行列的图像并将其设为 OLE 框的图像。
```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # 设置工作簿文件在 PowerPoint 中作为 OLE 对象使用时的显示大小。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # 获取 OLE 图像的宽度和高度（单位为点）。
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # 我们需要使用已修改的工作簿。
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


### **缩放单元格范围尺寸**

在此方法中，我们将学习如何缩放参与的行的高度和列的宽度，以匹配自定义的 OLE 框尺寸。

假设我们有一个模板 Excel 表，并希望将其作为 OLE 框添加到演示文稿中。在此场景下，我们将设置 OLE 框的尺寸，并缩放参与 OLE 框区域的行列大小。随后，我们会将工作簿保存到流中以应用更改，并转换为字节数组以添加到 OLE 框。为避免 PowerPoint 中 OLE 框出现红色 “EMBEDDED OLE OBJECT” 提示，我们还将捕获工作簿中所需行列的图像并将其设为 OLE 框的图像。
```py
# <param name="width">单元格范围的预期宽度（单位为点）。</param>
# <param name="height">单元格范围的预期高度（单位为点）。</param>
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

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # 设置工作簿文件在 PowerPoint 中作为 OLE 对象使用时的显示大小。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # 按框的尺寸缩放单元格范围。
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # 我们需要使用已修改的工作簿。
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

{{% alert color="primary" %}}

有两种方法可以修复工作表缩放问题。选择合适的方法取决于具体需求和使用场景。无论演示文稿是从模板创建还是从头开始，两种方法的工作原理相同。此外，此解决方案对 OLE 对象框的大小没有限制。

{{% /alert %}}