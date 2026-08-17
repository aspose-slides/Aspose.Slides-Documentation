---
title: Zastosuj lub zmień układy slajdów w Javie
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/java/slide-layout/
keywords:
- układ slajdu
- układ treści
- element zastępczy
- projekt prezentacji
- projekt slajdu
- nieużywany układ
- widoczność stopki
- slajd tytułowy
- tytuł i treść
- nagłówek sekcji
- dwa elementy treści
- porównanie
- tylko tytuł
- pusty układ
- treść z podpisem
- obraz z podpisem
- tytuł i pionowy tekst
- pionowy tytuł i tekst
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides for Java, dodawaj elementy zastępcze, usuwaj nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu określa pozycje i formatowanie elementów zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu zapewnia slajdom spójną strukturę, jednocześnie pozwalając każdemu slajdowi zawierać własną treść.

Najczęstsze układy to:

- **Slajd tytułowy**: Zawiera elementy zastępcze tytułu i podtytułu.
- **Title and Content**: Zawiera element zastępczy tytułu oraz ogólnego przeznaczenia element zastępczy treści.
- **Blank**: Nie zawiera elementów zastępczych treści i jest przydatny, gdy każdy kształt będzie pozycjonowany ręcznie.

## **Zrozumienie dziedziczenia układu**

Prezentacja posiada trzy powiązane poziomy:

1. A [master slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslide/) definiuje motyw, wspólne formatowanie, tła i obiekty wspólne.
2. A [layout slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/) należy do mastera i określa określoną organizację elementów zastępczych.
3. A [normal slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/) używa jednego układu i przechowuje wprowadzoną treść dla tego slajdu.

Normalny slajd dziedziczy motyw i formatowanie z jego układu, a układ dziedziczy z jego mastera. Wartość ustawiona bezpośrednio na normalnym slajdzie zastępuje wartość dziedziczoną na tym poziomie. Gdy tworzony jest normalny slajd, jego kształty elementów zastępczych są generowane na podstawie wybranego układu, natomiast treść wprowadzona w tych elementach należy do normalnego slajdu.

Dodaj wymagane elementy zastępcze do układu przed tworzeniem z niego slajdów. Dodanie kolejnego elementu zastępczego do układu później nie powoduje automatycznego dodania odpowiadającego kształtu elementu zastępczego do istniejących normalnych slajdów.

Ta zależność ma dwa ważne konsekwencje:

- Zmiana dziedziczonego formatowania lub istniejącej geometrii elementów zastępczych w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją układu, który jest już używany, sprawdź jego zależne slajdy i przejrzyj wynikową prezentację.
- Układ, który jest nadal używany przez slajd, nie może zostać usunięty. Przypisz najpierw jego zależne slajdy do innego układu albo usuń tylko nieużywane układy.

Aby uzyskać więcej informacji o najwyższym poziomie tej hierarchii, zobacz [Slide Master](/slides/pl/java/slide-master/).

## **Wybierz i zastosuj układ slajdu**

Używaj typu układu, gdy prezentacja podąża za standardowymi definicjami układów PowerPoint. Nazwy układów są edytowalne przez użytkownika i mogą być lokalizowane, więc wybór oparty na nazwie jest mniej niezawodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład wyszukuje **Title and Content** w pierwszym masterze. Jeśli ten układ jest niedostępny, celowo przechodzi do **Blank**. Drugi sprawdzanie pod kątem null jest potrzebne, ponieważ prezentacja może zawierać wyłącznie układy niestandardowe. Wybrany układ jest następnie zastosowany do pierwszego normalnego slajdu poprzez metodę [ISlide.setLayoutSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje elementów zastępczych, dziedziczone formatowanie oraz zgodność istniejących elementów zastępczych z nowym układem mogą ulec zmianie, więc sprawdzaj wynik przy przełączaniu między znacznie różnymi układami.

## **Dodaj układ slajdu**

Wybór i tworzenie to odrębne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) na kolekcji układów docelowego mastera.

Poniższy przykład zawsze dodaje nowy **Title and Content** układ o nazwie `Report Title and Content`, a następnie dodaje normalny slajd oparty na nim. Nazwy układów muszą być unikalne w ramach kolekcji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dodaj układ tylko wtedy, gdy szablon naprawdę potrzebuje kolejnej struktury wielokrotnego użytku. Jeśli odpowiedni układ już istnieje, wybierz i użyj go ponownie zamiast tworzyć duplikat.

## **Dodaj elementy zastępcze do układu slajdu**

Metoda [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) zapewnia [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/) do dodawania kształtów elementów zastępczych do układu.

| Element zastępczy PowerPoint      | `ILayoutPlaceholderManager` Method |
| --------------------------------- | ---------------------------------- |
| ![Content](content.png)           | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png)                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png)     | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png)           | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png)               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png)               | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png)               | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png)  | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Poniższy przykład weryfikuje, że układ **Blank** istnieje, dodaje do niego cztery elementy zastępcze, a następnie tworzy normalny slajd korzystający z zmodyfikowanego układu. Kolejność jest zamierzona: elementy zastępcze są dodawane przed utworzeniem normalnego slajdu, dzięki czemu Aspose.Slides może wygenerować odpowiadające kształty elementów zastępczych na tym slajdzie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Elementy zastępcze na slajdzie układu](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Zmiana dziedziczonego formatowania lub geometrii istniejących elementów zastępczych w układzie może wpłynąć na zależne slajdy. Nowo dodany element zastępczy układu nie jest automatycznie wstawiany do istniejących normalnych slajdów. Testuj zmiany układu na kopii prezentacji i sprawdzaj każdy zależny slajd.
{{% /alert %}}

## **Usuń nieużywane układy slajdów**

Użyj metody [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) aby usunąć układy, do których nie odwołuje się żaden normalny slajd. Metoda pozostawia nienaruszone układy, które są nadal używane.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby usunąć konkretny układ, najpierw użyj jego metody [hasDependingSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) lub [getDependingSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/#getDependingSlides--). Przypisz wszystkie zależne slajdy przed wywołaniem [ILayoutSlide.remove](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/#remove--). Próba usunięcia używanego układu generuje [PptxEditException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxeditexception/).

## **Kontroluj widoczność stopki w układzie slajdu**

Układ ma własne elementy zastępcze stopki, numeru slajdu i daty‑czasu. Użyj metody [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) aby kontrolować te elementy w jednym układzie. Jest to przydatne, gdy na przykład układy treści powinny wyświetlać stopki, a układy tytułowe nie.

Poniższy przykład wybiera układ w bezpieczny sposób i ustawia elementy stopki jako widoczne:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontroluj widoczność stopki w masterze i jego podrzędnych układach**

Aby zastosować spójne ustawienia stopki w całej hierarchii mastera, użyj metody [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Metody propagacji [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imasterslideheaderfootermanager/) działają na masterze oraz jego zależnych układach i normalnych slajdach; nie dotyczą pojedynczego normalnego slajdu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jaka jest różnica między master slajdem a układem slajdu?**

Master slajd definiuje motyw prezentacji i wspólne formatowanie. Układ slajdu należy do mastera i określa jedną wielokrotnego użytku organizację elementów zastępczych. Normalne slajdy używają tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji za pomocą metody [addClone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Przy kopiowaniu między prezentacjami sprawdź także czcionki, motywy, obrazy i inne zasoby użyte w źródłowym układzie.

**Co się stanie, gdy zmodyfikuję układ, który jest już używany?**

Zależne slajdy dziedziczą zmiany układu, chyba że lokalnie nadpiszą dotknięte formatowanie lub obiekty. Geometria elementów zastępczych oraz dziedziczone style mogą więc zmienić się jednocześnie na wielu slajdach. Użyj [getDependingSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides zgłasza [PptxEditException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxeditexception/). Najpierw przypisz zależne slajdy do innego układu lub użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) aby usunąć tylko nieodwołane układy.