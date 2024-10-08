---
title: Rendu des formes sur la diapositive en tant qu'images
type: docs
weight: 120
url: /fr/net/rendering-shapes-on-slide-as-images/
---

Cela couvre deux fonctions principales :

- Extraction d'images à partir d'une forme vers un fichier.
- Extraction de formes en tant que fichier image.
## **Extraction d'images à partir d'une forme vers un fichier**
Des images sont ajoutées en arrière-plan des diapositives et dans les formes. Parfois, il est nécessaire d'extraire les images ajoutées dans les formes de la présentation.

Dans **Aspose.Slides pour .NET**, des images peuvent être ajoutées à une forme de diapositive et à l'arrière-plan de la diapositive. Les images sont ajoutées dans **ImageCollectionEx** de la présentation. Dans cet exemple, nous allons parcourir chaque forme dans chaque diapositive de la présentation et voir s'il y a une image ajoutée dans la forme de la diapositive. Si une image est trouvée pour une forme, nous allons l'extraire et l'enregistrer dans un fichier. Le snippet de code suivant servira à cet effet.

``` csharp

 //Accéder à la présentation

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Accéder à la première diapositive

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Accéder à la forme avec image

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

		//Définir le format d'image souhaité

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
## **Télécharger le code d'exemple**
- [Codeplex](http://goo.gl/G3JI6p)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Extraction de formes en tant que fichier image**
```cs
//Instancier l'objet Présentation qui représente un fichier PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Accéder à une diapositive en utilisant sa position
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Obtenir l'image miniature de la forme
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Enregistrer l'image miniature au format gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Remarque :* L'extraction de formes est actuellement prise en charge dans le fichier .ppt.
## **Télécharger le code d'exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812536)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)