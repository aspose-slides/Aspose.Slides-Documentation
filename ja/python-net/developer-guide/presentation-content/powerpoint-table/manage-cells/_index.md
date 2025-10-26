---
title: Pythonでプレゼンテーションのテーブルセルを管理する
linktitle: セル管理
type: docs
weight: 30
url: /ja/python-net/developer-guide/presentation-content/powerpoint-table/manage-cells/
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のテーブルセルを簡単に管理できます。セルへのアクセス、変更、スタイリングを迅速に習得し、スライドの自動化をシームレスに行いましょう。"
---

## **概要**

本稿では、Aspose.Slides を使用してプレゼンテーション内のテーブルセルを操作する方法を示します。結合セルの検出、セルの境界線のクリアやカスタマイズ、結合および分割操作後の PowerPoint のセル番号付けの仕組みを理解することで、複雑なレイアウトでのインデックス予測が可能になります。また、セルの背景塗りつぶしの変更や、画像フィル設定で画像をセル内部に直接配置する方法も実演します。各シナリオには、テーブルを作成または編集し、更新したプレゼンテーションを保存する簡潔な Python サンプルが付属しているため、コードを自分のスライドにすぐに適用できます。

## **結合テーブルセルの特定**

ヘッダーや関連データのグループ化のために、テーブルでは結合セルが頻繁に使用されます。このセクションでは、特定のセルが結合領域に属しているかを判定し、マスター（左上）セルを取得してブロック全体を一貫して読み取り・書式設定する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. 1枚目のスライドからテーブルを取得します。  
1. テーブルの行と列を走査して結合セルを探します。  
1. 結合セルが見つかったらメッセージを出力します。

以下の Python コードは、プレゼンテーション内の結合テーブルセルを識別します。

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # 1枚目のスライドの最初のシェイプがテーブルであると仮定します。
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **テーブルセルの境界線を削除**

テーブル境界線がコンテンツの視認性を妨げたり、ビジュアルが乱れたりすることがあります。このセクションでは、選択したセルまたはセルの特定側の境界線を削除して、スライドデザインに合わせたすっきりしたレイアウトを実現する手順を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドを取得します。  
1. 列幅の配列を定義します。  
1. 行高さの配列を定義します。  
1. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドでスライドにテーブルを追加します。  
1. 各セルを走査し、上・下・左・右の境界線をクリアします。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、テーブルセルの境界線を削除する方法を示します。

```python
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスをインスタンス化します。
with slides.Presentation() as presentation:
    # 1枚目のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列幅と行高さを定義します。
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # スライドにテーブルシェイプを追加します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 各セルの境界線塗りつぶしをクリアします。
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

例えば (1,1)×(2,1) と (1,2)×(2,2) の 2 組のセルを結合した場合、結合後のテーブルは結合前と同じセル番号付けを保持します。以下の Python コードはこの動作を示します。

```python
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスをインスタンス化します。
with slides.Presentation() as presentation:
    # 1枚目のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列幅と行高さを定義します。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # スライドにテーブルシェイプを追加します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # セル (1,1) と (2,1) を結合します。
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # セル (1,2) と (2,2) を結合します。
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # セルインデックスを出力します。
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

前述の例では、セルを結合しても他のセルの番号は変わりませんでした。今回は結合されていない通常のテーブルを作成し、セル (1,1) を分割して特別なテーブルを生成します。このテーブルの番号付けは一見不自然に見えるかもしれませんが、Microsoft PowerPoint のセル番号付けロジックであり、Aspose.Slides も同様に動作します。

以下の Python コードはこの動作を示します。

```python
import aspose.slides as slides

# PPTX ファイルを表す Presentation クラスをインスタンス化します。
with slides.Presentation() as presentation:
    # 1枚目のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列幅と行高さを定義します。
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # スライドにテーブルシェイプを追加します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # セル (1,1) を幅で分割します。
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # セルインデックスを出力します。
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

## **テーブルセルの背景色変更**

以下の Python サンプルは、テーブルセルの背景色を変更する方法を示します。

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

## **テーブルセルへの画像挿入**

このセクションでは、Aspose.Slides でテーブルセルに画像を挿入する方法を示します。対象セルにピクチャーフィルを適用し、ストレッチやタイルなどの表示オプションを設定します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドを取得します。  
1. 列幅の配列を定義します。  
1. 行高さの配列を定義します。  
1. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドでスライドにテーブルを追加します。  
1. 画像ファイルを読み込みます。  
1. 画像をプレゼンテーションに追加して [PPImage] を取得します。  
1. テーブルセルの [FillType] を `PICTURE` に設定します。  
1. 画像をセルに適用し、フィルモード（例: `STRETCH`）を選択します。  
1. プレゼンテーションを PPTX ファイルとして保存します。

以下の Python コードは、テーブル作成時に画像をセル内部に配置する方法を示します。

```python
import aspose.slides as slides

# Presentation オブジェクトをインスタンス化します。
with slides.Presentation() as presentation:
    # 1枚目のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列幅と行高さを定義します。
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # スライドにテーブルシェイプを追加します。
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # 画像を読み込み、プレゼンテーションに追加して PPImage を取得します。
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # 最初のテーブルセルに画像を適用します。
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # プレゼンテーションをディスクに保存します。
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**単一セルの各辺に異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)、[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)、[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)、[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) の境界線は個別のプロパティを持つため、各辺の太さやスタイルを別々に設定できます。本稿で示したセル単位の側面別境界線制御がその根拠です。

**セルの背景に画像を設定した後で列・行サイズを変更した場合、画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)（stretch／tile）に依存します。stretch を使用すると画像は新しいセルサイズに合わせて伸縮し、tile を使用するとタイルが再計算されます。記事内でもセル内画像の表示モードについて述べています。

**セル内の全コンテンツにハイパーリンクを付けられますか？**

[Hyperlinks](/slides/ja/python-net/manage-hyperlinks/) はセル内テキストフレームのテキスト（portion）レベル、あるいはテーブル／シェイプ全体のレベルで設定します。実務では、セル内の全テキストに対してリンクを割り当てるか、個々の portion に割り当てるかを選択します。

**単一セル内でフォントを複数設定できますか？**

はい。セルのテキストフレームは [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)（ラン）をサポートしており、フォントファミリ、スタイル、サイズ、カラーなどを個別に設定できます。