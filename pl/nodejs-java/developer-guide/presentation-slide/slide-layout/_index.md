---
title: Zastosowanie lub zmiana układów slajdów w JavaScript
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/nodejs-java/slide-layout/
keywords:
- układ slajdu
- układ treści
- element zastępczy
- projektowanie prezentacji
- projektowanie slajdów
- nieużywany układ
- widoczność stopki
- slajd tytułowy
- tytuł i treść
- nagłówek sekcji
- dwa pola treści
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Zastosuj, utwórz i modyfikuj układy slajdów w Aspose.Slides dla Node.js przy użyciu Java, dodaj elementy zastępcze, usuń nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu określa pozycje i formatowanie elementów zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu zapewnia slajdom spójną strukturę, jednocześnie pozwalając każdemu slajdowi zawierać własną treść.

Najczęściej używane układy obejmują:

- **Title Slide**: Zawiera elementy zastępcze tytułu i podtytułu.
- **Title and Content**: Zawiera element zastępczy tytułu oraz ogólnego przeznaczenia element zastępczy treści.
- **Blank**: Nie zawiera elementów zastępczych treści i jest przydatny, gdy każdy kształt będzie pozycjonowany ręcznie.

## **Zrozumienie dziedziczenia układów**

Prezentacja ma trzy powiązane poziomy:

1. A [slajd master](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/) definiuje motyw, wspólne formatowanie, tła i wspólne obiekty.
2. A [slajd układu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/) należy do slajdu master i definiuje określone rozmieszczenie elementów zastępczych.
3. A [normalny slajd](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/) używa jednego układu i przechowuje wprowadzoną dla niego treść.

Normalny slajd dziedziczy motyw i formatowanie z jego układu, a układ dziedziczy z mastera. Wartość ustawiona bezpośrednio na normalnym slajdzie nadpisuje dziedziczoną wartość na tym poziomie. Gdy tworzony jest normalny slajd, jego elementy zastępcze są generowane na podstawie wybranego układu, podczas gdy wprowadzona do nich treść należy do normalnego slajdu.

Dodaj wymagane elementy zastępcze do układu przed tworzeniem z niego slajdów. Dodanie kolejnego elementu zastępczego do układu później nie powoduje automatycznego dodania odpowiadającego kształtu elementu zastępczego do istniejących normalnych slajdów.

Ten związek ma dwa ważne konsekwencje:

- Zmiana dziedziczonego formatowania lub istniejącej geometrii elementu zastępczego w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją układu już używanego, sprawdź jego zależne slajdy i przejrzyj wynikową prezentację.
- Układ, który jest nadal używany przez slajd, nie może być usunięty. Najpierw przypisz jego zależne slajdy do innego układu, albo usuń wyłącznie nieużywane układy.

Aby uzyskać więcej informacji o najwyższym poziomie tej hierarchii, zobacz [Master slajdu](/slides/pl/nodejs-java/slide-master/).

Aby ukryć dziedziczone loga lub dekoracyjne kształty mastera na jednym slajdzie lub poprzez współdzielony układ, zobacz [Kontrola widoczności grafiki mastera](/slides/pl/nodejs-java/slide-master/). Przykład porównuje dwa slajdy używające tego samego mastera.

## **Wybierz i zastosuj układ slajdu**

Użyj wartości [SlideLayoutType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidelayouttype/), gdy prezentacja stosuje standardowe definicje układów PowerPoint. Nazwy układów są edytowalne przez użytkownika i mogą być lokalizowane, więc wybór oparty na nazwie jest mniej niezawodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład wyszukuje **Title and Content** w pierwszym masterze. Jeśli ten układ jest niedostępny, celowo przechodzi do **Blank**. Drugi test na null jest konieczny, ponieważ prezentacja może zawierać wyłącznie niestandardowe układy. Wybrany układ jest następnie stosowany do pierwszego normalnego slajdu za pomocą metody [Slide.setLayoutSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#setLayoutSlide).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje elementów zastępczych, dziedziczone formatowanie oraz zgodność istniejących elementów zastępczych z nowym układem mogą ulec zmianie, dlatego należy sprawdzić wynik przy przełączaniu między znacznie różnymi układami.

## **Dodaj slajd układu**

Wybór i tworzenie to odrębne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) na kolekcji układów docelowego mastera.

Poniższy przykład zawsze dodaje nowy układ **Title and Content** o nazwie `Report Title and Content`, a następnie dodaje normalny slajd oparty na nim. Nazwy układów muszą być unikalne w ramach kolekcji.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dodaj układ tylko wtedy, gdy szablon rzeczywiście potrzebuje kolejnej struktury wielokrotnego użytku. Jeśli odpowiedni układ już istnieje, wybierz go i użyj ponownie zamiast tworzyć duplikat.

## **Dodaj elementy zastępcze do slajdu układu**

Metoda [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) udostępnia [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/) do dodawania kształtów elementów zastępczych do układu.

| Element zastępczy PowerPoint | Metoda LayoutPlaceholderManager |
| ---------------------------- | -------------------------------- |
| ![Zawartość](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Zawartość (pionowa)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Tekst](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Tekst (pionowy)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Obraz](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Wykres](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabela](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Obraz online](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Poniższy przykład weryfikuje, że układ **Blank** istnieje, dodaje do niego cztery elementy zastępcze, a następnie tworzy normalny slajd korzystający z zmodyfikowanego układu. Kolejność jest zamierzona: elementy zastępcze są dodawane przed utworzeniem normalnego slajdu, aby Aspose.Slides mógł wygenerować odpowiadające kształty elementów zastępczych na tym slajdzie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Elementy zastępcze na slajdzie układu](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Zmiana dziedziczonego formatowania lub geometrii istniejących elementów zastępczych układu może wpływać na slajdy zależne. Nowo dodany element zastępczy układu nie jest automatycznie wstawiany do istniejących normalnych slajdów. Testuj zmiany układu na kopii prezentacji i sprawdź każdy zależny slajd.
{{% /alert %}}

## **Usuń nieużywane slajdy układu**

Użyj metody [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), aby usunąć układy, do których nie odnosi się żaden normalny slajd. Metoda pozostawia nienaruszone układy, które są nadal używane.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby usunąć konkretny układ, najpierw użyj jego metody [hasDependingSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) lub [getDependingSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Przypisz ponownie wszystkie zależne slajdy przed wywołaniem [LayoutSlide.remove](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#remove). Próba usunięcia używanego układu powoduje wystąpienie [PptxEditException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxeditexception/).

## **Kontroluj widoczność stopki w slajdzie układu**

Układ posiada własne elementy zastępcze stopki, numeru slajdu i daty-czasu. Użyj metody [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager), aby kontrolować te elementy zastępcze dla jednego układu. Jest to przydatne, gdy na przykład układy treści powinny wyświetlać stopki, a układy tytułów nie powinny.

Poniższy przykład bezpiecznie wybiera układ i udostępnia jego elementy stopki:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontroluj widoczność stopki w masterze i jego podrzędnych układach**

Aby zastosować spójne ustawienia stopki w całej hierarchii mastera, użyj metody [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Metody propagacji [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslideheaderfootermanager/) działają na masterze oraz jego zależnych slajdach układu i normalnych slajdach; nie celują w pojedynczy normalny slajd.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jaka jest różnica między slajdem master a slajdem układu?**

Slajd master definiuje motyw prezentacji i wspólne formatowanie. Slajd układu należy do mastera i określa jedno wielokrotnego użytku rozmieszczenie elementów zastępczych. Normalne slajdy używają tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować slajd układu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji przy użyciu metody [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Przy kopiowaniu między prezentacjami, sprawdź także czcionki, motywy, obrazy i inne zasoby używane przez źródłowy układ.

**Co się dzieje, gdy modyfikuję układ, który jest już używany?**

Slajdy zależne dziedziczą zmiany układu, chyba że lokalnie nadpisują dotknięte formatowanie lub obiekty. Geometria elementów zastępczych i dziedziczone style mogą więc zmienić się na wielu slajdach jednocześnie. Użyj [getDependingSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#getDependingSlides), aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides zgłasza [PptxEditException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxeditexception/). Najpierw przypisz ponownie zależne slajdy lub użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), aby usunąć tylko nieodwołane układy.