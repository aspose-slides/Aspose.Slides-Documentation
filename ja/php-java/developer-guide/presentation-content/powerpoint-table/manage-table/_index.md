---
title: PHP でプレゼンテーション テーブルを管理する
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
description: "Java 経由で PHP 用 Aspose.Slides を使用して、PowerPoint スライド内のテーブルを作成および編集します。テーブル操作を効率化するシンプルなコード例をご紹介します。"
---
## **紹介**

PowerPoint の表は、情報を表示・表現する効率的な方法です。行と列に配置されたセルのグリッドにある情報は、シンプルで理解しやすいです。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Table) クラス、[Cell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cell/) クラス、その他の型を提供し、さまざまなプレゼンテーションで表を作成、更新、管理できるようにします。

## **スクラッチから表を作成する**

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [addTable](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addtable/) メソッドを使用して、スライドに [Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/table/) オブジェクトを追加します。  
6. 各 [Cell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cell/) を走査し、上・下・左・右の罫線に書式設定を適用します。  
7. 表の最初の行の最初の 2 つのセルを結合します。  
8. [Cell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cell/) の [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスします。  
9. [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にテキストを追加します。  
10. 変更されたプレゼンテーションを保存します。

```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # 列の幅と行の高さを定義します
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # スライドにテーブル シェイプを追加します
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

## **標準表の番号付け**

標準表では、セルの番号付けはシンプルでゼロベースです。表の最初のセルは 0,0（列 0、行 0）としてインデックス付けされます。

例えば、4 列 4 行の表のセルは次のように番号付けされます：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この PHP コードは、表のセルの番号付け方法を示しています：

```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # 列の幅と行の高さを定義します
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # スライドにテーブル シェイプを追加します
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの罫線書式を設定します
    $rows = $tbl->getRows();
    foreach($rows as $row) {
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

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して、表が含まれるスライドへの参照を取得します。  
3. [Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Table) オブジェクトを作成し、null に設定します。  
4. 表が見つかるまで、すべての [Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) オブジェクトを走査します。  

   スライドに単一の表しか含まれていないと疑われる場合は、含まれるすべてのシェイプをチェックすればよいです。シェイプが表として判別されたら、[Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Table) オブジェクトにキャストできます。複数の表が存在する場合は、[setAlternativeText(String value)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/setalternativetext/) で目的の表を検索した方が便利です。  

5. [Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Table) オブジェクトを使用して表を操作します。以下の例では、表に新しい行を追加しました。  
6. 変更されたプレゼンテーションを保存します。

```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # null TableEx を初期化します
    $tbl = null;
    # 形状を走査し、見つかった表への参照を設定します
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
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

## **テキスト フレームを所有するセルを見つける**

テーブルから取得した [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) を汎用的なテキスト処理コードで受け取る場合は、[TextFrame::getParentCell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#getParentCell) メソッドを使用して所有する [Cell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cell/) を取得します。テーブルセルのテキストフレームに対しては、[TextFrame::getParentCell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#getParentCell) が所有者を返し、[TextFrame::getParentShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#getParentShape) は `null` を返します（テーブル自体はシェイプです）。

セルの座標は、読み取り専用の [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cell/#getFirstColumnIndex) および [Cell::getFirstRowIndex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cell/#getFirstRowIndex) メソッドで取得できます。[TextFrame::getParentCell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#getParentCell) も読み取り専用のナビゲーションを提供し、所有者を返しますが所有権は変更されません。使用する前に必ず `java_is_null` で返されたセルをチェックしてください。

テーブルセルとシェイプの所有者を特定する完全な例（SmartArt ノードに関連付けられたシェイプを含む）は、[Search and Replace Text](/slides/ja/php-java/search-and-replace-text/) を参照してください。

## **表内のテキストを揃える**

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに [Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Table) オブジェクトを追加します。  
4. 表から [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) オブジェクトにアクセスします。  
5. [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) にアクセスします。  
6. テキストを垂直方向に揃えます。  
7. 変更されたプレゼンテーションを保存します。

```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $slide = $pres->getSlides()->get_Item(0);
    # 列の幅と行の高さを定義します
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # スライドにテーブル シェイプを追加します
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # テキスト フレームにアクセスします
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # テキスト フレーム用の Paragraph オブジェクトを作成します
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

## **テーブルレベルでテキスト書式を設定する**

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから [Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Table) オブジェクトにアクセスします。  
4. テキストの [setFontHeight(float value)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setFontHeight) を設定します。  
5. [setAlignment(int value)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setalignment/) と [setMarginRight(float value)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setmarginright/) を設定します。  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/settextverticaltype/) を設定します。  
7. 変更されたプレゼンテーションを保存します。

```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation("simpletable.pptx");
  try {
    # 最初のスライドの最初のシェイプがテーブルであると想定します
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # テーブルセルのフォント高さを設定します
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # テーブルセルのテキスト配置と右余白を一度の呼び出しで設定します
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # テーブルセルのテキスト垂直タイプを設定します
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

## **テーブルスタイルのプロパティを取得する**

Aspose.Slides は、テーブルのスタイルプロパティを取得できるようにし、その情報を別のテーブルや他の場所で使用できます。この PHP コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// 既定のスタイルプリセットテーマを変更します

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **表のアスペクト比をロックする**

幾何形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slides は、表やその他のシェイプに対してアスペクト比ロック設定を行うために、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) メソッドを提供しています。

この PHP コードは、表のアスペクト比をロックする方法を示しています：

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

**テーブル全体とセル内のテキストに右から左 (RTL) の読み方向を有効にできますか？**  

はい。テーブルは [setRightToLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/table/setrighttoleft/) メソッドを公開しており、段落には [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setrighttoleft/) があります。両方を使用することで、セル内の正しい RTL 順序とレンダリングが保証されます。

**最終ファイルで表をユーザーが移動またはサイズ変更できないようにするにはどうすればよいですか？**  

シェイプロックを使用して、移動、サイズ変更、選択などを無効にします。これらのロックは表にも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**  

はい。セルに対して [picture fill](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（ストレッチまたはタイル）に従ってセル領域全体をカバーします。