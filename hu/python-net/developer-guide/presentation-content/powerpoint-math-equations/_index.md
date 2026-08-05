---
title: Matematikai egyenletek hozzáadása PowerPoint prezentációkhoz Pythonban
linktitle: PowerPoint matematikai egyenletek
type: docs
weight: 80
url: /hu/python-net/powerpoint-math-equations/
keywords:
- matematikai egyenlet
- matematikai jel
- matematikai képlet
- matematikai szöveg
- matematikai egyenlet hozzáadása
- matematikai jel hozzáadása
- matematikai képlet hozzáadása
- matematikai szöveg hozzáadása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Matematikai egyenletek beillesztése és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Python via .NET segítségével, támogatja az OMML-t, a formázási vezérlőket és áttekinthető Python kódpéldákat."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Python via .NET segítségével programozott módon hozhat létre ugyanezt a típusú matematikai tartalmat: törtök, gyökök, függvények, határok, N-árnyú operátorok, mátrixok, tömbök és formázott matematikai blokkok.

A PowerPointban a felhasználók általában a **Insert > Equation** menüből adnak hozzá egyenleteket:

![PowerPoint Beszúrás lap a Képlet parancs kiválasztva](powerpoint-math-equations_1.png)

Az eredmény szerkeszthető matematikai szöveg a dián:

![PowerPoint dia szerkeszthető matematikai egyenlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides ezen matematikai szöveget három fő objektumon keresztül építi fel:

- Egy matematikai alakzat, amelyet a [add_math_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_math_shape/) segítségével hoz létre, az az alakzat, amely az egyenletet tartalmazza.
- [MathPortion](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathportion/) tárolja a matematikai tartalmat az alakzat szövegkeretén belül.
- [MathParagraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példában a [MathematicalText](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/) folyékony metódusait használjuk, hogy a kód rövid és olvasható legyen.

For MathML export scenarios, see [Export Math Equations from Presentations in Python via .NET](/slides/hu/python-net/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa egy matematikai alakzatot hoz létre, és hozzáadja a Pitagorasz‑tételt:

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

{{% alert color="primary" %}}
`add_math_shape` egy alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Az első `MathPortion` elérésével, a `MathParagraph`-t lekérdezve, hozzáadhat matematikai blokkokat vagy elemeket.
{{% /alert %}}

## **Törtek hozzáadása**

Használja a [`divide`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/divide/) függvényt tört létrehozásához. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathfractiontypes/) segítségével választhatja ki.

![Ferde matematikai tört, amely 1-et oszt x-szel](powerpoint-math-equations_4.png)

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

Használja a [`radical`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/radical/) függvényt négyzetgyök, köbgyök vagy egyéb gyök létrehozásához. Az aktuális elem lesz az alap, a argumentum a gyök fokát adja meg.

![n-edik gyök kifejezés, x a gyökjel alatt](powerpoint-math-equations_5.png)

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

Használja a [`as_argument_of_function`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) vagy a [`function`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/function/) függvényeket olyan függvényekhez, mint `sin(x)`, `log(x)`, vagy egyedi függvénynevekhez. Határokhoz helyezze a `lim`-et egy [MathLimit](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathlimit/) objektumba, vagy használja a [`set_lower_limit`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) függvényt.

![x határa, amikor x a végtelen felé tart](powerpoint-math-equations_8.png)

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

Egyedi függvénynévhez tegye a függvénynevet az aktuális elemnek:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-árnyú operátorok és integrálok hozzáadása**

Használja a [`nary`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/nary/) függvényt összeadások, uniók, metszetek és egyéb nagy operátorok esetén. Az [`integral`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/integral/) függvényt integrálokhoz. Mindkét metódus lehetővé teszi a alsó és felső határ beállítását.

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

Az N-árnyú operátorok nagy operátorok opcionális határokkal. Az egyszerű operátorok, mint a `+`, `-`, és `=` általában `MathematicalText`-ként kerülnek hozzáadásra és az egyenletbe illesztésre.

Integrálhoz használja a `integral`-t:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathmatrix/) oszlopok és sorok kezeléséhez. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért ha szükséges, zárójelek, szögletes vagy kapcsos zárójelek közé helyezze.

![Két soros matematikai mátrix egy üres cellával](powerpoint-math-equations_10.png)

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

Használja a [`to_math_array`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/to_math_array/) függvényt, ha igazított egyenletekre vagy függőleges kifejezéshalmazra van szükség.

![Függőleges matematikai tömb x felett y](powerpoint-math-equations_11.png)

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

Használja a [`as_argument_of_function`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) függvényt, ha az argumentum az aktuális elem, és a függvény neve ismert.

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

Használja az alsó- és felsőindex segédfüggvényeket indexek és hatványok számára. Ha az indexeknek az alap bal oldalán kell megjelenniük, használja a [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) függvényt.

![Nagy Y baloldali alsóindex 1 és felsőindex n](powerpoint-math-equations_9.png)

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

## **Határolójelek hozzáadása**

Használja a [`enclose`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/enclose/) függvényt kifejezés határolójelek közé helyezésére. Több elemet tartalmazó határoló kifejezésekhez beállíthat elválasztó karaktert is.

![Határoló kifejezés, amely x-et, y-t és z-t tartalmaz, függőleges vonalakkal elválasztva](powerpoint-math-equations_13.png)

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

## **Határoló doboz hozzáadása**

Használja a [`to_border_box`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/to_border_box/) függvényt, ha maga az egyenlet keretezésre szorul.

![Keretes egyenlet, amely a^2 = b^2 + c^2](powerpoint-math-equations_12.png)

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

Használja a [`group`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/group/) függvényt, hogy csoportosító karaktert helyezzen egy kifejezés fölé vagy alá. Egy határ hozzáadásával címkézheti a csoportosított kifejezéseket.

![x + y kifejezés csoportosítva a címkével, bármilyen szöveg alatta](powerpoint-math-equations_15.png)

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

Használja a formázó segédeszközöket csak ahol a képletet egyértelműbbé teszik. Például a [`overbar`](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/overbar/) egy vonalat helyez a matematikai elem fölé.

![ABC matematikai kifejezés felül vonallal](powerpoint-math-equations_14.png)

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
| Elemek kombinálása | [IMathElement.join](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/join/) |
| Törtek létrehozása | [IMathElement.divide](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Felső- vagy alsóindex hozzáadása | [set_superscript](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Gyökök hozzáadása | [radical](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Határok hozzáadása | [set_lower_limit](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Baloldali indexek hozzáadása | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Összegzések és integrálok hozzáadása | [nary](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [to_math_array](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Határolójelek hozzáadása | [enclose](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Vonalak és keretek hozzáadása | [overbar](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Kifejezések csoportosítása | [group](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/imathelement/group/) |

## **GYIK**

**Szerkeszthetek meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely `MathPortion`‑t tartalmaz, szerezze meg a `MathParagraph`‑t, és frissítse a bekezdésben lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint matematikaként vannak mentve?**

Igen. PPTX mentésekor az Aspose.Slides az egyenletet szerkeszthető Office matematikai tartalomként írja.

**Exportálhatok egyenleteket LaTeX‑be?**

Igen. Szerezze meg az egyenlet [MathParagraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathparagraph/) objektumát a [MathPortion](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathportion/)‑ból, és hívja meg a [MathParagraph.to_latex](https://reference.aspose.com/slides/hu/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) metódust a közvetlen exportáláshoz. Teljes példáért lásd a [Export Math Equations from Presentations in Python via .NET](/slides/hu/python-net/exporting-math-equations/#export-math-equations-to-latex).