---
title: 添加图片框架并应用动画 使用 VSTO 和 Aspose.Slides for .NET
linktitle: 带动画的图片框架
type: docs
weight: 60
url: /zh/net/adding-picture-frame-with-animation/
keywords:
- 图片框架
- 添加图像
- 添加图片
- 带动画的图像
- 带动画的图片
- 迁移
- VSTO
- Office 自动化
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "从 Microsoft Office 自动化迁移到 Aspose.Slides for .NET，并使用简洁的 C# 代码在 PowerPoint (PPT, PPTX) 幻灯片中为图片框架添加动画。"
---

{{% alert color="primary" %}} 

图片框架可应用于 Microsoft PowerPoint 中的形状或图像，以在演示文稿中为图像添加框架。本文展示如何通过先使用 [VSTO 2008](/slides/zh/net/adding-picture-frame-with-animation/) 然后使用 [Aspose.Slides for .NET](/slides/zh/net/adding-picture-frame-with-animation/) 以编程方式创建图片框架并对其应用动画。首先，我们展示如何使用 VSTO 2008 为图片应用框架和动画。随后，我们展示如何使用 Aspose.Slides for .NET 执行相同的步骤。

{{% /alert %}} 
## **添加图片框架并应用动画**
下面的代码示例创建一个包含幻灯片的演示文稿，向其中添加带有图片框架的图像并对其应用动画。
### **VSTO 2008 示例**
使用 VSTO 2008，请执行以下步骤：

1. 创建演示文稿。
1. 添加一个空白幻灯片。
1. 向幻灯片添加图片形状。
1. 对图片应用动画。
1. 将演示文稿写入磁盘。

**使用 VSTO 创建的输出演示文稿** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)
```c#
//创建空白演示文稿
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add Picture Frame
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Applying animation on picture frame
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Saving Presentation
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET 示例**
使用 Aspose.Slides for .NET，执行以下步骤：

1. 创建演示文稿。
1. 访问第一张幻灯片。
1. 将图像添加到图片集合中。
1. 向幻灯片添加图片形状。
1. 对图片应用动画。
1. 将演示文稿写入磁盘。

**使用 Aspose.Slides 创建的输出演示文稿** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)
```c#
// 创建空白演示文稿
using (Presentation pres = new Presentation())
{
    // 访问第一张幻灯片
    ISlide slide = pres.Slides[0];

    // 将图像添加到演示文稿的图像集合中
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 添加一个宽高与图像相同的图片框架
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 获取幻灯片的主动画序列
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 为图片框架添加从左侧飞入的动画效果
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // 保存演示文稿
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```
