---
title: Renderowane jako Tiff
type: docs
weight: 30
url: /pl/net/rendered-as-tiff/
---
Format TIFF jest znany ze swojej elastyczności w obsłudze obrazów wielostronicowych i danych. Mając na uwadze znaczenie i popularność formatu TIFF, Aspose.Slides for .NET zapewnia wsparcie dla konwersji prezentacji do dokumentu TIFF.
Ten artykuł wyjaśnia różne opcje eksportu tiff:

- Konwersja prezentacji do TIFF z domyślnym rozmiarem.
- Konwersja prezentacji do TIFF z niestandardowym rozmiarem.

Metoda **Save** udostępniona przez klasę **Presentation** może być wywołana przez programistów w celu konwersji całej prezentacji do dokumentu **TIFF**. Ponadto klasa TiffOptions udostępnia właściwość ImageSize, umożliwiającą określenie rozmiaru obrazu, jeśli jest to wymagane.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Utwórz obiekt Presentation, który reprezentuje plik prezentacji

using (Presentation pres = new Presentation(srcFileName))

{

    //Zapisanie prezentacji jako dokument TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)