---
title: Zarządzanie nagłówkami i stopkami prezentacji w JavaScript
linktitle: Nagłówek i stopka
type: docs
weight: 140
url: /pl/nodejs-java/presentation-header-and-footer/
keywords:
- nagłówek
- tekst nagłówka
- stopka
- tekst stopki
- ustaw nagłówek
- ustaw stopkę
- rozpiska
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Użyj JavaScript oraz Aspose.Slides dla Node.js, aby dodać i dostosować nagłówki i stopki w prezentacjach PowerPoint i OpenDocument, zapewniając profesjonalny wygląd."
---
## **Przegląd**

Aspose.Slides pozwala zarządzać ustawieniami nagłówka i stopki w prezentacjach PowerPoint. Nagłówki i stopki są obsługiwane na poziomie mastera prezentacji, a API udostępnia metody do ustawiania tekstu stopki, zmiany widoczności stopki oraz aktualizacji tekstu nagłówka na slajdach mastera notatek.

Można także zarządzać nagłówkami i stopkami w slajdach rozpisków i notatek. Obejmuje to zmianę widoczności i tekstu pól nagłówka, stopki, numeru slajdu oraz daty‑czasu dla mastera notatek, wszystkich podrzędnych slajdów notatek lub pojedynczego slajdu notatek.

## **Zarządzanie nagłówkiem i stopką w prezentacji**
Notatki niektórych konkretnych slajdów mogą zostać usunięte, jak pokazano w przykładzie poniżej:

```javascript
// Załaduj prezentację
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Ustawianie stopki
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Dostęp i aktualizacja nagłówka
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Zapisz prezentację
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Zarządzanie nagłówkiem i stopką w rozpiskach i notatkach**
Aspose.Slides for Node.js via Java obsługuje nagłówek i stopkę w rozpiskach i notatkach. Postępuj według poniższych kroków:

- Załaduj [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) zawierający wideo.
- Zmień ustawienia nagłówka i stopki dla mastera notatek i wszystkich slajdów notatek.
- Ustaw widoczność pól stopki w masterze notatek i we wszystkich podrzędnych slajdach.
- Ustaw widoczność pól daty i czasu w masterze notatek i we wszystkich podrzędnych slajdach.
- Zmień ustawienia nagłówka i stopki tylko dla pierwszego slajdu notatek.
- Ustaw widoczność pola nagłówka w slajdzie notatek.
- Ustaw tekst w polu nagłówka slajdu notatek.
- Ustaw tekst w polu daty‑czasu slajdu notatek.
- Zapisz zmodyfikowany plik prezentacji.

Fragment kodu podany w poniższym przykładzie.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Zmień ustawienia nagłówka i stopki dla mastera notatek i wszystkich slajdów notatek
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// spraw, aby master slajd notatek i wszystkie podrzędne pola stopki były widoczne
        headerFooterManager.setFooterAndChildFootersVisibility(true);// spraw, aby master slajd notatek i wszystkie podrzędne pola nagłówka były widoczne
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// spraw, aby master slajd notatek i wszystkie podrzędne pola numeru slajdu były widoczne
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// spraw, aby master slajd notatek i wszystkie podrzędne pola daty i czasu były widoczne
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// ustaw tekst w master slajdzie notatek i wszystkich podrzędnych polach nagłówka
        headerFooterManager.setFooterAndChildFootersText("Footer text");// ustaw tekst w master slajdzie notatek i wszystkich podrzędnych polach stopki
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// ustaw tekst w master slajdzie notatek i wszystkich podrzędnych polach daty i czasu
    }
    // Zmień ustawienia nagłówka i stopki tylko dla pierwszego slajdu notatek
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// spraw, aby pole nagłówka tego slajdu notatek było widoczne
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// spraw, aby pole stopki tego slajdu notatek było widoczne
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// spraw, aby pole numeru slajdu tego slajdu notatek było widoczne
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// spraw, aby pole daty i czasu tego slajdu notatek było widoczne
        headerFooterManager.setHeaderText("New header text");// ustaw tekst w polu nagłówka slajdu notatek
        headerFooterManager.setFooterText("New footer text");// ustaw tekst w polu stopki slajdu notatek
        headerFooterManager.setDateTimeText("New date and time text");// ustaw tekst w polu daty i czasu slajdu notatek
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę dodać „nagłówek” do zwykłych slajdów?**

W PowerPoint „Nagłówek” istnieje tylko w notatkach i rozpiskach; na zwykłych slajdach obsługiwane elementy to stopka, data/czas oraz numer slajdu. W Aspose.Slides obowiązują te same ograniczenia: nagłówek tylko w Notatkach/Rozpiskach, a na slajdach — Stopka/DataCzas/NumerSlajdu.

**Co zrobić, gdy układ nie zawiera obszaru stopki — czy można „włączyć” jej widoczność?**

Tak. Sprawdź widoczność za pomocą menedżera nagłówka/stopki i włącz ją w razie potrzeby. Te wskaźniki i metody API są przeznaczone dla przypadków, gdy pole zastępcze jest brakujące lub ukryte.

**Jak ustawić, aby numer slajdu zaczynał się od wartości innej niż 1?**

Ustaw [first slide number](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) prezentacji; po tym wszystkie numery są przeliczane. Na przykład możesz rozpocząć od 0 lub 10 oraz ukryć numer na slajdzie tytułowym.

**Co się dzieje z nagłówkami/stopkami przy eksporcie do PDF/obrazów/HTML?**

Są renderowane jako zwykłe elementy tekstowe prezentacji. To znaczy, że jeśli elementy są widoczne na slajdach lub stronach notatek, pojawią się także w formacie wyjściowym wraz z resztą treści.