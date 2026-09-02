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
- projektowanie slajdu
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides dla Node.js za pomocą Javy, dodawaj elementy zastępcze, usuwaj nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu określa pozycje i formatowanie elementów zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu zapewnia spójną strukturę slajdów, jednocześnie pozwalając każdemu slajdowi zawierać własną treść.

Najczęściej używane układy to:

- **Slajd tytułowy**: Zawiera elementy zastępcze tytułu i podtytułu.
- **Tytuł i treść**: Zawiera element zastępczy tytułu oraz ogólny element zastępczy treści.
- **Pusty**: Nie zawiera elementów zastępczych i jest przydatny, gdy wszystkie kształty będą rozmieszczane ręcznie.

## **Zrozumienie dziedziczenia układów**

Prezentacja ma trzy powiązane poziomy:

1. [Główny slajd](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/) definiuje motyw, wspólne formatowanie, tła i wspólne obiekty.  
2. [Układ slajdu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/) należy do głównego slajdu i określa konkretny układ elementów zastępczych.  
3. [Normalny slajd](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/) używa jednego układu i przechowuje wprowadzoną dla niego treść.

Normalny slajd dziedziczy motyw i formatowanie z układu, a układ dziedziczy z głównego slajdu. Wartość ustawiona bezpośrednio na normalnym slajdzie zastępuje dziedziczoną wartość na tym poziomie. Podczas tworzenia normalnego slajdu kształty elementów zastępczych są generowane na podstawie wybranego układu, a treść wprowadzona do tych elementów należy do normalnego slajdu.

Dodaj wymagane elementy zastępcze do układu przed tworzeniem z niego slajdów. Dodanie kolejnego elementu zastępczego do układu później nie spowoduje automatycznego dodania odpowiadającego kształtu elementu zastępczego do istniejących normalnych slajdów.

Relacja ta ma dwa ważne konsekwencje:

- Zmiana dziedziczonego formatowania lub istniejącej geometrii elementu zastępczego w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją układu, który jest już używany, sprawdź jego zależne slajdy i przejrzyj wynikową prezentację.  
- Układ, który jest nadal używany przez slajd, nie może zostać usunięty. Przypisz najpierw jego zależne slajdy do innego układu lub usuń tylko nieużywane układy.

Aby uzyskać więcej informacji o najwyższym poziomie tej hierarchii, zobacz [Slide Master](/slides/pl/nodejs-java/slide-master/).

## **Wybór i zastosowanie układu slajdu**

Użyj wartości [SlideLayoutType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidelayouttype/), gdy prezentacja korzysta ze standardowych definicji układów PowerPoint. Nazwy układów można edytować i lokalizować, więc wybór oparty na nazwie jest mniej niezawodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład wyszukuje **Title and Content** w pierwszym głównym slajdzie. Jeśli ten układ nie jest dostępny, celowo przechodzi do **Blank**. Drugi warunek null jest potrzebny, ponieważ prezentacja może zawierać tylko własne układy. Wybrany układ jest następnie zastosowany do pierwszego normalnego slajdu za pomocą metody [Slide.setLayoutSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#setLayoutSlide).

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

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje elementów zastępczych, dziedziczone formatowanie i powiązania między istniejącymi elementami zastępczymi a nowym układem mogą się zmienić, więc sprawdź wynik przy przełączaniu między znacząco różnymi układami.

## **Dodanie układu slajdu**

Wybór i tworzenie to odrębne operacje. W poprzednim przykładzie wybierany jest istniejący układ; nie jest on tworzony. Aby utworzyć układ, wywołaj metodę [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) na kolekcji układów docelowego głównego slajdu.

Poniższy przykład zawsze dodaje nowy układ **Title and Content** o nazwie `Report Title and Content`, a następnie dodaje normalny slajd oparty na tym układzie. Nazwy układów muszą być unikalne w kolekcji.

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

Dodawaj układ tylko wtedy, gdy szablon naprawdę potrzebuje kolejnej wielokrotnego użytku struktury. Jeśli istnieje odpowiedni układ, wybierz i użyj go ponownie zamiast tworzyć duplikat.

## **Dodawanie elementów zastępczych do układu slajdu**

Metoda [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) zwraca [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/) umożliwiający dodawanie kształtów elementów zastępczych do układu.

| Placeholder PowerPoint              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Treść](content.png)               | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Treść (pionowa)](contentV.png)    | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Tekst](text.png)                  | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Tekst (pionowy)](textV.png)       | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Obraz](picture.png)               | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Wykres](chart.png)                | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabela](table.png)                | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Obraz online](onlineImage.png)    | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Poniższy przykład weryfikuje, że układ **Blank** istnieje, dodaje do niego cztery elementy zastępcze, a następnie tworzy normalny slajd korzystający z zmodyfikowanego układu. Kolejność jest zamierzona: elementy zastępcze są dodawane przed utworzeniem normalnego slajdu, dzięki czemu Aspose.Slides może wygenerować odpowiadające im kształty na tym slajdzie.

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
Zmiana dziedziczonego formatowania lub geometrii istniejących elementów zastępczych w układzie może wpłynąć na zależne slajdy. Nowo dodany element zastępczy układu nie jest uzupełniany w istniejących normalnych slajdach. Testuj zmiany układów na kopii prezentacji i sprawdzaj każdy zależny slajd.
{{% /alert %}}

## **Usuwanie nieużywanych układów slajdu**

Użyj metody [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), aby usunąć układy, do których nie odnosi się żaden normalny slajd. Metoda pozostawia nienaruszone układy, które nadal są używane.

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

Aby usunąć konkretny układ, najpierw użyj jego metody [hasDependingSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) lub [getDependingSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Przypisz wszelkie zależne slajdy przed wywołaniem [LayoutSlide.remove](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#remove). Próba usunięcia używanego układu powoduje wyrzucenie [PptxEditException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxeditexception/).

## **Kontrola widoczności stopki w układzie slajdu**

Układ ma własne elementy zastępcze stopki, numeru slajdu i daty/czasu. Użyj metody [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager), aby sterować tymi elementami w jednym układzie. Jest to przydatne, gdy na przykład układy treści powinny wyświetlać stopki, a układy tytułowe nie powinny.

Poniższy przykład wybiera układ w sposób bezpieczny i ustawia widoczność elementów stopki:

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

## **Kontrola widoczności stopki w głównym slajdzie i jego układach potomnych**

Aby zastosować spójne ustawienia stopki w całej hierarchii głównego slajdu, użyj metody [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Metody propagacji [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslideheaderfootermanager/) działają na głównym slajdzie oraz jego zależnych układach i normalnych slajdach; nie dotyczą pojedynczego normalnego slajdu.

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

**Jaka jest różnica między głównym slajdem a układem slajdu?**

Główny slajd definiuje motyw prezentacji i wspólne formatowanie. Układ slajdu należy do głównego slajdu i określa jedną wielokrotnego użytku konfigurację elementów zastępczych. Normalne slajdy używają tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji przy użyciu metody [addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Przy kopiowaniu między prezentacjami sprawdź również czcionki, motywy, obrazy i inne zasoby użyte w źródłowym układzie.

**Co się stanie, gdy zmodyfikuję układ, który jest już używany?**

Zależne slajdy dziedziczą zmiany układu, chyba że nadpisują dotknięte formatowanie lub obiekty lokalnie. Geometria elementów zastępczych i dziedziczony styl mogą więc zmienić się jednocześnie na wielu slajdach. Użyj [getDependingSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/#getDependingSlides), aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides rzuca [PptxEditException](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pptxeditexception/). Najpierw przypisz zależne slajdy do innego układu lub użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), aby usunąć tylko nieodwoływane układy.