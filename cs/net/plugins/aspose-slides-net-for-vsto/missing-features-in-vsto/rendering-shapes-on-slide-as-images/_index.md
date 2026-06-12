---
title: Vykreslení tvarů na snímku jako obrázky
type: docs
weight: 120
url: /cs/net/rendering-shapes-on-slide-as-images/
---
Tento dokument pokrývá dvě hlavní funkce:

- Extrahování obrázku ze tvaru do souboru.
- Extrahování tvarů jako souborů obrázků.
## **Extrahovat obrázek ze tvaru do souboru**
Obrázky jsou přidány do pozadí snímku a tvarů. Někdy je potřeba extrahovat obrázky přidané do tvarů prezentace.

V **Aspose.Slides for .NET** lze obrázky přidávat do tvarů snímku a do pozadí snímku. Obrázky jsou uloženy v **ImageCollectionEx** prezentace. V tomto příkladu projdeme každý tvar na každém snímku prezentace a zjistíme, zda je v tvaru přidán nějaký obrázek. Pokud bude pro nějaký tvar obrázek nalezen, extrahujeme jej a uložíme do souboru. Následující útržek kódu slouží k tomuto účelu.

``` csharp

 //Přístup k prezentaci

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Přístup k prvnímu snímku

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Přístup k tvaru s obrázkem

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

		//Nastavení požadovaného formátu obrázku

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
## **Stáhnout ukázkový kód**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Extrahovat tvary jako soubory obrázků**
```cs
//Vytvořte objekt Presentation, který reprezentuje soubor PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Přístup k snímku pomocí jeho pozice
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Získání miniatury tvaru
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Uložení miniatury ve formátu gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Poznámka:* Extrakce tvaru je momentálně podporována v souborech .ppt.
## **Stáhnout ukázkový kód**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)