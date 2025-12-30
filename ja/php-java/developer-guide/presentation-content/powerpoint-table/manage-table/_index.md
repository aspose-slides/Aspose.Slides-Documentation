---
title: PHPでプレゼンテーションテーブルを管理する
linktitle: テーブルを管理
type: docs
weight: 10
url: /ja/php-java/manage-table/
keywords:
- テーブルを追加
- テーブルを作成
- テーブルにアクセス
- アスペクト比
- テキストを揃える
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint スライドのテーブルを作成および編集します。テーブル操作を効率化するシンプルなコード例をご紹介します。"
---

PowerPoint の表は、情報を表示および表現する効率的な方法です。行と列に配置されたセルのグリッド内の情報は、直接的で理解しやすいです。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) クラス、[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) インターフェイス、[Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) クラス、[ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) インターフェイス、その他の型を提供し、さまざまなプレゼンテーションで表を作成、更新、管理できるようにします。

## **Create a Table from Scratch**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) メソッドを使用して、スライドに [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) オブジェクトを追加します。  
6. 各 [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) を反復処理し、上部、下部、右側、左側の罫線に書式設定を適用します。  
7. 表の最初の行の最初の 2 つのセルを結合します。  
8. [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) の [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。  
9. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にテキストを追加します。  
10. 変更されたプレゼンテーションを保存します。

この PHP コードは、プレゼンテーション内に表を作成する方法を示しています:
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
    # 各セルの罫線書式を設定します
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


## **Numbering in a Standard Table**

標準の表では、セルの番号付けはシンプルでゼロベースです。表の最初のセルは (0,0)（列 0、行 0）としてインデックス付けされます。

たとえば、4 列 4 行の表のセルは次のように番号付けされます:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この PHP コードは、表のセル番号を指定する方法を示しています:
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
    # 各セルの罫線書式を設定します
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


## **Access an Existing Table**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  

2. インデックスを使用して、表が含まれるスライドへの参照を取得します。  

3. [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) オブジェクトを作成し、null に設定します。  

4. 表が見つかるまで、すべての [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) オブジェクトを反復処理します。  

   スライドに単一の表しか含まれていないと判断できる場合は、含まれるすべてのシェイプをチェックすればよいです。シェイプが表として識別されたら、[Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) オブジェクトに型キャストできます。スライドに複数の表が含まれている場合は、[setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-) を使用して目的の表を検索する方が適しています。  

5. [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) オブジェクトを使用して表を操作します。以下の例では、表に新しい行を追加しています。  

6. 変更されたプレゼンテーションを保存します。  

この PHP コードは、既存の表にアクセスして操作する方法を示しています:
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # null の TableEx を初期化します
    $tbl = null;
    # シェイプを反復処理し、見つかった表への参照を設定します
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # 第2行の第1列のテキストを設定します
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # 変更されたプレゼンテーションをディスクに保存します
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Align Text in a Table**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) オブジェクトを追加します。  
4. 表から [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) オブジェクトにアクセスします。  
5. [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) の [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) にアクセスします。  
6. テキストを垂直方向に揃えます。  
7. 変更されたプレゼンテーションを保存します。  

この PHP コードは、表内のテキストを揃える方法を示しています:
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
    # テキストを垂直方向に揃えます
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


## **Set Text Formatting on the Table Level**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) オブジェクトにアクセスします。  
4. テキストに対して [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。  
5. [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-) を設定します。  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。  
7. 変更されたプレゼンテーションを保存します。  

この PHP コードは、表内のテキストに好みの書式設定オプションを適用する方法を示しています:
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
    # テーブルセルのテキスト配置と右余白を一度に設定します
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # テーブルセルのテキスト垂直方向を設定します
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


## **Get Table Style Properties**

Aspose.Slides を使用すると、表のスタイル プロパティを取得でき、取得した詳細を別の表や他の場所で使用できます。この PHP コードは、表のプリセット スタイルからスタイル プロパティを取得する方法を示しています:
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


## **Lock Aspect Ratio of a Table**

幾何学的シェイプのアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slides は、表や他のシェイプのアスペクト比設定をロックできるように、[**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) プロパティを提供しています。

この PHP コードは、表のアスペクト比をロックする方法を示しています:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// 反転

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

はい。表は [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) メソッドを公開しており、段落は [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/) を持ちます。両方を使用することで、セル内の正しい RTL 順序とレンダリングが保証されます。

**How can I prevent users from moving or resizing a table in the final file?**

[shape locks](/slides/ja/php-java/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックは表にも適用されます。

**Is inserting an image inside a cell as a background supported?**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（ストレッチまたはタイル）に従ってセル領域を覆います。