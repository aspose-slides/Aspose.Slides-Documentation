---
title: 添加 OleObjectFrame 时的对象预览问题
linktitle: OLE 对象问题
type: docs
weight: 10
url: /zh/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 预览问题
- 嵌入对象
- 嵌入文件
- 对象已更改
- 对象预览
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解在 Aspose.Slides for Python via Java 中添加 OleObjectFrame 时为何出现 EMBEDDED OLE OBJECT，以及如何在 PPT、PPTX 和 ODP 演示文稿中解决预览问题。"
---
## **简介**

当您使用 Aspose.Slides for Python via Java 将 [OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/) 添加到幻灯片时，输出幻灯片上会显示 "EMBEDDED OLE OBJECT" 消息。此消息是有意的，并非错误。

如需了解有关 OLE 对象的更多信息，请参阅 [Manage OLE](/slides/zh/python-java/manage-ole/)。

## **说明与解决方案**

Aspose.Slides 显示 "EMBEDDED OLE OBJECT" 消息，以通知您 OLE 对象已更改，需要更新预览图像。

例如，如果您将 Microsoft Excel 图表作为 [OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/) 添加到幻灯片中（有关详细信息，请参阅 "Manage OLE" 文章），然后在 Microsoft PowerPoint 中打开演示文稿，您将在幻灯片上看到如下图像：

![OLE object message](OLE_object_message.png)

要确认 OLE 对象已添加到幻灯片，双击 "EMBEDDED OLE OBJECT" 消息，或右键单击它并选择 **Object > Edit**。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint 随后打开嵌入的 OLE 对象。

![OLE object data](OLE_object_data.png)

幻灯片可能仍会保留 "EMBEDDED OLE OBJECT" 消息。单击 OLE 对象后，幻灯片预览会更新，"EMBEDDED OLE OBJECT" 消息将被 OLE 对象的实际图像替代。

![OLE object preview](OLE_object_preview.png)

保存演示文稿以保留已更新的 OLE 对象预览图像。再次打开演示文稿时，您将不再看到 "EMBEDDED OLE OBJECT" 消息。

## **其他解决方案**

如果您不想通过在 PowerPoint 中打开演示文稿并保存来删除 "EMBEDDED OLE OBJECT" 消息，也可以将该消息替换为您偏好的预览图像。以下代码演示了该过程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # 向演示文稿资源添加图像。
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # 设置标题和 OLE 对象预览的图像。
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

包含 [OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/) 的幻灯片随后会更改为如下所示：

![New OLE object image](OLE_object_new_image.png)

## **常见问题**

**为什么会出现 "EMBEDDED OLE OBJECT" 消息？**

此消息表明 OLE 对象已更改，需要更新其预览图像。此行为是有意的。

**如何在 PowerPoint 中更新预览？**

双击该消息或选择 **Object > Edit** 打开嵌入的 OLE 对象。单击 OLE 对象以更新预览，然后保存演示文稿。

**是否可以在不打开 PowerPoint 的情况下替换该消息？**

可以。您可以像上面的代码示例中那样为 OLE 对象分配首选的预览图像。