---
title: Konwersja do PDF
type: docs
weight: 30
url: /pl/net/conversion-to-pdf/
---
Dokumenty PDF są powszechnie używane jako standardowy format wymiany dokumentów między organizacjami, sektorami rządowymi i osobami fizycznymi. Jest to popularny format, więc programiści są często proszeni o konwersję plików prezentacji Microsoft PowerPoint do dokumentów PDF. Mając na uwadze takie możliwe wymaganie, Aspose.Slides for .NET umożliwia konwersję prezentacji do dokumentów PDF bez użycia jakiegokolwiek innego komponentu.

**Aspose.Slides for .NET** oferuje klasę Presentation, która reprezentuje plik prezentacji. Klasa **Presentation** udostępnia metodę Save, którą można wywołać, aby przekonwertować całą prezentację na dokument **PDF**. Klasa **PdfOptions** zapewnia opcje tworzenia **PDF**, takie jak JpegQuality, TextCompression, Compliance i inne. Opcje te można wykorzystać do uzyskania pożądanego standardu PDF.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Utwórz obiekt Presentation, który reprezentuje plik prezentacji

Presentation pres = new Presentation(srcFileName);

//Zapisz prezentację do PDF z domyślnymi opcjami

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)