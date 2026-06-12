---
title: Převod prezentace do XPS
type: docs
weight: 60
url: /cs/net/convert-presentation-to-xps/
---
**XPS** formát je také široce používán pro výměnu dat. Aspose.Slides pro .NET se o jeho důležitost stará a poskytuje vestavěnou podporu pro převod prezentace do XPS dokumentu.

Metodu **Save**, kterou poskytuje třída Presentation, lze použít k převodu celé prezentace do **XPS** dokumentu. Dále třída **XpsOptions** zpřístupňuje vlastnost **SaveMetafileAsPng**, kterou lze nastavit na true nebo false podle požadavku.
## **Příklad**

``` 
 //Vytvořte objekt Presentation, který představuje soubor prezentace

Presentation pres = new Presentation("Conversion.ppt");

//Ukládání prezentace do TIFF dokumentu

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);
``` 
## **Stáhnout spuštěný příklad**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Pro více podrobností navštivte [Převod prezentací PowerPoint do XPS v .NET](/slides/cs/net/convert-powerpoint-to-xps/).

{{% /alert %}}