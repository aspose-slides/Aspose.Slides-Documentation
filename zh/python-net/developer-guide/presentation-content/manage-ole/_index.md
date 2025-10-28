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
description: "使用 Aspose.Slides for Python via .NET 优化 PowerPoint 和 OpenDocument 文件中的 OLE 对象管理。无缝嵌入、更新和导出 OLE 内容。"
---

## **概述**

{{% alert title="Info" color="info" %}}

**OLE（对象链接与嵌入）** 是微软技术，使在一个应用程序中创建的数据和对象能够在另一个应用程序中链接或嵌入。

{{% /alert %}}

例如，在 Microsoft Excel 中创建的图表并放置在 PowerPoint 幻灯片上，就是一个 OLE 对象。

- OLE 对象可能以图标形式出现。双击图标会在其关联的应用程序（例如 Excel）中打开对象，或提示您选择应用程序来打开或编辑它。
- OLE 对象可能直接显示其内容（例如图表）。在这种情况下，PowerPoint 会激活嵌入的对象，加载图表界面，并允许您在 PowerPoint 中编辑图表数据。

Aspose.Slides for Python 允许您将 OLE 对象插入幻灯片，作为 OLE 对象帧（[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)）。

## **向幻灯片添加 OLE 对象**

如果您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for Python 将其嵌入幻灯片作为 OLE 对象帧，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片引用。
1. 将 Excel 文件读取为字节数组。
1. 向幻灯片添加 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)，提供字节数组和其他 OLE 对象详细信息。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例将 Excel 文件中的图表嵌入幻灯片，作为 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)。

**注意：**[OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) 构造函数的第二个参数是可嵌入对象的文件扩展名。PowerPoint 使用此扩展名来识别文件类型并选择相应的应用程序打开 OLE 对象。

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Prepare the data for the OLE object.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Add an OLE object frame to the slide.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **添加链接 OLE 对象**

Aspose.Slides for Python 允许您添加一个链接到文件而不是嵌入数据的 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)。

以下 Python 示例展示了如何在幻灯片上添加一个链接到 Excel 文件的 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)：

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an OLE object frame with a linked Excel file.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **访问 OLE 对象**

如果 OLE 对象已经嵌入幻灯片，您可以按以下方式访问它：

1. 创建 Presentation 类的实例以加载包含嵌入 OLE 对象的演示文稿。
1. 按索引获取幻灯片引用。
1. 访问 OleObjectFrame 形状。
1. 获得 OLE 对象帧后，对其执行所需的操作。

下面的示例访问 OLE 对象帧（嵌入的 Excel 图表），并检索其文件数据。示例使用仅在第一张幻灯片上有单个形状的 PPTX。

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Get the embedded file data.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Get the extension of the embedded file.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **访问链接 OLE 对象属性**

Aspose.Slides 允许您访问链接 OLE 对象帧的属性。

下面的 Python 示例检查 OLE 对象是否为链接，并在是链接时获取链接文件的路径：

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Check whether the OLE object is linked.
        if ole_frame.is_object_link:
            # Print the full path to the linked file.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Print the relative path to the linked file, if present.
            # Only .ppt presentations can contain a relative path.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **更改 OLE 对象数据**

{{% alert color="primary" %}}
在本节中，下面的代码示例使用 [Aspose.Cells for Python via .NET](/cells/python-net/)。
{{% /alert %}}

如果 OLE 对象已经嵌入幻灯片，您可以按以下方式访问并修改其数据：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例以加载演示文稿。
1. 按索引获取目标幻灯片。
1. 访问 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 形状。
1. 获得 OLE 对象帧后，对其执行所需的操作。
1. 创建 `Workbook` 对象并读取 OLE 数据。
1. 打开所需的 `Worksheet` 并编辑数据。
1. 将更新后的 `Workbook` 保存到流中。
1. 使用该流替换 OLE 对象的数据。

下面的示例访问 OLE 对象帧（嵌入的 Excel 图表），并修改其文件数据以更新图表。示例使用先前创建的、在第一张幻灯片上仅包含单个形状的 PPTX。

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
            # Read the OLE object data as a Workbook object.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Modify the workbook data.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Change the OLE frame object data.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **在幻灯片中嵌入文件**

除了 Excel 图表，Aspose.Slides for Python 还允许您在幻灯片中嵌入其他文件类型。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入。用户双击插入的对象时，会自动在关联的应用程序中打开，或提示用户选择合适的程序。

下面的 Python 代码展示了如何在幻灯片中嵌入 HTML 和 ZIP 文件：

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

在处理演示文稿时，您可能需要将旧的 OLE 对象替换为新的，或将不受支持的 OLE 对象换成受支持的。Aspose.Slides for Python 允许您设置嵌入对象的文件类型，从而更新 OLE 帧数据或其文件扩展名。

下面的 Python 代码展示了如何将嵌入 OLE 对象的文件类型设置为 `zip`：

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Change the file type to ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **为嵌入对象设置图标图片和标题**

在嵌入 OLE 对象后，系统会自动添加基于图标的预览。该预览是用户在访问或打开 OLE 对象之前看到的内容。如果您想使用特定的图片和文字作为预览，可以使用 Aspose.Slides for Python 设置图标图片和标题。

下面的 Python 代码展示了如何为嵌入对象设置图标图片和标题：

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Add an image to the presentation resources.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Set a title and the image for the OLE preview.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **防止 OLE 对象帧被重新大小调整和重新定位**

在向幻灯片添加链接 OLE 对象后，打开演示文稿时 PowerPoint 可能会提示您更新链接。选择“更新链接”会因 PowerPoint 使用链接对象的数据刷新预览，从而改变 OLE 对象帧的大小和位置。若要阻止 PowerPoint 提示更新对象数据，请将 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 类的 `update_automatic` 属性设为 `False`：

```py
ole_frame.update_automatic = False
```

## **提取嵌入文件**

Aspose.Slides for Python 允许您按以下方式提取嵌入幻灯片的 OLE 文件：

1. 创建包含要提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类实例。
1. 遍历演示文稿中的所有形状，定位 OLEObjectFrame 形状。
1. 从每个 [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 中获取嵌入文件数据并写入磁盘。

下面的 Python 代码展示了如何提取幻灯片中作为 OLE 对象嵌入的文件：

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

## **常见问题**

**在将幻灯片导出为 PDF/图像时，OLE 内容会被渲染吗？**

渲染的仅是幻灯片上可见的内容——图标/替代图片（预览）。“实时” OLE 内容在渲染时不会被执行。如有需要，可自行设置预览图片，以确保导出 PDF 时的外观符合预期。

**如何在幻灯片上锁定 OLE 对象，使用户在 PowerPoint 中无法移动/编辑它？**

锁定形状：Aspose.Slides 提供[形状级别的锁定](/slides/zh/python-net/applying-protection-to-presentation/)。这不是加密，但能有效防止意外编辑和移动。

**为什么打开演示文稿时，链接的 Excel 对象会“跳动”或改变大小？**

PowerPoint 可能会刷新链接 OLE 的预览。为获得稳定外观，请参考[工作表大小调整的解决方案](/slides/zh/python-net/working-solution-for-worksheet-resizing/)：要么将框架尺寸适配范围，要么将范围缩放到固定框架并设置合适的替代图片。

**在 PPTX 格式中，链接 OLE 对象的相对路径会被保留吗？**

在 PPTX 中不存储“相对路径”信息——仅有完整路径。相对路径仅在旧的 PPT 格式中存在。为实现可移植性，建议使用可靠的绝对路径/可访问的 URI，或直接嵌入文件。