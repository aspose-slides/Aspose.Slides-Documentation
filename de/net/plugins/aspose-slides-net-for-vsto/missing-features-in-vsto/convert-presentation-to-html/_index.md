---
title: Präsentation in HTML konvertieren
type: docs
weight: 40
url: /de/net/convert-presentation-to-html/
---

**HTML** ist eines der mehreren weit verbreiteten Formate zum Austausch von Daten. **Aspose.Slides for .NET** bietet Unterstützung für die Konvertierung einer Präsentation in HTML. Nachfolgend finden Sie ein Code‑Snippet, das Ihnen zeigt, wie es funktioniert.

## **Beispiel**
``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Saving the presentation to HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Laufendes Beispiel herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Weitere Details finden Sie unter [PowerPoint-Präsentationen in HTML konvertieren in .NET](/slides/de/net/convert-powerpoint-to-html/).

{{% /alert %}}