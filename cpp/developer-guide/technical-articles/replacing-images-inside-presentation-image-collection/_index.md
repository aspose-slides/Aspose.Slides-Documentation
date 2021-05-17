---
title: Replacing Images inside Presentation Image Collection
type: docs
weight: 90
url: /cpp/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for C++ makes it possible to replace the images added in slide shapes. This article explains how to replace the image added in presentation image collection using different approaches.

{{% /alert %}} 
## **Replacing Image inside Presentation Image Collection**
Aspose.Slides for C++ provides a simple API methods for replacing the images inside presentation image collection. Please follow the steps below:

1. Load the presentation file with an image inside it using the [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Load an image from a file in a byte array.
1. Replace the target image with the new image in the byte array.
1. In the second approach load the image in an [Image](https://apireference.aspose.com/slides/cpp/class/system.drawing.image) object and replace the target image with the loaded image.
1. In the third approach replace the image with the already added image in the presentation image collection.
1. Write the modified presentation as a PPTX file.

``` cpp
// Instantiate the presentation
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"presentation.pptx");

// The first way
ArrayPtr<uint8_t> data = ReadAllBytes(u"image0.jpeg");
SharedPtr<IPPImage> oldImage = presentation->get_Images()->idx_get(0);
oldImage->ReplaceImage(data);

// The second way
SharedPtr<Image> newImage = Image::FromFile(u"image1.png");
oldImage = presentation->get_Images()->idx_get(1);
oldImage->ReplaceImage(newImage);

// The third way
oldImage = presentation->get_Images()->idx_get(2);
oldImage->ReplaceImage(presentation->get_Images()->idx_get(3));

// Save the presentation
presentation->Save(u"c:\\Presentations\\TestSmart.pptx", SaveFormat::Pptx);
```




