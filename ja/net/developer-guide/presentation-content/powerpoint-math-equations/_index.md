---
title: .NET で PowerPoint プレゼンテーションに数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/net/powerpoint-math-equations/
keywords:
- 数式
- 記号
- 数式
- 数式テキスト
- 数式の追加
- 記号の追加
- 数式の追加
- テキストの追加
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint PPT および PPTX に数式を挿入および編集し、OMML、書式設定コントロール、明確な C# コードサンプルをサポートします。"
---
## **概要**

PowerPointは方程式をOffice Math Markup Language（OMML）として保存します。Aspose.Slides for .NET を使用すると、プログラムで同様の数式コンテンツ（分数、根号、関数、リミット、N元演算子、行列、配列、書式設定された数式ブロック）を作成できます。

PowerPointでは、ユーザーは通常 **挿入 > 数式** から方程式を追加します：

![PowerPoint の挿入タブで数式コマンドが選択された状態](powerpoint-math-equations_1.png)

結果はスライド上の編集可能な数式テキストです：

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides は、次の 3 つの主要オブジェクトを使用して数式テキストを構築します：

- 数式シェイプは、[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) で作成され、方程式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) は、シェイプのテキストフレーム内に数式コンテンツを保存します。
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) は、1 つ以上の [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) オブジェクトを含みます。

以下のほとんどの例では、[MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) と [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) のフルエントメソッドを使用して、コードを簡潔で読みやすくしています。

MathML エクスポートシナリオについては、[プレゼンテーションから数式をエクスポート (.NET)](/slides/ja/net/exporting-math-equations/) を参照してください。

## **数式の作成**

この例では、[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) を使用して数式シェイプを作成し、ピタゴラスの定理を追加します：

![c² = a² + b² の式](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) は、すでに数式段落を含むシェイプを作成します。最初の [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) にアクセスし、その [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) を取得して、数式ブロックまたは数式要素を追加します。
{{% /alert %}}

### **数式ブロックの結合**

方程式の一部が [IMathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/) オブジェクトとして個別に作成される場合、[JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) を使用して結合します。この例では、左ブロックに `c² =`、右ブロックに `a² + b²` を構築します。[SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/) は、3 つすべての累乗に対して編集可能な数式上付き文字を作成します。

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

[JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) は `leftBlock` 自身を返し、現在は順序通りに両方の部分を含み、`rightBlock` は空になります。結合されたブロックは [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) に一度だけ追加します。`equation.pptx` を再度開くと、段落は `c² = a² + b²` を表す 1 つのブロックを含み、3 つの累乗はすべて数式上付き文字として保持されます。

`leftBlock.Add(rightBlock)` のように [Add](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelementcollection/add/) を呼び出すと、ブロックを直接入れ子にしようとして `InvalidOperationException` がスローされます。

## **分数の追加**

[Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) を使用して分数を作成します。[MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) で分数スタイルを選択できます。

![1 を x で割った斜めの分数](powerpoint-math-equations_4.png)

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

積み重ね型の分数については、[MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) を使用します：

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **根号の追加**

[Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) を使用して平方根、立方根、またはその他の根号を作成します。現在の要素が基底になり、引数が次数になります。

![x が根号記号の下にある n 次根号の式](powerpoint-math-equations_5.png)

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

### **平方根の次数の表示または非表示**

平方根は明示的に 2 を表示するか、従来の √x 記法を使用できます。[IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) の [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) プロパティでどちらの形が表示されるかを制御します。どちらの形でも、編集可能な数式では次数 2 と被根 x が保持されます。

![左側で HideDegree が false、右側で true に設定された同じ平方根](square-root-degree.png)

例では同じ平方根を 2 回保存します。`visible-degree.pptx` では 2 が表示され、`hidden-degree.pptx` では非表示になります。

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

## **関数とリミットの追加**

`sin(x)`、`log(x)` などの関数やカスタム関数名には、[AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) または [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) を使用します。リミットの場合は、[MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) に `lim` を配置するか、[SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/) を使用します。

![x が無限大に近づくときのリミット](powerpoint-math-equations_8.png)

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

カスタム関数名の場合は、関数名を現在の要素にして、その引数で [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) を呼び出します：

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N元演算子と積分の追加**

総和、和集合、交差集合、その他の大きな演算子には [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) を使用します。積分には [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) を使用します。両方のメソッドで下限と上限を設定できます。

![下限と上限を持つ総和記号](powerpoint-math-equations_7.png)

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

N元演算子は、任意の下限・上限を持つ大きな演算子用です。`+`、`-`、`=` のような単純な演算子は通常 [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) で追加し、式に結合します。

積分の場合は、[Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) を使用します：

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **行列の追加**

[MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) を使用して行と列を作成します。行列はデフォルトで括弧を含まないため、丸括弧、角括弧、波括弧が必要な場合は外側に囲んでください。

![空セルが1つある二行の数式行列](powerpoint-math-equations_10.png)

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

### **既存の行列の編集**

線形代数のレッスンが `matrix.pptx` の係数行列で始まるとします（前の例で保存）。次の演習では、最初の方程式を保持し、2 番目を 2 つの新しい方程式に置き換え、変数セットを改訂します。残っている係数を保持するために、[IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) を通して既存の行列を開きます。

![元の二行係数行列：第一行に 1、x、空セル、第二行に x、2、y がある](matrix-before-edit.png)

行と列のインデックスは 0 から始まり、各呼び出し時点の行列を指します。インデックス 1 の前に行を挿入すると、元の第 2 行がインデックス 2 に移動します。インデックス 2 の後に挿入すると行が追加されます。インデックス 2 の行を削除すると、元の第 2 方程式が削除され、追加された行が 1 つ上に移動します。列も同様にシフトします。

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) は最初の列を左揃えにし、[SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) はインデックス 1 から開始する 3 つの連続列を右揃えにします。`updated-matrix.pptx` では、行列は 3 つの方程式と 4 つの変数を持ち、元の第 1 行の係数 `1` と `x` が現在は第 1 列と第 3 列に現れます。

![更新された三行行列：行は 1, 0, x, 0; 12, 1, 0, 0; 0, 0, 10, 1](matrix-after-edit.png)

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

// 新しいセルは最初は null です。非ゼロ係数を最初に設定します。
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

## **方程式配列の追加**

整列された方程式や縦にスタックした式が必要な場合は、[ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) を使用します。

![x が上、y が下にある垂直の数式配列](powerpoint-math-equations_11.png)

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

### **配列を周囲の要素と揃える**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) は、配列の垂直位置を隣接する数式要素に対して制御します。以下の例は、最上行、配列中央、最下行での揃えを比較します。

次の例は、3 行で構成された同一の配列を 3 つ作成し、隣接要素 `A=` と `=B` を付けています。すべての数式テキストは Cambria Math の 24 ポイントです。配列の揃えだけが変わります。

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

以下の比較は、PowerPoint で保存されたプレゼンテーションを示します。各配列の隣にある `A=` と `=B` の位置に注意してください。

![PowerPoint の方程式配列（上揃え、中央揃え、下揃え）と同一の隣接要素](equation-array-alignment.png)

### **行間隔の設定**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) は、配列内の行に対する間隔ルールを選択します。[RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) は明示的な間隔ルール用の数値を提供し、プリセットルールでは無視されます。

正確な間隔はポイントで測定されます。比例間隔は半行で測定され、例の値 `3` は 1.5 行を表します。明示的な値を指定する場合は両方のプロパティを設定してください；数値だけを変更しても間隔ルールは選択されません。

以下の例は、同一の方程式、揃え、フォント設定で 5 つのプレゼンテーションを保存します。最初の 3 つはプリセット、残りの 2 つは明示的な値を示します。

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

配列の行間隔は段落間隔とは別です。[SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) と [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) は、配列行間ではなく、含む段落の前後にスペースを追加します。同様に、[IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) は数式段落全体の水平位置を決め、配列の垂直揃え設定を置き換えるものではありません。

## **三角関数の追加**

引数が現在の要素で関数名が既知の場合は、[AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) を使用します。

![2x に適用された三角関数 cos](powerpoint-math-equations_6.png)

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

## **添字と上付き文字の追加**

インデックスや指数には添字・上付き文字ヘルパーを使用します。インデックスを基底の左側に表示する必要がある場合は、[SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) を使用します。

![左側に添字 1、上付き n を持つ大文字 Y](powerpoint-math-equations_9.png)

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

### **右側の添字と上付き文字を揃える**

同一の基底に対して両方のスクリプトが属する場合は、[MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement/) を使用します。その [AlignScripts](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathrightsubsuperscriptelement/alignscripts/) プロパティは水平位置を制御し、`false`（デフォルト）では基底の輪郭に従い、`true` ではスクリプト同士を水平に揃えます。

この例は、同一の編集可能式を 2 つ横に並べます。どちらも数式イタリック f（U+1D453）、下添字 1、上添字 2、そして 72 ポイントの Cambria Math を使用しています。傾斜した基底により、PowerPoint で差が視覚的に確認できます。実行前に Cambria Math をインストールしてください。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(900, 250, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var format = new PortionFormat
{
    FontHeight = 72,
    LatinFont = new FontData("Cambria Math")
};

for (var i = 0; i < 2; i++)
{
    var left = 40 + i * 440;
    var shape = slide.Shapes.AddMathShape(left, 75, 380, 150);

    var baseText = new MathematicalText("\U0001D453", format);
    var subscript = new MathematicalText("1", format);
    var superscript = new MathematicalText("2", format);
    var scripts = new MathRightSubSuperscriptElement(baseText, subscript, superscript);
    scripts.AlignScripts = i == 1;

    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = format.FontHeight;
    portion.PortionFormat.LatinFont = format.LatinFont;
    portion.MathParagraph.Add(new MathBlock(scripts));
}

presentation.Save("aligned-scripts.pptx", SaveFormat.Pptx);
```

![左側で AlignScripts が false、右側で true に設定された、PowerPoint の2つの編集可能な式](aligned-scripts.png)

左側では、下添字が上添字より左に開始し、基底の輪郭に従います。右側では、2 つのスクリプトが水平に揃っています。

## **デリミタの追加**

[Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) を使用して式をデリミタで囲みます。複数要素を含むデリミタ式の場合は、区切り文字も設定できます。

![x、y、z が縦棒で区切られたデリミタ式](powerpoint-math-equations_13.png)

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

### **デリミタのサイズと位置合わせ**

[GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) を `true` に設定すると、縦に長いオペランドに合わせて括弧が伸縮し、`false` にすると通常サイズのままです。[DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) は 2 つの [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) 値のいずれかを取ります。`Centered` は括弧を数式軸（等号の中央）に中心合わせ、`Match` は括弧を囲む内容に合わせます。両設定はデリミタのみ影響し、内部式は変更されません。

例では、`x` の指数に分数を置き、式がベースライン上部により高く伸びるようにしています。4 つの方程式はすべて同一の括弧とフォント設定を使用します。

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

PowerPoint で行を比較すると、拡大の効果が確認できます。上段では、括弧が指数を囲むように伸び、両形状で同様に見えます。下段では拡大がオフになり、左側の小さな括弧（`Centered`）は等号に合わせ、右側（`Match`）は式の上部に高く配置されます。

![PowerPoint の4つの方程式：上段はデリミタの拡大が有効、下段は無効、左側は Centered、右側は Match](delimiter-sizing.png)

## **枠ボックスの追加**

分数に対して [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) を呼び出すと、式全体を枠で囲むことができます。返される [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) はデフォルトで 4 辺すべてを表示します。個別の辺を除去するには、[HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/)、[HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/)、[HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/)、[HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) を使用します。

例では、同一の分数を 1 スライドに 6 個配置します。取り消し線を示すために 4 辺すべてを非表示にし、上向き対角線（↗）には [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) を、下向き対角線（↘）には [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) を設定します。また、[StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) や [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) を任意の可視辺の組み合わせで使用できます。

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

![PowerPoint の6つの編集可能な分数。上段：全枠、下と左側、上向きの対角線。下段：下向きの対角線、水平ストライク、垂直ストライクと全枠](border-box-fractions.png)

この分数では、水平ストライクが分数線と重なります。垂直ストライクは分子と分母の両方を横切り、周囲の枠は表示されたままです。これらの線は式全体を装飾します。通常のテキスト取り消し線はテキストランの文字に適用されます。PowerPoint でプレゼンテーションを再度開くと、分子と分母は依然として個別に編集可能です。

## **Phantom 要素による表示とレイアウトの制御**

式を [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) で包むと、その表示と式が方程式に与える空間を個別に制御できます。[IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) のプロパティは以下を制御します：

| プロパティ | 効果 |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | `false` に設定すると式が非表示になります。対応するプロパティが `true` でない限り、サイズはレイアウトに影響します。 |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | 式の横幅を 0 とみなし、隣接要素をより近づけます。 |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | ベースライン上部の上昇部（高さ）を 0 とみなします。これにより、隣接要素上部の余白が減ります。 |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | ベースライン下部の下降部（深さ）を 0 とみなします。これにより、式下の分数バーや他のコンテンツが隣接要素に近づきます。 |

ベースラインは通常の数式文字が配置される基準線です。コンテンツを非表示にしてもサイズは残り、サイズを 0 と扱っても式は削除されません。基礎式は [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) から取得可能です。[Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) を `true` に戻すと再表示され、サイズ設定はそのままです。

以下の例は、並列に 5 つのバリエーションを作成します：表示される分数、スペースを確保したまま非表示の分数、そして 1 つの次元を 0 とした 3 つの非表示分数です。各バリエーションは同一の周囲式と 24 ポイントの Cambria Math を使用します。すべての数式シェイプは同一の上位置にあり、灰色のガイドで示されています。外側の分数の分子に phantom を配置すると、垂直レイアウトの変化が見やすくなります。

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

![PowerPoint の5つの方程式：表示分数、スペースを確保した非表示分数、ZeroWidth、ZeroAsc、ZeroDesc が有効な非表示分数を比較](math-phantom.png)

## **項のグループ化**

[Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) を使用して、式の上または下にグループ文字を配置します。グループ化された項にラベルを付けるにはリミットを追加します。

![式 x + y がグループ化され、下に任意のテキストがラベルとして付いている](powerpoint-math-equations_15.png)

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

式を明確にする場合にのみ、書式設定ヘルパーを使用してください。例として、[Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) は数式要素の上にバーを配置します。

![上線が付いた数式 ABC](powerpoint-math-equations_14.png)

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

### **既存の数式内のテキストの書式設定**

既存の数式全体のテキストを書式設定するには、各数式ブロックの要素ツリーを走査します。[IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) は直下の子要素のみを返すため、再帰的に呼び出して分数、スクリプト、根号、その他の入れ子構造内のテキストに到達します。開始要素が [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) の場合も含めるよう、現在の要素と子要素の両方を確認してください。

この例は、`z = xᵢ / ∛y` のような方程式がプレゼンテーションに含まれていることを想定しています。分子に添字、分母に根号を持つ分数が含まれます。ブロックの最上位要素だけを処理すると、分数内部のテキストが見落とされます。例では、スライドのテキストフレーム内の数式部分を検索し、[IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) を介してブロックにアクセスし、各テキスト要素の [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) プロパティで [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) を 28 ポイントに設定します。

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

保存されたプレゼンテーションは、処理された各方程式のすべてのレベルで更新されたテキスト書式を保持し、テキスト内容と数式構造はそのままです。

## **クイックリファレンス**

| タスク | 主要 API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| 要素の結合 | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| 分数の作成 | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| 上付き文字または下付き文字の追加 | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| 関数の追加 | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| 根号の追加 | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| リミットの追加 | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| 左側スクリプトの追加 | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| 総和と積分の追加 | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| 方程式配列の追加 | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| デリミタの追加 | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| バーと枠の追加 | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| 項のグループ化 | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、[MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) を含むシェイプを見つけ、その [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) を取得し、段落内の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX に保存すると、Aspose.Slides は方程式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

はい。式の [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) をその [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) から取得し、[IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) を呼び出すと直接エクスポートできます。完全な例については、[プレゼンテーションから数式をエクスポート (.NET)](/slides/ja/net/exporting-math-equations/#export-math-equations-to-latex) を参照してください。