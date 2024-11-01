---
title: Konvertierung zu HTML
type: docs
weight: 20
url: /de/net/conversion-to-html/
---

**HTML** ist eines von mehreren weitverbreiteten Formaten zum Austausch von Daten. **Aspose.Slides für .NET** bietet Unterstützung für die Konvertierung einer Präsentation in HTML. Unten finden Sie einen Codeausschnitt, der zeigt, wie es geht.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Instantiieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Speichern der Präsentation als HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Download Beispielcode**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)