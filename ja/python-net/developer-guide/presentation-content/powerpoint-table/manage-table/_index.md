---
title: Pythonでプレゼンテーションテーブルを管理する
linktitle: テーブルを管理
type: docs
weight: 10
url: /ja/python-net/manage-table/
keywords:
- テーブルの追加
- テーブルの作成
- テーブルへのアクセス
- アスペクト比
- テキストの整列
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のスライド内でテーブルを作成・編集します。テーブル操作を簡素化するコード例をご覧ください。"
---

## **概要**

PowerPoint のテーブルは、情報を効率的に提示する方法です。セル（行と列）のグリッドに情報を配置することで、直感的に理解しやすくなります。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) クラス、[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) クラス、その他関連型を提供し、プレゼンテーション内のテーブルの作成、更新、管理を支援します。

## **テーブルの新規作成**

このセクションでは、Aspose.Slides でスライドにテーブルシェイプを追加し、行と列を定義し、正確なサイズを設定してテーブルを作成する方法を示します。また、セルにテキストを入力し、配置や罫線を調整し、テーブルの外観をカスタマイズする方法も説明します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. 列幅の配列を定義します。  
4. 行高さの配列を定義します。  
5. スライドに [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) を追加します。  
6. 各 [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) の上、下、左、右の罫線をフォーマットします。  
7. テーブルの最初の行の最初の 2 つのセルを結合します。  
8. [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) の [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にアクセスします。  
9. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) にテキストを追加します。  
10. 変更したプレゼンテーションを保存します。

以下の Python の例は、プレゼンテーションにテーブルを作成する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation クラスのインスタンスを生成し、プレゼンテーション ファイルを表します。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列幅と行高さを定義します。
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # スライドにテーブルシェイプを追加します。
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # 各セルの罫線フォーマットを設定します。
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
        
    # (0,0) から (1,1) のセルを結合します。
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # 結合したセルにテキストを追加します。
    table.rows[0][0].text_frame.text = "Merged Cells"

    # プレゼンテーションをディスクに保存します。
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **標準テーブルの番号付け**

標準テーブルでは、セルの番号付けはシンプルで 0 ベースです。テーブルの最初のセルは (0, 0)（列 0、行 0）としてインデックス付けされます。

たとえば、4 列 4 行のテーブルの場合、セルの番号は次のようになります。

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

## **既存テーブルへのアクセス**

このセクションでは、Aspose.Slides を使用してプレゼンテーション内の既存テーブルを検索し、操作する方法を説明します。スライド上のテーブルを見つけ、行・列・セルにアクセスし、コンテンツや書式を更新する手順を学びます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでテーブルを含むスライドへの参照を取得します。  
3. すべての [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) オブジェクトを走査し、テーブルを見つけるまで繰り返します。  
4. [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) オブジェクトを使用してテーブルを操作します。  
5. 変更したプレゼンテーションを保存します。

{{% alert color="info" %}}
スライドに複数のテーブルが含まれる場合は、`alternative_text` プロパティで目的のテーブルを検索する方が便利です。
{{% /alert %}}

以下の Python の例は、既存テーブルにアクセスして操作する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation クラスのインスタンスを作成し、PPTX ファイルをロードします。
with slides.Presentation("sample.pptx") as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    table = None

    # シェイプを走査し、最初に見つかったテーブルを取得します。
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # 最初の行・最初のセルのテキストを設定します。
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # 変更したプレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブル内のテキスト整列**

このセクションでは、Aspose.Slides を使ってテーブルセル内のテキスト整列を制御する方法を示します。セルの水平・垂直整列を設定し、コンテンツを見やすく一貫性のあるレイアウトにします。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. スライドに [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) オブジェクトを追加します。  
4. テーブルから [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) オブジェクトを取得します。  
5. テキストを垂直方向に整列させます。  
6. 変更したプレゼンテーションを保存します。

以下の Python の例は、テーブル内のテキストを整列させる方法を示しています。

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

    # スライドにテーブルシェイプを追加します。
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # テキストを中央揃えにし、垂直方向の配置を設定します。
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # プレゼンテーションをディスクに保存します。
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルレベルでのテキスト書式設定**

このセクションでは、Aspose.Slides でテーブルレベルのテキスト書式設定を適用し、すべてのセルが統一されたスタイルを継承する方法を示します。フォントサイズ、配置、余白、垂直方向のテキスト向きをグローバルに設定します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. スライドに [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) を追加します。  
4. テキストのフォントサイズ（フォント高さ）を設定します。  
5. 段落の配置と余白を設定します。  
6. 垂直テキスト向きを設定します。  
7. 変更したプレゼンテーションを保存します。

以下の Python の例は、テーブル内のテキストに好みの書式オプションを適用する方法を示しています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # すべてのテーブルセルのフォントサイズを設定します。
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # すべてのテーブルセルの右揃えテキストと右余白を設定します。
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # すべてのテーブルセルの垂直テキスト向きを設定します。
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **組み込みテーブルスタイルの適用**

Aspose.Slides では、コード内で事前定義されたスタイルを使用してテーブルをフォーマットできます。以下の例は、テーブルを作成し、組み込みスタイルを適用して保存する手順を示しており、統一感のあるプロフェッショナルな書式設定を簡単に実現できます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルのアスペクト比ロック**

シェイプのアスペクト比は、幅と高さの比率です。Aspose.Slides は `aspect_ratio_locked` プロパティを提供し、テーブルやその他のシェイプのアスペクト比をロックできます。

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

**テーブル全体とセル内テキストの右から左 (RTL) 読み取り方向を有効にできますか？**

はい。テーブルは [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) プロパティを公開しており、段落は [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/) を持ちます。両方を使用することで、セル内の正しい RTL 順序とレンダリングが保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするには？**

[shape locks](/slides/ja/python-net/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（ストレッチまたはタイル）に従ってセル領域全体を覆います。