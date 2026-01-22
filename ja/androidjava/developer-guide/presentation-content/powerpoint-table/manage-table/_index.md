---
title: Android でプレゼンテーションの表を管理する
linktitle: 表の管理
type: docs
weight: 10
url: /ja/androidjava/manage-table/
keywords:
- 表を追加
- 表を作成
- 表にアクセス
- アスペクト比
- テキストの配置
- テキスト書式設定
- 表スタイル
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、PowerPoint スライドの表を作成および編集します。表の作業フローを効率化するシンプルな Java コード例をご覧ください。"
---

PowerPoint の表は、情報を表示および伝える効率的な方法です。行と列に配置されたセルのグリッド内の情報は、シンプルで理解しやすいです。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Table) クラス、[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITable) インターフェイス、[Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) クラス、[ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) インターフェイス、およびその他の型を提供し、さまざまなプレゼンテーションで表を作成、更新、管理できるようにします。

## **ゼロから表を作成する**

1. Presentation クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。 
3. `columnWidth` の配列を定義します。
4. `rowHeight` の配列を定義します。
5. addTable メソッドを使用して、スライドに ITable オブジェクトを追加します。
6. 各 ICell を反復処理し、上、下、右、左の境界線に書式設定を適用します。
7. テーブルの最初の行の最初の 2 つのセルを結合します。 
8. ICell の TextFrame にアクセスします。
9. TextFrame にテキストを追加します。
10. 変更されたプレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // 列の幅と行の高さを定義します
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // スライドにテーブル シェイプを追加します
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの枠線書式を設定します
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // 行 1 のセル 1 と 2 を結合します
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // 結合されたセルにテキストを追加します
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // プレゼンテーションをディスクに保存します
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **標準的な表の番号付け**

標準的な表では、セルの番号付けはシンプルで 0 から始まります。表の最初のセルは 0,0（列 0、行 0）としてインデックス付けされます。 

たとえば、4 列 4 行の表のセルは次のように番号付けされます:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // 列の幅と行の高さを定義します
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル シェイプを追加します
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの枠線書式を設定します
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // プレゼンテーションをディスクに保存します
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **既存の表にアクセスする**

1. Presentation クラスのインスタンスを作成します。

2. インデックスを使用して、表が含まれるスライドへの参照を取得します。 

3. ITable オブジェクトを作成し、null に設定します。

4. 表が見つかるまで、すべての IShape オブジェクトを反復処理します。  
   スライドに単一の表が含まれていると考えられる場合は、含まれるすべてのシェイプを単純にチェックできます。シェイプが表として識別されたら、Table オブジェクトに型キャストできます。ただし、スライドに複数の表が含まれている場合は、setAlternativeText(String value) を使用して目的の表を検索した方がよいでしょう。

5. ITable オブジェクトを使用して表を操作します。以下の例では、表に新しい行を追加しました。

6. 変更されたプレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // null の TableEx を初期化します
    ITable tbl = null;

    // 形状を反復処理し、見つかったテーブルへの参照を設定します
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // 第2行の第1列のテキストを設定します
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // 変更されたプレゼンテーションをディスクに保存します
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **表内のテキストを配置する**

1. Presentation クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。 
3. スライドに ITable オブジェクトを追加します。
4. 表から ITextFrame オブジェクトにアクセスします。
5. ITextFrame の IParagraph にアクセスします。
6. テキストを垂直方向に配置します。
7. 変更されたプレゼンテーションを保存します。

```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 列の幅と行の高さを定義します
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // スライドにテーブル シェイプを追加します
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // テキストフレームにアクセスします
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // テキストフレーム用の Paragraph オブジェクトを作成します
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Paragraph 用の Portion オブジェクトを作成します
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // テキストを垂直方向に配置します
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // プレゼンテーションをディスクに保存します
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **表レベルでテキスト書式設定を行う**

1. Presentation クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。 
3. スライドから ITable オブジェクトにアクセスします。
4. テキストの setFontHeight(float value) を設定します。
5. setAlignment(int value) と setMarginRight(float value) を設定します。
6. setTextVerticalType(byte value) を設定します。
7. 変更されたプレゼンテーションを保存します。 

```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("simpletable.pptx");
try {
    // 最初のスライドの最初のシェイプがテーブルであると仮定します
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // テーブルセルのフォント高さを設定します
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // テーブルセルのテキスト配置と右余白を一度に設定します
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // テーブルセルのテキスト縦方向タイプを設定します
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **表のスタイルプロパティを取得する**

Aspose.Slides では、表のスタイルプロパティを取得でき、他の表や別の場所でその詳細を使用できます。この Java コードは、表のプリセットスタイルからスタイルプロパティを取得する方法を示しています。

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


## **表のアスペクト比をロックする**

幾何学的形状のアスペクト比とは、異なる次元におけるサイズの比率です。Aspose.Slides は、表やその他のシェイプのアスペクト比設定をロックできるように、[**setAspectRatioLocked**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) プロパティを提供しています。

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // 反転

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

はい。表は setRightToLeft メソッドを提供し、段落には ParagraphFormat.setRightToLeft があります。両方を使用することで、セル内の RTL の順序と描画が正しく行われます。

**How can I prevent users from moving or resizing a table in the final file?**

シェイプ ロックを使用して、移動、サイズ変更、選択などを無効にします。これらのロックは表にも適用されます。

**Is inserting an image inside a cell as a background supported?**

はい。セルに picture fill を設定できます。選択したモード（伸縮またはタイル）に従って、画像がセル領域を覆います。