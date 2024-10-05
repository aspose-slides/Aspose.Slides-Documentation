---
title: セルの管理
type: docs
weight: 30
url: /python-net/manage-cells/
keywords: "テーブル, 結合セル, セル分割, テーブルセル内の画像, Python, Aspose.Slides for Python via .NET"
description: "PythonでのPowerPointプレゼンテーションのテーブルセル"
---

## **結合テーブルセルの特定**
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 最初のスライドからテーブルを取得します。
3. テーブルの行と列を反復処理して、結合セルを探します。
4. 結合セルが見つかった場合にメッセージを印刷します。

このPythonコードは、プレゼンテーション内の結合テーブルセルを特定する方法を示しています：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "SomePresentationWithTable.pptx") as pres:
    table = pres.slides[0].shapes[0] # assuming that #0.Shape#0 is a table
    for i in range(len(table.rows)):
        for j in range(len(table.columns)):
            currentCell = table.rows[i][j]
            if currentCell.is_merged_cell:
                print("セル 01 は行結合=2、列結合=3 の結合セルの一部であり、セル 45 から始まります。".format(
                    i, j, currentCell.row_span, currentCell.col_span, currentCell.first_row_index, currentCell.first_column_index))
```

## **テーブルセルの境界を削除**
1. `Presentation`クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。 
3. 幅のある列の配列を定義します。
4. 高さのある行の配列を定義します。
5. `AddTable`メソッドを介してスライドにテーブルを追加します。
6. 各セルを反復処理して、上部、下部、右側、および左側の境界をクリアします。
7. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードは、テーブルセルから境界を削除する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTXファイルを表すPresentationクラスのインスタンスを作成
with slides.Presentation() as pres:
   # 最初のスライドにアクセス
    sld = pres.slides[0]

    # 幅のある列と高さのある行を定義
    dblCols = [ 50, 50, 50, 50 ]
    dblRows = [ 50, 30, 30, 30, 30 ]

    # スライドにテーブルシェイプを追加
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # 各セルの境界フォーマットを設定
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # PPTXファイルをディスクに書き込む
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **結合セルの番号付け**
2対のセル(1, 1) x (2, 1)および(1, 2) x (2, 2)を結合すると、結果のテーブルが番号付けされます。このPythonコードはそのプロセスを示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTXファイルを表すPresentationクラスのインスタンスを作成
with slides.Presentation() as presentation:
    # 最初のスライドにアクセス
    sld = presentation.slides[0]

    # 幅のある列と高さのある行を定義
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # スライドにテーブルシェイプを追加
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # 各セルの境界フォーマットを設定
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # セルを結合 (1, 1) x (2, 1)
    tbl.merge_cells(tbl.rows[1][1], tbl.rows[2][1], False)

    # セルを結合 (1, 2) x (2, 2)
    tbl.merge_cells(tbl.rows[1][2], tbl.rows[2][2], False)

    presentation.save("MergeCells_out.pptx", slides.export.SaveFormat.PPTX)
```

その後、(1, 1)と(1, 2)を結合することで、テーブルの中央に大きな結合セルを含むテーブルが得られます：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTXファイルを表すPresentationクラスのインスタンスを作成
with slides.Presentation() as presentation:
    # 最初のスライドにアクセス
    slide = presentation.slides[0]

    # 幅のある列と高さのある行を定義
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70]

    # スライドにテーブルシェイプを追加
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # 各セルの境界フォーマットを設定
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # セルを結合 (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # セルを結合 (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # セルを結合 (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][1], table.rows[1][2], True)

    # PPTXファイルをディスクに書き込む
    presentation.save("MergeCells1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **分割セルの番号付け**
以前の例では、テーブルセルが結合されたとき、他のセルの番号付けは変更されませんでした。

今回は、通常のテーブル（結合セルのないテーブル）を取り、セル (1,1) を分割して特別なテーブルを取得しようとします。このテーブルの番号付けが奇妙に見えるかもしれませんが、これはMicrosoft PowerPointがテーブルセルに番号を付ける方法であり、Aspose.Slidesも同じことを行います。

このPythonコードは、私たちが説明したプロセスを示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTXファイルを表すPresentationクラスのインスタンスを作成
with slides.Presentation() as presentation:
    # 最初のスライドにアクセス
    slide = presentation.slides[0]

    # 幅のある列と高さのある行を定義
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # スライドにテーブルシェイプを追加
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # 各セルの境界フォーマットを設定
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # セルを結合 (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # セルを結合 (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # セル (1, 1) を分割します。
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # PPTXファイルをディスクに書き込む
    presentation.save("CellSplit_out.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルセルの背景色を変更**

このPythonコードは、テーブルセルの背景色を変更する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    dblCols = [ 150, 150, 150, 150 ]
    dblRows = [ 50, 50, 50, 50, 50 ]

    # 新しいテーブルを作成
    table = slide.shapes.add_table(50, 50, dblCols, dblRows)

    # セルの背景色を設定 
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルセル内に画像を追加**
1. `Presentation`クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. 幅のある列の配列を定義します。
4. 高さのある行の配列を定義します。
5. `AddTable`メソッドを介してスライドにテーブルを追加します。 
6. 画像ファイルを保持するための`Bitmap`オブジェクトを作成します。
7. ビットマップ画像を`IPPImage`オブジェクトに追加します。
8. テーブルセルの`FillFormat`を`Picture`に設定します。
9. テーブルの最初のセルに画像を追加します。
10. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードは、テーブルを作成する際にテーブルセル内に画像を配置する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentationクラスオブジェクトをインスタンス化
with slides.Presentation() as presentation:
    # 最初のスライドにアクセス
    islide = presentation.slides[0]

    # 幅のある列と高さのある行を定義
    dblCols =  [150, 150, 150, 150] 
    dblRows =  [100, 100, 100, 100, 90] 

    # スライドにテーブルシェイプを追加
    tbl = islide.shapes.add_table(50, 50, dblCols, dblRows)

    # 画像ファイルを保持するためのBitmap Imageオブジェクトを作成
    image = draw.Bitmap(path + "aspose-logo.jpg")

    # ビットマップオブジェクトを使ってIPPImageオブジェクトを作成
    imgx1 = presentation.images.add_image(image)

    # 最初のテーブルセルに画像を追加
    tbl.rows[0][0].cell_format.fill_format.fill_type = slides.FillType.PICTURE
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture.image = imgx1

    # PPTXをディスクに保存
    presentation.save("Image_In_TableCell_out.pptx", slides.export.SaveFormat.PPTX)
```