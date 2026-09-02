---
title: Zarządzanie przewodnikami rysunkowymi w prezentacjach w PHP
linktitle: Przewodniki rysunkowe
type: docs
weight: 85
url: /pl/php-java/drawing-guides/
keywords:
- przewodnik rysunkowy
- przewodnik poziomy
- przewodnik pionowy
- przewodnik wyrównania
- widok slajdu
- slajd wzorca
- slajd układu
- wzorzec notatek
- wzorzec wersji roboczej
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dodawaj, uzyskuj dostęp i usuwaj poziome oraz pionowe przewodniki rysunkowe w prezentacjach PowerPoint przy użyciu Aspose.Slides dla PHP via Java."
---
## **Przegląd**

Przewodniki rysunkowe to regulowane poziome i pionowe linie, które pomagają użytkownikom wyrównywać kształty konsekwentnie podczas edycji prezentacji w programie PowerPoint. Są szczególnie przydatne, gdy aplikacja generuje prezentację, która później zostanie ręcznie dopracowana: aplikacja może zapisać te same pomoce wyrównania, które autorzy powinni stosować przy dodawaniu lub przemieszczaniu treści.

Przewodniki rysunkowe są pomocą przy edycji, a nie treścią slajdu. Nie pojawiają się w pokazie slajdów ani w renderowanym wyjściu. Aspose.Slides for PHP via Java udostępnia je za pośrednictwem klasy [DrawingGuidesCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/drawingguidescollection/) . Przewodnik jest reprezentowany przez [DrawingGuide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/drawingguide/) i posiada orientację, pozycję oraz kolor.

Pozycja jest mierzona w punktach od lewego górnego rogu odpowiedniego slajdu lub wzorca. Pionowy przewodnik używa współrzędnej poziomej, zazwyczaj pomiędzy zerem a szerokością slajdu. Poziomy przewodnik używa współrzędnej pionowej, zazwyczaj pomiędzy zerem a wysokością slajdu.

## **Dodawanie przewodników w widoku slajdu**

Użyj [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) aby zarządzać przewodnikami wyświetlanymi podczas edycji normalnych slajdów. Wywołaj [DrawingGuidesCollection::add](https://reference.aspose.com/slides/pl/php-java/aspose.slides/drawingguidescollection/#add) z wartością [Orientation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/orientation/) i pozycją w punktach.

Poniższy przykład dodaje jeden pionowy przewodnik po prawej stronie środka slajdu oraz jeden poziomy przewodnik pod nim:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dostęp do przewodników rysunkowych**

Metody [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/pl/php-java/aspose.slides/drawingguidescollection/#getCount) i [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/pl/php-java/aspose.slides/drawingguidescollection/#get_Item) zapewniają dostęp do istniejących przewodników. Metody [DrawingGuide::getOrientation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/pl/php-java/aspose.slides/drawingguide/#getPosition) oraz [DrawingGuide::getColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/drawingguide/#getColor) zwracają wartości, które można również zmienić przy użyciu odpowiednich metod ustawiających.

Poniższy przykład odczytuje przewodniki widoku slajdu z prezentacji utworzonej powyżej:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Dodawanie przewodników do wzorca i slajdów układu**

Wzorzec slajdu i każdy z jego slajdów układu mogą mieć własne kolekcje przewodników rysunkowych. Użyj [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/#getDrawingGuides) dla slajdu wzorca oraz [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/#getDrawingGuides) dla slajdu układu.

Poniższy przykład dodaje pionowy przewodnik do pierwszego slajdu wzorca oraz poziomy przewodnik do pierwszego slajdu układu:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dodawanie przewodników do wzorców notatek i wersji roboczych**

Wzorce notatek i wzorce wersji roboczych również obsługują przewodniki rysunkowe. Użyj [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masternotesslide/#getDrawingGuides) i [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) aby uzyskać dostęp do ich kolekcji. Jeśli prezentacja nie zawiera jednego z tych wzorców, pobierz odpowiedni menedżer przy pomocy [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) lub [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), a następnie utwórz domyślny wzorzec przy użyciu `setDefaultMasterNotesSlide` lub `setDefaultMasterHandoutSlide`.

Poniższy przykład dodaje poziomy przewodnik do wzorca notatek oraz pionowy przewodnik do wzorca wersji roboczej:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Usuwanie przewodników rysunkowych**

Wywołaj [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/drawingguidescollection/#clear) aby usunąć wszystkie przewodniki z określonej kolekcji. Czyszczenie jednej kolekcji nie wpływa na przewodniki przechowywane w innej przestrzeni.

Poniższy przykład usuwa przewodniki widoku slajdu oraz wszystkie przewodniki na wzorcach slajdów, slajdach układu, wzorcu notatek i wzorcu wersji roboczej, nie tworząc brakujących wzorców:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy przewodniki rysunkowe pojawiają się w pokazie slajdów lub wyeksportowanych obrazach?**

Nie. Przewodniki rysunkowe są pomocyami do wyrównywania podczas edycji i nie są renderowane jako treść prezentacji.

**Czy można dodać przewodnik rysunkowy bezpośrednio do pojedynczego normalnego slajdu?**

Przewodniki edycji normalnych slajdów są przechowywane w właściwościach widoku slajdu prezentacji. Oddzielne kolekcje przewodników są dostępne dla wzorców slajdów, slajdów układu, wzorców notatek i wersji roboczych.

**Jakie jednostki są używane do określania pozycji przewodników?**

Pozycje podawane są w punktach, gdzie 72 punkty to jeden cal. Pozycje pionowe mierzone są od lewej krawędzi, a pozycje poziome od górnej krawędzi.

**Czy usunięcie przewodników rysunkowych usuwa kształty lub zmienia treść slajdu?**

Nie. Metoda [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/drawingguidescollection/#clear) usuwa tylko przewodniki w wybranej kolekcji. Kształty i inne elementy slajdu pozostają niezmienione.