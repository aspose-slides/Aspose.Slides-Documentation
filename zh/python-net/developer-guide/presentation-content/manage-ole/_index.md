---
title: 管理 OLE
type: docs
weight: 40
url: /zh/python-net/manage-ole/
keywords:
- 添加 OLE
- 嵌入 OLE
- 添加对象
- 嵌入对象
- 嵌入文件
- 链接对象
- 对象链接与嵌入
- OLE 对象
- PowerPoint 
- 演示文稿
- Python
- Aspose.Slides for Python via .NET
description: 在 Python 中将 OLE 对象添加到 PowerPoint 演示文稿
---

{{% alert title="信息" color="info" %}}

OLE (对象链接与嵌入) 是微软的一项技术，允许在一个应用程序中创建的数据和对象通过链接或嵌入的方式放置在另一个应用程序中。

{{% /alert %}} 

考虑在 MS Excel 中创建的图表。该图表随后被放置在 PowerPoint 幻灯片中。该 Excel 图表被视为 OLE 对象。

- OLE 对象可以显示为图标。在这种情况下，当您双击该图标时，图表将在其关联的应用程序 (Excel) 中打开，或者您会被要求选择一个应用程序以打开或编辑该对象。
- OLE 对象可以显示实际内容——例如，一个图表的内容。在这种情况下，图表在 PowerPoint 中激活，图表界面加载，您可以在 PowerPoint 应用程序中修改图表的数据。

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/python-net) 允许您将 OLE 对象插入幻灯片作为 OLE 对象框 ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/))。

## **将 OLE 对象框添加到幻灯片**
假设您已经在 Microsoft Excel 中创建了图表，并希望使用 Aspose.Slides for Python via .NET 将该图表嵌入幻灯片作为 OLE 对象框，您可以这样操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 打开包含 Excel 图表对象的 Excel 文件，并将其保存到 `MemoryStream`。
1. 将 OLE 对象框添加到包含字节数组和有关 OLE 对象的其他信息的幻灯片中。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们使用 Aspose.Slides for Python via .NET 将 Excel 文件中的图表添加到幻灯片作为 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)。  
**注意**，[IOleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/) 构造函数将可嵌入对象扩展名作为第二个参数。此扩展名允许 PowerPoint 正确解释文件类型，并选择正确的应用程序来打开此 OLE 对象。

```py 
import aspose.slides as slides

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation() as pres:
    # 访问第一张幻灯片
    sld = pres.slides[0]

    # 加载 Excel 文件到流中
    with open(path + "book1.xlsx", "rb") as fs:
        bytes = fs.read()
    
        # 创建用于嵌入的数据对象
        dataInfo = slides.dom.ole.OleEmbeddedDataInfo(bytes, "xlsx")

        # 添加 Ole 对象框形状
        oleObjectFrame = sld.shapes.add_ole_object_frame(0, 0, pres.slide_size.size.width, pres.slide_size.size.height, dataInfo)

        # 将 PPTX 文件写入磁盘
        pres.save("OleEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```
## **访问 OLE 对象框**
如果 OLE 对象已经嵌入到幻灯片中，您可以通过以下方式轻松找到或访问该对象：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。

1. 通过索引获取幻灯片的引用。

1. 访问 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 形状。

   在我们的示例中，我们使用之前创建的仅包含一张形状的 PPTX。然后，我们将该对象 *强制转换* 为 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)。这是要访问的所需 OLE 对象框。

1. 一旦访问了 OLE 对象框，您可以对其执行任何操作。

在下面的示例中，访问了 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象）——然后其文件数据被写入 Excel 文件：

```py 
import aspose.slides as slides

# 加载 PPTX 到演示文稿对象
with slides.Presentation(path + "AccessingOLEObjectFrame.pptx") as pres:
    # 访问第一张幻灯片
    sld = pres.slides[0]

    # 将形状强制转换为 OleObjectFrame
    oleObjectFrame = sld.shapes[0]

    # 读取 OLE 对象并写入磁盘
    if type(oleObjectFrame) is slides.OleObjectFrame:
        # 获取嵌入的文件数据
        data = oleObjectFrame.embedded_data.embedded_file_data

        # 获取嵌入的文件扩展名
        fileExtention = oleObjectFrame.embedded_data.embedded_file_extension

        # 创建保存提取文件的路径
        extractedPath = "excelFromOLE_out" + fileExtention

        # 保存提取的数据
        with open("out.xlsx", "wb") as fs:
            fs.write(data)
```

## **更改 OLE 对象数据**

如果 OLE 对象已经嵌入到幻灯片中，您可以使用 Aspose.Slides for Python via .NET 轻松访问该对象并修改其数据，方法如下：

1. 通过创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例来打开嵌入了 OLE 对象的演示文稿。

1. 通过索引获取幻灯片的引用。

1. 访问 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 形状。

   在我们的示例中，我们使用之前创建的 PPTX，它在第一张幻灯片上只有一张形状。然后，我们将该对象 *强制转换* 为 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)。这是要访问的所需 OLE 对象框。

1. 一旦访问了 OLE 对象框，您可以对其执行任何操作。

1. 创建工作簿对象并访问 OLE 数据。

1. 访问所需的工作表并修订数据。

1. 将更新后的工作簿保存在流中。

1. 从流数据更改 OLE 对象数据。

在下面的示例中，访问了 OLE 对象框（嵌入在幻灯片中的 Excel 图表对象）——然后其文件数据被修改以更改图表数据。

```py 
# [TODO:需要 Aspose.Cells for Python via .NET]
```

## 在幻灯片中嵌入其他文件类型

除了 Excel 图表外，Aspose.Slides for Python via .NET 还允许您在幻灯片中嵌入其他类型的文件。例如，您可以将 HTML、PDF 和 ZIP 文件作为对象插入到幻灯片中。当用户双击插入的对象时，该对象会自动在相关程序中启动，或者用户会被引导选择一个合适的程序来打开该对象。

以下 Python 代码演示如何在幻灯片中嵌入 HTML 和 ZIP 文件：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open(path + "index.html", "rb") as fs1:
        htmlBytes = fs1.read()
        dataInfoHtml = slides.dom.ole.OleEmbeddedDataInfo(htmlBytes, "html")
        oleFrameHtml = slide.shapes.add_ole_object_frame(150, 120, 50, 50, dataInfoHtml)
        oleFrameHtml.is_object_icon = True

    with open(path + "archive.zip", "rb") as fs2:
        zipBytes = fs2.read()
        dataInfoZip = slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip")
        oleFrameZip = slide.shapes.add_ole_object_frame(150, 220, 50, 50, dataInfoZip)
        oleFrameZip.is_object_icon = True

    pres.save("embeddedOle.pptx", slides.export.SaveFormat.PPTX)
```

## 设置嵌入对象的文件类型

在处理演示文稿时，您可能需要用新对象替换旧的 OLE 对象。或者您可能需要用支持的对象替换不支持的 OLE 对象。

Aspose.Slides for Python via .NET 允许您设置嵌入对象的文件类型。通过这种方式，您可以更改 OLE 框数据或其扩展名。

以下 Python 代码演示如何为嵌入的 OLE 对象设置文件类型：

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    print("当前嵌入数据扩展名为：" + oleObjectFrame.embedded_data.embedded_file_extension)
   
    with open(path + "1.zip", "rb") as fs2:
        zipBytes = fs2.read()

    oleObjectFrame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip"))
   
    pres.save("embeddedChanged.pptx", slides.export.SaveFormat.PPTX)
```

## 为嵌入对象设置图标图像和标题

在您嵌入 OLE 对象后，带有图标图像和标题的预览将自动添加。预览是用户在访问或打开 OLE 对象前所看到的内容。

如果您想使用特定的图像和文本作为预览中的元素，您可以使用 Aspose.Slides for Python via .NET 设置图标图像和标题。

以下 Python 代码演示如何为嵌入对象设置图标图像和标题：

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    
    with open("img.jpeg", "rb") as in_file:
        oleImage = pres.images.add_image(in_file)

    oleObjectFrame.substitute_picture_title = "我的标题"
    oleObjectFrame.substitute_picture_format.picture.image = oleImage
    oleObjectFrame.is_object_icon = False

    pres.save("embeddedOle-newImage.pptx", slides.export.SaveFormat.PPTX)
```

## **防止 OLE 对象框被调整大小和重新定位**

在您将链接的 OLE 对象添加到演示文稿幻灯片后，当您在 PowerPoint 中打开演示文稿时，您可能会看到一条消息，询问您是否要更新链接。点击“更新链接”按钮可能会改变 OLE 对象框的大小和位置，因为 PowerPoint 会更新来自链接的 OLE 对象的数据并刷新对象的预览。要防止 PowerPoint 提示更新对象的数据，请将 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 类的 `update_automatic` 属性设置为 `False`：

```py
oleObjectFrame.update_automatic = False
```

## 提取嵌入文件

Aspose.Slides for Python via .NET 允许您通过以下方式提取嵌入在幻灯片中的 OLE 对象文件：

1. 创建一个包含您打算提取的 OLE 对象的 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。
2. 循环访问演示文稿中的所有形状，访问 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 形状。
3. 从 OLE 对象框中访问嵌入文件的数据并将其写入磁盘。

以下 Python 代码演示如何提取嵌入在幻灯片中的 OLE 对象文件：

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    index = 0
    for shape in slide.shapes:

        if type(shape) is slides.OleObjectFrame:
            data = shape.embedded_data.embedded_file_data
            extension = shape.embedded_data.embedded_file_extension
            
            with open("oleFrame{idx}{ex}".format(idx = str(index), ex = extension), "wb") as fs:
                fs.write(data)
        index += 1
```