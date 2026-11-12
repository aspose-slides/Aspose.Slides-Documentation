---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in Python hinzufügen
linktitle: PowerPoint Mathematikgleichungen
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
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für Python via .NET einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare Python-Beispiele."
---
## **Übersicht**

PowerPoint speichert Gleichungen als Office Math Markup Language (OMML). Mit Aspose.Slides für Python via .NET können Sie denselben mathematischen Inhalt programmatisch erstellen: Brüche, Radikale, Funktionen, Grenzen, N‑äre Operatoren, Matrizen, Arrays und formatierte mathematische Blöcke.

In PowerPoint fügen Benutzer Gleichungen normalerweise über **Einfügen > Gleichung** hinzu:

![PowerPoint‑Registerkarte Einfügen mit ausgewähltem Befehl Gleichung](powerpoint-math-equations_1.png)

Das Ergebnis ist editierbarer mathematischer Text auf der Folie:

![Eine PowerPoint‑Folie mit einer editierbaren mathematischen Gleichung](powerpoint-math-equations_2.png)

Aspose.Slides erzeugt diesen mathematischen Text über drei Hauptobjekte:

- Eine Math‑Shape, erstellt mit [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), ist das Shape, das die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) speichert mathematischen Inhalt im Textfeld des Shapes.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)‑Objekte.

Die meisten nachfolgenden Beispiele verwenden [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) und die Fluent‑Methoden von [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), um den Code kurz und lesbar zu halten.

Für MathML‑Export‑Szenarien siehe [Mathematische Gleichungen aus Präsentationen in Python via .NET exportieren](/slides/de/python-net/exporting-math-equations/).

## **Gleichung erstellen**

Dieses Beispiel verwendet [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) , um eine Math‑Shape zu erstellen und fügt den Satz des Pythagoras hinzu:

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

{{% alert color="info" title="Hinweis" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) erstellt ein Shape, das bereits einen Math‑Paragraph enthält. Greifen Sie auf das erste [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) zu, erhalten Sie dessen [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), und fügen Sie Math‑Blöcke oder Math‑Elemente hinzu.
{{% /alert %}}

## **Brüche hinzufügen**

Verwenden Sie [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) , um einen Bruch zu erstellen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) auswählen.

![Ein schräger Bruch, der 1 durch x darstellt](powerpoint-math-equations_4.png)

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

Verwenden Sie [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) , um eine Quadratwurzel, Kubikwurzel oder andere Wurzel zu erzeugen. Das aktuelle Element wird zur Basis, das Argument zur Potenz.

![Ein n‑te Wurzel Ausdruck mit x unter dem Wurzelzeichen](powerpoint-math-equations_5.png)

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

## **Funktionen und Grenzen hinzufügen**

Verwenden Sie [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) oder [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) , um Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen zu erzeugen. Für Grenzen setzen Sie `lim` in ein [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) oder verwenden [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![Der Grenzwert von x, wenn x gegen unendlich strebt](powerpoint-math-equations_8.png)

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

Für einen benutzerdefinierten Funktionsnamen setzen Sie den Funktionsnamen als aktuelles Element und rufen [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) mit seinem Argument auf:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N‑äre Operatoren und Integrale hinzufügen**

Verwenden Sie [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) , um Summen, Vereinigungen, Schnitte und andere große Operatoren zu erzeugen. Verwenden Sie [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) , um Integrale zu erzeugen. Beide Methoden erlauben das Festlegen von unteren und oberen Grenzen.

![Eine Summation mit unteren und oberen Grenzen](powerpoint-math-equations_7.png)

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

N‑äre Operatoren sind für große Operatoren mit optionalen Grenzen gedacht. Einfache Operatoren wie `+`, `-` und `=` werden normalerweise als [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) hinzugefügt und in den Ausdruck eingefügt.

Für ein Integral verwenden Sie [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) :

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) , um Zeilen und Spalten zu erzeugen. Matrizen enthalten standardmäßig keine Klammern, daher sollten Sie die Matrix einschließen, wenn Sie Klammern, eckige Klammern oder geschweifte Klammern benötigen.

![Eine zweizeilige mathematische Matrix mit einer leeren Zelle](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # Eine Matrix hat keine eigenen Klammern, daher in runde Klammern einschließen.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warnung" %}}
`MathMatrix` erstellt das Zeilen‑ und Spaltenraster, legt die Zwischenräume fest und richtet die Spalten aus, aber Aspose.Slides für Python via .NET stellt keinen Zugriff auf eine einzelne Matrixzelle bereit. Eine im Code erstellte Matrix behält daher leere Zellen; die Zellen einer Matrix, die aus einer bestehenden Präsentation stammt, können mit `get_children` gelesen werden. Verwenden Sie ein Gleichungs‑Array, wenn Sie Zeilen programmgesteuert füllen müssen.
{{% /alert %}}

## **Gleichungs‑Arrays hinzufügen**

Verwenden Sie [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) , wenn Sie ausgerichtete Gleichungen oder einen vertikalen Stapel von Ausdrücken benötigen.

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

### **Ein Array mit benachbarten Elementen ausrichten**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) steuert die vertikale Ausrichtung eines Arrays im Verhältnis zu den benachbarten mathematischen Elementen. Das untenstehende Beispiel vergleicht die Ausrichtung der ersten Zeile, dem Zentrum des Arrays und der letzten Zeile.

Das folgende Beispiel erstellt drei identische Arrays, jeweils mit drei Zeilen und den Nachbarelementen `A=` und `=B`. Der gesamte mathematische Text verwendet Cambria Math in 24 Pt. Nur die Array‑Ausrichtung ändert sich.

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

![Gleichungs‑Arrays in PowerPoint mit oben, zentrierter und unten Ausrichtung und identischen benachbarten Elementen](equation-array-alignment.png)

### **Zeilenabstand konfigurieren**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) wählt die Abstandregel für Zeilen im Array. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) liefert einen numerischen Wert für eine explizite Abstandregel und wird von den Voreinstellungen ignoriert.

Für exakten Abstand wird der Wert in Punkten angegeben. Für proportionalen Abstand wird er in halben Zeilen gemessen: Der Wert `3` im Beispiel steht für 1,5 Zeilen. Setzen Sie beide Eigenschaften, wenn Sie einen expliziten Wert angeben; die alleinige Änderung des numerischen Werts wählt keine Abstandregel.

Der Zeilenabstand im Array ist getrennt vom Absatzabstand. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) und [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) fügen Abstand um den enthaltenden Absatz hinzu, nicht zwischen Array‑Zeilen. Ebenso positioniert [IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) den gesamten mathematischen Absatz horizontal; sie ersetzt nicht die vertikale Ausrichtung des Arrays.

Das untenstehende Beispiel speichert fünf Präsentationen mit denselben Gleichungen, Ausrichtungen und Schriftarteinstellungen. Die ersten drei verwenden Vorgaben; die letzten beiden zeigen explizite Werte.

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

## **Trigonometrische Funktionen hinzufügen**

Verwenden Sie [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) , wenn das Argument das aktuelle Element ist und der Funktionsname bekannt ist.

![Die trigonometrische Funktion cos angewendet auf 2x](powerpoint-math-equations_6.png)

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

## **Tief- und Hochstellungen hinzufügen**

Verwenden Sie die Hilfsfunktionen für Tief‑ und Hochstellungen für Indizes und Potenzen. Wenn die Indizes auf der linken Seite der Basis erscheinen sollen, verwenden Sie [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Ein großes Y mit linksseitigem Tiefstellungs‑1 und Hochstellungs‑n](powerpoint-math-equations_9.png)

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

## **Begrenzungszeichen hinzufügen**

Verwenden Sie [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) , um einen Ausdruck in Begrenzungszeichen zu setzen. Sie können auch ein Trennzeichen für Begrenzungs‑Ausdrücke festlegen, die mehrere Elemente enthalten.

![Ein Begrenzungs‑Ausdruck mit x, y und z, getrennt durch senkrechte Striche](powerpoint-math-equations_13.png)

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

### **Größe und Ausrichtung von Begrenzungszeichen**

Setzen Sie [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) auf `True`, damit die Klammern um einen hohen Operanden wachsen, oder auf `False`, um ihre normale Größe beizubehalten. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) akzeptiert einen von zwei [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/)‑Werten. `CENTERED` zentriert die Klammern auf der mathematischen Achse, die durch die Mitte des Gleichheitszeichens verläuft. `MATCH` richtet sie an den eingeschlossenen Inhalt aus. Beide Einstellungen beeinflussen nur die Begrenzungszeichen. Der innere Ausdruck bleibt unverändert.

Das Beispiel setzt einen Bruch in den Exponenten von `x`, sodass der Ausdruck weiter über die Grundlinie hinausragt als darunter. Alle vier Gleichungen verwenden dieselben Klammern und Schriftarteinstellungen.

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

In PowerPoint vergleichen Sie die Zeilen, um den Effekt des Wachstums zu sehen. In der oberen Zeile wachsen die Klammern, um den Exponenten zu umschließen, und sehen bei beiden Formen gleich aus. In der unteren Zeile ist das Wachstum deaktiviert. Die kleineren Klammern links (`CENTERED`) sind am Gleichheitszeichen ausgerichtet, während die rechts (`MATCH`) höher um den Ausdruck herum sitzen.

![Vier Gleichungen in PowerPoint mit aktivierten und deaktivierten Klammerwachstum, links zentriert und rechts passend](delimiter-sizing.png)

## **Rahmen‑Box hinzufügen**

Rufen Sie [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) bei einem Bruch auf, um den gesamten Ausdruck zu umrahmen. Das zurückgegebene [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) zeigt standardmäßig alle vier Seiten. Verwenden Sie [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/), und [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/), um einzelne Seiten zu entfernen.

Das Beispiel platziert sechs Kopien desselben Bruchs auf einer Folie. Um eine Streichung zu zeigen, verbergen Sie alle vier Seiten und setzen Sie [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) , um eine steigende Diagonale (↗) zu erhalten, oder [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) , um eine fallende Diagonale (↘) zu erhalten. Sie können auch [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) oder [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) mit beliebiger Kombination sichtbarer Seiten verwenden.

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

Bei diesem Bruch überlappt der horizontale Strich den Bruchstrich. Der vertikale Strich durchschneidet sowohl Zähler als auch Nenner, während der umgebende Rand sichtbar bleibt. Diese Linien dekorieren den gesamten Ausdruck. Normale Text‑Durchstreichungen gelten für Zeichen in einem Textlauf. Nach dem erneuten Öffnen der Präsentation in PowerPoint können Sie Zähler und Nenner weiterhin unabhängig bearbeiten.

## **Terme gruppieren**

Verwenden Sie [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) , um ein Gruppierungszeichen über oder unter einem Ausdruck zu platzieren. Fügen Sie eine Grenze hinzu, um die gruppierten Terme zu beschriften.

![Der Ausdruck x + y gruppiert mit der Beschriftung beliebiger Text darunter](powerpoint-math-equations_15.png)

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

Verwenden Sie Formatierungshilfen nur dort, wo sie die Formel verdeutlichen. Beispielsweise legt [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) einen Strich über ein mathematisches Element.

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

### **Text in einer bestehenden Gleichung formatieren**

Um Text in einer bestehenden Gleichung zu formatieren, durchlaufen Sie den Elementbaum jedes Math‑Blocks. [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) liefert nur die unmittelbaren Kinder, daher rufen Sie sie rekursiv auf, um Text in Brüchen, Skripten, Radikalen und anderen verschachtelten Strukturen zu erreichen. Prüfen Sie das aktuelle Element sowie seine Kinder, um das Ausgangselement einzubeziehen, wenn es sich um [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) handelt.

Dieses Beispiel geht davon aus, dass `input.pptx` eine Gleichung enthält, z. B. `z = xᵢ / ∛y`, mit einem Bruch, der im Zähler einen Tiefstellungs‑Index und im Nenner ein Radikal enthält. Die Verarbeitung nur der obersten Elemente des Blocks würde den Text im Bruch übersehen. Das Beispiel findet mathematische Portionen in Textfeldern von Folien, greift über [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) auf deren Blöcke zu und setzt [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) auf 28 Pt für jedes Textelement über dessen [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/)‑Eigenschaft.

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

Die gespeicherte Präsentation enthält die aktualisierte Textformatierung auf jeder Ebene jeder verarbeiteten Gleichung, während ihr Textinhalt und ihre mathematische Struktur erhalten bleiben.

## **Kurze Referenz**

| Aufgabe | Haupt‑API |
| --- | --- |
| Mathe‑Text erstellen | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Elemente kombinieren | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| Brüche erstellen | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Hoch‑ oder Tiefstellung hinzufügen | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Funktionen hinzufügen | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Radikale hinzufügen | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Grenzen hinzufügen | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Linksseitige Skripte hinzufügen | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Summen und Integrale hinzufügen | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Gleichungs‑Arrays hinzufügen | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Begrenzungszeichen hinzufügen | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Balken und Rahmen hinzufügen | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Terme gruppieren | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Kann ich eine bestehende PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, finden Sie das Shape, das ein [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) enthält, holen Sie dessen [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), und aktualisieren Sie die Math‑Blöcke in diesem Paragraphen.

**Werden Gleichungen als editierbare PowerPoint‑Mathe gespeichert?**

Ja. Beim Speichern als PPTX schreibt Aspose.Slides die Gleichung als editierbaren Office‑Math‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Ja. Holen Sie das [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) der Gleichung aus deren [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), und rufen Sie [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) auf, um sie direkt zu exportieren. Für ein vollständiges Beispiel siehe [Mathematische Gleichungen aus Präsentationen in Python via .NET exportieren](/slides/de/python-net/exporting-math-equations/#export-math-equations-to-latex).