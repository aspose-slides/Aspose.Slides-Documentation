---
title: 在 .NET 中管理演示文稿背景
linktitle: 幻灯片背景
type: docs
weight: 20
url: /zh/net/presentation-background/
keywords:
- 演示文稿背景
- 幻灯片背景
- 实色
- 渐变色
- 图像背景
- 背景透明度
- 背景属性
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 文件中设置动态背景，并提供提升演示效果的代码技巧。"
---

## **概述**

实色、渐变和图像通常用于幻灯片背景。您可以为 **普通幻灯片**（单张幻灯片）或 **母版幻灯片**（一次应用于多张幻灯片）设置背景。

![PowerPoint background](powerpoint-background.png)

## **为普通幻灯片设置实色背景**

Aspose.Slides 允许您为演示文稿中的特定幻灯片设置实色背景，即使该演示文稿使用了母版幻灯片。此更改仅适用于所选幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 设置为 `Solid`。
4. 在 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) 上使用 [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) 属性来指定实色背景颜色。
5. 保存修改后的演示文稿。

以下 C# 示例展示了如何将蓝色实色设置为普通幻灯片的背景：
```cs
// 创建 Presentation 类的实例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 将幻灯片的背景颜色设置为蓝色。
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // 将演示文稿保存到磁盘。
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```


## **为母版幻灯片设置实色背景**

Aspose.Slides 允许您为演示文稿中的母版幻灯片设置实色背景。母版幻灯片充当模板，控制所有幻灯片的格式，因此为母版幻灯片的背景选择实色后，它会应用于每张幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将母版幻灯片的 [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/)（通过 `masters`）设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 设置为 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) 来指定实色背景颜色。
5. 保存修改后的演示文稿。

以下 C# 示例展示了如何将实色（森林绿）设置为母版幻灯片的背景：
```cs
// 创建 Presentation 类的实例。
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // 将母版幻灯片的背景颜色设置为森林绿。
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // 将演示文稿保存到磁盘。
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```


## **为幻灯片设置渐变背景**

渐变是一种通过颜色逐渐变化产生的图形效果。用作幻灯片背景时，渐变可以使演示文稿看起来更具艺术感和专业性。Aspose.Slides 允许您为幻灯片设置渐变颜色背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 设置为 `Gradient`。
4. 在 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) 上使用 [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) 属性来配置所需的渐变设置。
5. 保存修改后的演示文稿。

以下 C# 示例展示了如何将渐变颜色设置为幻灯片的背景：
```cs
// 创建 Presentation 类的实例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 对背景应用渐变效果。
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // 将演示文稿保存到磁盘。
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```


## **将图像设置为幻灯片背景**

除了实色和渐变填充，Aspose.Slides 还允许您使用图像作为幻灯片背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 设置为 `Picture`。
4. 加载您想用作幻灯片背景的图像。
5. 将图像添加到演示文稿的图像集合中。
6. 在 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) 上使用 [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) 属性将图像分配为背景。
7. 保存修改后的演示文稿。

以下 C# 示例展示了如何将图像设置为幻灯片的背景：
```c#
// 创建 Presentation 类的实例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 设置背景图片属性。
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // 加载图片。
    IImage image = Images.FromFile("Tulips.jpg");
    // 将图片添加到演示文稿的图像集合中。
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // 将演示文稿保存到磁盘。
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```


以下代码示例展示了如何将背景填充类型设置为平铺图片并修改平铺属性：
```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // 设置用于背景填充的图像。
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // 将图片填充模式设置为平铺并调整平铺属性。
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}
阅读更多：[**Tile Picture As Texture**](/slides/zh/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **更改背景图像透明度**

您可能需要调整幻灯片背景图像的透明度，以突出幻灯片内容。以下 C# 代码展示了如何更改幻灯片背景图像的透明度：
```cs
var transparencyValue = 30; // 例如。

// Get the collection of picture transform operations.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```


## **获取幻灯片背景值**

Aspose.Slides 提供了 [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) 接口，用于检索幻灯片的有效背景值。该接口公开了有效的 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) 和 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/)。

通过使用 [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/) 类的 `background` 属性，您可以获取幻灯片的有效背景。

以下 C# 示例展示了如何获取幻灯片的有效背景值：
```cs
// 创建 Presentation 类的实例。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // 检索有效背景，考虑母版、布局和主题。
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **常见问题**

**我可以重置自定义背景并恢复主题/布局背景吗？**

可以。移除幻灯片的自定义填充后，背景将再次从相应的 [layout](/slides/zh/net/slide-layout/)/[master](/slides/zh/net/slide-master/) 幻灯片继承（即 [theme background](/slides/zh/net/presentation-theme/)）。

**如果我稍后更改演示文稿的主题，背景会怎样？**

如果幻灯片拥有自己的填充，则保持不变。如果背景是从 [layout](/slides/zh/net/slide-layout/)/[master](/slides/zh/net/slide-master/) 继承的，它将更新以匹配 [new theme](/slides/zh/net/presentation-theme/)。