---
title: Dodaj równania matematyczne do prezentacji PowerPoint w PHP
linktitle: Równania matematyczne PowerPoint
type: docs
weight: 80
url: /pl/php-java/powerpoint-math-equations/
keywords:
- równanie matematyczne
- symbol matematyczny
- formuła matematyczna
- tekst matematyczny
- dodaj równanie matematyczne
- dodaj symbol matematyczny
- dodaj formułę matematyczną
- dodaj tekst matematyczny
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Wstawiaj i edytuj równania matematyczne w PowerPoint PPT i PPTX przy użyciu Aspose.Slides dla PHP via Java, obsługując OMML, kontrolę formatowania oraz przejrzyste przykłady kodu PHP."
---
## **Przegląd**

PowerPoint przechowuje równania jako Office Math Markup Language (OMML). Za pomocą Aspose.Slides for PHP via Java możesz programowo tworzyć taki sam rodzaj treści matematycznych: ułamki, pierwiastki, funkcje, granice, operatory n-arne, macierze, tablice i sformatowane bloki matematyczne.

W programie PowerPoint użytkownicy zazwyczaj dodają równania z **Wstaw > Równanie**:

![Zakładka Wstaw w programie PowerPoint z wybraną komendą Równanie](powerpoint-math-equations_1.png)

Wynikiem jest edytowalny tekst matematyczny na slajdzie:

![Slajd PowerPoint zawierający edytowalne równanie matematyczne](powerpoint-math-equations_2.png)

Aspose.Slides tworzy ten tekst matematyczny za pomocą trzech głównych obiektów:

- Kształt matematyczny, tworzony przy pomocy [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape), to kształt zawierający równanie.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) przechowuje treść matematyczną wewnątrz ramki tekstowej kształtu.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) zawiera jeden lub więcej obiektów [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/).

Większość poniższych przykładów używa [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) oraz płynnych metod z [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), aby kod był krótki i czytelny.

W przypadku scenariuszy eksportu MathML zobacz [Eksportowanie równań matematycznych z prezentacji w PHP via Java](/slides/pl/php-java/exporting-math-equations/).

## **Utworzenie równania**

Ten przykład używa [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) do stworzenia kształtu matematycznego i dodaje twierdzenie Pitagorasa:

![Równanie c kwadrat równa się a kwadrat plus b kwadrat](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="info" title="Uwaga" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) tworzy kształt, który już zawiera akapit matematyczny. Uzyskaj dostęp do pierwszego [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), wywołaj [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), i dodaj bloki matematyczne lub elementy matematyczne.
{{% /alert %}}

## **Dodawanie ułamków**

Użyj [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide), aby utworzyć ułamek. Możesz wybrać styl ułamka przy pomocy [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/).

![Ułamek matematyczny przedstawiający 1 podzielone przez x](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Aby uzyskać ułamek z paseczkiem, użyj [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Dodawanie pierwiastków**

Użyj [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical), aby utworzyć pierwiastek kwadratowy, sześcienny lub inny. Bieżący element staje się podstawą, a argument określa stopień.

![Wyrażenie pierwiastka n-tego stopnia z x pod znakiem pierwiastka](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Dodawanie funkcji i granic**

Użyj [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) lub [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function), aby zdefiniować funkcje takie jak `sin(x)`, `log(x)` lub własne nazwy funkcji. Dla granic umieść `lim` w [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) lub użyj [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit).

![Granica x, gdy x dąży do nieskończoności](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

W przypadku własnej nazwy funkcji ustaw nazwę funkcji jako bieżący element i wywołaj [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) z jej argumentem:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Dodawanie operatorów n-arnych i całek**

Użyj [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary), aby dodać sumy, unie, przecięcia i inne duże operatory. Użyj [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral), aby dodać całki. Obie metody umożliwiają ustawienie dolnych i górnych granic.

![Suma z dolnymi i górnymi granicami](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Operatory n-arne służą do dużych operatorów z opcjonalnymi granicami. Proste operatory takie jak `+`, `-` i `=` są zazwyczaj dodawane jako [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) i łączone w wyrażenie.

Aby dodać całkę, użyj [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Dodawanie macierzy**

Użyj [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) aby definiować wiersze i kolumny. Macierze domyślnie nie zawierają nawiasów, więc otocz macierz, gdy potrzebujesz nawiasów okrągłych, kwadratowych lub klamrowych.

![Macierz matematyczna z dwoma wierszami i jedną pustą komórką](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Dodawanie tablic równań**

Użyj [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray), gdy potrzebujesz wyrównanych równań lub pionowego stosu wyrażeń.

![Pionowa tablica matematyczna z x nad y](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **Wyrównanie tablicy z elementami otaczającymi**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) kontroluje pionowe wyrównanie tablicy względem elementów matematycznych po jej bokach. Poniższy przykład porównuje wyrównanie pierwszego wiersza, środka tablicy i ostatniego wiersza.

Poniższy przykład tworzy trzy identyczne tablice, każda z trzema wierszami oraz sąsiednimi elementami `A=` i `=B`. Wszystki tekst matematyczny używa czcionki Cambria Math w rozmiarze 24 punkty. Zmienia się wyłącznie wyrównanie tablicy.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$alignments = ["Top" => MathVerticalAlignment::Top, "Center" => MathVerticalAlignment::Center, "Bottom" => MathVerticalAlignment::Bottom];
$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(780, 200, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 20;
    foreach ($alignments as $name => $alignment) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 10, 240, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($name);
        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(16);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $mathShape = $slide->getShapes()->addMathShape($x, 60, 240, 130);
        $mathShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification($alignment);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $x += 260;
    }
    $presentation->save("equation-array-alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Poniższe porównanie pokazuje zapisany plik prezentacji w programie PowerPoint. Zauważ położenie `A=` i `=B` obok każdej tablicy.

![Tablice równań w PowerPoint z wyrównaniem Góra, Środek i Dół oraz identycznymi elementami sąsiednimi](equation-array-alignment.png)

### **Konfiguracja odstępu wierszy**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) wybiera regułę odstępu wierszy w tablicy. [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) podaje wartość liczbową dla wyraźnej reguły odstępu i jest ignorowana przy użyciu reguł wbudowanych.

Dla dokładnego odstępu wartość mierzy się w punktach. Dla proporcjonalnego odstępu wartość mierzy się w półwierszach: wartość `3` w przykładzie określa 1,5 linii. Ustaw obie właściwości przy podawaniu wyraźnej wartości; zmiana samej liczby nie wybiera reguły odstępu.

Poniższy przykład zapisuje pięć prezentacji z tymi samymi równaniami, wyrównaniem i ustawieniami czcionki. Pierwsze trzy używają ustawień domyślnych; ostatnie dwa pokazują wyraźne wartości.

```php
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathRowSpacingRule;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$settings = [
    "SingleLineGap" => [MathRowSpacingRule::SingleLineGap, 0],
    "OneAndAHalfLineGap" => [MathRowSpacingRule::OneAndAHalfLineGap, 0],
    "TwoLineGap" => [MathRowSpacingRule::TwoLineGap, 0],
    "Exactly" => [MathRowSpacingRule::Exactly, 20],
    "Multiple" => [MathRowSpacingRule::Multiple, 3],
];

foreach ($settings as $name => [$rule, $spacing]) {
    $presentation = new Presentation();
    try {
        $mathShape = $presentation->getSlides()->get_Item(0)->getShapes()->addMathShape(20, 20, 600, 300);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification(MathVerticalAlignment::Center);
        $equationArray->setRowSpacingRule($rule);
        $equationArray->setRowSpacing($spacing);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $presentation->save("equation-array-$name.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

Odstęp wierszy tablicy jest oddzielny od odstępu akapitu. [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) i [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) dodają odstęp wokół całego akapitu, nie pomiędzy wierszami tablicy. Podobnie, [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) pozycjonuje cały akapit matematyczny poziomo; nie zastępuje ustawienia pionowego wyrównania tablicy.

## **Dodawanie funkcji trygonometrycznych**

Użyj [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction), gdy argument jest bieżącym elementem, a nazwa funkcji jest znana.

![Funkcja trygonometryczna cos zastosowana do 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Dodawanie indeksów dolnych i górnych**

Użyj pomocników indeksu dolnego i górnego dla indeksów i potęg. Gdy indeksy mają pojawiać się po lewej stronie podstawy, użyj [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Wielka litera Y z lewym indeksem dolnym 1 i górnym n](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Dodawanie delimitatorów**

Użyj [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose), aby umieścić wyrażenie w delimitatorach. Możesz także ustawić znak separatora dla wyrażeń delimitatorowych zawierających kilka elementów.

![Wyrażenie delimitatora zawierające x, y i z oddzielone pionowymi kreskami](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **Rozmiar i wyrównanie delimitatorów**

Przekaż `true` do [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), aby nawiasy rosły wokół wysokiego operandu, lub `false`, aby zachować ich normalny rozmiar. Użyj [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) z jedną z dwóch wartości [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/). `Centered` centruje nawiasy na osi matematycznej, która przechodzi przez środek znaku równości. `Match` wyrównuje je z zawartością. Oba ustawienia wpływają tylko na delimitatory. Wyrażenie wewnątrz pozostaje niezmienione.

W przykładzie umieszczono ułamek w wykładniku `x`, więc wyrażenie rozciąga się bardziej powyżej linii bazowej niż poniżej niej. Wszystkie cztery równania używają tych samych nawiasów i ustawień czcionki.

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

W programie PowerPoint porównaj wiersze, aby zobaczyć efekt rozrostu. W górnym wierszu nawiasy rosną, aby otoczyć wykładnik i wyglądają tak samo dla obu kształtów. W dolnym wierszu rozrost jest wyłączony. Mniejsze nawiasy po lewej (`Centered`) są wyrównane ze znakiem równości, natomiast po prawej (`Match`) są wyżej wokół wyrażenia.

![Cztery równania w PowerPoint z włączonym rozrostem delimitatorów powyżej i wyłączonym poniżej, oraz `Centered` po lewej i `Match` po prawej](delimiter-sizing.png)

## **Dodawanie ramki obramowania**

Wywołaj [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) na ułamku, aby otoczyć całe wyrażenie ramką. Zwrócony [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) domyślnie pokazuje wszystkie cztery strony. Użyj [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft), oraz [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight), aby usunąć poszczególne strony.

W przykładzie umieszczono sześć kopii tego samego ułamka na jednym slajdzie. Aby pokazać anulowanie, ukryj wszystkie cztery strony i przekaż `true` do [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) dla rosnącej przekątnej (↗) lub [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) dla opadającej przekątnej (↘). Można także użyć [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) lub [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) z dowolną kombinacją widocznych stron.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Sześć edytowalnych ułamków w PowerPoint. Górny wiersz: pełna ramka, dolna i lewa strona, rosnąca przekątna. Dolny wiersz: opadająca przekątna, poziome przekreślenie, pionowe przekreślenie z pełną ramką](border-box-fractions.png)

W tym ułamku poziome przekreślenie nachodzi na kreskę ułamka. Pionowe przekreślenie przecina zarówno licznik, jak i mianownik, przy zachowanej widoczności otaczającej ramki. Te linie ozdabiają całe wyrażenie. Zwykłe przekreślenie tekstu dotyczy znaków w ciągu tekstowym. Po ponownym otwarciu prezentacji w PowerPoint nadal można edytować licznik i mianownik oddzielnie.

## **Grupowanie wyrazów**

Użyj [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group), aby umieścić znak grupujący nad lub pod wyrażeniem. Dodaj granicę, aby oznaczyć grupowane wyrazy.

![Wyrażenie x plus y zgrupowane z etykietą dowolny tekst pod nim](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Formatowanie elementów matematycznych**

Używaj pomocników formatowania tylko tam, gdzie wyjaśniają formułę. Na przykład, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) umieszcza pasek nad elementem matematycznym.

![Wyrażenie matematyczne ABC z nadkreśleniem](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **Formatowanie tekstu w istniejącym równaniu**

Aby sformatować tekst w całym istniejącym równaniu, przejdź po drzewie elementów każdego bloku matematycznego. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) zwraca tylko bezpośrednie dzieci, więc wywołaj je rekurencyjnie, aby dotrzeć do tekstu wewnątrz ułamków, indeksów, pierwiastków i innych zagnieżdżonych struktur. Sprawdź bieżący element oraz jego dzieci, aby uwzględnić element początkowy, gdy jest to [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/).

Ten przykład zakłada, że `input.pptx` zawiera równanie takie jak `z = xᵢ / ∛y`, z ułamkiem zawierającym indeks dolny w liczniku i pierwiastek w mianowniku. Przetwarzanie tylko elementów najwyższego poziomu bloku pominęłoby tekst wewnątrz ułamka. Przykład znajduje części matematyczne w ramkach tekstowych slajdów, uzyskuje dostęp do ich bloków przez [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), i używa [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight), aby ustawić rozmiar czcionki na 28 punktów poprzez metodę [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) każdego elementu tekstowego.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Zapisana prezentacja zawiera zaktualizowane formatowanie tekstu na każdym poziomie każdego przetworzonego równania, zachowując jednocześnie jego treść tekstową i strukturę matematyczną.

## **Szybkie odniesienie**

| Zadanie | Główne API |
| --- | --- |
| Utworzenie tekstu matematycznego | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Łączenie elementów | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Utworzenie ułamków | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Dodanie indeksu górnego lub dolnego | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Dodanie funkcji | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Dodanie pierwiastków | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Dodanie granic | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Dodanie indeksów po lewej stronie | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Dodanie sum i całek | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Dodanie macierzy | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Dodanie tablic równań | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Dodanie delimiterów | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Dodanie kresek i obramowań | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Grupowanie wyrazów | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Czy mogę edytować istniejące równanie PowerPoint?**

Tak. Otwórz prezentację, znajdź kształt zawierający [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), wywołaj [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), i zaktualizuj bloki matematyczne w tym akapicie.

**Czy równania są zapisywane jako edytowalna matematyka PowerPoint?**

Tak. Po zapisaniu do PPTX, Aspose.Slides zapisuje równanie jako edytowalną zawartość Office Math.

**Czy mogę wyeksportować równania do LaTeX?**

Tak. Pobierz [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) równania z jego [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), i wywołaj [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex), aby wyeksportować je bezpośrednio. Pełny przykład znajdziesz w [Eksport równań matematycznych z prezentacji w PHP via Java](/slides/pl/php-java/exporting-math-equations/#export-math-equations-to-latex).