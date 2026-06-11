---
title: Konvertera presentation till XPS
type: docs
weight: 60
url: /sv/net/convert-presentation-to-xps/
---
**XPS**-formatet används också ofta för datautbyte. Aspose.Slides for .NET tar hänsyn till dess betydelse och tillhandahåller inbyggt stöd för att konvertera en presentation till ett XPS-dokument.

**Save**‑metoden som exponeras av Presentation‑klassen kan användas för att konvertera hela presentationen till ett **XPS**‑dokument. Dessutom exponerar **XpsOptions**‑klassen egenskapen **SaveMetafileAsPng** som kan sättas till true eller false enligt behov.
## **Exempel**

``` 

 //Instansiera ett Presentation-objekt som representerar en presentationsfil

Presentation pres = new Presentation("Conversion.ppt");

//Sparar presentationen till TIFF-dokument

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Ladda ner körande exempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Ladda ner exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

För mer information, besök [Konvertera PowerPoint-presentationer till XPS i .NET](/slides/sv/net/convert-powerpoint-to-xps/).

{{% /alert %}}