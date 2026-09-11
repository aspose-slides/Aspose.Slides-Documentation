---
title: Python（Java経由）でプレゼンテーションからシェイプの実効プロパティを取得
linktitle: 実効プロパティ
type: docs
weight: 50
url: /ja/python-java/shape-effective-properties/
keywords:
- シェイププロパティ
- カメラプロパティ
- ライトリグ
- ベベルシェイプ
- テキストフレーム
- テキストスタイル
- フォント高さ
- 塗りつぶし形式
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python（Java経由）で Aspose.Slides を使用し、PowerPoint プレゼンテーションにおけるシェイプのローカル、継承、および実効書式設定を区別する方法を学びます。"
---
## **ローカル、継承、実効プロパティの理解**

PowerPoint の書式設定は複数の場所から取得されます。オブジェクトに直接保存されている値は **ローカル値** です。その値が設定されていない場合、PowerPoint は段落のデフォルト、テキスト スタイル、レイアウトまたはマスタースライド、テーマ、プレゼンテーション レベルのデフォルトなどの親書式設定ソースを確認します。これらの値は **継承値** と呼ばれます。階層全体が解決された後に残る値が **実効値** であり、オブジェクトの描画に使用される値です。

たとえば、テキストの一部がフォント高さを個別に定義していない場合、そのローカル [getFontHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#getFontHeight) の値は `float("nan")` となり、これは「ここでは設定されていない」ことを意味します。その部分は段落、プレゼンテーションのデフォルト テキスト スタイル、または他の適用可能なソースから高さを継承できます。部分書式に対して [getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/#getEffective) を呼び出すと、最終的に解決された高さが返されます。

2 種類の書式データを目的に応じて使用します。

- 値がどこで定義されているかを制御したい場合は、[PortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) などのローカル書式オブジェクトを読み取ったり変更したりします。
- 最終的に描画される結果が必要な場合は、`PortionFormatEffectiveData` などの実効データオブジェクトを読み取ります。実効データは読み取り専用です。

## **ローカル、継承、実効値の比較**

次の完全な例は、シェイプを作成し、プレゼンテーション、段落、部分レベルでフォント高さを設定します。各ステップでそれらのレベルで定義された値と、同じテキスト部分の実効値を出力します。また、書式設定を変更した後に実効データを再度取得する必要がある理由も示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # 前の変更後に実効データを読み取ります。
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # 異なる 2 つのレベルで継承値を定義します。
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # 部分のローカル値が 2 つの継承値を上書きします。
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # 継承値を変更しても、既存のローカル値は上書きされません。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # ローカル値をクリアします。部分は再び段落から継承します。
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # 段落の値をクリアします。プレゼンテーションのデフォルトが結果を提供します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

この例の優先順位は、部分のローカル書式 → 段落書式 → プレゼンテーションのデフォルトです。別のオブジェクトは異なる継承チェーンを持つことがありますが、原則は同じです。より具体的な明示的値が優先され、[getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/#getEffective) が最終結果を返します。

## **実効テキストプロパティの取得**

テキスト書式設定は複数のオブジェクトに分割されています。

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#getEffective) はマージン、アンカリング、オートフィット、垂直テキスト方向などのテキスト フレーム プロパティを解決します。
- [TextStyle.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textstyle/#getEffective) は各テキスト スタイル レベルの段落書式を解決します。
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#getEffective) は配置、インデント、箇条書きなどの段落プロパティを解決します。
- [PortionFormat.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/#getEffective) はフォント高さ、フォント名、色、太字、斜体などの文字プロパティを解決します。

次の例では、`text-formatting.pptx` に少なくとも 1 枚のスライドと、空でないテキスト フレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) が必要です。AutoShape はシェイプ コレクション内の任意の位置に存在して構いません。コードは適切なオブジェクトを検索し、使用前に検証します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **実効 3D プロパティの取得**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/threedformat/#getEffective) は、すべての解決済み 3D 設定をまとめた `ThreeDFormatEffectiveData` オブジェクトを返します。その `getCamera`、`getLightRig`、`getBevelTop`、`getBevelBottom` メソッドは対応する実効データを公開します。これらの関連設定をまとめて取得することで、シェイプの最終的な 3D 表示を理解しやすくなります。

この例では、`shape-3d.pptx` に最初のスライドに少なくとも 1 つのシェイプが含まれている必要があります。そのシェイプに 3D カメラ、照明、ベベル設定を適用しておくと、デフォルト以外の値が出力に含まれます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **実効テーブル書式の取得**

テーブル書式はテーブルスタイルと、テーブル全体、列、行、個々のセルに適用された書式の両方から取得されます。明示的に定義された塗りつぶしが競合する場合の優先順位は、セル → 行 → 列 → テーブル全体です。セルの実効書式は、そのセルを描画する際に使用される最終書式です。

この例では、`table-formatting.pptx` に最初のスライドに少なくとも 1 つのテーブルが必要です。テーブルは少なくとも 1 行と 1 列を持っている必要があります。コードは `getShapes().get_Item(0)` がテーブルであると仮定せず、[Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) オブジェクトを検索します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

塗りつぶしタイプだけでなく色が必要な場合は、まず実効 `getFillType` を確認し、次にそのタイプに対応するメソッド（例: 固体塗りつぶしの場合は `getSolidFillColor`）を使用して色を取得します。

## **変更後に実効データを再取得する**

実効データは解決時点の書式階層を記述しています。階層に参加できる要素を変更した後は、再度 [getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/#getEffective) を呼び出してください。対象となる要素は次のとおりです。

- オブジェクトのローカル書式
- 段落またはテキスト フレームのデフォルト
- テーブルスタイル、テーブル、列、行、セルの書式
- レイアウトまたはマスタースライドの書式
- テーマ データまたはプレゼンテーション レベルのデフォルト
- スライドに割り当てられたレイアウトまたはマスター

実効データ オブジェクトを永続的なスナップショットとして保持しないでください。Aspose.Slides は内部で一部の実効データをキャッシュすることがあり、後続の [getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/#getEffective) 呼び出しでデータが更新されます。変更前後の値を比較したい場合は、フォント高さ、色、配置、ベベル幅など必要なスカラー値を自分の変数にコピーしてから変更を加えてください。

値を変更するには、適切なローカル書式オブジェクトを更新し、次に [getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/#getEffective) を呼び出して結果を確認します。実効データ オブジェクト自体は読み取り専用です。

## **FAQ**

**実効値がどのレベルから供給されたかを判別する方法は？**

実効データは最終値のみを保持し、ソースは保持しません。最も具体的なレベルから外側へ向かって該当するローカルオブジェクトを調べます。テキストの場合は、部分、段落、テキスト フレーム、レイアウト、マスター、テーマ、プレゼンテーション デフォルトが対象です。`float("nan")` や `None` のような未定義値は、検索が別のレベルに続くことを示します。

**どのレベルでもプロパティが定義されていない場合はどうなるか？**

Aspose.Slides は適切な PowerPoint またはライブラリのデフォルト値を解決します。その解決済み値が実効データに含まれ、ローカルオブジェクトが明示的に定義していなくても表示されます。

**実効値がローカル値と同じになるのはなぜか？**

ローカル値が継承計算で勝ったことを示します。オブジェクトにプロパティが明示的に設定され、より具体的なルールが上書きしない場合にこのようになります。

**ローカルデータと実効データはどちらを使うべきか？**

特定の書式レベルを検査または編集したい場合はローカルデータを使用します。継承、テーマ ルール、適用スタイルがすべて解決された後の最終的な外観が必要な場合は実効データを使用します。**[ローカル、継承、実効値の比較例](#compare-local-inherited-and-effective-values)** が同一ワークフローで両方を示しています。