---
title: Manage Image Transform Effects in Presentations with C++
linktitle: Image Transform Effects
type: docs
weight: 11
url: /cpp/image-transform-effects/
keywords:
- image transform
- picture effect
- brightness
- contrast
- grayscale
- duotone
- tint
- HSL
- color replacement
- blur
- transparency
- alpha effect
- effect chain
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Apply, chain, inspect, remove, and verify image transform effects for picture frames with Aspose.Slides for C++."
---

## **Overview**

Aspose.Slides represents picture adjustments as an ordered collection of image transform operations. For a picture frame, start with the frame's [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) and access [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/). The returned [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) lets you append, enumerate, inspect, remove, and clear effects without rewriting the original image bytes.

This article demonstrates a complete workflow for brightness and contrast, color transformations, blur, transparency, ordered effect chains, effective values, removal, and PPTX round-trip verification.

## **Understand Effect Ownership and Image Reuse**

An image resource and the picture that displays it are different objects:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) stores or references the source image data owned by the presentation.
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) belongs to a picture fill and refers to an image resource while storing the image transform collection.
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) is the slide shape that owns the relevant picture fill, geometry, crop settings, and other frame-level formatting.

Therefore, image transform operations do not modify the bytes in [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/). When the same `IPPImage` is passed to [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) more than once, each new picture frame receives its own `ISlidesPicture` and its own transform collection. Applying grayscale to one frame does not make the other frames grayscale, even though all of them reuse the same embedded image resource.

The same `ISlidesPicture::get_ImageTransform` model is also used by other picture fills, such as a shape or slide background. The examples below focus on picture frames.

## **Use Valid Parameter Ranges and Units**

The demonstrated methods use the following semantic ranges and units. Keep values in these ranges even if a particular library version does not reject every out-of-range value immediately; the target presentation format may normalize, omit, or reject invalid data during save or when PowerPoint opens the file.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` through `100`, percent; `0` leaves the component unchanged. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | No numeric parameters. Alpha is unchanged. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Two colors for dark and light pixels. RGB and alpha channels in `System::Drawing::Color` use `0` through `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue is `0` inclusive through `360` exclusive, in degrees; amount is `-100` through `100`, percent. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue is `0` inclusive through `360` exclusive, in degrees; saturation and luminance are `-100` through `100`, percent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | The replacement color uses channel values from `0` through `255`. Existing alpha values are unchanged. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius is nonnegative and is measured in points; `grow` controls whether blurred content may extend outside the original bounds. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nonnegative percent. Use `0` through `100` for ordinary opacity scaling: `0` is fully transparent and `100` preserves the existing alpha. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` through `100`, percent opacity. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` through `100`, percent alpha threshold. Values below it become transparent; values at or above it become opaque. |

For fixed alpha modulation, transparency and opacity are complementary. For example, 35% transparency corresponds to an alpha modulation amount of 65%.

## **Apply Brightness and Contrast**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) returns an [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) operation. Its scalar settings are supplied when the operation is created. The `IBrightnessContrast::GetEffective` method returns calculated read-only values that can be inspected or logged.

The following example increases brightness by 15% and contrast by 20%, then renders a preview without modifying the embedded image:

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

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) is an Office 2010 picture-effect extension and is less portable than the standard DrawingML luminance effect. When brightness and contrast must remain editable after a PPTX round trip, use [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) and verify the result after reopening the file. The format limitations section explains this distinction in more detail.

## **Apply Color Transformations**

Color effects can be applied independently to different picture frames that reuse one image resource. The following example creates five frames and applies grayscale, duotone, tint, HSL adjustment, and color replacement.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) contains two independently editable color parameters: `get_Color1` maps dark pixels, while `get_Color2` maps light pixels. This makes it a useful example of an effect whose settings are more complex than a single scalar value.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) replaces every pixel's color with one fixed color while preserving alpha. It is different from [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), which maps one source color to another and exposes both source and target color formats.

## **Add Blur, Transparency, and Alpha Effects**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) affects all color channels, including alpha. Set `grow` to `true` when the blurred edge may extend beyond the original picture bounds.

For uniform transparency, use [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). It multiplies every existing alpha value, so partially transparent pixels remain proportionally different. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) instead assigns one alpha value to all pixels. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) converts alpha to two levels based on a threshold.

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

Other parameter-free alpha operations include [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), which makes every nonzero alpha fully opaque; [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), which makes every alpha below 100% fully transparent; and [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), which changes alpha to `100% - alpha`.

## **Build an Ordered Effect Chain**

Every `Add...Effect` method appends a new operation to the end of the collection. The renderer uses the collection as an ordered pipeline: the output of operation 0 becomes the input of operation 1, and so on. Consequently, the same operations in a different order can produce a different image.

For example, grayscale followed by tint first removes chromatic information and then recolors the luminance result. Tint followed by grayscale removes the tint again. Similarly, alpha replacement can override alpha values calculated by earlier operations, while alpha modulation preserves their relative differences.

The following example builds a four-operation chain, saves it as PPTX, reopens the presentation, checks both the operation types and their order, and renders the reopened result:

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

The collection does not impose a compatibility matrix that restricts color, alpha, and blur operations to separate chains. They can be combined, but combinations are not always useful. A fixed color replacement removes RGB variation produced by earlier color effects; grayscale after duotone removes the two selected colors; and alpha ceiling, floor, replacement, or bi-level operations can discard alpha detail created earlier. Build the chain according to the desired pixel-processing sequence rather than treating its items as unordered formatting flags.

## **Inspect Editable and Effective Values**

An editable operation is the object stored in `ISlidesPicture::get_ImageTransform`. Depending on the effect, it may expose writable members directly. For example, [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) exposes `set_Radius` and `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) exposes `set_Amount`, and [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) exposes `set_Threshold`. Color effects such as [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) expose mutable [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/) objects.

Some operation interfaces, including [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/), and [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/), do not expose their creation scalars as writable properties. To change those settings, remove the operation and add a replacement at the required position.

Effective data returned by `GetEffective()` is calculated and read-only. It is useful for resolving theme-dependent colors and reading the normalized values that the renderer uses, but it is not another editing surface. The following example enumerates the chain and inspects effective values for several common operations:

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

Parameter-free effects such as grayscale, alpha ceiling, and alpha inverse still have an effective-data object, but there are no scalar settings to print. Their presence and position in the collection are the important information.

## **Remove or Clear Image Transforms**

Use [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) to remove one operation by index. Because indexes shift after removal, search for the target first and remove it after enumeration. Use `Clear()` to remove the entire chain.

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

Removing or clearing transforms changes only the picture formatting. It does not delete, recompress, or otherwise alter the reused [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) resource.

## **Consider Presentation Formats and Export Targets**

Image transforms originate in DrawingML, so PPTX is the preferred editable format for effect chains. Even with PPTX, not every operation has identical portability:

- Standard DrawingML operations such as luminance, grayscale, duotone, tint, HSL, blur, and common alpha operations have the best chance of surviving a PPTX round trip. Always reopen the generated file and inspect the collection when preservation is a requirement.
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) is an Office 2010 extension rather than the standard DrawingML luminance operation. It can be used for in-memory rendering, but it is not guaranteed to remain as an editable [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) after saving and reopening PPTX. Prefer [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) for persistent brightness and contrast adjustments.
- The binary PPT format predates the full DrawingML effect model. Saving to PPT can omit unsupported operations, reduce a chain to a supported subset, or approximate the appearance. Do not use PPT as the verification format for a complex editable chain.
- Rendering to PNG, JPEG, TIFF, PDF, SVG, HTML, or other visual output applies the supported chain to the rendered appearance. Those outputs do not contain an editable `IImageTransformOperationCollection`; raster formats flatten the result into pixels, and document or vector exports store their own rendering representation.
- Effects do not make a linked image self-contained. Rendering a linked picture still depends on the linked resource being available when the presentation is loaded.

Different presentation consumers may render edge cases differently, especially when several alpha or color-quantizing operations are combined. For critical output, test both the editable round trip and the final export format with the same Aspose.Slides version used in production.

## **FAQ**

**Do image transform effects modify the embedded image data?**

No. The operations belong to the `ISlidesPicture` used by the picture fill. The underlying `IPPImage` bytes remain unchanged.

**Will two picture frames that reuse the same image share their effects?**

No. Reusing an `IPPImage` avoids duplicate image data, but each picture frame normally has a separate `ISlidesPicture` and image transform collection.

**Can color, blur, and alpha effects be combined?**

Yes. The collection accepts them in one ordered chain. Consider what each operation does to the output of the previous one because replacement and threshold operations may discard earlier color or alpha detail.

**Why are effective values read-only?**

Effective data represents calculated values used for rendering, including resolved colors. Edit the operation stored in the transform collection where writable members exist; otherwise remove it and add a replacement with new creation parameters.

**Which format should I use to preserve a transform chain?**

Use PPTX and verify the file by reopening it. Legacy PPT cannot represent the full DrawingML effect model, and rendered export formats preserve appearance rather than editable transform operations.
