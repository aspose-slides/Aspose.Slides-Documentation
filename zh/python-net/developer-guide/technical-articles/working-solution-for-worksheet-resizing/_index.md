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
description: "修复演示文稿中 Excel 工作表 OLE 缩放问题：通过两种方式保持对象框一致——缩放框架或工作表——适用于 PPT 和 PPTX 格式。"
---

{{% alert color="primary" %}} 

已观察到，使用 Aspose 组件将 Excel 工作表作为 OLE 对象嵌入 PowerPoint 演示文稿后，在第一次激活后会被重新缩放到未知比例。此行为导致演示文稿中 OLE 对象的激活前后出现明显的视觉差异。我们已对该问题进行深入调查并提供了解决方案，详见本文。

{{% /alert %}} 

## **背景**

在文章[Manage OLE](/slides/zh/python-net/manage-ole/)中，我们说明了如何使用 Aspose.Slides for Python via .NET 将 OLE 框添加到 PowerPoint 演示文稿。为了解决[对象预览问题](/slides/zh/python-net/object-preview-issue-when-adding-oleobjectframe/)，我们为 OLE 对象框分配了所选工作表区域的图像。在输出的演示文稿中，双击显示工作表图像的 OLE 对象框时，会激活 Excel 工作簿。最终用户可以对实际的 Excel 工作簿进行任意更改，然后通过单击激活的 Excel 工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。缩放因子取决于 OLE 对象框和嵌入的 Excel 工作簿的大小。

## **缩放原因**

由于 Excel 工作簿有其自身的窗口大小，它会尝试在首次激活时保持原始尺寸。另一方面，OLE 对象框也有其自身的尺寸。根据 Microsoft 的说明，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。缩放基于 Excel 窗口尺寸与 OLE 对象框尺寸和位置之间的差异而发生。

## **可行解决方案**

有两种可能的解决方案可以避免缩放效果。

- 将 PowerPoint 演示文稿中的 OLE 框尺寸缩放至与 OLE 框中所需行列数的高度和宽度匹配。
- 保持 OLE 框尺寸不变，缩放参与的行和列的尺寸，使其适配选定的 OLE 框尺寸。

### **缩放 OLE 框尺寸**

在此方法中，我们将学习如何将嵌入的 Excel 工作簿的 OLE 框尺寸设置为与 Excel 工作表中参与行列的累加尺寸相匹配。

假设我们有一个模板 Excel 工作表，并希望将其作为 OLE 框添加到演示文稿中。在此场景下，OLE 对象框的尺寸首先根据工作簿中参与行列的累计行高和列宽计算得出。随后，我们将 OLE 框的尺寸设置为该计算值。为避免 PowerPoint 中 OLE 框出现红色“EMBEDDED OLE OBJECT”提示，我们还会捕获工作簿中所需行列部分的图像，并将其设为 OLE 框的图像。
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

    # 设置工作簿文件作为 PowerPoint 中 OLE 对象时的显示尺寸。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # 获取 OLE 图像的宽度和高度（单位：点）。
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

            # 创建 OLE 对象框架。
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **缩放单元格范围尺寸**

在此方法中，我们将学习如何缩放参与行的高度和参与列的宽度，以匹配自定义的 OLE 框尺寸。

假设我们有一个模板 Excel 工作表，并希望将其作为 OLE 框添加到演示文稿中。在此场景下，我们将设置 OLE 框的尺寸，并缩放位于 OLE 框区域内的行列尺寸。然后将工作簿保存到流中以应用更改，并将其转换为字节数组以添加到 OLE 框中。为避免 PowerPoint 中 OLE 框出现红色“EMBEDDED OLE OBJECT”提示，我们还会捕获工作簿中所需行列部分的图像，并将其设为 OLE 框的图像。
```py
# <param name="width">单元格范围预期的宽度（单位：点）。</param>
# <param name="height">单元格范围预期的高度（单位：点）。</param>
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

    # 设置工作簿文件作为 PowerPoint 中 OLE 对象时的显示尺寸。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # 将单元格范围缩放以适应框架尺寸。
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

            # 创建 OLE 对象框架。
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **结论**

{{% alert color="primary" %}}

有两种方法可以解决工作表缩放问题。选择哪种方法取决于具体需求和使用场景。无论是基于模板创建演示文稿还是从头开始，这两种方法的工作原理相同。此外，此解决方案对 OLE 对象框的尺寸没有限制。

{{% /alert %}}