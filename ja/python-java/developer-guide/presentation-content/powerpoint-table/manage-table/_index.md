---
title: Python でプレゼンテーションの表を管理する
linktitle: 表の管理
type: docs
weight: 10
url: /ja/python-java/manage-table/
keywords:
- 表を追加
- 表を作成
- 表にアクセス
- アスペクト比
- テキストの配置
- テキスト書式設定
- 表スタイル
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Java 経由で Python 用 Aspose.Slides を使用し、PowerPoint スライド内の表を作成および編集します。表のワークフローを効率化するシンプルなコード例をご覧ください。"
---
## **導入**

PowerPoint の表は情報を表示する効率的な方法です。行と列に配置されたセルのグリッド内の情報はシンプルで理解しやすいです。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) クラス、[Cell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cell/) クラス、その他の型を提供し、さまざまなプレゼンテーションで表を作成、更新、管理できるようにします。

## **スクラッチから表を作成する**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. 列幅のリストを定義します。  
4. 行の高さのリストを定義します。  
5. スライドに [Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) オブジェクトを、[addTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addTable) メソッドを通じて追加します。  
6. 各 [Cell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cell/) を反復処理し、上、下、右、左の境界線に書式設定を適用します。  
7. 表の最初の行の最初の 2 つのセルを結合します。  
8. [Cell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cell/) の [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) にアクセスします。  
9. [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) にテキストを追加します。  
10. 変更されたプレゼンテーションを保存します。  

この Python コードは、プレゼンテーション内に表を作成する方法を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します
presentation = Presentation()
try:

    # 最初のスライドにアクセスします
    slide = presentation.getSlides().get_Item(0)

    # 列幅と行高さを定義します
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # スライドに表シェイプを追加します
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 各セルの罫線書式を設定します
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

    # 行 1 のセル 1 と 2 を結合します
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # 結合されたセルにテキストを追加します
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # プレゼンテーションをディスクに保存します
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **標準テーブルの番号付け**

標準テーブルでは、セルの番号付けはシンプルでゼロベースです。テーブルの最初のセルは 0,0（列 0、行 0）としてインデックス付けされます。

たとえば、4 列 4 行のテーブルのセルは次のように番号付けされます:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この Python コードは、標準セル番号付けのテーブルを作成する方法を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します
presentation = Presentation()
try:

    # 最初のスライドにアクセスします
    slide = presentation.getSlides().get_Item(0)

    # 列幅と行高さを定義します
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # スライドに表シェイプを追加します
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # 各セルの罫線書式を設定します
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)

    # プレゼンテーションをディスクに保存します
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **既存のテーブルにアクセスする**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでテーブルを含むスライドへの参照を取得します。  
3. [Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) オブジェクト用の変数を初期化し、`None` に設定します。  
4. すべての [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) オブジェクトを反復処理してテーブルが見つかるまで検索します。  

   スライドに単一のテーブルしか含まれていないと疑う場合は、含まれるすべてのシェイプを確認すれば十分です。シェイプがテーブルとして判別されたら、[Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) オブジェクトとして使用できます。複数のテーブルがある場合は、[getAlternativeText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getAlternativeText) を使って目的のテーブルを検索した方が良いでしょう。  

5. [Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) オブジェクトを使用してテーブルを操作します。以下の例では、2 行目の 1 列目のテキストを更新します。  
6. 変更されたプレゼンテーションを保存します。  

この Python コードは、既存のテーブルにアクセスして操作する方法を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # 最初のスライドにアクセスします
    slide = presentation.getSlides().get_Item(0)

    # テーブル参照を初期化します。
    table = None

    # シェイプを反復処理し、見つかったテーブルへの参照を設定します
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # 2 行目の最初の列のテキストを設定します
            table.get_Item(0, 1).getTextFrame().setText("New")

    # 変更されたプレゼンテーションをディスクに保存します
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テキストフレームを所有するセルを見つける**

テーブルから取得した一般的なテキスト処理コードが [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) を受け取った場合は、[TextFrame.getParentCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/#getParentCell) メソッドを使用して所有セル ([Cell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cell/)) を取得します。テーブルセルのテキストフレームの場合、[TextFrame.getParentCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/#getParentCell) は所有者を返し、[TextFrame.getParentShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/#getParentShape) は `None` を返します。テーブル自体はシェイプですが、テキストフレームの親シェイプは存在しません。

セルの座標は、読み取り専用の [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cell/#getFirstColumnIndex) および [Cell.getFirstRowIndex](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cell/#getFirstRowIndex) メソッドで取得できます。[TextFrame.getParentCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/#getParentCell) も所有者を返しますが、所有権は変更されません。使用する前に必ず `None` かどうかを確認してください。

テーブルセルとシェイプの所有者（SmartArt ノードに関連付けられたシェイプを含む）を特定する完全な例については、[Search and Replace Text](/slides/ja/python-java/search-and-replace-text/) を参照してください。

## **テーブル内のテキストを揃える**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. スライドに [Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) オブジェクトを追加します。  
4. テーブルから [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) オブジェクトにアクセスします。  
5. [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) の [Paragraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) にアクセスします。  
6. テキストを垂直方向に揃えます。  
7. 変更されたプレゼンテーションを保存します。  

この Python コードは、テーブル内のテキストを揃える方法を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Presentation クラスのインスタンスを作成します
presentation = Presentation()
try:

    # 最初のスライドを取得します
    slide = presentation.getSlides().get_Item(0)

    # 列幅と行高さを定義します
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # スライドに表シェイプを追加します
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # テキストフレームにアクセスします
    text_frame = table.get_Item(0, 0).getTextFrame()

    # テキストフレーム内の最初の段落にアクセスします。
    paragraph = text_frame.getParagraphs().get_Item(0)

    # 段落内の最初のポーションにアクセスします。
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # テキストを垂直方向に揃えます
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # プレゼンテーションをディスクに保存します
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テーブルレベルでテキスト書式設定を行う**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. スライドから [Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) オブジェクトにアクセスします。  
4. [setFontHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setFontHeight) でテキストのフォント高さを設定します。  
5. [setAlignment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setAlignment) と [setMarginRight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setMarginRight) で配置と右マージンを設定します。  
6. [setTextVerticalType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setTextVerticalType) で垂直テキストタイプを設定します。  
7. 変更されたプレゼンテーションを保存します。  

この Python コードは、テーブル内のテキストに好みの書式設定オプションを適用する方法を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Presentation クラスのインスタンスを作成します
presentation = Presentation("simpletable.pptx")
try:

    # 最初のスライドの最初のシェイプが表であると想定します
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # 表セルのフォント高さを設定します
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # 表セルのテキスト配置と右マージンを一度に設定します
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # 表セルのテキスト縦方向タイプを設定します
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **テーブルスタイルのプロパティを取得する**

Aspose.Slides は、テーブルのスタイルプロパティを取得できるため、取得した詳細を別のテーブルや他の場所で使用できます。この Python コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # デフォルトのスタイルプリセットテーマを変更します

    # テーブルのスタイルプリセットを取得します
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # 取得したスタイルプリセットを別のテーブルに適用します
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テーブルのアスペクト比をロックする**

幾何形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slides は、[setAspectRatioLocked](https://reference.aspose.com/slides/ja/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) メソッドを提供し、テーブルやその他のシェイプのアスペクト比設定をロックできます。

この Python コードは、テーブルのアスペクト比をロックする方法を示します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # 反転
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**テーブル全体とセル内のテキストの右から左 (RTL) 読み取り方向を有効にできますか？**  

はい。テーブルは [setRightToLeft](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/#setRightToLeft) メソッドを公開しており、段落は [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setRightToLeft) を持ちます。両方を使用することで、セル内で正しい RTL 順序とレンダリングが保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするには？**  

[shape locks](/slides/ja/python-java/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**  

はい。セルに [picture fill](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（伸張またはタイル）に従ってセル領域を覆います。