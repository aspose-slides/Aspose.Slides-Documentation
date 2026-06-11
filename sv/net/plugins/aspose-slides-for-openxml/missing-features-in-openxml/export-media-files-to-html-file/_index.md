---
title: Exportera mediefiler till HTML‑fil
type: docs
weight: 40
url: /sv/net/export-media-files-to-html-file/
---
För att exportera mediefiler till HTML. Följ stegen nedan:

- Skapa en instans av Presentation‑klassen
- Hämta referensen till bilden
- Ställ in övergångseffekten
- Spara presentationen som en PPTX‑fil

I exemplet nedan har vi exporterat mediefilerna till HTML.
## **Exempel**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Laddar en presentation

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Ställer in HTML-alternativ

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Sparar filen

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Ladda ner exempelkod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Ladda ner körbart exempel**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 
För mer information, besök [Exportera mediefiler till html‑fil](/slides/sv/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).
{{% /alert %}}