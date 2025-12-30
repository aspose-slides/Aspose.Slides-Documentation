---
title: PowerPoint テーブルで PHP を使用して行と列を管理
linktitle: 行と列
type: docs
weight: 20
url: /ja/php-java/manage-rows-and-columns/
keywords:
- テーブル行
- テーブル列
- 最初の行
- テーブルヘッダー
- 行のクローン
- 列のクローン
- 行のコピー
- 列のコピー
- 行の削除
- 列の削除
- 行テキスト書式設定
- 列テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint のテーブル行と列を管理し、プレゼンテーションの編集とデータ更新を高速化します。"
---

PowerPoint プレゼンテーションでテーブルの行と列を管理できるように、Aspose.Slides は [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) インターフェイス、その他多数の型を提供します。

## **最初の行をヘッダーとして設定**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) オブジェクトを作成し、null に設定します。
4. すべての [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) オブジェクトを反復処理して、対象のテーブルを見つけます。
5. テーブルの最初の行をヘッダーとして設定します。

この PHP コードは、テーブルの最初の行をヘッダーとして設定する方法を示します：
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation("table.pptx");
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # null の TableEx を初期化します
    $tbl = null;
    # シェイプを走査し、テーブルへの参照を設定します
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


## **テーブルの行または列をクローン**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. `columnWidth` の配列を定義します。
4. `rowHeight` の配列を定義します。
5. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドを使用して、スライドに [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) オブジェクトを追加します。
6. テーブルの行をクローンします。
7. テーブルの列をクローンします。
8. 変更されたプレゼンテーションを保存します。

この PHP コードは、PowerPoint テーブルの行または列をクローンする方法を示します：
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation("Test.pptx");
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # 列幅と行高さを定義
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
    # 先頭列を末尾にクローン
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # 2 列目を 4 列目の位置にクローン
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

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. `columnWidth` の配列を定義します。
4. `rowHeight` の配列を定義します。
5. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドを使用して、スライドに [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) オブジェクトを追加します。
6. テーブルの行を削除します。
7. テーブルの列を削除します。
8. 変更されたプレゼンテーションを保存します。

この PHP コードは、テーブルから行または列を削除する方法を示します：
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


## **テーブル行レベルでテキスト書式を設定**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. スライドから対象の [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) オブジェクトにアクセスします。
4. 最初の行のセルの [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。
5. 最初の行のセルの [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-) を設定します。
6. 2 行目のセルの [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。
7. 変更されたプレゼンテーションを保存します。

この PHP コードは操作を示します。
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
    # 最初の行のセルのテキスト配置と右余白を設定します
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # 2 行目のセルのテキストの垂直タイプを設定します
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


## **テーブル列レベルでテキスト書式を設定**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. スライドから対象の [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) オブジェクトにアクセスします。
4. 最初の列のセルの [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。
5. 最初の列のセルの [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-) を設定します。
6. 2 列目のセルの [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。
7. 変更されたプレゼンテーションを保存します。

この PHP コードは操作を示します：
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドの最初のシェイプがテーブルであると仮定します
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 最初の列のセルのフォント高さを設定
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # 最初の列のセルのテキスト配置と右余白を一度に設定
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # 2 列目のセルのテキストの垂直タイプを設定
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


## **テーブルスタイルのプロパティを取得**

Aspose.Slides を使用すると、テーブルのスタイルプロパティを取得でき、取得した詳細を別のテーブルや他の場所で使用できます。この PHP コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示します：
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


## **FAQ**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスターテーマを継承し、なお、塗りつぶし、枠線、テキストの色などをそのテーマの上で上書きすることができます。

**Excel のようにテーブル行をソートできますか？**

いいえ、Aspose.Slides のテーブルには組み込みのソートやフィルター機能はありません。データをメモリ上で先にソートし、その順序でテーブル行を再度設定してください。

**特定のセルにカスタムカラーを保持しながら、バンド（ストライプ）列を使用できますか？**

はい。バンド付き列を有効にし、特定のセルにローカルの書式設定で上書きすれば、セルレベルの書式設定がテーブルスタイルより優先されます。