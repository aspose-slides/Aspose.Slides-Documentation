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
description: "了解在 Aspose.Slides for Java 中添加 OleObjectFrame 时出现 EMBEDDED OLE OBJECT 的原因，以及如何修复 PPT、PPTX 和 ODP 演示文稿中的预览问题。"
---

## **介绍**

使用 Aspose.Slides for Java 时，当您向幻灯片添加 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) 时，输出幻灯片上会显示 “EMBEDDED OLE OBJECT” 消息。此消息是有意的，而非错误。

有关使用 OLE 对象的更多信息，请参阅 [Manage OLE](/slides/zh/java/manage-ole/)。

## **解释和解决方案**

Aspose.Slides 会显示 “EMBEDDED OLE OBJECT” 消息，以通知您 OLE 对象已更改，预览图像需要更新。

例如，如果您将 Microsoft Excel 图表作为 [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) 添加到幻灯片中（有关详细信息，请参阅 “Manage OLE” 文章），然后在 Microsoft PowerPoint 中打开演示文稿，您将在幻灯片上看到以下图像：

![OLE 对象消息](OLE_object_message.png)

如果您想检查并确认 OLE 对象已添加到幻灯片，需要双击 “EMBEDDED OLE OBJECT” 消息，或者右键单击它并选择 **Object > Edit** 选项。

![OLE 对象 > 编辑](OLE_object_edit.png)

PowerPoint 随后打开嵌入的 OLE 对象。

![OLE 对象数据](OLE_object_data.png)

幻灯片可能仍保留 “EMBEDDED OLE OBJECT” 消息。单击 OLE 对象后，幻灯片预览将更新，且 “EMBEDDED OLE OBJECT” 消息会被 OLE 对象的实际图像替代。

![OLE 对象预览](OLE_object_preview.png)

现在，您可能希望保存演示文稿，以确保 OLE 对象的图像正确更新。这样，在保存演示文稿后再次打开时，您将不会看到 “EMBEDDED OLE OBJECT” 消息。

## **其他解决方案**

### **解决方案 1：用图像替换 “Embedded OLE Object” 消息**

如果您不想通过在 PowerPoint 中打开演示文稿并保存来移除 “EMBEDDED OLE OBJECT” 消息，可以将该消息替换为您首选的预览图像。下面的代码行演示了该过程：
```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // 将图像添加到演示文稿资源。
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // 为 OLE 对象预览设置标题和图像。
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```


包含 `OleObjectFrame` 的幻灯片随后会变为如下所示：

![新的 OLE 对象图像](OLE_object_new_image.png)

### **解决方案 2：为 PowerPoint 创建插件**

您还可以为 Microsoft PowerPoint 创建插件，在程序中打开演示文稿时更新所有 OLE 对象。