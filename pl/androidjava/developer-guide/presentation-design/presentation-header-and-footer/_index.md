---
title: Zarządzanie nagłówkami i stopkami prezentacji w systemie Android
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
- materiały rozdawnicze
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać polami zastępczymi stopki, daty/godziny, numeru slajdu i nagłówka na slajdach, stronach notatek i materiałach rozdawniczych przy użyciu Aspose.Slides for Android via Java."
---
## **Omówienie**

PowerPoint używa różnych pól zastępczych nagłówka i stopki w zależności od typu strony. Aspose.Slides for Android via Java umożliwia kontrolowanie tekstu i widoczności tych pól zastępczych za pomocą interfejsów menedżera nagłówka/stopki.

Dostępne pola zastępcze zależą od zakresu:

| Zakres | Nagłówek | Stopka | Data/godzina | Numer slajdu/strony |
|---|---|---|---|---|
| Zwykły slajd | Nie | Tak | Tak | Tak |
| Mistrz notatek | Tak | Tak | Tak | Tak |
| Slajd notatek | Tak | Tak | Tak | Tak |
| Mistrz wersji | Tak | Tak | Tak | Tak |

Zwykły slajd prezentacji nie ma pola zastępczego nagłówka. Nagłówki są dostępne na stronach notatek i materiałach rozdawniczych. Dla zwykłych slajdów użyj pól zastępczych stopki, daty/godziny oraz numeru slajdu.

Zakres zmiany zależy od używanego menedżera. Interfejs [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideheaderfootermanager/) steruje jednym zwykłym slajdem. Interfejs [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) steruje jednym slajdem notatek. Menedżery master i layout mogą również propagować ustawienia do zależnych slajdów, natomiast interfejs [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) steruje masterem materiału rozdawniczego.

## **Ustaw stopkę, datę/godzinę i numery slajdów na zwykłych slajdach**

Dla zwykłych slajdów podstawowy przepływ pracy polega na uzyskaniu menedżera nagłówka/stopki każdego slajdu, ustawieniu tekstu stopki i daty/godziny, włączeniu wymaganych pól zastępczych i zapisaniu prezentacji. Numery slajdów są generowane przez prezentację, więc kontrolujesz jedynie ich widoczność.

Użyj [`setFooterText`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) i [`setDateTimeText`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseslideheaderfootomanager/#setDateTimeText-java.lang.String-) aby ustawić tekst, oraz użyj [`setFooterVisibility`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseslideheaderfootomanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseslideheaderfootomanager/#setDateTimeVisibility-boolean-), i [`setSlideNumberVisibility`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseslideheaderfootomanager/#setSlideNumberVisibility-boolean-) aby wyświetlić odpowiednie pola zastępcze.

Poniższy przykład końcowy stosuje taką samą stopkę, tekst daty/godziny i widoczność numeru slajdu dla wszystkich zwykłych slajdów:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli potrzebujesz zaktualizować tylko jeden slajd, uzyskaj ten slajd bezpośrednio przez metodę [`getSlides`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSlides--) zamiast iterować przez całą kolekcję.

## **Ustaw nagłówki i stopki w masterze notatek**

Master notatek definiuje wspólne formatowanie i zachowanie pól zastępczych dla stron notatek. Użyj interfejsu [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) gdy chcesz zmienić tylko sam master notatek.

Poniższy przykład ustawia tekst nagłówka, stopki i daty/godziny w masterze notatek i powoduje widoczność wszystkich obsługiwanych pól zastępczych w tym masterze:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoda [`getMasterNotesSlide`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) zwraca `null`, gdy prezentacja nie zawiera mastera notatek.

## **Zastosuj ustawienia mastera notatek do podrzędnych slajdów notatek**

Master notatek może zastosować ustawienia nagłówka i stopki zarówno do siebie, jak i do wszystkich zależnych slajdów notatek. Użyj dedykowanych metod propagacji na interfejsie [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) gdy te same ustawienia mają być zastosowane w całej hierarchii notatek.

Na przykład, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslideheaderfootomanager/#setHeaderAndChildHeadersText-java.lang.String-) i [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslideheaderfootomanager/#setHeaderAndChildHeadersVisibility-boolean-) aktualizują nagłówek mastera notatek oraz wszystkie nagłówki podrzędne. Dostępne są równoważne metody dla stopek, daty/godziny i numerów slajdów.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metody propagacji użyte powyżej to [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslideheaderfootomanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslideheaderfootomanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslideheaderfootomanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslideheaderfootomanager/#setDateTimeAndChildDateTimesVisibility-boolean-), oraz [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslideheaderfootomanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Ustaw nagłówki i stopki na pojedynczym slajdzie notatek**

Slajd notatek należy do konkretnego zwykłego slajdu. Użyj jego interfejsu [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/inotesslideheaderfootomanager/) gdy chcesz dostosować tylko tę stronę notatek.

Metoda [`addNotesSlide`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) zwraca slajd notatek dla bieżącego slajdu i tworzy go, jeśli jeszcze nie istnieje. Poniższy przykład konfiguruje stronę notatek powiązaną z pierwszym slajdem prezentacji:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli najpierw propagujesz ustawienia z mastera notatek, a potem zmieniasz pojedynczy slajd notatek, późniejsze ustawienia per‑slajd pozwalają dostosować tę stronę notatek niezależnie.

## **Ustaw nagłówki i stopki w masterze wersji drukowanej**

Strony wersji drukowanej używają mastera wersji drukowanej dla swoich pól zastępczych nagłówka, stopki, daty/godziny oraz numeru strony. W przeciwieństwie do stron notatek, ustawienia wersji drukowanej są zarządzane przez master wersji drukowanej, a nie przez poszczególne slajdy wersji drukowanej.

Użyj metody [`getMasterHandoutSlide`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) aby uzyskać dostęp do mastera wersji drukowanej. Jeśli nie jest on obecny, wywołaj [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) aby utworzyć domyślny master wersji drukowanej.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zrozum zakres i dziedziczenie**

Wybierz menedżera nagłówka/stopki, który odpowiada zakresowi, który chcesz zmienić:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideheaderfootermanager/) zmienia ustawienia stopki, daty/godziny i numeru slajdu dla jednego zwykłego slajdu.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) steruje slajdem układu i może propagować obsługiwane ustawienia do zależnych slajdów.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslideheaderfootomanager/) steruje regularnym masterem slajdów i może propagować obsługiwane ustawienia do zależnych slajdów.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasternotesslideheaderfootomanager/) steruje masterem notatek i może propagować ustawienia do wszystkich zależnych slajdów notatek.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/inotesslideheaderfootomanager/) zmienia jeden slajd notatek i obsługuje pole zastępcze nagłówka oprócz stopki, daty/godziny i numeru slajdu.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterhandoutslideheaderfootomanager/) zmienia master wersji drukowanej i obsługuje wszystkie cztery typy pól zastępczych.

Używaj propagacji z mastera lub układu, gdy to samo ustawienie ma obowiązywać w całej jego hierarchii. Używaj menedżera pojedynczego slajdu lub slajdu notatek, gdy potrzebujesz lokalnego ustawienia dla jednej strony.

## **FAQ**

**Czy mogę dodać nagłówek do zwykłego slajdu?**

Nie. PowerPoint nie definiuje pola zastępczego nagłówka dla zwykłych slajdów. Na zwykłych slajdach użyj pól zastępczych stopki, daty/godziny i numeru slajdu. Pola nagłówka są dostępne na stronach notatek i wersjach drukowanych.

**Co zrobić, gdy pole zastępcze stopki, daty/godziny lub numeru slajdu nie jest widoczne?**

Użyj odpowiedniego menedżera nagłówka/stopki, aby sprawdzić jego widoczność i w razie potrzeby ją włączyć. Na przykład metoda [`isFooterVisible`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseslideheaderfootomanager/#isFooterVisible--) informuje, czy pole stopki jest obecne, a [`setFooterVisibility`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseslideheaderfootomanager/#setFooterVisibility-boolean-) zmienia jego widoczność.

**Jak rozpocząć numerację slajdów od wartości innej niż 1?**

Wywołaj metodę [`setFirstSlideNumber`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) prezentacji. Pola zastępcze numeru slajdu użyją zaktualizowanej sekwencji numeracji.

**Co się dzieje z nagłówkami i stopkami podczas eksportu do PDF, obrazów lub HTML?**

Widoczne elementy nagłówka i stopki są renderowane wraz z resztą treści prezentacji w wyjściowym formacie. Ich wygląd zależy od typu eksportowanej strony oraz odpowiednich ustawień widoczności pól zastępczych.