---
title: PythonでPowerPointプレゼンテーションに数式を追加する
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/python-net/powerpoint-math-equations/
keywords:
- 数式
- 数学記号
- 数式
- 数式テキスト
- 数式を追加
- 記号を追加
- 数式を追加
- 数式テキストを追加
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint の PPT および PPTX に数式を挿入および編集できます。OMML のサポート、書式設定コントロール、わかりやすい Python コードサンプルを提供しています。"
---
## **概要**

PowerPoint は数式を Office Math Markup Language (OMML) として保存します。Aspose.Slides for Python via .NET を使用すると、同様の数式コンテンツをプログラムで作成できます：分数、根、関数、リミット、N 進演算子、行列、配列、そして書式設定された数式ブロック。

PowerPoint では、ユーザーは通常 **挿入 > 数式** から数式を追加します：

![PowerPoint の挿入タブで数式コマンドが選択されている状態](powerpoint-math-equations_1.png)

結果はスライド上の編集可能な数式テキストになります：

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides はその数式テキストを次の 3 つの主要オブジェクトで構築します：

- 数式シェイプは [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) で作成され、数式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) はシェイプのテキストフレーム内に数式コンテンツを保存します。
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) は 1 つ以上の [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) オブジェクトを含みます。

以下のほとんどの例は、コードを短く読みやすくするために [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) と [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) のフルエントメソッドを使用しています。

[Python via .NET でプレゼンテーションから数式をエクスポートする](/slides/ja/python-net/exporting-math-equations/)

## **数式の作成**

この例では [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) を使用して数式シェイプを作成し、ピタゴラスの定理を追加します：

![c² = a² + b² の数式](powerpoint-math-equations_3.png)

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) はすでに数式パラグラフを含むシェイプを作成します。最初の [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) にアクセスし、その [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) を取得して、数式ブロックまたは数式要素を追加します。{{% /alert %}}

## **分数の追加**

[divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) を使用して分数を作成します。[MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) で分数スタイルを選択できます。

![1 / x を示す斜めの分数](powerpoint-math-equations_4.png)

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

積み重ねた分数には [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) を使用します：

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **根号の追加**

[radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) を使用して平方根、立方根、その他の根号を作成します。現在の要素が基底になり、引数が次数になります。

![x が根号の下にある n 次根の式](powerpoint-math-equations_5.png)

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

## **関数とリミットの追加**

`sin(x)`、`log(x)`、またはカスタム関数名などの関数には [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) または [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) を使用します。リミットの場合は、`lim` を [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) に入れるか、[set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) を使用します。

![x が無限大に近づくリミット](powerpoint-math-equations_8.png)

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

カスタム関数名の場合、関数名を現在の要素にし、引数と共に [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) を呼び出します：

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N 進演算子と積分の追加**

総和、合併、交差、およびその他の大きな演算子には [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) を使用します。積分には [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) を使用します。両方のメソッドで下限と上限を設定できます。

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

N 進演算子はオプションのリミットを持つ大きな演算子向けです。`+`、`-`、`=` のような単純な演算子は通常 [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) で追加し、式に結合されます。

積分には [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) を使用します：

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **行列の追加**

行と列には [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) を使用します。行列はデフォルトで括弧を含まないため、必要に応じて丸括弧、角括弧、または波括弧で囲んでください。

![1 つの空セルを持つ 2 行の数式行列](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # 行列には独自の括弧がないため、丸括弧で囲みます。
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` は行と列のグリッドを構築し、間隔を設定し、列を揃えますが、Aspose.Slides for Python via .NET では個々の行列セルへのアクセサは公開されていません。そのためコードで作成された行列は空セルのままです。既存のプレゼンテーションからの行列のセルは `get_children` で読み取れます。コードから行を埋める必要がある場合は数式配列を使用してください。{{% /alert %}}

## **数式配列の追加**

整列された数式または縦に並んだ式が必要なときは [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) を使用します。

![x が上に、y が下にある縦の数式配列](powerpoint-math-equations_11.png)

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

### **配列の周囲要素との位置揃え**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) は配列の垂直位置揃えを隣接する数式要素に対して制御します。以下の例は、最初の行、配列の中心、最後の行での位置揃えを比較しています。

以下の例は、3 行の同一配列を 3 つ作成し、隣接要素 `A=` と `=B` を付けています。すべての数式テキストは Cambria Math の 24 ポイントです。配列の位置揃えだけが変わります。

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

以下の比較は PowerPoint で保存されたプレゼンテーションを示します。各配列の横にある `A=` と `=B` の位置に注目してください。

![PowerPoint の上部・中央・下部位置揃えの数式配列と同一の隣接要素](equation-array-alignment.png)

### **行間隔の構成**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) は配列内の行に対する間隔規則を選択します。[row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) は明示的な間隔規則の数値を提供し、プリセット規則では無視されます。

正確な間隔はポイント単位で測定されます。比例間隔は半行単位で測定され、例の値 `3` は 1.5 行を表します。明示的な値を指定する場合は両方のプロパティを設定してください。数値だけを変更しても間隔規則は選択されません。

以下の例は、同じ数式、位置揃え、フォント設定で 5 つのプレゼンテーションを保存します。最初の 3 つはプリセット、最後の 2 つは明示的な値です。

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

配列の行間隔は段落の間隔とは別です。[space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) と [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) は、配列行の間ではなく、包含する段落の前後にスペースを加えます。同様に、[IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) は数式段落全体を水平に配置し、配列の垂直位置揃え設定を置き換えるものではありません。

## **三角関数の追加**

引数が現在の要素で関数名が分かっている場合は、[as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) を使用します。

![cos が 2x に適用された三角関数](powerpoint-math-equations_6.png)

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

## **下付文字と上付文字の追加**

添字と指数には下付文字・上付文字ヘルパーを使用します。添字を基底の左側に表示する必要がある場合は、[set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) を使用してください。

![左側に下付文字 1 と上付文字 n が付いた大文字 Y](powerpoint-math-equations_9.png)

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

[enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) を使用して式を区切り記号で囲みます。複数要素を含む区切り式の場合は、区切り文字も設定できます。

![x、y、z が縦棒で区切られた区切り式](powerpoint-math-equations_13.png)

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

### **区切り記号のサイズと位置揃え**

[grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) を `True` に設定すると、縦に長いオペランドに合わせて括弧が拡大します。`False` にすると通常サイズのままです。[delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) は2つの [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) のいずれかを受け取ります。`CENTERED` は等号の中央を通る数学軸上に括弧を中央揃えにし、`MATCH` は囲まれた内容に合わせて揃えます。これらの設定は区切り記号だけに影響し、内部の式は変わりません。

例では、分数を `x` の指数に配置し、式がベースラインの上方に広がります。4 つの式はすべて同じ括弧とフォント設定を使用しています。

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

PowerPoint で行を比較して、拡大の効果を確認してください。上段では、括弧が指数を囲むように拡大し、両方の形状が同じに見えます。下段では拡大がオフです。左側の小さい括弧（`CENTERED`）は等号に揃えられ、右側の（`MATCH`）は式の上部に位置します。

![PowerPoint の 4 つの式、上段は区切り記号の拡大が有効、下段は無効、左は CENTERED、右は MATCH](delimiter-sizing.png)

## **枠ボックスの追加**

分数に対して [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) を呼び出すと、式全体に枠を付けます。返される [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) はデフォルトで 4 つの辺すべてを表示します。個別の辺を非表示にするには、[hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/)、[hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/)、[hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/)、[hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) を使用します。

例では、同じ分数を 6 つスライドに配置しています。取り消しを示すために、4 つの側すべてを非表示にし、[strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) で上昇対角線 (↗) または [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) で下降対角線 (↘) を設定します。また、[strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) や [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) を使用して、表示側の組み合わせを自由に設定できます。

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

![PowerPoint の 6 つの編集可能な分数。上段：全枠、下と左側、上昇対角線。下段：下降対角線、水平ストライク、垂直ストライクと全枠。](border-box-fractions.png)

この分数では、水平ストライクが分数バーと重なります。垂直ストライクは分子と分母の両方を横切り、周囲の枠は表示されたままです。これらの線は式全体を装飾します。通常のテキストの取り消し線はテキストランの文字に適用されます。PowerPoint でプレゼンテーションを再度開いた後でも、分子と分母を個別に編集できます。

## **項のグループ化**

式の上または下にグループ文字を配置するには [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) を使用します。グループ化された項にラベルを付けるにはリミットを追加します。

![x + y の式が任意のテキストラベルで下側にグループ化された様子](powerpoint-math-equations_15.png)

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

数式を明確にする場合にのみ書式ヘルパーを使用してください。例として、[overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) は数式要素の上にバーを付けます。

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

### **既存の数式内テキストの書式設定**

既存の数式全体のテキストを書式設定するには、各数式ブロックの要素ツリーを走査します。[IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) は直接の子要素のみを返すため、分数、添字・上付、根号、その他の入れ子構造のテキストに到達するには再帰的に呼び出します。開始要素が [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) の場合も含めるよう、現在の要素とその子要素をチェックしてください。

この例では、`input.pptx` に `z = xᵢ / ∛y` のような数式が含まれていると想定しています。分子に下付文字を持つ分数と、分母に根号がある場合などです。ブロックのトップレベル要素だけを処理すると、分数内部のテキストが抜け落ちます。例では、スライドのテキストフレーム内の数式部分を取得し、[MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) を介してブロックにアクセスし、各テキスト要素の [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) プロパティで [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) を 28 ポイントに設定します。

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

保存されたプレゼンテーションは、処理された各数式のすべてのレベルで更新されたテキスト書式を保持し、テキスト内容と数式構造をそのまま保ちます。

## **クイックリファレンス**

| タスク | 主な API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| 要素の結合 | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| 分数の作成 | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| 上付文字または下付文字の追加 | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| 関数の追加 | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| 根号の追加 | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| リミットの追加 | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| 左側スクリプトの追加 | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| 総和と積分の追加 | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| 数式配列の追加 | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| 区切り記号の追加 | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| バーと枠の追加 | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| 項のグループ化 | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **よくある質問**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) を含むシェイプを見つけ、その [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) を取得し、その段落内の数式ブロックを更新します。

**数式は編集可能な PowerPoint 数式として保存されますか？**

はい。PPTX に保存すると、Aspose.Slides は数式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

はい。数式の [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) をその [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) から取得し、[MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) を呼び出すと直接エクスポートできます。完全な例については、[Python via .NET でプレゼンテーションから数式をエクスポートする](/slides/ja/python-net/exporting-math-equations/#export-math-equations-to-latex) を参照してください。