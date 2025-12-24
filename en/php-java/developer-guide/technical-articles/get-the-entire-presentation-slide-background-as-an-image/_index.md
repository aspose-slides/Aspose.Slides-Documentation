---
title: Get the Entire Slide Background from a Presentation as an Image
linktitle: Entire Slide Background
type: docs
weight: 95
url: /php-java/get-the-entire-presentation-slide-background-as-an-image/
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
- PHP
- Aspose.Slides
description: "Extract full slide backgrounds as images from PowerPoint and OpenDocument presentations using Aspose.Slides for PHP via Java, streamlining visual workflows."
---

## **Get the Entire Slide Background**

In PowerPoint presentations, the slide background can consist of many elements. In addition to the image set as the [slide background](/slides/php-java/presentation-background/), the final background can be influenced by the presentation theme, color scheme, and the shapes placed on the master slide and layout slide.

Aspose.Slides for PHP via Java does not provide a simple method to extract the entire presentation slide background as an image, but you can follow the steps below to do this:
1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/) class.
1. Get the slide size from the presentation.
1. Select a slide.
1. Create a temporary presentation.
1. Set the same slide size in the temporary presentation.
1. Clone the selected slide into the temporary presentation.
1. Delete the shapes from the cloned slide.
1. Convert the cloned slide to an image.

The following code example extracts the entire presentation slide background as an image.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **FAQ**

**Will complex gradients, textures, or picture fills from a master slide be preserved in the resulting background image?**

Yes. Aspose.Slides renders gradient, picture, and texture fills defined on the slide, layout, or master. If you need to isolate the look from inherited masters, [set an own background](/slides/php-java/presentation-background/) on the current slide before exporting.

**Can I add a watermark to the resulting background image before saving it?**

Yes. You can [add a watermark](/slides/php-java/watermark/) shape or image on a working [copy of the slide](/slides/php-java/clone-slides/) (placed behind other content) and then export. This lets you generate a background image with the watermark baked in.

**Can I get the background for a specific layout or master without tying it to an existing slide?**

Yes. Access the desired master or layout, apply it to a [temporary slide](/slides/php-java/clone-slides/) with the required size, and export that slide to obtain the background derived from that layout or master.

**Are there licensing limitations that affect image export?**

Rendering features are fully available with a [valid license](/slides/php-java/licensing/). In evaluation mode, output may include limitations such as a watermark. Activate the license once per process before running batch exports.
