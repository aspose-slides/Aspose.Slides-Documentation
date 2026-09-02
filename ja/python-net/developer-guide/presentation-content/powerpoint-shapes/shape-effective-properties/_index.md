---
title: Python でプレゼンテーションからシェイプの有効プロパティを取得する
linktitle: 有効プロパティ
type: docs
weight: 50
url: /ja/python-net/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライト リグ
- ベベル シェイプ
- テキスト フレーム
- テキスト スタイル
- フォント 高さ
- 塗りつぶし 形式
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーションにおけるシェイプのローカル、継承、および有効な書式設定を区別する方法を学びます。"
---
## **ローカル、継承、および有効なプロパティを理解する**

PowerPoint の書式設定は複数の場所から取得されます。オブジェクトに直接格納されている値は **ローカル値** です。その値が設定されていない場合、PowerPoint は段落のデフォルトやテキスト スタイル、レイアウトまたはマスター スライド、テーマ、プレゼンテーション レベルのデフォルトなど、親の書式設定元を参照します。これらの値は **継承値** と呼ばれます。階層全体が解決された後に残る値が **有効値** であり、オブジェクトの描画に使用されます。

たとえば、テキストの一部がフォント高さを定義していない場合、そのローカル [font_height](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ibaseportionformat/font_height/) は `float("nan")` となり、これは「ここでは設定されていない」ことを意味します。その部分は段落、プレゼンテーションのデフォルト テキスト スタイル、または他の適用可能なソースから高さを継承できます。部分フォーマットで [get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iportionformat/get_effective/) を呼び出すと、最終的に解決された高さが返されます。

2 種類の書式データを目的に応じて使用します：

- **ローカル** フォーマット オブジェクト（例: [IPortionFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iportionformat/)）を読み取ったり変更したりして、値がどこで定義されているかを制御します。
- **有効** データ オブジェクト（例: [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iportionformateffectivedata/)）を読み取って、最終的な描画結果を取得します。有効データは読み取り専用です。

## **ローカル、継承、および有効な値を比較する**

次の完全な例はシェイプを作成し、プレゼンテーション、段落、部分レベルでフォント高さを設定します。各ステップはそれらのレベルで定義された値と、同じテキスト部分の結果として得られる有効値を出力します。また、書式変更後に有効データを再度読み取る必要がある理由も示しています。

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # 前の変更の後で有効データを読み取ります。
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # 2 つの異なるレベルで継承値を定義します。
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # 部分のローカル値が 2 つの継承値の両方を上書きします。
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # 継承値を変更しても、既存のローカル値は上書きされません。
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # ローカル値をクリアします。部分は再び段落から継承します。
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # 段落の値をクリアします。プレゼンテーションのデフォルトが結果を提供します。
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

この例での優先順位は、部分のローカル書式 → 段落書式 → プレゼンテーションのデフォルトです。他のオブジェクトは異なる継承チェーンを持つことがありますが、原則は同じです。より具体的な明示的な値が勝ち、[get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iportionformat/get_effective/) が最終結果を返します。

## **有効なテキスト プロパティを取得する**

テキストの書式設定は複数のオブジェクトに分割されています：

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/ja/python-net/aspose.slides/itextframeformat/get_effective/) は余白、アンカリング、オートフィット、縦書き方向などのテキスト フレーム プロパティを解決します。
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/ja/python-net/aspose.slides/itextstyle/get_effective/) は各テキスト スタイル レベルの段落書式を解決します。
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iparagraphformat/get_effective/) は配置、インデント、箇条書きなどの段落プロパティを解決します。
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iportionformat/get_effective/) はフォント高さ、書体、色、太字、斜体などの文字プロパティを解決します。

次の例では、`text-formatting.pptx` に少なくとも 1 枚のスライドと、空でないテキスト フレームを持つ 1 つの [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) が含まれている必要があります。AutoShape はシェイプ コレクションの任意の位置に配置でき、コードは適切なオブジェクトを検索して使用前に検証します。

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **有効な 3D プロパティを取得する**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ithreedformat/get_effective/) は、すべての解決済み 3D 設定をまとめた 1 つの [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ithreedformateffectivedata/) オブジェクトを返します。その [camera](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ithreedformateffectivedata/camera/)、[light_rig](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ithreedformateffectivedata/light_rig/)、[bevel_top](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/)、および [bevel_bottom](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) プロパティは、対応する有効データを公開します。これらの関連設定をまとめて読み取ることで、シェイプの最終的な 3D 外観を理解しやすくなります。

この例では、`shape-3d.pptx` に最初のスライドに少なくとも 1 つのシェイプが含まれている必要があります。そのシェイプに 3D カメラ、照明、またはベベル設定を適用して、デフォルト以外の値が出力に含まれるようにしてください。

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **有効なテーブル 書式設定を取得する**

テーブルの書式設定はテーブル スタイルと、テーブル全体、列、行、個々のセルに適用された書式設定の両方から取得できます。明示的に定義された塗りつぶしが競合する場合の優先順位は、セル → 行 → 列 → テーブル全体です。セルの有効書式は、そのセルを描画する際に使用される最終書式です。

この例では、`table-formatting.pptx` に最初のスライドに少なくとも 1 つのテーブルが含まれている必要があります。そのテーブルは少なくとも 1 行と 1 列を持っている必要があります。コードは `shapes[0]` がテーブルであると仮定せず、[Table](https://reference.aspose.com/slides/ja/python-net/aspose.slides/table/) を検索します。

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

色が必要で塗りつぶしタイプだけでなく、まず有効な [fill_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ifillformateffectivedata/fill_type/) を確認し、次にそのタイプに対応するプロパティを読み取ります。例として、単色塗りつぶしの場合は [solid_fill_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) を使用します。

## **変更後に有効データを再取得する**

有効データは解決時点の書式階層を表します。階層に参加できる要素を変更した後は、`get_effective` を再度呼び出してください。対象となる要素は次のとおりです。

- オブジェクトのローカル書式
- 段落またはテキスト フレームのデフォルト
- テーブル スタイル、テーブル、列、行、セルの書式
- レイアウトまたはマスター スライドの書式
- テーマ データまたはプレゼンテーション レベルのデフォルト
- スライドに割り当てられたレイアウトまたはマスター

有効データ オブジェクトを永久的なスナップショットとして保持しないでください。Aspose.Slides は内部で一部の有効データをキャッシュすることがあり、後続の `get_effective` 呼び出しでデータが更新されます。変更前後の値を比較したい場合は、フォント高さ、色、配置、ベベル幅など必要なスカラー値を自分の変数にコピーしてから変更を行ってください。

値を変更するには、適切なローカル フォーマット オブジェクトを更新し、`get_effective` を呼び出して結果を確認します。有効データ オブジェクト自体は読み取り専用です。

## **FAQ**

**どのレベルが有効値を提供したかをどうやって判断できますか？**

有効データには最終値のみが含まれ、ソースは含まれません。最も具体的なレベルから外側へ向かって該当するローカル オブジェクトを調べます。テキストの場合は、部分、段落、テキスト フレーム、レイアウト、マスター、テーマ、プレゼンテーション デフォルトが対象です。`float("nan")` や `None` など未定義の値は、検索が別のレベルに続くことを示します。

**どのレベルでもプロパティが定義されていない場合はどうなりますか？**

Aspose.Slides は適切な PowerPoint またはライブラリのデフォルトを解決します。その解決された値はローカル オブジェクトが明示的に定義していなくても有効データに表示されます。

**なぜ有効値がローカル値と同じになることがあるのですか？**

ローカル値が継承計算で勝った結果です。オブジェクトにプロパティが明示的に設定され、より具体的なルールが上書きしなかった場合にこのようになります。

**ローカルデータと有効データはいつ使い分けるべきですか？**

ローカルデータは特定の書式レベルを検査・編集する際に使用します。有効データは継承、テーマ ルール、適用スタイルがすべて解決された後の最終的な外観が必要なときに使用します。**[完全比較サンプル](#compare-local-inherited-and-effective-values)** が同一ワークフローで両方を示しています。