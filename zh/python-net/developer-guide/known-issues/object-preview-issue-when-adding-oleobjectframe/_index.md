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

## **Introduction**

使用 Aspose.Slides for Python via .NET 时，向幻灯片添加 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 后，输出幻灯片上会显示 “EMBEDDED OLE OBJECT” 消息。此消息是有意显示的，并非错误。

有关 OLE 对象的更多使用信息，请参见 [Manage OLE](/slides/zh/python-net/manage-ole/)。 

## **Explanation and Solution**

Aspose.Slides 显示 “EMBEDDED OLE OBJECT” 消息是为了通知您 OLE 对象已更改，需要更新预览图像。

例如，如果您将 Microsoft Excel 图表作为 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 添加到幻灯片（有关详细信息，请参阅 “Manage OLE” 文章），然后在 Microsoft PowerPoint 中打开该演示文稿，您将在幻灯片上看到如下图像：

![OLE object message](OLE_object_message.png)

如果您想检查并确认 OLE 对象已成功添加到幻灯片，需要双击 “EMBEDDED OLE OBJECT” 消息，或右键单击它并选择 **Object > Edit**：

![OLE object > Edit](OLE_object_edit.png)

PowerPoint 随后会打开嵌入的 OLE 对象。

![OLE object data](OLE_object_data.png)

幻灯片可能仍然保留 “EMBEDDED OLE OBJECT” 消息。单击 OLE 对象后，幻灯片预览会更新，“EMBEDDED OLE OBJECT” 消息将被实际的 OLE 对象图像取代。

![OLE object preview](OLE_object_preview.png)

此时，您可能需要保存演示文稿，以确保 OLE 对象的图像正确更新。这样，在保存后再次打开演示文稿时，您将不会看到 “EMBEDDED OLE OBJECT” 消息。 

## **Other Solutions**

### **Solution 1: Replace the "Embedded OLE Object" Message with an Image**

如果您不想通过在 PowerPoint 中打开演示文稿并保存来去除 “EMBEDDED OLE OBJECT” 消息，可以用您喜欢的预览图像替换该消息。以下代码演示了此过程：
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # 将图像添加到演示文稿资源。
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # 设置 OLE 对象预览的标题和图像。
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


包含 `OleObjectFrame` 的幻灯片随后会变为如下所示：

![New OLE object image](OLE_object_new_image.png)

### **Solution 2: Create an Add-On for PowerPoint**

您还可以为 Microsoft PowerPoint 创建一个加载项，在打开演示文稿时自动更新所有 OLE 对象。