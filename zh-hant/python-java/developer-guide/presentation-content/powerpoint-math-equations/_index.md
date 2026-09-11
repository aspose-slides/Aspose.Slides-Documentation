---
title: 在 Python 中為 PowerPoint 簡報新增數學公式
linktitle: PowerPoint 數學公式
type: docs
weight: 80
url: /zh-hant/python-java/powerpoint-math-equations/
keywords:
- 數學公式
- 數學符號
- 數學公式
- 數學文字
- 新增數學公式
- 新增數學符號
- 新增數學公式
- 新增數學文字
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint PPT 與 PPTX 中插入與編輯數學公式，支援 OMML、格式控制，並提供清晰的 Python 程式碼範例。"
---
## **概述**

PowerPoint 以 Office Math Markup Language (OMML) 儲存公式。使用 Aspose.Slides for Python via Java，您可以以程式方式建立相同類型的數學內容：分數、根號、函數、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常透過 **Insert > Equation** 新增公式：

![PowerPoint 插入索引標籤，已選取 Equation 命令](powerpoint-math-equations_1.png)

結果是投影片上的可編輯數學文字：

![包含可編輯數學公式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建立此數學文字：

- 數學圖形，由 [addMathShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addMathShape) 建立，用於容納公式的圖形。
- [MathPortion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathportion/) 在圖形的文字框內儲存數學內容。
- [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathblock/) 物件。

以下大多數範例使用 [MathematicalText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathematicaltext/) 與來自 [MathElementBase](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/) 的流暢方法，以保持程式碼簡潔易讀。

對於 MathML 匯出情況，請參閱 [Export Math Equations from Presentations in Python](/slides/zh-hant/python-java/exporting-math-equations/).

## **建立公式**

此範例建立一個數學圖形，並加入畢氏定理：

![方程式 c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addMathShape) 會建立已包含數學段落的圖形。存取第一個 [MathPortion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathportion/)，取得其 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathparagraph/)，然後向其中加入數學區塊或數學元素。
{{% /alert %}}

## **新增分數**

使用 [divide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#divide) 來建立分數。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathfractiontypes/) 選擇分數樣式。

![一個斜式分數，顯示 1 ÷ x](powerpoint-math-equations_4.png)

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

若需堆疊式分數，使用 [MathFractionTypes.Bar](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **新增根號**

使用 [radical](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#radical) 建立平方根、立方根或其他根號。當前元素將成為底，參數則為指數。

![一個 n 次根號，x 位於根號之下](powerpoint-math-equations_5.png)

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

## **新增函數與極限**

使用 [asArgumentOfFunction](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) 或 [function](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#function) 來表示函數，例如 `sin(x)`、`log(x)`，或自訂函數名稱。若要表示極限，將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathlimit/) 中，或使用 [setLowerLimit](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#setLowerLimit)。

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

若使用自訂函數名稱，將函數名稱設為當前元素：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **新增 N 元運算子與積分**

使用 [nary](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#nary) 來表示求和、聯集、交集以及其他大型運算子。使用 [integral](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#integral) 表示積分。兩個方法皆可設定下限與上限。

![具有上下限的求和符號](powerpoint-math-equations_7.png)

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

N 元運算子用於帶有可選上下限的大型運算子。簡單運算子如 `+`、`-`、`=` 通常以 [MathematicalText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathematicaltext/) 加入並串接成表達式。

若要表示積分，使用 [integral](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#integral):

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

使用 [MathMatrix](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathmatrix/) 來建立行與列。預設情況下矩陣不會包含括號，若需要圓括號、方括號或大括號，請自行將矩陣包起來。

![一個兩列的數學矩陣，包含一個空格](powerpoint-math-equations_10.png)

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

## **新增公式陣列**

當需要對齊的公式或垂直堆疊的表達式時，使用 [toMathArray](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#toMathArray)。

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

## **新增三角函數**

當參數為當前元素且函數名稱已知時，使用 [asArgumentOfFunction](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction)：

![三角函數 cos 作用於 2x](powerpoint-math-equations_6.png)

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

使用下標與上標輔助函式來表示指數與次方。若指標需出現在基底的左側，請使用 [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)：

![大寫 Y，左側下標 1 以及上標 n](powerpoint-math-equations_9.png)

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

## **新增分隔符**

使用 [enclose](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#enclose) 把表達式置於分隔符內。對於包含多個元素的分隔符表達式，亦可設定分隔字元。

![一個分隔符表達式，包含 x、y、z，並以垂直線分隔](powerpoint-math-equations_13.png)

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

## **新增邊框盒子**

當公式本身需要被框住時，使用 [toBorderBox](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#toBorderBox)：

![一個帶框的公式，a² = b² + c²](powerpoint-math-equations_12.png)

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

    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    boxed_equation = MathematicalText("a").setSuperscript("2").join("=").join(b_squared).join("+").join(c_squared).toBorderBox()

    math_block = MathBlock(boxed_equation)
    math_paragraph.add(math_block)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **分組項目**

使用 [group](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#group) 在表達式上方或下方放置分組字符。可加入限制以標記分組的項目。

![表達式 x + y 之上有分組符號，並在下方加上標籤任意文字](powerpoint-math-equations_15.png)

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

僅在有助於說明公式時才使用格式化輔助函式。例如，[overbar](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#overbar) 會在數學元素上方加上橫線。

![數學表達式 ABC，上方加有橫線](powerpoint-math-equations_14.png)

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

## **快速參考**

| 任務 | 主要 API |
| --- | --- |
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathematicaltext/) |
| 結合元素 | [MathElementBase.join](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#join) |
| 建立分數 | [MathElementBase.divide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#divide) |
| 加入上標或下標 | [setSuperscript](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#setSubscript) |
| 加入函數 | [function](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| 加入根號 | [MathElementBase.radical](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#radical) |
| 加入極限 | [setLowerLimit](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| 加入左側上下標 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| 加入求和與積分 | [nary](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#integral) |
| 加入矩陣 | [MathMatrix](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathmatrix/) |
| 加入公式陣列 | [toMathArray](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#toMathArray) |
| 加入分隔符 | [enclose](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#enclose) |
| 加入橫線與框線 | [overbar](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| 分組項目 | [group](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathelementbase/#group) |

## **FAQ**

**我可以編輯現有的 PowerPoint 公式嗎？**

可以。打開簡報，尋找包含 [MathPortion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathportion/) 的圖形，取得其 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathparagraph/)，然後更新該段落中的數學區塊。

**公式是否以可編輯的 PowerPoint 數學形式儲存？**

是的。將檔案儲存為 PPTX 時，Aspose.Slides 會將公式寫入為可編輯的 Office 數學內容。

**我可以將公式匯出為 LaTeX 嗎？**

可以。從其 [MathPortion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathportion/) 取得公式的 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathparagraph/)，然後呼叫 [MathParagraph.toLatex](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/mathparagraph/#toLatex) 直接匯出。完整範例請參閱 [Export Math Equations from Presentations in Python](/slides/zh-hant/python-java/exporting-math-equations/#export-math-equations-to-latex)。