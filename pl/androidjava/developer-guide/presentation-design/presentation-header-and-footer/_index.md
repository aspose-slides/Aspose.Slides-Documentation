---
title: Zarządzanie nagłówkami i stopkami prezentacji w Androidzie
linktitle: Nagłówek i stopka
type: docs
weight: 140
url: /pl/androidjava/presentation-header-and-footer/
keywords:
- nagłówek
- tekst nagłówka
- stopka
- tekst stopki
- ustaw nagłówek
- ustaw stopkę
- materiały
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Użyj Aspose.Slides dla Androida w języku Java, aby dodać i dostosować nagłówki oraz stopki w prezentacjach PowerPoint i OpenDocument, zapewniając profesjonalny wygląd."
---
## **Przegląd**

Aspose.Slides umożliwia zarządzanie ustawieniami nagłówka i stopki w prezentacjach PowerPoint. Nagłówki i stopki są obsługiwane na poziomie mastera prezentacji, a API zapewnia metody ustawiania tekstu stopki, zmiany widoczności stopki oraz aktualizacji tekstu nagłówka na masterowych slajdach notatek.

Możesz również zarządzać nagłówkami i stopkami w slajdach wersji rozrzuconych i notatek. Obejmuje to zmianę widoczności i tekstu pól zastępczych nagłówka, stopki, numeru slajdu oraz daty i godziny dla mastera notatek, wszystkich podrzędnych slajdów notatek lub pojedynczego slajdu notatek.

## **Zarządzanie nagłówkami i stopkami w prezentacji**
Notatki niektórych konkretnych slajdów mogą zostać usunięte, jak pokazano w poniższym przykładzie:

```java
// Wczytaj prezentację
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Ustawianie stopki
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Dostęp i aktualizacja nagłówka
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Zapisz prezentację
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Metoda ustawiająca tekst nagłówka/stopki
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Zarządzanie nagłówkami i stopkami w wersjach rozrzuconych i slajdach notatek**
Aspose.Slides dla Androida w wersji Java obsługuje nagłówki i stopki w wersjach rozrzuconych i slajdach notatek. Proszę wykonać poniższe kroki:

- Załaduj [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) zawierającą wideo.
- Zmień ustawienia nagłówka i stopki dla mastera notatek oraz wszystkich slajdów notatek.
- Ustaw widoczność pól zastępczych stopki w masterze notatek i wszystkich podrzędnych slajdach.
- Ustaw widoczność pól zastępczych daty i godziny w masterze notatek i wszystkich podrzędnych slajdach.
- Zmień ustawienia nagłówka i stopki tylko dla pierwszego slajdu notatek.
- Ustaw widoczność pola zastępczego nagłówka w slajdzie notatek.
- Ustaw tekst w polu zastępczym nagłówka slajdu notatek.
- Ustaw tekst w polu zastępczym daty i godziny slajdu notatek.
- Zapisz zmodyfikowany plik prezentacji.

Fragment kodu podany w poniższym przykładzie.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Zmień ustawienia nagłówka i stopki dla mastera notatek i wszystkich slajdów notatek
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // spraw, aby masterowy slajd notatek oraz wszystkie podrzędne pola zastępcze stopki były widoczne
        headerFooterManager.setFooterAndChildFootersVisibility(true); // spraw, aby masterowy slajd notatek oraz wszystkie podrzędne pola zastępcze nagłówka były widoczne
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // spraw, aby masterowy slajd notatek oraz wszystkie podrzędne pola zastępcze numeru slajdu były widoczne
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // spraw, aby masterowy slajd notatek oraz wszystkie podrzędne pola zastępcze daty i godziny były widoczne

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // ustaw tekst w masterowym slajdzie notatek oraz wszystkich podrzędnych polach zastępczych nagłówka
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // ustaw tekst w masterowym slajdzie notatek oraz wszystkich podrzędnych polach zastępczych stopki
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // ustaw tekst w masterowym slajdzie notatek oraz wszystkich podrzędnych polach zastępczych daty i godziny
    }

    // Zmień ustawienia nagłówka i stopki tylko dla pierwszego slajdu notatek
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // spraw, aby pole zastępcze nagłówka tego slajdu notatek było widoczne

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // spraw, aby pole zastępcze stopki tego slajdu notatek było widoczne

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // spraw, aby pole zastępcze numeru slajdu tego slajdu notatek było widoczne

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // spraw, aby pole zastępcze daty i czasu tego slajdu notatek było widoczne

        headerFooterManager.setHeaderText("New header text"); // ustaw tekst w polu zastępczym nagłówka slajdu notatek
        headerFooterManager.setFooterText("New footer text"); // ustaw tekst w polu zastępczym stopki slajdu notatek
        headerFooterManager.setDateTimeText("New date and time text"); // ustaw tekst w polu zastępczym daty i czasu slajdu notatek
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę dodać „nagłówek” do zwykłych slajdów?**

W programie PowerPoint „Nagłówek” istnieje tylko w notatkach i wersjach rozrzuconych; w zwykłych slajdach obsługiwane elementy to stopka, data/godzina i numer slajdu. W Aspose.Slides obowiązują te same ograniczenia: nagłówek tylko w Notatkach/Wersjach rozrzuconych, a na slajdach – Stopka/DataTime/SlideNumber.

**Co zrobić, jeśli układ nie zawiera obszaru stopki – czy można włączyć jej widoczność?**

Tak. Sprawdź widoczność za pomocą menedżera nagłówka/stopki i w razie potrzeby ją włącz. Te wskaźniki API i metody są przeznaczone do przypadków, gdy pole zastępcze jest nieobecne lub ukryte.

**Jak ustawić, aby numer slajdu zaczynał się od wartości innej niż 1?**

Ustaw [first slide number](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) prezentacji; po tym wszystkie numery zostaną przeliczone. Na przykład możesz rozpocząć od 0 lub 10 oraz ukryć numer na slajdzie tytułowym.

**Co się dzieje z nagłówkami/stopkami przy eksporcie do PDF/obrazów/HTML?**

Są renderowane jako zwykłe elementy tekstowe prezentacji. Oznacza to, że jeśli elementy są widoczne na slajdach lub stronach notatek, pojawią się również w formacie wyjściowym wraz z resztą treści.