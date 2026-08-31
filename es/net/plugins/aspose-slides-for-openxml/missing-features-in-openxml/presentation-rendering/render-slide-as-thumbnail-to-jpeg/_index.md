---
title: Renderizar diapositiva como miniatura a JPEG
type: docs
weight: 60
url: /es/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** se utiliza para crear archivos de presentación que contienen diapositivas. Estas diapositivas pueden verse al abrir los archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver las diapositivas como imágenes usando su visor de imágenes favorito. En esos casos, Aspose.Slides for .NET le ayuda a generar imágenes en miniatura de las diapositivas.

Para generar la miniatura de cualquier diapositiva deseada con Aspose.Slides for .NET:

1. Cree una instancia de la clase **Presentation**.
1. Obtenga la referencia de la diapositiva deseada mediante su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con una escala especificada.
1. Guarde la imagen en miniatura en el formato de imagen que desee.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instanciar la clase Presentation que representa el archivo de presentación
using (Presentation pres = new Presentation(srcFileName))
{
    //Acceder a la primera diapositiva
    ISlide sld = pres.Slides[0];

    //Crear una imagen a escala completa
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Guardar la imagen en disco en formato JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Descargar código de ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)