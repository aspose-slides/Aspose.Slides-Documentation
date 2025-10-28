---
title: Pythonでプレゼンテーションテーブルを管理する
linktitle: テーブルを管理
type: docs
weight: 10
url: /ja/python-net/manage-table/
keywords:
- テーブルを追加
- テーブルを作成
- テーブルにアクセス
- アスペクト比
- テキストを揃える
- テキストの書式設定
- テーブルスタイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のスライドでテーブルを作成・編集します。テーブル操作を効率化するシンプルなコード例をご覧ください。"
---

## **概要**

PowerPoint のテーブルは情報を効果的に提示する方法です。セル（行と列）のグリッドに配置された情報は、シンプルで理解しやすいです。

Aspose.Slides は、テーブルを作成、更新、管理するための [テーブル](https://reference.aspose.com/slides/python-net/aspose.slides/table/) クラス、[セル](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) クラス、その他の関連タイプを提供します。

## **テーブルをゼロから作成する**

このセクションでは、スライドにテーブル シェイプを追加し、行と列を定義し、正確なサイズを設定することで、Aspose.Slides でテーブルをゼロから作成する方法を示します。セルにテキストを入れ、配置や罫線を調整し、テーブルの外観をカスタマイズする方法も学びます。

1. Presentation クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 列幅の配列を定義します。
4. 行高さの配列を定義します。
5. スライドに [テーブル](https://reference.aspose.com/slides/python-net/aspose.slides/table/) を追加します。
6. 各 [セル](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) を反復処理し、上、下、右、左の罫線を設定します。
7. テーブルの最初の行の最初の 2 つのセルを結合します。
8. セルの [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。
9. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にテキストを追加します。
10. 変更したプレゼンテーションを保存します。

以下の Python の例は、プレゼンテーションにテーブルを作成する方法を示しています。

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

## **標準テーブルの番号付け**

標準テーブルでは、セルの番号付けはシンプルで 0 から始まります。テーブルの最初のセルは (0, 0)（列 0、行 0）とインデックス付けされます。

たとえば、4 列 4 行のテーブルの場合、セルは次のように番号付けされます。

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下の Python の例は、この 0 ベースの番号付けを使用してセルを参照する方法を示しています。

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **既存のテーブルにアクセスする**

このセクションでは、Aspose.Slides を使用してプレゼンテーション内の既存のテーブルを見つけて操作する方法を説明します。スライド上のテーブルを検索し、行、列、セルにアクセスし、コンテンツや書式を更新する方法を学びます。

1. Presentation クラスのインスタンスを作成します。
2. テーブルが含まれるスライドへのインデックスで参照を取得します。
3. テーブルが見つかるまですべての [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) オブジェクトを反復処理します。
4. [テーブル](https://reference.aspose.com/slides/python-net/aspose.slides/table/) オブジェクトを使用してテーブルを操作します。
5. 変更したプレゼンテーションを保存します。

{{% alert color="info" %}}

スライドに複数のテーブルが含まれている場合は、`alternative_text` プロパティで必要なテーブルを検索する方が良いです。

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

## **テーブル内のテキストを揃える**

このセクションでは、Aspose.Slides を使用してテーブルセル内のテキスト配置を制御する方法を示します。セルの水平・垂直配置を設定し、コンテンツを明確で一貫したものに保つ方法を学びます。

1. Presentation クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [テーブル](https://reference.aspose.com/slides/python-net/aspose.slides/table/) オブジェクトを追加します。
4. テーブルから [セル](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) オブジェクトにアクセスします。
5. テキストを垂直方向に揃えます。
6. 変更したプレゼンテーションを保存します。

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

このセクションでは、Aspose.Slides でテーブルレベルのテキスト書式を適用し、すべてのセルが一貫した統一スタイルを継承する方法を示します。フォントサイズ、配置、余白などをグローバルに設定する方法を学びます。

1. Presentation クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [テーブル](https://reference.aspose.com/slides/python-net/aspose.slides/table/) を追加します。
4. テキストのフォントサイズ（フォント高さ）を設定します。
5. 段落の配置と余白を設定します。
6. テキストの垂直方向の向きを設定します。
7. 変更したプレゼンテーションを保存します。

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

Aspose.Slides を使用すると、コード内で事前定義されたスタイルを利用してテーブルをフォーマットできます。この例では、テーブルを作成し、組み込みスタイルを適用して結果を保存する方法を示します。これにより、一貫したプロフェッショナルな書式設定が効率的に行えます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルのアスペクト比をロックする**

シェイプのアスペクト比は、その寸法の比率です。Aspose.Slides は `aspect_ratio_locked` プロパティを提供し、テーブルやその他のシェイプのアスペクト比をロックできます。

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

## **よくある質問**

**テーブル全体とセル内のテキストの右から左（RTL）読み取り方向を有効にできますか？**

はい。テーブルは [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) プロパティを公開しており、段落には [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/) があります。両方を使用すると、セル内で正しい RTL 順序とレンダリングが保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするには？**

テーブルにも適用できる [shape locks](/slides/ja/python-net/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（伸縮またはタイル）に従ってセル領域を覆います。