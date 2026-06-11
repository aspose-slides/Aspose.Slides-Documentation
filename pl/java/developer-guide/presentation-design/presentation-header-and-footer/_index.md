---
title: Zarządzanie nagłówkami i stopkami prezentacji w Javie
linktitle: Nagłówek i stopka
type: docs
weight: 140
url: /pl/java/presentation-header-and-footer/
keywords:
- nagłówek
- tekst nagłówka
- stopka
- tekst stopki
- ustaw nagłówek
- ustaw stopkę
- rozdanie
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Użyj Aspose.Slides dla Javy, aby dodać i dostosować nagłówki oraz stopki w prezentacjach PowerPoint i OpenDocument, uzyskując profesjonalny wygląd."
---
## **Przegląd**

Aspose.Slides umożliwia zarządzanie ustawieniami nagłówka i stopki w prezentacjach PowerPoint. Nagłówki i stopki są obsługiwane na poziomie mastera prezentacji, a API udostępnia metody ustawiania tekstu stopki, zmiany widoczności stopki oraz aktualizacji tekstu nagłówka na slajdach notatek mastera.

Możesz również zarządzać nagłówkami i stopkami dla slajdów rozdania i notatek. Obejmuje to zmianę widoczności i tekstu pól zastępczych nagłówka, stopki, numeru slajdu oraz daty i godziny dla mastera notatek, wszystkich podrzędnych slajdów notatek lub pojedynczego slajdu notatek.

## **Zarządzaj nagłówkami i stopkami w prezentacji**
Notatki niektórych konkretnych slajdów mogą zostać usunięte, jak pokazano w przykładzie poniżej:

```java
// Załaduj prezentację
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

## **Zarządzaj nagłówkami i stopkami na slajdach rozdania i notatek**
Aspose.Slides for Java obsługuje nagłówek i stopkę w slajdach rozdania i notatek. Proszę postępować zgodnie z poniższymi krokami:

- Załaduj [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) zawierający wideo.
- Zmień ustawienia nagłówka i stopki dla mastera notatek i wszystkich slajdów notatek.
- Ustaw widoczność wszystkich pól zastępczych Footer w masterze notatek i wszystkich podrzędnych slajdach.
- Ustaw widoczność wszystkich pól zastępczych Date i time w masterze notatek i wszystkich podrzędnych slajdach.
- Zmień ustawienia nagłówka i stopki tylko dla pierwszego slajdu notatek.
- Ustaw widoczny pole zastępcze Header w slajdzie notatek.
- Ustaw tekst w polu zastępczym Header slajdu notatek.
- Ustaw tekst w polu zastępczym Date-time slajdu notatek.
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

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // spraw, aby master slajd notatek i wszystkie podrzędne pola zastępcze stopki były widoczne
        headerFooterManager.setFooterAndChildFootersVisibility(true); // spraw, aby master slajd notatek i wszystkie podrzędne pola zastępcze nagłówka były widoczne
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // spraw, aby master slajd notatek i wszystkie podrzędne pola zastępcze numeru slajdu były widoczne
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // spraw, aby master slajd notatek i wszystkie podrzędne pola zastępcze daty i czasu były widoczne

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // ustaw tekst w master slajdzie notatek oraz wszystkich podrzędnych polach zastępczych nagłówka
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // ustaw tekst w master slajdzie notatek oraz wszystkich podrzędnych polach zastępczych stopki
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // ustaw tekst w master slajdzie notatek oraz wszystkich podrzędnych polach zastępczych daty i czasu
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

W programie PowerPoint „Header” istnieje tylko dla notatek i rozdania; na zwykłych slajdach obsługiwane elementy to stopka, data/godzina oraz numer slajdu. W Aspose.Slides obowiązują te same ograniczenia: nagłówek tylko dla Notatek/Rozdania, a na slajdach — Footer/DateTime/SlideNumber.

**Co jeśli układ nie zawiera obszaru stopki — czy mogę „włączyć” jej widoczność?**

Tak. Sprawdź widoczność za pomocą menedżera nagłówka/stopki i włącz ją w razie potrzeby. Te wskaźniki i metody API są przeznaczone do sytuacji, gdy pole zastępcze jest nieobecne lub ukryte.

**Jak sprawić, aby numer slajdu zaczynał się od wartości innej niż 1?**

Ustaw [first slide number](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) prezentacji; po tym wszystkie numery zostaną przeliczone. Na przykład możesz rozpocząć od 0 lub 10 oraz ukryć numer na slajdzie tytułowym.

**Co się dzieje z nagłówkami/stopkami podczas eksportu do PDF/obrazów/HTML?**

Są renderowane jako zwykłe elementy tekstowe prezentacji. Oznacza to, że jeśli elementy są widoczne na slajdach/stronach notatek, pojawią się również w formacie wyjściowym wraz z resztą treści.