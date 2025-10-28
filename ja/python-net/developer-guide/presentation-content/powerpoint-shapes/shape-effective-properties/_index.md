---
title: Python でプレゼンテーションからシェイプの実効プロパティを取得する
linktitle: 実効プロパティ
type: docs
weight: 50
url: /ja/python-net/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライトリグ
- ベベル シェイプ
- テキスト フレーム
- テキスト スタイル
- フォント 高さ
- 塗りつぶし 形式
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET が正確な PowerPoint および OpenDocument のレンダリングのために、実効シェイプ プロパティを計算および適用する方法を紹介します。"
---

## **概要**

このトピックでは、**実効** プロパティと **ローカル** プロパティの概念を学びます。次のレベルで値が直接設定されている場合:

1. スライド上のテキスト部分プロパティ。
2. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイル（テキストフレームがある場合）。
3. プレゼンテーション全体のグローバルテキスト設定。

これらの値は **ローカル** 値と呼ばれます。任意のレベルで **ローカル** 値は定義されても、未定義でも構いません。アプリケーションがテキスト部分の表示方法を決定する必要があるときは、**実効** 値を使用します。実効値は、ローカルフォーマットの `get_effective` メソッドを呼び出すことで取得できます。

以下の例は、テキストフレーム形式とテキスト部分形式の実効値を取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **有効なカメラ プロパティ の取得**

Aspose.Slides for Python via .NET では、実効カメラ プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) クラスは、これらのプロパティを含む不変オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) のインスタンスは、[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) クラスの実効値を提供します。

以下の例は、実効カメラ プロパティを取得する方法を示しています。

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

## **有効なライトリグ プロパティ の取得**

Aspose.Slides for Python via .NET では、ライトリグの実効プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) クラスは、これらのプロパティを含む不変オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) のインスタンスは、[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) クラスの実効値を提供します。

以下の例は、実効ライトリグ プロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```

## **有効なシェイプ ベベル プロパティ の取得**

Aspose.Slides for Python via .NET では、シェイプ ベベルの実効プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) クラスは、シェイプの面リフト（ベベル）プロパティを含む不変オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) のインスタンスは、[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) クラスの実効値を提供します。

以下の例は、シェイプ ベベルの実効プロパティを取得する方法を示しています。

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

## **有効なテキスト フレーム プロパティ の取得**

Aspose.Slides for Python via .NET を使用すると、テキスト フレームの実効プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) クラスは、実効テキスト フレームの書式設定プロパティを含みます。

以下の例は、実効テキスト フレーム書式設定プロパティを取得する方法を示しています。

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

## **有効なテキスト スタイル プロパティ の取得**

Aspose.Slides for Python via .NET を使用すると、テキスト スタイルの実効プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) クラスは、実効テキスト スタイルのプロパティを含みます。

以下の例は、実効テキスト スタイル プロパティを取得する方法を示しています。

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

## **有効なフォント 高さ の取得**

Aspose.Slides for Python via .NET を使用すると、実効フォント 高さを取得できます。以下の例は、プレゼンテーション構造の異なるレベルでローカル フォント 高さを設定したときに、テキスト部分の実効フォント 高さがどのように変化するかを示しています。

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

## **有効なテーブル 塗りつぶし 形式 の取得**

Aspose.Slides for Python via .NET を使用すると、テーブルのさまざまな論理部位の実効塗りつぶし書式設定を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) クラスは、実効塗りつぶし書式設定プロパティを含みます。セルの書式設定は常に行の書式設定より優先され、行は列より優先され、列はテーブル全体より優先されます。

したがって、最終的にテーブルを描画する際には、[ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) のプロパティが使用されます。以下の例は、テーブルの各レベルの実効塗りつぶし書式設定を取得する方法を示しています。

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

**「スナップショット」を取得したのか「ライブオブジェクト」なのかをどう判断し、実効プロパティはいつ再取得すべきですか？**

EffectiveData オブジェクトは、呼び出し時点で計算された値の不変スナップショットです。シェイプのローカルまたは継承設定を変更した場合は、実効データを再取得して更新された値を取得してください。

**レイアウト／マスタースライドを変更すると、既に取得した実効プロパティに影響しますか？**

はい、ただし再取得したときにのみ反映されます。既に取得した EffectiveData オブジェクトは自動更新しません。レイアウトやマスターを変更した後に再度取得してください。

**EffectiveData を介して値を変更できますか？**

できません。EffectiveData は読み取り専用です。ローカルの書式オブジェクト（シェイプ／テキスト／3D など）を変更し、必要に応じて再度 EffectiveData を取得してください。

**シェイプレベル、レイアウト／マスター、グローバル設定のいずれにもプロパティが設定されていない場合はどうなりますか？**

実効値はデフォルトのメカニズム（PowerPoint／Aspose.Slides の既定値）で決定されます。その決定された値が EffectiveData のスナップショットに含まれます。

**実効フォント値から、どのレベルがサイズまたはフォント名を提供したか判断できますか？**

直接はできません。EffectiveData は最終的な値を返すだけです。元の定義元を知りたい場合は、部分／段落／テキストフレームのローカル値や、レイアウト／マスター／プレゼンテーションのテキストスタイルを確認して、最初に明示的に設定された場所を特定してください。

**実効データの値がローカル値と同じに見えるのはなぜですか？**

ローカル値が最終的な結果となり、上位レベルからの継承が必要なかった場合です。その場合、実効値はローカル値と一致します。

**実効プロパティを使用すべきタイミングと、ローカルプロパティだけを使用すべきタイミングは？**

すべての継承が適用された「実際に表示される」結果が必要なときは EffectiveData を使用してください（例: 色、インデント、サイズの整合）。特定のレベルで書式を変更したい場合はローカルプロパティを操作し、必要に応じて EffectiveData を再取得して結果を確認してください。