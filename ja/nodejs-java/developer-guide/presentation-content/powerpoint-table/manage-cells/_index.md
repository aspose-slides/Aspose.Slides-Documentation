---
title: セルの管理
type: docs
weight: 30
url: /ja/nodejs-java/manage-cells/
keywords: "テーブル、結合セル、分割セル、テーブルセル内の画像、Java、Node.js via Java 用 Aspose.Slides"
description: "JavaScript における PowerPoint プレゼンテーションのテーブルセル"
---

## **結合されたテーブルセルの識別**
1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 
2. 最初のスライドからテーブルを取得します。
3. テーブルの行と列を反復処理して、結合されたセルを見つけます。
4. 結合されたセルが見つかったときにメッセージを表示します。

この JavaScript コードは、プレゼンテーション内の結合されたテーブルセルを識別する方法を示します。
```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0); // Slide#0.Shape#0 がテーブルであると想定
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テーブルセルの枠線を削除する**
1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 
2. インデックスを使用してスライドの参照を取得します。
3. 幅を指定した列の配列を定義します。
4. 高さを指定した行の配列を定義します。
5. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) メソッドを使用してスライドにテーブルを追加します。
6. すべてのセルを反復処理して、上・下・右・左の枠線をクリアします。
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この JavaScript コードは、テーブルセルの枠線を削除する方法を示します。
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var sld = pres.getSlides().get_Item(0);
    // 列の幅と行の高さを定義
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // スライドにテーブルシェイプを追加
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 各セルの枠線フォーマットを設定
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // PPTX をディスクに保存
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **結合セルの番号付け**
セル (1, 1) x (2, 1) および (1, 2) x (2, 2) の 2 つのペアを結合すると、結果のテーブルに番号が付けられます。この JavaScript コードはそのプロセスを示します。
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var sld = pres.getSlides().get_Item(0);
    // 列の幅と行の高さを定義
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // スライドにテーブルシェイプを追加
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 各セルの枠線フォーマットを設定
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
    // (1, 1) と (2, 1) のセルを結合
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // (1, 2) と (2, 2) のセルを結合
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```



次に、セル (1, 1) と (1, 2) を結合してさらにセルを結合します。その結果、中央に大きな結合セルを持つテーブルが得られます。 
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var sld = pres.getSlides().get_Item(0);
    // 列の幅と行の高さを定義
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // スライドにテーブルシェイプを追加
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 各セルの枠線フォーマットを設定
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
    // (1, 1) と (2, 1) のセルを結合
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // (1, 2) と (2, 2) のセルを結合
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // (1, 1) と (1, 2) のセルを結合
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // PPTX ファイルをディスクに書き込み
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **分割セルの番号付け**
前の例では、テーブルセルが結合されたとき、他のセルの番号付けや番号体系は変わりませんでした。

今回は、結合されていない通常のテーブルを使用し、セル (1,1) を分割して特別なテーブルを作成します。このテーブルの番号付けは奇妙に見えるかもしれませんが、Microsoft PowerPoint がテーブルセルに番号を付ける方式であり、Aspose.Slides も同様です。

この JavaScript コードは、前述のプロセスを示します。
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var sld = pres.getSlides().get_Item(0);
    // 列の幅と行の高さを定義
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // スライドにテーブルシェイプを追加
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 各セルの枠線フォーマットを設定
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
    // (1, 1) と (2, 1) のセルを結合
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // (1, 2) と (2, 2) のセルを結合
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // (1, 1) のセルを分割
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // PPTX ファイルをディスクに書き込み
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テーブルセルの背景色を変更する**
この JavaScript コードは、テーブルセルの背景色を変更する方法を示します。
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // 新しいテーブルを作成
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // セルの背景色を設定
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **テーブルセル内に画像を追加する**
1. Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 
2. インデックスを使用してスライドの参照を取得します。
3. 幅を指定した列の配列を定義します。
4. 高さを指定した行の配列を定義します。
5. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) メソッドを使用してスライドにテーブルを追加します。
6. 画像ファイルを保持する `Images` オブジェクトを作成します。
7. `IImage` 画像を `PPImage` オブジェクトに追加します。
8. テーブルセルの `FillFormat` を `Picture` に設定します。
9. 画像をテーブルの最初のセルに追加します。
10. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この JavaScript コードは、テーブル作成時にテーブルセル内に画像を配置する方法を示します。
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var islide = pres.getSlides().get_Item(0);
    // 列の幅と行の高さを定義
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // スライドにテーブルシェイプを追加
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // 画像ファイルを使用して PPImage オブジェクトを作成
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 画像を最初のテーブルセルに追加
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // PPTX ファイルをディスクに保存
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**単一セルの各側に異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) の枠線は個別のプロパティを持っているため、各側の太さやスタイルを異ならせることができます。これは、記事で示されたセルごとの枠線制御に論理的に対応しています。

**セルの背景に画像を設定した後で列/行のサイズを変更すると、画像はどうなりますか？**

動作は[fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) に依存します。伸縮の場合、画像は新しいセルに合わせて調整され、タイルの場合はタイルが再計算されます。記事ではセル内の画像表示モードについて言及しています。

**セルのすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/nodejs-java/manage-hyperlinks/) は、セルのテキスト フレーム内のテキスト (portion) レベル、またはテーブル全体/シェイプレベルで設定されます。実際には、リンクをテキストの一部またはセル内のすべてのテキストに割り当てます。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキスト フレームは、[portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)（ラン）ごとに独立した書式設定（フォント ファミリ、スタイル、サイズ、カラー）をサポートします。