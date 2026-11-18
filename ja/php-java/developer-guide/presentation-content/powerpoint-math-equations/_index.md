---
title: PHP で PowerPoint プレゼンテーションに数式を追加
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
- 数式テキストを追加
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint の PPT および PPTX で数式を挿入・編集できます。OMML のサポート、書式設定コントロール、わかりやすい PHP コードサンプルを提供します。"
---
## **概要**

PowerPoint は数式を Office Math Markup Language (OMML) として保存します。Aspose.Slides for PHP via Java を使用すると、プログラムで同様の数式コンテンツを作成できます。分数、根号、関数、リミット、N 項演算子、行列、配列、書式設定された数式ブロックなどです。

PowerPoint で、ユーザーは通常 **挿入 > 数式** から数式を追加します：

![PowerPoint の挿入タブで数式コマンドが選択されている状態](powerpoint-math-equations_1.png)

結果はスライド上の編集可能な数式テキストです：

![編集可能な数式が含まれる PowerPoint スライド](powerpoint-math-equations_2.png)

Aspose.Slides は、以下の 3 つの主要オブジェクトを使用して数式テキストを構築します：

- 数式シェイプは、[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) で作成され、数式を含むシェイプです。
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) はシェイプのテキストフレーム内に数式コンテンツを格納します。
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) は 1 つ以上の [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) オブジェクトを含みます。

以下のほとんどの例は、[MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) と [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) の流暢なメソッドを使用して、コードを簡潔で読みやすくしています。

MathML エクスポートのシナリオについては、[Export Math Equations from Presentations in PHP via Java](/slides/ja/php-java/exporting-math-equations/) を参照してください。

## **数式の作成**

この例では [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) を使用して数式シェイプを作成し、ピタゴラスの定理を追加します：

![c² = a² + b² の式](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) は既に数式段落を含むシェイプを作成します。最初の [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) にアクセスし、[getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) を呼び出して、数式ブロックまたは数式要素を追加します。
{{% /alert %}}

## **分数の追加**

[divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) を使用して分数を作成します。[MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/) で分数のスタイルを選択できます。

![1 を x で割った斜めの分数](powerpoint-math-equations_4.png)

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

積み上げ型の分数には、[MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar) を使用します：

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **根号の追加**

[radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) を使用して平方根、立方根、その他の根号を作成します。現在の要素が底部となり、引数が指数（次数）となります。

![x が根号記号の下にある n 乗根の式](powerpoint-math-equations_5.png)

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

### **平方根の次数の表示または非表示**

平方根は明示的に 2 を表示するか、従来の √x 表記を使用できます。[MathRadical](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/) の [setHideDegree](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/#setHideDegree) メソッドでどちらの形式を使用するか制御します。どちらの形式でも次数 2 と根号内部の x は編集可能な数式に保持されます。

![左側で次数が表示され、右側で非表示の同じ平方根](square-root-degree.png)

この例では同じ平方根を 2 回保存します。`visible-degree.pptx` では 2 が表示され、`hidden-degree.pptx` では非表示になります。

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $radical = (new MathematicalText("x"))->radical("2");

    $shape = $slide->getShapes()->addMathShape(20, 20, 200, 100);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getMathParagraph()->add(new MathBlock($radical));

    $radical->setHideDegree(false);
    $presentation->save("visible-degree.pptx", SaveFormat::Pptx);

    $radical->setHideDegree(true);
    $presentation->save("hidden-degree.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **関数とリミットの追加**

関数（例：`sin(x)`, `log(x)` あるいはカスタム関数名）には、[asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) または [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) を使用します。リミットの場合は、[MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) に `lim` を入れるか、[setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit) を使用します。

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

カスタム関数名の場合、関数名を現在の要素にし、引数とともに [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) を呼び出します：

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N 項演算子と積分の追加**

合計、和集合、積集合、その他の大きな演算子には [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) を使用します。積分には [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) を使用します。どちらのメソッドも下限と上限を設定できます。

![下限と上限を持つ総和](powerpoint-math-equations_7.png)

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

N-項演算子はオプションのリミットを伴う大きな演算子用です。`+`, `-`, `=` のような単純な演算子は通常 [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) で追加し、式に結合します。

積分の場合は、[integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) を使用します：

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **行列の追加**

行と列には [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) を使用します。行列はデフォルトで括弧を含まないため、丸括弧、角括弧、波括弧が必要な場合は行列を囲んでください。

![1 つの空セルを含む 2 行の数式行列](powerpoint-math-equations_10.png)

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

### **既存の行列を編集**

線形代数のレッスンが前の例で保存された `matrix.pptx` の係数行列から始まるとします。次の演習では、最初の式を保持し、2 番目を 2 つの新しい式に置き換え、変数のセットを更新します。適用可能な係数を保持するために、[MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) を使用して既存の行列を開きます。

![元の 2 行の係数行列（1、x、空セル が最初の行、x、2、y が二行目）](matrix-before-edit.png)

行と列のインデックスは 0 から始まり、各呼び出し時の行列を指します。インデックス 1 の前に行を挿入すると、元の 2 行目がインデックス 2 に移動します。インデックス 2 の後に挿入すると行が追加されます。インデックス 2 の行を削除すると、元の 2 行目の式が削除され、追加した行が 1 つ上に移動します。列も同様にシフトします。

```php
use aspose\slides\MathematicalText;
use aspose\slides\MathHorizontalAlignment;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("matrix.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $block = $portion->getMathParagraph()->get_Item(0);
    $matrix = $block->get_Item(0);

    $matrix->insertRowBefore(1);
    $matrix->insertRowAfter(2);
    $matrix->deleteRow(2);

    $matrix->insertColumnBefore(1);
    $matrix->insertColumnAfter(3);
    $matrix->deleteColumn(3);

    // 新しいセルは最初は null です。まず非ゼロの係数を設定します。
    $matrix->set_Item(1, 0, new MathematicalText("12"));
    $matrix->set_Item(1, 1, new MathematicalText("1"));
    $matrix->set_Item(2, 2, new MathematicalText("10"));
    $matrix->set_Item(2, 3, new MathematicalText("1"));
    $rowCount = java_values($matrix->getRowCount());
    $columnCount = java_values($matrix->getColumnCount());
    for ($row = 0; $row < $rowCount; $row++) {
        for ($column = 0; $column < $columnCount; $column++) {
            $coefficient = $matrix->get_Item($row, $column);
            if (java_is_null($coefficient)) {
                $matrix->set_Item($row, $column, new MathematicalText("0"));
            }
        }
    }

    $matrix->setColumnAlignment(0, MathHorizontalAlignment::Left);
    $matrix->setColumnsAlignment(1, 3, MathHorizontalAlignment::Right);

    $presentation->save("updated-matrix.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnAlignment) は最初の列を左揃えにします。[setColumnsAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnsAlignment) はインデックス 1 から始まる連続した 3 列を右揃えにします。`updated-matrix.pptx` では、行列は 3 つの式と 4 つの変数を持ちます。元の最初の行の係数 `1` と `x` は現在、1 列目と 3 列目に表示されます。

![更新された 3 行の行列（行は 1,0,x,0；12,1,0,0；0,0,10,1）](matrix-after-edit.png)

## **数式配列の追加**

整列された式や縦に積み重ねた式が必要な場合は、[toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) を使用します。

![x が上、y が下の縦方向の数式配列](powerpoint-math-equations_11.png)

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

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) は配列の垂直位置合わせを隣接する数式要素に対して制御します。以下の例は、最初の行、配列の中央、最後の行での位置合わせを比較しています。

次の例では、3 行の同一配列を 3 つ作成し、隣接要素 `A=` と `=B` を付けています。すべての数式テキストは 24 ポイントの Cambria Math を使用します。配列の位置合わせだけが変わります。

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

以下の比較は PowerPoint で保存されたプレゼンテーションを示します。各配列の横にある `A=` と `=B` の位置に注目してください。

![PowerPoint の数式配列（上寄せ、中央寄せ、下寄せ）と同一の隣接要素](equation-array-alignment.png)

### **行間隔の設定**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) は配列内の行の間隔ルールを選択します。[setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) は明示的な間隔ルールの数値を指定し、プリセットルールでは無視されます。

正確な間隔の場合、値はポイントで測定されます。比例間隔の場合は半行単位で測定され、例の値 `3` は 1.5 行を示します。明示的な値を指定する際は両方のプロパティを設定してください。数値だけを変更しても間隔ルールは選択されません。

以下の例では、同じ式、位置合わせ、フォント設定で 5 つのプレゼンテーションを保存します。最初の 3 つはプリセットを使用し、最後の 2 つは明示的な値を示します。

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

配列の行間隔は段落間隔とは別です。[setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) と [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) は配列行間ではなく、包含する段落の前後に余白を追加します。同様に、[MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) は数式段落全体を横方向に位置付けますが、配列の垂直位置合わせ設定を置き換えるものではありません。

## **三角関数の追加**

引数が現在の要素で、関数名が分かっている場合は、[asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) を使用します。

![2x に対して cos の三角関数を適用した式](powerpoint-math-equations_6.png)

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

## **下付文字と上付文字の追加**

添字と指数には下付文字と上付文字のヘルパーを使用します。添字を基底の左側に表示する必要がある場合は、[setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) を使用します。

![左側に添字 1 と上付文字 n を持つ大文字 Y](powerpoint-math-equations_9.png)

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

[enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) を使用して式を区切り記号で囲みます。複数の要素を含む区切り式には区切り文字も設定できます。

![x、y、z を縦線で区切った区切り式](powerpoint-math-equations_13.png)

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

### **区切り記号のサイズと位置合わせ**

`true` を [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) に渡すと、背の高いオペランドに合わせて括弧が伸長します。`false` を渡すと通常サイズのままです。[setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) では、2 つの [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) のいずれかを使用します。`Centered` は等号の中央を通る数式軸上で括弧を中央揃えにし、`Match` は括弧を囲む内容に合わせます。これらの設定は区切り記号にのみ影響し、内部の式は変わりません。

例では、分数を `x` の指数に配置し、式がベースラインより上に長く伸びるようにしています。4 つの式すべてが同じ括弧とフォント設定を使用します。

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

PowerPoint で行を比較し、伸長の効果を確認してください。上段では、括弧が指数を囲むように伸長し、2 つの形状は同様に見えます。下段では伸長がオフになります。左側の小さい括弧（`Centered`）は等号に揃えられ、右側（`Match`）は式の上方に配置されます。

![PowerPoint の 4 つの式：上段は区切り記号の伸長が有効、下段は無効、左は Centered、右は Match](delimiter-sizing.png)

## **ボーダーボックスの追加**

分数に対して [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) を呼び出すと、式全体を枠で囲みます。返される [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) はデフォルトで四辺すべてを表示します。個別の辺を非表示にするには、[setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft), [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) を使用します。

この例では、同じ分数を 6 つスライドに配置します。取り消し線を示すために四辺すべてを非表示にし、上昇対角線 (↗) 用に [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) に `true` を渡すか、下降対角線 (↘) 用に [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) に `true` を渡します。また、[setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) や [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) を使用して、表示する辺の組み合わせで線を引くこともできます。

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

![PowerPoint の 6 つの編集可能な分数。上段：全枠、下部と左側、上昇対角線。下段：下降対角線、横線、縦線と全枠。](border-box-fractions.png)

この分数では、横の取り消し線が分数線と重なります。縦の取り消し線は分子と分母の両方を横切り、周囲の枠は表示されたままです。これらの線は式全体を装飾します。通常のテキストの取り消し線はテキストランの文字に適用されます。PowerPoint でプレゼンテーションを再度開いても、分子と分母は個別に編集可能です。

## **Phantom 要素で可視性とレイアウトを制御**

式を [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) でラップすると、可視性と式へのスペースへの寄与を個別に制御できます。[MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) のメソッドは以下を制御します：

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) | `false` を渡すと式が非表示になります。対応する下記メソッドで `true` が指定されない限り、サイズはレイアウトに影響します。 |
| [setZeroWidth](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroWidth) | 式の横幅を 0 とみなすことで、隣接要素を近づけられます。 |
| [setZeroAsc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroAsc) | 上昇部（ベースライン上の高さ）を 0 とみなすことで、隣接要素上部のスペースを削減できます。 |
| [setZeroDesc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroDesc) | 下降部（ベースライン下の深さ）を 0 とみなすことで、分数線や他の下側コンテンツを隣接要素に近づけられます。 |

ベースラインは通常の数学文字が置かれる基準線です。コンテンツを非表示にしてもサイズは残り、サイズをゼロにしても式は削除されません。基になる式は [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#getBase) で取得できます。[setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) に `true` を渡すと再表示され、次元設定はそのまま保持されます。

以下の例は、並列に 5 つのバリエーションを作成します：表示される分数、スペースを保持したまま非表示の分数、幅、上昇、下降のいずれかをゼロにした 3 つの非表示分数です。各バリエーションは同じ周囲式と 24 ポイントの Cambria Math を使用します。すべての数式シェイプは同じ上位置で、灰色ガイドで示されています。外側の分数の分子に phantom を配置すると、垂直レイアウトの変化が見やすくなります。

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathBlock;
use aspose\slides\MathFraction;
use aspose\slides\MathPhantom;
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

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(1000, 180, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"];

    $guide = $slide->getShapes()->addAutoShape(ShapeType::Line, 10, 60, 980, 0);
    $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    foreach ($labels as $i => $labelText) {
        $left = 10 + $i * 200;

        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $left, 10, 190, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($labelText);

        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(14);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $fractionNumerator = $createText("a+b");
        $fractionDenominator = $createText("c+d");
        $fraction = new MathFraction($fractionNumerator, $fractionDenominator);
        $phantom = new MathPhantom($fraction);
        $phantom->setShow($i === 0);
        $phantom->setZeroWidth($i === 2);
        $phantom->setZeroAsc($i === 3);
        $phantom->setZeroDesc($i === 4);

        $leftText = $createText("x+");
        $rightText = $createText("+y");
        $numerator = (new MathBlock($leftText))->join($phantom)->join($rightText);
        $denominator = $createText("z");
        $equation = new MathFraction($numerator, $denominator);

        $shape = $slide->getShapes()->addMathShape($left, 60, 190, 100);
        $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);

        $mathPortion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $mathParagraph = $mathPortion->getMathParagraph();
        $mathBlock = new MathBlock($equation);
        $mathParagraph->add($mathBlock);
    }

    $presentation->save("math-phantom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![PowerPoint の 5 つの式：表示された分数、スペースを保持した非表示分数、ZeroWidth、ZeroAsc、ZeroDesc が有効な非表示分数の比較](math-phantom.png)

## **項のグループ化**

[group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) を使用して、式の上または下にグルーピング文字を配置します。リミットを追加してグループ化された項にラベルを付けます。

![式 x + y が下にラベル any text を付けてグループ化された例](powerpoint-math-equations_15.png)

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

書式設定ヘルパーは式を明確にする場合にのみ使用してください。例として、[overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) は数式要素の上にバーを付けます。

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

### **既存の式のテキスト書式設定**

既存の式全体のテキストを書式設定するには、各数式ブロックの要素ツリーを走査します。[MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) は直接の子要素のみ返すため、再帰的に呼び出して分数、スクリプト、根号、その他の入れ子構造内のテキストに到達します。開始要素が [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) の場合も含めるために、現在の要素と子要素の両方をチェックします。

この例は、`input.pptx` に `z = xᵢ / ∛y` のような式が含まれていることを想定しています。分子に下付文字、分母に根号を持つ分数です。ブロックのトップレベル要素だけを処理すると、分数内部のテキストが見逃されます。この例は、スライドのテキストフレーム内の数式部分を見つけ、[MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) を介してブロックにアクセスし、各テキスト要素の [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) メソッドを使って [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) でフォントサイズを 28 ポイントに設定します。

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

保存されたプレゼンテーションは、処理されたすべての式の各レベルで更新されたテキスト書式設定を保持し、テキスト内容と数式構造はそのままです。

## **クイックリファレンス**

| Task | Main API |
| --- | --- |
| 数式テキストの作成 | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| 要素の結合 | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 分数の作成 | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 上付文字または下付文字の追加 | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 関数の追加 | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 根号の追加 | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| リミットの追加 | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 左側スクリプトの追加 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 総和と積分の追加 | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 行列の追加 | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| 数式配列の追加 | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 区切り記号の追加 | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| バーとボーダーの追加 | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| 項のグループ化 | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**既存の PowerPoint の数式を編集できますか？**

はい。プレゼンテーションを開き、[MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) を含むシェイプを見つけ、[getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) を呼び出して、その段落内の数式ブロックを更新します。

**数式は編集可能な PowerPoint の数式として保存されますか？**

はい。PPTX として保存すると、Aspose.Slides は数式を編集可能な Office 数式コンテンツとして書き込みます。

**数式を LaTeX にエクスポートできますか？**

はい。式の [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) をその [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) から取得し、[MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) を呼び出して直接エクスポートします。完全な例については、[Export Math Equations from Presentations in PHP via Java](/slides/ja/php-java/exporting-math-equations/#export-math-equations-to-latex) を参照してください。