---
title: "Pythonでプレゼンテーションテーブルを管理"
linktitle: "テーブル管理"
type: docs
weight: 10
url: /ja/python-net/manage-table/
keywords:
- テーブル追加
- テーブル作成
- テーブルアクセス
- アスペクト比
- テキスト整列
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python (.NET 経由) を使用して、PowerPoint および OpenDocument のスライドでテーブルの作成と編集を行います。テーブル操作を効率化するシンプルなコード例をご紹介します。"
---
## **はじめに**

PowerPoint のテーブルは情報を行と列に整理し、値の読み取りや比較を容易にします。

Aspose.Slides は [テーブル](https://reference.aspose.com/slides/python-net/aspose.slides/table/) と [セル](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) クラスやその他の型を提供し、プレゼンテーション内のテーブルの作成、更新、管理が可能です。

## **スクラッチからテーブルを作成する**

位置、列幅、行高さを指定してテーブルを作成します。スライドに追加した後、セルの罫線を書式設定したり、セルを結合したり、テキストを挿入したりできます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 列幅のリスト（ポイント単位）を定義します。
4. 行高さのリスト（ポイント単位）を定義します。
5. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドでスライドに [テーブル](https://reference.aspose.com/slides/python-net/aspose.slides/table/) オブジェクトを追加します。
6. 各 [セル](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) を走査して、上・下・右・左の罫線に書式を適用します。
7. テーブルの最初の行の最初の 2 つのセルを結合します。
8. 結合されたセルはその [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) プロパティで取得します。
9. 結合セルにテキストを設定します。
10. 変更したプレゼンテーションを保存します。

以下の例は、(100, 50) ポイントに 3 列 5 行のテーブルを作成し、幅 5 ポイントの赤い罫線を適用し、最初の行の最初の 2 つのセルを結合して、結果を `table.pptx` として保存します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **標準テーブルのインデックス付け**

標準テーブルでは、セルのインデックスはゼロベースで (列, 行) の順序です。最初のセルは (0, 0) とインデックス付けされます。Python では `table.rows[row_index][column_index]` のようにセルにアクセスします。ここで行インデックスが先に来ます。

たとえば、4 列 4 行のテーブルのセルは次のように番号付けされます。

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この例は上記の 4 × 4 テーブルを作成し、列幅と行高さを 70 ポイント、罫線を幅 5 ポイントの赤に設定します。座標はセルインデックスを示しています。セルは空のままで、テーブルは `StandardTables_out.pptx` として保存されます。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **既存のテーブルにアクセスする**

テーブルはスライドのシェイプコレクションに格納されています。シェイプを走査してテーブルを見つけ、[テーブル](https://reference.aspose.com/slides/python-net/aspose.slides/table/) クラスでセルを読み書きします。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスでプレゼンテーションをロードします。
2. インデックスでテーブルを含むスライドへの参照を取得します。
3. [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) オブジェクトを走査し、テーブルが見つかったら停止します。スライドに複数のテーブルがある場合は、[alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) を使用して目的のテーブルを特定します。
4. 対象セルのテキストを更新します。
5. 変更したプレゼンテーションを保存します。

以下の例は `UpdateExistingTable.pptx` を開き、最初のスライドの最初のテーブルを見つけます。列 0、行 1 のセルに `New` を設定し、結果を `table1_out.pptx` として保存します。入力には少なくとも 1 枚のスライドが必要で、該当スライドの最初のテーブルは少なくとも 1 列 2 行を持つ必要があります。

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

既存テーブルの行のサイズを変更し、実際の高さが要求された最小高さを超える理由を理解するには、[行の高さの制御](/slides/ja/python-net/manage-rows-and-columns/#control-row-height) を参照してください。

## **テキストフレームを所有するセルを検索する**

汎用テキスト処理コードがテーブルから取得した [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) に対しては、所有する [セル](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) を取得するために [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) プロパティを使用します。テーブルセルのテキストフレームの場合、[TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) は設定され、[TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) は `None` になります（テーブル自体はシェイプです）。

セルの座標は読み取り専用の [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) および [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) プロパティで取得できます。[TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) も読み取り専用で、所有者へのナビゲーションを提供しますが所有権は変更されません。使用する前に `None` でないことを必ず確認してください。

テーブルセルとシェイプの所有者を特定する完全な例（SmartArt ノードに関連付けられたシェイプを含む）については、[テキストの検索と置換](/slides/ja/python-net/search-and-replace-text/) を参照してください。

## **テーブル内のテキストを揃える**

個々のテーブルセルの垂直アンカーとテキスト方向を制御できます。このセクションの例では、最初のセルのテキストを中央揃えにし、270 度回転させます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [テーブル](https://reference.aspose.com/slides/python-net/aspose.slides/table/) オブジェクトを追加します。
4. テーブルから [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) オブジェクトを取得します。
5. 最初の [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) にアクセスし、テキストと色を設定します。
6. セルの [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) と [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) を設定します。
7. 変更したプレゼンテーションを保存します。

この例は列幅 120 ポイント、行高さ 100 ポイントの 4 × 4 テーブルを作成し、セル (0, 0) のテキストを書式設定し、最初の行の残りのセルに値を追加して、結果を `Vertical_Align_Text_out.pptx` として保存します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルレベルでテキスト書式を設定する**

[set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) を使用して、テーブル内のすべてのセルにテキスト書式を適用できます。オーバーロードは部分、段落、テキストフレームの書式設定を受け入れるため、個々のセルを走査せずにこれらのプロパティを設定できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスでプレゼンテーションをロードします。
2. インデックスでスライドへの参照を取得します。
3. スライドから [テーブル](https://reference.aspose.com/slides/python-net/aspose.slides/table/) オブジェクトを取得します。
4. テキストの [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) を設定します。
5. [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) と [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) を設定します。
6. [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) を設定します。
7. 変更したプレゼンテーションを保存します。

以下の例は `table.pptx` を開きます（少なくとも 1 枚のスライドにテーブルが最初のシェイプとして存在する必要があります）。フォントサイズを 25 ポイント、段落を右揃えにして右マージンを 20 ポイント、テキストを垂直に設定し、結果を `result.pptx` として保存します。

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルのスタイルプロパティを取得する**

[style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) を使用してテーブルのプリセットスタイルを読み取ったり割り当てたりできます。この例は [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) を 1 つのテーブルに適用し、プリセット名を出力し、同じプリセットを 2 番目のテーブルに割り当てます。両方のテーブルは `table-style.pptx` に保存されます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルのアスペクト比をロックする**

テーブルのアスペクト比は幅と高さの比率です。[aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) を使用してこの比率をロックできます。

以下の例は `pres.pptx` を開きます（少なくとも 1 枚のスライドにテーブルが最初のシェイプとして存在する必要があります）。現在のロック状態を出力し、アスペクト比ロックを有効にして更新後の状態（`True`）を出力し、結果を `pres-out.pptx` として保存します。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**テーブル全体とセル内テキストの右から左 (RTL) 読み取り方向を有効にできますか？**

はい。テーブルは [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) プロパティを公開しており、段落は [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/) を持ちます。両方を使用することで、セル内の正しい RTL 順序と描画が保証されます。

**最終ファイルでテーブルの移動やサイズ変更をユーザーができないようにするには？**

[シェイプレック](/slides/ja/python-net/applying-protection-to-presentation/) を使用して移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（ストレッチまたはタイル）に従ってセル領域を覆います。