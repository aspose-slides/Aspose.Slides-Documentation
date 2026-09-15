---
title: 创建 Excel 图表并将其嵌入为 OLE 对象到演示文稿
type: docs
weight: 30
url: /zh/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 图表
- 嵌入图表
- OLE 对象
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Python 创建 Excel 图表并将其作为 OLE 对象嵌入 PowerPoint 和 OpenDocument 演示文稿。步骤指南并附有代码示例。"
---
## **背景**

在 PowerPoint 中，使用可编辑的图表以图形方式显示数据是常见做法。Aspose 支持使用 Aspose.Cells for Python via Java 创建 Excel 图表，然后通过 Aspose.Slides for Python via Java 将这些图表嵌入为 PowerPoint 幻灯片中的 OLE 对象。本文介绍必要的步骤，并提供一个 Python 代码示例，用于创建 Excel 图表并将其作为 OLE 对象嵌入 PowerPoint 演示文稿，使用 Aspose.Cells 和 Aspose.Slides。

## **必要步骤**

1. 使用 Aspose.Cells 创建 Excel 图表。  
2. 使用 Aspose.Cells 设置 Excel 图表的 OLE 大小。  
3. 使用 Aspose.Cells 获取 Excel 图表的图像。  
4. 使用 Aspose.Slides 将 Excel 图表作为 OLE 对象嵌入 PPTX 演示文稿。  
5. 用第 3 步获取的图像替换 “EMBEDDED OLE OBJECT” 图像，以解决 [对象预览问题](/slides/zh/python-java/object-preview-issue-when-adding-oleobjectframe/)。  
6. 以 PPTX 格式将演示文稿保存到磁盘。

## **必要步骤的实现**

上述步骤的 Python 实现如下：

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
    # 单元格名称数组。
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # 单元格数据数组。
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # 添加新工作表以填充数据单元格。
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # 用数据填充数据工作表。
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # 添加图表工作表。
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # 向图表工作表添加图表，数据系列来自数据工作表。
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # 将图表工作表设为活动工作表。
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # 将工作簿描述为嵌入的 OLE 数据。
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# 创建工作簿。
workbook = Workbook()

# 添加 Excel 图表。
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# 设置图表的 OLE 大小。
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# 获取图表图像并保存到流。
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# 将工作簿保存到流。
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# 创建演示文稿。
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 将工作簿添加到幻灯片。
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # 将演示文稿保存到磁盘。
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

上述方法创建的演示文稿将包含作为 OLE 对象的 Excel 图表，用户可以通过双击 OLE 对象框来激活它。

## **结论**

通过同时使用 Aspose.Cells for Python via Java 和 Aspose.Slides for Python via Java，我们可以创建 Aspose.Cells 支持的任何 Excel 图表，并将该图表嵌入为 PowerPoint 幻灯片中的 OLE 对象。Excel 图表的 OLE 大小也可以定义。最终用户随后可以像编辑其他 OLE 对象一样编辑该 Excel 图表。

## **相关章节**

- [PPTX 中图表大小调整的可行方案](/slides/zh/python-java/working-solution-for-chart-resizing-in-pptx/)
- [添加 OleObjectFrame 时的对象预览问题](/slides/zh/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **常见问题**

**使用哪些库来创建和嵌入 Excel 图表？**

Aspose.Cells for Python via Java 用于创建 Excel 图表，Aspose.Slides for Python via Java 将其嵌入为 PowerPoint 幻灯片中的 OLE 对象。

**用户如何编辑嵌入的 Excel 图表？**

用户可以双击 OLE 对象框来激活图表，并像编辑其他 OLE 对象一样进行编辑。

**默认的 OLE 对象预览是如何被替换的？**

示例使用 Aspose.Cells 获取 Excel 图表的图像，并用该图像替换 “EMBEDDED OLE OBJECT” 图像。