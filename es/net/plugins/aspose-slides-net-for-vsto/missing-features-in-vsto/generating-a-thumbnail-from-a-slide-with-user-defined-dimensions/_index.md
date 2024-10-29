---
title: Generando una miniatura de una diapositiva con dimensiones definidas por el usuario
type: docs
weight: 100
url: /es/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

Para generar la miniatura de cualquier diapositiva deseada utilizando Aspose.Slides para .NET:

- Crea una instancia de la clase Presentation.
- Obtén la referencia de cualquier diapositiva deseada utilizando su ID o índice.
- Obtén los factores de escala X e Y en función de las dimensiones X e Y definidas por el usuario.
- Obtén la imagen en miniatura de la diapositiva referenciada en una escala especificada.
- Guarda la imagen en miniatura en cualquier formato de imagen deseado.
## **Ejemplo**
```cs
//Instanciar la clase Presentation que representa el archivo de presentación
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Acceder a la primera diapositiva
    ISlide sld = pres.Slides[0];

    //Dimensión definida por el usuario
    int desiredX = 1200;
    int desiredY = 800;

    //Obteniendo el valor escalado de X e Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Crear una imagen a escala completa
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Guardar la imagen en el disco en formato JPEG
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Descargar ejemplo en ejecución**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/User Defined Thumbnail/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Descargar código de muestra**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Para más detalles, visita [Creating Slides Thumbnail Image](/slides/es/net/presentation-viewer/#creating-slides-thumbnail-image).

{{% /alert %}}