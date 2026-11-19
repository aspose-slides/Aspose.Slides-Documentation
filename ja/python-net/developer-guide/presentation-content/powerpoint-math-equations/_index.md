---
title: PowerPoint プレゼンテーションに数式を追加する（Python）
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/python-net/powerpoint-math-equations/
keywords:
- 数学方程式
- 数学記号
- 数学式
- 数学テキスト
- 数学方程式を追加
- 数学記号を追加
- 数学式を追加
- 数学テキストを追加
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint PPT および PPTX に数式を挿入・編集し、OMML、書式設定コントロール、明確な Python コードサンプルをサポートします。"
---
## **概要**

PowerPoint は数式を Office Math Markup Language (OMML) として保存します。Aspose.Slides for Python via .NET を使用すると、分数、根号、関数、極限、N 元演算子、行列、配列、書式設定された数式ブロックなど、同様の数式コンテンツをプログラムで作成できます。

PowerPoint では、ユーザーは通常 **挿入 > 数式** から数式を追加します:

![PowerPoint の「挿入」タブで「数式」コマンドが選択されている状態](powerpoint-math-equations_1.png)

結果としてスライド上に編集可能な数式テキストが表示されます:

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides は、次の 3 つの主要オブジェクトを使用して数式テキストを構築します:

- 数式シェイプは、[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) で作成され、数式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) はシェイプのテキストフレーム内に数式コンテンツを保存します。
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) は 1 つ以上の [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) オブジェクトを含みます。

以下の例のほとんどは、コードを短く読みやすく保つために [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) と [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/) のフルエントメソッドを使用しています。

MathML エクスポートシナリオについては、[Export Math Equations from Presentations in Python via .NET](/slides/ja/python-net/exporting-math-equations/) を参照してください。

## **数式の作成**

この例では、[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) を使用して数式シェイプを作成し、ピタゴラスの定理を追加します:

![c² = a² + b² の式](powerpoint-math-equations_3.png)

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) は、すでに数式段落を含むシェイプを作成します。最初の [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) にアクセスし、その [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) を取得して、数式ブロックまたは数式要素を追加します。
{{% /alert %}}

### **数式ブロックの結合**

数式の一部が [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) オブジェクトとして個別に作成されている場合、[join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) を使用して結合します。この例では、左側のブロックで `c² =`、右側のブロックで `a² + b²` を構築します。[set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/) は、3 つすべての累乗に対して編集可能な数式上付き文字を作成します。

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

[join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) は `left_block` 自身を返し、順番通りに両方の部分を含むようになり、`right_block` は空になります。結合したブロックは [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) に一度だけ追加します。`equation.pptx` を再度開くと、段落には `c² = a² + b²` を表す 1 つのブロックが含まれ、3 つの累乗はすべて数式上付き文字として保持されます。

[add](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/add/) を `left_block.add(right_block)` のように呼び出すと、ブロックを直接入れ子にしようとし、.NET の `InvalidOperationException` をラップした `RuntimeError` が発生します。

## **分数の追加**

[divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) を使用して分数を作成します。[MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) で分数のスタイルを選択できます。

![1 を x で割った斜めの数式分数](powerpoint-math-equations_4.png)

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

積み上げ分数の場合は、[MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) を使用します:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **根号の追加**

[radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) を使用して平方根、立方根、その他の根号を作成します。現在の要素が基底となり、引数が次数になります。

![根号記号の下に x がある n 次根式](powerpoint-math-equations_5.png)

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

### **平方根の次数の表示・非表示**

平方根は明示的に 2 を表示するか、従来の √x 記法を使用できます。[MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) の [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/) プロパティでどちらの形式を表示するか制御します。どちらの形式でも、編集可能な数式では次数 2 と被根式 x が保持されます。

![左側に次数 2 が表示され、右側で非表示の x の平方根](square-root-degree.png)

この例では同じ平方根を2回保存します。`visible-degree.pptx` では 2 が表示され、`hidden-degree.pptx` では非表示になります。

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

## **関数と極限の追加**

`sin(x)`、`log(x)` などの関数やカスタム関数名には [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) または [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) を使用します。極限の場合は、`lim` を [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) に入れるか、[set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/) を使用します。

![x が無限大に近づく極限](powerpoint-math-equations_8.png)

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

カスタム関数名の場合、関数名を現在の要素にし、引数とともに [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) を呼び出します:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N 元演算子と積分の追加**

総和、和集合、積集合、その他の大きな演算子には [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/) を使用します。積分には [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) を使用します。両方のメソッドで下限と上限を設定できます。

![下限と上限を持つ総和](powerpoint-math-equations_7.png)

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

N 元演算子は、オプションで上下限を持つ大きな演算子向けです。`+`、`-`、`=` などの単純な演算子は通常 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) として追加し、式に結合します。

積分の場合は、[integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) を使用します:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **行列の追加**

[MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) を使用して行と列を作成します。行列はデフォルトで括弧を含まないため、必要に応じて丸括弧、角括弧、波括弧で囲んでください。

![空のセルが1つある2行の数式行列](powerpoint-math-equations_10.png)

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

### **既存の行列の編集**

`matrix.pptx` に前述の例で保存された係数行列があるとします。次の練習では、最初の式はそのままにし、2番目の式を2つの新しい式に置き換え、変数のセットを修正します。既存の行列を [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) として取得し、まだ有効な係数を保持します。

![元の2行の係数行列：1、x、空セルが1行目に、x、2、y が2行目にあります](matrix-before-edit.png)

行と列のインデックスは 0 から始まり、各呼び出し時点の行列を指します。インデックス 1 の前に行を挿入すると、元の2行目がインデックス2に移動します。インデックス 2 の後に挿入すると行が追加されます。行2を削除すると、元の2番目の式が削除され、追加された行が1つ上に移動します。列も同様にシフトします。

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

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) は最初の列を左揃えにします。[set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) はインデックス1から開始する 3 つの連続した列を右揃えにします。`updated-matrix.pptx` では、行列は3つの式と4つの変数を持ちます。元の1行目の係数 `1` と `x` は現在、1列目と3列目に表示されます。

![更新された3行の行列：行は 1,0,x,0；12,1,0,0；0,0,10,1](matrix-after-edit.png)

## **数式配列の追加**

整列した数式や縦に積み重ねた式が必要な場合は、[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) を使用します。

![x が上、y が下にある縦方向の数式配列](powerpoint-math-equations_11.png)

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

### **配列を周囲の要素と揃える**

[MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) は、配列の垂直位置を隣接する数式要素に対して制御します。以下の例は、配列の最上行、中央、最下行との揃え方を比較しています。

次の例では、3 行からなる同一の配列を 3 つ作成し、隣接要素として `A=` と `=B` を配置します。すべての数式テキストは 24 ポイントの Cambria Math を使用します。配列の揃え方だけが変わります。

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

以下の比較は、PowerPoint で保存されたプレゼンテーションを示しています。各配列の横にある `A=` と `=B` の位置に注目してください。

![PowerPoint での数式配列：上揃え、中央揃え、下揃えで、隣接要素は同一](equation-array-alignment.png)

### **行間隔の設定**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) は、配列内の行の間隔ルールを選択します。[row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) は、明示的な間隔ルールに数値を提供し、プリセットルールでは無視されます。

正確な間隔の場合、値はポイントで測定されます。比例間隔の場合、半行単位で測定されます。例の値 `3` は 1.5 行に相当します。明示的な値を指定する場合は両方のプロパティを設定してください。数値だけを変更しても間隔ルールは選択されません。

以下の例は、同じ数式、揃え、フォント設定で 5 つのプレゼンテーションを保存します。最初の 3 つはプリセットを使用し、最後の 2 つは明示的な値を示します。

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

配列の行間隔は段落間隔とは別です。[space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) と [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) は配列行間ではなく、包含する段落の前後に空白を追加します。同様に、[MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) は数式段落全体の水平位置を決め、配列の垂直揃え設定を置き換えるものではありません。

## **三角関数の追加**

引数が現在の要素で関数名が既知の場合は、[as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) を使用します。

![2x に適用された三角関数 cos](powerpoint-math-equations_6.png)

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

## **下付き文字と上付き文字の追加**

インデックスや累乗には下付き文字・上付き文字ヘルパーを使用します。インデックスを基底の左側に表示する必要がある場合は、[set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) を使用します。

![左側に下付き文字 1 と上付き文字 n を持つ大文字 Y](powerpoint-math-equations_9.png)

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

## **区切り記号の追加**

[enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) を使用して式を区切り記号で囲みます。複数要素を含む区切り記号式には区切り文字も設定できます。

![x、y、z を縦棒で区切った区切り記号式](powerpoint-math-equations_13.png)

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

### **区切り記号のサイズと位置合わせ**

[grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/) を `True` に設定すると、縦長のオペランドに合わせて括弧が拡大します。`False` にすると通常サイズのままです。[delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) は [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) の 2 つの値のいずれかを取ります。`CENTERED` は等号の中間を通る数式軸上に括弧を中央揃えし、`MATCH` は内部コンテンツに合わせて位置合わせします。両設定は括弧のみに影響し、内部式は変わりません。

この例では、`x` の指数に分数を配置し、式がベースラインより上に大きく伸びるようにしています。4 つの式すべてで同じ括弧とフォント設定を使用しています。

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

PowerPoint で行を比較すると拡大効果がわかります。上段では、括弧が指数を囲むように拡大し、両形状で同様に見えます。下段では拡大がオフになっています。左側の小さな括弧（`CENTERED`）は等号に合わせ、右側（`MATCH`）は式の上部に高く配置されます。

![PowerPoint の 4 つの式：上段は区切り記号の拡大が有効、下段は無効、左側は Centered、右側は Match](delimiter-sizing.png)

## **枠付きボックスの追加**

分数に対して [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) を呼び出すと、式全体に枠が付けられます。返される [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) はデフォルトで四辺すべてを表示します。個別の辺を削除するには、[hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/)、[hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/)、[hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/)、[hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/) を使用します。

この例では、同じ分数のコピーを 1 スライドに 6 つ配置しています。取り消し線を示すためにすべての辺を非表示にし、上向き対角線（↗）には [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/)、下向き対角線（↘）には [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) を設定します。また、[strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) や [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) を任意の表示辺の組み合わせで使用できます。

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

![PowerPoint の 6 つの編集可能な分数。上段：全枠、下部と左側の枠、上向き対角線。下段：下向き対角線、横線、縦線と全枠](border-box-fractions.png)

この分数では、横の取り消し線が分数棒と重なります。縦の取り消し線は分子と分母の両方を横切り、周囲の枠は表示されたままです。これらの線は式全体を装飾します。通常のテキスト取り消し線はテキストラン内の文字に適用されます。PowerPoint でプレゼンテーションを再度開いても、分子と分母はそれぞれ独立して編集可能です。

## **Phantom 要素で可視性とレイアウトを制御**

式を [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) でラップすると、可視性と式が占めるスペースを個別に制御できます。そのプロパティは以下を制御します:

| プロパティ | 効果 |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | `False` に設定すると式を非表示にします。対応する下位プロパティが `True` でない限り、寸法はレイアウトに寄与し続けます。 |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | 式の横幅を 0 とみなすことで、隣接要素がより近づきます。 |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | 上昇部（ベースライン上の高さ）を 0 とみなします。これにより、隣接要素の上部の余白が減少することがあります。 |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | 下降部（ベースライン下の深さ）を 0 とみなします。これにより、分数棒や他のコンテンツが式の下部に近づきます。 |

ベースラインは、通常の数式文字が配置される基準ラインです。コンテンツを非表示にしても寸法は残り、寸法を 0 と扱っても式自体は削除されません。基礎となる式は [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/) から取得可能です。[show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) を `True` に戻すと再び表示され、寸法設定はそのまま保持されます。

以下の例は、5 つの横並びバリエーションを作成します：可視分数、スペースを確保した非表示分数、そして 1 つの寸法をゼロにした 3 つの非表示分数です。各バリエーションは同じ周囲式と 24 ポイントの Cambria Math を使用します。すべての数式シェイプは同じ上位置に配置され、グレーのガイドで示されています。外側の分数の分子に phantom を置くと、縦レイアウトの変化が見やすくなります。

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

![PowerPoint での 5 つの式：可視分数、スペースを確保した非表示分数、ZeroWidth、ZeroAsc、ZeroDesc が有効な非表示分数の比較](math-phantom.png)

## **項のグループ化**

[group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) を使用して、式の上または下にグループ化文字を配置します。グループ化した項にラベルを付けるにはリミットを追加します。

![x + y の式がグループ化文字で囲まれ、下に任意のテキストがラベルとして付いている](powerpoint-math-equations_15.png)

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

## **数式要素の書式設定**

書式設定ヘルパーは、式の可読性が向上する場合にのみ使用してください。例として、[overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/) は数式要素の上にバーを配置します。

![上にバーが付いた数式 ABC](powerpoint-math-equations_14.png)

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

### **既存の式のテキスト書式設定**

既存の式全体のテキストを書式設定するには、各数式ブロックの要素ツリーを走査します。[MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) は直接の子要素のみを返すため、再帰的に呼び出して分数、スクリプト、根号、その他の入れ子構造内のテキストに到達します。現在の要素とその子要素の両方をチェックし、開始要素が [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) の場合も含めます。

この例では、`input.pptx` に `z = xᵢ / ∛y` のような式が含まれていると想定します。分子に下付き文字、分母に根号を持つ分数が含まれます。ブロックのトップレベル要素だけを処理すると、分数内部のテキストが見逃されます。例はスライドのテキストフレーム内の数式部分を検索し、[MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) を介してブロックにアクセスし、各テキスト要素の [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) プロパティから [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) を 28 ポイントに設定します。

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

保存されたプレゼンテーションには、処理された各式のすべてのレベルで更新されたテキスト書式が含まれ、テキスト内容と数式構造は保持されたままです。

## **クイックリファレンス**

| タスク | 主な API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| 要素の結合 | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| 分数の作成 | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| 上付き文字または下付き文字の追加 | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| 関数の追加 | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| 根号の追加 | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| 極限の追加 | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| 左側添字の追加 | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| 総和と積分の追加 | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| 数式配列の追加 | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| 区切り記号の追加 | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| バーと枠の追加 | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| 項のグループ化 | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **FAQ**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) を含むシェイプを見つけ、その [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) を取得して、段落内の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX に保存すると、Aspose.Slides は数式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

はい。式の [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) をその [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) から取得し、[MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) を呼び出して直接エクスポートします。完全なサンプルは、[Export Math Equations from Presentations in Python via .NET](/slides/ja/python-net/exporting-math-equations/#export-math-equations-to-latex) を参照してください。