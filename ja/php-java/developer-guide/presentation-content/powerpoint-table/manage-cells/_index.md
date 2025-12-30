---
title: PHPを使用してプレゼンテーションのテーブルセルを管理する
linktitle: セルを管理する
type: docs
weight: 30
url: /ja/php-java/manage-cells/
keywords:
- テーブルセル
- セル結合
- 枠線の削除
- セル分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して、PowerPoint のテーブルセルを簡単に管理できます。セルへのアクセス、変更、スタイル設定を迅速に習得し、スライドの自動化をシームレスに実現します。"
---

## **結合されたテーブルセルを特定する**
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドからテーブルを取得します。
3. テーブルの行と列をイテレートして結合セルを検索します。
4. 結合セルが見つかったときにメッセージを出力します。

この PHP コードは、プレゼンテーションで結合されたテーブルセルを特定する方法を示します。
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


## **テーブルセルの枠線を削除する**
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. 幅を指定した列の配列を定義します。
4. 高さを指定した行の配列を定義します。
5. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) メソッドを使用してスライドにテーブルを追加します。
6. 各セルをイテレートし、上・下・右・左の枠線をクリアします。
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、テーブルセルの枠線を削除する方法を示します。
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成する
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスする
    $sld = $pres->getSlides()->get_Item(0);
    # 幅を持つ列と高さを持つ行を定義する
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # スライドにテーブル シェイプを追加する
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの枠線フォーマットを設定する
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # PPTX をディスクに書き込む
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **結合セル内の番号付け**
2 つのセルペア (1, 1) x (2, 1) と (1, 2) x (2, 2) を結合すると、結果のテーブルに番号が付けられます。 この PHP コードはその手順を示します。
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成する
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスする
    $sld = $pres->getSlides()->get_Item(0);
    # 幅を持つ列と高さを持つ行を定義する
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # スライドにテーブル シェイプを追加する
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの枠線フォーマットを設定する
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
    # セル (1, 1) と (2, 1) を結合する
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # セル (1, 2) と (2, 2) を結合する
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


次に、(1, 1) と (1, 2) を結合してさらにセルを結合します。 結果として、中央に大きな結合セルを持つテーブルが生成されます。 
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成する
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスする
    $sld = $pres->getSlides()->get_Item(0);
    # 幅を持つ列と高さを持つ行を定義する
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # スライドにテーブルシェイプを追加する
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの枠線フォーマットを設定する
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
    # セル (1, 1) と (2, 1) を結合する
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # セル (1, 2) と (2, 2) を結合する
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # セル (1, 1) と (1, 2) を結合する
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # PPTX ファイルをディスクに書き込む
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **分割セル内の番号付け**
以前の例では、テーブルセルが結合されたとき、他のセルの番号付けや番号体系は変わりませんでした。

今回は、結合セルのない通常のテーブルを使用し、セル (1,1) を分割して特別なテーブルを作成します。このテーブルの番号付けは奇妙に見えるかもしれませんが、Microsoft PowerPoint がテーブルセルに番号を付ける方式であり、Aspose.Slides も同様です。

この PHP コードは、上記の手順を示します。
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成する
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスする
    $sld = $pres->getSlides()->get_Item(0);
    # 幅を持つ列と高さを持つ行を定義する
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # スライドにテーブル形状を追加する
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの枠線フォーマットを設定する
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
    # セル (1, 1) と (2, 1) を結合する
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # セル (1, 2) と (2, 2) を結合する
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # セル (1, 1) を分割する
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # PPTX ファイルをディスクに書き込む
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブルセルの背景色を変更する**
この PHP コードは、テーブルセルの背景色を変更する方法を示します。
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
5. [AddTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) メソッドを使用してスライドにテーブルを追加します。
6. 画像ファイルを保持する `Images` オブジェクトを作成します。
7. `IImage` 画像を `IPPImage` オブジェクトに追加します。
8. テーブルセルの `FillFormat` を `Picture` に設定します。
9. 画像をテーブルの最初のセルに追加します。
10. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この PHP コードは、テーブル作成時にテーブルセル内に画像を配置する方法を示します。
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成する
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスする
    $islide = $pres->getSlides()->get_Item(0);
    # 幅を持つ列と高さを持つ行を定義する
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # スライドにテーブル形状を追加する
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # 画像ファイルを使用して IPPImage オブジェクトを作成する
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 画像を最初のテーブルセルに追加する
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # PPTX ファイルをディスクに保存する
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**
**単一セルの各側面に対して異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) の枠線は個別のプロパティを持っているため、各側面の太さやスタイルを別々に設定できます。これは、記事で示されたセルごとの枠線制御から論理的に導かれます。

**画像をセルの背景として設定した後に列や行のサイズを変更すると、画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)（stretch/tile）に依存します。stretch の場合、画像は新しいセルに合わせて伸縮し、tile の場合、タイルが再計算されます。記事ではセル内の画像表示モードについて説明しています。

**セル内のすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/php-java/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（portion）レベル、またはテーブル／シェイプ全体のレベルで設定されます。実際には、リンクをテキストの一部またはセル内のすべてのテキストに割り当てます。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキストフレームは、[portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)（ラン）ごとにフォントファミリー、スタイル、サイズ、色などを個別に設定できることをサポートしています。