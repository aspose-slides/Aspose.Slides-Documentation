---
title: JavaScript でプレゼンテーションの表を管理する
linktitle: 表を管理する
type: docs
weight: 10
url: /ja/nodejs-java/manage-table/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js を使用して PowerPoint スライドの表を作成および編集します。表の操作を簡素化するコード例をご紹介します。"
---
## **はじめに**

PowerPoint の表は情報を行と列に整理し、値の読み取りや比較を容易にします。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) クラス、[Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) クラス、およびその他の型を提供し、プレゼンテーション内の表の作成、更新、管理が可能です。

## **ゼロから表を作成する**

位置、列幅、行高さを指定して表を作成します。スライドに追加した後、セルの罫線を書式設定したり、セルを結合したり、テキストを挿入したりできます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 列幅（ポイント）の配列を定義します。
4. 行高さ（ポイント）の配列を定義します。
5. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) メソッドで、スライドに [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) オブジェクトを追加します。
6. 各 [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) を反復し、上、下、右、左の罫線に書式設定を適用します。
7. 表の最初の行の最初の 2 つのセルを結合します。
8. 結合されたセルを、その [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) メソッドで取得します。
9. 結合セルにテキストを設定します。
10. 変更されたプレゼンテーションを保存します。

以下の例は、(100, 50) ポイントの位置に列 3、行 5 の表を作成します。幅 5 ポイントの赤色罫線を適用し、最初の行の最初の 2 つのセルを結合し、結果を `table.pptx` として保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **標準表の番号付け**

標準表では、セルインデックスは 0 から始まり、順序は (列, 行) です。最初のセルは (0, 0) としてインデックス付けされます。

たとえば、4 列 4 行の表のセルは次のように番号付けされます：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この例は、上図の 4 × 4 表を作成し、列幅と行高さを 70 ポイント、罫線を幅 5 ポイントの赤色に設定します。座標はセルインデックスを示しています。セルは空のままにし、表を `StandardTables_out.pptx` として保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **既存の表へアクセスする**

表はスライドのシェイプコレクションに格納されています。シェイプを走査して表を見つけ、[Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) クラスでセルを読み取ったり更新したりします。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
2. インデックスで、表が含まれるスライドへの参照を取得します。
3. [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) オブジェクトを反復し、表が見つかったら停止します。スライドに複数の表がある場合は、[getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) を使用して目的の表を識別します。
4. 対象セルのテキストを更新します。
5. 変更されたプレゼンテーションを保存します。

以下の例は `UpdateExistingTable.pptx` を開き、最初のスライドの最初の表を見つけます。列 0、行 1 のセルに `New` を設定し、結果を `table1_out.pptx` として保存します。入力ファイルは少なくとも 1 つのスライドを含み、該当スライドの最初の表は少なくとも 1 列 2 行を持っている必要があります。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

既存の表で行のサイズを変更し、実際の高さが要求された最小値を超える理由を理解するには、[行高さの制御](/slides/ja/nodejs-java/manage-rows-and-columns/#control-row-height) を参照してください。

## **テキストフレームの所有セルを取得する**

テーブルから取得した [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) を扱う汎用テキスト処理コードでは、[TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) メソッドを使用して所有者である [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) を取得します。テーブルセルのテキストフレームの場合、[TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) は所有セルを返し、[TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) は `null` を返します（テーブル自体はシェイプですが例外です）。

セルの座標は読み取り専用の [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) と [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) メソッドで取得できます。[TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) は所有セルを返すだけで所有権を変更しない読み取り専用ナビゲーションも提供します。使用前に返されたセルが `null` でないことを必ず確認してください。

テーブルセルとシェイプの所有者（SmartArt ノードに関連付けられたシェイプを含む）を特定する完全な例については、[テキストの検索と置換](/slides/ja/nodejs-java/search-and-replace-text/) を参照してください。

## **表内のテキストを揃える**

個々のセルの垂直アンカリングとテキスト方向を制御できます。このセクションの例では、最初のセル内のテキストを中央揃えにし、270 度回転させます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) オブジェクトを追加します。
4. 表から [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) オブジェクトを取得します。
5. 最初の [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) にアクセスし、テキストと色を設定します。
6. [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) と [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-) を使用してセルの垂直アンカリングとテキスト方向を設定します。
7. 変更されたプレゼンテーションを保存します。

この例は、列幅 120 ポイント、行高さ 100 ポイントの 4 × 4 表を作成します。セル (0, 0) のテキストを書式設定し、最初の行の残りのセルに値を追加して、結果を `Vertical_Align_Text_out.pptx` として保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルレベルでテキスト書式設定を行う**

[setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) を使用して、テーブル内のすべてのセルにテキスト書式設定を適用できます。オーバーロードにより、ポーション、段落、テキストフレームの書式設定を受け取り、個々のセルを走査せずにこれらのプロパティを設定できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
2. インデックスでスライドへの参照を取得します。
3. スライドから [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) オブジェクトを取得します。
4. テキストのフォントサイズを [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) で 25 ポイントに設定します。
5. [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) と [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) を使用して段落を右揃えにし、右余白を 20 ポイントに設定します。
6. [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) でテキスト方向を垂直に設定します。
7. 変更されたプレゼンテーションを保存します。

以下の例は `table.pptx` を開きます。このファイルは少なくとも 1 つのスライドを含み、その最初のシェイプが表である必要があります。フォントサイズを 25 ポイントに設定し、段落を右揃えにして右余白を 20 ポイント、テキストを垂直にします。書式設定されたプレゼンテーションは `result.pptx` として保存されます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルのスタイルプロパティを取得する**

[getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) で表のプリセットスタイルを取得し、[setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) で割り当てます。この例では [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) を 1 つの表に適用し、プリセット値を出力し、同じプリセットを別の表に設定します。両方の表は `table-style.pptx` に保存されます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **表のアスペクト比をロックする**

表のアスペクト比は幅と高さの比率です。[setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) を使用してこの比率をロックできます。

以下の例は `pres.pptx` を開きます。このファイルは少なくとも 1 つのスライドを含み、その最初のシェイプが表である必要があります。現在のロック状態を出力し、アスペクト比ロックを有効にして更新された状態 (`true`) を出力し、結果を `pres-out.pptx` として保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**テーブル全体とセル内のテキストに対して右から左 (RTL) の読み方向を有効にできますか？**

はい。テーブルは [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) メソッドを公開しており、段落は [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-) を持ちます。両方を使用すると、セル内で正しい RTL 順序とレンダリングが保証されます。

**最終ファイルでユーザーが表を移動またはサイズ変更できないようにするにはどうすればよいですか？**

[shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックは表にも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) を設定できます。選択したモード（伸縮またはタイル）に従って、画像がセル領域全体を覆います。