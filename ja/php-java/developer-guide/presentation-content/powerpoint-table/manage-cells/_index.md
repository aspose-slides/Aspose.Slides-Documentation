---
title: PHP を使用したプレゼンテーションのテーブル セルの管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/php-java/manage-cells/
keywords:
- テーブル セル
- セルの結合
- 枠の削除
- セルの分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP で PowerPoint のテーブル セルを管理します: 結合されたセルの識別、枠の削除、セルの分割、背景色と画像の設定を Aspose.Slides for PHP via Java で行います。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内のテーブル セルにアクセスして変更できます。本記事では、結合されたテーブル セルの識別、セル枠の削除、結合または分割後のセル番号の操作、セルの背景色の変更、テーブル セル内への画像の追加方法について説明します。例では、プレゼンテーションの作成またはオープン、スライドからテーブルの取得、セル プロパティによるセル書式設定の更新、変更されたプレゼンテーションの PPTX ファイルへの保存方法を示しています。

Aspose.Slides は、テーブル セルへのアクセスにゼロベースのインデックス `(column, row)` を使用します。

## **結合されたテーブル セルの識別**

この例は既存のプレゼンテーションを開き、最初のスライドの最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。その後、すべての行と列を走査し、[isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) を使用して結合領域のセルを識別します。該当するセルが見つかると、`row;column` の順序でセル座標と、[getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)、[getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)、および領域の開始座標である [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) と [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) を出力します。

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

## **テーブル セル枠の削除**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) を作成し、[addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) で最初のスライドにテーブルを追加します。列幅、行高さ、テーブルの位置はポイントで指定します。この例では、すべてのセル枠を [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) に設定し、枠を非表示にします。

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

## **対角線セル枠の追加**

[getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) を使用して左上から右下へ線を描画し、[getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) を使用して左下から右上へ線を描画します。対角線はコーナー ヘッダーを示すことができ、両方の対角線を組み合わせて「該当なし」セルを示す X を作成できます。

各対角線は個別の [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) を持ちます。その [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) で [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) を使用して [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) を選択し、[getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) で色を指定します。線の太さは [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) でポイント単位で設定します。

この例では、1 行に 3 つのセルを作成します。赤い下向き対角線、青い上向き対角線、そして両方の対角線です。上下左右のセル枠は変更しません。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

対角線はセルの書式設定のみを変更します。各セルは単一のテキスト フレームを保持し、[getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) でアクセスできます。対角線の両側の領域は個別に編集できません。

Microsoft PowerPoint でレンダリングされた保存済みテーブル:

![左上から右下へ赤い対角線、左下から右上へ青い対角線、そして両方の対角線で X を形成する 3 つのテーブル セル。](diagonal-cell-borders.png)

*左から右へ: 下向き対角線 (赤、3 pt)、上向き対角線 (青、5 pt)、両方の対角線。*

## **テーブル セルの結合**

[mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) を使用して、矩形領域のテーブル セルを 1 つのセルに結合します。領域の左上隅と右下隅のセルを指定します。最後の引数は、結合が指定領域外のセルを含むかどうかを制御します。`false` を指定すると結合はその領域内に留まります。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、`(1, 1)` から `(2, 2)` の 4 つの中央セルを結合します。結果のセルは 2 列 × 2 行にまたがりますが、テーブルの基礎グリッドは 4 列 × 4 行のままです。結合セルの内容や書式にアクセスするには、左上位置 `$table->get_Item(1, 1)` を使用します。結合範囲外のセルインデックスは変わりません。

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

前の例でセルを結合すると、テーブルのグリッドは保持されます。セルを分割すると新しいグリッド列が導入され、右側のセルの列インデックスが変更されることがあります。Aspose.Slides は PowerPoint のテーブル グリッド モデルに従います。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、セル `(1, 1)` に対して [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) を呼び出します。セルの幅 70 ポイントの半分を渡して、幅が等しい 2 つのセルを作成します。

分割後、2 つの半分は `$table->get_Item(1, 1)` と `$table->get_Item(2, 1)` でアクセスできます。テーブル グリッドは現在 5 列になり、元々列 2 と 3 にあったセルはそれぞれ列 3 と 4 に移動します。行インデックスは変更されません。分割後にセルにアクセスする際は、更新された列インデックスを使用してください。

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

<!-- visual-explanation:manage-cells:start -->
[![結合されていない 70 ポイントのセルが 2 つの 35 ポイントセルに分割され、5 番目のグリッド列が追加され、右側のインデックスがシフトします。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*幅の分割はセル (1, 1) に影響し、ゼロベースの (column, row) インデックスを使用します。他の行は両方の新しい列位置にまたがるセルを保持します。*
<!-- visual-explanation:manage-cells:end -->

### **行または列のスパンで結合セルを分割する**

データ入力のために結合テンプレートセルを準備するには、[splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) を使用して既存の行境界に沿って分割するか、[splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) を使用して列境界に沿って分割します。

`index` 引数は、分割の上部部分の行または左部部分の列をカウントし、結合領域に対して相対的です。

- 行の分割: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)。
- 列の分割: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)。

この例は、プレゼンテーションに最初のスライドの最初のシェイプとしてテーブルがあり、`(1, 2)` と `(1, 3)` が垂直に結合されていることを前提とします。下部位置から開始し、[getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) と [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) を使用して起点を特定し、両方のスパンを確認します。`splitByRowSpan(1)` は製品名用に行 2 と 3 を分離します。水平の 2 列結合の場合は `splitByColSpan(1)` を使用します。

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

テーブル グリッドと周囲のセルインデックスは変更されません。結果のセルは座標で取得できます。ここでは両方のセルのスパンは 1 で、[isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) は `false` を返します。1 回の分割後も、領域の一部が結合されたままになることがあります。

元のテキストと書式は上部（または左部）のセルに残り、新しいセルは空ですが、塗りつぶし、枠、余白などのセル書式を継承します。分割後にセルにデータを入力し、必要に応じてテキスト書式を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式が保持されたまま、別々の「Product A」および「Product B」セルが含まれます。詳細は [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) を参照してください。

### **特定の高さでセルを分割する**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) は上部の高さ（ポイント）を受け取り、[splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) は上部に含める既存グリッド行数を受け取ります。右側の列で 40 ポイントのセルを中央に配置するには、セルの実際の高さから 40 を引き、残りのスペースを上下に均等に分割します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

最初の分割でグリッド行が追加され、セル `(1, 1)` の下部は 90 ポイントのまま残ります。2 回目の分割でそのセルを 40 ポイントの中間セルと 50 ポイントの下部セルに分割します。右側の列は上から下へ 50、40、50 ポイントの 3 つのセルになります。左側のセルは 3 行すべてに跨り、元の高さ 140 ポイントを保持します。

![左側のセルがテーブル全体の高さを占め、中央に「Middle」セルがある 3 つの右側セル。](split-by-height.png)

## **テーブル セルの背景色の変更**

この例では、列幅 150 ポイント、行高さ 50 ポイントのテーブルを作成します。[setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) で塗りつぶしタイプを実体塗りに設定し、[getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) が返す色を赤に設定して、セル `(2, 3)`（3 列目、4 行目）の背景色を変更します。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 51, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブル セル内に画像を追加する**

この例を実行する前に、入力画像を作業ディレクトリに配置してください。[Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) で画像を読み込み、[addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) でプレゼンテーションの画像コレクションに追加します。その後、画像をセル `(0, 0)`（テーブルの最初のセル）の画像塗りつぶしに割り当てます。

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) は画像をセル全体に伸ばすため、アスペクト比が変わることがあります。列幅と行高さはポイントで指定します。読み込んだ画像は、プレゼンテーションに追加した後、`finally` ブロックで破棄されます。

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

**単一セルの各辺に対して異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)、[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)、[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)、[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) の各枠は個別のプロパティを持つため、各辺の太さやスタイルを別々に設定できます。

**セルの背景に画像を設定した後、列・行サイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)（stretch/​tile）に依存します。stretch の場合、画像は新しいセルサイズに合わせて調整され、tile の場合はタイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを割り当てられますか？**

[Hyperlinks](/slides/ja/php-java/manage-hyperlinks/) はセルのテキスト フレーム内のテキスト（部分）レベル、またはテーブル/シェイプ全体のレベルで設定します。実際には、セル内のテキスト全体または部分にリンクを割り当てます。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキスト フレームは、フォント ファミリ、スタイル、サイズ、色などを個別に設定できる [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)（ラン）をサポートしています。