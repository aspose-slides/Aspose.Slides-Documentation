---
title: JavaScript を使用して PowerPoint プレゼンテーションに数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/nodejs-java/powerpoint-math-equations/
keywords:
- 数式
- 数式記号
- 数式
- 数式テキスト
- 数式を追加
- 数式記号を追加
- 数式を追加
- 数式テキストを追加
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js 用 Aspose.Slides for Java を使用して、PowerPoint の PPT と PPTX に数式を挿入および編集できます。OMML のサポート、書式設定コントロール、分かりやすい JavaScript コードサンプルを提供します。"
---
## **概要**

PowerPoint は方程式を Office Math Markup Language (OMML) として保存します。Aspose.Slides for Node.js via Java を使うと、分数、根号、関数、極限、N 進演算子、行列、配列、書式設定された数式ブロックなど、同様の数式コンテンツをプログラムで作成できます。

PowerPoint では、ユーザーは通常 **Insert > Equation** から方程式を追加します:

![PowerPoint の挿入タブで「Equation」コマンドが選択されている状態](powerpoint-math-equations_1.png)

結果として、スライド上に編集可能な数式テキストが表示されます:

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides は、次の 3 つの主要オブジェクトを使用して数式テキストを構築します:

- 数式シェイプは、[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) を使用して作成され、方程式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) は、シェイプのテキストフレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) は、1 つ以上の [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) オブジェクトを含みます。

以下のほとんどの例では、[MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) と [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) のフルエントメソッドを使用して、コードを簡潔かつ読みやすくしています。

MathML エクスポートシナリオについては、[Node.js via Java でのプレゼンテーションから数式をエクスポート](/slides/ja/nodejs-java/exporting-math-equations/) を参照してください。

## **方程式の作成**

この例では [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) を使用して数式シェイプを作成し、ピタゴラスの定理を追加します:

![c の二乗が a の二乗 + b の二乗に等しい方程式](powerpoint-math-equations_3.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) は、すでに数式段落を含むシェイプを作成します。最初の [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) にアクセスし、[getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) を呼び出して、数式ブロックまたは数式要素を追加します。
{{% /alert %}}

## **分数の追加**

[divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) を使用して分数を作成します。[MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) で分数スタイルを選択できます。

![1 を x で割った斜めの数式分数](powerpoint-math-equations_4.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

積み重ね式分数の場合は、[MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar) を使用します：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **根号の追加**

[radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) を使用して平方根、立方根、その他の根号を作成します。現在の要素が基底となり、引数が指数になります。

![根号記号の下に x がある n 頭根号式](powerpoint-math-equations_5.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **平方根の指数の表示／非表示**

平方根は明示的に 2 を表示するか、従来の √x 表記を使用できます。[setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) メソッドは、[MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) のどちらの形式が表示されるかを制御します。両方の形式は、指数 2 と根体 x を編集可能な方程式に保持します。

![左側に指数が表示され、右側に非表示の同じ平方根](square-root-degree.png)

例では同じ平方根を 2 回保存します。`visible-degree.pptx` では 2 が表示され、`hidden-degree.pptx` では非表示になります。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let radical = new aspose.slides.MathematicalText("x").radical("2");
    
    let shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    let portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new aspose.slides.MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", aspose.slides.SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **関数と極限の追加**

[asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) または [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) を使用して、`sin(x)`, `log(x)` などの関数やカスタム関数名を作成します。極限については、[MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) に `lim` を入れるか、[setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit) を使用します。

![x が無限大に近づく極限](powerpoint-math-equations_8.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

カスタム関数名の場合、関数名を現在の要素にし、引数で [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) を呼び出します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **N 進演算子と積分の追加**

[nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) を使用して総和、和集合、積集合、その他の大きな演算子を作成します。[integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) を使用して積分を作成します。両方のメソッドで下限と上限を設定できます。

![下限と上限を持つ総和](powerpoint-math-equations_7.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

N 進演算子は、オプションの上下限を持つ大きな演算子用です。`+`, `-`, `=` のような単純な演算子は通常、[MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) を使用して式に結合します。

積分の場合は、[integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) を使用します：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **行列の追加**

[MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) を使用して行と列を作成します。行列はデフォルトで括弧を含まないため、括弧、角括弧、波括弧が必要な場合は行列を囲んでください。

![空のセルが 1 つある 2 行の数式行列](powerpoint-math-equations_10.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **既存の行列の編集**

線形代数の授業が `matrix.pptx` の係数行列から始まり、前の例で保存されたとします。次の演習では、最初の方程式を保持し、2 番目を 2 つの新しい方程式に置き換え、変数のセットを修正します。残っている係数を保持するために、[MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) を介して既存の行列を開きます。

![元の 2 行係数行列（1、x、空セル）と（x、2、y）](matrix-before-edit.png)

行と列のインデックスは 0 から始まり、各呼び出し時点の行列を指します。インデックス 1 の前に行を挿入すると、元の 2 行目がインデックス 2 に移動します。インデックス 2 の後に挿入すると行が追加されます。行 2 を削除すると、元の 2 行目が削除され、追加された行が 1 つ上に移動します。列も同様にシフトします。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("matrix.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const matrix = portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // 新しいセルは最初は null です。非ゼロ係数を先に設定します。
    matrix.set_Item(1, 0, new slides.MathematicalText("12"));
    matrix.set_Item(1, 1, new slides.MathematicalText("1"));
    matrix.set_Item(2, 2, new slides.MathematicalText("10"));
    matrix.set_Item(2, 3, new slides.MathematicalText("1"));
    for (let row = 0; row < matrix.getRowCount(); row++) {
        for (let column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new slides.MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, slides.MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, slides.MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) は最初の列を左揃えにします。[setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) はインデックス 1 から開始して、3 つの連続列を右揃えにします。`updated-matrix.pptx` では、行列は 3 つの方程式と 4 つの変数を持ちます。元の最初の行の係数 `1` と `x` は現在、1 列目と 3 列目に表示されます。

![更新された 3 行行列（行 1,0,x,0; 12,1,0,0; 0,0,10,1）](matrix-after-edit.png)

## **方程式配列の追加**

[toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) を使用して、整列された方程式や縦に並んだ式が必要な場合は、配列を作成します。

![x が上、y が下の縦方向数式配列](powerpoint-math-equations_11.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **配列と周囲要素の配置合わせ**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) は、配列の垂直配置を隣接する数式要素に対して制御します。以下の例は、最初の行、配列の中心、最後の行での配置を比較します。

次の例では、3 つの同一配列を作成します。それぞれ 3 行で、隣接要素は `A=` と `=B` です。すべての数式テキストは Cambria Math の 24 ポイントです。配列の配置だけが変わります。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [slides.MathVerticalAlignment.Top, slides.MathVerticalAlignment.Center, slides.MathVerticalAlignment.Bottom];
    const alignmentNames = ["Top", "Center", "Bottom"];

    for (let i = 0; i < alignments.length; i++) {
        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(alignmentNames[i]);
        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));
        const mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下の比較は、PowerPoint で保存されたプレゼンテーションを示しています。各配列の横にある `A=` と `=B` の位置に注目してください。

![PowerPoint の方程式配列（上部、中央、下部配置）と同一の隣接要素](equation-array-alignment.png)

### **行間の設定**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) は、配列内の行の間隔ルールを選択します。[setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) は、明示的な間隔ルールの数値を提供し、プリセットルールでは無視されます。

正確な間隔の場合、値はポイントで測定されます。比例間隔の場合、半行単位で測定されます：例の値 `3` は 1.5 行を指定します。明示的な値を指定する場合は、両方のプロパティを設定します。数値だけを変更しても間隔ルールは選択されません。

以下の例では、同じ方程式、配置、フォント設定で 5 つのプレゼンテーションを保存します。最初の 3 つはプリセット、最後の 2 つは明示的な値を示しています。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const rules = [slides.MathRowSpacingRule.SingleLineGap, slides.MathRowSpacingRule.OneAndAHalfLineGap, slides.MathRowSpacingRule.TwoLineGap, slides.MathRowSpacingRule.Exactly, slides.MathRowSpacingRule.Multiple];
const spacingValues = [0, 0, 0, 20, 3];
const ruleNames = ["SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple"];

for (let i = 0; i < rules.length; i++) {
    const fileName = "equation-array-" + ruleNames[i] + ".pptx";
    const presentation = new slides.Presentation();
    try {
        const mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        const paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        const mathParagraph = paragraph.getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(slides.MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(java.newLong(spacingValues[i]));
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

配列の行間は段落間隔とは別です。[setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) と [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) は、配列行の間ではなく、包含する段落の前後にスペースを追加します。同様に、[MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) は数式段落全体の水平位置を設定し、配列の垂直配置設定を置き換えるものではありません。

## **三角関数の追加**

引数が現在の要素で関数名が既知の場合は、[asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) を使用します。

![cos(2x) の三角関数](powerpoint-math-equations_6.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

下付き文字と上付き文字のヘルパーを使用してインデックスやべき乗を付けます。インデックスを基底の左側に表示する必要がある場合は、[setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) を使用します。

![左側に下付き 1、上付き n の大文字 Y](powerpoint-math-equations_9.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

[enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) を使用して式を区切り記号で囲みます。複数要素を含む区切り記号式には、区切り文字も設定できます。

![縦棒で区切られた x, y, z を含む区切り式](powerpoint-math-equations_13.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

### **区切り記号のサイズと配置**

`true` を [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) に渡すと、オペランドが高い場合に括弧が伸長します。`false` を渡すと通常サイズのままです。[setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) を [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) のいずれかの値と共に使用します。`Centered` は括弧を数式軸の中心に配置し、`Match` は囲んだ内容に合わせます。これらの設定は区切り記号にのみ影響し、内部式は変わりません。

例では、`x` の指数に分数を置き、式がベースラインより上に伸びるようにしています。4 つの式すべてで同じ括弧とフォント設定を使用しています。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    for (let row = 0; row < 2; row++) {
        for (let column = 0; column < 2; column++) {
            const fraction = new slides.MathematicalText("a + b").divide("c + d");
            const power = new slides.MathematicalText("x").setSuperscript(fraction);
            const delimiter = power.enclose(java.newChar('('), java.newChar(')'));
            delimiter.setGrowToMatchOperandHeight(row === 0);
            delimiter.setDelimiterShape(column === 0 ? slides.MathDelimiterShape.Centered : slides.MathDelimiterShape.Match);

            const mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            const portion = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            const equation = new slides.MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint で行を比較して、伸長の効果を確認してください。上段では、括弧が指数を囲むように伸長し、両形状で同じに見えます。下段では伸長がオフです。左側の小さい括弧（`Centered`）は等号の位置に合わせ、右側（`Match`）は式の上に高く配置されます。

![PowerPoint の 4 つの式（上段で伸長有効、下段で無効、左側 Centered、右側 Match）](delimiter-sizing.png)

## **枠線ボックスの追加**

分数に対して [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) を呼び出すと、式全体を枠で囲むことができます。返される [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) はデフォルトで 4 辺すべてを表示します。個別の辺を削除するには、[setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop)、[setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom)、[setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft)、[setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) を使用します。

例では、同じ分数のコピーを 1 スライドに 6 つ配置しています。取り消し線を示すために、すべての辺を非表示にし、[setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) に `true` を渡して右上がりの対角線 (↗) を、または [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) に `true` を渡して左下がりの対角線 (↘) を描きます。また、[setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) や [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) を使用して、表示する辺の任意の組み合わせで水平または垂直の取り消し線を描くこともできます。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    function addFraction(x, y, hideBorder) {
        const fraction = new slides.MathematicalText("x+1").divide("y+2");
        const box = fraction.toBorderBox();
        box.setHideTop(hideBorder);
        box.setHideBottom(hideBorder);
        box.setHideLeft(hideBorder);
        box.setHideRight(hideBorder);

        const shape = slide.getShapes().addMathShape(x, y, 160, 90);
        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(28);
        const block = new slides.MathBlock(box);
        portion.getMathParagraph().add(block);
        return box;
    }

    addFraction(10, 10, false);

    const partial = addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    addFraction(190, 120, true).setStrikethroughHorizontal(true);
    addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![6 つの編集可能な分数（上段：全枠、下部と左部、右上がりの対角線。下段：左下がりの対角線、水平線、垂直線＋全枠）](border-box-fractions.png)

この分数では、水平線が分数線と重なります。垂直線は分子と分母の両方を横切り、周囲の枠は可視のままです。これらの線は式全体を装飾します。通常の文字取り消しはテキストランの文字に適用されます。PowerPoint でプレゼンテーションを再度開くと、分子と分母を個別に編集できる状態が保たれます。

## **Phantom 要素で可視性とレイアウトを制御**

式を [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) でラップすると、可視性と式が方程式に占めるスペースを個別に制御できます。[MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) の各メソッドは次のことを制御します：

| メソッド | 効果 |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | `false` を渡すと式を非表示にします。対応する下位メソッドが `true` を受け取らない限り、寸法はレイアウトに寄与し続けます。 |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | 式の横幅を 0 とみなし、隣接要素がより近くなるようにします。 |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | 基線上の高さ（上昇部）を 0 とみなし、上部のスペースを削減します。 |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | 基線下の深さ（下降部）を 0 とみなし、下部のコンテンツが隣接要素に近づきます。 |

ベースラインは、通常の数式文字が配置される基準線です。内容を非表示にしても寸法は削除されず、寸法を 0 としても式自体は削除されません。基礎式は [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase) で取得できます。`true` を [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) に渡すと再度表示され、寸法設定は変更されません。

以下の例では、5 つの横並びバリアントを作成します：表示された分数、スペースを保持した非表示分数、ZeroWidth、ZeroAsc、ZeroDesc のいずれかの寸法が 0 の非表示分数。各バリアントは同じ外側式と Cambria Math の 24 ポイントを使用します。すべての方程式シェイプは同じ上部位置で、グレーガイドで示されています。外側分数の分子に phantom を配置すると、垂直レイアウトの変化が見やすくなります。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(1000, 180, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const labels = [ "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" ];

    const guide = slide.getShapes().addAutoShape(slides.ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    for (let i = 0; i < labels.length; i++) {
        const left = 10 + i * 200;

        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(labels[i]);

        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const fractionNumerator = createText("a+b");
        const fractionDenominator = createText("c+d");
        const fraction = new slides.MathFraction(fractionNumerator, fractionDenominator);
        const phantom = new slides.MathPhantom(fraction);
        phantom.setShow(i === 0);
        phantom.setZeroWidth(i === 2);
        phantom.setZeroAsc(i === 3);
        phantom.setZeroDesc(i === 4);

        const leftText = createText("x+");
        const rightText = createText("+y");
        const numerator = new slides.MathBlock(leftText).join(phantom).join(rightText);
        const denominator = createText("z");
        const equation = new slides.MathFraction(numerator, denominator);

        const shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));

        const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new slides.MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![PowerPoint の 5 つの方程式（表示分数、スペース保持非表示分数、ZeroWidth、ZeroAsc、ZeroDesc の非表示分数）](math-phantom.png)

## **項のグループ化**

[group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) を使用して、式の上または下にグルーピング文字を配置します。ラベル付けにはリミットを追加します。

![式 x + y が下に任意のテキストラベルでグループ化された様子](powerpoint-math-equations_15.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

書式設定ヘルパーは、式を明確にする場合にのみ使用してください。例えば、[overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) は数式要素の上にバーを配置します。

![上にバーが付いた数式 ABC](powerpoint-math-equations_14.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **既存の方程式内テキストの書式設定**

既存の方程式全体のテキストを書式設定するには、各数式ブロックの要素ツリーを走査します。[MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) は直接の子要素のみを返すため、再帰的に呼び出して分数、添字、根号、その他の入れ子構造内のテキストに到達します。開始要素が [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) の場合も含めるため、現在の要素とその子要素の両方をチェックします。

この例では、`input.pptx` に `z = xᵢ / ∛y` のような方程式が含まれていると仮定します。分子に下付き文字、分母に根号を持つ分数です。ブロックのトップレベル要素だけを処理すると、分数内部のテキストは見逃されます。例では、スライドのテキストフレーム内の数式部分を見つけ、[MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) を介してブロックにアクセスし、[setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) を使用して各テキスト要素の [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) メソッドでフォントサイズを 28 ポイントに設定します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatMathText(element) {
    if (java.instanceOf(element, "com.aspose.slides.MathematicalText")) {
        element.getFormat().setFontHeight(28);
    }

    let children = element.getChildren();
    for (let i = 0; i < children.length; i++) {
        formatMathText(children[i]);
    }
}

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }

            let textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let k = 0; k < textFrame.getParagraphs().getCount(); k++) {
                let paragraph = textFrame.getParagraphs().get_Item(k);
                for (let l = 0; l < paragraph.getPortions().getCount(); l++) {
                    let portion = paragraph.getPortions().get_Item(l);
                    if (java.instanceOf(portion, "com.aspose.slides.IMathPortion")) {
                        let mathParagraph = portion.getMathParagraph();
                        for (let m = 0; m < mathParagraph.getCount(); m++) {
                            formatMathText(mathParagraph.get_Item(m));
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存されたプレゼンテーションは、処理された各方程式のすべてのレベルで更新されたテキスト書式設定を保持し、テキスト内容と数式構造はそのままです。

## **クイックリファレンス**

| タスク | 主な API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| 要素の結合 | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 分数の作成 | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 上付きまたは下付きの追加 | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 関数の追加 | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 根号の追加 | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 極限の追加 | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 左側スクリプトの追加 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 総和と積分の追加 | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| 方程式配列の追加 | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 区切り記号の追加 | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| バーと枠線の追加 | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 項のグループ化 | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **よくある質問**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、[MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) を含むシェイプを見つけ、[getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) を呼び出してその段落の数式ブロックを更新します。

**方程式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX として保存すると、Aspose.Slides は方程式を編集可能な Office 数式コンテンツとして書き込みます。

**方程式を LaTeX にエクスポートできますか？**

はい。方程式の [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) をその [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) から取得し、[MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) を呼び出して直接エクスポートします。完全な例については、[Node.js via Java でのプレゼンテーションから数式をエクスポート](/slides/ja/nodejs-java/exporting-math-equations/#export-math-equations-to-latex) を参照してください。