---
title: Zarządzanie kształtami prezentacji w PHP
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/php-java/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- Kształt na slajdzie
- Znajdź kształt
- Klonuj kształt
- Usuń kształt
- Ukryj kształt
- Zmień kolejność kształtu
- Pobierz ID kształtu interop
- Alternatywny tekst kształtu
- Punkt regulacji kształtu
- Regulacja kształtu predefiniowanego
- Geometria kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- Odbij kształt
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, regulować, klonować, usuwać, ukrywać, zmieniać kolejność, eksportować, wyrównywać i odbijać kształty prezentacji za pomocą Aspose.Slides dla PHP poprzez Java."
---
## **Przegląd**

Aspose.Slides for PHP via Java reprezentuje kształty na slajdzie jako uporządkowaną [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/). Kolekcja jest jednocześnie miejscem, w którym znajdujesz i modyfikujesz kształty oraz źródłem ich kolejności nakładania: indeks `0` to najdalej w tle kształt, a ostatni indeks to kształt najbardziej na wierzchu.

Ten artykuł opiera się na tym modelu. Najpierw wyjaśnia, jak wiarygodnie zidentyfikować kształt i zmodyfikować wstępnie ustawione punkty regulacji, a potem pokazuje, jak klonować, usuwać, ukrywać i zmieniać kolejność kształtów. Ostatnie sekcje obejmują formatowanie na poziomie układu, eksport SVG, wyrównywanie i ustawienia odbicia. Każdy przykład jest niezależny, więc możesz używać tylko operacji wymaganych w Twoim przepływie pracy.

## **Identyfikacja i znajdowanie kształtów**

Indeksy kolekcji są wygodne podczas przetwarzania znanego pliku, ale nie są stabilnymi identyfikatorami. Dodanie, usunięcie lub zmiana kolejności kształtu może zmienić jego indeks. Wybierz identyfikator zgodnie z tym, jak prezentacja jest tworzona i utrzymywana:

- [Name](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getname/) jest przydatny w szablonach kontrolowanych przez dewelopera i łatwy do sprawdzenia w panelu wyboru PowerPointa. Nazwy można edytować i nie są gwarantowane jako unikalne, więc wprowadź konwencję nazewnictwa, jeśli kod od nich zależy.
- [AlternativeText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getalternativetext/) jest przydatny, gdy opis dostępności lub znak dostarczony przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub przepisywany pod kątem dostępności i nie jest gwarantowany jako unikalny. Nie używaj cichego przekształcania znaczącego tekstu dostępności jako klucza bazy danych.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getofficeinteropshapeid/) jest identyfikatorem tylko do odczytu, unikalnym w obrębie slajdu i odpowiadającemu identyfikatorowi kształtu używanemu przez interop PowerPointa. Używaj go przy integracji z PowerPointem lub gdy potrzebujesz jednoznacznego odniesienia w czasie życia kształtu. Sklonowany lub odtworzony kształt jest innym kształtem i otrzymuje własny identyfikator.

Powiązana metoda [Shape::getUniqueId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getuniqueid/) zwraca identyfikator o zakresie prezentacji, ale jest przeznaczona dla dodatków i może być ponownie przypisana. Nie należy jej traktować jako stałego klucza zewnętrznego. Jeśli trwała tożsamość jest kluczowa, przechowuj mapowanie w danych aplikacji i weryfikuj, że oczekiwany kształt nadal istnieje.

Poniższy przykład wyszukuje po nazwie przy użyciu dokładnego porównania i zgłasza interopowy identyfikator w zakresie slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z niewłaściwym obiektem.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Gdy operacja jest specyficzna dla typu kształtu, sprawdź klasę w czasie wykonywania przed użyciem członków specyficznych dla typu. Ten przykład aktualizuje tekst i alternatywny tekst tylko wtedy, gdy nazwany obiekt jest [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Identyfikacja i modyfikacja wstępnie ustawionych regulacji kształtu**

Kształty o predefiniowanej geometrii mogą udostępniać punkty regulacji, które kontrolują takie cechy jak rozmiar narożników, proporcje strzałek lub kąty łuków. Dostęp do nich uzyskuje się przez kolekcję tylko do odczytu [GeometryShape::getAdjustments](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometryshape/#getAdjustments). Sama kolekcja jest dostarczana przez kształt, ale każdy [AdjustValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/adjustvalue/) zawiera wartość, którą można zmienić.

Nie polegaj wyłącznie na stałym indeksie kolekcji. Przeglądaj regulacje i sprawdzaj metodę tylko do odczytu [AdjustValue::getType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/adjustvalue/#getType), której wartość [ShapeAdjustmentType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapeadjustmenttype/) opisuje, co dana regulacja kontroluje. Metoda tylko do odczytu [AdjustValue::getName](https://reference.aspose.com/slides/pl/php-java/aspose.slides/adjustvalue/getname/) dostarcza dodatkowych informacji identyfikacyjnych i jest szczególnie przydatna, gdy predefinicja zawiera więcej niż jedną regulację tego samego typu semantycznego.

Użyj metody wartości odpowiadającej znaczeniu regulacji:

| Typ regulacji | Cel | Wartość do zmiany |
|---|---|---|
| `CornerSize` | Rozmiar zaokrąglonych narożników | [setRawValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Grubość ogona strzałki | `setRawValue` |
| `ArrowheadLength` | Długość grotu strzałki | `setRawValue` |
| `ArrowheadWidth` | Szerokość grotu strzałki | `setRawValue` |
| `StartAngle` | Kąt początkowy wycinka lub łuku | [setAngleValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Kąt końcowy wycinka lub łuku | `setAngleValue` |

`getType` i `getName` zwracają informacje tylko do odczytu. `getRawValue` i `setRawValue` pracują z liczbą całkowitą w natywnych jednostkach geometrii predefinicji, natomiast `getAngleValue` i `setAngleValue` pracują z kątem w stopniach. Liczba, kolejność, znaczenie i dopuszczalny zakres regulacji zależą od predefinicji [GeometryShape::getShapeType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometryshape/#getShapeType). Wartość ważna dla jednej predefinicji może być nieprawidłowa lub mieć inny efekt dla innej.

Gdy `getType` zwraca `ShapeAdjustmentType::Custom`, API nie rozpoznaje standardowego znaczenia semantycznego. Sprawdź `getName`, typ predefinicji oraz istniejącą wartość i pozostaw regulację niezmienioną, chyba że znane są oczekiwane znaczenie i zakres. Nawet dla rozpoznanych typów, sprawdź, czy ten sam typ występuje więcej niż raz, zanim wybierzesz wartość. Artykuł [Connector](/slides/pl/php-java/connector/) pokazuje tę sytuację w kontekście regulacji zgięcia łącznika.

Poniższy kompletny przykład tworzy domyślne i zmodyfikowane wersje trzech predefiniowanych kształtów. Przegląda każdą regulację, zgłasza jej nazwę i typ, zmienia wartości związane z rozmiarem za pomocą `setRawValue`, zmienia kąty za pomocą `setAngleValue` i zapisuje wynik. Lewa kolumna zachowuje domyślną geometrię; prawa kolumna pokazuje dostosowany prostokąt zaokrąglony, czterokierunkową strzałkę i wycinek.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Dodaj nagłówki dla kolumn kształtów domyślnych i zmodyfikowanych.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sprawdzanie typu semantycznego przed zmianą wartości sprawia, że kod jest jednoznaczny co do intencji i unika założenia, że dany indeks kolekcji ma to samo znaczenie w różnych predefiniowanych kształtach.

## **Modyfikacja kolekcji kształtów**

Metody dodawania, klonowania, usuwania i zmiany kolejności działają natychmiast na kolekcji. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie polegaj dalej na indeksach pobranych przed tą operacją.

### **Klonowanie kształtu**

[ShapeCollection::addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addclone/) tworzy niezależną kopię i dołącza ją do docelowej kolekcji. [ShapeCollection::insertClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/insertclone/) także tworzy kopię, ale umieszcza ją pod określonym indeksem z‑order. Przeciążenia przyjmujące współrzędne przenoszą klon bez zmiany jego rozmiaru; przeciążenia z szerokością i wysokością mogą również zmienić rozmiar.

Przykład tworzy slajd docelowy, klonuje opisany prostokąt na wierzch i wstawia drugi klon na tył. Zmiany w jednym klonie nie modyfikują kształtu źródłowego.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Klonowanie kopiuje zawartość i formatowanie kształtu, w tym jego nazwę i tekst alternatywny. Przypisz nowe logiczne identyfikatory klonowi, gdy te wartości muszą być unikalne. Zasoby używane przez złożone kształty są zarządzane przez prezentację, ale klon pozostaje nowym elementem kolekcji z nową tożsamością kształtu.

### **Usuwanie kształtów**

[ShapeCollection::remove](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/remove/) usuwa określony obiekt kształtu z jego kolekcji. Podczas usuwania wielu dopasowań w trakcie iteracji po indeksach, przeglądaj od końca, aby każdy pozostały indeks pozostał ważny.

Ten przykład usuwa każdy kształt o określonej nazwie. Odczytuje kształt pod bieżącym indeksem, nie stały element kolekcji, i nie wykonuje niepotrzebnego rzutowania.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Po usunięciu liczba kształtów i indeksy kolejnych kształtów się zmieniają. Odwołania do niezmienionych kształtów pozostają bardziej niezawodne niż zapisane indeksy. Pamiętaj także o łącznikach, animacjach i innych elementach prezentacji, które mogą odwoływać się do usuniętego obiektu; usunięcie widocznego kształtu może zmienić więcej niż wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Shape::setHidden](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/sethidden/) na `true` pozostawia kształt w kolekcji, ale zapobiega jego wyświetleniu w normalnym pokazie slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne dla kodu, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą zostać przywrócone później.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ukrycie nie jest usunięciem ani zabezpieczeniem. Obiekt nadal może być odnaleziony i odkryty przez użytkownika lub kod, i pozostaje częścią pliku prezentacji.

### **Zmiana Z‑Order**

Nakładające się kształty są rysowane w kolejności kolekcji. [ShapeCollection::reorder](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/reorder/) przenosi istniejący kształt do docelowego indeksu bez klonowania. Indeks `0` to tył; `size() - 1` to przód.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Prostokąt jest tworzony jako pierwszy i początkowo znajduje się za elipsą. Przeniesienie go do ostatniego indeksu powoduje, że jest na wierzchu. Ustal ostateczny Z‑Order po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dopisują lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzoną kolejkę.

## **Inspekcja kształtów na slajdach układu**

Normalne slajdy, slajdy układu i slajdy nadrzędne mają oddzielne kolekcje kształtów. Kształt w kolekcji układu nie jest tym samym obiektem co podobnie pozycjonowany kształt na normalnym slajdzie. Sprawdzaj kształty układu, gdy musisz zrozumieć lub zmienić formatowanie dostarczane przez układ.

Poniższy przykład odczytuje [FillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getfillformat/) i [LineFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getlineformat/) każdego kształtu układu, nie zakładając, że każdy kształt jest `AutoShape`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Edycja układu może wpływać na wiele slajdów, które go używają. Przed zmianą kształtu układu określ, czy normalny slajd dziedziczy obiekt czy zawiera lokalne nadpisanie, i przetestuj każdy slajd używający tego układu.

## **Eksport kształtu do SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/writeassvg/) zapisuje renderowaną zawartość jednego kształtu do strumienia. Wynik zawiera tylko kształt, a nie tło całego slajdu ani sąsiadujące kształty.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Trzymaj prezentację otwartą podczas renderowania. Wyjście zależy od formatowania kształtu oraz od zasobów takich jak czcionki i obrazy. Jeśli potrzebujesz całej kompozycji, wyeksportuj slajd zamiast pojedynczego kształtu. Wywołujący własność strumienia musi go zamknąć.

## **Wyrównywanie kształtów**

Przeciążenia [SlideUtil::alignShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideutil/alignshapes/) wyrównują wszystkie kształty lub wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapesalignmenttype/) określa krawędź, linię środkową lub tryb dystrybucji. Ustaw `alignToSlide` na `true`, aby używać krawędzi slajdu; ustaw na `false`, aby wyrównywać wybrane kształty względem siebie.

Ten przykład wyrównuje trzy kształty do górnej krawędzi slajdu. Zwrócone referencje kształtów są przeliczane na ich bieżące indeksy bezpośrednio przed wyrównaniem.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wyrównanie zmienia pozycje, a nie Z‑Order. Wyrównanie względne zazwyczaj wymaga przynajmniej dwóch kształtów, podczas gdy dystrybucja pozioma lub pionowa wymaga wystarczającej liczby kształtów do określenia odstępów. Przelicz indeksy, jeśli modyfikujesz kolekcję przed wywołaniem metody.

## **Odbicie kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odbicia poziomego i pionowego oraz obrót. Jej wartości `getFlipH` i `getFlipV` używają [NullableBool](https://reference.aspose.com/slides/pl/php-java/aspose.slides/nullablebool/): `True` włącza odbicie, `False` wyłącza, a `NotDefined` zachowuje nieokreślony/ domyślny stan.

Poniższa prezentacja wejściowa zawiera jeden nieodbijany kształt.

![The shape before flipping](shape_to_be_flipped.png)

Przykład zachowuje wszystkie inne wartości ramki i zamienia jedynie dwa ustawienia odbicia. Jest to ważne, ponieważ przypisanie nowego [Frame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/setframe/) zastępuje całą ramkę.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Zapisany kształt jest odbity poziomo i pionowo, zachowując jednocześnie pozycję, rozmiar i obrót.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w krótkotrwałym przetwarzaniu, gdy kolekcja nie zmieni się przed użyciem indeksu. Preferuj zweryfikowaną konwencję `Name` lub `AlternativeText` dla szablonów tworzonych ręcznie, lub `OfficeInteropShapeId` dla prac w zakresie interopu slajdu.

**Czy ukrycie kształtu usuwa go z Z‑Order?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Można go znaleźć, zmienić kolejność, edytować lub ponownie uczynić widocznym.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

`addClone` dołącza klon na koniec kolekcji, co jest przodem Z‑Order. Użyj `insertClone`, aby wybrać początkowy indeks, lub `reorder` po dodaniu wszystkich kształtów.

**Czy mogę używać stałego indeksu do identyfikacji regulacji predefiniowanego kształtu?**

Tylko po zweryfikowaniu dokładnej predefinicji i układu kolekcji. Preferuj iterację przez `GeometryShape::getAdjustments` i sprawdzanie `AdjustValue::getType`; używaj `AdjustValue::getName` jako dodatkowej informacji, gdy ten sam typ semantyczny pojawia się więcej niż raz.