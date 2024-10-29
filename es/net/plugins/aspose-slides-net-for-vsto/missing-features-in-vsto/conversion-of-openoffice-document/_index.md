---
title: Conversión de Documento OpenOffice
type: docs
weight: 30
url: /es/net/conversion-of-openoffice-document/
---

Aspose.Slides para .NET ofrece la clase **Presentation** que representa un archivo de presentación. La clase **Presentation** ahora también puede acceder a **ODP** a través del constructor de Presentation cuando se instancia el objeto.

A continuación se muestra el ejemplo de conversión de ODP a PPT/PPTX.
## **Ejemplo**
```

 //Instanciar un objeto Presentation que representa un archivo de presentación

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Guardar la presentación PPTX en formato PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

```

A continuación se muestra el ejemplo de conversión de PPT/PPTX a ODP.
## **Ejemplo**
```

 //Instanciar un objeto Presentation que representa un archivo de presentación

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Guardar la presentación PPTX en formato PPTX

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

```
## **Descargar Ejemplo en Ejecución**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Conversion from ODP to PPTX/Converting From and To ODP/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Descargar Código de Ejemplo**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)