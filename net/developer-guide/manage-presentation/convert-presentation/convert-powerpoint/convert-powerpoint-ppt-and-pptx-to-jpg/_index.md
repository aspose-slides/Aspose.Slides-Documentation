---
title: Convert Powerpoint PPT and PPTX to JPG
type: docs
weight: 60
url: /net/convert-powerpoint-ppt-and-pptx-to-jpg/
keywords: "Convert PowerPoint to JPG, "
description: "Convert PowerPoint to JPG: PPT to JPG, PPTX to JPG, with Aspose.Slides API."
---

## **About PowerPoint to JPG Conversion**
With [**Aspose.Slides .NET API**](https://products.aspose.com/slides/net) you can convert PowerPoint PPT or PPTX presentation to JPG image. It is also possible to convert PPT/PPTX to BMP, PNG or SVG. With this features it's easy to implement your own presentation viewer, create  the thumbnail for every slide. This may be useful if you want to protect presentation slides from copywriting, demonstrate presentation in read-only mode. Aspose.Slides allows to convert the whole presentation or a certain slide into image formats. 



{{% alert color="primary" %}} 

To see how Aspose.Slides API converts PPT/PPTX to JPG, you may try [**Aspose.Slides Converter** ](https://products.aspose.app/slides/conversion)online free app:

[![todo:image_alt_text](ppt-to-jpg.png)](https://products.aspose.app/slides/conversion)

{{% /alert %}} 
## **Convert PowerPoint PPT/PPTX to JPG**
Here are the steps to convert PPT/PPTX to JPG:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)type.
- Get the slide object of [ISlide](https://apireference.aspose.com/net/slides/aspose.slides/islide) type from [Presentation.Slides](https://apireference.aspose.com/net/slides/aspose.slides/presentation/properties/slides) collection.
- Create the thumbnail of each slide and then convert it into JPG. [**ISlide.GetThumbnail(float scaleX, float scaleY)**](https://apireference.aspose.com/net/slides/aspose.slides.islide/getthumbnail/methods/6) method is used to get a thumbnail of a slide, it returns [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=netframework-4.8) object as a result. [GetThumbnail](https://apireference.aspose.com/net/slides/aspose.slides.islide/getthumbnail/methods/6) method has to be called from the needed slide of [ISlide](https://apireference.aspose.com/net/slides/aspose.slides/islide) type, the scales of the resulting thumbnail are passed into the method.
- After you get the slide thumbnail, call [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) method from the thumbnail object. Pass the resulting file name and the image format into it. 

{{% alert color="primary" %}} 
**Note**: PPT/PPTX to JPG conversion differs from the conversion to other types in Aspose.Slides .NET API. For other types, you usually use [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)** ](https://apireference.aspose.com/net/slides/aspose.slides.ipresentation/save/methods/5)method, but here you need [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) method.
{{% /alert %}} 


{{< gist "aspose-com-gists" "ea7de1097bd23deee0a6d59674d5f465" "Convert-PPT-to-JPG.cs" >}}


## **Convert PowerPoint PPT/PPTX to JPG with Customized Dimensions**
To change the dimension of the resulting thumbnail and JPG image, you can set the *ScaleX* and *ScaleY* for it. To do that, pass *ScaleX* and *ScaleY* values into [**ISlide.GetThumbnail(float scaleX, float scaleY)**](https://apireference.aspose.com/net/slides/aspose.slides.islide/getthumbnail/methods/6) method:

{{< gist "aspose-com-gists" "ea7de1097bd23deee0a6d59674d5f465" "Convert-PPT-to-JPG-Customized-Scaling.cs" >}}


## **Render Comments when saving Presentation into Image**
Aspose.Slides for .NET provides a facility to render comments of presentations or slide when converting those into images.  An example is given below that shows how to render comments of presentation into an image.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-RenderComments-RenderComments.cs" >}}


## **See also**
See other options to convert PPT/PPTX into image, like:

- [PPT/PPTX to SVG conversion](/slides/net/presentation-viewer/)




