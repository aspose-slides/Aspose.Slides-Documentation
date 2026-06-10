---
title: Math egyenletek hozzáadása PowerPoint prezentációkhoz Pythonban
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
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Python via .NET segítségével, OMML támogatással, formázási vezérlőkkel és áttekinthető Python kódmintákkal."
---
## **Áttekintés**

A PowerPoint egyenleteket Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Python via .NET segítségével programozottan létrehozhatja ugyanazt a matematikai tartalmat: törtek, gyökök, függvények, határok, N-áris operátorok, mátrixok, tömbök és formázott matematikai blokkok.

A PowerPointban a felhasználók általában a **Insert > Equation** menüponttal adnak hozzá egyenleteket:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

Az eredmény szerkeszthető matematikai szöveg a dián:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Az Aspose.Slides ezen a matematikai szövegen három fő objektumon keresztül épít fel:

- A matematikai alakzat, amelyet a [add_math_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_math_shape/) hoz létre, az a forma, amely tartalmazza az egyenletet.
- [MathPortion](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathportion/) tárolja a matematikai tartalmat a forma szövegtáblájában.
- [MathParagraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/) folyékony módszereit használja, hogy a kód rövid és olvasható legyen.

MathML exportálási esetekhez lásd a [Export Math Equations from Presentations in Python via .NET](/slides/hu/python-net/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa egy matematikai alakzatot hoz létre, és hozzáadja a Pitagorasz-tételt:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

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

`add_math_shape` egy olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Hozzáfér az első `MathPortion`-höz, lekéri annak `MathParagraph`-ját, és hozzáadja a matematikai blokkokat vagy matematikai elemeket.

{{% /alert %}}

## **Törtek hozzáadása**

Használja a [`divide`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/divide/) függvényt törtek létrehozásához. A törttípus kiválasztásához használhatja a [MathFractionTypes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathfractiontypes/) lehetőséget.

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

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

Halmozott tört létrehozásához használja a `MathFractionTypes.BAR`-t:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Gyökök hozzáadása**

Használja a [`radical`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/radical/) függvényt négyzetgyök, köbgyök vagy más gyök létrehozásához. Az aktuális elem lesz az alap, a paraméter pedig a gyök kitevője.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

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

Használja a [`as_argument_of_function`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) vagy a [`function`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/function/) függvényeket olyan függvényekhez, mint a `sin(x)`, `log(x)`, vagy egyedi függvénynevekhez. Határok esetén helyezze a `lim`-et egy [MathLimit](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathlimit/) objektumba, vagy használja a [`set_lower_limit`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) függvényt.

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

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

Egyedi függvénynév esetén tegye a függvénynevet az aktuális elemmé:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-áris operátorok és integrálok hozzáadása**

Használja a [`nary`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/nary/) függvényt összeadások, uniók, metszetek és más nagy operátorok esetén. Integrálokhoz használja a [`integral`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/integral/) függvényt. Mindkét módszerrel megadhatja az alsó és felső határokat.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

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

Az N-áris operátorok nagy operátorok opcionális határokkal való használatához szolgálnak. Az egyszerű operátorok, mint a `+`, `-`, és `=`, általában `MathematicalText`‑ként kerülnek hozzáadásra, majd az kifejezésbe fűzve.

Integrálhoz használja a `integral`-t:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathmatrix/) oszlopok és sorok létrehozásához. Alapértelmezésként a mátrixok nem tartalmaznak zárójeleket, ezért ha zárójelekre, szögletes vagy kapcsos zárókra van szükség, akkor kézzel kell őket körülvenni.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

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

## **Egyenlet tömbök hozzáadása**

Használja a [`to_math_array`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/to_math_array/) függvényt, ha igazított egyenletekre vagy függőleges kifejezésstackre van szükség.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

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

Használja a [`as_argument_of_function`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) függvényt, ha a argumentum az aktuális elem és a függvény neve ismert.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

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

Használja az alsó- és felsőindex segédfüggvényeket indexek és hatványok esetén. Ha az indexeknek az alap bal oldalán kell megjelenniük, használja a [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) függvényt.

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

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

Használja a [`enclose`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/enclose/) függvényt egy kifejezés határolók közé helyezéséhez. Több elemet tartalmazó határolók esetén beállíthat egy elválasztó karaktert is.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

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

## **Keretdoboz hozzáadása**

Használja a [`to_border_box`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/to_border_box/) függvényt, ha maga az egyenlet keretezett legyen.

![A boxed equation showing a squared equals b squared plus c squared](powerpoint-math-equations_12.png)

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

## **Kifejezések csoportosítása**

Használja a [`group`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/group/) függvényt, hogy egy csoportosító karaktert helyezzen a kifejezés fölé vagy alá. Határ hozzáadásával címkézheti a csoportosított kifejezéseket.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

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

Használja a formázó segédfüggvényeket csak ott, ahol tisztázza a képletet. Például a [`overbar`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/overbar/) egy vonalat helyez a matematikai elem fölé.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

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

## **Gyors referencia**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Elemek egyesítése | [IMathElement.join](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/join/) |
| Törtek létrehozása | [IMathElement.divide](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Felső- vagy alsóindex hozzáadása | [set_superscript](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Gyökök hozzáadása | [radical](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Határok hozzáadása | [set_lower_limit](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Baloldali indexek hozzáadása | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Összeadások és integrálok hozzáadása | [nary](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [to_math_array](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Határolók hozzáadása | [enclose](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Vonalak és keretek hozzáadása | [overbar](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Kifejezések csoportosítása | [group](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/group/) |

## **GYIK**

**Szerkeszthetek egy meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely `MathPortion`-t tartalmaz, szerezze be annak `MathParagraph`-ját, és frissítse a bekezdésben lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint matematikaként mentődnek?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office matematikai tartalomként írja.

**Exportálhatok egyenleteket LaTeX-be?**

Az Aspose.Slides a matematikai egyenleteket MathML formátumba exportálja. Ha LaTeX-re van szüksége, először exportáljon MathML-be, majd a cél LaTeX dialektusát támogató eszközzel konvertálja át.