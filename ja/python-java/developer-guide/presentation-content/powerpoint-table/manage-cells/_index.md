---
title: Python を使用したプレゼンテーションのテーブルセルの管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/python-java/manage-cells/
keywords:
- テーブルセル
- セルの結合
- 枠線の削除
- セルの分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python で PowerPoint のテーブルセルを管理します。結合セルの識別、枠線の削除、セルの分割、背景色と画像の設定を、Java 経由の Aspose.Slides for Python で行います。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内のテーブルセルにアクセスして変更できます。この記事では、結合されたテーブルセルの識別、セルの枠線の削除、結合または分割後のセル番号の取り扱い、セルの背景色の変更、テーブルセル内への画像の追加方法を説明します。例では、プレゼンテーションを作成または開き、スライドからテーブルを取得し、セルプロパティを介してセルの書式設定を更新し、変更されたプレゼンテーションを PPTX ファイルとして保存する方法を示します。

Aspose.Slides は、テーブルセルにアクセスする際に、ゼロベースのインデックスを `(column, row)` の順序で使用します。

## **結合されたテーブルセルの識別**

例では、既存のプレゼンテーションを開き、最初のスライドの最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。その後、すべての行と列を反復し、[isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) を使用して結合領域のセルを識別します。マッチする各セルについて、`row;column` の順序でセル座標、[getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)、[getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan)、および領域の開始座標である[getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) と[getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) を出力します。

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

## **テーブルセルの枠線を削除**

まず、[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) を作成し、[addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) を使用して最初のスライドにテーブルを追加します。列幅、行高さ、テーブル位置はポイント単位で指定します。例では、すべての四辺のセル枠線を [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) に設定し、見えなくしています。

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

## **テーブルセルの結合**

矩形範囲のテーブルセルを 1 つのセルに結合するには、[mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) を使用します。範囲の左上隅と右下隅のセルを指定します。最後の引数は、指定範囲外のセルを含めるかどうかを制御します。`False` を指定すると、結合はその範囲内に留まります。

例では、列幅と行高さが 70 ポイントの 4×4 テーブルを作成し、`(1, 1)` から `(2, 2)` の 4 つの中央セルを結合します。結果のセルは 2 列と 2 行にまたがりますが、テーブルの基礎グリッドは 4 列と 4 行のままです。結合されたセルの内容や書式にアクセスするには、左上の位置 `table.get_Item(1, 1)` を使用します。この例では他の位置はテーブルグリッドの一部であり、範囲外のセルインデックスは変わりません。

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

前の例でセルを結合すると、テーブルのグリッドは保持されます。セルを分割すると、新しいグリッド列が導入され、右側のセルの列インデックスが変わります。Aspose.Slides は PowerPoint のテーブルグリッドモデルに従います。

この例では、列幅と行高さが 70 ポイントの 4×4 テーブルを作成し、セル `(1, 1)` に対して [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) を呼び出します。70 ポイントの幅の半分を渡して、幅が等しい 2 つのセルを作成します。

この分割後、2 つの半分は `table.get_Item(1, 1)` と `table.get_Item(2, 1)` でアクセスできます。テーブルグリッドは現在 5 列になり、元々列 2 と 3 にあったセルはそれぞれ列 3 と 4 に移動します。行インデックスは変更されません。分割後にセルへアクセスする際は、これら更新された列インデックスを使用してください。

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

### **行または列のスパンで結合セルを分割**

データ入力のために結合されたテンプレートセルを準備するには、既存の行境界に沿って分割する [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) または列境界に沿って分割する [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) を使用します。

`index` 引数は、分割の上部部分の行または左側部分の列をカウントし、結合領域に対して相対的です：

- 行の分割: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)。
- 列の分割: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan)。

例では、プレゼンテーションに最初のスライドの最初のシェイプとしてテーブルがあり、`(1, 2)` と `(1, 3)` が垂直に結合されていることを想定しています。下側の位置から開始し、[getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) と [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) を使用して起点を特定し、両方のスパンを確認します。`splitByRowSpan(1)` は製品名用に行 2 と 3 を分離します。水平の 2 列結合の場合は、代わりに `splitByColSpan(1)` を使用します。

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

        # 分割後にテーブルから取得したセルを取得する。
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

テーブルグリッドと周囲のセルインデックスは変更されません。結果のセルは座標で取得できます。ここでは、両方ともスパンが 1 で、[isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) は `False` を返します。大きな領域は、1 回の分割後も部分的に結合されたままにできます。

元のテキストと書式は上部（または左側）のセルに残り、新しいセルは空ですが、塗りつぶし、枠線、余白などのセル書式を継承します。分割後にセルにテキストを入力し、必要なテキスト書式を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式が保持されたまま、"Product A" と "Product B" のセルが個別に含まれます。詳細は [Cell API リファレンス](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) を参照してください。

## **テーブルセルの背景色の変更**

この例では、列幅 150 ポイント、行高さ 50 ポイントのテーブルを作成します。[setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) を使用して単色塗りつぶしを選択し、[getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) で取得した色を赤に設定して、セル `(2, 3)`（3 列目・4 行目）に適用します。

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

## **テーブルセル内への画像の追加**

実行前に入力画像を作業ディレクトリに配置してください。画像は [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) で読み込み、[addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) を使用してプレゼンテーションの画像コレクションに追加します。その後、画像をセル `(0, 0)`（テーブルの最初のセル）のピクチャーフィルに割り当てます。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) は画像をセル全体に伸ばすため、アスペクト比が変わる可能性があります。列幅と行高さはポイント単位です。読み込んだ画像は、プレゼンテーションに追加された後、`finally` ブロックで破棄されます。

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

**単一セルの各辺に異なる線の太さやスタイルを設定できますか？**

はい。[上](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[下](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[左](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[右](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) の枠線は個別のプロパティを持つため、各辺の太さとスタイルを個別に設定できます。

**セルの背景に画像を設定した後、列や行のサイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/)（stretch/tilе）に依存します。stretch の場合、画像は新しいセルサイズに合わせて調整され、tiling の場合はタイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを割り当てられますか？**

[Hyperlinks](/slides/ja/python-java/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（ポーション）レベル、またはテーブル/シェイプ全体のレベルで設定します。実際には、リンクをポーションまたはセル内のすべてのテキストに割り当てます。

**単一セル内でフォントを異なるものに設定できますか？**

はい。セルのテキストフレームは、フォントファミリ、スタイル、サイズ、色を個別に設定できる [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/)（ラン）をサポートします。