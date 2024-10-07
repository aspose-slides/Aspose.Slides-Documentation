---
title: Formen auf Folien als Bilder rendern
type: docs
weight: 120
url: /net/rendering-shapes-on-slide-as-images/
---

Dies behandelt zwei Hauptfunktionen:

- Bild aus Form in Datei extrahieren.
- Formen als Bilddatei extrahieren.
## **Bild aus Form in Datei extrahieren**
Bilder werden im Folienhintergrund und in Formen hinzugefügt. Manchmal ist es erforderlich, die in den Präsentationsformen hinzugefügten Bilder zu extrahieren.

In **Aspose.Slides für .NET** können Bilder in Folienformen und im Folienhintergrund hinzugefügt werden. Die Bilder werden in **ImageCollectionEx** der Präsentation hinzugefügt. In diesem Beispiel werden wir jede Form in jeder Folie der Präsentation durchlaufen und prüfen, ob es eine Bild in der Folienform gibt. Wenn das Bild für eine Form gefunden wird, werden wir es extrahieren und in eine Datei speichern. Der folgende Codeausschnitt dient diesem Zweck.

``` csharp

 //Zugriff auf die Präsentation

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Zugriff auf die erste Folie

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Zugriff auf die Form mit Bild

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

		//Festlegen des gewünschten Bildformats

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
## **Beispielcode herunterladen**
- [Codeplex](http://goo.gl/G3JI6p)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Formen als Bilddatei extrahieren**
```cs
//Instanziieren des Präsentationsobjekts, das eine PPT-Datei darstellt
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Zugriff auf eine Folie anhand ihrer Folienposition
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Erhalten des Miniaturbilds der Form
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Speichern des Miniaturbilds im gif-Format
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Hinweis:*Die Extraktion von Formen wird derzeit in .ppt-Dateien unterstützt.
## **Beispielcode herunterladen**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812536)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)