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
- Sklonuj kształt
- Usuń kształt
- Ukryj kształt
- Zmień kolejność kształtu
- Pobierz ID kształtu interop
- Alternatywny tekst kształtu
- Punkt regulacji kształtu
- Regulacja wstępnie ustawionego kształtu
- Geometria kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- Odwróć kształt
- PowerPoint
- Prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, regulować, klonować, usuwać, ukrywać, zmieniać kolejność, eksportować, wyrównywać i odwracać kształty prezentacji za pomocą Aspose.Slides dla Node.js poprzez Java."
---
## **Przegląd**

Aspose.Slides for Node.js via Java przedstawia kształty na slajdzie jako uporządkowaną [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/). Kolekcja jest jednocześnie miejscem, w którym znajdziesz i zmodyfikujesz kształty oraz źródłem ich kolejności nakładania: indeks `0` to najdalej znajdujący się z tyłu kształt, a ostatni indeks to kształt najbliżej przodu.

Ten artykuł opiera się na tym modelu. Najpierw wyjaśnia, jak wiarygodnie zidentyfikować kształt i zmodyfikować wstępnie ustawione punkty regulacji, a potem pokazuje, jak klonować, usuwać, ukrywać i zmieniać kolejność kształtów. Ostatnie sekcje obejmują formatowanie na poziomie układu, eksport SVG, wyrównywanie i ustawienia odbicia. Każdy przykład jest niezależny, więc możesz używać tylko operacji wymaganych w Twoim przepływie pracy.

## **Identyfikowanie i znajdowanie kształtów**

Indeksy kolekcji są wygodne przy przetwarzaniu znanego pliku, ale nie są stabilnymi identyfikatorami. Dodanie, usunięcie lub zmiana kolejności kształtu może zmienić jego indeks. Wybierz identyfikator zgodnie z tym, jak prezentacja jest tworzona i utrzymywana:

- [Name](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getname/) jest przydatny w szablonach kontrolowanych przez dewelopera i łatwo go sprawdzić w panelu wyboru PowerPointa. Nazwy można edytować i nie są gwarantowanie unikalne, więc wprowadź konwencję nazewnictwa, jeśli kod od nich zależy.
- [AlternativeText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getalternativetext/) jest użyteczny, gdy opis dostępności lub tag dostarczony przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub przepisany w celu zapewnienia dostępności i nie jest gwarantowanie unikalny. Nie używaj cicho znaczącego tekstu dostępności jako klucza bazy danych.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) to identyfikator tylko do odczytu, unikalny w obrębie slajdu i odpowiadający ID kształtu używanemu przez interfejs PowerPoint. Używaj go przy integracji z PowerPointem lub gdy potrzebujesz jednoznacznego odwołania podczas życia kształtu. Sklonowany lub odtworzony kształt jest innym kształtem i otrzymuje własny ID.

Powiązana metoda [getUniqueId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getuniqueid/) zwraca identyfikator w zakresie prezentacji, ale ten identyfikator jest przeznaczony dla dodatków i może być ponownie przypisany. Nie należy go traktować jako trwałego klucza zewnętrznego. Jeśli długoterminowa tożsamość jest istotna, przechowuj mapowanie w danych aplikacji i weryfikuj, czy oczekiwany kształt wciąż istnieje.

Poniższy przykład wyszukuje po nazwie przy użyciu dokładnego porównania i raportuje interopowy ID w zakresie slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z niewłaściwym obiektem.

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

## **Identyfikowanie i modyfikowanie wstępnie ustawionych regulacji kształtów**

Kształty o wstępnie określonej geometrii mogą udostępniać punkty regulacji, które kontrolują cechy takie jak rozmiar narożnika, proporcje strzałki lub kąty łuku. Dostęp do nich uzyskuje się przez tylko do odczytu kolekcję [GeometryShape.getAdjustments](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/geometryshape/). Sama kolekcja jest dostarczana przez kształt, ale każdy [AdjustValue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/adjustvalue/) zawiera wartość, którą można zmienić.

Nie polegaj wyłącznie na stałym indeksie kolekcji. Iteruj przez regulacje i sprawdzaj tylko do odczytu metodę [getType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/adjustvalue/), której wartość [ShapeAdjustmentType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapeadjustmenttype/) opisuje, co regulacja kontroluje. Metoda tylko do odczytu [getName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/adjustvalue/getname/) dostarcza dodatkowych informacji identyfikacyjnych i jest szczególnie przydatna, gdy wstępnie ustawiony kształt zawiera więcej niż jedną regulację tego samego typu semantycznego.

Użyj metody wartości odpowiadającej znaczeniu regulacji:

| Typ regulacji | Cel | Wartość do zmiany |
|---|---|---|
| `CornerSize` | Rozmiar zaokrąglonych narożników | [setRawValue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Grubość ogona strzałki | `setRawValue` |
| `ArrowheadLength` | Długość grotu strzałki | `setRawValue` |
| `ArrowheadWidth` | Szerokość grotu strzałki | `setRawValue` |
| `StartAngle` | Kąt początkowy wycinka koła lub łuku | [setAngleValue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Kąt końcowy wycinka koła lub łuku | `setAngleValue` |

`getType` i `getName` zwracają informacje tylko do odczytu. `getRawValue` i `setRawValue` pracują z liczbą całkowitą w natywnych jednostkach geometrii wstępnego ustawienia, natomiast `getAngleValue` i `setAngleValue` pracują z kątem w stopniach. Liczba, kolejność, znaczenie i prawidłowy zakres regulacji zależą od wstępnie ustawionego [GeometryShape.getShapeType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/geometryshape/). Wartość ważna dla jednego wstępnie ustawienia może być nieważna lub mieć inny efekt dla innego.

Gdy `getType` zwraca `ShapeAdjustmentType.Custom`, API nie rozpoznaje standardowego znaczenia semantycznego. Sprawdź `getName`, typ wstępny i istniejącą wartość, i pozostaw regulację niezmienioną, chyba że znane są oczekiwane znaczenie i zakres. Nawet dla rozpoznanych typów, sprawdź, czy ten sam typ występuje więcej niż raz przed wybraniem wartości. Artykuł [Connector](/slides/pl/nodejs-java/connector/) pokazuje tę sytuację w kontekście regulacji zgięcia łącznika.

Poniższy kompletny przykład tworzy domyślne i zmodyfikowane wersje trzech wstępnie ustawionych kształtów. Iteruje przez każdą regulację, raportuje jej nazwę i typ, zmienia wartości związane z rozmiarem poprzez `setRawValue`, zmienia kąty poprzez `setAngleValue` i zapisuje wynik. Lewa kolumna zachowuje domyślną geometrię; prawa kolumna pokazuje dostosowany prostokąt zaokrąglony, czterokierunkową strzałkę i wycinek koła.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Dodaje nagłówki dla kolumn domyślnego i zmodyfikowanego kształtu.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sprawdzanie typu semantycznego przed zmianą wartości sprawia, że kod jest jednoznaczny co do zamiaru i unika założenia, że konkretny indeks kolekcji ma to samo znaczenie w różnych wstępnie ustawionych kształtach.

## **Modyfikowanie kolekcji kształtów**

Metody dodawania, klonowania, usuwania i zmiany kolejności działają natychmiast na kolekcji. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie polegaj dalej na indeksach pobranych przed tą operacją.

### **Klonowanie kształtu**

[addClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/addclone/) tworzy niezależną kopię i dołącza ją do docelowej kolekcji. [insertClone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/insertclone/) również tworzy kopię, ale umieszcza ją pod określonym indeksem z‑order. Przeciążenia przyjmujące współrzędne przesuwają klon bez zmiany jego rozmiaru; przeciążenia z szerokością i wysokością mogą go także przeskalować.

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

Klonowanie kopiuje zawartość i formatowanie kształtu, w tym jego nazwę i tekst alternatywny. Przypisz nowe logiczne identyfikatory klonowi, gdy te wartości muszą być unikalne. Zasoby używane przez złożone kształty są obsługiwane przez prezentację, ale klon pozostaje nowym elementem kolekcji z nową tożsamością kształtu.

### **Usuwanie kształtów**

[remove](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/remove/) usuwa konkretny obiekt kształtu z jego kolekcji. Podczas usuwania wielu dopasowań w trakcie iteracji indeksowanej, przechodź od końca, aby każdy pozostały indeks pozostał prawidłowy.

Ten przykład usuwa każdy kształt o określonej nazwie. Odczytuje kształt pod bieżącym indeksem i nie zakłada konkretnego typu kształtu.

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

Po usunięciu liczba kształtów i indeksy kolejnych kształtów ulegają zmianie. Odwołania do niezmienionych kształtów pozostają bardziej wiarygodne niż zapisane indeksy. Pamiętaj także o łącznikach, animacjach i innych elementach prezentacji, które mogą odwoływać się do usuniętego obiektu; usunięcie widzialnego kształtu może zmienić więcej niż wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Hidden](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/sethidden/) na `true` pozostawia kształt w kolekcji, ale zapobiega jego wyświetlaniu w normalnym pokazie slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne w kodzie, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą być przywrócone później.

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

Ukrywanie nie jest usuwaniem ani zabezpieczeniem. Obiekt nadal może być wykryty i odsłonięty przez użytkownika lub kod, i pozostaje częścią pliku prezentacji.

### **Zmiana kolejności Z‑Order**

Nakładające się kształty są renderowane w kolejności kolekcji. [reorder](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/reorder/) przenosi istniejący kształt do docelowego indeksu bez jego klonowania. Indeks `0` to tył; `size() - 1` to przód.

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

Prostokąt jest tworzony jako pierwszy i początkowo znajduje się za elipsą. Przeniesienie go na ostatni indeks umieszcza go z przodu. Sfinalizuj kolejność Z po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dołączają lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzoną kolejność.

## **Inspekcja kształtów na slajdach układu**

Normalne slajdy, slajdy układu i slajdy mistrza mają oddzielne kolekcje kształtów. Kształt w kolekcji układu nie jest tym samym obiektem co podobnie pozycjonowany kształt na normalnym slajdzie. Przeglądaj kształty układu, gdy potrzebujesz zrozumieć lub zmienić formatowanie dostarczane przez układ.

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

Edycja układu może wpływać na wiele slajdów, które go używają. Przed zmianą kształtu układu określ, czy normalny slajd dziedziczy obiekt lub zawiera lokalne nadpisanie, i przetestuj każdy slajd korzystający z tego układu.

## **Eksportowanie kształtu do SVG**

[writeAsSvg](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/writeassvg/) zapisuje wyrenderowaną zawartość jednego kształtu do strumienia. Wynik zawiera kształt, a nie całe tło slajdu ani sąsiednie kształty.

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

Utrzymuj prezentację otwartą podczas renderowania. Wyjście zależy od formatowania kształtu oraz od zasobów takich jak czcionki i obrazy. Jeśli potrzebujesz całej kompozycji, wyeksportuj slajd zamiast pojedynczego kształtu. Wywołujący jest właścicielem strumienia i musi go zamknąć.

## **Wyrównywanie kształtów**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideutil/alignshapes/) ma przeciążenia, które wyrównują wszystkie kształty lub wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapesalignmenttype/) określa krawędź, linię środkową lub tryb dystrybucji. Ustaw `alignToSlide` na `true`, aby używać krawędzi slajdu; ustaw na `false`, aby wyrównywać wybrane kształty względem siebie nawzajem.

Ten przykład wyrównuje trzy kształty do górnej krawędzi slajdu. Zwrotne referencje do kształtów są konwertowane na ich bieżące indeksy bezpośrednio przed wyrównaniem.

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

Wyrównanie zmienia pozycje, a nie kolejność Z. Wyrównanie względne zazwyczaj wymaga przynajmniej dwóch kształtów, podczas gdy dystrybucja pozioma lub pionowa wymaga wystarczającej liczby kształtów do określenia odstępów. Przelicz indeksy, jeśli modyfikujesz kolekcję przed wywołaniem metody.

## **Odbijanie kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odbicia poziomego i pionowego oraz rotację. Jej wartości `getFlipH` i `getFlipV` używają [NullableBool](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/nullablebool/): `True` włącza odbicie, `False` wyłącza, a `NotDefined` zachowuje nieokreślony/ domyślny stan.

Prezentacja wejściowa poniżej zawiera jeden nieodbijany kształt.

![The shape before flipping](shape_to_be_flipped.png)

Przykład zachowuje wszystkie inne wartości ramki i zamienia tylko dwa ustawienia odbicia. To ważne, ponieważ przypisanie nowego [Frame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/setframe/) zastępuje całą ramkę.

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

Zapisany kształt jest lustrzanie odbity poziomo i pionowo, zachowując pozycję, rozmiar i rotację.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w krótkotrwałym przetwarzaniu, gdy kolekcja nie zmieni się przed użyciem indeksu. Preferuj zweryfikowaną konwencję `Name` lub `AlternativeText` dla szablonów tworzonych ręcznie, lub `OfficeInteropShapeId` dla prac opartych na interop z PowerPointem.

**Czy ukrycie kształtu usuwa go z kolejności Z?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Może być odnaleziony, przestawiony, edytowany lub ponownie widoczny.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

`addClone` dołącza klon na końcu kolekcji, co jest przodem kolejności Z. Użyj `insertClone`, aby wybrać początkowy indeks, lub `reorder` po dodaniu wszystkich kształtów.

**Czy mogę używać stałego indeksu do identyfikacji regulacji wstępnie ustawionego kształtu?**

Tylko po zweryfikowaniu dokładnego wstępnego ustawienia i układu kolekcji. Preferuj iterację przez `GeometryShape.getAdjustments` i sprawdzanie `AdjustValue.getType`; użyj `AdjustValue.getName` jako dodatkowej informacji, gdy ten sam typ semantyczny pojawia się więcej niż raz.