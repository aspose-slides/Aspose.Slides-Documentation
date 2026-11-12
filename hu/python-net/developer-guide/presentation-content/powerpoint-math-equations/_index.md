---
title: Matematikai egyenletek hozzáadása PowerPoint prezentációkhoz Pythonban
linktitle: PowerPoint matematikai egyenletek
type: docs
weight: 80
url: /hu/python-net/powerpoint-math-equations/
keywords:
- matematikai egyenlet
- matematikai szimbólum
- matematikai formula
- matematikai szöveg
- matematikai egyenlet hozzáadása
- matematikai szimbólum hozzáadása
- matematikai formula hozzáadása
- matematikai szöveg hozzáadása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Python via .NET segítségével, OMML támogatással, formázási beállításokkal és átlátható Python kódpéldákkal."
---
## **Áttekintés**

A PowerPoint az egyenleteket Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Python via .NET segítségével programozottan hozhat létre ugyanilyen matematikai tartalmat: törtek, gyökök, függvények, határok, N-áris operátorok, mátrixok, tömbök és formázott matematikai blokkok.

PowerPointban a felhasználók általában a **Insert > Equation** menüpontból adnak hozzá egyenleteket:

![PowerPoint beszúrási lapon az Equation parancs kiválasztva](powerpoint-math-equations_1.png)

Az eredmény egy szerkeszthető matematikai szöveg a dián:

![PowerPoint dia szerkeszthető matematikai egyenlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides a matematikai szöveget három fő objektumon keresztül építi fel:

- Egy matematikai alakzat, amelyet a [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) hoz létre, az az alakzat, amely az egyenletet tartalmazza.
- A [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) tárolja a matematikai tartalmat az alakzat szövegdobozában.
- A [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) folyékony metódusait használja a kód rövid és olvasható tartásához.

MathML export esetén lásd a [Export Math Equations from Presentations in Python via .NET](/slides/hu/python-net/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa a [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) használatával hoz létre egy matematikai alakzatot, és hozzáadja a Pithagorasz-tételt:

![A c négyzet egyenlő a a négyzetével plusz b négyzetével](powerpoint-math-equations_3.png)

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Nyissa meg az első [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)-t, szerezze meg a [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)-t, és adjon hozzá matematikai blokkokat vagy elemeket.
{{% /alert %}}

## **Törtek hozzáadása**

Használja a [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) metódust törtek létrehozásához. Törtszerkezetet a [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) segítségével választhat.

![Egy ferde matematikai tört, amely egyet oszt el x-szel](powerpoint-math-equations_4.png)

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

Halmozott tört esetén használja a [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) értéket:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Gyökök hozzáadása**

Használja a [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) metódust négyzetgyök, köbgyök vagy egyéb gyök létrehozásához. A jelenlegi elem lesz az alap, az argumentum pedig a gyök fokszáma.

![n-dik gyök, amelyben x áll a gyökjel alatt](powerpoint-math-equations_5.png)

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

## **Függvények és határok hozzáadása**

Használja a [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) vagy a [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) metódust olyan függvényekhez, mint a `sin(x)`, `log(x)` vagy egyedi függvénynevek. Határok esetén helyezze a `lim`-et egy [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) objektumba, vagy használja a [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) metódust.

![Az x határa, amikor x a végtelen felé tart](powerpoint-math-equations_8.png)

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

Egyedi függvénynevekhez tegye a függvénynevet a jelenlegi elemnek, majd hívja a [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) metódust az argumentummal:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-áris operátorok és integrálok hozzáadása**

Használja a [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) metódust összegekre, uniókra, metszetekre és egyéb nagy operátorokra. Az integrálokhoz használja az [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) metódust. Mindkét módszer lehetővé teszi a felső és alsó határ beállítását.

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

Az N-áris operátorok nagy operátorok, opcionális határokkal. Az egyszerű operátorok, mint a `+`, `-` és `=` általában [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) használatával kerülnek a kifejezésbe.

Integrál esetén használja a [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) metódust:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) osztályt sorok és oszlopok definiálásához. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért ha zárójelekre, szögletes vagy kapcsos zárójelekre van szükség, a mátrixot ezekkel kell körülvenni.

![Két soros matematikai mátrix, egy üres cellával](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # A mátrixnak nincs saját zárójele, ezért zárójelbe kell tenni.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` építi a sor- és oszloprácsot, beállítja a közök közti hézagot, és igazítja az oszlopokat, de az Aspose.Slides for Python via .NET nem tesz elérhetővé hozzáférést egyedi mátrixcellához. A kódból létrehozott mátrix tehát üres cellákat tartalmaz; a meglévő prezentációból származó mátrix celláit a `get_children` metódussal lehet olvasni. Ha sorokat kell kódból feltölteni, használjon egyenlet tömböket.
{{% /alert %}}

## **Egyenlet tömbök hozzáadása**

Használja a [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) metódust, ha igazított egyenletekre vagy függőleges kifejezésstackre van szükség.

![Függőleges matematikai tömb, x a y felett](powerpoint-math-equations_11.png)

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

### **Tömb igazítása a környező elemekhez**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) szabályozza a tömb függőleges igazítását a mellette lévő matematikai elemekhez képest. Az alábbi példa az első sor, a tömb középpontja és az utolsó sor igazítását mutatja össze.

A következő példa három azonos tömböt hoz létre, mindegyik három sorral és a szomszédos elemekkel `A=` és `=B`. Minden matematikai szöveg 24 pont Cambria Math betűtípussal jelenik meg. Csak a tömb igazítása változik.

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

Az alábbi összehasonlítás a PowerPointban mentett prezentációt mutatja. Figyelje meg az `A=` és `=B` pozícióját minden tömb mellett.

![Egyenlet tömbök PowerPointban felső, középső és alsó igazítással, azonos szomszédos elemekkel](equation-array-alignment.png)

### **Sorok távolságának beállítása**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) választja ki a sorok közti távolság szabályát a tömbben. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) egy numerikus értéket ad meg egy explicit szabálynak, a beépített szabályok viszont figyelmen kívül hagyják.

Pontos távolságnál az érték pontban van megadva. Arányos távolságnál fél‑sorokban mér: a példában a `3` érték 1,5 sort jelent. Az explicit érték megadásakor mindkét tulajdonságot be kell állítani; csak a numerikus érték módosítása nem választ szabályt.

Az alábbi példa öt prezentációt ment ugyanazzal a képlettel, igazítással és betűtípus-beállítással. Az első három előre definiált beállítást használ, az utolsó kettő explicit értékeket mutat.

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

A tömb sorok távolsága különbözik a bekezdés távolságától. A [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) és a [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) a körülvevő bekezdés köré ad helyet, nem a tömb sorok közé. Hasonlóképpen az [IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) a teljes matematikai bekezdést vízszintesen helyezi el; nem módosítja a tömb függőleges igazítási beállítását.

## **Trigonometrikus függvények hozzáadása**

Használja a [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) metódust, amikor az argumentum a jelenlegi elem, és a függvény neve ismert.

![A trigonometrikus cos függvény alkalmazva 2x‑re](powerpoint-math-equations_6.png)

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

Használja az alsó‑ és felső‑index segédfüggvényeket indexek és hatványok létrehozásához. Ha az indexeknek a bázis bal oldalán kell megjelenniük, használja a [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) metódust.

![Nagy Y betű baloldali alsó indexszel 1 és felső indexszel n](powerpoint-math-equations_9.png)

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

## **Határolók hozzáadása**

Használja az [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) metódust, hogy egy kifejezést határolók közé helyezzen. Több elemet tartalmazó határolók esetén beállíthat egy elválasztó karaktert is.

![Határoló kifejezés, amely x‑et, y‑t és z‑t függőleges vonalakkal választ el](powerpoint-math-equations_13.png)

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

### **Határolók mérete és igazítása**

Állítsa a [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) értékét **True**‑ra, hogy a zárójelek nagyobb operandus körül növekedjenek, vagy **False**‑ra, ha normál méretűek maradjanak. A [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) a két [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) érték egyikét veheti fel. A `CENTERED` a zárójeleket a matematikai tengely közepére helyezi, amely a = jel közepén halad. A `MATCH` a tartalomhoz igazítja őket. Mindkét beállítás csak a határolókra hat, a kifejezés belseje változatlan marad.

A példa egy törtet helyez az `x` kitevőjébe, így a kifejezés a bazisszint fölött nagyobb, mint alatta. A négy egyenlet ugyanazokat a zárójeleket és betűtípus‑beállításokat használja.

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

PowerPointban hasonlítsa össze a sorokat a növekedés hatását láthatja. A felső sorban a zárójelek a kitevő körül növekednek, és mindkét forma hasonló. Az alsó sorban a növekedés ki van kapcsolva. A baloldali kisebb zárójelek (`CENTERED`) a = jelhez igazodnak, míg a jobboldali (`MATCH`) magasabban helyezkednek el a kifejezés körül.

![Négy egyenlet PowerPointban, a határolók növekedése felül engedélyezve, alul letiltva, baloldalon Centered, jobboldalon Match](delimiter-sizing.png)

## **Határoló keret hozzáadása**

Hívja a [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) metódust egy törtön, hogy a teljes kifejezést keretezze. A visszakapott [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) alapértelmezés szerint a négy oldalt is mutatja. A [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/) és [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) használatával egyes oldalakat távolíthat el.

A példa hat másolatot helyez ugyanabból a törtből egy diára. A törlés megjelenítéséhez rejtse el az összes oldalt, és állítsa be a [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) vonalat egy emelkedő átlóhoz (↗), vagy a [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) vonalat egy leszálló átlóhoz (↘). Használhatja a [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) vagy a [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) metódusokat is, tetszőleges kombinációban a látható oldalakkal.

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

![Hat szerkeszthető tört PowerPointban. Felső sor: teljes keret, alsó és bal oldalak, emelkedő átló. Alsó sor: leszálló átló, vízszintes átló, függőleges átló teljes kerettel.](border-box-fractions.png)

Ezen tört esetén a vízszintes átló átfedi a törtvonalat. A függőleges átló átszeli a számlálót és a nevezőt, miközben a körülvevő keret látható marad. Ezek a vonalak a teljes kifejezést díszítik. A szokásos szöveg‑áthúzás csak a szövegfutam karaktereire vonatkozik. A prezentáció PowerPoint‑ban való újranyitása után is szerkesztheti a számlálót és a nevezőt külön‑külön.

## **Kifejezések csoportosítása**

Használja a [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) metódust, hogy egy csoportosító karaktert helyezzen egy kifejezés fölé vagy alá. Adj hozzá egy határt a csoportosított kifejezések feliratozásához.

![Az x + y kifejezés csoportosítva egy alatta lévő szöveggel](powerpoint-math-equations_15.png)

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

Használja a formázó segédfüggvényeket csak ott, ahol a képletet tisztábbá teszik. Például a [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) egy vonalat helyez egy matematikai elem fölé.

![ABC matematikai kifejezés túlvonallal](powerpoint-math-equations_14.png)

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

A szöveg minden részének formázásához járja be a matematika blokk elemei közötti fa struktúrát. Az [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan kell hívni, hogy elérje a szöveget törtekben, felső‑/alsó‑indexekben, gyökökben és egyéb beágyazott struktúrákban. Ellenőrizze a jelenlegi elemet és annak gyermekeit is, hogy a kiinduló elem is benne legyen, ha az [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Ez a példa feltételezi, hogy a `input.pptx` egy olyan egyenletet tartalmaz, mint például `z = xᵢ / ∛y`, ahol a tört számlálójában alsó‑index, a nevezőjében pedig gyök található. Ha csak a blokk felső‑szintű elemeit dolgozza fel, a törtben lévő szöveget elmulasztja. A példa megtalálja a matematikai részeket a dia szövegdobozában, a blokkokat a [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) segítségével érheti el, és a [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) értékét 28 pontra állítja minden szövegelemen keresztül a [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) tulajdonságon keresztül.

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

A mentett prezentáció minden feldolgozott egyenlet minden szintjén frissített szövegformázást tartalmaz, miközben megőrzi a szövegtartalmat és a matematikai struktúrát.

## **Gyors referencia**
| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Elemmek egyesítése | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| Törtek létrehozása | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Felső‑ vagy alsóindex hozzáadása | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Gyökök hozzáadása | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Határok hozzáadása | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Baloldali indexek hozzáadása | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Összegek és integrálok hozzáadása | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Határolók hozzáadása | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Vonalkák és keretek hozzáadása | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Kifejezések csoportosítása | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **GYIK**
**Szerkeszthetek egy meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)‑t tartalmaz, szerezze meg a [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)-t, és frissítse az ott lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint‑matematikaként vannak mentve?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office‑math tartalomként írja ki.

**Exportálhatok egyenleteket LaTeX‑be?**

Igen. Szerezze meg a [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)‑t a [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)-ról, és hívja a [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) metódust a közvetlen exportáláshoz. Teljes példa a [Export Math Equations from Presentations in Python via .NET](/slides/hu/python-net/exporting-math-equations/#export-math-equations-to-latex) oldalon található.