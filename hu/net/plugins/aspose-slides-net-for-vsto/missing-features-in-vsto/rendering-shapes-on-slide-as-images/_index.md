---
title: Alakzatok megjelenítése dián képként
type: docs
weight: 120
url: /hu/net/rendering-shapes-on-slide-as-images/
---
Ez két fő funkciót fed le:

- Kép kinyerése alakzatról fájlba.
- Alakzatok kinyerése képfájlként.
## **Kép kinyerése alakzatról fájlba**
A képek a dia háttérbe és az alakzatokba kerülnek hozzáadásra. Néha szükség van a prezentáció alakzataiban lévő képek kinyerésére.

**Aspose.Slides for .NET**-ban a képek hozzáadhatók a dia alakzathoz és a dia háttérhez. A képek a prezentáció **ImageCollectionEx**-ban kerülnek tárolásra. Ebben a példában végigjárjuk a prezentáció minden diájának minden alakzatát, és ellenőrizzük, hogy van-e képet a dia alakzatában. Ha bármely alakzathoz megtaláljuk a képet, azt kinyerjük, és fájlba mentjük. Az alábbi kódrészlet ezt a célt szolgálja.

``` csharp

 //A prezentáció elérése

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Az első dia elérése

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Az alakzat elérése képpel

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

		//A kívánt képformátum beállítása

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
## **Minta kód letöltése**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Alakzatok kinyerése képfájlokként**
```cs
//PPT fájlt képviselő Presentation objektum példányosítása
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Dia elérése a diapozíciója alapján
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Az alakzat bélyegképének lekérése
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //A bélyegkép mentése gif formátumban
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Megjegyzés:* Az alakzat kinyerése jelenleg .ppt fájlokban támogatott.
## **Minta kód letöltése**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)