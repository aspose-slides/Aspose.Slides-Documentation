---
title: Convertir presentación a HTML
type: docs
weight: 40
url: /es/net/convert-presentation-to-html/
---

**HTML** es uno de varios formatos ampliamente utilizados para el intercambio de datos. **Aspose.Slides for .NET** ofrece soporte para convertir una presentación a HTML. A continuación se muestra un fragmento de código que le indica cómo hacerlo.
## **Ejemplo**
``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Saving the presentation to HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Descargar Ejemplo en Ejecución**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Descargar Código de Muestra**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Para obtener más detalles, visite [Convert PowerPoint Presentations to HTML in .NET](/slides/es/net/convert-powerpoint-to-html/).
{{% /alert %}}