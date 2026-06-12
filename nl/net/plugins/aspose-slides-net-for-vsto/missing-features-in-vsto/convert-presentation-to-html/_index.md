---
title: Presentatie converteren naar HTML
type: docs
weight: 40
url: /nl/net/convert-presentation-to-html/
---
**HTML** is een van de verschillende veelgebruikte formaten voor het uitwisselen van gegevens. **Aspose.Slides for .NET** biedt ondersteuning voor het converteren van een presentatie naar HTML. Hieronder staat een codefragment dat laat zien hoe.
## **Voorbeeld**
``` 

 //Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//De presentatie opslaan als HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Werkend voorbeeld downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Voorbeeldcode downloaden**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Voor meer details, bezoek [PowerPoint-presentaties naar HTML converteren in .NET](/slides/nl/net/convert-powerpoint-to-html/).
{{% /alert %}}