---
title: Mediabestanden exporteren naar HTML-bestand
type: docs
weight: 40
url: /nl/net/export-media-files-to-html-file/
---
Om mediabestanden te exporteren naar HTML. Volg de onderstaande stappen:

- Maak een instantie van de Presentation‑klasse
- Haal een referentie op van de dia
- Stel het overgangseffect in
- Schrijf de presentatie als een PPTX‑bestand

In het onderstaande voorbeeld hebben we de mediabestanden geëxporteerd naar HTML.
## **Voorbeeld**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Een presentatie laden

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //HTML‑opties instellen

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Het bestand opslaan

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Download voorbeeldcode**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Werkend voorbeeld downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 

Voor meer details, bezoek [Mediabestanden exporteren naar html‑bestand](/slides/nl/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}