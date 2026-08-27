---
title: Python でプレゼンテーションのテーブルを管理
linktitle: テーブルの管理
type: docs
weight: 10
url: /ja/python-net/manage-table/
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
description: ".NET を通じて Python 用 Aspose.Slides で PowerPoint および OpenDocument スライドのテーブルを作成および編集します。テーブル操作を効率化するシンプルなコード例を紹介します。"
---
## **概要**

PowerPoint の表は情報を提示する効率的な方法です。セル（行と列）のグリッドに配置された情報は、単純で理解しやすいです。

Aspose.Slides は [テーブル](https://reference.aspose.com/slides/ja/python-net/aspose.slides/table/) クラス、[セル](https://reference.aspose.com/slides/ja/python-net/aspose.slides/cell/) クラス、およびその他の関連型を提供し、プレゼンテーション内の表の作成、更新、管理を支援します。

## **テーブルをゼロから作成**

このセクションでは、スライドにテーブルシェイプを追加し、行と列を定義し、正確なサイズを設定することで、Aspose.Slides でテーブルをゼロから作成する方法を示します。セルにテキストを入力し、配置や罫線を調整し、表の外観をカスタマイズする方法も確認できます。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. 列幅の配列を定義します。  
4. 行高さの配列を定義します。  
5. スライドに [テーブル](https://reference.aspose.com/slides/ja/python-net/aspose.slides/table/) を追加します。  
6. 各 [セル](https://reference.aspose.com/slides/ja/python-net/aspose.slides/cell/) を反復処理し、上、下、右、左の罫線を書式設定します。  
7. 最初の 2 行と最初の 2 列のセルを 1 つのセルに結合します。  
8. [セル](https://reference.aspose.com/slides/ja/python-net/aspose.slides/cell/) の [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にアクセスします。  
9. [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) にテキストを追加します。  
10. 変更したプレゼンテーションを保存します。

次の Python の例は、プレゼンテーションにテーブルを作成する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列幅と行高さを定義します。
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # スライドにテーブル シェイプを追加します。
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # 各セルの罫線書式を設定します。
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
        
    # (行 0, 列 0) から (行 1, 列 1) までのセルを結合します。
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # 結合したセルにテキストを追加します。
    table.rows[0][0].text_frame.text = "Merged Cells"

    # プレゼンテーションをディスクに保存します。
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **標準テーブルの番号付け**

標準テーブルでは、セルの番号付けはシンプルでゼロベースです。テーブルの最初のセルは (0, 0)（列 0、行 0）としてインデックス付けされます。

たとえば、4 列 4 行のテーブルでは、セルは次のように番号付けされます。

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

次の Python の例は、このゼロベースの番号付けを使用してセルを参照する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 4 列 4 行のテーブルを追加します。
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **既存のテーブルにアクセス**

このセクションでは、Aspose.Slides を使用してプレゼンテーション内の既存テーブルを検索し操作する方法を説明します。スライド上のテーブルを見つけ、行・列・セルにアクセスし、内容や書式を更新する方法を学びます。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでテーブルを含むスライドへの参照を取得します。  
3. すべての [Shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/) オブジェクトを走査してテーブルを見つけます。  
4. [テーブル](https://reference.aspose.com/slides/ja/python-net/aspose.slides/table/) オブジェクトを使用してテーブルを操作します。  
5. 変更したプレゼンテーションを保存します。

{{% alert color="info" title="注" %}}
スライドに複数のテーブルが含まれる場合は、`alternative_text` プロパティで目的のテーブルを検索した方が便利です。
{{% /alert %}}

次の Python の例は、既存のテーブルにアクセスして操作する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTX ファイルを読み込むために Presentation クラスのインスタンスを作成します。
with slides.Presentation("sample.pptx") as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    table = None

    # シェイプを走査し、最初に見つかったテーブルを参照します。
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # 最初の行の最初のセルのテキストを設定します。
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # 変更したプレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **テキストフレームを所有するセルを検索**

テーブルから取得した [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) を汎用テキスト処理コードで扱う際は、[TextFrame.parent_cell](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/parent_cell/) プロパティを使用して所有する [セル](https://reference.aspose.com/slides/ja/python-net/aspose.slides/cell/) を取得します。テーブルセルのテキストフレームでは、`TextFrame.parent_cell` が設定され、`TextFrame.parent_shape` は `None` です（テーブル自体はシェイプです）。

セルの座標は読み取り専用の [Cell.first_column_index](https://reference.aspose.com/slides/ja/python-net/aspose.slides/cell/first_column_index/) および [Cell.first_row_index](https://reference.aspose.com/slides/ja/python-net/aspose.slides/cell/first_row_index/) プロパティで取得できます。`TextFrame.parent_cell` も読み取り専用で、所有者へのナビゲーションを提供しますが所有権は変更されません。使用前に取得したセルが `None` でないことを必ず確認してください。

テーブルセルとシェイプの所有者を特定する完全な例（SmartArt ノードに関連付けられたシェイプを含む）については、[Search and Replace Text](/slides/ja/python-net/search-and-replace-text/) を参照してください。

## **テーブル内のテキストの配置**

このセクションでは、Aspose.Slides を使用してテーブルセル内のテキスト配置を制御する方法を示します。セル内のテキストを垂直方向にセンタリングし、テキストの流れる方向を変更する方法を学びます。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. スライドに [テーブル](https://reference.aspose.com/slides/ja/python-net/aspose.slides/table/) オブジェクトを追加します。  
4. テーブルから [セル](https://reference.aspose.com/slides/ja/python-net/aspose.slides/cell/) オブジェクトを取得します。  
5. セル内のテキストを垂直方向にセンタリングし、テキスト方向を設定します。  
6. 変更したプレゼンテーションを保存します。

次の Python の例は、テーブル内のテキストを整列させる方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

    # Presentation クラスのインスタンスを作成します。
    with slides.Presentation() as presentation:
        # 最初のスライドにアクセスします。
        slide = presentation.slides[0]

        # 列幅と行高さを定義します。
        column_widths = [40, 120, 120, 120]
        row_heights = [100, 100, 100, 100]

        # スライドにテーブル シェイプを追加します。
        table = slide.shapes.add_table(100, 50, column_widths, row_heights)
        table.rows[0][0].text_frame.text = "Numbers"
        table.rows[1][0].text_frame.text = "10"
        table.rows[2][0].text_frame.text = "20"
        table.rows[3][0].text_frame.text = "30"

        # テキストを中央揃えにし、垂直方向を設定します。
        cell = table.rows[0][0]
        cell.text_anchor_type = slides.TextAnchorType.CENTER
        cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

        # プレゼンテーションをディスクに保存します。
        presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルレベルでテキスト書式設定**

このセクションでは、Aspose.Slides でテーブルレベルのテキスト書式設定を適用し、すべてのセルが一貫した統一スタイルを継承できるようにする方法を示します。フォントサイズ、配置、余白をグローバルに設定する方法を学びます。

1. [プレゼンテーション](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. スライドに [テーブル](https://reference.aspose.com/slides/ja/python-net/aspose.slides/table/) を追加します。  
4. テキストのフォントサイズ（フォント高さ）を設定します。  
5. 段落の配置と余白を設定します。  
6. 垂直テキストの方向を設定します。  
7. 変更したプレゼンテーションを保存します。

次の Python の例は、テーブル内のテキストに希望の書式オプションを適用する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # すべてのテーブルセルのフォントサイズを設定します。
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # すべてのテーブルセルのテキストを右揃えにし、右余白を設定します。
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # すべてのテーブルセルの垂直テキスト方向を設定します。
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **組み込みテーブルスタイルの適用**

Aspose.Slides では、コード内で事前定義されたスタイルを使用してテーブルをフォーマットできます。この例では、テーブルを作成し、組み込みスタイルを適用し、結果を保存します。これにより、一貫したプロフェッショナルな書式設定が効率的に実現できます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルのアスペクト比をロック**

シェイプのアスペクト比は、幅と高さの比率です。Aspose.Slides は `aspect_ratio_locked` プロパティを提供し、テーブルやその他のシェイプのアスペクト比をロックできます。

次の Python の例は、テーブルのアスペクト比をロックする方法を示しています。

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

**テーブル全体とセル内テキストの右から左 (RTL) 読み方向を有効にできますか？**

はい。テーブルは [right_to_left](https://reference.aspose.com/slides/ja/python-net/aspose.slides/table/right_to_left/) プロパティを公開しており、段落は [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/ja/python-net/aspose.slides/paragraphformat/right_to_left/) を持ちます。両方を使用することで、セル内の正しい RTL 順序と描画が保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするにはどうすればよいですか？**

[shape locks](/slides/ja/python-net/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに [picture fill](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（伸張またはタイル）に従ってセル領域を覆います。