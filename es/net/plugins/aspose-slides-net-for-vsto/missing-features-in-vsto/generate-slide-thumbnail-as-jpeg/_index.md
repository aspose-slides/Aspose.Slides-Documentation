---
title: Generar Miniatura de Diapositiva como JPEG
type: docs
weight: 90
url: /es/net/generate-slide-thumbnail-as-jpeg/
---

Para generar la miniatura de cualquier diapositiva deseada usando Aspose.Slides para .NET:

- Cree una instancia de la clase Presentation.
- Obtenga la referencia de cualquier diapositiva deseada usando su ID o índice.
- Obtenga la imagen en miniatura de la diapositiva referenciada en una escala especificada.
- Guarde la imagen en miniatura en cualquier formato de imagen deseado.
## **Ejemplo**
```cs
//Instanciar la clase Presentation que representa el archivo de presentación
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Acceder a la primera diapositiva
    ISlide sld = pres.Slides[0];

    //Crear una imagen a escala completa
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Guardar la imagen en disco en formato JPEG
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Descargar Ejemplo en Ejecución**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Slide Thumbnail to JPEG/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Descargar Código de Ejemplo**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Para más detalles, visita [Creando Imagen de Miniatura de Diapositivas](/slides/es/net/presentation-viewer/#presentationviewer-creatingslidesthumbnailimage).

{{% /alert %}}