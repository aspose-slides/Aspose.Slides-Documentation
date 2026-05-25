---
title: PHP で PowerPoint プレゼンテーションに数式を追加する
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/php-java/powerpoint-math-equations/
keywords:
- 数式
- 数学記号
- 数学式
- 数式テキスト
- 数式を追加する
- 数学記号を追加する
- 数式を追加する
- 数式テキストを追加する
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint の PPT と PPTX に数式を挿入および編集でき、OMML、書式設定コントロール、明確な PHP コードサンプルをサポートします。"
---
## **概要**

PowerPointは方程式をOffice Math Markup Language（OMML）として保存します。Aspose.Slides for PHP via Java を使用すると、プログラムで同様の数式コンテンツ（分数、根号、関数、リミット、N項演算子、行列、配列、書式設定された数式ブロック）を作成できます。

PowerPointでは、ユーザーは通常**挿入 > 数式**から方程式を追加します:

![PowerPointの挿入タブで数式コマンドが選択された状態](powerpoint-math-equations_1.png)

結果として、スライド上に編集可能な数式テキストが表示されます:

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides は、次の 3 つの主要オブジェクトを使用してその数式テキストを構築します:

- 数式シェイプは、[addMathShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/#addMathShape) で作成され、方程式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathportion/) は、シェイプのテキストフレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathparagraph/) は、1 つ以上の [MathBlock](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathblock/) オブジェクトを含みます。

以下のほとんどの例は、[MathematicalText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathematicaltext/) と [MathElementBase](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) のフルエントメソッドを使用して、コードを短く読みやすくしています。

MathML エクスポートのシナリオについては、[PHP via Java でプレゼンテーションから数式をエクスポート](/slides/ja/php-java/exporting-math-equations/) を参照してください。

## **方程式の作成**

この例では、数式シェイプを作成し、ピタゴラスの定理を追加します:

![c の二乗が a の二乗 + b の二乗に等しい方程式](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="primary" %}}
`addMathShape` は、既に数式段落を含むシェイプを作成します。最初の `MathPortion` にアクセスし、その `MathParagraph` を取得して、数式ブロックまたは数式要素を追加します。
{{% /alert %}}

## **分数の追加**

[`divide`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して分数を作成します。分数のスタイルは [MathFractionTypes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathfractiontypes/)で選択できます。

![1 ÷ x を示す傾いた分数](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

積み上げ式分数を作成するには、`MathFractionTypes::Bar` を使用します:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **根号の追加**

[`radical`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して平方根、立方根、その他の根号を作成します。現在の要素が基底になり、引数が次数になります。

![x が根号記号の下にある n 次根号の式](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **関数とリミットの追加**

[`asArgumentOfFunction`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) または [`function`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して、`sin(x)`、`log(x)` などの関数やカスタム関数名を指定します。リミットでは、`lim` を [MathLimit](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathlimit/) に入れるか、[`setLowerLimit`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用します。

![x が無限大に近づくときの lim](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

カスタム関数名の場合は、関数名を現在の要素にします:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N項演算子と積分の追加**

[`nary`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して総和、合併、交差、その他の大きな演算子を作成します。[`integral`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して積分を作成します。どちらのメソッドも下限と上限を設定できます。

![下限と上限を持つ総和記号](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

N-項演算子は、オプションのリミットを持つ大きな演算子用です。`+`、`-`、`=` などの単純な演算子は通常 `MathematicalText` として追加し、式に結合します。

積分を作成するには、`integral` を使用します:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **行列の追加**

行と列には [MathMatrix](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathmatrix/) を使用します。行列はデフォルトで括弧が付かないため、丸括弧、角括弧、波括弧が必要な場合は行列を囲んでください。

![1 つの空セルを含む2行の数式行列](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **方程式配列の追加**

[`toMathArray`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して、整列した方程式や縦方向に積み重ねた式が必要な場合に使用します。

![x の上に y がある縦方向の数式配列](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **三角関数の追加**

引数が現在の要素で関数名が既知の場合は、[`asArgumentOfFunction`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用します。

![2x に適用された三角関数 cos](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **添字と上付き文字の追加**

添字と上付き文字のヘルパーを使用して、インデックスや指数を設定します。インデックスを基底の左側に表示する必要がある場合は、[`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用します。

![左側添字 1 と上付き n を持つ大文字 Y](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **区切り記号の追加**

[`enclose`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して式を区切り記号で囲みます。複数の要素を含む区切り記号式では、区切り文字も設定できます。

![x, y, z を縦棒で区切った区切り記号式](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **枠付きボックスの追加**

式自体を枠で囲む場合は、[`toBorderBox`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用します。

![a² = b² + c² を示す枠付き方程式](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **項のグループ化**

[`group`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して、式の上または下にグループ化文字を配置します。リミットを追加してグループ化した項にラベルを付けます。

![x + y の式が下にラベル（任意のテキスト）でグループ化された様子](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **数式要素の書式設定**

書式設定ヘルパーは、式を明確にする場合にのみ使用してください。例として、[`overbar`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) は数式要素の上にバーを付けます。

![上にバーが付いた数式 ABC](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **クイックリファレンス**

| タスク | 主な API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathematicaltext/) |
| 要素の結合 | [join](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 分数の作成 | [divide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 上付き文字または下付き文字の追加 | [setSuperscript](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 関数の追加 | [function](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 根号の追加 | [radical](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| リミットの追加 | [setLowerLimit](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 左側添字/上付き文字の追加 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 総和と積分の追加 | [nary](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathmatrix/) |
| 方程式配列の追加 | [toMathArray](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 区切り記号の追加 | [enclose](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| バーと枠の追加 | [overbar](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 項のグループ化 | [group](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |

## **よくある質問**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、`MathPortion` を含むシェイプを見つけ、その `MathParagraph` を取得し、その段落内の数式ブロックを更新します。

**方程式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX に保存すると、Aspose.Slides は方程式を編集可能な Office 数式コンテンツとして書き込みます。

**方程式を LaTeX にエクスポートできますか？**

Aspose.Slides は数式を MathML にエクスポートします。LaTeX が必要な場合は、まず MathML にエクスポートし、対象の LaTeX 方言をサポートするツールで MathML を変換してください。