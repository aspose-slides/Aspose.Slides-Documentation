---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in JavaScript hinzufügen
linktitle: PowerPoint Mathematische Gleichungen
type: docs
weight: 80
url: /de/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für Node.js über Java einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare JavaScript-Codebeispiele."
---
## **Übersicht**

PowerPoint speichert Gleichungen als Office Math Markup Language (OMML). Mit Aspose.Slides für Node.js über Java können Sie dieselben mathematischen Inhalte programmgesteuert erstellen: Brüche, Wurzeln, Funktionen, Grenzwerte, N‑äre Operatoren, Matrizen, Arrays und formatierte mathematische Blöcke.

In PowerPoint fügen Benutzer Gleichungen normalerweise über **Einfügen > Gleichung** hinzu:

![PowerPoint‑Registerkarte Einfügen mit dem Befehl Gleichung ausgewählt](powerpoint-math-equations_1.png)

Das Ergebnis ist editierbarer mathematischer Text auf der Folie:

![Eine PowerPoint‑Folien, die eine editierbare mathematische Gleichung enthält](powerpoint-math-equations_2.png)

Aspose.Slides erstellt diesen mathematischen Text über drei Hauptobjekte:

- Ein mathematisches Shape, erstellt mit [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape), ist das Shape, das die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) speichert mathematischen Inhalt im Textfeld des Shapes.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/)-Objekte.

Die meisten Beispiele unten verwenden [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) und die Fluent‑Methoden aus [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), um den Code kurz und lesbar zu halten.

Für MathML‑Export‑Szenarien siehe [Exportieren von mathematischen Gleichungen aus Präsentationen in Node.js über Java](/slides/de/nodejs-java/exporting-math-equations/).

## **Erstellen einer Gleichung**

Dieses Beispiel verwendet [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape), um ein mathematisches Shape zu erstellen und fügt den pythagoreischen Lehrsatz hinzu:

![Die Gleichung c² = a² + b²](powerpoint-math-equations_3.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) erstellt ein Shape, das bereits einen mathematischen Absatz enthält. Greifen Sie auf das erste [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) zu, rufen Sie [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) auf und fügen Sie math‑Blöcke oder math‑Elemente hinzu.
{{% /alert %}}

## **Brüche hinzufügen**

Verwenden Sie [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide), um einen Bruch zu erstellen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) auswählen.

![Ein schräger mathematischer Bruch, der eins durch x zeigt](powerpoint-math-equations_4.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für einen gestapelten Bruch verwenden Sie [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Wurzeln hinzufügen**

Verwenden Sie [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical), um eine Quadratwurzel, Kubikwurzel oder andere Wurzel zu erstellen. Das aktuelle Element wird zur Basis und das Argument zum Grad.

![Ein n‑te Wurzel‑Ausdruck mit x unter dem Wurzelzeichen](powerpoint-math-equations_5.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Funktionen und Grenzwerte hinzufügen**

Verwenden Sie [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) oder [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) für Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen. Für Grenzwerte setzen Sie `lim` in ein [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) oder verwenden [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![Der Grenzwert von x, wenn x gegen unendlich geht](powerpoint-math-equations_8.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für einen benutzerdefinierten Funktionsnamen machen Sie den Funktionsnamen zum aktuellen Element und rufen [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) mit seinem Argument auf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N‑äre Operatoren und Integrale hinzufügen**

Verwenden Sie [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary), für Summen, Vereinigungen, Schnittmengen und andere große Operatoren. Verwenden Sie [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral), für Integrale. Beide Methoden ermöglichen das Festlegen von unteren und oberen Grenzen.

![Eine Summation mit unteren und oberen Grenzen](powerpoint-math-equations_7.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N‑äre Operatoren gelten für große Operatoren mit optionalen Grenzen. Einfache Operatoren wie `+`, `-` und `=` werden normalerweise als [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) hinzugefügt und in den Ausdruck eingefügt.

Für ein Integral verwenden Sie [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) für Zeilen und Spalten. Matrizen enthalten standardmäßig keine Klammern, daher müssen Sie die Matrix einschließen, wenn Sie Klammern, eckige Klammern oder geschweifte Klammern benötigen.

![Eine zweizeilige mathematische Matrix mit einer leeren Zelle](powerpoint-math-equations_10.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gleichungsarrays hinzufügen**

Verwenden Sie [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray), wenn Sie ausgerichtete Gleichungen oder einen vertikalen Stapel von Ausdrücken benötigen.

![Ein vertikales mathematisches Array mit x über y](powerpoint-math-equations_11.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ein Array mit umgebenden Elementen ausrichten**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) steuert die vertikale Ausrichtung eines Arrays im Verhältnis zu den nebenstehenden mathematischen Elementen. Das nachstehende Beispiel vergleicht die Ausrichtung mit der ersten Zeile, der Mitte des Arrays und der letzten Zeile.

Das folgende Beispiel erstellt drei identische Arrays, jeweils mit drei Zeilen und den Nachbarelementen `A=` und `=B`. Der gesamte mathematische Text verwendet Cambria Math in 24 pt. Nur die Array‑Ausrichtung ändert sich.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [slides.MathVerticalAlignment.Top, slides.MathVerticalAlignment.Center, slides.MathVerticalAlignment.Bottom];
    const alignmentNames = ["Top", "Center", "Bottom"];

    for (let i = 0; i < alignments.length; i++) {
        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(alignmentNames[i]);
        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));
        const mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der folgende Vergleich zeigt die gespeicherte Präsentation in PowerPoint. Beachten Sie die Position von `A=` und `=B` neben jedem Array.

![Gleichungsarrays in PowerPoint mit oben, Mitte und unten Ausrichtung und identischen Nachbarelementen](equation-array-alignment.png)

### **Zeilenabstand konfigurieren**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) wählt die Abstandsregel für Zeilen innerhalb des Arrays aus. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) liefert einen numerischen Wert für eine explizite Abstandsregel und wird von den voreingestellten Regeln ignoriert.

Für exakten Abstand wird der Wert in Punkten gemessen. Für proportionalen Abstand wird in halben Zeilen gemessen: Der Wert `3` im Beispiel entspricht 1,5 Zeilen. Setzen Sie beide Eigenschaften, wenn Sie einen expliziten Wert angeben; das Ändern des numerischen Werts allein wählt keine Abstandsregel.

Das nachstehende Beispiel speichert fünf Präsentationen mit denselben Gleichungen, derselben Ausrichtung und denselben Schriftarteinstellungen. Die ersten drei verwenden Vorgaben; die letzten beiden zeigen explizite Werte.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const rules = [slides.MathRowSpacingRule.SingleLineGap, slides.MathRowSpacingRule.OneAndAHalfLineGap, slides.MathRowSpacingRule.TwoLineGap, slides.MathRowSpacingRule.Exactly, slides.MathRowSpacingRule.Multiple];
const spacingValues = [0, 0, 0, 20, 3];
const ruleNames = ["SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple"];

for (let i = 0; i < rules.length; i++) {
    const fileName = "equation-array-" + ruleNames[i] + ".pptx";
    const presentation = new slides.Presentation();
    try {
        const mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        const paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        const mathParagraph = paragraph.getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(slides.MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(java.newLong(spacingValues[i]));
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

Der Zeilenabstand des Arrays ist vom Absatzabstand getrennt. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) und [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) fügen Abstand um den enthaltenden Absatz hinzu, nicht zwischen den Array‑Zeilen. Ebenso positioniert [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) den gesamten mathematischen Absatz horizontal; es ersetzt nicht die vertikale Ausrichtung des Arrays.

## **Trigonometrische Funktionen hinzufügen**

Verwenden Sie [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction), wenn das Argument das aktuelle Element ist und der Funktionsname bekannt ist.

![Die trigonometrische Funktion cos angewendet auf 2x](powerpoint-math-equations_6.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Indizes und Hochstellungen hinzufügen**

Verwenden Sie die Hilfsfunktionen für Sub‑ und Superskripte … Wenn die Indizes auf der linken Seite der Basis erscheinen sollen, verwenden Sie [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Ein großes Y mit linksseitigem Index 1 und Hochstellung n](powerpoint-math-equations_9.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Begrenzer hinzufügen**

Verwenden Sie [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose), um einen Ausdruck in Begrenzungen zu setzen. Sie können auch ein Trennzeichen für Begrenzungsausdrücke festlegen, die mehrere Elemente enthalten.

![Ein Begrenzungsausdruck, der x, y und z enthält, getrennt durch senkrechte Striche](powerpoint-math-equations_13.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Größe und Ausrichtung von Begrenzern**

Übergeben Sie `true` an [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), damit die Klammern um einen hohen Operanden wachsen, oder übergeben Sie `false`, um ihre normale Größe beizubehalten. Verwenden Sie [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) mit einem der beiden Werte aus [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/). `Centered` zentriert die Klammern auf der mathematischen Achse, die durch das Gleichheitszeichen verläuft. `Match` richtet sie an dem eingeschlossenen Inhalt aus. Beide Einstellungen wirken nur auf die Begrenzungen. Der innere Ausdruck bleibt unverändert.

Das Beispiel setzt einen Bruch in den Exponenten von `x`, sodass sich der Ausdruck weiter über die Grundlinie hinaus erstreckt als darunter. Alle vier Gleichungen verwenden dieselben Klammern und Schriftarteinstellungen.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    for (let row = 0; row < 2; row++) {
        for (let column = 0; column < 2; column++) {
            const fraction = new slides.MathematicalText("a + b").divide("c + d");
            const power = new slides.MathematicalText("x").setSuperscript(fraction);
            const delimiter = power.enclose(java.newChar('('), java.newChar(')'));
            delimiter.setGrowToMatchOperandHeight(row === 0);
            delimiter.setDelimiterShape(column === 0 ? slides.MathDelimiterShape.Centered : slides.MathDelimiterShape.Match);

            const mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            const portion = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            const equation = new slides.MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vergleichen Sie in PowerPoint die Zeilen, um die Wirkung des Wachstums zu sehen. In der oberen Zeile wachsen die Klammern, um den Exponenten zu umschließen, und sehen für beide Formen gleich aus. In der unteren Zeile ist das Wachstum deaktiviert. Die kleineren Klammern links (`Centered`) sind an das Gleichheitszeichen ausgerichtet, während die rechts (`Match`) höher um den Ausdruck liegen.

![Vier Gleichungen in PowerPoint mit aktiviertem und deaktiviertem Klammernwachstum, links zentriert und rechts passend](delimiter-sizing.png)

## **Rahmenbox hinzufügen**

Rufen Sie [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) für einen Bruch auf, um den gesamten Ausdruck einzurahmen. Das zurückgegebene [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) zeigt standardmäßig alle vier Seiten. Verwenden Sie [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) und [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight), um einzelne Seiten zu entfernen.

Das Beispiel legt sechs Kopien desselben Bruchs auf einer Folie an. Um eine Durchstreichung zu zeigen, verbergen Sie alle vier Seiten und übergeben `true` an [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) für eine aufsteigende Diagonale (↗) oder an [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) für eine absteigende Diagonale (↘). Sie können auch [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) oder [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) mit beliebigen Kombinationen sichtbarer Seiten verwenden.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    function addFraction(x, y, hideBorder) {
        const fraction = new slides.MathematicalText("x+1").divide("y+2");
        const box = fraction.toBorderBox();
        box.setHideTop(hideBorder);
        box.setHideBottom(hideBorder);
        box.setHideLeft(hideBorder);
        box.setHideRight(hideBorder);

        const shape = slide.getShapes().addMathShape(x, y, 160, 90);
        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(28);
        const block = new slides.MathBlock(box);
        portion.getMathParagraph().add(block);
        return box;
    }

    addFraction(10, 10, false);

    const partial = addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    addFraction(190, 120, true).setStrikethroughHorizontal(true);
    addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sechs editierbare Brüche in PowerPoint. Obere Zeile: voller Rahmen, untere und linke Seite, aufsteigende Diagonale. Untere Zeile: absteigende Diagonale, horizontale Durchstreichung, vertikale Durchstreichung mit vollem Rahmen](border-box-fractions.png)

Bei diesem Bruch überlappt die horizontale Durchstreichung den Bruchstrich. Die vertikale Durchstreichung schneidet Zähler und Nenner, während der umgebende Rahmen sichtbar bleibt. Diese Linien dekorieren den gesamten Ausdruck. Durchgestrichener Normaltext wirkt sich nur auf Zeichen in einem Textlauf aus. Nach dem erneuten Öffnen der Präsentation in PowerPoint können Zähler und Nenner weiterhin unabhängig bearbeitet werden.

## **Terme gruppieren**

Verwenden Sie [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group), um ein Gruppierungszeichen über oder unter einem Ausdruck zu platzieren. Fügen Sie eine Grenze hinzu, um die gruppierten Terme zu beschriften.

![Der Ausdruck x + y gruppiert mit dem Beschriftungstext darunter](powerpoint-math-equations_15.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mathematische Elemente formatieren**

Verwenden Sie Formatierungs‑Hilfsfunktionen nur dort, wo sie die Formel verdeutlichen. Zum Beispiel setzt [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) einen Strich über ein mathematisches Element.

![Ein mathematischer Ausdruck ABC mit einem Überstrich](powerpoint-math-equations_14.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Text in einer bestehenden Gleichung formatieren**

Um Text in einer bestehenden Gleichung zu formatieren, traversieren Sie den Elementbaum jedes Math‑Blocks. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) liefert nur die direkten Kinder, rufen Sie sie also rekursiv auf, um Text in Brüchen, Skripten, Wurzeln und anderen verschachtelten Strukturen zu erreichen. Prüfen Sie das aktuelle Element sowie seine Kinder, um das Ausgangselement einzuschließen, wenn es sich um [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) handelt.

Dieses Beispiel geht davon aus, dass `input.pptx` eine Gleichung wie `z = xᵢ / ∛y` enthält, wobei ein Bruch im Zähler einen Index und im Nenner eine Wurzel hat. Die Verarbeitung nur der obersten Elemente des Blocks würde den Text im Bruch übersehen. Das Beispiel findet mathematische Abschnitte in Folientextfeldern, greift über [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) auf deren Blöcke zu und verwendet [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight), um die Schriftgröße über jedes Textelements [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat)-Methode auf 28 pt zu setzen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatMathText(element) {
    if (java.instanceOf(element, "com.aspose.slides.MathematicalText")) {
        element.getFormat().setFontHeight(28);
    }

    let children = element.getChildren();
    for (let i = 0; i < children.length; i++) {
        formatMathText(children[i]);
    }
}

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }

            let textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let k = 0; k < textFrame.getParagraphs().getCount(); k++) {
                let paragraph = textFrame.getParagraphs().get_Item(k);
                for (let l = 0; l < paragraph.getPortions().getCount(); l++) {
                    let portion = paragraph.getPortions().get_Item(l);
                    if (java.instanceOf(portion, "com.aspose.slides.IMathPortion")) {
                        let mathParagraph = portion.getMathParagraph();
                        for (let m = 0; m < mathParagraph.getCount(); m++) {
                            formatMathText(mathParagraph.get_Item(m));
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die gespeicherte Präsentation enthält die aktualisierte Textformatierung auf jeder Ebene jeder verarbeiteten Gleichung, wobei der Textinhalt und die mathematische Struktur erhalten bleiben.

## **Kurzreferenz**

| Aufgabe | Haupt‑API |
| --- | --- |
| Mathe‑Text erstellen | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Elemente kombinieren | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Brüche erstellen | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Hoch‑ bzw. Tiefstellung hinzufügen | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Funktionen hinzufügen | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Wurzeln hinzufügen | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Grenzwerte hinzufügen | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Linksseitige Skripte hinzufügen | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Summen und Integrale hinzufügen | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Gleichungs‑Arrays hinzufügen | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Begrenzer hinzufügen | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Striche und Rahmen hinzufügen | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Terme gruppieren | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Kann ich eine bestehende PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, suchen Sie das Shape, das einen [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) enthält, rufen Sie [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) auf und aktualisieren Sie die Math‑Blöcke in diesem Absatz.

**Werden Gleichungen als editierbare PowerPoint‑Mathematik gespeichert?**

Ja. Beim Speichern als PPTX schreibt Aspose.Slides die Gleichung als editierbaren Office‑Math‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Ja. Holen Sie sich das [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) aus seinem [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), und rufen Sie [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) auf, um es direkt zu exportieren. Für ein vollständiges Beispiel siehe [Mathematische Gleichungen aus Präsentationen in Node.js über Java exportieren](/slides/de/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).