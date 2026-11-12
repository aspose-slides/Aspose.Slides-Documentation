---
title: Přidání matematických rovnic do prezentací PowerPoint v Pythonu
linktitle: Matematické rovnice PowerPoint
type: docs
weight: 80
url: /cs/python-net/powerpoint-math-equations/
keywords:
- matematická rovnice
- matematický symbol
- matematický vzorec
- matematický text
- přidat matematickou rovnici
- přidat matematický symbol
- přidat matematický vzorec
- přidat matematický text
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vkládejte a upravujte matematické rovnice v PowerPoint PPT a PPTX pomocí Aspose.Slides pro Python přes .NET, podporující OMML, ovládací prvky formátování a přehledné ukázky kódu v Pythonu."
---
## **Přehled**

PowerPoint ukládá rovnice jako Office Math Markup Language (OMML). S Aspose.Slides pro Python přes .NET můžete programově vytvářet stejný typ matematického obsahu: zlomky, odmocniny, funkce, limity, N-ární operátory, matice, pole a formátované matematické bloky.

V PowerPointu uživatelé obvykle přidávají rovnice z **Insert > Equation**:

![Karta Insert v PowerPointu s vybraným příkazem Equation](powerpoint-math-equations_1.png)

Výsledkem je editovatelný matematický text na snímku:

![Snímek v PowerPointu obsahující editovatelnou matematickou rovnici](powerpoint-math-equations_2.png)

Aspose.Slides vytváří tento matematický text pomocí tří hlavních objektů:

- Matematický tvar, vytvořený pomocí [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), je tvar, který obsahuje rovnici.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) ukládá matematický obsah do textového rámečku tvaru.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) obsahuje jeden nebo více objektů [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Většina ukázek níže používá [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) a plynulé metody z [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) , aby byl kód stručný a čitelný.

Pro scénáře exportu MathML si prohlédněte [Export rovnic z prezentací v Pythonu pomocí .NET](/slides/cs/python-net/exporting-math-equations/).

## **Vytvoření rovnice**

Tento příklad používá [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) k vytvoření matematického tvaru a přidává Pythagorovu větu:

![Rovnice c na druhou rovná se a na druhou plus b na druhou](powerpoint-math-equations_3.png)

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) vytváří tvar, který již obsahuje matematický odstavec. Získejte první [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), pak jeho [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), a přidejte do něj matematické bloky nebo matematické prvky.
{{% /alert %}}

## **Přidání zlomků**

Použijte [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) , abyste vytvořili zlomek. Styl zlomku můžete zvolit pomocí [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Zkosený matematický zlomek ukazující jedna děleno x](powerpoint-math-equations_4.png)

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

Pro svislý (stacked) zlomek použijte [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Přidání odmocnin**

Použijte [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) , abyste vytvořili odmocninu ze druhé, třetí nebo jiného řádu. Aktuální prvek se stane základem a argument určuje stupeň.

![Výraz n-té odmocniny s x pod znakem odmocniny](powerpoint-math-equations_5.png)

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

## **Přidání funkcí a limit**

Použijte [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) nebo [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) pro funkce jako `sin(x)`, `log(x)` nebo vlastní názvy funkcí. Pro limity vložte `lim` do [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) nebo použijte [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![Limit x, když x směřuje k nekonečnu](powerpoint-math-equations_8.png)

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

Pro vlastní název funkce učinte název funkce aktuálním prvkem a zavolejte [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) s jeho argumentem:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **Přidání N-árních operátorů a integrálů**

Použijte [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) pro součty, sjednocení, průniky a další velké operátory. Použijte [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) pro integrály. Obě metody umožňují nastavit dolní a horní limity.

![Součet s dolní a horní limitou](powerpoint-math-equations_7.png)

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

N-ární operátory slouží pro velké operátory s volitelnými limity. Jednoduché operátory jako `+`, `-` a `=` se obvykle přidávají jako [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) a spojují do výrazu.

Pro integrál použijte [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) :

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Přidání matic**

Použijte [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) pro řádky a sloupce. Matice standardně neobsahují závorky, takže je obalte, když potřebujete kulaté, hranaté nebo složené závorky.

![Matematická matice se dvěma řádky a jednou prázdnou buňkou](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # Matice nemá vlastní závorky, proto ji obalte v kulatých závorkách.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` vytváří mřížku řádků a sloupců, nastavuje mezery mezi nimi a zarovnává sloupce, ale Aspose.Slides pro Python přes .NET neumožňuje přístup k jednotlivým buňkám matice. Matice vytvořená v kódu si tak zachová prázdné buňky; buňky matice pocházející ze stávající prezentace lze číst pomocí `get_children`. Použijte pole rovnic, pokud potřebujete řádky vyplnit z kódu.
{{% /alert %}}

## **Přidání polí rovnic**

Použijte [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) , když potřebujete zarovnané rovnice nebo svislé uspořádání výrazů.

![Svislé pole s x nad y](powerpoint-math-equations_11.png)

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

### **Zarovnání pole s okolními prvky**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) řídí svislé zarovnání pole vzhledem k matematickým prvkům vedle něj. Níže uvedený příklad srovnává zarovnání s první řádkou, středem pole a poslední řádkou.

Následující příklad vytváří tři identická pole, každé se třemi řádky a sousedními prvky `A=` a `=B`. Veškerý matematický text používá písmo Cambria Math o velikosti 24 bodů. Mění se pouze zarovnání pole.

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

Následující srovnání ukazuje uloženou prezentaci v PowerPointu. Všimněte si umístění `A=` a `=B` vedle každého pole.

![Polí rovnic v PowerPointu s horním, středním a dolním zarovnáním a identickými sousedními prvky](equation-array-alignment.png)

### **Nastavení mezery řádků**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) vybírá pravidlo mezery pro řádky v rámci pole. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) poskytuje číselnou hodnotu pro explicitní pravidlo mezery a je ignorováno přednastavenými pravidly.

Pro přesnou mezeru se hodnota měří v bodech. Pro proporcionální mezeru se měří v půlčárkách: hodnota `3` v příkladu představuje 1,5 řádku. Při zadávání explicitní hodnoty nastavte oba vlastnosti; změna pouze číselné hodnoty nevybírá pravidlo mezery.

Níže uvedený příklad uloží pět prezentací se stejnými rovnicemi, zarovnáním a nastavením písma. První tři používají předvolby; poslední dvě ukazují explicitní hodnoty.

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

Mezera řádků pole je oddělena od mezery odstavce. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) a [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) přidávají prostor kolem obsahujícího odstavce, nikoli mezi řádky pole. Podobně [IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) umisťuje celý matematický odstavec horizontálně; nenahrazuje nastavení svislého zarovnání pole.

## **Přidání trigonometrických funkcí**

Použijte [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) , když je argument aktuálním prvkem a název funkce je znám.

![Trigonometrická funkce cos aplikovaná na 2x](powerpoint-math-equations_6.png)

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

## **Přidání dolních a horních indexů**

Použijte pomocníky pro dolní a horní indexy pro indexy a mocniny. Když musí být indexy umístěny na levé straně základu, použijte [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Velké Y s levým dolním indexem 1 a horním indexem n](powerpoint-math-equations_9.png)

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

## **Přidání oddělovačů**

Použijte [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) , abyste vložili výraz do oddělovačů. Můžete také nastavit znak oddělovače pro výrazy s více prvky.

![Výraz s oddělovači obsahující x, y a z oddělené svislými čarami](powerpoint-math-equations_13.png)

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

### **Velikost a zarovnání oddělovačů**

Nastavte [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) na `True`, aby se závorky roztahovaly kolem vysokého operandu, nebo na `False`, aby zůstaly v normální velikosti. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) přijímá jednu ze dvou hodnot [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/). `CENTERED` vycentruje závorky na matematické ose, která prochází středem znaménka rovnosti. `MATCH` je zarovná s obsaženým obsahem. Obě nastavení ovlivňují pouze oddělovače. Výraz uvnitř zůstává stejný.

Příklad umístí zlomek do exponentu `x`, takže se výraz rozprostírá výše nad základní čárou než pod ní. Všechny čtyři rovnice používají stejné závorky a nastavení písma.

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

V PowerPointu porovnejte řádky, abyste viděli efekt růstu. V horním řádku se závorky rozšíří tak, aby obklopily exponent a vypadají stejně pro oba tvary. V dolním řádku je růst vypnutý. Menší závorky vlevo (`CENTERED`) jsou zarovnány s rovnítkem, zatímco ty vpravo (`MATCH`) jsou výše kolem výrazu.

![Čtyři rovnice v PowerPointu s povoleným růstem oddělovačů nahoře a vypnutým dole, a Centered vlevo a Match vpravo](delimiter-sizing.png)

## **Přidání rámečku**

Zavolejte [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) na zlomek, aby se ohraničila celá výraz. Vrácený [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) standardně zobrazuje všechny čtyři strany. Použijte [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/), a [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) , abyste odstranili jednotlivé strany.

Příklad umístí šest kopií stejného zlomku na jeden snímek. Pro zobrazení zrušení skryjte všechny čtyři strany a nastavte [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) pro rostoucí úhlopříčku (↗) nebo [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) pro klesající úhlopříčku (↘). Můžete také použít [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) nebo [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) s libovolnou kombinací viditelných stran.

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

![Šest editovatelných zlomků v PowerPointu. Horní řádek: plný rámeček, spodní a levá strana, rostoucí úhlopříčka. Dolní řádek: klesající úhlopříčka, horizontální úsečka, vertikální úsečka s plným rámečkem](border-box-fractions.png)

U tohoto zlomku vodorovná úsečka překrývá čáru zlomku. Svislá úsečka prochází jak čitatelem, tak jmenovatelem, zatímco okolní rámeček zůstává viditelný. Tyto čáry zdobí celý výraz. Běžné přeškrtnutí textu se vztahuje na znaky v textovém úseku. Po opětovném otevření prezentace v PowerPointu můžete stále samostatně upravovat čitatel i jmenovatel.

## **Seskupení členů**

Použijte [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) , abyste umístili znak seskupení nad nebo pod výraz. Přidejte limit pro označení seskupených členů.

![Výraz x plus y seskupený s popiskem libovolný text pod ním](powerpoint-math-equations_15.png)

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

## **Formátování matematických prvků**

Používejte pomocníky formátování jen tam, kde objasňují rovnici. Například [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) umisťuje čáru nad matematický prvek.

![Matematický výraz ABC s vodorovnou čárou](powerpoint-math-equations_14.png)

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

### **Formátování textu v existující rovnici**

Pro formátování textu v celé existující rovnici projděte strom elementů každého matematického bloku. [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) vrací pouze přímé potomky, takže jej volejte rekurzivně, abyste se dostali k textu uvnitř zlomků, skriptů, odmocnin a dalších vnořených struktur. Zkontrolujte aktuální prvek i jeho potomky, aby byl zahrnut počáteční prvek, pokud je to [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Tento příklad předpokládá, že `input.pptx` obsahuje rovnici jako `z = xᵢ / ∛y`, se zlomkem, který má dolní index v čitateli a odmocninu ve jmenovateli. Zpracování pouze prvků nejvyšší úrovně bloku by vynechalo text uvnitř zlomku. Příklad najde matematické části v textových rámečcích snímků, získá jejich bloky pomocí [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), a nastaví [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) na 28 bodů u každého textového elementu přes jeho [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) vlastnost.

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

Uložená prezentace obsahuje aktualizované formátování textu na každé úrovni každé zpracované rovnice, přičemž zachovává její textový obsah a matematickou strukturu.

## **Rychlý přehled**

| Úkol | Hlavní API |
| --- | --- |
| Vytvořit matematický text | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Kombinovat prvky | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| Vytvořit zlomky | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Přidat horní nebo dolní index | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Přidat funkce | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Přidat odmocniny | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Přidat limity | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Přidat levé skripty | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Přidat součty a integrály | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Přidat matice | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Přidat pole rovnic | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Přidat oddělovače | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Přidat čáry a rámečky | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Seskupit členy | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **Často kladené otázky**

**Mohu upravit existující rovnici v PowerPointu?**

Ano. Otevřete prezentaci, najděte tvar, který obsahuje [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), získejte jeho [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), a aktualizujte matematické bloky v tomto odstavci.

**Ukládají se rovnice jako editovatelná matematika v PowerPointu?**

Ano. Při uložení do PPTX Aspose.Slides zapisuje rovnici jako editovatelný obsah Office Math.

**Mohu exportovat rovnice do LaTeXu?**

Ano. Získejte [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) rovnice z jejího [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), a zavolejte [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) pro přímý export. Pro kompletní příklad viz [Export rovnic z prezentací v Pythonu pomocí .NET](/slides/cs/python-net/exporting-math-equations/#export-math-equations-to-latex).