---
title: Mediendateien in HTML-Datei exportieren
type: docs
weight: 40
url: /de/net/export-media-files-to-html-file/
---

Um Mediendateien nach HTML zu exportieren, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse Presentation
- Holen Sie sich die Referenz der Folie
- Legen Sie den Übergangseffekt fest
- Speichern Sie die Präsentation als PPTX-Datei

Im nachstehenden Beispiel haben wir die Mediendateien nach HTML exportiert.
## **Beispiel**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Loading a presentation

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Setting HTML options

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Saving the file

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Ausführendes Beispiel herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 

Für weitere Details besuchen Sie bitte [Exportieren von Mediendateien in HTML](/slides/de/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}