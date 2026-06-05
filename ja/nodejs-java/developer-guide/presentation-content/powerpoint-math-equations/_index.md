---
title: JavaScript で PowerPoint プレゼンテーションに数式を追加する
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint の PPT および PPTX に数式を挿入および編集できます。OMML のサポート、書式設定コントロール、分かりやすい JavaScript コードサンプルを提供します。"
---
## **概要**

PowerPoint は数式を Office Math Markup Language (OMML) として保存します。Aspose.Slides for Node.js via Java を使用すると、分数・根号・関数・リミット・N 項演算子・行列・配列・書式設定された数式ブロックなど、同様の数式コンテンツをプログラムで作成できます。

PowerPoint では通常、**挿入 > 数式** から数式を追加します。

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

結果はスライド上で編集可能な数式テキストになります。

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides は次の 3 つの主要オブジェクトを通じて数式テキストを構築します。

- `addMathShape` で作成される数式シェイプは、数式を含むシェイプです。詳細は[addMathShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#addMathShape)をご覧ください。
- [MathPortion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathportion/) はシェイプのテキストフレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathparagraph/) は 1 つ以上の [MathBlock](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathblock/) オブジェクトを保持します。

以下のほとんどの例は [MathematicalText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathematicaltext/) と、コードを簡潔に保つための [MathElementBase](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) のフルエントメソッドを使用しています。

MathML エクスポートのシナリオについては、[Export Math Equations from Presentations in Node.js via Java](/slides/ja/nodejs-java/exporting-math-equations/) を参照してください。

## **数式の作成**

この例では数式シェイプを作成し、ピタゴラスの定理を追加します。

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

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
`addMathShape` はすでに数式段落を含むシェイプを作成します。最初の `MathPortion` にアクセスし、その `MathParagraph` を取得して、数式ブロックや数式要素を追加してください。
{{% /alert %}}

## **分数の追加**

[`divide`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用して分数を作成します。分数のスタイルは [MathFractionTypes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathfractiontypes/) で選択できます。

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

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

スタックされた分数を作成するには、`MathFractionTypes.Bar` を使用します。

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **根号の追加**

[`radical`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用して平方根、立方根、その他の根号を作成します。現在の要素が基数となり、引数が指数（根の次数）になります。

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

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

関数（例: `sin(x)`、`log(x)`、またはカスタム関数名）には [`asArgumentOfFunction`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) または [`function`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用します。リミットは [MathLimit](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathlimit/) に `lim` を入れるか、[`setLowerLimit`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用してください。

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

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

カスタム関数名を使用する場合は、関数名を現在の要素として設定します。

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N 項演算子と積分の追加**

和、合併、交差などの大きな演算子には [`nary`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を、積分には [`integral`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用します。両メソッドとも下限と上限を設定できます。

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

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

N 項演算子はオプションで上下限を持つ大きな演算子です。`+`、`-`、`=` などの単純演算子は通常 `MathematicalText` として追加し、式に結合します。

積分を追加するには `integral` を使用します。

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **行列の追加**

行と列を扱うには [MathMatrix](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathmatrix/) を使用します。行列はデフォルトで括弧を含まないため、丸括弧・角括弧・波括弧が必要な場合は外側に囲んでください。

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

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

整列された数式や縦方向にスタックされた式が必要な場合は [`toMathArray`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用します。

![A vertical math array with x above y](powerpoint-math-equations_11.png)

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

引数が現在の要素で関数名が既知の場合は、[`asArgumentOfFunction`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用します。

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

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

## **下付き文字と上付き文字の追加**

インデックスや指数には下付き文字・上付き文字ヘルパーを使用します。インデックスを基数の左側に配置する必要がある場合は、[`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用します。

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

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

式を区切り記号で囲むには [`enclose`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用します。複数要素を含む区切り記号式の場合は、区切り文字も設定できます。

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

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

数式全体を枠で囲む場合は [`toBorderBox`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用します。

![A boxed equation showing a squared equals b squared plus c squared](powerpoint-math-equations_12.png)

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

式の上または下にグループ化文字を配置するには [`group`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) を使用し、ラベルを付けるためにリミットを追加します。

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

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

書式設定ヘルパーは式の可読性が向上する場合にのみ使用してください。例として、[`overbar`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) は数式要素の上にバーを付加します。

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

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

| タスク | メイン API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathematicaltext/) |
| 要素の結合 | [join](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 分数の作成 | [divide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 上付き・下付き文字の追加 | [setSuperscript](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 関数の追加 | [function](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 根号の追加 | [radical](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| リミットの追加 | [setLowerLimit](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 左側スクリプトの追加 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 和・積分の追加 | [nary](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathmatrix/) |
| 数式配列の追加 | [toMathArray](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 区切り記号の追加 | [enclose](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| バーや枠の追加 | [overbar](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |
| 項のグループ化 | [group](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、`MathPortion` を含むシェイプを見つけ、その `MathParagraph` を取得して、段落内の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX に保存すると、Aspose.Slides は数式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

Aspose.Slides は数式を MathML にエクスポートします。LaTeX が必要な場合は、まず MathML にエクスポートし、対象の LaTeX 方言をサポートするツールで MathML を変換してください。