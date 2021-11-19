---
title: Convert Powerpoint PPT to JPG
type: docs
weight: 60
url: /net/convert-powerpoint-to-jpg/
keywords: "Convert PowerPoint Presentation, JPG, JPEG, PowerPoint to JPG, PowerPoint to JPEG, PPT to JPG, PPTX to JPG, PPT to JPEG, PPTX to JPEG, C#, Csharp, .NET, Aspose.Slides"
description: "Convert PowerPoint to JPG in C# or .NET. Save slide as JPG image"
---

## **About PowerPoint to JPG Conversion**
With [**Aspose.Slides .NET API**](https://products.aspose.com/slides/net/) you can convert PowerPoint PPT or PPTX presentation to JPG image. It is also possible to convert PPT/PPTX to BMP, PNG or SVG. With this features it's easy to implement your own presentation viewer, create  the thumbnail for every slide. This may be useful if you want to protect presentation slides from copywriting, demonstrate presentation in read-only mode. Aspose.Slides allows to convert the whole presentation or a certain slide into image formats. 

{{% alert color="primary" %}} 

To see how Aspose.Slides converts PowerPoint to JPG, you may want to try these free online converters: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) and [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

[![todo:image_alt_text](ppt-to-jpg.png)](https://products.aspose.app/slides/conversion)

{{% /alert %}} 
## **Convert PowerPoint PPT/PPTX to JPG**
Here are the steps to convert PPT/PPTX to JPG:

- Create an instance of [Presentation ](https://apireference.aspose.com/slides/net/aspose.slides/presentation)type.
- Get the slide object of [ISlide](https://apireference.aspose.com/slides/net/aspose.slides/islide) type from [Presentation.Slides](https://apireference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) collection.
- Create the thumbnail of each slide and then convert it into JPG. [**ISlide.GetThumbnail(float scaleX, float scaleY)**](https://apireference.aspose.com/slides/net/aspose.slides.islide/getthumbnail/methods/6) method is used to get a thumbnail of a slide, it returns [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=netframework-4.8) object as a result. [GetThumbnail](https://apireference.aspose.com/slides/net/aspose.slides.islide/getthumbnail/methods/6) method has to be called from the needed slide of [ISlide](https://apireference.aspose.com/slides/net/aspose.slides/islide) type, the scales of the resulting thumbnail are passed into the method.
- After you get the slide thumbnail, call [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) method from the thumbnail object. Pass the resulting file name and the image format into it. 

{{% alert color="primary" %}} 
**Note**: PPT/PPTX to JPG conversion differs from the conversion to other types in Aspose.Slides .NET API. For other types, you usually use [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)** ](https://apireference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5)method, but here you need [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) method.
{{% /alert %}} 

```c#
using (Presentation pres = new Presentation("PowerPoint-Presentation.ppt"))
{
	foreach (ISlide sld in pres.Slides)
	{
		// Create a full scale image
		Bitmap bmp = sld.GetThumbnail(1f, 1f);

		// Save the image to disk in JPEG format
		bmp.Save(string.Format("Slide_{0}.jpg", sld.SlideNumber), System.Drawing.Imaging.ImageFormat.Jpeg);
	}
}
```

## **Convert PowerPoint PPT/PPTX to JPG with Customized Dimensions**
To change the dimension of the resulting thumbnail and JPG image, you can set the *ScaleX* and *ScaleY* for it. To do that, pass *ScaleX* and *ScaleY* values into [**ISlide.GetThumbnail(float scaleX, float scaleY)**](https://apireference.aspose.com/slides/net/aspose.slides.islide/getthumbnail/methods/6) method:

```c#
using (Presentation pres = new Presentation("PowerPoint-Presentation.pptx"))
{
	// Define dimensions
	int desiredX = 1200;
	int desiredY = 800;
	// Get scaled values of X and Y
	float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
	float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

	foreach (ISlide sld in pres.Slides)
	{
		// Create a full scale image
		Bitmap bmp = sld.GetThumbnail(ScaleX, ScaleY);

		// Save the image to disk in JPEG format
		bmp.Save(string.Format("Slide_{0}.jpg", sld.SlideNumber), System.Drawing.Imaging.ImageFormat.Jpeg);
	}
}
```




## **Render Comments when saving Presentation into Image**
Aspose.Slides for .NET provides a facility to render comments of presentations or slide when converting those into images.  An example is given below that shows how to render comments of presentation into an image.

```c#
Presentation pres = new Presentation("test.pptx");
Bitmap bmp = new Bitmap(740, 960);

IRenderingOptions opts = new RenderingOptions();
opts.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;
opts.NotesCommentsLayouting.CommentsAreaColor = Color.Red;
opts.NotesCommentsLayouting.CommentsAreaWidth = 200;
opts.NotesCommentsLayouting.CommentsPosition = CommentsPositions.Right;

using (Graphics graphics = Graphics.FromImage(bmp))
{
	pres.Slides[0].RenderToGraphics(opts, graphics);
}
bmp.Save("OutPresBitmap.png", ImageFormat.Png);
System.Diagnostics.Process.Start("OutPresBitmap.png");
```

{{% alert title="Tip" color="primary" %}}

Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

{{% /alert %}}

## **See also**

See other options to convert PPT/PPTX into image, like:

- [PPT/PPTX to SVG conversion](/slides/net/presentation-viewer/)



