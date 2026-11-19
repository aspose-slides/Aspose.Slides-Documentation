---
title: Voeg wiskundige vergelijkingen toe aan PowerPoint-presentaties in Python
linktitle: PowerPoint wiskundige vergelijkingen
type: docs
weight: 80
url: /nl/python-net/powerpoint-math-equations/
keywords:
- wiskundige vergelijking
- wiskundig symbool
- wiskundige formule
- wiskundige tekst
- voeg wiskundige vergelijking toe
- voeg wiskundig symbool toe
- voeg wiskundige formule toe
- voeg wiskundige tekst toe
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Voeg wiskundige vergelijkingen in PowerPoint PPT en PPTX in en bewerk ze met Aspose.Slides voor Python via .NET, met ondersteuning voor OMML, opmaakbesturingen en duidelijke Python-codesamples."
---
## **Overzicht**

PowerPoint slaat vergelijkingen op als Office Math Markup Language (OMML). Met Aspose.Slides voor Python via .NET kun je dezelfde soort wiskundige inhoud programmatisch maken: breuken, wortels, functies, limieten, N-ary‑operatoren, matrices, arrays en opgemaakte wiskundige blokken.

In PowerPoint voegen gebruikers normaal gesproken vergelijkingen toe via **Insert > Equation**:

![PowerPoint-tabblad Invoegen met de opdracht Vergelijking geselecteerd](powerpoint-math-equations_1.png)

Het resultaat is bewerkbare wiskundige tekst op de dia:

![Een PowerPoint-dia met een bewerkbare wiskundige vergelijking](powerpoint-math-equations_2.png)

Aspose.Slides bouwt die wiskundige tekst via drie hoofdobjecten:

- Een wiskundige vorm, gemaakt met [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), is de vorm die de vergelijking bevat.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) slaat wiskundige inhoud op binnen het tekstframe van de vorm.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) bevat een of meer [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) objecten.

De meeste voorbeelden hieronder gebruiken [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) en de fluente methoden van [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/) om de code kort en leesbaar te houden.

Voor MathML‑exportscenario's, zie [Exporteer wiskundige vergelijkingen uit presentaties in Python via .NET](/slides/nl/python-net/exporting-math-equations/).

## **Maak een vergelijking**

Dit voorbeeld gebruikt [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) om een wiskundige vorm te maken en voegt de stelling van Pythagoras toe:

![De vergelijking c² = a² + b²](powerpoint-math-equations_3.png)

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) maakt een vorm die al een wiskundige alinea bevat. Toegang tot de eerste [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), krijg zijn [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), en voeg wiskundige blokken of wiskunde‑elementen toe.
{{% /alert %}}

### **Combineer wiskundige blokken**

Wanneer delen van een vergelijking onafhankelijk worden opgebouwd als [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) objecten, gebruik [join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) om ze te combineren. Het voorbeeld bouwt `c² =` in het linkse blok en `a² + b²` in het rechtse blok. [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/) maakt bewerkbare wiskundige superscripts voor alle drie de machten.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_math_shape(20, 20, 600, 100)
    math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph

    left_block = math.MathBlock()
    left_block.add(math.MathematicalText("c").set_superscript("2"))
    left_block.add(math.MathematicalText("="))

    right_block = math.MathBlock()
    right_block.add(math.MathematicalText("a").set_superscript("2"))
    right_block.add(math.MathematicalText("+"))
    right_block.add(math.MathematicalText("b").set_superscript("2"))

    combined_block = left_block.join_block(right_block)
    math_paragraph.add(combined_block)

    presentation.save("equation.pptx", slides.export.SaveFormat.PPTX)
```

[join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) geeft `left_block` zelf terug, nu met beide delen in de juiste volgorde, en laat `right_block` leeg. Voeg het gecombineerde blok slechts één keer toe aan de [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Na het heropenen van `equation.pptx` bevat de alinea één blok dat `c² = a² + b²` weergeeft, waarbij alle drie de machten behouden blijven als wiskundige superscripts.

Het aanroepen van [add](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/add/) als `left_block.add(right_block)` probeert een blok direct binnen een ander blok te nesten en veroorzaakt een `RuntimeError` die een .NET `InvalidOperationException` omsluit.

## **Voeg breuken toe**

Gebruik [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) om een breuk te maken. Je kunt een breukstijl kiezen met [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Een scheve wiskundige breuk waarbij 1 gedeeld wordt door x](powerpoint-math-equations_4.png)

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

Voor een gestapelde breuk, gebruik [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Voeg wortels toe**

Gebruik [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) om een vierkantswortel, kubieke wortel of een andere wortel te maken. Het huidige element wordt de basis, en het argument wordt de graad.

![Een n‑de machtswortel met x onder het wortelteken](powerpoint-math-equations_5.png)

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

### **Toon of verberg de graad van een vierkantswortel**

Een vierkantswortel kan een expliciete 2 weergeven of de conventionele √x‑notatie gebruiken. De eigenschap [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/) van [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) bepaalt welke vorm verschijnt. Beide vormen behouden graad 2 en radicand x in de bewerkbare vergelijking.

![De vierkantswortel van x met graad 2 zichtbaar links en verborgen rechts](square-root-degree.png)

Het voorbeeld slaat dezelfde vierkantswortel twee keer op. De 2 is zichtbaar in `visible-degree.pptx` en verborgen in `hidden-degree.pptx`.

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

## **Voeg functies en limieten toe**

Gebruik [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) of [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) voor functies zoals `sin(x)`, `log(x)` of aangepaste functienamen. Voor limieten plaats je `lim` in een [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) of gebruik [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/).

![De limiet van x wanneer x naar oneindig gaat](powerpoint-math-equations_8.png)

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

Voor een aangepaste functienaam maak je de functienaam het huidige element en roep je [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) aan met zijn argument:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **Voeg N‑ary‑operatoren en integralen toe**

Gebruik [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/) voor sommaties, unies, intersecties en andere grote operatoren. Gebruik [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) voor integralen. Beide methoden laten je onder‑ en bovengrenzen instellen.

![Een sommatieteken met onder‑ en bovengrens](powerpoint-math-equations_7.png)

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

N‑ary‑operatoren zijn voor grote operatoren met optionele grenzen. Eenvoudige operatoren zoals `+`, `-` en `=` worden meestal toegevoegd als [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) en samengevoegd in de uitdrukking.

Voor een integraal, gebruik [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Voeg matrices toe**

Gebruik [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) voor rijen en kolommen. Matrices bevatten standaard geen haakjes, dus omsluit de matrix met ronde, vierkante of accolades wanneer dat nodig is.

![Een matrix met twee rijen en één lege cel](powerpoint-math-equations_10.png)

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

### **Bewerk een bestaande matrix**

Stel dat een les lineaire algebra start met de coëfficiëntmatrix in `matrix.pptx`, opgeslagen door het vorige voorbeeld. Voor de volgende oefening, behoud je de eerste vergelijking, vervang je de tweede door twee nieuwe vergelijkingen en pas je de variabelen aan. Open de bestaande matrix als een [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) om de nog geldende coëfficiënten te behouden.

![Originele matrix met twee rijen, entries 1, x en een lege cel in de eerste rij, en x, 2, y in de tweede](matrix-before-edit.png)

Rij‑ en kolomindexen beginnen bij nul en verwijzen naar de matrix zoals die op het moment van de oproep bestaat. Een rij invoegen vóór index 1 verplaatst de oorspronkelijke tweede rij naar index 2. Invoegen na index 2 voegt vervolgens nog een rij toe. Verwijderen van rij 2 verwijdert de oorspronkelijke tweede vergelijking en verschuift de toegevoegde rij één positie omhoog. Kolommen verschuiven op dezelfde manier.

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

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) legt de eerste kolom links uit. [set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) legt drie opeenvolgende kolommen rechts uit, beginnend bij index 1. In `updated-matrix.pptx` heeft de matrix drie vergelijkingen en vier variabelen. De oorspronkelijke eerste‑rij coëfficiënten `1` en `x` verschijnen nu in de eerste en derde kolom.

![Bijgewerkte matrix met drie rijen: 1, 0, x, 0; 12, 1, 0, 0; en 0, 0, 10, 1](matrix-after-edit.png)

## **Voeg vergelijking‑arrays toe**

Gebruik [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) wanneer je uitgelijnde vergelijkingen of een verticale stapel van uitdrukkingen nodig hebt.

![Een verticale wiskundige array met x boven y](powerpoint-math-equations_11.png)

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

### **Lijn een array uit met omringende elementen**

[MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) bepaalt de verticale uitlijning van een array ten opzichte van de wiskundige elementen ernaast. Het voorbeeld hieronder vergelijkt uitlijning met de eerste rij, het midden van de array en de laatste rij.

Het volgende voorbeeld maakt drie identieke arrays, elk met drie rijen en de naburige elementen `A=` en `=B`. Alle wiskundige tekst gebruikt Cambria Math op 24 pt. Alleen de array‑uitlijning verschilt.

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

De volgende vergelijking toont de opgeslagen presentatie in PowerPoint. Let op de positie van `A=` en `=B` naast elke array.

![Vergelijkings‑arrays in PowerPoint met boven‑, midden‑ en onder‑uitlijning en identieke naburige elementen](equation-array-alignment.png)

### **Configureer rij‑afstand**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) selecteert de afstandsregel voor rijen binnen de array. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) levert een numerieke waarde voor een expliciete afstandsregel en wordt genegeerd door de vooraf ingestelde regels.

Voor exacte afstand wordt de waarde gemeten in punten. Voor proportionele afstand wordt gemeten in halve regels: de waarde `3` in het voorbeeld betekent 1,5 regels. Stel beide eigenschappen in wanneer je een expliciete waarde opgeeft; alleen de numerieke waarde wijzigen selecteert geen afstandsregel.

Het onderstaande voorbeeld slaat vijf presentaties op met dezelfde vergelijkingen, uitlijning en lettertype‑instellingen. De eerste drie gebruiken presets; de laatste twee laten expliciete waarden zien.

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

Array‑rij‑afstand staat los van alinea‑afstand. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) en [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) voegen ruimte toe rond de omvattende alinea, niet tussen array‑rijen. Evenzo bepaalt [MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) de horizontale positie van de volledige wiskundige alinea; het vervangt niet de verticale uitlijningsinstelling van de array.

## **Voeg trigonometrische functies toe**

Gebruik [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) wanneer het argument het huidige element is en de functienaam bekend.

![De trigonometrische functie cos toegepast op 2x](powerpoint-math-equations_6.png)

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

## **Voeg subscripten en superscripten toe**

Gebruik de subscrip‑ en superscripthulpmiddelen voor indexen en machten. Wanneer de indexen links van de basis moeten staan, gebruik [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/).

![Een hoofdletter Y met links‑subscript 1 en superscript n](powerpoint-math-equations_9.png)

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

## **Voeg delimiters toe**

Gebruik [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) om een uitdrukking tussen delimiters te plaatsen. Je kunt ook een scheidingsteken instellen voor delimiter‑uitdrukkingen die meerdere elementen bevatten.

![Een delimiter‑uitdrukking met x, y en z gescheiden door verticale streepjes](powerpoint-math-equations_13.png)

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

### **Grootte en uitlijning van delimiters**

Stel [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/) in op `True` om de haakjes te laten groeien rond een hoog operand, of op `False` om ze op normale grootte te houden. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) neemt één van twee [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) waarden aan. `CENTERED` centreert de haakjes op de wiskundige as, die door het midden van het gelijkteken loopt. `MATCH` aligneert ze op de ingesloten inhoud. Beide instellingen beïnvloeden alleen de delimiters; de uitdrukking binnen blijft gelijk.

Het voorbeeld plaatst een breuk in de exponent van `x` zodat de uitdrukking hoger uitsteekt boven de basislijn dan eronder. Alle vier de vergelijkingen gebruiken dezelfde haakjes en lettertype‑instellingen.

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

In PowerPoint kun je de rijen vergelijken om het groeieffect te zien. In de bovenste rij groeien de haakjes om de exponent heen en zien ze er identiek uit voor beide vormen. In de onderste rij is groei uitgeschakeld. De kleinere haakjes links (`CENTERED`) zijn uitgelijnd met het gelijkteken, terwijl die rechts (`MATCH`) hoger rondom de uitdrukking staan.

![Vier vergelijkingen in PowerPoint met delimiter‑groei ingeschakeld boven en uitgeschakeld onder, en Centered links en Match rechts](delimiter-sizing.png)

## **Voeg een border‑box toe**

Roep [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) aan op een breuk om de hele uitdrukking in een kader te plaatsen. Het geretourneerde [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) toont standaard alle vier de zijden. Gebruik [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/) en [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/) om individuele zijden te verwijderen.

Het voorbeeld plaatst zes kopieën van dezelfde breuk op één dia. Om annulering te tonen, verberg je alle vier de zijden en stel je [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/) in voor een stijgende diagonale streep (↗) of [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) voor een dalende diagonale streep (↘). Je kunt ook [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) of [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) gebruiken met elke combinatie van zichtbare zijden.

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

![Zes bewerkbare breuken in PowerPoint. Bovenste rij: volledig kader, onder‑ en linkerkant, stijgende diagonale streep. Onderste rij: dalende diagonale streep, horizontale streep, verticale streep met volledig kader.](border-box-fractions.png)

Op deze breuk overlapt de horizontale streep de breukstreep. De verticale streep doorkruist zowel de teller als de noemer terwijl het omringende kader zichtbaar blijft. Deze lijnen decoreren de hele uitdrukking. Gewone tekst‑doorstreeping geldt voor tekens in een text‑run. Na het heropenen van de presentatie in PowerPoint kun je de teller en noemer nog steeds onafhankelijk bewerken.

## **Beheer zichtbaarheid en lay‑out met phantom‑elementen**

Omhul een uitdrukking in [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) om de zichtbaarheid en de ruimte die hij aan een vergelijking bijdraagt onafhankelijk te regelen. De eigenschappen bepalen het volgende:

| Eigenschap | Effect |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | Zet op `False` om de uitdrukking te verbergen. De afmetingen blijven wel meetellen voor de lay‑out, tenzij de onderliggende eigenschappen hieronder op `True` staan. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | Behandelt de horizontale breedte van de uitdrukking als nul, zodat naburige elementen dichter bijeen kunnen komen. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | Behandelt de stijging (hoogte boven de basislijn) als nul. Dit kan de ruimte boven naburige elementen verminderen. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | Behandelt de daling (diepte onder de basislijn) als nul. Dit kan een breukstreep of andere inhoud onder de uitdrukking dichter bij de buren brengen. |

De basislijn is de referentielijn waarop gewone wiskundige letters rusten. Het verbergen van inhoud verwijdert de dimensies niet, en het behandelen van een dimensie als nul verwijdert de uitdrukking niet. De onderliggende uitdrukking blijft beschikbaar via [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/). Zet [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) terug op `True` om hem opnieuw te tonen; de dimensie‑instellingen blijven ongewijzigd.

Het voorbeeld hieronder maakt vijf varianten naast elkaar: een zichtbare breuk, een verborgen breuk die ruimte reserveert, en drie verborgen breuken met één dimensie op nul gezet. Elke variant gebruikt dezelfde omringende uitdrukking en Cambria Math op 24 pt. Alle vergelijking‑vormen hebben dezelfde boven‑positie, gemarkeerd door de grijze richtlijn. Het plaatsen van de phantom in de teller van een buitenste breuk maakt verticale lay‑out‑veranderingen duidelijker zichtbaar.

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

![Vijf vergelijkingen in PowerPoint die een zichtbare breuk, een verborgen breuk die ruimte reserveert, en verborgen breuken met ZeroWidth, ZeroAsc of ZeroDesc tonen](math-phantom.png)

## **Groeperen van termen**

Gebruik [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) om een groeperingssymbool boven of onder een uitdrukking te plaatsen. Voeg een limiet toe om de gegroepeerde termen te labelen.

![De uitdrukking x + y gegroepeerd met het label willekeurige tekst eronder](powerpoint-math-equations_15.png)

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

## **Opmaak van wiskundige elementen**

Gebruik opmaak‑hulpmiddelen alleen waar ze de formule verduidelijken. Bijvoorbeeld, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/) plaatst een balk boven een wiskundig element.

![Een wiskundige uitdrukking ABC met een overbar](powerpoint-math-equations_14.png)

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

### **Formateer tekst in een bestaande vergelijking**

Om tekst door een bestaande vergelijking heen te formatteren, doorloop je de elementboom van elk wiskundig blok. [MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) geeft alleen de directe kinderen terug, dus roep je het recursief aan om tekst in breuken, scripts, wortels en andere geneste structuren te bereiken. Controleer zowel het huidige element als zijn kinderen om het start‑element mee te nemen wanneer het een [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) is.

Dit voorbeeld gaat ervan uit dat `input.pptx` een vergelijking bevat zoals `z = xᵢ / ∛y`, met een breuk die een subscript in de teller heeft en een wortel in de noemer. Alleen de boven‑niveau‑elementen van het blok verwerken zou tekst in de breuk missen. Het voorbeeld zoekt wiskundige delen in dia‑tekstframes, opent hun blokken via [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), en stelt [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) in op 28 pt via de [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) eigenschap van elk tekstelement.

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

De opgeslagen presentatie bevat de bijgewerkte tekstopmaak op elk niveau van elke verwerkte vergelijking, terwijl de tekstinhoud en wiskundige structuur behouden blijven.

## **Snelle referentie**

| Taak | Hoofd‑API |
| --- | --- |
| Maak wiskundige tekst | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Combineer elementen | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| Maak breuken | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| Voeg superscript of subscript toe | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| Voeg functies toe | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| Voeg wortels toe | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| Voeg limieten toe | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| Voeg linkerscripts toe | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| Voeg sommaties en integralen toe | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| Voeg matrices toe | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Voeg vergelijking‑arrays toe | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| Voeg delimiters toe | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| Voeg balken en randen toe | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| Groepeer termen | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **FAQ**

**Kan ik een bestaande PowerPoint‑vergelijking bewerken?**

Ja. Open de presentatie, zoek de vorm die een [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) bevat, krijg zijn [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), en werk de wiskundige blokken in die alinea bij.

**Worden vergelijkingen opgeslagen als bewerkbare PowerPoint‑wiskunde?**

Ja. Bij het opslaan naar PPTX schrijft Aspose.Slides de vergelijking als bewerkbare Office‑wiskunde‑inhoud.

**Kan ik vergelijkingen exporteren naar LaTeX?**

Ja. Haal de [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) van de [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) op, en roep [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) aan om deze rechtstreeks te exporteren. Voor een compleet voorbeeld, zie [Exporteer wiskundige vergelijkingen uit presentaties in Python via .NET](/slides/nl/python-net/exporting-math-equations/#export-math-equations-to-latex).