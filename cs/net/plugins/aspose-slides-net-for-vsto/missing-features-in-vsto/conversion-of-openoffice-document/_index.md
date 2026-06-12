---
title: Převod dokumentu OpenOffice
type: docs
weight: 30
url: /cs/net/conversion-of-openoffice-document/
---
Aspose.Slides pro .NET poskytuje třídu **Presentation**, která představuje soubor prezentace. Třída **Presentation** nyní může také přistupovat k **ODP** prostřednictvím konstruktoru Presentation, když je objekt vytvořen.

Níže je příklad převodu z ODP na PPT/PPTX.
## **Příklad**
```

 //Vytvořte objekt Presentation, který představuje soubor prezentace

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Ukládání prezentace PPTX do formátu PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Níže je příklad převodu z PPT/PPTX na ODP.
## **Příklad**
``` 

 //Vytvořte objekt Presentation, který představuje soubor prezentace

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Ukládání prezentace PPTX do formátu PPTX

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Stáhnout běžící příklad**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)