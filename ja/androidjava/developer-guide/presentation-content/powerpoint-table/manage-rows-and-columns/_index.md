---
title: Android で PowerPoint テーブルの行と列を管理
linktitle: 行と列
type: docs
weight: 20
url: /ja/androidjava/manage-rows-and-columns/
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
- 行のテキスト書式設定
- 列のテキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java で PowerPoint のテーブル行と列を管理し、プレゼンテーションの編集とデータ更新を高速化します。"
---

PowerPoint プレゼンテーションでテーブルの行と列を管理できるように、Aspose.Slides は [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) インターフェイス、その他多数の型を提供します。

## **最初の行をヘッダーとして設定**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) オブジェクトを作成し、null に設定します。
4. すべての [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) オブジェクトを反復処理して、対象のテーブルを見つけます。
5. テーブルの最初の行をヘッダーとして設定します。

この Java コードは、テーブルの最初の行をヘッダーとして設定する方法を示します。
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
            
            //テーブルの最初の行をヘッダーとして設定します
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

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. `columnWidth` の配列を定義します。
4. `rowHeight` の配列を定義します。
5. [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドを使用して、スライドに [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) オブジェクトを追加します。
6. テーブルの行をクローンします。
7. テーブルの列をクローンします。
8. 変更されたプレゼンテーションを保存します。

この Java コードは、PowerPoint テーブルの行または列をクローンする方法を示します。
```java
 // Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("Test.pptx");
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // 列の幅と行の高さを定義します
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブルシェイプを追加します
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 行 1 のセル 1 にテキストを追加します
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // 行 1 のセル 2 にテキストを追加します
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // テーブルの末尾に行 1 をクローンします
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // 行 2 のセル 1 にテキストを追加します
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // 行 2 のセル 2 にテキストを追加します
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // テーブルの 4 行目として行 2 をクローンします
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // 末尾に最初の列をクローンします
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // 4 番目の列インデックスに 2 番目の列をクローンします
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // プレゼンテーションをディスクに保存します
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テーブルから行または列を削除する**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. `columnWidth` の配列を定義します。
4. `rowHeight` の配列を定義します。
5. [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドを使用して、スライドに [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) オブジェクトを追加します。
6. テーブルの行を削除します。
7. テーブルの列を削除します。
8. 変更されたプレゼンテーションを保存します。

この Java コードは、テーブルから行または列を削除する方法を示します。
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


## **テーブル行レベルでテキスト書式設定を行う**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. スライドから対象の [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) オブジェクトにアクセスします。
4. 最初の行のセルの [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。
5. 最初の行のセルの [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を設定します。
6. 2 行目のセルの [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。
7. 変更されたプレゼンテーションを保存します。

この Java コードは操作を示します。
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
    
    // 最初の行のセルのテキスト配置と右余白を設定します
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // 2 行目のセルのテキスト縦方向タイプを設定します
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // プレゼンテーションをディスクに保存します
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テーブル列レベルでテキスト書式設定を行う**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. スライドから対象の [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) オブジェクトにアクセスします。
4. 最初の列のセルの [setFontHeight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。
5. 最初の列のセルの [setAlignment(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を設定します。
6. 2 列目のセルの [setTextVerticalType(byte value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。
7. 変更されたプレゼンテーションを保存します。

この Java コードは操作を示します：
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドの最初のシェイプがテーブルであると仮定します
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // 最初の列のセルのフォント高さを設定します
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // 最初の列のセルのテキスト配置と右余白を一度に設定します
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // 2 列目のセルのテキスト縦方向タイプを設定します
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テーブルスタイルプロパティの取得**

Aspose.Slides を使用すると、テーブルのスタイル プロパティを取得でき、取得した詳細を別のテーブルや他の場所で利用できます。この Java コードは、テーブルのプリセットスタイルからスタイル プロパティを取得する方法を示します。
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


## **FAQ**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド／レイアウト／マスターテーマを継承しますが、その上で塗りつぶし、枠線、テキストカラーを上書きすることも可能です。

**Excel のようにテーブル行を並べ替えできますか？**

いいえ、Aspose.Slides のテーブルには組み込みのソートやフィルタ機能はありません。まずメモリ上でデータをソートし、その順序でテーブルの行を再度設定してください。

**特定のセルにカスタムカラーを保持しながら、帯状（ストライプ）列を使用できますか？**

はい。帯状列を有効にした上で、特定のセルにローカル書式を上書きできます。セルレベルの書式設定はテーブルスタイルよりも優先されます。