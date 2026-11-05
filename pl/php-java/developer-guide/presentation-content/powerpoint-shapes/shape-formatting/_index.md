---
title: Formatuj kształty PowerPoint w PHP
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/php-java/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicu
- linia kształtu szkicu
- formatowanie stylu połączenia
- wypełnienie gradientem
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie kolorem stałym
- przezroczystość kształtu
- renderowanie kształtu czarno-białe
- renderowanie kształtu w odcieniach szarości
- obrót kształtu
- efekt 3D bevel
- efekt rotacji 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w PHP przy użyciu Aspose.Slides - ustawiaj style wypełnienia, linii i efektów dla plików PPT i PPTX z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

Formatuj kształty w programie PowerPoint, dostosowując ich kontury, wypełnienia i efekty. Aspose.Slides for PHP via Java pozwala sterować tymi ustawieniami programowo, w tym przezroczystością, rotacją i formatowaniem 3D.

![Opcje formatowania kształtów w programie PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java udostępnia klasy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatuj linie**

Użyj [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) aby kontrolować kontur kształtu. Ten przykład tworzy nie wypełniony prostokąt z niebieskim, przerywanym konturem. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) wybiera linię złożoną gruba-cienka, natomiast [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) ustawia jej szerokość na 7 punktów, a [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) wybiera wzór kreskowania.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

### **Ustaw niestandardowe wzory kreskowania linii**

Użyj [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern), gdy predefiniowane style linii nie zapewniają potrzebnych długości kresek i przerw, na przykład dla brandowanych konturów lub diagramów technicznych. Przypisanie wzoru automatycznie zmienia styl kreskowania linii na [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

Elementy tablicy naprzemiennie określają długości kresek i przerw, zaczynając od kreski. Każda wartość jest wielokrotnością szerokości linii: `[4, 2]` przy szerokości 3 punktów daje kreskę o długości 12 punktów, a następnie przerwę 6 punktów. Używaj par skończonych, nieujemnych wartości, aby definiować pełne segmenty kreska-przerwa. Przykład używa dodatnich wartości, aby każda kreska i przerwa były widoczne.

Ten przykład tworzy pięć niebieskich linii o tej samej długości i płaskich zakończeniach. Pierwsze trzy porównują wzory przy szerokości 3 punktów. Czwarta powtarza pierwszy wzór przy dwukrotnej szerokości, podwajając zarówno długość kresek, jak i przerw. Piąta przełącza się z niestandardowego wzoru na linię ciągłą.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // Przywróć ostatnią linię do stylu ciągłego.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aby zamiast tego powrócić do predefiniowanego stylu kreskowanego, przekaż [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) do [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). Wybrany styl kontroluje wygląd linii.

Wynik w programie PowerPoint, od góry do dołu: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; oraz **Solid, 3 pt**.

![Trzy niestandardowe wzory kreskowania, szersza linia używająca pierwszego wzoru oraz linia ciągła w programie PowerPoint](custom-dash-patterns.png)

### **Ustaw zakończenia linii**

Użyj [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle), aby ustawić końce otwartej linii. Klasa [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) udostępnia trzy wyraźne style zakończeń:

- `Flat`: Pędzel zatrzymuje się na końcowym punkcie.
- `Round`: Półokrągłe zakończenie wykracza poza końcowy punkt o połowę szerokości linii.
- `Square`: Kwadratowe zakończenie wykracza poza końcowy punkt o połowę szerokości linii.

Klasa zawiera również `NotDefined`, co oznacza, że żaden styl zakończenia nie jest wyraźnie przypisany.

Zakończenia różnią się od grotów strzałek, które dodają symbole na końcach linii, oraz połączeń, które kontrolują narożniki między segmentami linii. Ten przykład wyłącza groty strzałek przy użyciu [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) i [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle), aby porównać jedynie kształty zakończeń.

Poniższy przykład tworzy trzy w przeciwnym razie identyczne poziome linie o szerokości 20 punktów. Od góry do dołu używają one odpowiednio płaskich, okrągłych i kwadratowych zakończeń. Ich końcowe punkty mają te same współrzędne poziome; okrągłe i kwadratowe zakończenia wykraczają 10 punktów poza każdy koniec.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik w PowerPoint, od góry do dołu: **Flat**, **Round** i **Square**.

![Płaskie, okrągłe i kwadratowe zakończenia na identycznych grubych liniach w programie PowerPoint](line-caps.png)

## **Zastosuj efekty szkicu do linii kształtu**

Efekt szkicu sprawia, że linia kształtu wygląda na odręcznie narysowaną. Użyj [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat), aby uzyskać dostęp do ustawień linii, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat), aby uzyskać dostęp do ustawień szkicu, oraz [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType), aby wybrać wartość z klasy [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Poniższy kod PHP pokazuje, jak zastosować efekt [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) , odczytać wyraźnie przypisaną wartość i usunąć efekt za pomocą [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Wartość zwrócona przez [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu głównego lub slajdu układu, użyj [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective), uzyskaj metodę `getSketchFormat` zwróconego obiektu i odczytaj jej wartość `getSketchType`. Wartość efektywna odzwierciedla formatowanie faktycznie zastosowane po rozwiązaniu dziedziczenia. Ten przykład wymaga istniejącej prezentacji z co najmniej jednym kształtem na pierwszym slajdzie i wypisuje obie wartości:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $lineFormat = $shape->getLineFormat();
    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Formatuj style połączeń**

Oto trzy dostępne opcje typu połączenia:
* Zaokrąglony
* Kątowy
* Ścięty

Styl połączenia określa, w jaki sposób dwa segmenty konturu łączą się w narożniku. Użyj **Round** dla zaokrąglonych narożników, **Miter** dla ostrych narożników lub **Bevel** dla spłaszczonych narożników.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Ten przykład tworzy trzy czarne prostokąty z niebieskimi konturami o szerokości 15 punktów. Ustawia [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) odpowiednio na wartości miter, bevel i round klasy [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/), aby porównać, jak rysowane są narożniki.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ogranicz łączenia kątowe przy ostrych narożnikach**

Użyj [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) w połączeniu z [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) ustawionym na [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/), aby ograniczyć, jak daleko może rozciągać się ostry narożnik.

Limit jest stosunkiem odległości między wewnętrznym a zewnętrznym narożnikiem połączenia do szerokości linii. Na przykład wartość `8` pozwala na długość kątowego połączenia do ośmiokrotności szerokości linii; nie jest to miara w punktach. Jeśli narożnik miałby przekroczyć limit, PowerPoint używa połączenia ściętego w tym miejscu. Większy limit pozwala na ostrzejsze punkty. Ustawienie wpływa wyłącznie na połączenia kątowe i zmiana nie ma widocznego efektu, gdy narożnik pozostaje w obu limitach.

Przykład tworzy dwa identyczne, nie wypełnione trójkąty z konturami o szerokości 20 punktów. Lewy trójkąt używa limitu `2`, a prawy `8`. Każdy trójkąt ma szerokość 80 punktów i wysokość 160 punktów, co daje stosunek długości kątowego połączenia do szerokości linii w górnym narożniku około `4,12`. W konsekwencji PowerPoint ścięła lewy wierzchołek i zachowała prawy.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik w PowerPoint: **Miter limit 2** po lewej i **miter limit 8** po prawej.

![Ścięty wierzchołek z limitem miter 2 i ostry wierzchołek z limitem miter 8 w programie PowerPoint](miter-limits.png)

## **Wypełnienie gradientem**

Wypełnienie gradientem miesza kolory w obrębie kształtu. Ten przykład wypełnia elipsę gradientem liniowym pod kątem 45 stopni od czerwonego do fioletowego, używając [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). Metoda [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) umieszcza przystanki kolorów na pozycjach 0 i 1, czyli na początku i końcu gradientu. Usunięcie istniejących przystanków zapewnia, że używane będą tylko te dwie kolory.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

Jeśli gradient wygląda inaczej w wyeksportowanym obrazie niż w programie PowerPoint, zobacz [Choose a Gradient Rendering Style](/slides/pl/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Możesz wybrać styl renderowania bez zmiany wypełnienia gradientowego zapisanego w prezentacji.

### **Ustaw kąt gradientu liniowego**

Użyj [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle), aby kontrolować orientację wypełnienia [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/). Kąt jest mierzony w stopniach i rośnie zgodnie z ruchem wskazówek zegara: `0` przebiega od lewej do prawej, `90` od góry do dołu, `180` od prawej do lewej, a `270` od dołu do góry. Obsługiwane są kąty ułamkowe. Kąty skończone poza zakresem `[0, 360)` są normalizowane do jednej pełnej rotacji; na przykład `-45` staje się `315`, a `360` staje się `0`.

Ten przykład tworzy sześć prostokątów z identycznymi przystankami czerwonego, zielonego i niebieskiego na pozycjach `0`, `0.5` i `1`. Skalowanie jest wyłączone, aby kąty można było porównać niezależnie od proporcji prostokątów. Kąty, od lewej do prawej, to `0`, `45` i `90` w pierwszym wierszu oraz `135`, `180` i `270` w drugim wierszu.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik w PowerPoint:

![Gradienty liniowe pod kątem 0°, 45° i 90° w górnym wierszu oraz 135°, 180° i 270° w dolnym wierszu](linear-gradient-angles.png)

### **Skaluj gradient liniowy wraz z kształtem**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) przyjmuje wartość typu [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/). Ustaw ją explicite na `False`, aby zachować geometryczny kąt gradientu przy zmianie proporcji kształtu, lub na `True`, aby skalować gradient razem z szerokością i wysokością kształtu. Przy włączonej skali widoczny kąt może różnić się od przypisanego kąta w przypadku kształtu niebędącego kwadratem.

Poniższy przykład używa kąta `45` stopni i tych samych przystanków kolorowych co w porównaniu kątów. Lewa kolumna używa `False`; prawa kolumna używa `True`. Każda kolumna zawiera szeroki prostokąt nad wysokim prostokątem. Obie zaczynają od tych samych szerokich wymiarów; zmiana szerokości i wysokości drugiego prostokąta pokazuje, jak wypełnienie reaguje na zmianę rozmiaru bez zmiany ustawień gradientu.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik w PowerPoint, przy wyłączonej skali po lewej i włączonej po prawej:

![Szerokie i wysokie prostokąty z gradientem 45°, porównujące LinearGradientScaled False po lewej i True po prawej](linear-gradient-scaling.png)

Przy wyłączonej skali, ukośne pasma kolorów zachowują tę samą orientację w obu prostokątach. Przy włączonej skali, pasma rozciągają się wraz z proporcjami kształtu. Pomaga to odtworzyć gradient szablonu przy dopasowywaniu kształtu do innego rozmiaru. W przypadku kwadratu, włączenie skali nie zmienia wyglądu tego gradientu pod kątem `45` stopni.

Zarówno ustawienie kąta, jak i skali mają zastosowanie do gradientów liniowych. Nie kontrolują one wypełnień [GradientShape::Radial or GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/).

### **Połącz kąt z kierunkiem gradientu**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) wybiera styl gradientu z klasy [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/). Nie jest to zamiennik dla kąta liczbowego. Dla gradientu liniowego style narożników mogą zmieniać obszar, w którym rozprowadzane są kolory, bez zmiany kąta przypisanego za pomocą [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle). Zachowaj niezmieniony kierunek przy porównywaniu kątów lub skali.

Poniższy przykład stosuje te same ustawienia w odwrotnej kolejności. Dwa prostokąty wyglądają identycznie: przypisanie kierunku przed lub po kącie nie zmienia wyniku.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Wypełnienie wzorem**

Wypełnienie wzorem nakłada dwukolorowy wzór, taki jak kropki, pasy lub kratkę. Ten przykład używa [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle), aby wybrać wzór kratki. [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) dostarcza jasno szare tło, a [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) dostarcza żółty kolor wzoru.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

Wypełnienie obrazem używa obrazu wewnątrz kształtu. Ten przykład wymaga lokalnego obrazu i używa [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile), aby załadować go do kolekcji obrazów prezentacji. Ustawienie [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) na tryb kafelkowy powtarza obraz w obrębie prostokąta. Poniżej pokazano użyty obraz źródłowy:

![Obraz lotosu](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Użyj obrazu jako tekstury kafelkowej**

Jeśli chcesz ustawić obraz w trybie kafelkowym jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod klasy [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Ustawia tryb wypełnienia obrazu — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Określa wyrównanie kafelków wewnątrz kształtu.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Steruje, czy kafelek jest odbity w poziomie, w pionie, czy w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definiuje pionową skalę kafelka jako procent.

Ten przykład wymaga lokalnego obrazu i konfiguruje [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) aby powtórzyć go w 50% oryginalnego rozmiaru. Offsety −32 punktów przesuwają kafelki poziomo i pionowo; wyrównanie w prawym dolnym rogu oraz odbicie w obu kierunkach określają, jak powtarzana tekstura jest rozmieszczona.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie kolorem stałym**

Wypełnienie kolorem stałym nadaje kształtowi jednolity, jednolity kolor. Ten przykład ustawia [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) na tryb wypełnienia stałego i przypisuje żółty kolor za pomocą [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), a następnie zapisuje prostokąt w prezentacji.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Kształt z wypełnieniem kolorem stałym](solid-color-fill.png)

### **Kopiuj kolory zachowując odniesienia do motywu**

Użyj [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom), aby skopiować definicję koloru, w tym jego typ, odniesienie do motywu i transformacje. Jest to przydatne przy przenoszeniu koloru wypełnienia między kształtami, które mają nadal podążać za motywem prezentacji. Metoda kopiuje tylko kolor: nie kopiuje typu wypełnienia, konturu ani innych formatowań kształtu. Ustaw typ wypełnienia celu wyraźnie za pomocą [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType).

Ten przykład tworzy trzy prostokąty, od lewej do prawej: źródłowy, kopiowany z zachowaniem motywu oraz kopiowany z ustalonym RGB. Źródło używa [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor), aby odwołać się do pierwszego koloru akcentu i dodaje tonację za pomocą [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add). Kopia RGB używa efektywnego koloru wypełnienia źródła, więc wszystkie trzy początkowo wyglądają identycznie. Wywołanie [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor), ustawia stałą wartość RGB i usuwa istniejące transformacje koloru.

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // Odwołania do motywu podążają za nowym kolorem akcentu; stała wartość RGB tego nie robi.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Przed zmianą motywu wszystkie trzy wypełnienia są identyczne:

![Źródło, docelowy copyFrom i stały docelowy RGB z identycznym niebieskim wypełnieniem](color-copy-before.png)

Po zmianie motywu źródło i kopia z zachowaniem motywu podążają za nowym kolorem akcentu i zachowują swoją tonację. Kopia RGB pozostaje niebieska:

![Źródło i docelowy copyFrom z pomarańczowymi wypełnieniami, podczas gdy stały docelowy RGB pozostaje niebieski](color-copy-after.png)

Skopiowana definicja jest niezależna od źródła. Kolejna zmiana odniesienia do motywu w źródle, przypisanie innego koloru lub dodanie/usunięcie jego transformacji nie zmienia celu. Zmiana motywu nadal wpływa na oba kształty, ponieważ każdy niezależnie odwołuje się do tego samego koloru motywu.

Zapis i ponowne otwarcie pliku PPTX zachowuje typ skopiowanego koloru zwracany przez [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType), odniesienie do motywu oraz kolekcję transformacji zwracanych przez [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform); nie spłaszcza definicji do RGB.

Podczas kopiowania pomiędzy różnymi kontekstami motywu, takimi jak prezentacje z różnymi paletami akcentów, skopiowane odniesienie jest rozwiązywane względem motywu docelowego. To samo odniesienie i transformacje mogą więc dawać inny widoczny kolor. Zobacz [Presentation Theme](/slides/pl/php-java/presentation-theme/) po więcej informacji o konfigurowaniu kolorów motywu.

## **Użyj tła slajdu jako wypełnienia kształtu**

Użyj [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill), gdy kształt ma pasować do tła slajdu, na przykład w szablonie prezentacji. Najpierw ustaw typ wypełnienia za pomocą [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) na [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) , aby usunąć wszelkie wyraźne wypełnienie. W takiej kombinacji kształt używa tła slajdu zamiast swojego wypełnienia stylu. Włączenie samej flagi nie usuwa istniejącego wyraźnego wypełnienia.

Różni się to od [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/): wypełnienie tłem pokrywa obiekty znajdujące się za kształtem odpowiednim obszarem tła slajdu, podczas gdy brak wypełnienia pozostawia te obiekty widoczne. Gradient pozostaje wyrównany do slajdu, a nie rozpoczyna się wewnątrz każdego kształtu.

Poniższy przykład tworzy tło główne dziedziczone przez slajd i umieszcza magentowy pasek za trzema prostokątami. Lewy prostokąt używa tła, środkowy prostokąt nie ma wypełnienia, a prawy prostokąt przełącza się z wypełnienia tłem na wyraźne pomarańczowe wypełnienie.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // Dziedzicz gradient z mastera.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // Dodaj ten obiekt jako pierwszy, aby był za prostokątami.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // Wyłącz wypełnienie tłem przed zastosowaniem wyraźnego wypełnienia.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik, od lewej do prawej: **wypełnienie tłem**, **brak wypełnienia** i **wyraźne wypełnienie**. Magentowy pasek jest zasłonięty przez lewy i prawy prostokąt, ale pozostaje widoczny przez środkowy prostokąt.

![Wypełnienie tłem, brak wypełnienia i wyraźne pomarańczowe wypełnienie na magentowym pasku](background-fill.png)

To samo zachowanie dotyczy tła zdefiniowanego bezpośrednio na slajdzie lub dziedziczonego z układu. Kształt używa rozwiązania tła slajdu; przykład pozostawia zarówno tło slajdu, jak i układu niezdefiniowane, więc dostarcza je główny szablon.

## **Ustaw przezroczystość**

W przypadku wypełnienia stałego składnik alfa koloru kontroluje nieprzezroczystość: 0 oznacza całkowitą przezroczystość, a 255 pełną nieprzezroczystość. Ten przykład używa wartości alfa 128 dla żółtego prostokąta, co sprawia, że jest on w przybliżeniu 50% przezroczysty, więc prostokąt pod spodem pozostaje widoczny. Kolor jest przypisany za pomocą [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Przezroczysty kształt](shape-transparency.png)

## **Obracaj kształty**

Użyj [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation), aby obrócić kształt w płaszczyźnie slajdu. Kąt jest mierzony w stopniach; ten przykład obraca prostokąt o 5 stopni zgodnie z ruchem wskazówek zegara i zapisuje prezentację.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Obrót kształtu](shape-rotation.png)

## **Dodaj efekty 3D Bevel**

Użyj [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat), aby nadać kształtowi głębokość i ścięte krawędzie. Ten przykład tworzy zieloną elipsę z pomarańczowym konturem, ustawia [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) na 4 punkty i stosuje okrągłe wykończenie górne o szerokości i wysokości 6 punktów poprzez [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). Kamera ortograficzna skierowana na przód oraz oświetlenie trójpunktowe sprawiają, że ścięcie jest widoczne.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Efekt 3D Bevel](3D-bevel-effect.png)

## **Dodaj efekty rotacji 3D**

Widok 3D kształtu jest kontrolowany przez ustawienia kamery. Ten przykład używa [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) z kątem szerokości, długości i obrotu odpowiednio 40°, 35° i 20°. Wybiera kamerę izometryczną poprzez [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType), a zrównoważone oświetlenie poprzez [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), po czym zapisuje sformatowany prostokąt.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynik:

![Efekt rotacji 3D](3D-rotation-effect.png)

## **Kontroluj renderowanie czarno-białe dla kształtów**

Metoda [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) określa, jak pojedynczy kształt jest renderowany, gdy prezentacja jest wyświetlana lub przetwarzana w trybie czarno-białym. Nie włącza ona samego wyświetlania czarno-białego i nie zmienia wypełnienia, linii ani innych formatowań kształtu w normalnym trybie kolorowym.

Użyj wartości z klasy [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) , aby wybrać pożądane zachowanie. Na przykład `Automatic` pozwala aplikacji renderującej wybrać konwersję, `Gray` i `LightGray` używają odcieni szarości, `BlackWhite` używa wyłącznie czerni i bieli, `Black` i `White` wymuszają pojedynczy kolor, `Color` zachowuje normalne kolorowanie, a `Hidden` pomija kształt w trybie czarno-białym. `NotDefined` oznacza, że nie przypisano trybu dla kształtu.

Ten przykład tworzy pomarańczowy prostokąt i ustawia [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) na szary. Zapisany kształt zachowuje pomarańczowe wypełnienie w normalnym trybie kolorowym i żąda szarego kolorowania od aplikacji, które respektują ustawienia wyświetlania czarno-białego:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

W normalnym trybie kolorowym prostokąt zachowuje pomarańczowe wypełnienie. W przepływie pracy wyświetlania czarno-białego używa szarego kolorowania, ponieważ jego tryb jest ustawiony na `Gray`. To pozwala zachować slajd w pełnym kolorze, definiując odrębny wygląd dla drukowania, podglądu lub innych przepływów pracy, które respektują ustawienia wyświetlania czarno-białego prezentacji.

## **Resetowanie formatowania**

Użyj [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset), aby przywrócić pozycję, rozmiar i formatowanie elementów zastępczych slajdu z ich odpowiednich elementów zastępczych układu. Ten przykład wymaga istniejącej prezentacji z elementami zastępczymi powiązanymi z układem i resetuje każdy slajd przed zapisaniem. Kształty bez odpowiadających elementów zastępczych układu nie są resetowane.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy formatowanie kształtu wpływa na ostateczny rozmiar pliku prezentacji?**

Kolory, style linii i ustawienia efektów zazwyczaj dodają niewiele danych w porównaniu do osadzonych obrazów i multimediów. Wypełnienia obrazem mogą zwiększyć rozmiar pliku, ponieważ ich obrazy są przechowywane w prezentacji.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — wypełnienie, linię i ustawienia efektów. Jeśli wszystkie odpowiadające wartości się zgadzają, potraktuj ich style jako identyczne i logicznie pogrupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów do osobnego pliku, aby ponownie używać ich w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w szablonie zestawu slajdów lub pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylowane kształty i ponownie zastosuj ich formatowanie tam, gdzie jest to wymagane.