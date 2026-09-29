---
title: 添加 OleObjectFrame 时的对象预览占位符
linktitle: OLE 预览占位符
type: docs
weight: 10
url: /zh/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 预览问题
- 预览占位符
- 设计如此
- 嵌入对象
- 嵌入文件
- 对象已更改
- 对象预览
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "为什么使用 Aspose.Slides for Java 添加的 OLE 对象会显示 “EMBEDDED OLE OBJECT” 占位符，直到其预览被更新，以及如何设置您自己的预览图像。"
---
## **介绍**

使用 Aspose.Slides for Java 时，当您向幻灯片添加 [OleObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/oleobjectframe/) 时，输出幻灯片上会显示 “EMBEDDED OLE OBJECT” 消息。此消息是有意的，并非错误。

有关使用 OLE 对象的更多信息，请参阅 [Manage OLE](/slides/zh/java/manage-ole/).

## **解释和解决方案**

Aspose.Slides 显示 “EMBEDDED OLE OBJECT” 消息，以通知您 OLE 对象已更改，需要更新预览图像。

例如，如果您将 Microsoft Excel 图表作为 [OleObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/oleobjectframe/) 添加到幻灯片中（更多详情请参阅 “Manage OLE” 文章），然后在 Microsoft PowerPoint 中打开演示文稿，您将在幻灯片上看到此图像：

![OLE object message](OLE_object_message.png)

如果您想检查并确认 OLE 对象已添加到幻灯片，需要双击 “EMBEDDED OLE OBJECT” 消息，或右键单击它并通过 **Object > Edit** 选项进行操作。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint 会打开嵌入的 OLE 对象。

![OLE object data](OLE_object_data.png)

幻灯片可能仍保留 “EMBEDDED OLE OBJECT” 消息。单击 OLE 对象后，幻灯片预览会更新，“EMBEDDED OLE OBJECT” 消息将被 OLE 对象的实际图像取代。

![OLE object preview](OLE_object_preview.png)

现在，您可能希望保存演示文稿，以确保 OLE 对象的图像正确更新。这样，在保存演示文稿后再次打开时，您将不会看到 “EMBEDDED OLE OBJECT” 消息。

## **其它解决方案**

如果您不想通过在 PowerPoint 中打开演示文稿并保存来移除 “EMBEDDED OLE OBJECT” 消息，可以将该消息替换为您喜欢的预览图像。这段代码演示了该过程。它假设 *embeddedOLE.pptx* 的第一张幻灯片上的第一个形状是 OLE 对象框，且 *myImage.png* 包含要显示的图像，并将结果保存为 *embeddedOLE-newImage.pptx*：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // 将图像添加到演示文稿资源。
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // 设置 OLE 对象预览的图像。
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

包含 `OleObjectFrame` 的幻灯片随后会变为以下效果：

![New OLE object image](OLE_object_new_image.png)