---
title: Pobierz efektywne właściwości kształtu z prezentacji w JavaScript
linktitle: Efektywne właściwości
type: docs
weight: 50
url: /pl/nodejs-java/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- system oświetlenia
- kształt fazowany
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak używać Aspose.Slides dla Node.js via Java, aby rozróżnić lokalne, dziedziczone i efektywne formatowanie kształtów w prezentacjach PowerPoint."
---
## **Zrozumienie lokalnych, dziedziczonych i efektywnych właściwości**

PowerPoint formatowanie może pochodzić z kilku miejsc. Wartość przechowywana bezpośrednio na obiekcie jest jego **wartością lokalną**. Jeśli ta wartość nie jest ustawiona, PowerPoint przegląda źródła formatowania nadrzędnego, takie jak domyślny akapit, styl tekstu, układ lub slajd wzorcowy, motyw lub domyślne ustawienia na poziomie prezentacji. Te wartości są **wartościami dziedziczonymi**. Wartość, która pozostaje po rozwiązaniu całej hierarchii, jest **wartością efektywną** — wartością używaną do renderowania obiektu.

Na przykład fragment tekstu może nie definiować własnej wysokości czcionki. Jego lokalna wartość [getFontHeight](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portionformat/#getFontHeight) jest wtedy `NaN`, co oznacza „nie ustawiono tutaj”. Fragment może dziedziczyć wysokość z akapitu, domyślnego stylu tekstu w prezentacji lub innego odpowiedniego źródła. Wywołanie [getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portionformat/#getEffective) na formacie fragmentu zwraca ostateczną rozwiązane wysokość.

Używaj dwóch rodzajów danych formatowania w różnych celach:

- Odczytaj lub zmień lokalny obiekt formatowania, taki jak [PortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portionformat/), gdy potrzebujesz kontrolować, gdzie wartość jest zdefiniowana.
- Odczytaj [efektywne dane zwracane przez PortionFormat.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portionformat/#getEffective), gdy potrzebujesz ostatecznego, renderowanego wyniku. Dane efektywne są tylko do odczytu.

Przed uruchomieniem przykładów, [zainstaluj Aspose.Slides dla Node.js via Java](/slides/pl/nodejs-java/installation/).

## **Porównaj wartości lokalne, dziedziczone i efektywne**

Poniższy kompletny przykład tworzy kształt i stosuje wysokości czcionek na poziomach prezentacji, akapitu i fragmentu. Każdy krok wypisuje wartości zdefiniowane na tych poziomach oraz wynikającą wartość efektywną dla tego samego fragmentu tekstu. Pokazuje także, dlaczego dane efektywne muszą być odczytane ponownie po zmianach formatowania.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Odczytaj dane efektywne po poprzednich zmianach.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Zdefiniuj dziedziczone wartości na dwóch różnych poziomach.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Lokalna wartość w fragmencie nadpisuje obie dziedziczone wartości.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Zmiana dziedziczonej wartości nie nadpisuje istniejącej lokalnej wartości.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Wyczyść lokalną wartość. Fragment teraz ponownie dziedziczy z akapitu.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Wyczyść wartość akapitu. Domyślna wartość prezentacji teraz dostarcza wynik.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Priorytet w tym przykładzie to formatowanie lokalne fragmentu, następnie formatowanie akapitu, a na końcu domyślne w prezentacji. Inne obiekty mogą mieć różne łańcuchy dziedziczenia, ale zasada jest ta sama: bardziej specyficzna, jawna wartość wygrywa, a [getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portionformat/#getEffective) zwraca ostateczny wynik.

## **Pobierz efektywne właściwości tekstu**

Formatowanie tekstu jest podzielone na kilka obiektów:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#getEffective) rozwiązuje właściwości ramki tekstowej, takie jak marginesy, zakotwiczenie, dopasowanie automatyczne i pionowy kierunek tekstu.
- [TextStyle.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textstyle/#getEffective) rozwiązuje formatowanie akapitu dla każdego poziomu stylu tekstu.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#getEffective) rozwiązuje właściwości akapitu, takie jak wyrównanie, wcięcie i punktorowanie.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portionformat/#getEffective) rozwiązuje właściwości znaków, takie jak wysokość czcionki, krój, kolor, pogrubienie i kursywa.

Dla kolejnego przykładu, `text-formatting.pptx` musi zawierać przynajmniej jeden slajd i jedną [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) z niepustą ramką tekstową. AutoShape może znajdować się w dowolnym miejscu kolekcji kształtów; kod wyszukuje odpowiedni obiekt i waliduje go przed użyciem.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywne właściwości 3D**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getEffective) zwraca jeden obiekt danych efektywnych, który grupuje wszystkie rozwiązane ustawienia 3D. Jego metody [getCamera](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getBevelTop) i [getBevelBottom](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/#getBevelBottom) udostępniają odpowiadające dane efektywne. Czytanie tych powiązanych ustawień razem ułatwia zrozumienie ostatecznego wyglądu 3D kształtu.

Dla tego przykładu, `shape-3d.pptx` musi zawierać przynajmniej jeden kształt na pierwszym slajdzie. Zastosuj ustawienia kamery 3D, oświetlenia lub fazowania do tego kształtu, jeśli chcesz, aby wynik zawierał wartości inne niż domyślne.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywne formatowanie tabeli**

Formatowanie tabeli może pochodzić ze stylu tabeli oraz z formatów zastosowanych do całej tabeli, kolumny, wiersza lub pojedynczej komórki. W przypadku konfliktów między jawnie zdefiniowanymi wypełnieniami priorytet jest: komórka, wiersz, kolumna, a następnie cała tabela. Efektywny format komórki to ostateczny format używany do jej rysowania.

Dla tego przykładu, `table-formatting.pptx` musi zawierać przynajmniej jedną tabelę na pierwszym slajdzie. Tabela musi mieć przynajmniej jeden wiersz i jedną kolumnę. Kod wyszukuje [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/table/) zamiast zakładać, że `getShapes().get_Item(0)` jest tabelą.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Jeśli potrzebujesz koloru, a nie tylko typu wypełnienia, najpierw sprawdź efektywne [getFillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/#getFillType), a następnie odczytaj metodę odpowiadającą temu typowi — na przykład [getSolidFillColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) dla wypełnienia jednolitego.

## **Ponowne odczytanie danych efektywnych po zmianach**

Dane efektywne opisują hierarchię formatowania w momencie ich rozwiązania. Wywołaj `getEffective` ponownie po zmianie czegokolwiek, co może uczestniczyć w tej hierarchii, w tym:

- lokalne formatowanie obiektu;
- domyślne wartości akapitu lub ramki tekstowej;
- styl tabeli, tabela, kolumna, wiersz lub format komórki;
- formatowanie układu lub slajdu wzorcowego;
- dane motywu lub domyślne ustawienia na poziomie prezentacji;
- układ lub slajd wzorcowy przypisany do slajdu.

Nie przechowuj obiektu danych efektywnych jako trwałej migawki. Aspose.Slides może wewnętrznie buforować niektóre dane efektywne, a późniejsze wywołanie `getEffective` może odświeżyć te dane. Jeśli potrzebujesz porównać wartości przed i po zmianie, skopiuj potrzebne wartości skalarne — takie jak wysokość czcionki, kolor, wyrównanie lub szerokość fazowania — do własnych zmiennych przed dokonaniem zmiany.

Aby zmienić wartość, zaktualizuj odpowiedni lokalny obiekt formatowania, a następnie wywołaj `getEffective`, aby zweryfikować wynik. Obiekty danych efektywnych są tylko do odczytu.

## **FAQ**

**Jak mogę określić, który poziom dostarczył efektywną wartość?**

Dane efektywne zawierają ostateczną wartość, a nie jej źródło. Przejrzyj odpowiednie lokalne obiekty, zaczynając od najbardziej specyficznego poziomu i idąc na zewnątrz. Dla tekstu może to obejmować fragment, akapit, ramkę tekstową, układ, slajd wzorcowy, motyw i domyślne ustawienia prezentacji. Niezdefiniowane wartości, takie jak `NaN` lub `null`, wskazują, że wyszukiwanie kontynuuje na kolejnym poziomie.

**Co się dzieje, gdy żaden poziom nie definiuje właściwości?**

Aspose.Slides rozwiązuje odpowiedni domyślny PowerPointa lub biblioteki. Ta rozwiązana wartość pojawia się w danych efektywnych, mimo że żaden lokalny obiekt nie definiuje jej jawnie.

**Dlaczego efektywna wartość czasami jest równa wartości lokalnej?**

Wartość lokalna wygrała obliczenia dziedziczenia. Jest to oczekiwane, gdy właściwość jest jawnie ustawiona na obiekcie i żadna bardziej szczegółowa reguła jej nie nadpisuje.

**Kiedy powinienem używać danych lokalnych zamiast danych efektywnych?**

Używaj danych lokalnych do inspekcji lub edycji konkretnego poziomu formatowania. Używaj danych efektywnych, gdy potrzebny jest ostateczny wygląd po zastosowaniu dziedziczenia, zasad motywu i odpowiednich stylów. [Pełny przykład porównania](#compare-local-inherited-and-effective-values) demonstruje oba w tym samym przepływie pracy.