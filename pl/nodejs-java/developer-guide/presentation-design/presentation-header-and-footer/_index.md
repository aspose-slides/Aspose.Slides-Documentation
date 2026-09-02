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
- materiał rozdawniczy
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak zarządzać polami zastępczymi stopki, daty i godziny, numeru slajdu oraz nagłówka na slajdach, stronach notatek i materiałach rozdawniczych przy użyciu Aspose.Slides for Node.js via Java."
---
## **Przegląd**

PowerPoint używa różnych pól zastępczych nagłówka i stopki w zależności od typu strony. Aspose.Slides dla Node.js via Java umożliwia kontrolowanie tekstu i widoczności tych pól zastępczych za pomocą klas menedżera nagłówka/stopki.

Dostępne pola zastępcze zależą od zakresu:

| Zakres | Nagłówek | Stopka | Data/godzina | Numer slajdu/strony |
|---|---|---|---|---|
| Zwykły slajd | Nie | Tak | Tak | Tak |
| Mistrz notatek | Tak | Tak | Tak | Tak |
| Slajd notatek | Tak | Tak | Tak | Tak |
| Mistrz wersji wydruku | Tak | Tak | Tak | Tak |

Zwykły slajd prezentacji nie posiada pola zastępczego nagłówka. Nagłówki są dostępne na stronach notatek i materiałach rozdawniczych. Dla zwykłych slajdów używaj pól zastępczych stopki, daty/godziny oraz numeru slajdu zamiast nich.

Zakres zmiany zależy od używanego menedżera. Klasa [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideheaderfootermanager/) steruje jednym zwykłym slajdem. Klasa [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notesslideheaderfootermanager/) steruje jednym slajdem notatek. Menedżery mistrza i układu mogą także propagować ustawienia do zależnych slajdów, podczas gdy klasa [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) steruje mistrzem wersji wydruku.

## **Ustaw stopkę, datę/godzinę i numery slajdów na zwykłych slajdach**

Dla zwykłych slajdów podstawowy przebieg pracy polega na uzyskaniu menedżera nagłówka/stopki każdego slajdu, ustawieniu tekstu stopki i daty/godziny, włączeniu wymaganych pól zastępczych oraz zapisaniu prezentacji. Numery slajdów są generowane przez prezentację, więc musisz kontrolować jedynie ich widoczność.

Użyj [`setFooterText`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) i [`setDateTimeText`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) aby ustawić tekst, oraz użyj [`setFooterVisibility`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) i [`setSlideNumberVisibility`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) aby wyświetlić odpowiednie pola zastępcze.

Poniższy przykład końcowy stosuje tę samą stopkę, tekst daty/godziny oraz widoczność numeru slajdu do wszystkich zwykłych slajdów:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli potrzebujesz zaktualizować tylko jeden slajd, uzyskaj dostęp do tego slajdu bezpośrednio za pomocą metody [`getSlides`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getslides/) zamiast iterować po całej kolekcji.

## **Ustaw nagłówki i stopki w mistrzu notatek**

Mistrz notatek definiuje wspólne formatowanie i zachowanie pól zastępczych dla stron notatek. Użyj klasy [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) gdy chcesz zmienić tylko sam mistrz notatek.

Poniższy przykład ustawia tekst nagłówka, stopki i daty/godziny w mistrzu notatek oraz sprawia, że wszystkie obsługiwane pola zastępcze są widoczne w tym mistrzu:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoda [`getMasterNotesSlide`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) zwraca `null`, gdy prezentacja nie zawiera mistrza notatek.

## **Zastosuj ustawienia mistrza notatek do podrzędnych slajdów notatek**

Mistrz notatek może zastosować ustawienia nagłówka i stopki do siebie oraz do wszystkich zależnych slajdów notatek. Użyj dedykowanych metod propagacji w klasie [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) gdy te same ustawienia mają być stosowane w całej hierarchii notatek.

Na przykład, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) i [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) aktualizują nagłówek mistrza notatek oraz wszystkie nagłówki podrzędne. Dostępne są równoważne metody dla stopek, daty/godziny i numerów slajdów.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metody propagacji użyte powyżej to [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) oraz [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Ustaw nagłówki i stopki w pojedynczym slajdzie notatek**

Slajd notatek należy do konkretnego zwykłego slajdu. Użyj jego klasy [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notesslideheaderfootermanager/) gdy chcesz dostosować tylko tę stronę notatek.

Metoda [`addNotesSlide`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) zwraca slajd notatek dla bieżącego slajdu i tworzy go, jeśli jeszcze nie istnieje. Poniższy przykład konfiguruje stronę notatek powiązaną z pierwszym slajdem prezentacji:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli najpierw propagujesz ustawienia z mistrza notatek, a następnie zmienisz pojedynczy slajd notatek, późniejsze ustawienia per-slajd pozwalają na niezależne dostosowanie tej strony notatek.

## **Ustaw nagłówki i stopki w mistrzu wersji wydruku**

Strony wersji wydruku używają mistrza wersji wydruku dla swoich pól zastępczych nagłówka, stopki, daty/godziny i numeru strony. W przeciwieństwie do stron notatek, ustawienia wersji wydruku są zarządzane przez mistrza wersji wydruku, a nie przez pojedyncze slajdy wersji wydruku.

Użyj [`getMasterHandoutSlide`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) aby uzyskać dostęp do mistrza wersji wydruku. Jeśli nie istnieje, wywołaj [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) aby utworzyć domyślny mistrz wersji wydruku.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zrozum zakres i dziedziczenie**

Wybierz menedżera nagłówka/stopki, który odpowiada zakresowi, który chcesz zmienić:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideheaderfootermanager/) zmienia ustawienia stopki, daty/godziny i numeru slajdu dla jednego zwykłego slajdu.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) steruje slajdem układu i może propagować obsługiwane ustawienia do zależnych slajdów.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslideheaderfootermanager/) steruje mistrzem zwykłych slajdów i może propagować obsługiwane ustawienia do zależnych slajdów.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) steruje mistrzem notatek i może propagować ustawienia do wszystkich zależnych slajdów notatek.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notesslideheaderfootermanager/) zmienia jeden slajd notatek i obsługuje pole nagłówka oprócz stopki, daty/godziny i numeru slajdu.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) zmienia mistrza wersji wydruku i obsługuje wszystkie cztery typy pól zastępczych.

Użyj propagacji z mistrza lub układu, gdy to samo ustawienie ma obowiązywać w całej hierarchii. Użyj menedżera pojedynczego slajdu lub slajdu notatek, gdy potrzebujesz lokalnego ustawienia dla jednej strony.

## **FAQ**

**Czy mogę dodać nagłówek do zwykłego slajdu?**

Nie. PowerPoint nie definiuje pola zastępczego nagłówka dla zwykłych slajdów. Na zwykłych slajdach używaj pól zastępczych stopki, daty/godziny i numeru slajdu. Pola nagłówka są dostępne na stronach notatek i materiałach rozdawniczych.

**Co zrobić, gdy pole zastępcze stopki, daty/godziny lub numeru slajdu nie jest widoczne?**

Użyj odpowiedniego menedżera nagłówka/stopki, aby sprawdzić jego widoczność i w razie potrzeby ją włączyć. Na przykład, [`isFooterVisible`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) informuje, czy pole zastępcze stopki jest obecne, a [`setFooterVisibility`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) zmienia jego widoczność.

**Jak rozpocząć numerację slajdów od wartości innej niż 1?**

Wywołaj metodę [`setFirstSlideNumber`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) prezentacji. Pola zastępcze numeru slajdu będą wtedy używać zaktualizowanej sekwencji numeracji.

**Co się dzieje z nagłówkami i stopkami podczas eksportu do PDF, obrazów lub HTML?**

Widoczne elementy nagłówka i stopki są renderowane wraz z pozostałą zawartością prezentacji w wyjściowym formacie. Ich wygląd zależy od eksportowanego typu strony oraz od ustawień widoczności odpowiednich pól zastępczych.