---
title: Konwersja do XPS
type: docs
weight: 40
url: /pl/net/conversion-to-xps/
---
**XPS** format jest również powszechnie używany do wymiany danych. Aspose.Slides dla .NET dba o jego znaczenie i zapewnia wbudowane wsparcie dla konwertowania prezentacji na dokument XPS.

Metoda **Save** udostępniona przez klasę Presentation może być użyta do konwersji całej prezentacji do dokumentu **XPS**. Ponadto klasa **XpsOptions** udostępnia właściwość **SaveMetafileAsPng**, którą można ustawić na true lub false według potrzeb.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Utwórz obiekt Presentation, który reprezentuje plik prezentacji

Presentation pres = new Presentation(srcFileName);

//Zapisywanie prezentacji do dokumentu TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)