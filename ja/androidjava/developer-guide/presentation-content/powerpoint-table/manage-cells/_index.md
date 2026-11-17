---
title: Android のプレゼンテーションでテーブルセルを管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/androidjava/manage-cells/
keywords:
- テーブルセル
- セル結合
- 枠線削除
- セル分割
- セル内画像
- 背景色
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 上で PowerPoint のテーブルセルを管理します：結合セルの特定、枠線の削除、セルの分割、背景色と画像の設定を Aspose.Slides for Android を Java で使用して行う。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内のテーブルセルにアクセスして変更できます。この記事では、結合されたテーブルセルの特定方法、セルの枠線の削除、セルの結合または分割後の番号付けの操作、セルの背景色の変更、テーブルセル内への画像の追加方法について説明します。例では、プレゼンテーションを作成または開き、スライドからテーブルを取得し、セルプロパティを介してセルの書式設定を更新し、修正されたプレゼンテーションを PPTX ファイルとして保存する方法を示しています。

Aspose.Slides は、テーブルセルへアクセスする際に 0 から始まるインデックスを使用し、順序は `(column, row)` です。

## **結合されたテーブルセルの識別**

この例は既存のプレゼンテーションを開き、最初のスライドの最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。その後、すべての行と列を反復処理し、[isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) を使用して結合領域内のセルを識別します。マッチする各セルについて、`row;column` の順序でセル座標、[getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--)、[getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--)、および領域の開始座標である [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) と [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) を出力します。

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

## **テーブルセルの枠線を削除**

[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) を作成し、[addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) を使用して最初のスライドにテーブルを追加します。列幅、行高さ、およびテーブルの位置はポイントで指定します。この例では、4 つすべてのセル枠線を [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) に設定し、枠線を非表示にします。

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

## **対角線セル枠線の追加**

[getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) を使用して左上隅から右下隅へ線を描画し、[getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) を使用して左下隅から右上隅へ線を描画します。対角線はコーナーヘッダーを示すことができ、両方の対角線を組み合わせて X を形成し、セルが該当しないことを示すこともできます。

各対角線は [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) です。その [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) で、[setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) を使用して [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) を選択し、[getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) で色を指定します。[setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) で線の幅をポイント単位で設定します。

この例では、1 行に 3 つのセルを作成します。下向きの赤い対角線、上向きの青い対角線、そして両方の対角線です。上、下、左、右のセル枠線は変更しません。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

対角線は書式設定プロパティであり、セルの分割ではありません。各セルは [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) を通じて取得できる単一のテキストフレームを保持します。対角線の両側の領域は個別に編集できません。

保存されたテーブルは Microsoft PowerPoint でレンダリングされます:

![左上から右下への赤い対角線、左下から右上への青い対角線、そして両方の対角線で X を形成する 3 つのテーブルセル](diagonal-cell-borders.png)

*左から右へ: 下向き対角線（赤、3 pt）、上向き対角線（青、5 pt）、両方の対角線*

## **テーブルセルの結合**

[mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) を使用して、テーブルセルの矩形範囲を 1 つのセルに結合します。範囲の左上隅と右下隅のセルを指定します。最後の引数は、結合が指定範囲外のセルを含むかどうかを制御します。`false` は結合をその範囲内に留めます。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、`(1, 1)` から `(2, 2)` の 4 つの中心セルを結合します。結果として得られるセルは 2 列と 2 行にまたがりますが、テーブルの基礎グリッドは 4 列 4 行のままです。結合セルの内容や書式設定にアクセスするには、左上の位置 `table.get_Item(1, 1)` を使用します。この例ではこの位置です。結合範囲内の他の位置はテーブルグリッドの一部として残り、範囲外のセルインデックスは変更されません。

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

前の例でセルを結合するとテーブルのグリッドは保持されます。セルを分割すると新しいグリッド列が追加され、右側のセルの列インデックスが変わる可能性があります。Aspose.Slides は PowerPoint のテーブルグリッドモデルに従います。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、セル `(1, 1)` に対して [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) を呼び出します。セルの 70 ポイント幅の半分を渡して、幅が等しい 2 つのセルを作成します。

この分割後、2 つの半分は `table.get_Item(1, 1)` と `table.get_Item(2, 1)` でアクセスできます。テーブルグリッドは現在 5 列になり、元々列 2 と列 3 にあったセルはそれぞれ列 3 と列 4 に移動します。行インデックスは変わりません。分割後にセルにアクセスする際は、更新された列インデックスを使用してください。

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
[![結合されていない 70 ポイントセルが 2 つの 35 ポイントセルに分割され、5 番目のグリッド列が追加され、右側のインデックスがシフトします。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*幅の分割はセル (1, 1) に影響し、0 ベースの (column, row) インデックスを使用します。その他の行は新しい列位置の両方にまたがるセルを保持します。*
<!-- visual-explanation:manage-cells:end -->

### **行または列のスパンで結合セルを分割**

データ入力用に結合テンプレートセルを準備するには、既存の行境界に沿って分割するために [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) を使用するか、列境界に沿って分割するために [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) を使用します。

`index` 引数は、分割上部の行数または左側の列数をカウントし、結合領域に対して相対的です：

- 行分割: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- 列分割: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

この例では、プレゼンテーションの最初のスライドの最初のシェイプがテーブルであり、`(1, 2)` と `(1, 3)` が垂直に結合されていることを前提としています。下側の位置から開始し、[getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) と [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) を使用して起点を特定し、両方のスパンを確認します。`splitByRowSpan(1)` は製品名用に行 2 と行 3 を分割します。横方向の 2 列結合の場合は、代わりに `splitByColSpan(1)` を使用します。

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

        // 分割後にテーブルから結果のセルを取得します。
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

テーブルグリッドおよび周囲のセルインデックスは変更されません。結果のセルは座標で取得します；ここでは両方ともスパンが 1 で、[isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) は `false` を出力します。より大きな領域は、1 回の分割後も部分的に結合されたままにできる場合があります。

元のテキストと書式設定は上部（または左側）のセルに残り、新しいセルは空ですが、塗りつぶし、枠線、余白などのセル書式設定を継承します。分割後にセルにデータを入力し、必要なテキスト書式設定を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式設定が保持されたまま、別々の「Product A」セルと「Product B」セルが含まれます。詳細は [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) を参照してください。

### **特定の高さでセルを分割**

[splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) は上部の高さをポイントで受け取ります。[splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) は上部の既存グリッド行数を受け取ります。右側の列で 40 ポイントのセルを中央に配置するには、セルの実際の高さから 40 を減算し、残りのスペースを上下に均等に分割します。

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

最初の分割でグリッド行が追加され、セル `(1, 1)` の下部に 90 ポイントが残ります。2 回目の分割でそのセルは 40 ポイントの中間セルと 50 ポイントの下部セルに分割されます。右側の列は上から順に 50、40、50 ポイントの 3 つのセルを持ちます。左側のセルは 3 行すべてにまたがり、元の高さ 140 ポイントを保持します。

![左側のセルはテーブル全体の高さにまたがり、中央に「Middle」セルがある 3 つのセルの横に配置されています。](split-by-height.png)

## **テーブルセルの背景色を変更**

この例では、列幅 150 ポイント、行高さ 50 ポイントのテーブルを作成します。[setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) を使用して塗りつぶしを実体に設定し、[getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) が返す色を赤に設定して、セル `(2, 3)`（3 列目・4 行目）に適用します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

この例を実行する前に、入力画像を作業ディレクトリに配置してください。[Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) で画像を読み込み、[addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) を使用してプレゼンテーションの画像コレクションに追加します。その後、画像をテーブルの最初のセル `(0, 0)` の画像塗りつぶしに割り当てます。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) は画像をセル全体に拡大して表示し、アスペクト比が変わることがあります。列幅と行高さはポイント単位です。ロードされた画像は、プレゼンテーションに追加された後、`finally` ブロックで破棄されます。

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

**単一のセルの各側面に対して異なる線の太さやスタイルを設定できますか？**

はい。上部[​top​](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--) /下部[​bottom​](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--) /左部[​left​](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--) /右部[​right​](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) の枠線は個別のプロパティを持つため、各側面の太さやスタイルを異なる設定にできます。

**セルの背景に画像を設定した後、列や行のサイズを変更すると画像はどうなりますか？**

動作は[fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) に依存します（stretch/タイル）。ストレッチの場合、画像は新しいセルサイズに合わせて調整されます。タイルの場合、タイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/androidjava/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（ポーション）レベル、またはテーブル/シェイプ全体のレベルで設定します。実際には、セル内の一部またはすべてのテキストにリンクを割り当てます。

**単一のセル内でフォントを異なる設定にできますか？**

はい。セルのテキストフレームは、[portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/)（ラン）ごとにフォントファミリー、スタイル、サイズ、色などの書式設定を個別に設定できます。