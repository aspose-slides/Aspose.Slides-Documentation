---
title: 演示文稿背景
type: docs
weight: 20
url: /zh/net/presentation-background/
keywords:
- PowerPoint 背景
- 设置背景
- C#
- Csharp
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中设置 PowerPoint 演示文稿的背景"
---

固体颜色、渐变颜色和图片通常用作幻灯片的背景图像。您可以为 **正常幻灯片**（单个幻灯片）或 **母版幻灯片**（多个幻灯片同时）设置背景。

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **为正常幻灯片设置固体颜色背景**

Aspose.Slides 允许您为演示文稿中的特定幻灯片设置固体颜色作为背景（即使该演示文稿包含母版幻灯片）。背景的更改仅影响所选的幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 枚举设置为 `Solid`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) 中公开的 [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) 属性为背景指定固体颜色。
5. 保存修改后的演示文稿。

这段 C# 代码向您展示了如何将固体颜色（蓝色）设置为正常幻灯片的背景：

```c#
// 创建 Presentation 类的实例
using (Presentation pres = new Presentation())
{

    // 将第一张 ISlide 的背景颜色设置为蓝色
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;
    
    // 将演示文稿写入磁盘
    pres.Save("ContentBG_out.pptx", SaveFormat.Pptx);
}
```

## **为母版幻灯片设置固体颜色背景**

Aspose.Slides 允许您为演示文稿中的母版幻灯片设置固体颜色作为背景。母版幻灯片充当模板，包含和控制所有幻灯片的格式设置。因此，当您选择固体颜色作为母版幻灯片的背景时，该新背景将用于所有幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将母版幻灯片（`Masters`）的 [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 枚举设置为 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) 中公开的 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) 属性为背景指定固体颜色。
5. 保存修改后的演示文稿。

这段 C# 代码向您展示了如何将固体颜色（森林绿）设置为演示文稿中母版幻灯片的背景：

```c#
// 创建 Presentation 类的实例
using (Presentation pres = new Presentation())
{

    // 将母版 ISlide 的背景颜色设置为森林绿
    pres.Masters[0].Background.Type = BackgroundType.OwnBackground;
    pres.Masters[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // 将演示文稿写入磁盘
    pres.Save("SetSlideBackgroundMaster_out.pptx", SaveFormat.Pptx);

}
```

## **为幻灯片设置渐变颜色背景**

渐变是基于颜色逐渐变化的图形效果。渐变颜色用作幻灯片的背景时，使演示文稿看起来更具艺术感和专业性。Aspose.Slides 允许您为演示文稿中的幻灯片设置渐变颜色作为背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 枚举设置为 `Gradient`。
4. 使用 [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) 中公开的 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) 属性指定您首选的渐变设置。
5. 保存修改后的演示文稿。

这段 C# 代码向您展示了如何将渐变颜色设置为幻灯片的背景：

```c#
// 创建 Presentation 类的实例
using (Presentation pres = new Presentation("SetBackgroundToGradient.pptx"))
{

    // 将渐变效果应用于背景
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Gradient;
    pres.Slides[0].Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // 将演示文稿写入磁盘
    pres.Save("ContentBG_Grad_out.pptx", SaveFormat.Pptx);
}
```

## **为幻灯片设置图片作为背景**

除了固体颜色和渐变颜色，Aspose.Slides 还允许您在演示文稿的幻灯片上设置图片作为背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 枚举设置为 `Picture`。
4. 加载要用作幻灯片背景的图片。
5. 将图片添加到演示文稿的图像集合。
6. 使用 [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) 中公开的 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) 属性将图片设置为背景。
7. 保存修改后的演示文稿。

这段 C# 代码向您展示了如何将图片设置为幻灯片的背景：

```c#
// 创建 Presentation 类的实例
using (Presentation pres = new Presentation("SetImageAsBackground.pptx"))
{
    // 设置背景图片的条件
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Picture;
    pres.Slides[0].Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // 加载图像并将其添加到演示文稿的图像集合中
    IImage image = Images.FromFile("Tulips.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    pres.Slides[0].Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // 将演示文稿写入磁盘
    pres.Save("ContentBG_Img_out.pptx", SaveFormat.Pptx);
}
```

### **更改背景图片的透明度**

您可能希望调整幻灯片背景图像的透明度，以突出幻灯片的内容。此 C# 代码向您展示了如何更改幻灯片背景图像的透明度：

```c#
var transparencyValue = 30; // 例如

// 获取图片变换操作的集合
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// 查找具有固定百分比的透明度效果。
var transparencyOperation = null as AlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is AlphaModulateFixed alphaModulateFixed)
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

## **获取幻灯片背景的值**

Aspose.Slides 提供了 [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) 接口，以允许您获取幻灯片背景的有效值。此接口包含关于有效 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat) 和有效 [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/) 的信息。

使用 [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/) 类中 [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/background/) 属性，可以获取幻灯片背景的有效值。

这段 C# 代码向您展示了如何获取幻灯片的有效背景值：

```c#
// 创建 Presentation 类的实例
Presentation pres = new Presentation("SamplePresentation.pptx");

IBackgroundEffectiveData effBackground = pres.Slides[0].Background.GetEffective();

if (effBackground.FillFormat.FillType == FillType.Solid)
    Console.WriteLine("填充颜色: " + effBackground.FillFormat.SolidFillColor);
else
    Console.WriteLine("填充类型: " + effBackground.FillFormat.FillType);
```