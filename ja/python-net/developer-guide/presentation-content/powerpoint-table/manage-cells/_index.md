---
title: Pythonでプレゼンテーションのテーブルセルを管理する
linktitle: セルを管理する
type: docs
weight: 30
url: /ja/python-net/manage-cells/
keywords:
- テーブルセル
- 結合セル
- 枠線を削除
- セルを分割
- セル内の画像
- 背景色
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python（.NET版）を使用して、PowerPoint と OpenDocument のテーブルセルを手軽に管理できます。セルへのアクセス、変更、スタイリングを迅速に習得し、スライドの自動化をシームレスに実現します。"
---

## **概要**

本記事では、Aspose.Slides を使用してプレゼンテーションの表セルを操作する方法を示します。結合セルの検出、セルの枠線のクリアやカスタマイズ、結合および分割操作後の PowerPoint のセル番号付けの仕組みを理解し、複雑なレイアウトでのインデックス予測ができるようになります。また、セルの背景塗りの変更などの一般的な書式設定タスクを実演し、画像塗り設定を使用して表セル内に画像を直接配置する方法も示します。各シナリオには、表を作成または編集し、更新されたプレゼンテーションを保存する簡潔な Python の例が添付されているため、スニペットを自分のスライドにすぐに適用できます。

## **結合された表セルの特定**

表にはヘッダーや関連データをグループ化するために結合セルが含まれることがよくあります。このセクションでは、特定のセルが結合領域に属しているかどうかを判断し、マスタ（左上）セルを参照してブロック全体を一貫して読み取ったり書式設定したりする方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドからテーブルを取得します。
1. テーブルの行と列を反復して結合セルを見つけます。
1. 結合セルが見つかったときにメッセージを出力します。

以下の Python コードは、プレゼンテーション内の結合された表セルを特定します。
```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # 最初のスライドの最初のシェイプがテーブルであると想定しています。
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```


## **表セルの枠線の削除**

場合によっては、表の枠線がコンテンツの妨げになったり視覚的に散らかって見えることがあります。このセクションでは、選択したセルまたはセルの特定の側面から枠線を削除し、よりすっきりしたレイアウトとスライドのデザインに合わせた配置を実現する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドを取得します。
1. 列幅の配列を定義します。
1. 行高さの配列を定義します。
1. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドを使用してスライドに表を追加します。
1. 各セルを反復し、上、下、左、右の枠線をクリアします。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、表セルの枠線を削除する方法を示します。
```python
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 幅を指定した列と高さを指定した行を定義します。
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # スライドにテーブル シェイプを追加します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 各セルの枠線塗りをクリアします。
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # PPTX ファイルをディスクに保存します。
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **結合セルの番号付け**

2 つのセルペアを結合すると、たとえば (1, 1) x (2, 1) および (1, 2) x (2, 2) の場合、結果の表は結合しない表と同じセル番号を保持します。以下の Python コードはこの動作を示します。
```python
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列の幅と行の高さを定義します。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # スライドにテーブル シェイプを追加します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # セル (1,1) と (2,1) を結合します。
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # セル (1, 2) と (2, 2) を結合します。
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


## **分割セルの番号付け**

前の例では、表セルが結合されたとき、他のセルの番号は変わりませんでした。今回は、結合セルのない通常の表を作成し、セル (1, 1) を分割して特別な表を作成します。この表の番号付けに注意してください—見た目が変則的に見えるかもしれません。しかし、これは Microsoft PowerPoint が表セルに番号を付ける方法であり、Aspose.Slides も同じ動作を踏襲しています。

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

    # スライドにテーブル シェイプを追加します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # セル (1, 1) を分割します。
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


## **表セルの背景色の変更**

以下の Python の例は、表セルの背景色を変更する方法を示します。
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # 新しいテーブルを作成します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # セルの背景色を設定します。
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```


## **表セルへの画像挿入**

このセクションでは、Aspose.Slides で表セルに画像を挿入する方法を示します。対象セルへの画像塗りの適用と、ストレッチやタイルなどの表示オプションの設定について説明します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. 列幅の配列を定義します。
1. 行高さの配列を定義します。
1. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドを使用してスライドに表を追加します。
1. ファイルから画像をロードします。
1. 画像をプレゼンテーションの images に追加して [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を取得します。
1. 表セルの [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) を `PICTURE` に設定します。
1. 画像を表セルに適用し、塗りモード（例: `STRETCH`）を選択します。
1. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、表作成時に画像を表セル内に配置する方法を示します。
```python
import aspose.slides as slides

# プレゼンテーション オブジェクトをインスタンス化します。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列幅と行高さを定義します。
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # スライドにテーブル シェイプを追加します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 画像をロードし、プレゼンテーションに追加して PPImage を取得します。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # 画像を最初のテーブルセルに適用します。
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # プレゼンテーションをディスクに保存します。
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**単一セルの各側面に異なる線の太さやスタイルを設定できますか？**

はい。 [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) の枠線は個別のプロパティを持つため、各側面の太さとスタイルを変更できます。これは、記事で示したセルの側面ごとの枠線制御に論理的に対応しています。

**セルの背景として画像を設定した後に列/行サイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)（stretch/tile）に依存します。ストレッチの場合、画像は新しいセルに合わせて調整されます。タイルの場合、タイルが再計算されます。記事ではセル内の画像表示モードについて言及しています。

**セル内のすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/python-net/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（部分）レベル、またはテーブル/シェイプ全体のレベルで設定されます。実際には、リンクを部分またはセル内のすべてのテキストに割り当てます。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキストフレームは、[portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)（ラン）ごとにフォントファミリ、スタイル、サイズ、色などの個別の書式設定をサポートします。