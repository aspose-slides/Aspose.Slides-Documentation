---
title: Konwersja dokumentu OpenOffice
type: docs
weight: 30
url: /pl/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET oferuje klasę **Presentation**, która reprezentuje plik prezentacji. Klasa **Presentation** może teraz również uzyskać dostęp do **ODP** za pośrednictwem konstruktora Presentation, gdy obiekt jest tworzony.

Poniżej znajduje się przykład konwersji z ODP do PPT/PPTX.
## **Przykład**
```

 //Utwórz obiekt Presentation, który reprezentuje plik prezentacji

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Zapisz prezentację PPTX w formacie PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Poniżej znajduje się przykład konwersji z PPT/PPTX do ODP.
## **Przykład**
``` 
 //Utwórz obiekt Presentation, który reprezentuje plik prezentacji
using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))
{
   //Zapisz prezentację PPTX w formacie PPTX
   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);
}
``` 
## **Pobierz działający przykład**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)