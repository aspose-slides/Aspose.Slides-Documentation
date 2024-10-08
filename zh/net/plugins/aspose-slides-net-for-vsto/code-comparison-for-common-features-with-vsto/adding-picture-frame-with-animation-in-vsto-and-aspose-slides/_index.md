---
title: 在 VSTO 和 Aspose.Slides 中添加带动画的图片框架
type: docs
weight: 20
url: /net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---

下面的代码示例创建了一个包含幻灯片的演示文稿，添加了一个带图片框架的图像，并对其应用了动画。
## **VSTO**
使用 VSTO，按照以下步骤操作：

1. 创建一个演示文稿。
1. 添加一个空白幻灯片。
1. 向幻灯片添加一个图片形状。
1. 对图片应用动画。
1. 将演示文稿写入磁盘。

``` csharp

 //创建空演示文稿

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//添加一个空白幻灯片

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//添加图片框架

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//对图片框架应用动画

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//保存演示文稿

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
使用 Aspose.Slides for .NET，执行以下步骤：

1. 创建一个演示文稿。
1. 访问第一张幻灯片。
1. 向图片集合添加图片。
1. 向幻灯片添加一个图片形状。
1. 对图片应用动画。
1. 将演示文稿写入磁盘。

``` csharp

 //创建空演示文稿

Presentation pres = new Presentation();

//访问第一张幻灯片

Slide slide = pres.GetSlideByPosition(1);

//向演示文稿的图片集合添加图片对象

Picture pic = new Picture(pres, "pic.jpeg");

//添加图片对象后，图片会被赋予一个唯一的图片 ID

int picId = pres.Pictures.Add(pic);

//添加图片框架

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//对图片框架应用动画

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//保存演示文稿

pres.Write("AsposeAnim.ppt");

``` 
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772946)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip)