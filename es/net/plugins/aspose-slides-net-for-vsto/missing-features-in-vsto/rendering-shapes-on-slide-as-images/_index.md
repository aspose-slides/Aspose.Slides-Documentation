---
title: Renderizar formas en la diapositiva como imágenes
type: docs
weight: 120
url: /es/net/rendering-shapes-on-slide-as-images/
---

Esto cubre dos funciones principales:

- Extraer una Imagen de una Forma a un archivo.
- Extraer Formas como archivo de imagen.
## **Extraer una Imagen de una Forma a un Archivo**
Las imágenes se añaden en el fondo de la diapositiva y en las formas. A veces, es necesario extraer las imágenes añadidas en las formas de la presentación.

En **Aspose.Slides for .NET**, las imágenes pueden añadirse a la forma de la diapositiva y al fondo de la diapositiva. Las imágenes se añaden en **ImageCollectionEx** de la presentación. En este ejemplo recorreremos cada forma dentro de cada diapositiva de la presentación y veremos si hay alguna imagen añadida en la forma de la diapositiva. Si se encuentra una imagen para alguna forma, la extraeremos y la guardaremos en un archivo. El siguiente fragmento de código servirá para ello.
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

		// Accediendo a la forma con picture

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

		//Estableciendo el formato de imagen deseado

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
## **Download Sample Code**
- [Codeplex](http://goo.gl/G3JI6p)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Extract Shapes as Image Files**
```cs
//Instanciar el objeto Presentation que representa un archivo PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Accediendo a una diapositiva usando su posición
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Obteniendo la imagen miniatura de la forma
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Guardando la imagen miniatura en formato gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```


*Nota:* La extracción de forma es actualmente compatible en archivos .ppt.
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812536)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)