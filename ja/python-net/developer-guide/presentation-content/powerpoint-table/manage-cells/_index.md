---
title: Python でプレゼンテーションのテーブルセルを管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/python-net/manage-cells/
keywords:
- テーブルセル
- セル結合
- 境界線の削除
- セル分割
- セル内画像
- 背景色
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: ".NET 経由で Python 用 Aspose.Slides を使用して、PowerPoint と OpenDocument のテーブルセルを手軽に管理します。セルへのアクセス、変更、スタイリングを迅速に習得し、スライドの自動化をシームレスに実現します。"
---

## **概要**

本記事では Aspose.Slides を使用してプレゼンテーションのテーブルセルを操作する方法を示します。結合セルの検出方法、セル境界線のクリアやカスタマイズ方法、結合や分割操作後の PowerPoint のセル番号付けの仕組みを理解して、複雑なレイアウトでのインデックス予測が可能になります。また、セルの背景塗りの変更や、画像をテーブルセル内に直接配置するピクチャーフィル設定の方法も紹介します。各シナリオには簡潔な Python サンプルが添えてあり、テーブルの作成・編集から更新されたプレゼンテーションの保存までをすぐに自分のスライドに応用できます。

## **結合されたテーブルセルの識別**

ヘッダーや関連データのグループ化のために、テーブルはしばしば結合セルを含みます。このセクションでは、特定のセルが結合領域に属しているかを判断し、マスタ（左上）セルを参照してブロック全体を一貫して読み取ったり書式設定したりする方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. 最初のスライドからテーブルを取得します。  
1. テーブルの行と列を走査して結合セルを探します。  
1. 結合セルが見つかったらメッセージを出力します。

以下の Python コードは、プレゼンテーション内の結合テーブルセルを識別します。

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Assuming the first shape on the first slide is a table.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **テーブルセルの境界線の削除**

テーブルの境界線がコンテンツの視認性を妨げたり、視覚的にごちゃごちゃした印象を与えることがあります。このセクションでは、選択したセルやセルの特定の側面の境界線を削除し、スライドのデザインに合わせてすっきりとしたレイアウトを実現する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドを取得します。  
1. 列幅の配列を定義します。  
1. 行高さの配列を定義します。  
1. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドでスライドにテーブルを追加します。  
1. 各セルを走査して上・下・左・右の境界線をクリアします。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、テーブルセルの境界線を削除する方法を示します。

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Clear the border fill for each cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Save the PPTX file to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **結合セルにおける番号付け**

例えば (1, 1) x (2, 1) と (1, 2) x (2, 2) の 2 組のセルを結合した場合、結合後のテーブルは結合前と同じセル番号体系を保持します。以下の Python コードでこの挙動を確認できます。

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Merge cells (1,1) and (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Merge cells (1, 2) and (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Print the cell indices.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Save the PPTX file to disk.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

出力:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **分割セルにおける番号付け**

前の例ではセルを結合しても他のセルの番号は変わりませんでした。今回は結合のない通常のテーブルを作成し、セル (1, 1) を分割して特殊なテーブルを作ります。このテーブルの番号付けは一見変則的に見えますが、Microsoft PowerPoint のセル番号付けロジックであり、Aspose.Slides も同様に動作します。

以下の Python コードでこの挙動を確認できます。

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Split cell (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Print the cell indices.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Save the PPTX file to disk.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

出力:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **テーブルセルの背景色の変更**

以下の Python サンプルは、テーブルセルの背景色を変更する方法を示します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Create a new table.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Set the background color for a cell.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルセルへの画像挿入**

このセクションでは、Aspose.Slides でテーブルセルに画像を挿入する方法を示します。対象セルにピクチャーフィルを適用し、ストレッチやタイルなどの表示オプションを設定します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライド参照を取得します。  
1. 列幅の配列を定義します。  
1. 行高さの配列を定義します。  
1. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドでスライドにテーブルを追加します。  
1. ファイルから画像を読み込みます。  
1. 画像をプレゼンテーションの画像コレクションに追加して [PPImage] を取得します。  
1. テーブルセルの [FillType] を `PICTURE` に設定します。  
1. 画像をセルに適用し、フィルモード（例: `STRETCH`）を選択します。  
1. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、テーブル作成時に画像をセル内に配置する方法を示します。

```python
import aspose.slides as slides

# Instantiate a Presentation object.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Load the image and add it to the presentation to obtain a PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Apply the image to the first table cell.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Save the presentation to disk.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**1\. 1 つのセルの各側面に対して、異なる線の太さやスタイルを設定できますか？**

はい。セルの [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) 境界線はそれぞれ個別のプロパティを持つため、各側面の太さやスタイルを別々に設定できます。

**2\. 画像をセルの背景として設定した後に、列や行のサイズを変更すると画像はどうなりますか？**

動作は設定した [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)（stretch／tile）によります。stretch を使用するとセルサイズ変更に合わせて画像が伸縮し、tile を使用するとタイルの数や位置が再計算されます。

**3\. セル内のすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/python-net/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（portion）レベル、またはテーブル／シェイプ全体のレベルで設定できます。実際には、セル内のすべてのテキストに対してリンクを設定するか、テキストフレーム全体に対してリンクを設定します。

**4\. 1 つのセル内で異なるフォントを使用できますか？**

はい。セルのテキストフレームは [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)（ラン）をサポートしており、フォントファミリ、スタイル、サイズ、色などを部分ごとに個別に設定できます。