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
- Zmień kolejność kształtów
- Pobierz interopowy identyfikator kształtu
- Alternatywny tekst kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- Odbij kształt
- PowerPoint
- Prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, klonować, usuwać, ukrywać, zmieniać kolejność, eksportować, wyrównywać i odbijać kształty prezentacji przy użyciu Aspose.Slides for PHP via Java."
---
## **Przegląd**

Aspose.Slides for PHP via Java reprezentuje kształty na slajdzie jako uporządkowaną [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/). Kolekcja jest zarówno miejscem, w którym można znaleźć i modyfikować kształty, jak i źródłem ich kolejności nakładania: indeks `0` to kształt najbardziej z tyłu, a ostatni indeks to kształt najbardziej z przodu.

Ten artykuł opiera się na tym modelu. Najpierw wyjaśnia, jak niezawodnie zidentyfikować kształt, a następnie pokazuje, jak klonować, usuwać, ukrywać i zmieniać kolejność kształtów. Ostatnie sekcje obejmują formatowanie na poziomie układu, eksport do SVG, wyrównanie i ustawienia odbicia. Każdy przykład jest niezależny, więc możesz używać tylko tych operacji, które są potrzebne w Twoim przepływie pracy.

## **Identyfikowanie i znajdowanie kształtów**

Indeksy kolekcji są wygodne podczas przetwarzania znanego pliku, ale nie są stabilnymi identyfikatorami. Dodanie, usunięcie lub zmiana kolejności kształtu może zmienić jego indeks. Wybierz identyfikator zgodnie z tym, jak prezentacja jest tworzona i utrzymywana:

- [Name](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getname/) jest przydatny w szablonach kontrolowanych przez programistów i łatwy do sprawdzenia w Panelu wyboru PowerPointa. Nazwy można edytować i nie są gwarantowane jako unikalne, więc wprowadź konwencję nazewnictwa, jeśli kod od nich zależy.
- [AlternativeText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getalternativetext/) jest użyteczny, gdy opis dostępności lub tag nadany przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub przepisany pod kątem dostępności i nie jest gwarantowany jako unikalny. Nie używaj cichego przekształcania znaczącego tekstu dostępności jako klucza bazodanowego.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getofficeinteropshapeid/) jest identyfikatorem tylko do odczytu, który jest unikalny w obrębie slajdu i odpowiada identyfikatorowi kształtu używanemu przez interfejs PowerPointa. Używaj go przy integracji z PowerPointem lub gdy potrzebujesz jednoznacznego odniesienia w czasie życia kształtu. Sklonowany lub odtworzony kształt jest innym kształtem i otrzymuje własny identyfikator.

Powiązana metoda [Shape::getUniqueId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getuniqueid/) zwraca identyfikator o zakresie prezentacji, ale jest przeznaczona dla dodatków i może być ponownie przypisana. Nie należy jej traktować jako trwałego zewnętrznego klucza. Jeśli długoterminowa tożsamość jest istotna, przechowuj mapowanie w danych aplikacji i weryfikuj, czy oczekiwany kształt nadal istnieje.

Poniższy przykład wyszukuje według nazwy przy użyciu dokładnego porównania i raportuje interopowy identyfikator w zakresie slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z niewłaściwym obiektem.

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

Gdy operacja jest specyficzna dla typu kształtu, sprawdź klasę w czasie wykonywania przed użyciem członków specyficznych dla typu. Ten przykład aktualizuje tekst i tekst alternatywny tylko wtedy, gdy nazwany obiekt jest [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/).

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

## **Modyfikowanie kolekcji kształtów**

Metody dodawania, klonowania, usuwania i zmiany kolejności działają na kolekcji natychmiast. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie polegaj dalej na indeksach przechwyconych przed tą operacją.

### **Klonowanie kształtu**

[ShapeCollection::addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addclone/) tworzy niezależną kopię i dodaje ją na koniec docelowej kolekcji. [ShapeCollection::insertClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/insertclone/) również tworzy kopię, ale umieszcza ją pod określonym indeksem kolejności Z. Przeciążenia przyjmujące współrzędne przemieszcza klon bez zmiany rozmiaru; przeciążenia z szerokością i wysokością mogą go także przeskalować.

Przykład tworzy slajd docelowy, klonuje oznaczony prostokąt na przednią warstwę i wstawia drugi klon z tyłu. Zmiany w którymkolwiek klonie nie modyfikują kształtu źródłowego.

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

Klonowanie kopiuje zawartość i formatowanie kształtu, w tym jego nazwę i tekst alternatywny. Przypisz nowe logiczne identyfikatory klonowi, gdy te wartości muszą być unikalne. Zasoby używane przez złożone kształty są obsługiwane przez prezentację, ale klon pozostaje nowym elementem kolekcji z nową tożsamością kształtu.

### **Usuwanie kształtów**

[ShapeCollection::remove](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/remove/) usuwa konkretny obiekt kształtu z jego kolekcji. Podczas usuwania wielu dopasowań w trakcie iteracji po indeksach, przechodź od końca, aby każdy pozostały indeks pozostał prawidłowy.

Ten przykład usuwa każdy kształt o wyznaczonej nazwie. Czyta kształt pod aktualnym indeksem, a nie stały element kolekcji, i nie rzutuje go niepotrzebnie.

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

Po usunięciu liczba kształtów i indeksy późniejszych kształtów ulegają zmianie. Odwołania do niezmienionych kształtów pozostają bardziej wiarygodne niż zapisane indeksy. Pamiętaj także o łącznikach, animacjach i innych funkcjach prezentacji, które mogą odwoływać się do usuniętego obiektu; usunięcie widocznego kształtu może zmienić więcej niż wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Shape::setHidden](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/sethidden/) na `true` pozostawia kształt w kolekcji, ale zapobiega jego wyświetlaniu w normalnym pokazie slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne w kodzie, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą być przywrócone później.

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

Ukrywanie nie jest usuwaniem ani zabezpieczeniem. Obiekt nadal może być odnaleziony i odsłonięty przez użytkownika lub kod, i pozostaje częścią pliku prezentacji.

### **Zmiana kolejności Z**

Nakładające się kształty są rysowane w kolejności kolekcji. [ShapeCollection::reorder](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/reorder/) przemieszcza istniejący kształt do docelowego indeksu bez jego klonowania. Indeks `0` to tył; `size() - 1` to przód.

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

Prostokąt jest tworzony najpierw i początkowo znajduje się za elipsą. Przeniesienie go na ostatni indeks umieszcza go na wierzchu. Finalizuj kolejność Z po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dodają lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzoną warstwę.

## **Inspekcja kształtów na slajdach układu**

Zwykłe slajdy, slajdy układu i slajdy bazowe mają oddzielne kolekcje kształtów. Kształt w kolekcji układu nie jest tym samym obiektem co podobnie położony kształt na zwykłym slajdzie. Sprawdzaj kształty układu, gdy musisz zrozumieć lub zmienić formatowanie dostarczane przez układ.

Poniższy przykład odczytuje dla każdego kształtu układu [FillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getfillformat/) i [LineFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getlineformat/) bez zakładania, że każdy kształt jest `AutoShape`.

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

Edycja układu może wpływać na wiele slajdów, które go używają. Przed zmianą kształtu układu zdecyduj, czy zwykły slajd dziedziczy obiekt, czy zawiera lokalne nadpisanie, i przetestuj każdy slajd korzystający z tego układu.

## **Eksportowanie kształtu do SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/writeassvg/) zapisuje renderowaną zawartość jednego kształtu do strumienia. Wynik zawiera tylko kształt, a nie całe tło slajdu ani sąsiadujące kształty.

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

Utrzymuj otwartą prezentację podczas renderowania. Wyjście zależy od formatowania kształtu oraz od zasobów, takich jak czcionki i obrazy. Jeśli potrzebujesz całej kompozycji, wyeksportuj slajd zamiast pojedynczego kształtu. Wywołujący jest właścicielem strumienia i musi go zamknąć.

## **Wyrównywanie kształtów**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideutil/alignshapes/) ma przeciążenia, które wyrównują wszystkie kształty lub wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapesalignmenttype/) określa krawędź, linię środkową lub tryb dystrybucji. Ustaw `alignToSlide` na `true`, aby używać krawędzi slajdu; ustaw na `false`, aby wyrównać wybrane kształty względem siebie.

Ten przykład wyrównuje trzy kształty do górnej krawędzi slajdu. Zwrócone odniesienia do kształtów są konwertowane na ich bieżące indeksy tuż przed wyrównaniem.

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

Wyrównywanie zmienia pozycje, a nie kolejność Z. Wyrównanie względne zazwyczaj wymaga przynajmniej dwóch kształtów, podczas gdy dystrybucja pozioma lub pionowa wymaga wystarczającej liczby kształtów do określenia odstępów. Przelicz indeksy, jeśli modyfikujesz kolekcję przed wywołaniem metody.

## **Odbicie kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odbicia poziomego i pionowego oraz obrót. Jej wartości `getFlipH` i `getFlipV` używają [NullableBool](https://reference.aspose.com/slides/pl/php-java/aspose.slides/nullablebool/): `True` włącza odbicie, `False` wyłącza, a `NotDefined` zachowuje stan nieokreślony/domyślny.

Wejściowa prezentacja poniżej zawiera jeden nieodbity kształt.

![Kształt przed odbiciem](shape_to_be_flipped.png)

Przykład zachowuje wszystkie inne wartości ramki i zamienia tylko dwa ustawienia odbicia. Jest to ważne, ponieważ przypisanie nowego [Frame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/setframe/) zastępuje całą ramkę.

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

Zapisany kształt jest odbity poziomo i pionowo, zachowując jednocześnie swoją pozycję, rozmiar i obrót.

![Kształt po odbiciu](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w krótkotrwałym przetwarzaniu, gdy kolekcja nie zmieni się przed użyciem indeksu. Preferuj zweryfikowaną konwencję `Name` lub `AlternativeText` dla szablonów tworzonych przez autora lub `OfficeInteropShapeId` dla pracy z interopem w zakresie slajdu.

**Czy ukrycie kształtu usuwa go z kolejności Z?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Może być odnaleziony, przestawiony, edytowany lub ponownie widoczny.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

`addClone` dodaje klon na koniec kolekcji, co jest przodem kolejności Z. Użyj `insertClone`, aby wybrać początkowy indeks, lub `reorder` po dodaniu wszystkich kształtów.