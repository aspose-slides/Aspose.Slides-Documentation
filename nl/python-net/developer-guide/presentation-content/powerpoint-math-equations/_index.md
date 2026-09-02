---
title: Wiskundige vergelijkingen toevoegen aan PowerPoint‑presentaties in Python
linktitle: PowerPoint wiskundige vergelijkingen
type: docs
weight: 80
url: /nl/python-net/powerpoint-math-equations/
keywords:
- wiskundige vergelijking
- wiskundig symbool
- wiskundige formule
- wiskundige tekst
- wiskundige vergelijking toevoegen
- wiskundig symbool toevoegen
- wiskundige formule toevoegen
- wiskundige tekst toevoegen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Invoegen en bewerken van wiskundige vergelijkingen in PowerPoint PPT en PPTX met Aspose.Slides voor Python via .NET, ondersteuning voor OMML, opmaakbesturingen en duidelijke Python‑codevoorbeelden."
---
## **Overzicht**

PowerPoint slaat vergelijkingen op als Office Math Markup Language (OMML). Met Aspose.Slides voor Python via .NET kun je dezelfde soort wiskundige inhoud programmatically maken: breuken, radicalen, functies, limieten, N‑aire operatoren, matrices, arrays en opgemaakte wiskundige blokken.

In PowerPoint voegen gebruikers normaal gesproken vergelijkingen toe via **Invoegen > Vergelijking**:

![PowerPoint tabblad Invoegen met de opdracht Vergelijking geselecteerd](powerpoint-math-equations_1.png)

Een PowerPoint‑dia met een bewerkbare wiskundige vergelijking:

![Een PowerPoint‑dia met een bewerkbare wiskundige vergelijking](powerpoint-math-equations_2.png)

Aspose.Slides bouwt die wiskundige tekst via drie hoofdobjecten:

- Een wiskundige vorm, gecreëerd met [add_math_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_math_shape/), is de vorm die de vergelijking bevat.
- [MathPortion](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathportion/) slaat wiskundige inhoud op in het tekstframe van de vorm.
- [MathParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/) bevat één of meer [MathBlock](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathblock/)-objecten.

De meeste voorbeelden hieronder gebruiken [MathematicalText](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathematicaltext/) en de fluente methoden van [IMathElement](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/) om de code kort en leesbaar te houden.

Voor exportscenario's naar MathML, zie [Math‑vergelijkingen exporteren vanuit presentaties in Python via .NET](/slides/nl/python-net/exporting-math-equations/).

## **Maak een vergelijking**

Dit voorbeeld maakt een wiskundige vorm en voegt de stelling van Pythagoras toe:

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

{{% alert color="primary" %}}
`add_math_shape` maakt een vorm die al een wiskundige alinea bevat. Verkrijg de eerste `MathPortion`, haal zijn `MathParagraph` op en voeg wiskundige blokken of wiskundige elementen toe.
{{% /alert %}}

## **Breuken toevoegen**

Gebruik [`divide`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/divide/) om een breuk te maken. Je kunt een breukstijl kiezen met [MathFractionTypes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Een scheve wiskundige breuk die één gedeeld door x toont](powerpoint-math-equations_4.png)

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

Voor een gestapelde breuk, gebruik `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Radicalen toevoegen**

Gebruik [`radical`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/radical/) om een vierkantswortel, derdemachtswortel of een andere wortel te maken. Het huidige element wordt de basis en het argument wordt de graad.

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

## **Functies en limieten toevoegen**

Gebruik [`as_argument_of_function`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) of [`function`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/function/) voor functies zoals `sin(x)`, `log(x)` of aangepaste functienamen. Voor limieten, zet `lim` in een [MathLimit](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathlimit/) of gebruik [`set_lower_limit`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

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

Voor een aangepaste functienaam, maak de functienaam het huidige element:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **N‑aire operatoren en integralen toevoegen**

Gebruik [`nary`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/nary/) voor sommaties, unies, doorsnedingen en andere grote operatoren. Gebruik [`integral`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/integral/) voor integralen. Beide methoden laten je onder‑ en bovengrenzen instellen.

![Een som met onder‑ en bovengrenzen](powerpoint-math-equations_7.png)

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

N‑aire operatoren zijn voor grote operatoren met optionele grenzen. Eenvoudige operatoren zoals `+`, `-` en `=` worden meestal als `MathematicalText` toegevoegd en aan de uitdrukking gekoppeld.

Voor een integraal, gebruik `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Matrixen toevoegen**

Gebruik [MathMatrix](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathmatrix/) voor rijen en kolommen. Matrices bevatten standaard geen haakjes, dus omsluit de matrix wanneer je haakjes, vierkante haken of accolades nodig hebt.

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

## **Vergelijkingsarrays toevoegen**

Gebruik [`to_math_array`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/to_math_array/) wanneer je uitgelijnde vergelijkingen of een verticale stapel uitdrukkingen nodig hebt.

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

## **Trigonometrische functies toevoegen**

Gebruik [`as_argument_of_function`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) wanneer het argument het huidige element is en de functienaam bekend.

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

## **Subscripties en superscripties toevoegen**

Gebruik de subscript‑ en superscript‑helpers voor indexen en machten. Wanneer de indexen links van de basis moeten staan, gebruik [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Een hoofdletter Y met links subscript 1 en superscript n](powerpoint-math-equations_9.png)

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

## **Scheidingstekens toevoegen**

Gebruik [`enclose`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/enclose/) om een uitdrukking binnen delimiters te plaatsen. Je kunt ook een scheidingsteken instellen voor delimiter‑uitdrukkingen die meerdere elementen bevatten.

![Een delimiter‑expressie met x, y en z gescheiden door verticale streepjes](powerpoint-math-equations_13.png)

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

## **Een kader toevoegen**

Gebruik [`to_border_box`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/to_border_box/) wanneer de vergelijking zelf in een kader moet staan.

![Een omkaderde vergelijking die a² = b² + c² toont](powerpoint-math-equations_12.png)

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

## **Termen groeperen**

Gebruik [`group`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/group/) om een groeperingskarakter boven of onder een uitdrukking te plaatsen. Voeg een limiet toe om de gegroepeerde termen te labelen.

![De uitdrukking x plus y gegroepeerd met het label enige tekst eronder](powerpoint-math-equations_15.png)

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

## **Wiskundige elementen opmaken**

Gebruik opmaak‑helpers alleen waar ze de formule verduidelijken. Bijvoorbeeld, [`overbar`](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/overbar/) plaatst een balk boven een wiskundig element.

![Een wiskundige uitdrukking ABC met een overbalk](powerpoint-math-equations_14.png)

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

## **Snelle referentie**

| Taak | Hoofd‑API |
| --- | --- |
| Wiskundige tekst maken | [MathematicalText](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Elementen combineren | [IMathElement.join](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/join/) |
| Breuken maken | [IMathElement.divide](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Superscript of subscript toevoegen | [set_superscript](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Functies toevoegen | [function](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Radicalen toevoegen | [radical](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Limieten toevoegen | [set_lower_limit](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Links‑scripts toevoegen | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Sommaties en integralen toevoegen | [nary](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Matrixen toevoegen | [MathMatrix](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathmatrix/) |
| Vergelijkingsarrays toevoegen | [to_math_array](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Delimiters toevoegen | [enclose](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Balken en kaders toevoegen | [overbar](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Termen groeperen | [group](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/imathelement/group/) |

## **Veelgestelde vragen**

**Kan ik een bestaande PowerPoint‑vergelijking bewerken?**

Ja. Open de presentatie, zoek de vorm die een `MathPortion` bevat, haal de `MathParagraph` op en werk de wiskundige blokken in die alinea bij.

**Worden vergelijkingen opgeslagen als bewerkbare PowerPoint‑wiskunde?**

Ja. Wanneer je opslaat als PPTX, schrijft Aspose.Slides de vergelijking weg als bewerkbare Office‑wiskundige inhoud.

**Kan ik vergelijkingen exporteren naar LaTeX?**

Ja. Haal de [MathParagraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/) van de [MathPortion](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathportion/) op, en roep [MathParagraph.to_latex](https://reference.aspose.com/slides/nl/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) aan om direct te exporteren. Voor een volledig voorbeeld, zie [Math‑vergelijkingen exporteren vanuit presentaties in Python via .NET](/slides/nl/python-net/exporting-math-equations/#export-math-equations-to-latex).