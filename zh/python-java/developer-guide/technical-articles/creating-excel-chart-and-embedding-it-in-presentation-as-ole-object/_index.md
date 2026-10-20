---
title: 创建 Excel 图表并将其作为 OLE 对象嵌入到演示文稿中
type: docs
weight: 30
url: /zh/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 图表
- 嵌入图表
- OLE 对象
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Cells for Python via Java 创建 Excel 图表，并使用 Aspose.Slides 将工作簿嵌入到 PowerPoint 演示文稿中，包括图表预览。"
---
## **概述**

本文展示了如何使用 Aspose.Cells for Python via Java 创建 Excel 柱形图，并将其工作簿嵌入到使用 Aspose.Slides for Python via Java 的 PowerPoint 演示文稿中。嵌入的工作簿同时包含源数据和图表。单独的 PNG 预览在 OLE 对象激活之前在幻灯片上显示图表。

结果是嵌入的 Excel 对象，而非原生 PowerPoint 图表。通过 OLE 编辑工作簿需要支持 OLE 激活的桌面应用程序以及兼容的 Excel 安装。

## **先决条件**

安装 `aspose-cells` 和 `aspose-slides-java` Python 包以及兼容的 Java 运行时。在启动 JVM 之前导入这两个包，以便它们的 Java 库可供 JPype 使用。生成演示文稿时不需要 Microsoft Office。

不需要输入文件：示例在内存中创建数据和图表，然后将 `OutputChart.pptx` 写入当前工作目录。在非评估模式下运行时，请为两个产品应用许可证。

## **嵌入工作原理**

1. 创建包含数据工作表和图表工作表的工作簿。
1. 将图表工作表设为活动工作表，以便工作簿打开时显示图表。
1. 设置工作簿的 OLE 显示范围并将图表渲染为 PNG。
1. 将工作簿以 XLSX 格式保存在内存中，并将这些字节嵌入到幻灯片中。
1. 将 PNG 设为 OLE 对象的预览图，并将演示文稿保存为 PPTX。

工作簿显示范围和幻灯片上的框架具有不同的作用。[setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) 使用基于零的起始/结束行和列索引。而 [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) 则接受顶部行、左侧列、底部行和右侧列。示例使用行索引 55 和列索引 25 作为右下边界；这些数值是布局选择，而非数据行或列的数量。

幻灯片框架使用点（points）。示例将其适配到幻灯片内部并居中显示，同时保持 PNG 的宽高比，而不是拉伸预览以填满幻灯片。

## **创建并嵌入图表**

下面的完整示例向 `DataSheet` 填充四行五列的数值。每一行对应一个图表系列。在保存工作簿之前，将 `ChartSheet` 设为活动工作表。

工作簿显式保存为 XLSX，匹配传递给 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) 的 `xlsx` 扩展名。Java 字节数组流在内存中保留工作簿和图像，并提供 Java API 所需的字节数组。PNG 直接从其字节加载，无需中间位图转换。通过 [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 进行赋值，可替换默认的 OLE 占位符。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # 渲染图表预览并将可编辑的工作簿单独序列化。
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # 在不改变宽高比的情况下，将预览适配到幻灯片内。
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **预期结果**

`OutputChart.pptx` 包含一张带有嵌入式 Excel 工作簿和图表预览的幻灯片。工作簿包含原始数据和一个四系列的柱形图。预览居中显示并保持其比例。

![Excel 柱形图显示为嵌入工作簿的预览](excel-chart-ole-preview.png)

在已安装 Excel 的兼容桌面 PowerPoint 环境中，双击对象即可激活并编辑嵌入的工作簿。激活和编辑取决于宿主应用的 OLE 支持和安全设置。

## **常见问题**

**为什么需要预览图像？**

嵌入的工作簿和其幻灯片预览是分离的内容。提供图表图像，以便幻灯片显示图表而不是默认的“EMBEDDED OLE OBJECT”占位符。参见 [添加 OleObjectFrame 时的对象预览问题](/slides/zh/python-java/object-preview-issue-when-adding-oleobjectframe/)。

**当我在代码中更改工作簿时，预览会自动更新吗？**

将预览视为快照。当以编程方式更新工作簿数据时，需要重新生成图表图像并同时替换预览和嵌入的工作簿数据。

**我可以使用 XLS 而不是 XLSX 吗？**

可以。将工作簿保存为 XLS 格式并使用 `xls` 作为嵌入数据的扩展名。扩展名必须与实际的工作簿格式匹配，仅更改扩展名并不会转换数据。

**为什么对象在激活后可能会改变大小？**

宿主应用在激活工作簿时可能会更新 OLE 对象的显示。工作簿的 OLE 显示范围和幻灯片框架的尺寸都会影响。参见 [PPTX 中图表大小调整的可行方案](/slides/zh/python-java/working-solution-for-chart-resizing-in-pptx/)。

## **相关章节**

- [PPTX 中图表大小调整的可行方案](/slides/zh/python-java/working-solution-for-chart-resizing-in-pptx/)
- [添加 OleObjectFrame 时的对象预览问题](/slides/zh/python-java/object-preview-issue-when-adding-oleobjectframe/)