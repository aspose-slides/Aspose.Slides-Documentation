---
title: Voeg wiskundige vergelijkingen toe aan PowerPoint-presentaties in Python
linktitle: PowerPoint wiskundige vergelijkingen
type: docs
weight: 80
url: /nl/python-java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Voeg wiskundige vergelijkingen in PowerPoint PPT en PPTX in met Aspose.Slides voor Python via Java, met ondersteuning voor OMML, opmaaktecontroles en duidelijke Python-codevoorbeelden."
---
## **Overzicht**

PowerPoint slaat vergelijkingen op als Office Math Markup Language (OMML). Met Aspose.Slides for Python via Java kun je dezelfde soort wiskundige inhoud programmatisch maken: breuken, wortels, functies, limieten, N‑waardige operatoren, matrices, arrays en opgemaakte wiskunde‑blokken.

In PowerPoint voegen gebruikers normaal gesproken vergelijkingen toe via **Invoegen > Vergelijking**:

![PowerPoint tabblad Invoegen met het commando Vergelijking geselecteerd](powerpoint-math-equations_1.png)

Het resultaat is bewerkbare wiskundige tekst op de dia:

![Een PowerPoint‑dia met een bewerkbare wiskundige vergelijking](powerpoint-math-equations_2.png)

Aspose.Slides bouwt die wiskundige tekst op via drie hoofdobjecten:

- Een wiskundige vorm, gemaakt met [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape), is de vorm die de vergelijking bevat.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) bewaart wiskundige inhoud binnen het vorm‑tekstkader.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) bevat één of meer [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) objecten.

De meeste onderstaande voorbeelden gebruiken [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) en de fluent‑methoden van [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) om de code kort en leesbaar te houden.

Voor MathML‑exportscenario’s zie [Export Math Equations from Presentations in Python](/slides/nl/python-java/exporting-math-equations/).

## **Een vergelijking maken**

Dit voorbeeld gebruikt [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) om een wiskundige vorm te maken en voegt de stelling van Pythagoras toe:

![De vergelijking c² = a² + b²](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Opmerking" %}}
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) maakt een vorm die al een wiskundig alinea bevat. Open de eerste [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), roep [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) aan en voeg wiskundige blokken of elementen toe.
{{% /alert %}}

## **Breuken toevoegen**

Gebruik [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) om een breuk te maken. Je kunt een breukstijl kiezen met [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/).

![Een scheve wiskundige breuk die één gedeeld door x toont](powerpoint-math-equations_4.png)

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

Voor een gestapelde breuk, gebruik [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Wortels toevoegen**

Gebruik [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) om een vierkantswortel, kubiekwortel of een andere wortel te maken. Het huidige element wordt de basis, en het argument wordt de graad.

![Een n‑de wortel met x onder het wortelteken](powerpoint-math-equations_5.png)

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

## **Functies en limieten toevoegen**

Gebruik [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) of [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) voor functies zoals `sin(x)`, `log(x)` of aangepaste functienamen. Voor limieten, zet `lim` in een [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) of gebruik [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit).

![De limiet van x wanneer x naar oneindig gaat](powerpoint-math-equations_8.png)

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

Voor een aangepaste functienaam, maak de functienaam het huidige element en roep [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) aan met zijn argument:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **N‑waardige operatoren en integralen toevoegen**

Gebruik [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) voor sommaties, unies, intersecties en andere grote operatoren. Gebruik [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) voor integralen. Beide methoden laten je onder‑ en bovengrenzen instellen.

![Een sommatiesymbool met onder‑ en bovengrenzen](powerpoint-math-equations_7.png)

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

N‑waardige operatoren zijn voor grote operatoren met optionele grenzen. Simpele operatoren zoals `+`, `-` en `=` worden meestal toegevoegd als [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) en samengevoegd in de uitdrukking.

Voor een integraal gebruik je [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

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

## **Matrices toevoegen**

Gebruik [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) voor rijen en kolommen. Matrices bevatten standaard geen haakjes, dus omring de matrix wanneer je haakjes, vierkante haakjes of accolades nodig hebt.

![Een matrix met twee rijen en één lege cel](powerpoint-math-equations_10.png)

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

## **Vergelijkingsarrays toevoegen**

Gebruik [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) wanneer je uitgelijnde vergelijkingen of een verticale stapel uitdrukkingen nodig hebt.

![Een verticale wiskundige array met x boven y](powerpoint-math-equations_11.png)

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

## **Trigonometrische functies toevoegen**

Gebruik [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) wanneer het argument het huidige element is en de functienaam bekend is.

![De trigonometrische functie cos toegepast op 2x](powerpoint-math-equations_6.png)

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

## **Subscripties en superscripties toevoegen**

Gebruik de subscript- en superscript‑hulpmiddelen voor indexen en exponenten. Wanneer de indexen links van de basis moeten staan, gebruik [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Een hoofdletter Y met links subscript 1 en superscript n](powerpoint-math-equations_9.png)

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

## **Scheidingstekens toevoegen**

Gebruik [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) om een uitdrukking tussen scheidingstekens te plaatsen. Je kunt ook een scheidingstekenkarakter instellen voor uitdrukkingen die meerdere elementen bevatten.

![Een scheidingsteken‑expressie die x, y en z bevat, gescheiden door verticale staven](powerpoint-math-equations_13.png)

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

### **Grootte en uitlijning van scheidingstekens**

Geef `True` aan [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) om de haakjes te laten groeien rond een hoge operand, of `False` om ze op normale grootte te houden. Gebruik [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) met een van de twee waarden van [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/). `Centered` centreert de haakjes op de wiskundige as, die door het midden van het gelijkteken loopt. `Match` lijnt ze uit met de ingesloten inhoud. Beide instellingen hebben alleen invloed op de scheidingstekens. De uitdrukking binnen blijft gelijk.

Het voorbeeld plaatst een breuk in de exponent van `x` zodat de uitdrukking hoger uitsteekt boven de basislijn dan eronder. Alle vier de vergelijkingen gebruiken dezelfde haakjes en lettertype‑instellingen.

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

In PowerPoint, vergelijk de rijen om het groeieffect te zien. In de bovenste rij groeien de haakjes om de exponent heen en zien ze er gelijk uit voor beide vormen. In de onderste rij is groei uitgeschakeld. De kleinere haakjes links (`Centered`) lijnnen uit met het gelijkteken, terwijl die rechts (`Match`) hoger om de uitdrukking heen staan.

![Vier vergelijkingen in PowerPoint met scheidingsteken‑groei ingeschakeld boven en uitgeschakeld hieronder, en Centered links en Match rechts](delimiter-sizing.png)

## **Een randvak toevoegen**

Roep [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) aan op een breuk om de hele uitdrukking te omkaderen. Het geretourneerde [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) toont standaard alle vier de zijden. Gebruik [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) en [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) om individuele zijden te verbergen.

Het voorbeeld plaatst zes kopieën van dezelfde breuk op één dia. Om een doorhaling te laten zien, verberg je alle vier de zijden en geef je `True` aan [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) voor een opgaande diagonale (↗) of [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) voor een neergaande diagonale (↘). Je kunt ook [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) of [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) gebruiken met elke combinatie van zichtbare zijden.

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

![Zes bewerkbare breuken in PowerPoint. Bovenste rij: volledige rand, onder‑ en linkerzijden, opgaande diagonal. onderste rij: neergaande diagonal, horizontale streep, verticale streep met volledige rand.](border-box-fractions.png)

Op deze breuk overlapt de horizontale streep de breukstreep. De verticale streep doorkruist zowel de teller als de noemer terwijl de omringende rand zichtbaar blijft. Deze lijnen versieren de hele uitdrukking. Gewone tekstdoorhaling geldt voor tekens in een tekstrun. Na het opnieuw openen van de presentatie in PowerPoint kun je de teller en noemer nog steeds afzonderlijk bewerken.

## **Termen groeperen**

Gebruik [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) om een groepeerteken boven of onder een uitdrukking te plaatsen. Voeg een limiet toe om de gegroepeerde termen van een label te voorzien.

![De uitdrukking x + y gegroepeerd met het label willekeurige tekst eronder](powerpoint-math-equations_15.png)

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

## **Wiskundige elementen opmaken**

Gebruik opmaak‑helpers alleen waar ze de formule verduidelijken. Bijvoorbeeld, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) plaatst een streep boven een wiskundig element.

![Een wiskundige uitdrukking ABC met een overbalk](powerpoint-math-equations_14.png)

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

### **Tekst opmaken in een bestaande vergelijking**

Om tekst door de hele bestaande vergelijking heen op te maken, doorloop je elk element in de boom van elk wiskundig blok. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) retourneert alleen de directe kinderen, dus roep het recursief aan om tekst binnen breuken, scripts, wortels en andere geneste structuren te bereiken. Controleer het huidige element en de kinderen om het start‑element op te nemen wanneer het [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) is.

Dit voorbeeld gaat uit van een `input.pptx` die een vergelijking bevat zoals `z = xᵢ / ∛y`, met een breuk die een subscript in de teller en een wortel in de noemer heeft. Alleen de bovenliggende elementen van het blok verwerken zou de tekst binnen de breuk missen. Het voorbeeld zoekt wiskundige porties in dia‑tekstkaders, opent hun blokken via [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), en gebruikt [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) om de lettergrootte op 28 pt te zetten via de [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat)‑methode van elk tekstelement.

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

De opgeslagen presentatie bevat de bijgewerkte tekstopmaak op elk niveau van elke verwerkte vergelijking, terwijl de tekstinhoud en wiskundige structuur behouden blijven.

## **Snelreferentie**

| Taak | Hoofd‑API |
| --- | --- |
| Wiskundige tekst maken | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| Elementen combineren | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| Breuken maken | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| Superscript of subscript toevoegen | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| Functies toevoegen | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| Wortels toevoegen | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| Limieten toevoegen | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| Scripts links van de basis toevoegen | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| Sommaties en integralen toevoegen | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| Matrices toevoegen | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| Vergelijkingsarrays toevoegen | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| Scheidingstekens toevoegen | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| Balken en randvlakken toevoegen | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| Termen groeperen | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **Veelgestelde vragen**

**Kan ik een bestaande PowerPoint‑vergelijking bewerken?**

Ja. Open de presentatie, vind de vorm die een [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) bevat, roep [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) aan en werk de wiskundige blokken in dat alinea bij.

**Worden vergelijkingen opgeslagen als bewerkbare PowerPoint‑wiskunde?**

Ja. Wanneer je opslaat naar PPTX, schrijft Aspose.Slides de vergelijking als bewerkbare Office‑wiskundige inhoud.

**Kan ik vergelijkingen exporteren naar LaTeX?**

Ja. Haal het [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) op uit de [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), en roep [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) aan om het direct te exporteren. Voor een volledig voorbeeld, zie [Export Math Equations from Presentations in Python](/slides/nl/python-java/exporting-math-equations/#export-math-equations-to-latex).