---
title: Zastosuj lub zmień układy slajdów na Androidzie
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/androidjava/slide-layout/
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
- dwa zestawy treści
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
- Android
- Java
- Aspose.Slides
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides dla Androida przy użyciu Javy, dodawaj elementy zastępcze, usuwaj nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu definiuje pozycje i formatowanie elementów zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu zapewnia slajdom spójną strukturę, jednocześnie pozwalając każdemu slajdowi zawierać własną treść.

Najczęściej używane układy to:

- **Slajd tytułowy**: Zawiera elementy zastępcze tytułu i podtytułu.
- **Tytuł i treść**: Zawiera element zastępczy tytułu oraz ogólnego przeznaczenia element zastępczy treści.
- **Pusty**: Nie zawiera elementów zastępczych i jest przydatny, gdy wszystkie kształty będą rozmieszczane ręcznie.

## **Zrozumienie dziedziczenia układów**

Prezentacja ma trzy powiązane poziomy:

1. [master slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/) definiuje motyw, wspólne formatowanie, tła i wspólne obiekty.
1. [layout slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/) należy do mastera i definiuje konkretny układ elementów zastępczych.
1. [normal slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/) używa jednego układu i przechowuje treść wprowadzoną dla tego slajdu.

Normalny slajd dziedziczy motyw i formatowanie z jego układu, a układ dziedziczy z mastera. Wartość ustawiona bezpośrednio na normalnym slajdzie nadpisuje dziedziczoną wartość na tym poziomie. Gdy tworzony jest normalny slajd, jego kształty elementów zastępczych są generowane na podstawie wybranego układu, natomiast wprowadzona do nich treść należy do normalnego slajdu.

Dodaj wymagane elementy zastępcze do układu przed tworzeniem z niego slajdów. Dodanie kolejnego elementu zastępczego do układu później nie dodaje automatycznie odpowiadającego kształtu elementu zastępczego do istniejących normalnych slajdów.

Ta zależność ma dwa istotne konsekwencje:

- Zmiana dziedziczonego formatowania lub istniejącej geometrii elementu zastępczego w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją układu już używanego, sprawdź jego zależne slajdy i przejrzyj wynikową prezentację.
- Układ, który jest nadal używany przez slajd, nie może być usunięty. Przed usunięciem przypisz jego zależne slajdy do innego układu lub usuń tylko nieużywane układy.

Więcej informacji o najwyższym poziomie tej hierarchii znajdziesz w [Slide Master](/slides/pl/androidjava/slide-master/).

## **Wybór i zastosowanie układu slajdu**

Używaj typu układu, gdy prezentacja podąża za standardowymi definicjami układów PowerPoint. Nazwy układów są edytowalne przez użytkownika i mogą być lokalizowane, więc wybór oparty na nazwie jest mniej niezawodny, o ile nie kontrolujesz szablonu źródłowego.

Poniższy przykład wyszukuje **Title and Content** w pierwszym masterze. Jeśli ten układ jest niedostępny, celowo przechodzi do **Blank**. Drugi test na null jest konieczny, ponieważ prezentacja może zawierać jedynie niestandardowe układy. Wybrany układ jest następnie stosowany do pierwszego normalnego slajdu za pomocą metody [ISlide.setLayoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

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

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje elementów zastępczych, dziedziczone formatowanie i zgodność istniejących elementów zastępczych z nowym układem mogą się zmienić, więc sprawdź wynik przy przełączaniu między znacząco różnymi układami.

## **Dodawanie układu slajdu**

Wybór i tworzenie to oddzielne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) na kolekcji układów docelowego mastera.

Poniższy przykład zawsze dodaje nowy układ **Title and Content** o nazwie `Report Title and Content`, a następnie dodaje na jego podstawie normalny slajd. Nazwy układów muszą być unikalne w obrębie kolekcji.

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

Dodawaj układ tylko wtedy, gdy szablon naprawdę potrzebuje kolejnej struktury wielokrotnego użytku. Jeśli odpowiedni układ już istnieje, wybierz i użyj go ponownie zamiast tworzyć duplikat.

## **Dodawanie elementów zastępczych do układu slajdu**

Metoda [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) udostępnia [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) do dodawania kształtów elementów zastępczych do układu.

| PowerPoint Placeholder              | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Content](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Poniższy przykład weryfikuje, że układ **Blank** istnieje, dodaje do niego cztery elementy zastępcze, a następnie tworzy normalny slajd wykorzystujący zmodyfikowany układ. Kolejność jest zamierzona: elementy zastępcze są dodawane przed utworzeniem normalnego slajdu, aby Aspose.Slides mógł wygenerować odpowiadające im kształty elementów zastępczych na tym slajdzie.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Zmiana dziedziczonego formatowania lub geometrii istniejących elementów zastępczych w układzie może wpłynąć na zależne slajdy. Nowo dodany element zastępczy układu nie jest automatycznie uzupełniany w istniejących normalnych slajdach. Testuj zmiany układu na kopii prezentacji i sprawdzaj każdy zależny slajd.
{{% /alert %}}

## **Usuwanie nieużywanych układów slajdu**

Użyj metody [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) aby usunąć układy, do których nie odnosi się żaden normalny slajd. Metoda pozostawia nietknięte układy, które są nadal używane.

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

Aby usunąć konkretny układ, najpierw użyj jego metody [hasDependingSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) lub [getDependingSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--). Przypisz wszystkie zależne slajdy przed wywołaniem [ILayoutSlide.remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#remove--). Próba usunięcia używanego układu generuje [PptxEditException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxeditexception/).

## **Kontrola widoczności stopki w układzie slajdu**

Układ ma własne elementy zastępcze stopki, numeru slajdu i daty‑czasu. Użyj metody [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) aby kontrolować te elementy w jednym układzie. Jest to przydatne, gdy na przykład układy treści powinny wyświetlać stopki, a układy tytułowe nie.

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

Aby zastosować spójne ustawienia stopki w całej hierarchii mastera, użyj metody [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) . Metody propagacji [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) działają na masterze oraz jego zależnych układach slajdu i normalnych slajdach; nie dotyczą pojedynczego normalnego slajdu.

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

**Jaka jest różnica między masterem a układem slajdu?**

Master slajd definiuje motyw prezentacji i wspólne formatowanie. Układ slajdu należy do mastera i definiuje jedną wielokrotnego użytku konfigurację elementów zastępczych. Normalne slajdy używają tych układów i przechowują zawartość specyficzną dla slajdu.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji metodą [addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) . Przy kopiowaniu między prezentacjami sprawdź także czcionki, motywy, obrazy i inne zasoby używane przez źródłowy układ.

**Co się stanie, gdy zmodyfikuję układ, który jest już używany?**

Zależne slajdy dziedziczą zmiany układu, o ile nie nadpiszą dotkniętego formatowania lub obiektów lokalnie. Geometria elementów zastępczych i dziedziczone style mogą więc zmienić się jednocześnie na wielu slajdach. Użyj [getDependingSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides zgłasza [PptxEditException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxeditexception/). Przypisz najpierw zależne slajdy lub użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) aby usunąć tylko nieodwoływane układy.