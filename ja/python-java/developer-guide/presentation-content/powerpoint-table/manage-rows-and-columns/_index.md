---
title: Python を使用して PowerPoint テーブルの行と列を管理する
linktitle: 行と列
type: docs
weight: 20
url: /ja/python-java/manage-rows-and-columns/
keywords:
- テーブル行
- テーブル列
- 1 行目
- テーブルヘッダー
- 行のクローン
- 列のクローン
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
description: "Java 経由で Python 用 Aspose.Slides を使用して PowerPoint のテーブル行と列を管理し、プレゼンテーションの編集やデータ更新を高速化します。"
---
## **はじめに**

PowerPoint プレゼンテーションでテーブルの行と列を管理できるように、Aspose.Slides は [Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) クラスやその他多数の型を提供しています。

## **最初の行をヘッダーとして設定**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスでスライドへの参照を取得します。
3. [Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) の参照を作成し、`None` に設定します。
4. [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) オブジェクトをすべて走査して、対象のテーブルを見つけます。
5. テーブルの最初の行をヘッダーとして設定します。

この Python コードは、テーブルの最初の行をヘッダーとして設定する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テーブルの行または列をクローン**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスでスライドへの参照を取得します。
3. 列幅のリストを定義します。
4. 行高さのリストを定義します。
5. [addTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addTable) メソッドを使用して、スライドに [Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) オブジェクトを追加します。
6. テーブルの行をクローンします。
7. テーブルの列をクローンします。
8. 変更されたプレゼンテーションを保存します。

この Python コードは、PowerPoint テーブルの行または列をクローンする方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テーブルから行または列を削除**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 列幅のリストを定義します。
4. 行高さのリストを定義します。
5. [addTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addTable) メソッドを使用して、スライドに [Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) オブジェクトを追加します。
6. テーブルの行を削除します。
7. テーブルの列を削除します。
8. 変更されたプレゼンテーションを保存します。

この Python コードは、テーブルから行または列を削除する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テーブル行レベルでテキスト書式設定**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスでスライドへの参照を取得します。
3. スライドから該当する [Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) オブジェクトにアクセスします。
4. [setFontHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setFontHeight) を使用して、最初の行のセルのフォント高さを設定します。
5. [setAlignment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setAlignment) と [setMarginRight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setMarginRight) を使用して、最初の行のセルのテキスト配置と右余白を設定します。
6. [setTextVerticalType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setTextVerticalType) を使用して、2 行目のセルの縦書きテキストタイプを設定します。
7. 変更されたプレゼンテーションを保存します。

この Python コードは操作を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **テーブル列レベルでテキスト書式設定**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスでスライドへの参照を取得します。
3. スライドから該当する [Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) オブジェクトにアクセスします。
4. [setFontHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setFontHeight) を使用して、最初の列のセルのフォント高さを設定します。
5. [setAlignment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setAlignment) と [setMarginRight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setMarginRight) を使用して、最初の列のセルのテキスト配置と右余白を設定します。
6. [setTextVerticalType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setTextVerticalType) を使用して、2 列目のセルの縦書きテキストタイプを設定します。
7. 変更されたプレゼンテーションを保存します。

この Python コードは操作を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **テーブルスタイルプロパティの取得**

Aspose.Slides は、テーブルのスタイルプロパティを取得できるため、その詳細を別のテーブルや他の場所で利用できます。この Python コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスターテーマを継承しますが、そのテーマの上で塗りつぶし、枠線、テキストカラーを上書きすることも可能です。

**Excel のようにテーブルの行を並び替えることはできますか？**

いいえ、Aspose.Slides のテーブルには組み込みのソートやフィルタ機能はありません。まずメモリ上でデータをソートし、その順序でテーブルの行を再配置してください。

**特定のセルにカスタムカラーを保持しつつ、バンド（ストライプ）列を設定できますか？**

はい。バンド列を有効にした後、特定のセルにローカルな書式設定で上書きすれば、セルレベルの書式設定がテーブルスタイルより優先されます。