---
title: 行と列の管理
type: docs
weight: 20
url: /python-net/manage-rows-and-columns/
keywords: "テーブル, テーブルの行と列, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションのテーブル行と列を管理する"
---

PowerPointプレゼンテーションのテーブルの行と列を管理するために、Aspose.Slidesは[Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)クラス、[ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/)インターフェイス、およびその他の多くのタイプを提供します。

## **最初の行をヘッダーとして設定**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションを読み込みます。 
2. スライドのインデックスを通じてスライドの参照を取得します。 
3. [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/)オブジェクトを作成し、それをnullに設定します。
4. すべての[IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/)オブジェクトを繰り返し、関連するテーブルを見つけます。 
5. テーブルの最初の行をそのヘッダーとして設定します。

このPythonコードは、テーブルの最初の行をヘッダーとして設定する方法を示しています：

```python
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation("table.pptx") as pres:
    # 最初のスライドにアクセス
    sld = pres.slides[0]

    # nullのTableExを初期化
    tbl = None

    # 図形を繰り返してテーブルへの参照を設定
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # テーブルの最初の行をヘッダーとして設定 
    tbl.first_row = True
    
    # プレゼンテーションをディスクに保存
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルの行または列をクローン**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. スライドの参照をインデックスを通じて取得します。 
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. `add_table(x, y, column_widths, row_heights)`メソッドを通じてスライドに[ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/)オブジェクトを追加します。
6. テーブルの行をクローンします。
7. テーブルの列をクローンします。
8. 修正されたプレゼンテーションを保存します。

このPythonコードは、PowerPointテーブルの行または列をクローンする方法を示しています：

```python
 import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation() as presentation:

    # 最初のスライドにアクセス
    sld = presentation.slides[0]

    # 幅を持つ列と高さを持つ行を定義
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # スライドにテーブル形状を追加
    table = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # 行1のセル1にテキストを追加
    table.rows[0][0].text_frame.text = "行 1 セル 1"

    # 行1のセル2にテキストを追加
    table.rows[1][0].text_frame.text = "行 1 セル 2"

    # テーブルの最後に行1をクローン
    table.rows.add_clone(table.rows[0], False)

    # 行2のセル1にテキストを追加
    table.rows[0][1].text_frame.text = "行 2 セル 1"

    # 行2のセル2にテキストを追加
    table.rows[1][1].text_frame.text = "行 2 セル 2"

    # テーブルの4行目として行2をクローン
    table.rows.insert_clone(3,table.rows[1], False)

    # 最後に1列目をクローン
    table.columns.add_clone(table.columns[0], False)

    # 4列目のインデックスで2列目をクローン
    table.columns.insert_clone(3,table.columns[1], False)
    
    # プレゼンテーションをディスクに保存
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルから行または列を削除**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. スライドの参照をインデックスを通じて取得します。 
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. `add_table(x, y, column_widths, row_heights)`メソッドを通じてスライドに[ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/)オブジェクトを追加します。
6. テーブルの行を削除します。
7. テーブルの列を削除します。
8. 修正されたプレゼンテーションを保存します。

このPythonコードは、テーブルから行または列を削除する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    colWidth =  [100, 50, 30] 
    rowHeight =  [30, 50, 30] 

    table = slide.shapes.add_table(100, 100, colWidth, rowHeight)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)
    pres.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブル行レベルのテキスト書式設定の設定**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. スライドの参照をインデックスを通じて取得します。 
3. スライドから関連する[ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/)オブジェクトにアクセスします。 
4. 最初の行のセルの`font_height`を設定します。
5. 最初の行のセルの`alignment`と`margin_right`を設定します。 
6. 2行目のセルの`text_vertical_type`を設定します。
7. 修正されたプレゼンテーションを保存します。

このPythonコードは、操作を示しています。

```python
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation() as presentation:
    
    slide = presentation.slides[0]

    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 最初の行のセルのフォント高さを設定
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.rows[0].set_text_format(portionFormat)

    # 最初の行のセルのテキスト揃えと右マージンを設定
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.rows[0].set_text_format(paragraphFormat)

    # 2行目のセルのテキストの垂直タイプを設定
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.rows[1].set_text_format(textFrameFormat)
	
    # プレゼンテーションをディスクに保存
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブル列レベルのテキスト書式設定の設定**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. スライドの参照をインデックスを通じて取得します。 
3. スライドから関連する[ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/)オブジェクトにアクセスします。 
4. 最初の列のセルの`font_height`を設定します。
5. 最初の列のセルの`alignment`と`margin_right`を設定します。 
6. 2列目のセルの`text_vertical_type`を設定します。
7. 修正されたプレゼンテーションを保存します。 

このPythonコードは、操作を示しています：

```python
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation() as pres:
    slide = pres.slides[0]
    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 最初の列のセルのフォント高さを設定
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.columns[0].set_text_format(portionFormat)

    # 最初の列のセルのテキスト揃えと右マージンを設定 
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.columns[0].set_text_format(paragraphFormat)

    # 2列目のセルのテキストの垂直タイプを設定
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.columns[1].set_text_format(textFrameFormat)

    # プレゼンテーションをディスクに保存
    pres.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルスタイルプロパティの取得**

Aspose.Slidesを使用すると、テーブルのスタイルプロパティを取得し、それを別のテーブルや他の場所で使用できます。このPythonコードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```