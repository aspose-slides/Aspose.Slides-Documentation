---
title: Java でプレゼンテーションの表を管理する
linktitle: 表の管理
type: docs
weight: 10
url: /ja/java/manage-table/
keywords:
- 表の追加
- 表の作成
- 表へのアクセス
- アスペクト比
- テキストの配置
- テキスト書式設定
- 表スタイル
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint スライド内の表を作成および編集します。表の操作を効率化するシンプルなコード例をご覧ください。"
---
## **概要**

PowerPoint の表は情報を効率的に表示・提示する方法です。行と列で構成されたセルのグリッドに入った情報はシンプルで理解しやすいです。

Aspose.Slides は、[Table] クラス、[ITable] インターフェイス、[Cell] クラス、[ICell] インターフェイス、その他の型を提供し、さまざまなプレゼンテーションで表を作成、更新、管理できるようにします。

## **ゼロから表を作成する**

1. [Presentation] クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。 
3. `columnWidth` の配列を定義します。
4. `rowHeight` の配列を定義します。
5. [addTable] メソッドを使用してスライドに [ITable] オブジェクトを追加します。
6. 各 [ICell] を反復処理し、上・下・右・左の罫線に書式設定を適用します。
7. 表の最初の行の最初の 2 つのセルを結合します。 
8. [ICell] の [TextFrame] にアクセスします。 
9. [TextFrame] にテキストを追加します。
10. 変更されたプレゼンテーションを保存します。

この Java コードは、プレゼンテーション内に表を作成する方法を示します。

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // 列の幅と行の高さを定義します
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // スライドにテーブルシェイプを追加します
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの罫線書式を設定します
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
    // 1 行目のセル 1 と 2 を結合します
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // 結合されたセルにテキストを追加します
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // プレゼンテーションをディスクに保存します
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **標準的な表の番号付け**

標準的な表では、セルの番号付けはシンプルで 0 始まりです。表の最初のセルは 0,0（列 0、行 0）とインデックス付けされます。

たとえば、4 列 4 行の表のセルは次のように番号付けされます:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この Java コードは、表のセルの番号付けを指定する方法を示します。

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // 列の幅と行の高さを定義します
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブルシェイプを追加します
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの罫線書式を設定します
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

1. [Presentation] クラスのインスタンスを作成します。

2. インデックスを使用して、表が含まれるスライドへの参照を取得します。 

3. [ITable] オブジェクトを作成し、null に設定します。

4. 表が見つかるまで、すべての [IShape] オブジェクトを反復処理します。

   スライドに単一の表しか含まれていないと疑われる場合は、含まれるすべてのシェイプをチェックすれば済みます。シェイプが表として識別されたら、[Table] オブジェクトに型変換できます。ただし、スライドに複数の表が含まれている場合は、[setAlternativeText(String value)] を使用して目的の表を検索した方が確実です。

5. [ITable] オブジェクトを使用して表を操作します。以下の例では、表に新しい行を追加しています。

6. 変更されたプレゼンテーションを保存します。

この Java コードは、既存の表にアクセスして操作する方法を示します。

```java
import com.aspose.slides.*;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // null の TableEx を初期化します
    ITable tbl = null;

    // シェイプを反復処理し、見つかった表への参照を設定します
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // 2 行目の 1 列目のテキストを設定します
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // 変更されたプレゼンテーションをディスクに保存します
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストフレームを所有するセルを見つける**

汎用的なテキスト処理コードが表から [ITextFrame] を受け取った場合、所有する [ICell] を取得するために [ITextFrame.getParentCell] メソッドを使用します。表セルのテキストフレームでは、[ITextFrame.getParentCell] は所有者を返し、[ITextFrame.getParentShape] は `null` を返します（表自体はシェイプであるにもかかわらず）。

セルの座標は、読み取り専用の [ICell.getFirstColumnIndex] および [ICell.getFirstRowIndex] メソッドで取得できます。[ITextFrame.getParentCell] も読み取り専用のナビゲーションを提供し、所有者を返しますが所有権は変更しません。使用前に返されたセルが `null` でないことを必ず確認してください。

テーブルセルとシェイプの所有者（SmartArt ノードに関連付けられたシェイプを含む）を特定する完全な例については、[Search and Replace Text](/slides/ja/java/search-and-replace-text/) を参照してください。

## **表内のテキストを配置する**

1. [Presentation] クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。 
3. スライドに [ITable] オブジェクトを追加します。 
4. 表から [ITextFrame] オブジェクトにアクセスします。 
5. [ITextFrame] の [IParagraph] にアクセスします。
6. テキストを垂直方向に配置します。
7. 変更されたプレゼンテーションを保存します。

この Java コードは、表内のテキストを配置する方法を示します。

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 列の幅と行の高さを定義します
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // スライドにテーブルシェイプを追加します
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

1. [Presentation] クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。 
3. スライドから [ITable] オブジェクトにアクセスします。
4. テキストの [setFontHeight(float value)] を設定します。 
5. [setAlignment(int value)] と [setMarginRight(float value)] を設定します。 
6. [setTextVerticalType(byte value)] を設定します。
7. 変更されたプレゼンテーションを保存します。 

この Java コードは、表内のテキストに希望する書式設定オプションを適用する方法を示します。

```java
import com.aspose.slides.*;

// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("simpletable.pptx");
try {
    // 最初のスライドの最初のシェイプが表であると仮定します
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // 表セルのフォント高さを設定します
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // 表セルのテキスト配置と右余白を一度に設定します
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // 表セルのテキスト垂直方向タイプを設定します
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **表のスタイル プロパティを取得する**

Aspose.Slides は、表のスタイル プロパティを取得できるため、別の表や他の場所でその詳細を利用できます。この Java コードは、表のプリセット スタイルからスタイル プロパティを取得する方法を示します。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // デフォルトのスタイルプリセットテーマを変更します

    // テーブルのスタイルプリセットを取得します
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // 取得したスタイルプリセットを別のテーブルに適用します
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **表のアスペクト比をロックする**

幾何学的形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slides は、表やその他のシェイプのアスペクト比設定をロックできるように、[**setAspectRatioLocked**] プロパティを提供しています。 

この Java コードは、表のアスペクト比をロックする方法を示します。

```java
import com.aspose.slides.*;

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

**テーブル全体とセル内のテキストに右から左 (RTL) の読み方向を設定できますか？**

はい。テーブルは [setRightToLeft] メソッドを公開しており、段落は [ParagraphFormat.setRightToLeft] を持ちます。両方を使用することで、セル内の正しい RTL 順序と描画が保証されます。

**最終ファイルでユーザーが表を移動またはサイズ変更できないようにするにはどうすればよいですか？**

[shape locks](/slides/ja/java/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックは表にも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに [picture fill] を設定できます。画像は選択したモード（伸縮またはタイル）に従ってセル領域を覆います。