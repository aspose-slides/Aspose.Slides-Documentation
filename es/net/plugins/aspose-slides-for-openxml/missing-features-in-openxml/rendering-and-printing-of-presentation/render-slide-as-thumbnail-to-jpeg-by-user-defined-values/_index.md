---
title: Renderizar Diapositiva como Miniatura a JPEG por Valores Definidos por el Usuario
type: docs
weight: 70
url: /es/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

Para generar la miniatura de cualquier diapositiva deseada utilizando Aspose.Slides para .NET:

1. Cree una instancia de la clase **Presentation**.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga los factores de escalado X e Y en función de las dimensiones X e Y definidas por el usuario.
1. Obtenga la imagen en miniatura de la diapositiva referenciada en una escala especificada.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Miniatura Definida por el Usuario.pptx";
string destFileName = filePath + "Miniatura Definida por el Usuario.jpg";

//Instanciar la clase Presentation que representa el archivo de presentación
using (Presentation pres = new Presentation(srcFileName))
{
    //Acceder a la primera diapositiva
    ISlide sld = pres.Slides[0];

    //Dimensión definida por el usuario
    int desiredX = 1200;
    int desiredY = 800;

    //Obteniendo valor escalado de X e Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Crear una imagen a escala completa
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Guardar la imagen en disco en formato JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)