---
title: JavaScript で PowerPoint プレゼンテーションに数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/nodejs-java/powerpoint-math-equations/
keywords:
- 数式
- 記号
- 式
- 数式テキスト
- 数式を追加
- 記号を追加
- 式を追加
- テキストを追加
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint の PPT および PPTX に数式を挿入・編集できます。OMML 対応、書式設定コントロール、わかりやすい JavaScript コードサンプルをサポートしています。"
---
## **概要**

PowerPoint は数式を Office Math Markup Language (OMML) として保存します。Aspose.Slides for Node.js via Java を使用すると、プログラムで同様の数式コンテンツ（分数、根号、関数、リミット、N 進演算子、行列、配列、書式設定された数式ブロック）を作成できます。

PowerPoint では、ユーザーは通常 **Insert > Equation** から数式を追加します:

![PowerPoint の挿入タブで「数式」コマンドが選択されている状態](powerpoint-math-equations_1.png)

結果はスライド上の編集可能な数式テキストです:

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides は、次の 3 つの主要オブジェクトを使用して数式テキストを構築します。

- 数式シェイプは、[addMathShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#addMathShape) で作成され、数式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathportion/) はシェイプのテキストフレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathparagraph/) は 1 つ以上の [MathBlock](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathblock/) オブジェクトを含みます。

以下の例のほとんどは、[MathematicalText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathematicaltext/) と、コードを短く読みやすくするために [MathElementBase](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) のフルエントメソッドを使用しています。

MathML エクスポートシナリオについては、[Export Math Equations from Presentations in Node.js via Java](/slides/ja/nodejs-java/exporting-math-equations/) を参照してください。

## **数式の作成**

この例は数式シェイプを作成し、ピタゴラスの定理を追加します:

![c² = a² + b² の数式](powerpoint-math-equations_3.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` は、すでに数式段落を含むシェイプを作成します。最初の `MathPortion` にアクセスし、その `MathParagraph` を取得して、数式ブロックまたは数式要素を追加します。
{{% /alert %}}

## **分数の追加**

[`divide`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用して分数を作成します。分数のスタイルは [MathFractionTypes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathfractiontypes/) で選択できます。

![1 が x で割られた斜めの分数](powerpoint-math-equations_4.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

スタックされた分数の場合は `MathFractionTypes.Bar` を使用します:

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **根号の追加**

[`radical`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用して平方根、立方根、その他の根号を作成します。現在の要素が基底になり、引数が根号の次数になります。

![x が根号記号の下にある n 次根の式](powerpoint-math-equations_5.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **関数とリミットの追加**

[`asArgumentOfFunction`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) または [`function`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用して `sin(x)`、`log(x)` などの関数やカスタム関数名を指定します。リミットの場合は、`lim` を [MathLimit](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathlimit/) に入れるか、[`setLowerLimit`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用します。

![x が無限大に近づくリミット](powerpoint-math-equations_8.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

カスタム関数名を使用する場合は、関数名を現在の要素にします:

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N 進演算子と積分の追加**

[`nary`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用して総和、和集合、積集合などの大きな演算子を作成します。[`integral`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用して積分を作成します。両方のメソッドで下限と上限を設定できます。

![下限と上限付きの総和](powerpoint-math-equations_7.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N 進演算子はオプションのリミットを持つ大きな演算子向けです。`+`、`-`、`=` などの単純演算子は通常 `MathematicalText` として追加し、式に結合します。

積分の場合は `integral` を使用します:

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **行列の追加**

[MathMatrix](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathmatrix/) を使用して行と列を作成します。行列はデフォルトで括弧を含まないため、丸括弧、角括弧、波括弧が必要なときは行列全体を囲んでください。

![空のセルが 1 つある 2 行の行列](powerpoint-math-equations_10.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **数式配列の追加**

整列した数式や縦方向に積み重ねた式が必要なときは、[`toMathArray`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用します。

![x が y の上にある縦方向の数式配列](powerpoint-math-equations_11.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **三角関数の追加**

引数が現在の要素で関数名が決まっている場合は、[`asArgumentOfFunction`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用します。

![cos が 2x に適用された三角関数](powerpoint-math-equations_6.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **下付字と上付字の追加**

インデックスや指数には下付字・上付字ヘルパーを使用します。インデックスを基底の左側に配置する必要がある場合は、[`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用します。

![左側下付字 1 と上付字 n を持つ大文字 Y](powerpoint-math-equations_9.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **区切り記号の追加**

[`enclose`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用して式を区切り記号で囲みます。複数要素を含む区切り式では、区切り文字を設定することもできます。

![x、y、z が縦棒で区切られた区切り式](powerpoint-math-equations_13.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **枠付きボックスの追加**

数式自体を枠で囲む必要がある場合は、[`toBorderBox`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用します。

![a² = b² + c² を示す枠付き数式](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **項のグループ化**

[`group`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用して、式の上または下にグループ文字を配置します。グループ化された項にラベルを付けるためにリミットを追加できます。

![x + y が下に「任意のテキスト」ラベル付きでグループ化された式](powerpoint-math-equations_15.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **数式要素の書式設定**

書式設定ヘルパーは式を明確にする場合にのみ使用します。例として、[`overbar`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) は数式要素の上にバーを付けます。

![上にバーが付いた数式 ABC](powerpoint-math-equations_14.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **クイックリファレンス**

| タスク | 主な API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathematicaltext/) |
| 要素の結合 | [join](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 分数の作成 | [divide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 上付字または下付字の追加 | [setSuperscript](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 関数の追加 | [function](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 根号の追加 | [radical](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| リミットの追加 | [setLowerLimit](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 左側スクリプトの追加 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 総和と積分の追加 | [nary](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathmatrix/) |
| 数式配列の追加 | [toMathArray](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 区切り記号の追加 | [enclose](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| バーと枠の追加 | [overbar](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 項のグループ化 | [group](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、`MathPortion` を含むシェイプを見つけて、その `MathParagraph` を取得し、段落内の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX として保存すると、Aspose.Slides は数式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

はい。数式の [MathParagraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathparagraph/) を取得し、[MathParagraph.toLatex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathparagraph/#toLatex--) を呼び出すことで直接エクスポートできます。完全な例については、[Export Math Equations from Presentations in Node.js via Java](/slides/ja/nodejs-java/exporting-math-equations/#export-math-equations-to-latex) を参照してください。