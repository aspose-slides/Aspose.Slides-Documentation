---
title: Konwertuj prezentacje PowerPoint na SWF Flash w Javie
linktitle: PowerPoint do SWF
type: docs
weight: 80
url: /pl/java/convert-powerpoint-to-swf-flash/
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
- Java
- Aspose.Slides
description: "Konwertuj PowerPoint (PPT/PPTX) na SWF Flash w Javie z Aspose.Slides. Przykłady kodu krok po kroku, szybki i wysokiej jakości wynik, bez automatyzacji PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak przy użyciu Aspose.Slides konwertować prezentacje PowerPoint na format SWF. Pokazuje, jak zapisać prezentację jako plik SWF przy użyciu metody [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) oraz jak skonfigurować eksport przy pomocy [SwfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/swfoptions/), w tym ustawienia podglądu oraz układ notatek lub komentarzy.

## **Konwertowanie prezentacji na Flash**

Metoda [save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) udostępniona przez klasę [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) może zostać użyta do konwersji całej prezentacji do dokumentu **SWF**. Poniższy przykład pokazuje, jak konwertować prezentację do dokumentu **SWF** przy użyciu opcji udostępnionych przez klasę [**SWFOptions**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SwfOptions). Można również dołączyć komentarze w generowanym pliku SWF przy pomocy klasy [**ISWFOptions**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISwfOptions) oraz interfejsu [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INotesCommentsLayoutingOptions).

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Zapisywanie prezentacji
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```
## **FAQ**

**Czy mogę uwzględnić ukryte slajdy w pliku SWF?**

Tak. Włącz ukryte slajdy, używając metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) w klasie [SwfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/swfoptions/). Domyślnie ukryte slajdy nie są eksportowane.

**Jak mogę kontrolować kompresję i ostateczny rozmiar pliku SWF?**

Użyj metody [setCompressed](https://reference.aspose.com/slides/pl/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) oraz [adjust JPEG quality](https://reference.aspose.com/slides/pl/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) aby zrównoważyć rozmiar pliku i jakość obrazu.

**Do czego służy „setViewerIncluded” i kiedy powinienem je wyłączyć?**

Metoda [setViewerIncluded](https://reference.aspose.com/slides/pl/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) dodaje wbudowany interfejs odtwarzacza (kontrolki nawigacji, panele, wyszukiwanie). Wyłącz ją, jeśli planujesz używać własnego odtwarzacza lub potrzebujesz czystego pliku SWF bez interfejsu użytkownika.

**Co się stanie, jeśli na maszynie eksportującej brakuje źródłowej czcionki?**

Aspose.Slides zastąpi brakującą czcionkę czcionką określoną w metodzie [setDefaultRegularFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) w [SwfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/swfoptions/), aby uniknąć niezamierzonego zastąpienia.