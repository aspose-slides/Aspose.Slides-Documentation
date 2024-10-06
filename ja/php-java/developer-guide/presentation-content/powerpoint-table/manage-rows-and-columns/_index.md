---
title: 行と列の管理
type: docs
weight: 20
url: /ja/php-java/manage-rows-and-columns/
keywords: "テーブル, テーブルの行と列, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションのテーブルの行と列を管理する"
---

PowerPointプレゼンテーションのテーブルの行と列を管理するために、Aspose.Slidesは[Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/)クラス、[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)インターフェース、およびその他の多くのタイプを提供します。

## **最初の行をヘッダーとして設定**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. スライドのインデックスを通じてスライドの参照を取得します。
3. [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)オブジェクトを作成し、nullに設定します。
4. すべての[IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/)オブジェクトを反復処理して、関連するテーブルを見つけます。
5. テーブルの最初の行をヘッダーとして設定します。

このPHPコードは、テーブルの最初の行をヘッダーとして設定する方法を示しています：

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation("table.pptx");
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # null TableExを初期化
    $tbl = null;
    # 形状を反復処理し、テーブルへの参照を設定
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # テーブルの最初の行をヘッダーとして設定
        $tbl->setFirstRow(true);
      }
    }
    # プレゼンテーションをディスクに保存
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テーブルの行または列を複製**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. スライドのインデックスを通じてスライドの参照を取得します。
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)オブジェクトを[addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---)メソッドを通じてスライドに追加します。
6. テーブル行を複製します。
7. テーブル列を複製します。
8. 修正されたプレゼンテーションを保存します。

このPHPコードは、PowerPointテーブルの行または列を複製する方法を示しています：

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation("Test.pptx");
  try {
    # 最初のスライドにアクセス
    $sld = $pres->getSlides()->get_Item(0);
    # 幅を持つ列と高さを持つ行を定義
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # スライドにテーブル形状を追加
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 行1のセル1にテキストを追加
    $table->get_Item(0, 0)->getTextFrame()->setText("行1 セル1");
    # 行1のセル2にテキストを追加
    $table->get_Item(1, 0)->getTextFrame()->setText("行1 セル2");
    # テーブルの最後に行1を複製
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # 行2のセル1にテキストを追加
    $table->get_Item(0, 1)->getTextFrame()->setText("行2 セル1");
    # 行2のセル2にテキストを追加
    $table->get_Item(1, 1)->getTextFrame()->setText("行2 セル2");
    # 行2をテーブルの4番目の行として複製
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # 最後に最初の列を複製
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # 4番目の列インデックスで2番目の列を複製
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

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. スライドのインデックスを通じてスライドの参照を取得します。
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)オブジェクトを[addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---)メソッドを通じてスライドに追加します。
6. テーブルの行を削除します。
7. テーブルの列を削除します。
8. 修正されたプレゼンテーションを保存します。

このPHPコードは、テーブルから行または列を削除する方法を示しています：

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

## **テーブルの行レベルでテキストの書式設定を設定**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. スライドのインデックスを通じてスライドの参照を取得します。
3. スライドから関連する[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)オブジェクトにアクセスします。
4. 最初の行のセルの[setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-)を設定します。
5. 最初の行のセルの[setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-)と[setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-)を設定します。
6. 二行目のセルの[setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)を設定します。
7. 修正されたプレゼンテーションを保存します。

このPHPコードは、操作を示しています：

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドの最初の形状がテーブルであると仮定しましょう
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 最初の行のセルのフォントサイズを設定
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # 最初の行のセルのテキストの配置と右マージンを設定
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # 二行目のセルのテキストの垂直タイプを設定
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # プレゼンテーションをディスクに保存
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テーブルの列レベルでテキストの書式設定を設定**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. スライドのインデックスを通じてスライドの参照を取得します。
3. スライドから関連する[ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable)オブジェクトにアクセスします。
4. 最初の列のセルの[setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-)を設定します。
5. 最初の列のセルの[setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-)と[setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-)を設定します。
6. 二番目の列のセルの[setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)を設定します。
7. 修正されたプレゼンテーションを保存します。

このPHPコードは、操作を示しています：

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドの最初の形状がテーブルであると仮定しましょう
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 最初の列のセルのフォントサイズを設定
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # 最初の列のセルのテキストの配置と右マージンを1回の呼び出しで設定
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # 二番目の列のセルのテキストの垂直タイプを設定
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

## **テーブルスタイルプロパティの取得**

Aspose.Slidesを使用すると、テーブルのスタイルプロパティを取得して、それらの詳細を別のテーブルや他の場所で使用できます。このPHPコードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています：

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