---
title: Replacing Images inside Presentation Image Collection
type: docs
weight: 90
url: /cpp/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for C++ allows you to replace the images added in slide shapes. In this article, you will learn how to replace the image added in presentation image collection through different approaches.

{{% /alert %}} 
## **Replacing the Image inside a Presentation Image Collection**
Aspose.Slides for C++ provides a simple API method that allows you to replace the image inside a presentation image collection this way:

1. Load the presentation file with an image inside it using the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Load an image from a file in a byte array.
1. Use one of these approaches:
   - First approach: Replace the target image with the new image in the byte array.
   - Second approach: Load the image in an [Image](https://reference.aspose.com/slides/cpp/class/system.drawing.image) object and replace the target image with the loaded image.
   - Third approach: Replace the image with the already added image in the presentation image collection.
1. Write the modified presentation as a PPTX file.

This sample code shows you how to replace the image in a presentation image collection:

``` cpp
// Instantiate the presentation
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"presentation.pptx");

// The first approach
ArrayPtr<uint8_t> data = ReadAllBytes(u"image0.jpeg");
SharedPtr<IPPImage> oldImage = presentation->get_Images()->idx_get(0);
oldImage->ReplaceImage(data);

// The second approach
SharedPtr<Image> newImage = Image::FromFile(u"image1.png");
oldImage = presentation->get_Images()->idx_get(1);
oldImage->ReplaceImage(newImage);

// The third approach
oldImage = presentation->get_Images()->idx_get(2);
oldImage->ReplaceImage(presentation->get_Images()->idx_get(3));

// Save the presentation
presentation->Save(u"c:\\Presentations\\TestSmart.pptx", SaveFormat::Pptx);
```



