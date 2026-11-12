---
title: 在 Python 中將數學方程式新增至 PowerPoint 簡報
linktitle: PowerPoint 數學方程式
type: docs
weight: 80
url: /zh-hant/python-java/powerpoint-math-equations/
keywords:
- 數學方程式
- 數學符號
- 數學公式
- 數學文字
- 新增數學方程式
- 新增數學符號
- 新增數學公式
- 新增數學文字
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint PPT 和 PPTX 中插入與編輯數學方程式，支援 OMML、格式控制，並提供清晰的 Python 程式碼範例。"
---
## **概覽**

PowerPoint 以 Office Math Markup Language (OMML) 儲存方程式。使用 Aspose.Slides for Python via Java，您可以以程式方式建立相同類型的數學內容：分數、根號、函式、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint，使用者通常從 **Insert > Equation** 新增方程式：

![PowerPoint 插入標籤，已選取「方程式」指令](powerpoint-math-equations_1.png)

結果是在投影片上可編輯的數學文字：

![PowerPoint 投影片包含可編輯的數學方程式](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建立該數學文字：

- 數學形狀，由 [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) 建立，用於包含方程式的形狀。
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) 在形狀文字框內儲存數學內容。
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) 物件。

以下大多數範例使用 [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) 和來自 [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) 的流暢方法，以保持程式碼簡潔且易讀。

若需 MathML 匯出情境，請參閱 [Export Math Equations from Presentations in Python](/slides/zh-hant/python-java/exporting-math-equations/)。

## **建立方程式**

此範例使用 [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) 建立數學形狀，並加入畢氏定理：

![c 平方等於 a 平方加 b 平方 的方程式](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) 會建立已包含數學段落的形狀。取得第一個 [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/)，呼叫 [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph)，並向其新增數學區塊或數學元素。
{{% /alert %}}

## **新增分數**

使用 [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) 建立分數。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) 來選擇分數樣式。

![一個斜式數學分數，顯示 1 除以 x](powerpoint-math-equations_4.png)

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

若要堆疊式分數，請使用 [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **新增根號**

使用 [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) 建立平方根、立方根或其他根號。當前元素成為根底，參數則成為次方。

![一個 n 次根號表達式，x 位於根號符號下方](powerpoint-math-equations_5.png)

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

## **新增函式與極限**

對於 `sin(x)`、`log(x)` 或自訂函式名稱等函式，使用 [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) 或 [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function)。對於極限，將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) 或使用 [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit)。

![當 x 趨近於無限大時的極限](powerpoint-math-equations_8.png)

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

若要使用自訂函式名稱，將函式名稱設為當前元素，然後以其參數呼叫 [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **新增 N 元運算子與積分**

使用 [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) 來表示求和、聯集、交集及其他大型運算子。使用 [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) 來表示積分。兩個方法皆可設定上下限。

![帶有上下限的求和符號](powerpoint-math-equations_7.png)

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

N 元運算子用於具有可選上下限的大型運算子。`+`、`-`、`=` 等簡單運算子通常以 [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) 新增，並加入到表達式中。

若要表示積分，使用 [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral)：

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

## **新增矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) 來定義行與列。預設情況下矩陣不會包含括號，若需要圓括號、方括號或大括號，請自行將矩陣包起來。

![具有兩列且其中一格為空的數學矩陣](powerpoint-math-equations_10.png)

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

## **新增方程式陣列**

當需要對齊的方程式或垂直堆疊的表達式時，使用 [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray)。

![垂直的數學陣列，x 位於 y 之上](powerpoint-math-equations_11.png)

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

### **對齊陣列與周圍元素**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) 控制陣列相對於其旁邊數學元素的垂直對齊。以下範例比較了以第一列、陣列中心以及最後一列對齊的情況。

以下範例建立三個相同的陣列，每個都有三列，且鄰近元素為 `A=` 與 `=B`。所有數學文字皆使用 24 點 Cambria Math。唯一變更的是陣列的對齊方式。

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

下圖顯示在 PowerPoint 中儲存的簡報比較。請注意每個陣列旁的 `A=` 與 `=B` 位置。

![PowerPoint 中的方程式陣列，分別使用上對齊、置中、下對齊，且相鄰元素相同](equation-array-alignment.png)

### **設定列間距**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) 選取陣列內列的間距規則。[setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) 為明確的間距規則提供數值，預設規則會忽略此設定。

若使用精確間距，數值以點為單位。若使用比例間距，則以半行為單位：範例中的值 `3` 表示 1.5 行。設定明確間距時，需同時設定兩個屬性；僅變更數值不會選取間距規則。

以下範例儲存五個簡報，內容的方程式、對齊與字型設定相同。前三個使用預設規則；最後兩個顯示明確數值。

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

陣列列間距與段落間距分開。[setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) 與 [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) 只在包含的段落前後加入空白，並不影響陣列列之間。相同地，[MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) 只會水平定位整個數學段落，並不會取代陣列的垂直對齊設定。

## **新增三角函式**

當參數為當前元素且函式名稱已知時，使用 [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction)。

![三角函式 cos 套用於 2x](powerpoint-math-equations_6.png)

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

## **新增下標與上標**

使用下標與上標輔助方法處理索引與次方。若索引需顯示在基底左側，請使用 [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)。

![大寫 Y，左側有下標 1 與上標 n](powerpoint-math-equations_9.png)

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

## **新增分隔符號**

使用 [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) 將表達式包在分隔符號內。對於包含多個元素的分隔符號表達式，亦可設定分隔字元。

![一個分隔符號表達式，包含 x、y、z，以直線分隔](powerpoint-math-equations_13.png)

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

### **調整分隔符號大小與對齊**

將 `True` 傳遞給 [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight)，可讓括號依據較高的運算元自動延伸；傳遞 `False` 則保持其正常大小。使用 [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) 搭配兩種 [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) 之一。`Centered` 使括號在數學軸上居中，該軸貫穿等號的中間。`Match` 則與內部內容對齊。這兩個設定僅影響分隔符號本身，內部表達式保持不變。

範例將分數放在 `x` 的指數位置，使表達式在基線上方的延伸較下方更長。四個方程式皆使用相同的括號與字型設定。

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

在 PowerPoint 中，比較各列以觀察成長效果。上列的括號會延伸以包住指數，兩種形狀看起來相同。下列則關閉了成長。左側較小的括號（`Centered`）與等號對齊，而右側（`Match`）則在表達式上方較高。

![PowerPoint 中的四個方程式，左側使用 Centered 且啟用分隔符號成長，上方；右側使用 Match 且關閉成長，下方](delimiter-sizing.png)

## **新增邊框盒**

對分數呼叫 [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) 以為整個表達式加上框線。回傳的 [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) 預設顯示四側。可使用 [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop)、[setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom)、[setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) 與 [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) 來移除個別側邊。

對於 `↗` 或 `↘`，可分別傳遞 `True` 給 [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) 或 [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight)。亦可使用 [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) 或 [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) 並結合任意可見側。

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

![PowerPoint 中的六個可編輯分數。上列：完整邊框、底部與左側、向上對角線。下列：向下對角線、水平斜線、垂直斜線且保留完整邊框。](border-box-fractions.png)

在此分數中，水平斜線與分數線重疊。垂直斜線穿過分子與分母，而周圍的邊框仍可見。這些線條裝飾整個表達式。普通的文字刪除線僅適用於文字跑中的字元。重新在 PowerPoint 開啟簡報後，仍可分別編輯分子與分母。

## **分組項目**

使用 [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) 在表達式上方或下方放置分組符號。可加入極限以為分組項目標籤。

![將表達式 x 加 y 分組，並在底下加上標籤任意文字](powerpoint-math-equations_15.png)

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

## **格式化數學元素**

僅在有助於說明公式時才使用格式化輔助方法。例如，[overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) 會在數學元素上方加上一條橫線。

![數學表達式 ABC 帶有上方橫線](powerpoint-math-equations_14.png)

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

### **格式化既有方程式中的文字**

若要在既有方程式中格式化文字，需要遍歷每個數學區塊的元素樹。[MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) 僅回傳直接子項，故需遞迴呼叫以取得分數、上下標、根號及其他巢狀結構中的文字。也要檢查當前元素與其子項，若起始元素為 [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) 時亦需包含。

此範例假設 `input.pptx` 內含例如 `z = xᵢ / ∛y` 的方程式，該分數的分子包含下標，分母則為根號。若僅處理區塊的頂層元素，會遺漏分數內的文字。範例會在投影片文字框中尋找數學區段，透過 [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) 取得其區塊，並使用 [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) 將每個文字元素的 [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) 方法設定為 28 點字型大小。

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

儲存的簡報在每個已處理方程式的所有層級中都包含更新的文字格式，同時保留其文字內容與數學結構。

## **快速參考**

| 任務 | Main API |
| --- | --- |
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| 結合元素 | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| 建立分數 | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| 新增上標或下標 | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| 新增函式 | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| 新增根號 | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| 新增極限 | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| 新增左側上下標 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| 新增求和與積分 | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| 新增矩陣 | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| 新增方程式陣列 | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| 新增分隔符號 | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| 新增橫線與邊框 | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| 分組項目 | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **常見問題**

**我可以編輯既有的 PowerPoint 方程式嗎？**

是的。開啟簡報，找出包含 [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) 的形狀，呼叫 [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph)，並更新該段落中的數學區塊。

**方程式是否以可編輯的 PowerPoint 數學方式儲存？**

是的。儲存為 PPTX 時，Aspose.Slides 會將方程式寫入可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

是的。從其 [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) 取得方程式的 [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/)，然後呼叫 [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) 直接匯出。完整範例請參閱 [Export Math Equations from Presentations in Python](/slides/zh-hant/python-java/exporting-math-equations/#export-math-equations-to-latex)。