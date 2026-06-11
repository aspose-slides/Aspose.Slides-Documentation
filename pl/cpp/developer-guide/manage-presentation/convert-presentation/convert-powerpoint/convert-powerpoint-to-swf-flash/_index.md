---
title: Konwertuj prezentacje PowerPoint na SWF Flash w C++
linktitle: PowerPoint do SWF
type: docs
weight: 80
url: /pl/cpp/convert-powerpoint-to-swf-flash/
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
- C++
- Aspose.Slides
description: "Konwertuj PowerPoint (PPT/PPTX) na SWF Flash w C++ przy użyciu Aspose.Slides. Przykłady kodu krok po kroku, szybki wysokiej jakości wynik, bez automatyzacji PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na pliki SWF przy użyciu Aspose.Slides. Pokazuje, jak zapisać prezentację jako plik SWF metodą [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/) oraz jak skonfigurować eksport przy użyciu [SwfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/swfoptions/), w tym ustawienia podglądu oraz układ notatek lub komentarzy.

## **Konwertowanie prezentacji do Flash**

Metoda [Save](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) udostępniona przez klasę [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) może być użyta do konwersji całej prezentacji do dokumentu SWF. Możesz również dołączyć komentarze do wygenerowanego pliku SWF, używając klasy [SWFOptions](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.swf_options) oraz klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notescommentslayoutingoptions/). Poniższy przykład pokazuje, jak przekonwertować prezentację do dokumentu SWF przy użyciu opcji udostępnionych przez klasę SWFOptions.

```cpp
// Ścieżka do katalogu dokumentów.
    System::String dataDir = GetDataPath();

    // Utwórz obiekt Presentation, który reprezentuje plik prezentacji
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Zapisywanie prezentacji i stron z notatkami
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **FAQ**

**Czy mogę uwzględnić ukryte slajdy w pliku SWF?**

Tak. Użyj metody [set_ShowHiddenSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) w [SwfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/swfoptions/). Domyślnie ukryte slajdy nie są eksportowane.

**Jak mogę kontrolować kompresję i ostateczny rozmiar pliku SWF?**

Użyj metody [set_Compressed](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/swfoptions/set_compressed/) oraz dostosuj [JPEG quality](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/swfoptions/set_jpegquality/), aby wyważyć rozmiar pliku i jakość obrazu.

**Do czego służy 'set_ViewerIncluded' i kiedy powinienem go używać?**

[set_ViewerIncluded](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) dodaje wbudowany interfejs odtwarzacza (elementy nawigacyjne, panele, wyszukiwanie). Wyłącz go, jeśli planujesz używać własnego odtwarzacza lub potrzebujesz czystej ramki SWF bez interfejsu.

**Co się stanie, jeśli na komputerze eksportującym brakuje czcionki źródłowej?**

Aspose.Slides zastąpi brakującą czcionkę czcionką określoną za pomocą [set_DefaultRegularFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) w [SwfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/swfoptions/), aby uniknąć niezamierzonego domyślnego zastąpienia.