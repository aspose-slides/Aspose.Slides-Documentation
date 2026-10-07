---
title: JavaScript を使用してプレゼンテーション内のテーブルセルを管理する
linktitle: セルの管理
type: docs
weight: 30
url: /ja/nodejs-java/manage-cells/
keywords:
- テーブルセル
- セルの結合
- 枠線の削除
- セルの分割
- セル内画像
- 背景色
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript で PowerPoint のテーブルセルを管理します：結合セルの識別、枠線の削除、セルの分割、背景色と画像の設定を Aspose.Slides for Node.js を使用して行います。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内のテーブルセルにアクセスして変更できます。この記事では、結合されたテーブルセルの識別、セル枠線の削除、セルの結合または分割後の番号付けの操作、セルの背景色の変更、テーブルセル内への画像挿入方法について説明します。サンプルでは、プレゼンテーションの作成または読み込み、スライドからテーブルの取得、セルプロパティを介したセル書式設定の更新、変更後のプレゼンテーションを PPTX ファイルとして保存する手順を示します。

Aspose.Slides は、テーブルセルにアクセスする際に **0 ベース** のインデックスを使用し、順序は `(column, row)` です。

## **結合されたテーブルセルを識別する**

このサンプルは既存のプレゼンテーションを開き、最初のスライドの最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。次にすべての行と列を走査し、[isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) を使用して結合領域内のセルを識別します。一致したセルについては、`row;column` の順で座標を出力し、[getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)、[getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)、領域の開始座標である [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) と [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) を取得します。

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

## **テーブルセルの枠線を削除する**

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) を作成し、[addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) で最初のスライドにテーブルを追加します。列幅、行高さ、テーブル位置はポイント単位で指定します。この例では、すべてのセル枠線を [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) に設定して目に見えなくしています。

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

## **テーブルセルを結合する**

[mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) を使用して、矩形領域のテーブルセルを 1 つのセルに結合します。結合範囲の左上セルと右下セルを指定します。最後の引数は、結合が指定範囲外のセルを含むかどうかを制御します。`false` を指定すると、結合は範囲内に限定されます。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、`(1, 1)` から `(2, 2)` の 4 つの中央セルを結合します。結果として得られるセルは 2 列 × 2 行にまたがりますが、テーブルの基礎グリッドは依然として 4 列 × 4 行のままです。結合セルの内容や書式にアクセスするには、左上位置 `table.get_Item(1, 1)` を使用します。結合範囲内の他の位置はテーブルグリッドの一部として残り、範囲外のセルインデックスは変わりません。

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

## **テーブルセルを分割する**

前述の結合例ではテーブルのグリッドは維持されます。セルを分割すると新しい列が追加され、右側のセルの列インデックスが変わります。Aspose.Slides は PowerPoint のテーブルグリッドモデルに従います。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、セル `(1, 1)` に対して [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) を呼び出します。セル幅の半分 (35 ポイント) を渡すことで、幅が等しい 2 つのセルに分割します。

分割後、2 つの半分はそれぞれ `table.get_Item(1, 1)` と `table.get_Item(2, 1)` でアクセスできます。テーブルグリッドは 5 列になり、元々列 2 と列 3 にあったセルはそれぞれ列 3 と列 4 に移動します。行インデックスは変わりません。分割後にセルへアクセスする際は、更新された列インデックスを使用してください。

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

### **結合セルを行または列のスパンで分割する**

データ投入用に結合されたテンプレートセルを準備するには、既存の行境界で分割する [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) または列境界で分割する [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) を使用します。

`index` 引数は分割する上部部分の行数または左部部分の列数をカウントし、結合領域に対して相対的です。

- 行分割: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)。
- 列分割: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)。

この例は、最初のスライドの最初のシェイプがテーブルであることを前提とし、`(1, 2)` と `(1, 3)` が縦方向に結合されていると想定します。下側の位置から [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) と [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) で起点を取得し、両方のスパンを確認します。`splitByRowSpan(1)` は製品名用に行 2 と行 3 を分離します。横方向の 2 列結合の場合は `splitByColSpan(1)` を使用してください。

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

        // 分割後にテーブルから結果のセルを取得します。
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

テーブルグリッドと周囲のセルインデックスは変更されません。結果のセルは座標で取得できます。この例では両方のセルがスパン 1 で、[isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) は `false` を返します。大きな領域は 1 回の分割だけでも一部が結合されたまま残ります。

元のテキストと書式は上部（または左側）のセルに残り、新しいセルは空ですが、塗りつぶし、枠線、余白などのセル書式は継承されます。分割後にセルにテキストを入力し、必要に応じてテキスト書式を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式が保持された「Product A」および「Product B」セルが個別に存在します。詳細は [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) を参照してください。

## **テーブルセルの背景色を変更する**

この例では、列幅 150 ポイント、行高さ 50 ポイントのテーブルを作成します。[setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) で実色塗りを選択し、[getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) が返すカラーを赤に設定して、セル `(2, 3)`（3 列目・4 行目）の背景色を変更します。

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

## **テーブルセル内に画像を追加する**

サンプルを実行する前に、入力画像を作業ディレクトリに配置してください。画像は [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) で読み込み、[addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) でプレゼンテーションの画像コレクションに追加します。その後、画像をテーブルの最初のセル `(0, 0)` のピクチャーフィルに割り当てます。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) は画像をセル全体に伸ばすため、アスペクト比が変わる可能性があります。列幅・行高さはポイント単位です。読み込んだ画像は、プレゼンテーションへ追加した後、`finally` ブロックで破棄します。

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

**単一セルの各辺に対して異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) の枠線は個別のプロパティを持つため、各辺の太さやスタイルを別々に設定できます。

**セルの背景に画像を設定した後で列/行サイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/)（stretch/​tile）に依存します。stretch の場合は画像が新しいセルサイズに合わせて調整され、tile の場合はタイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを割り当てられますか？**

[Hyperlinks](/slides/ja/nodejs-java/manage-hyperlinks/) はセル内のテキスト（ポーション）レベル、またはテーブル/シェイプ全体のレベルで設定できます。実務では、ポーション単位またはセル内のすべてのテキストにリンクを付与します。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキストフレームは [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)（ラン）をサポートしており、フォントファミリ、スタイル、サイズ、カラーを個別に指定できます。