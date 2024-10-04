---
title: Conversión a HTML
type: docs
weight: 20
url: /net/conversion-to-html/
---

**HTML** es uno de varios formatos ampliamente utilizados para intercambiar datos. **Aspose.Slides para .NET** proporciona soporte para convertir una presentación a HTML. A continuación se muestra un fragmento de código que te muestra cómo hacerlo.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Convirtiendo a HTML.html";

//Instanciar un objeto Presentation que representa un archivo de presentación

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Guardar la presentación en HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Convirtiendo%20a%20HTML%20%28Aspose.Slides%29.zip)