---
title: Eksportuj pliki multimedialne do pliku HTML
type: docs
weight: 80
url: /pl/net/export-media-files-into-html-file/
---
Aby wyeksportować pliki multimedialne do HTML, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy Presentation
- Uzyskaj odwołanie do slajdu
- Ustaw efekt przejścia
- Zapisz prezentację jako plik PPTX

W poniższym przykładzie wyeksportowaliśmy pliki multimedialne do HTML.
## **Przykład**
``` 

 //Ładowanie prezentacji

using (Presentation pres = new Presentation("example.pptx"))

{

   const string path = "path";

   const string fileName = "video.html";

   const string baseUri = "http://www.example.com/";

   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

   //Ustawianie opcji HTML

   HtmlOptions htmlOptions = new HtmlOptions(controller);

   SVGOptions svgOptions = new SVGOptions(controller);

   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

   //Zapisywanie pliku

   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Pobierz działający przykład**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)