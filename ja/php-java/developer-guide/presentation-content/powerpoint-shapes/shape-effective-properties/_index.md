---
title: PHP でプレゼンテーションからシェイプの有効プロパティを取得
linktitle: 有効プロパティ
type: docs
weight: 50
url: /ja/php-java/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライト リグ
- ベベル シェイプ
- テキスト フレーム
- テキスト スタイル
- フォント 高さ
- 塗りつぶし 形式
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 向け Aspose.Slides を使用し、PowerPoint プレゼンテーションにおけるシェイプのローカル、継承、および有効な書式設定を区別する方法を学びます。"
---
## **ローカル、継承、および有効なプロパティの理解**

PowerPoint の書式設定は複数の場所から取得されます。オブジェクトに直接保存されている値は **ローカル値** です。その値が設定されていない場合、PowerPoint は段落のデフォルト、テキストスタイル、レイアウトまたはマスタースライド、テーマ、またはプレゼンテーションレベルのデフォルトなどの親書式設定ソースを参照します。これらの値は **継承値** です。階層全体が解決された後に残る値が **有効値** であり、オブジェクトの描画に使用される値です。

たとえば、テキストの一部はフォントの高さを独自に定義していない場合があります。そのローカル [getFontHeight](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/) の値は `NAN` となり、これは「ここでは設定されていない」ことを意味します。その部分は段落やプレゼンテーションのデフォルトテキストスタイル、または他の適用可能なソースから高さを継承できます。部分フォーマットで [getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/geteffective/) を呼び出すと、最終的に解決された高さが返されます。

異なる目的で 2 種類の書式設定データを使用します：

- 値が定義されている場所を制御したい場合は、[PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/) のようなローカル書式オブジェクトを読み取るか変更します。
- 最終的なレンダリング結果が必要な場合は、[data returned by PortionFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/geteffective/) のような有効データオブジェクトを読み取ります。有効データは読み取り専用です。

サンプルを実行する前に、[install Aspose.Slides for PHP via Java](/slides/ja/php-java/installation/) を実行してください。

## **ローカル、継承、および有効な値の比較**

以下の完全な例はシェイプを作成し、プレゼンテーション、段落、部分の各レベルでフォント高さを適用します。各ステップでそれらのレベルで定義された値と、同じテキスト部分の結果として得られる有効値を出力します。また、書式設定の変更後に有効データを再取得する必要がある理由も示しています。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // 前の変更の後に有効なデータを読み取ります。
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // 2 つの異なるレベルで継承値を定義します。
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // 部分のローカル値が継承された両方の値を上書きします。
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // 継承された値を変更しても、既存のローカル値は上書きされません。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // ローカル値をクリアします。部分は再び段落から継承します。
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // 段落の値をクリアします。プレゼンテーションのデフォルトが結果を提供します。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

この例での優先順位は、部分のローカル書式、次に段落書式、そしてプレゼンテーションのデフォルトです。その他のオブジェクトでも継承チェーンは異なる場合がありますが、原則は同じです。より具体的な明示的な値が勝ち、[getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/geteffective/) が最終結果を返します。

## **有効なテキストプロパティの取得**

テキストの書式設定は複数のオブジェクトに分割されています：

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/geteffective/) は、余白、アンカリング、自動調整、垂直テキスト方向などのテキストフレームのプロパティを解決します。
- [TextStyle.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textstyle/geteffective/) は、各テキストスタイルレベルの段落書式を解決します。
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/geteffective/) は、配置、インデント、箇条書きなどの段落プロパティを解決します。
- [PortionFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/geteffective/) は、フォント高さ、書体、色、太字、斜体などの文字プロパティを解決します。

次の例では、`text-formatting.pptx` に少なくとも 1 枚のスライドと、空でないテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) が必要です。AutoShape はシェイプコレクションの任意の位置に配置でき、コードは適切なオブジェクトを検索し、使用前に検証します。

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **有効な 3D プロパティの取得**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/geteffective/) は、解決されたすべての 3D 設定をまとめた 1 つの有効データオブジェクトを返します。その [getCamera](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/geteffective/)、[getLightRig](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/geteffective/)、[getBevelTop](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/geteffective/)、および [getBevelBottom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/geteffective/) メソッドは、対応する有効データを公開します。これらの関連設定をまとめて読むことで、シェイプの最終的な 3D 外観を理解しやすくなります。

この例では、`shape-3d.pptx` に最初のスライドに少なくとも 1 つのシェイプが含まれている必要があります。デフォルト以外の値を出力に含めたい場合は、そのシェイプに 3D カメラ、照明、またはベベル設定を適用してください。

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **有効なテーブル書式の取得**

テーブルの書式設定はテーブルスタイルと、テーブル全体、列、行、個々のセルに適用された書式の両方から取得できます。明示的に定義された塗りつぶしが競合する場合、優先順位はセル、行、列、そしてテーブル全体の順です。セルの有効書式は、そのセルを描画する際に使用される最終的な書式です。

この例では、`table-formatting.pptx` に最初のスライドに少なくとも 1 つのテーブルが含まれている必要があります。テーブルは少なくとも 1 行と 1 列を持っている必要があります。コードは `getShapes()->get_Item(0)` がテーブルであると仮定せず、[Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/table/) を検索します。

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

色が必要で塗りつぶしタイプだけでは足りない場合は、まず有効な [getFillType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/geteffective/) の値を確認し、次にそのタイプに対応するメソッドを読み取ります。たとえば、単色塗りつぶしの場合は [getSolidFillColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/geteffective/) を使用します。

## **変更後に有効データを再取得する**

有効データは解決時点の書式階層を表します。階層に参加できる要素を変更した後は、`getEffective` を再度呼び出してください。対象となる要素は次のとおりです：

- オブジェクトのローカル書式
- 段落またはテキストフレームのデフォルト
- テーブルスタイル、テーブル、列、行、セルの書式
- レイアウトまたはマスタースライドの書式
- テーマデータまたはプレゼンテーションレベルのデフォルト
- スライドに割り当てられたレイアウトまたはマスター

有効データオブジェクトを永続的なスナップショットとして保持しないでください。Aspose.Slides は内部で一部の有効データをキャッシュする可能性があり、後続の `getEffective` 呼び出しでそのデータが更新されます。変更前後の値を比較する必要がある場合は、フォント高さ、色、配置、ベベル幅など必要なスカラー値を自分の変数にコピーしてから変更を行ってください。

値を変更するには、適切なローカル書式オブジェクトを更新し、`getEffective` を呼び出して結果を確認します。有効データオブジェクト自体は読み取り専用です。

## **FAQ**

**有効値を提供したレベルはどうやって判別できますか？**

有効データには最終値しか含まれず、ソースは示されません。最も具体的なレベルから外側へ向かって該当するローカルオブジェクトを調べます。テキストの場合は、部分、段落、テキストフレーム、レイアウト、マスター、テーマ、プレゼンテーションのデフォルトが対象です。`NAN` や `null` など未定義の値は、検索がさらに上位のレベルへ続くことを示します。

**どのレベルもプロパティを定義していない場合はどうなりますか？**

Aspose.Slides は適切な PowerPoint またはライブラリのデフォルトを解決します。その解決された値が有効データに表示され、ローカルオブジェクトが明示的に定義していなくても有効になります。

**有効値がローカル値と同じになることはなぜですか？**

ローカル値が継承計算で勝ったことを示します。オブジェクトに明示的に設定され、より具体的なルールが上書きしなかった場合に起こります。

**ローカルデータと有効データはどちらを使うべきですか？**

ローカルデータは特定の書式レベルを調査・編集する際に使用します。継承、テーマ規則、適用スタイルがすべて解決された最終的な外観が必要な場合は有効データを使用します。[完全な比較例](#compare-local-inherited-and-effective-values) では、同一ワークフローで両方を示しています。