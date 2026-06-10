---
title: Bemutató konvertálása XPS formátumba
type: docs
weight: 60
url: /hu/net/convert-presentation-to-xps/
---
**XPS** formátum szintén széles körben használatos adatok cseréjére. Az Aspose.Slides for .NET figyelembe veszi a fontosságát, és beépített támogatást biztosít egy bemutató XPS dokumentummá konvertálásához.

A **Save** metódus, amelyet a Presentation osztály biztosít, használható a teljes bemutató **XPS** dokumentummá konvertálásához. Továbbá, a **XpsOptions** osztály rendelkezik **SaveMetafileAsPng** tulajdonsággal, amely igény szerint true vagy false értékre állítható.
## **Példa**

``` 

 //Példányosít egy Presentation objektumot, amely egy bemutató fájlt képvisel

Presentation pres = new Presentation("Conversion.ppt");

//A bemutató mentése TIFF dokumentumba

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Futó példa letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
További részletekért látogassa meg a [PowerPoint bemutatók XPS-re konvertálása .NET-ben](/slides/hu/net/convert-powerpoint-to-xps/).
{{% /alert %}}