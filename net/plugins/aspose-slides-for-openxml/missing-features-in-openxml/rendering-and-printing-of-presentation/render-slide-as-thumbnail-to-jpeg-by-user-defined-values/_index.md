---
title: Render Slide As Thumbnail to JPEG by User defined Values
type: docs
weight: 70
url: /net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

To generate the thumbnail of any desired slide using Aspose.Slides for .NET:

1. Create an instance of the **Presentation** class.
1. Obtain the reference of any desired slide by using its ID or index.
1. Get the X and Y scaling factors based on user defined X and Y dimensions.
1. Get the thumbnail image of the referenced slide on a specified scale.
1. Save the thumbnail image in any desired image format.

{{< highlight csharp >}}

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "User Defined Thumbnail.pptx";

string destFileName = FilePath + "User Defined Thumbnail.jpg";

//Instantiate a Presentation class that represents the presentation file

using (Presentation pres = new Presentation(srcFileName))

{

//Access the first slide

ISlide sld = pres.Slides[0];

//User defined dimension

int desiredX = 1200;

int desiredY = 800;

//Getting scaled value  of X and Y

float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;

float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

//Create a full scale image

Bitmap bmp = sld.GetThumbnail(ScaleX, ScaleY);

//Save the image to disk in JPEG format

bmp.Save(destFileName, System.Drawing.Imaging.ImageFormat.Jpeg);

}

{{< /highlight >}}
## **Download Sample Code**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)
