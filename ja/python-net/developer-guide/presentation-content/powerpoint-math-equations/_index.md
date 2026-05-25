---
title: Python で PowerPoint プレゼンテーションに数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/python-net/powerpoint-math-equations/
keywords:
- 数式
- 数学記号
- 数学式
- 数式テキスト
- 数式の追加
- 記号の追加
- 式の追加
- テキストの追加
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint の PPT および PPTX に数式を挿入および編集できます。OMML のサポート、書式設定コントロール、分かりやすい Python コード例を提供します。"
---
## **概要**

PowerPointは数式を Office Math Markup Language (OMML) として保存します。Aspose.Slides for Python via .NET を使用すると、同じ種類の数式コンテンツをプログラムで作成できます：分数、根号、関数、リミット、N 進演算子、行列、配列、そして書式設定された数式ブロックです。

PowerPointでは、ユーザーは通常**挿入 > 数式**から数式を追加します：

![PowerPointの[挿入]タブで[数式]コマンドが選択されている状態](powerpoint-math-equations_1.png)

結果としてスライド上に編集可能な数式テキストが表示されます：

![編集可能な数式が含まれるPowerPointのスライド](powerpoint-math-equations_2.png)

Aspose.Slidesはその数式テキストを次の3つの主要オブジェクトで構築します：

- 数式シェイプは、[add_math_shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_math_shape/)で作成され、数式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathportion/) はシェイプのテキストフレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathparagraph/) は1つ以上の [MathBlock](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathblock/) オブジェクトを含みます。

以下のほとんどの例は、[MathematicalText](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathematicaltext/) と [IMathElement](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/) のフルエントメソッドを使用して、コードを簡潔で読みやすくしています。

MathML エクスポートシナリオについては、[Export Math Equations from Presentations in Python via .NET](/slides/ja/python-net/exporting-math-equations/) を参照してください。

## **数式の作成**

この例では、数式シェイプを作成し、ピタゴラスの定理を追加します：

![c^2 = a^2 + b^2 の式](powerpoint-math-equations_3.png)

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
`add_math_shape` は、すでに数式段落を含むシェイプを作成します。最初の `MathPortion` にアクセスし、その `MathParagraph` を取得して、数式ブロックまたは数式要素を追加します。
{{% /alert %}}

## **分数の追加**

[`divide`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/divide/) を使用して分数を作成します。[MathFractionTypes](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathfractiontypes/) で分数のスタイルを選択できます。

![1 を x で除した斜めの分数](powerpoint-math-equations_4.png)

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

スタックされた分数の場合は、`MathFractionTypes.BAR` を使用します：

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **根号の追加**

[`radical`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/radical/) を使用して平方根、立方根、またはその他の根号を作成します。現在の要素が基底となり、引数が次数になります。

![x が根号の下にある n 次根号の式](powerpoint-math-equations_5.png)

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

[`as_argument_of_function`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) または [`function`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/function/) を使用して、`sin(x)`、`log(x)` などの関数やカスタム関数名を指定できます。リミットの場合は、`lim` を [MathLimit](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathlimit/) に入れるか、[`set_lower_limit`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) を使用します。

![x が無限大に近づくときのリミット](powerpoint-math-equations_8.png)

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

カスタム関数名の場合は、関数名を現在の要素にします：

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **N 進演算子と積分の追加**

総和、和集合、積集合、その他の大きな演算子には `[`nary`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/nary/)` を使用します。積分には `[`integral`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/integral/)` を使用します。両方のメソッドで下限と上限を設定できます。

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

N 進演算子は、オプションのリミットを持つ大きな演算子向けです。`+`、`-`、`=` などの単純な演算子は通常 `MathematicalText` として追加され、式に結合されます。

積分を追加するには、`integral` を使用します：

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **行列の追加**

行と列には [MathMatrix](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathmatrix/) を使用します。行列はデフォルトで括弧を含まないため、丸括弧、角括弧、波括弧が必要な場合は行列を囲んでください。

![1つの空セルを含む2行の数式行列](powerpoint-math-equations_10.png)

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

## **方程式配列の追加**

整列した方程式や縦に並んだ式が必要な場合は、`[`to_math_array`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/to_math_array/)` を使用します。

![x が上、y が下にある垂直の数式配列](powerpoint-math-equations_11.png)

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

引数が現在の要素で、関数名が分かっている場合は、`[`as_argument_of_function`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/)` を使用します。

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

## **下付き文字と上付き文字の追加**

添字や指数には下付き・上付きヘルパーを使用します。インデックスを基底の左側に表示する必要がある場合は、`[`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/)` を使用します。

![左側に下付き 1、上付き n を持つ大文字 Y](powerpoint-math-equations_9.png)

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

`[`enclose`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/enclose/)` を使用して式を区切り記号で囲みます。複数の要素を含む区切り式の場合、区切り文字も設定できます。

![x、y、z を縦棒で区切った区切り式](powerpoint-math-equations_13.png)

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

## **枠付きボックスの追加**

式自体を枠で囲む場合は、`[`to_border_box`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/to_border_box/)` を使用します。

![a^2 = b^2 + c^2 を示す枠付きの方程式](powerpoint-math-equations_12.png)

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

式の上または下にグループ化文字を配置するには、`[`group`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/group/)` を使用します。グループ化された項にラベルを付けるためにリミットを追加します。

![式 x + y が下に任意のテキストラベルでグループ化された例](powerpoint-math-equations_15.png)

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

書式ヘルパーは、式を明確にする必要がある場合にのみ使用します。例として、`[`overbar`](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/overbar/)` は数式要素の上にバーを配置します。

![ABC の上にバーが付いた数式](powerpoint-math-equations_14.png)

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

## **クイックリファレンス**

| タスク | 主な API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathematicaltext/) |
| 要素の結合 | [IMathElement.join](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/join/) |
| 分数の作成 | [IMathElement.divide](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/divide/) |
| 上付き文字または下付き文字の追加 | [set_superscript](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| 関数の追加 | [function](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| 根号の追加 | [radical](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/radical/) |
| リミットの追加 | [set_lower_limit](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| 左側スクリプトの追加 | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| 総和および積分の追加 | [nary](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/integral/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathmatrix/) |
| 方程式配列の追加 | [to_math_array](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| 区切り記号の追加 | [enclose](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| バーと枠の追加 | [overbar](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| 項のグループ化 | [group](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/imathelement/group/) |

## **よくある質問**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、`MathPortion` を含むシェイプを見つけ、その `MathParagraph` を取得して、段落内の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX として保存すると、Aspose.Slides は数式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

Aspose.Slides は数式を MathML にエクスポートします。LaTeX が必要な場合は、まず MathML にエクスポートし、対象の LaTeX 方言をサポートするツールで MathML を変換してください。