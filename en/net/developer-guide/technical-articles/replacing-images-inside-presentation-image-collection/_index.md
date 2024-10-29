---
title: Replacing Images inside Presentation Image Collection
type: docs
weight: 110
url: /net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for .NET makes it possible to replace the images added in slide shapes. This article explains how to replace the image added in presentation image collection using different approaches.

{{% /alert %}} 
## **Replacing Image inside Presentation Image Collection**
Aspose.Slides for .NET provides a simple API methods for replacing the images inside presentation image collection. Please follow the steps below:

1. Load the presentation file with image inside it using [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Load an image from file in byte array.
1. Replace the target image with new image in byte array
1. In second approach load the image in Image object and replace the target image with loaded image.
1. In third approach replace the image with already added image in presentation image collection.
1. Write the modified presentation as a PPTX file.

```c#
//Instantiate the presentation
using Presentation presentation = new Presentation("presentation.pptx");

//the first way
byte[] data = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(data);

//the second way
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

//the third way
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

//Save the presentation
presentation.Save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
```

