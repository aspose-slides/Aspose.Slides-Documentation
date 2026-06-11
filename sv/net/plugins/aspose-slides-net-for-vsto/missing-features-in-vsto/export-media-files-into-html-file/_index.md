---
title: Exportera mediafiler till HTML-fil
type: docs
weight: 80
url: /sv/net/export-media-files-into-html-file/
---
För att exportera mediafiler till HTML. Följ stegen nedan:

- Skapa en instans av Presentation-klassen
- Hämta referensen till bilden
- Ställ in övergångseffekten
- Skriv presentationen som en PPTX-fil

I exemplet nedan har vi exporterat mediafilerna till HTML.
## **Exempel**
``` 

 //Laddar en presentation

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //Ställer in HTML-alternativ

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Sparar filen

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

```
## **Ladda ner körande exempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Ladda ner exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)