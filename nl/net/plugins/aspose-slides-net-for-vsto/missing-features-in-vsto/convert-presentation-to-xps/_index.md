---
title: Presentatie converteren naar XPS
type: docs
weight: 60
url: /nl/net/convert-presentation-to-xps/
---
**XPS**-formaat wordt ook veel gebruikt voor gegevensuitwisseling. Aspose.Slides for .NET houdt rekening met het belang ervan en biedt ingebouwde ondersteuning voor het converteren van een presentatie naar een XPS‑document.

De **Save**‑methode van de Presentation‑klasse kan worden gebruikt om de volledige presentatie naar een **XPS**‑document te converteren. Daarnaast biedt de **XpsOptions**‑klasse de eigenschap **SaveMetafileAsPng**, die naar wens op true of false kan worden gezet.
## **Voorbeeld**

``` 

 //Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt

Presentation pres = new Presentation("Conversion.ppt");

//De presentatie opslaan naar een TIFF-document

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Download Werkend Voorbeeld**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Download voorbeeldcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Voor meer details, bezoek [PowerPoint‑presentaties converteren naar XPS in .NET](/slides/nl/net/convert-powerpoint-to-xps/).

{{% /alert %}}