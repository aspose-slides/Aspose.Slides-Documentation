---
title: Konwersja do HTML
type: docs
weight: 20
url: /pl/net/conversion-to-html/
---
**HTML** jest jednym z kilku powszechnie używanych formatów wymiany danych. **Aspose.Slides for .NET** zapewnia wsparcie dla konwertowania prezentacji do HTML. Poniżej znajduje się fragment kodu, który pokazuje, jak to zrobić.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Utwórz obiekt Presentation, który reprezentuje plik prezentacji

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Zapis prezentacji do HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)