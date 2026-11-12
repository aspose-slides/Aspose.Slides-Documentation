---
title: Python で PowerPoint プレゼンテーションに数式を追加
linktitle: PowerPoint 数学方程式
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
description: "Aspose.Slides for Python via .NET を使用して PowerPoint PPT および PPTX に数式を挿入および編集でき、OMML、書式設定コントロール、明確な Python コードサンプルをサポートします。"
---
## **概要**

PowerPoint は数式を Office Math Markup Language (OMML) として保存します。Aspose.Slides for Python via .NET を使用すると、プログラムで同様の数式コンテンツ、たとえば分数、根号、関数、極限、N 進演算子、行列、配列、整形された数式ブロックを作成できます。

PowerPoint では、ユーザーは通常 **挿入 > 数式** から数式を追加します：

![数式コマンドが選択された PowerPoint の挿入タブ](powerpoint-math-equations_1.png)

結果としてスライド上に編集可能な数式テキストが表示されます：

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides は、次の 3 つの主要オブジェクトを使用してその数式テキストを構築します：

- 数式を含むシェイプとなる math shape は、[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/)で作成されます。
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) は、シェイプのテキストフレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) は、1つ以上の[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)オブジェクトを含みます。

以下のほとんどの例では、コードを簡潔で読みやすく保つために[MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/)と[IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)のフルエントメソッドを使用しています。

MathML エクスポートのシナリオについては、[Export Math Equations from Presentations in Python via .NET](/slides/ja/python-net/exporting-math-equations/) を参照してください。

## **数式の作成**

この例では、[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) を使用して math shape を作成し、ピタゴラスの定理を追加します：

![c の二乗が a の二乗と b の二乗の和に等しい式](powerpoint-math-equations_3.png)

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) は、すでに math paragraph を含むシェイプを作成します。最初の[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)にアクセスし、その[math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)を取得して、math blockまたはmath elementを追加します。
{{% /alert %}}

## **分数の追加**

分数を作成するには、[divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) を使用します。分数のスタイルは[MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/)で選択できます。

![1÷x を示す斜めの数式分数](powerpoint-math-equations_4.png)

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

積み上げ式の分数には、[MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/)を使用します：

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **根号の追加**

[radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) を使用して平方根、立方根、またはその他の根号を作成します。現在の要素が基底となり、引数が次数となります。

![x が根号記号の下にある n 次根の式](powerpoint-math-equations_5.png)

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

## **関数と極限の追加**

関数（例: `sin(x)`, `log(x)`, またはカスタム関数名）には、[as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) または [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) を使用します。極限の場合は、`lim` を[MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/)に入れるか、[set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/)を使用します。

![x が無限大に近づくときの極限](powerpoint-math-equations_8.png)

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

カスタム関数名の場合、関数名を現在の要素にし、引数と共に[function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) を呼び出します：

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N 進演算子と積分の追加**

総和、和集合、積集合、その他の大きな演算子には[nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/)を使用します。積分には[integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/)を使用します。両方のメソッドで下限と上限を設定できます。

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

N 進演算子は、オプションの上下限を持つ大きな演算子用です。`+`, `-`, `=` などの単純な演算子は通常、[MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) として追加し、式に結合します。

積分の場合は、[integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) を使用します：

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **行列の追加**

行と列には[MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/)を使用します。行列はデフォルトで括弧を含まないため、丸括弧、角括弧、または波括弧が必要な場合は行列を囲んでください。

![空白セルが1つある2行の数式行列](powerpoint-math-equations_10.png)

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
`MathMatrix` は行と列のグリッドを構築し、間隔を設定し、列を揃えますが、Aspose.Slides for Python via .NET では個々の行列セルへのアクセサは公開されていません。そのため、コードで作成された行列は空白セルのままです。既存のプレゼンテーションからの行列のセルは `get_children` で取得できます。コードから行を埋める必要がある場合は、式配列を使用してください。
{{% /alert %}}

## **式配列の追加**

整列した式や縦に積み重ねた式が必要な場合は、[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) を使用します。

![x が上、y が下に配置された縦方向の式配列](powerpoint-math-equations_11.png)

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

## **三角関数の追加**

引数が現在の要素で関数名が既知の場合は、[as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) を使用します。

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

インデックスや指数には下付き・上付きヘルパーを使用します。インデックスを基底の左側に表示する必要がある場合は、[set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) を使用します。

![左側下付き 1、上付き n を持つ大文字 Y](powerpoint-math-equations_9.png)

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

式を区切り記号で囲むには[enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) を使用します。複数の要素を含む区切り式の場合、区切り文字を設定することもできます。

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

### **区切り記号のサイズと位置合わせ**

[grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) を `True` に設定すると、縦に長いオペランドに合わせて括弧が拡大します。`False` にすると通常サイズのままです。[delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) は[MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/)の2つの値のいずれかを取ります。`CENTERED` は等号の中央を通る数式軸上で括弧を中央揃えにし、`MATCH` は囲んだ内容に合わせて位置合わせします。これらの設定は区切り記号のみが対象で、内部の式は変わりません。

この例では、`x` の指数に分数を配置するため、式はベースラインの上側により遠くまで伸びます。4 つの式すべてが同じ括弧とフォント設定を使用しています。

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

PowerPoint で行を比較すると、拡大の効果が確認できます。上段では、括弧が指数を囲むように拡大し、両シェイプで同じように見えます。下段では拡大が無効になっています。左側の小さい括弧（`CENTERED`）は等号に合わせ、右側（`MATCH`）は式の上に高く位置します。

![PowerPoint で区切り記号の拡大が上で有効、下で無効、左が Centered、右が Match の 4 つの式](delimiter-sizing.png)

## **枠付きボックスの追加**

式自体を枠で囲む必要がある場合は、[to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) を使用します。

![二乗が b の二乗と c の二乗の和に等しいことを示す枠付き式](powerpoint-math-equations_12.png)

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

## **項のグループ化**

式の上または下にグルーピング文字を配置するには、[group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) を使用します。グループ化された項にラベルを付けるには limit を追加します。

![x + y の式が下に任意のテキストラベルとともにグループ化されたもの](powerpoint-math-equations_15.png)

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

書式設定ヘルパーは、数式の可読性が向上する場合にのみ使用してください。例として、[overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) は数式要素の上にバーを付けます。

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

### **既存の式内テキストの書式設定**

既存の式全体のテキストを書式設定するには、各 math block の要素ツリーを走査します。[IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) は直下の子要素だけを返すため、分数、添え字、根号、その他の入れ子構造内のテキストに到達するには再帰的に呼び出します。開始要素が[MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/)の場合も含めるよう、現在の要素とその子要素をチェックします。

この例では、`input.pptx` に `z = xᵢ / ∛y` のような式が含まれていると仮定します。この式は、分子に下付き文字、分母に根号を含む分数です。ブロックのトップレベル要素だけを処理すると、分数内のテキストが見逃されます。例では、スライドのテキストフレーム内の数式部分を見つけ、[MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) を介してブロックにアクセスし、各テキスト要素の[format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/)プロパティを通じて[font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/)を 28 ポイントに設定します。

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

保存されたプレゼンテーションは、処理された各式のすべてのレベルでテキスト書式が更新され、テキスト内容と数式構造は保持されます。

## **クイックリファレンス**

| タスク | メイン API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| 要素の結合 | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| 分数の作成 | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| 上付き・下付きの追加 | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| 関数の追加 | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| 根号の追加 | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| 極限の追加 | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| 左側添え字の追加 | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| 総和と積分の追加 | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| 式配列の追加 | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| 区切り記号の追加 | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| バーと枠の追加 | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| 項のグループ化 | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **よくある質問**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) を含むシェイプを見つけ、その[math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)を取得し、該当段落の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX で保存すると、Aspose.Slides は数式を編集可能な Office Math コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

はい。式の[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)をその[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)から取得し、[MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) を呼び出すことで直接エクスポートできます。完全な例については、[Export Math Equations from Presentations in Python via .NET](/slides/ja/python-net/exporting-math-equations/#export-math-equations-to-latex) を参照してください。