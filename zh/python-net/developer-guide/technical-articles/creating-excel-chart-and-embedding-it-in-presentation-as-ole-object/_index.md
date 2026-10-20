---
title: 创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿
type: docs
weight: 50
url: /zh/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 图表
- 嵌入图表
- OLE 对象
- PowerPoint
- 演示文稿
- Python
- Python via .NET
- Aspose.Slides
description: "使用 Aspose.Cells for Python via .NET 创建 Excel 图表，并将工作簿嵌入使用 Aspose.Slides 的 PowerPoint 演示文稿中，包含图表预览。"
---
## **概述**

本文展示了如何使用 Aspose.Cells for Python via .NET 创建 Excel 柱形图，并将其工作簿嵌入到使用 Aspose.Slides for Python via .NET 的 PowerPoint 演示文稿中。嵌入的工作簿同时包含源数据和图表。单独的 PNG 预览将在激活 OLE 对象之前在幻灯片上显示该图表。

结果是一个嵌入的 Excel 对象，而不是原生的 PowerPoint 图表。通过 OLE 编辑工作簿需要支持 OLE 激活的桌面应用程序以及兼容的 Excel 安装。

## **先决条件**

在你的 Python 环境中安装 `aspose-cells-python` 和 `aspose-slides` 包。使用这些库生成演示文稿不需要 Microsoft Office。

不需要任何输入文件：示例在内存中创建数据和图表，然后将 `OutputChart.pptx` 写入当前工作目录。在评估模式之外运行时，请为两个产品都应用许可证。

## **嵌入工作原理**

1. 创建一个包含数据工作表和图表工作表的工作簿。  
2. 将图表工作表设为活动工作表，以便打开工作簿时显示图表。  
3. 设置工作簿的 OLE 显示范围并将图表渲染为 PNG。  
4. 将工作簿以 XLSX 格式保存到内存中，并将这些字节嵌入到幻灯片中。  
5. 将 PNG 设为 OLE 对象的预览图并将演示文稿保存为 PPTX。

工作簿的显示范围和幻灯片上的框架具有不同的作用。[set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) 使用零基的起始/结束行列索引。相反，[ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) 使用顶部行、左侧列、底部行和右侧列。示例使用行索引 55 和列索引 25 作为右下边界；这些值是布局选择，而不是数据行或列的数量。

幻灯片框架使用磅（points）单位。示例将其适配到幻灯片内部并居中，同时保持 PNG 的宽高比，而不是将预览拉伸至填满幻灯片。

## **创建并嵌入图表**

下面的完整示例向 `DataSheet` 填充四行五列的数值。每行都成为图表的一个系列。`ChartSheet` 在保存工作簿之前被选为活动工作表。

工作簿显式保存为 XLSX，匹配传递给 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) 的 `xlsx` 扩展名。PNG 直接从其流中加载，无需中间的位图转换。通过 [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) 进行分配会替换默认的 OLE 占位符。

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# 渲染图表预览并分别序列化可编辑的工作簿。
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # 在幻灯片内适配预览图，保持其宽高比不变。
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **预期结果**

`OutputChart.pptx` 包含一张带有嵌入式 Excel 工作簿和图表预览的幻灯片。工作簿包含原始数据以及一个具有四个系列的柱形图。预览图居中显示在幻灯片上并保持其比例。

![Excel 柱形图作为嵌入工作簿的预览显示](excel-chart-ole-preview.png)

在兼容的桌面 PowerPoint 环境且已安装 Excel 时，双击对象即可激活并编辑嵌入的工作簿。激活和编辑取决于宿主应用程序的 OLE 支持和安全设置。

## **常见问题**

**为什么需要预览图像？**

嵌入的工作簿和幻灯片预览是分开的内容。提供图表图像，使幻灯片显示图表而不是默认的 “EMBEDDED OLE OBJECT” 占位符。请参阅 [添加 OleObjectFrame 时的对象预览问题](/slides/zh/python-net/object-preview-issue-when-adding-oleobjectframe/)。

**预览在代码中更改工作簿时会自动更新吗？**

将预览视为快照。在以编程方式更新工作簿数据时，需要重新生成图表图像并替换预览以及嵌入的工作簿数据。

**我可以使用 XLS 而不是 XLSX 吗？**

可以。将工作簿保存为 XLS 格式，并使用 `xls` 作为嵌入数据的扩展名。扩展名必须与实际的工作簿格式匹配，仅更改扩展名并不会转换数据。

**为什么对象在激活后可能会改变大小？**

宿主应用程序在激活工作簿时可以更新 OLE 对象的呈现。工作簿的 OLE 显示范围和幻灯片框架尺寸都很重要。请参阅 [在 PowerPoint 演示文稿中自动调整 OLE 对象大小](/slides/zh/python-net/working-solution-for-worksheet-resizing/)。

## **相关章节**

- [在 PowerPoint 演示文稿中自动调整 OLE 对象大小](/slides/zh/python-net/working-solution-for-worksheet-resizing/)
- [添加 OleObjectFrame 时的对象预览问题](/slides/zh/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [管理 OLE 对象](/slides/zh/python-net/manage-ole/)