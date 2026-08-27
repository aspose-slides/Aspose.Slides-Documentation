---
title: JavaScript でプレゼンテーションテーブルを管理する
linktitle: テーブルの管理
type: docs
weight: 10
url: /ja/nodejs-java/manage-table/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js を使用して、PowerPoint スライド内のテーブルを作成および編集します。テーブル操作を効率化するシンプルなコード例をご覧ください。"
---
## **概要**

PowerPoint のテーブルは情報を表示および表現する効率的な方法です。行と列に配置されたセルのグリッド内の情報はシンプルで理解しやすいです。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Table) クラス、[Cell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cell/) クラス、およびその他の型を提供し、さまざまなプレゼンテーションでテーブルの作成、更新、管理を可能にします。

## **テーブルをゼロから作成**

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [addTable](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) メソッドを使用して、スライドに [Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Table) オブジェクトを追加します。  
6. 各 [Cell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cell/) を反復処理し、上、下、右、左の境界線に書式設定を適用します。  
7. テーブルの左上隅にある 4 つのセル（最初の 2 列と最初の 2 行）を 1 つのセルに結合します。  
8. [Cell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cell/) の [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスします。  
9. [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にテキストを追加します。  
10. 変更したプレゼンテーションを保存します。

この JavaScript コードは、プレゼンテーションでテーブルを作成する方法を示しています：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスします
    var sld = pres.getSlides().get_Item(0);
    // 列の幅と行の高さを定義します
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // スライドにテーブル シェイプを追加します
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 各セルの罫線書式を設定します
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // 左上の 2x2 セルブロックを 1 つのセルに結合します
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // 結合されたセルにテキストを追加します
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // プレゼンテーションをディスクに保存します
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **標準テーブルの番号付け**

標準テーブルでは、セルの番号付けはシンプルでゼロベースです。テーブルの最初のセルは 0,0（列 0、行 0）としてインデックス付けされます。

例として、4 列 4 行のテーブルのセルは次のように番号付けされます：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この JavaScript コードは、テーブル内のセルの番号付けを指定する方法を示しています：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスします
    var sld = pres.getSlides().get_Item(0);
    // 列の幅と行の高さを定義します
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // スライドにテーブル シェイプを追加します
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 各セルの罫線書式を設定します
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // プレゼンテーションをディスクに保存します
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **既存のテーブルにアクセス**

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してテーブルを含むスライドへの参照を取得します。  
3. [Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Table) オブジェクトを作成し、null に設定します。  
4. [Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) オブジェクトをすべて反復処理して、テーブルが見つかるまで続けます。  
   対象のスライドに単一のテーブルが含まれていると疑う場合は、含まれるすべてのシェイプを単純にチェックできます。シェイプがテーブルとして識別されたら、[Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Table) オブジェクトに型キャストできます。ただし、対象のスライドに複数のテーブルが含まれている場合は、[setAlternativeText(String value)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) を使用して目的のテーブルを検索した方がよいでしょう。  
5. [Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Table) オブジェクトを使用してテーブルを操作します。以下の例では、テーブル内のセルのテキストを設定しています。  
6. 変更したプレゼンテーションを保存します。

この JavaScript コードは、既存のテーブルにアクセスして操作する方法を示しています：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // 最初のスライドにアクセスします
    var sld = pres.getSlides().get_Item(0);
    // null の TableEx を初期化します
    var tbl = null;
    // シェイプを走査し、見つかったテーブルへの参照を設定します
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // 2 行目の最初の列のテキストを設定します
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // 変更したプレゼンテーションをディスクに保存します
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **テキストフレームを所有するセルの取得**

テーブルから [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) を取得した汎用テキスト処理コードでは、所有する [Cell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cell/) を取得するために [TextFrame.getParentCell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParentCell--) メソッドを使用します。テーブルセルのテキストフレームの場合、[TextFrame.getParentCell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParentCell--) は所有者を返し、[TextFrame.getParentShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParentShape--) は `null` を返します（テーブル自体はシェイプであるにもかかわらず）。

セルの座標は、読み取り専用の [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) および [Cell.getFirstRowIndex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) メソッドで取得できます。[TextFrame.getParentCell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParentCell--) は所有者を返すだけで所有権を変更しない読み取り専用ナビゲーションも提供します。使用する前に、返されたセルが `null` でないことを必ず確認してください。

テーブルセルとシェイプの所有者（SmartArt ノードに関連付けられたシェイプを含む）を識別する完全な例については、[Search and Replace Text](/slides/ja/nodejs-java/search-and-replace-text/) を参照してください。

## **テーブル内のテキストを配置**

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに [Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Table) オブジェクトを追加します。  
4. テーブルから [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) オブジェクトにアクセスします。  
5. [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) の [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) にアクセスします。  
6. テキストを垂直方向に配置します。  
7. 変更したプレゼンテーションを保存します。

この JavaScript コードは、テーブル内のテキストを配置する方法を示しています：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します
    var slide = pres.getSlides().get_Item(0);
    // 列の幅と行の高さを定義します
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // スライドにテーブル シェイプを追加します
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // テキストフレームにアクセスします
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // テキストフレーム用の Paragraph オブジェクトを作成します
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Paragraph 用の Portion オブジェクトを作成します
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // テキストを垂直方向に配置します
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // プレゼンテーションをディスクに保存します
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **テーブルレベルでテキスト書式設定を行う**

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから [Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Table) オブジェクトにアクセスします。  
4. テキストの [setFontHeight(float value)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) を設定します。  
5. [setAlignment(int value)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) と [setMarginRight(float value)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) を設定します。  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) を設定します。  
7. 変更したプレゼンテーションを保存します。

この JavaScript コードは、テーブル内のテキストに好みの書式設定オプションを適用する方法を示しています：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // 最初のスライドの最初のシェイプがテーブルであると仮定します
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // テーブルセルのフォント高さを設定します
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // テーブルセルのテキスト配置と右マージンを一度の呼び出しで設定します
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // テーブルセルのテキスト垂直方向のタイプを設定します
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **テーブルスタイルのプリセットを設定**

Aspose.Slides は組み込みの PowerPoint テーブルスタイルを [TableStylePreset](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tablestylepreset/) 列挙型として提供しているため、任意のテーブルに同じ外観を適用できます。この JavaScript コードは、テーブルの既定スタイルをプリセットスタイルに置き換える方法を示しています：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// デフォルトのスタイルプリセットテーマを変更します
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **テーブルのアスペクト比をロック**

幾何学的形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slides は、テーブルやその他のシェイプのアスペクト比設定をロックできるように、[**setAspectRatioLocked**](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) プロパティを提供しています。

この JavaScriptコードは、テーブルのアスペクト比をロックする方法を示しています：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// 反転
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **よくある質問**

**テーブル全体およびセル内のテキストに右から左 (RTL) の読み方向を有効にできますか？**

はい。テーブルは [setRightToLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/table/setrighttoleft/) メソッドを提供し、段落には [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) があります。両方を使用することで、セル内の正しい RTL 順序とレンダリングが保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするにはどうすればよいですか？**

シェイプのロック機能を使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/) を設定できます。選択したモード（伸縮またはタイル）に従って画像がセル領域を覆います。