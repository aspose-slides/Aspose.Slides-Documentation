---
title: Lägg till matematiska ekvationer i PowerPoint-presentationer i Python
linktitle: PowerPoint-matematiska ekvationer
type: docs
weight: 80
url: /sv/python-net/powerpoint-math-equations/
keywords:
- matematisk ekvation
- matematiskt symbol
- matematisk formel
- matematisk text
- lägg till matematisk ekvation
- lägg till matematiskt symbol
- lägg till matematisk formel
- lägg till matematisk text
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Infoga och redigera matematiska ekvationer i PowerPoint PPT och PPTX med Aspose.Slides för Python via .NET, med stöd för OMML, formateringskontroller och tydliga Python-kodexempel."
---
## **Översikt**

PowerPoint lagrar ekvationer som Office Math Markup Language (OMML). Med Aspose.Slides för Python via .NET kan du programmässigt skapa samma typ av matematikinnehåll: bråk, rötter, funktioner, gränsvärden, N‑ära operatorer, matriser, arrayer och formaterade matematiska block.

I PowerPoint lägger användare normalt till ekvationer från **Insert > Equation**:

![PowerPoint fliken Infoga med kommandot Ekvation markerat](powerpoint-math-equations_1.png)

Resultatet är redigerbar matematisk text på bilden:

![En PowerPoint‑bild som innehåller en redigerbar matematisk ekvation](powerpoint-math-equations_2.png)

Aspose.Slides bygger den matematiska texten genom tre huvudobjekt:

- En matematikform, skapad med [add_math_shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_math_shape/), är den form som innehåller ekvationen.
- [MathPortion](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathportion/) lagrar matematikinnehåll i formens textruta.
- [MathParagraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathparagraph/) innehåller ett eller flera [MathBlock](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathblock/)-objekt.

De flesta exempel nedan använder [MathematicalText](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathematicaltext/) och de flytande metoderna från [IMathElement](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/) för att hålla koden kort och läsbar.

För MathML‑exportscenarier, se [Export Math Equations from Presentations in Python via .NET](/slides/sv/python-net/exporting-math-equations/).

## **Skapa en ekvation**

Detta exempel skapar en matematikform och lägger till Pythagoras sats:

![Ekvationen c² = a² + b²](powerpoint-math-equations_3.png)

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
`add_math_shape` skapar en form som redan innehåller ett matematikstycke. Hämta den första `MathPortion`, få dess `MathParagraph` och lägg till matematiksblock eller matematiskelement i den.
{{% /alert %}}

## **Lägg till bråk**

Använd [`divide`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/divide/) för att skapa ett bråk. Du kan välja en bråktyp med [MathFractionTypes](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Ett skevt matematiskt bråk som visar ett delat med x](powerpoint-math-equations_4.png)

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

För ett staplat bråk, använd `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Lägg till rötter**

Använd [`radical`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/radical/) för att skapa en kvadratrot, kubikrot eller annan rot. Det nuvarande elementet blir basen och argumentet blir graden.

![Ett n:te rotuttryck med x under rotsymbolen](powerpoint-math-equations_5.png)

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

## **Lägg till funktioner och gränsvärden**

Använd [`as_argument_of_function`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) eller [`function`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/function/) för funktioner såsom `sin(x)`, `log(x)` eller anpassade funktionsnamn. För gränsvärden, placera `lim` i en [MathLimit](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathlimit/) eller använd [`set_lower_limit`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![Gränsvärdet för x när x närmar sig oändligheten](powerpoint-math-equations_8.png)

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

För ett anpassat funktionsnamn, gör funktionsnamnet till det nuvarande elementet:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **Lägg till N‑ära operatorer och integraler**

Använd [`nary`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/nary/) för summationer, unioner, snitt och andra stora operatorer. Använd [`integral`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/integral/) för integraler. Båda metoderna låter dig ange lägre och övre gränser.

![En summation med lägre och övre gränser](powerpoint-math-equations_7.png)

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

N‑ära operatorer är för stora operatorer med valfria gränser. Enkla operatorer såsom `+`, `-` och `=` läggs vanligtvis till som `MathematicalText` och kombineras i uttrycket.

För en integral, använd `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Lägg till matriser**

Använd [MathMatrix](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathmatrix/) för rader och kolumner. Matriser innehåller inte hakparenteser som standard, så omge matrisen när du behöver parenteser, hakparenteser eller måsvingar.

![En matris med två rader och en tom cell](powerpoint-math-equations_10.png)

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

## **Lägg till ekvationsarrayer**

Använd [`to_math_array`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/to_math_array/) när du behöver inriktade ekvationer eller en vertikal stapel av uttryck.

![En vertikal matematikarray med x ovanför y](powerpoint-math-equations_11.png)

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

## **Lägg till trigonometriska funktioner**

Använd [`as_argument_of_function`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) när argumentet är det nuvarande elementet och funktionsnamnet är känt.

![Den trigonometriska funktionen cos applicerad på 2x](powerpoint-math-equations_6.png)

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

## **Lägg till nedsänkta och upphöjda index**

Använd hjälpfunktionerna för nedsänkta och upphöjda index för index och potenser. När indexen måste visas på vänster sida av basen, använd [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Ett versalt Y med nedsänkt index 1 på vänster sida och upphöjt index n](powerpoint-math-equations_9.png)

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

## **Lägg till avgränsare**

Använd [`enclose`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/enclose/) för att placera ett uttryck inom avgränsare. Du kan också ange ett avgränsartecken för avgränsaruttryck som innehåller flera element.

![Ett avgränsaruttryck som innehåller x, y och z separerade med vertikala streck](powerpoint-math-equations_13.png)

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

## **Lägg till en ramruta**

Använd [`to_border_box`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/to_border_box/) när själva ekvationen ska ramas in.

![En inramad ekvation som visar a² = b² + c²](powerpoint-math-equations_12.png)

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

## **Gruppera termer**

Använd [`group`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/group/) för att placera ett grupptecken ovanför eller nedanför ett uttryck. Lägg till en gräns för att märka de grupperade termerna.

![Uttrycket x + y grupperat med etiketten någon text under det](powerpoint-math-equations_15.png)

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

## **Formatera matematiska element**

Använd formateringshjälpmedel endast där de förtydligar formeln. Till exempel placerar [`overbar`](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/overbar/) ett streck ovanför ett matematiskt element.

![Ett matematiskt uttryck ABC med ett överstreck](powerpoint-math-equations_14.png)

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

## **Snabbreferens**

| Uppgift | Huvud‑API |
| --- | --- |
| Skapa matematisk text | [MathematicalText](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Kombinera element | [IMathElement.join](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/join/) |
| Skapa bråk | [IMathElement.divide](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Lägg till upphöjt eller nedsänkt index | [set_superscript](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Lägg till funktioner | [function](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Lägg till rötter | [radical](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Lägg till gränsvärden | [set_lower_limit](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Lägg till vänstersidiga script | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Lägg till summationer och integraler | [nary](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Lägg till matriser | [MathMatrix](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/mathmatrix/) |
| Lägg till ekvationsarrayer | [to_math_array](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Lägg till avgränsare | [enclose](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Lägg till streck och ramar | [overbar](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Gruppera termer | [group](https://reference.aspose.com/slides/sv/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Kan jag redigera en befintlig PowerPoint‑ekvation?**

Ja. Öppna presentationen, hitta formen som innehåller en `MathPortion`, hämta dess `MathParagraph` och uppdatera matematiksblocken i det stycket.

**Sparas ekvationer som redigerbar PowerPoint‑matematik?**

Ja. När du sparar till PPTX skriver Aspose.Slides ekvationen som redigerbart Office‑math‑innehåll.

**Kan jag exportera ekvationer till LaTeX?**

Aspose.Slides exporterar matematiska ekvationer till MathML. Om du behöver LaTeX, exportera först till MathML och konvertera sedan MathML med ett verktyg som stödjer ditt mål‑LaTeX‑dialekt.