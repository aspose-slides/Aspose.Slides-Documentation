---
title: JavaScript を使用してプレゼンテーションのテーブルセルを管理
linktitle: セルを管理
type: docs
weight: 30
url: /ja/nodejs-java/manage-cells/
keywords:
- テーブルセル
- セルの結合
- 枠線の削除
- セルの分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript で PowerPoint のテーブルセルを管理: 結合セルの識別、枠線の削除、セルの分割、背景色と画像の設定を Aspose.Slides for Node.js を使用して実行します。"
---
## **概要**

Aspose.Slides は PowerPoint プレゼンテーションのテーブルセルにアクセスし、変更することができます。この記事では、結合されたテーブルセルの識別、セルの枠線の削除、結合または分割後のセル番号の操作、セルの背景色の変更、およびテーブルセル内への画像の追加方法を説明します。例では、プレゼンテーションの作成またはオープン、スライドからテーブルを取得、セルプロパティを介したセルの書式設定の更新、そして変更されたプレゼンテーションを PPTX ファイルとして保存する方法を示します。

Aspose.Slides は、テーブルセルにアクセスする際にゼロベースのインデックスを使用し、`(column, row)` の順序で指定します。

## **結合されたテーブルセルの識別**

この例は既存のプレゼンテーションを開き、最初のスライドの最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。次にすべての行と列を走査し、[isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) を使用して結合領域内のセルを識別します。マッチが見つかるたびに、`row;column` 順のセル座標、[getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)、[getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)、および領域の開始座標である [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) と [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) を出力します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **テーブルセルの枠線の削除**

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) を作成し、[addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) で最初のスライドにテーブルを追加します。列幅、行高さ、テーブル位置はポイントで指定します。この例では、すべてのセル枠線を [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) に設定し、枠線を非表示にします。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **対角線のセル枠線の追加**

[getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/) を使用して左上から右下へ線を描画し、[getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/) を使用して左下から右上へ線を描画します。対角線は角ヘッダーを示すことができ、両方の対角線を組み合わせて X マークとして「該当なし」セルを示すことができます。

各対角線は [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) です。その [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) で [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) を使用し、[FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を選択して [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) で色を指定します。線幅は [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) でポイント単位で設定します。

この例では、1 行に 3 つのセルを作成します。赤い下向き対角線、青い上向き対角線、そして両方の対角線です。上、下、左、右の枠線は変更せずに残します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

対角線は書式設定プロパティであり、セルの分割ではありません。各セルは [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/) でアクセスできる単一のテキストフレームを保持しており、対角線の両側の領域を独立して編集することはできません。

![左上から右下への赤い対角線、左下から右上への青い対角線、そして X を形成する両方の対角線を示す 3 つのテーブルセル。](diagonal-cell-borders.png)

*左から右へ: 下向き対角線（赤、3 pt）、上向き対角線（青、5 pt）、そして両方の対角線。*

## **テーブルセルの結合**

[mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) を使用して、矩形領域のテーブルセルを 1 つのセルに結合します。範囲の左上と右下のセルを指定します。最後の引数は、結合が指定範囲外のセルを含むかどうかを制御します。`false` にすると結合はその範囲内にとどまります。

この例では、列幅・行高さ 70 ポイントの 4×4 テーブルを作成し、中央の 4 つのセル `(1, 1)` から `(2, 2)` を結合します。結果のセルは 2 列×2 行に跨りますが、テーブルの基礎グリッドは依然として 4 列×4 行です。結合セルの内容や書式へアクセスするには、左上位置 `table.get_Item(1, 1)` を使用します。結合範囲外のセルインデックスは変わりません。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルセルの分割**

前の例でセルを結合してもテーブルのグリッドは保持されます。セルを分割すると新しいグリッド列が追加され、右側のセルの列インデックスが変わります。Aspose.Slides は PowerPoint のテーブルグリッドモデルに従います。

この例では、列幅・行高さ 70 ポイントの 4×4 テーブルを作成し、セル `(1, 1)` に対して [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) を呼び出します。セル幅の半分 (35 ポイント) を渡して、等幅の 2 つのセルを作ります。

分割後、2 つの新しいセルは `table.get_Item(1, 1)` と `table.get_Item(2, 1)` でアクセスできます。テーブルグリッドは 5 列になり、元々列 2 と 3 にあったセルはそれぞれ列 3 と 4 にシフトします。行インデックスは変わりません。分割後にセルへアクセスする際は、更新された列インデックスを使用してください。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![結合されていない 70 ポイントのセルが 35 ポイントのセル 2 つに分割され、5 番目のグリッド列が追加され、右側のインデックスがシフトします。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*幅の分割はセル (1, 1) に影響し、ゼロベースの (column, row) インデックスで表されます。他の行は両方の新しい列位置にまたがるセルを保持します。*
<!-- visual-explanation:manage-cells:end -->

### **行または列のスパンで結合セルを分割**

マージされたテンプレートセルをデータ入力用に分割するには、[splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) で既存の行境界に沿って分割するか、[splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) で列境界に沿って分割します。

`index` 引数は分割の上部部分の行数または左部部分の列数をカウントし、結合領域に対して相対的です。

- 行分割: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)。
- 列分割: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)。

この例では、プレゼンテーションの最初のスライドの最初のシェイプがテーブルであることを前提とし、`(1, 2)` と `(1, 3)` が縦に結合されていると想定します。下側の位置から開始し、[getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) と [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) で起点を特定し、両方のスパンを確認します。`splitByRowSpan(1)` は製品名用に行 2 と 3 を分離します。横方向の 2 列結合の場合は `splitByColSpan(1)` を使用してください。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // 分割後にテーブルから得られるセルを取得します。
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

テーブルグリッドと周囲のセルインデックスは変更されません。結果のセルは座標で取得できます。この例では、両方のセルのスパンは 1 で、[isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) は `false` を返します。1 回の分割後も、より大きな領域が部分的に結合されたまま残ることがあります。

元のテキストと書式は上部（または左部）セルに残り、新しいセルは空ですが、塗りつぶし、枠線、余白などのセル書式を継承します。分割後にセルにデータを入力し、必要に応じてテキスト書式を明示的に設定してください。

保存されたプレゼンテーションは、テンプレートのセル書式が保持されたまま「Product A」および「Product B」セルが別々に存在します。詳細は [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) を参照してください。

### **特定の高さでセルを分割**

[splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/) は上部部分の高さ（ポイント）を受け取り、[splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) は上部部分の既存グリッド行数を受け取ります。右側の列に 40 ポイントのセルを中央に配置するには、セルの実際の高さから 40 を引き、残りのスペースを上下に均等に分割します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

最初の分割でグリッド行が追加され、セル `(1, 1)` の下部に 90 ポイントが残ります。2 回目の分割でそのセルは 40 ポイントの中央セルと 50 ポイントの下部セルに分かれます。右側の列は上から下へそれぞれ 50、40、50 ポイントの 3 つのセルになります。左側のセルは 3 行すべてを跨ぎ、元の高さ 140 ポイントを保持します。

![左側のセルがテーブル全体の高さを跨り、中央に「Middle」ラベルがある 3 つのセルと並んでいます。](split-by-height.png)

## **テーブルセルの背景色の変更**

この例では、列幅 150 ポイント、行高さ 50 ポイントのテーブルを作成します。セル `(2, 3)`（3 列目・4 行目）に対して、[setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) で実体塗りつぶしを選択し、[getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) が返す色を赤に設定します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルセル内に画像を追加**

例を実行する前に、入力画像を作業ディレクトリに配置してください。画像は [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) で読み込み、[addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) でプレゼンテーションの画像コレクションに追加します。その後、画像をセル `(0, 0)`（テーブルの最初のセル）のピクチャーフィルとして割り当てます。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) は画像をセル全体に伸張します（アスペクト比が変わる可能性があります）。列幅と行高さはポイント単位です。ロードした画像は、プレゼンテーションに追加された後、`finally` ブロックで破棄されます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**単一のセルの各辺に対して異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)、[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)、[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)、[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) の枠線は個別のプロパティを持つため、各辺の太さやスタイルを別々に設定できます。

**セルの背景に画像を設定した後で列や行のサイズを変更すると、画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/)（stretch/​tile）に依存します。stretch の場合、画像は新しいセルサイズに合わせて伸縮します。tile の場合はタイルが再計算されます。

**セル全体のコンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/nodejs-java/manage-hyperlinks/) はセル内のテキスト（ポーション）レベル、またはテーブル/シェイプ全体のレベルで設定できます。実際には、ポーションにリンクを設定するか、セル内のすべてのテキストに対してリンクを設定します。

**単一のセル内でフォントを複数設定できますか？**

はい。セルのテキストフレームは [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)（ラン）をサポートしており、フォントファミリ、スタイル、サイズ、色などを個別に設定できます。