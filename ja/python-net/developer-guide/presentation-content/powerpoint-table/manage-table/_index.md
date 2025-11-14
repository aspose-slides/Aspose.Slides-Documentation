---
title: Python でプレゼンテーションのテーブルを管理する
linktitle: テーブルを管理
type: docs
weight: 10
url: /ja/python-net/manage-table/
keywords:
- テーブルを追加
- テーブルを作成
- テーブルにアクセス
- アスペクト比
- テキストを整列
- テキストの書式設定
- テーブルスタイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のスライドでテーブルを作成および編集する方法をご紹介します。テーブルのワークフローを効率化するシンプルなコード例を確認しましょう。"
---

PowerPointのテーブルは、情報を表示し表現するための効率的な方法です。セルのグリッド内の情報（行と列に配置）は明確で理解しやすいです。

Aspose.Slidesは、[Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)クラス、[ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/)インターフェース、[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)クラス、[ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/)インターフェース、および他のタイプを提供し、あらゆる種類のプレゼンテーションでテーブルを作成、更新、および管理することを可能にします。 

## **ゼロからテーブルを作成する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドのインデックスを通じてスライドの参照を取得します。 
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. `add_table(x, y, column_widths, row_heights)`メソッドを通じてスライドに[ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/)オブジェクトを追加します。
6. 各[ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/)を反復処理して、上、下、右、左の境界線のフォーマットを適用します。
7. テーブルの最初の行の最初の2つのセルをマージします。 
8. [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/)の[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)にアクセスします。 
9. [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)にテキストを追加します。
10. 修正されたプレゼンテーションを保存します。

このPythonコードは、プレゼンテーションにテーブルを作成する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTXファイルを表すPresentationクラスのインスタンスを構築
with slides.Presentation() as pres:
    # 最初のスライドにアクセス
    sld = pres.slides[0]

    # 幅と高さを持つ列と行を定義
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # スライドにテーブルシェイプを追加
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # 各セルの境界線のフォーマットを設定
    for row in range(len(tbl.rows)):
        for cell in range(len(tbl.rows[row])):
            tbl.rows[row][cell].cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_top.width = 5

            tbl.rows[row][cell].cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            tbl.rows[row][cell].cell_format.border_bottom.width =5

            tbl.rows[row][cell].cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            tbl.rows[row][cell].cell_format.border_left.width = 5

            tbl.rows[row][cell].cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_right.width = 5
        

    # 行1のセル1および2をマージ
    tbl.merge_cells(tbl.rows[0][0], tbl.rows[1][1], False)

    # マージされたセルにテキストを追加
    tbl.rows[0][0].text_frame.text = "マージされたセル"

    # プレゼンテーションをディスクに保存
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **標準テーブルにおける番号付け**

標準テーブルでは、セルの番号付けは明確でゼロから始まります。テーブルの最初のセルは0,0（列0、行0）としてインデックス付けされます。 

例えば、4列4行のテーブルのセルは次のように番号が付けられます：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

このPythonコードは、テーブル内のセルに番号を指定する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTXファイルを表すPresentationクラスのインスタンスを構築
with slides.Presentation() as pres:
    # 最初のスライドにアクセス
    sld = pres.slides[0]

    # 幅と高さを持つ列と行を定義
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # スライドにテーブルシェイプを追加
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # 各セルの境界線のフォーマットを設定
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

    # プレゼンテーションをディスクに保存
    pres.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **既存のテーブルにアクセスする**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。

2. そのインデックスを通じてテーブルを含むスライドへの参照を取得します。 

3. [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/)オブジェクトを作成し、nullに設定します。

4. テーブルが見つかるまで、すべての[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)オブジェクトを反復処理します。

   処理しているスライドに単一のテーブルが含まれていると疑う場合、含まれるすべてのシェイプを単純にチェックできます。シェイプがテーブルとして識別された場合、それを[Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)オブジェクトとして型キャストできます。しかし、処理しているスライドに複数のテーブルが含まれている場合は、`alternative_text`を通じて必要なテーブルを検索した方が良いです。 

5. [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/)オブジェクトを使用してテーブルで作業します。以下の例では、テーブルに新しい行を追加しました。

6. 修正されたプレゼンテーションを保存します。

このPythonコードは、既存のテーブルにアクセスして作業する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# PPTXファイルを表すPresentationクラスのインスタンスを構築
with slides.Presentation(path + "UpdateExistingTable.pptx") as pres:
    # 最初のスライドにアクセス
    sld = pres.slides[0]

    # nullのTableExを初期化
    tbl = None

    # シェイプを反復処理して見つかったテーブルへの参照を設定
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # 2行目の最初の列のテキストを設定
    tbl.rows[0][1].text_frame.text = "新しい"

    # 修正されたプレゼンテーションをディスクに保存
    pres.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **テーブル内のテキストを整列させる**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドのインデックスを通じてスライドの参照を取得します。 
3. スライドに[ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/)オブジェクトを追加します。 
4. テーブルから[ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)オブジェクトにアクセスします。 
5. [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)の[IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/)にアクセスします。
6. テキストを垂直に整列させます。
7. 修正されたプレゼンテーションを保存します。

このPythonコードは、テーブル内のテキストを整列させる方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation() as presentation:
    # 最初のスライドを取得 
    slide = presentation.slides[0]

    # 幅と高さを持つ列と行を定義
    dblCols =  [120, 120, 120, 120] 
    dblRows =  [100, 100, 100, 100] 

    # スライドにテーブルシェイプを追加
    tbl = slide.shapes.add_table(100, 50, dblCols, dblRows)
    tbl.rows[1][0].text_frame.text = "10"
    tbl.rows[2][0].text_frame.text = "20"
    tbl.rows[3][0].text_frame.text = "30"

    # テキストフレームにアクセス
    txtFrame = tbl.rows[0][0].text_frame

    # テキストフレーム用のParagraphオブジェクトを作成
    paragraph = txtFrame.paragraphs[0]

    # 段落用のPortionオブジェクトを作成
    portion = paragraph.portions[0]
    portion.text = "ここにテキスト"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # テキストを垂直に整列
    cell = tbl.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # プレゼンテーションをディスクに保存
    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルレベルでのテキストフォーマットの設定**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドのインデックスを通じてスライドの参照を取得します。 
3. スライドから[ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/)オブジェクトにアクセスします。
4. テキストの`font_height`を設定します。 
5. `alignment`および`margin_right`を設定します。 
6. `text_vertical_type`を設定します。
7. 修正されたプレゼンテーションを保存します。 

このPythonコードは、テーブル内のテキストに希望するフォーマットオプションを適用する方法を示しています：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation() as presentation:
    someTable = presentation.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # テーブルセルのフォント高さを設定
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.set_text_format(portionFormat)

    # テーブルセルのテキスト整列と右マージンを一度の呼び出しで設定
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.set_text_format(paragraphFormat)

    # テーブルセルのテキストの垂直タイプを設定
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.set_text_format(textFrameFormat)


    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルスタイルプロパティの取得**

Aspose.Slidesを使用すると、テーブルのスタイルプロパティを取得して、他のテーブルや別の場所で使用できます。このPythonコードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルのアスペクト比をロックする**

幾何学的形状のアスペクト比は、異なる次元におけるそのサイズの比率です。Aspose.Slidesでは、テーブルや他のシェイプのアスペクト比設定をロックするために`aspect_ratio_locked`プロパティが提供されています。 

このPythonコードは、テーブルのアスペクト比をロックする方法を示しています：

```c#
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])
    print("ロックされたアスペクト比: {0}".format(table.shape_lock.aspect_ratio_locked))

    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked

    print("ロックされたアスペクト比: {0}".format(table.shape_lock.aspect_ratio_locked))

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```