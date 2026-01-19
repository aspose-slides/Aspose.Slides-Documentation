---
title: Conversión de documento OpenOffice
type: docs
weight: 30
url: /es/net/conversion-of-openoffice-document/
---

Aspose.Slides for .NET ofrece la clase **Presentation** que representa un archivo de presentación. La clase **Presentation** ahora también puede acceder a **ODP** a través del constructor Presentation cuando se instancia el objeto.

A continuación se muestra un ejemplo de conversión de ODP a PPT/PPTX.
## **Ejemplo**
```

 //Instantiate a Presentation object that represents a presentation file

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Saving the PPTX presentation to PPTX format

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

A continuación se muestra un ejemplo de conversión de PPT/PPTX a ODP.
## **Ejemplo**
``` 

 //Instantiate a Presentation object that represents a presentation file

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Saving the PPTX presentation to PPTX format

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Descargar ejemplo en ejecución**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Descargar código de ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)