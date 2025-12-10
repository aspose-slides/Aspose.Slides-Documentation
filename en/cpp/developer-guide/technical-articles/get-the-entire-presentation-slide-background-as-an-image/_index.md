---
title: Get the Entire Slide Background from a Presentation as an Image
linktitle: Entire Slide Background
type: docs
weight: 95
url: /cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slide background
- final background
- extract background
- entire background
- background to image
- PPT background
- PPTX background
- ODP background
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Extract full slide backgrounds as images from PowerPoint and OpenDocument presentations using Aspose.Slides for C++, streamlining visual workflows."
---

## **Get the Entire Slide Background**

In PowerPoint presentations, the slide background can consist of many elements. In addition to the image set as the [slide background](/slides/cpp/presentation-background/), the final background can be influenced by the presentation theme, color scheme, and the shapes placed on the master slide and layout slide.

Aspose.Slides for C++ does not provide a simple method to extract the entire presentation slide background as an image, but you can follow the steps below to do this:
1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Get the slide size from the presentation.
1. Select a slide.
1. Create a temporary presentation.
1. Set the same slide size in the temporary presentation.
1. Clone the selected slide into the temporary presentation.
1. Delete the shapes from the cloned slide.
1. Convert the cloned slide to an image.

The following code example extracts the entire presentation slide background as an image.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **FAQ**

**Will complex gradients, textures, or picture fills from a master slide be preserved in the resulting background image?**

Yes. Aspose.Slides renders gradient, picture, and texture fills defined on the slide, layout, or master. If you need to isolate the look from inherited masters, [set an own background](/slides/cpp/presentation-background/) on the current slide before exporting.

**Can I add a watermark to the resulting background image before saving it?**

Yes. You can [add a watermark](/slides/cpp/watermark/) shape or image on a working [copy of the slide](/slides/cpp/clone-slides/) (placed behind other content) and then export. This lets you generate a background image with the watermark baked in.

**Can I get the background for a specific layout or master without tying it to an existing slide?**

Yes. Access the desired master or layout, apply it to a [temporary slide](/slides/cpp/clone-slides/) with the required size, and export that slide to obtain the background derived from that layout or master.

**Are there licensing limitations that affect image export?**

Rendering features are fully available with a [valid license](/slides/cpp/licensing/). In evaluation mode, output may include limitations such as a watermark. Activate the license once per process before running batch exports.
