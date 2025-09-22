---
title: Manage Presentation Backgrounds in C++
linktitle: Slide Background
type: docs
weight: 20
url: /cpp/presentation-background/
keywords:
- presentation background
- slide background
- solid color
- gradient color
- image background
- background transparency
- background properties
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Learn how to set dynamic backgrounds in PowerPoint and OpenDocument files using Aspose.Slides for C++, with code tips to boost your presentations."
---

## **Overview**

Solid colors, gradients, and images are commonly used for slide backgrounds. You can set the background for a **normal slide** (a single slide) or a **master slide** (applies to multiple slides at once).

![PowerPoint background](powerpoint-background.png)

## **Set a Solid Color Background for a Normal Slide**

Aspose.Slides allows you to set a solid color as the background for a specific slide in a presentation—even if the presentation uses a master slide. The change applies only to the selected slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Set the slide’s [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) to `OwnBackground`.
3. Set the slide background [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) to `Solid`.
4. Use the [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) method on [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) to specify the solid background color.
5. Save the modified presentation.

The following C++ example shows how to set a blue solid color as the background for a normal slide:

```cpp
// Create an instance of the Presentation class.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Set the background color of the slide to blue.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save the presentation to disk.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Set a Solid Color Background for the Master Slide**

Aspose.Slides allows you to set a solid color as the background for the master slide in a presentation. The master slide acts as a template that controls formatting for all slides, so when you choose a solid color for the master slide’s background, it applies to every slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Set the master slide’s [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) (via `get_Masters`) to `OwnBackground`.
3. Set the master slide background [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) to `Solid`.
4. Use the [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) method to specify the solid background color.
5. Save the modified presentation.

The following C++ example shows how to set a solid color (forest green) as the background for a master slide:

```cpp
// Create an instance of the Presentation class.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Set the background color for the Master slide to Forest Green.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Save the presentation to disk.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Set a Gradient Background for a Slide**

A gradient is a graphical effect created by a gradual change in color. When used as a slide background, gradients can make presentations look more artistic and professional. Aspose.Slides allows you to set a gradient color as the background for slides.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Set the slide’s [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) to `OwnBackground`.
3. Set the slide background [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) to `Gradient`.
4. Use the [get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_gradientformat/) method on [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) to configure your preferred gradient settings.
5. Save the modified presentation.

The following C++ example shows how to set a gradient color as the background for a slide:

```cpp
// Create an instance of the Presentation class.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Apply a gradient effect to the background.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Save the presentation to disk.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Set an Image as a Slide Background**

In addition to solid and gradient fills, Aspose.Slides allows you to use images as slide backgrounds.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. Set the slide’s [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) to `OwnBackground`.
3. Set the slide background [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) to `Picture`.
4. Load the image you want to use as the slide background.
5. Add the image to the presentation’s image collection.
6. Use the [get_PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_picturefillformat/) method on [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) to assign the image as the background.
7. Save the modified presentation.

The following C++ example shows how to set an image as the background for a slide:

```cpp
// Create an instance of the Presentation class.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Set background image properties.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Load the image.
auto image = Images::FromFile(u"Tulips.jpg");
// Add the image to the presentation's image collection.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Save the presentation to disk.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The following code sample shows how to set the background fill type to a tiled picture and modify the tiling properties:

```cpp
auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}

Read more: [**Tile Picture As Texture**](/slides/cpp/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Change the Background Image Transparency**

You may want to adjust the transparency of a slide's background image to make the contents of the slide stand out. The following C++ code shows you how to change the transparency for a slide background image:

```cpp
auto transparencyValue = 30; // For example.

// Get the collection of picture transform operations.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Find an existing fixed-percentage transparency effect.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **Get the Slide Background Value**

Aspose.Slides provides the [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/) interface for retrieving a slide’s effective background values. This interface exposes the effective [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) and [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/).

Using the [BaseSlide](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/) class’s `get_Background` method, you can obtain the effective background for a slide.

The following C++ example shows how to get a slide’s effective background value:

```cpp
// Create an instance of the Presentation class.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Retrieve the effective background, taking into account master, layout, and theme.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```
