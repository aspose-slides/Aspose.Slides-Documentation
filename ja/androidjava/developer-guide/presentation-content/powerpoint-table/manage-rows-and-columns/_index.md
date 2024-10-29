---
title: 行と列の管理
type: docs
weight: 20
url: /ja/androidjava/manage-rows-and-columns/
keywords: "テーブル, テーブルの行と列, PowerPoint プレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "Java で PowerPoint プレゼンテーションのテーブルの行と列を管理する"
---

PowerPoint プレゼンテーションのテーブルの行と列を管理できるようにするために、Aspose.Slides は [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) インターフェース、その他多くのタイプを提供します。

## **最初の行をヘッダーとして設定する**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。
2. インデックスを使用してスライドの参照を取得します。 
3. [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) オブジェクトを作成し、nullに設定します。
4. すべての [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) オブジェクトを反復処理して、関連するテーブルを見つけます。
5. テーブルの最初の行をヘッダーとして設定します。 

以下の Java コードは、テーブルの最初の行をヘッダーとして設定する方法を示しています：

```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("table.pptx");
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // null の TableEx を初期化します
    ITable tbl = null;

    // シェイプを反復処理し、テーブルへの参照を設定します
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            // テーブルの最初の行をヘッダーとして設定します
            tbl.setFirstRow(true);
        }
    }
    
    // プレゼンテーションをディスクに保存します
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルの行または列をクローンする**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。
2. インデックスを使用してスライドの参照を取得します。 
3. `columnWidth` の配列を定義します。
4. `rowHeight` の配列を定義します。
5. [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) オブジェクトをスライドに [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドを通じて追加します。
6. テーブルの行をクローンします。
7. テーブルの列をクローンします。
8. 修正したプレゼンテーションを保存します。

以下の Java コードは、PowerPoint テーブルの行または列をクローンする方法を示しています：

```java
 // Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("Test.pptx");
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅のあるカラムと高さのある行を定義します
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブルシェイプを追加します
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 行 1 のセル 1 にテキストを追加します
    table.get_Item(0, 0).getTextFrame().setText("行 1 セル 1");

    // 行 1 のセル 2 にテキストを追加します
    table.get_Item(1, 0).getTextFrame().setText("行 1 セル 2");

    // 行 1 をテーブルの最後にクローンします
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // 行 2 のセル 1 にテキストを追加します
    table.get_Item(0, 1).getTextFrame().setText("行 2 セル 1");

    // 行 2 のセル 2 にテキストを追加します
    table.get_Item(1, 1).getTextFrame().setText("行 2 セル 2");

    // 行 2 をテーブルの 4 番目の行としてクローンします
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // 最初の列を最後にクローンします
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // 2 番目の列を 4 番目の列インデックスでクローンします
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    
    // プレゼンテーションをディスクに保存します
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルから行または列を削除する**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。
2. インデックスを使用してスライドの参照を取得します。 
3. `columnWidth` の配列を定義します。
4. `rowHeight` の配列を定義します。
5. [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) オブジェクトをスライドに [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドを通じて追加します。
6. テーブル行を削除します。
7. テーブル列を削除します。
8. 修正したプレゼンテーションを保存します。 

以下の Java コードは、テーブルから行または列を削除する方法を示しています：

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

## **テーブル行レベルでのテキストフォーマットを設定する**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。
2. インデックスを使用してスライドの参照を取得します。 
3. スライドから関連する [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) オブジェクトにアクセスします。
4. 最初の行のセルの [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。
5. 最初の行のセルの [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を設定します。
6. 2 番目の行のセルの [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。
7. 修正したプレゼンテーションを保存します。

以下の Java コードは、操作を示しています。

```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドの最初のシェイプがテーブルであると仮定します
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // 最初の行のセルのフォント高さを設定します
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // 最初の行のセルのテキストの整列と右マージンを設定します
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // 2 番目の行のセルのテキストの垂直タイプを設定します
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // プレゼンテーションをディスクに保存します
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブル列レベルでのテキストフォーマットを設定する**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションを読み込みます。
2. インデックスを使用してスライドの参照を取得します。 
3. スライドから関連する [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) オブジェクトにアクセスします。
4. 最初の列のセルの [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。
5. 最初の列のセルの [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を設定します。
6. 2 番目の列のセルの [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。
7. 修正したプレゼンテーションを保存します。 

以下の Java コードは、操作を示しています： 

```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドの最初のシェイプがテーブルであると仮定します
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // 最初の列のセルのフォント高さを設定します
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // 最初の列のセルのテキストの整列と右マージンを1 回の呼び出しで設定します
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // 2 番目の列のセルのテキストの垂直タイプを設定します
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルスタイルのプロパティを取得する**

Aspose.Slides を使用すると、別のテーブルや他の場所で使用するために、テーブルのスタイルプロパティを取得できます。この Java コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // デフォルトのスタイルプリセットテーマを変更します
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```