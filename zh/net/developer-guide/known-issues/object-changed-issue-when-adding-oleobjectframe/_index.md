---
title: 添加 OleObjectFrame 时的对象更改问题
type: docs
weight: 10
url: /zh/net/object-changed-issue-when-adding-oleobjectframe/
---

{{% alert color="primary" %}} 

使用 Aspose.Slides for .NET，当您向幻灯片添加 **[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)** 时，输出幻灯片上会显示 **对象已更改** 消息（而不是在 OLE 对象上）。所描述的过程是一个故意的行为，而不是一个 bug。 

有关 OLE 对象的更多信息，请参见 [管理 OLE](/slides/zh/net/manage-ole/)。 

{{% /alert %}} 
## **解释** 和解决方案
Aspose.Slides 显示 **对象已更改** 消息以通知您 OLE 对象已被更改，并且预览图像必须更新。 

例如，如果您将 Microsoft Excel 图表作为 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 添加到幻灯片中（有关更多详细信息，请参阅管理 OLE 文章），然后在 Microsoft PowerPoint 应用程序中打开演示文稿，您将在幻灯片上看到此图像：

~~用新图像替换所有图像~~

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

如果您想检查并确认您的 OLE 对象已添加到幻灯片中，您必须双击 **对象已更改** 消息，或者可以右键单击它并选择 **工作表对象 > 编辑选项。**

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

然后 PowerPoint 会打开嵌入的 OLE 对象

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)



幻灯片可能会保留 **对象已更改** 消息。您点击 OLE 对象后，幻灯片预览进行更新，**对象已更改** 消息被 OLE 对象的实际图像所替换。 

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

现在，您可能希望保存您的演示文稿以确保 OLE 对象的图像正确更新。这样，在保存演示文稿后，当您再次打开演示文稿时，您将看不到 **对象已更改** 消息。 

## **其他解决方案**
### **解决方案 1：用图像替换对象已更改消息**

如果您不想通过在 PowerPoint 中打开演示文稿然后保存来删除 **对象已更改** 消息，您可以用您喜欢的预览图像替换该消息。这些代码行演示了该过程：

``` csharp 
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
   ISlide slide = pres.Slides[0];
   IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    
   IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("my_image.png"));
   oleObjectFrame.SubstitutePictureTitle = "我的标题";
   oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
   oleObjectFrame.IsObjectIcon = false;
    
   pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```

包含 `OleObjectFrame` 的幻灯片变为：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

### **解决方案 2：为 PowerPoint 创建插件**
您还可以为 Microsoft PowerPoint 创建一个插件，该插件在您在程序中打开演示文稿时更新所有 OLE 对象。