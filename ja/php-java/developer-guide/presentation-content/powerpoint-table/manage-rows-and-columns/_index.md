---
title: "PHP を使用して PowerPoint テーブルの行と列を管理する"
linktitle: "行と列"
type: docs
weight: 20
url: /ja/php-java/manage-rows-and-columns/
keywords:
- "テーブル 行"
- "テーブル 列"
- "最初の行"
- "テーブル ヘッダー"
- "行 をクローン"
- "列 をクロン"
- "行 をコピー"
- "列 をコピー"
- "行 を削除"
- "列 を削除"
- "行 テキスト 書式設定"
- "列 テキスト 書式設定"
- "テーブル スタイル"
- "PowerPoint"
- "プレゼンテーション"
- "PHP"
- "Aspose.Slides"
description: "Java を介して PHP 用 Aspose.Slides を使用し、PowerPoint のテーブルの行と列を管理し、プレゼンテーションの編集とデータ更新を高速化します。"
---

PowerPoint プレゼンテーションでテーブルの行と列を管理できるように、Aspose.Slides は [テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/table/) クラスやその他多数の型を提供しています。

## **最初の行をヘッダーとして設定**

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. [テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/Table) オブジェクトを作成し、null に設定します。  
4. すべての [シェイプ](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) オブジェクトを走査し、対象のテーブルを見つけます。  
5. テーブルの最初の行をヘッダーとして設定します。  

この PHP コードは、テーブルの最初の行をヘッダーとして設定する方法を示しています:
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation("table.pptx");
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # null の TableEx を初期化します
    $tbl = null;
    # シェイプを反復処理し、テーブルへの参照を設定します
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # テーブルの最初の行をヘッダーとして設定します
        $tbl->setFirstRow(true);
      }
    }
    # プレゼンテーションをディスクに保存します
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブル行または列のクローン作成**

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) メソッドを使用して、スライドに [テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/Table) オブジェクトを追加します。  
6. テーブル行をクローンします。  
7. テーブル列をクローンします。  
8. 変更されたプレゼンテーションを保存します。  

この PHP コードは、PowerPoint テーブルの行または列をクローンする方法を示しています:
```php
  # Presentation クラスのインスタンス化
  $pres = new Presentation("Test.pptx");
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # 列の幅と行の高さを定義
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # スライドにテーブル シェイプを追加
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 行 1 のセル 1 にテキストを追加
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # 行 1 のセル 2 にテキストを追加
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # テーブルの末尾に行 1 をクローン
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # 行 2 のセル 1 にテキストを追加
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # 行 2 のセル 2 にテキストを追加
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # 行 2 をテーブルの 4 行目としてクローン
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # 末尾に最初の列をクローン
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # 4 列目のインデックスに 2 番目の列をクローン
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # プレゼンテーションをディスクに保存
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブルから行または列を削除**

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) メソッドを使用して、スライドに [テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/Table) オブジェクトを追加します。  
6. テーブル行を削除します。  
7. テーブル列を削除します。  
8. 変更されたプレゼンテーションを保存します。  

この PHP コードは、テーブルから行または列を削除する方法を示しています:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブル行レベルでのテキスト書式設定**

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから対象の [テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/Table) オブジェクトにアクセスします。  
4. 最初の行のセルに対して [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) を設定します。  
5. 最初の行のセルに対して [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) と [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) を設定します。  
6. 2 行目のセルに対して [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) を設定します。  
7. 変更されたプレゼンテーションを保存します。  

この PHP コードは操作をデモンストレーションします。
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドの最初のシェイプがテーブルであると仮定します
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 最初の行のセルのフォント高さを設定します
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # 最初の行のセルのテキスト配置と右マージンを設定します
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # 2 行目のセルのテキストの垂直方向タイプを設定します
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # プレゼンテーションをディスクに保存します
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブル列レベルでのテキスト書式設定**

1. [プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから対象の [テーブル](https://reference.aspose.com/slides/php-java/aspose.slides/Table) オブジェクトにアクセスします。  
4. 最初の列のセルに対して [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) を設定します。  
5. 最初の列のセルに対して [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) と [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) を設定します。  
6. 2 列目のセルに対して [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) を設定します。  
7. 変更されたプレゼンテーションを保存します。  

この PHP コードは操作をデモンストレーションします:
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドの最初のシェイプがテーブルであると仮定します
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 最初の列のセルのフォント高さを設定します
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # 1 回の呼び出しで最初の列のセルのテキスト配置と右マージンを設定します
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # 2 列目のセルのテキストの垂直方向タイプを設定します
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブル スタイル プロパティの取得**

Aspose.Slides はテーブルのスタイル プロパティを取得できるため、取得した詳細を別のテーブルや他の場所で使用できます。この PHP コードは、テーブルのプリセット スタイルからスタイル プロパティを取得する方法を示しています:
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// デフォルトのスタイルプリセットテーマを変更する

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスタ テーマを継承しますが、その上で塗りつぶし、枠線、テキスト色を上書きすることも可能です。

**Excel のようにテーブル行をソートできますか？**

いいえ、Aspose.Slides のテーブルには組み込みのソートやフィルタ機能はありません。データをメモリ内で先にソートし、その順序でテーブル行を再配置してください。

**特定のセルにカスタムカラーを保持しながら、帯状（ストライプ）列を設定できますか？**

はい。帯状列を有効にした後、ローカル書式で特定のセルを上書きできます。セル単位の書式がテーブル スタイルより優先されます。