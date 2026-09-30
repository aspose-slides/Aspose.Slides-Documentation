---
title: Python を使用して PowerPoint テーブルの行と列を管理する
linktitle: 行と列
type: docs
weight: 20
url: /ja/python-net/manage-rows-and-columns/
keywords:
- テーブル行
- テーブル列
- 最初の行
- テーブルヘッダー
- 行の複製
- 列の複製
- 行のコピー
- 列のコピー
- 行の削除
- 列の削除
- 行のテキスト書式設定
- 列のテキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint のテーブル行と列を管理し、プレゼンテーションの編集とデータ更新を高速化します。"
---
## **導入**

Aspose.Slides for Python via .NET を使用すると、PowerPoint プレゼンテーション内のテーブルの構造と書式設定を [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) クラスで管理できます。ヘッダー行を指定したり、行や列を複製または削除したり、行や列全体にテキスト書式設定を適用したりできます。

この記事では、これらの操作を Python のサンプルで説明します。また、テーブルのスタイルプリセットを取得して再利用する方法も示します。テーブルの行と列のインデックスは 0 から始まります。

## **行の高さの制御**

[Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) を使用して、行の最小高さ（ポイント単位）を設定します。これは下限であり、固定高さではありません。[Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) は実際の高さを返し、読み取り専用です。行は [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/) から取得します。

サンプルは [row-height-input.pptx](row-height-input.pptx) を読み込みます。このファイルは最初のスライドの最初のシェイプとしてテーブルを含み、最初の行は 70 ポイントから始まります。セルは 18 ポイントの Arial 文字、折り返し、上下に 6 ポイントの余白を使用しています。2 列目の長いテキストは複数行に折り返されています。サンプルは最小高さを 100 ポイントに増やした後、20 ポイントに減らし、各変更後に実際の高さを出力し、両方の結果を保存します。

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

提供されたプレゼンテーションでは、最小高さを増やすと行に余白が追加され、減らすと余分な余白が削除されますが、実際の高さはテキストとセル余白のため 20 ポイントより大きくなります。最小高さだけを減らしても、コンテンツが要求するスペース以下には行を強制できません。

実際の高さに影響する要因は次のとおりです。

- **テキストとフォントサイズ:** 長いテキスト、明示的な改行、または大きなフォントは垂直方向のスペースを多く必要とします。
- **折り返しと列幅:** 折り返しが有効な場合、狭い [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) は行数を増やします。広い列は垂直方向の必要スペースを減らすことがあります。
- **セル余白:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) と [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) は垂直余白を追加します。[Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) と [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) はテキスト領域の幅を狭め、折り返しを増やす可能性があります。

結合セルがないこのテーブルでは、最も垂直スペースを必要とするセルが行全体の下限を決定します。行を短くしたい場合は、テキストを短くしたり、フォントサイズや余白を減らしたり、列幅を広げる必要があります。

以下の画像は同じテーブルを同一スケールで示しています。この実行では、実際の高さは 70、100、55.2 ポイントでした。最終行は 20 ポイントの最小高さよりも高く残っています。フォント環境によりテキスト測定は多少変わります。保存された結果は [increased minimum](row-height-increased.pptx) と [decreased minimum](row-height-decreased.pptx) からダウンロードできます。

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **最初の行をヘッダーとして設定する**

[first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) プロパティを使用して、最初の行をヘッダー書式としてマークします。見た目はテーブルに適用されたスタイルに依存します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスでプレゼンテーションを読み込む。  
2. 最初のスライドにアクセスする。  
3. スライド上の最初のシェイプとして格納されているテーブルにアクセスする。  
4. その最初の行のヘッダー書式を有効にする。  
5. 変更したプレゼンテーションを保存する。

サンプルは最初のスライドの最初のシェイプとしてテーブルを含む `table.pptx` を必要とします。最初の行にヘッダー書式を設定し、`First_row_header.pptx` として保存します。

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブル行または列を複製する**

行や列を複製して、コンテンツと書式を再利用できます。複製はテーブルの末尾に追加することも、特定の位置に挿入することもできます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスでプレゼンテーションを読み込む。  
2. 最初のスライドにアクセスする。  
3. 列幅と行高さを定義する。  
4. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドでテーブルを追加する。  
5. 必要な行を複製する。  
6. 必要な列を複製する。  
7. 変更したプレゼンテーションを保存する。

サンプルは少なくとも1枚のスライドを含む `Test.pptx` を必要とします。3 列 5 行のテーブルをポイント単位で作成し、最初の行と列のコピーを末尾に追加し、2 行目と列のコピーをインデックス 3（4 番目の位置）に挿入します。結果として 7 行 5 列のテーブルができます。`False` 引数は隣接する結合行・列への複製を無効にします。このテーブルに結合セルはありません。

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルから行または列を削除する**

不要になった行や列をテーブルから削除します。削除により、以降の行や列のインデックスがシフトします。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスでプレゼンテーションを作成する。  
2. 最初のスライドにアクセスする。  
3. 列幅と行高さを定義する。  
4. [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) メソッドでテーブルを追加する。  
5. 2 行目と 2 列目を削除する。  
6. 変更したプレゼンテーションを保存する。

このサンプルは 3×3 のテーブルを作成し、インデックス 1 の行と列を削除して 2×2 のテーブルを `TestTable_out.pptx` に残します。サイズはポイント単位です。`False` 引数は隣接する結合行・列の削除を無効にします。このテーブルに結合セルはありません。

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

## **テーブル行レベルでテキスト書式を設定する**

行全体にテキスト書式を適用してセル間の一貫性を保ちます。フォント属性、段落書式、テキスト方向を個別のセルを編集せずに設定できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスでプレゼンテーションを読み込む。  
2. 最初のスライド上のテーブルにアクセスする。  
3. 最初の行に対して [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) を設定する。  
4. 最初の行に対して [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) と [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) を設定する。  
5. 2 行目に対して [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) を設定する。  
6. 変更したプレゼンテーションを保存する。

サンプルは最初のシェイプとしてテーブルを含む `table.pptx` と、少なくとも 2 行があることを前提とします。1 行目に 25 ポイントのテキスト、右揃え、右段落余白 20 ポイントを適用し、2 行目に縦書きテキストを設定します。

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブル列レベルでテキスト書式を設定する**

列全体にテキスト書式を適用してセル間の一貫性を保ちます。フォント属性、段落書式、テキスト方向を個別のセルを編集せずに設定できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスでプレゼンテーションを読み込む。  
2. 最初のスライド上のテーブルにアクセスする。  
3. 最初の列に対して [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) を設定する。  
4. 最初の列に対して [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) と [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) を設定する。  
5. 2 列目に対して [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) を設定する。  
6. 変更したプレゼンテーションを保存する。

サンプルは最初のシェイプとしてテーブルを含む `table.pptx` と、少なくとも 2 列があることを前提とします。1 列目に 25 ポイントのテキスト、右揃え、右段落余白 20 ポイントを適用し、2 列目に縦書きテキストを設定します。

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルスタイル プロパティの取得**

[style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) プロパティを使用して、テーブルに適用されたプリセットを取得し、別のテーブルで再利用できます。これは個々のセル書式オーバーライドではなく、プリセット自体を識別します。

サンプルはテーブルを作成し、[TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) を適用してからプリセットを読み戻します。取得したプリセットが適用したものと一致すれば `True` を出力し、テーブルを `table.pptx` に保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスタのテーマを継承しますが、テーマ上に塗りつぶし、枠線、テキスト色などを上書きすることも可能です。

**Excel のようにテーブル行を並べ替えることはできますか？**

できません。Aspose.Slides のテーブルには組み込みのソートやフィルター機能はありません。まずメモリ上でデータをソートし、その順序でテーブル行を再配置してください。

**帯状（ストライプ）列を使用しつつ、特定のセルにカスタムカラーを保持できますか？**

はい。帯状列を有効にした後、特定のセルにローカル書式を上書きすれば、セルレベルの書式がテーブルスタイルより優先されます。