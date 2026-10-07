---
title: PHP を使用したプレゼンテーションのテーブルセル管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/php-java/manage-cells/
keywords:
- テーブルセル
- セルの結合
- 枠線の削除
- セルの分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP で PowerPoint のテーブルセルを管理します：結合セルの識別、枠線の削除、セルの分割、背景色と画像の設定を Aspose.Slides for PHP via Java を使用して行います。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内のテーブル セルにアクセスして変更できます。この記事では、結合されたテーブル セルの識別、セルの枠線の削除、セルの結合または分割後の番号付けの操作、セルの背景色の変更、テーブル セル内への画像の追加方法を説明します。例では、プレゼンテーションの作成または開く方法、スライドからテーブルを取得する方法、セル プロパティを介してセルの書式設定を更新する方法、および変更されたプレゼンテーションを PPTX ファイルとして保存する方法を示します。

Aspose.Slides は、テーブル セルにアクセスする際にゼロベースのインデックスを使用し、順序は`(column, row)`です。

## **結合されたテーブル セルの識別**

例では、既存のプレゼンテーションを開き、最初のスライドの最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。その後、すべての行と列を反復し、[isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) を使用して結合領域のセルを識別します。マッチする各セルについて、`row;column` の順序でセル座標を出力し、[getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)、[getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)、および領域の開始座標である [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) と [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) を取得します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **テーブル セルの枠線の削除**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) を作成し、[addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) を使用して最初のスライドにテーブルを追加します。列幅、行高さ、テーブルの位置はポイントで指定します。例では、すべての四辺のセル枠線を [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) に設定し、非表示にします。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブル セルの結合**

[mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) を使用して、テーブル セルの矩形範囲を1つのセルに結合します。範囲の左上隅と右下隅のセルを指定します。最後の引数は、結合が指定範囲外のセルを含むかどうかを制御します。`false` を指定すると、結合はその範囲内に留まります。

例では、列幅と行高さが70ポイントの4×4テーブルを作成し、`(1, 1)` から `(2, 2)` の 4 つの中心セルを結合します。結果として得られるセルは 2 列と 2 行にまたがりますが、テーブルの基礎グリッドは 4 列 4 行のままです。結合されたセルの内容や書式設定にアクセスするには、左上の位置を使用します。この例では `$table->get_Item(1, 1)` を使用します。結合範囲内の他の位置はテーブル グリッドの一部として残り、範囲外のセルのインデックスは変更されません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブル セルの分割**

前の例でセルを結合すると、テーブルのグリッドが保持されます。セルを分割すると新しいグリッド列が追加され、右側のセルの列インデックスが変わる可能性があります。Aspose.Slides は PowerPoint のテーブル グリッド モデルに従います。

この例では、列幅と行高さが70ポイントの4×4テーブルを作成し、セル `(1, 1)` に対して [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) を呼び出します。セルの幅70ポイントの半分を渡して、幅が等しい 2 つのセルを作成します。

この分割後、2 つの半分は `$table->get_Item(1, 1)` と `$table->get_Item(2, 1)` でアクセスできます。テーブル グリッドは現在 5 列になり、元々列 2 と 3 にあったセルはそれぞれ列 3 と 4 に移動します。行インデックスは変わりません。分割後にセルにアクセスする際は、これら更新された列インデックスを使用してください。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **行または列のスパンで結合セルを分割**

結合テンプレート セルをデータ入力用に準備するには、既存の行境界に沿って分割するために [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) を、列境界に沿って分割するために [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) を使用します。

`index` 引数は、分割上部の行または左側の列の数をカウントし、結合領域に対して相対的です：

- 行の分割: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)。
- 列の分割: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)。

例では、プレゼンテーションの最初のスライドの最初のシェイプがテーブルであり、`(1, 2)` と `(1, 3)` が縦に結合されていることを想定しています。下側の位置から開始し、[getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) と [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) を使用して起点を特定し、両方のスパンを確認します。`splitByRowSpan(1)` は製品名用に行 2 と 3 を分離します。横方向に 2 列結合する場合は、代わりに `splitByColSpan(1)` を使用します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // 分割後、テーブルから結果のセルを取得します。
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

テーブル グリッドと周囲のセル インデックスは変更されません。結果のセルは座標で取得します。ここでは、両方ともスパンが 1 で、[isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) は `false` を出力します。より大きな領域は、1 回の分割後も部分的に結合されたままになることがあります。

元のテキストと書式設定は上部（または左側）のセルに残り、新しいセルは空ですが、塗りつぶし、枠線、余白などのセル書式設定を継承します。分割後にセルにデータを入力し、必要なテキスト書式設定を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式設定が保持されたままの "Product A" と "Product B" の個別セルが含まれます。詳細は [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) を参照してください。

## **テーブル セルの背景色の変更**

この例では、列幅150ポイント、行高さ50ポイントのテーブルを作成します。[setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) を使用して実体塗りを選択し、[getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) が返す色をセル `(2, 3)`（第3列・第4行）の赤に設定します。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブル セル内への画像追加**

この例を実行する前に、入力画像を作業ディレクトリに配置してください。[Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) で画像を読み込み、[addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) を使用してプレゼンテーションの画像コレクションに追加します。その後、画像をセル `(0, 0)`（テーブルの最初のセル）の画像塗りつぶしに割り当てます。

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) は画像を伸張してセルを埋めますが、アスペクト比が変わる可能性があります。列幅と行高さはポイントで指定します。ロードされた画像は、プレゼンテーションに追加された後、`finally` ブロックで破棄されます。

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**単一セルの各側面につき異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) の枠線は個別のプロパティを持つため、各側面の太さやスタイルを異ならせることが可能です。

**画像をセルの背景として設定した後に列・行のサイズを変更するとどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) に依存します。stretch（伸張）を使用すると、画像は新しいセルサイズに合わせて調整されます。tile（タイル）を使用すると、タイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを割り当てられますか？**

[Hyperlinks](/slides/ja/php-java/manage-hyperlinks/) は、セルのテキストフレーム内のテキスト（部分）レベル、またはテーブル/シェイプ全体のレベルで設定されます。実際には、リンクをセル内の一部のテキストまたはすべてのテキストに割り当てます。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキストフレームは、[portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)（ラン）ごとにフォントファミリー、スタイル、サイズ、色などの書式設定を個別に持つことができます。