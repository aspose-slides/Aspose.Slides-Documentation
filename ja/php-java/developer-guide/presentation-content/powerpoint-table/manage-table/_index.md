---
title: PHP でプレゼンテーション テーブルを管理する
linktitle: テーブルを管理する
type: docs
weight: 10
url: /ja/php-java/manage-table/
keywords:
- テーブルを追加
- テーブルを作成
- テーブルにアクセス
- アスペクト比
- テキストの配置
- テキストの書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint スライドのテーブルを作成および編集します。テーブル操作を効率化するシンプルなコード例をご紹介します。"
---
## **概要**

PowerPoint の表は情報を行と列に整理し、値を読み取りやすく比較しやすくします。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) クラス、[Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) クラス、およびその他のタイプを提供し、プレゼンテーション内の表を作成、更新、管理できるようにします。

## **テーブルを最初から作成する**

位置、列幅、行高さを指定してテーブルを作成します。スライドに追加した後、セルの罫線を書式設定したり、セルを結合したり、テキストを挿入したりできます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 列幅をポイント単位の配列で定義します。
4. 行高さをポイント単位の配列で定義します。
5. スライドに [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) オブジェクトを [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) メソッドで追加します。
6. [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) をそれぞれ反復処理し、上、下、右、左の罫線に書式設定を適用します。
7. テーブルの最初の行の最初の 2 つのセルを結合します。
8. 結合されたセルを [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) メソッドで取得します。
9. 結合セルのテキストを設定します。
10. 変更されたプレゼンテーションを保存します。

以下の例は、(100, 50) ポイントの位置に列が 3、行が 5 のテーブルを作成します。幅 5 ポイントの赤い罫線を適用し、最初の行の最初の 2 つのセルを結合し、結果を `table.pptx` として保存します。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **標準テーブルの番号付け**

標準テーブルでは、セルインデックスは 0 から始まり、順序は (列, 行) です。最初のセルは (0, 0) とインデックス付けされます。

たとえば、4 列 4 行のテーブルのセルは次のように番号付けされます。

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この例は、上図の 4 × 4 テーブルを作成し、列幅と行高さを 70 ポイント、幅 5 ポイントの赤い罫線で設定します。座標はセルインデックスを示しています。セルは空のままにし、テーブルを `StandardTables_out.pptx` として保存します。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **既存のテーブルにアクセスする**

テーブルはスライドのシェイプ コレクションに格納されます。シェイプを反復処理してテーブルを見つけ、[Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) クラスを使用してセルを読み取ったり更新したりします。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. インデックスでテーブルを含むスライドへの参照を取得します。
3. [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) オブジェクトを反復処理し、テーブルが見つかった時点で停止します。スライドに複数のテーブルがある場合は、[getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) を使用して目的のテーブルを識別します。
4. 対象セルのテキストを更新します。
5. 変更されたプレゼンテーションを保存します。

以下の例は `UpdateExistingTable.pptx` を開き、最初のスライドの最初のテーブルを見つけます。列 0、行 1 のセルに `New` を設定し、結果を `table1_out.pptx` として保存します。入力ファイルは少なくとも 1 枚のスライドを含み、そのスライドの最初のテーブルは少なくとも 1 列 2 行を持つ必要があります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

既存のテーブルで行のサイズを変更し、実際の高さが要求された最小値を超える理由を理解するには、[Control Row Height](/slides/ja/php-java/manage-rows-and-columns/#control-row-height) を参照してください。

## **テキストフレームを所有するセルを見つける**

テーブルから取得した [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) に対して汎用的なテキスト処理コードが受け取った場合は、[TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) メソッドを使用して所有する [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) を取得します。テーブルセルのテキストフレームの場合、[TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) は所有者を返し、[TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) は `null` を返します。テーブル自体はシェイプですが、このような動作になります。

セルの座標は読み取り専用の [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) と [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) メソッドで取得できます。[TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) は所有者を返すだけで所有権を変更しない読み取り専用ナビゲーションも提供します。使用する前に必ず `java_is_null` で返されたセルをチェックしてください。

テーブルセルとシェイプの所有者、SmartArt ノードに関連付けられたシェイプを識別する完全な例については、[Search and Replace Text](/slides/ja/php-java/search-and-replace-text/) を参照してください。

## **テーブル内のテキストを配置する**

個々のテーブルセルの垂直アンカーとテキスト方向を制御できます。このセクションの例では、最初のセル内のテキストを中央揃えにし、270 度回転させます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) オブジェクトを追加します。
4. テーブルから [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) オブジェクトを取得します。
5. 最初の [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) にアクセスし、テキストと色を設定します。
6. [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) と [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) を使用してセルの垂直アンカーとテキスト方向を設定します。
7. 変更されたプレゼンテーションを保存します。

この例は列幅 120 ポイント、行高さ 100 ポイントの 4 × 4 テーブルを作成し、セル (0, 0) のテキストをフォーマットし、最初の行の残りのセルに値を追加して、`Vertical_Align_Text_out.pptx` として保存します。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブルレベルでテキスト書式設定を行う**

[setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) を使用して、テーブル内のすべてのセルにテキスト書式設定を適用できます。オーバーロードにより、部分、段落、テキストフレームの書式設定を受け取るため、個々のセルを反復処理せずにこれらのプロパティを設定できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. インデックスでスライドへの参照を取得します。
3. スライドから [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) オブジェクトを取得します。
4. テキストのフォントサイズを [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) で設定します。
5. [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) と [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) を使用して段落の揃えと右余白を設定します。
6. [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) でテキスト方向を設定します。
7. 変更されたプレゼンテーションを保存します。

以下の例は `table.pptx` を開きます。このファイルは少なくとも 1 枚のスライドを含み、最初のシェイプがテーブルである必要があります。フォントサイズを 25 ポイントに設定し、右余白 20 ポイントで段落を右揃えにし、テキストを縦方向にします。書式設定されたプレゼンテーションは `result.pptx` として保存されます。

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブルスタイル プロパティの取得**

[getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) を使用してテーブルのプリセットスタイルを読み取り、[setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) で割り当てます。この例では [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) を 1 つのテーブルに適用し、プリセット値を出力し、同じプリセットを 2 番目のテーブルに割り当てます。両方のテーブルは `table-style.pptx` に保存されます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブルの縦横比を固定する**

テーブルの縦横比は幅と高さの比率です。[setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) を使用してこの比率をロックできます。

以下の例は `pres.pptx` を開きます。このファイルは少なくとも 1 枚のスライドを含み、最初のシェイプがテーブルである必要があります。現在のロック状態を出力し、縦横比ロックを有効にして、更新された状態 (`true`) を出力し、結果を `pres-out.pptx` として保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **よくある質問**

**テーブル全体およびセル内のテキストに対して右から左 (RTL) の読み取り方向を有効にできますか？**

はい。テーブルは [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) メソッドを公開しており、段落には [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/) があります。両方を使用することで、セル内で正しい RTL の順序と描画が保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするにはどうすればよいですか？**

[shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) を設定できます。画像は選択されたモード（ストレッチまたはタイル）に従ってセル領域全体を覆います。