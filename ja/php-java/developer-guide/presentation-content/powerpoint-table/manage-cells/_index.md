---
title: PHP を使用したプレゼンテーションでのテーブルセルの管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/php-java/manage-cells/
keywords:
- テーブルセル
- セルの結合
- 罫線の削除
- セルの分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して、PowerPoint のテーブルセルを簡単に管理できます。セルへのアクセス、変更、スタイリングを迅速にマスターし、スライドの自動化をシームレスに実現します。"
---

## **マージされたテーブルセルを特定する**
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドからテーブルを取得します。 
3. テーブルの行と列を走査してマージされたセルを検出します。
4. マージされたセルが見つかったらメッセージを出力します。

この PHP コードは、プレゼンテーション内でマージされたテーブルセルを特定する方法を示しています:
```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// Slide#0.Shape#0 がテーブルであると想定しています

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブルセルの罫線を削除する**
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。 
3. 幅を指定した列の配列を定義します。
4. 高さを指定した行の配列を定義します。
5. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addTable) メソッドを使用してスライドにテーブルを追加します。
6. 各セルを走査し、上・下・右・左の罫線をクリアします。
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、テーブルセルの罫線を削除する方法を示しています:
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # 列幅と行高さを定義します
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # スライドにテーブル シェイプを追加します
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの罫線フォーマットを設定します
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # PPTX をディスクに書き込みます
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **マージされたセルの番号付け**
2 つのセルペア (1, 1) x (2, 1) と (1, 2) x (2, 2) をマージすると、結果のテーブルに番号が付けられます。この PHP コードはその手順を示しています:
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # 列幅と行高さを定義します
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # スライドにテーブル シェイプを追加します
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの罫線フォーマットを設定します
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # セル (1, 1) と (2, 1) を結合します
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # セル (1, 2) と (2, 2) を結合します
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


その後、セル (1, 1) と (1, 2) をさらにマージします。結果は、中央に大きなマージセルを持つテーブルになります: 
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # 列幅と行高さを定義します
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # スライドにテーブル シェイプを追加します
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの罫線フォーマットを設定します
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # セル (1, 1) と (2, 1) を結合します
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # セル (1, 2) と (2, 2) を結合します
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # セル (1, 1) と (1, 2) を結合します
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # PPTX ファイルをディスクに書き込みます
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **分割されたセルの番号付け**
前の例では、テーブルセルをマージしても、他のセルの番号付けや番号体系は変わりませんでした。

今回は、マージされていない通常のテーブルを使用し、セル (1,1) を分割して特別なテーブルを作成します。このテーブルの番号付けは奇妙に見えるかもしれませんが、これは Microsoft PowerPoint がテーブルセルに付与する番号付け方式であり、Aspose.Slides も同様です。

この PHP コードは、上記の手順を実演しています:
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # 列幅と行高さを定義します
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # スライドにテーブル シェイプを追加します
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの罫線フォーマットを設定します
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # セル (1, 1) と (2, 1) を結合します
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # セル (1, 2) と (2, 2) を結合します
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # セル (1, 1) を分割します
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # PPTX ファイルをディスクに書き込みます
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブルセルの背景色を変更する**

この PHP コードは、テーブルセルの背景色を変更する方法を示しています:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # 新しいテーブルを作成する
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # セルの背景色を設定する
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **テーブルセル内に画像を追加する**
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. 幅を指定した列の配列を定義します。
4. 高さを指定した行の配列を定義します。
5. [AddTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addTable) メソッドを使用してスライドにテーブルを追加します。
6. 画像ファイルを保持する `Images` オブジェクトを作成します。
7. `IImage` 画像を `IPPImage` オブジェクトに追加します。
8. テーブルセルの `FillFormat` を `Picture` に設定します。
9. 画像をテーブルの最初のセルに追加します。
10. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、テーブル作成時にテーブルセル内に画像を配置する方法を示しています:
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $islide = $pres->getSlides()->get_Item(0);
    # 列幅と行高さを定義します
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # スライドにテーブル シェイプを追加します
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # 画像ファイルを使用して IPPImage オブジェクトを作成します
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 画像を最初のテーブルセルに追加します
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # PPTX ファイルをディスクに保存します
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**単一セルの異なる側面に対して異なる線の太さやスタイルを設定できますか？**

はい。上部[borderTop](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)、下部[borderBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)、左側[borderLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)、右側[borderRight](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) の罫線は個別のプロパティを持っているため、各側面の太さとスタイルを別々に設定できます。

**セルの背景に画像を設定した後で列/行のサイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)（ストレッチ/タイル）に依存します。ストレッチの場合、画像は新しいセルサイズに合わせて調整され、タイルの場合はタイルが再計算されます。記事ではセル内の画像表示モードについて説明しています。

**セル内のすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/php-java/manage-hyperlinks/) は、セルのテキストフレーム内のテキスト（部分）レベル、またはテーブル/シェイプ全体のレベルで設定できます。実際には、部分またはセル内のすべてのテキストに対してリンクを割り当てます。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキストフレームは、フォントファミリ、スタイル、サイズ、色が個別に設定可能な [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)（ラン）をサポートしています。