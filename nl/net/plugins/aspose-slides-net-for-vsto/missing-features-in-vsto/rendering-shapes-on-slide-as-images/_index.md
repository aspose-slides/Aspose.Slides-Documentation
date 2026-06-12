---
title: Vormen renderen op dia als afbeeldingen
type: docs
weight: 120
url: /nl/net/rendering-shapes-on-slide-as-images/
---
Dit behandelt twee hoofdfuncties:

- Een afbeelding uit een vorm extraheren naar een bestand.
- Vormen extraheren als afbeeldingsbestand.
## **Een afbeelding uit een vorm extraheren naar een bestand**
Afbeeldingen worden toegevoegd aan de achtergrond van dia's en aan vormen. Soms is het nodig om de afbeeldingen die aan de presentatievormen zijn toegevoegd te extraheren.

In **Aspose.Slides for .NET** kunnen afbeeldingen worden toegevoegd aan een vorm op een dia en aan de dia‑achtergrond. De afbeeldingen worden opgeslagen in **ImageCollectionEx** van de presentatie. In dit voorbeeld doorlopen we elke vorm in elke dia van de presentatie en kijken we of er een afbeelding aan de vorm op de dia is toegevoegd. Als een afbeelding voor een vorm wordt gevonden, extraheren we deze en slaan we deze op in een bestand. Het volgende code‑fragment dient hiervoor.

``` csharp

 //Toegang tot de presentatie

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Toegang tot de eerste dia

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Accessing the shape with picture

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

		//Het gewenste afbeeldingsformaat instellen

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
## **Voorbeeldcode downloaden**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Vormen extraheren als afbeeldingsbestanden**
```cs
//Instantiëren van het Presentation-object dat een PPT-bestand vertegenwoordigt
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Toegang tot een dia via de positie van de dia
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //De thumbnail-afbeelding van de vorm ophalen
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //De thumbnail-afbeelding opslaan in gif-formaat
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Opmerking:*Extractie van vormen wordt momenteel ondersteund in .ppt‑bestanden.
## **Voorbeeldcode downloaden**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)