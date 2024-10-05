---
title: テーブルの管理
type: docs
weight: 10
url: /php-java/manage-table/
keywords: "テーブル、テーブルの作成、テーブルへのアクセス、テーブルのアスペクト比、PowerPointプレゼンテーション、Java、Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションにおけるテーブルの作成と管理"
---

PowerPointのテーブルは、情報を表示し表現する効率的な方法です。セルのグリッド内の情報（行と列に配置されている）は、わかりやすく、理解しやすいものです。

Aspose.Slidesは、[Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table)クラス、[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)インターフェース、[Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)クラス、[ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/)インターフェース、その他の種類を提供し、さまざまなプレゼンテーションでテーブルを作成、更新、管理できるようにします。

## **最初からテーブルを作成する**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)オブジェクトを、[addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-)メソッドを使用してスライドに追加します。
6. 各[ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/)を反復し、上部、下部、右側、左側の境界線に書式設定を適用します。
7. テーブルの最初の行の最初の2つのセルをマージします。
8. [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/)の[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)にアクセスします。
9. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)にテキストを追加します。
10. 修正したプレゼンテーションを保存します。

このPHPコードは、プレゼンテーションにテーブルを作成する方法を示しています：

```php
  # PPTXファイルを表すPresentationクラスをインスタンス化します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # 幅を持つ列と高さを持つ行を定義します
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # スライドにテーブルの形状を追加します
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの境界線の書式を設定します
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # 行1のセル1と2をマージします
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # マージされたセルにテキストを追加します
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("マージされたセル");
    # プレゼンテーションをディスクに保存します
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **標準テーブルの番号付け**

標準テーブルでは、セルの番号付けは簡単で、ゼロベースです。テーブルの最初のセルは0,0（列0、行0）としてインデックス付けされます。

たとえば、4列4行のテーブルのセルは次のように番号付けされます：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

このPHPコードは、テーブル内のセルの番号付けを指定する方法を示しています：

```php
  # PPTXファイルを表すPresentationクラスをインスタンス化します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # 幅を持つ列と高さを持つ行を定義します
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # スライドにテーブルの形状を追加します
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの境界線の書式を設定します
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
    # プレゼンテーションをディスクに保存します
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **既存のテーブルにアクセスする**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。

2. インデックスを通じてテーブルを含むスライドの参照を取得します。

3. [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)オブジェクトを作成し、nullに設定します。

4. テーブルが見つかるまで、すべての[IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/)オブジェクトを反復します。

   もしあなたが扱っているスライドが単一のテーブルを含んでいると思われる場合、含まれているすべての形状を確認するだけで済みます。形状がテーブルとして識別された場合、[Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table)オブジェクトとして型変換できます。しかし、扱っているスライドが複数のテーブルを含んでいる場合は、[setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-)を通じて必要なテーブルを検索する方が良いでしょう。

5. [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)オブジェクトを使用してテーブルを操作します。以下の例では、テーブルに新しい行を追加しました。

6. 修正したプレゼンテーションを保存します。

このPHPコードは、既存のテーブルにアクセスして操作する方法を示しています：

```php
  # PPTXファイルを表すPresentationクラスをインスタンス化します
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # nullのTableExを初期化します
    $tbl = null;
    # 形状を反復し、見つかったテーブルへの参照を設定します
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # 2行目の最初の列のテキストを設定します
        $tbl->get_Item(0, 1)->getTextFrame()->setText("新しい");
      }
    }
    # 修正したプレゼンテーションをディスクに保存します
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テーブル内のテキストを整列させる**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. スライドに[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)オブジェクトを追加します。
4. テーブルから[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)オブジェクトにアクセスします。
5. [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)の[IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/)にアクセスします。
6. テキストを垂直に整列させます。
7. 修正したプレゼンテーションを保存します。

このPHPコードは、テーブル内のテキストを整列させる方法を示しています：

```php
  # Presentationクラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $slide = $pres->getSlides()->get_Item(0);
    # 幅を持つ列と高さを持つ行を定義します
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # スライドにテーブルの形状を追加します
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # テキストフレームにアクセスします
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # テキストフレームのためのParagraphオブジェクトを作成します
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # 段落のためのPortionオブジェクトを作成します
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("ここにテキスト");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # テキストを垂直に整列させます
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # プレゼンテーションをディスクに保存します
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テーブルレベルでのテキストの書式設定を設定する**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. スライドから[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)オブジェクトにアクセスします。
4. テキストの[setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-)を設定します。
5. [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-) を設定します。
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)を設定します。
7. 修正したプレゼンテーションを保存します。

このPHPコードは、テーブル内のテキストに好みの書式オプションを適用する方法を示しています：

```php
  # Presentationクラスのインスタンスを作成します
  $pres = new Presentation("simpletable.pptx");
  try {
    # 最初のスライドの最初の形状がテーブルであると仮定します
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # テーブルセルのフォントの高さを設定します
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # テーブルセルのテキストの整列と右余白を一度の呼び出しで設定します
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # テーブルセルのテキストの垂直タイプを設定します
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テーブルスタイルプロパティを取得する**

Aspose.Slidesを使用すると、テーブルのスタイルプロパティを取得して、他のテーブルや別の場所でその詳細を使用することができます。このPHPコードは、テーブルプリセットスタイルからスタイルプロパティを取得する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// デフォルトのスタイルプリセットテーマを変更します

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テーブルのアスペクト比をロックする**

幾何学的形状のアスペクト比は、異なる次元でのサイズの比率です。Aspose.Slidesは、テーブルやその他の形状のアスペクト比設定をロックできるように、[**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-)プロパティを提供しています。

このPHPコードは、テーブルのアスペクト比をロックする方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("ロックされたアスペクト比設定: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// 反転

    echo("ロックされたアスペクト比設定: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```