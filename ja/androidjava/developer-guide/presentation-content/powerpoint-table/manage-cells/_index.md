---
title: Android でのプレゼンテーションの表セル管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/androidjava/manage-cells/
keywords:
- 表セル
- セル結合
- 枠線の削除
- セルの分割
- セル内画像
- 背景色
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Java で Aspose.Slides を使用して、PowerPoint の表セルを管理します。結合セルの識別、枠線の削除、セルの分割、背景色や画像の設定が可能です。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーションの表セルにアクセスして変更できます。この記事では、結合された表セルの識別、セルの枠線の削除、結合または分割後のセル番号の操作、セルの背景色の変更、表セル内への画像の追加方法について説明します。例では、プレゼンテーションの作成またはオープン、スライドから表を取得、セルプロパティによるセル書式設定の更新、変更したプレゼンテーションを PPTX ファイルとして保存する方法を示しています。

Aspose.Slides は、`(column, row)` の順序でテーブルセルにアクセスするために、0 ベースのインデックスを使用します。

## **結合された表セルの識別**

この例では既存のプレゼンテーションを開き、最初のスライドの最初の図形を表として取得します。スライドと図形が存在し、図形が表であることを前提としています。その後、すべての行と列を走査し、[isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) を使用して結合領域のセルを識別します。マッチする各セルについて、`row;column` の順序でセル座標、[getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--)、[getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--)、および領域の開始座標である [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--)、[getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) を出力します。

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

## **表セルの枠線を削除**

[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) を作成し、[addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) を使用して最初のスライドに表を追加します。列幅、行高さ、表の位置はポイントで指定されます。例では、すべての 4 つのセル枠線を [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) に設定し、枠線を非表示にします。

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

## **表セルの結合**

[mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) を使用して、矩形領域の表セルを 1 つのセルに結合します。範囲の左上隅と右下隅のセルを指定します。最後の引数は、指定された範囲外のセルを結合に含めるかどうかを制御します。`false` を指定すると、結合はその範囲内にとどまります。

この例では、70 ポイントの列幅と行高さを持つ 4×4 の表を作成し、`(1, 1)` から `(2, 2)` までの中央の 4 つのセルを結合します。結果として得られるセルは 2 列×2 行にまたがりますが、表の基礎となるグリッドは依然として 4 列 4 行のままです。結合されたセルの内容や書式設定にアクセスするには、左上位置 `table.get_Item(1, 1)` を使用します。この例では、結合領域内の他の位置は表グリッドの一部として残り、範囲外のセルのインデックスは変わりません。

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

## **表セルの分割**

前の例でセルを結合すると、表のグリッドは維持されます。セルを分割すると新しいグリッド列が作成され、右側のセルの列インデックスが変わることがあります。Aspose.Slides は PowerPoint の表グリッドモデルに従います。

この例では、70 ポイントの列幅と行高さを持つ 4×4 の表を作成し、セル `(1, 1)` に対して [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) を呼び出します。セルの 70 ポイント幅の半分を渡して、幅が等しい 2 つのセルを作成します。

この分割後、2 つの半分は `table.get_Item(1, 1)` と `table.get_Item(2, 1)` でアクセスできます。表のグリッドは現在 5 列になり、元々列 2 と列 3 にあったセルはそれぞれ列 3 と列 4 に移動します。行インデックスは変わりません。分割後にセルへアクセスする際は、更新された列インデックスを使用してください。

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

### **行または列のスパンで結合セルを分割**

データ入力用に結合テンプレートセルを準備するには、既存の行境界に沿って分割するために [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) を、列境界に沿って分割するために [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) を使用します。

`index` 引数は、分割された上部の行または左側の列の数をカウントし、結合領域に対して相対的です。

- 行の分割: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- 列の分割: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

この例では、プレゼンテーションの最初のスライドの最初の図形が表であり、`(1, 2)` と `(1, 3)` が縦に結合されていることを想定しています。下側の位置から開始し、[getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) と [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) を使用して起点を特定し、両方のスパンを確認します。次に `splitByRowSpan(1)` を呼び出して、製品名用に行 2 と行 3 を分離します。横方向の 2 列結合の場合は、代わりに `splitByColSpan(1)` を使用します。

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

表のグリッドおよび周囲のセルインデックスは変更されません。座標で結果のセルを取得します。ここでは、両方ともスパンが 1 であり、[isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) は `false` を出力します。1 回の分割後も、より大きな領域が部分的に結合されたままになることがあります。

元のテキストと書式設定は上部（または左側）のセルに残り、新しいセルは空ですが、塗りつぶし、枠線、余白などのセル書式設定を継承します。分割後にセルにデータを入力し、必要なテキスト書式設定を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式が保持されたまま、別々の「Product A」セルと「Product B」セルが含まれます。詳細は [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) を参照してください。

## **表セルの背景色の変更**

この例では、150 ポイントの列幅と 50 ポイントの行高さを持つ表を作成します。[setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) を使用して単色塗りを選択し、[getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) が返す色を赤に設定して、セル `(2, 3)`（3 列目、4 行目）の背景色を変更します。

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

## **表セル内に画像を追加**

この例を実行する前に、入力画像を作業ディレクトリに配置してください。画像は [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) で読み込まれ、[addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) を使用してプレゼンテーションの画像コレクションに追加されます。その後、画像を表の最初のセルである `(0, 0)` のピクチャーフィルに割り当てます。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) は画像をセル全体に伸ばしてフィットさせますが、アスペクト比が変わる可能性があります。列幅と行高さはポイントで指定します。読み込んだ画像は、プレゼンテーションに追加された後、`finally` ブロックで破棄されます。

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

**単一のセルの各側面で異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) の枠線は個別のプロパティを持つため、各側面の太さやスタイルを個別に設定できます。

**セルの背景として画像を設定した後に列または行のサイズを変更すると、画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/)（stretch/tiling）に依存します。stretch を使用すると、画像は新しいセルサイズに合わせて調整されます。tiling を使用すると、タイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/androidjava/manage-hyperlinks/) は、セルのテキストフレーム内のテキスト（portion）レベル、またはテーブル/シェイプ全体のレベルで設定します。実際には、リンクを特定の portion に割り当てるか、セル内のすべてのテキストに割り当てます。

**単一のセル内でフォントを異なるものに設定できますか？**

はい。セルのテキストフレームは、[portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/)（ラン）をサポートしており、フォント名、スタイル、サイズ、色などを個別に書式設定できます。