---
title: Python を使用してプレゼンテーションのテーブルセルを管理する
linktitle: セルを管理
type: docs
weight: 30
url: /ja/python-java/manage-cells/
keywords:
- テーブルセル
- セルの結合
- 罫線の削除
- セルの分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python で PowerPoint のテーブルセルを管理します。結合セルの特定、罫線の削除、セルの分割、背景色や画像の設定を、Java 経由の Aspose.Slides for Python で行います。"
---
## **概要**

Aspose.Slides は PowerPoint プレゼンテーションのテーブルセルにアクセスし、変更することができます。この記事では、結合されたテーブルセルの特定、セルの罫線の削除、セルを結合または分割した後のセル番号の操作、セルの背景色の変更、テーブルセル内への画像追加方法を説明します。例では、プレゼンテーションの作成またはオープン、スライドからテーブルを取得、セルプロパティを介したセルの書式設定の更新、そして変更したプレゼンテーションを PPTX ファイルとして保存する方法を示します。

Aspose.Slides は、テーブルセルにアクセスする際にゼロベースのインデックスを使用し、順序は `(column, row)` です。

## **結合されたテーブルセルの特定**

The example opens an existing presentation and accesses the first shape on the first slide as a table. It assumes that the slide and shape exist and that the shape is a table. It then iterates through all rows and columns and uses [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) to identify cells in merged regions. For each match, it prints the cell coordinates in `row;column` order, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), and the region's starting coordinates, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) and [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **テーブルセルの罫線を削除する**

Create a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) and add a table to its first slide with [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Column widths, row heights, and the table position are specified in points. The example sets all four cell borders to [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) , making them invisible.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **対角罫線を追加する**

Use [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) to draw a line from the top-left corner to the bottom-right, and [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) to draw a line from the bottom-left corner to the top-right. A diagonal can mark a corner header. Both diagonals can form an X to mark a cell as not applicable.

Each diagonal is an [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/). In its [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat), use [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) to select [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) and choose a color through [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor). Set the line's width in points with [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth).

The example creates three cells in one row: a red downward diagonal, a blue upward diagonal, and both diagonals. It leaves the top, bottom, left, and right cell borders unchanged.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A diagonal is a formatting property, not a cell split. Each cell retains a single text frame, accessed through [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame). The regions on either side of a diagonal cannot be edited independently.

The saved table, rendered in Microsoft PowerPoint:

![3 つのテーブルセルが、左上から右下への赤い対角線、左下から右上への青い対角線、そして X 形に交差する両対角線を示しています。](diagonal-cell-borders.png)

*左から右へ: 下向きの対角線（赤、3 pt）、上向きの対角線（青、5 pt）、および両方の対角線。*

## **テーブルセルの結合**

Use [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) to combine a rectangular range of table cells into one cell. Specify the cells at the top-left and bottom-right corners of the range. The final argument controls whether the merge may include cells outside the specified range; `False` keeps the merge within that range.

The example creates a 4-by-4 table with 70-point columns and rows, then merges the four central cells from `(1, 1)` through `(2, 2)`. The resulting cell spans two columns and two rows, while the table's underlying grid retains four columns and four rows. To access the merged cell's content or formatting, use its top-left position: `table.get_Item(1, 1)` in this example. The other positions in the merged range remain part of the table grid, so the indices of cells outside the range do not change.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テーブルセルの分割**

Merging cells in the previous example preserves the table's grid. Splitting a cell can introduce a new grid column and change the column indices of cells to its right. Aspose.Slides follows PowerPoint's table grid model.

This example creates a 4-by-4 table with 70-point columns and rows and calls [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) on cell `(1, 1)`. Half of the cell's 70-point width is passed to create two equal-width cells.

After this split, the two halves are accessed as `table.get_Item(1, 1)` and `table.get_Item(2, 1)`. The table grid now has five columns: cells originally in columns 2 and 3 move to columns 3 and 4, respectively. Row indices remain unchanged. Use these updated column indices when accessing cells after the split.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


<!-- visual-explanation:manage-cells:start -->
[![結合されていない 70 ポイントのセルが 35 ポイントのセル 2 つに分割され、5 番目のグリッド列が追加され、右側のインデックスがシフトします。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*幅の分割はセル (1, 1) に影響し、ゼロベース (列, 行) インデックスを使用します。他の行は新しい列位置の両方にまたがるセルを保持します。*
<!-- visual-explanation:manage-cells:end -->

### **行または列スパンで結合セルを分割する**

To prepare merged template cells for data population, use [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) to split along an existing row boundary, or [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) to split along a column boundary.

The `index` argument counts rows in the upper part or columns in the left part of the split; it is relative to the merged region:

- 行の分割: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- 列の分割: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

The example expects a presentation to have a table as the first shape on the first slide, with `(1, 2)` and `(1, 3)` merged vertically. Starting from the lower position, it uses [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) and [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) to locate the origin and checks both spans. `splitByRowSpan(1)` then separates rows 2 and 3 for product names. For a horizontal two-column merge, use `splitByColSpan(1)` instead.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # 分割後にテーブルから結果のセルを取得する。
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

The table grid and surrounding cell indices stay unchanged. Retrieve the resulting cells by their coordinates; here, both have spans of 1 and [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) prints `False`. Larger regions can remain partly merged after one split.

The original text and its formatting remain in the upper (or left) cell; the new cell is empty but inherits cell formatting such as fill, borders, and margins. Populate the cells after splitting and set any required text formatting explicitly.

The saved presentation contains separate "Product A" and "Product B" cells with the template's cell formatting retained. See the [Cell API リファレンス](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) for details.

### **特定の高さでセルを分割する**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) takes the height of the upper part in points. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) takes the number of existing grid rows in the upper part. To center a 40-point cell in the right column, subtract 40 from the cell’s actual height and divide the remaining space equally above and below it.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The first split adds a grid row and leaves the lower 90 points in cell `(1, 1)`. The second split divides that cell into a 40-point middle cell and a 50-point bottom cell. The right column now has three cells with heights of 50, 40, and 50 points from top to bottom. The left cell spans all three rows and retains its original height of 140 points.

![左側のセルがテーブル全体の高さにわたり、中央に「Middle」セルがある 3 つのセルと並んでいます。](split-by-height.png)

## **テーブルセルの背景色を変更する**

This example creates a table with 150-point columns and 50-point rows. It uses [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) to select a solid fill and sets the color returned by [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) to red for cell `(2, 3)`, in the third column and fourth row.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テーブルセル内に画像を追加する**

Place the input image in the working directory before running this example. It loads the image with [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) and adds it to the presentation's image collection with [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). It then assigns the image to the picture fill of cell `(0, 0)`, the first cell in the table.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) stretches the image to fill the cell, which may change its aspect ratio. Column widths and row heights are in points. The loaded image is disposed in a `finally` block after it is added to the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**単一セルの各側面に対して異なる線の太さやスタイルを設定できますか？**

Yes. The [上](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[下](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[左](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[右](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) borders have separate properties, so the thickness and style of each side can differ.

**セルの背景に画像を設定した後、列/行のサイズを変更すると画像はどうなりますか？**

The behavior depends on the [塗りつぶしモード](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). With stretching, the image adjusts to the new cell; with tiling, the tiles are recalculated.

**セル内のすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[ハイパーリンク](/slides/ja/python-java/manage-hyperlinks/) are set at the text (portion) level inside the cell’s text frame or at the level of the entire table/shape. In practice, you assign the link to a portion or to all the text in the cell.

**単一セル内で異なるフォントを設定できますか？**

Yes. A cell’s text frame supports [ポーション](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.