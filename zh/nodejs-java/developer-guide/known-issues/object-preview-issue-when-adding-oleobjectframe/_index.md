---
title: 添加 OleObjectFrame 时的对象预览问题
linktitle: OLE 对象问题
type: docs
weight: 10
url: /zh/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 预览问题
- 嵌入对象
- 嵌入文件
- 对象已更改
- 对象预览
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解在 Aspose.Slides for Node.js 中添加 OleObjectFrame 时为何会出现 EMBEDDED OLE OBJECT，以及如何修复 PPT、PPTX 和 ODP 演示文稿中的预览问题。"
---
## **介绍**

使用 Aspose.Slides for Java 时，将 [OleObjectFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/oleobjectframe/) 添加到幻灯片时，输出幻灯片上会显示 “EMBEDDED OLE OBJECT” 消息。此消息是有意的，并非错误。

有关 OLE 对象的更多使用信息，请参阅 [Manage OLE](/slides/zh/nodejs-java/manage-ole/)。

## **解释 与 解决方案**

Aspose.Slides 显示 “EMBEDDED OLE OBJECT” 消息，以通知您 OLE 对象已更改，需更新预览图像。

例如，如果您将 Microsoft Excel 图表作为 [OleObjectFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/oleobjectframe/) 添加到幻灯片（有关详细信息，请参阅 “Manage OLE” 文章），然后在 Microsoft PowerPoint 中打开演示文稿，您将在幻灯片上看到此图像：

![OLE 对象消息](OLE_object_message.png)

如果您想检查并确认 OLE 对象已添加到幻灯片，需要双击 “EMBEDDED OLE OBJECT” 消息，或者右键单击它并通过 **Object > Edit** 选项进行操作。

![OLE 对象 > 编辑](OLE_object_edit.png)

PowerPoint 随后打开嵌入的 OLE 对象。

![OLE 对象数据](OLE_object_data.png)

幻灯片可能仍保留 “EMBEDDED OLE OBJECT” 消息。单击 OLE 对象后，幻灯片预览会更新，“EMBEDDED OLE OBJECT” 消息将被 OLE 对象的实际图像取代。

![OLE 对象预览](OLE_object_preview.png)

现在，您可能需要保存演示文稿，以确保 OLE 对象的图像正确更新。这样，在保存演示文稿后再次打开时，您将不会看到 “EMBEDDED OLE OBJECT” 消息。

## **其他解决方案**

### **解决方案 1：用图像替换 “Embedded OLE Object” 消息**

如果您不想通过在 PowerPoint 中打开演示文稿并保存来移除 “EMBEDDED OLE OBJECT” 消息，可以用您首选的预览图像替换该消息。这段代码演示了此过程：

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // 将图像添加到演示文稿资源。
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // 为 OLE 对象预览设置标题和图像。
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

包含 `OleObjectFrame` 的幻灯片随后会变为如下所示：

![新的 OLE 对象图像](OLE_object_new_image.png)

### **解决方案 2：为 PowerPoint 创建插件**

您还可以为 Microsoft PowerPoint 创建一个插件，在程序中打开演示文稿时更新所有 OLE 对象。