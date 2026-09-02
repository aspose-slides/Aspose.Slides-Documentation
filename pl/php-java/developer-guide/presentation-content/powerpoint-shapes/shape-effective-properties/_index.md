---
title: Pobieranie efektywnych właściwości kształtu z prezentacji w PHP
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/php-java/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- zestaw oświetlenia
- kształt sfazowany
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak używać Aspose.Slides dla PHP via Java, aby rozróżnić lokalne, dziedziczone i efektywne formatowanie kształtów w prezentacjach PowerPoint."
---
## **Zrozumienie lokalnych, dziedziczonych i efektywnych właściwości**

Formatowanie PowerPoint może pochodzić z kilku miejsc. Wartość przechowywana bezpośrednio na obiekcie jest jego **wartością lokalną**. Jeśli ta wartość nie jest ustawiona, PowerPoint sprawdza źródła formatowania nadrzędnego, takie jak domyślny akapit, styl tekstu, układ lub slajd-mistrz, motyw lub domyślne ustawienia prezentacji. Te wartości są **wartościami dziedziczonymi**. Wartość, która pozostaje po rozwiązaniu całej hierarchii, jest **wartością efektywną** — wartością używaną do renderowania obiektu.

Na przykład fragment tekstu może nie definiować własnej wysokości czcionki. Jego lokalna wartość [getFontHeight](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/) wynosi wtedy `NAN`, co oznacza „nie ustawiono tutaj”. Fragment może dziedziczyć wysokość z akapitu, domyślnego stylu tekstu prezentacji lub innego odpowiedniego źródła. Wywołanie [getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/geteffective/) na formacie fragmentu zwraca ostateczną rozwiązaną wysokość.

Używaj dwóch rodzajów danych formatowania w różnych celach:

- Odczytuj lub zmieniaj lokalny obiekt formatu, taki jak [PortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/), gdy potrzebujesz kontrolować, gdzie wartość jest zdefiniowana.
- Odczytuj obiekt danych efektywnych, taki jak [dane zwracane przez PortionFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/geteffective/), gdy potrzebujesz ostatecznego, wyrenderowanego wyniku. Dane efektywne są tylko do odczytu.

Przed uruchomieniem przykładów, [zainstaluj Aspose.Slides dla PHP via Java](/slides/pl/php-java/installation/).

## **Porównanie wartości lokalnych, dziedziczonych i efektywnych**

Poniższy kompletny przykład tworzy kształt i stosuje wysokości czcionek na poziomach prezentacji, akapitu i fragmentu. Każdy krok wypisuje wartości zdefiniowane na tych poziomach oraz wynikającą wartość efektywną dla tego samego fragmentu tekstu. Pokazuje także, dlaczego dane efektywne należy odczytać ponownie po zmianach formatowania.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Odczytaj dane efektywne po poprzednich zmianach.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Zdefiniuj dziedziczone wartości na dwóch różnych poziomach.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Lokalna wartość w fragmencie nadpisuje obie dziedziczone wartości.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Zmiana dziedziczonej wartości nie nadpisuje istniejącej lokalnej wartości.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Wyczyść lokalną wartość. Fragment ponownie dziedziczy z akapitu.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Wyczyść wartość akapitu. Domyślne ustawienie prezentacji teraz dostarcza wynik.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Priorytet w tym przykładzie to najpierw formatowanie lokalne fragmentu, potem formatowanie akapitu, a na końcu domyślne ustawienia prezentacji. Inne obiekty mogą mieć różne łańcuchy dziedziczenia, ale zasada jest taka sama: bardziej konkretną, wyraźnie określoną wartość wygrywa, a [getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/geteffective/) zwraca ostateczny wynik.

## **Uzyskiwanie efektywnych właściwości tekstu**

Formatowanie tekstu jest podzielone na kilka obiektów:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/geteffective/) rozwiązuje właściwości ramki tekstu, takie jak marginesy, pozycjonowanie, dopasowanie automatyczne i pionowy kierunek tekstu.
- [TextStyle.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textstyle/geteffective/) rozwiązuje formatowanie akapitu dla każdego poziomu stylu tekstu.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/geteffective/) rozwiązuje właściwości akapitu, takie jak wyrównanie, wcięcie i wypunktowanie.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/geteffective/) rozwiązuje właściwości znaków, takie jak wysokość czcionki, krój, kolor, pogrubienie i kursywa.

W następnym przykładzie plik `text-formatting.pptx` musi zawierać co najmniej jeden slajd i jedną [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) z niepustą ramką tekstową. AutoShape może znajdować się w dowolnym miejscu kolekcji kształtów; kod wyszukuje odpowiedni obiekt i waliduje go przed użyciem.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Uzyskiwanie efektywnych właściwości 3D**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/geteffective/) zwraca jeden obiekt danych efektywnych, który grupuje wszystkie rozwiązane ustawienia 3D. Jego metody [getCamera](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/geteffective/) i [getBevelBottom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/geteffective/) udostępniają odpowiadające im dane efektywne. Czytanie tych powiązanych ustawień razem ułatwia zrozumienie ostatecznego wyglądu 3D kształtu.

W tym przykładzie plik `shape-3d.pptx` musi zawierać co najmniej jeden kształt na pierwszym slajdzie. Zastosuj ustawienia kamery 3D, oświetlenia lub sfazowania do tego kształtu, jeśli chcesz, aby wynik zawierał wartości inne niż domyślne.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Uzyskiwanie efektywnego formatowania tabeli**

Formatowanie tabeli może pochodzić ze stylu tabeli oraz z formatów zastosowanych do całej tabeli, kolumny, wiersza lub pojedynczej komórki. W przypadku konfliktów między jawnie określonymi wypełnieniami priorytet jest następujący: komórka, wiersz, kolumna, a następnie cała tabela. Efektywny format komórki jest ostatecznym formatem używanym do rysowania tej komórki.

W tym przykładzie plik `table-formatting.pptx` musi zawierać co najmniej jedną tabelę na pierwszym slajdzie. Tabela musi mieć przynajmniej jeden wiersz i jedną kolumnę. Kod wyszukuje [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/table/) zamiast zakładać, że `getShapes()->get_Item(0)` jest tabelą.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Jeśli potrzebujesz koloru zamiast samego typu wypełnienia, najpierw sprawdź efektywną wartość [getFillType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/geteffective/), a następnie odczytaj metodę odpowiadającą temu typowi — na przykład [getSolidFillColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/geteffective/) dla wypełnienia jednolitego.

## **Ponowne odczytanie danych efektywnych po zmianach**

Dane efektywne opisują hierarchię formatowania w momencie ich rozwiązania. Wywołaj ponownie `getEffective` po zmianie czegokolwiek, co może uczestniczyć w tej hierarchii, w tym:

- lokalnego formatowania obiektu;
- domyślnych ustawień akapitu lub ramki tekstowej;
- stylu tabeli, tabeli, kolumny, wiersza lub formatu komórki;
- formatowania układu lub slajdu-mistrza;
- danych motywu lub domyślnych ustawień prezentacji;
- układu lub mistrza przypisanego do slajdu.

Nie przechowuj obiektu danych efektywnych jako trwałego migawki. Aspose.Slides może buforować niektóre dane efektywne wewnętrznie, a późniejsze wywołanie `getEffective` może odświeżyć te dane. Jeśli potrzebujesz porównać wartości przed i po zmianie, skopiuj potrzebne wartości skalarnych (np. wysokość czcionki, kolor, wyrównanie lub szerokość sfazowania) do własnych zmiennych przed wprowadzeniem zmiany.

Aby zmienić wartość, zaktualizuj odpowiedni lokalny obiekt formatu, a następnie wywołaj `getEffective`, aby zweryfikować rezultat. Same obiekty danych efektywnych są tylko do odczytu.

## **FAQ**

**Jak mogę określić, który poziom dostarczył wartość efektywną?**

Dane efektywne zawierają ostateczną wartość, a nie jej źródło. Przeglądaj odpowiednie obiekty lokalne, zaczynając od najbardziej konkretnego poziomu i idąc na zewnątrz. Dla tekstu może to obejmować fragment, akapit, ramkę tekstową, układ, mistrza, motyw oraz domyślne ustawienia prezentacji. Niezdefiniowane wartości, takie jak `NAN` lub `null`, wskazują, że wyszukiwanie kontynuowane jest na kolejnym poziomie.

**Co się dzieje, gdy żaden poziom nie definiuje właściwości?**

Aspose.Slides rozwiązuje odpowiednie domyślne ustawienie PowerPointa lub biblioteki. Ta rozwiązana wartość pojawia się w danych efektywnych, mimo że żaden obiekt lokalny jej nie definiuje.

**Dlaczego wartość efektywna czasami jest równa wartości lokalnej?**

Wartość lokalna wygrała w obliczeniach dziedziczenia. Dzieje się tak, gdy właściwość jest wyraźnie ustawiona na obiekcie i żadne bardziej szczegółowe zasady jej nie nadpisują.

**Kiedy powinienem używać danych lokalnych zamiast danych efektywnych?**

Używaj danych lokalnych, aby sprawdzić lub edytować konkretny poziom formatowania. Używaj danych efektywnych, gdy potrzebny jest ostateczny wygląd po uwzględnieniu dziedziczenia, reguł motywu i obowiązujących stylów. [Pełny przykład porównania](#compare-local-inherited-and-effective-values) pokazuje oba podejścia w jednym przepływie pracy.