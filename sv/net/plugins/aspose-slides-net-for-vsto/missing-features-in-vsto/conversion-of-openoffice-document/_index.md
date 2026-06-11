---
title: Konvertering av OpenOffice-dokument
type: docs
weight: 30
url: /sv/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET erbjuder **Presentation**-klassen som representerar en presentationsfil. **Presentation**-klassen kan nu också komma åt **ODP** via Presentation‑konstruktorn när objektet instansieras.

Nedan följer ett exempel på konvertering från ODP till PPT/PPTX.
## **Exempel**
```

 //Instansiera ett Presentation-objekt som representerar en presentationsfil

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{
   //Sparar PPTX-presentationen i PPTX-format
   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);
}

``` 

Nedan följer ett exempel på konvertering från PPT/PPTX till ODP.
## **Exempel**
``` 

 //Instansiera ett Presentation-objekt som representerar en presentationsfil

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Sparar PPTX-presentationen i PPTX-format

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Ladda ner körande exempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Ladda ner exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)