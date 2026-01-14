---
title: PHPでプレゼンテーションテーブルを管理
linktitle: テーブルを管理
type: docs
weight: 10
url: /ja/php-java/manage-table/
keywords:
- テーブルの追加
- テーブルの作成
- テーブルへのアクセス
- アスペクト比
- テキストの配置
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint スライド内のテーブルを作成・編集します。テーブル操作を効率化するシンプルなコード例をご紹介します。"
---

PowerPoint の表は、情報を表示および表現する効率的な方法です。行と列に配置されたセルのグリッド内の情報は、わかりやすく簡単に理解できます。

Aspose.Slides は、[Table] クラス、[Cell] クラス、およびその他のタイプを提供し、さまざまなプレゼンテーションで表の作成、更新、管理を可能にします。

## **テーブルをゼロから作成する**

1. [Presentation] クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [addTable] メソッドを使用してスライドに [Table] オブジェクトを追加します。  
6. 各 [Cell] を反復処理し、上、下、右、左の罫線に書式設定を適用します。  
7. テーブルの最初の行の最初の 2 つのセルを結合します。  
8. [Cell] の [TextFrame] にアクセスします。  
9. [TextFrame] にテキストを追加します。  
10. 変更されたプレゼンテーションを保存します。  

この PHP コードは、プレゼンテーションで表を作成する方法を示しています:
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # 列の幅と行の高さを定義
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # スライドにテーブル シェイプを追加
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの罫線書式を設定
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
    # 行 1 のセル 1 と 2 を結合
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # 結合されたセルにテキストを追加
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # プレゼンテーションをディスクに保存
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **標準テーブルの番号付け**

標準テーブルでは、セルの番号付けはシンプルでゼロベースです。テーブルの最初のセルは 0,0（列 0、行 0）としてインデックス付けされます。

例えば、4 列 4 行のテーブルのセルは次のように番号付けされます：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この PHP コードは、テーブルのセルの番号付けを指定する方法を示しています:
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # 列の幅と行の高さを定義
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # スライドにテーブル シェイプを追加
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 各セルの罫線書式を設定
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
    # プレゼンテーションをディスクに保存
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **既存のテーブルへアクセスする**

1. [Presentation] クラスのインスタンスを作成します。  
2. インデックスを使用して、テーブルを含むスライドへの参照を取得します。  
3. [Table] オブジェクトを作成し、null に設定します。  
4. テーブルが見つかるまで、すべての [Shape] オブジェクトを反復処理します。  
   対象のスライドに単一のテーブルが含まれていると考えられる場合は、含まれるすべてのシェイプを単純にチェックできます。シェイプがテーブルとして識別されたら、[Table] オブジェクトに型キャストできます。ただし、対象のスライドに複数のテーブルが含まれている場合は、[setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) を使用して必要なテーブルを検索した方が良いでしょう。  
5. [Table] オブジェクトを使用してテーブルを操作します。以下の例では、テーブルに新しい行を追加しました。  
6. 変更されたプレゼンテーションを保存します。  

この PHP コードは、既存のテーブルにアクセスして操作する方法を示しています:
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # null の TableEx を初期化
    $tbl = null;
    # シェイプを走査し、見つかったテーブルへの参照を設定
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # 第2行の第1列のテキストを設定
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # 変更されたプレゼンテーションをディスクに保存
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブル内のテキストを揃える**

1. [Presentation] クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. [Table] オブジェクトをスライドに追加します。  
4. テーブルから [TextFrame] オブジェクトにアクセスします。  
5. [Paragraph] にアクセスします。  
6. テキストを垂直方向に揃えます。  
7. 変更されたプレゼンテーションを保存します。  

この PHP コードは、テーブル内のテキストを揃える方法を示しています:
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 列の幅と行の高さを定義
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # テーブル シェイプをスライドに追加
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # テキストフレームにアクセス
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # テキストフレーム用の Paragraph オブジェクトを作成
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraph 用の Portion オブジェクトを作成
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # テキストを垂直方向に揃える
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # プレゼンテーションをディスクに保存
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブルレベルでテキスト書式設定を行う**

1. [Presentation] クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから [Table] オブジェクトにアクセスします。  
4. テキストの [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) を設定します。  
5. [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) と [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) を設定します。  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) を設定します。  
7. 変更されたプレゼンテーションを保存します。  

この PHP コードは、テーブル内のテキストに好みの書式設定を適用する方法を示しています:
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation("simpletable.pptx");
  try {
    # 最初のスライドの最初のシェイプがテーブルであると想定します
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # テーブルセルのフォント高さを設定
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # テーブルセルのテキスト配置と右余白を一度に設定
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # テーブルセルのテキストの縦方向タイプを設定
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

Aspose.Slides を使用すると、テーブルのスタイルプロパティを取得でき、別のテーブルや他の場所でその詳細を使用できます。この PHP コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています:
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// デフォルトのスタイルプリセットテーマを変更

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブルのアスペクト比をロックする**

幾何形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slides は、テーブルやその他のシェイプのアスペクト比設定をロックできるように、[setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) メソッドを提供しています。

この PHP コードは、テーブルのアスペクト比をロックする方法を示しています:
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


## **よくある質問**

**テーブル全体およびセル内のテキストに右から左 (RTL) の読み方向を有効にできますか？**

はい。テーブルは [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) メソッドを公開しており、段落には [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/) があります。両方を使用すると、セル内で正しい RTL の順序と描画が保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするにはどうすればよいですか？**

テーブルの移動、サイズ変更、選択などを無効にするには、[shape locks](/slides/ja/php-java/applying-protection-to-presentation/) を使用します。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) を設定できます。画像は、選択したモード（伸縮またはタイル）に従ってセル領域全体を覆います。