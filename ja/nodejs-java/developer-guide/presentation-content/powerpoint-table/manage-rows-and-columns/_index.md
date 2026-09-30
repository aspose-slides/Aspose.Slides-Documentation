---
title: JavaScript を使用して PowerPoint テーブルの行と列を管理する
linktitle: 行と列
type: docs
weight: 20
url: /ja/nodejs-java/manage-rows-and-columns/
keywords:
- テーブル行
- テーブル列
- 最初の行
- テーブルヘッダー
- 行の複製
- 列の複製
- 行のコピー
- 列のコピー
- 行の削除
- 列の削除
- 行のテキスト書式設定
- 列のテキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js via Java を使用して PowerPoint のテーブル行と列を管理し、プレゼンテーションの編集やデータ更新を高速化します。"
---
## **はじめに**

Aspose.Slides for Node.js via Java を使用すると、PowerPoint プレゼンテーション内のテーブル構造と書式設定を [テーブル](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) クラスで管理できます。ヘッダー行を指定したり、行や列を複製または削除したり、行または列全体にテキスト書式を適用したりできます。

この記事では、JavaScript の例を用いてこれらの操作を説明します。また、テーブルのスタイルプリセットを取得して再利用する方法も示します。テーブルの行と列のインデックスは 0 ベースです。

## **行の高さの制御**

ポイント単位で行の最小高さを設定するには、[Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) を使用します。これは下限であり、固定高さではありません。[Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) は実際の高さを返します。行は [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--) で取得します。

この例では、[row-height-input.pptx](row-height-input.pptx) を読み込みます。このファイルは、最初のスライドの最初のシェイプとしてテーブルを持ちます。最初の行は 70 ポイントから始まります。セルは 18 ポイントの Arial テキスト、折り返し、上下 6 ポイントの余白を使用しています。2 列目の長いテキストは複数行に折り返されます。例では、最小高さを 100 ポイントに増やし、次に 20 ポイントに減らし、各変更後に実際の高さを出力し、両方の結果を保存します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

提供されたプレゼンテーションでは、最小高さを増やすと行に余白が追加されます。減らすと余分なスペースが削除されますが、テキストとセルの余白がより多くの領域を必要とするため、実際の高さは 20 ポイントより大きくなります。最小高さを下げるだけでは、内容が必要とするスペース以下に行を強制することはできません。

実際の高さに影響を与える要因は複数あります。

- **テキストとフォントサイズ:** 長いテキスト、明示的な改行、または大きなフォントは、垂直方向のスペースを多く必要とします。
- **折り返しと列幅:** 折り返しが有効な場合、[Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) で列幅を狭めると行数が増えます。列幅を広げると垂直方向の必要スペースを減らすことができます。
- **セルの余白:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) と [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) は垂直方向の余白を追加します。[Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) と [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) はテキストに利用できる幅を減らし、折り返しが増える原因となります。

結合セルのないこのテーブルでは、最も垂直スペースを必要とするセルが行全体の下限を決定します。行を短くするには、テキストを短くしたり、フォントサイズや余白を減らしたり、列幅を広げる必要があります。

下の画像は同じテーブルを同一スケールで示しています。示された結果では、実際の高さはそれぞれ 70、100、55.2 ポイントでした。最終行は 20 ポイントの最小値よりも高くなっています。テキストの測定は環境にインストールされているフォントに依存して若干変わる可能性があります。保存された結果は以下からダウンロードできます: [最小値を増やしたもの](row-height-increased.pptx) と [最小値を減らしたもの](row-height-decreased.pptx)。

| 元の状態: 最小 70 pt、実際 70 pt | 増加: 最小 100 pt、実際 100 pt | 減少: 最小 20 pt、実際 55.2 pt |
| --- | --- | --- |
| ![最初の行が 70 ポイントの元のテーブル。](row-height-before.png) | ![最初の行の最小高さを 100 ポイントに増やした後のテーブル。](row-height-increased.png) | ![最初の行の最小高さを 20 ポイントに減らした後のテーブル。折り返しテキストにより行は最小値以上の高さになっています。](row-height-decreased.png) |

## **最初の行をヘッダーとして設定**

最初の行をヘッダー書式に設定するには、[setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) メソッドを使用します。外観はテーブルに適用されたテーブルスタイルに依存します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込む。
2. 最初のスライドにアクセスする。
3. スライド上の最初のシェイプとして保存されているテーブルにアクセスする。
4. その最初の行にヘッダー書式を有効にする。
5. 変更したプレゼンテーションを保存する。

この例では、最初のスライドの最初のシェイプとしてテーブルを持つ `table.pptx` が必要です。最初の行にヘッダー書式を有効にし、`First_row_header.pptx` として保存します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルの行または列を複製**

行や列を複製して内容と書式を再利用できます。コピーをテーブルの末尾に追加したり、特定の位置に挿入したりできます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込む。
2. 最初のスライドにアクセスする。
3. 列幅と行高さを定義する。
4. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) メソッドでテーブルを追加する。
5. 必要な行を複製する。
6. 必要な列を複製する。
7. 変更したプレゼンテーションを保存する。

この例では、少なくとも 1 枚のスライドがある `Test.pptx` が必要です。3 列 5 行のテーブルをポイント単位で作成し、最初の行と列のコピーを末尾に追加し、2 番目の行と列のコピーをインデックス 3（4 番目の位置）に挿入します。結果として 7 行 5 列のテーブルになります。`false` 引数は隣接する結合行や列への複製を無効にします。このテーブルには結合セルはありません。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルから行または列を削除**

テーブル内で不要になった行や列を削除します。項目を削除すると、その後ろにある行や列のインデックスがシフトします。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスでプレゼンテーションを作成する。
2. 最初のスライドにアクセスする。
3. 列幅と行高さを定義する。
4. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) メソッドでテーブルを追加する。
5. 2 番目の行と 2 番目の列を削除する。
6. 変更したプレゼンテーションを保存する。

この例では、3×3 のテーブルを作成し、インデックス 1 の行と列を削除して 2×2 のテーブルを `TestTable_out.pptx` に残します。サイズはポイント単位です。`false` 引数は結合された隣接行や列の削除を無効にします。このテーブルには結合セルはありません。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブル行レベルでテキスト書式を設定**

行全体にテキスト書式を適用してセル間の一貫性を保ちます。各セルを個別に書式設定することなく、フォントプロパティ、段落書式、テキスト方向を設定できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込む。
2. 最初のスライドのテーブルにアクセスする。
3. 最初の行に対して [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) を使用する。
4. 最初の行に対して [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) と [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) を使用する。
5. 2 番目の行に対して [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) を使用する。
6. 変更したプレゼンテーションを保存する。

この例では、最初のスライドの最初のシェイプとしてテーブルを持ち、少なくとも 2 行ある `table.pptx` が必要です。最初の行に 25 ポイントのテキスト、右揃え、20 ポイントの右段落余白を適用し、2 行目に縦書きテキストを設定します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブル列レベルでテキスト書式を設定**

列全体にテキスト書式を適用してセル間の一貫性を保ちます。各セルを個別に書式設定することなく、フォントプロパティ、段落書式、テキスト方向を設定できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込む。
2. 最初のスライドのテーブルにアクセスする。
3. 最初の列に対して [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) を使用する。
4. 最初の列に対して [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) と [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) を使用する。
5. 2 番目の列に対して [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) を使用する。
6. 変更したプレゼンテーションを保存する。

この例では、最初のスライドの最初のシェイプとしてテーブルを持ち、少なくとも 2 列ある `table.pptx` が必要です。最初の列に 25 ポイントのテキスト、右揃え、20 ポイントの右段落余白を適用し、2 列目に縦書きテキストを設定します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルスタイルプロパティの取得**

[getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) メソッドを使用してテーブルに適用されたプリセットを取得し、別のテーブルで再利用できます。これは個々のセル書式オーバーライドではなく、プリセット自体を特定します。

この例ではテーブルを作成し、[TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) を適用してからプリセットを読み戻します。`DarkStyle1` に対応する整数値を出力し、テーブルを `table.pptx` に保存します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスターテーマを継承しますが、その上で塗りつぶし、枠線、テキストカラーを個別に上書きすることが可能です。

**Excel のようにテーブル行を並べ替えることはできますか？**

できません。Aspose.Slides のテーブルには組み込みの並び替えやフィルタ機能はありません。データをメモリ上で先に並び替えてから、希望の順序で行を再配置してください。

**特定のセルにカスタムカラーを保持しながら、バンド（ストライプ）列を設定できますか？**

できます。バンド列を有効にした上で、特定のセルにローカル書式を上書きすれば、セルレベルの書式がテーブルスタイルより優先されます。