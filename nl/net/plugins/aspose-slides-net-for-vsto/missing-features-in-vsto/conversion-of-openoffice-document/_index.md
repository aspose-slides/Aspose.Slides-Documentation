---
title: Conversie van OpenOffice-document
type: docs
weight: 30
url: /nl/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET biedt de **Presentation**-klasse die een presentatiedocument vertegenwoordigt. De **Presentation**-klasse kan nu ook **ODP** benaderen via de Presentation‑constructor wanneer het object wordt aangemaakt.

Hieronder staat het voorbeeld voor het converteren van ODP naar PPT/PPTX.
## **Voorbeeld**
```

 //Instantieer een Presentation-object dat een presentatiedocument vertegenwoordigt

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Opslaan van de PPTX-presentatie in PPTX-formaat

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Hieronder staat het voorbeeld voor het converteren van PPT/PPTX naar ODP.
## **Voorbeeld**
``` 

 //Instantieer een Presentation-object dat een presentatiedocument vertegenwoordigt

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Opslaan van de PPTX-presentatie in PPTX-formaat

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Download Werkend Voorbeeld**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Download Voorbeeldcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)