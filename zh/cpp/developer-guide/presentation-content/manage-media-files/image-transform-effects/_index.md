---
title: 使用 C++ 管理演示文稿中的图像转换效果
linktitle: 图像转换效果
type: docs
weight: 11
url: /zh/cpp/image-transform-effects/
keywords:
- 图像转换
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 对图片框的图像转换效果进行应用、链式、检查、删除和验证。"
---
## **概述**

Aspose.Slides 将图片调整表示为有序的图像转换操作集合。对于图片框，首先获取框的 [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) 并访问 [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/)。返回的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) 允许您追加、枚举、检查、删除以及清除效果，而无需重写原始图像字节。

本文演示了亮度和对比度、颜色转换、模糊、透明度、有序效果链、有效值、删除以及 PPTX 循环验证的完整工作流。

## **了解效果所有权和图像复用**

一个图像资源和显示它的图片是不同的对象：

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 存储或引用演示文稿拥有的源图像数据。
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) 属于图片填充并引用图像资源，同时保存图像转换集合。
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) 是幻灯片形状，拥有相关的图片填充、几何、裁剪设置以及其他框级格式。

因此，图像转换操作不会修改 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 中的字节。当同一 `IPPImage` 被多次传递给 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) 时，每个新图片框都会获得自己的 `ISlidesPicture` 和自己的转换集合。对一个框应用灰度不会使其他框变为灰度，即使它们复用相同的嵌入图像资源。

相同的 `ISlidesPicture::get_ImageTransform` 模型也被其他图片填充使用，例如形状或幻灯片背景。下面的示例重点放在图片框上。

## **使用有效的参数范围和单位**

演示的方法使用如下语义范围和单位。即使特定库版本不会立即拒绝每个超出范围的值，也请保持在这些范围内；目标演示文稿格式可能在保存时或 PowerPoint 打开文件时规范化、省略或拒绝无效数据。

| 操作 | 参数 | 有效范围和单位 |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 保持组件不变。 |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | 无 | 无数值参数。Alpha 保持不变。 |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 用于深色和浅色像素的两种颜色。`System::Drawing::Color` 中的 RGB 和 Alpha 通道使用 `0` 到 `255`。 |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 色相范围为 `0`（含）到 `360`（不含），单位为度；量值范围为 `-100` 到 `100`，百分比。 |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 色相范围为 `0`（含）到 `360`（不含），单位为度；饱和度和亮度范围为 `-100` 到 `100`，百分比。 |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 替换颜色使用 `0` 到 `255` 的通道值。现有的 Alpha 值保持不变。 |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 半径为非负值，单位为点；`grow` 控制模糊内容是否可以超出原始边界。 |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非负百分比。使用 `0` 到 `100` 进行普通不透明度缩放：`0` 完全透明，`100` 保持现有 Alpha。 |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` 到 `100`，百分比 Alpha 阈值。低于阈值的像素变为透明；达到或超过阈值的像素变为不透明。 |

对于固定的 Alpha 调制，透明度和不透明度是互补的。例如，35% 透明度对应 65% 的 Alpha 调制量。

## **应用亮度和对比度**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) 返回一个 [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) 操作。其标量设置在创建操作时提供。`IBrightnessContrast::GetEffective` 方法返回计算得到的只读值，可用于检查或记录。

以下示例将亮度提高 15%，对比度提高 20%，随后在不修改嵌入图像的情况下渲染预览：

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 的图片效果扩展，其可移植性低于标准 DrawingML 亮度效果。当亮度和对比度在 PPTX 循环后必须保持可编辑时，请使用 [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 并在重新打开文件后验证结果。格式限制章节对此区别作了更详细的说明。

## **应用颜色转换**

颜色效果可以独立地应用于复用同一图像资源的不同图片框。以下示例创建五个框并分别应用灰度、双音、色调、HSL 调整和颜色替换。

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) 包含两个可独立编辑的颜色参数：`get_Color1` 映射暗像素，`get_Color2` 映射亮像素。这使其成为一个设置比单一标量更复杂的效果示例。

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) 将每个像素的颜色替换为固定颜色，同时保留 Alpha。它不同于 [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)，后者将一种源颜色映射为另一种，并公开源颜色和目标颜色的格式。

### **应用亮度阈值**

亮度阈值可以使扫描页上的淡淡痕迹更容易与背景区分。[AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) 保留中间的灰度阶调。[AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) 将亮度映射为黑或白，而 [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) 对不透明度应用阈值。

亮度阈值范围为 0% 到 100%，含端点。低于阈值的像素变为黑色，达到或超过阈值的像素变为白色。提高阈值会使更多色调变黑，因为更多像素落在阈值以下。

下载 [grayscale-swatches.png](grayscale-swatches.png) 到工作目录。每个标签给出 0 到 255 范围内的原始灰度级别。示例将原始图像放在两份副本旁边，并在演示文稿中保存每份副本的阈值。

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

在 PowerPoint 中打开输出演示文稿以比较这三个框。标记为 96 的样本约有 38% 亮度（96/255）。在 20% 阈值时变为白色，60% 阈值时变为黑色。

![原始灰度样本以及在亮度阈值20%和60%下的黑白结果](luminance-threshold.png)

## **添加模糊、透明度和 Alpha 效果**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) 影响所有颜色通道，包括 Alpha。当模糊边缘可能超出原始图片边界时，将 `grow` 设置为 `true`。

对于均匀透明度，请使用 [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)。它将每个现有 Alpha 值相乘，因此部分透明像素保持比例差异。[AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) 则为所有像素分配单一 Alpha 值。[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) 根据阈值将 Alpha 转换为两级。

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

其他无需参数的 Alpha 操作包括 [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)，它使所有非零 Alpha 完全不透明；[AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)，它使所有低于 100% 的 Alpha 完全透明；以及 [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)，它将 Alpha 变为 `100% - alpha`。

## **构建有序效果链**

每个 `Add...Effect` 方法会将新操作追加到集合的末尾。渲染器将集合视为有序管道：操作 0 的输出成为操作 1 的输入，依此类推。因此，以不同顺序排列相同操作可能产生不同图像。

例如，先灰度后色调会先去除色彩信息再对亮度结果上色；先色调后灰度则会再次去除色调。同样，Alpha 替换可以覆盖早前操作计算的 Alpha 值，而 Alpha 调制则保留它们的相对差异。

以下示例构建四步链，保存为 PPTX，重新打开演示文稿，检查操作类型及其顺序，并渲染重新打开的结果：

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

该集合不强制兼容性矩阵将颜色、Alpha 和模糊操作限制在不同链中。它们可以组合，但组合并非总有用。固定的颜色替换会去除早期颜色效果产生的 RGB 变化；灰度在双音之后会去除两种选定颜色；Alpha 天花板、底部、替换或双级操作会丢弃早期创建的 Alpha 细节。应根据所需的像素处理顺序构建链，而非把项目视为无序的格式标志。


<!-- visual-explanation:image-transform-effects:start -->
[![相同图像先经过灰度再加色调，和先加色调再经过灰度。两个最终的灰度图像具有不同的色调。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*在此示例性的 Aspose.Slides for .NET 26.11 渲染中，220°、25% 的色调对灰度图像无影响。在灰度之前应用相同的色调会产生不同的色调。*
<!-- visual-explanation:image-transform-effects:end -->

## **检查可编辑和有效值**

可编辑的操作是存储在 `ISlidesPicture::get_ImageTransform` 中的对象。根据效果的不同，它可能直接公开可写成员。例如，[IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) 公开 `set_Radius` 和 `set_Grow`，[IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) 公开 `set_Amount`，以及 [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) 公开 `set_Threshold`。像 [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) 这样的颜色效果则公开可变的 [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/) 对象。

某些操作接口，包括 [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/)、[ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/) 和 [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/)，不公开其创建时的标量作为可写属性。若要更改这些设置，需要删除该操作并在所需位置添加替代操作。

`GetEffective()` 返回的有效数据是计算后只读的。它对解析主题相关颜色以及读取渲染器使用的归一化值很有用，但并不是另一个编辑界面。以下示例遍历链并检查多个常见操作的有效值：

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

类似灰度、Alpha 天花板和 Alpha 反转等无需参数的效果仍然拥有有效数据对象，只是没有可打印的标量设置。它们在集合中的存在与位置才是重要信息。

## **移除或清除图像变换**

使用 [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) 可以通过索引删除单个操作。由于删除后索引会移动，建议先搜索目标再在遍历后删除。使用 `Clear()` 可以删除整个链。

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

移除或清除变换仅更改图片的格式化，不会删除、重新压缩或以其他方式更改复用的 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 资源。

## **考虑演示文稿格式和导出目标**

图像变换起源于 DrawingML，因此 PPTX 是效果链的首选可编辑格式。即使使用 PPTX，也并非每个操作都有相同的可移植性：

- 标准 DrawingML 操作（如亮度、灰度、双音、色调、HSL、模糊以及常见 Alpha 操作）最有可能在 PPTX 循环后仍然存在。若需保持可编辑性，请始终重新打开生成的文件并检查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 的扩展，而非标准 DrawingML 亮度操作。它可用于内存渲染，但保存并重新打开 PPTX 后不能保证仍为可编辑的 [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/)。请优先使用 [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 实现持久的亮度和对比度调整。
- 二进制 PPT 格式早于完整的 DrawingML 效果模型。保存为 PPT 可能会省略不受支持的操作、将链缩减为受支持的子集，或近似外观。不要将 PPT 用作复杂可编辑链的验证格式。
- 渲染为 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他可视输出时，会将支持的链应用到渲染结果。这些输出不包含可编辑的 `IImageTransformOperationCollection`；光栅格式会将结果展平成像素，文档或矢量导出会存储其自己的渲染表示。
- 效果不会使链接的图像成为自包含的。渲染链接图片仍依赖于加载演示文稿时链接资源的可用性。

不同的演示文稿阅读器可能对边缘情况的渲染不同，尤其是在组合了多个 Alpha 或颜色量化操作时。对于关键输出，请使用生产环境中相同的 Aspose.Slides 版本同时测试可编辑的循环和最终导出格式。

## **常见问题**

**图片变换效果会修改嵌入的图像数据吗？**

不会。操作属于图片填充使用的 `ISlidesPicture`，底层的 `IPPImage` 字节保持不变。

**复用同一图像的两个图片框会共享它们的效果吗？**

不会。复用 `IPPImage` 可以避免重复的图像数据，但每个图片框通常拥有独立的 `ISlidesPicture` 和图像转换集合。

**颜色、模糊和 Alpha 效果可以组合使用吗？**

可以。集合接受它们在同一有序链中。请考虑每个操作对前一步输出的影响，因为替换和阈值操作可能会丢弃早期的颜色或 Alpha 细节。

**为什么有效值是只读的？**

有效数据表示用于渲染的计算值，包括已解析的颜色。请在转换集合中编辑具有可写成员的操作；否则请删除并以新创建参数添加替代操作。

**应使用哪种格式来保留变换链？**

使用 PPTX 并通过重新打开文件进行验证。传统 PPT 无法完整表示 DrawingML 效果模型，且渲染导出格式只保留外观而不保留可编辑的变换操作。