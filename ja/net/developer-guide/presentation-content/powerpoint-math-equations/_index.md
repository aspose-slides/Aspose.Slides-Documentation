---
title: .NET で PowerPoint プレゼンテーションに数式を追加する
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/net/powerpoint-math-equations/
keywords:
- 数式
- 数学記号
- 数学式
- 数式テキスト
- 数式を追加
- 記号を追加
- 式を追加
- テキストを追加
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint の PPT および PPTX に数式を挿入・編集でき、OMML、書式設定コントロール、そして分かりやすい C# コードサンプルをサポートします。"
---
## **概要**

PowerPoint は数式を Office Math Markup Language (OMML) として保存します。Aspose.Slides for .NET を使用すると、分数、根号、関数、極限、N 項演算子、行列、配列、書式設定された数式ブロックなど、同様の数式コンテンツをプログラムで作成できます。

PowerPoint では通常、**挿入 > 数式** から数式を追加します。

![PowerPoint の挿入タブで「数式」コマンドが選択された状態](powerpoint-math-equations_1.png)

結果はスライド上の編集可能な数式テキストになります。

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides は次の 3 つの主要オブジェクトを使って数式テキストを構築します。

- Math シェイプは、[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) で作成され、数式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) はシェイプのテキストフレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) は 1 つ以上の [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) オブジェクトを含みます。

以下の例は主に [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) と、コードを簡潔かつ可読に保つための [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) のフルエントメソッドを使用しています。

MathML エクスポートシナリオについては、[Export Math Equations from Presentations in .NET](/slides/ja/net/exporting-math-equations/) を参照してください。

## **数式の作成**

この例では [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) を使用して数式シェイプを作成し、ピタゴラスの定理を追加します。

![c² = a² + b² の数式](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

{{% alert color="info" title="注意" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) は、すでに数式段落を含むシェイプを作成します。最初の [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) にアクセスし、その [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) を取得して、数式ブロックや数式要素を追加します。
{{% /alert %}}

### **数式ブロックの結合**

数式の一部が [IMathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/) オブジェクトとして個別に構築されている場合、[JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) を使用して結合します。この例では左ブロックに `c² =`、右ブロックに `a² + b²` を構築し、[SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/) で 3 つすべての指数を編集可能な上付き文字にします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddMathShape(20, 20, 600, 100);
var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var leftBlock = new MathBlock();
leftBlock.Add(new MathematicalText("c").SetSuperscript("2"));
leftBlock.Add(new MathematicalText("="));

var rightBlock = new MathBlock();
rightBlock.Add(new MathematicalText("a").SetSuperscript("2"));
rightBlock.Add(new MathematicalText("+"));
rightBlock.Add(new MathematicalText("b").SetSuperscript("2"));

var combinedBlock = leftBlock.JoinBlock(rightBlock);
mathParagraph.Add(combinedBlock);

presentation.Save("equation.pptx", SaveFormat.Pptx);
```

[JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) は `leftBlock` 自身を返し、現在は両方の部分を順序どおりに含んでいます。一方 `rightBlock` は空になります。結合されたブロックは [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) に一度だけ追加します。`equation.pptx` を再度開くと、段落は `c² = a² + b²` を表す 1 つのブロックとなり、3 つの指数はすべて数式上付き文字として保持されています。

`leftBlock.Add(rightBlock)` のように [Add](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelementcollection/add/) を呼び出すと、ブロックを直接別のブロック内にネストしようとして `InvalidOperationException` がスローされます。

## **分数の追加**

[Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) を使用して分数を作成します。分数のスタイルは [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) で選択できます。

![x で除算された分数を斜めに表示した例](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

スタック表示の分数の場合は、[MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) を使用します。

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **根号の追加**

[Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) を使用して平方根、立方根、その他の根号を作成します。現在の要素が基底となり、引数が次数になります。

![x が根号記号の下にある n 次根の例](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

### **平方根の次数の表示/非表示**

平方根は明示的に 2 を表示するか、従来の √x 記法を使用するか選択できます。[IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) の [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) プロパティで形式を制御します。どちらの場合でも次数 2 と被根 x は編集可能な数式内に保持されます。

![左側が HideDegree=false、右側が true の同一平方根](square-root-degree.png)

この例では同じ平方根を 2 回保存します。`visible-degree.pptx` では 2 が表示され、`hidden-degree.pptx` では非表示になります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var radical = new MathematicalText("x").Radical("2");

var shape = slide.Shapes.AddMathShape(20, 20, 200, 100);
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
portion.MathParagraph.Add(new MathBlock(radical));

radical.HideDegree = false;
presentation.Save("visible-degree.pptx", SaveFormat.Pptx);

radical.HideDegree = true;
presentation.Save("hidden-degree.pptx", SaveFormat.Pptx);
```

## **関数と極限の追加**

[AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) または [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) を使用して `sin(x)`、`log(x)` などの関数やカスタム関数名を作成します。極限の場合は [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) に `lim` を入れるか、[SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/) を使用します。

![x が無限大に近づく極限の例](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

カスタム関数名を使用する場合、関数名を現在の要素に設定し、引数で [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) を呼び出します。

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N 項演算子と積分の追加**

[Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) を使用して総和、和集合、積集合などの大きな演算子を作成します。[Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) を使用して積分記号を作成し、下限と上限を設定できます。

![下限と上限がある総和の例](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

N 項演算子はオプションで下限・上限を持つ大きな演算子向けです。`+`、`-`、`=` などの単純演算子は通常 [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) で追加し、式に結合します。

積分の場合は [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) を使用します。

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **行列の追加**

[MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) を使用して行と列を定義します。デフォルトでは括弧は含まれないため、必要に応じて丸括弧、角括弧、波括弧で囲んでください。

![空白セルを含む 2 行の数式行列](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

### **既存の行列を編集する**

たとえば `matrix.pptx` に係数行列が保存されているとします。次の演習では最初の式を保持し、2 つ目の式を新しい 2 式に置き換え、変数のセットを更新します。既存の行列は [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) で開き、まだ有効な係数を保持します。

![1 行目が 1, x, 空白セル、2 行目が x, 2, y の元の 2 行係数行列](matrix-before-edit.png)

行と列のインデックスは 0 から始まり、呼び出しごとに現在の行列状態を指します。インデックス 1 の前に行を挿入すると、元の 2 行目がインデックス 2 に移動します。インデックス 2 の後に挿入すると行が追加されます。インデックス 2 の行を削除すると元の 2 行目が除かれ、追加された行が上にシフトします。列も同様にシフトします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("matrix.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
var matrix = (IMathMatrix)portion.MathParagraph[0][0];

matrix.InsertRowBefore(1);
matrix.InsertRowAfter(2);
matrix.DeleteRow(2);

matrix.InsertColumnBefore(1);
matrix.InsertColumnAfter(3);
matrix.DeleteColumn(3);

// 新しいセルは最初は null です。最初に非ゼロ係数を設定してください。
matrix[1, 0] = new MathematicalText("12");
matrix[1, 1] = new MathematicalText("1");
matrix[2, 2] = new MathematicalText("10");
matrix[2, 3] = new MathematicalText("1");
for (var row = 0; row < matrix.RowCount; row++)
{
    for (var column = 0; column < matrix.ColumnCount; column++)
    {
        matrix[row, column] ??= new MathematicalText("0");
    }
}

matrix.SetColumnAlignment(0, MathHorizontalAlignment.Left);
matrix.SetColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

presentation.Save("updated-matrix.pptx", SaveFormat.Pptx);
```

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) は最左列を左揃えにし、[SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) はインデックス 1 から開始する 3 つの連続列を右揃えにします。`updated-matrix.pptx` では行列に 3 つの式と 4 つの変数があり、元の 1 行目係数 `1` と `x` が 1 列目と 3 列目に表示されます。

![更新後の 3 行行列、行は 1, 0, x, 0; 12, 1, 0, 0; 0, 0, 10, 1 の順](matrix-after-edit.png)

## **式配列の追加**

整列された式や縦方向に積み重ねた式が必要なときは [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) を使用します。

![x が y の上にある縦方向の数式配列](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

### **周囲要素と配列を揃える**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) は配列の垂直揃え位置を隣接する数式要素に対して制御します。この例では 1 行目、配列の中心、最終行の 3 つの揃え方を比較します。

以下の例は同一の配列を 3 つ作成し、各配列に隣接要素 `A=` と `=B` を配置します。すべての数式テキストは Cambria Math の 24pt で、配列の揃え方だけが異なります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(780, 200, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var alignments = new[] { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };

for (int i = 0; i < alignments.Length; i++)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = alignments[i].ToString();
    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 16;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var mathShape = slide.Shapes.AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    var mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Justification = MathJustification.LeftJustified;

    var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
    var equationArray = new MathArray(rows);
    equationArray.BaseJustification = alignments[i];
    var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
    mathParagraph.Add(equation);
}

presentation.Save("equation-array-alignment.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

以下の比較画像は PowerPoint で保存されたプレゼンテーションを示しています。各配列の横にある `A=` と `=B` の位置に注目してください。

![上部、中央、下部揃えの 3 つの式配列と同一の隣接要素](equation-array-alignment.png)

### **行間隔の設定**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) は配列内行の間隔規則を選択します。[RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) は数値による明示的な間隔を指定し、プリセット規則が無視されます。

正確な間隔はポイントで測定されます。比例間隔は半行単位で測定され、例の `3` は 1.5 行に相当します。明示的な値を指定する場合は両方のプロパティを設定してください。数値だけを変更しても間隔規則は選択されません。

以下の例は同一の式、揃え、フォント設定で 5 つのプレゼンテーションを保存します。最初の 3 つはプリセット、残りの 2 つは明示的な数値を使用しています。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

var settings = new (MathRowSpacingRule Rule, uint Spacing)[]
{
    (MathRowSpacingRule.SingleLineGap, 0),
    (MathRowSpacingRule.OneAndAHalfLineGap, 0),
    (MathRowSpacingRule.TwoLineGap, 0),
    (MathRowSpacingRule.Exactly, 20),
    (MathRowSpacingRule.Multiple, 3)
};

foreach (var setting in settings)
{
    var fileName = $"equation-array-{setting.Rule}.pptx";
    using (var presentation = new Presentation())
    {
        var mathShape = presentation.Slides[0].Shapes.AddMathShape(20, 20, 600, 300);
        var paragraph = mathShape.TextFrame.Paragraphs[0];
        paragraph.ParagraphFormat.SpaceBefore = 0;
        paragraph.ParagraphFormat.SpaceAfter = 0;
        var mathParagraph = ((IMathPortion)paragraph.Portions[0]).MathParagraph;
        mathParagraph.Justification = MathJustification.LeftJustified;

        var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
        var equationArray = new MathArray(rows);
        equationArray.BaseJustification = MathVerticalAlignment.Center;
        equationArray.RowSpacingRule = setting.Rule;
        equationArray.RowSpacing = setting.Spacing;
        var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
        mathParagraph.Add(equation);

        presentation.Save(fileName, SaveFormat.Pptx);
    }

}

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

配列の行間隔は段落間隔とは別です。[SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) と [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) は配列を含む段落全体の前後に余白を加えるだけで、配列行間には影響しません。同様に、[IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) は数式段落全体の水平位置を決定し、配列の垂直揃え設定を置き換えるものではありません。

## **三角関数の追加**

引数が現在の要素で関数名が分かっている場合は、[AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) を使用します。

![2x に対する cos 関数の例](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **下付文字と上付文字の追加**

インデックスや指数のために下付文字・上付文字ヘルパーを使用します。インデックスが基底の左側に表示される必要がある場合は、[SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) を使用します。

![左側に下付文字 1 と上付文字 n を持つ大文字 Y の例](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **区切り記号の追加**

[Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) を使用して式を区切り記号で囲みます。複数要素を含む区切り式の場合は区切り文字も設定できます。

![x、y、z を縦棒で区切った式の例](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

### **区切り記号のサイズと配置**

[GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) を `true` に設定すると、被演算子が高い場合に括弧が自動で拡大します。`false` の場合は標準サイズのままです。[DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) は [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) の `Centered` または `Match` のいずれかを取ります。`Centered` は数式軸を中心に括弧を配置し、`Match` は内容に合わせて位置を調整します。これらの設定は区切り記号のみに影響し、内部式はそのままです。

この例では分数を `x` の指数に配置し、式がベースラインより上に広がるようにしています。4 つの式すべてで同じ括弧とフォント設定を使用しています。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

void AddExpression(float left, float top, bool grow, MathDelimiterShape shape)
{
    var fraction = new MathematicalText("a + b").Divide("c + d");
    var power = new MathematicalText("x").SetSuperscript(fraction);
    var delimiter = power.Enclose('(', ')');
    delimiter.GrowToMatchOperandHeight = grow;
    delimiter.DelimiterShape = shape;

    var mathShape = slide.Shapes.AddMathShape(left, top, 300, 100);
    var portion = (MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 32;
    var equation = new MathematicalText("y = ").Join(delimiter);
    portion.MathParagraph.Add(equation);
}

AddExpression(20, 20, true, MathDelimiterShape.Centered);
AddExpression(350, 20, true, MathDelimiterShape.Match);
AddExpression(20, 140, false, MathDelimiterShape.Centered);
AddExpression(350, 140, false, MathDelimiterShape.Match);

presentation.Save("delimiter-sizing.pptx", SaveFormat.Pptx);
```

PowerPoint で行を比較すると、上部の行では括弧が指数を囲むように拡大し、下部の行では拡大が無効になっています。左側の `Centered` は等号の位置に合わせ、右側の `Match` は式全体の上部に配置されます。

![上部で括弧が拡大、下部で拡大がオフの 4 つの式。左は Centered、右は Match](delimiter-sizing.png)

## **枠付きボックスの追加**

分数に対して [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) を呼び出すと、式全体を枠で囲むことができます。返される [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) はデフォルトで 4 辺すべてが表示されます。個別に非表示にするには、[HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/)、[HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/)、[HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/)、[HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) を使用します。

この例では同一分数を 6 つスライドに配置し、取り消し線を示すためにすべての辺を非表示にしたうえで、上向き斜線 (↗) 用に [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) または下向き斜線 (↘) 用に [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) を設定します。さらに、[StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) や [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) を組み合わせて、表示する辺を選択できます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(540, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

IMathBorderBox AddFraction(float x, float y, bool hideBorder = false)
{
    var fraction = new MathematicalText("x+1").Divide("y+2");
    var box = fraction.ToBorderBox();
    box.HideTop = box.HideBottom = box.HideLeft = box.HideRight = hideBorder;

    var shape = slide.Shapes.AddMathShape(x, y, 160, 90);
    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 28;
    portion.MathParagraph.Add(new MathBlock(box));
    return box;
}

AddFraction(10, 10);

var partial = AddFraction(190, 10);
partial.HideTop = true;
partial.HideRight = true;

AddFraction(370, 10, hideBorder: true).StrikethroughBottomLeftToTopRight = true;
AddFraction(10, 120, hideBorder: true).StrikethroughTopLeftToBottomRight = true;
AddFraction(190, 120, hideBorder: true).StrikethroughHorizontal = true;
AddFraction(370, 120).StrikethroughVertical = true;

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

![上段：全枠、下段と左側の枠、上向き斜線。下段：下向き斜線、水平線、垂直線と全枠](border-box-fractions.png)

この分数では水平の取り消し線が分数棒と重なります。垂直の取り消し線は分子と分母の両方を横切り、枠は残ります。これらの線は式全体を装飾します。通常の文字取り消しはテキストランの文字に適用されます。PowerPoint でプレゼンテーションを再度開いても、分子と分母は個別に編集可能です。

## **ファントム要素で表示とレイアウトを制御**

式全体を [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) でラップすると、表示とレイアウトへの影響を個別に制御できます。[IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) のプロパティは次のように機能します。

| プロパティ | 効果 |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | `false` にすると式を非表示にします。`true` に戻すまで、寸法はレイアウトに残ります。 |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | 横幅を 0 とみなすことで、隣接要素が近づきます。 |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | 上昇部（ベースライン上の高さ）を 0 とみなします。これにより上部の余白が減少します。 |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | 下降部（ベースライン下の深さ）を 0 とみなします。分数棒や他のコンテンツが下に近づきます。 |

ベースラインは通常の数式文字が配置される基準線です。コンテンツを非表示にしても寸法は残り、寸法を 0 としても式自体は削除されません。元の式は [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) で取得できます。[Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) を `true` に戻せば再表示され、寸法設定はそのまま保持されます。

以下の例は 5 つの横並びバリエーションを作成します：表示される分数、空間を保持したまま非表示の分数、そして 3 つの次元を 0 とした非表示分数。すべて同じ外側式と Cambria Math の 24pt を使用し、式の上位置はグレイガイドで統一しています。外側分数の分子にファントムを入れると、縦レイアウトの変化が分かりやすくなります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(1000, 180, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var labels = new[] { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

var guide = slide.Shapes.AddAutoShape(ShapeType.Line, 10, 60, 980, 0);
guide.LineFormat.FillFormat.FillType = FillType.Solid;
guide.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

for (var i = 0; i < labels.Length; i++)
{
    var left = 10 + i * 200;
    
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = labels[i];

    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 14;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var fraction = new MathFraction(CreateText("a+b"), CreateText("c+d"));
    var phantom = new MathPhantom(fraction);
    phantom.Show = i == 0;
    phantom.ZeroWidth = i == 2;
    phantom.ZeroAsc = i == 3;
    phantom.ZeroDesc = i == 4;

    var numerator = new MathBlock(CreateText("x+")).Join(phantom).Join(CreateText("+y"));
    var equation = new MathFraction(numerator, CreateText("z"));

    var shape = slide.Shapes.AddMathShape(left, 60, 190, 100);
    shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;

    var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Add(new MathBlock(equation));
}

presentation.Save("math-phantom.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

![表示分数、空間を保持した非表示分数、ZeroWidth、ZeroAsc、ZeroDesc が有効な非表示分数の比較](math-phantom.png)

## **項のグループ化**

[Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) を使用して、式の上または下にグループ記号を配置します。ラベルを付けるために下限を設定できます。

![下に「任意のテキスト」ラベルが付いた x + y の式](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

書式設定ヘルパーは式の可読性が向上する場合にのみ使用してください。たとえば、[Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) は要素の上にバーを付けます。

![ABC の上にオーバーバーが付いた式](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

### **既存の式内テキストの書式設定**

既存の式全体のテキストを書式設定するには、各数式ブロックの要素ツリーを走査します。[IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) は直接の子要素のみを返すため、分数や添字、根号などの入れ子構造に再帰的に呼び出す必要があります。開始要素が [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) の場合も含めてチェックします。

この例では、`z = xᵢ / ∛y` のような式がスライドのテキストフレームに含まれていると仮定します。分数の分子に添字があり、分母に根号がある構造です。ブロックのトップレベル要素だけを処理すると、分数内部のテキストが見逃されます。例では数式部分を取得し、[IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) からブロックにアクセスし、各テキスト要素の [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) の [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) を 28pt に設定します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape || autoShape.TextFrame == null)
            continue;

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is IMathPortion mathPortion)
                {
                    foreach (var block in mathPortion.MathParagraph)
                        FormatMathText(block);
                }
            }
        }
    }
}

presentation.Save("formatted-equations.pptx", SaveFormat.Pptx);

void FormatMathText(IMathElement element)
{
    if (element is MathematicalText text)
        text.Format.FontHeight = 28;

    foreach (var child in element.GetChildren())
        FormatMathText(child);
}
```

保存されたプレゼンテーションは、すべての階層でテキスト書式が更新された状態で保持され、式の内容と構造はそのままです。

## **クイックリファレンス**

| タスク | メイン API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| 要素の結合 | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| 分数の作成 | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| 上付き・下付き文字の追加 | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| 関数の追加 | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| 根号の追加 | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| 極限の追加 | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| 左側添字・上付き文字の追加 | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| 総和・積分の追加 | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| 式配列の追加 | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| 区切り記号の追加 | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| 上バー・枠の追加 | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| 項のグループ化 | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**既存の PowerPoint 数式を編集できますか？**

はい。プレゼンテーションを開き、[MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) を含むシェイプを見つけ、その [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) を取得して、段落内の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX に保存すると、Aspose.Slides は数式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

はい。[MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) から取得した [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) の [ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) を呼び出すと直接エクスポートできます。完全な例は [Export Math Equations from Presentations in .NET](/slides/ja/net/exporting-math-equations/#export-math-equations-to-latex) を参照してください。