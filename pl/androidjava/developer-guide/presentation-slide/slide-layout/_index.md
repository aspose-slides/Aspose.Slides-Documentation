---
title: Zastosuj lub zmień układy slajdów w Androidzie
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/androidjava/slide-layout/
keywords:
- układ slajdu
- układ zawartości
- pole zastępcze
- projekt prezentacji
- projekt slajdu
- nieużywany układ
- widoczność stopki
- slajd tytułowy
- tytuł i zawartość
- nagłówek sekcji
- dwie zawartości
- porównanie
- tylko tytuł
- pusty układ
- zawartość z podpisem
- obraz z podpisem
- tytuł i pionowy tekst
- pionowy tytuł i tekst
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides for Android przy użyciu Javy, dodawaj pola zastępcze, usuwaj nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu definiuje pozycje i formatowanie pól zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu zapewnia slajdom spójną strukturę, jednocześnie pozwalając każdemu slajdowi zawierać własną treść.

- **Slajd tytułowy**: Zawiera pola zastępcze tytułu i podtytułu.
- **Tytuł i zawartość**: Zawiera pole zastępcze tytułu oraz uniwersalne pole zawartości.
- **Pusty**: Nie zawiera pól zastępczych treści i jest przydatny, gdy każdy kształt będzie rozmieszczany ręcznie.

## **Zrozumienie dziedziczenia układów**

Prezentacja ma trzy powiązane poziomy:

1. A [master slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/) definiuje motyw, współdzielone formatowanie, tła i wspólne obiekty.
2. A [layout slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/) należy do mastera i definiuje określone rozmieszczenie pól zastępczych.
3. A [normal slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/) używa jednego układu i przechowuje wprowadzone dla niego treści.

Normalny slajd dziedziczy motyw i formatowanie z jego układu, a układ dziedziczy z mastera. Wartość ustawiona bezpośrednio na normalnym slajdzie zastępuje dziedziczoną wartość na tym poziomie. Gdy tworzony jest normalny slajd, jego kształty pól zastępczych są generowane na podstawie wybranego układu, natomiast treść wprowadzona do tych pól należy do normalnego slajdu.

Dodaj wymagane pola zastępcze do układu przed tworzeniem z niego slajdów. Dodanie kolejnego pola zastępczego do układu później nie powoduje automatycznego dodania odpowiadającego kształtu pola do istniejących normalnych slajdów.

Ta relacja ma dwa ważne konsekwencje:

- Zmiana dziedziczonego formatowania lub istniejącej geometrii pól zastępczych w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją układu już używanego, sprawdź jego zależne slajdy i przejrzyj powstałą prezentację.
- Układ, który jest nadal używany przez slajd, nie może być usunięty. Przypisz najpierw zależne od niego slajdy do innego układu lub usuń tylko nieużywane układy.

Więcej informacji o najwyższym poziomie tej hierarchii znajdziesz w [Mistrz slajdów](/slides/pl/androidjava/slide-master/).

Aby ukryć dziedziczone logotypy lub dekoracyjne kształty mastera na jednym slajdzie lub w ramach wspólnego układu, zobacz [Kontrola widoczności grafiki mastera](/slides/pl/androidjava/slide-master/). Przykład porównuje dwa slajdy korzystające z tego samego mastera.

## **Wybierz i zastosuj układ slajdu**

Używaj typu układu, gdy prezentacja korzysta ze standardowych definicji układów PowerPoint. Nazwy układów można edytować i mogą być lokalizowane, więc wybór oparty na nazwie jest mniej wiarygodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład szuka **Title and Content** w pierwszym masterze. Jeśli ten układ nie jest dostępny, celowo przechodzi do **Blank**. Drugi sprawdzanie null jest konieczne, ponieważ prezentacja może zawierać wyłącznie układy niestandardowe. Wybrany układ jest następnie zastosowany do pierwszego normalnego slajdu przy użyciu metody [ISlide.setLayoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

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

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje pól zastępczych, dziedziczone formatowanie oraz zgodność istniejących pól z nowym układem mogą ulec zmianie, dlatego należy sprawdzić wynik przy przełączaniu między znacznie różnymi układami.

## **Dodaj układ slajdu**

Wybór i tworzenie to osobne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) na kolekcji układów docelowego mastera.

Poniższy przykład zawsze dodaje nowy układ **Title and Content** o nazwie `Report Title and Content`, a następnie dodaje normalny slajd oparty na nim. Nazwy układów muszą być unikalne w obrębie kolekcji.

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

Dodawaj układ tylko wtedy, gdy szablon naprawdę potrzebuje kolejnej wielokrotnego użycia struktury. Jeśli odpowiedni układ już istnieje, wybierz i użyj go ponownie zamiast tworzyć duplikat.

## **Dodaj pola zastępcze do układu slajdu**

Metoda [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) udostępnia [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) do dodawania kształtów pól zastępczych do układu.

| Pole zastępcze PowerPoint | Metoda `ILayoutPlaceholderManager` |
| -------------------------- | ----------------------------------- |
| ![Zawartość](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Zawartość (pionowa)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Tekst](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Tekst (pionowy)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Obraz](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Wykres](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabela](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Obraz online](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Poniższy przykład weryfikuje, czy układ **Blank** istnieje, dodaje do niego cztery pola zastępcze, a następnie tworzy normalny slajd używający zmodyfikowanego układu. Kolejność jest zamierzona: pola są dodawane przed utworzeniem normalnego slajdu, aby Aspose.Slides mógł wygenerować odpowiadające im kształty pól na tym slajdzie.

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

![Pola zastępcze na slajdzie układu](add_placeholders.png)

{{% alert color="warning" title="Ostrzeżenie" %}}
Zmiana dziedziczonego formatowania lub geometrii istniejących pól zastępczych układu może wpływać na zależne slajdy. Nowo dodane pole zastępcze układu nie jest automatycznie wstawiane do istniejących normalnych slajdów. Testuj zmiany układu na kopii prezentacji i sprawdzaj każdy zależny slajd.
{{% /alert %}}

## **Usuń nieużywane układy slajdów**

Użyj metody [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) aby usunąć układy, do których nie odnosi się żaden normalny slajd. Metoda pozostawia nienaruszone układy wciąż używane.

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

Aby usunąć konkretny układ, najpierw użyj jego metody [hasDependingSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) lub [getDependingSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--). Przypisz ponownie wszystkie zależne slajdy przed wywołaniem [ILayoutSlide.remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#remove--). Próba usunięcia używanego układu powoduje wyrzucenie [PptxEditException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxeditexception/).

## **Kontrola widoczności stopki w układzie slajdu**

Układ posiada własne pola zastępcze stopki, numeru slajdu i daty‑czasu. Użyj metody [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) aby kontrolować te pola dla jednego układu. Jest to przydatne, gdy na przykład układy zawartości mają wyświetlać stopki, a układy tytułowe nie powinny.

Poniższy przykład bezpiecznie wybiera układ i ustawia widoczność jego elementów stopki:

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

## **Kontrola widoczności stopki w masterze i jego układach podrzędnych**

Aby zastosować spójne ustawienia stopki w całej hierarchii mastera, użyj metody [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Metody propagacji z [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) działają na masterze oraz jego zależnych układach slajdów i normalnych slajdach; nie dotyczą pojedynczego normalnego slajdu.

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

Master slajd definiuje temat prezentacji i współdzielone formatowanie. Układ slajdu należy do mastera i określa jedno wielokrotnego użycia rozmieszczenie pól zastępczych. Normalne slajdy używają tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji metodą [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Przy kopiowaniu między prezentacjami, sprawdź również czcionki, motywy, obrazy i inne zasoby używane przez źródłowy układ.

**Co się dzieje, gdy modyfikuję układ już używany?**

Zależne slajdy dziedziczą zmiany układu, chyba że lokalnie nadpiszą dotknięte formatowanie lub obiekty. Geometria pól zastępczych i dziedziczone style mogą więc zmienić się jednocześnie na wielu slajdach. Użyj [getDependingSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides zgłasza [PptxEditException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxeditexception/). Najpierw przypisz ponownie zależne slajdy lub użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) aby usunąć tylko nieodwołane układy.