---
title: Android でプレゼンテーション テーブルを管理する
linktitle: テーブルの管理
type: docs
weight: 10
url: /ja/androidjava/manage-table/
keywords:
- テーブルを追加
- テーブルを作成
- テーブルにアクセス
- アスペクト比
- テキストを揃える
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PowerPoint スライドのテーブルを作成および編集します。テーブル操作を効率化するシンプルな Java コード例をご確認ください。"
---
## **概要**

PowerPoint の表は、情報を表示および表現する効率的な方法です。行と列に配置されたセルのグリッド内の情報は、シンプルで理解しやすいです。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Table) クラス、[ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITable) インターフェイス、[Cell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/cell/) クラス、[ICell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icell/) インターフェイス、およびその他の型を提供し、さまざまなプレゼンテーションで表の作成、更新、管理が可能です。

## **テーブルを最初から作成する**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` 配列を定義します。  
4. `rowHeight` 配列を定義します。  
5. [addTable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) メソッドを使用して、スライドに [ITable] オブジェクトを追加します。  
6. 各 [ICell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icell/) を反復処理し、上・下・右・左の罫線に書式設定を適用します。  
7. テーブルの最初の行の最初の 2 つのセルを結合します。  
8. [ICell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icell/) の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) にアクセスします。  
9. [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) にテキストを追加します。  
10. 変更されたプレゼンテーションを保存します。

この Java コードは、プレゼンテーションでテーブルを作成する方法を示しています：

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

    // スライドにテーブル形状を追加します
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
    // 行 1 のセル 1 と 2 を結合します
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // 結合されたセルにテキストを追加します
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // プレゼンテーションをディスクに保存します
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
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

この Java コードは、テーブルのセルの番号付けを指定する方法を示しています：

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

    // スライドにテーブル形状を追加します
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

## **既存のテーブルにアクセスする**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して、テーブルを含むスライドへの参照を取得します。  
3. [ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITable) オブジェクトを作成し、null に設定します。  
4. テーブルが見つかるまで、すべての [IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) オブジェクトを反復処理します。  
   スライドに単一のテーブルだけが含まれていると疑われる場合は、含まれるすべてのシェイプを単純にチェックできます。シェイプがテーブルとして識別されたら、[Table](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Table) オブジェクトに型変換できます。しかし、スライドに複数のテーブルが含まれている場合は、[setAlternativeText(String value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) メソッドを使用して目的のテーブルを検索した方が適切です。  
5. [ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITable) オブジェクトを使用してテーブルを操作します。以下の例では、テーブル内のセルのテキストを設定します。  
6. 変更されたプレゼンテーションを保存します。

この Java コードは、既存のテーブルにアクセスして操作する方法を示しています：

```java
import com.aspose.slides.*;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // null の TableEx を初期化します
    ITable tbl = null;

    // シェイプを反復処理し、見つかったテーブルへの参照を設定します
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

## **テキストフレームを所有するセルを見つける**

テーブルから取得した [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) を汎用的なテキスト処理コードが受け取った場合、所有する [ICell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icell/) を取得するために [ITextFrame.getParentCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentCell--) メソッドを使用します。テーブルセルのテキストフレームの場合、[ITextFrame.getParentCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentCell--) は所有者を返し、[ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentShape--) は `null` を返します（テーブル自体はシェイプであるにもかかわらず）。

セルの座標は、読み取り専用の [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) および [ICell.getFirstRowIndex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) メソッドで取得できます。[ITextFrame.getParentCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentCell--) も読み取り専用のナビゲーションを提供し、所有者を返しますが所有権は変更しません。使用する前に必ず返されたセルが `null` でないことを確認してください。

テーブルセルとシェイプの所有者（SmartArt ノードに関連付けられたシェイプを含む）を特定する完全な例については、[Search and Replace Text](/slides/ja/androidjava/search-and-replace-text/) を参照してください。

## **テーブル内のテキストを揃える**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに [ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITable) オブジェクトを追加します。  
4. テーブルから [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) オブジェクトにアクセスします。  
5. [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) の [IParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/) にアクセスします。  
6. テキストを垂直方向に揃えます。  
7. 変更されたプレゼンテーションを保存します。

この Java コードは、テーブル内のテキストを揃える方法を示しています：

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
    
    // スライドにテーブル形状を追加します
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
    
    // テキストを垂直方向に揃えます
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // プレゼンテーションをディスクに保存します
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルレベルでテキスト書式設定を行う**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから [ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITable) オブジェクトにアクセスします。  
4. テキストの [setFontHeight(float value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。  
5. [setAlignment(int value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を設定します。  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。  
7. 変更されたプレゼンテーションを保存します。

この Java コードは、テーブル内のテキストに好みの書式設定オプションを適用する方法を示しています：

```java
import com.aspose.slides.*;

// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("simpletable.pptx");
try {
    // 最初のスライドの最初のシェイプがテーブルであると仮定します
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // テーブルセルのフォントの高さを設定します
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // テーブルセルのテキスト配置と右余白を一度に設定します
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // テーブルセルのテキストの垂直方向を設定します
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルのスタイルプロパティを取得する**

Aspose.Slides を使用すると、テーブルのスタイルプロパティを取得でき、取得した詳細を別のテーブルや他の場所で使用できます。この Java コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // デフォルトのスタイルプリセットテーマを変更します

    // テーブルのスタイルプリセットを取得する
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // 取得したスタイルプリセットを別のテーブルに適用する
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルのアスペクト比をロックする**

幾何学的形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slides は、テーブルやその他のシェイプのアスペクト比設定をロックできるように、[**setAspectRatioLocked**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) プロパティを提供しています。

この Java コードは、テーブルのアスペクト比をロックする方法を示しています：

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

**テーブル全体とセル内のテキストに右から左 (RTL) の読書方向を有効にできますか？**

はい。テーブルは [setRightToLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) メソッドを公開しており、段落には [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) があります。両方を使用することで、セル内の正しい RTL 順序と描画が保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするにはどうすればよいですか？**

シェイプのロックを使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに [picture fill](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（ストレッチまたはタイル）に従ってセル領域を覆います。