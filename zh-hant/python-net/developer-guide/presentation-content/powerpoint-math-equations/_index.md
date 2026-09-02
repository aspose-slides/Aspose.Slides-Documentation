---
title: 在 Python 中於 PowerPoint 簡報加入數學方程式
linktitle: PowerPoint 數學方程式
type: docs
weight: 80
url: /zh-hant/python-net/powerpoint-math-equations/
keywords:
- 數學方程式
- 數學符號
- 數學公式
- 數學文字
- 加入數學方程式
- 加入數學符號
- 加入數學公式
- 加入數學文字
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint PPT 與 PPTX 中插入與編輯數學方程式，支援 OMML、格式控制，並提供清晰的 Python 程式碼範例。"
---
## **概觀**

PowerPoint 將方程式儲存為 Office Math Markup Language（OMML）。使用 Aspose.Slides for Python via .NET，您可以以程式方式建立相同類型的數學內容：分數、根號、函式、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常從 **Insert > Equation** 新增方程式：

![PowerPoint Insert 標籤中選取 Equation 命令的畫面](powerpoint-math-equations_1.png)

結果是在投影片上顯示可編輯的數學文字：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建構該數學文字：

- 數學圖形，由 [add_math_shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_math_shape/) 建立，用於容納方程式的圖形。
- [MathPortion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathportion/) 儲存圖形文字框內的數學內容。
- [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathblock/) 物件。

以下大多數範例使用 [MathematicalText](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathematicaltext/) 以及來自 [IMathElement](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/) 的流式方法，以保持程式碼簡潔易讀。

如需 MathML 匯出情境，請參閱 [從簡報中匯出數學方程式（Python via .NET）](/slides/zh-hant/python-net/exporting-math-equations/)。

## **建立方程式**

此範例建立一個數學圖形並加入畢氏定理：

![c 的平方等於 a 的平方加上 b 的平方的方程式](powerpoint-math-equations_3.png)

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
`add_math_shape` 會建立已包含數學段落的圖形。存取第一個 `MathPortion`，取得其 `MathParagraph`，然後在其中加入數學區塊或數學元素。
{{% /alert %}}

## **新增分數**

使用 [`divide`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/divide/) 建立分數。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathfractiontypes/) 選擇分數樣式。

![顯示 1 除以 x 的傾斜數學分數](powerpoint-math-equations_4.png)

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

若要堆疊式分數，使用 `MathFractionTypes.BAR`：

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **新增根號**

使用 [`radical`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/radical/) 建立平方根、立方根或其他根號。當前元素成為底數，參數則為指數。

![帶有根號符號，根號下方為 x 的 n 次根表達式](powerpoint-math-equations_5.png)

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

## **新增函式與極限**

使用 [`as_argument_of_function`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) 或 [`function`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/function/) 來建立 `sin(x)`、`log(x)` 或自訂函式名稱等函式。若要加入極限，請在 [MathLimit](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathlimit/) 中放入 `lim`，或使用 [`set_lower_limit`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/)。

![當 x 趨近於正無限大時的極限圖示](powerpoint-math-equations_8.png)

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

若要自訂函式名稱，將函式名稱設為當前元素：

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **新增 N 元運算子與積分**

使用 [`nary`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/nary/) 取得求和、聯集、交集等大型運算子。使用 [`integral`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/integral/) 取得積分。兩者皆可設定上下限。

![帶有上下限的求和符號](powerpoint-math-equations_7.png)

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

N 元運算子用於帶有（可選）上下限的大型運算子。`+`、`-`、`=` 等簡單運算子通常以 `MathematicalText` 加入並串接於表達式中。

若要加入積分，使用 `integral`：

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **新增矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathmatrix/) 來建立列與欄。矩陣預設不包含括號，若需要括弧、方括號或大括號，請自行將矩陣包起來。

![兩列矩陣，包含一個空白儲存格](powerpoint-math-equations_10.png)

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

## **新增方程式陣列**

當需要對齊的方程式或垂直堆疊的表達式時，使用 [`to_math_array`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/to_math_array/)。

![垂直陣列，x 位於 y 之上](powerpoint-math-equations_11.png)

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

## **新增三角函式**

當參數為當前元素且函式名稱已知時，使用 [`as_argument_of_function`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/)。

![三角函式 cos 套用於 2x 的示例](powerpoint-math-equations_6.png)

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

## **新增下標與上標**

使用下標與上標輔助方法來處理索引與次方。若必須將索引放於基底左側，請使用 [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/)。

![左側帶下標 1 與上標 n 的大寫 Y](powerpoint-math-equations_9.png)

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

## **新增分隔符號**

使用 [`enclose`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/enclose/) 可將表達式放入分隔符號內。對於包含多個元素的分隔符號表達式，您亦可設定分隔字元。

![包含 x、y、z 並以直線分隔的分隔符號表達式](powerpoint-math-equations_13.png)

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

## **新增框線方程式**

使用 [`to_border_box`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/to_border_box/)，當方程式本身需要被框住時。

![方程式 a² = b² + c² 以框線呈現的示例](powerpoint-math-equations_12.png)

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

## **群組項目**

使用 [`group`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/group/) 可在表達式上方或下方放置分組符號。加入上下限以為群組項目加上標籤。

![將 x 加 y 以分組方式呈現，並在下方顯示任意文字標籤](powerpoint-math-equations_15.png)

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

僅在能提升公式可讀性時使用格式化輔助方法。例如，[`overbar`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/overbar/) 會在數學元素上方加上橫線。

![帶有上橫線的 ABC 數學表達式](powerpoint-math-equations_14.png)

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
| 組合元素 | [IMathElement.join](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/join/) |
| 建立分數 | [IMathElement.divide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/divide/) |
| 新增上標或下標 | [set_superscript](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| 新增函式 | [function](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| 新增根號 | [radical](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/radical/) |
| 新增極限 | [set_lower_limit](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| 新增左側上下標 | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| 新增求和與積分 | [nary](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/integral/) |
| 新增矩陣 | [MathMatrix](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathmatrix/) |
| 新增方程式陣列 | [to_math_array](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| 新增分隔符號 | [enclose](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| 新增橫線與框線 | [overbar](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| 群組項目 | [group](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/imathelement/group/) |

## **常見問題**  

**我可以編輯現有的 PowerPoint 方程式嗎？**

可以。開啟簡報，找到包含 `MathPortion` 的圖形，取得其 `MathParagraph`，然後更新該段落中的數學區塊。

**方程式會以可編輯的 PowerPoint 數學格式儲存嗎？**

會。儲存為 PPTX 時，Aspose.Slides 會將方程式寫入可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

可以。從 `MathPortion` 取得方程式的 [MathParagraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/)，然後呼叫 [MathParagraph.to_latex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) 直接匯出。完整範例請參閱 [從簡報中匯出數學方程式（Python via .NET）](/slides/zh-hant/python-net/exporting-math-equations/#export-math-equations-to-latex)。