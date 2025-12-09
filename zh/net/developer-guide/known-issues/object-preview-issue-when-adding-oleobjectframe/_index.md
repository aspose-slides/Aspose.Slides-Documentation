---
title: 添加 OleObjectFrame 时的对象预览问题
linktitle: OLE 对象问题
type: docs
weight: 10
url: /zh/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- 预览问题
- 嵌入对象
- 嵌入文件
- 对象已更改
- 对象预览
- 演示文稿
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "了解在 Aspose.Slides for .NET 中添加 OleObjectFrame 时为何出现 EMBEDDED OLE OBJECT，以及如何修复 PPT、PPTX 和 ODP 演示文稿中的预览问题。"
---

## **简介**

使用 Aspose.Slides for .NET 时，当您向幻灯片添加 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 时，输出幻灯片上会显示 “EMBEDDED OLE OBJECT” 消息。此消息是有意的，而不是错误。

有关 OLE 对象的更多使用信息，请参阅 [Manage OLE](/slides/zh/net/manage-ole/)。

## **解释与解决方案**

Aspose.Slides 显示 “EMBEDDED OLE OBJECT” 消息，以提醒您 OLE 对象已更改，需要更新预览图像。 

例如，如果您将 Microsoft Excel 图表作为 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 添加到幻灯片中（有关详细信息，请参阅 “Manage OLE” 文章），然后在 Microsoft PowerPoint 中打开演示文稿，您将在幻灯片上看到此图像：

![OLE object message](OLE_object_message.png)

如果您想检查并确认 OLE 对象已添加到幻灯片，必须双击 “EMBEDDED OLE OBJECT” 消息，或右键单击它并通过 **Object > Edit** 选项进行操作。

![OLE object > Edit](OLE_object_edit.png)

PowerPoint 随后打开嵌入的 OLE 对象。

![OLE object data](OLE_object_data.png)

幻灯片可能仍保留 “EMBEDDED OLE OBJECT” 消息。单击 OLE 对象后，幻灯片预览将更新，“EMBEDDED OLE OBJECT” 消息会被 OLE 对象的实际图像取代。

![OLE object preview](OLE_object_preview.png)

现在，您可能希望保存演示文稿，以确保 OLE 对象的图像已正确更新。这样，在保存演示文稿后再次打开时，您将不会看到 “EMBEDDED OLE OBJECT” 消息。 

## **其他解决方案**

### **解决方案 1：用图像替换 “Embedded OLE Object” 消息**

如果您不想通过在 PowerPoint 中打开演示文稿并保存来移除 “EMBEDDED OLE OBJECT” 消息，您可以将该消息替换为您首选的预览图像。以下代码行演示了该过程：
```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```


包含 `OleObjectFrame` 的幻灯片随后会更改为如下所示：

![New OLE object image](OLE_object_new_image.png)

### **解决方案 2：为 PowerPoint 创建加载项**

您还可以为 Microsoft PowerPoint 创建一个加载项，在程序中打开演示文稿时更新所有 OLE 对象。