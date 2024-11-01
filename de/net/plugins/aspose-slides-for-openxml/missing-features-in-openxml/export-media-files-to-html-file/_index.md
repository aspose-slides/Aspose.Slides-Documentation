---
title: Medien Dateien in HTML-Datei exportieren
type: docs
weight: 40
url: /de/net/export-media-files-to-html-file/
---

Um Medien Dateien in HTML zu exportieren, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der Präsentationsklasse
- Holen Sie sich eine Referenz der Folie
- Einstellen des Übergangseffekts
- Schreiben Sie die Präsentation als PPTX-Datei

Im unten gegebenen Beispiel haben wir die Medien Dateien in HTML exportiert.
## **Beispiel**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Laden einer Präsentation

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Einstellen der HTML-Optionen

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Speichern der Datei

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Laufendes Beispiel herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Export media files into html/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

Für weitere Details besuchen Sie [Exportieren von Medien Dateien in die HTML-Datei](/slides/de/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}