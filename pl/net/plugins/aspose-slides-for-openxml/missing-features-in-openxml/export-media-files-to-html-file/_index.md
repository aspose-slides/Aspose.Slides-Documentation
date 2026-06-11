---
title: Eksportowanie plików multimedialnych do pliku HTML
type: docs
weight: 40
url: /pl/net/export-media-files-to-html-file/
---
Aby wyeksportować pliki multimedialne do formatu HTML, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy Presentation
- Uzyskaj odniesienie do slajdu
- Ustaw efekt przejścia
- Zapisz prezentację jako plik PPTX

W poniższym przykładzie wyeksportowaliśmy pliki multimedialne do HTML.
## **Przykład**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Ładowanie prezentacji

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Ustawianie opcji HTML

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Zapisywanie pliku

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Pobierz działający przykład**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 
Po więcej szczegółów odwiedź [Eksportowanie plików multimedialnych do pliku html](/slides/pl/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).
{{% /alert %}}