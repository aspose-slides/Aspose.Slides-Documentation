---
title: Präsentation in XPS konvertieren
type: docs
weight: 60
url: /net/convert-presentation-to-xps/
---

**XPS**-Format wird ebenfalls häufig zum Austausch von Daten verwendet. Aspose.Slides für .NET berücksichtigt dessen Bedeutung und bietet die integrierte Unterstützung für die Konvertierung einer Präsentation in ein XPS-Dokument.

Die **Save**-Methode der Präsentationsklasse kann verwendet werden, um die gesamte Präsentation in ein **XPS**-Dokument zu konvertieren. Darüber hinaus bietet die **XpsOptions**-Klasse die Eigenschaft **SaveMetafileAsPng**, die je nach Bedarf auf wahr oder falsch gesetzt werden kann.
## **Beispiel**

``` 

//Ein Präsentationsobjekt instanziieren, das eine Präsentationsdatei darstellt

Presentation pres = new Presentation("Conversion.ppt");

//Speichern der Präsentation als TIFF-Dokument

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Laden Sie das Ausführungsbeispiel herunter**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to XPS/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Laden Sie Beispielcode herunter**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Für weitere Details besuchen Sie [Konvertierung in XPS](/slides/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/).

{{% /alert %}}