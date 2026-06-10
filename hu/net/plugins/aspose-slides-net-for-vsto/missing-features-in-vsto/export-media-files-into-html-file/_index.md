---
title: Médiafájlok exportálása HTML fájlba
type: docs
weight: 80
url: /hu/net/export-media-files-into-html-file/
---
A médiafájlok HTML-be exportálásához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból
- Szerezze be a diára való hivatkozást
- Állítsa be az áttűnési hatást
- Mentse a bemutatót PPTX fájlként

Az alábbi példában a médiafájlokat HTML-be exportáltuk.
## **Példa**
``` 

 //Prezentáció betöltése

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //HTML beállítások megadása

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Fájl mentése

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Futó példa letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)