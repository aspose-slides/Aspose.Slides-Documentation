---
title: 使用 .NET 在演示文稿中管理图像变换效果
linktitle: 图像变换效果
type: docs
weight: 11
url: /zh/net/image-transform-effects/
keywords:
- 图像变换
- 图片效果
- 亮度
- 对比度
- 灰度
- 双音
- 色调
- HSL
- 颜色替换
- 模糊
- 透明度
- Alpha 效果
- 效果链
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 对图片框的图像变换效果进行应用、链式、检查、移除和验证。"
---
## **概览**

Aspose.Slides 将图片调整表示为有序的图像变换操作集合。对于图片框，首先获取框的 [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) 并访问 [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/)。返回的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) 允许您追加、枚举、检查、移除和清除效果，而无需重写原始图像字节。

本文演示了亮度和对比度、颜色转换、模糊、透明度、有序效果链、有效值、移除以及 PPTX 循环验证的完整工作流。

## **了解效果所有权和图像复用**

图像资源和显示它的图片是不同的对象：

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 存储或引用演示文稿拥有的源图像数据。
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) 属于图片填充并引用图像资源，同时存储图像变换集合。
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) 是幻灯片形状，拥有相应的图片填充、几何、裁剪设置以及其他框级格式。

因此，图像变换操作不会修改 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 中的字节。当相同的 `IPPImage` 多次传递给 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) 时，每个新图片框都会获得其自己的 `ISlidesPicture` 和其自己的变换集合。对一个框应用灰度不会使其他框变为灰度，即使它们复用了相同的嵌入图像资源。

相同的 `ISlidesPicture.ImageTransform` 模型也用于其他图片填充，例如形状或幻灯片背景。下面的示例专注于图片框。

## **使用有效的参数范围和单位**

演示的方法使用以下语义范围和单位。即使特定库版本未立即拒绝每个超出范围的值，也请保持在这些范围内；目标演示文稿格式可能在保存或 PowerPoint 打开文件时规范化、忽略或拒绝无效数据。

| 操作 | 参数 | 有效范围和单位 |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 保持组件不变。 |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | 无数值参数。Alpha 保持不变。 |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 用于暗像素和亮像素的两种颜色。`System.Drawing.Color` 中的 RGB 和 alpha 通道使用 `0` 到 `255`。 |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 色相为 `0`（含）至 `360`（不含）度；量为 `-100` 到 `100`，百分比。 |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 色相为 `0`（含）至 `360`（不含）度；饱和度和亮度为 `-100` 到 `100`，百分比。 |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 替换颜色使用 `0` 到 `255` 的通道值。现有的 alpha 值保持不变。 |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 半径为非负值，单位为点；`grow` 为布尔值，控制模糊内容是否可以超出原始边界。 |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | `amount` 为非负百分比。使用 `0` 到 `100` 进行普通不透明度缩放：`0` 完全透明，`100` 保留现有 alpha。 |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `alpha` 为 `0` 到 `100`，百分比不透明度。 |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `threshold` 为 `0` 到 `100`，百分比 alpha 阈值。低于阈值的像素变为透明；等于或高于阈值的像素变为不透明。 |

对于固定的 alpha 调制，透明度和不透明度是互补的。例如，35% 透明度对应 alpha 调制量为 65%。

## **应用亮度和对比度**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) 返回一个 [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) 操作。其标量设置在创建操作时提供。[IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) 返回计算后的只读值，可用于检查或记录。

下面的示例将亮度提高 15%，对比度提高 20%，然后在不修改嵌入图像的情况下渲染预览：

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 图片效果扩展，兼容性不如标准 DrawingML 亮度效果。当亮度和对比度在 PPTX 循环后必须保持可编辑时，请使用 [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 并在重新打开文件后验证结果。格式限制部分对此区别作了更详细的说明。

## **应用颜色转换**

颜色效果可以独立地应用于复用同一图像资源的不同图片框。下面的示例创建了五个框并分别应用灰度、双音、色调、HSL 调整和颜色替换。

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) 包含两个可独立编辑的颜色参数：`Color1` 映射暗像素，`Color2` 映射亮像素。这使其成为一个设置比单一标量更复杂的效果示例。

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) 将每个像素的颜色替换为固定颜色，同时保留 alpha。它不同于 [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)，后者将一种源颜色映射到另一种，并暴露源色和目标色格式。

### **应用亮度阈值**

亮度阈值可以让扫描页上的淡淡痕迹更容易与背景区分。[AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) 保留中间的灰度层次。[AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) 将亮度映射为黑或白，而 [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) 对不透明度施加阈值。

亮度阈值范围为 0% 到 100%，包括两端。低于阈值的像素变为黑色。等于或高于阈值的像素变为白色。提升阈值会使更多的色调变为黑色，因为更多像素落在阈值以下。

下载 [grayscale-swatches.png](grayscale-swatches.png) 到工作目录。每个标签给出 0~255 范围内的原始灰度值。示例将原始图像放在两个副本旁边，并将每个副本的阈值保存到演示文稿中。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

在 PowerPoint 中打开输出演示文稿以比较三个框。标记为 96 的色板大约有 38% 的亮度（96/255）。在 20% 阈值时变为白色，在 60% 阈值时变为黑色。

![原始灰度色板旁边的黑白结果，亮度阈值为 20% 和 60%](luminance-threshold.png)

## **添加模糊、透明度和 Alpha 效果**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) 影响所有颜色通道，包括 alpha。当模糊边缘可能超出原始图片边界时，将 `grow` 设为 `true`。

要实现统一透明度，请使用 [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)。它会乘以每个已有的 alpha 值，因此部分透明像素仍保持比例差异。[AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) 则为所有像素分配同一 alpha 值。[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) 根据阈值将 alpha 转换为两级。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

其他无参数的 alpha 操作包括 [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)，它使每个非零 alpha 完全不透明；[AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)，它使每个低于 100% 的 alpha 完全透明；以及 [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)，它将 alpha 改为 `100% - alpha`。

## **构建有序效果链**

每个 `Add...Effect` 方法都会将新操作追加到集合的末尾。渲染器将集合视为有序管道：操作 0 的输出成为操作 1 的输入，依此类推。因此，以不同顺序排列相同操作可能产生不同图像。

例如，先灰度后色调会先去除色彩信息再重新着色亮度结果；先色调后灰度会再次去除色调。同理，alpha 替换可以覆盖早期操作计算的 alpha 值，而 alpha 调制则保留它们的相对差异。

下面的示例构建了四操作链，将其保存为 PPTX，重新打开演示文稿，检查操作类型及其顺序，并渲染重新打开的结果：

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

该集合不强制兼容性矩阵将颜色、alpha 和模糊操作限制在不同链中。它们可以组合，但组合并不总是有用。固定的颜色替换会去除先前颜色效果产生的 RGB 变化；灰度在双音之后会去除两种选定颜色；而 alpha ceiling、floor、replacement 或 bi-level 操作可能会丢弃之前创建的 alpha 细节。请根据所需的像素处理顺序构建链，而不是将其项视为无序的格式标志。

<!-- visual-explanation:image-transform-effects:start -->
[![相同的图像先经过灰度再加色调，和先加色调再经过灰度。两个最终的灰度图像具有不同的色调。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*在此示例性的 Aspose.Slides for .NET 26.11 渲染中，220° 色调、25% 透明度保持灰度图像不变。先应用相同的色调再进行灰度会产生不同的色调。*
<!-- visual-explanation:image-transform-effects:end -->

## **检查可编辑和有效值**

可编辑的操作是存储在 `ISlidesPicture.ImageTransform` 中的对象。根据效果的不同，它可能直接暴露可写成员。例如，[IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) 暴露可写的 `Radius` 和 `Grow`，[IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) 暴露可写的 `Amount`，以及 [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) 暴露可写的 `Threshold`。像 [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) 这样的颜色效果会暴露可变的 [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/) 对象。

包括 [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/)、[ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/) 和 [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/) 在内的某些操作接口并未将其创建时的标量暴露为可写属性。要更改这些设置，需要先移除该操作，再在所需位置添加替代操作。

`GetEffective()` 返回的有效数据是计算得出的只读值。它对解析主题相关颜色和读取渲染器使用的归一化值很有帮助，但并不是另一个编辑界面。以下示例枚举链并在相应 API 提供的地方检查有效值：

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

如灰度、alpha ceiling、alpha inverse 等无参数效果仍然拥有有效数据对象，只是没有可打印的标量设置。它们的存在与在集合中的位置是重要信息。

## **移除或清除图像变换**

使用 [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) 可以按索引移除单个操作。由于移除后索引会改变，建议先搜索目标再在枚举后移除。使用 `Clear()` 可以移除整个链。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

移除或清除变换仅更改图片格式。它不会删除、重新压缩或以其他方式修改复用的 [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 资源。

## **考虑演示文稿格式和导出目标**

图像变换起源于 DrawingML，因此 PPTX 是效果链的首选可编辑格式。即使使用 PPTX，并非所有操作的可移植性完全相同：

- 标准 DrawingML 操作（如亮度、灰度、双音、色调、HSL、模糊以及常见的 alpha 操作）最有可能在 PPTX 循环后仍然存在。对需要保留的情况，请始终重新打开生成的文件并检查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 的扩展，而非标准 DrawingML 亮度操作。它可用于内存渲染，但在保存并重新打开 PPTX 后不保证仍保持为可编辑的 [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/)。请优先使用 [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 以实现持久的亮度和对比度调整。
- 二进制 PPT 格式早于完整的 DrawingML 效果模型。保存为 PPT 可能会省略不受支持的操作、将链缩减为受支持的子集，或对外观进行近似。不要将 PPT 用作复杂可编辑链的验证格式。
- 渲染为 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他可视输出时，会将支持的链应用于渲染后的外观。这些输出不包含可编辑的 `IImageTransformOperationCollection`；光栅格式会将结果展平为像素，文档/矢量导出会存储其自己的渲染表示。
- 效果不会使链接图片成为自包含。渲染链接图片仍然依赖于加载演示文稿时链接资源的可用性。

不同的演示文稿消费方在渲染边缘情况时可能表现不同，尤其是当多个 alpha 或颜色量化操作组合时。对于关键输出，请使用生产环境中相同的 Aspose.Slides 版本同时测试可编辑的循环和最终导出格式。

## **常见问题**

**图像变换效果会修改嵌入的图像数据吗？**

不会。操作属于用于图片填充的 `ISlidesPicture`。底层的 `IPPImage` 字节保持不变。

**复用同一图像的两个图片框会共享它们的效果吗？**

不会。复用 `IPPImage` 可以避免重复的图像数据，但每个图片框通常拥有各自独立的 `ISlidesPicture` 和图像变换集合。

**可以组合颜色、模糊和 alpha 效果吗？**

可以。集合接受它们在同一有序链中。请考虑每个操作对前一个操作输出的影响，因为替换和阈值操作可能会丢弃之前的颜色或 alpha 细节。

**为什么有效值是只读的？**

有效数据代表渲染时使用的计算值，包括已解析的颜色。请在变换集合中编辑具备可写成员的操作；否则请移除该操作并添加使用新创建参数的替代操作。

**使用哪种格式可以保留变换链？**

使用 PPTX 并通过重新打开文件进行验证。传统 PPT 无法表示完整的 DrawingML 效果模型，而渲染的导出格式仅保留外观，不保留可编辑的变换操作。