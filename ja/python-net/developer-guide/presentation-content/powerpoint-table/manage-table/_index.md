---
title: Pythonでプレゼンテーションテーブルを管理する
linktitle: テーブルの管理
type: docs
weight: 10
url: /ja/python-net/developer-guide/presentation-content/powerpoint-table/manage-table/
keywords:
- テーブルを追加
- テーブルを作成
- テーブルにアクセス
- アスペクト比
- テキストの配置
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "PowerPoint と OpenDocument スライドでテーブルを作成・編集するための Aspose.Slides for Python via .NET。テーブル操作を効率化するシンプルなコード例をご紹介します。"
---

## **概要**

PowerPoint のテーブルは情報を効果的に提示する方法です。セル（行と列）のグリッドに配置された情報はシンプルで理解しやすいです。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) クラス、[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) クラス、その他の関連型を提供し、任意のプレゼンテーションでテーブルの作成、更新、管理を支援します。

## **テーブルをゼロから作成する**

このセクションでは、Aspose.Slides でテーブル形状をスライドに追加し、行と列を定義し、正確なサイズを設定して、テーブルをゼロから作成する方法を示します。セルにテキストを入力し、配置や罫線を調整し、テーブルの外観をカスタマイズする方法も紹介します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 列幅の配列を定義します。
4. 行高さの配列を定義します。
5. スライドに [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) を追加します。
6. 各 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) をループし、上・下・左・右の罫線を設定します。
7. テーブルの最初の行の最初の 2 つのセルを結合します。
8. [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) の [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。
9. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にテキストを追加します。
10. 変更したプレゼンテーションを保存します。

以下の Python の例は、プレゼンテーション内にテーブルを作成する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Set the border format for each cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Merge cells from (row 0, col 0) to (row 1, col 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Add text to the merged cell.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Save the presentation to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **標準テーブルにおける番号付け**

標準テーブルでは、セルの番号付けはシンプルで 0 ベースです。テーブルの最初のセルは (0, 0)（列 0、行 0）としてインデックス付けされます。

たとえば、4 列 4 行のテーブルでは、セルは次のように番号付けされます。

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下の Python の例は、0 ベースの番号付けを使用してセルを参照する方法を示しています。

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **既存のテーブルにアクセスする**

このセクションでは、Aspose.Slides を使用してプレゼンテーション内の既存テーブルを検索し、操作する方法を説明します。スライド上のテーブルを見つけ、行・列・セルにアクセスし、コンテンツや書式を更新する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. テーブルが含まれるスライドへの参照をインデックスで取得します。
3. すべての [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) オブジェクトを走査し、テーブルが見つかるまで繰り返します。
4. [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) オブジェクトを使用してテーブルを操作します。
5. 変更したプレゼンテーションを保存します。

{{% alert color="info" %}}
スライドに複数のテーブルがある場合は、必要なテーブルを `alternative_text` プロパティで検索する方が便利です。
{{% /alert %}}

以下の Python の例は、既存のテーブルにアクセスして操作する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class to load a PPTX file.
with slides.Presentation("sample.pptx") as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    table = None

    # Iterate through shapes and reference the first table found.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Set the text of the first cell in the first row.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Save the modified presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブル内のテキストを配置する**

このセクションでは、Aspose.Slides を使用してテーブルセル内のテキスト配置を制御する方法を示します。セルの横方向・縦方向の配置を設定し、コンテンツを明確かつ一貫して表示できるようにします。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) オブジェクトを追加します。
4. テーブルから [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) オブジェクトにアクセスします。
5. テキストを縦方向に配置します。
6. 変更したプレゼンテーションを保存します。

以下の Python の例は、テーブル内のテキストを配置する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Center the text and set vertical orientation.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Save the presentation to disk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルレベルでテキスト書式を設定する**

このセクションでは、Aspose.Slides でテーブルレベルのテキスト書式を適用し、すべてのセルが統一されたスタイルを継承できるようにします。フォントサイズ、配置、余白、縦書き設定をグローバルに設定する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) を追加します。
4. テキストのフォントサイズ（フォント高さ）を設定します。
5. 段落の配置と余白を設定します。
6. 縦方向のテキスト配置を設定します。
7. 変更したプレゼンテーションを保存します。

以下の Python の例は、テーブル内テキストに好みの書式オプションを適用する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Set the font size for all table cells.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Set right-aligned text and a right margin for all table cells.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Set the vertical text orientation for all table cells.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **組み込みテーブルスタイルを適用する**

Aspose.Slides では、コード内で定義された組み込みスタイルを使用してテーブルを書式設定できます。以下の例は、テーブルを作成し、組み込みスタイルを適用して保存する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルのアスペクト比をロックする**

シェイプのアスペクト比とは、その寸法の比率のことです。Aspose.Slides は `aspect_ratio_locked` プロパティを提供し、テーブルやその他のシェイプのアスペクト比をロックできます。

以下の Python の例は、テーブルのアスペクト比をロックする方法を示しています。

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**テーブル全体およびセル内のテキストに右から左 (RTL) 読み方向を有効にできますか？**

はい。テーブルは [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) プロパティを公開しており、段落は [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/) を持ちます。両方を使用すると、セル内で正しい RTL 順序とレンダリングが保証されます。

**最終ファイルでテーブルの移動やサイズ変更をユーザーに禁止するにはどうすればよいですか？**

[shape locks](/slides/ja/python-net/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（伸縮またはタイル）に従ってセル領域を覆います。