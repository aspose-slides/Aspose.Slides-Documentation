---
title: 添加带动画的画框
type: docs
weight: 60
url: /net/adding-picture-frame-with-animation/
---

{{% alert color="primary" %}} 

画框用于在 Microsoft PowerPoint 中给形状或图像加框，以便在演示文稿中展示图像。本文展示了如何使用 [VSTO 2008](/slides/net/adding-picture-frame-with-animation/) 和 [Aspose.Slides for .NET](/slides/net/adding-picture-frame-with-animation/) 以编程方式创建画框并对其应用动画。首先，我们展示如何使用 VSTO 2008 应用框架和动画。然后，我们展示如何使用 Aspose.Slides for .NET 执行相同的步骤。

{{% /alert %}} 
## **添加带动画的画框**
下面的代码示例创建一个包含幻灯片的演示文稿，添加带画框的图像并对其应用动画。
### **VSTO 2008 示例**
使用 VSTO 2008，执行以下步骤：

1. 创建演示文稿。
1. 添加空白幻灯片。
1. 向幻灯片添加一个图片形状。
1. 对图片应用动画。
1. 将演示文稿写入磁盘。

**使用 VSTO 创建的输出演示文稿** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//创建空演示文稿
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//添加空白幻灯片
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//添加画框
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//对画框应用动画
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//保存演示文稿
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET 示例**
使用 Aspose.Slides for .NET，执行以下步骤：

1. 创建演示文稿。
1. 访问第一张幻灯片。
1. 向图片集合添加图像。
1. 向幻灯片添加一个图片形状。
1. 对图片应用动画。
1. 将演示文稿写入磁盘。

**使用 Aspose.Slides 创建的输出演示文稿** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// 创建一个空的演示文稿
using (Presentation pres = new Presentation())
{
    // 访问第一张幻灯片
    ISlide slide = pres.Slides[0];

    // 向演示文稿的图像集合添加图像
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 添加一个高度和宽度与图像匹配的画框
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // 获取幻灯片的主动画序列
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 向画框添加从左飞入的动画效果
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // 保存演示文稿
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```