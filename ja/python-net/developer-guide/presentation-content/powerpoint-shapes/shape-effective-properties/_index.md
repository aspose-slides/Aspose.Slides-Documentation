---
title: Get Shape Effective Properties from Presentations with Python
linktitle: Effective Properties
type: docs
weight: 50
url: /ja/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-effective-properties/
keywords:
- shape properties
- camera properties
- light rig
- bevel shape
- text frame
- text style
- font height
- fill format
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET が、正確な PowerPoint および OpenDocument のレンダリングのために、効果的なシェイプ プロパティを計算および適用する方法をご紹介します。"
---

## **概要**

このトピックでは、**効果的な (effective)** プロパティと **ローカル (local)** プロパティの概念を学びます。以下のレベルで直接値が設定された場合:

1. スライド上のテキスト部分プロパティ。
2. レイアウトまたはマスタースライド上のプロトタイプ シェイプのテキストスタイル (テキスト フレームがある場合)。
3. プレゼンテーション全体のテキスト設定。

これらの値は **ローカル** 値と呼ばれます。任意のレベルで **ローカル** 値は定義されてもよいし、省略されてもよいです。アプリケーションがテキスト部分の表示方法を決定する必要があるときは、**効果的な** 値を使用します。効果的な値は、ローカルフォーマットの `get_effective` メソッドを呼び出すことで取得できます。

以下の例は、テキスト フレーム フォーマットとテキスト 部分フォーマットの効果的な値を取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **効果的なカメラ プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、効果的なカメラ プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) クラスは、これらのプロパティを保持する不変オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) のインスタンスは、[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) 経由で公開され、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) クラスの効果的な値を提供します。

以下の例は、効果的なカメラ プロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective camera properties =")
	print("Type:", str(three_d_effective_data.camera.camera_type))
	print("Field of view:", str(three_d_effective_data.camera.field_of_view_angle))
	print("Zoom:", str(three_d_effective_data.camera.zoom))
```

## **効果的なライト リグ プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、ライト リグの効果的なプロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) クラスは、これらのプロパティを保持する不変オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) のインスタンスは、[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) 経由で公開され、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) クラスの効果的な値を提供します。

以下の例は、効果的なライト リグ プロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```

## **効果的なシェイプ ベベル プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、シェイプ ベベルの効果的なプロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) クラスは、シェイプのフェイスリリーフ (ベベル) プロパティを保持する不変オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) のインスタンスは、[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) 経由で公開され、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) クラスの効果的な値を提供します。

以下の例は、シェイプ ベベルの効果的なプロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective shape's top face relief properties =")
	print("Type:", str(three_d_effective_data.bevel_top.bevel_type))
	print("Width:", str(three_d_effective_data.bevel_top.width))
	print("Height:", str(three_d_effective_data.bevel_top.height))
```

## **効果的なテキスト フレーム プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、テキスト フレームの効果的なプロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) クラスは、効果的なテキスト フレーム書式設定プロパティを保持しています。

以下の例は、効果的なテキスト フレーム書式設定プロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
	shape = presentation.slides[0].shapes[0]

	text_frame_format_effective_data = shape.text_frame.text_frame_format.get_effective()

	print("Anchoring type:", str(text_frame_format_effective_data.anchoring_type))
	print("Autofit type:", str(text_frame_format_effective_data.autofit_type))
	print("Text vertical type:", str(text_frame_format_effective_data.text_vertical_type))
	print("Margins")
	print("   Left:", str(text_frame_format_effective_data.margin_left))
	print("   Top:", str(text_frame_format_effective_data.margin_top))
	print("   Right:", str(text_frame_format_effective_data.margin_right))
	print("   Bottom:", str(text_frame_format_effective_data.margin_bottom))
```

## **効果的なテキスト スタイル プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、テキスト スタイルの効果的なプロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) クラスは、効果的なテキスト スタイル プロパティを保持しています。

以下の例は、効果的なテキスト スタイル プロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    effective_text_style = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effective_text_style.get_level(i)
        print(f"= Effective paragraph formatting for style level #{str(i)} =")

        print("Depth:", str(effectiveStyleLevel.depth))
        print("Indent:", str(effectiveStyleLevel.indent))
        print("Alignment:", str(effectiveStyleLevel.alignment))
        print("Font alignment:", str(effectiveStyleLevel.font_alignment))
```

## **効果的なフォント 高さの取得**

Aspose.Slides for Python via .NET を使用すると、効果的なフォント 高さを取得できます。以下の例は、プレゼンテーション構造の異なるレベルでローカル フォント 高さを設定したときに、テキスト部分の効果的なフォント 高さがどのように変化するかを示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)

    shape.add_text_frame("")
    paragraph = shape.text_frame.paragraphs[0]

    portion0 = slides.Portion("Sample text with first portion")
    portion1 = slides.Portion(" and second portion.")

    paragraph.portions.add(portion0)
    paragraph.portions.add(portion1)

    print("Effective font height just after creation:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Effective font height after setting entire presentation default font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[0].portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[1].portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```

## **効果的なテーブル 塗りつぶしフォーマットの取得**

Aspose.Slides for Python via .NET を使用すると、テーブルのさまざまな論理部位に対する効果的な塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) クラスは、効果的な塗りつぶし書式プロパティを保持しています。セルの書式は常に行の書式より優先され、行は列の書式より優先され、列はテーブル全体の書式より優先されます。

したがって、最終的にテーブルを描画する際に使用されるのは [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) のプロパティです。以下の例は、テーブルの各レベルに対する効果的な塗りつぶし書式を取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	table = presentation.slides[0].shapes[0]

	table_format_effective = table.table_format.get_effective()
	row_format_effective = table.rows[0].row_format.get_effective()
	column_format_effective = table.columns[0].column_format.get_effective()
	cell_format_effective = table[0, 0].cell_format.get_effective()

	table_fill_format_effective = table_format_effective.fill_format
	row_fill_format_effective = row_format_effective.fill_format
	column_fill_format_effective = column_format_effective.fill_format
	cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**「スナップショット」か「ライブオブジェクト」かをどのように判別し、効果的なプロパティはいつ再取得すべきですか？**

EffectiveData オブジェクトは、取得時点で計算された値の不変のスナップショットです。シェイプのローカルまたは継承設定を変更した場合は、再度 EffectiveData を取得して更新された値を取得してください。

**レイアウト/マスタースライドを変更すると、すでに取得した効果的プロパティに影響しますか？**

はい、ただし再取得した後にのみ反映されます。既に取得した EffectiveData オブジェクトは自動で更新されません。レイアウトやマスターを変更したら、再度取得してください。

**EffectiveData を通して値を変更できますか？**

できません。EffectiveData は読み取り専用です。ローカルの書式オブジェクト（シェイプ/テキスト/3D など）を変更し、必要に応じて再度 EffectiveData を取得してください。

**シェイプレベルでもレイアウト/マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**

効果的な値はデフォルトのメカニズム（PowerPoint/Aspose.Slides の既定値）により決定されます。その決定された値が EffectiveData のスナップショットに含まれます。

**効果的なフォント値から、どのレベルがサイズやフォントファミリを提供したか判別できますか？**

直接は判別できません。EffectiveData は最終的な値だけを返します。どのレベルで最初に明示的に定義されたかを知りたい場合は、ポーション/段落/テキストフレームのローカル値や、レイアウト/マスター/プレゼンテーションのテキストスタイルを確認してください。

**なぜ EffectiveData の値がローカル値と同じに見えることがあるのですか？**

ローカル値が最終的な値となり、上位レベルからの継承が必要なかった場合です。このようなケースでは、効果的な値はローカル値と一致します。

**効果的なプロパティを使用すべきタイミングと、ローカルプロパティだけを扱うべきタイミングは？**

すべての継承が適用された「実際に描画される」結果が必要なときは EffectiveData を使用します（例: 色やインデント、サイズの整合）。特定のレベルで書式を変更したい場合はローカルプロパティを操作し、必要に応じて EffectiveData を再取得して結果を確認してください。