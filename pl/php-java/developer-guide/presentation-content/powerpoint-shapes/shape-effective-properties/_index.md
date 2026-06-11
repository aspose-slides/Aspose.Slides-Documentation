---
title: Pobierz efektywne właściwości kształtu z prezentacji w PHP
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/php-java/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- rig oświetleniowy
- kształt fazowy
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla PHP poprzez Java oblicza i stosuje efektywne właściwości kształtu, aby zapewnić precyzyjne renderowanie PowerPointa."
---
## **Przegląd**

Ten temat wyjaśnia różnicę między **lokalnymi** a **efektywnymi** właściwościami. Wartości lokalne to wartości ustawiane bezpośrednio na określonym poziomie formatowania, takie jak:

1. Właściwości fragmentu na slajdzie.
1. Style tekstu prototypu kształtu na układzie lub slajdzie głównym, gdy kształt ramki tekstowej fragmentu posiada je.
1. Globalne ustawienia tekstu w prezentacji.

Wartości lokalne mogą być zdefiniowane lub pominięte na dowolnym poziomie. Gdy Aspose.Slides potrzebuje ostatecznego formatowania „jak wyświetlone”, rozwiązuje łańcuch dziedziczenia i zwraca **efektywne** wartości. Można je uzyskać wywołując metodę `getEffective` na obiekcie lokalnego formatu.

Poniższy przykład pokazuje, jak uzyskać efektywne wartości. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) z ramką tekstową i przynajmniej jednym fragmentem.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Efektywne dane formatowania reprezentują aktualnie obliczone formatowanie po zastosowaniu dziedziczenia. W bieżącej implementacji niektóre obiekty danych efektywnych zwracane przez metody takie jak [PortionFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/geteffective/) mogą być przechowywane w pamięci podręcznej wewnętrznie. Ponowne wywołanie `getEffective` po zmianie formatowania nadrzędnego lub dziedziczonego może odświeżyć pamięć podręczną, a wcześniej uzyskany obiekt może już nie odzwierciedlać wcześniejszego stanu. Jeśli trzeba zachować efektywne wartości do późniejszego użycia, skopiuj wymagane właściwości, takie jak wysokość czcionki, kolor wypełnienia, styl czcionki lub wyrównanie, do własnego obiektu danych.
{{% /alert %}}

## **Pobieranie efektywnych właściwości kamery**

Aspose.Slides umożliwia pobranie efektywnych właściwości kamery. Efektywne dane zwracane przez [ThreeDFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/geteffective/) zawierają ostateczne właściwości kamery dla [ThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Pobieranie efektywnych właściwości rigu oświetleniowego**

Aspose.Slides umożliwia pobranie efektywnych właściwości rigu oświetleniowego. Efektywne dane zwracane przez [ThreeDFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/geteffective/) zawierają ostateczne właściwości rigu oświetleniowego dla [ThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Pobieranie efektywnych właściwości kształtu z fazą (bevel)**

Aspose.Slides umożliwia pobranie efektywnych właściwości fazy kształtu. Efektywne dane zwracane przez [ThreeDFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/geteffective/) zawierają ostateczne właściwości reliefu powierzchni dla [ThreeDFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/threedformat/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Pobieranie efektywnych właściwości ramki tekstowej**

Korzystając z Aspose.Slides, możesz uzyskać efektywne właściwości ramki tekstowej. Efektywne dane zwracane przez [TextFrameFormat.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/geteffective/) zawierają właściwości formatowania ramki tekstowej.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Pobieranie efektywnych właściwości stylu tekstu**

Korzystając z Aspose.Slides, możesz uzyskać efektywne właściwości stylu tekstu. Efektywne dane zwracane przez [TextStyle.getEffective](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textstyle/geteffective/) zawierają właściwości stylu tekstu.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Pobieranie efektywnej wartości wysokości czcionki**

Korzystając z Aspose.Slides, możesz pobrać efektywną wysokość czcionki. Poniższy kod demonstruje, jak efektywna wysokość czcionki fragmentu zmienia się po ustawieniu lokalnych wartości wysokości czcionki na różnych poziomach struktury prezentacji.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Pobieranie efektywnego formatu wypełnienia dla tabeli**

Korzystając z Aspose.Slides, możesz uzyskać efektywne formatowanie wypełnienia dla różnych części tabeli. Efektywne dane zwracane przez obiekty formatu zawierają właściwości [FillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/). Formatowanie komórki ma wyższy priorytet niż formatowanie wiersza, formatowanie wiersza ma wyższy priorytet niż formatowanie kolumny, a formatowanie kolumny ma wyższy priorytet niż formatowanie całej tabeli.

W rezultacie, efektywne właściwości [CellFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellformat/) są używane do renderowania komórek tabeli. Poniższy kod pokazuje, jak pobrać efektywne formatowanie wypełnienia dla różnych części tabeli. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/table/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy `getEffective` zwraca migawkę?**

Nie zawsze. Efektywne dane reprezentują obliczone formatowanie po zastosowaniu dziedziczenia, ale niektóre obiekty danych efektywnych mogą być przechowywane w pamięci podręcznej wewnętrznie. Kolejne wywołanie `getEffective` może przeliczyć formatowanie i odświeżyć pamięć podręczną, więc wcześniej uzyskany obiekt nie powinien być traktowany jako trwała migawka.

**Kiedy powinienem ponownie odczytać efektywne właściwości?**

Wywołaj ponownie `getEffective` po zmianie formatowania lokalnego, stylów nadrzędnych, formatowania układu, formatowania szablonu głównego lub domyślnych ustawień na poziomie prezentacji. Następne wywołanie ponownie oceni hierarchię formatowania i zwróci aktualny wynik efektywny.

**Czy zmiana lub usunięcie układu/slajdu głównego wpływa na już pobrane efektywne właściwości?**

Tak, ale zmiana zostanie odzwierciedlona przy następnym wywołaniu `getEffective`. Jeśli źródło formatowania nadrzędnego zostanie zmienione lub usunięte, wcześniej uzyskane dane efektywne mogą stać się nieaktualne. Po ponownym wywołaniu `getEffective` Aspose.Slides przeliczy drzewo formatowania i wynikające czcionki, kolory, rozmiary lub inne wartości mogą ulec zmianie.

**Czy mogę modyfikować wartości poprzez obiekty danych efektywnych?**

Nie. Obiekty danych efektywnych udostępniają wyliczone wartości. Wprowadzaj zmiany w lokalnych obiektach formatowania, a następnie ponownie pobieraj efektywne wartości.

**Co się stanie, jeśli właściwość nie jest ustawiona na poziomie kształtu, układu/mastera ani w ustawieniach globalnych?**

Wartość efektywna jest określana przez mechanizm domyślny, który obejmuje domyślne ustawienia PowerPointa i Aspose.Slides. Rozwiązana wartość staje się częścią bieżących danych efektywnych.

**Na podstawie efektywnej wartości czcionki, czy mogę określić, który poziom dostarczył rozmiar lub krój?**

Nie bezpośrednio. Efektywne dane zwracają ostateczną wartość. Aby znaleźć źródło, sprawdź lokalne wartości na poziomie fragmentu, akapitu, ramki tekstowej i stylów tekstu w układzie, masterze i prezentacji, aby zobaczyć, gdzie pojawia się pierwsza jawna definicja.

**Dlaczego efektywne wartości czasami wyglądają identycznie jak lokalne?**

Ponieważ wartość lokalna okazała się ostateczna (nie było konieczne dziedziczenie z wyższego poziomu). W takich przypadkach wartość efektywna jest taka sama jak lokalna.

**Kiedy powinienem używać efektywnych właściwości, a kiedy pracować tylko z lokalnymi?**

Używaj danych efektywnych, gdy potrzebujesz wyniku „jak wyświetlone” po zastosowaniu całego dziedziczenia, np. do wyrównania kolorów, wcięć lub rozmiarów. Jeśli musisz zachować te wartości niezależnie od późniejszych zmian formatowania, skopiuj wymagane właściwości do własnego obiektu. Jeśli chcesz zmienić formatowanie na określonym poziomie, modyfikuj właściwości lokalne, a potem, w razie potrzeby, odczytaj ponownie dane efektywne, aby zweryfikować rezultat.