---
title: Renderizar diapositiva como miniatura a JPEG
type: docs
weight: 60
url: /es/net/render-slide-as-thumbnail-to-jpeg/
---

**Aspose.Slides for .NET** se usa para crear archivos de presentación que contienen diapositivas. Estas diapositivas pueden verse al abrir los archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver las diapositivas como imágenes usando su visor de imágenes favorito. En esos casos, Aspose.Slides for .NET le ayuda a generar imágenes en miniatura de las diapositivas.

Para generar la miniatura de cualquier diapositiva deseada usando Aspose.Slides for .NET:

1. Crear una instancia de la clase **Presentation**.
1. Obtener la referencia de la diapositiva deseada mediante su ID o índice.
1. Obtener la imagen en miniatura de la diapositiva referenciada con una escala especificada.
1. Guardar la imagen en miniatura en el formato de imagen que se desee.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //Create a full scale image
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Save the image to disk in JPEG format
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Descargar código de ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)