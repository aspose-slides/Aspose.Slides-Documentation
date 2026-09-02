---
title: Zarządzanie kształtami prezentacji w JavaScript
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/nodejs-java/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- Kształt na slajdzie
- Znajdź kształt
- Klonuj kształt
- Usuń kształt
- Ukryj kształt
- Zmień kolejność kształtu
- Pobierz interop ID kształtu
- Alternatywny tekst kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- Odbij kształt
- PowerPoint
- Prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, klonować, usuwać, ukrywać, zmieniać kolejność, eksportować, wyrównywać i odbijać kształty prezentacji za pomocą Aspose.Slides dla Node.js via Java."
---
## **Przegląd**

Aspose.Slides for Node.js via Java przedstawia kształty na slajdzie jako uporządkowaną [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/). Kolekcja jest jednocześnie miejscem, w którym znajdujesz i modyfikujesz kształty, oraz źródłem ich kolejności nakładania: indeks `0` to najdalej w tył kształt, a ostatni indeks to kształt najbliżej przodu.

Ten artykuł podąża za tym modelem. Najpierw wyjaśnia, jak wiarygodnie zidentyfikować kształt, a następnie pokazuje, jak klonować, usuwać, ukrywać i zmieniać kolejność kształtów. Ostatnie sekcje obejmują formatowanie na poziomie układu, eksport do SVG, wyrównywanie i ustawienia odbicia. Każdy przykład jest niezależny, więc możesz używać tylko operacji, które są potrzebne w twoim przepływie pracy.

## **Identyfikacja i znajdowanie kształtów**

Indeksy w kolekcji są wygodne podczas przetwarzania znanego pliku, ale nie są stabilnymi identyfikatorami. Dodanie, usunięcie lub zmiana kolejności kształtu może zmienić jego indeks. Wybierz identyfikator w zależności od tego, jak prezentacja jest tworzona i utrzymywana:

- [Name](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getname/) jest przydatny w szablonach kontrolowanych przez dewelopera i łatwo go sprawdzić w panelu wyboru programu PowerPoint. Nazwy mogą być edytowane i nie są gwarantowane jako unikalne, więc ustanów konwencję nazewnictwa, jeśli kod od nich zależy.
- [AlternativeText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getalternativetext/) jest przydatny, gdy opis dostępności lub tag dostarczony przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub przepisany pod kątem dostępności i nie jest gwarantowany jako unikalny. Nie należy cicho wykorzystywać istotnego tekstu dostępnościowego jako klucza w bazie danych.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) jest identyfikatorem tylko do odczytu, który jest unikalny w obrębie slajdu i odpowiada identyfikatorowi kształtu używanemu przez interfejs PowerPoint. Używaj go przy integracji z PowerPoint lub gdy potrzebujesz jednoznacznego odniesienia w czasie życia kształtu. Sklonowany lub odtworzony kształt jest innym kształtem i otrzymuje własny identyfikator.

Powiązana metoda [getUniqueId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getuniqueid/) zwraca identyfikator o zakresie prezentacji, ale jest przeznaczona dla dodatków i może być ponownie przypisana. Nie należy traktować go jako stały klucz zewnętrzny. Jeśli trwała tożsamość jest istotna, przechowuj mapowanie w danych aplikacji i weryfikuj, czy oczekiwany kształt nadal istnieje.

Poniższy przykład wyszukuje po nazwie przy użyciu dokładnego porównania i raportuje interopowy identyfikator w zakresie slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z niewłaściwym obiektem.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Gdy operacja jest specyficzna dla typu kształtu, sprawdź klasę w czasie wykonywania przed użyciem członków specyficznych dla typu. Ten przykład aktualizuje tekst i tekst alternatywny tylko wtedy, gdy nazwany obiekt jest [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Modyfikacja kolekcji kształtów**

Metody add, clone, remove i reorder działają na kolekcji natychmiast. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie polegaj dalej na indeksach zarejestrowanych przed tą operacją.

### **Klonowanie kształtu**

[addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/addclone/) tworzy niezależną kopię i dołącza ją do docelowej kolekcji. [insertClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/insertclone/) również tworzy kopię, ale umieszcza ją pod określonym indeksem kolejności Z. Przeciążenia przyjmujące współrzędne przemieszczają klon bez zmiany jego rozmiaru; przeciążenia z szerokością i wysokością mogą również zmienić jego rozmiar.

Przykład tworzy slajd docelowy, klonuje oznaczony prostokąt na przód i wstawia drugi klon z tyłu. Zmiany w którymkolwiek klonie nie modyfikują kształtu źródłowego.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Klonowanie kopiuje zawartość i formatowanie kształtu, w tym jego nazwę i tekst alternatywny. Przypisz nowe logiczne identyfikatory do klona, gdy te wartości muszą być unikalne. Zasoby używane przez złożone kształty są obsługiwane przez prezentację, ale klon pozostaje nowym elementem kolekcji z nową tożsamością kształtu.

### **Usuwanie kształtów**

[remove](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/remove/) usuwa konkretny obiekt kształtu z jego kolekcji. Przy usuwaniu wielu dopasowań podczas iteracji po indeksach, przechodź od końca, aby każdy pozostały indeks pozostał ważny.

Ten przykład usuwa każdy kształt o wyznaczonej nazwie. Odczytuje kształt pod bieżącym indeksem i nie zakłada określonego typu kształtu.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Po usunięciu liczba kształtów i indeksy kolejnych kształtów ulegają zmianie. Odniesienia do niezmienionych kształtów pozostają bardziej wiarygodne niż zapisane indeksy. Weź także pod uwagę łączniki, animacje i inne elementy prezentacji, które mogą odwoływać się do usuniętego obiektu; usunięcie widocznego kształtu może zmienić więcej niż wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Hidden](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/sethidden/) na `true` pozostawia kształt w kolekcji, ale zapobiega jego wyświetlaniu w normalnym pokazie slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne dla kodu, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą być przywrócone później.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ukrywanie nie jest usuwaniem ani zabezpieczeniem. Obiekt nadal może być odnaleziony i odkryty przez użytkownika lub kod, i pozostaje częścią pliku prezentacji.

### **Zmiana kolejności Z**

Nakładające się kształty są rysowane w kolejności kolekcji. [reorder](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/reorder/) przenosi istniejący kształt do docelowego indeksu bez jego klonowania. Indeks `0` to tył; `size() - 1` to przód.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Prostokąt jest tworzony najpierw i początkowo znajduje się za elipsą. Przeniesienie go do ostatniego indeksu umieszcza go z przodu. Ustal kolejność Z po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dołączają lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzoną kolejność.

## **Inspekcja kształtów na slajdach układu**

Normalne slajdy, slajdy układu i slajdy główne mają osobne kolekcje kształtów. Kształt w kolekcji układu nie jest tym samym obiektem co podobnie pozycjonowany kształt na normalnym slajdzie. Inspekcję kształtów układu przeprowadzaj, gdy musisz zrozumieć lub zmienić formatowanie dostarczane przez układ.

Poniższy przykład odczytuje [FillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getfillformat/) i [LineFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getlineformat/) każdego kształtu układu, nie zakładając, że każdy kształt jest `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Edycja układu może wpływać na wiele slajdów, które go używają. Przed zmianą kształtu w układzie, określ, czy normalny slajd dziedziczy obiekt, czy zawiera lokalne nadpisanie, i przetestuj każdy slajd wykorzystujący ten układ.

## **Eksport kształtu do SVG**

[writeAsSvg](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/writeassvg/) zapisuje wyrenderowaną zawartość jednego kształtu do strumienia. Wynik zawiera kształt, a nie pełne tło slajdu ani sąsiednie kształty.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Utrzymuj prezentację otwartą podczas renderowania. Wyjście zależy od formatowania kształtu oraz zasobów, takich jak czcionki i obrazy. Jeśli potrzebujesz całej kompozycji, wyeksportuj slajd zamiast pojedynczego kształtu. Strumień należy do wywołującego i musi zostać zamknięty.

## **Wyrównywanie kształtów**

Przeciążenia [SlideUtil.alignShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideutil/alignshapes/) wyrównują wszystkie kształty lub wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapesalignmenttype/) określa krawędź, linię środkową lub tryb rozmieszczania. Ustaw `alignToSlide` na `true`, aby użyć krawędzi slajdu; ustaw na `false`, aby wyrównać wybrane kształty względem siebie.

Ten przykład wyrównuje trzy kształty do górnej krawędzi slajdu. Zwrócone odwołania do kształtów są konwertowane na ich bieżące indeksy tuż przed wyrównaniem.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wyrównanie zmienia pozycje, a nie kolejność Z. Wyrównanie względne zazwyczaj wymaga co najmniej dwóch kształtów, podczas gdy rozmieszczenie poziome lub pionowe wymaga wystarczającej liczby kształtów do określenia odstępów. Przelicz indeksy ponownie, jeśli modyfikujesz kolekcję przed wywołaniem metody.

## **Odbicie kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odbicia w poziomie i pionie oraz obrót. Jej wartości `getFlipH` i `getFlipV` używają [NullableBool](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/nullablebool/): `True` włącza odbicie, `False` je wyłącza, a `NotDefined` zachowuje nieokreślony/ domyślny stan.

Poniższa prezentacja wejściowa zawiera jeden nieodbijany kształt.

![Kształt przed odbiciem](shape_to_be_flipped.png)

Przykład zachowuje wszystkie inne wartości ramki i zamienia tylko dwa ustawienia odbicia. Jest to ważne, ponieważ przypisanie nowej [Frame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/setframe/) zastępuje całą ramkę.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zapisany kształt jest odbity poziomo i pionowo, zachowując jednocześnie swoją pozycję, rozmiar i obrót.

![Kształt po odbiciu](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w przypadku krótkotrwałego przetwarzania, gdy kolekcja nie zmieni się przed użyciem indeksu. Preferuj zweryfikowaną konwencję `Name` lub `AlternativeText` dla tworzonych szablonów, lub `OfficeInteropShapeId` dla pracy z interopem w zakresie slajdu.

**Czy ukrycie kształtu usuwa go z kolejności Z?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Może być odnaleziony, przestawiony, edytowany lub ponownie widoczny.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

`addClone` dołącza klon na koniec kolekcji, co jest przodem kolejności Z. Użyj `insertClone`, aby wybrać początkowy indeks, lub `reorder` po dodaniu wszystkich kształtów.