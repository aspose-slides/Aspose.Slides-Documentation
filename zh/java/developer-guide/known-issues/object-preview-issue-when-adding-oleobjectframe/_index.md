---
title: 添加 OleObjectFrame 时的对象预览问题
linktitle: OLE 对象问题
type: docs
weight: 10
url: /zh/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 预览问题
- 嵌入对象
- 嵌入文件
- 对象已更改
- 对象预览
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解在 Aspose.Slides for Java 中添加 OleObjectFrame 时为何出现 EMBEDDED OLE OBJECT，以及如何修复 PPT、PPTX 和 ODP 演示文稿中的预览问题。"
---
## **介绍**

使用 Aspose.Slides for Java 时，向幻灯片添加 [OleObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/oleobjectframe/) 后，输出幻灯片上会显示 “EMBEDDED OLE OBJECT” 消息。此消息是有意的，而非错误。

有关 OLE 对象的更多使用信息，请参阅 [管理 OLE](/slides/zh/java/manage-ole/)。 

## **说明与解决方案**

Aspose.Slides 显示 “EMBEDDED OLE OBJECT” 消息，以提醒您 OLE 对象已更改，需要更新预览图像。

例如，如果您将 Microsoft Excel 图表作为 [OleObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/oleobjectframe/) 添加到幻灯片（更多细节请参阅 “管理 OLE” 文档），然后在 Microsoft PowerPoint 中打开演示文稿，您将在幻灯片上看到如下图像：

![OLE 对象消息](OLE_object_message.png)

如果需要检查并确认 OLE 对象已添加到幻灯片，必须双击 “EMBEDDED OLE OBJECT” 消息，或右键单击该消息并选择 **Object > Edit**。

![OLE 对象 > 编辑](OLE_object_edit.png)

PowerPoint 随后打开嵌入的 OLE 对象。

![OLE 对象数据](OLE_object_data.png)

幻灯片可能仍保留 “EMBEDDED OLE OBJECT” 消息。单击 OLE 对象后，幻灯片预览将更新，原来的 “EMBEDDED OLE OBJECT” 消息会被 OLE 对象的实际图像取代。

![OLE 对象预览](OLE_object_preview.png)

此时，您可能希望保存演示文稿，以确保 OLE 对象的图像正确更新。这样，保存后再次打开演示文稿时，就不会再看到 “EMBEDDED OLE OBJECT” 消息。

## **其他解决方案**

如果不想通过在 PowerPoint 中打开演示文稿并保存来去除 “EMBEDDED OLE OBJECT” 消息，您可以将该消息替换为自定义的预览图像。以下代码演示了该过程：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // 向演示文稿资源添加图像。
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // 设置 OLE 对象预览的标题和图像。
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

包含 `OleObjectFrame` 的幻灯片随后会更改为如下所示：

![新的 OLE 对象图像](OLE_object_new_image.png)