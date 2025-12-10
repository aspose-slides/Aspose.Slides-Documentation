---
title: Java を使用して PowerPoint テーブルの行と列を管理する
linktitle: 行と列
type: docs
weight: 20
url: /ja/java/manage-rows-and-columns/
keywords:
- テーブル行
- テーブル列
- 1 行目
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint のテーブル行と列を管理し、プレゼンテーションの編集とデータ更新を高速化します。"
---

PowerPointプレゼンテーションでテーブルの行と列を管理できるように、Aspose.Slides は Table クラス、ITable インターフェイス、その他多数の型を提供します。 

## **最初の行をヘッダーとして設定する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) オブジェクトを作成し、null に設定します。  
4. すべての [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) オブジェクトを列挙して、該当するテーブルを見つけます。  
5. テーブルの最初の行をヘッダーとして設定します。  

この Java コードは、テーブルの最初の行をヘッダーとして設定する方法を示しています:
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("table.pptx");
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // null TableEx を初期化します
    ITable tbl = null;

    // シェイプを走査し、テーブルへの参照を設定します
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Sets テーブルの最初の行をヘッダーとして設定します
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

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします、  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` 配列を定義します。  
4. `rowHeight` 配列を定義します。  
5. スライドに [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) オブジェクトを追加し、[addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドを使用します。  
6. テーブル行をクローンします。  
7. テーブル列をクローンします。  
8. 変更されたプレゼンテーションを保存します。  

この Java コードは、PowerPoint テーブルの行または列をクローンする方法を示しています:
```java
 // Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("Test.pptx");
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // 列幅と行高さを定義します
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブル シェイプを追加します
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 行1セル1にテキストを追加します
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // 行1セル2にテキストを追加します
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // テーブルの末尾に行1をクローンします
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // 行2セル1にテキストを追加します
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // 行2セル2にテキストを追加します
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // テーブルの4行目として行2をクローンします
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // 末尾に最初の列をクローンします
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // 4番目の列インデックスに2番目の列をクローンします
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // プレゼンテーションをディスクに保存します
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テーブルから行または列を削除する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします、  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` 配列を定義します。  
4. `rowHeight` 配列を定義します。  
5. スライドに [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) オブジェクトを追加し、[addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドを使用します。  
6. テーブル行を削除します。  
7. テーブル列を削除します。  
8. 変更されたプレゼンテーションを保存します。 

この Java コードは、テーブルから行または列を削除する方法を示しています:
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


## **テーブル行レベルでテキスト書式を設定する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします、  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから該当する [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) オブジェクトにアクセスします。  
4. 最初の行のセルの [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。  
5. 最初の行のセルの [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を設定します。  
6. 2 行目のセルの [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。  
7. 変更されたプレゼンテーションを保存します。  

この Java コードは操作を実演します。
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
    
    // 最初の行のセルのテキスト配置と右マージンを設定します
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // 2 行目のセルのテキスト垂直方向を設定します
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // プレゼンテーションをディスクに保存します
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テーブル列レベルでテキスト書式を設定する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします、  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから該当する [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) オブジェクトにアクセスします。  
4. 最初の列のセルの [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。  
5. 最初の列のセルの [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を設定します。  
6. 2 列目のセルの [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。  
7. 変更されたプレゼンテーションを保存します。 

この Java コードは操作を実演します: 
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

    // 最初の列のセルのテキスト配置と右マージンを一度に設定します
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // 2 列目のセルのテキスト垂直方向を設定します
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テーブルのスタイルプロパティを取得する**

Aspose.Slides を使用すると、テーブルのスタイルプロパティを取得でき、その詳細を別のテーブルや他の場所で使用できます。この Java コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています:
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


## **よくある質問**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスターテーマを継承し、テーマ上で塗りつぶし、枠線、テキスト色を上書きすることもできます。

**Excel のようにテーブルの行を並べ替えることはできますか？**

いいえ、Aspose.Slides のテーブルには組み込みの並べ替えやフィルター機能はありません。まずメモリ上でデータを並べ替え、その順序でテーブル行を再配置してください。

**特定のセルにカスタムカラーを保持しつつ、バンド（ストライプ）列を設定できますか？**

はい。バンド列を有効にし、特定のセルにローカル書式を上書きすれば、セルレベルの書式がテーブルスタイルより優先されます。