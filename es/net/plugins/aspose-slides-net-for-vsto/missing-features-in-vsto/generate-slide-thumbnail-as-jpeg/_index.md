---
title: Generar miniatura de diapositiva como JPEG
type: docs
weight: 90
url: /es/net/generate-slide-thumbnail-as-jpeg/
---

Para generar la miniatura de cualquier diapositiva deseada usando Aspose.Slides para .NET:

- Cree una instancia de la clase Presentation.
- Obtenga la referencia de la diapositiva deseada utilizando su ID o índice.
- Obtenga la imagen en miniatura de la diapositiva referenciada en una escala especificada.
- Guarde la imagen en miniatura en el formato de imagen que desee.
## **Ejemplo**
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //Create a full scale image
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Save the image to disk in JPEG format
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Descargar ejemplo en ejecución**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Descargar código de ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Para obtener más detalles, visite [Convertir PPT y PPTX a JPG en .NET](/slides/es/net/convert-powerpoint-to-jpg/).

{{% /alert %}}