---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in Python hinzufügen
linktitle: PowerPoint Mathematische Gleichungen
type: docs
weight: 80
url: /de/python-java/powerpoint-math-equations/
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
- Python
- Java
- Aspose.Slides
description: "Math‑Gleichungen in PowerPoint‑PPT und PPTX mit Aspose.Slides für Python via Java einfügen und bearbeiten, unterstützt OMML, Formatierungssteuerungen und klare Python‑Code‑Beispiele."
---
## **Übersicht**

PowerPoint speichert Gleichungen als Office Math Markup Language (OMML). Mit Aspose.Slides für Python via Java können Sie dieselben mathematischen Inhalte programmgesteuert erstellen: Brüche, Radikale, Funktionen, Grenzen, N‑äre Operatoren, Matrizen, Arrays und formatierte Mathematikblöcke.

In PowerPoint fügen Benutzer normalerweise Gleichungen über **Einfügen > Gleichung** hinzu:

![PowerPoint‑Registerkarte Einfügen mit dem Befehl Gleichung ausgewählt](powerpoint-math-equations_1.png)

Das Ergebnis ist editierbarer mathematischer Text auf der Folie:

![Eine PowerPoint‑Folient mit einer editierbaren mathematischen Gleichung](powerpoint-math-equations_2.png)

Aspose.Slides erstellt diesen mathematischen Text über drei Hauptobjekte:

- Eine mathematische Form, erstellt mit [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape), ist die Form, die die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) speichert mathematischen Inhalt im Textfeld der Form.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) Objekte.

Die meisten Beispiele unten verwenden [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) und die Fluent‑Methoden von [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) , um den Code kurz und lesbar zu halten.

Für MathML‑Export‑Szenarien siehe [Export Math Equations from Presentations in Python](/slides/de/python-java/exporting-math-equations/).

## **Eine Gleichung erstellen**

Dieses Beispiel verwendet [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape), um eine mathematische Form zu erstellen und fügt den Satz des Pythagoras hinzu:

![Die Gleichung c² = a² + b²](powerpoint-math-equations_3.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    equation = MathematicalText("c").setSuperscript("2").join("=").join(a_squared).join("+").join(b_squared)

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) erstellt eine Form, die bereits ein mathematisches Absatz enthält. Greifen Sie auf das erste [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) zu, rufen Sie [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) auf und fügen Sie Mathematikblöcke oder Mathe‑Elemente hinzu.
{{% /alert %}}

## **Brüche hinzufügen**

Verwenden Sie [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide), um einen Bruch zu erstellen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) wählen.

![Ein schräger mathematischer Bruch, der 1 durch x darstellt](powerpoint-math-equations_4.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFractionTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    fraction = MathematicalText("1").divide("x", MathFractionTypes.Skewed)

    math_block = MathBlock(fraction)
    math_paragraph.add(math_block)

    presentation.save("fraction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Für einen gestapelten Bruch verwenden Sie [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Radikale hinzufügen**

Verwenden Sie [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical), um eine Quadratwurzel, Kubikwurzel oder andere Wurzel zu erstellen. Das aktuelle Element wird zur Basis und das Argument bestimmt den Exponenten.

![Ein n‑te‑Wurzel‑Ausdruck mit x unter dem Wurzelzeichen](powerpoint-math-equations_5.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    radical = MathematicalText("x").radical("n")

    math_block = MathBlock(radical)
    math_paragraph.add(math_block)

    presentation.save("radical.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Grad einer Quadratwurzel anzeigen oder ausblenden**

Eine Quadratwurzel kann die explizite 2 anzeigen oder die konventionelle √x‑Notation verwenden. Die [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree)‑Methode von [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) steuert, welche Form angezeigt wird. Beide Formen behalten den Grad 2 und den Radikanden x in der editierbaren Gleichung bei.

![Die gleiche Quadratwurzel, links mit sichtbar‑em Grad und rechts ausgeblendet](square-root-degree.png)

Das Beispiel speichert dieselbe Quadratwurzel zweimal. In `visible-degree.pptx` ist die 2 sichtbar. In `hidden-degree.pptx` ist sie ausgeblendet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    radical = MathematicalText("x").radical("2")
    math_block = MathBlock(radical)

    math_shape = slide.getShapes().addMathShape(20, 20, 200, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()
    math_paragraph.add(math_block)

    radical.setHideDegree(False)
    presentation.save("visible-degree.pptx", SaveFormat.Pptx)

    radical.setHideDegree(True)
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Funktionen und Grenzen hinzufügen**

Verwenden Sie [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) oder [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) für Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen. Für Grenzen setzen Sie `lim` in ein [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) oder verwenden [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit).

![Der Grenzwert von x, wenn x gegen unendlich strebt](powerpoint-math-equations_8.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    limit = MathematicalText("lim").setLowerLimit("x\u2192\u221E").function("x")

    math_block = MathBlock(limit)
    math_paragraph.add(math_block)

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Für einen benutzerdefinierten Funktionsnamen setzen Sie den Funktionsnamen als aktuelles Element und rufen [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) mit seinem Argument auf:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **N‑äre Operatoren und Integrale hinzufügen**

Verwenden Sie [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), um Summen, Vereinigungen, Schnitte und andere große Operatoren darzustellen. Verwenden Sie [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral), um Integrale darzustellen. Beide Methoden ermöglichen das Festlegen von Unter‑ und Obergrenzen.

![Eine Summation mit Unter‑ und Obergrenzen](powerpoint-math-equations_7.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathNaryOperatorTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_power = MathematicalText("a").setSuperscript("n-k")
    summation_base = MathematicalText("x").setSuperscript("k").join(a_power)

    summation = summation_base.nary(MathNaryOperatorTypes.Summation, "k=0", "n")

    math_block = MathBlock(summation)
    math_paragraph.add(math_block)

    presentation.save("nary-operators.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

N‑äre Operatoren sind für große Operatoren mit optionalen Grenzen gedacht. Einfache Operatoren wie `+`, `-` und `=` werden üblicherweise als [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) hinzugefügt und in den Ausdruck integriert.

Für ein Integral verwenden Sie [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathIntegralTypes, MathematicalText

differential = MathematicalText("dx").toBox()
integral_base = MathematicalText("x").join(differential)
integral = integral_base.integral(MathIntegralTypes.Simple, "0", "1")
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/), um Zeilen und Spalten zu erzeugen. Matrizen enthalten standardmäßig keine Klammern, sodass Sie die Matrix einschließen sollten, wenn Sie runde Klammern, eckige Klammern oder geschweifte Klammern benötigen.

![Eine zweizeilige mathematische Matrix mit einer leeren Zelle](powerpoint-math-equations_10.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathMatrix, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    matrix = MathMatrix(2, 3)
    cell_0_0 = MathematicalText("1")
    matrix.set_Item(0, 0, cell_0_0)
    cell_0_1 = MathematicalText("x")
    matrix.set_Item(0, 1, cell_0_1)
    cell_1_0 = MathematicalText("x")
    matrix.set_Item(1, 0, cell_1_0)
    cell_1_1 = MathematicalText("2")
    matrix.set_Item(1, 1, cell_1_1)
    cell_1_2 = MathematicalText("y")
    matrix.set_Item(1, 2, cell_1_2)

    math_block = MathBlock(matrix)
    math_paragraph.add(math_block)

    presentation.save("matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Eine bestehende Matrix bearbeiten**

Stellen Sie sich vor, ein Unterricht in Linearer Algebra beginnt mit der Koeffizientenmatrix in `matrix.pptx`, die im vorherigen Beispiel gespeichert wurde. Für die nächste Aufgabe behalten Sie die erste Gleichung, ersetzen die zweite durch zwei neue Gleichungen und überarbeiten die Menge der Variablen. Öffnen Sie die bestehende Matrix über [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/), um die noch gültigen Koeffizienten beizubehalten.

![Ursprüngliche zweizeilige Koeffizientenmatrix mit den Einträgen 1, x und einer leeren Zelle in der ersten Zeile sowie x, 2 und y in der zweiten](matrix-before-edit.png)

Zeilen‑ und Spaltenindizes beginnen bei null und beziehen sich auf die Matrix, wie sie bei jedem Aufruf ist. Das Einfügen einer Zeile vor Index 1 verschiebt die ursprüngliche zweite Zeile zu Index 2. Das Einfügen nach Index 2 fügt dann eine Zeile an. Das Löschen von Zeile 2 entfernt die ursprüngliche zweite Gleichung und verschiebt die angefügte Zeile eine Position nach oben. Spalten verschieben sich analog.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathHorizontalAlignment, MathematicalText, Presentation, SaveFormat

presentation = Presentation("matrix.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    matrix = portion.getMathParagraph().get_Item(0).get_Item(0)

    matrix.insertRowBefore(1)
    matrix.insertRowAfter(2)
    matrix.deleteRow(2)

    matrix.insertColumnBefore(1)
    matrix.insertColumnAfter(3)
    matrix.deleteColumn(3)

    # Neue Zellen sind zunächst leer. Setzen Sie zuerst die nicht‑null‑Koeffizienten.
    matrix.set_Item(1, 0, MathematicalText("12"))
    matrix.set_Item(1, 1, MathematicalText("1"))
    matrix.set_Item(2, 2, MathematicalText("10"))
    matrix.set_Item(2, 3, MathematicalText("1"))
    for row in range(matrix.getRowCount()):
        for column in range(matrix.getColumnCount()):
            if matrix.get_Item(row, column) is None:
                matrix.set_Item(row, column, MathematicalText("0"))

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left)
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right)
    
    presentation.save("updated-matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) richtet die erste Spalte linksbündig aus. [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) richtet die restlichen drei Spalten rechtsbündig aus, beginnend bei Index 1. In `updated-matrix.pptx` hat die Matrix drei Gleichungen und vier Variablen. Die ursprünglichen Koeffizienten der ersten Zeile `1` und `x` erscheinen nun in der ersten und dritten Spalte.

![Aktualisierte dreizeilige Matrix mit den Zeilen 1, 0, x, 0; 12, 1, 0, 0; und 0, 0, 10, 1](matrix-after-edit.png)

## **Gleichungs‑Arrays hinzufügen**

Verwenden Sie [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray), wenn Sie ausgerichtete Gleichungen oder einen vertikalen Stapel von Ausdrücken benötigen.

![Ein vertikales mathematisches Array mit x über y](powerpoint-math-equations_11.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 140)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    equation_array = MathematicalText("x").join("y").toMathArray()

    math_block = MathBlock(equation_array)
    math_paragraph.add(math_block)

    presentation.save("equation-array.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ein Array mit umgebenden Elementen ausrichten**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) steuert die vertikale Ausrichtung eines Arrays relativ zu den benachbarten mathematischen Elementen. Das nachfolgende Beispiel vergleicht die Ausrichtung mit der ersten Zeile, der Mitte des Arrays und der letzten Zeile.

Das folgende Beispiel erzeugt drei identische Arrays, jeweils mit drei Zeilen und den benachbarten Elementen `A=` und `=B`. Der gesamte mathematische Text verwendet Cambria Math mit 24 Punkten. Nur die Array‑Ausrichtung ändert sich.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathVerticalAlignment, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)
    
    alignments = (("Top", MathVerticalAlignment.Top), ("Center", MathVerticalAlignment.Center), ("Bottom", MathVerticalAlignment.Bottom))
    for index, (name, alignment) in enumerate(alignments):
        x = 20 + index * 260
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 10, 240, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(16)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        math_shape = slide.getShapes().addMathShape(x, 60, 240, 130)
        math_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(alignment)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der nachfolgende Vergleich zeigt die gespeicherte Präsentation in PowerPoint. Beachten Sie die Position von `A=` und `=B` neben jedem Array.

![Gleichungs‑Arrays in PowerPoint mit oberer, mittlerer und unterer Ausrichtung und identischen benachbarten Elementen](equation-array-alignment.png)

### **Zeilenabstand konfigurieren**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) wählt die Abstandregel für Zeilen innerhalb des Arrays. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) liefert einen numerischen Wert für eine explizite Abstandregel und wird von den voreingestellten Regeln ignoriert.

Für exakten Abstand wird der Wert in Punkten gemessen. Für proportionalen Abstand wird er in Halblinien gemessen: Der Wert `3` im Beispiel entspricht 1,5 Zeilen. Setzen Sie beide Eigenschaften, wenn Sie einen expliziten Wert angeben; das alleinige Ändern des numerischen Werts wählt keine Abstandregel aus.

Das nachfolgende Beispiel speichert fünf Präsentationen mit denselben Gleichungen, derselben Ausrichtung und denselben Schriftarteinstellungen. Die ersten drei verwenden Voreinstellungen; die letzten beiden zeigen explizite Werte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathRowSpacingRule, MathVerticalAlignment, Presentation, SaveFormat

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


settings = (("SingleLineGap", MathRowSpacingRule.SingleLineGap, 0), ("OneAndAHalfLineGap", MathRowSpacingRule.OneAndAHalfLineGap, 0), ("TwoLineGap", MathRowSpacingRule.TwoLineGap, 0), ("Exactly", MathRowSpacingRule.Exactly, 20), ("Multiple", MathRowSpacingRule.Multiple, 3))
for name, rule, spacing in settings:
    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        math_shape = slide.getShapes().addMathShape(20, 20, 600, 300)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(MathVerticalAlignment.Center)
        equation_array.setRowSpacingRule(rule)
        equation_array.setRowSpacing(spacing)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

        presentation.save(f"equation-array-{name}.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Der Zeilenabstand im Array ist getrennt vom Absatzabstand. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) und [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) fügen Abstand um den enthaltenden Absatz hinzu, nicht zwischen Array‑Zeilen. Ebenso positioniert [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) den gesamten mathematischen Absatz horizontal; es ersetzt nicht die vertikale Ausrichtung des Arrays.

## **Trigonometrische Funktionen hinzufügen**

Verwenden Sie [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction), wenn das Argument das aktuelle Element ist und der Funktionsname bekannt ist.

![Die trigonometrische Funktion cos angewendet auf 2x](powerpoint-math-equations_6.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFunctionsOfOneArgument, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    cosine = MathematicalText("2x").asArgumentOfFunction(MathFunctionsOfOneArgument.Cos)

    math_block = MathBlock(cosine)
    math_paragraph.add(math_block)

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tief- und Hochstellungen hinzufügen**

Verwenden Sie die Hilfsfunktionen für Tief- und Hochstellungen für Indizes und Potenzen. Wenn die Indizes auf der linken Seite der Basis erscheinen sollen, verwenden Sie [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Ein großes Y mit dem linken Tiefstellungswert 1 und Hochstellung n](powerpoint-math-equations_9.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    scripts = MathematicalText("Y").setSubSuperscriptOnTheLeft("1", "n")

    math_block = MathBlock(scripts)
    math_paragraph.add(math_block)

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Begrenzer hinzufügen**

Verwenden Sie [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose), um einen Ausdruck in Begrenzungszeichen zu setzen. Sie können auch ein Trennzeichen für Begrenzungsausdrücke festlegen, die mehrere Elemente enthalten.

![Ein Begrenzungsausdruck, der x, y und z enthält, getrennt durch senkrechte Striche](powerpoint-math-equations_13.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    delimiter = MathematicalText("x").join("y").join("z").enclose('<', '>')
    delimiter.setSeparatorCharacter('|')

    math_block = MathBlock(delimiter)
    math_paragraph.add(math_block)

    presentation.save("delimiters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Größe und Ausrichtung von Begrenzern**

Geben Sie `True` an [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), damit die Klammern um einen hohen Operanden wachsen, oder geben Sie `False` an, um ihre normale Größe beizubehalten. Verwenden Sie [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) mit einem von zwei [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) Werten. `Centered` zentriert die Klammern auf der mathematischen Achse, die durch die Mitte des Gleichheitszeichens verläuft. `Match` richtet sie am eingeschlossenen Inhalt aus. Beide Einstellungen wirken nur auf die Begrenzungszeichen. Der Ausdruck im Inneren bleibt unverändert.

Das Beispiel platziert einen Bruch im Exponenten von `x`, sodass der Ausdruck weiter über die Grundlinie hinausgeht als darunter. Alle vier Gleichungen verwenden dieselben Klammern und Schriftarteinstellungen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathDelimiterShape, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    for row, grow in enumerate((True, False)):
        for column, shape in enumerate((MathDelimiterShape.Centered, MathDelimiterShape.Match)):
            fraction = MathematicalText("a + b").divide("c + d")
            power = MathematicalText("x").setSuperscript(fraction)
            delimiter = power.enclose("(", ")")
            delimiter.setGrowToMatchOperandHeight(grow)
            delimiter.setDelimiterShape(shape)

            math_shape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100)
            portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            portion.getPortionFormat().setFontHeight(32)
            equation = MathematicalText("y = ").join(delimiter)
            portion.getMathParagraph().add(equation)

    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vergleichen Sie in PowerPoint die Zeilen, um die Wirkung des Wachstums zu sehen. In der oberen Zeile wachsen die Klammern, um den Exponenten zu umschließen, und sehen bei beiden Formen gleich aus. In der unteren Zeile ist das Wachstum deaktiviert. Die kleineren Klammern links (`Centered`) richten sich nach dem Gleichheitszeichen aus, während die rechten (`Match`) höher um den Ausdruck herum sitzen.

![Vier Gleichungen in PowerPoint mit aktiviertem Begrenzungswachstum oben und deaktiviert unten, sowie `Centered` links und `Match` rechts](delimiter-sizing.png)

## **Ein Rahmenfeld hinzufügen**

Rufen Sie [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) bei einem Bruch auf, um den gesamten Ausdruck zu umrahmen. Das zurückgegebene [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) zeigt standardmäßig alle vier Seiten. Verwenden Sie [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) und [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight), um einzelne Seiten zu entfernen.

Das Beispiel platziert sechs Kopien desselben Bruchs auf einer Folie. Um eine Streichung zu zeigen, verbergen Sie alle vier Seiten und geben `True` an [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) für eine steigende Diagonale (↗) oder [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) für eine fallende Diagonale (↘). Sie können auch [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) oder [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) mit beliebiger Kombination sichtbarer Seiten verwenden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    def add_fraction(x, y, hide_border):
        fraction = MathematicalText("x+1").divide("y+2")
        box = fraction.toBorderBox()
        box.setHideTop(hide_border)
        box.setHideBottom(hide_border)
        box.setHideLeft(hide_border)
        box.setHideRight(hide_border)

        shape = slide.getShapes().addMathShape(x, y, 160, 90)
        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(28)
        math_block = MathBlock(box)
        portion.getMathParagraph().add(math_block)
        return box

    add_fraction(10, 10, False)

    partial = add_fraction(190, 10, False)
    partial.setHideTop(True)
    partial.setHideRight(True)

    add_fraction(370, 10, True).setStrikethroughBottomLeftToTopRight(True)
    add_fraction(10, 120, True).setStrikethroughTopLeftToBottomRight(True)
    add_fraction(190, 120, True).setStrikethroughHorizontal(True)
    add_fraction(370, 120, False).setStrikethroughVertical(True)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Sechs editierbare Brüche in PowerPoint. Obere Zeile: voller Rand, untere und linke Seiten, steigende Diagonale. Untere Zeile: fallende Diagonale, horizontale Streichung, vertikale Streichung mit vollem Rand](border-box-fractions.png)

Bei diesem Bruch überlappt die horizontale Streichung den Bruchstrich. Die vertikale Streichung durchschneidet sowohl den Zähler als auch den Nenner, während der umgebende Rand sichtbar bleibt. Diese Linien dekorieren den gesamten Ausdruck. Durchgestrichener normaler Text gilt für Zeichen in einem Textlauf. Nach dem erneuten Öffnen der Präsentation in PowerPoint können Sie den Zähler und den Nenner weiterhin unabhängig bearbeiten.

## **Sichtbarkeit und Layout mit Phantom‑Elementen steuern**

Umwickeln Sie einen Ausdruck mit [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/), um seine Sichtbarkeit und den von ihm zu einer Gleichung beigetragenen Raum unabhängig zu steuern. Die Methoden von [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) kontrollieren Folgendes:

| Methode | Wirkung |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | Geben Sie `False` an, um den Ausdruck auszublenden. Seine Abmessungen tragen weiterhin zum Layout bei, es sei denn, die entsprechenden Methoden unten erhalten `True`. |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | Behandeln Sie die horizontale Breite des Ausdrucks als null, sodass benachbarte Elemente näher zusammenrücken können. |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | Behandeln Sie seine Aufstiegshöhe (die Höhe über der Grundlinie) als null. Dies kann den über benachbarten Elementen reservierten Raum reduzieren. |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | Behandeln Sie seine Abstiegs­höhe (die Tiefe unter der Grundlinie) als null. Dadurch kann ein Bruchstrich oder anderer Inhalt unter dem Ausdruck näher an seine Nachbarn rücken. |

Die Grundlinie ist die Referenzlinie, auf der gewöhnliche mathematische Buchstaben sitzen. Das Ausblenden von Inhalt entfernt nicht seine Abmessungen, und das Behandeln einer Dimension als null löscht den Ausdruck nicht. Der zugrunde liegende Ausdruck bleibt über [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase) verfügbar. Geben Sie `True` an [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow), um ihn wieder anzuzeigen; die Dimensionseinstellungen bleiben unverändert.

Das nachfolgende Beispiel erstellt fünf nebeneinanderliegende Varianten: einen sichtbaren Bruch, einen ausgeblendeten Bruch, der Platz reserviert, und drei ausgeblendete Brüche, bei denen eine Dimension als null behandelt wird. Jede Variante verwendet denselben umgebenden Ausdruck und Cambria Math mit 24 Punkten. Alle Gleichungsformen haben dieselbe obere Position, gekennzeichnet durch die graue Führung. Das Platzieren des Phantoms im Zähler eines äußeren Bruchs erleichtert das Erkennen der vertikalen Layout‑Änderungen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathBlock, MathFraction, MathematicalText, MathPhantom, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color


def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    labels = ("Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc")

    guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0)
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)

    for index, name in enumerate(labels):
        left = 10 + index * 200
        
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(14)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = MathFraction(fraction_numerator, fraction_denominator)
        phantom = MathPhantom(fraction)
        phantom.setShow(index == 0)
        phantom.setZeroWidth(index == 2)
        phantom.setZeroAsc(index == 3)
        phantom.setZeroDesc(index == 4)

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = MathFraction(numerator, denominator)

        shape = slide.getShapes().addMathShape(left, 60, 190, 100)
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        math_paragraph = math_portion.getMathParagraph()
        math_block = MathBlock(equation)
        math_paragraph.add(math_block)

    presentation.save("math-phantom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Fünf Gleichungen in PowerPoint, die einen sichtbaren Bruch, einen ausgeblendeten Bruch mit reserviertem Platz und ausgeblendete Brüche mit aktiviertem ZeroWidth, ZeroAsc bzw. ZeroDesc vergleichen](math-phantom.png)

## **Terme gruppieren**

Verwenden Sie [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group), um ein Gruppierungszeichen über oder unter einem Ausdruck zu platzieren. Fügen Sie ein Limit hinzu, um die gruppierten Terme zu beschriften.

![Der Ausdruck x plus y, gruppiert mit der Beschriftung irgendein Text darunter](powerpoint-math-equations_15.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathTopBotPositions, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    grouped = MathematicalText("x + y").group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top).setLowerLimit("any text")

    math_block = MathBlock(grouped)
    math_paragraph.add(math_block)

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mathe‑Elemente formatieren**

Verwenden Sie Formatierungshilfen nur dort, wo sie die Formel verdeutlichen. Beispielsweise setzt [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) einen Strich über ein Mathe‑Element.

![Ein mathematischer Ausdruck ABC mit einem Überstrich](powerpoint-math-equations_14.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    overbar = MathematicalText("ABC").overbar()

    math_block = MathBlock(overbar)
    math_paragraph.add(math_block)

    presentation.save("overbar.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Text in einer bestehenden Gleichung formatieren**

Um Text in einer bestehenden Gleichung zu formatieren, durchlaufen Sie den Elementbaum jedes Mathematikblocks. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) liefert nur die unmittelbaren Kind‑Elemente, weshalb Sie sie rekursiv aufrufen sollten, um Text innerhalb von Brüchen, Skripten, Radikalen und anderen verschachtelten Strukturen zu erreichen. Prüfen Sie das aktuelle Element sowie seine Kinder, um das Ausgangselement einzubeziehen, wenn es ein [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) ist.

Dieses Beispiel geht davon aus, dass `input.pptx` eine Gleichung wie `z = xᵢ / ∛y` enthält, mit einem Bruch, der im Zähler einen Tiefstellung und im Nenner ein Radikal hat. Nur die obersten Elemente des Blocks zu verarbeiten, würde den Text im Bruch übersehen. Das Beispiel findet mathematische Abschnitte in Folientextfeldern, greift über [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) auf ihre Blöcke zu und verwendet [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight), um die Schriftgröße jedes Textelements über dessen [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat)‑Methode auf 28 Punkte zu setzen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathematicalText, MathPortion, Presentation, SaveFormat


def format_math_text(element):
    if isinstance(element, MathematicalText):
        element.getFormat().setFontHeight(28)

    for child in element.getChildren():
        format_math_text(child)


presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    if isinstance(portion, MathPortion):
                        for block in portion.getMathParagraph():
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die gespeicherte Präsentation enthält die aktualisierte Textformatierung auf jeder Ebene jeder verarbeiteten Gleichung, wobei ihr Textinhalt und die mathematische Struktur erhalten bleiben.

## **Kurzreferenz**

| Aufgabe | Haupt‑API |
| --- | --- |
| Mathe‑Text erstellen | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| Elemente kombinieren | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| Brüche erstellen | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| Hoch‑ oder Tiefstellung hinzufügen | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| Funktionen hinzufügen | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| Radikale hinzufügen | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| Grenzen hinzufügen | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| Linksseitige Skripte hinzufügen | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| Summen und Integrale hinzufügen | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| Gleichungs‑Arrays hinzufügen | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| Begrenzer hinzufügen | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| Balken und Rahmen hinzufügen | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| Terme gruppieren | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **FAQ**

**Kann ich eine bestehende PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, finden Sie die Form, die ein [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) enthält, rufen Sie [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) auf und aktualisieren Sie die Mathematikblöcke in diesem Absatz.

**Werden Gleichungen als editierbare PowerPoint‑Mathematik gespeichert?**

Ja. Wenn Sie in PPTX speichern, schreibt Aspose.Slides die Gleichung als editierbaren Office‑Mathematik‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Ja. Holen Sie sich das [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) der Gleichung über ihr [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), und rufen Sie [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) auf, um sie direkt zu exportieren. Für ein vollständiges Beispiel siehe [Export Math Equations from Presentations in Python](/slides/de/python-java/exporting-math-equations/#export-math-equations-to-latex).