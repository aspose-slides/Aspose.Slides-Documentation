---
title: Konwertuj prezentację do HTML
type: docs
weight: 40
url: /pl/net/convert-presentation-to-html/
---
**HTML** jest jednym z kilku powszechnie używanych formatów wymiany danych. **Aspose.Slides for .NET** zapewnia wsparcie dla konwersji prezentacji do HTML. Poniżej znajduje się fragment kodu pokazujący, jak to zrobić.
## **Przykład**
``` 

 //Utwórz obiekt Presentation, który reprezentuje plik prezentacji

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Zapisywanie prezentacji do HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Pobierz działający przykład**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Aby uzyskać więcej szczegółów, odwiedź [Convert PowerPoint Presentations to HTML in .NET](/slides/pl/net/convert-powerpoint-to-html/).

{{% /alert %}}