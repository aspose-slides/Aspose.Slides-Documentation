---
title: Konvertierung von OpenOffice-Dokumenten
type: docs
weight: 30
url: /de/net/conversion-of-openoffice-document/
---

Aspose.Slides für .NET bietet die Klasse **Presentation**, die eine Präsentationsdatei darstellt. Die Klasse **Presentation** kann jetzt auch auf **ODP** über den Präsentations-Konstruktor zugreifen, wenn das Objekt instanziiert wird.

Nachfolgend ein Beispiel für die Umwandlung von ODP in PPT/PPTX.
## **Beispiel**
```

 //Instanziieren eines Präsentationsobjekts, das eine Präsentationsdatei darstellt

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Speichern der PPTX-Präsentation im PPTX-Format

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Nachfolgend ein Beispiel für die Umwandlung von PPT/PPTX in ODP.
## **Beispiel**
``` 

 //Instanziieren eines Präsentationsobjekts, das eine Präsentationsdatei darstellt

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Speichern der PPTX-Präsentation im PPTX-Format

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Laden Sie das funktionierende Beispiel herunter**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Conversion from ODP to PPTX/Converting From and To ODP/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Laden Sie den Beispielcode herunter**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)