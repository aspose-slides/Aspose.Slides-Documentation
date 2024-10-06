---
title: セルの管理
type: docs
weight: 30
url: /ja/java/manage-cells/
keywords: "テーブル, マージされたセル, 分割されたセル, テーブルセル内の画像, Java, Aspose.Slides for Java"
description: "Java の PowerPoint プレゼンテーションにおけるテーブルセル"
---


## **マージされたテーブルセルを特定する**
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドからテーブルを取得します。
3. テーブルの行と列を繰り返してマージされたセルを見つけます。
4. マージされたセルが見つかったときにメッセージを表示します。

この Java コードは、プレゼンテーション内のマージされたテーブルセルを特定する方法を示しています：

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // スライド#0のシェイプ#0がテーブルであると仮定
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("セル %d;%d は、RowSpan=%d と ColSpan=%d を持つマージされたセルの一部です。最初のセルは %d;%d から始まります。",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルセルの境界線を削除する**
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. 幅を持つ列の配列を定義します。
4. 高さを持つ行の配列を定義します。
5. [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) メソッドを通じてスライドにテーブルを追加します。
6. すべてのセルを繰り返して、上、下、右、左の境界線をクリアします。
7. 修正されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、テーブルセルから境界線を削除する方法を示しています：

```java
// PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブルシェイプを追加
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの境界の書式を設定
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // PPTX をディスクに書き込み
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **マージされたセルの番号付け**
2 つのペアのセル (1, 1) x (2, 1) と (1, 2) x (2, 2) をマージすると、結果として得られるテーブルに番号が付きます。この Java コードはそのプロセスを示しています：

```java
// PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブルシェイプを追加
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの境界の書式を設定
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

    // セル (1, 1) x (2, 1) をマージ
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // セル (1, 2) x (2, 2) をマージ
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

その後、セル (1, 1) と (1, 2) をさらにマージして、結果として中央に大きなマージされたセルを含むテーブルが得られます：

```java
// PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブルシェイプを追加
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの境界の書式を設定
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

    // セル (1, 1) x (2, 1) をマージ
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // セル (1, 2) x (2, 2) をマージ
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // セル (1, 1) x (1, 2) をマージ
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// PPTX ファイルをディスクに書き込み
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **分割されたセルの番号付け**
前の例では、テーブルセルをマージしたときに、他のセルの番号システムは変わりませんでした。

今回は、通常のテーブル（マージされたセルのないテーブル）を取り、その後セル (1, 1) を分割して特別なテーブルを作成します。このテーブルの番号付けに注意が必要で、少々奇妙に感じるかもしれません。しかし、これが Microsoft PowerPoint のテーブルセルの番号付け方法であり、Aspose.Slides も同様のことを行います。

この Java コードは、私たちが説明したプロセスを示しています：

```java
// PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブルシェイプを追加
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの境界の書式を設定
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

    // セル (1, 1) x (2, 1) をマージ
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // セル (1, 2) x (2, 2) をマージ
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // セル (1, 1) を分割
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // PPTX ファイルをディスクに書き込み
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルセルの背景色を変更する**

この Java コードは、テーブルセルの背景色を変更する方法を示しています：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // 新しいテーブルを作成
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // セルの背景色を設定
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **テーブルセル内に画像を追加する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. 幅を持つ列の配列を定義します。
4. 高さを持つ行の配列を定義します。
5. [AddTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) メソッドを通じてスライドにテーブルを追加します。
6. 画像ファイルを保持する `Images` オブジェクトを作成します。
7. `IPPImage` オブジェクトに `IImage` 画像を追加します。
8. テーブルセルの `FillFormat` を `Picture` に設定します。
9. 画像をテーブルの最初のセルに追加します。
10. 修正されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、テーブルを作成するときにセル内に画像を配置する方法を示しています：

```java
// PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide islide = pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // スライドにテーブルシェイプを追加
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // 画像ファイルを使用して IPPImage オブジェクトを作成
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 最初のテーブルセルに画像を追加
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX ファイルをディスクに書き込み
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```