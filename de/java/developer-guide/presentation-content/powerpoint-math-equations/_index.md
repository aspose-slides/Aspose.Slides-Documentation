---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in Java hinzufügen
linktitle: PowerPoint Mathegleichungen
type: docs
weight: 80
url: /de/java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für Java einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare Java-Beispielcode."
---
## **Übersicht**

PowerPoint speichert Gleichungen als Office Math Markup Language (OMML). Mit Aspose.Slides für Java können Sie dieselben mathematischen Inhalte programmgesteuert erstellen: Brüche, Radikale, Funktionen, Grenzen, N‑äre Operatoren, Matrizen, Arrays und formatierte mathematische Blöcke.

In PowerPoint fügen Benutzer Gleichungen normalerweise über **Einfügen > Gleichung** hinzu:

![PowerPoint-Registerkarte Einfügen mit dem Befehl Gleichung ausgewählt](powerpoint-math-equations_1.png)

Das Ergebnis ist bearbeitbarer mathematischer Text auf der Folie:

![Eine PowerPoint‑Folie mit einer editierbaren mathematischen Gleichung](powerpoint-math-equations_2.png)

Aspose.Slides erstellt diesen mathematischen Text über drei Hauptobjekte:

- Ein mathematisches Shape, erstellt mit [addMathShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-), ist das Shape, das die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathportion/) speichert mathematischen Inhalt im Textfeld des Shapes.
- [MathParagraph](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathblock/)-Objekte.

Die meisten Beispiele unten verwenden [MathematicalText](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathematicaltext/) und die Fluent‑Methoden von [IMathElement](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/), um den Code kurz und lesbar zu halten.

Für MathML‑Export‑Szenarien siehe [Export Math Equations from Presentations in Java](/slides/de/java/exporting-math-equations/).

## **Gleichung erstellen**

Dieses Beispiel erstellt ein mathematisches Shape und fügt den Satz des Pythagoras hinzu:

![Die Gleichung c² = a² + b²](powerpoint-math-equations_3.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` erstellt ein Shape, das bereits einen mathematischen Absatz enthält. Greifen Sie auf die erste `MathPortion` zu, holen Sie deren `MathParagraph` und fügen Sie mathematische Blöcke oder Elemente hinzu.
{{% /alert %}}

## **Brüche hinzufügen**

Verwenden Sie `divide`, um einen Bruch zu erstellen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathfractiontypes/) wählen.

![Ein schräger Bruch, der 1 geteilt durch x zeigt](powerpoint-math-equations_4.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für einen gestapelten Bruch verwenden Sie `MathFractionTypes.Bar`:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Radikale hinzufügen**

Verwenden Sie `radical`, um eine Quadratwurzel, Kubikwurzel oder andere Wurzel zu erzeugen. Das aktuelle Element wird zur Basis, das Argument zum Grad.

![Ein n‑te Wurzel‑Ausdruck mit x unter dem Wurzelzeichen](powerpoint-math-equations_5.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Funktionen und Grenzen hinzufügen**

Verwenden Sie `asArgumentOfFunction` oder `function` für Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen. Für Grenzen setzen Sie `lim` in ein [MathLimit](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathlimit/) oder verwenden `setLowerLimit`.

![Die Grenze von x, wenn x gegen ∞ geht](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für einen benutzerdefinierten Funktionsnamen machen Sie den Funktionsnamen zum aktuellen Element:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N‑äre Operatoren und Integrale hinzufügen**

Verwenden Sie `nary` für Summen, Vereinigungen, Schnitte und andere große Operatoren. Verwenden Sie `integral` für Integrale. Beide Methoden erlauben das Setzen von Unter‑ und Obergrenzen.

![Eine Summation mit Unter‑ und Obergrenzen](powerpoint-math-equations_7.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N‑äre Operatoren sind für große Operatoren mit optionalen Grenzen gedacht. Einfache Operatoren wie `+`, `-` und `=` werden normalerweise als `MathematicalText` hinzugefügt und zum Ausdruck verbunden.

Für ein Integral verwenden Sie `integral`:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathmatrix/) für Zeilen und Spalten. Matrizen enthalten standardmäßig keine Klammern, also umschließen Sie die Matrix, wenn Sie Klammern, eckige Klammern oder geschweifte Klammern benötigen.

![Eine zweizeilige Matrix mit einer leeren Zelle](powerpoint-math-equations_10.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gleichungs‑Arrays hinzufügen**

Verwenden Sie `toMathArray`, wenn Sie ausgerichtete Gleichungen oder einen vertikalen Stapel von Ausdrücken benötigen.

![Ein vertikales Mathematik‑Array mit x über y](powerpoint-math-equations_11.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trigonometrische Funktionen hinzufügen**

Verwenden Sie `asArgumentOfFunction`, wenn das Argument das aktuelle Element ist und der Funktionsname bekannt ist.

![Die trigonometrische Funktion cos, angewendet auf 2x](powerpoint-math-equations_6.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tief‑ und Hochstellungen hinzufügen**

Verwenden Sie die Hilfsmethoden für Tief‑ und Hochstellungen für Indizes und Potenzen. Wenn die Indizes links von der Basis stehen sollen, verwenden Sie `setSubSuperscriptOnTheLeft`.

![Ein großes Y mit linksseitigem Tiefstellung 1 und Hochstellung n](powerpoint-math-equations_9.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Begrenzungszeichen hinzufügen**

Verwenden Sie `enclose`, um einen Ausdruck in Begrenzungszeichen zu setzen. Sie können auch ein Trennzeichen für Begrenzungs‑Ausdrücke festlegen, die mehrere Elemente enthalten.

![Ein Begrenzungs‑Ausdruck mit x, y und z, getrennt durch senkrechte Striche](powerpoint-math-equations_13.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rahmen‑Box hinzufügen**

Verwenden Sie `toBorderBox`, wenn die Gleichung selbst gerahmt werden soll.

![Eine eingekapselte Gleichung, die a² = b² + c² zeigt](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Terme gruppieren**

Verwenden Sie `group`, um ein Gruppierungszeichen über oder unter einem Ausdruck zu platzieren. Fügen Sie eine Grenze hinzu, um die gruppierten Terme zu beschriften.

![Der Ausdruck x + y, gruppiert mit dem Beschriftungstext darunter](powerpoint-math-equations_15.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mathematische Elemente formatieren**

Verwenden Sie Formatierungshilfen nur dort, wo sie die Formel verdeutlichen. Beispiel: `overbar` setzt einen Strich über ein mathematisches Element.

![Ein mathematischer Ausdruck ABC mit einem Überstrich](powerpoint-math-equations_14.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kurzreferenz**

| Aufgabe | Haupt‑API |
| --- | --- |
| Mathematischen Text erstellen | [MathematicalText](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathematicaltext/) |
| Elemente kombinieren | [IMathElement.join](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| Brüche erstellen | [IMathElement.divide](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| Hoch‑ oder Tiefstellung hinzufügen | [setSuperscript](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| Funktionen hinzufügen | [function](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| Radikale hinzufügen | [IMathElement.radical](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| Grenzen hinzufügen | [setLowerLimit](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| Linksseitige Skripte hinzufügen | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Summen und Integrale hinzufügen | [nary](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/de/java/com.aspose.slides/mathmatrix/) |
| Gleichungs‑Arrays hinzufügen | [toMathArray](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#toMathArray--) |
| Begrenzungszeichen hinzufügen | [enclose](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| Balken und Rahmen hinzufügen | [overbar](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#toBorderBox--) |
| Terme gruppieren | [group](https://reference.aspose.com/slides/de/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **FAQ**

**Kann ich eine vorhandene PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, finden Sie das Shape, das eine `MathPortion` enthält, holen Sie dessen `MathParagraph` und aktualisieren Sie die mathematischen Blöcke in diesem Absatz.

**Werden Gleichungen als bearbeitbares PowerPoint‑Math gespeichert?**

Ja. Beim Speichern im PPTX‑Format schreibt Aspose.Slides die Gleichung als bearbeitbaren Office‑Math‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Aspose.Slides exportiert mathematische Gleichungen nach MathML. Wenn Sie LaTeX benötigen, exportieren Sie zuerst nach MathML und konvertieren Sie dann das MathML mit einem Tool, das Ihr gewünschtes LaTeX‑Dialekt unterstützt.