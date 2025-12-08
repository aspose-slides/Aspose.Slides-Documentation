---
title: 使用 C# 管理演示文稿背景
linktitle: 幻灯片背景
type: docs
weight: 20
url: /zh/net/presentation-background/
keywords:
- 演示文稿背景
- 幻灯片背景
- 纯色
- 渐变颜色
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

纯色、渐变和图像是幻灯片背景的常用选择。您可以为**普通幻灯片**（单个幻灯片）或**母版幻灯片**（一次应用于多个幻灯片）设置背景。

![PowerPoint 背景](powerpoint-background.png)

## **为普通幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿中的特定幻灯片设置纯色背景，即使该演示文稿使用了母版幻灯片。此更改仅适用于所选幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 设置为 `Solid`。
4. 在 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) 上使用 [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) 属性来指定纯色背景颜色。
5. 保存修改后的演示文稿。

下面的 C# 示例演示了如何将蓝色纯色设置为普通幻灯片的背景：
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


## **为母版幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿的母版幻灯片设置纯色背景。母版幻灯片充当模板，控制所有幻灯片的格式，因此当您为母版幻灯片的背景选择纯色时，它会应用于每个幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将母版幻灯片的 [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/)（通过 `masters`）设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 设置为 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) 指定纯色背景颜色。
5. 保存修改后的演示文稿。

下面的 C# 示例演示了如何将森林绿设为母版幻灯片的纯色背景：
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

渐变是一种通过颜色逐渐变化实现的图形效果。将其用作幻灯片背景时，能够让演示文稿看起来更具艺术感和专业感。Aspose.Slides 允许您为幻灯片设置渐变颜色作为背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 设置为 `Gradient`。
4. 在 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) 上使用 [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) 属性配置所需的渐变设置。
5. 保存修改后的演示文稿。

下面的 C# 示例演示了如何将渐变颜色设置为幻灯片的背景：
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


## **将图像设为幻灯片背景**

除了纯色和渐变填充，Aspose.Slides 还允许您使用图像作为幻灯片背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 设置为 `Picture`。
4. 加载要用作幻灯片背景的图像。
5. 将图像添加到演示文稿的图像集合中。
6. 在 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) 上使用 [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) 属性将图像指定为背景。
7. 保存修改后的演示文稿。

下面的 C# 示例演示了如何将图像设为幻灯片的背景：
```c#
// 创建 Presentation 类的实例。
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 设置背景图像属性。
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // 加载图像。
    IImage image = Images.FromFile("Tulips.jpg");
    // 将图像添加到演示文稿的图像集合中。
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // 将演示文稿保存到磁盘。
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```


下面的代码示例演示了如何将背景填充类型设置为平铺图片并修改平铺属性：
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

了解更多：[**将图片平铺为纹理**](/slides/zh/net/shape-formatting/#tile-picture-as-texture)。

{{% /alert %}}

### **更改背景图像透明度**

您可能希望调整幻灯片背景图像的透明度，以突出幻灯片内容。下面的 C# 代码展示了如何更改幻灯片背景图像的透明度：
```cs
var transparencyValue = 30; // 例如。

// 获取图片变换操作的集合。
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// 查找已有的固定百分比透明度效果。
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// 设置新的透明度值。
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

使用 [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/) 类的 `background` 属性，您可以获取幻灯片的有效背景。

下面的 C# 示例演示了如何获取幻灯片的有效背景值：
```cs
// 创建 Presentation 类的实例。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // 检索有效的背景，考虑母版、布局和主题。
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **常见问题**

**我可以重置自定义背景并恢复主题/布局背景吗？**

可以。移除幻灯片的自定义填充后，背景将再次从相应的 [layout](/slides/zh/net/slide-layout/)/[master](/slides/zh/net/slide-master/) 幻灯片（即 [theme background](/slides/zh/net/presentation-theme/)）继承。

**如果我之后更改演示文稿的主题，背景会怎样？**

如果幻灯片拥有自己的填充，它将保持不变。如果背景是从 [layout](/slides/zh/net/slide-layout/)/[master](/slides/zh/net/slide-master/) 继承的，则会更新以匹配新的主题。