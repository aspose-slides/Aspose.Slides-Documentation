---
title: Extract Images from Presentation Shapes
linktitle: Image from Shape
type: docs
weight: 100
url: /php-java/extracting-images-from-presentation-shapes/
keywords:
- extract image
- retrieve image
- slide background
- shape background
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Extract images from shapes in PowerPoint and OpenDocument presentations with Aspose.Slides for PHP via Java — quick, code-friendly solution."
---

## **Extract Images from Shapes**

{{% alert color="primary" %}} 

Images are often added to shapes and also frequently used as slides' backgrounds. The image objects are added through [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/), which is a collection of [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) objects.

This article explains how you can extract the images added to presentations. 

{{% /alert %}} 

To extract an image from a presentation, you have to locate the image first by going through every slide and then going through every shape. Once the image is found or identified, you can extract it and save it as a new file. 

```php

```

## **FAQ**

**Can I extract the original image without any cropping, effects, or shape transformations?**

Yes. When you access a shape’s image, you get the image object from the presentation’s [image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/), meaning the original pixels without cropping or styling effects. The workflow goes through the presentation’s image collection and [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) objects, which store the raw data.

**Is there a risk of duplicating identical files when saving many images at once?**

Yes, if you save everything indiscriminately. A presentation’s [image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) can contain identical binary data referenced by different shapes or slides. To avoid duplicates, compare hashes, sizes, or contents of the extracted data before writing.

**How can I determine which shapes are linked to a specific image from the presentation’s collection?**

Aspose.Slides does not store reverse links from [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) to shapes. Build a mapping manually during traversal: whenever you find a reference to an [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), record which shapes use it.

**Can I extract images embedded inside OLE objects, such as attached documents?**

Not directly, because an OLE object is a container. You need to extract the OLE package itself and then analyze its contents using separate tools. Presentation picture shapes work via [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/); OLE is a different object type.
