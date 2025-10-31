---
title: Python を使用したプレゼンテーションの表セル管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/python-net/manage-cells/
keywords:
- 表セル
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument の表セルを手軽に管理します。セルへのアクセス、変更、スタイリングを素早く習得し、スライド自動化をシームレスに実現します。"
---

## **概要**

この記事では、Aspose.Slides を利用してプレゼンテーション内の表セルを操作する方法を示します。結合セルの検出、セル境界線のクリアまたはカスタマイズ、結合および分割操作後の PowerPoint のセル番号付けの仕組みを理解して、複雑なレイアウトでのインデックス予測が可能になります。また、セルの背景塗りの変更や画像を直接セル内に配置するピクチャーフィル設定など、一般的な書式設定タスクも紹介します。各シナリオには、表を作成または編集し、更新したプレゼンテーションを保存する簡潔な Python サンプルが添付されているため、スニペットをすぐに自分のスライドに適用できます。

## **結合表セルの識別**

ヘッダーや関連データのグループ化のために、表では結合セルが頻繁に使用されます。このセクションでは、特定のセルが結合領域に属しているかを判断し、マスタ―（左上）セルを参照してブロック全体を一貫して読み取ったり書式設定したりする方法を紹介します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドから表を取得します。
3. 表の行と列を走査して結合セルを検出します。
4. 結合セルが見つかったらメッセージを出力します。

以下の Python コードは、プレゼンテーション内の結合表セルを識別します。

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # 最初のスライド上の最初のシェイプが表であると想定しています。
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **表セル境界線の削除**

表の境界線がコンテンツの妨げになったり、視覚的な雑音を生むことがあります。このセクションでは、選択したセルまたはセルの特定側の境界線を削除して、レイアウトをすっきりさせ、スライドのデザインに合わせる方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドを取得します。
3. 列幅の配列を定義します。
4. 行高さの配列を定義します。
5. [add_table](httpshttps://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドを使用してスライドに表を追加します。
6. 各セルの上・下・左・右境界線をクリアします。
7. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、表セルの境界線を削除する方法を示します。

```python
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列幅と行高さを定義します。
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # スライドに表シェイプを追加します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 各セルの境界線の塗りをクリアします。
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # PPTX ファイルをディスクに保存します。
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **結合セルにおける番号付け**

たとえば (1,1)×(2,1) と (1,2)×(2,2) の 2 ペアのセルを結合すると、結果の表は結合前と同じセル番号付けを保持します。以下の Python コードはこの動作を示します。

```python
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列幅と行高さを定義します。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # スライドに表シェイプを追加します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # セル (1,1) と (2,1) を結合します。
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # セル (1,2) と (2,2) を結合します。
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # セルのインデックスを出力します。
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # PPTX ファイルをディスクに保存します。
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

前述の例では、セルを結合しても他のセルの番号は変わりませんでした。ここでは、結合セルの無い通常の表を作成し、セル (1,1) を分割して特別な表を生成します。この表の番号付けに注意してください。見た目は変わっているように見えますが、これは Microsoft PowerPoint のセル番号付け方式であり、Aspose.Slides も同様に振る舞います。

以下の Python コードはこの動作を示します。

```python
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列幅と行高さを定義します。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # スライドに表シェイプを追加します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # セル (1,1) を幅で分割します。
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # セルのインデックスを出力します。
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # PPTX ファイルをディスクに保存します。
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

出力:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **表セルの背景色変更**

以下の Python サンプルは、表セルの背景色を変更する方法を示します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # 新しい表を作成します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # セルの背景色を設定します。
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **表セルへの画像挿入**

このセクションでは、Aspose.Slides で表セルに画像を挿入する方法を示します。対象セルにピクチャーフィルを適用し、ストレッチやタイルなどの表示オプションを設定します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライド参照を取得します。
3. 列幅の配列を定義します。
4. 行高さの配列を定義します。
5. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドでスライドに表を追加します。
6. ファイルから画像を読み込みます。
7. 画像をプレゼンテーションの画像コレクションに追加し、[PPImage] を取得します。
8. 表セルの [FillType] を `PICTURE` に設定します。
9. 画像をセルに適用し、フィルモード（例:`STRETCH`）を選択します。
10. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、表作成時に画像をセル内に配置する方法を示します。

```python
import aspose.slides as slides

# Presentation オブジェクトをインスタンス化します。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列幅と行高さを定義します。
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # スライドに表シェイプを追加します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 画像を読み込み、プレゼンテーションに追加して PPImage を取得します。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # 最初の表セルに画像を適用します。
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # プレゼンテーションをディスクに保存します。
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**単一セルの各辺に対して異なる線の太さやスタイルを設定できますか？**

はい。上、下、左、右の各境界線は個別のプロパティを持つため、各辺の太さやスタイルを別々に設定できます。この記事で示したセル単位の側面別境界線制御に基づくものです。

**セルの背景に画像を設定した後、列/行サイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)（stretch／tile）に依存します。ストレッチの場合、画像は新しいセルサイズに合わせて拡大縮小され、タイルの場合はタイルが再計算されます。記事内でセル内画像の表示モードについて説明しています。

**セル内のすべてのコンテンツにハイパーリンクを割り当てられますか？**

[Hyperlinks](/slides/ja/python-net/manage-hyperlinks/) はセル内テキストフレームのテキスト（ポーション）レベル、またはテーブル／シェイプ全体のレベルで設定します。実際には、ポーション単位またはセル内全テキストにリンクを付与します。

**単一セル内でフォントを複数設定できますか？**

はい。セルのテキストフレームは [Portion]（走査）をサポートしており、フォント ファミリー、スタイル、サイズ、色などを個別に設定可能です。