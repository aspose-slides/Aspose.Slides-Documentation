---
title: Convert PowerPoint PPT to JPG in Python
linktitle: Convert PowerPoint PPT to JPG
type: docs
weight: 60
url: /python-net/convert-powerpoint-to-jpg/
keywords: "python ppt to image, Convert PowerPoint Presentation, JPG, JPEG, PowerPoint to JPG, PowerPoint to JPEG, PPT to JPG, PPTX to JPG, PPT to JPEG, PPTX to JPEG, Python, Aspose.Slides"
description: "Convert PowerPoint to JPG in Python. Save slide as JPG image"
---

## **About PowerPoint to JPG Conversion**
With [**Aspose.Slides .NET API**](https://products.aspose.com/slides/python-net/) you can convert PowerPoint PPT or PPTX presentation to JPG image in Python. It is also possible to convert PPT/PPTX to BMP, PNG or SVG in Python. With this features it's easy to implement your own presentation viewer, create  the thumbnail for every slide. This may be useful if you want to protect presentation slides from copywriting, demonstrate presentation in read-only mode. Aspose.Slides allows to convert the whole presentation or a certain slide into image formats. 

{{% alert color="primary" %}} 

To see how Aspose.Slides converts PowerPoint to JPG images, you may want to try these free online converters: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) and [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Convert PowerPoint PPT/PPTX to JPG**
Here are the steps to convert PPT/PPTX to JPG:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get the slide object of [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) type from [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) collection.
3. Create the thumbnail of each slide and then convert it into JPG. [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) method is used to get a thumbnail of a slide, it returns [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) object as a result. [GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) method has to be called from the needed slide of [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) type, the scales of the resulting thumbnail are passed into the method.
4. After you get the slide thumbnail, call [**IImage.Save(string filename, ImageFormat format)**]((https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) method from the thumbnail object. Pass the resulting file name and the image format into it. 

{{% alert color="primary" %}} 
**Note**: PPT/PPTX to JPG conversion differs from the conversion to other types in Aspose.Slides .NET API. For other types, you usually use [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)** ](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)method, but here you need [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) method.
{{% /alert %}} 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for sld in pres.slides:
    with sld.get_image(1, 1) as bmp:
        bmp.save("Slide_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

## **Convert PowerPoint PPT/PPTX to JPG with Customized Dimensions**
To change the dimension of the resulting thumbnail and JPG image, you can set the *ScaleX* and *ScaleY* values by passing them into the [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) method:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

desiredX = 1200
desiredY = 800
scaleX = (float)(1.0 / pres.slide_size.size.width) * desiredX
scaleY = (float)(1.0 / pres.slide_size.size.height) * desiredY

for sld in pres.slides:
    with sld.get_image(scaleX, scaleY) as bmp:
        bmp.save("Slide_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

{{% alert title="Tip" color="primary" %}}

Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

Using the same principles described in this article, you can convert images from one format to another. For more information, see these pages: convert [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **See also**

See other options to convert PPT/PPTX into image like:

- [PPT/PPTX to SVG conversion](/slides/python-net/render-a-slide-as-an-svg-image/).



