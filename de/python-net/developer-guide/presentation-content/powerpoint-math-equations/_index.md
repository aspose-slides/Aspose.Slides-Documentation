---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in Python hinzufügen
linktitle: PowerPoint Mathe Gleichungen
type: docs
weight: 80
url: /de/python-net/powerpoint-math-equations/
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
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für Python über .NET einfügen und bearbeiten, unterstützt OMML, Formatierungssteuerungen und klare Python‑Beispiele."
---
## **Überblick**

PowerPoint speichert Gleichungen als Office Math Markup Language (OMML). Mit Aspose.Slides für Python über .NET können Sie denselben mathematischen Inhalt programmatisch erstellen: Brüche, Radikale, Funktionen, Grenzwerte, N‑äre Operatoren, Matrizen, Arrays und formatierte mathematische Blöcke.

In PowerPoint fügen Benutzer normalerweise Gleichungen über **Einfügen > Gleichung** hinzu:

![PowerPoint-Registerkarte Einfügen mit dem Befehl Gleichung ausgewählt](powerpoint-math-equations_1.png)

Das Ergebnis ist editierbarer mathematischer Text auf der Folie:

![Eine PowerPoint-Folie mit einer editierbaren mathematischen Gleichung](powerpoint-math-equations_2.png)

Aspose.Slides erzeugt diesen mathematischen Text über drei Hauptobjekte:

- Ein mathematisches Shape, erstellt mit [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), ist das Shape, das die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) speichert mathematischen Inhalt im Textfeld des Shapes.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)-Objekte.

Die meisten Beispiele unten verwenden [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) und die Fluent-Methoden von [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/), um den Code kurz und lesbar zu halten.

Für MathML-Export‑Szenarien siehe [Math‑Gleichungen aus Präsentationen in Python über .NET exportieren](/slides/de/python-net/exporting-math-equations/).

## **Eine Gleichung erstellen**

Dieses Beispiel verwendet [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), um ein mathematisches Shape zu erstellen und fügt den Satz des Pythagoras hinzu:

![Die Gleichung c² = a² + b²](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) erzeugt ein Shape, das bereits einen mathematischen Absatz enthält. Greifen Sie auf das erste [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) zu, erhalten Sie dessen [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), und fügen Sie mathematische Blöcke oder mathematische Elemente hinzu.
{{% /alert %}}

## **Brüche hinzufügen**

Verwenden Sie [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/), um einen Bruch zu erstellen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) wählen.

![Ein schräger mathematischer Bruch, der eins durch x zeigt](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

Für einen gestapelten Bruch verwenden Sie [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Radikale hinzufügen**

Verwenden Sie [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/), um eine Quadratwurzel, Kubikwurzel oder andere Wurzel zu erstellen. Das aktuelle Element wird zur Basis, das Argument zum Grad.

![Ein n‑te-Wurzel-Ausdruck mit x unter dem Wurzelzeichen](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

### **Grad einer Quadratwurzel anzeigen oder ausblenden**

Eine Quadratwurzel kann die explizite 2 anzeigen oder die übliche √x‑Notation verwenden. Die [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/)‑Eigenschaft von [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) steuert, welche Form angezeigt wird. Beide Formen behalten den Grad 2 und das Radikand x in der editierbaren Gleichung bei.

![Die Quadratwurzel von x, bei der der Grad 2 links sichtbar und rechts ausgeblendet ist](square-root-degree.png)

Das Beispiel speichert dieselbe Quadratwurzel zweimal. Die 2 ist in `visible-degree.pptx` sichtbar und in `hidden-degree.pptx` ausgeblendet.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    radical = math.MathematicalText("x").radical("2")

    shape = slide.shapes.add_math_shape(20, 20, 200, 100)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.math_paragraph.add(math.MathBlock(radical))

    radical.hide_degree = False
    presentation.save("visible-degree.pptx", slides.export.SaveFormat.PPTX)

    radical.hide_degree = True
    presentation.save("hidden-degree.pptx", slides.export.SaveFormat.PPTX)
```

## **Funktionen und Grenzwerte hinzufügen**

Verwenden Sie [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) oder [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), um Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen zu erzeugen. Für Grenzwerte setzen Sie `lim` in ein [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) oder verwenden Sie [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/).

![Der Grenzwert von x, wenn x gegen unendlich geht](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

Für einen benutzerdefinierten Funktionsnamen machen Sie den Funktionsnamen zum aktuellen Element und rufen [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) mit seinem Argument auf:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N‑äre Operatoren und Integrale hinzufügen**

Verwenden Sie [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), um Summen, Vereinigungen, Schnitte und andere große Operatoren zu erzeugen. Verwenden Sie [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/), um Integrale zu erzeugen. Beide Methoden erlauben das Setzen von Unter‑ und Obergrenzen.

![Eine Summation mit Unter‑ und Obergrenzen](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

N‑äre Operatoren dienen großen Operatoren mit optionalen Grenzen. Einfache Operatoren wie `+`, `-` und `=` werden normalerweise als [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) hinzugefügt und in den Ausdruck eingefügt.

Für ein Integral verwenden Sie [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/), um Zeilen und Spalten zu erzeugen. Matrizen enthalten standardmäßig keine Klammern, daher umschließen Sie die Matrix bei Bedarf mit Klammern, eckigen Klammern oder geschweiften Klammern.

![Eine zweizeilige mathematische Matrix mit einer leeren Zelle](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    matrix[0, 0] = math.MathematicalText("1")
    matrix[0, 1] = math.MathematicalText("x")
    matrix[1, 0] = math.MathematicalText("x")
    matrix[1, 1] = math.MathematicalText("2")
    matrix[1, 2] = math.MathematicalText("y")
    math_paragraph.add(math.MathBlock(matrix))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

### **Eine vorhandene Matrix bearbeiten**

Nehmen wir an, ein Lineare‑Algebra‑Unterricht beginnt mit der Koeffizientenmatrix in `matrix.pptx`, gespeichert vom vorherigen Beispiel. Für die nächste Übung behalten Sie die erste Gleichung bei, ersetzen die zweite durch zwei neue Gleichungen und überarbeiten das Variablen‑Set. Greifen Sie auf die bestehende Matrix als [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) zu, um die noch gültigen Koeffizienten beizubehalten.

![Originale zweizeilige Koeffizientenmatrix mit Einträgen 1, x und einer leeren Zelle in der ersten Zeile sowie x, 2 und y in der zweiten](matrix-before-edit.png)

Zeilen‑ und Spaltenindizes beginnen bei Null und beziehen sich auf die Matrix, wie sie bei jedem Aufruf steht. Das Einfügen einer Zeile vor Index 1 verschiebt die ursprüngliche zweite Zeile zu Index 2. Das Einfügen nach Index 2 fügt dann eine Zeile an. Das Löschen von Zeile 2 entfernt die ursprüngliche zweite Gleichung und verschiebt die eingefügte Zeile um eine Position nach oben. Spalten verschieben sich analog.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation("matrix.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    portion = shape.text_frame.paragraphs[0].portions[0]
    matrix = portion.math_paragraph[0][0]

    matrix.insert_row_before(1)
    matrix.insert_row_after(2)
    matrix.delete_row(2)

    matrix.insert_column_before(1)
    matrix.insert_column_after(3)
    matrix.delete_column(3)

    matrix[1, 0] = math.MathematicalText("12")
    matrix[1, 1] = math.MathematicalText("1")
    matrix[2, 2] = math.MathematicalText("10")
    matrix[2, 3] = math.MathematicalText("1")
    for row in range(matrix.row_count):
        for column in range(matrix.column_count):
            if matrix[row, column] is None:
                matrix[row, column] = math.MathematicalText("0")

    matrix.set_column_alignment(0, math.MathHorizontalAlignment.LEFT)
    matrix.set_columns_alignment(1, 3, math.MathHorizontalAlignment.RIGHT)

    presentation.save("updated-matrix.pptx", slides.export.SaveFormat.PPTX)
```

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) richtet die erste Spalte linksbündig aus. [set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) richtet drei aufeinanderfolgende Spalten rechtsbündig aus, beginnend bei Index 1. In `updated-matrix.pptx` hat die Matrix drei Gleichungen und vier Variablen. Die ursprünglichen Koeffizienten der ersten Zeile `1` und `x` erscheinen nun in der ersten und dritten Spalte.

![Aktualisierte dreizeilige Matrix mit den Zeilen 1, 0, x, 0; 12, 1, 0, 0; und 0, 0, 10, 1](matrix-after-edit.png)

## **Gleichungs‑Arrays hinzufügen**

Verwenden Sie [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/), wenn Sie ausgerichtete Gleichungen oder einen vertikalen Stapel von Ausdrücken benötigen.

![Ein vertikales mathematisches Array mit x über y](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

### **Ein Array mit umgebenden Elementen ausrichten**

[MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) steuert die vertikale Ausrichtung eines Arrays relativ zu den mathematischen Elementen daneben. Das Beispiel unten vergleicht die Ausrichtung mit der ersten Zeile, der Mitte des Arrays und der letzten Zeile.

Das folgende Beispiel erstellt drei identische Arrays, jeweils mit drei Zeilen und den benachbarten Elementen `A=` und `=B`. Der gesamte mathematische Text verwendet Cambria Math in 24‑Punkt. Nur die Array‑Ausrichtung ändert sich.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(780, 200, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    alignments = [math.MathVerticalAlignment.TOP, math.MathVerticalAlignment.CENTER, math.MathVerticalAlignment.BOTTOM]
    labels = ["Top", "Center", "Bottom"]

    for i, alignment in enumerate(alignments):
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20 + i * 260, 10, 240, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = labels[i]
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 16
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        math_shape = slide.shapes.add_math_shape(20 + i * 260, 60, 240, 130)
        math_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = alignment
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", slides.export.SaveFormat.PPTX)
```

Der folgende Vergleich zeigt die gespeicherte Präsentation in PowerPoint. Beachten Sie die Position von `A=` und `=B` neben jedem Array.

![Gleichungs‑Arrays in PowerPoint mit oberer, mittlerer und unterer Ausrichtung und identischen benachbarten Elementen](equation-array-alignment.png)

### **Zeilenabstand konfigurieren**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) wählt die Abstandregel für Zeilen innerhalb des Arrays. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) liefert einen numerischen Wert für eine explizite Abstandregel und wird von den Voreinstellungen ignoriert.

Für exakten Abstand wird der Wert in Punkten gemessen. Für proportionalen Abstand wird er in halben Zeilen gemessen: Der Wert `3` im Beispiel entspricht 1,5 Zeilen. Setzen Sie beide Eigenschaften, wenn Sie einen expliziten Wert angeben; das Ändern des numerischen Werts allein wählt keine Abstandregel.

Das Beispiel unten speichert fünf Präsentationen mit denselben Gleichungen, Ausrichtungen und Schrifteinstellungen. Die ersten drei verwenden Voreinstellungen; die letzten beiden zeigen explizite Werte.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


settings = [
    (math.MathRowSpacingRule.SINGLE_LINE_GAP, 0),
    (math.MathRowSpacingRule.ONE_AND_A_HALF_LINE_GAP, 0),
    (math.MathRowSpacingRule.TWO_LINE_GAP, 0),
    (math.MathRowSpacingRule.EXACTLY, 20),
    (math.MathRowSpacingRule.MULTIPLE, 3)
]

for rule, spacing in settings:
    file_name = f"equation-array-{rule.name}.pptx"
    with slides.Presentation() as presentation:
        math_shape = presentation.slides[0].shapes.add_math_shape(20, 20, 600, 300)
        paragraph = math_shape.text_frame.paragraphs[0]
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        math_paragraph = paragraph.portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = math.MathVerticalAlignment.CENTER
        equation_array.row_spacing_rule = rule
        equation_array.row_spacing = spacing
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Der Zeilenabstand im Array ist getrennt vom Absatzabstand. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) und [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) fügen Abstand um den umgebenden Absatz hinzu, nicht zwischen Array‑Zeilen. Ebenso positioniert [MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) den gesamten mathematischen Absatz horizontal; es ersetzt nicht die vertikale Ausrichtung des Arrays.

## **Trigonometrische Funktionen hinzufügen**

Verwenden Sie [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/), wenn das Argument das aktuelle Element ist und der Funktionsname bekannt ist.

![Die trigonometrische Funktion cos, angewendet auf 2x](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **Indizes und Hochstellungen hinzufügen**

Verwenden Sie die Hilfsfunktionen für Sub‑ und Superskript für Indizes und Potenzen. Wenn die Indizes auf der linken Seite der Basis erscheinen sollen, verwenden Sie [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/).

![Ein großes Y mit linksseitigem Subskript 1 und Superskript n](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **Begrenzer hinzufügen**

Verwenden Sie [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/), um einen Ausdruck in Begrenzungszeichen zu setzen. Sie können auch ein Trennzeichen‑Zeichen für Begrenzungs‑Ausdrücke festlegen, die mehrere Elemente enthalten.

![Ein Begrenzungs‑Ausdruck, der x, y und z enthält, getrennt durch senkrechte Striche](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

### **Größe und Ausrichtung von Begrenzern**

Setzen Sie [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/) auf `True`, damit die Klammern um einen hohen Operanden wachsen, oder auf `False`, um ihre normale Größe beizubehalten. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) nimmt einen von zwei [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/)‑Werten an. `CENTERED` zentriert die Klammern auf der mathematischen Achse, die durch die Mitte des Gleichheitszeichens verläuft. `MATCH` richtet sie an dem eingeschlossenen Inhalt aus. Beide Einstellungen wirken sich nur auf die Begrenzungszeichen aus. Der Ausdruck innen bleibt gleich.

Das Beispiel platziert einen Bruch im Exponenten von `x`, sodass der Ausdruck weiter über die Grundlinie hinausragt als darunter. Alle vier Gleichungen verwenden dieselben Klammern und Schrifteinstellungen.

```python
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_expression(slide, left, top, grow, shape):
    fraction = math.MathematicalText("a + b").divide("c + d")
    power = math.MathematicalText("x").set_superscript(fraction)
    delimiter = power.enclose("(", ")")
    delimiter.grow_to_match_operand_height = grow
    delimiter.delimiter_shape = shape

    math_shape = slide.shapes.add_math_shape(left, top, 300, 100)
    portion = math_shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 32
    equation = math.MathematicalText("y = ").join(delimiter)
    portion.math_paragraph.add(equation)


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    add_expression(slide, 20, 20, True, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 20, True, math.MathDelimiterShape.MATCH)
    add_expression(slide, 20, 140, False, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 140, False, math.MathDelimiterShape.MATCH)

    presentation.save("delimiter-sizing.pptx", slides.export.SaveFormat.PPTX)
```

In PowerPoint vergleichen Sie die Zeilen, um die Wirkung des Wachstums zu sehen. In der oberen Zeile wachsen die Klammern, um den Exponenten zu umschließen, und sehen für beide Formen gleich aus. In der unteren Zeile ist das Wachstum deaktiviert. Die kleineren Klammern links (`CENTERED`) sind an das Gleichheitszeichen ausgerichtet, während die rechten (`MATCH`) höher um den Ausdruck liegen.

![Vier Gleichungen in PowerPoint mit aktiviertem und deaktiviertem Klammerwachstum, links zentriert und rechts angepasst](delimiter-sizing.png)

## **Ein Randfeld hinzufügen**

Rufen Sie [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) für einen Bruch auf, um den gesamten Ausdruck zu rahmen. Das zurückgegebene [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) zeigt standardmäßig alle vier Seiten. Verwenden Sie [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/), und [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/), um einzelne Seiten zu entfernen.

Das Beispiel platziert sechs Kopien desselben Bruchs auf einer Folie. Um die Streichung zu zeigen, verbergen Sie alle vier Seiten und setzen [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/) für eine steigende Diagonale (↗) oder [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) für eine fallende Diagonale (↘). Sie können auch [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) oder [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) mit beliebiger Kombination sichtbarer Seiten verwenden.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_fraction(slide, x, y, hide_border=False):
    fraction = math.MathematicalText("x+1").divide("y+2")
    box = fraction.to_border_box()
    box.hide_top = box.hide_bottom = box.hide_left = box.hide_right = hide_border

    shape = slide.shapes.add_math_shape(x, y, 160, 90)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 28
    portion.math_paragraph.add(math.MathBlock(box))
    return box


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(540, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    add_fraction(slide, 10, 10)

    partial = add_fraction(slide, 190, 10)
    partial.hide_top = True
    partial.hide_right = True

    add_fraction(slide, 370, 10, hide_border=True).strikethrough_bottom_left_to_top_right = True
    add_fraction(slide, 10, 120, hide_border=True).strikethrough_top_left_to_bottom_right = True
    add_fraction(slide, 190, 120, hide_border=True).strikethrough_horizontal = True
    add_fraction(slide, 370, 120).strikethrough_vertical = True

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

![Sechs editierbare Brüche in PowerPoint. Obere Zeile: voller Rand, untere und linke Seiten, steigende Diagonale. Untere Zeile: fallende Diagonale, horizontaler Strich, vertikaler Strich mit vollem Rand.](border-box-fractions.png)

Bei diesem Bruch überlappt der horizontale Strich die Bruchlinie. Der vertikale Strich durchschneidet sowohl Zähler als auch Nenner, während der umgebende Rand sichtbar bleibt. Diese Linien dekorieren den gesamten Ausdruck. Der gewöhnliche Text‑Durchstreichen gilt für Zeichen in einem Textlauf. Nach dem erneuten Öffnen der Präsentation in PowerPoint können Sie Zähler und Nenner weiterhin unabhängig bearbeiten.

## **Sichtbarkeit und Layout mit Phantom‑Elementen steuern**

Umgeben Sie einen Ausdruck mit [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/), um seine Sichtbarkeit und den von ihm im Ausdruck beanspruchten Platz unabhängig zu steuern. Seine Eigenschaften kontrollieren folgendes:

| Property | Effect |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | Auf `False` setzen, um den Ausdruck auszublenden. Seine Abmessungen tragen weiterhin zum Layout bei, es sei denn, die entsprechenden Eigenschaften unten sind auf `True` gesetzt. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | Die horizontale Breite des Ausdrucks als Null behandeln, sodass benachbarte Elemente näher zusammenrücken können. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | Den Aufstieg (Höhe über der Grundlinie) als Null behandeln. Das kann den über den Nachbarelementen reservierten Abstand verringern. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | Den Abstieg (Tiefe unter der Grundlinie) als Null behandeln. Das kann eine Bruchlinie oder anderen Inhalt unter dem Ausdruck näher an die Nachbarn bringen. |

Die Grundlinie ist die Referenzlinie, auf der gewöhnliche mathematische Zeichen sitzen. Das Ausblenden von Inhalt entfernt nicht seine Abmessungen, und das Behandeln einer Dimension als Null löscht den Ausdruck nicht. Der zugrunde liegende Ausdruck bleibt über [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/) verfügbar. Setzen Sie [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) zurück auf `True`, um ihn wieder anzuzeigen; die Dimensionseinstellungen bleiben unverändert.

Das Beispiel unten erzeugt fünf nebeneinander liegende Varianten: einen sichtbaren Bruch, einen ausgeblendeten Bruch, der Platz reserviert, und drei ausgeblendete Brüche, bei denen jeweils eine Dimension als Null behandelt wird. Jede Variante verwendet denselben umgebenden Ausdruck und Cambria Math in 24 Punkten. Alle Gleichungs‑Shapes haben dieselbe obere Position, markiert durch die graue Hilfslinie. Das Platzieren des Phantoms im Zähler eines äußeren Bruchs erleichtert das Erkennen der vertikalen Layout‑Änderungen.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(1000, 180, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"]

    guide = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 10, 60, 980, 0)
    guide.line_format.fill_format.fill_type = slides.FillType.SOLID
    guide.line_format.fill_format.solid_fill_color.color = slides.Color.light_gray

    for i, label_text in enumerate(labels):
        left = 10 + i * 200
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, left, 10, 190, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = label_text
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 14
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = math.MathFraction(fraction_numerator, fraction_denominator)
        phantom = math.MathPhantom(fraction)
        phantom.show = i == 0
        phantom.zero_width = i == 2
        phantom.zero_asc = i == 3
        phantom.zero_desc = i == 4

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = math.MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = math.MathFraction(numerator, denominator)

        shape = slide.shapes.add_math_shape(left, 60, 190, 100)
        shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.add(math.MathBlock(equation))

    presentation.save("math-phantom.pptx", slides.export.SaveFormat.PPTX)
```

![Fünf Gleichungen in PowerPoint, die einen sichtbaren Bruch, einen ausgeblendeten Bruch, der Platz reserviert, und ausgeblendete Brüche mit ZeroWidth, ZeroAsc bzw. ZeroDesc aktiv vergleichen](math-phantom.png)

## **Terme gruppieren**

Verwenden Sie [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/), um ein Gruppierungszeichen über oder unter einem Ausdruck zu platzieren. Fügen Sie ein Limit hinzu, um die gruppierten Terme zu beschriften.

![Der Ausdruck x plus y gruppiert mit dem Etikett beliebiger Text darunter](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **Mathematische Elemente formatieren**

Verwenden Sie Formatierungshilfen nur dort, wo sie die Formel verdeutlichen. Zum Beispiel platziert [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/) einen Strich über einem mathematischen Element.

![Ein mathematischer Ausdruck ABC mit einem Überstrich](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

### **Text in einer vorhandenen Gleichung formatieren**

Um Text in einer bestehenden Gleichung zu formatieren, durchlaufen Sie den Elementbaum jedes mathematischen Blocks. [MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) gibt nur die direkten Kinder zurück, daher rufen Sie es rekursiv auf, um Text in Brüchen, Skripts, Radikalen und anderen verschachtelten Strukturen zu erreichen. Prüfen Sie das aktuelle Element sowie seine Kinder, um das Ausgangselement einzubeziehen, wenn es ein [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) ist.

Dieses Beispiel geht davon aus, dass `input.pptx` eine Gleichung wie `z = xᵢ / ∛y` enthält, wobei ein Bruch im Zähler einen Subskript und ein Radikal im Nenner hat. Das Verarbeiten nur der obersten Elemente des Blocks würde den Text im Bruch übersehen. Das Beispiel findet mathematische Portionen in Folien‑Textfeldern, greift über [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) auf deren Blöcke zu und setzt [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) auf 28 Punkte über die [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/)‑Eigenschaft jedes Textelements.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def format_math_text(element):
    if isinstance(element, math.MathematicalText):
        element.format.font_height = 28

    for child in element.get_children():
        format_math_text(child)


with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if isinstance(portion, math.MathPortion):
                        for block in portion.math_paragraph:
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", slides.export.SaveFormat.PPTX)
```

Die gespeicherte Präsentation enthält die aktualisierte Textformatierung auf jeder Ebene jeder verarbeiteten Gleichung, wobei der Textinhalt und die mathematische Struktur erhalten bleiben.

## **Kurze Referenz**

| Aufgabe | Haupt‑API |
| --- | --- |
| Mathematischen Text erstellen | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Elemente kombinieren | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| Brüche erstellen | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| Hoch- oder Tiefstellung hinzufügen | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| Funktionen hinzufügen | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| Radikale hinzufügen | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| Grenzen hinzufügen | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| Linksseitige Skripte hinzufügen | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| Summen und Integrale hinzufügen | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Gleichungs‑Arrays hinzufügen | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| Begrenzungszeichen hinzufügen | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| Striche und Rahmen hinzufügen | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| Terme gruppieren | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **FAQ**

**Kann ich eine vorhandene PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, finden Sie das Shape, das ein [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) enthält, erhalten Sie dessen [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), und aktualisieren Sie die mathematischen Blöcke in diesem Absatz.

**Werden Gleichungen als editierbare PowerPoint‑Mathe gespeichert?**

Ja. Beim Speichern als PPTX schreibt Aspose.Slides die Gleichung als editierbaren Office‑Math‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Ja. Holen Sie das [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) einer [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) und rufen Sie [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) auf, um es direkt zu exportieren. Für ein vollständiges Beispiel siehe [Math‑Gleichungen aus Präsentationen in Python über .NET exportieren](/slides/de/python-net/exporting-math-equations/#export-math-equations-to-latex).