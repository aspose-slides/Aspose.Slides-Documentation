---
title: Python でプレゼンテーションのテーブルセルを管理する
linktitle: セルを管理
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
description: "Python で PowerPoint のテーブルセルを管理します：結合されたセルの識別、枠線の削除、セルの分割、背景色や画像の設定を Aspose.Slides for Python (via .NET) を使用して行います。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内のテーブルセルにアクセスして変更できます。この記事では、結合されたテーブルセルの識別、セルの枠線の削除、結合または分割後のセル番号の操作、セルの背景色の変更、テーブルセル内への画像の挿入方法について説明します。サンプルは、プレゼンテーションの作成または開く方法、スライドからテーブルを取得する方法、セルプロパティを介してセルの書式設定を更新する方法、および変更されたプレゼンテーションを PPTX ファイルとして保存する方法を示します。

Aspose.Slides は 0 ベースのインデックスを使用します。本記事の座標は `(column, row)` の形式で記述されています。

## **結合されたテーブルセルの識別**

例では既存のプレゼンテーションを開き、最初のスライドの最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。その後、すべての行と列を反復し、[is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) を使用して結合領域のセルを識別します。マッチするセルごとに、`row;column` の順序でセル座標、[row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)、[col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)、および領域の開始座標である [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) と [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) を出力します。

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

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、[add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) を使用して最初のスライドにテーブルを追加します。列幅、行の高さ、テーブルの位置はポイントで指定します。例では、すべてのセル枠線を [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) に設定し、非表示にします。

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

## **テーブルセルの結合**

[merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) を使用して、テーブルセルの矩形領域を 1 つのセルに結合します。範囲の左上セルと右下セルを指定します。最後の引数は、結合が指定範囲外のセルを含むかどうかを制御し、`False` は結合をその範囲内に留めます。

例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、`(1, 1)` から `(2, 2)` の 4 つの中心セルを結合します。結果として得られるセルは 2 列と 2 行にまたがりますが、テーブルの基礎となるグリッドは 4 列 4 行のままです。結合されたセルの内容や書式設定にアクセスするには、左上の位置 `table.rows[1][1]` を使用します（この例では）。結合範囲内の他の位置はテーブルグリッドの一部として残るため、範囲外のセルのインデックスは変更されません。

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

前の例でセルを結合するとテーブルのグリッドは維持されます。セルを分割すると新しいグリッド列が追加され、右側のセルの列インデックスが変更されることがあります。Aspose.Slides は PowerPoint のテーブルグリッドモデルに従います。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、セル `(1, 1)` に対して [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) を呼び出します。セルの 70 ポイント幅の半分を渡して、幅が等しい 2 つのセルを作成します。

この分割後、2 つの半分は `table.rows[1][1]` と `table.rows[1][2]` でアクセスできます。テーブルグリッドは現在 5 列になり、元々列 2 と列 3 にあったセルはそれぞれ列 3 と列 4 に移動します。行インデックスは変わりません。分割後にセルにアクセスする際は、更新された列インデックスを使用してください。

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

### **行または列のスパンで結合されたセルを分割**

データ入力のために結合されたテンプレートセルを準備するには、既存の行境界に沿って分割するために [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) を使用し、列境界に沿って分割するには [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) を使用します。

`index` 引数は、分割の上部部分の行数または左側部分の列数をカウントし、結合領域を基準とします：

- 行の分割: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/)。
- 列の分割: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/)。

この例では、プレゼンテーションの最初のスライドの最初のシェイプがテーブルであり、`(1, 2)` と `(1, 3)` が垂直に結合されていることを前提としています。下側の位置から開始し、[first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) と [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) を使用して起点を特定し、両方のスパンを確認します。インデックス 1 の `split_by_row_span` を実行すると、製品名用に行 2 と行 3 が分割されます。横方向の 2 列結合の場合は、代わりにインデックス 1 の `split_by_col_span` を使用します。

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

        # 分割後にテーブルから得られるセルを取得します。
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

テーブルグリッドと周囲のセルインデックスは変更されません。結果のセルは座標で取得します。ここでは、両方ともスパンが 1 で、[is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) は `False` を返します。より大きな領域は、1 回の分割後も部分的に結合されたままにできる場合があります。

元のテキストと書式は上部（または左側）のセルに残り、新しいセルは空ですが、塗りつぶし、枠線、余白などのセル書式設定を継承します。分割後にセルにデータを入力し、必要なテキスト書式を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式が保持されたまま、別々の「Product A」セルと「Product B」セルが含まれます。詳細は [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) を参照してください。

## **テーブルセルの背景色の変更**

この例では、列幅 150 ポイント、行高さ 50 ポイントのテーブルを作成します。セル `(2, 3)`（3 列目・4 行目）に対し、[fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) を solid に設定し、[solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) を赤に設定します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルセル内への画像の追加**

この例を実行する前に、入力画像を作業ディレクトリに配置してください。画像は [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) で読み込み、[add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) を使用してプレゼンテーションの画像コレクションに追加します。次に、画像をテーブルの最初のセルである `(0, 0)` のピクチャーフィルに割り当てます。

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) は画像をセル全体に伸ばして表示し、アスペクト比が変わる場合があります。列幅と行高さはポイント単位です。読み込まれた画像は `with` ブロックが終了すると自動的に破棄されます。

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

## **よくある質問**

**単一セルの各辺に対して異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) の枠線は個別のプロパティを持っているため、各辺の太さやスタイルを別々に設定できます。

**セルの背景に画像を設定した後、列または行のサイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)（stretch/​tile）に依存します。ストレッチの場合、画像は新しいセルサイズに合わせて調整され、タイルの場合はタイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/python-net/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（ポーション）レベル、またはテーブル/シェイプ全体のレベルで設定されます。実際には、セル内のテキストの一部または全部にリンクを割り当てます。

**単一セル内でフォントを異なるものに設定できますか？**

はい。セルのテキストフレームは [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)（ラン）をサポートしており、フォントファミリ、スタイル、サイズ、色などを個別に設定できます。