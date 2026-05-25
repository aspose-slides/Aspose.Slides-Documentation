---
title: .NET で PowerPoint プレゼンテーションに数式を追加
linktitle: PowerPoint の数式
type: docs
weight: 80
url: /ja/net/powerpoint-math-equations/
keywords:
- 数式
- 記号
- 数式
- 数式テキスト
- 数式を追加
- 記号を追加
- 数式を追加
- テキストを追加
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint の PPT および PPTX に数式を挿入および編集できます。OMML、書式設定コントロール、わかりやすい C# コードサンプルをサポートしています。"
---
## **概要**

PowerPoint は数式を Office Math Markup Language（OMML）として保存します。Aspose.Slides for .NET を使用すると、分数、根号、関数、リミット、N 進演算子、行列、配列、書式設定された数式ブロックなど、同様の数式コンテンツをプログラムで作成できます。

PowerPoint では、ユーザーは通常 **挿入 > 数式** から数式を追加します：

![PowerPoint の挿入タブで数式コマンドが選択されている状態](powerpoint-math-equations_1.png)

結果はスライド上の編集可能な数式テキストになります：

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides は次の 3 つの主要オブジェクトを通じてその数式テキストを構築します：

- `AddMathShape` で作成される数式シェイプは、数式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathportion/) はシェイプのテキスト フレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathparagraph/) は 1 つまたは複数の [MathBlock](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathblock/) オブジェクトを含みます。

以下のほとんどの例は、[MathematicalText](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathematicaltext/) と [IMathElement](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/) のフルエント メソッドを使用して、コードを短く読みやすく保っています。

MathML エクスポートのシナリオについては、[Export Math Equations from Presentations in .NET](/slides/ja/net/exporting-math-equations/) を参照してください。

## **数式の作成**

この例は数式シェイプを作成し、ピタゴラスの定理を追加します：

![c の二乗が a の二乗プラス b の二乗に等しい数式](powerpoint-math-equations_3.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}}
`AddMathShape` は既に数式段落を含むシェイプを作成します。最初の `MathPortion` にアクセスし、その `MathParagraph` を取得して、数式ブロックまたは数式要素を追加します。
{{% /alert %}}

## **分数を追加**

`Divide` を使用して分数を作成します。分数のスタイルは [MathFractionTypes](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathfractiontypes/) で選択できます。

![1 を x で割った斜めの分数](powerpoint-math-equations_4.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

積み重ねた分数には `MathFractionTypes.Bar` を使用します：

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **根号を追加**

`Radical` を使用して平方根、立方根、その他の根号を作成します。現在の要素が基底になり、引数が次数になります。

![x が根号記号の下にある n 次根の式](powerpoint-math-equations_5.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

## **関数とリミットを追加**

`AsArgumentOfFunction` または `Function` を使用して `sin(x)`、`log(x)`、またはカスタム関数名などの関数を作成します。リミットの場合は [MathLimit](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathlimit/) に `lim` を入れるか、`SetLowerLimit` を使用します。

![x が無限大に近づくリミット](powerpoint-math-equations_8.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

カスタム関数名を使用する場合は、関数名を現在の要素にします：

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N 進演算子と積分を追加**

`Nary` を使用して総和、合併、交差などの大きな演算子を作成します。`Integral` を使用して積分を作成します。両方のメソッドで下限と上限を設定できます。

![下限と上限が付いた総和記号](powerpoint-math-equations_7.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

N 進演算子はオプションのリミットを持つ大きな演算子用です。`+`、`-`、`=` などの単純な演算子は通常 `MathematicalText` として追加し、式に結合します。

積分の場合は `Integral` を使用します：

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **行列を追加**

行と列には [MathMatrix](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathmatrix/) を使用します。行列はデフォルトで括弧を含まないため、必要に応じて丸括弧、角括弧、波括弧で囲んでください。

![空のセルが 1 つある 2 行の行列](powerpoint-math-equations_10.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

## **数式配列を追加**

`ToMathArray` は整列された数式や縦方向にスタックされた式が必要なときに使用します。

![x の上に y がある縦方向の数式配列](powerpoint-math-equations_11.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

## **三角関数を追加**

引数が現在の要素で関数名が分かっている場合は `AsArgumentOfFunction` を使用します。

![cos が 2x に適用された三角関数](powerpoint-math-equations_6.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **下付文字と上付文字を追加**

インデックスや指数には下付文字・上付文字ヘルパーを使用します。インデックスを基底の左側に表示する必要がある場合は `SetSubSuperscriptOnTheLeft` を使用します。

![左側に下付文字 1 と上付文字 n を持つ大文字 Y](powerpoint-math-equations_9.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **区切り文字を追加**

`Enclose` を使用して式を区切り文字で囲みます。複数要素を含む区切り文字式には区切り文字を設定することもできます。

![x、y、z が縦棒で区切られた区切り文字式](powerpoint-math-equations_13.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

## **枠付きボックスを追加**

式自体を枠で囲む場合は `ToBorderBox` を使用します。

![a の二乗が b の二乗プラス c の二乗に等しい枠付き数式](powerpoint-math-equations_12.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **項をグループ化**

`Group` を使用して式の上または下にグループ化文字を配置します。ラベル付きのリミットを追加してグループ化された項を示すことができます。

![x と y が「任意のテキスト」ラベルで下にグループ化された式](powerpoint-math-equations_15.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **数式要素の書式設定**

書式設定ヘルパーは式の意味が明確になる場合にのみ使用します。たとえば `Overbar` は数式要素の上にバーを配置します。

![上にバーが付いた数式 ABC](powerpoint-math-equations_14.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

## **クイックリファレンス**

| タスク | 主な API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathematicaltext/) |
| 要素の結合 | [IMathElement.Join](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/join/) |
| 分数の作成 | [IMathElement.Divide](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/divide/) |
| 上付文字または下付文字の追加 | [SetSuperscript](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| 関数の追加 | [Function](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| 根号の追加 | [IMathElement.Radical](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/radical/) |
| リミットの追加 | [SetLowerLimit](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| 左側スクリプトの追加 | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| 総和と積分の追加 | [Nary](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/integral/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathmatrix/) |
| 数式配列の追加 | [ToMathArray](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| 区切り文字の追加 | [Enclose](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/enclose/) |
| バーと枠の追加 | [Overbar](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| 項のグループ化 | [Group](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、`MathPortion` を含むシェイプを見つけ、その `MathParagraph` を取得して、その段落内の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX に保存すると、Aspose.Slides は数式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

Aspose.Slides は数式を MathML にエクスポートします。LaTeX が必要な場合は、まず MathML にエクスポートし、その後対象の LaTeX 方言をサポートするツールで MathML を変換してください。