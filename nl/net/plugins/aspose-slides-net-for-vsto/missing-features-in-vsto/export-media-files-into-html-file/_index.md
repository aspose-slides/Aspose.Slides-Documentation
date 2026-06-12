---
title: Mediabestanden exporteren naar HTML‑bestand
type: docs
weight: 80
url: /nl/net/export-media-files-into-html-file/
---
Om mediabestanden naar HTML te exporteren, volgt u de onderstaande stappen:

- Maak een instantie van de klasse Presentation
- Verkrijg een referentie naar de dia
- Stel het overgangseffect in
- Schrijf de presentatie weg als een PPTX‑bestand

In het onderstaande voorbeeld hebben we de mediabestanden geëxporteerd naar HTML.
## **Voorbeeld**
``` 

 //Presentatie laden

using (Presentation pres = new Presentation("example.pptx"))
{
   const string path = "path";
   const string fileName = "video.html";
   const string baseUri = "http://www.example.com/";
   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);
   //HTML‑opties instellen
   HtmlOptions htmlOptions = new HtmlOptions(controller);
   SVGOptions svgOptions = new SVGOptions(controller);
   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);
   //Bestand opslaan
   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);
}
``` 
## **Download Werkend Voorbeeld**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Download Voorbeeldcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)