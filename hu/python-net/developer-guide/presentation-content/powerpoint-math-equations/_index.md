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
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Python via .NET segítségével, OMML támogatással, formázási vezérlőkkel és érthető Python kódrészletekkel."
---
## **Áttekintés**

A PowerPoint egyenleteket Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Python via .NET segítségével programozottan hozhatók létre ugyanilyen matematikai tartalmak: törtök, gyökök, függvények, határok, N-áris operátorok, mátrixok, tömbök és formázott matematikai blokkok.

A PowerPointban a felhasználók általában a **Insert > Equation** menüből adják hozzá az egyenleteket:

![PowerPoint Insert lapfül, a Equation parancs kijelölve](powerpoint-math-equations_1.png)

Az eredmény szerkeszthető matematikai szöveg a dián:

![Egy PowerPoint dia, amely szerkeszthető matematikai egyenletet tartalmaz](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- A **math shape**, amelyet a [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) hoz létre, az a forma, amely az egyenletet tartalmazza.
- A [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) tárolja a matematikai tartalmat a forma szövegkeretében.
- A [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) objektumot tartalmaz.

A legtöbb példa alább a [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) fluent metódusait használja a rövid és olvasható kód érdekében.

MathML export esetén lásd a [Export Math Equations from Presentations in Python via .NET](/slides/hu/python-net/exporting-math-equations/) oldalt.

## **Egyenlet létrehozása**

Ez a példa a [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) használatával hoz létre egy math shape‑t, és hozzáadja a Pitagorasz‑tételt:

![A c² = a² + b² egyenlet](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Megjegyzés" %}}

[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Az első [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) elérésével, annak [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) tulajdonságával, hozzáadhatók matematikai blokkok vagy elemek.

{{% /alert %}}

## **Törtek hozzáadása**

Használja a [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) függvényt tört létrehozásához. A tört stílusa a [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) segítségével választható.

![Egy ferde tört, amely 1‑et oszt x‑szel](powerpoint-math-equations_4.png)

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

Használja a [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) függvényt négyzetgyök, köbgyök vagy más gyök létrehozásához. A jelenlegi elem lesz a gyök alapja, az argumentum pedig a kitevő.

![Egy n‑edik gyök, amelynek alatta a x jel van a gyökjelben](powerpoint-math-equations_5.png)

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

Használja az [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) vagy a [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) függvényeket a `sin(x)`, `log(x)` vagy saját függvénynevekhez. Határok esetén helyezze a `lim`‑et egy [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/)‑be, vagy használja a [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) függvényt.

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

Egyedi függvénynévhez tegye a függvénynevet a jelenlegi elemnek, majd hívja meg a [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/)‑t a paraméterrel:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N‑áris operátorok és integrálok hozzáadása**

Használja a [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) függvényt összegzések, uniók, metszetek és egyéb nagy operátorokhoz. Az integrálokhoz a [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) függvényt használja. Mindkét metódus lehetővé teszi a felső és alsó határ beállítását.

![Összegzés alsó és felső határral](powerpoint-math-equations_7.png)

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

Az N‑áris operátorok nagy operátorok opcionális határokkal. Az egyszerű operátorok, mint a `+`, `-` és `=` általában [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/)‑ként kerülnek be, és egyesülnek a kifejezéssel.

Integrál esetén használja a [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/)‑t:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/)‑t sorok és oszlopok definiálásához. Alapértelmezés szerint a mátrixok nem tartalmaznak zárójeleket, ezért ha zárójelekre, szögletes vagy kapcsos zárójelekre van szükség, akkor a mátrixot ezek között kell elhelyezni.

![Két soros mátrix egy üres cellával](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # A mátrixnak nincs saját zárójele, ezért zárójelek közé kell helyezni.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Figyelmeztetés" %}}

A `MathMatrix` létrehozza a sor‑ és oszlop‑rácsot, beállítja a réseket köztük, és igazítja az oszlopokat, de az Aspose.Slides for Python via .NET nem biztosít hozzáférést egyedi mátrixcellához. A kódból létrehozott mátrix ezért üres cellákat tartalmaz; egy meglévő prezentációból származó mátrix celláit a `get_children` segítségével olvashatja. Ha kódból kell sorokat feltölteni, használjon egyenlet‑tömböt.

{{% /alert %}}

## **Egyenlet‑tömbök hozzáadása**

Használja a [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) függvényt, ha igazított egyenletekre vagy függőlegesen halmozott kifejezésekre van szükség.

![Függőleges egyenlet‑tömb, ahol x felette y‑nak van](powerpoint-math-equations_11.png)

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

Használja az [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/)‑t, amikor az argumentum a jelenlegi elem, és a függvény neve ismert.

![A `cos` trigonometrikus függvény alkalmazva 2x‑re](powerpoint-math-equations_6.png)

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

## **Alsó‑ és felső indexek hozzáadása**

Használja az alindex és felső index segédfüggvényeit indexek és hatványok megadásához. Ha az indexeknek a bázis bal oldalán kell megjelenniük, használja a [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/)‑t.

![Egy nagy Y betű baloldali alsó index 1‑el és felső index n‑nel](powerpoint-math-equations_9.png)

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

## **Határoló jelek hozzáadása**

Használja az [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) függvényt egy kifejezés határoló jelek közé helyezéséhez. Több elemet tartalmazó kifejezésekhez beállítható egy elválasztó karakter is.

![Határoló kifejezés, amely x‑et, y‑t és z‑t tartalmaz, függőleges vonalakkal elválasztva](powerpoint-math-equations_13.png)

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

### **Határolók méretezése és igazítása**

Állítsa a [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) értékét `True`‑ra, hogy a zárójelek a magas operandus körül növekedjenek, vagy `False`‑ra, ha a normál méretet szeretné megtartani. A [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) a [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) két értékének egyét veheti fel. A `CENTERED` a zárójeleket a matematikai tengely közepéhez igazítja, amely áthalad az egyenlőségjel közepén. A `MATCH` a tartalomhoz igazítja őket. Mindkét beállítás csak a határoló jelekre hat, a kifejezés belseje változatlan marad.

A példa egy törtet helyez az `x` kitevőjébe, így a kifejezés a vonal felett magasabban nyúlik, mint alatta. Négy egyenlet ugyanazzal a zárójellel és betűtípussal.

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

PowerPointban hasonlítsa össze a sorokat, hogy lássa a növekedés hatását. A felső sorban a zárójelek növekednek, hogy befoglalják a kitevőt, és mindkét alakzatnál hasonlóan néznek ki. Az alsó sorban a növekedés ki van kapcsolva. A baloldali kisebb zárójelek (`CENTERED`) az egyenlőségjelhez igazodnak, míg a jobboldali (`MATCH`) magasabban helyezkednek el a kifejezés körül.

![Négy egyenlet PowerPointban, ahol a határolók növekedése be van kapcsolva a felső sorban és ki van kapcsolva az alsó sorban, balra `CENTERED`, jobbra `MATCH`](delimiter-sizing.png)

## **Keretes doboz hozzáadása**

Használja a [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) függvényt, ha az egyenletet keretbe kell helyezni.

![Egy keretes egyenlet, amelyben a négyzet a b² + c² értékkel egyenlő](powerpoint-math-equations_12.png)

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

Használja a [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/)‑ot, hogy egy csoportosító jelet helyezzen egy kifejezés fölé vagy alá. Címkézze a csoportosított tagokat limit hozzáadásával.

![Az `x + y` kifejezés `any text` címkével alul csoportosítva](powerpoint-math-equations_15.png)

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

Csak ott használjon formázó segédfüggvényeket, ahol az egyenlet érthetőbbé válik. Például a [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) fölé helyezett vonal egy elem fölött.

![Az `ABC` kifejezés fölött egy vonal](powerpoint-math-equations_14.png)

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

A szöveg formázásához járja be minden matematikai blokk elemfáját. Az [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) csak a közvetlen gyerekeket adja vissza, ezért rekurzívan hívja meg, hogy elérje a tört, index, gyök és egyéb beágyazott struktúrák szövegét. Vizsgálja meg a jelenlegi elemet és annak gyerekeit is, hogy a [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) elemek is benne legyenek.

Ez a példa feltételezi, hogy a `input.pptx` egy olyan egyenletet tartalmaz, mint `z = xᵢ / ∛y`, ahol a tört számlálója alsó indexet, nevezője pedig gyököt tartalmaz. Ha csak a blokk felső szintű elemeit dolgozza fel, akkor a törtben lévő szöveget kihagyja. A példa megtalálja a matematikai részeket a diák szövegkereteiben, a [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) segítségével hozzáfér a blokkokhoz, és a [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) értékét 28 ponttal állítja minden szövegelem [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) tulajdonságán keresztül.

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

A mentett prezentáció minden szinten frissített szövegformázást tartalmaz, miközben megőrzi az eredeti szövegtartalmat és a matematikai struktúrát.

## **Gyors referencia**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Elemek kombinálása | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| Törtek létrehozása | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Felső‑ vagy alsó index hozzáadása | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Gyökök hozzáadása | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Határok hozzáadása | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Baloldali indexek hozzáadása | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Összegzések és integrálok | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Egyenlet‑tömbök hozzáadása | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Határolók hozzáadása | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Vonalak és keretek | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Kifejezések csoportosítása | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **GYIK**

**Szerkeszthetek meglévő PowerPoint‑egyenletet?**

Igen. Nyissa meg a prezentációt, találja meg azt a formát, amely [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)‑t tartalmaz, szerezze be annak [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) tulajdonságát, és frissítse a benne lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint‑mathként kerülnek mentésre?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office‑math tartalomként írja.

**Exportálhatom az egyenleteket LaTeX‑be?**

Igen. Szerezze be az egyenlet [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)‑ját a [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)‑ból, majd hívja meg a [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/)‑t a közvetlen exportáláshoz. Teljes példa a [Export Math Equations from Presentations in Python via .NET](/slides/hu/python-net/exporting-math-equations/#export-math-equations-to-latex) oldalon található.