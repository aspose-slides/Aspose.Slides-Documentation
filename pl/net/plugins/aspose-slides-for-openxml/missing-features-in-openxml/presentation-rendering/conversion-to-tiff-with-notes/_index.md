---
title: Konwersja do Tiff z notatkami
type: docs
weight: 10
url: /pl/net/conversion-to-tiff-with-notes/
---
TIFF jest jednym z kilku szeroko używanych formatów obrazu, które Aspose.Slides dla .NET obsługuje przy konwertowaniu prezentacji z notatkami na obrazy. Możesz również generować miniatury slajdów w widoku Notatki slajdu. Poniżej znajdują się dwa fragmenty kodu, które pokazują, jak wygenerować obrazy TIFF z prezentacji w widoku Notatki slajdu.

Metoda **Save** udostępniona przez klasę **Presentation** może być użyta do konwersji całej prezentacji w widoku Notatki slajdu do formatu TIFF. Możesz także wygenerować miniaturę slajdu w widoku Notatki slajdu dla poszczególnych slajdów.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Utwórz obiekt Presentation, który reprezentuje plik prezentacji
using (Presentation pres = new Presentation(srcFileName))
{
    //Umieść notatki prelegenta pod każdym renderowanym slajdem
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //Zapisz prezentację jako TIFF z notatkami
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)