---
title: Python を使用してプレゼンテーションからシェイプの有効プロパティを取得する
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
- 塗りつぶし 書式
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET が、正確な PowerPoint 表示のためにシェイプの有効プロパティを計算し適用する方法を学びましょう。"
---
## **概要**

このトピックでは、**ローカル** と **有効** プロパティの違いについて説明します。ローカル値は、特定の書式設定レベルで直接設定される値であり、例えば以下のようなものです:

1. スライド上のポーション プロパティ。
1. レイアウトやマスタースライド上のプロトタイプシェイプのテキストスタイル（ポーションのテキストフレーム シェイプがある場合）。
1. プレゼンテーション全体のテキスト設定。

ローカル値は任意のレベルで定義されたり省略されたりできます。Aspose.Slides が最終的な「描画後」書式設定を必要とする場合、継承チェーンを解決し、**有効** な値を返します。ローカル書式オブジェクトの `get_effective` メソッドを呼び出すことで取得できます。

次の例は、有効な値を取得する方法を示しています。最初のスライドの最初のシェイプが、テキストフレームと少なくとも1つのポーションを持つ [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) であると仮定しています。

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
有効な書式データは、継承が適用された後の現在計算された書式を表します。現在の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iportionformateffectivedata/) のような一部の有効データオブジェクトが内部でキャッシュされる場合があります。`get_effective` を再度呼び出すと、親または継承された書式を変更した後にキャッシュされたデータが更新され、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。有効な値を後で再利用する必要がある場合は、フォント高さ、塗りの色、フォントスタイル、または配置など、必要なプロパティを自分のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの有効プロパティを取得**

Aspose.Slides を使用すると、カメラの有効プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/icameraeffectivedata/) 型は、カメラの有効プロパティを含む不変オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/icameraeffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ithreedformateffectivedata/) を介して公開され、[ThreeDFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/) の有効な値を提供します。

次のコードサンプルは、カメラの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持っていると仮定しています。

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

## **ライトリグの有効プロパティを取得**

Aspose.Slides を使用すると、ライトリグの有効プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ilightrigeffectivedata/) 型は、ライトリグの有効プロパティを含む不変オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ilightrigeffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ithreedformateffectivedata/) を介して公開され、[ThreeDFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/) の有効な値を提供します。

次のコードサンプルは、ライトリグの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持っていると仮定しています。

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

## **ベベルシェイプの有効プロパティを取得**

Aspose.Slides を使用すると、シェイプベベルの有効プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ishapebeveleffectivedata/) 型は、シェイプの有効な面リフトプロパティを含む不変オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ishapebeveleffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ithreedformateffectivedata/) を介して公開され、[ThreeDFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/) の有効な値を提供します。

次のコードサンプルは、シェイプの上部ベベルの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持っていると仮定しています。

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

## **テキストフレームの有効プロパティを取得**

Aspose.Slides を使用すると、テキストフレームの有効プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/itextframeformateffectivedata/) 型は、テキストフレームの有効な書式設定プロパティを含みます。

次のコードサンプルは、テキストフレームの有効な書式設定プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) であると仮定しています。

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

## **テキストスタイルの有効プロパティを取得**

Aspose.Slides を使用すると、テキストスタイルの有効プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/itextstyleeffectivedata/) 型は、テキストスタイルの有効プロパティを含みます。

次のコードサンプルは、テキストスタイルの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) であると仮定しています。

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

## **有効なフォント高さの値を取得**

Aspose.Slides を使用すると、有効なフォント高さを取得できます。次のコードは、プレゼンテーション構造のさまざまなレベルでローカルフォント高さが設定された後に、ポーションの有効フォント高さがどのように変化するかを示しています。

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

## **テーブルの有効な塗りつぶし書式を取得**

Aspose.Slides を使用すると、テーブルのさまざまな部分に対する有効な塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ifillformateffectivedata/) 型は、有効な塗りつぶし書式プロパティを含みます。セル書式は行書式より優先され、行書式は列書式より優先され、列書式はテーブル全体の書式より優先されます。

その結果、[ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/icellformateffectivedata/) のプロパティがテーブルセルの描画に使用されます。次のコードサンプルは、テーブルのさまざまな部分に対する有効な塗りつぶし書式を取得する方法を示しています。最初のスライドの最初のシェイプが [Table](https://reference.aspose.com/slides/ja/python-net/aspose.slides/table/) であると仮定しています。

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

必ずしもそうではありません。有効データは継承が適用された後に計算された書式を表しますが、一部の有効データオブジェクトは内部でキャッシュされる場合があります。続けて `get_effective` を呼び出すと書式が再計算されキャッシュが更新されることがあり、以前取得したオブジェクトは永続的なスナップショットとして扱うべきではありません。

**有効プロパティはいつ再取得すべきですか？**

`get_effective` を再度呼び出すのは、ローカル書式、親スタイル、レイアウト書式、マスタ書式、またはプレゼンテーションレベルのデフォルトを変更した後です。次の呼び出しで書式階層が再評価され、現在の有効な結果が返されます。

**レイアウトやマスタースライドを変更または削除すると、すでに取得した有効プロパティに影響しますか？**

はい、ただし変更は次の `get_effective` 呼び出しで反映されます。親書式ソースが変更または削除されると、以前取得した有効データは古くなる可能性があります。`get_effective` を再度呼び出すと、Aspose.Slides が書式ツリーを再評価し、フォントや色、サイズなどの値が変わることがあります。

**有効データオブジェクトを介して値を変更できますか？**

できません。有効データオブジェクトは計算済みの値を公開するだけです。ローカル書式オブジェクトで変更を行い、再度有効な値を取得してください。

**シェイプレベルでもレイアウト/マスターでもグローバル設定でもプロパティが設定されていない場合、どうなりますか？**

有効値はデフォルトメカニズムにより決定され、PowerPoint と Aspose.Slides の既定値が含まれます。解決された値が現在の有効データの一部となります。

**有効なフォント値から、どのレベルがサイズやフォントを提供したか判断できますか？**

直接はできません。有効データは最終的な値を返します。ソースを特定するには、ポーション、段落、テキストフレーム、レイアウト、マスター、プレゼンテーションレベルのローカル値を順に確認し、最初に明示的に定義された場所を探してください。

**なぜ有効値がローカル値と同じに見えることがあるのですか？**

ローカル値が最終的な値となり、上位レベルの継承が必要なかったためです。その場合、有効値はローカル値と一致します。

**有効プロパティはいつ使用し、ローカルプロパティだけで作業すべきはいつですか？**

すべての継承が適用された「描画後」の結果が必要なときは有効データを使用します。たとえば、色やインデント、サイズを揃える場合です。あとで書式変更があってもこれらの値を保持したい場合は、必要なプロパティを自分のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて有効データを再取得して結果を確認してください。