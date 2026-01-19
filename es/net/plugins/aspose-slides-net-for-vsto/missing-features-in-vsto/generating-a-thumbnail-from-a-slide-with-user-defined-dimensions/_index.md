---
title: Generación de una miniatura a partir de una diapositiva con dimensiones definidas por el usuario
type: docs
weight: 100
url: /es/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

Para generar la miniatura de cualquier diapositiva deseada usando Aspose.Slides para .NET:

- Cree una instancia de la clase Presentation.
- Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
- Obtenga los factores de escala X e Y basados en las dimensiones X e Y definidas por el usuario.
- Obtenga la imagen en miniatura de la diapositiva referenciada con una escala especificada.
- Guarde la imagen en miniatura en cualquier formato de imagen deseado.
## **Ejemplo**
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("TestPresentation.pptx"))
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
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Descargar Ejemplo en Ejecución**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Descargar Código de Ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Para obtener más detalles, visite [Convertir diapositiva](/slides/es/net/convert-slide/).
{{% /alert %}}