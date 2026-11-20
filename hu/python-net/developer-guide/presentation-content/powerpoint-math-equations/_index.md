---
title: Matematika egyenletek hozzáadása PowerPoint prezentációkhoz Pythonban
linktitle: PowerPoint Matematika Egyenletek
type: docs
weight: 80
url: /hu/python-net/powerpoint-math-equations/
keywords:
- matematika egyenlet
- matematika szimbólum
- matematika képlet
- matematika szöveg
- matematika egyenlet hozzáadása
- matematika szimbólum hozzáadása
- matematika képlet hozzáadása
- matematika szöveg hozzáadása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Python via .NET segítségével, OMML támogatással, formázási vezérlőkkel és érthető Python kódpéldákkal."
---
## **Áttekintés**

A PowerPoint a képleteket Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Python via .NET segítségével programozottan hozhat létre ugyanilyen matematikai tartalmakat: törtöket, gyököket, függvényeket, határokat, N-áris operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

A PowerPointban a felhasználók általában a **Insert > Equation** menüből adnak hozzá egyenleteket:

![PowerPoint Insert lap a Képlet parancs kiválasztva](powerpoint-math-equations_1.png)

Az eredmény egy szerkeszthető matematikai szöveg a dián:

![PowerPoint dia szerkeszthető matematikai egyenlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- Egy matematikai alakzat, amelyet a [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) metódus hoz létre, az az alakzat, amely a képletet tartalmazza.
- A [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) tárolja a matematikai tartalmat az alakzat szövegdobozában.
- A [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) objektumot tartalmaz.

A továbbiakban a legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) és a [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/) folyékony metódusait használja, hogy a kód rövid és olvasható legyen.

MathML exportálási esetekhez lásd a [Export Math Equations from Presentations in Python via .NET](/slides/hu/python-net/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa a [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) metódust használja egy matematikai alakzat létrehozásához, és hozzáadja a Pithagorasz-tételt:

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

{{% alert color="info" title="Note" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) egy olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Az első [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) elérése, a [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) lekérése, majd a matematikai blokkok vagy elemek hozzáadása.
{{% /alert %}}

### **Matematikai blokkok összevonása**

Amikor egy egyenlet részei önállóan [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) objektumokként épülnek, a [join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) használható azok egyesítésére. A példa a `c² =` szöveget a bal blokkban, az `a² + b²` szöveget pedig a jobb blokkban hozza létre. A [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/) szerkeszthető matematikai felső indexeket hoz létre mindhárom hatványhoz.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_math_shape(20, 20, 600, 100)
    math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph

    left_block = math.MathBlock()
    left_block.add(math.MathematicalText("c").set_superscript("2"))
    left_block.add(math.MathematicalText("="))

    right_block = math.MathBlock()
    right_block.add(math.MathematicalText("a").set_superscript("2"))
    right_block.add(math.MathematicalText("+"))
    right_block.add(math.MathematicalText("b").set_superscript("2"))

    combined_block = left_block.join_block(right_block)
    math_paragraph.add(combined_block)

    presentation.save("equation.pptx", slides.export.SaveFormat.PPTX)
```

[join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) a `left_block`-ot adja vissza, amely most már sorban tartalmazza mindkét részt, a `right_block` pedig üres marad. A kombinált blokkot csak egyszer kell hozzáadni a [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)-hoz. Az `equation.pptx` újbóli megnyitása után a bekezdés egyetlen blokkot tartalmaz, amely a `c² = a² + b²` egyenletet képviseli, mindhárom hatvány matematikai felső indexként megmarad.

A [add](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/add/) hívása `left_block.add(right_block)` helyett egy blokk közvetlen beágyazására próbálkozik, és `RuntimeError`-t dob, amely .NET `InvalidOperationException`-t csomagol.

## **Törtök hozzáadása**

A [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) használható tört létrehozásához. A törttípust a [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) segítségével választhatja ki.

![Egy ferdén ábrázolt tört, amelyben 1 osztva x-szel szerepel](powerpoint-math-equations_4.png)

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

Halmozott tört esetén a [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) használható:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Gyökök hozzáadása**

A [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) használatával hozhat létre négyzetgyököt, köbgyököt vagy egyéb gyököt. A jelenlegi elem lesz az alap, a paraméter pedig a kitevő.

![Egy n-dik gyök, amelyben x áll a gyökjel alatt](powerpoint-math-equations_5.png)

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

### **A négyzetgyök kitevőjének megjelenítése vagy elrejtése**

A négyzetgyök megjeleníthet egy explicite 2-es kitevőt, vagy a szokásos √x jelölést használhatja. A [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/) tulajdonsága szabályozza, melyik forma jelenik meg. Mindkét forma megőrzi a 2-es kitevőt és az x alapot a szerkeszthető egyenletben.

![A négyzetgyök x-re, bal oldalon a kitevő látható, jobb oldalon rejtett](square-root-degree.png)

A példa ugyanazt a négyzetgyököt kétszer menti. A 2 látható a `visible-degree.pptx`-ben, rejtett a `hidden-degree.pptx`-ben.

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

Használja az [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) vagy a [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) metódust függvényekhez, például `sin(x)`, `log(x)` vagy egyedi függvénynevekhez. Határokhoz helyezze a `lim` szót egy [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/)-be, vagy használja a [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/) metódust.

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

Egy egyéni függvénynév esetén tegye a függvénynevet a jelenlegi elemmé, majd hívja a [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) metódust argumentummal:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-áris operátorok és integrálok hozzáadása**

Az [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/) használható összegzésekhez, uniókhoz, metszetekhez és egyéb nagy operátorokhoz. Az [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) integrálokhoz. Mindkét metódus lehetővé teszi a felső és alsó határok beállítását.

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

Az N-áris operátorok nagy operátorok opcionális határokkal. Egyszerű operátorok, mint a `+`, `-`, és `=` általában [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) segítségével kerülnek hozzáadásra, majd az kifejezéshez csatlakoztatásra.

Integrál esetén használja az [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) metódust:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) oszlopok és sorok kezeléséhez. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért ha zárójeleket, szögletes vagy kapcsos zárójeleket szeretne, a mátrixot annak megfelelően kell körülvenni.

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

### **Meglévő mátrix szerkesztése**

Tegyük fel, hogy egy lineáris algebra óra a `matrix.pptx` fájlban lévő koefficiensmátrixszal kezdődik, amelyet az előző példa mentett. A következő feladatnál tartsa meg az első egyenletet, cserélje le a másodikat két új egyenletre, és módosítsa a változók halmazát. A meglévő mátrixot [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/)‑ként érje el, hogy a még érvényes együtthatókat megtartsa.

![Eredeti kétsoros koefficiens mátrix 1, x és egy üres cella az első sorban, illetve x, 2, y a második sorban](matrix-before-edit.png)

A sor‑ és oszlop‑indexelés nulláról indul, és a mátrix aktuális állapotára vonatkozik minden hívásnál. Sor beszúrása az 1‑es index előtt a második sort 2‑re tolja. Sor beszúrása az 2‑es index után egy új sort ad hozzá. Sor törlése a 2‑nél eltávolítja az eredeti második egyenletet, és a hozzáadott sort egy hellyel feljebb viszi. Az oszlopok hasonló módon mozdulnak.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation("matrix.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    portion = shape.text_frame.paragraphs[0].portions[0]
    matrix = portion.math_paragraph[0][0]

    matrix.insert_row_before(1)
    matrix.insert_row_after(2)
    matrix.delete_row(2)

    matrix.insert_column_before(1)
    matrix.insert_column_after(3)
    matrix.delete_column(3)

    matrix[1, 0] = math.MathematicalText("12")
    matrix[1, 1] = math.MathematicalText("1")
    matrix[2, 2] = math.MathematicalText("10")
    matrix[2, 3] = math.MathematicalText("1")
    for row in range(matrix.row_count):
        for column in range(matrix.column_count):
            if matrix[row, column] is None:
                matrix[row, column] = math.MathematicalText("0")

    matrix.set_column_alignment(0, math.MathHorizontalAlignment.LEFT)
    matrix.set_columns_alignment(1, 3, math.MathHorizontalAlignment.RIGHT)

    presentation.save("updated-matrix.pptx", slides.export.SaveFormat.PPTX)
```

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) a első oszlopot balra igazítja. [set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) három egymást követő oszlopot jobbra igazít index 1‑től kezdve. Az `updated-matrix.pptx` fájlban a mátrix három egyenletet és négy változót tartalmaz. Az eredeti első sor együtthatói (`1` és `x`) most már az első és a harmadik oszlopban jelennek meg.

![Frissített háromsoros mátrix: 1, 0, x, 0; 12, 1, 0, 0; és 0, 0, 10, 1](matrix-after-edit.png)

## **Egyenlet tömbök hozzáadása**

Használja a [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) metódust, ha igazított egyenletekre vagy függőleges kifejezés‑tömbökre van szüksége.

![Függőleges matematikai tömb, ahol x fölött y van](powerpoint-math-equations_11.png)

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

### **Tömb igazítása környező elemekhez**

A [MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) szabályozza a tömb függőleges igazítását a mellette lévő matematikai elemekhez képest. Az alábbi példa három azonos tömböt hoz létre, mindegyik három soros, és a szomszédos `A=` és `=B` elemekkel.

Minden matematikai szöveg Cambria Math betűtípussal, 24 pontos mérettel jelenik meg. Csak a tömb igazítása változik.

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

Az alábbi összehasonlítás a PowerPointban mentett prezentációt mutatja. Figyelje meg az `A=` és `=B` elhelyezkedését minden tömb mellett.

![Egyenlet tömbök PowerPointban, felső, középső és alsó igazítással, azonos szomszédos elemekkel](equation-array-alignment.png)

### **Sor‑távolság beállítása**

A [row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) szabályozza a sorok közti távolságot a tömbben. A [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) numerikus értéket ad meg egy explicit szabályhoz, és a beépített szabályok esetén figyelmen kívül marad.

Az exakktávolság pontban van megadva. Arányos távolság esetén fél‑sort használ: a példában a `3` érték 1,5 sort jelent. Mindkét tulajdonságot be kell állítani explicit érték megadása esetén; csak a numerikus érték módosítása önmagában nem választ szabályt.

Az alábbi példa öt prezentációt ment, mind ugyanazokkal az egyenletekkel, igazítással és betűtípussal. Az első három előre definiált beállítást használ, az utolsó kettő explicit értékeket mutat.

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

A tömb sor‑távolsága különbözik a bekezdés távolságától. A [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) és [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) a körülvevő bekezdés körüli helyet adja, nem a tömb sorai közti távolságot. Hasonlóképpen a [MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) a teljes matematikai bekezdést igazítja vízszintesen; nem helyettesíti a tömb függőleges igazítását.

## **Trigonometrikus függvények hozzáadása**

Használja a [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) metódust, ha az argumentum a jelenlegi elem, a függvény neve pedig ismert.

![A cos trigonometrikus függvény 2x‑re alkalmazva](powerpoint-math-equations_6.png)

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

Alkalmazza az alsó‑ és felső index segédfüggvényeit indexekhez és hatványokhoz. Ha az indexeknek a bázis bal oldalán kell megjelenniük, használja a [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) metódust.

![Nagy Y betű baloldali alsó index 1‑el és felső index n‑nel](powerpoint-math-equations_9.png)

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

### **Jobb‑oldali alsó‑ és felső indexek igazítása**

Ha mindkét index ugyanahhoz a bázishoz tartozik, használja a [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)-et. Ennek az [align_scripts](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/align_scripts/) tulajdonsága szabályozza a vízszintes pozíciókat: `False` (az alapértelmezett) a bázis kontúrját követi, míg `True` vízszintesen igazítja az indexeket egymáshoz.

Ez a példa két azonos szerkeszthető kifejezést helyez el egymás mellett. Mindkettő matematikai dőlt f (U+1D453) betűt, 1 alsó indexet, 2 felső indexet és Cambria Math betűtípust 72 pontban használ. A ferdén álló bázis a különbséget láthatóvá teszi PowerPointban. Telepítse a Cambria Math betűtípust a példa futtatása előtt.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(900, 250, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    text_format = slides.PortionFormat()
    text_format.font_height = 72
    text_format.latin_font = slides.FontData("Cambria Math")

    for i in range(2):
        left = 40 + i * 440
        shape = slide.shapes.add_math_shape(left, 75, 380, 150)

        base_text = math.MathematicalText("\U0001D453", text_format)
        subscript = math.MathematicalText("1", text_format)
        superscript = math.MathematicalText("2", text_format)
        scripts = math.MathRightSubSuperscriptElement(base_text, subscript, superscript)
        scripts.align_scripts = i == 1

        portion = shape.text_frame.paragraphs[0].portions[0]
        portion.portion_format.font_height = text_format.font_height
        portion.portion_format.latin_font = text_format.latin_font
        portion.math_paragraph.add(math.MathBlock(scripts))

    presentation.save("aligned-scripts.pptx", slides.export.SaveFormat.PPTX)
```

![Két szerkeszthető kifejezés PowerPointban, bal oldalon align_scripts=False, jobb oldalon True](aligned-scripts.png)

Bal oldalon az alsó index jobban balra indul, mint a felső, követve a bázis kontúrját. Jobb oldalon a két index vízszintesen igazítva van egymáshoz.

## **Határolók hozzáadása**

Használja a [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) metódust egy kifejezés határolók közé helyezéséhez. Több elemet tartalmazó határoló kifejezéseknél elválasztó karaktert is beállíthat.

![Határoló kifejezés, amely x, y és z elemeket tartalmaz, függőleges sávokkal elválasztva](powerpoint-math-equations_13.png)

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

Állítsa a [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/) értékét `True`‑ra, hogy a zárójelek a magas operandus köré nőjenek, vagy `False`‑ra, hogy a normál méretben maradjanak. A [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) a [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) egyik értékét veszi fel. A `CENTERED` középre helyezi a zárójeleket a matematikai tengelyen, amely a egyenlőségjel közepén halad. A `MATCH` a zárójeleket a tartalomhoz igazítja. Mindkét beállítás csak a határolókat érinti; a kifejezés belseje változatlan marad.

A példa a törtet az `x` kitevőjébe helyezi, így a kifejezés magasabbra nyúlik a kiindulási vonal fölött, mint alatta. Négy egyenlet ugyanazt a zárójelet és betűtípust használja.

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

PowerPointban hasonlítsa össze a sorokat a növekedés hatását. A felső sorban a zárójelek a kitevő köré nőnek, és mindkét alakzat hasonló. Az alsó sorban a növekedés ki van kapcsolva. A bal oldali kisebb zárójelek (`CENTERED`) a egyenlőségjelhez igazodnak, míg a jobb oldali (`MATCH`) feljebb helyezkednek a kifejezés körül.

![Négy egyenlet PowerPointban, a növekedés engedélyezve felül és letiltva alul, bal oldalon középre, jobb oldalon illesztve](delimiter-sizing.png)

## **Keretes doboz hozzáadása**

Hívja a [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) metódust egy törtön, hogy a teljes kifejezést keretezze. A visszakapott [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) alapértelmezés szerint négy oldalt jelenít meg. Használja a [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/) és [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/) metódusokat egyedi oldalak eltávolításához.

A példa hat másolatot helyez el ugyanabból a törtből egy dián. A törlés megjelenítéséhez rejtse el mind a négy oldalt, és állítsa be a [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/) tulajdonságot egy emelkedő átló (↗) vagy a [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) tulajdonságot egy leereszkedő átló (↘) használatához. A [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) vagy a [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) kombinálható bármely látható oldallal.

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

![Hat szerkeszthető tört PowerPointban. Felső sor: teljes keret, alsó és bal oldal, emelkedő átló. Alsó sor: leereszkedő átló, vízszintes áthúzás, függőleges áthúzás teljes kerettel.](border-box-fractions.png)

Ezen tört esetén a vízszintes áthúzás átfedi a törtvonalat. A függőleges áthúzás áthalad a számláló és a nevező felett, miközben a környező keret látható marad. Ezek a vonalak a teljes kifejezést díszítik. A szokásos szövegátlátszóság a szövegkimenetek karaktereire vonatkozik. A prezentáció újbóli megnyitása után a számlálót és a nevezőt továbbra is önállóan szerkesztheti.

## **Láthatóság és elrendezés vezérlése fantom elemekkel**

Tegye a kifejezést egy [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/)‑ba, hogy önállóan szabályozza a láthatóságát és az egyenlethez hozzájáruló helyet. Tulajdonságai a következőt befolyásolják:

| Property | Effect |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | `False`‑ra állítva elrejti a kifejezést. Méretei továbbra is részt vesznek az elrendezésben, hacsak a lenti megfelelő tulajdonságok `True`‑ra nincsenek állítva. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | A kifejezés vízszintes szélességét nullának tekinti, lehetővé téve a szomszédos elemek közelebb kerülését. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | A kifejezés felmenetelét (a kiindulási vonal feletti magasság) nullának tekinti, ez csökkentheti a szomszédos elemek fölötti helyet. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | A kifejezés lesülését (a kiindulási vonal alatti mélységet) nullának tekinti, ez közelebb hozhatja a törtvonalat vagy egyéb tartalmat a kifejezés alatti szomszédos elemekhez. |

A kiindulási vonal az a referencia, amelyen a szokásos matematikai betűk állnak. A tartalom elrejtése nem távolítja el a méreteket, és a méret nullának tekintése sem törli a kifejezést. Az alapvető kifejezés a [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/)‑on keresztül továbbra is elérhető. Állítsa a [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/)‑t vissza `True`‑ra a megjelenítéshez; a méretbeállítások változatlanok maradnak.

Az alábbi példa öt egymás melletti változatot hoz létre: egy látható tört, egy rejtett tört, amely helyet fenntart, és három rejtett tört, melyeknél egy dimenziót nullának tekintenek. Minden változat ugyanazt a környező kifejezést és Cambria Math 24 pontot használ. Minden egyenlet alakzat ugyanabban a felső pozícióban helyezkedik el, egy szürke segédvonal mutatja. A fantom elhelyezése egy külső tört számlálójába megkönnyíti a függőleges elrendezés változásainak megfigyelését.

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

![Öt egyenlet PowerPointban: látható tört, helyet fenntartó rejtett tört, valamint ZeroWidth, ZeroAsc vagy ZeroDesc beállítással ellátott rejtett törtök](math-phantom.png)

## **Csoportosítás**

Használja a [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) metódust egy csoportosító karakter fel vagy alá helyezéséhez egy kifejezéshez. Adjunk határt a csoportosított tagok címkézéséhez.

![Az x + y kifejezés csoportosítva, alatta „any text” felirat](powerpoint-math-equations_15.png)

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

Használja a formázó segédfüggvényeket csak ott, ahol a képletet tisztábbá teszik. Például a [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/) egy vonalat helyez a matematikai elem fölé.

![ABC matematikai kifejezés overbar‑ral](powerpoint-math-equations_14.png)

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

A szöveg formázásához egy meglévő egyenletben járja be a minden matematikai blokk elemfa struktúráját. A [MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan kell hívni, hogy a törtek, indexek, gyökök és egyéb beágyazott szerkezetek szövegéhez is eljusson. Ellenőrizze a jelenlegi elemet és annak gyermekeit is, hogy a [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) esetén is a kiinduló elemet belevegye.

Ez a példa azt feltételezi, hogy a `input.pptx` egy olyan egyenletet tartalmaz, mint `z = xᵢ / ∛y`, ahol a tört számlálójában alsó index, a nevezőjében gyök található. Ha csak a blokk felső szintű elemeit dolgozza fel, akkor a törtben lévő szöveget kihagyja. A példa megtalálja a matematikai részeket a diák szövegdobozában, hozzáfér a blokkokhoz a [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) segítségével, és minden szövegelem [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) tulajdonságán keresztül a [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) értékét 28 pontra állítja.

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

A mentett prezentáció minden szintjén frissített szövegformázást tartalmaz, miközben megőrzi a szövegtartalmat és a matematikai szerkezetet.

## **Gyors referencia**

| Task | Main API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Elemek összevonása | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| Törtek létrehozása | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| Felső‑ vagy alsó index hozzáadása | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| Gyökök hozzáadása | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| Határok hozzáadása | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| Bal‑oldali indexek hozzáadása | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| Összegzések és integrálok | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Egyenlet‑tömbök hozzáadása | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| Határolók hozzáadása | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| Vonalak és keretek | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| Tagok csoportosítása | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **GYIK**

**Szerkeszthetek már meglévő PowerPoint‑egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt a alakzatot, amely [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)‑t tartalmaz, szerezze meg a [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)-ját, és frissítse az ottani matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint‑matematikaként mentődnek?**

Igen. PPTX-be mentéskor az Aspose.Slides az egyenletet szerkeszthető Office‑matematikai tartalomként írja.

**Exportálhatom az egyenleteket LaTeX‑be?**

Igen. Szerezze meg a [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)‑t a [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)-ból, majd hívja a [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) metódust a közvetlen exportáláshoz. Teljes példa a [Export Math Equations from Presentations in Python via .NET](/slides/hu/python-net/exporting-math-equations/#export-math-equations-to-latex) oldalon érhető el.