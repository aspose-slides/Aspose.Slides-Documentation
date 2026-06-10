---
title: Bemutató konvertálása HTML-re
type: docs
weight: 40
url: /hu/net/convert-presentation-to-html/
---
**HTML** a számos, széles körben használt adatcserélési formátum egyike. **Aspose.Slides for .NET** támogatja a bemutató HTML-re konvertálását. Az alábbi kódrészlet megmutatja, hogyan.
## **Példa**
``` 

 //Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//A prezentáció mentése HTML-be

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Futtatható példa letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
További részletekért látogassa meg a [PowerPoint bemutatók HTML-re konvertálása .NET-ben](/slides/hu/net/convert-powerpoint-to-html/).
{{% /alert %}}