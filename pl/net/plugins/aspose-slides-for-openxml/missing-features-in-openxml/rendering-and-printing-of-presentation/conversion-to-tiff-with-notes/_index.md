---
title: Konwersja do TIFF z notatkami
type: docs
weight: 10
url: /pl/net/conversion-to-tiff-with-notes/
---
TIFF jest jednym z kilku powszechnie używanych formatów obrazu, które Aspose.Slides dla .NET obsługuje przy konwertowaniu prezentacji z notatkami na obrazy. Możesz również generować miniatury slajdów w widoku Notatek slajdu. Poniżej znajdują się dwa fragmenty kodu, które pokazują, jak wygenerować obrazy TIFF prezentacji w widoku Notatek slajdu.

Metoda **Save** udostępniona przez klasę **Presentation** może być użyta do konwersji całej prezentacji w widoku Notatek slajdu do formatu TIFF. Możesz także wygenerować miniaturę slajdu w widoku Notatek slajdu dla poszczególnych slajdów.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Utwórz obiekt Presentation, który reprezentuje plik prezentacji

Presentation pres = new Presentation(srcFileName);

//Zapis prezentacji do notatek TIFF

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)