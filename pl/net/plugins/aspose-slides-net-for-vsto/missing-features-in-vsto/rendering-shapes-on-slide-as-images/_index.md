---
title: Renderowanie kształtów na slajdzie jako obrazy
type: docs
weight: 120
url: /pl/net/rendering-shapes-on-slide-as-images/
---
Ten dokument obejmuje dwie główne funkcje:

- Wyodrębnianie obrazu z kształtu do pliku.
- Wyodrębnianie kształtów jako plik obrazu.
## **Wyodrębnij obraz z kształtu do pliku**
Obrazy są dodawane jako tło slajdu oraz w kształtach. Czasami konieczne jest wyodrębnienie obrazów dodanych w kształtach prezentacji.

W **Aspose.Slides for .NET** obrazy można dodać do kształtu slajdu oraz do tła slajdu. Obrazy są przechowywane w **ImageCollectionEx** prezentacji. W tym przykładzie przejdziemy przez każdy kształt na każdym slajdzie prezentacji i sprawdzimy, czy w kształcie slajdu znajduje się obraz. Jeśli obraz zostanie znaleziony dla dowolnego kształtu, wyodrębnimy go i zapiszemy do pliku. Poniższy fragment kodu spełnia to zadanie.

``` csharp

 //Dostęp do prezentacji

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Dostęp do pierwszego slajdu

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Dostęp do kształtu z obrazem

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

		//Ustawienie żądanego formatu obrazu

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
## **Pobierz przykładowy kod**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Wyodrębnij kształty jako pliki obrazów**
```cs
//Utwórz obiekt Presentation reprezentujący plik PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Uzyskiwanie slajdu przy użyciu jego pozycji
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Pobieranie miniatury obrazu kształtu
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Zapisywanie miniatury obrazu w formacie gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Uwaga:* Wyodrębnianie kształtów jest obecnie obsługiwane w plikach .ppt.
## **Pobierz przykładowy kod**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)