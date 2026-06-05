---
title: Python でプレゼンテーションからシェイプの実効プロパティを取得する
linktitle: 実効プロパティ
type: docs
weight: 50
url: /ja/python-net/shape-effective-properties/
keywords:
- シェイプのプロパティ
- カメラ プロパティ
- ライト リグ
- ベベル シェイプ
- テキストフレーム
- テキストスタイル
- フォント高さ
- 塗りつぶし書式
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET が、正確な PowerPoint 表示のために実効シェイププロパティを計算し適用する方法を紹介します。"
---
## **概要**

このトピックでは、**ローカル**プロパティと**実効**プロパティの違いについて説明します。ローカル値は、特定の書式レベルで直接設定された値で、次のようなものがあります。

1. スライド上の部分（Portion）プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプ形状テキストスタイル（その部分のテキストフレーム形状が持っている場合）。
1. プレゼンテーション全体のグローバルテキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「描画後」の書式を必要とする場合、継承チェーンを解決し、**実効**値を返します。実効値は、ローカル書式オブジェクトの `get_effective` メソッドを呼び出すことで取得できます。

以下の例は、実効値の取得方法を示しています。最初のスライドの最初の図形が、テキストフレームと少なくとも1つの部分を持つ [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) であることを前提としています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
実効書式データは、継承が適用された後に計算された現在の書式を表します。現行の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iportionformateffectivedata/) などの一部の実効データオブジェクトが内部でキャッシュされることがあります。親や継承された書式を変更した後に `get_effective` を再度呼び出すとキャッシュが更新され、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。実効値を後で再利用したい場合は、フォントの高さ、塗りつぶし色、フォントスタイル、配置など、必要なプロパティを自分のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの実効プロパティの取得**

Aspose.Slides ではカメラの実効プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/icameraeffectivedata/) 型は、実効カメラプロパティを含む不変オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/icameraeffectivedata/) インスタンスは、[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ithreedformateffectivedata/) を介して公開され、[ThreeDFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/) の実効値を提供します。

以下のコードサンプルは、カメラの実効プロパティを取得する方法を示しています。最初のスライドの最初の図形が 3D 書式設定されていることを前提としています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **ライトリグの実効プロパティの取得**

Aspose.Slides ではライトリグの実効プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ilightrigeffectivedata/) 型は、実効ライトリグプロパティを含む不変オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ilightrigeffectivedata/) インスタンスは、[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ithreedformateffectivedata/) を介して公開され、[ThreeDFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/) の実効値を提供します。

以下のコードサンプルは、ライトリグの実効プロパティを取得する方法を示しています。最初のスライドの最初の図形が 3D 書式設定されていることを前提としています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **シェイプベベルの実効プロパティの取得**

Aspose.Slides ではシェイプベベルの実効プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ishapebeveleffectivedata/) 型は、シェイプの実効フェイスリフトプロパティを含む不変オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ishapebeveleffectivedata/) インスタンスは、[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ithreedformateffectivedata/) を介して公開され、[ThreeDFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/) の実効値を提供します。

以下のコードサンプルは、シェイプの上部ベベルの実効プロパティを取得する方法を示しています。最初のスライドの最初の図形が 3D 書式設定されていることを前提としています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **テキストフレームの実効プロパティの取得**

Aspose.Slides を使用すると、テキストフレームの実効プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/itextframeformateffectivedata/) 型は、実効テキストフレーム書式プロパティを含みます。

以下のコードサンプルは、テキストフレームの実効書式プロパティを取得する方法を示しています。最初のスライドの最初の図形がテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) であることを前提としています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **テキストスタイルの実効プロパティの取得**

Aspose.Slides を使用すると、テキストスタイルの実効プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/itextstyleeffectivedata/) 型は、実効テキストスタイルプロパティを含みます。

以下のコードサンプルは、テキストスタイルの実効プロパティを取得する方法を示しています。最初のスライドの最初の図形がテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) であることを前提としています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **実効フォント高さの取得**

Aspose.Slides を使用すると、実効フォント高さを取得できます。以下のコードは、ローカルのフォント高さがプレゼンテーション構造の異なるレベルで設定された後に、部分の実効フォント高さがどのように変化するかを示します。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **テーブルの実効塗りつぶし書式の取得**

Aspose.Slides を使用すると、テーブルの異なる部分に対する実効塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ifillformateffectivedata/) 型は、実効塗りつぶし書式プロパティを含みます。セルの書式は行の書式より優先され、行の書式は列の書式より優先され、列の書式はテーブル全体の書式より優先されます。

その結果、[ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/icellformateffectivedata/) プロパティがテーブルセルの描画に使用されます。以下のコードサンプルは、テーブルの各部分に対する実効塗りつぶし書式を取得する方法を示しています。最初のスライドの最初の図形が [Table](https://reference.aspose.com/slides/ja/python-net/aspose.slides/table/) であることを前提としています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**`get_effective` はスナップショットを返しますか？**

常にではありません。実効データは継承が適用された後に計算された書式を表しますが、一部の実効データオブジェクトは内部でキャッシュされることがあります。ローカルや継承された書式を変更した後に再度 `get_effective` を呼び出すと書式が再計算され、キャッシュが更新されるため、以前取得したオブジェクトは永続的なスナップショットとして扱うべきではありません。

**実効プロパティを再度読み取るべきタイミングは？**

ローカル書式、親スタイル、レイアウト書式、マスタ書式、またはプレゼンテーションレベルのデフォルトを変更した後に `get_effective` を再度呼び出してください。次の呼び出しで書式階層が再評価され、現在の実効結果が返されます。

**レイアウト／マスタスライドを変更または削除すると、既に取得した実効プロパティに影響しますか？**

はい。ただし変更は次の `get_effective` 呼び出し時に反映されます。親書式ソースが変更または削除された場合、以前取得した実効データは古くなる可能性があります。`get_effective` を再度呼び出すと Aspose.Slides が書式ツリーを再評価し、フォント、色、サイズ、その他の値が変わることがあります。

**実効データオブジェクトを通じて値を変更できますか？**

できません。実効データオブジェクトは計算された値を公開するだけです。変更はローカル書式オブジェクトで行い、必要に応じて再度実効値を取得してください。

**シェイプレベルでもレイアウト／マスタでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**

実効値はデフォルトメカニズムに従って決定されます。これは PowerPoint と Aspose.Slides のデフォルト設定を含みます。解決された値が現在の実効データの一部となります。

**実効フォント値から、どのレベルがサイズまたはフォント名を提供したか判断できますか？**

直接は判断できません。実効データは最終的な値を返すだけです。どのレベルで最初に明示的に定義されたかを知りたい場合は、部分、段落、テキストフレーム、レイアウト、マスタ、プレゼンテーションレベルのローカル値を順に確認してください。

**実効値がローカル値と同じに見えることがありますが、なぜですか？**

ローカル値が最終的な値となり、上位レベルからの継承が不要だった場合です。そのような場合、実効値はローカル値と一致します。

**実効プロパティを使用すべき時とローカルプロパティだけを使用すべき時は？**

すべての継承が適用された「描画後」の結果が必要なときは実効データを使用します。たとえば色やインデント、サイズを合わせる場合です。後で書式が変わっても値を保持したい場合は、必要なプロパティを自分のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて実効データを再取得して結果を確認します。