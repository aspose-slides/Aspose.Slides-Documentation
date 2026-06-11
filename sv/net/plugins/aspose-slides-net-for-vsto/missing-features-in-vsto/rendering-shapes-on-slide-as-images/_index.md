---
title: Rendera former på bild som bilder
type: docs
weight: 120
url: /sv/net/rendering-shapes-on-slide-as-images/
---
Detta täcker två huvudfunktioner:

- Extrahera bild från form till fil.
- Extrahera former som bildfil.
## **Extrahera en bild från en form till en fil**
Bilder läggs till i bildbakgrund och former. Ibland krävs det att extrahera bilder som lagts till i presentationens former.

I **Aspose.Slides for .NET** kan bilder läggas till i bildform och bildbakgrund. Bilderna läggs till i **ImageCollectionEx** i presentationen. I detta exempel kommer vi att gå igenom varje form i varje bild i presentationen och kontrollera om det finns någon bild som lagts till i bildformen. Om en bild hittas för någon form, kommer vi att extrahera den och spara den i en fil. Följande kodavsnitt uppfyller syftet.

``` csharp

 //Åtkomst till presentationen

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Åtkomst till den första bilden

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Åtkomst till formen med bild

		ShapeEx sh = sl.Shapes[j];

		if (sh is AutoShapeEx)

		{

			AutoShapeEx ashp = (AutoShapeEx)sh;

			if (ashp.FillFormat.FillType == FillTypeEx.Picture)

			{

				img = ashp.FillFormat.PictureFillFormat.Picture.Image;

				ImageType = img.ContentType;

				ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);

				ifImageFound = true;

			}

		}

		else if (sh is PictureFrameEx)

		{

			PictureFrameEx pf = (PictureFrameEx)sh;

			if (pf.FillFormat.FillType == FillTypeEx.Picture)

			{

				img = pf.PictureFormat.Picture.Image;

				ImageType = img.ContentType;

				ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);

				ifImageFound = true;

			}

		}


		//

		//Ställ in önskat bildformat

		if (ifImageFound)

		{

			switch (ImageType)

			{

				case "jpeg":

					Format = System.Drawing.Imaging.ImageFormat.Jpeg;

					break;

				case "emf":

					Format = System.Drawing.Imaging.ImageFormat.Emf;

					break;

				case "bmp":

					Format = System.Drawing.Imaging.ImageFormat.Bmp;

					break;

				case "png":

					Format = System.Drawing.Imaging.ImageFormat.Png;

					break;

				case "wmf":

					Format = System.Drawing.Imaging.ImageFormat.Wmf;

					break;

				case "gif":

					Format = System.Drawing.Imaging.ImageFormat.Gif;

					break;

			}

			//

			img.Image.Save(path+"ResultedImage"+"." + ImageType, Format);

		}

		ifImageFound = false;
``` 
## **Ladda ner exempelkod**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Extrahera former som bildfiler**
```cs
//Instansiera Presentation-objektet som representerar en PPT-fil
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Åtkomst till en bild med dess bildposition
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Hämtar miniatyrbilden av formen
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Sparar miniatyrbilden i gif-format
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Obs!* Extrahering av form stöds för närvarande i .ppt-filer.
## **Ladda ner exempelkod**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)