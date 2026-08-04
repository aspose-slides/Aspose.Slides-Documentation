---
title: Rendering Shapes on Slide as Images
type: docs
weight: 120
url: /net/rendering-shapes-on-slide-as-images/
---

This covers two main function:

- Extracting Image from Shape to file.
- Extracting Shapes as image file.
## **Extract an Image from a Shape to a File**
Images are added in slide background and shapes. Sometimes, it is required to extract the images added in the presentation shapes.

In **Aspose.Slides for .NET**, images can be added to slide shape and slide background. The images are added in **ImageCollectionEx** of the presentation. In this example we will traverse through each shape inside every slide of presentation and see if there is any image added in slide shape. If the image will be found for any shape, we will extract that and will save it in file.The following code snippet will serve the purpose.

``` csharp
using System.IO;
using Aspose.Slides;

//Accessing the presentation
using (Presentation pres = new Presentation("RenderImageFromShape.pptx"))
{
	int imageIndex = 0;

	foreach (ISlide slide in pres.Slides)
	{
		foreach (IShape shape in slide.Shapes)
		{
			IPPImage image = null;

			//The picture an AutoShape is filled with
			IAutoShape autoShape = shape as IAutoShape;
			if (autoShape != null && autoShape.FillFormat.FillType == FillType.Picture)
			{
				image = autoShape.FillFormat.PictureFillFormat.Picture.Image;
			}
			else
			{
				//The picture of a PictureFrame
				IPictureFrame pictureFrame = shape as IPictureFrame;
				if (pictureFrame != null)
					image = pictureFrame.PictureFormat.Picture.Image;
			}

			if (image == null)
				continue;

			//ContentType is a MIME type like "image/jpeg", so the part after the
			//slash gives the file extension
			string imageType = image.ContentType.Substring(image.ContentType.IndexOf("/") + 1);

			//Save the picture with its original encoding
			File.WriteAllBytes("ResultedImage" + imageIndex + "." + imageType, image.BinaryData);
			imageIndex++;
		}
	}
}
``` 
## **Download Sample Code**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Extract Shapes as Image Files**
```cs
using Aspose.Slides;

//Instantiate the Presentation object that represents a PPT file
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Accessing a slide using its slide position
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Getting the thumbnail image of the shape
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Saving the thumbnail image in gif format
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Note:*Extraction of shape is currently supported in .ppt file.
## **Download Sample Code**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)
