---
title: 在 Python 中將數學方程式加入 PowerPoint 簡報
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
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint PPT 和 PPTX 中插入與編輯數學方程式，支援 OMML、格式控制，以及清晰的 Python 程式碼範例。"
---
## **概述**

PowerPoint 以 Office Math Markup Language (OMML) 儲存方程式。使用 Aspose.Slides for Python via .NET，您可以以程式方式建立相同類型的數學內容：分數、根號、函數、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常從 **Insert > Equation** 新增方程式：

![PowerPoint 插入索引標籤，已選取「方程式」指令](powerpoint-math-equations_1.png)

結果是投影片上可編輯的數學文字：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建構此數學文字：

- 數學圖形，使用 [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) 建立，是包含方程式的圖形。
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 在圖形的文字框內儲存數學內容。
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) 物件。

大多數以下範例使用 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 以及來自 [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) 的串流方法，以保持程式碼簡潔且易於閱讀。

對於 MathML 匯出情境，請參閱【[匯出以 Python via .NET 的簡報中的數學方程式](/slides/zh-hant/python-net/exporting-math-equations/)】。

## **建立方程式**

此範例使用 [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) 建立數學圖形，並加入畢氏定理：

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

{{% alert color="info" title="Note" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) 會建立一個已包含數學段落的圖形。存取第一個 [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)，取得其 [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)，即可向其中加入數學區塊或數學元素。
{{% /alert %}}

## **加入分數**

使用 [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) 來建立分數。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) 選擇分數樣式。

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

若要建立堆疊分數，使用 [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/)：

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **加入根號**

使用 [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) 來建立平方根、立方根或其他次根。當前元素成為底數，參數則成為次方。

![含 x 在根號符號下的 n 次根號表達式](powerpoint-math-equations_5.png)

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

### **顯示或隱藏平方根的次方**

平方根可以明確顯示 2，或使用慣用的 √x 記法。[hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathradical/hide_degree/) 屬性於 [IMathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathradical/) 控制顯示形式。兩種形式皆保留次方 2 與根號內的 x。

![x 的平方根，左側顯示次方 2，右側隱藏次方 2](square-root-degree.png)

此範例將相同的平方根儲存兩次。`visible-degree.pptx` 中次方可見，`hidden-degree.pptx` 中次方被隱藏。

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

## **加入函數與極限**

使用 [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) 或 [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) 來處理 `sin(x)`、`log(x)` 或自訂函數名稱等函數。對於極限，可在 [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) 中放入 `lim`，或使用 [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/)。

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

若使用自訂函數名稱，先將函數名稱設為當前元素，然後以其參數呼叫 [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/)：

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **加入 N 元運算子與積分**

使用 [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) 來表示求和、聯集、交集等大型運算子。使用 [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) 來表示積分。兩種方法皆可設定上下限。

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

N 元運算子用於帶有可選上下限的大型運算子。像 `+`、`-`、`=` 這類簡單運算子通常以 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 加入並串接至表達式。

對於積分，使用 [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/)：

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **加入矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) 來處理列與欄。預設情況下矩陣不包含括號，若需要括弧、方括號或大括號，請自行將矩陣包起來。

![兩列的數學矩陣，包含一個空白儲存格](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # 矩陣本身沒有括號，所以要用圓括號將其包起來。
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` 會建立列與欄的格線、設定格子間距並對齊欄，但 Aspose.Slides for Python via .NET 並未公開個別格子的存取器。以程式碼建立的矩陣因此會保留空格子；若矩陣來源於現有簡報，則可透過 `get_children` 讀取格子。需要從程式碼填充列時，請使用方程式陣列。
{{% /alert %}}

## **加入方程式陣列**

當需要對齊的方程式或垂直堆疊的表達式時，使用 [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/)。

![垂直的數學陣列，x 在 y 上方](powerpoint-math-equations_11.png)

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

### **將陣列與周圍元素對齊**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) 控制陣列相對於旁邊數學元素的垂直對齊。以下範例比較了以第一列、陣列中心以及最後一列作為對齊基準的效果。

以下範例會建立三個相同的陣列，每個陣列皆有三列，且相鄰元素為 `A=` 與 `=B`。所有數學文字皆使用 Cambria Math，字型大小 24 點。唯一變動的是陣列的對齊方式。

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

比較圖顯示了在 PowerPoint 中儲存的簡報。請注意每個陣列旁的 `A=` 與 `=B` 位置。

![PowerPoint 中的方程式陣列，使用頂部、居中與底部對齊，且相鄰元素相同](equation-array-alignment.png)

### **設定列間距**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) 用於選擇陣列內列的間距規則。[row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) 提供明確的數值，會在使用預設規則時被忽略。

若使用精確間距，數值以點為單位。若使用比例間距，則以半行為單位：範例中的值 `3` 代表 1.5 行。設定明確數值時，需同時設定兩個屬性；僅更改數值不會自動選擇間距規則。

以下範例儲存了五個簡報，方程式、對齊與字型設定相同。前三個使用預設規則，後兩個則使用明確數值。

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

陣列列間距獨立於段落間距。[space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) 與 [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) 會在包含段落的前後加入空間，而不是在陣列列之間。同樣地，[IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) 會水平定位整個數學段落，並不會取代陣列的垂直對齊設定。

## **加入三角函數**

當參數為當前元素且函數名稱已知時，使用 [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/)。

![三角函數 cos 套用於 2x](powerpoint-math-equations_6.png)

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

使用下標與上標輔助工具處理索引與次方。若索引必須顯示在基底左側，請使用 [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/)。

![大寫 Y 左側下標 1 及上標 n](powerpoint-math-equations_9.png)

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

## **加入分界符**

使用 [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) 將表達式置於分界符內。若分界符包含多個元素，亦可設定分隔字元。

![包含 x、y、z 並以垂直線分隔的分界符表達式](powerpoint-math-equations_13.png)

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

### **調整分界符的大小與對齊**

將 [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) 設為 `True`，即可讓括號隨較高的運算元自動伸長；設為 `False` 時則保持普通大小。[delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) 接受兩種 [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) 之一。`CENTERED` 會將括號置於數學軸的中心（等號的中間），`MATCH` 則與所包圍的內容對齊。這兩項設定僅影響分界符本身，裡面的表達式保持不變。

範例將分數放在 `x` 的指數位置，使表達式在基線之上延伸得比基線之下更高。四個方程式皆使用相同的括號與字型設定。

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

在 PowerPoint 中比較各列，可見成長效果。上列的括號在包住指數時會伸長，左右兩種形狀的外觀相同。下列則關閉成長功能，左側（`CENTERED`）的較小括號與等號對齊，右側（`MATCH`）的括號則在表達式上方較高。

![PowerPoint 中四個方程式，左側使用 Centered、右側使用 Match，且上方啟用分界符成長、下方停用。](delimiter-sizing.png)

## **加入邊框盒**

對分數呼叫 [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/)，即可為整個表達式加上框線。回傳的 [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) 預設顯示四側。可分別使用 [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/)、[hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/)、[hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/)、[hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) 來隱藏個別側邊。

範例在同一張投影片上放置六個相同的分數。為了呈現取消效果，將四側全部隱藏，並設定 [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) 產生上升對角線 (↗)，或使用 [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) 產生下降對角線 (↘)。也可搭配任意可見側使用 [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) 或 [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/)。

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

![PowerPoint 中的六個可編輯分數。上列：完整邊框、底部與左側邊框、上升對角線。下列：下降對角線、水平刪除線、垂直刪除線且帶完整邊框。](border-box-fractions.png)

在此分數中，水平刪除線與分數線重疊。垂直刪除線同時穿過分子與分母，而周圍的邊框仍然可見。這些線條裝飾整個表達式。普通文字的刪除線僅適用於文字執行。重新在 PowerPoint 開啟簡報後，仍可分別編輯分子與分母。

## **使用幻影元素控制可見性與布局**

將表達式包在 [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) 中，即可獨立控制其可見性與對方程式佔用的空間。[IMathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/) 的屬性如下：

| 屬性 | 效果 |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/show/) | 設為 `False` 可隱藏表達式。其尺寸仍會影響布局，除非下列對應屬性為 `True`。 |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/zero_width/) | 將表達式的水平寬度視為 0，讓相鄰元素更靠近。 |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/zero_asc/) | 將其上升部（基線以上的高度）視為 0，可減少相鄰元素上方的預留空間。 |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/zero_desc/) | 將其下降部（基線以下的深度）視為 0，可使分數線或其他內容更靠近其下方的相鄰元素。 |

基線是普通數學字母所在的參考線。隱藏內容並不會移除其尺寸，將尺寸視為 0 亦不會刪除表達式。底層表達式仍可透過 [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/base/) 取得。將 [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathphantom/show/) 設回 `True` 可重新顯示，尺寸設定則保持不變。

以下範例建立五種相鄰變體：一個可見分數、一個保留空間的隱藏分數，以及三個以單一維度為 0 的隱藏分數。每種變體皆使用相同的周圍表達式與 Cambria Math，字型大小 24 點。所有方程式圖形的上緣位置相同，以灰色參考線標示。將幻影放在外部分數的分子中，可更易觀察垂直布局的變化。

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

![PowerPoint 中的五個方程式，比較可見分數、保留空間的隱藏分數，以及啟用 ZeroWidth、ZeroAsc 或 ZeroDesc 的隱藏分數。](math-phantom.png)

## **分組項目**

使用 [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) 可將分組符號放置於表達式的上方或下方。加入上下限即可為分組項目加上標籤。

![將表達式 x 加 y 分組，且在其下方加上任何文字標籤](powerpoint-math-equations_15.png)

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

僅在需要說明公式時使用格式化輔助工具。例如，[overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) 可在數學元素上方加上一條橫線。

![帶上劃線的數學表達式 ABC](powerpoint-math-equations_14.png)

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

### **格式化現有方程式中的文字**

若要在現有方程式中格式化文字，必須遍歷每個數學區塊的元素樹。[IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) 僅返回直接子項目，請以遞迴方式呼叫以取得分數、上標／下標、根號及其他巢狀結構內的文字。檢查當前元素與其子項，以確保當元素為 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) 時也會被納入。

此範例假設 `input.pptx` 包含如 `z = xᵢ / ∛y` 的方程式，其中分數的分子帶有下標，分母則為根號。僅處理區塊的頂層元素會遺漏分數內的文字。範例會在投影片文字框中找出數學部分，透過 [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) 取得其區塊，並將每個文字元素的 [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) 中的 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) 設為 28 點。

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

儲存的簡報會在每個處理過的方程式的每個層級上更新文字格式，同時保留文字內容與數學結構。

## **快速參考**

| 任務 | 主要 API |
| --- | --- |
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| 結合元素 | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| 建立分數 | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| 加入上標或下標 | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| 加入函數 | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| 加入根號 | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| 加入極限 | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| 加入左側上下標 | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| 加入求和與積分 | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| 加入矩陣 | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| 加入方程式陣列 | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| 加入分界符 | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| 加入劃線與邊框 | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| 分組項目 | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **常見問題**

**我可以編輯現有的 PowerPoint 方程式嗎？**

可以。開啟簡報，找到包含 [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 的圖形，取得其 [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)，然後更新該段落中的數學區塊即可。

**方程式會以可編輯的 PowerPoint 數學形式儲存嗎？**

會。儲存為 PPTX 時，Aspose.Slides 會將方程式寫入可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

可以。從其 [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) 取得 [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)，然後呼叫 [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) 直接匯出。完整範例請參閱【[匯出以 Python via .NET 的簡報中的數學方程式](/slides/zh-hant/python-net/exporting-math-equations/#export-math-equations-to-latex)】。