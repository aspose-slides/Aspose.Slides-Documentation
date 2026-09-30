---
title: Python でプレゼンテーションテーブルを管理する
linktitle: テーブルの管理
type: docs
weight: 10
url: /ja/python-java/manage-table/
keywords:
- テーブルの追加
- テーブルの作成
- テーブルへのアクセス
- アスペクト比
- テキストの配置
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint スライド内のテーブルを作成および編集します。テーブル操作を簡素化するシンプルなコード例をご紹介します。"
---
## **概要**

PowerPoint のテーブルは情報を行と列に整理し、値の読み取りと比較を容易にします。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) と [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) クラスおよびその他の型を提供し、プレゼンテーション内のテーブルの作成、更新、管理が可能です。

## **最初からテーブルを作成する**

位置、列幅、行高さを指定してテーブルを作成します。スライドに追加した後、セルの枠線を書式設定したり、セルを結合したり、テキストを挿入したりできます。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. ポイント単位で列幅のリストを定義します。
4. ポイント単位で行高さのリストを定義します。
5. スライドに [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) オブジェクトを [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) メソッドで追加します。
6. [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) を順に処理し、上・下・右・左の枠線に書式設定を適用します。
7. テーブルの最初の行の最初の 2 つのセルを結合します。
8. 結合されたセルを [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) メソッドで取得します。
9. 結合されたセルにテキストを設定します。
10. 変更したプレゼンテーションを保存します。

以下の例は、3 列 5 行のテーブルを (100, 50) ポイントの位置に作成します。幅 5 ポイントの赤い枠線を適用し、最初の行の最初の 2 つのセルを結合し、結果を `table.pptx` として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **標準テーブルの番号付け**

標準テーブルでは、セルのインデックスはゼロベースで、順序は (列, 行) です。最初のセルは (0, 0) とインデックス付けされます。

例えば、4 列 4 行のテーブルのセルは以下のように番号付けされます：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この例は、上図の 4 × 4 テーブルを作成し、列幅と行高さを 70 ポイント、幅 5 ポイントの赤いセル枠線を適用します。座標はセルインデックスを示しています。セルは空のままで、テーブルを `StandardTables_out.pptx` として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **既存テーブルへのアクセス**

テーブルはスライドのシェイプコレクションに格納されています。シェイプを順に走査してテーブルを見つけ、[Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) クラスを使用してセルを読み取ったり更新したりします。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
2. インデックスでテーブルを含むスライドへの参照を取得します。
3. [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) オブジェクトを順に走査し、テーブルが見つかったら停止します。スライドに複数のテーブルがある場合は、[getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) を使用して必要なテーブルを識別します。
4. 対象セルのテキストを更新します。
5. 変更したプレゼンテーションを保存します。

以下の例は `UpdateExistingTable.pptx` を開き、最初のスライド上の最初のテーブルを見つけます。列 0、行 1 のセルに `New` を設定し、結果を `table1_out.pptx` として保存します。入力には少なくとも 1 つのスライドが必要で、該当スライドの最初のテーブルは少なくとも 1 列 2 行を持つ必要があります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

既存テーブルの行サイズを変更し、実際の高さが要求された最小値を超える理由を理解するには、[Control Row Height](/slides/ja/python-java/manage-rows-and-columns/#control-row-height) を参照してください。

## **テキストフレームを所有するセルの検索**

汎用のテキスト処理コードがテーブルから [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) を受け取った場合、所有する [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) を取得するには [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) メソッドを使用します。テーブルセルのテキストフレームの場合、[TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) は所有者を返し、[TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) は `None` を返しますが、テーブル自体はシェイプです。

セル座標は読み取り専用の [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) および [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) メソッドで取得できます。[TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) は読み取り専用のナビゲーションも提供し、所有者を返すものの所有権は変更しません。使用する前に返されたセルが `None` でないことを必ず確認してください。

テーブルセルとシェイプの所有者（SmartArt ノードに関連付けられたシェイプを含む）を特定する完全な例については、[Search and Replace Text](/slides/ja/python-java/search-and-replace-text/) を参照してください。

## **テーブル内のテキストの配置**

個々のテーブルセルの垂直アンカーとテキスト方向を制御できます。このセクションの例では、最初のセル内のテキストを中央揃えにし、270 度回転させます。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) オブジェクトを追加します。
4. テーブルから [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) オブジェクトを取得します。
5. 最初の [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) を取得し、テキストと色を設定します。
6. [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) と [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType) を使用してセルの垂直アンカーとテキスト方向を設定します。
7. 変更したプレゼンテーションを保存します。

この例は、列幅 120 ポイント、行高さ 100 ポイントの 4 × 4 テーブルを作成します。セル (0, 0) のテキストを書式設定し、最初の行の残りのセルに値を追加し、結果を `Vertical_Align_Text_out.pptx` として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テーブルレベルでのテキスト書式設定**

[setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) を使用してテーブル内のすべてのセルにテキスト書式設定を適用します。オーバーロードはパーション、段落、テキストフレームの書式設定を受け付けるため、個々のセルを走査せずにこれらのプロパティを設定できます。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
2. インデックスでスライドへの参照を取得します。
3. スライドから [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) オブジェクトを取得します。
4. テキストのフォントサイズを [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) で設定します。
5. [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) と [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) を使用して段落の配置と右マージンを設定します。
6. [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) を使用してテキスト方向を設定します。
7. 変更したプレゼンテーションを保存します。

以下の例は `table.pptx` を開きます。このファイルには少なくとも 1 枚のスライドがあり、最初のシェイプがテーブルである必要があります。フォントサイズを 25 ポイントに設定し、段落を右揃えにして右マージンを 20 ポイントにし、テキストを縦方向に設定します。書式設定されたプレゼンテーションは `result.pptx` として保存されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テーブルスタイルプロパティの取得**

[getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) を使用してテーブルのプリセットスタイルを読み取り、[setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) で設定します。この例では、1 つのテーブルに [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) を適用し、プリセット値を出力し、同じプリセットを 2 番目のテーブルにも割り当てます。両方のテーブルは `table-style.pptx` に保存されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テーブルのアスペクト比をロックする**

テーブルのアスペクト比は幅と高さの比率です。[setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) を使用して、この比率をテーブルに対してロックします。

以下の例は `pres.pptx` を開きます。このファイルには少なくとも 1 枚のスライドがあり、最初のシェイプがテーブルである必要があります。現在のロック状態を出力し、アスペクト比ロックを有効にして、更新された状態（`True`）を出力し、結果を `pres-out.pptx` として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **よくある質問**

**テーブル全体とセル内のテキストに右から左 (RTL) の読み取り方向を有効にできますか？**

はい。テーブルは [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) メソッドを提供し、段落には [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft) が用意されています。両方を使用することで、セル内の正しい RTL 順序と描画が保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするにはどうすればよいですか？**

[shape locks](/slides/ja/python-java/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（伸縮またはタイル）に従ってセル領域全体を覆います。