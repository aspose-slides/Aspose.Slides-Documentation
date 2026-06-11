---
title: Konwertuj prezentacje PowerPoint do SWF Flash w .NET
linktitle: PowerPoint do SWF
type: docs
weight: 80
url: /pl/net/convert-powerpoint-to-swf-flash/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do SWF
- prezentacja do SWF
- slajd do SWF
- PPT do SWF
- PPTX do SWF
- PowerPoint do Flash
- prezentacja do Flash
- slajd do Flash
- PPT do Flash
- PPTX do Flash
- zapisz PPT jako SWF
- zapisz PPTX jako SWF
- eksportuj PPT do SWF
- eksportuj PPTX do SWF
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Konwertuj PowerPoint (PPT/PPTX) do SWF Flash w .NET przy użyciu Aspose.Slides. Przykłady kodu C# krok po kroku, szybki i wysokiej jakości wynik, bez automatyzacji PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu SWF przy użyciu Aspose.Slides. Pokazuje, jak zapisać prezentację jako plik SWF przy użyciu metody [Presentation.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/save/) oraz jak skonfigurować eksport przy użyciu [SwfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/swfoptions/), w tym ustawienia podglądu oraz układ notatek lub komentarzy.

## **Konwertuj prezentacje do Flash**

Metoda [Save](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/methods/save/index) udostępniona przez klasę [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) może być użyta do konwersji całej prezentacji do dokumentu SWF.  Można również dołączyć komentarze do wygenerowanego pliku SWF, używając klasy [SWFOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/swfoptions) oraz interfejsu [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/inotescommentslayoutingoptions). Poniższy przykład pokazuje, jak przekonwertować prezentację do dokumentu SWF przy użyciu opcji udostępnionych przez klasę SWFOptions.

```c#
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Zapisanie prezentacji i stron notatek
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **FAQ**

**Czy mogę uwzględnić ukryte slajdy w pliku SWF?**

Tak. Włącz opcję [ShowHiddenSlides](https://reference.aspose.com/slides/pl/net/aspose.slides.export/swfoptions/showhiddenslides/) w [SwfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/swfoptions/). Domyślnie ukryte slajdy nie są eksportowane.

**Jak mogę kontrolować kompresję i ostateczny rozmiar pliku SWF?**

Użyj flagi [Compressed](https://reference.aspose.com/slides/pl/net/aspose.slides.export/swfoptions/compressed/) (włączona domyślnie) i dostosuj [JpegQuality](https://reference.aspose.com/slides/pl/net/aspose.slides.export/swfoptions/jpegquality/), aby zrównoważyć rozmiar pliku i jakość obrazu.

**Do czego służy 'ViewerIncluded' i kiedy należy go wyłączyć?**

[ViewerIncluded](https://reference.aspose.com/slides/pl/net/aspose.slides.export/swfoptions/viewerincluded/) dodaje wbudowany interfejs odtwarzacza (kontrolki nawigacji, panele, wyszukiwanie). Wyłącz go, jeśli planujesz używać własnego odtwarzacza lub potrzebujesz czystej ramki SWF bez interfejsu.

**Co się stanie, jeśli na komputerze eksportującym brak będzie czcionki źródłowej?**

Aspose.Slides zastąpi czcionkę, którą określisz za pomocą [DefaultRegularFont](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveoptions/defaultregularfont/) w [SwfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveoptions/), aby uniknąć niezamierzonego domyślnego zastąpienia.