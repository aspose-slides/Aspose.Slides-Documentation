---
title: Renderizar diapositiva como miniatura JPEG con valores definidos por el usuario
type: docs
weight: 70
url: /es/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

Para generar la miniatura de cualquier diapositiva deseada usando Aspose.Slides para .NET:

1. Crear una instancia de la **Presentation** class.
1. Obtener la referencia de la diapositiva deseada mediante su ID o índice.
1. Obtener los factores de escala X e Y basados en las dimensiones X e Y definidas por el usuario.
1. Obtener la imagen en miniatura de la diapositiva referenciada en una escala especificada.
1. Guardar la imagen en miniatura en el formato de imagen deseado.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //User defined dimension
    int desiredX = 1200;
    int desiredY = 800;

    //Getting scaled value  of X and Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Create a full scale image
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Save the image to disk in JPEG format
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Descargar código de ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)