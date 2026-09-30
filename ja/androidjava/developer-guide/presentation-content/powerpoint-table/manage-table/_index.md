---
title: Android でプレゼンテーションテーブルを管理する
linktitle: テーブル管理
type: docs
weight: 10
url: /ja/androidjava/manage-table/
keywords:
- テーブルを追加
- テーブルを作成
- テーブルにアクセス
- アスペクト比
- テキストの配置
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PowerPoint スライド内のテーブルを作成および編集します。テーブル操作を効率化するシンプルな Java コード例をご紹介します。"
---
## **導入**

PowerPoint の表は情報を行と列に整理し、値の読み取りや比較を容易にします。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) インターフェイス、[Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) クラス、[ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) インターフェイスなどの型を提供し、プレゼンテーション内で表の作成、更新、管理を可能にします。

## **スクラッチから表を作成する**

位置、列幅、行高さを指定して表を作成します。スライドに追加した後、セルの罫線の書式設定、セルの結合、テキストの挿入が可能です。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. ポイント単位で列幅の配列を定義します。
4. ポイント単位で行高さの配列を定義します。
5. [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) メソッドを使用して [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) オブジェクトをスライドに追加します。
6. 各 [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) を反復処理し、上、下、右、左の罫線に書式を適用します。
7. 表の最初の行の最初の 2 つのセルを結合します。
8. 結合されたセルをその [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) メソッドで取得します。
9. 結合されたセルにテキストを設定します。
10. 変更されたプレゼンテーションを保存します。

以下の例は、(100, 50) ポイントの位置に列が 3、行が 5 の表を作成し、幅 5 ポイントの赤い罫線を適用し、最初の行の最初の 2 つのセルを結合し、結果を `table.pptx` として保存します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **標準テーブルのインデックス付け**

標準テーブルでは、セルのインデックスはゼロベースで (列, 行) の順序で使用されます。最初のセルは (0, 0) とインデックス付けされます。

例えば、4 列 4 行のテーブルのセルは次のように番号付けされます。

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この例は、上記の 4 × 4 テーブルを作成し、列幅と行高さを 70 ポイント、罫線を幅 5 ポイントの赤で設定します。座標はセルインデックスを示しています。セルは空のままで、テーブルは `StandardTables_out.pptx` として保存されます。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **既存のテーブルにアクセスする**

テーブルはスライドのシェイプコレクションに格納されます。シェイプを走査してテーブルを見つけ、[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) インターフェイスを使用してセルの読み取りまたは更新を行います。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. インデックスでテーブルが含まれるスライドへの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) オブジェクトを走査し、テーブルが見つかった時点で停止します。スライドに複数のテーブルがある場合は、[getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) を使用して目的のテーブルを特定します。
4. 対象セルのテキストを更新します。
5. 変更されたプレゼンテーションを保存します。

以下の例は `UpdateExistingTable.pptx` を開き、最初のスライドの最初のテーブルを見つけます。列 0、行 1 のセルに `New` を設定し、結果を `table1_out.pptx` として保存します。入力には少なくとも 1 枚のスライドが含まれ、該当スライドの最初のテーブルは少なくとも 1 列 2 行を持っている必要があります。

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

行の高さを変更し、実際の高さが要求された最小値を超える理由を理解するには、[行の高さの制御](/slides/ja/androidjava/manage-rows-and-columns/#control-row-height) を参照してください。

## **テキストフレームを所有するセルの取得**

テーブルから取得した [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) を処理する汎用コードでは、[ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) メソッドを使用して所有する [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) を取得します。テーブルセルのテキストフレームに対しては、[ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) が所有者を返し、[ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) は `null` を返します (テーブル自体はシェイプです)。

セルの座標は、読み取り専用の [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) と [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) メソッドで取得できます。 [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) は読み取り専用のナビゲーションも提供し、所有者を返しますが所有権は変更しません。使用する前に返されたセルが `null` でないことを必ず確認してください。

テーブルセルとシェイプの所有者を識別する完全な例（SmartArt ノードに関連付けられたシェイプを含む）については、[テキストの検索と置換](/slides/ja/androidjava/search-and-replace-text/) を参照してください。

## **テーブル内のテキストの配置**

個々のテーブルセルの垂直アンカーとテキスト方向を制御できます。このセクションの例は、最初のセルのテキストを中央揃えにし、270 度回転させます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) オブジェクトを追加します。
4. 表から [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) オブジェクトを取得します。
5. 最初の [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) にアクセスし、テキストとカラーを設定します。
6. [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) と [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) を使用してセルの垂直アンカーとテキスト方向を設定します。
7. 変更されたプレゼンテーションを保存します。

この例は列幅 120 ポイント、行高さ 100 ポイントの 4 × 4 テーブルを作成し、セル (0, 0) のテキストを書式設定し、最初の行の残りのセルに値を追加して、結果を `Vertical_Align_Text_out.pptx` として保存します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **テーブルレベルでのテキスト書式設定**

[setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) を使用して、テーブル内のすべてのセルにテキスト書式設定を適用できます。オーバーロードにより、部分、段落、テキストフレームの書式設定を受け取り、個々のセルを走査せずにこれらのプロパティを設定できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. インデックスでスライドへの参照を取得します。
3. スライドから [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) オブジェクトを取得します。
4. テキストのフォントサイズを [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) で設定します。
5. [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) と [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) を使用して段落の配置と右余白を設定します。
6. [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) でテキスト方向を設定します。
7. 変更されたプレゼンテーションを保存します。

以下の例は `table.pptx`（少なくとも 1 枚のスライドがあり、最初のシェイプがテーブルである必要があります）を開き、フォントサイズを 25 ポイント、段落を右揃えにし右余白を 20 ポイントに設定し、テキストを縦向きにします。書式設定されたプレゼンテーションは `result.pptx` として保存されます。

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

[getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) でテーブルのプリセットスタイルを取得し、[setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) で設定できます。この例は [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) を 1 つのテーブルに適用し、プリセット値を出力し、同じプリセットを 2 番目のテーブルに割り当てます。両方のテーブルは `table-style.pptx` に保存されます。

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

## **テーブルの縦横比をロックする**

テーブルの縦横比は幅と高さの比率です。[setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) を使用してこの比率をロックできます。

以下の例は `pres.pptx`（少なくとも 1 枚のスライドがあり、最初のシェイプがテーブルである必要があります）を開き、現在のロック状態を出力し、縦横比ロックを有効にして更新後の状態 (`true`) を出力し、結果を `pres-out.pptx` として保存します。

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

**テーブル全体とセル内のテキストに対して右から左 (RTL) 読み方向を有効にできますか？**

はい。テーブルは [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) メソッドを公開しており、段落は [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) を持ちます。両方を使用すると、セル内の正しい RTL 順序と描画が保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするにはどうすればよいですか？**

[shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) を設定できます。画像は選択したモード (ストレッチまたはタイル) に従ってセル領域全体を覆います。