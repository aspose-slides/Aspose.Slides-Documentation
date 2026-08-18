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
- materiały rozdawnicze
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać placeholderami stopki, daty i czasu, numeru slajdu oraz nagłówka na slajdach, stronach notatek i materiałach rozdawniczych przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

PowerPoint używa różnych symboli nagłówka i stopki w zależności od typu strony. Aspose.Slides for Java pozwala kontrolować tekst i widoczność tych symboli za pomocą interfejsów menedżera nagłówka/stopki.

Dostępne symbole zależą od zakresu:

| Zakres | Nagłówek | Stopka | Data/czas | Numer slajdu/strony |
|---|---|---|---|---|
| Zwykły slajd | Nie | Tak | Tak | Tak |
| Mistrz notatek | Tak | Tak | Tak | Tak |
| Slajd notatek | Tak | Tak | Tak | Tak |
| Mistrz wersji rozdawniczej | Tak | Tak | Tak | Tak |

Zwykły slajd prezentacji nie ma symbolu nagłówka. Nagłówki są dostępne na stronach notatek i materiałach rozdawniczych. Dla zwykłych slajdów używaj symboli stopki, daty/czasu i numeru slajdu.

Zakres zmiany zależy od używanego menedżera. Interfejs [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islideheaderfootermanager/) kontroluje jeden zwykły slajd. Interfejs [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/inotesslideheaderfootermanager/) kontroluje jeden slajd notatek. Menedżerowie master i układu mogą także propagować ustawienia do zależnych slajdów, natomiast interfejs [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) kontroluje mistrza wersji rozdawniczej.

## **Ustaw Stopkę, Datę/Czas i Numery Slajdów na Zwykłych Slajdach**

Dla zwykłych slajdów podstawowy przepływ pracy polega na uzyskaniu menedżera nagłówka/stopki każdego slajdu, ustawieniu tekstu stopki i daty/czasu, włączeniu potrzebnych symboli oraz zapisaniu prezentacji. Numery slajdów są generowane przez prezentację, więc wystarczy kontrolować ich widoczność.

Użyj [`setFooterText`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) i [`setDateTimeText`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) do ustawiania tekstu oraz [`setFooterVisibility`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), i [`setSlideNumberVisibility`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) aby pokazać odpowiednie symbole.

Poniższy kompletny przykład stosuje tę samą stopkę, tekst daty/czasu oraz widoczność numeru slajdu we wszystkich zwykłych slajdach:

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

Jeśli musisz zaktualizować tylko jeden slajd, uzyskaj ten slajd bezpośrednio za pomocą metody [`getSlides`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSlides--) zamiast iterować po całej kolekcji.

## **Ustaw Nagłówki i Stopki w Mistrzu Notatek**

Mistrz notatek definiuje wspólne formatowanie i zachowanie symboli dla stron notatek. Użyj interfejsu [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslideheaderfootermanager/) kiedy chcesz zmienić tylko sam mistrz notatek.

Poniższy przykład ustawia nagłówek, stopkę i tekst daty/czasu w mistrzu notatek oraz sprawia, że wszystkie obsługiwane symbole są widoczne w tym mistrzu:

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

Metoda [`getMasterNotesSlide`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) zwraca `null`, gdy prezentacja nie zawiera mistrza notatek.

## **Zastosuj Ustawienia Mistrza Notatek do Dziecięcych Slajdów Notatek**

Mistrz notatek może zastosować ustawienia nagłówka i stopki zarówno do siebie, jak i do wszystkich zależnych slajdów notatek. Użyj dedykowanych metod propagacji na interfejsie [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslideheaderfootermanager/) gdy te same ustawienia mają być zastosowane w całej hierarchii notatek.

Na przykład, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) i [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) aktualizują nagłówek mistrza notatek oraz wszystkie nagłówki podrzędne. Dostępne są odpowiednie metody dla stopek, daty/czasu i numerów slajdów.

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

Metody propagacji użyte powyżej to [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), oraz [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Ustaw Nagłówki i Stopki na Indywidualnym Slajdzie Notatek**

Slajd notatek należy do konkretnego zwykłego slajdu. Użyj jego interfejsu [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/inotesslideheaderfootermanager/) kiedy chcesz dostosować tylko tę stronę notatek.

Metoda [`addNotesSlide`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) zwraca slajd notatek dla bieżącego slajdu i tworzy go, jeśli jeszcze nie istnieje. Poniższy przykład konfiguruje stronę notatek powiązaną z pierwszym slajdem prezentacji:

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

Jeśli najpierw propagujesz ustawienia z mistrza notatek, a potem zmieniasz indywidualny slajd notatek, późniejsze ustawienia per‑slajd pozwalają niezależnie dostosować tę stronę notatek.

## **Ustaw Nagłówki i Stopki w Mistrzu Materiałów Rozdawniczych**

Strony materiałów rozdawniczych używają mistrza wersji rozdawniczej dla swoich symboli nagłówka, stopki, daty/czasu i numeru strony. W przeciwieństwie do stron notatek, ustawienia materiałów rozdawniczych są zarządzane przez mistrza wersji rozdawniczej, a nie przez poszczególne slajdy rozdawnicze.

Użyj metody [`getMasterHandoutSlide`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) aby uzyskać dostęp do mistrza wersji rozdawniczej. Jeśli go nie ma, wywołaj [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) aby utworzyć domyślny mistrz wersji rozdawniczej.

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

## **Zrozum Zakres i Dziedziczenie**

Wybierz menedżera nagłówka/stopki, który odpowiada zakresowi, który chcesz zmienić:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islideheaderfootermanager/) zmienia ustawienia stopki, daty/czasu i numeru slajdu dla jednego zwykłego slajdu.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslideheaderfootermanager/) steruje slajdem układu i może propagować obsługiwane ustawienia do zależnych slajdów.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslideheaderfootermanager/) steruje zwykłym masterem slajdu i może propagować obsługiwane ustawienia do zależnych slajdów.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasternotesslideheaderfootermanager/) steruje mistrzem notatek i może propagować ustawienia do wszystkich zależnych slajdów notatek.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/inotesslideheaderfootermanager/) zmienia jeden slajd notatek i obsługuje placeholder nagłówka oprócz stopki, daty/czasu i numeru slajdu.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) zmienia mistrza wersji rozdawniczej i obsługuje wszystkie cztery typy placeholderów.

Używaj propagacji z mastera lub układu, gdy to samo ustawienie ma obowiązywać w całej hierarchii. Używaj menedżera indywidualnego slajdu lub slajdu notatek, gdy potrzebne jest lokalne ustawienie dla jednej strony.

## **FAQ**

**Czy mogę dodać nagłówek do zwykłego slajdu?**

Nie. PowerPoint nie definiuje placeholdera nagłówka dla zwykłych slajdów. Na zwykłych slajdach używaj placeholderów stopki, daty/czasu i numeru slajdu. Placeholdery nagłówka są dostępne na stronach notatek i materiałach rozdawniczych.

**Co zrobić, jeśli placeholder stopki, daty/czasu lub numeru slajdu nie jest widoczny?**

Użyj odpowiedniego menedżera nagłówka/stopki, aby sprawdzić jego widoczność i w razie potrzeby ją włączyć. Na przykład, metoda [`isFooterVisible`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) informuje, czy placeholder stopki jest obecny, a [`setFooterVisibility`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) zmienia jego widoczność.

**Jak rozpocząć numerację slajdów od wartości innej niż 1?**

Wywołaj metodę prezentacji [`setFirstSlideNumber`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-). Placeholdery numeru slajdu użyją zaktualizowanej sekwencji numeracji.

**Co się dzieje z nagłówkami i stopkami podczas eksportu do PDF, obrazów lub HTML?**

Widoczne elementy nagłówka i stopki są renderowane wraz z resztą zawartości prezentacji w wyjściowym formacie. Ich wygląd zależy od typu eksportowanej strony i odpowiadających ustawień widoczności placeholderów.