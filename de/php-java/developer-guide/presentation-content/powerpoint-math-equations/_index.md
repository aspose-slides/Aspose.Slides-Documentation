---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in PHP hinzufügen
linktitle: PowerPoint Mathematikgleichungen
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
- mathematischen Text hinzufügen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für PHP via Java einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare PHP-Beispielcode."
---
## **Übersicht**

PowerPoint speichert Gleichungen im Office Math Markup Language (OMML)-Format. Mit Aspose.Slides für PHP über Java können Sie dieselben mathematischen Inhalte programmgesteuert erstellen: Brüche, Radikale, Funktionen, Grenzen, N‑äre Operatoren, Matrizen, Arrays und formatierte Mathematikblöcke.

In PowerPoint fügen Benutzer Gleichungen normalerweise über **Einfügen > Gleichung** hinzu:

![PowerPoint‑Einfügen‑Registerkarte mit dem ausgewählten Befehl Gleichung](powerpoint-math-equations_1.png)

Das Ergebnis ist editierbarer mathematischer Text auf der Folie:

![Eine PowerPoint‑Folie mit einer editierbaren mathematischen Gleichung](powerpoint-math-equations_2.png)

Aspose.Slides erstellt diesen mathematischen Text über drei Hauptobjekte:

- Ein mathematisches Shape, erstellt mit [addMathShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/#addMathShape), ist das Shape, das die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathportion/) speichert mathematischen Inhalt im Textfeld des Shapes.
- [MathParagraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathblock/)-Objekte.

Die meisten Beispiele unten verwenden [MathematicalText](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathematicaltext/) und die fluente Methoden von [MathElementBase](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), um den Code kurz und lesbar zu halten.

Für MathML‑Export‑Szenarien siehe [Exportieren von mathematischen Gleichungen aus Präsentationen in PHP via Java](/slides/de/php-java/exporting-math-equations/).

## **Eine Gleichung erstellen**

Dieses Beispiel erstellt ein mathematisches Shape und fügt den Satz des Pythagoras hinzu:

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

{{% alert color="primary" %}}

`addMathShape` erstellt ein Shape, das bereits einen mathematischen Absatz enthält. Greifen Sie auf die erste `MathPortion` zu, erhalten Sie ihr `MathParagraph` und fügen Sie mathematische Blöcke oder mathematische Elemente hinzu.

{{% /alert %}}

## **Brüche hinzufügen**

Verwenden Sie [`divide`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), um einen Bruch zu erstellen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathfractiontypes/) auswählen.

![Ein schräger mathematischer Bruch, der 1 durch x teilt](powerpoint-math-equations_4.png)

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

Für einen gestapelten Bruch verwenden Sie `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Radikale hinzufügen**

Verwenden Sie [`radical`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), um eine Quadratwurzel, Kubikwurzel oder andere Wurzel zu erstellen. Das aktuelle Element wird zur Basis und das Argument zum Wurzelgrad.

![Ein n‑te‑Wurzel‑Ausdruck mit x unter dem Wurzelzeichen](powerpoint-math-equations_5.png)

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

## **Funktionen und Grenzen hinzufügen**

Verwenden Sie [`asArgumentOfFunction`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) oder [`function`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) für Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen. Für Grenzen setzen Sie `lim` in ein [MathLimit](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathlimit/) oder verwenden [`setLowerLimit`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/).

![Der Grenzwert von x wenn x gegen ∞ geht](powerpoint-math-equations_8.png)

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

Für einen benutzerdefinierten Funktionsnamen machen Sie den Funktionsnamen zum aktuellen Element:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N‑äre Operatoren und Integrale hinzufügen**

Verwenden Sie [`nary`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) für Summen, Vereinigungen, Schnitte und andere große Operatoren. Verwenden Sie [`integral`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) für Integrale. Beide Methoden ermöglichen das Setzen von unteren und oberen Grenzen.

![Eine Summation mit unterer und oberer Grenze](powerpoint-math-equations_7.png)

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

N‑äre Operatoren dienen großen Operatoren mit optionalen Grenzen. Einfache Operatoren wie `+`, `-` und `=` werden normalerweise als `MathematicalText` hinzugefügt und zum Ausdruck verknüpft.

Für ein Integral verwenden Sie `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathmatrix/) für Zeilen und Spalten. Matrizen enthalten standardmäßig keine Klammern, daher sollten Sie die Matrix einschließen, wenn Sie Klammern, eckige Klammern oder geschweifte Klammern benötigen.

![Eine zweizeilige mathematische Matrix mit einer leeren Zelle](powerpoint-math-equations_10.png)

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

Verwenden Sie [`toMathArray`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), wenn Sie ausgerichtete Gleichungen oder einen vertikalen Stapel von Ausdrücken benötigen.

![Ein vertikales Mathe‑Array mit x über y](powerpoint-math-equations_11.png)

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

## **Trigonometrische Funktionen hinzufügen**

Verwenden Sie [`asArgumentOfFunction`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), wenn das Argument das aktuelle Element ist und der Funktionsname bekannt ist.

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

## **Tief‑ und Hochstellungen hinzufügen**

Verwenden Sie die Hilfsfunktionen für Tief‑ und Hochstellungen für Indizes und Potenzen. Wenn die Indizes links von der Basis erscheinen müssen, verwenden Sie [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/).

![Ein großes Y mit linksseitigem Tiefstellung 1 und Hochstellung n](powerpoint-math-equations_9.png)

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

Verwenden Sie [`enclose`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), um einen Ausdruck in Begrenzungszeichen zu setzen. Sie können außerdem ein Trennzeichen‑Zeichen für Begrenzungs‑Ausdrücke festlegen, die mehrere Elemente enthalten.

![Ein Begrenzungs‑Ausdruck, der x, y und z mit senkrechten Strichen trennt](powerpoint-math-equations_13.png)

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

## **Eine Rahmen‑Box hinzufügen**

Verwenden Sie [`toBorderBox`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), wenn die Gleichung selbst gerahmt werden soll.

![Eine eingeklammerte Gleichung, die c² = b² + a² zeigt](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Terme gruppieren**

Verwenden Sie [`group`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), um ein Gruppierungszeichen über oder unter einem Ausdruck zu platzieren. Fügen Sie eine Grenze hinzu, um die gruppierten Terme zu beschriften.

![Der Ausdruck x + y gegliedert mit dem Etikett beliebiger Text darunter](powerpoint-math-equations_15.png)

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

## **Mathe‑Elemente formatieren**

Verwenden Sie Formatierungs‑Hilfsfunktionen nur dort, wo sie die Formel verdeutlichen. Zum Beispiel setzt [`overbar`](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) einen Balken über ein mathematisches Element.

![Ein mathematischer Ausdruck ABC mit einem Überbalken](powerpoint-math-equations_14.png)

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

## **Kurzreferenz**

| Aufgabe | Haupt‑API |
| --- | --- |
| Mathematischen Text erstellen | [MathematicalText](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathematicaltext/) |
| Elemente kombinieren | [join](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) |
| Brüche erstellen | [divide](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) |
| Hoch‑ oder Tiefstellung hinzufügen | [setSuperscript](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) |
| Funktionen hinzufügen | [function](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) |
| Radikale hinzufügen | [radical](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) |
| Grenzen hinzufügen | [setLowerLimit](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) |
| Linksseitige Skripte hinzufügen | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) |
| Summen und Integrale hinzufügen | [nary](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathmatrix/) |
| Gleichungs‑Arrays hinzufügen | [toMathArray](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) |
| Begrenzungszeichen hinzufügen | [enclose](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) |
| Balken und Rahmen hinzufügen | [overbar](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) |
| Terme gruppieren | [group](https://reference.aspose.com/slides/de/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Kann ich eine vorhandene PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, finden Sie das Shape, das eine `MathPortion` enthält, holen Sie dessen `MathParagraph` und aktualisieren Sie die mathematischen Blöcke in diesem Absatz.

**Werden Gleichungen als editierbare PowerPoint‑Mathematik gespeichert?**

Ja. Beim Speichern als PPTX schreibt Aspose.Slides die Gleichung als editierbaren Office‑Mathe‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Aspose.Slides exportiert mathematische Gleichungen nach MathML. Wenn Sie LaTeX benötigen, exportieren Sie zuerst nach MathML und konvertieren Sie das MathML anschließend mit einem Tool, das Ihren Ziel‑LaTeX‑Dialekt unterstützt.