---
title: Médiafájlok exportálása HTML-fájlba
type: docs
weight: 40
url: /hu/net/export-media-files-to-html-file/
---
A médiafájlok HTML-be exportálásához kövesse az alábbi lépéseket:

- Hozzon létre egy Presentation osztály példányt
- Szerezze be a dia hivatkozását
- Állítsa be az áttűnési hatást
- Mentse a prezentációt PPTX fájlként

Az alábbi példában a médiafájlokat HTML-be exportáltuk.
## **Példa**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Prezentáció betöltése

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //HTML beállítások megadása

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Fájl mentése

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}
``` 
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Futtatható példa letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 

További részletekért látogasson el a [Médiafájlok exportálása HTML fájlba](/slides/hu/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}