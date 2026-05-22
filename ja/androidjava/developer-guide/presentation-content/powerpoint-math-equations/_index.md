---
title: Android で PowerPoint プレゼンテーションに数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、PowerPoint の PPT および PPTX に数式を挿入および編集できます。OMML のサポート、書式設定コントロール、そして分かりやすい Java コードサンプルが含まれます。"
---
## **概要**

PowerPoint は数式を Office Math Markup Language (OMML) で保存します。Aspose.Slides for Android via Java を使用すると、プログラムで同様の数式コンテンツ（分数、根号、関数、極限、N 進演算子、行列、配列、書式設定された数式ブロック）を作成できます。

PowerPoint では、ユーザーは通常、**挿入 > 数式** から数式を追加します:

![PowerPoint の[挿入]タブで[数式]コマンドが選択されている状態](powerpoint-math-equations_1.png)

結果はスライド上の編集可能な数式テキストです:

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides はこの数式テキストを 3 つの主要オブジェクトで構築します:

- 数式シェイプは、[addMathShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/) で作成され、数式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathportion/) はシェイプのテキストフレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathparagraph/) は 1 つ以上の [MathBlock](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathblock/) オブジェクトを含みます。

以下のほとんどの例は [MathematicalText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathematicaltext/) と [IMathElement](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) のフルエント メソッドを使用して、コードを簡潔かつ読みやすくしています。

MathML エクスポートのシナリオについては、[Export Math Equations from Presentations on Android](/slides/ja/androidjava/exporting-math-equations/) を参照してください。

## **数式の作成**

この例は数式シェイプを作成し、ピタゴラスの定理を追加します:

![c の二乗が a の二乗 + b の二乗に等しい数式](powerpoint-math-equations_3.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` は、すでに数式段落を含むシェイプを作成します。最初の `MathPortion` にアクセスし、`MathParagraph` を取得して、数式ブロックまたは数式要素を追加します。
{{% /alert %}}

## **分数の追加**

`divide` を使用して分数を作成します。分数のスタイルは [MathFractionTypes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathfractiontypes/) で選択できます。

![1 ÷ x の斜め分数](powerpoint-math-equations_4.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

積み上げ分数の場合は `MathFractionTypes.Bar` を使用します:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **根号の追加**

`sqrt` を使用して平方根、立方根、またはその他の根号を作成します。現在の要素が底になり、引数が指数になります。

![x が根号記号の下にある n 乗根の式](powerpoint-math-equations_5.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **関数と極限の追加**

`asArgumentOfFunction` または `function` を使用して `sin(x)`、`log(x)` などの関数やカスタム関数名を作成します。極限の場合は、[MathLimit](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathlimit/) に `lim` を入れるか、`setLowerLimit` を使用します。

![x が無限大に近づくときの lim](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

カスタム関数名を使用する場合は、関数名を現在の要素として設定します:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N 進演算子と積分の追加**

`summation`、`union`、`intersection` などの大きな演算子には `nary` を使用します。積分には `integral` を使用します。どちらのメソッドも上下限を設定できます。

![上下限付きの総和](powerpoint-math-equations_7.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N 進演算子はオプションの上下限を持つ大きな演算子用です。`+`、`-`、`=` などの単純な演算子は通常 `MathematicalText` として追加し、式に結合します。

積分の場合は `integral` を使用します:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **行列の追加**

行と列には [MathMatrix](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathmatrix/) を使用します。行列はデフォルトで括弧を含まないため、必要に応じて丸括弧、角括弧、波括弧で囲んでください。

![1 つの空セルを含む 2 行の数式行列](powerpoint-math-equations_10.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **数式配列の追加**

整列された数式や縦に積み重ねた式が必要なときは `toMathArray` を使用します。

![x が y の上にある縦方向の数式配列](powerpoint-math-equations_11.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **三角関数の追加**

引数が現在の要素で関数名が既知の場合は `asArgumentOfFunction` を使用します。

![2x に cos を適用した三角関数](powerpoint-math-equations_6.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **下付き文字と上付き文字の追加**

インデックスや指数には下付き・上付きヘルパーを使用します。インデックスを基底の左側に表示する必要がある場合は `setSubSuperscriptOnTheLeft` を使用します。

![左側に下付き 1、上付き n が付いた大文字 Y](powerpoint-math-equations_9.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **デリミタの追加**

`enclose` を使用して式をデリミタで囲みます。複数要素を含むデリミタ式では区切り文字も設定できます。

![x、y、z を縦棒で区切ったデリミタ式](powerpoint-math-equations_13.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **枠付きボックスの追加**

式全体を枠で囲む必要がある場合は `toBorderBox` を使用します。

![a² = b² + c² を示す枠付き数式](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **項のグループ化**

`group` を使用して式の上または下にグルーピング文字を配置します。ラベル付けのためにリミットを追加できます。

![x + y の式を下に任意のテキストラベルでグループ化したもの](powerpoint-math-equations_15.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **数式要素の書式設定**

書式設定ヘルパーは式の明確化が必要な場合にのみ使用します。例として、`overbar` は数式要素の上にバーを配置します。

![上にバーが付いた ABC の数式](powerpoint-math-equations_14.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **クイックリファレンス**

| タスク | 主な API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathematicaltext/) |
| 要素の結合 | [IMathElement.join](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) |
| 分数の作成 | [IMathElement.divide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) |
| 上付きまたは下付きの追加 | [setSuperscript](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) |
| 関数の追加 | [function](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) |
| 根号の追加 | [IMathElement.radical](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) |
| 極限の追加 | [setLowerLimit](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) |
| 左側スクリプトの追加 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) |
| 総和と積分の追加 | [nary](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathmatrix/) |
| 数式配列の追加 | [toMathArray](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) |
| デリミタの追加 | [enclose](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) |
| バーと枠の追加 | [overbar](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) |
| 項のグループ化 | [group](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathelement/) |

## **よくある質問**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、`MathPortion` を含むシェイプを見つけ、`MathParagraph` を取得し、その段落内の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX 形式で保存すると、Aspose.Slides は数式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

Aspose.Slides は数式を MathML にエクスポートします。LaTeX が必要な場合は、まず MathML にエクスポートし、対象の LaTeX 方言をサポートするツールで MathML を変換してください。