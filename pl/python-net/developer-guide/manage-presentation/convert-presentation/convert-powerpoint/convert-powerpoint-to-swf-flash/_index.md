---
title: Konwertowanie prezentacji PowerPoint do SWF Flash w Python
linktitle: PowerPoint do SWF Flash
type: docs
weight: 80
url: /pl/python-net/convert-powerpoint-to-swf-flash/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- PowerPoint do SWF
- prezentacja do SWF
- slajd do SWF
- PPT do SWF
- PPTX do SWF
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Konwertuj PowerPoint (PPT/PPTX) do SWF Flash w Python przy użyciu Aspose.Slides. Przykłady kodu krok po kroku, szybki i wysokiej jakości wynik, bez automatyzacji PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu SWF przy użyciu Aspose.Slides. Pokazuje, jak zapisać prezentację jako plik SWF metodą [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) oraz jak skonfigurować eksport przy użyciu [SwfOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/swfoptions/), w tym ustawienia podglądu oraz układ notatek lub komentarzy.

## **Konwertowanie prezentacji do Flash**

Metoda [save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) udostępniona przez klasę [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) może być użyta do konwersji całej prezentacji do dokumentu SWF. Możesz również uwzględnić komentarze w generowanym pliku SWF, używając klasy [SWFOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/swfoptions/) oraz klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notescommentslayoutingoptions/). Poniższy przykład pokazuje, jak skonwertować prezentację do dokumentu SWF przy użyciu opcji udostępnionych przez klasę SWFOptions.

```py
import aspose.slides as slides

# Utwórz obiekt Presentation, który reprezentuje plik prezentacji
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Zapisywanie prezentacji i stron notatek
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **FAQ**

**Czy mogę uwzględnić ukryte slajdy w pliku SWF?**

Tak. Włącz opcję [show_hidden_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) w [SwfOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/swfoptions/). Domyślnie ukryte slajdy nie są eksportowane.

**Jak mogę kontrolować kompresję i ostateczny rozmiar pliku SWF?**

Użyj flagi [compressed](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/swfoptions/compressed/) (włączonej domyślnie) oraz dostosuj [jpeg_quality](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/swfoptions/jpeg_quality/), aby zbalansować rozmiar pliku i jakość obrazu.

**Do czego służy 'viewer_included' i kiedy powinienem je wyłączyć?**

[viewer_included](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/swfoptions/viewer_included/) dodaje wbudowany interfejs odtwarzacza (kontrolki nawigacji, panele, wyszukiwanie). Wyłącz tę opcję, jeśli planujesz używać własnego odtwarzacza lub potrzebujesz czystej ramki SWF bez interfejsu.

**Co się stanie, jeśli na maszynie eksportującej brakuje czcionki źródłowej?**

Aspose.Slides podmieni brakującą czcionkę na tę, którą określisz za pomocą [default_regular_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/swfoptions/default_regular_font/) w [SwfOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/swfoptions/), aby uniknąć niezamierzonego domyślnego zastąpienia.