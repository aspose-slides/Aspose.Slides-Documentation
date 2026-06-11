---
title: Konwertuj prezentacje PowerPoint do SWF Flash w JavaScript
linktitle: PowerPoint do SWF
type: docs
weight: 80
url: /pl/nodejs-java/convert-powerpoint-to-swf-flash/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj PowerPoint (PPT/PPTX) do SWF Flash przy użyciu Aspose.Slides dla Node.js. Przykłady kodu krok po kroku, szybki i wysokiej jakości wynik, bez automatyzacji PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu SWF przy użyciu Aspose.Slides. Pokazuje, jak zapisać prezentację jako plik SWF przy użyciu metody [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save) i jak skonfigurować eksport za pomocą [SwfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/swfoptions/), w tym ustawienia przeglądarki oraz układ notatek lub komentarzy.

## **Konwertuj PPT(X) do SWF**
Metoda [save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) udostępniona przez klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) może być użyta do konwersji całej prezentacji do dokumentu **SWF**. Poniższy przykład pokazuje, jak przekonwertować prezentację do dokumentu **SWF** przy użyciu opcji dostarczonych przez klasę [**SWFOptions**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SwfOptions). Można również dołączyć komentarze w generowanym pliku SWF, używając klasy [**SWFOptions**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SwfOptions) oraz klasy [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions).

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Zapisywanie prezentacji
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę uwzględnić ukryte slajdy w pliku SWF?**

Tak. Użyj metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) w [SwfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/swfoptions/). Domyślnie ukryte slajdy nie są eksportowane.

**Jak mogę kontrolować kompresję i ostateczny rozmiar pliku SWF?**

Użyj metod [setCompressed](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/swfoptions/setcompressed/) i [setJpegQuality](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/swfoptions/setjpegquality/), aby zrównoważyć rozmiar pliku i jakość obrazu.

**Do czego służy 'setViewerIncluded' i kiedy powinienem go używać?**

[setViewerIncluded](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) dodaje wbudowany interfejs odtwarzacza (elementy nawigacji, panele, wyszukiwanie). Użyj go, jeśli zamierzasz korzystać z własnego odtwarzacza lub potrzebujesz czystej ramki SWF bez interfejsu użytkownika.

**Co się stanie, gdy na komputerze eksportującym brakuje czcionki źródłowej?**

Aspose.Slides zastąpi czcionkę określoną za pomocą [setDefaultRegularFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) w [SwfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/swfoptions/), aby uniknąć niezamierzonego zastąpienia.