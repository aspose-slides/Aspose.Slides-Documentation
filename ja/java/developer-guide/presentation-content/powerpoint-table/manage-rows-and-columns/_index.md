---
title: 行と列の管理
type: docs
weight: 20
url: /ja/java/manage-rows-and-columns/
keywords: "テーブル, テーブル行と列, PowerPoint プレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaのPowerPointプレゼンテーションでテーブルの行と列を管理する"
---

PowerPointプレゼンテーションのテーブルの行と列を管理できるように、Aspose.Slidesは[Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/)クラス、[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)インターフェース、およびその他の多くの型を提供します。 

## **最初の行をヘッダーとして設定**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. インデックスを通じてスライドの参照を取得します。 
3. [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)オブジェクトを作成し、nullに設定します。
4. すべての[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)オブジェクトを反復処理して、関連するテーブルを見つけます。 
5. テーブルの最初の行をヘッダーとして設定します。 

このJavaコードは、テーブルの最初の行をヘッダーとして設定する方法を示しています:

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation("table.pptx");
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // nullのTableExを初期化
    ITable tbl = null;

    // シェイプを反復処理してテーブルへの参照を設定
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            // テーブルの最初の行をヘッダーとして設定
            tbl.setFirstRow(true);
        }
    }
    
    // プレゼンテーションをディスクに保存
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テーブルの行または列を複製**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. インデックスを通じてスライドの参照を取得します。 
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)オブジェクトを[addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---)メソッドを介してスライドに追加します。
6. テーブルの行を複製します。
7. テーブルの列を複製します。
8. 修正したプレゼンテーションを保存します。

このJavaコードは、PowerPointテーブルの行または列を複製する方法を示しています:

```java
 // Presentationクラスのインスタンスを作成
Presentation pres = new Presentation("Test.pptx");
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅と高さを持つ列と行を定義
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブル形状を追加
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 行1のセル1にテキストを追加
    table.get_Item(0, 0).getTextFrame().setText("行 1 セル 1");

    // 行1のセル2にテキストを追加
    table.get_Item(1, 0).getTextFrame().setText("行 1 セル 2");

    // テーブルの最後に行1を複製
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // 行2のセル1にテキストを追加
    table.get_Item(0, 1).getTextFrame().setText("行 2 セル 1");

    // 行2のセル2にテキストを追加
    table.get_Item(1, 1).getTextFrame().setText("行 2 セル 2");

    // 行2をテーブルの4番目の行として複製
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // 最後に最初の列を複製
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // 4番目の列インデックスに2番目の列を複製
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // プレゼンテーションをディスクに保存
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルから行または列を削除する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. インデックスを通じてスライドの参照を取得します。 
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)オブジェクトを[addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---)メソッドを介してスライドに追加します。
6. テーブルの行を削除します。
7. テーブルの列を削除します。
8. 修正したプレゼンテーションを保存します。 

このJavaコードは、テーブルから行または列を削除する方法を示しています:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブル行レベルのテキストフォーマットを設定**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. インデックスを通じてスライドの参照を取得します。 
3. スライドから関連する[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)オブジェクトを取得します。 
4. 最初の行のセルの[setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-)を設定します。 
5. 最初の行のセルの[setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-)と[setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-)を設定します。 
6. 2番目の行のセルの[setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)を設定します。
7. 修正したプレゼンテーションを保存します。

このJavaコードは、操作を示しています。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドの最初のシェイプがテーブルだと仮定
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // 最初の行のセルのフォントの高さを設定
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // 最初の行のセルのテキストの整列と右マージンを設定
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // 2番目の行のセルのテキストの垂直タイプを設定
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // プレゼンテーションをディスクに保存
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブル列レベルのテキストフォーマットを設定**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. インデックスを通じてスライドの参照を取得します。 
3. スライドから関連する[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable)オブジェクトを取得します。 
4. 最初の列のセルの[setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-)を設定します。
5. 最初の列のセルの[setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-)と[setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-)を設定します。 
6. 2番目の列のセルの[setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)を設定します。
7. 修正したプレゼンテーションを保存します。 

このJavaコードは、操作を示しています: 

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドの最初のシェイプがテーブルだと仮定
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 最初の列のセルのフォントの高さを設定
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // 最初の列のセルのテキストの整列と右マージンを一回の呼び出しで設定
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // 2番目の列のセルのテキストの垂直タイプを設定
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルスタイルプロパティの取得**

Aspose.Slidesでは、別のテーブルや別の場所で使用できるように、テーブルのスタイルプロパティを取得できます。このJavaコードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // デフォルトのスタイルプリセットテーマを変更
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```