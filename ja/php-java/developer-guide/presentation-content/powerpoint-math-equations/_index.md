---
title: PHP で PowerPoint プレゼンテーションに数式を追加
linktitle: PowerPoint 数式
type: docs
weight: 80
url: /ja/php-java/powerpoint-math-equations/
keywords:
- 数式
- 記号
- 式
- 数式テキスト
- 数式の追加
- 記号の追加
- 式の追加
- テキストの追加
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint の PPT および PPTX に数式を挿入・編集できます。OMML のサポート、書式設定コントロール、わかりやすい PHP コードサンプルを提供します。"
---
## **概要**

PowerPoint は数式を Office Math Markup Language (OMML) として保存します。Aspose.Slides for PHP via Java を使用すると、プログラムで同様の数式コンテンツを作成できます：分数、根号、関数、リミット、N 元演算子、行列、配列、そして書式設定された数式ブロック。

PowerPoint では、ユーザーは通常 **挿入 > 数式** から数式を追加します:

![PowerPoint の挿入タブで「数式」コマンドが選択された状態](powerpoint-math-equations_1.png)

結果はスライド上の編集可能な数式テキストになります:

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides は、次の 3 つの主要オブジェクトを使用して数式テキストを構築します:

- 数式シェイプは、[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) で作成され、数式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) はシェイプのテキストフレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) は 1 つ以上の [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) オブジェクトを含みます。

以下の例のほとんどは、コードを短く読みやすくするために [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) と [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) のフルエントメソッドを使用しています。

MathML エクスポート シナリオについては、[Export Math Equations from Presentations in PHP via Java](/slides/ja/php-java/exporting-math-equations/) を参照してください。

## **数式の作成**

この例では [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) を使用して数式シェイプを作成し、ピタゴラスの定理を追加します:

![c の二乗 = a の二乗 + b の二乗 の式](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) は、すでに数式段落が含まれたシェイプを作成します。最初の [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) にアクセスし、[getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) を呼び出して、数式ブロックまたは数式要素を追加します。
{{% /alert %}}

## **分数の追加**

[divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) を使用して分数を作成します。分数スタイルは [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/) で選択できます。

![1 ÷ x を示す斜めの分数](powerpoint-math-equations_4.png)

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

積み重ね式の分数には、[MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar) を使用します:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **根号の追加**

[radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) を使用して平方根、立方根、その他の根号を作成します。現在の要素が基底となり、引数が次数になります。

![根号記号の下に x がある n 次根式](powerpoint-math-equations_5.png)

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

[asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) または [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) を使用して、`sin(x)`、`log(x)` などの関数やカスタム関数名を作成します。リミットの場合は、`lim` を [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) に入れるか、[setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit) を使用します。

![x が無限大に近づくときのリミット](powerpoint-math-equations_8.png)

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

カスタム関数名の場合は、関数名を現在の要素にし、[function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) を引数と共に呼び出します:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N元演算子と積分の追加**

[nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) を使用して総和、和集合、積集合、その他の大きな演算子を作成します。[integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) を使用して積分を作成します。両方のメソッドで下限と上限を設定できます。

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

N元演算子は、オプションのリミットを持つ大きな演算子用です。`+`、`-`、`=` などの単純な演算子は通常 [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) で追加し、式に結合します。

積分の場合は、[integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) を使用します:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **行列の追加**

行と列には [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) を使用します。行列はデフォルトで括弧を含まないため、丸括弧、角括弧、波括弧が必要な場合は行列を囲んでください。

![空のセルが 1 つある 2 行の数式行列](powerpoint-math-equations_10.png)

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

整列した数式や縦に並んだ式が必要な場合は、[toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) を使用します。

![x が上、y が下に配置された縦方向の数式配列](powerpoint-math-equations_11.png)

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

### **配列を周囲の要素と揃える**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) は、配列の縦方向の配置を隣接する数式要素に対して制御します。以下の例は、最初の行、配列の中心、最後の行での配置を比較しています。

次の例は、3 行の同一配列を 3 つ作成し、隣接要素 `A=` と `=B` を付けます。すべての数式テキストは 24 ポイントの Cambria Math を使用します。配列の配置だけが変わります。

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$alignments = ["Top" => MathVerticalAlignment::Top, "Center" => MathVerticalAlignment::Center, "Bottom" => MathVerticalAlignment::Bottom];
$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(780, 200, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 20;
    foreach ($alignments as $name => $alignment) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 10, 240, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($name);
        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(16);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $mathShape = $slide->getShapes()->addMathShape($x, 60, 240, 130);
        $mathShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification($alignment);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $x += 260;
    }
    $presentation->save("equation-array-alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

以下の比較は、PowerPoint で保存されたプレゼンテーションを示しています。各配列の横にある `A=` と `=B` の位置に注目してください。

![PowerPoint の数式配列：上部、中央、下部の配置と同一の隣接要素](equation-array-alignment.png)

### **行間の設定**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) は、配列内の行の間隔ルールを選択します。[setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) は明示的な間隔ルールの数値を提供し、プリセットルールでは無視されます。

正確な間隔の場合、値はポイントで測定されます。比例間隔の場合は半行単位で測定され、例の値 `3` は 1.5 行を表します。明示的な値を指定する際は両方のプロパティを設定してください。数値だけを変更しても間隔ルールは選択されません。

以下の例は、同じ数式、配置、フォント設定で 5 つのプレゼンテーションを保存します。最初の 3 つはプリセットを使用し、最後の 2 つは明示的な値を示します。

```php
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathRowSpacingRule;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$settings = [
    "SingleLineGap" => [MathRowSpacingRule::SingleLineGap, 0],
    "OneAndAHalfLineGap" => [MathRowSpacingRule::OneAndAHalfLineGap, 0],
    "TwoLineGap" => [MathRowSpacingRule::TwoLineGap, 0],
    "Exactly" => [MathRowSpacingRule::Exactly, 20],
    "Multiple" => [MathRowSpacingRule::Multiple, 3],
];

foreach ($settings as $name => [$rule, $spacing]) {
    $presentation = new Presentation();
    try {
        $mathShape = $presentation->getSlides()->get_Item(0)->getShapes()->addMathShape(20, 20, 600, 300);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification(MathVerticalAlignment::Center);
        $equationArray->setRowSpacingRule($rule);
        $equationArray->setRowSpacing($spacing);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $presentation->save("equation-array-$name.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

配列の行間は段落間隔とは別です。[setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) と [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) は配列を含む段落の前後に空白を追加し、行間には影響しません。同様に、[MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) は数式段落全体を水平に配置しますが、配列の垂直配置設定を置き換えるものではありません。

## **三角関数の追加**

引数が現在の要素で関数名が既知の場合は、[asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) を使用します。

![2x に cos を適用した三角関数](powerpoint-math-equations_6.png)

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

インデックスや指数には下付き文字・上付き文字ヘルパーを使用します。インデックスを基底の左側に表示する必要がある場合は、[setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) を使用します。

![左側に下付き 1、上付き n が付いた大文字 Y](powerpoint-math-equations_9.png)

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

## **デリミタの追加**

[enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) を使用して式をデリミタで囲みます。複数の要素を含むデリミタ式には、区切り文字を設定することもできます。

![x、y、z を縦棒で区切ったデリミタ式](powerpoint-math-equations_13.png)

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

### **デリミタのサイズと配置**

`true` を [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) に渡すと、括弧が高いオペランドに合わせて拡大します。`false` を渡すと通常サイズのままです。[setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) を使用し、[MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) の 2 つの値のいずれかを指定します。`Centered` は等号の中央を通る数式軸上で括弧を中央に配置し、`Match` は囲まれた内容に合わせて配置します。これらの設定はデリミタのみに影響し、内部の式は変わりません。

この例は `x` の指数に分数を置き、式がベースラインの上側により遠く伸びるようにします。4 つの式すべてが同じ括弧とフォント設定を使用しています。

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint で行を比較して、拡大効果を確認してください。上段では、括弧が指数を囲むように拡大し、両形状で同じように見えます。下段では拡大が無効です。左側の小さい括弧（`Centered`）は等号に合わせ、右側（`Match`）は式の上部に配置されます。

![PowerPoint の 4 つの式：上段はデリミタ拡大有効、下段は無効、左は Centered、右は Match](delimiter-sizing.png)

## **枠ボックスの追加**

分数に対して [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) を呼び出すと、式全体を枠で囲みます。返される [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) はデフォルトで 4 辺すべてを表示します。個別の辺を非表示にするには、[setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop)、[setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom)、[setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft)、[setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) を使用します。

この例では、同一の分数を 1 スライドに 6 つ配置します。取り消し線を示すために、4 辺すべてを非表示にし、上向き対角線 (↗) の場合は `true` を [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) に、下向き対角線 (↘) の場合は [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) に渡します。また、[setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) や [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) を使用して、表示する辺の組み合わせを指定できます。

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![PowerPoint の 6 つの編集可能な分数。上段：全枠、下部と左側の枠、上向き対角線。下段：下向き対角線、水平取り消し線、垂直取り消し線（全枠あり）。](border-box-fractions.png)

この分数では、水平取り消し線が分数線と重なります。垂直取り消し線は分子と分母の両方を横切り、周囲の枠は表示されたままです。これらの線は式全体を装飾します。通常のテキストの取り消し線はテキストランの文字に適用されます。PowerPoint でプレゼンテーションを再度開いても、分子と分母は個別に編集可能です。

## **項のグループ化**

式の上または下にグルーピング文字を配置するには、[group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) を使用します。グループ化された項にラベルを付けるにはリミットを追加します。

![式 x + y が下に任意のテキストラベルでグループ化された様子](powerpoint-math-equations_15.png)

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

書式設定ヘルパーは、式を明確にする場合にのみ使用してください。例として、[overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) は数式要素の上にバーを付けます。

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

### **既存の数式内テキストの書式設定**

既存の数式全体のテキストを書式設定するには、各数式ブロックの要素ツリーを走査します。[MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) は直接の子要素のみを返すので、分数、添字・上付き文字、根号、その他入れ子構造の内部テキストに到達するために再帰的に呼び出します。開始要素が [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) の場合も、現在の要素とその子要素をチェックして含めます。

この例では、`input.pptx` に `z = xᵢ / ∛y` のような数式が含まれていると想定します。この数式は、分子に下付き文字、分母に根号を持つ分数です。ブロックのトップレベル要素だけを処理すると、分数内部のテキストが見逃されます。例では、スライドのテキストフレーム内の数式部分を見つけ、[MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) を介してブロックにアクセスし、各テキスト要素の [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) メソッドを通じて [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) でフォントサイズを 28 ポイントに設定します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

保存されたプレゼンテーションは、処理された各数式のすべてのレベルで更新されたテキスト書式を保持しつつ、テキスト内容と数式構造を維持しています。

## **クイック リファレンス**

| タスク | 主な API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| 要素の結合 | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 分数の作成 | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 上付き・下付き文字の追加 | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 関数の追加 | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 根号の追加 | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| リミットの追加 | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 左側添字の追加 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 総和と積分の追加 | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| 数式配列の追加 | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| デリミタの追加 | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| バーと枠の追加 | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 項のグループ化 | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**既存の PowerPoint 数式を編集できますか？**

はい。プレゼンテーションを開き、[MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) を含むシェイプを見つけ、[getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) を呼び出して、その段落の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX に保存すると、Aspose.Slides は数式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

はい。数式の [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) をその [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) から取得し、[MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) を呼び出して直接エクスポートできます。完全な例については、[Export Math Equations from Presentations in PHP via Java](/slides/ja/php-java/exporting-math-equations/#export-math-equations-to-latex) を参照してください。