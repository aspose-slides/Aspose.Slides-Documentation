---
title: Java を使用してプレゼンテーションのテーブルセルを管理する
linktitle: セルの管理
type: docs
weight: 30
url: /ja/java/manage-cells/
keywords:
- テーブルセル
- セルの結合
- 境界線の削除
- セルの分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint のテーブルセルを簡単に管理します。セルへのアクセス、変更、スタイリングを迅速に習得し、スライドの自動化をシームレスに実現します。"
---

## **マージされたテーブルセルの特定**
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドからテーブルを取得します。
3. テーブルの行と列を反復処理して、マージされたセルを見つけます。
4. マージされたセルが見つかったときにメッセージを出力します。

この Java コードは、プレゼンテーションでマージされたテーブルセルを特定する方法を示します。
```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // Slide#0.Shape#0 がテーブルであると想定
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **テーブルセルの境界線の削除**
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドのインデックスで参照を取得します。
3. 幅を指定した列の配列を定義します。
4. 高さを指定した行の配列を定義します。
5. [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) メソッドを使用してスライドにテーブルを追加します。
6. すべてのセルを反復処理して、上、下、右、左の境界線をクリアします。
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、テーブルセルから境界線を削除する方法を示します。
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義します
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブル シェイプを追加します
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの罫線書式を設定します
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

    // PPTX をディスクに書き込みます
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **マージされたセルの番号付け**
セル (1, 1) x (2, 1) と (1, 2) x (2, 2) の 2 ペアをマージすると、結果のテーブルに番号が付けられます。この Java コードはその手順を示しています。
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義します
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル シェイプを追加します
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの罫線書式を設定します
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

    // セル (1, 1) と (2, 1) を結合します
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // セル (1, 2) と (2, 2) を結合します
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


次に、セル (1, 1) と (1, 2) をさらにマージします。その結果、中心に大きなマージされたセルを含むテーブルが得られます。 
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義します
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル シェイプを追加します
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの罫線書式を設定します
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

    // セル (1, 1) と (2, 1) を結合します
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // セル (1, 2) と (2, 2) を結合します
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // セル (1, 1) と (1, 2) を結合します
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
    // PPTX ファイルをディスクに書き込みます
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```



## **分割されたセルの番号付け**
前の例では、テーブルセルがマージされたとき、他のセルの番号付けや番号体系は変わりませんでした。  

今回は、マージされたセルのない通常のテーブルを使用し、セル (1,1) を分割して特殊なテーブルを作成します。このテーブルの番号付けは奇妙に見えるかもしれませんが、Microsoft PowerPoint がテーブルセルに番号を付ける方法であり、Aspose.Slides も同様です。  

この Java コードは、上記の手順を示しています。
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義します
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル シェイプを追加します
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 各セルの罫線書式を設定します
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

    // セル (1, 1) と (2, 1) を結合します
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // セル (1, 2) と (2, 2) を結合します
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // セル (1, 1) を分割します
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    //PPTX ファイルをディスクに書き込みます
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テーブルセルの背景色の変更**
この Java コードは、テーブルセルの背景色を変更する方法を示します。
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // 新しいテーブルを作成します
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // セルの背景色を設定します
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **テーブルセル内への画像の追加**
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドのインデックスで参照を取得します。
3. 幅を指定した列の配列を定義します。
4. 高さを指定した行の配列を定義します。
5. [AddTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) メソッドを使用してスライドにテーブルを追加します。
6. 画像ファイルを保持する `Images` オブジェクトを作成します。
7. `IImage` 画像を `IPPImage` オブジェクトに追加します。
8. テーブルセルの `FillFormat` を `Picture` に設定します。
9. 画像をテーブルの最初のセルに追加します。
10. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは、テーブル作成時にテーブルセル内に画像を配置する方法を示します。
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスします
    ISlide islide = pres.getSlides().get_Item(0);

    // 幅を持つ列と高さを持つ行を定義します
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // スライドにテーブル シェイプを追加します
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // 画像ファイルを使用して IPPImage オブジェクトを作成します
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 画像を最初のテーブルセルに追加します
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX ファイルをディスクに保存します
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**単一セルの各側面に対して、異なる線の太さやスタイルを設定できますか？**

はい。[上](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[下](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[左](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[右](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) の境界線は個別のプロパティを持つため、各側面の太さやスタイルを異なる設定にできます。これは、記事で示されたセルの側面ごとの境界線制御から論理的に導かれます。

**セルの背景に画像を設定した後、列/行のサイズを変更すると画像はどうなりますか？**

挙動は [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/)（stretch/tilе）に依存します。ストレッチの場合、画像は新しいセルに合わせて調整され、タイルの場合はタイルが再計算されます。記事ではセル内の画像表示モードについて言及しています。

**セル内のすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/java/manage-hyperlinks/) は、セルのテキストフレーム内のテキスト（portion）レベル、またはテーブル全体/シェイプレベルで設定されます。実際には、リンクはセル内の特定の portion またはすべてのテキストに割り当てます。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキストフレームは、[portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)（ラン）ごとにフォントファミリー、スタイル、サイズ、色などの独立した書式設定をサポートしています。