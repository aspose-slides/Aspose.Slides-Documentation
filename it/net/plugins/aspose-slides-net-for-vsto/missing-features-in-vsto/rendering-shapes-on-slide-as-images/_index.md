---
title: Rendering di forme nella diapositiva come immagini
type: docs
weight: 120
url: /it/net/rendering-shapes-on-slide-as-images/
---
Questo copre due funzioni principali:

- Estrarre l'immagine da una forma in un file.
- Estrarre le forme come file immagine.
## **Estrarre un'immagine da una forma in un file**
Le immagini vengono aggiunte nello sfondo della diapositiva e nelle forme. A volte è necessario estrarre le immagini aggiunte nelle forme della presentazione.

In **Aspose.Slides for .NET**, le immagini possono essere aggiunte alla forma della diapositiva e allo sfondo della diapositiva. Le immagini vengono aggiunte nella **ImageCollectionEx** della presentazione. In questo esempio attraverseremo ogni forma all'interno di ogni diapositiva della presentazione e verificheremo se c'è qualche immagine aggiunta nella forma della diapositiva. Se l'immagine viene trovata per una forma, la estrarremo e la salveremo in un file. Il frammento di codice seguente servirà allo scopo.

``` csharp

 //Accesso alla presentazione

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Accesso alla prima diapositiva

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Accesso alla forma con immagine

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

		//Impostazione del formato immagine desiderato

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
## **Scarica il codice di esempio**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Estrarre le forme come file immagine**
```cs
//Istanziare l'oggetto Presentation che rappresenta un file PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Accesso a una diapositiva usando la sua posizione
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Ottenere l'immagine thumbnail della forma
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Salvare l'immagine thumbnail in formato gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Nota:* L'estrazione della forma è attualmente supportata nei file .ppt.
## **Scarica il codice di esempio**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)