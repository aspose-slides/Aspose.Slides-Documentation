---
title: "Matematikai egyenletek hozzáadása PowerPoint prezentációkhoz Pythonban"
linktitle: "PowerPoint matematikai egyenletek"
type: docs
weight: 80
url: /hu/python-net/powerpoint-math-equations/
keywords:
- "matematikai egyenlet"
- "matematikai szimbólum"
- "matematikai képlet"
- "matematikai szöveg"
- "matematikai egyenlet hozzáadása"
- "matematikai szimbólum hozzáadása"
- "matematikai képlet hozzáadása"
- "matematikai szöveg hozzáadása"
- "PowerPoint"
- "prezentáció"
- "Python"
- "Aspose.Slides"
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT- és PPTX-fájlokban az Aspose.Slides for Python via .NET használatával, OMML támogatással, formázási vezérlőkkel és világos Python kódpéldákkal."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Python via .NET segítségével programozottan létrehozhatja ugyanazt a típusú matematikai tartalmat: törtök, gyökök, függvények, határok, N‑áris operátorok, mátrixok, tömbök és formázott matematikai blokkok.

A PowerPointban a felhasználók általában egyenleteket adnak hozzá a **Insert > Equation**:

![PowerPoint Insert lap, a Equation parancs kiválasztva](powerpoint-math-equations_1.png)

Az eredmény szerkeszthető matematikai szöveg a dián:

![Egy PowerPoint dia, amely szerkeszthető matematikai egyenletet tartalmaz](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- A matematikai alakzat, amelyet a [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) hoz létre, az az alakzat, amely az egyenletet tartalmazza.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) tárolja a matematikai tartalmat az alakzat szövegkeretében.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) folyékony módszereit használja, hogy a kód rövid és olvasható legyen.

MathML export esetén lásd a [Matematikai egyenletek exportálása prezentációkból Pythonon keresztül .NET](/slides/hu/python-net/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa a [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) használatával hoz létre egy matematikai alakzatot, és hozzáadja a Pitagorasz‑tételt:

![c négyzet egyenlő a négyzet plusz b négyzet](powerpoint-math-equations_3.png)

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Hozzáfér az első [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), lekéri annak [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), és hozzáad matematikai blokkokat vagy elemeket.
{{% /alert %}}

## **Törtek hozzáadása**

A [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) használatával hozhat létre egy törtet. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) segítségével választhatja.

![Egy ferde matematikai tört, amely 1-et oszt x-szel](powerpoint-math-equations_4.png)

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

Egy egymásra helyezett tört esetén használja a [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/)-t:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Gyökök hozzáadása**

A [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) használatával hozhat létre négyzetgyököt, köbgyököt vagy más gyököt. A jelenlegi elem lesz az alap, az argumentum pedig a kitevő.

![n-dik gyök kifejezés, ahol x áll a gyökjel alatt](powerpoint-math-equations_5.png)

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

### **A négyzetgyök fokszámának megjelenítése vagy elrejtése**

A négyzetgyök megjeleníthet egy explicit 2‑t, vagy a szokásos √x jelölést használhatja. Az [IMathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathradical/) [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathradical/hide_degree/) tulajdonsága szabályozza, hogy melyik forma jelenik meg. Mindkét forma megtartja a 2 fokszámot és az x radikanduszt a szerkeszthető egyenletben.

![Az x négyzetgyöke, balra a 2 látható, jobbra rejtett](square-root-degree.png)

A példa ugyanazt a négyzetgyököt kétszer menti. A 2 látható a `visible-degree.pptx` fájlban, és rejtett a `hidden-degree.pptx` fájlban.

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

## **Függvények és határok hozzáadása**

Használja a [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) vagy a [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) függvényeket olyan függvényekhez, mint a `sin(x)`, `log(x)`, vagy egyedi függvénynevek. Határok esetén helyezze a `lim`‑et egy [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) belé, vagy használja a [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/)-et.

![x határa, ahogy x a végtelen felé tart](powerpoint-math-equations_8.png)

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

Egy egyedi függvénynévhez tegye a függvénynevet a jelenlegi elemmé, és hívja a [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) a argumentummal:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N‑áris operátorok és integrálok hozzáadása**

A [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) használatával végezhet összeadásokat, uniókat, metszeteket és más nagy operátorokat. Az [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) integrálokhoz. Mindkét módszer lehetővé teszi a alsó és felső határ beállítását.

![Összegzés alsó és felső határokkal](powerpoint-math-equations_7.png)

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

Az N‑áris operátorok nagy operátorok opcionális határokkal. Az egyszerű operátorok, mint a `+`, `-`, és `=` általában [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) formájában vannak hozzáadva és az kifejezésbe illesztve.

Integrálhoz használja a [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/)-t:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Mátrixok hozzáadása**

A sorok és oszlopok kezeléséhez használja a [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/). Alapértelmezés szerint a mátrixok nem tartalmaznak zárójeleket, ezért ha zárójelekre, szögletes vagy kapcsos zárókra van szükség, burkolja be a mátrixot.

![Két soros matematikai mátrix, egy üres cellával](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # A mátrix önmagában nem tartalmaz zárójelet, ezért zárójelek közé kell helyezni.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` felépíti a sor- és oszlopszövetet, beállítja a köztük lévő hézagokat, és igazítja az oszlopokat, de az Aspose.Slides for Python via .NET nem teszi elérhetővé az egyes mátrixcellák hozzáférését. A kódban létrehozott mátrix ezért üres cellákat tartalmaz; egy létező prezentációból származó mátrix celláit a `get_children` segítségével olvashatja. Használjon egyenlet tömböt, ha a sorokat kódból akarja feltölteni.
{{% /alert %}}

## **Egyenlet tömbök hozzáadása**

Használja a [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) függvényt, ha igazított egyenletekre vagy függőleges kifejezéskörre van szükség.

![Függőleges matematikai tömb, x felül, y alatt](powerpoint-math-equations_11.png)

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

### **Tömb igazítása a környező elemekkel**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) szabályozza egy tömb függőleges igazítását a mellette lévő matematikai elemekhez képest. Az alábbi példa összehasonlítja az igazítást az első sorral, a tömb közepével és az utolsó sorral.

A következő példa három azonos tömböt hoz létre, mindegyik három sorral és a szomszédos elemekkel `A=` és `=B`. Minden matematikai szöveg Cambria Math betűtípussal, 24 pontban van. Csak a tömb igazítása változik.

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

Az alábbi összehasonlítás megmutatja a mentett prezentációt PowerPointban. Figyelje meg az `A=` és `=B` pozícióját minden tömb mellett.

![Egyenlet tömbök PowerPointban felső, középső és alsó igazítással és azonos környező elemekkel](equation-array-alignment.png)

### **Sor távolság beállítása**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) kiválasztja a sorok közti távolság szabályát a tömbön belül. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) numerikus értéket ad meg egy explicit távolság szabályhoz, és a beépített szabályok figyelmen kívül hagyják.

Pontos távolságnál az értéket pontban mérik. Arányos távolságnál fél sorban: a példában a `3` érték 1,5 sort jelent. Mindkét tulajdonságot állítsa be explicit érték megadásakor; csak a numerikus érték módosítása nem választ szabályt.

Az alábbi példa öt prezentációt ment ugyanazzal az egyenlettel, igazítással és betűtípus beállításokkal. Az első három előre beállított szabályt használ; az utolsó két explicit értéket mutat.

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

A tömb sorok közti távolság elkülönül a bekezdés távolságától. A [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) és a [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) a környező bekezdés körül ad helyet, nem a tömb sorai között. Hasonlóan, az [IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) a teljes matematikai bekezdést helyezi vízszintesen; nem felülírja a tömb függőleges igazítási beállítását.

## **Trigonometrikus függvények hozzáadása**

Használja a [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) függvényt, amikor az argumentum a jelenlegi elem, és a függvény neve ismert.

![A cos trigonometrikus függvény alkalmazva 2x-re](powerpoint-math-equations_6.png)

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

## **Alsó- és felső indexek hozzáadása**

Használja az alsó- és felső index segédfüggvényeit indexekhez és hatványokhoz. Ha az indexeknek az alap bal oldalán kell megjelenniük, használja a [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/)‑t.

![Egy nagy Y baloldali alsó index 1-gyel és felső index n-mel](powerpoint-math-equations_9.png)

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

## **Elválasztók hozzáadása**

A [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) használatával helyezhet egy kifejezést elválasztók közé. Több elemet tartalmazó elválasztó kifejezésekhez megadhat egy elválasztó karaktert is.

![Elválasztó kifejezés, amely x-et, y-t és z-t tartalmaz, függőleges vonalakkal elválasztva](powerpoint-math-equations_13.png)

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

### **Elválasztók mérete és igazítása**

Állítsa a [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) értékét `True`‑ra, hogy a zárójelek a magas operandus körül nőjenek, vagy `False`‑ra, hogy a normál méretet megtartsák. A [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) két [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) érték egyiket veszi fel. A `CENTERED` a zárójeleket a matematikai tengely közepére helyezi, amely az egyenlőségjel közepén halad. A `MATCH` a tartalomhoz igazítja őket. Mindkét beállítás csak az elválasztókat érinti. A belső kifejezés változatlan marad.

Az példa egy törtet helyez az `x` kitevőjébe, így a kifejezés a vonal felett tovább nyúlik, mint alatta. Mind a négy egyenlet ugyanazt a zárójelet és betűtípus beállítást használja.

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

PowerPointban hasonlítsa össze a sorokat a növekedés hatásának megtekintéséhez. A felső sorban a zárójelek növekednek, hogy körbevegyék a kitevőt, és mindkét alakzat hasonló. Az alsó sorban a növekedés ki van kapcsolva. A bal oldali kisebb zárójelek (`CENTERED`) az egyenlőségjelhez igazodnak, míg a jobb oldali (`MATCH`) magasabban helyezkednek el a kifejezés körül.

![Négy egyenlet PowerPointban, a delimiter növekedés engedélyezve felül és letiltva alul, a bal oldalon CENTERED, a jobb oldalon MATCH](delimiter-sizing.png)

## **Szegélydoboz hozzáadása**

A [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) hívásával egy tört köré keretezhető az egész kifejezés. A visszaadott [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) alapértelmezés szerint négy oldalt mutat. Használja a [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/), és a [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) függvényeket az egyes oldalak eltávolításához.

A példa hat példányt helyez ugyanabból a törtből egy diára. A törlés megjelenítéséhez rejtsük el a négy oldalt, és állítsuk be a [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/)‑t egy emelkedő átlóhoz (↗) vagy a [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/)‑t egy lejtő átlóhoz (↘). Használhatja a [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) vagy a [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) függvényeket bármely látható oldalak kombinációjával.

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

![Hat szerkeszthető tört PowerPointban. Felső sor: teljes szegély, alsó és bal oldalak, emelkedő átló. Alsó sor: lejtő átló, vízszintes vonal, függőleges vonal teljes szegéllyel.](border-box-fractions.png)

Ezen a törtön a vízszintes áthúzás átfedi a törtvonalat. A függőleges áthúzás áthalad a számláló és a nevező felett, míg a környező szegély látható marad. Ezek a vonalak az egész kifejezést díszítik. Az egyszerű szöveg áthúzása a szövegfutam karaktereire vonatkozik. A prezentáció PowerPointban való újbóli megnyitása után továbbra is szerkesztheti a számlálót és nevezőt külön‑külön.

## **Láthatóság és elrendezés vezérlése fantom elemekkel**

Egy kifejezést csomagoljon be a [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) segítségével, hogy önállóan szabályozza a láthatóságát és a egyenlethez hozzáadott helyet. Az [IMathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/) tulajdonságai a következőket vezérlik:

| Tulajdonság | Hatás |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/show/) | `False`‑ra állítva rejtse el a kifejezést. Méretei továbbra is hatnak az elrendezésre, hacsak az alábbi megfelelő tulajdonságok nem `True`. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/zero_width/) | A kifejezés vízszintes szélességét nulla értékre tekinti, így a szomszédos elemek közelebb mozgathatók. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/zero_asc/) | A kitevőjét, a vonal feletti magasságot nulla értékre tekinti. Ez csökkentheti a felső elem feletti helyet. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/zero_desc/) | A lejtőjét, a vonal alatti mélységet nulla értékre tekinti. Ez egy törtvonalat vagy egyéb tartalmat közelebb hozhat a környező elemekhez. |

A vonal az a referencia, amelyen a szokásos matematikai betűk állnak. A tartalom elrejtése nem távolítja el a méreteket, és egy dimenzió nullának tekintése nem törli a kifejezést. Az alapprogramozott kifejezés a [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/base/)‑on keresztül továbbra is elérhető. Állítsa a [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/show/)‑t `True`‑ra, hogy újból megjelenjen; a dimenzió beállítások változatlanok maradnak.

Az alábbi példa öt egymás mellett elhelyezett változatot hoz létre: egy látható tört, egy helyet fenntartó rejtett tört, és három rejtett tört, ahol egy dimenzió nulla értéken van. Minden változat ugyanazt a környező kifejezést és Cambria Math betűtípust 24 pontban használja. Minden egyenlet alakzat ugyanabban a felső pozícióban van, a szürke segédvonallal jelölve. A fantom elhelyezése egy külső tört számlálójába könnyebben láthatóvá teszi a függőleges elrendezésváltozásokat.

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

![Öt egyenlet PowerPointban, összehasonlítva egy látható törtet, egy helyet fenntartó rejtett törtet, és ZeroWidth, ZeroAsc vagy ZeroDesc engedélyezett rejtett törteket](math-phantom.png)

## **Kifejezések csoportosítása**

Használja a [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) függvényt, hogy egy csoportosító karaktert helyezzen egy kifejezés fölé vagy alá. Hozzáadhat határt a csoportosított kifejezések címkézéséhez.

![Az x plusz y kifejezés csoportosítva, alatti címke bármilyen szöveg](powerpoint-math-equations_15.png)

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

## **Matematikai elemek formázása**

Csak ott használjon formázó segédfüggvényeket, ahol azok egyértelművé teszik a képletet. Például a [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) egy vonalat helyez egy matematikai elem felett.

![ABC matematikai kifejezés felülről vonallal](powerpoint-math-equations_14.png)

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

### **Szöveg formázása meglévő egyenletben**

A szöveg formázásához egy meglévő egyenletben járja be az egyes matematikai blokkok elemfáját. Az [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) csak a közvetlen gyerekeket adja vissza, ezért rekurzívan kell hívni, hogy elérje a tört, index, gyök és más beágyazott struktúrák szövegét. Ellenőrizze a jelenlegi elemet és annak gyerekeit is, hogy a kiinduló elem is benne legyen, ha az [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) típusú.

Ez a példa azt feltételezi, hogy a `input.pptx` olyan egyenletet tartalmaz, mint `z = xᵢ / ∛y`, egy törtet, amelynek számlálójában alsó index, a nevezőjében pedig gyök található. Ha csak a blokk felső szintű elemeit dolgozza fel, a tört belső szövege kimarad. A példa a diá szövegkeretekben keresi a matematikai részeket, a [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) segítségével eléri a blokkokat, és minden szövegelemtől a [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) tulajdonságát 28 pontra állítja a [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) segítségével.

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

A mentett prezentáció minden szintjén frissített szövegformázást tartalmaz a feldolgozott egyenletekben, miközben megőrzi a szövegtartalmat és a matematikai struktúrát.

## **Gyorsreferencia**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Elemek kombinálása | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| Törtek létrehozása | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Felső vagy alsó index hozzáadása | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Gyökök hozzáadása | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Határok hozzáadása | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Baloldali indexek hozzáadása | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Összeadások és integrálok hozzáadása | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Elválasztók hozzáadása | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Vonalak és szegélyek hozzáadása | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Kifejezések csoportosítása | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **GYIK**

**Szerkeszthetek meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely egy [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) tartalmaz, szerezze meg a [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) attribútumát, és frissítse a bekezdésben lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint matematikaként mentődnek?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office matematikaként írja.

**Exportálhatok egyenleteket LaTeX‑be?**

Igen. Szerezze meg az egyenlet [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)‑ját a [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)‑ból, és hívja a [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/)‑t a közvetlen exporthoz. Teljes példáért lásd a [Matematikai egyenletek exportálása prezentációkból Pythonon keresztül .NET](/slides/hu/python-net/exporting-math-equations/#export-math-equations-to-latex).