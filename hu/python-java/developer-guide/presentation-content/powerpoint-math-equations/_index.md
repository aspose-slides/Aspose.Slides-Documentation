---
title: Matematika egyenletek hozzáadása PowerPoint prezentációkhoz Pythonban
linktitle: PowerPoint matematikai egyenletek
type: docs
weight: 80
url: /hu/python-java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Python via Java segítségével, támogatja az OMML-t, a formázási vezérléseket, és érthető Python kódrészleteket."
---
## **Áttekintés**

PowerPoint az egyenleteket Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Python via Java segítségével programozottan hozhat létre ugyanezt a típusú matematikai tartalmat: törtöket, gyököket, függvényeket, határokat, N‑áris operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

PowerPointban a felhasználók általában a **Beszúrás > Egyenlet** menüből adnak hozzá egyenleteket:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

Az eredmény szerkeszthető matematikai szöveg a dián:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- Egy matematikai alakzat, a [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) segítségével létrehozott, amely tartalmazza az egyenletet.
- A [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) tárolja a matematikai tartalmat az alakzat szövegdobozában.
- A [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) objektumot tartalmaz.

Az alábbi példák nagy része a [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) és a [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) folyékony metódusait használja a kód rövid és olvasható tartásához.

MathML export esetén lásd a [Export Math Equations from Presentations in Python](/slides/hu/python-java/exporting-math-equations/) oldalt.

## **Egyenlet létrehozása**

Ez a példa a [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) használatával hoz létre egy matematikai alakzatot, és hozzáadja a Pitagorasz‑tételt:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}

[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) létrehoz egy olyan alakzatot, amely már tartalmaz egy matematikai bekezdést. Az első [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) elérésével hívja meg a [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) metódust, és adja hozzá a matematikai blokkokat vagy elemeket.

{{% /alert %}}

## **Törtek hozzáadása**

A [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) segítségével hozhat létre egy törtet. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) segítségével választhatja ki.

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

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

Összeállított tört esetén használja a [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar) értéket:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Gyökök hozzáadása**

A [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) segítségével hozhat létre négyzetgyököt, köbgyököt vagy más gyököt. A jelenlegi elem lesz az alap, az argumentum a gyök fokszáma.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

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

### **A négyzetgyök fokszámának megjelenítése vagy elrejtése**

A négyzetgyök megjeleníthet egy explicit 2‑t vagy a szokásos √x jelölést használhatja. A [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) metódusa határozza meg, melyik forma jelenik meg. Mindkét forma megtartja a 2 fokszámot és az x radikandusát a szerkeszthető egyenletben.

![The same square root with the degree visible on the left and hidden on the right](square-root-degree.png)

A példa ugyanazt a négyzetgyököt kétszer menti. A `visible-degree.pptx` fájlban a 2 látható. A `hidden-degree.pptx` fájlban rejtett.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    radical = MathematicalText("x").radical("2")
    math_block = MathBlock(radical)

    math_shape = slide.getShapes().addMathShape(20, 20, 200, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()
    math_paragraph.add(math_block)

    radical.setHideDegree(False)
    presentation.save("visible-degree.pptx", SaveFormat.Pptx)

    radical.setHideDegree(True)
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Függvények és határok hozzáadása**

Használja a [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) vagy a [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) metódusokat függvényekhez, például `sin(x)`, `log(x)` vagy egyéni függvénynevek esetén. Határokhoz helyezze a `lim` szimbólumot egy [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) belsejébe, vagy használja a [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit) metódust.

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

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

Egy egyéni függvénynévhez tegye a függvénynevet a jelenlegi elemmé, és hívja meg a [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) metódust az argumentummal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **N‑áris operátorok és integrálok hozzáadása**

A [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) használható összegzésekhez, uniókhoz, metszetekhez és egyéb nagy operátorokhoz. Az [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) a integrálokhoz. Mindkét metódus lehetővé teszi az alsó és felső határok beállítását.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

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

Az N‑áris operátorok nagy operátorok opcionális határokkal. Az egyszerű operátorok, mint `+`, `-`, és `=` általában a [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) használatával kerülnek hozzáadásra, és az kifejezésbe illesztve.

Integrálhoz használja az [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) metódust:

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

## **Mátrixok hozzáadása**

A [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) segítségével hozhat létre sorokat és oszlopokat. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért a mátrixot körül kell tenni, ha zárójeleket, szögletes vagy kapcsos zárójeleket szeretne.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

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

## **Egyenlet tömbök hozzáadása**

Használja a [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) metódust, ha igazított egyenletekre vagy függőlegesen halmozott kifejezésekre van szüksége.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

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

### **Tömb igazítása környező elemekkel**

A [setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) szabályozza egy tömb függőleges igazítását a mellette lévő matematikai elemekhez képest. Az alábbi példa az első sor, a tömb közepe és az utolsó sor alapján mutatja az igazítást.

A következő példa három azonos tömböt hoz létre, mindegyik három soros, és a szomszédos elemek `A=` és `=B`. Az összes matematikai szöveg Cambria Math betűtípussal, 24 pont mérettel jelenik meg. Csak a tömb igazítása változik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathVerticalAlignment, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)
    
    alignments = (("Top", MathVerticalAlignment.Top), ("Center", MathVerticalAlignment.Center), ("Bottom", MathVerticalAlignment.Bottom))
    for index, (name, alignment) in enumerate(alignments):
        x = 20 + index * 260
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 10, 240, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(16)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        math_shape = slide.getShapes().addMathShape(x, 60, 240, 130)
        math_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(alignment)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az alábbi összehasonlítás a mentett PowerPoint prezentációt mutatja. Figyelje meg az `A=` és `=B` pozícióját minden tömb mellett.

![Equation arrays in PowerPoint with Top, Center, and Bottom alignment and identical neighboring elements](equation-array-alignment.png)

### **Sorok közti távolság beállítása**

A [setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) választja ki a sorok közti távolság szabályát a tömbön belül. A [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) numerikus értéket ad meg egy explicit szabálynál, és a preset szabályok figyelmen kívül hagyják.

Az pontos távolság értéke pontban van megadva. Az arányos távolság esetén fél sorban mérik: a példában a `3` érték 1,5 sort jelent. Mindkét tulajdonságot állítsa be explicit érték megadásakor; csak a numerikus érték módosítása nem választ szabályt.

Az alábbi példa öt prezentációt ment ugyanazzal az egyenlettel, igazítással és betűbeállítással. Az első három preset, az utolsó kettő explicit értékek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathRowSpacingRule, MathVerticalAlignment, Presentation, SaveFormat

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


settings = (("SingleLineGap", MathRowSpacingRule.SingleLineGap, 0), ("OneAndAHalfLineGap", MathRowSpacingRule.OneAndAHalfLineGap, 0), ("TwoLineGap", MathRowSpacingRule.TwoLineGap, 0), ("Exactly", MathRowSpacingRule.Exactly, 20), ("Multiple", MathRowSpacingRule.Multiple, 3))
for name, rule, spacing in settings:
    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        math_shape = slide.getShapes().addMathShape(20, 20, 600, 300)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(MathVerticalAlignment.Center)
        equation_array.setRowSpacingRule(rule)
        equation_array.setRowSpacing(spacing)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

        presentation.save(f"equation-array-{name}.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

A tömb sorok közti távolsága különbözik a bekezdés távolságtól. A [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) és [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) a tartalmazó bekezdés körül adnak helyet, nem a tömb sorok között. Hasonlóképpen a [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) a teljes matematikai bekezdést helyezi el vízszintesen; nem módosítja a tömb függőleges igazítását.

## **Trigonometrikus függvények hozzáadása**

Használja a [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) metódust, ha az argumentum a jelenlegi elem, és a függvény neve ismert.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

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

## **Alsó‑ és felső indexek hozzáadása**

Használja az alsó‑ és felső index segédfüggvényeket indexek és hatványok számára. Ha az indexeknek a bázis bal oldalán kell megjelenniük, használja a [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) metódust.

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

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

## **Elválasztó jelek hozzáadása**

Használja az [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) metódust, hogy egy kifejezést elválasztó jelek közé helyezzen. Több elemet tartalmazó elválasztó kifejezésekhez beállíthatja a szeparátort.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

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

### **Elválasztók mérete és igazítása**

Adjon át `True` értéket a [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) metódusnak, hogy a zárójelek a magas operandus körül növekedjenek, vagy `False`‑t adjon át, hogy a normál méretben maradjanak. Használja a [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) egyik [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) értékével. A `Centered` középre helyezi a zárójeleket a matematikai tengelyen, amely áthalad az egyenlőségjel közepén. A `Match` a tartalomhoz igazítja őket. Mindkét beállítás csak az elválasztókat érinti; a kifejezés belseje változatlan marad.

A példa egy törtet helyez az `x` kitevőjébe, így a kifejezés jobban emelkedik a vonal felett, mint alatta. Mind a négy egyenlet ugyanazokat a zárójeleket és betűtípust használja.

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

PowerPointban hasonlítsa össze a sorokat a növekedés hatását láthatóvá tenni. A felső sorban a zárójelek növekednek, hogy befoglalják a kitevőt, és mindkét alakzat hasonló. Az alsó sorban a növekedés ki van kapcsolva. A bal oldali kisebb zárójelek (`Centered`) az egyenlőségjellel igazodnak, míg a jobb oldali (`Match`) magasabban helyezkednek a kifejezés körül.

![Four equations in PowerPoint with delimiter growth enabled above and disabled below, and Centered on the left and Match on the right](delimiter-sizing.png)

## **Határoló doboz hozzáadása**

A [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) metódus hívása egy törtön keretezi az egész kifejezést. A visszaadott [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) alapértelmezés szerint négy oldalt jelenít meg. Használja a [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) és [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) metódusokat az egyes oldalak eltávolításához.

A példa hat példányban helyezi el ugyanazt a törtet egy dián. A törlés megmutatásához rejtse el mind a négy oldalt, és adjon át `True` értéket a [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) metódusnak egy emelkedő átlóhoz (↗), vagy a [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) metódusnak egy süllyedő átlóhoz (↘). Használhatja a [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) vagy a [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) metódusokat is, bármilyen kombinációval a látható oldalakból.

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

![Six editable fractions in PowerPoint. Top row: full border, bottom and left sides, rising diagonal. Bottom row: falling diagonal, horizontal strike, vertical strike with a full border.](border-box-fractions.png)

Ezen a törtön a vízszintes vonal átfedi a törtvonalat. A függőleges vonal áthalad a számláló és a nevező felett, miközben a környező keret látható marad. Ezek a vonalak az egész kifejezést díszítik. A normál szöveg áthúzása a karakterekre vonatkozik egy szövegrészen belül. A prezentáció újra megnyitása után még szerkeszthető a számláló és a nevező külön‑külön.

## **Átlátszó elemekkel a láthatóság és elrendezés vezérlése**

Egy kifejezést a [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) használatával vegye körül, hogy függetlenül szabályozza a láthatóságát és a egyenlethez járuló helyet. A [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) metódusai a következőket vezérlik:

| Metódus | Hatás |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | `False` értékkel elrejtheti a kifejezést. Méretei továbbra is részt vesznek az elrendezésben, hacsak az alábbi módszerek nem kapnak `True` értéket. |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | A kifejezés vízszintes szélességét nullának tekinti, lehetővé téve a szomszédos elemek közötti közelebb kerülést. |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | A felmenetét, azaz a baseline fölötti magasságot nullának tekinti. Ez csökkentheti a szomszédos elemek fölött fenntartott helyet. |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | A lesülését, a baseline alatti mélységet nullának tekinti. Ez a törtvonalat vagy más, a kifejezés alatti tartalmat közelebb hozhat a szomszédokhoz. |

A baseline a referencia vonal, amelyen a szokásos matematikai betűk állnak. A tartalom elrejtése nem távolítja el a méreteket, és egy méret nullának kezelése sem törli a kifejezést. Az alapkifejezés továbbra is elérhető a [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase) metódussal. A [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) `True` értékkel való hívása újra megjeleníti azt; a dimenzió beállítások változatlanok maradnak.

Az alábbi példa öt egymás mellé helyezett változatot hoz létre: egy látható tört, egy rejtett tört, amely helyet tart, és három rejtett tört, amelynél egy dimenzió nullaként van kezelve. Minden változat ugyanazt a környező kifejezést és Cambria Math 24 pont betűtípust használja. Minden egyenlet alakzat ugyanabban a felső pozícióban van, amit a szürke segédvonal jelöl. A fantom elhelyezése a külső tört számlálójában könnyebben láthatóvá teszi a függőleges elrendezés változását.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathBlock, MathFraction, MathematicalText, MathPhantom, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color


def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    labels = ("Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc")

    guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0)
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)

    for index, name in enumerate(labels):
        left = 10 + index * 200
        
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(14)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = MathFraction(fraction_numerator, fraction_denominator)
        phantom = MathPhantom(fraction)
        phantom.setShow(index == 0)
        phantom.setZeroWidth(index == 2)
        phantom.setZeroAsc(index == 3)
        phantom.setZeroDesc(index == 4)

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = MathFraction(numerator, denominator)

        shape = slide.getShapes().addMathShape(left, 60, 190, 100)
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        math_paragraph = math_portion.getMathParagraph()
        math_block = MathBlock(equation)
        math_paragraph.add(math_block)

    presentation.save("math-phantom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Five equations in PowerPoint comparing a visible fraction, a hidden fraction that reserves space, and hidden fractions with ZeroWidth, ZeroAsc, or ZeroDesc enabled](math-phantom.png)

## **Kifejezések csoportosítása**

Használja a [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) metódust, hogy csoportosító karaktert helyezzen egy kifejezés fölé vagy alá. Adj egy határt a csoportosított tagok címkézéséhez.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

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

## **Matematikai elemek formázása**

Használjon formázó segédfüggvényeket csak ott, ahol a képlet átláthatóbbá válik. Például a [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) a matematikai elem fölé helyez egy vonalat.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

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

### **Szöveg formázása meglévő egyenletben**

A szöveg formázásához egy már létező egyenletben járja be minden matematikai blokk elemi faát. A [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan kell hívni, hogy elérje a tört, szkriptek, gyökök és egyéb beágyazott struktúrák szövegét. Ellenőrizze a jelenlegi elemet és gyermekeit is, hogy a kiinduló elem a [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) legyen.

Ez a példa feltételezi, hogy a `input.pptx` egy olyan egyenletet tartalmaz, mint `z = xᵢ / ∛y`, amelyben a tört számlálója egy alsó indexet, a nevezője pedig egy gyököt tartalmaz. Ha csak a blokk felső szintű elemeit dolgozza fel, a törtben lévő szöveget kihagyja. A példa megtalálja a matematikai részeket a diák szövegdobozában, eléri a blokkokat a [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) segítségével, és a [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) metódussal 28 pont betűméretet állít be minden szövegelemen keresztül a [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) metóduson.

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

A mentett prezentáció tartalmazza az frissített szövegformátumot minden szintű feldolgozott egyenletben, miközben megőrzi a szövegtartalmat és a matematikai szerkezetet.

## **Gyors referencia**

| Feladat | Fő API |
| --- | --- |
| Create math text | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| Combine elements | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| Create fractions | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| Add superscript or subscript | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| Add functions | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| Add radicals | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| Add limits | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| Add left-side scripts | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| Add summations and integrals | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| Add matrices | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| Add equation arrays | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| Add delimiters | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| Add bars and borders | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| Group terms | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **GYIK**

**Lehet‑e meglévő PowerPoint egyenletet szerkeszteni?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) tartalmaz, hívja meg a [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) metódust, és frissítse a matematikai blokkokat abban a bekezdésben.

**Az egyenletek szerkeszthető PowerPoint mathként mentődnek?**

Igen. PPTX mentésekor az Aspose.Slides az egyenletet szerkeszthető Office math tartalomként írja.

**Exportálhatók‑e az egyenletek LaTeX‑be?**

Igen. Szerezze meg az egyenlet [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) objektumát a [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) segítségével, és hívja a [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) metódust a közvetlen exportáláshoz. Egy teljes példáért tekintse meg a [Export Math Equations from Presentations in Python](/slides/hu/python-java/exporting-math-equations/#export-math-equations-to-latex) oldalt.