---
title: Python を使用してプレゼンテーションのテーブルセルを管理する
linktitle: セルの管理
type: docs
weight: 30
url: /ja/python-java/manage-cells/
keywords:
- テーブルセル
- セル結合
- 罫線の削除
- セル分割
- セル内画像
- 背景色
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint のテーブルセルを簡単に管理できます。セルへのアクセス、変更、スタイリングを迅速に習得し、スライドの自動化をシームレスに実現します。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーションのテーブルセルにアクセスして変更できます。本稿では、結合されたテーブルセルの判別、セルの罫線の削除、結合または分割後のセル番号の操作、セルの背景色の変更、テーブルセル内への画像追加方法について説明します。例では、プレゼンテーションの作成またはオープン、スライドからテーブルを取得、セルプロパティによる書式設定の更新、変更後のプレゼンテーションを PPTX ファイルとして保存する方法を示します。

## **結合されたテーブルセルの識別**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドからテーブルを取得します。
3. テーブルの行と列を走査して結合セルを探します。
4. 結合セルが見つかったらメッセージを出力します。

この Python コードは、プレゼンテーション内の結合テーブルセルを識別する方法を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # 最初のスライドの最初のシェイプがテーブルであると想定します。
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **テーブルセルの罫線を削除する**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 列幅のリストを定義します。
4. 行高さのリストを定義します。
5. [addTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addTable) メソッドでスライドにテーブルを追加します。
6. すべてのセルを走査し、上・下・右・左の罫線をクリアします。
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、テーブルセルの罫線を削除する方法を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # 最初のスライドにアクセスします。
    slide = presentation.getSlides().get_Item(0)

    # 列幅と行高さを定義します。
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # スライドにテーブルを追加します。
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 各セルの罫線書式を設定します。
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **結合セルの番号付け**

2 つのセルペア (1, 1) と (2, 1)、および (1, 2) と (2, 2) を結合すると、結果のテーブルはセル番号を保持します。この Python コードはその手順を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 最初のスライドにアクセスします。
    slide = presentation.getSlides().get_Item(0)

    # 列幅と行高さを定義します。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # スライドにテーブルを追加します。
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 各セルの罫線書式を設定します。
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # (1, 1) と (2, 1) のセルを結合します。
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # (1, 2) と (2, 2) のセルを結合します。
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

その後、さらに (1, 1) と (1, 2) を結合します。結果として、中央に大きな結合セルを持つテーブルが得られます:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 最初のスライドにアクセスします。
    slide = presentation.getSlides().get_Item(0)

    # 列幅と行高さを定義します。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # スライドにテーブルを追加します。
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 各セルの罫線書式を設定します。
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # (1, 1) と (2, 1) のセルを結合します。
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # (1, 2) と (2, 2) のセルを結合します。
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # (1, 1) と (1, 2) のセルを結合します。
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **分割セルの番号付け**

前述の例では、テーブルセルを結合しても他のセルの番号は変わりません。

今回は、結合セルのない通常のテーブルからセル (1, 1) を分割し、特別なテーブルを作成します。このテーブルの番号付けは奇妙に見えるかもしれませんが、これは Microsoft PowerPoint がテーブルセルに付与する番号付け方式であり、Aspose.Slides も同様です。

この Python コードは、上記の手順を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 最初のスライドにアクセスします。
    slide = presentation.getSlides().get_Item(0)

    # 列幅と行高さを定義します。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # スライドにテーブルを追加します。
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 各セルの罫線書式を設定します。
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # セル (1, 1) を分割します。
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テーブルセルの背景色を変更する**

この Python コードは、テーブルセルの背景色を変更する方法を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # 最初のスライドにアクセスします。
    slide = presentation.getSlides().get_Item(0)

    # 列幅と行高さを定義します。
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # スライドにテーブルを追加します。
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # セルの背景色を設定します。
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テーブルセル内に画像を追加する**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 列幅のリストを定義します。
4. 行高さのリストを定義します。
5. [addTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addTable) メソッドでスライドにテーブルを追加します。
6. [Images.fromFile](https://reference.aspose.com/slides/ja/python-java/aspose.slides/images/#fromFile) を使用して画像ファイルを読み込みます。
7. 画像をプレゼンテーションに追加して [PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) オブジェクトを作成します。
8. テーブルセルの [FillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fillformat/) の塗りタイプを [FillType.Picture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filltype/#Picture) に設定します。
9. 画像をテーブルの最初のセルに追加します。
10. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、テーブル作成時にテーブルセル内に画像を配置する方法を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # 最初のスライドにアクセスします。
    slide = presentation.getSlides().get_Item(0)

    # 列幅と行高さを定義します。
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # スライドにテーブルを追加します。
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # 画像ファイルからプレゼンテーション画像を作成します。
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # 画像を最初のテーブルセルに追加します。
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**単一セルの各辺に異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cellformat/#getBorderRight) 罫線は個別のプロパティを持つため、各辺の太さやスタイルを別々に設定できます。これは本稿で紹介したセルの側面ごとの罫線制御に基づくものです。

**セルの背景に画像を設定した後、列・行サイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillmode/)（stretch/​tile）に依存します。stretch の場合、画像は新しいセルサイズに合わせて伸縮し、tile の場合はタイルが再計算されます。この記事ではセル内の画像表示モードについて説明しています。

**セル内のすべてのコンテンツにハイパーリンクを割り当てられますか？**

[Hyperlinks](/slides/ja/python-java/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（ポーション）レベル、またはテーブル/シェイプ全体のレベルで設定できます。実際には、ポーション単位またはセル内のすべてのテキストにリンクを付与します。

**単一セル内でフォントを複数設定できますか？**

はい。セルのテキストフレームは [portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/)（ラン）ごとにフォントファミリ、スタイル、サイズ、色などの書式を個別に設定できます。