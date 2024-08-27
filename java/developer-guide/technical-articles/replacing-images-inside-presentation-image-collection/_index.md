---
title: Replacing Images inside Presentation Image Collection
type: docs
weight: 80
url: /java/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for Java makes it possible to replace images in slide shapes. This article explains how to replace an image added to the presentation image collection using different approaches.

{{% /alert %}} 
## **Replacing Image inside Presentation Image Collection**
Aspose.Slides for Java provides a simple API methods for replacing the images inside presentation image collection. Please follow the steps below:

1. Load the presentation file with image inside it using the Presentation class.
1. Load an image from file in byte array.
1. Replace the target image with new image in byte array
1. In second approach load the image in Image object and replace the target image with loaded image.
1. In third approach replace the image with already added image in presentation image collection.
1. Write the modified presentation as a PPTX file.

```java
//Instantiate the presentation
Presentation presentation = new Presentation("presentation.pptx");

//the first way
byte[] data = Files.readAllBytes(Paths.get("image0.jpeg"));
IPPImage oldImage = presentation.getImages().get_Item(0);
oldImage.replaceImage(data);

//the second way
IImage newImage = Images.fromFile("image1.png");
oldImage = presentation.getImages().get_Item(1);
oldImage.replaceImage(newImage);
newImage.dispose();

//the third way
oldImage = presentation.getImages().get_Item(2);
oldImage.replaceImage(presentation.getImages().get_Item(3));

//Save the presentation
presentation.save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
presentation.dispose();
```
