---
title: Präsentation in XPS konvertieren
type: docs
weight: 60
url: /de/net/convert-presentation-to-xps/
---

**XPS**-Format wird ebenfalls häufig zum Austausch von Daten verwendet. Aspose.Slides für .NET berücksichtigt dessen Bedeutung und bietet integrierte Unterstützung zum Konvertieren einer Präsentation in ein XPS‑Dokument.

Die von der Presentation‑Klasse bereitgestellte **Save**‑Methode kann verwendet werden, um die gesamte Präsentation in ein **XPS**‑Dokument zu konvertieren. Darüber hinaus stellt die **XpsOptions**‑Klasse die Eigenschaft **SaveMetafileAsPng** zur Verfügung, die je nach Bedarf auf true oder false gesetzt werden kann.
## **Beispiel**

``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

//Saving the presentation to TIFF document

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Beispiel herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Für weitere Details besuchen Sie [PowerPoint-Präsentationen in XPS konvertieren in .NET](/slides/de/net/convert-powerpoint-to-xps/).

{{% /alert %}}