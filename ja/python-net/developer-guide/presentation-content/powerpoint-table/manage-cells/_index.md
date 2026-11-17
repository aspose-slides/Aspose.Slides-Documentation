---
title: Python でプレゼンテーションのテーブルセルを管理する
linktitle: セルを管理する
type: docs
weight: 30
url: /ja/python-net/manage-cells/
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
description: "Python で PowerPoint のテーブルセルを管理します：結合されたセルの識別、枠線の削除、セルの分割、背景色と画像の設定を Aspose.Slides for Python via .NET で実行します。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内のテーブルセルにアクセスして変更できます。この記事では、結合されたテーブルセルを特定する方法、セルの枠線を削除する方法、セルを結合または分割した後のセル番号付けの操作方法、セルの背景色を変更する方法、およびテーブルセル内に画像を追加する方法を説明します。例では、プレゼンテーションを作成または開き、スライドからテーブルを取得し、セルのプロパティを介してセルの書式設定を更新し、変更されたプレゼンテーションを PPTX ファイルとして保存する手順を示します。

Aspose.Slides はゼロベースのインデックスを使用します。本記事の座標は `(column, row)` の形式で示されています。

## **結合されたテーブルセルの識別**

この例は既存のプレゼンテーションを開き、最初のスライドの最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。その後、すべての行と列を走査し、[is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) を使用して結合領域内のセルを識別します。マッチした各セルについて、`row;column` の順序でセル座標、[row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)、[col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)、および領域の開始座標である [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) と [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) を出力します。

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **テーブルセルの枠線の削除**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、[add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) を使用して最初のスライドにテーブルを追加します。列幅、行高さ、テーブルの位置はポイント単位で指定します。この例では、すべてのセル枠線を [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) に設定し、非表示にします。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **対角線枠線の追加**

[border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) を使用して左上から右下へ線を描画し、[border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) を使用して左下から右上へ線を描画します。対角線は角ヘッダーのマークに使用でき、両方の対角線を組み合わせて X マークを作成し、セルが該当しないことを示すことができます。

各対角線は [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/) です。その [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) で [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) を [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) に設定し、[solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) を選択します。線の [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) はポイント単位で指定します。

この例では、1 行に 3 つのセルを作成し、赤い下向き対角線、青い上向き対角線、そして両方の対角線を設定します。上下左右のセル枠線は変更しません。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

対角線は書式設定プロパティであり、セルの分割ではありません。各セルは単一の [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) を保持し、対角線の両側の領域を個別に編集することはできません。

保存されたテーブルは Microsoft PowerPoint で次のように表示されます:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*左から右へ: 下向き対角線（赤、3 pt）、上向き対角線（青、5 pt）、両対角線（X）。*

## **テーブルセルの結合**

[merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) を使用して、矩形領域のテーブルセルを 1 つのセルに結合します。範囲の左上隅と右下隅のセルを指定します。最後の引数は、結合が指定範囲外のセルを含むかどうかを制御します。`False` を指定すると結合は範囲内にとどまります。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、`(1, 1)` から `(2, 2)` までの中央 4 セルを結合します。結果として得られるセルは 2 列×2 行にまたがりますが、テーブルの基礎グリッドは 4 列×4 行のままです。結合セルの内容や書式にアクセスするには、左上位置 `table.rows[1][1]` を使用します。結合範囲外のセルのインデックスは変わりません。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルセルの分割**

前の例でセルを結合した場合でも、テーブルのグリッドは保持されます。セルを分割すると新しいグリッド列が追加され、右側のセルの列インデックスが変わります。Aspose.Slides は PowerPoint のテーブルグリッドモデルに従います。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、セル `(1, 1)` に対して [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) を呼び出します。セルの幅 70 ポイントの半分を渡すことで、同じ幅の 2 つのセルが作成されます。

分割後、2 つの半分はそれぞれ `table.rows[1][1]` と `table.rows[1][2]` でアクセスできます。テーブルグリッドは 5 列になり、元々列 2 と 3 にあったセルはそれぞれ列 3 と 4 に移動します。行インデックスは変わりません。分割後にセルにアクセスする際は、更新された列インデックスを使用してください。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```


<!-- visual-explanation:manage-cells:start -->
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*The width split affects cell (1, 1), using zero-based (column, row) indices. Other rows keep a cell spanning both new column positions.*
<!-- visual-explanation:manage-cells:end -->

### **行または列のスパンで結合セルを分割する**

結合テンプレートセルをデータ入力用に準備するには、[split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) を使用して既存の行境界で分割するか、[split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) を使用して列境界で分割します。

`index` 引数は、分割上部の行または左側の列の数をカウントし、結合領域に対して相対的です:

- 行の分割: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)。
- 列の分割: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)。

この例では、プレゼンテーションの最初のスライドの最初のシェイプがテーブルであることを前提とし、`(1, 2)` と `(1, 3)` が縦に結合されていると想定します。下側の位置から開始し、[first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) と [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) を使用して起点を特定し、両方のスパンをチェックします。`split_by_row_span` にインデックス 1 を指定すると、製品名用に行 2 と 3 が分離されます。横方向の 2 列結合の場合は、代わりに `split_by_col_span` にインデックス 1 を指定します。

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # 分割後、テーブルから結果のセルを取得します。
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

テーブルグリッドと周囲のセルインデックスは変更されません。結果のセルは座標で取得できます。ここでは両方ともスパンが 1 で、[is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) は `False` を返します。大きな領域は 1 回の分割だけで部分的に結合されたままにできる場合があります。

元のテキストと書式は上部（または左部）のセルに残り、新しいセルは空ですが、塗りつぶし、枠線、余白などのセル書式は継承します。分割後にセルに文字列を入力し、必要に応じてテキスト書式を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式が保持されたまま「Product A」セルと「Product B」セルが別々に存在します。詳細は [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) を参照してください。

### **特定の高さでセルを分割する**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) は上部部分の高さ（ポイント）を受け取り、[split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) は上部に残す既存グリッド行数を受け取ります。右列のセルを垂直方向に 40 ポイントで中央に配置するには、セルの実際の高さから 40 を引き、残りのスペースを上下に均等に分配します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

最初の分割でグリッド行が追加され、下部の 90 ポイントが `table.rows[1][1]` に残ります。2 回目の分割でそのセルを 40 ポイントの中央セルと 50 ポイントの下部セルに分割します。右列の 3 つのセルは上から順に 50、40、50 ポイントの高さになります。左側のセルは元の高さ 140 ポイントで 3 行すべてに跨ります。

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **テーブルセルの背景色の変更**

この例では、列幅 150 ポイント、行高さ 50 ポイントのテーブルを作成します。セル `(2, 3)`（3 列目・4 行目）に対して、[fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) を solid に設定し、[solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) を赤に設定します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルセル内に画像を追加する**

この例を実行する前に、入力画像を作業ディレクトリに配置してください。画像は [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) で読み込み、[add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) を使用してプレゼンテーションの画像コレクションに追加します。その後、画像をセル `(0, 0)`（テーブルの最初のセル）のピクチャーフィルに割り当てます。

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) は画像をセル全体に拡大し、アスペクト比が変わる可能性があります。列幅と行高さはポイント単位です。`with` ブロックが終了すると、読み込んだ画像は自動的に破棄されます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**セルの各辺に異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)、[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)、[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)、[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) の枠線は個別のプロパティを持ち、各辺の太さとスタイルを別々に設定できます。

**セルの背景に画像を設定した後で列／行のサイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)（stretch/​tile）に依存します。ストレッチの場合、画像は新しいセルサイズに合わせて調整されます。タイルの場合はタイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを設定できますか？**

[Hyperlinks](/slides/ja/python-net/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（ポーション）レベル、またはテーブル／シェイプ全体のレベルで設定します。実務的には、ポーションにリンクを付与するか、セル内のすべてのテキストにリンクを付与します。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキストフレームは [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)（ラン）をサポートしており、フォントファミリ、スタイル、サイズ、色などを個別に書式設定できます。