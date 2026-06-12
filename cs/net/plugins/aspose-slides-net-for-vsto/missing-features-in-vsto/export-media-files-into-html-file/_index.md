---
title: Export mediálních souborů do souboru HTML
type: docs
weight: 80
url: /cs/net/export-media-files-into-html-file/
---
Pro export mediálních souborů do HTML postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation
- Získejte odkaz na snímek
- Nastavte přechodový efekt
- Uložte prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme exportovali mediální soubory do HTML.
## **Příklad**
``` 

 //Načítání prezentace

using (Presentation pres = new Presentation("example.pptx"))

{
   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //Nastavení HTML možností

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Ukládání souboru

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}
``` 
## **Stáhnout běžící příklad**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)