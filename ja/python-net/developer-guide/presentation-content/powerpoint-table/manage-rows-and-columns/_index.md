---
title: Python を使用して PowerPoint テーブルの行と列を管理
linktitle: 行と列
type: docs
weight: 20
url: /ja/python-net/manage-rows-and-columns/
keywords:
- テーブル行
- テーブル列
- 最初の行
- テーブルヘッダー
- 行のクローン
- 列のクロン
- 行のコピー
- 列のコピー
- 行の削除
- 列の削除
- 行テキスト書式設定
- 列テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のテーブル行と列を管理し、プレゼンテーションの編集とデータ更新を高速化します。"
---

## **概要**

この記事では、Aspose.Slides for Python を使用して PowerPoint および OpenDocument プレゼンテーションの表の行と列を管理する方法を示します。行または列の追加、挿入、クローン作成、削除、最初の行をヘッダーとしてマーク、サイズやレイアウトの調整、行または列レベルでのテキストおよびスタイルの書式設定方法を学びます。各タスクは、[Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) API をベースにしたコンパクトで自立したコードスニペットで示されるので、スライド上の表をすばやく見つけて、デザインに合わせて構造を変更できます。

## **最初の行をヘッダーとして設定**

表の最初の行をヘッダーとしてマークし、列のタイトルとデータを明確に区別します。Aspose.Slides for Python では、テーブルの *First Row* オプションを有効にするだけで、選択したテーブルスタイルで定義されたヘッダー書式が適用されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
1. インデックスでスライドにアクセスします。
1. すべての [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) オブジェクトを反復処理して、対象のテーブルを見つけます。
1. テーブルの最初の行をヘッダーとして設定します。

この Python コードは、テーブルの最初の行をヘッダーとして設定する方法を示しています。
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation("table.pptx") as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # シェイプを反復処理し、テーブルへの参照を取得します。
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # テーブルの最初の行をヘッダーとして設定します。
    table.first_row = True
    
    # プレゼンテーションをディスクに保存します。
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **テーブルの行または列をクローン**

任意のテーブル行または列をクローンし、テーブル内の目的の位置にコピーを挿入します。クローンはセルの内容、書式、サイズを保持するため、レイアウトを迅速かつ一貫して拡張できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
1. インデックスでスライドにアクセスします。
1. 列の幅の配列を定義します。
1. 行の高さの配列を定義します。
1. [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) をスライドに `add_table(x, y, column_widths, row_heights)` で追加します。
1. テーブル行をクローンします。
1. テーブル列をクローンします。
1. 変更されたプレゼンテーションを保存します。

この Python コードは、PowerPoint のテーブルの行と列をクローンする方法を示しています。
```python
 import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # 列幅と行高さを定義します。
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # スライドにテーブルを追加します。
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # 行1、列1にテキストを追加します。
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # 行2、列1にテキストを追加します。
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # テーブルの末尾に行1をクローンします。
    table.rows.add_clone(table.rows[0], False)

    # 行1、列2にテキストを追加します。
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # 行2、列2にテキストを追加します。
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # テーブルの4番目の行として行2をクローンします。
    table.rows.insert_clone(3,table.rows[1], False)

    # 末尾に最初の列をクローンします。
    table.columns.add_clone(table.columns[0], False)

    # インデックス3（4番目の位置）に2番目の列をクローンします。
    table.columns.insert_clone(3,table.columns[1], False)
    
    # プレゼンテーションをディスクに保存します。
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **テーブルから行または列を削除**

Aspose.Slides for Python を使用してインデックスで任意の行または列を削除し、テーブルを簡素化します。レイアウトは自動的に再調整され、残りのセルの書式は保持されます。データグリッドを簡略化したり、プレースホルダーを削除してテーブルを再構築しない場合に便利です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
1. インデックスでスライドにアクセスします。
1. 列の幅の配列を定義します。
1. 行の高さの配列を定義します。
1. `add_table(x, y, column_widths, row_heights)` を使用してスライドに ITable を追加します。
1. テーブルの行を削除します。
1. テーブルの列を削除します。
1. 変更されたプレゼンテーションを保存します。

以下の Python コードは、テーブルから行と列を削除する方法を示しています。
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```


## **テーブル行レベルでテキスト書式を設定**

1 つの手順でテーブル行全体に一貫したテキストスタイルを適用します。Aspose.Slides for Python を使用すると、行内のすべてのセルに対してフォントファミリー、サイズ、太さ、色、配置を一括で設定でき、見出しやデータバンドを統一できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
1. インデックスでスライドにアクセスします。
1. スライド上の対象 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) オブジェクトにアクセスします。
1. 最初の行のセルのフォント高さを設定します。
1. 最初の行のセルの配置と右余白を設定します。
1. 2 行目のセルのテキスト垂直タイプを設定します。
1. 変更されたプレゼンテーションを保存します。

この Python コードは操作を示しています。
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 最初の行のセルのフォント高さを設定します。
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # 最初の行のセルのテキスト配置と右余白を設定します。
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # 2 行目のセルのテキスト垂直タイプを設定します。
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
	# プレゼンテーションをディスクに保存します。
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **テーブル列レベルでテキスト書式を設定**

テーブル列全体に一貫したテキストスタイルを一度に適用します。Aspose.Slides for Python を使用すると、列内のすべてのセルに対してフォントファミリー、サイズ、太さ、色、配置を設定でき、見出しやデータの垂直帯を統一できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
1. インデックスでスライドにアクセスします。
1. スライド上の対象 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) オブジェクトにアクセスします。
1. 最初の列のセルのフォント高さを設定します。
1. 最初の列のセルの配置と右余白を設定します。
1. 2 列目のセルのテキスト垂直タイプを設定します。
1. 変更されたプレゼンテーションを保存します。

以下の Python コードは操作を示しています。
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # 最初の列のセルのフォント高さを設定します。
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # 最初の列のセルのテキスト配置と右余白を設定します。
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # 2 番目の列のセルのテキスト垂直タイプを設定します。
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # プレゼンテーションをディスクに保存します。
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **テーブルスタイル プロパティの取得**

Aspose.Slides では、テーブルのスタイルプロパティを取得できるため、別のテーブルや他の場所で再利用できます。以下の Python コードは、プリセットのテーブルスタイルからスタイルプロパティを取得する方法を示しています。
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスターテーマを継承し、必要に応じて塗りつぶし、枠線、テキスト色を上書きできます。

**Excel のようにテーブル行を並べ替えられますか？**

いいえ、Aspose.Slides のテーブルには組み込みの並べ替えやフィルタ機能はありません。データをメモリ内でソートしてから、同じ順序でテーブル行を再配置してください。

**特定のセルにカスタムカラーを保持しながら、帯状（ストライプ）列を設定できますか？**

はい。帯状列を有効にし、特定のセルにローカル書式で上書きすれば、セルレベルの書式がテーブルスタイルより優先されます。