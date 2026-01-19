---
title: Konvertierung zu HTML
type: docs
weight: 20
url: /de/net/conversion-to-html/
---

**HTML** ist eines der mehreren weit verbreiteten Formate zum Austausch von Daten. **Aspose.Slides for .NET** bietet Unterstützung für die Konvertierung einer Präsentation in HTML. Unten ist ein Code‑Snippet, das zeigt, wie es funktioniert.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Saving the presentation to HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)