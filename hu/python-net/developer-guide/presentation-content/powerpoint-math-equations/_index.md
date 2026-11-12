---
title: Matematikai egyenletek hozzáadása PowerPoint prezentációkhoz Pythonban
linktitle: PowerPoint matematikai egyenletek
type: docs
weight: 80
url: /hu/python-net/powerpoint-math-equations/
keywords:
- matematikai egyenlet
- matematikai szimbólum
- matematikai képlet
- matematikai szöveg
- matematikai egyenlet hozzáadása
- matematikai szimbólum hozzáadása
- matematikai képlet hozzáadása
- matematikai szöveg hozzáadása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Python via .NET segítségével, OMML támogatással, formázási vezérlőkkel és tiszta Python kódmintákkal."
---
## **Áttekintés**

A PowerPoint a képleteket Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Python via .NET segítségével programozottan hozhat létre ugyanilyen matematikai tartalmakat: törtöket, gyököket, függvényeket, határokat, N-értékű operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

PowerPointban a felhasználók általában a **Insert > Equation** menüpontból adnak hozzá egyenleteket:

![PowerPoint Insert lapfül, ahol a Equation parancs ki van jelölve](powerpoint-math-equations_1.png)

Az eredmény szerkeszthető matematikai szöveg a dián:

![Egy PowerPoint dia, amely szerkeszthető matematikai egyenletet tartalmaz](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektum segítségével építi fel ezt a matematikai szöveget:

- A math shape, created with [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), a forma, amely az egyenletet tartalmazza.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) a matematikai tartalmat a forma szövegdobozában tárolja.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) objektumot tartalmaz.

Az alábbi példák a [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) valamint az [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) folyékony metódusait használják, hogy a kód rövid és olvasható legyen.

Exportálja a matematikai egyenleteket a prezentációkból Pythonon keresztül .NET ([Export Math Equations from Presentations in Python via .NET](/slides/hu/python-net/exporting-math-equations/)).

## **Egyenlet létrehozása**

Ez a példa a [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) használatával hoz létre egy math shape-et, és hozzáadja a Pithagorasz-tételt:

![Az egyenlet: c² = a² + b²](powerpoint-math-equations_3.png)

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

[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) olyan alakzatot hoz létre, amely már tartalmaz egy math paragraph-et. A első [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) elérésével, a [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) lekérdezésével adhat hozzá math block-okat vagy math elemeket.

{{% /alert %}}

## **Tört hozzáadása**

Használja a [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) funkciót tört létrehozásához. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) segítségével választhatja.

![Egy ferde matematikai tört, amely 1/x-et mutat](powerpoint-math-equations_4.png)

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

A rétegezett tört esetén használja a [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/)-t:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Gyökök hozzáadása**

Használja a [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) függvényt négyzetgyök, köbgyök vagy más gyök létrehozásához. A jelenlegi elem lesz az alap, a argumentum pedig a fok.

![Egy n-dik gyök kifejezés, ahol x a gyökjel alatti](powerpoint-math-equations_5.png)

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

Használja az [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) vagy a [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) függvényt olyan függvényekhez, mint a `sin(x)`, `log(x)`, vagy egyedi függvénynevek. Határok esetén helyezze a `lim`-et egy [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) objektumba, vagy használja a [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

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

Egy egyedi függvény névhez tegye a függvénynevet a jelenlegi elemnek, és hívja meg a [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) a paraméterével:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-értékű operátorok és integrálok hozzáadása**

Használja a [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) funkciót összegekre, uniókra, metszetekre és egyéb nagy operátorokra. Integrálokhoz használja a [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) függvényt. Mindkét módszerrel beállítható az alsó és felső határ.

![Egy összegzés alsó és felső határral](powerpoint-math-equations_7.png)

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

N-értékű operátorok nagy operátorok opcionális határokkal. Egyszerű operátorok, mint a `+`, `-`, és `=` általában [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) segítségével kerülnek a kifejezésbe.

Integrál esetén használja a [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/)-t:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) oszlopok és sorok kezelésére. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért a mátrixot zárójelek, szögletes zárójelek vagy kapcsos zárójelek közé kell helyezni, ha szükséges.

![Egy két soros matematikai mátrix egy üres cellával](powerpoint-math-equations_10.png)

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
A `MathMatrix` felépíti a sor- és oszlopszövetet, beállítja a közti hézagokat, és igazítja az oszlopokat, de az Aspose.Slides for Python via .NET nem biztosít hozzáférést egyedi mátrixcellához. A kódban létrehozott mátrix ezért üres cellákat tartalmaz; egy meglévő prezentációból származó mátrix cellái `get_children` segítségével olvashatók. Egy egyenlet tömböt használjon, ha sorokat kell kódból feltölteni.
{{% /alert %}}

## **Egyenlet tömbök hozzáadása**

A [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) használata ajánlott, ha igazított egyenletekre vagy függőleges kifejezésstack-re van szükség.

![Egy függőleges matematikai tömb, ahol x van y felett](powerpoint-math-equations_11.png)

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

## **Trigonometrikus függvények hozzáadása**

Használja az [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/)‑t, ha az argumentum a jelenlegi elem, és a függvény neve ismert.

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

## **Alsó- és felsőindexek hozzáadása**

Használja az alsó- és felsőindex segédfüggvényeket indexek és hatványok kezelésére. Ha az indexeknek a bázis bal oldalán kell megjelenniük, használja a [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Egy nagy Y nagybetű baloldali alsóindexszel 1 és felsőindexszel n](powerpoint-math-equations_9.png)

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

Használja a [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/)‑t, hogy egy kifejezést elválasztók közé helyezzen. Több elemet tartalmazó elválasztók kifejezéseknél beállíthat egy elválasztó karaktert is.

![Egy elválasztó kifejezés, amely x, y és z-t függőleges vonalakkal választ el](powerpoint-math-equations_13.png)

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

### **Méret és igazítás elválasztók**

Sételje be a [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) értékét `True`‑ra, hogy a zárójelek egy magas operandus körül növekedjenek, vagy `False`‑ra, hogy normál méretben maradjanak. A [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) a két [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) közül egyikét veszi fel. A `CENTERED` a zárójeleket a matematikai tengely közepére helyezi, amely áthalad az egyenlőség jel közepén. A `MATCH` a zárójeleket a tartalommal igazítja. Mindkét beállítás csak az elválasztókra hat, a bennük lévő kifejezés változatlan marad.

A példában egy törtet helyeznek el az `x` kitevőjébe, így a kifejezés a vonal felett tovább nyúlik, mint alatta. A négy egyenlet ugyanazokat a zárójeleket és betűtípust használja.

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

PowerPointban hasonlítsa össze a sorokat a növekedés hatásának megtekintéséhez. A felső sorban a zárójelek növekednek, hogy befoglalják a kitevőt, és mindkét alakzat hasonló lesz. Az alsó sorban a növekedés ki van kapcsolva. A baloldali kisebb zárójelek (`CENTERED`) az egyenlőség jelhez igazodnak, míg a jobb oldali (`MATCH`) magasabban helyezkednek el a kifejezés körül.

![Négy egyenlet PowerPointban, ahol a felső sorban engedélyezett az elválasztó növekedés, az alsóban le van tiltva, balra CENTERED, jobbra MATCH](delimiter-sizing.png)

## **Határdoboz hozzáadása**

Kérje a [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) hívását egy törtön, hogy az egész kifejezést keretet kapja. A visszaadott [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) alapértelmezés szerint mind a négy oldalt megjeleníti. A [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/) és [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) használatával eltávolíthatja az egyes oldalakat.

A példa hat példányt helyez el ugyanabból a törtből egy dián. A megszüntetés megjelenítéséhez rejtse el mind a négy oldalt, és állítsa be a [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) egy emelkedő átló (↗) vagy a [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) egy lejtő átló (↘) használatával. A [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) vagy [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) is használható a látható oldalak bármilyen kombinációjával.

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

![Hét szerkeszthető tört PowerPointban. Felső sor: teljes szegély, alsó és bal oldalak, emelkedő átló. Alsó sor: lejtő átló, vízszintes áthúzás, függőleges áthúzás teljes szegéllyel](border-box-fractions.png)

Ezen a törtön a vízszintes áthúzás átfedi a tört vonalát. A függőleges áthúzás áthalad a számlálón és a nevezőn is, miközben a környező szegély látható marad. Ezek a vonalak az egész kifejezést díszítik. A normál szöveg áthúzása a szövegrész karaktereire vonatkozik. A prezentáció PowerPointban való újbóli megnyitása után is szerkesztheti a számlálót és a nevezőt külön-külön.

## **Kifejezések csoportosítása**

Használja a [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/)‑t, hogy egy csoportosító karaktert helyezzen a kifejezés fölé vagy alá. Határozzon meg egy limitet a csoportosított kifejezések címkézéséhez.

![Az x + y kifejezés csoportosítva, a címke bármilyen szöveg alatta](powerpoint-math-equations_15.png)

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

Használja a formázó segédfüggvényeket csak ott, ahol a képletet tisztábbá teszik. Például a [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) egy vonalat helyez a matematikai elem fölé.

![Egy ABC matematikai kifejezés, amelyen egy túlvonal van](powerpoint-math-equations_14.png)

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

### **Szöveg formázása egy meglévő egyenletben**

Egy meglévő egyenlet szövegének formázásához járja be minden math block elemfáját. A [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan kell hívni, hogy elérje a tört, szkript, gyök és egyéb beágyazott szerkezetek szövegét. Ellenőrizze a jelenlegi elemet és annak gyermekeit is, hogy a kiinduló elemet is belefoglalja, ha az [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Ez a példa azt feltételezi, hogy az `input.pptx` egy olyan egyenletet tartalmaz, mint például `z = xᵢ / ∛y`, ahol a tört a számlálóban alsóindexet, a nevezőben gyököt tartalmaz. Ha csak a block felső szintű elemeit dolgozzuk fel, a tört belsejében lévő szöveget elmulasztjuk. A példa megtalálja a matematikai részeket a dia szövegdobozokban, eléri azok blockjait a [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) segítségével, és [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) értékét 28 pontra állítja minden szövegelem [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) tulajdonságán keresztül.

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

A mentett prezentáció minden feldolgozott egyenlet minden szintjén tartalmazza a frissített szövegformázást, miközben megőrzi a szöveg tartalmát és a matematikai szerkezetet.

## **Gyorsreferencia**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Elemt összekapcsolása | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| Törtek létrehozása | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Felső- vagy alsóindex hozzáadása | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Gyökök hozzáadása | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Határok hozzáadása | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Baloldali indexek hozzáadása | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Összegek és integrálok hozzáadása | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Elválasztók hozzáadása | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Vonalak és szegélyek hozzáadása | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Kifejezések csoportosítása | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **GYIK**

**Módosíthatok meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt a formát, amely egy [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) tartalmaz, szerezze meg a [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), és frissítse a blockokban található math block-okat abban a bekezdésben.

**A egyenletek szerkeszthető PowerPoint matematikaként vannak mentve?**

Igen. PPTX‑re mentéskor az Aspose.Slides az egyenletet szerkeszthető Office math tartalomként írja.

**Exportálhatok egyenleteket LaTeX‑be?**

Igen. Szerezze meg az egyenlet [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) objektumát a [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) segítségével, és hívja meg a [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) metódust a közvetlen exportáláshoz. Teljes példáért tekintse meg a [Exportáljon matematikai egyenleteket a prezentációkból Pythonon keresztül .NET](/slides/hu/python-net/exporting-math-equations/#export-math-equations-to-latex).