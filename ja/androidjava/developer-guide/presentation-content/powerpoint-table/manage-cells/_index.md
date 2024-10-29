---
title: セルの管理
type: docs
weight: 30
url: /ja/androidjava/manage-cells/
keywords: "テーブル, 統合セル, 分割セル, テーブルセル内の画像, Java, Aspose.Slides for Android via Java"
description: "JavaでのPowerPointプレゼンテーションのテーブルセル"
---

## **統合されたテーブルセルを識別する**
1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドからテーブルを取得します。
3. テーブルの行と列を反復処理して、結合セルを見つけます。
4. 統合セルが見つかった場合にメッセージを印刷します。

このJavaコードは、プレゼンテーション内の統合されたテーブルセルを識別する方法を示しています：

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // assume that Slide#0.Shape#0 is a table
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d は RowSpan=%d と ColSpan=%d で、Cell %d;%d から始まる統合セルの一部です。",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルセルの境界線を削除する**
1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. 幅のある列の配列を定義します。
4. 高さのある行の配列を定義します。
5. [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) メソッドを通じてスライドにテーブルを追加します。
6. 各セルを反復処理して、上、下、右、左の境界線をクリアします。
7. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このJavaコードは、テーブルセルから境界線を削除する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブル形状を追加
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの境界線形式を設定
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

    // PPTXをディスクに書き込む
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **統合セルの番号付け**
セル (1, 1) x (2, 1) と (1, 2) x (2, 2) の2組のセルを結合すると、結果のテーブルには番号が付けられます。このJavaコードはプロセスを示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル形状を追加
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの境界線形式を設定
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

    // セル (1, 1) x (2, 1) を統合
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // セル (1, 2) x (2, 2) を統合
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

その後、(1, 1) と (1, 2) を統合して、センターに大きな統合セルを持つテーブルを作成します：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル形状を追加
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの境界線形式を設定
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

    // セル (1, 1) x (2, 1) を統合
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // セル (1, 2) x (2, 2) を統合
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // セル (1, 1) x (1, 2) を統合
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// PPTXファイルをディスクに書き込む
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **分割セルの番号付け**
前の例では、テーブルセルが統合されると、他のセルの番号付けや番号システムは変更されませんでした。

今回は通常のテーブル（結合セルのないテーブル）を取り、セル (1,1) を分割して特別なテーブルを取得します。このテーブルの番号付けは奇妙だと見なされるかもしれませんが、Microsoft PowerPointがテーブルセルに番号を付ける方法であり、Aspose.Slidesも同様です。

このJavaコードは、前述のプロセスを示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル形状を追加
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの境界線形式を設定
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

    // セル (1, 1) x (2, 1) を統合
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // セル (1, 2) x (2, 2) を統合
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // セル (1, 1) を分割
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // PPTXファイルをディスクに書き込む
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルセルの背景色を変更する**

このJavaコードは、テーブルセルの背景色を変更する方法を示しています：

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

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. 幅のある列の配列を定義します。
4. 高さのある行の配列を定義します。
5. [AddTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) メソッドを通じてスライドにテーブルを追加します。
6. 画像ファイルを保持する `Images` オブジェクトを作成します。
7. `IPPImage` オブジェクトに `IImage` 画像を追加します。
8. テーブルセルの `FillFormat` を `Picture` に設定します。
9. 画像をテーブルの最初のセルに追加します。
10. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このJavaコードは、テーブルを作成する際にテーブルセル内に画像を配置する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide islide = pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // スライドにテーブル形状を追加
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // 画像ファイルを使用してIPPImageオブジェクトを作成
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

    // PPTXファイルをディスクに保存
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```