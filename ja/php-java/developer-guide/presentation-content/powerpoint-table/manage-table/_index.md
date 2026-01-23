---
title: PHPでプレゼンテーションテーブルを管理
linktitle: テーブルを管理
type: docs
weight: 10
url: /ja/php-java/manage-table/
keywords:
- テーブルを追加
- テーブルを作成
- テーブルにアクセス
- アスペクト比
- テキストの配置
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint スライド内のテーブルを作成および編集します。テーブル操作を効率化するシンプルなコード例を紹介します。"
---

PowerPoint の表は、情報を効率的に表示・伝達する方法です。行と列で構成されたセルのグリッドに情報が入っているため、シンプルで理解しやすくなります。

Aspose.Slides は、[テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/Table) クラス、[セル](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) クラス、その他の型を提供し、さまざまなプレゼンテーションで表の作成、更新、管理が可能です。

## **ゼロから表を作成する**

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使ってスライドへの参照を取得します。  
3. `columnWidth` 配列を定義します。  
4. `rowHeight` 配列を定義します。  
5. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) メソッドでスライドに [テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/table/) オブジェクトを追加します。  
6. 各 [セル](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) を反復処理し、上・下・右・左の枠線の書式設定を適用します。  
7. 表の最初の行の最初の 2 つのセルを結合します。  
8. [セル](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) の [テキストフレーム](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。  
9. [テキストフレーム](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にテキストを追加します。  
10. 変更したプレゼンテーションを保存します。

この PHP コードは、プレゼンテーションで表を作成する方法を示しています。
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # 列の幅と行の高さを定義します
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # スライドにテーブルシェイプを追加します
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの枠線書式を設定します
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
    # 行 1 のセル 1 と 2 を結合します
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # 結合されたセルにテキストを追加します
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # プレゼンテーションをディスクに保存します
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **標準表の番号付け**

標準表では、セルの番号付けはシンプルで 0 から始まります。表の最初のセルは 0,0（列 0、行 0）としてインデックス付けされます。

たとえば、4 列 4 行の表のセルは次のように番号付けされます。

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この PHP コードは、表のセルの番号付けを指定する方法を示しています。
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # 列の幅と行の高さを定義します
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # スライドにテーブルシェイプを追加します
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの枠線書式を設定します
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


## **既存の表にアクセスする**

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使って、表が含まれるスライドへの参照を取得します。  
3. [テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/Table) オブジェクトを作成し、null に設定します。  
4. 表が見つかるまで、すべての [シェイプ](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) オブジェクトを反復処理します。  

   スライドに単一の表しかないと推測できる場合は、含まれるすべてのシェイプをチェックすれば十分です。シェイプが表として識別されたら、[テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/Table) オブジェクトに型変換できます。スライドに複数の表がある場合は、[setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) で目的の表を検索した方が確実です。  
5. [テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/Table) オブジェクトを使用して表を操作します。以下の例では、表に新しい行を追加しています。  
6. 変更したプレゼンテーションを保存します。  

この PHP コードは、既存の表にアクセスして操作する方法を示しています。
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # null の TableEx を初期化します
    $tbl = null;
    # シェイプを反復処理し、見つかったテーブルへの参照を設定します
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # 第2行の第1列のテキストを設定します
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
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


## **表内のテキストを配置する**

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使ってスライドへの参照を取得します。  
3. スライドに [テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/Table) オブジェクトを追加します。  
4. 表から [テキストフレーム](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) オブジェクトにアクセスします。  
5. [段落](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) にアクセスします。  
6. テキストを垂直方向に配置します。  
7. 変更したプレゼンテーションを保存します。  

この PHP コードは、表内のテキストの配置方法を示しています。
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $slide = $pres->getSlides()->get_Item(0);
    # 列の幅と行の高さを定義します
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # スライドにテーブルシェイプを追加します
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # テキストフレームにアクセスします
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # テキストフレーム用の Paragraph オブジェクトを作成します
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraph 用の Portion オブジェクトを作成します
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # テキストを垂直方向に配置します
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


## **表レベルでテキスト書式設定を行う**

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使ってスライドへの参照を取得します。  
3. スライドから [テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/Table) オブジェクトにアクセスします。  
4. テキストの [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) を設定します。  
5. [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) と [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) を設定します。  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) を設定します。  
7. 変更したプレゼンテーションを保存します。  

この PHP コードは、表内テキストに好みの書式設定オプションを適用する方法を示しています。
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation("simpletable.pptx");
  try {
    # 最初のスライドの最初のシェイプがテーブルであると仮定します
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # テーブルセルのフォント高さを設定します
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # テーブルセルのテキストの配置と右マージンを一度に設定します
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # テーブルセルのテキスト縦方向タイプを設定します
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


## **表スタイルプロパティの取得**

Aspose.Slides を使用すると、表のスタイルプロパティを取得でき、別の表や他の場所でそれらの詳細を使用できます。この PHP コードは、表のプリセットスタイルからスタイルプロパティを取得する方法を示しています。
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


## **表のアスペクト比をロックする**

幾何形状のアスペクト比は、異なる寸法におけるサイズの比率です。Aspose.Slides は、[setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) メソッドを提供し、表やその他のシェイプのアスペクト比設定をロックできます。

この PHP コードは、表のアスペクト比をロックする方法を示しています。
```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**テーブル全体およびセル内テキストに右から左 (RTL) の読み取り方向を有効にできますか？**

はい。テーブルは [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) メソッドを公開しており、段落は [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/) を持ちます。両方を使用すると、セル内で正しい RTL 順序とレンダリングが保証されます。

**最終ファイルでユーザーが表を移動またはサイズ変更できないようにするには？**

シェイプロックを使用して、移動、サイズ変更、選択などを無効にします。これらのロックは表にも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（伸張またはタイル）に従ってセル領域全体を覆います。