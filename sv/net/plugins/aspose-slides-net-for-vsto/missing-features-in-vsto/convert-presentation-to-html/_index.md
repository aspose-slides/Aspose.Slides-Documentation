---
title: Konvertera presentation till HTML
type: docs
weight: 40
url: /sv/net/convert-presentation-to-html/
---
**HTML** är ett av flera allmänt använda format för att utbyta data. **Aspose.Slides for .NET** erbjuder stöd för att konvertera en presentation till HTML. Nedan är ett kodexempel som visar hur du gör.
## **Exempel**
``` 

 //Instansiera ett Presentation-objekt som representerar en presentationsfil

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Sparar presentationen till HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Ladda ner körbart exempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Ladda ner exempel kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
För mer information, besök [Convert PowerPoint Presentations to HTML in .NET](/slides/sv/net/convert-powerpoint-to-html/).
{{% /alert %}}