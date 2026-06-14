---
title: 在 Python 中為 PowerPoint 簡報新增數學方程式
linktitle: PowerPoint 數學方程式
type: docs
weight: 80
url: /zh-hant/python-net/powerpoint-math-equations/
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
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint PPT 與 PPTX 中插入與編輯數學方程式，支援 OMML、格式控制，並提供清晰的 Python 程式碼範例。"
---
## **概觀**

PowerPoint 存儲方程式為 Office Math Markup Language (OMML)。使用 Aspose.Slides for Python via .NET，您可以以程式方式建立相同類型的數學內容：分數、根號、函數、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常從 **插入 > 方程式** 加入方程式：

![PowerPoint 插入標籤，已選取方程式指令 selected](powerpoint-math-equations_1.png)

結果是可編輯的數學文字在投影片上：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建立該數學文字：

- 數學形狀，使用 [add_math_shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_math_shape/) 建立，是包含方程式的形狀。
- [MathPortion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathportion/) 在形狀的文字框內儲存數學內容。
- [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathblock/) 物件。

以下大多數範例使用 [MathematicalText](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathematicaltext/) 以及來自 [IMathElement](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/) 的流暢方法，以保持程式碼簡潔且易讀。

對於 MathML 匯出情況，請參閱 [Export Math Equations from Presentations in Python via .NET](/slides/zh-hant/python-net/exporting-math-equations/)。

## **建立方程式**

此範例建立一個數學形狀並加入畢氏定理：

![c 平方等於 a 平方加 b 平方的方程式](powerpoint-math-equations_3.png)

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
`add_math_shape` 會建立已包含數學段落的形狀。存取第一個 `MathPortion`，取得其 `MathParagraph`，並將數學區塊或數學元素加入其中。
{{% /alert %}}

## **加入分數**

使用 [`divide`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/divide/) 來建立分數。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathfractiontypes/) 來選擇分數樣式。

![顯示 1 除以 x 的斜分數](powerpoint-math-equations_4.png)

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

若要堆疊分數，使用 `MathFractionTypes.BAR`：

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **加入根號**

使用 [`radical`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/radical/) 來建立平方根、立方根或其他根。當前元素成為底部，而參數則成為次方。

![帶有 x 在根號下的 n 次根號表達式](powerpoint-math-equations_5.png)

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

## **加入函數與極限**

使用 [`as_argument_of_function`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) 或 [`function`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/function/) 來處理如 `sin(x)`、`log(x)` 或自訂函數名稱的函數。對於極限，將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathlimit/) 或使用 [`set_lower_limit`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/)。

![當 x 趨近於無限大時的極限](powerpoint-math-equations_8.png)

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

對於自訂函數名稱，將函數名稱設為當前元素：

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **加入 N 元運算子與積分**

使用 [`nary`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/nary/) 來處理求和、聯集、交集以及其他大型運算子。使用 [`integral`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/integral/) 來處理積分。這兩個方法都允許設定上下限。

![帶有上下限的求和](powerpoint-math-equations_7.png)

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

N 元運算子用於帶有可選上下限的大型運算子。像 `+`、`-`、`=` 這樣的簡單運算子通常以 `MathematicalText` 形式加入並組合成表達式。

對於積分，使用 `integral`：

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **加入矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathmatrix/) 來設定行與列。矩陣預設不包含括號，因此當需要圓括號、方括號或大括號時，請自行將矩陣包起來。

![具有一個空格的兩列數學矩陣](powerpoint-math-equations_10.png)

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

## **加入方程式陣列**

當需要對齊的方程式或垂直堆疊的表達式時，使用 [`to_math_array`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/to_math_array/)。

![垂直的數學陣列，x 位於 y 之上](powerpoint-math-equations_11.png)

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

## **加入三角函數**

當參數為當前元素且函數名稱已知時，使用 [`as_argument_of_function`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/)。

![cos 三角函數套用於 2x](powerpoint-math-equations_6.png)

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

## **加入下標與上標**

使用下標與上標助手來處理索引與次方。當索引必須顯示在基底的左側時，使用 [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/)。

![大寫 Y，左側下標 1 以及上標 n](powerpoint-math-equations_9.png)

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

## **加入分隔符號**

使用 [`enclose`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/enclose/) 可將表達式放入分隔符號中。您也可以為包含多個元素的分隔符號表達式設定分隔字元。

![包含 x、y、z 並以垂直線分隔的分隔符號表達式](powerpoint-math-equations_13.png)

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

## **加入邊框盒**

當方程式本身需要被框住時，使用 [`to_border_box`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/to_border_box/)。

![顯示 a 平方等於 b 平方加 c 平方的框線方程式](powerpoint-math-equations_12.png)

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

## **分組項目**

使用 [`group`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/group/) 在表達式上方或下方放置分組字符。加入上下限以標記分組的項目。

![x 加 y 的表達式被分組，並在其下方加上任意文字標籤](powerpoint-math-equations_15.png)

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

## **格式化數學元素**

僅在需要闡明公式時使用格式化助手。例如，[`overbar`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/overbar/) 會在數學元素上方加上一條橫線。

![帶有上橫線的數學表達式 ABC](powerpoint-math-equations_14.png)

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

## **快速參考**

| 任務 | 主要 API |
| --- | --- |
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathematicaltext/) |
| 結合元素 | [IMathElement.join](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/join/) |
| 建立分數 | [IMathElement.divide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/divide/) |
| 加入上標或下標 | [set_superscript](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| 加入函數 | [function](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| 加入根號 | [radical](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/radical/) |
| 加入極限 | [set_lower_limit](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| 加入左側標註 | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| 加入求和與積分 | [nary](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/integral/) |
| 加入矩陣 | [MathMatrix](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathmatrix/) |
| 加入方程式陣列 | [to_math_array](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| 加入分隔符號 | [enclose](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| 加入橫線與邊框 | [overbar](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| 分組項目 | [group](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/group/) |

## **常見問題**

**我可以編輯現有的 PowerPoint 方程式嗎？**

可以。開啟簡報，找到包含 `MathPortion` 的形狀，取得其 `MathParagraph`，然後更新該段落中的數學區塊。

**方程式是否以可編輯的 PowerPoint 數學形式儲存？**

可以。當儲存為 PPTX 時，Aspose.Slides 會將方程式寫入為可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

Aspose.Slides 會將數學方程式匯出為 MathML。如果需要 LaTeX，請先匯出為 MathML，然後使用支援目標 LaTeX 方言的工具將 MathML 轉換為 LaTeX。