---
title: Konwertowanie prezentacji PowerPoint do SWF Flash w PHP
linktitle: PowerPoint do SWF
type: docs
weight: 80
url: /pl/php-java/convert-powerpoint-to-swf-flash/
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
  - PHP
  - Aspose.Slides
description: "Konwertuj PowerPoint (PPT/PPTX) do SWF Flash w PHP przy użyciu Aspose.Slides. Przykłady kodu krok po kroku, szybki wysokiej jakości wynik, bez automatyzacji PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu SWF przy użyciu Aspose.Slides. Pokazuje, jak zapisać prezentację jako plik SWF przy użyciu metody [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/save/) oraz jak skonfigurować eksport za pomocą [SwfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/swfoptions/), w tym ustawienia podglądu oraz układ notatek lub komentarzy.

## **Konwertowanie prezentacji do Flash**

Metoda [save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/save/) udostępniona przez klasę [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) może być użyta do konwersji całej prezentacji do dokumentu **SWF**. Poniższy przykład pokazuje, jak przekonwertować prezentację do dokumentu **SWF** przy użyciu opcji udostępnionych przez klasę [SWFOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/swfoptions/). Można także dołączyć komentarze do wygenerowanego pliku SWF, używając klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notescommentslayoutingoptions/).

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Zapisywanie prezentacji
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę dołączyć ukryte slajdy do pliku SWF?**

Tak. Włącz ukryte slajdy, używając metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/swfoptions/setshowhiddenslides/) w [SwfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/swfoptions/). Domyślnie ukryte slajdy nie są eksportowane.

**Jak mogę kontrolować kompresję i ostateczny rozmiar pliku SWF?**

Użyj metody [setCompressed](https://reference.aspose.com/slides/pl/php-java/aspose.slides/swfoptions/setcompressed/) oraz [dostosować jakość JPEG](https://reference.aspose.com/slides/pl/php-java/aspose.slides/swfoptions/setjpegquality/) aby zrównoważyć rozmiar pliku i jakość obrazu.

**Po co jest 'setViewerIncluded' i kiedy należy je wyłączyć?**

[setViewerIncluded](https://reference.aspose.com/slides/pl/php-java/aspose.slides/swfoptions/setviewerincluded/) dodaje wbudowany interfejs odtwarzacza (kontrolki nawigacji, panele, wyszukiwanie). Wyłącz ją, jeśli planujesz używać własnego odtwarzacza lub potrzebujesz czystej ramki SWF bez interfejsu.

**Co się stanie, jeśli na komputerze eksportującym brak jest czcionki źródłowej?**

Aspose.Slides zastąpi brakującą czcionkę czcionką określoną przy pomocy [setDefaultRegularFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) w [SwfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/swfoptions/), aby uniknąć niezamierzonego domyślnego zastąpienia.