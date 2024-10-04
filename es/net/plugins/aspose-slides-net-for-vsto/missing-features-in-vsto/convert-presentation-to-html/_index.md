---
title: Convertir Presentación a HTML
type: docs
weight: 40
url: /es/net/convert-presentation-to-html/
---

**HTML** es uno de varios formatos ampliamente utilizados para intercambiar datos. **Aspose.Slides para .NET** proporciona soporte para convertir una presentación a HTML. A continuación se muestra un fragmento de código que te muestra cómo hacerlo.
## **Ejemplo**
``` 

 //Instanciar un objeto Presentation que representa un archivo de presentación

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Guardar la presentación como HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Descargar Ejemplo en Ejecución**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to HTML/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Descargar Código de Ejemplo**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Para más detalles, visita [Convirtiendo Presentación a HTML](/slides/es/net/convert-powerpoint-ppt-and-pptx-to-html/).

{{% /alert %}}