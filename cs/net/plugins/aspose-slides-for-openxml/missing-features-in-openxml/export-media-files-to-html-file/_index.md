---
title: Export mediálních souborů do HTML souboru
type: docs
weight: 40
url: /cs/net/export-media-files-to-html-file/
---
Pro export mediálních souborů do HTML postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation
- Získejte odkaz na snímek
- Nastavte přechodový efekt
- Uložte prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme exportovali mediální soubory do HTML.
## **Příklad**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Načítání prezentace

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Nastavení HTML možností

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Ukládání souboru

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Stáhnout spouštěný příklad**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 

Další podrobnosti najdete na [Export mediálních souborů do html souboru](/slides/cs/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}