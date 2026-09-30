---
title: Javaでプレゼンテーションの表を管理
linktitle: 表の管理
type: docs
weight: 10
url: /ja/java/manage-table/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint スライドの表を作成および編集します。表のワークフローを効率化するシンプルなコード例をご覧ください。"
---
## **はじめに**

PowerPoint の表は情報を行と列に整理し、値の読み取りと比較を容易にします。

Aspose.Slides は [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) インターフェイス、[Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) クラス、[ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) インターフェイス、およびその他の型を提供し、プレゼンテーション内で表の作成、更新、管理を可能にします。

## **スクラッチから表を作成**

位置、列幅、行高さを指定して表を作成します。スライドに追加した後、セルの枠線をフォーマットし、セルを結合し、テキストを挿入できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 列幅の配列（ポイント単位）を定義します。
4. 行高さの配列（ポイント単位）を定義します。
5. [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドを使用して、スライドに [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) オブジェクトを追加します。
6. 各 [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) を反復処理し、上・下・右・左の枠線に書式を適用します。
7. 表の最初の行の最初の 2 つのセルを結合します。
8. 結合されたセルを [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) メソッドで取得します。
9. 結合セルにテキストを設定します。
10. 変更されたプレゼンテーションを保存します。

以下の例は、(100, 50) ポイントの位置に 3 列 5 行の表を作成し、幅 5 ポイントの赤い枠線を適用し、最初の行の最初の 2 つのセルを結合し、結果を `table.pptx` として保存します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **標準表の番号付け**

標準表ではセルインデックスは 0 から始まり、順序は (列, 行) です。最初のセルは (0, 0) とインデックス付けされます。

例えば、4 列 4 行の表のセルは次のように番号付けされます。

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この例は上記の 4 × 4 表を作成し、列幅と行高さを 70 ポイント、枠線を幅 5 ポイントの赤に設定します。座標はセルインデックスを示しています。例ではセルを空のままにし、表を `StandardTables_out.pptx` として保存します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **既存の表にアクセスする**

表はスライドのシェイプコレクションに格納されています。シェイプを反復処理して表を見つけ、[ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) インターフェイスを使用してセルを読み取ったり更新したりできます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. インデックスで表が含まれるスライドへの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) オブジェクトを反復処理し、表が見つかった時点で停止します。スライドに複数の表がある場合は、[getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) を使用して目的の表を識別します。
4. 対象セルのテキストを更新します。
5. 変更されたプレゼンテーションを保存します。

以下の例は `UpdateExistingTable.pptx` を開き、最初のスライド上の最初の表を見つけます。列 0、行 1 のセルに `New` を設定し、結果を `table1_out.pptx` として保存します。入力には少なくとも 1 枚のスライドが必要で、対象スライド上の最初の表は少なくとも 1 列 2 行を持つ必要があります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

既存の表の行のサイズを変更し、実際の高さが要求された最小高さを超える理由を理解するには、[Control Row Height](/slides/ja/java/manage-rows-and-columns/#control-row-height) を参照してください。

## **テキストフレームを所有するセルを見つける**

テーブルから取得した [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) を汎用テキスト処理コードが受け取った場合、[ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) メソッドを使用して所有する [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) を取得します。テーブルセルのテキストフレームに対しては、[ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) は所有者を返し、[ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) は `null` を返します（テーブル自体はシェイプです）。

セルの座標は読み取り専用の [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) と [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) メソッドで取得できます。[ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) は所有者を返しますが所有権を変更しません。常に取得したセルが `null` でないことを確認してから使用してください。

テーブルセルとシェイプの所有者を特定する完全な例（SmartArt ノードに関連付けられたシェイプを含む）については、[Search and Replace Text](/slides/ja/java/search-and-replace-text/) を参照してください。

## **表内のテキストの配置**

個々のテーブルセルの垂直アンカリングとテキスト方向を制御できます。このセクションの例は、最初のセル内のテキストを中央揃えにし、270 度回転させます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) オブジェクトを追加します。
4. テーブルから [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) オブジェクトを取得します。
5. 最初の [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) にアクセスし、テキストと色を設定します。
6. [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) と [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-) を使用してセルの垂直アンカリングとテキスト方向を設定します。
7. 変更されたプレゼンテーションを保存します。

この例は列幅 120 ポイント、行高さ 100 ポイントの 4 × 4 表を作成し、セル (0, 0) のテキストをフォーマットし、最初の行の残りのセルに値を追加し、結果を `Vertical_Align_Text_out.pptx` として保存します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルレベルでテキスト書式を設定する**

[setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) を使用して、テーブル内のすべてのセルにテキスト書式を適用します。そのオーバーロードは部分、段落、テキストフレームの書式設定を受け入れるため、個々のセルを反復処理せずにこれらのプロパティを設定できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. インデックスでスライドへの参照を取得します。
3. スライドから [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) オブジェクトを取得します。
4. テキストのフォントサイズを [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) で設定します。
5. [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を使用して段落の配置と右余白を設定します。
6. [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) でテキスト方向を設定します。
7. 変更されたプレゼンテーションを保存します。

以下の例は `table.pptx` を開きます。このファイルは少なくとも 1 枚のスライドを含み、最初のシェイプが表である必要があります。フォントサイズを 25 ポイントに設定し、右余白 20 ポイントで右揃えにし、テキストを縦向きにします。書式設定されたプレゼンテーションは `result.pptx` として保存されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルスタイルプロパティの取得**

[getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) を使用してテーブルのプリセットスタイルを読み取り、[setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) で割り当てます。この例は [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) を 1 つの表に適用し、プリセット値を出力し、同じプリセットを 2 番目の表に割り当てます。両方の表は `table-style.pptx` に保存されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルのアスペクト比を固定する**

テーブルのアスペクト比は幅と高さの比率です。[setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) を使用してこの比率をロックできます。

以下の例は `pres.pptx` を開きます。このファイルは少なくとも 1 枚のスライドを含み、最初のシェイプが表である必要があります。現在のロック状態を出力し、アスペクト比ロックを有効にし、更新された状態（`true`）を出力し、結果を `pres-out.pptx` として保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**テーブル全体とセル内テキストの右から左 (RTL) 読み取り方向を有効にできますか？**

はい。テーブルは [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-) メソッドを公開し、段落は [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) を持ちます。両方を使用することで、セル内の正しい RTL 順序と描画が保証されます。

**最終ファイルでテーブルの移動やサイズ変更をユーザーに禁止するにはどうすればよいですか？**

[shape locks](/slides/ja/java/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にできます。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（伸張またはタイル）に従ってセル領域をカバーします。