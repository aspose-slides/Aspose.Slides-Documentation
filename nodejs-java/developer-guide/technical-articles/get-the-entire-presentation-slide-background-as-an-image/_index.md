---
title: Get the Entire Presentation Slide Background as an Image
type: docs
weight: 95
url: /java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slide
- background
- slide background
- background to an image
- PowerPoint
- PPT
- PPTX
- PowerPoint presentation
- Java
- Aspose.Slides for Java
---

In PowerPoint presentations, the slide background can consist of many elements. In addition to the image set as the [slide background](/slides/java/presentation-background/), the final background can be influenced by the presentation theme, color scheme, and the shapes placed on the master slide and layout slide.

Aspose.Slides for Java does not provide a simple method to extract the entire presentation slide background as an image, but you can follow the steps below to do this:
1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
1. Get the slide size from the presentation.
1. Select a slide.
1. Create a temporary presentation.
1. Set the same slide size in the temporary presentation.
1. Clone the selected slide into the temporary presentation.
1. Delete the shapes from the cloned slide.
1. Convert the cloned slide to an image.

The following code example extracts the entire presentation slide background as an image.
```javascript
    var slideIndex = 0;
    var imageScale = 1;
    var presentation = new  aspose.slides.Presentation("sample.pptx");
    var slideSize = presentation.getSlideSize().getSize();
    var slide = presentation.getSlides().get_Item(slideIndex);
    var tempPresentation = new  aspose.slides.Presentation();
    var slideWidth = slideSize.getWidth();
    var slideHeight = slideSize.getHeight();
    tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
    var clonedSlide = tempPresentation.getSlides().addClone(slide);
    clonedSlide.getShapes().clear();
    var background = clonedSlide.getImage(imageScale, imageScale);
    background.save("output.png", aspose.slides.ImageFormat.Png);
    tempPresentation.dispose();
    presentation.dispose();
```
