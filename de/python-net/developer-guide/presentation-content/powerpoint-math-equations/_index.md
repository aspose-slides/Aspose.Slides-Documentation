---
title: Mathgleichungen zu PowerPoint-Präsentationen in Python hinzufügen
linktitle: PowerPoint-Mathegleichungen
type: docs
weight: 80
url: /de/python-net/powerpoint-math-equations/
keywords:
- mathematische Gleichung
- mathematisches Symbol
- mathematische Formel
- Mathematiktext
- mathematische Gleichung hinzufügen
- mathematisches Symbol hinzufügen
- mathematische Formel hinzufügen
- Mathematiktext hinzufügen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Mathegleichungen in PowerPoint PPT und PPTX einfügen und bearbeiten mit Aspose.Slides für Python via .NET, unterstützt OMML, Formatierungsoptionen und klare Python-Codebeispiele."
---
## **Überblick**

PowerPoint speichert Gleichungen als Office Math Markup Language (OMML). Mit Aspose.Slides for Python via .NET können Sie dieselbe Art von mathematischem Inhalt programmgesteuert erstellen: Brüche, Wurzeln, Funktionen, Grenzen, N‑äre Operatoren, Matrizen, Arrays und formatierte Mathematikblöcke.

In PowerPoint fügen Benutzer Gleichungen normalerweise über **Einfügen > Gleichung** hinzu:

![PowerPoint-Registerkarte Einfügen mit ausgewähltem Befehl Gleichung](powerpoint-math-equations_1.png)

Das Ergebnis ist editierbarer mathematischer Text auf der Folie:

![Eine PowerPoint-Folie, die eine editierbare mathematische Gleichung enthält](powerpoint-math-equations_2.png)

Aspose.Slides erzeugt diesen mathematischen Text über drei Hauptobjekte:

- Ein Mathe‑Shape, erstellt mit [add_math_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_math_shape/), ist das Shape, das die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathportion/) speichert mathematischen Inhalt im Textfeld des Shapes.
- [MathParagraph](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathblock/)-Objekte.

Die meisten Beispiele unten verwenden [MathematicalText](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathematicaltext/) und die Fluent‑Methoden von [IMathElement](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/), um den Code kurz und lesbar zu halten.

Für MathML‑Export‑Szenarien siehe [Export Math Equations from Presentations in Python via .NET](/slides/de/python-net/exporting-math-equations/).

## **Gleichung erstellen**

Dieses Beispiel erstellt ein Mathe‑Shape und fügt den Satz des Pythagoras hinzu:

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

{{% alert color="primary" %}}
`add_math_shape` erstellt ein Shape, das bereits einen Math‑Paragraph enthält. Greifen Sie auf das erste `MathPortion` zu, holen Sie dessen `MathParagraph` und fügen Sie Math‑Blöcke oder Math‑Elemente hinzu.
{{% /alert %}}

## **Brüche hinzufügen**

Verwenden Sie [`divide`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/divide/), um einen Bruch zu erstellen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathfractiontypes/) wählen.

![Ein schräger mathematischer Bruch, der 1 durch x zeigt](powerpoint-math-equations_4.png)

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

Für einen gestapelten Bruch verwenden Sie `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Wurzeln hinzufügen**

Verwenden Sie [`radical`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/radical/), um eine Quadratwurzel, Kubikwurzel oder andere Wurzel zu erstellen. Das aktuelle Element wird zur Basis, das Argument zum Exponenten.

![Ein n‑te Wurzel‑Ausdruck mit x unter dem Wurzelzeichen](powerpoint-math-equations_5.png)

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

Verwenden Sie [`as_argument_of_function`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) oder [`function`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/function/) für Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen. Für Grenzen setzen Sie `lim` in ein [MathLimit](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathlimit/) oder verwenden [`set_lower_limit`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![Der Limes von x, wenn x gegen unendlich geht](powerpoint-math-equations_8.png)

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

Für einen benutzerdefinierten Funktionsnamen machen Sie den Funktionsnamen zum aktuellen Element:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **N‑äre Operatoren und Integrale hinzufügen**

Verwenden Sie [`nary`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/nary/) für Summen, Vereinigungen, Schnittmengen und andere große Operatoren. Verwenden Sie [`integral`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/integral/) für Integrale. Beide Methoden erlauben das Festlegen von Unter‑ und Obergrenzen.

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

N‑äre Operatoren sind für große Operatoren mit optionalen Grenzen. Einfache Operatoren wie `+`, `-` und `=` werden normalerweise als `MathematicalText` hinzugefügt und zu dem Ausdruck verbunden.

Für ein Integral verwenden Sie `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathmatrix/) für Zeilen und Spalten. Matrizen enthalten standardmäßig keine Klammern, daher schließen Sie die Matrix ein, wenn Sie Klammern, eckige Klammern oder geschweifte Klammern benötigen.

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

## **Gleichungsarrays hinzufügen**

Verwenden Sie [`to_math_array`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/to_math_array/), wenn Sie ausgerichtete Gleichungen oder einen vertikalen Stapel von Ausdrücken benötigen.

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

## **Trigonometrische Funktionen hinzufügen**

Verwenden Sie [`as_argument_of_function`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/), wenn das Argument das aktuelle Element ist und der Funktionsname bekannt ist.

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

## **Tief‑ und Hochstellungen hinzufügen**

Verwenden Sie die Hilfsfunktionen für Tief‑ und Hochstellung für Indizes und Potenzen. Wenn die Indizes links von der Basis erscheinen sollen, verwenden Sie [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Ein großes Y mit linksseitigem Tiefstellungswert 1 und Hochstellungswert n](powerpoint-math-equations_9.png)

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

## **Trennzeichen hinzufügen**

Verwenden Sie [`enclose`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/enclose/), um einen Ausdruck in Trennzeichen zu setzen. Sie können auch ein Trennzeichen‑Zeichen für Ausdrücke mit mehreren Elementen festlegen.

![Ein Trennzeichen‑Ausdruck, der x, y und z enthält und durch senkrechte Striche getrennt ist](powerpoint-math-equations_13.png)

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

## **Rahmen‑Box hinzufügen**

Verwenden Sie [`to_border_box`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/to_border_box/), wenn die Gleichung selbst gerahmt werden soll.

![Eine eingerahmte Gleichung, die a² = b² + c² zeigt](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **Terme gruppieren**

Verwenden Sie [`group`](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/group/), um ein Gruppierungszeichen über oder unter einem Ausdruck zu platzieren. Fügen Sie ein Limit hinzu, um die gruppierten Terme zu beschriften.

![Der Ausdruck x + y, gruppiert mit der Beschriftung irgendein Text darunter](powerpoint-math-equations_15.png)

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

Verwenden Sie Formatierungs‑Hilfsfunktionen nur dort, wo sie die Formel verdeutlichen. Zum Beispiel legt `overbar` einen Balken über ein Math‑Element.

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

## **Schnellreferenz**

| Aufgabe | Haupt‑API |
| --- | --- |
| Mathe‑Text erstellen | [MathematicalText](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Elemente kombinieren | [IMathElement.join](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/join/) |
| Brüche erstellen | [IMathElement.divide](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Hoch‑ oder Tiefstellung hinzufügen | [set_superscript](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Funktionen hinzufügen | [function](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Wurzeln hinzufügen | [radical](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Grenzen hinzufügen | [set_lower_limit](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Linksseitige Skripte hinzufügen | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Summen und Integrale hinzufügen | [nary](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/mathmatrix/) |
| Gleichungsarrays hinzufügen | [to_math_array](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Trennzeichen hinzufügen | [enclose](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Balken und Rahmen hinzufügen | [overbar](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Terme gruppieren | [group](https://reference.aspose.com/slides/de/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Kann ich eine vorhandene PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, finden Sie das Shape, das einen `MathPortion` enthält, holen Sie dessen `MathParagraph` und aktualisieren Sie die Math‑Blöcke in diesem Paragraphen.

**Werden Gleichungen als editierbare PowerPoint‑Mathematik gespeichert?**

Ja. Beim Speichern als PPTX schreibt Aspose.Slides die Gleichung als editierbaren Office‑Mathe‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Aspose.Slides exportiert mathematische Gleichungen nach MathML. Wenn Sie LaTeX benötigen, exportieren Sie zuerst nach MathML und konvertieren Sie dann das MathML mit einem Tool, das Ihren Ziel‑LaTeX‑Dialekt unterstützt.