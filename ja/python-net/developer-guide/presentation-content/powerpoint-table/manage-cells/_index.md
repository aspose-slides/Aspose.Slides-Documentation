---
title: Python でプレゼンテーションのテーブルセルを管理する
linktitle: セルの管理
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
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のテーブルセルを簡単に管理できます。セルへのアクセス、変更、スタイリングを素早く習得し、スライドの自動化をシームレスに実現します。"
---

## **概要**

本記事では、Aspose.Slides を使用してプレゼンテーション内のテーブルセルを操作する方法を示します。結合セルの検出方法、セルの枠線のクリアまたはカスタマイズ手順、そして PowerPoint が結合・分割操作後にセルに付与する番号付けの仕組みを解説し、複雑なレイアウトでのインデックス予測を可能にします。また、セルの背景塗りの変更や、画像を直接セルに埋め込むピクチャー塗り設定の方法も紹介します。各シナリオには、テーブルの作成・編集・保存を行う簡潔な Python サンプルが添付されているので、すぐに自分のスライドに応用できます。

## **結合されたテーブルセルの識別**

テーブルでは、ヘッダーや関連データのグループ化のためにセルを結合することがよくあります。このセクションでは、特定のセルが結合領域に属しているかどうかを判定し、マスタ（左上）セルを取得してブロック全体を一貫して読み取り・書式設定する方法を説明します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. 最初のスライドからテーブルを取得します。  
3. テーブルの行と列を走査して結合セルを探します。  
4. 結合セルが見つかったらメッセージを出力します。  

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

## **テーブルセルの枠線を削除する**

テーブルの枠線がコンテンツの視認性を妨げたり、ビジュアルがごちゃごちゃになることがあります。このセクションでは、選択したセルまたはセルの特定側の枠線を削除して、レイアウトをすっきりさせ、スライドのデザインに合わせる方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドを取得します。  
3. 列幅の配列を定義します。  
4. 行高さの配列を定義します。  
5. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドでスライドにテーブルを追加します。  
6. 各セルの上・下・左・右枠線をクリアします。  
7. 変更後のプレゼンテーションを PPTX ファイルとして保存します。  

以下の Python コードは、テーブルセルの枠線を削除する方法を示します。

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

たとえば (1, 1) と (2, 1) および (1, 2) と (2, 2) の 2 ペアのセルを結合すると、結合後のテーブルは結合前と同じセル番号体系を保ちます。以下の Python コードはこの動作を示します。

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

前の例ではセルを結合しても他のセルの番号は変わりませんでした。ここでは結合セルのない通常テーブルを作成し、セル (1, 1) を分割して特殊なテーブルを生成します。テーブルの番号付けに注意してください—見た目が変則的に見えるかもしれませんが、これは Microsoft PowerPoint のセル番号付け方式であり、Aspose.Slides も同様に動作します。

以下の Python コードはこの動作を示します。

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

## **テーブルセルの背景色を変更する**

以下の Python 例は、テーブルセルの背景色を変更する方法を示します。

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

## **テーブルセルに画像を挿入する**

このセクションでは、Aspose.Slides でテーブルセルに画像を挿入する手順を説明します。対象セルにピクチャー塗りを適用し、ストレッチやタイルなどの表示オプションを設定します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドを取得します。  
3. 列幅の配列を定義します。  
4. 行高さの配列を定義します。  
5. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドでスライドにテーブルを追加します。  
6. 画像をファイルから読み込みます。  
7. 画像をプレゼンテーションのイメージコレクションに追加して [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を取得します。  
8. テーブルセルの [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `PICTURE` に設定します。  
9. 画像をセルに適用し、塗りモード（例: `STRETCH`）を選択します。  
10. プレゼンテーションを PPTX ファイルとして保存します。  

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

**単一セルの各辺に異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) の枠線は個別のプロパティを持ち、各辺の太さやスタイルを別々に設定できます。

**セルの背景にピクチャーを設定した後で列・行サイズを変更した場合、画像はどうなりますか？**

挙動は [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)（stretch / tile）に依存します。ストレッチの場合は画像が新しいセルサイズに合わせて拡大縮小され、タイルの場合はタイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを割り当てられますか？**

[Hyperlinks](/slides/ja/python-net/manage-hyperlinks/) はセル内のテキストフレーム（portion）単位、またはテーブル/シェイプ全体レベルで設定します。実務では、セル内のテキスト全体または特定の portion にリンクを付与します。

**単一セル内でフォントを複数設定できますか？**

はい。セルのテキストフレームは [portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)（ラン）をサポートしており、フォントファミリ、スタイル、サイズ、色などを個別に設定できます。