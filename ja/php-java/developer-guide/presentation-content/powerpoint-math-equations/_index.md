---
title: PHPでPowerPointプレゼンテーションに数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/php-java/powerpoint-math-equations/
keywords:
- 数式
- 数記号
- 数式
- 数式テキスト
- 数式を追加
- 記号を追加
- 数式を追加
- テキストを追加
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint の PPT および PPTX に数式を挿入・編集できます。OMML のサポート、書式設定コントロール、明確な PHP コードサンプルを提供します。"
---
## **概要**

PowerPoint は数式を Office Math Markup Language (OMML) として保存します。Aspose.Slides for PHP via Java を使用すると、分数、根号、関数、リミット、N 進演算子、行列、配列、書式設定された数式ブロックなど、同様の数式コンテンツをプログラムで作成できます。

PowerPoint では、通常 **挿入 > 数式** から数式を追加します:

![PowerPoint の挿入タブで数式コマンドが選択されている](powerpoint-math-equations_1.png)

結果はスライド上で編集可能な数式テキストになります:

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides は主に 3 つのオブジェクトで数式テキストを構築します:

- [addMathShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/#addMathShape) で作成される数式シェイプは、数式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathportion/) はシェイプのテキストフレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathparagraph/) は 1 つ以上の [MathBlock](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathblock/) オブジェクトを含みます。

以下の例は主に [MathematicalText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathematicaltext/) と [MathElementBase](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) のフルエントメソッドを使用して、コードを短く読みやすくしています。

MathML エクスポートのシナリオについては、[Export Math Equations from Presentations in PHP via Java](/slides/ja/php-java/exporting-math-equations/) を参照してください。

## **数式の作成**

この例は数式シェイプを作成し、ピタゴラスの定理を追加します:

![c² = a² + b² の数式](powerpoint-math-equations_3.png)

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
`addMathShape` はすでに数式段落を含むシェイプを作成します。最初の `MathPortion` にアクセスし、その `MathParagraph` を取得して、数式ブロックや数式要素を追加します。
{{% /alert %}}

## **分数の追加**

[`divide`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して分数を作成します。分数のスタイルは [MathFractionTypes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathfractiontypes/) で選択できます。

![1 ÷ x の斜め分数](powerpoint-math-equations_4.png)

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

スタック分数の場合は `MathFractionTypes::Bar` を使用します:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **根号の追加**

[`radical`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して平方根、立方根、その他の根号を作成します。現在の要素が基底となり、引数が指数（根）になります。

![x が根号記号の下にある n 次根](powerpoint-math-equations_5.png)

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

[`asArgumentOfFunction`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) または [`function`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して、`sin(x)`、`log(x)` などの関数やカスタム関数名を表現できます。リミットの場合は `lim` を [MathLimit](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathlimit/) に入れるか、[`setLowerLimit`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用します。

![x が無限大に近づく極限](powerpoint-math-equations_8.png)

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

カスタム関数名を使用する場合は、関数名を現在の要素に設定します:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N 進演算子と積分の追加**

[`nary`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して総和、和集合、積集合、その他の大きな演算子を表現します。積分には [`integral`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用します。両方のメソッドで下限と上限を設定できます。

![下限と上限付きの総和](powerpoint-math-equations_7.png)

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

N 進演算子はオプションのリミットを伴う大きな演算子用です。`+`、`-`、`=` のような単純な演算子は通常 `MathematicalText` として追加し、式に結合します。

積分の場合は `integral` を使用します:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **行列の追加**

[MathMatrix](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathmatrix/) を使用して行と列を定義します。既定では括弧が付かないため、必要に応じて丸括弧、角括弧、波括弧で囲んでください。

![空セルが 1 つある 2 行の行列](powerpoint-math-equations_10.png)

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

## **数式配列の追加**

[`toMathArray`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用すると、揃えられた数式や縦に積み重ねた式を作成できます。

![x が y の上にある縦方向の数式配列](powerpoint-math-equations_11.png)

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

[`asArgumentOfFunction`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して、引数が現在の要素で関数名が既知の場合に表現できます。

![cos が 2x に適用された三角関数](powerpoint-math-equations_6.png)

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

## **下付き文字と上付き文字の追加**

インデックスや指数には下付き・上付きヘルパーを使用します。インデックスを基底の左側に表示する必要がある場合は、[`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用します。

![左側下付き 1 と上付き n を持つ大文字 Y](powerpoint-math-equations_9.png)

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

[`enclose`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して式を区切り記号で囲みます。複数要素を含む区切り式には区切り文字も設定できます。

![縦棒で区切られた x、y、z を含む区切り式](powerpoint-math-equations_13.png)

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

[`toBorderBox`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用すると、数式自体を枠で囲むことができます。

![a² = b² + c² を示す枠付き数式](powerpoint-math-equations_12.png)

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

[`group`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) を使用して、式の上または下にグループ文字を配置します。リミットを追加してグループ化した項にラベルを付けることができます。

![x + y が下に任意のテキストラベル付きでグループ化された式](powerpoint-math-equations_15.png)

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

書式設定ヘルパーは式の可読性が向上する場合にのみ使用してください。例として、[`overbar`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) は数式要素の上にバーを付けます。

![上にバーが付いた ABC の数式](powerpoint-math-equations_14.png)

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

| タスク | 主なAPI |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathematicaltext/) |
| 要素の結合 | [join](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 分数の作成 | [divide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 上付き・下付き文字の追加 | [setSuperscript](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 関数の追加 | [function](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 根号の追加 | [radical](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| リミットの追加 | [setLowerLimit](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 左側スクリプトの追加 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 総和と積分の追加 | [nary](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathmatrix/) |
| 数式配列の追加 | [toMathArray](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 区切り記号の追加 | [enclose](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| バーと枠の追加 | [overbar](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |
| 項のグループ化 | [group](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathelementbase/) |

## **よくある質問**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、`MathPortion` を含むシェイプを見つけ、その `MathParagraph` を取得して、段落内の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX で保存すると、Aspose.Slides は数式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

はい。`MathPortion` からその [MathParagraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathparagraph/) を取得し、[MathParagraph::toLatex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathparagraph/#toLatex) を呼び出して直接エクスポートします。完全な例は [Export Math Equations from Presentations in PHP via Java](/slides/ja/php-java/exporting-math-equations/#export-math-equations-to-latex) を参照してください。