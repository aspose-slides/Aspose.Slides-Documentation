---
title: 使用 .NET 管理演示文稿中的图像变换效果
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
description: "使用 Aspose.Slides for .NET 对图片框的图像变换效果进行应用、链式处理、检查、删除和验证。"
---
## **概述**

Aspose.Slides 将图片调整表示为有序的图像变换操作集合。对于图片框，先获取框的 [ISlidesPicture](https://reference.aspose.com/slides/zh/net/aspose.slides/islidespicture/) 并访问 [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/zh/net/aspose.slides/islidespicture/imagetransform/)。返回的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/) 让您可以追加、枚举、检查、移除和清除效果，而无需重新写入原始图像字节。

本文展示了亮度与对比度、颜色变换、模糊、透明度、有序效果链、有效值、移除以及 PPTX 循环验证的完整工作流。

## **理解效果所有权与图像复用**

图像资源和显示它的图片是不同的对象：

- [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 存储或引用演示文稿拥有的源图像数据。
- [ISlidesPicture](https://reference.aspose.com/slides/zh/net/aspose.slides/islidespicture/) 属于图片填充，引用图像资源并存储图像变换集合。
- [IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 是拥有相应图片填充、几何、裁剪设置以及其他框级格式的幻灯片形状。

因此，图像变换操作不会修改 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 中的字节。当同一个 `IPPImage` 被多次传递给 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addpictureframe/) 时，每个新图片框都会获得自己的 `ISlidesPicture` 和自己的变换集合。对一个框应用灰度并不会让其他框变为灰度，即使它们复用了相同的嵌入图像资源。

相同的 `ISlidesPicture.ImageTransform` 模型也被其他图片填充使用，例如形状或幻灯片背景。下面的示例重点关注图片框。

## **使用有效的参数范围和单位**

演示的方法使用以下语义范围和单位。即使特定库版本未立即拒绝所有超出范围的值，也请保持在这些范围内；目标演示文稿格式可能在保存时或 PowerPoint 打开文件时对无效数据进行标准化、忽略或拒绝。

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 保持组件不变。 |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | 无数值参数。Alpha 保持不变。 |
| [AddDuotoneEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 两种颜色分别用于暗像素和亮像素。`System.Drawing.Color` 的 RGB 和 Alpha 通道取值范围为 `0` 到 `255`。 |
| [AddTintEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue 为 `0`（含）到 `360`（不含）度；amount 为 `-100` 到 `100`，百分比。 |
| [AddHSLEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue 为 `0`（含）到 `360`（不含）度；饱和度和亮度为 `-100` 到 `100`，百分比。 |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 替换颜色的通道值范围为 `0` 到 `255`。已有的 Alpha 保持不变。 |
| [AddBlurEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius 为非负数，单位为点；`grow` 为布尔值，控制模糊内容是否可以超出原始边界。 |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非负百分比。使用 `0` 到 `100` 表示普通不透明度缩放：`0` 为完全透明，`100` 保持现有 Alpha。 |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` 到 `100`，百分比 Alpha 阈值。低于阈值的变为透明；等于或高于阈值的变为不透明。 |

对于固定 Alpha 调制，透明度和不透明度是互补的。例如，35% 透明度对应 65% 的 Alpha 调制量。

## **应用亮度与对比度**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) 返回一个 [IBrightnessContrast](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/ibrightnesscontrast/) 操作。其标量设置在创建操作时提供。[IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/brightnesscontrast/geteffective/) 返回计算后的只读值，可用于检查或记录。

下面的示例将亮度提升 15%，对比度提升 20%，随后在不修改嵌入图像的情况下渲染预览：

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

[BrightnessContrast](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 的图片效果扩展，移植性不如标准 DrawingML 亮度效果。当亮度和对比度在 PPTX 循环后必须保持可编辑时，使用 [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 并在重新打开文件后验证结果。格式限制章节对该区别作了更详细的说明。

## **应用颜色变换**

颜色效果可以独立地应用于复用同一图像资源的不同图片框。下面的示例创建五个框，并分别应用灰度、双音、色调、HSL 调整和颜色替换。

[IDuotone](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iduotone/) 包含两个独立可编辑的颜色参数：`Color1` 映射暗像素，`Color2` 映射亮像素。这使其成为一个设置比单一标量更复杂的有效示例。

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) 将每个像素的颜色替换为固定颜色，同时保留 Alpha。它不同于 [AddColorChangeEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)，后者将一种源颜色映射到另一种颜色，并公开源色和目标色的格式。

## **添加模糊、透明度和 Alpha 效果**

[AddBlurEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) 影响所有颜色通道，包括 Alpha。当模糊边缘可能超出原始图片边界时，将 `grow` 设为 `true`。

若需统一透明度，使用 [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)。它会乘以每个已有的 Alpha 值，使部分透明像素保持比例差异。[AddAlphaReplaceEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) 则为所有像素分配同一 Alpha 值。[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) 根据阈值将 Alpha 转换为两级。

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

其他无参 Alpha 操作包括 [AddAlphaCeilingEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)，将所有非零 Alpha 设为完全不透明；[AddAlphaFloorEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)，将低于 100% 的 Alpha 设为完全透明；以及 [AddAlphaInverseEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)，将 Alpha 变为 `100% - alpha`。

## **构建有序的效果链**

每个 `Add...Effect` 方法都会把新操作追加到集合的末尾。渲染器按顺序使用集合：操作 0 的输出成为操作 1 的输入，依此类推。因此，顺序不同的相同操作可能产生不同的图像。

例如，先灰度后色调会先去除色彩信息再对亮度结果重新着色；先色调后灰度则会再次去除色调。类似地，Alpha 替换可以覆盖之前操作计算的 Alpha，而 Alpha 调制则保留相对差异。

下面的示例构建了一个四操作链，保存为 PPTX，重新打开演示文稿，检查操作类型及其顺序，并渲染重新打开的结果：

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

集合并未强制将颜色、Alpha 和模糊操作限制在不同的链中。它们可以组合使用，但并非所有组合都有意义。固定颜色替换会去除早期颜色效果产生的 RGB 变化；在双音后应用灰度会去除两种选定颜色；Alpha 天花板、地板、替换或二级操作可能会丢弃之前创建的 Alpha 细节。请根据所需的像素处理顺序构建链，而不是把链项视为无序的格式标记。

## **检查可编辑和有效值**

可编辑的操作是存储在 `ISlidesPicture.ImageTransform` 中的对象。根据效果的不同，它可能直接公开可写成员。例如，[IBlur](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iblur/) 公开可写的 `Radius` 和 `Grow`，[IAlphaModulateFixed](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/ialphamodulatefixed/) 公开 `Amount`，[IAlphaBiLevel](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/ialphabilevel/) 公开 `Threshold`。像 [IDuotone](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iduotone/) 这样的颜色效果会暴露可变的 [IColorFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/icolorformat/) 对象。

某些操作接口（包括 [IBrightnessContrast](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/ihsl/)、[ITint](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/itint/) 和 [IAlphaReplace](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/ialphareplace/)）不将创建时的标量暴露为可写属性。若要更改这些设置，需要移除该操作并在所需位置添加替代操作。

`GetEffective()` 返回的有效数据是计算后的只读值。它用于解析主题相关颜色并读取渲染器使用的标准化值，但并非另一个编辑表面。下面的示例枚举链并在相应 API 提供时检查有效值：

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

没有参数的效果（如灰度、Alpha 天花板、Alpha 反转）仍然拥有有效数据对象，只是没有可打印的标量设置。它们在集合中的存在与位置就是重要信息。

## **移除或清除图像变换**

使用 [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) 按索引移除单个操作。由于移除后索引会变化，请先搜索目标再在枚举后移除。使用 `Clear()` 可以移除整个链。

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

移除或清除变换仅改变图片格式，不会删除、重新压缩或以其他方式改变复用的 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 资源。

## **考虑演示文稿格式和导出目标**

图像变换源自 DrawingML，因此 PPTX 是效果链的首选可编辑格式。即使使用 PPTX，也并非每个操作的可移植性完全相同：

- 标准 DrawingML 操作（如亮度、灰度、双音、色调、HSL、模糊以及常见 Alpha 操作）最有可能在 PPTX 循环后仍然可用。始终重新打开生成的文件并检查集合，以满足保持的需求。
- [BrightnessContrast](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 的扩展，而非标准 DrawingML 亮度操作。它可用于内存渲染，但保存并重新打开 PPTX 后不保证仍以可编辑的 [IBrightnessContrast](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/ibrightnesscontrast/) 形式存在。请优先使用 [AddLuminanceEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 实现持久的亮度和对比度调整。
- 二进制 PPT 格式早于完整的 DrawingML 效果模型。保存为 PPT 可能会省略不支持的操作、将链缩减为受支持的子集，或近似外观。不要将 PPT 用作复杂可编辑链的验证格式。
- 渲染为 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他可视输出时，会将支持的链应用到渲染结果。这些输出不包含可编辑的 `IImageTransformOperationCollection`；光栅格式会将结果展平成像素，文档/向量导出会存储其自己的渲染表示。
- 效果并不会使链接的图像变为自包含。渲染链接图片仍依赖于加载演示文稿时链接资源的可用性。

不同的演示文稿消费端在处理边缘情况时可能表现不同，尤其是当多个 Alpha 或颜色量化操作组合使用时。对于关键输出，请使用生产环境中相同的 Aspose.Slides 版本同时测试可编辑循环和最终导出格式。

## **常见问答**

**图像变换效果会修改嵌入的图像数据吗？**

不会。操作属于图片填充使用的 `ISlidesPicture`。底层的 `IPPImage` 字节保持不变。

**复用同一图像的两个图片框会共享它们的效果吗？**

不会。复用 `IPPImage` 只避免了图像数据的重复，但每个图片框通常都有单独的 `ISlidesPicture` 和图像变换集合。

**可以同时组合颜色、模糊和 Alpha 效果吗？**

可以。集合允许它们在同一有序链中存在。请考虑每个操作对前一个操作输出的影响，因为替换和阈值操作可能会丢弃之前的颜色或 Alpha 细节。

**为什么有效值是只读的？**

有效数据表示用于渲染的计算值，包括解析后的颜色。请在变换集合中编辑具备可写成员的操作；若不存在可写属性，则需要移除该操作并添加具有新创建参数的替代操作。

**使用哪种格式可以保留变换链？**

使用 PPTX 并通过重新打开文件进行验证。传统 PPT 无法完整表示 DrawingML 效果模型，渲染导出格式仅保留外观而不保留可编辑的变换操作。