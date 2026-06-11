---
title: Konwertuj prezentacje PowerPoint do formatu SWF Flash na Androidzie
linktitle: PowerPoint do SWF
type: docs
weight: 80
url: /pl/androidjava/convert-powerpoint-to-swf-flash/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj PowerPoint (PPT/PPTX) do formatu SWF Flash w Javie z Aspose.Slides dla Androida. Przykłady kodu krok po kroku, szybki i wysokiej jakości wynik, bez automatyzacji PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu SWF przy użyciu Aspose.Slides. Pokazuje, jak zapisać prezentację jako plik SWF przy użyciu metody [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) oraz jak skonfigurować eksport za pomocą [SwfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/swfoptions/), w tym ustawienia podglądu oraz układ notatek lub komentarzy.

## **Konwertuj PPT(X) do SWF**
Metoda [Save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) udostępniona przez klasę [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) może być użyta do konwersji całej prezentacji na dokument **SWF**. Poniższy przykład pokazuje, jak przekonwertować prezentację na dokument **SWF** przy użyciu opcji udostępnionych przez klasę [**SWFOptions**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SwfOptions). Można także dołączyć komentarze do generowanego pliku SWF, używając klasy [**ISWFOptions**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISwfOptions) oraz interfejsu [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).

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

Tak. Włącz ukryte slajdy, używając metody [setShowHiddenSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) w [SwfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/swfoptions/). Domyślnie ukryte slajdy nie są eksportowane.

**Jak mogę kontrolować kompresję i ostateczny rozmiar pliku SWF?**

Użyj metody [setCompressed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) oraz [ustaw jakość JPEG](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) aby zrównoważyć rozmiar pliku i jakość obrazu.

**Do czego służy „setViewerIncluded” i kiedy powinienem je wyłączyć?**

[setViewerIncluded](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) dodaje wbudowany interfejs odtwarzacza (sterowanie nawigacją, panele, wyszukiwanie). Wyłącz go, jeśli planujesz używać własnego odtwarzacza lub potrzebujesz czystej ramki SWF bez interfejsu użytkownika.

**Co się stanie, jeśli na maszynie eksportującej brakuje czcionki źródłowej?**

Aspose.Slides zastąpi czcionkę podaną w metodzie [setDefaultRegularFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) w [SwfOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/swfoptions/), aby uniknąć niezamierzonego fallbacku.