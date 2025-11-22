---
title: 使用 Python 管理演示文稿中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh/python-net/manage-ole/
keywords:
- OLE 对象
- 对象链接与嵌入
- 添加 OLE
- 嵌入 OLE
- 添加对象
- 嵌入对象
- 添加文件
- 嵌入文件
- 链接对象
- 链接文件
- 更改 OLE
- OLE 图标
- OLE 标题
- 提取 OLE
- 提取对象
- 提取文件
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 优化在 PowerPoint 和 OpenDocument 文件中的 OLE 对象管理。无缝嵌入、更新和导出 OLE 内容。"
---

## **概述**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** 是 Microsoft 的一种技术，可让在一个应用程序中创建的数据和对象链接或嵌入到另一个应用程序中。

{{% /alert %}}

例如，在 Microsoft Excel 中创建的图表并放置在 PowerPoint 幻灯片上，即为 OLE 对象。

- OLE 对象可能显示为图标。双击图标会在其关联的应用程序（例如 Excel）中打开对象，或提示您选择用于打开或编辑的应用程序。
- OLE 对象也可能直接显示其内容（例如图表）。在这种情况下，PowerPoint 会激活嵌入的对象，加载图表界面，并允许您在 PowerPoint 中编辑图表的数据。

Aspose.Slides for Python 允许您将 OLE 对象作为 OLE 对象框架（[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)）插入幻灯片。

## **向幻灯片添加 OLE 对象**

如果您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for Python 将其作为 OLE 对象框架嵌入到幻灯片中，请按照下列步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片的引用。
1. 将 Excel 文件读取为字节数组。
1. 向幻灯片添加一个 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)，并提供字节数组及其他 OLE 对象详细信息。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例演示了如何将 Excel 文件中的图表嵌入为 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)。

**注意：**[OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) 构造函数的第二个参数是可嵌入对象的文件扩展名。PowerPoint 使用该扩展名来识别文件类型并选择相应的应用程序打开 OLE 对象。
```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # 为 OLE 对象准备数据。
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # 向幻灯片添加 OLE 对象框架。
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **添加链接的 OLE 对象**

Aspose.Slides for Python 允许您添加一个链接到文件而不是嵌入其数据的 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)。

以下 Python 示例展示了如何在幻灯片上添加一个链接到 Excel 文件的 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)：
```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加一个链接到 Excel 文件的 OLE 对象框架。
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **访问 OLE 对象**

如果幻灯片中已经嵌入了 OLE 对象，您可以按以下方式访问它：

1. 创建 Presentation 类的实例以加载包含嵌入 OLE 对象的演示文稿。
1. 按索引获取幻灯片的引用。
1. 访问 OleObjectFrame 形状。
1. 获得 OLE 对象框架后，对其执行所需的操作。

下面的示例访问 OLE 对象框架（一个嵌入的 Excel 图表）并检索其文件数据。示例使用的 PPTX 在第一张幻灯片上仅包含一个形状。
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # 获取嵌入文件的数据。
        file_data = ole_frame.embedded_data.embedded_file_data

        # 获取嵌入文件的扩展名。
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```


### **访问链接 OLE 对象属性**

Aspose.Slides 允许您访问链接 OLE 对象框架的属性。

下面的 Python 示例检查 OLE 对象是否为链接对象，如果是，则检索链接文件的路径：
```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # 检查 OLE 对象是否为链接。
        if ole_frame.is_object_link:
            # 打印链接文件的完整路径。
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # 打印链接文件的相对路径（如果存在）。
            # 仅 .ppt 演示文稿可以包含相对路径。
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```


## **更改 OLE 对象数据**

{{% alert color="primary" %}}

本节中的代码示例使用 [Aspose.Cells for Python via .NET](/cells/python-net/)。

{{% /alert %}}

如果幻灯片中已经嵌入了 OLE 对象，您可以按以下方式访问并修改其数据：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例以加载演示文稿。
1. 按索引获取目标幻灯片。
1. 访问 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 形状。
1. 获得 OLE 对象框架后，对其执行所需的操作。
1. 创建 `Workbook` 对象并读取 OLE 数据。
1. 打开所需的 `Worksheet` 并编辑数据。
1. 将更新后的 `Workbook` 保存到流中。
1. 使用该流替换 OLE 对象的数据。

下面的示例访问一个 OLE 对象框架（嵌入的 Excel 图表），并修改其文件数据以更新图表。示例使用的是先前创建的、在第一张幻灯片上仅包含一个形状的 PPTX。
```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # 将 OLE 对象数据读取为 Workbook 对象。
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # 修改工作簿数据。
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # 更改 OLE 框架对象的数据。
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **在幻灯片中嵌入文件**

除了 Excel 图表外，Aspose.Slides for Python 还允许您在幻灯片中嵌入其他文件类型。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。当用户双击插入的对象时，它会自动在关联的应用程序中打开，或提示用户选择合适的程序。

以下 Python 代码演示了如何在幻灯片中嵌入 HTML 和 ZIP 文件：
```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **设置嵌入对象的文件类型**

在处理演示文稿时，您可能需要用新对象替换旧的 OLE 对象，或将不受支持的 OLE 对象替换为受支持的对象。Aspose.Slides for Python 允许您设置嵌入对象的文件类型，从而更新 OLE 框架的数据或文件扩展名。

以下 Python 代码展示了如何将嵌入的 OLE 对象的文件类型设置为 `zip`：
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # 将文件类型更改为 ZIP。
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **设置嵌入对象的图标图像和标题**

嵌入 OLE 对象后，系统会自动添加基于图标的预览。此预览是在用户访问或打开 OLE 对象之前看到的内容。如果您希望在预览中使用特定的图像和文字，可以使用 Aspose.Slides for Python 设置图标图像和标题。

以下 Python 代码演示了如何为嵌入对象设置图标图像和标题：
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # 将图像添加到演示文稿资源中。
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # 为 OLE 预览设置标题和图像。
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **防止 OLE 对象框架被重新大小调整和重新定位**

在向幻灯片添加链接 OLE 对象后，打开演示文稿时 PowerPoint 可能会提示更新链接。选择“更新链接”可能会因 PowerPoint 使用链接对象的数据刷新预览而更改 OLE 对象框架的大小和位置。为防止 PowerPoint 提示您更新对象数据，请将 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 类的 `update_automatic` 属性设置为 `False`：
```py
ole_frame.update_automatic = False
```


## **提取嵌入文件**

Aspose.Slides for Python 允许您按以下方式提取嵌入在幻灯片中作为 OLE 对象的文件：

1. 创建一个包含要提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类实例。
1. 遍历演示文稿中的所有形状，定位 OLEObjectFrame 形状。
1. 从每个 [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 检索嵌入文件数据并写入磁盘。

以下 Python 代码展示了如何提取幻灯片中作为 OLE 对象嵌入的文件：
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```


## **FAQ**

**在将幻灯片导出为 PDF/图片时，OLE 内容会被渲染吗？**

渲染的仅是幻灯片上可见的内容——图标/替代图像（预览）。“实时” OLE 内容在渲染期间不会执行。如有需要，设置您自己的预览图像，以确保导出 PDF 的外观符合预期。

**如何锁定幻灯片上的 OLE 对象，使用户在 PowerPoint 中无法移动或编辑它？**

锁定形状：Aspose.Slides 提供了 [形状级别的锁定](/slides/zh/python-net/applying-protection-to-presentation/)。这不是加密，但可以有效防止意外的编辑和移动。

**为什么链接的 Excel 对象在打开演示文稿时会“跳动”或改变大小？**

PowerPoint 可能会刷新链接 OLE 的预览。为获得稳定的外观，请遵循 [工作表大小调整的解决方案](/slides/zh/python-net/working-solution-for-worksheet-resizing/)——要么将框架适配到范围，要么将范围缩放到固定框架并设置适当的替代图像。

**在 PPTX 格式中，链接 OLE 对象的相对路径会被保留吗？**

在 PPTX 中不存在“相对路径”信息——仅保存完整路径。相对路径存在于旧的 PPT 格式中。为实现可移植性，建议使用可靠的绝对路径/可访问的 URI 或直接嵌入文件。