---
title: 添加 OleObjectFrame 时的对象预览问题
linktitle: OLE 对象问题
type: docs
weight: 10
url: /zh/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 预览问题
- 嵌入对象
- 嵌入文件
- 对象已更改
- 对象预览
- 演示文稿
- PowerPoint
- Python
- Aspose.Slides
description: "了解在 Aspose.Slides for Python 中添加 OleObjectFrame 时为何出现 EMBEDDED OLE OBJECT，以及如何修复 PPT、PPTX 和 ODP 演示文稿中的预览问题。"
---

## **介绍**

使用 Aspose.Slides for Python via .NET 时，向幻灯片添加 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 会在输出幻灯片上显示 “EMBEDDED OLE OBJECT” 消息。此消息是有意的，并非错误。

如需了解更多关于 OLE 对象的使用信息，请参阅 [Manage OLE](/slides/zh/python-net/manage-ole/)。

## **解释与解决方案**

Aspose.Slides 显示 “EMBEDDED OLE OBJECT” 消息，以通知您 OLE 对象已更改，需要更新预览图像。

例如，若您将 Microsoft Excel 图表作为 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 添加到幻灯片（有关详细信息，请参阅 “Manage OLE” 文章），然后在 Microsoft PowerPoint 中打开演示文稿，您将在幻灯片上看到如下图像：

![OLE 对象消息](OLE_object_message.png)

如果您想检查并确认 OLE 对象已添加到幻灯片，需要双击 “EMBEDDED OLE OBJECT” 消息，或右键单击该消息并通过 **Object > Edit** 选项进行操作。

![OLE 对象 > 编辑](OLE_object_edit.png)

PowerPoint 随后会打开嵌入的 OLE 对象。

![OLE 对象数据](OLE_object_data.png)

幻灯片可能仍保留 “EMBEDDED OLE OBJECT” 消息。单击 OLE 对象后，幻灯片预览会更新，消息将被 OLE 对象的实际图像所取代。

![OLE 对象预览](OLE_object_preview.png)

现在，您可以保存演示文稿，以确保 OLE 对象的图像得到正确更新。这样，保存后再次打开演示文稿时，您将不会再看到 “EMBEDDED OLE OBJECT” 消息。

## **其他解决方案**

### **解决方案 1：将 “Embedded OLE Object” 消息替换为图像**

如果您不想通过在 PowerPoint 中打开演示文稿并保存来移除 “EMBEDDED OLE OBJECT” 消息，可以将该消息替换为您首选的预览图像。以下代码行演示了此过程：
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # 添加图像到演示文稿资源。
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # 为 OLE 对象预览设置标题和图像。
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


包含 `OleObjectFrame` 的幻灯片随后会变为如下所示：

![新 OLE 对象图像](OLE_object_new_image.png)

### **解决方案 2：为 PowerPoint 创建插件**

您还可以为 Microsoft PowerPoint 创建插件，在程序中打开演示文稿时更新所有 OLE 对象。