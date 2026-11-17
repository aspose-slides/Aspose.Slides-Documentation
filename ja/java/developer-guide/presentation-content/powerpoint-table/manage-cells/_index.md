---
title: Java を使用してプレゼンテーションのテーブルセルを管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/java/manage-cells/
keywords:
- テーブルセル
- セル結合
- 罫線削除
- セル分割
- セル内画像
- 背景色
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java で PowerPoint のテーブルセルを管理: 結合セルの識別、罫線の削除、セルの分割、背景色や画像の設定を Aspose.Slides for Java で行う。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内のテーブルセルにアクセスして変更できます。本記事では、結合されたテーブルセルの識別、セルの罫線の削除、結合または分割後のセル番号の操作、セルの背景色の変更、テーブルセル内への画像追加方法について説明します。例は、プレゼンテーションの作成または開く方法、スライドからテーブルを取得する方法、セルプロパティを介してセルの書式設定を更新する方法、そして変更されたプレゼンテーションを PPTX ファイルとして保存する方法を示しています。

Aspose.Slides は、テーブルセルへ `(column, row)` の順序でゼロベースのインデックスを使用してアクセスします。

## **結合されたテーブルセルの識別**

この例は既存のプレゼンテーションを開き、1 枚目のスライドの最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。その後、すべての行と列をループし、[isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) を使用して結合領域内のセルを識別します。マッチした各セルについて、`row;column` の順序でセル座標、[getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)、[getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)、および領域の開始座標である [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) と [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) を出力します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **テーブルセルの罫線の削除**

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) を作成し、[addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) を使用して最初のスライドにテーブルを追加します。列幅、行高さ、テーブルの位置はポイントで指定します。この例では、すべてのセル罫線を [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) に設定して非表示にします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **対角罫線の追加**

[getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) を使用して左上隅から右下隅へ線を描画し、[getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) を使用して左下隅から右上隅へ線を描画します。対角線はコーナーヘッダーを示すことができ、両方の対角線を組み合わせて X 記号を作り、セルが適用外であることを示すことができます。

各対角線は [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) です。その [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) で、[setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) を使用して [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を選択し、[getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) で色を指定します。線の幅は [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) でポイント単位で設定します。

この例では 1 行に 3 つのセルを作成し、赤い下向き対角線、青い上向き対角線、そして両方の対角線を設定します。上、下、左、右の罫線は変更せずに残します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

対角線は書式プロパティであり、セルの分割ではありません。各セルは単一のテキストフレームを保持し、[getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) で取得できます。対角線の両側の領域を個別に編集することはできません。

Microsoft PowerPoint でレンダリングされた保存されたテーブル:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*左から右へ: 下向き対角線 (赤、3 pt)、上向き対角線 (青、5 pt)、および両方の対角線。*

## **テーブルセルの結合**

[mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) を使用して、矩形領域のテーブルセルを 1 つのセルに結合します。結合範囲の左上セルと右下セルを指定します。最後の引数は、結合が指定範囲外のセルを含むかどうかを制御します。`false` に設定すると結合はその範囲内にとどまります。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、`(1, 1)` から `(2, 2)` の 4 つの中央セルを結合します。結果のセルは 2 列と 2 行にまたがりますが、テーブルの基礎グリッドは 4 列 4 行のままです。結合セルの内容や書式にアクセスするには、左上位置 `table.get_Item(1, 1)` を使用します。結合範囲外のセル位置は変更されません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルセルの分割**

前の例でセルを結合した場合でも、テーブルのグリッドは保持されます。セルを分割すると新しいグリッド列が追加され、右側のセルの列インデックスが変わることがあります。Aspose.Slides は PowerPoint のテーブルグリッドモデルに従います。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、セル `(1, 1)` に対して [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) を呼び出します。セルの 70 ポイント幅の半分を渡して、幅が同じ 2 つのセルを作成します。

分割後、2 つの半分は `table.get_Item(1, 1)` と `table.get_Item(2, 1)` でアクセスできます。テーブルグリッドは 5 列になり、元々列 2 と列 3 にあったセルはそれぞれ列 3 と列 4 に移動します。行インデックスは変わりません。分割後にセルにアクセスするときは、更新された列インデックスを使用してください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*幅の分割はセル (1, 1) に影響し、ゼロベースの (column, row) インデックスを使用します。他の行は両方の新しい列位置にまたがるセルを保持します。*
<!-- visual-explanation:manage-cells:end -->

### **行または列のスパンで結合セルを分割**

マージされたテンプレートセルをデータ入力用に準備するには、[splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) を使用して既存の行境界に沿って分割するか、[splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) を使用して列境界に沿って分割します。

`index` 引数は、分割の上部部分の行数または左側部分の列数を表し、結合領域を基準に相対的です。

- 行分割: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)。
- 列分割: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)。

この例では、プレゼンテーションの最初のスライドの最初のシェイプがテーブルであり、`(1, 2)` と `(1, 3)` が縦に結合されていることを前提とします。下側の位置から開始し、[getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) と [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) で起点を特定し、両方のスパンを確認します。`splitByRowSpan(1)` は製品名用に行 2 と行 3 を分割します。横方向の 2 列結合の場合は、代わりに `splitByColSpan(1)` を使用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // 分割後にテーブルから得られるセルを取得します。
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

テーブルグリッドと周囲のセルインデックスは変更されません。結果のセルは座標で取得できます。ここでは両方のセルのスパンは 1 で、[isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) は `false` を返します。1 回の分割後も部分的に結合されたままの大きな領域が残ることがあります。

元のテキストと書式は上部（または左部）のセルに残り、新しいセルは空ですが、塗りつぶし、罫線、余白などのセル書式を継承します。分割後にセルにデータを入力し、必要なテキスト書式を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式が保持されたまま、別々の「Product A」および「Product B」セルが含まれます。詳細は [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) を参照してください。

### **特定の高さでセルを分割**

[splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) は上部部分の高さ（ポイント）を受け取り、[splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) は上部部分の既存グリッド行数を受け取ります。右列の 40 ポイントセルを中央に配置するには、セルの実際の高さから 40 を引き、残りのスペースを上下に均等に分配します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };
    
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

最初の分割でグリッド行が追加され、セル `(1, 1)` の下部に 90 ポイントが残ります。2 回目の分割でそのセルが 40 ポイントの中間セルと 50 ポイントの下部セルに分かれます。右列は上から順に高さ 50、40、50 ポイントの 3 つのセルになります。左側のセルは 3 行すべてにまたがり、元の高さ 140 ポイントを保持します。

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **テーブルセルの背景色の変更**

この例では、列幅 150 ポイント、行高さ 50 ポイントのテーブルを作成します。[setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) を使用して実体塗りつぶしを選択し、[getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) が返す色を赤に設定して、セル `(2, 3)`（3 列目・4 行目）の背景色を変更します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルセル内に画像を追加**

サンプルを実行する前に、入力画像を作業ディレクトリに配置してください。画像は [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) で読み込み、[addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) を使用してプレゼンテーションの画像コレクションに追加します。その後、画像をテーブルの最初のセル `(0, 0)` のピクチャーフィルとして割り当てます。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) は画像をセル全体に伸ばすため、アスペクト比が変わることがあります。列幅と行高さはポイントで指定します。読み込んだ画像は、プレゼンテーションに追加された後、`finally` ブロックで破棄されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**単一セルの各辺に対して異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)、[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)、[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)、[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) の罫線は別々のプロパティとして管理されているため、各辺の太さやスタイルを個別に設定できます。

**セルの背景に画像を設定した後で列・行のサイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/)（stretch / tile）に依存します。ストレッチの場合、画像は新しいセルサイズに合わせて調整されます。タイルの場合はタイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを割り当てられますか？**

[Hyperlinks](/slides/ja/java/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（ポーション）レベル、またはテーブル/シェイプ全体のレベルで設定します。実務では、テキストの一部またはセル内のすべてのテキストにリンクを割り当てます。

**単一セル内でフォントを異なるものに設定できますか？**

はい。セルのテキストフレームは [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)（ラン）をサポートしており、フォントファミリ、スタイル、サイズ、色などを個別に設定できます。