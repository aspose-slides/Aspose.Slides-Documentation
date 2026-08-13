---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen auf Android hinzufügen
linktitle: PowerPoint Mathe Gleichungen
type: docs
weight: 80
url: /de/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für Android einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare Java-Code-Beispiele."
---
## **Übersicht**

PowerPoint speichert Gleichungen als Office Math Markup Language (OMML). Mit Aspose.Slides für Android via Java können Sie dieselben mathematischen Inhalte programmgesteuert erstellen: Brüche, Radikale, Funktionen, Grenzen, N‑stellige Operatoren, Matrizen, Arrays und formatierte Matheblöcke.

In PowerPoint fügen Benutzer Gleichungen normalerweise über **Einfügen > Gleichung** ein:

![PowerPoint‑Registerkarte Einfügen mit ausgewähltem Befehl Gleichung](powerpoint-math-equations_1.png)

Das Ergebnis ist editierbarer mathematischer Text auf der Folie:

![Eine PowerPoint‑Folie mit einer editierbaren mathematischen Gleichung](powerpoint-math-equations_2.png)

Aspose.Slides erstellt diesen mathematischen Text über drei Hauptobjekte:

- Eine Mathe‑Form, erstellt mit [addMathShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/), ist die Form, die die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathportion/) speichert den mathematischen Inhalt im Textfeld der Form.
- [MathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathblock/)-Objekte.

Die meisten Beispiele unten verwenden [MathematicalText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathematicaltext/) und die Fluent‑Methoden von [IMathElement](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/), um den Code kurz und lesbar zu halten.

Für MathML‑Export‑Szenarien siehe [Export Math Equations from Presentations on Android](/slides/de/androidjava/exporting-math-equations/).

## **Eine Gleichung erstellen**

Dieses Beispiel erstellt eine Mathe‑Form und fügt den Satz des Pythagoras hinzu:

![Die Gleichung c² = a² + b²](powerpoint-math-equations_3.png)

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
`addMathShape` erstellt eine Form, die bereits einen Math‑Paragraph enthält. Greifen Sie auf die erste `MathPortion` zu, holen Sie deren `MathParagraph` und fügen Sie Math‑Blöcke oder Math‑Elemente hinzu.
{{% /alert %}}

## **Brüche hinzufügen**

Verwenden Sie `divide`, um einen Bruch zu erstellen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathfractiontypes/) wählen.

![Ein schräger mathematischer Bruch, der eins durch x teilt](powerpoint-math-equations_4.png)

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Radikale hinzufügen**

Verwenden Sie `radical`, um eine Quadratwurzel, Kubikwurzel oder ein anderes Radikal zu erzeugen. Das aktuelle Element wird zur Basis, das Argument zum Exponenten.

![Ein n‑te‑Wurzel‑Radikal‑Ausdruck mit x unter dem Wurzelzeichen](powerpoint-math-equations_5.png)

```java
import com.aspose.slides.*;

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

Verwenden Sie `asArgumentOfFunction` oder `function` für Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen. Für Grenzen setzen Sie `lim` in ein [MathLimit](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathlimit/) oder nutzen `setLowerLimit`.

![Der Grenzwert von x, wenn x gegen unendlich geht](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für einen benutzerdefinierten Funktionsnamen machen Sie den Funktionsnamen zum aktuellen Element:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N‑stellige Operatoren und Integrale hinzufügen**

Verwenden Sie `nary` für Summen, Vereinigungen, Durchschnitte und andere große Operatoren. Verwenden Sie `integral` für Integrale. Beide Methoden erlauben das Setzen von unteren und oberen Grenzen.

![Eine Summation mit unterer und oberer Grenze](powerpoint-math-equations_7.png)

```java
import com.aspose.slides.*;

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

N‑stellige Operatoren dienen großen Operatoren mit optionalen Grenzen. Einfache Operatoren wie `+`, `-` und `=` werden in der Regel als `MathematicalText` hinzugefügt und in den Ausdruck eingefügt.

Für ein Integral verwenden Sie `integral`:

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathmatrix/) für Zeilen und Spalten. Matrizen enthalten standardmäßig keine Klammern; schließen Sie die Matrix bei Bedarf in Klammern, eckige Klammern oder geschweifte Klammern ein.

![Eine zweizeilige Mathe‑Matrix mit einer leeren Zelle](powerpoint-math-equations_10.png)

```java
import com.aspose.slides.*;

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

Verwenden Sie `toMathArray`, wenn Sie ausgerichtete Gleichungen oder einen vertikalen Stack von Ausdrücken benötigen.

![Ein vertikales Mathe‑Array mit x über y](powerpoint-math-equations_11.png)

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

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

## **Tief- und Hochstellen hinzufügen**

Verwenden Sie die Hilfsmethoden für Tief‑ und Hochstellen für Indizes und Potenzen. Wenn die Indizes links von der Basis erscheinen sollen, nutzen Sie `setSubSuperscriptOnTheLeft`.

![Ein großes Y mit linksseitigem Tiefstellen 1 und Hochstellen n](powerpoint-math-equations_9.png)

```java
import com.aspose.slides.*;

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

Verwenden Sie `enclose`, um einen Ausdruck in Begrenzungszeichen zu setzen. Sie können auch ein Trennzeichen‑Zeichen für Ausdrücke festlegen, die mehrere Elemente enthalten.

![Ein Ausdruck mit Begrenzungszeichen, der x, y und z durch senkrechte Striche trennt](powerpoint-math-equations_13.png)

```java
import com.aspose.slides.*;

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

## **Eine Rahmen‑Box hinzufügen**

Verwenden Sie `toBorderBox`, wenn die Gleichung selbst gerahmt werden soll.

![Eine umrahmte Gleichung, die a² = b² + c² zeigt](powerpoint-math-equations_12.png)

```java
import com.aspose.slides.*;

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

![Der Ausdruck x + y, gruppiert mit dem Label irgendein Text darunter](powerpoint-math-equations_15.png)

```java
import com.aspose.slides.*;

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

## **Mathe‑Elemente formatieren**

Verwenden Sie Format‑Hilfsmittel nur dort, wo sie die Formel klarer machen. Zum Beispiel setzt `overbar` einen Balken über ein Mathe‑Element.

![Ein mathematischer Ausdruck ABC mit einem Überstrich](powerpoint-math-equations_14.png)

```java
import com.aspose.slides.*;

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
| Mathe‑Text erstellen | [MathematicalText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathematicaltext/) |
| Elemente kombinieren | [IMathElement.join](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/) |
| Brüche erstellen | [IMathElement.divide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/) |
| Hoch- oder Tiefstellen hinzufügen | [setSuperscript](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/) |
| Funktionen hinzufügen | [function](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/) |
| Radikale hinzufügen | [IMathElement.radical](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/) |
| Grenzen hinzufügen | [setLowerLimit](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/) |
| Linksseitige Skripte hinzufügen | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/) |
| Summen und Integrale hinzufügen | [nary](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/mathmatrix/) |
| Gleichungs‑Arrays hinzufügen | [toMathArray](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/) |
| Begrenzungszeichen hinzufügen | [enclose](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/) |
| Balken und Rahmen hinzufügen | [overbar](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/) |
| Terme gruppieren | [group](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathelement/) |

## **FAQ**

**Kann ich eine bereits bestehende PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, finden Sie die Form, die ein `MathPortion` enthält, holen Sie deren `MathParagraph` und aktualisieren Sie die Math‑Blöcke in diesem Paragraphen.

**Werden Gleichungen als editierbare PowerPoint‑Math gespeichert?**

Ja. Beim Speichern als PPTX schreibt Aspose.Slides die Gleichung als editierbaren Office‑Math‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Ja. Holen Sie das [IMathParagraph](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathparagraph/) der Gleichung über ihr [IMathPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathportion/), und rufen Sie [IMathParagraph.toLatex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imathparagraph/#toLatex--) auf, um direkt zu exportieren. Ein vollständiges Beispiel finden Sie unter [Export Math Equations from Presentations in Android via Java](/slides/de/androidjava/exporting-math-equations/#export-math-equations-to-latex).