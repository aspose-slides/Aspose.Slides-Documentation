---
title: Renderizando Formas en Diapositiva como Imágenes
type: docs
weight: 120
url: /net/rendering-shapes-on-slide-as-images/
---

Esto cubre dos funciones principales:

- Extracción de Imagen de Forma a archivo.
- Extracción de Formas como archivo de imagen.
## **Extracción de Imagen de Forma a archivo**
Las imágenes se agregan en el fondo de la diapositiva y en las formas. A veces, es necesario extraer las imágenes añadidas en las formas de la presentación.

En **Aspose.Slides for .NET**, las imágenes se pueden agregar al formato de diapositiva y al fondo de la diapositiva. Las imágenes se agregan en **ImageCollectionEx** de la presentación. En este ejemplo, recorreremos cada forma dentro de cada diapositiva de la presentación y veremos si hay alguna imagen agregada en la forma de la diapositiva. Si se encuentra la imagen para alguna forma, la extraeremos y la guardaremos en un archivo. El siguiente fragmento de código cumplirá con este propósito.

``` csharp

 //Accediendo a la presentación

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Accediendo a la primera diapositiva

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Accediendo a la forma con imagen

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

		//Configurando el formato de imagen deseado

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
## **Descargar Código de Ejemplo**
- [Codeplex](http://goo.gl/G3JI6p)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Extracción de Formas como archivo de imagen**
```cs
//Instanciar el objeto Presentación que representa un archivo PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Accediendo a una diapositiva usando su posición en la diapositiva
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Obteniendo la imagen en miniatura de la forma
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Guardando la imagen en miniatura en formato gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Nota:* La extracción de forma se soporta actualmente en archivos .ppt.
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812536)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)