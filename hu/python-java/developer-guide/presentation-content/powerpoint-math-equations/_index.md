---
title: Matematikai képletek hozzáadása PowerPoint prezentációkhoz Pythonban
linktitle: PowerPoint matematikai képletek
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
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokba az Aspose.Slides for Python via Java segítségével, OMML támogatással, formázási vezérlőkkel és átlátható Python kódrészletekkel."
---
## **Áttekintés**

A PowerPoint a képleteket Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Python via Java segítségével programozottan hozhat létre ugyanilyen matematikai tartalmat: törtöket, gyököket, függvényeket, határokat, N-áris operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

PowerPointban a felhasználók általában a **Insert > Equation** menüpontból adnak hozzá képleteket:

![PowerPoint Insert lapfül a Képlet parancs kiválasztásával](powerpoint-math-equations_1.png)

Az eredmény egy szerkeszthető matematikai szöveg a dián:

![PowerPoint dia szerkeszthető matematikai képlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektum segítségével építi fel a matematikai szöveget:

- A matematikai alakzat, amelyet a [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) hoz létre, az az alakzat, amely a képletet tartalmazza.
- A [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) a matematikai tartalmat tárolja az alakzat szövegkeretében.
- A [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) objektumot tartalmaz.

Az alábbi példák a [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) és a [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) folyékony metódusait használják a kód rövid és olvasható tartásához.

MathML export szcenáriókhoz lásd a [Matematikai képletek exportálása bemutatókból Pythonban](/slides/hu/python-java/exporting-math-equations/).

## **Képlet létrehozása**

Ez a példa a [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) használatával hoz létre egy matematikai alakzatot, és hozzáadja a Pitagorasz-tételt:

![A c² = a² + b² egyenlet](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) létrehoz egy alakzatot, amely már tartalmaz egy matematikai bekezdést. Hozzáfér az első [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), meghívja a [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) metódust, és hozzáadja a math blokkokat vagy math elemeket.
{{% /alert %}}

### **Matematikai blokkok kombinálása**

Amikor egy egyenlet részei önállóan [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) objektumokként épülnek, használja a [joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) metódust a kombináláshoz. A példa a `c² =` bal blokkba, és `a² + b²` jobb blokkba építi. A [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript) szerkeszthető matematikai felső indexeket hoz létre mindhárom hatványhoz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addMathShape(20, 20, 600, 100)
    math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    left_block = MathBlock()
    left_block.add(MathematicalText("c").setSuperscript("2"))
    left_block.add(MathematicalText("="))

    right_block = MathBlock()
    right_block.add(MathematicalText("a").setSuperscript("2"))
    right_block.add(MathematicalText("+"))
    right_block.add(MathematicalText("b").setSuperscript("2"))

    combined_block = left_block.joinBlock(right_block)
    math_paragraph.add(combined_block)

    presentation.save("equation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[joinBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#joinBlock) visszaadja magát a `left_block`‑ot, amely most a két részt sorrendben tartalmazza, míg a `right_block` üres marad. A kombinált blokkot csak egyszer adja hozzá a [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/)-hez. Az `equation.pptx` újbóli megnyitása után a bekezdés egyetlen blokkot tartalmaz, amely a `c² = a² + b²` kifejezést képviseli, a három hatvány matematikai felső indexként megmarad.

A [add](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/#add) metódus `left_block.add(right_block)` formában való hívása ehelyett közvetlenül egy blokkot próbál beágyazni egy másikba, és `InvalidOperationException` kivételt dob.

## **Törtek hozzáadása**

A [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) metódussal hozhat létre törteket. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) segítségével választhatja.

![Egy ferde matematikai tört, ahol az egyet x osztja](powerpoint-math-equations_4.png)

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

Halmozott tört esetén használja a [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar) értéket:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Gyökök hozzáadása**

A [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) metódussal hozhat létre négyzetgyököt, köbgyököt vagy egyéb gyököt. Az aktuális elem lesz az alap, a paraméter a kitevő.

![n-dik gyökös kifejezés, ahol az x a gyökjel alatti operandus](powerpoint-math-equations_5.png)

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

### **A négyzetgyök kitevőjének megjelenítése vagy elrejtése**

A négyzetgyök megjeleníthet egy explicit 2‑t, vagy használhatja a megszokott √x jelölést. A [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) metódus a [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/)‑ban szabályozza, melyik forma jelenik meg. Mindkét forma megtartja a 2‑es kitevőt és az x alapot a szerkeszthető egyenletben.

![Ugyanaz a négyzetgyök, balra a kitevő látható, jobbra rejtett](square-root-degree.png)

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

Használja az [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) vagy a [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) metódust függvényekhez, például `sin(x)`, `log(x)`, vagy egyéni függvénynevekhez. Határok esetén helyezze a `lim`‑et egy [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) objektumba, vagy használja a [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit) metódust.

![x határértéke, amikor x a végtelen felé tart](powerpoint-math-equations_8.png)

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

Egy egyéni függvénynév esetén a függvény nevét tegye az aktuális elemé, majd hívja a [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function)‑t az argumentummal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **N-áris operátorok és integrálok hozzáadása**

Használja az [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) metódust összegekre, uniókra, metszetekre és egyéb nagy operátorokra. Az [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) metódust integrálokhoz. Mindkét módszerrel megadhatja az alsó és felső határokat.

![Összegzés alsó és felső határokkal](powerpoint-math-equations_7.png)

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

Az N-áris operátorok nagy operátorok opcionális határokkal. Egyszerű operátorok, mint a `+`, `-`, és `=`, általában a [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/)‑vel kerülnek hozzáadásra, majd egyesítve a kifejezést.

Integrál esetén használja az [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral)‑t:

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

Használja a [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/)‑t sorok és oszlopok kezelésére. A mátrixok alapértelmezés szerint nem tartalmaznak zárójeleket, ezért szükség esetén zárójelezze a mátrixot, ha zárójelekre, szögletes vagy kapcsos zárójelekre van szükség.

![Két soros matematikai mátrix egy üres cellával](powerpoint-math-equations_10.png)

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

### **Meglévő mátrix szerkesztése**

Tegyük fel, hogy egy lineáris algebra óra a `matrix.pptx`‑ben lévő koefficiens mátrixszal kezdődik, amelyet az előző példa mentett. A következő feladatnál tartsa meg az első egyenletet, cserélje le a másodikat két új egyenletre, és módosítsa a változók halmazát. Nyissa meg a meglévő mátrixot a [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) segítségével, hogy megőrizze a még érvényes koefficiens értékeket.

![Eredeti két soros koefficiens mátrix 1, x és egy üres cellával az első sorban, valamint x, 2 és y a második sorban](matrix-before-edit.png)

A sor‑ és oszlop‑indexelés nulláról indul, és az aktuális hívás időpontjában létező mátrixra vonatkozik. Sor beszúrása az 1‑es index előtt az eredeti második sort a 2‑es indexre helyezi. Beszúrás után index 2‑nél egy új sor kerül hozzáadásra. A 2‑es sor törlése eltávolítja az eredeti második egyenletet, és a hozzáadott sort egy pozícióval feljebb hozza. Az oszlopok is ugyanígy eltolódnak.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathHorizontalAlignment, MathematicalText, Presentation, SaveFormat

presentation = Presentation("matrix.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    matrix = portion.getMathParagraph().get_Item(0).get_Item(0)

    matrix.insertRowBefore(1)
    matrix.insertRowAfter(2)
    matrix.deleteRow(2)

    matrix.insertColumnBefore(1)
    matrix.insertColumnAfter(3)
    matrix.deleteColumn(3)

    # Az új cellák kezdetben üresek. Előbb állítsa be a nem nulla koefficienseket.
    matrix.set_Item(1, 0, MathematicalText("12"))
    matrix.set_Item(1, 1, MathematicalText("1"))
    matrix.set_Item(2, 2, MathematicalText("10"))
    matrix.set_Item(2, 3, MathematicalText("1"))
    for row in range(matrix.getRowCount()):
        for column in range(matrix.getColumnCount()):
            if matrix.get_Item(row, column) is None:
                matrix.set_Item(row, column, MathematicalText("0"))

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left)
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right)
    
    presentation.save("updated-matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) balra igazítja az első oszlopot. [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) a maradék három oszlopot jobbra igazítja, az 1‑es indextől kezdve. A `updated-matrix.pptx`‑ben a mátrix három egyenletet és négy változót tartalmaz. Az eredeti első sor koefficiens‑értékei `1` és `x` most már az első és a harmadik oszlopban jelennek meg.

![Frissített három soros mátrix, sorok: 1, 0, x, 0; 12, 1, 0, 0; és 0, 0, 10, 1](matrix-after-edit.png)

## **Egyenlet tömbök hozzáadása**

Használja a [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray)‑t, ha igazított egyenletekre vagy függőleges kifejezés‑veremre van szükség.

![Függőleges matematikai tömb x felső, y alsó elhelyezkedéssel](powerpoint-math-equations_11.png)

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

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) szabályozza a tömb függőleges igazítását a mellette lévő matematikai elemekhez képest. Az alábbi példa összehasonlítja az első sor, a tömb középpontja és az utolsó sor igazítását.

Az alábbi példa három azonos tömböt hoz létre, mindegyik három soros, és a szomszédos elemek `A=` és `=B`. Minden matematikai szöveg Cambria Math 24 pont méretű, csak a tömb igazítása változik.

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

Az alábbi összehasonlítás a PowerPointban mentett prezentációt mutatja. Figyelje meg az `A=` és `=B` elhelyezkedését minden tömb mellett.

![Egyenlet tömbök PowerPointban felső, középső és alsó igazítással, azonos környező elemekkel](equation-array-alignment.png)

### **Sor távolságának beállítása**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) kiválasztja a sorok közötti távolság szabályát a tömbben. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) numerikus értéket ad meg egy explicit távolság szabálynál, és a preset szabályok ignorálják.

A pontos távolság pontban van megadva. Az arányos távolság fél‑sorban mérve: a példában a `3` érték 1,5 sort jelent. Explicit érték megadásakor mindkét tulajdonságot be kell állítani; csak a numerikus érték módosítása nem választ szabályt.

Az alábbi példa öt prezentációt ment ugyanazzal az egyenlettel, igazítással és betűtípus‑beállítással. Az első három preset‑et használ, az utolsó két példában explicit értékek láthatók.

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

A tömb sor távolsága különbözik a bekezdés távolságtól. A [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) és a [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) a tartalmazó bekezdés köré ad helyet, nem a sorok közé. Hasonlóképpen a [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) a teljes matematikai bekezdést vízszintesen helyezi el, nem helyettesíti a tömb függőleges igazítási beállítását.

## **Trigonometrikus függvények hozzáadása**

Használja az [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction)‑t, amikor az argumentum az aktuális elem, és a függvény neve ismert.

![A trigonometrikus cos függvény 2x-re alkalmazva](powerpoint-math-equations_6.png)

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

## **Alsó- és felső indexek hozzáadása**

Használja az alsó‑ és felső‑index segédfüggvényeket indexekhez és hatványokhoz. Ha az indexeknek a bázis bal oldalán kell megjelenniük, használja a [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)‑t.

![Nagy Y baloldali alsó index 1 és felső index n](powerpoint-math-equations_9.png)

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

### **Jobb oldali alsó és felső indexek igazítása**

Amikor egy alsó‑ és egy felső‑index ugyanazt a bázist osztja, használja a [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-java/aspose.slides/mathrightsubsuperscriptelement/)‑et. A [setAlignScripts](https://reference.aspose.com/slides/python-java/aspose.slides/mathrightsubsuperscriptelement/#setAlignScripts) metódus szabályozza azok vízszintes pozícióját. Alapértelmezett `False` esetén minden szkript követi a bázis körvonalát. `True` esetén a szkriptek ugyanabban a vízszintes pozícióban indulnak.

Ez a példa két példányban helyezi el ugyanazt a szerkeszthető kifejezést egymás mellett. Mindkettő 72 pont Cambria Math betűtípussal, matematikai dőlt f (U+1D453) karakterrel, alindex 1‑gyel és felső index 2‑vel. Az f dőlésszöge teszi láthatóvá a különbséget a PowerPointban. Futtatás előtt telepítse a Cambria Math betűtípust.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathBlock, MathematicalText, MathRightSubSuperscriptElement
from asposeslides.api import PortionFormat, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(900, 250, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    text_format = PortionFormat()
    font = FontData("Cambria Math")
    text_format.setFontHeight(72)
    text_format.setLatinFont(font)

    for left, align_scripts in [(40, False), (480, True)]:
        shape = slide.getShapes().addMathShape(left, 75, 380, 150)
        base = MathematicalText("\U0001D453", text_format)
        subscript = MathematicalText("1", text_format)
        superscript = MathematicalText("2", text_format)
        scripts = MathRightSubSuperscriptElement(base, subscript, superscript)
        scripts.setAlignScripts(align_scripts)

        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(text_format.getFontHeight())
        portion.getPortionFormat().setLatinFont(font)
        block = MathBlock(scripts)
        portion.getMathParagraph().add(block)

    presentation.save("aligned-scripts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Két szerkeszthető kifejezés PowerPointban, bal oldalon setAlignScripts False, jobb oldalon True](aligned-scripts.png)

Bal oldalon az alsó index tovább balra kezd, követve az f körvonalát. Jobb oldalon a két szkript bal széle egymásra igazodik.

## **Elválasztók hozzáadása**

Használja a [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose)‑t, hogy egy kifejezést elválasztók közé tegye. Több elemet tartalmazó elválasztó kifejezéseknél megadhat elválasztó karaktert is.

![Elválasztó kifejezés, amely x, y és z-ot függőleges vonalakkal választ el](powerpoint-math-equations_13.png)

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

Az [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight)‑nek `True` értéket adva a zárójelek növekednek a magas operandus körül, `False` esetén normál méretűek maradnak. Használja az [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape)‑et az egyik [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) értékkel. A `Centered` középre helyezi a zárójeleket a matematikai tengelyen, amely átmegy az egyenlőségjel közepén. A `Match` a tartalomhoz igazítja őket. Mindkét beállítás csak a zárójeleket érinti; a kifejezés maga változatlan marad.

A példa egy törtet helyez az `x` kitevőjébe, így a kifejezés magasabbra nyúlik a vonal alatti résznél. Négy egyenlet ugyanazt a zárójelet és betűtípust használja.

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

PowerPointban hasonlítsa össze a sorokat a növekedés hatásának megtekintéséhez. A felső sorban a zárójelek növekednek az exponens körül, és mindkét forma hasonló. Az alsó sorban a növekedés ki van kapcsolva. A bal oldali kisebb zárójelek (`Centered`) az egyenlőségjelhez igazodnak, a jobb oldali (`Match`) a kifejezés felett magasabban helyezkednek el.

![Négy egyenlet PowerPointban, ahol a zárójelek növekedése be van kapcsolva felül, le van tiltva alul, bal oldalon Centered, jobb oldalon Match](delimiter-sizing.png)

## **Szegélyes doboz hozzáadása**

Hívja a [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) metódust egy törtön, hogy a teljes kifejezést keretezze. Az eredményül kapott [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) alapértelmezés szerint mind a négy oldalt megjeleníti. A [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) és [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) metódusokkal egyes oldalakat is eltávolíthat.

A példa hat példányban helyezi el ugyanazt a törtet egy dián. A törlés megjelenítéséhez rejtse el mind a négy oldalt, és adjon `True` értéket a [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight)‑nek egy emelkedő átló (↗) vagy a [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight)‑nek egy csökkenő átló (↘) esetén. Használhatja a [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) vagy a [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) metódusokat is, tetszőleges kombinációval a látható oldalakra.

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

![Hat szerkeszthető tört PowerPointban. Felső sor: teljes körvonal, alsó és bal oldal, emelkedő átló. Alsó sor: csökkenő átló, vízszintes áthúzás, függőleges áthúzás teljes körvonallal](border-box-fractions.png)

Ezen tört esetén a vízszintes áthúzás átfedi a törtvonalat. A függőleges áthúzás áthalad a számláló és a nevező felett, míg a körvonal látható marad. Ezek a vonalak a teljes kifejezést díszítik. Az egyszerű szöveg áthúzása csak a szövegkarakterekre vonatkozik. A prezentáció újbóli megnyitása után a számlálót és a nevezőt továbbra is önállóan szerkesztheti.

## **Láthatóság és elrendezés vezérlése fantom elemekkel**

Tegye az egész kifejezést egy [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/)‑ba, hogy önállóan szabályozza a láthatóságát és a helyet, amelyet az egyenlethez hozzájárul. A [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) metódusai a következőket szabályozzák:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | `False` megadása elrejti a kifejezést. Méretei továbbra is részt vesznek az elrendezésben, hacsak az alábbi módszerek nem kapnak `True` értéket. |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | A kifejezés vízszintes szélességét nullának tekinti, így a szomszédos elemek közelebb helyezkedhetnek el. |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | A felmenet (a baseline fölötti magasság) nullának tekinthető, ez csökkentheti a szomszédos elemek fölött fenntartott helyet. |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | A leszállás (a baseline alatti mélység) nullának tekinthető, ez a törtvonal vagy egyéb tartalom a kifejezés alatti részét közelebb hozhatja a szomszédos elemekhez. |

A baseline az a referencia vonal, amelyen a szokásos matematikai betűk elhelyezkednek. A tartalom elrejtése nem távolítja el a méreteket, és egy dimenzió nullára állítása sem törli a kifejezést. Az alap kifejezés a [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase)‑on keresztül továbbra is elérhető. A [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow)‑nek `True` értéket adva újra megjelenítheti, a dimenzió‑beállítások változatlanok maradnak.

Az alábbi példa öt egymás melletti változatot hoz létre: egy látható tört, egy elrejtett, helyet fenntartó tört, valamint három elrejtett tört, amelynél egy dimenzió nullára van állítva. Minden változat ugyanazt a környező kifejezést és 24 pont Cambria Math betűtípust használja. Az összes egyenlet alakzat ugyanabban a felső pozícióban van, egy szürke segédvonal jelöli. A fantom elhelyezése egy külső tört számlálójában megkönnyíti a függőleges elrendezés változásainak megfigyelését.

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

![Öt egyenlet PowerPointban, összehasonlítva egy látható törtet, egy elrejtett, helyet fenntartó törtet, és ZeroWidth, ZeroAsc vagy ZeroDesc beállítású elrejtett törteket](math-phantom.png)

## **Tagok csoportosítása**

Használja a [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group)‑t, hogy egy csoportosító karaktert helyezzen egy kifejezés fölé vagy alá. Határonként hozzáadhat címkét a csoportosított tagok megjelöléséhez.

![Az x + y kifejezés csoportosítva, alatta a „valamennyi szöveg” címkével](powerpoint-math-equations_15.png)

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

Használjon formázó segédmetódusokat csak ott, ahol az egyenletet egyértelműbbé teszik. Például a [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) egy vonalat helyez el egy matematikai elem felett.

![Matematikai kifejezés ABC felül egy vonallal](powerpoint-math-equations_14.png)

```python
import jpype
 
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from Asplos… (omitted…)
```

### **Szöveg formázása meglévő egyenletben**

A meglévő egyenlet szövegének formázásához járja be az egyes matematikai blokkok elemtűzét. A [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) csak a közvetlen gyermekeket adja vissza, ezért rekurzívan kell hívni a törtek, szkriptek, gyökök és egyéb beágyazott szerkezetek szövegének eléréséhez. Ellenőrizze az aktuális elemet, valamint annak gyermekeit, hogy a [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) is be legyen vonva.

Ez a példa azt feltételezi, hogy az `input.pptx` egy olyan egyenletet tartalmaz, például `z = xᵢ / ∛y`, ahol a tört számlálójában alsó index, a nevezőben gyök található. Csak a blokk felső‑szintű elemeinek feldolgozása kihagyja a törten belüli szöveget. A példa a diák szövegkereteiben talál matematikai részeket, a blokkokat a [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph)‑vel éri el, és a [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight)‑vel 28 pont betűméretet állít be minden szövegelem [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) metódusán keresztül.

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

Az elmentett prezentáció minden feldolgozott egyenlet minden szintjén frissített szövegformázást tartalmaz, miközben megőrzi a szöveges tartalmat és a matematikai struktúrát.

## **Gyorsreferencia**

| Task | Main API |
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

**Szerkeszthetek meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amelyben [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) található, hívja a [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph)‑t, és frissítse a bekezdésben lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint matematikaként vannak mentve?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office‑math tartalomként írja.

**Exportálhatok egyenleteket LaTeX‑be?**

Igen. Szerezze meg az egyenlet [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/)‑ját a [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/)‑ból, majd hívja a [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex)‑t a közvetlen exportáláshoz. Teljes példáért lásd a [Matematikai képletek exportálása bemutatókból Pythonban](/slides/hu/python-java/exporting-math-equations/#export-math-equations-to-latex).