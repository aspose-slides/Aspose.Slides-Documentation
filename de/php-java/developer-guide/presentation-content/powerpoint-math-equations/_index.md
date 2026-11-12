---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in PHP hinzufügen
linktitle: PowerPoint Mathematische Gleichungen
type: docs
weight: 80
url: /de/php-java/powerpoint-math-equations/
keywords:
- mathematische Gleichung
- mathematisches Symbol
- mathematische Formel
- mathematischer Text
- mathematische Gleichung hinzufügen
- mathematisches Symbol hinzufügen
- mathematische Formel hinzufügen
- Mathematiktext hinzufügen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für PHP via Java einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare PHP‑Code‑Beispiele."
---
## **Übersicht**

PowerPoint speichert Gleichungen als Office Math Markup Language (OMML). Mit Aspose.Slides für PHP via Java können Sie denselben mathematischen Inhalt programmatisch erstellen: Brüche, Wurzeln, Funktionen, Grenzwerte, N‑äre Operatoren, Matrizen, Arrays und formatierte mathematische Blöcke.

In PowerPoint fügen Benutzer Gleichungen normalerweise über **Einfügen > Gleichung** hinzu:

![PowerPoint‑Registerkarte Einfügen mit dem Befehl Gleichung ausgewählt](powerpoint-math-equations_1.png)

Eine PowerPoint‑Folie, die eine bearbeitbare mathematische Gleichung enthält:

![Eine PowerPoint‑Folie, die eine bearbeitbare mathematische Gleichung enthält](powerpoint-math-equations_2.png)

Aspose.Slides erstellt diesen mathematischen Text über drei Hauptobjekte:

- Ein mathematisches Shape, erstellt mit [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape), ist das Shape, das die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) speichert mathematischen Inhalt im Textfeld des Shapes.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)‑Objekte.

Die meisten nachfolgenden Beispiele verwenden [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) und die Fluent‑Methoden von [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), um den Code kurz und lesbar zu halten.

Für MathML‑Export‑Szenarien siehe [Exportieren mathematischer Gleichungen aus Präsentationen in PHP via Java](/slides/de/php-java/exporting-math-equations/).

## **Gleichung erstellen**

Dieses Beispiel verwendet [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape), um ein mathematisches Shape zu erstellen und fügt den Satz des Pythagoras hinzu:

![Die Gleichung c² = a² + b²](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Hinweis" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) erstellt ein Shape, das bereits einen mathematischen Absatz enthält. Greifen Sie auf die erste [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) zu, rufen Sie [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) auf und fügen Sie Math‑Blöcke oder Math‑Elemente hinzu.
{{% /alert %}}

## **Brüche hinzufügen**

Verwenden Sie [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide), um einen Bruch zu erstellen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/) auswählen.

![Ein schräger mathematischer Bruch, der eins geteilt durch x zeigt](powerpoint-math-equations_4.png)

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

Für einen gestapelten Bruch verwenden Sie [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Wurzeln hinzufügen**

Verwenden Sie [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical), um eine Quadratwurzel, Kubikwurzel oder andere Wurzel zu erstellen. Das aktuelle Element wird zur Basis, das Argument zum Exponenten.

![Ein n‑ter Wurzelausdruck mit x unter dem Wurzelzeichen](powerpoint-math-equations_5.png)

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

## **Funktionen und Grenzwerte hinzufügen**

Verwenden Sie [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) oder [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) für Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen. Für Grenzwerte setzen Sie `lim` in ein [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) oder verwenden Sie [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit).

![Der Grenzwert von x, wenn x gegen unendlich geht](powerpoint-math-equations_8.png)

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

Für einen benutzerdefinierten Funktionsnamen machen Sie den Funktionsnamen zum aktuellen Element und rufen [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) mit seinem Argument auf:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N‑äre Operatoren und Integrale hinzufügen**

Verwenden Sie [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) für Summationen, Vereinigungen, Schnittmengen und andere große Operatoren. Verwenden Sie [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) für Integrale. Beide Methoden ermöglichen das Setzen von Unter‑ und Obergrenzen.

![Eine Summation mit Unter‑ und Obergrenzen](powerpoint-math-equations_7.png)

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

N‑äre Operatoren sind für große Operatoren mit optionalen Grenzen gedacht. Einfache Operatoren wie `+`, `-` und `=` werden normalerweise über [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) eingefügt und in den Ausdruck integriert.

Für ein Integral verwenden Sie [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) für Zeilen und Spalten. Matrizen enthalten standardmäßig keine Klammern, daher müssen Sie die Matrix bei Bedarf in Klammern, eckige Klammern oder geschweifte Klammern einschließen.

![Eine mathematische Matrix mit zwei Zeilen und einer leeren Zelle](powerpoint-math-equations_10.png)

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

## **Gleichungs‑Arrays hinzufügen**

Verwenden Sie [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray), wenn Sie ausgerichtete Gleichungen oder einen vertikalen Stapel von Ausdrücken benötigen.

![Ein vertikales mathematisches Array mit x über y](powerpoint-math-equations_11.png)

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

### **Ein Array mit umgebenden Elementen ausrichten**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) steuert die vertikale Ausrichtung eines Arrays relativ zu den mathematischen Elementen neben ihm. Das nachfolgende Beispiel vergleicht die Ausrichtung mit der ersten Zeile, der Mitte des Arrays und der letzten Zeile.

Das folgende Beispiel erzeugt drei identische Arrays, jeweils mit drei Zeilen und den Nachbarelementen `A=` und `=B`. Der gesamte mathematische Text verwendet Cambria Math in 24 pt. Nur die Array‑Ausrichtung ändert sich.

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

Der folgende Vergleich zeigt die gespeicherte Präsentation in PowerPoint. Beachten Sie die Position von `A=` und `=B` neben jedem Array.

![Gleichungs‑Arrays in PowerPoint mit oben, zentriert und unten Ausrichtung und identischen benachbarten Elementen](equation-array-alignment.png)

### **Zeilenabstand konfigurieren**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) wählt die Abstandregel für Zeilen innerhalb des Arrays. [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) liefert einen numerischen Wert für eine explizite Abstandregel und wird von den Vorgaberegeln ignoriert.

Für exakten Abstand wird der Wert in Punkten gemessen. Für proportionalen Abstand wird in halben Zeilen gemessen: Der Wert `3` im Beispiel steht für 1,5 Zeilen. Setzen Sie beide Eigenschaften, wenn Sie einen expliziten Wert angeben; das alleinige Ändern des numerischen Werts wählt keine Abstandregel aus.

Das Beispiel speichert fünf Präsentationen mit denselben Gleichungen, derselben Ausrichtung und denselben Schrifteinstellungen. Die ersten drei verwenden Vorgaben; die letzten beiden zeigen explizite Werte.

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

Der Zeilenabstand des Arrays ist getrennt vom Absatzabstand. [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) und [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) fügen Abstand um den enthaltenden Absatz hinzu, nicht zwischen Array‑Zeilen. Ebenso positioniert [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) den gesamten mathematischen Absatz horizontal; es ersetzt nicht die vertikale Ausrichtung des Arrays.

## **Trigonometrische Funktionen hinzufügen**

Verwenden Sie [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction), wenn das Argument das aktuelle Element ist und der Funktionsname bekannt ist.

![Die trigonometrische Funktion cos angewendet auf 2x](powerpoint-math-equations_6.png)

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

## **Tief- und Hochstellungen hinzufügen**

Verwenden Sie die Hilfsmethoden für Tief- und Hochstellungen für Indizes und Potenzen. Wenn die Indizes links von der Basis stehen sollen, nutzen Sie [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Ein großes Y mit linksseitigem Tiefindex 1 und Hochindex n](powerpoint-math-equations_9.png)

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

## **Begrenzungszeichen hinzufügen**

Verwenden Sie [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose), um einen Ausdruck in Begrenzungszeichen zu setzen. Sie können auch ein Trennzeichen‑Zeichen für Begrenzungszeichen‑Ausdrücke festlegen, die mehrere Elemente enthalten.

![Ein Ausdruck mit Begrenzungszeichen, der x, y und z enthält, getrennt durch senkrechte Striche](powerpoint-math-equations_13.png)

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

### **Größe und Ausrichtung von Begrenzungszeichen**

Übergeben Sie `true` an [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), damit die Klammern um einen hohen Operanden wachsen, oder `false`, um ihre normale Größe beizubehalten. Verwenden Sie [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) mit einem der beiden Werte von [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/). `Centered` zentriert die Klammern auf der mathematischen Achse, die durch das Gleichheitszeichen verläuft. `Match` richtet sie an den eingeschlossenen Inhalt aus. Beide Einstellungen betreffen nur die Begrenzungszeichen. Der Ausdruck im Inneren bleibt unverändert.

Das Beispiel platziert einen Bruch im Exponenten von `x`, sodass der Ausdruck weiter über die Grundlinie hinausgeht als darunter. Alle vier Gleichungen verwenden dieselben Klammern und Schriftart‑Einstellungen.

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

In PowerPoint vergleichen Sie die Zeilen, um den Effekt des Wachstums zu sehen. In der oberen Zeile wachsen die Klammern, um den Exponenten zu umschließen, und sehen für beide Formen gleich aus. In der unteren Zeile ist das Wachstum deaktiviert. Die kleineren Klammern links (`Centered`) richten sich nach dem Gleichheitszeichen aus, während die rechten (`Match`) höher um den Ausdruck herum sitzen.

![Vier Gleichungen in PowerPoint mit aktiviertem Begrenzungszeichen‑Wachstum oben und deaktiviert unten, links zentriert und rechts passend](delimiter-sizing.png)

## **Rahmenbox hinzufügen**

Rufen Sie [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) bei einem Bruch auf, um den gesamten Ausdruck einzurahmen. Das zurückgegebene [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) zeigt standardmäßig alle vier Seiten. Verwenden Sie [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft) und [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight), um einzelne Seiten zu entfernen.

Das Beispiel platziert sechs Kopien desselben Bruchs auf einer Folie. Um eine Streichung zu zeigen, verbergen Sie alle vier Seiten und übergeben Sie `true` an [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) für eine aufsteigende Diagonale (↗) oder [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) für eine fallende Diagonale (↘). Sie können auch [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) oder [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) in Kombination mit beliebigen sichtbaren Seiten verwenden.

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

![Sechs bearbeitbare Brüche in PowerPoint. Obere Zeile: voller Rand, untere und linke Seite, aufsteigende Diagonale. Untere Zeile: fallende Diagonale, horizontaler Strich, vertikaler Strich mit vollem Rand.](border-box-fractions.png)

Bei diesem Bruch überschneidet der horizontale Strich den Bruchstrich. Der vertikale Strich schneidet sowohl Zähler als auch Nenner, während der umgebende Rand sichtbar bleibt. Diese Linien dekorieren den gesamten Ausdruck. Normale Text‑Durchstreichungen gelten für Zeichen in einem Textlauf. Nach erneutem Öffnen der Präsentation in PowerPoint können Sie Zähler und Nenner weiterhin unabhängig voneinander bearbeiten.

## **Terme gruppieren**

Verwenden Sie [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group), um ein Gruppierungszeichen über oder unter einem Ausdruck zu platzieren. Fügen Sie eine Grenze hinzu, um die gruppierten Terme zu beschriften.

![Der Ausdruck x + y gruppiert mit dem Label beliebiger Text darunter](powerpoint-math-equations_15.png)

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

## **Mathematische Elemente formatieren**

Verwenden Sie Formatierungs‑Hilfsmethoden nur dort, wo sie die Formel verdeutlichen. Zum Beispiel platziert [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) einen Strich über einem mathematischen Element.

![Ein mathematischer Ausdruck ABC mit einem Überstrich](powerpoint-math-equations_14.png)

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

### **Text in einer bestehenden Gleichung formatieren**

Um Text durchgehend in einer bestehenden Gleichung zu formatieren, traversieren Sie den Element‑Baum jedes Math‑Blocks. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) liefert nur die unmittelbaren Kinder, daher rufen Sie sie rekursiv auf, um Text in Brüchen, Skripten, Wurzeln und anderen verschachtelten Strukturen zu erreichen. Prüfen Sie das aktuelle Element sowie dessen Kinder, um das Ausgangselement einzubeziehen, wenn es ein [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) ist.

Dieses Beispiel geht davon aus, dass `input.pptx` eine Gleichung wie `z = xᵢ / ∛y` enthält, wobei ein Bruch einen Tiefindex im Zähler und eine Wurzel im Nenner hat. Das reine Verarbeiten der Top‑Level‑Elemente des Blocks würde den Text im Bruch übersehen. Das Beispiel findet mathematische Abschnitte in Folientext‑Frames, greift über [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) auf deren Blöcke zu und verwendet [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight), um die Schriftgröße über jedes Textelement‑[getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat)‑Methoden auf 28 pt zu setzen.

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

Die gespeicherte Präsentation enthält die aktualisierte Textformatierung auf jeder Ebene jeder verarbeiteten Gleichung, während ihr Textinhalt und ihre mathematische Struktur erhalten bleiben.

## **Kurzreferenz**

| Aufgabe | Haupt‑API |
| --- | --- |
| Mathe‑Text erstellen | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Elemente kombinieren | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Brüche erstellen | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Hoch- oder Tiefstellung hinzufügen | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Funktionen hinzufügen | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Wurzeln hinzufügen | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Grenzwerte hinzufügen | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Linksseitige Skripte hinzufügen | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Summen und Integrale hinzufügen | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Gleichungs‑Arrays hinzufügen | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Begrenzungszeichen hinzufügen | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Balken und Rahmen hinzufügen | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Terme gruppieren | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Kann ich eine bestehende PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, finden Sie das Shape, das eine [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) enthält, rufen Sie [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) auf und aktualisieren Sie die Math‑Blöcke in diesem Absatz.

**Werden Gleichungen als editierbare PowerPoint‑Mathematik gespeichert?**

Ja. Beim Speichern als PPTX schreibt Aspose.Slides die Gleichung als editierbaren Office‑Math‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Ja. Holen Sie sich das [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) einer [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), und rufen Sie [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) auf, um es direkt zu exportieren. Ein komplettes Beispiel finden Sie unter [Exportieren mathematischer Gleichungen aus Präsentationen in PHP via Java](/slides/de/php-java/exporting-math-equations/#export-math-equations-to-latex).