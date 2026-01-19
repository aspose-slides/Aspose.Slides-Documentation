---
title: Konvertierung von OpenOffice-Dokument
type: docs
weight: 30
url: /de/net/conversion-of-openoffice-document/
---

Aspose.Slides für .NET bietet die **Presentation**‑Klasse, die eine Präsentationsdatei darstellt. Die **Presentation**‑Klasse kann jetzt auch über den Presentation‑Konstruktor auf **ODP** zugreifen, wenn das Objekt instanziiert wird.

Im Folgenden finden Sie ein Beispiel für die Konvertierung von ODP zu PPT/PPTX.
## **Beispiel**
```

 //Instantiate a Presentation object that represents a presentation file

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Saving the PPTX presentation to PPTX format

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Im Folgenden finden Sie ein Beispiel für die Konvertierung von PPT/PPTX zu ODP.
## **Beispiel**
``` 

 //Instantiate a Presentation object that represents a presentation file

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Saving the PPTX presentation to PPTX format

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Laufendes Beispiel herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)