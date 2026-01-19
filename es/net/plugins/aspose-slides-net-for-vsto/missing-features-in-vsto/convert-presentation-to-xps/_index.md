---
title: Convertir presentación a XPS
type: docs
weight: 60
url: /es/net/convert-presentation-to-xps/
---

**XPS** es también muy usado para el intercambio de datos. Aspose.Slides for .NET se ocupa de su importancia y ofrece soporte incorporado para convertir una presentación en un documento XPS.

El método **Save** expuesto por la clase Presentation puede utilizarse para convertir toda la presentación en un documento **XPS**. Además, la clase **XpsOptions** expone la propiedad **SaveMetafileAsPng**, que puede establecerse en true o false según sea necesario.
## **Ejemplo**

``` 

 //Instanciar un objeto Presentation que representa un archivo de presentación

Presentation pres = new Presentation("Conversion.ppt");

//Guardar la presentación como documento TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Descargar ejemplo en ejecución**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Descargar código de ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Para obtener más detalles, visite [Convertir presentaciones de PowerPoint a XPS en .NET](/slides/es/net/convert-powerpoint-to-xps/).

{{% /alert %}}