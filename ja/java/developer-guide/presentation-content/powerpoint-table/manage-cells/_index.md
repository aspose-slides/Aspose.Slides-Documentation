---
title: Java を使用したプレゼンテーションのテーブルセル管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/java/manage-cells/
keywords:
- テーブルセル
- セルの結合
- 枠線の削除
- セルの分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java で PowerPoint のテーブルセルを管理します: 結合セルの識別、枠線の削除、セルの分割、背景色と画像の設定を Aspose.Slides for Java で実行します。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内のテーブルセルにアクセスして変更できます。この記事では、結合されたテーブルセルの特定、セルの枠線の削除、セルの結合または分割後の番号付けの操作、セルの背景色の変更、テーブルセル内への画像の追加方法について説明します。サンプルでは、プレゼンテーションの作成またはオープン、スライドからテーブルの取得、セルプロパティによるセル書式の更新、そして変更されたプレゼンテーションを PPTX ファイルとして保存する方法を示しています。

Aspose.Slides は、テーブルセルへアクセスする際に 0 から始まるインデックスを使用し、順序は `(column, row)` です。

## **結合されたテーブルセルの識別**

この例では既存のプレゼンテーションを開き、最初のスライドの最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。その後、すべての行と列を反復し、[isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) を使用して結合領域内のセルを特定します。マッチする各セルについて、`row;column` の順序でセル座標、[getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)、[getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)、および領域の開始座標である [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) と [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) を出力します。

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

## **テーブルセルの枠線の削除**

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) を作成し、[addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) を使用して最初のスライドにテーブルを追加します。列幅、行高さ、テーブルの位置はポイント単位で指定します。この例では、すべてのセル枠線を [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) に設定し、枠線を非表示にします。

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

## **テーブルセルの結合**

[mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) を使用して、矩形領域のテーブルセルを 1 つのセルに結合します。範囲の左上隅と右下隅のセルを指定します。最後の引数は、結合が指定範囲外のセルを含むかどうかを制御し、`false` の場合は範囲内に留まります。

この例では、70 ポイントの列幅と行高さを持つ 4×4 のテーブルを作成し、`(1, 1)` から `(2, 2)` の中央の 4 つのセルを結合します。結果のセルは 2 列分と 2 行分に跨り、テーブルの基礎グリッドは 4 列 4 行のままです。この例では結合されたセルの内容や書式にアクセスするために、左上位置 `table.get_Item(1, 1)` を使用します。結合範囲内の他の位置はテーブルグリッドの一部であり、範囲外のセルインデックスは変更されません。

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

前の例でセルを結合するとテーブルのグリッドは保持されます。セルを分割すると新しいグリッド列が追加され、右側のセルの列インデックスが変わることがあります。Aspose.Slides は PowerPoint のテーブルグリッドモデルに従います。

この例では、70 ポイントの列幅と行高さを持つ 4×4 のテーブルを作成し、セル `(1, 1)` に対して [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) を呼び出します。セルの幅 70 ポイントの半分を渡して、同幅の 2 つのセルを作成します。

この分割後、2 つの半分は `table.get_Item(1, 1)` と `table.get_Item(2, 1)` でアクセスできます。テーブルグリッドは現在 5 列になり、元々列 2 と列 3 にあったセルはそれぞれ列 3 と列 4 に移動します。行インデックスは変わりません。分割後にセルへアクセスする際は、これら更新された列インデックスを使用してください。

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

### **行または列のスパンによる結合セルの分割**

結合されたテンプレートセルをデータ入力用に準備するには、既存の行境界に沿って分割するために [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) を使用し、列境界に沿って分割する場合は [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) を使用します。

`index` 引数は、分割の上部部分の行数または左側部分の列数をカウントし、結合領域に対して相対的です。

- 行分割: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)。
- 列分割: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)。

この例では、プレゼンテーションの最初のスライドの最初のシェイプがテーブルであり、`(1, 2)` と `(1, 3)` が縦に結合されていることを前提としています。下側の位置から開始し、[getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) と [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) を使用して起点を特定し、両方のスパンを確認します。`splitByRowSpan(1)` は製品名用に行 2 と 3 を分離します。横方向の 2 列結合の場合は、代わりに `splitByColSpan(1)` を使用します。

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

        // 分割後にテーブルから得られたセルを取得します。
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

テーブルグリッドと周囲のセルインデックスは変更されません。座標で結果のセルを取得すると、ここでは両方ともスパンが 1 であり、[isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) は `false` を返します。大きな領域は 1 回の分割後も部分的に結合されたままにできることがあります。

元のテキストと書式設定は上部（または左側）のセルに残り、新しいセルは空ですが、塗りつぶし、枠線、余白などのセル書式を継承します。分割後にセルにデータを入力し、必要なテキスト書式設定を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式が保持されたまま、"Product A" と "Product B" の別々のセルが含まれます。詳細は [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) を参照してください。

## **テーブルセルの背景色の変更**

この例では、150 ポイントの列幅と 50 ポイントの行高さを持つテーブルを作成します。[setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) を使用して単色塗りつぶしを選択し、[getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) が返す色を赤に設定して、列 3 行 4 のセル `(2, 3)` に適用します。

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

## **テーブルセル内への画像の追加**

この例を実行する前に、入力画像を作業ディレクトリに配置してください。画像は [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) で読み込み、[addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) を使ってプレゼンテーションの画像コレクションに追加します。次に、画像をテーブルの最初のセルである `(0, 0)` のピクチャー塗りつぶしに割り当てます。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) は画像を伸張してセル全体を埋めますが、アスペクト比が変わる可能性があります。列幅と行高さはポイント単位です。読み込んだ画像は、プレゼンテーションに追加された後、`finally` ブロックで破棄されます。

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

## **よくある質問**

**単一セルの各辺に対して異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) の枠線は個別のプロパティを持つため、各辺の太さやスタイルを異しく設定できます。

**セルの背景に画像を設定した後、列や行のサイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) に依存します。伸張 (stretch) の場合、画像は新しいセルサイズに合わせて調整されます。タイル (tile) の場合、タイルが再計算されます。

**セル内の全コンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/java/manage-hyperlinks/) は、セルのテキストフレーム内のテキスト（ポーション）レベル、またはテーブル/シェイプ全体のレベルで設定されます。実際には、セル内の一部または全テキストにリンクを割り当てます。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキストフレームは、[portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)（ラン）ごとにフォントファミリー、スタイル、サイズ、色などの独立した書式設定をサポートしています。