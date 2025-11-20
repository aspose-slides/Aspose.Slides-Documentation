---
title: Python を使用してプレゼンテーションからシェイプの有効プロパティを取得
linktitle: 有効プロパティ
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
- 塗りつぶし フォーマット
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET が、正確な PowerPoint および OpenDocument のレンダリングのために、シェイプの実効プロパティを計算および適用する方法を紹介します。"
---

## **概要**

このトピックでは、**effective** と **local** プロパティの概念を学びます。次のレベルで値が直接設定された場合:

1. スライド上のテキスト部分のプロパティで。
2. レイアウトまたはマスタースライド上のプロトタイプ形状のテキストスタイルで（テキストフレームがある場合）。
3. プレゼンテーションのグローバルテキスト設定で。

これらの値は **local** 値と呼ばれます。任意のレベルで **local** 値は定義されてもよいし、省略されてもよいです。アプリケーションがテキスト部分の表示方法を決定する必要があるとき、**effective** 値を使用します。**effective** 値はローカルフォーマット上で `get_effective` メソッドを呼び出すことで取得できます。

以下の例は、テキストフレーム形式およびテキスト部分形式の **effective** 値を取得する方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```


## **Effective カメラ プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、effective カメラ プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) クラスは、これらのプロパティを含む不変オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) を介して公開され、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) クラスの **effective** 値を提供します。

以下の例は、effective カメラ プロパティを取得する方法を示しています。
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


## **Effective ライト リグ プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、effective ライト リグ プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) クラスは、これらのプロパティを含む不変オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) を介して公開され、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) クラスの **effective** 値を提供します。

以下の例は、effective ライト リグ プロパティを取得する方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```


## **Effective シェイプ ベベル プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、effective シェイプ ベベル プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) クラスは、シェイプの面リリーフ（ベベル）プロパティを含む不変オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) を介して公開され、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) クラスの **effective** 値を提供します。

以下の例は、シェイプ ベベル の **effective** プロパティを取得する方法を示しています。
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


## **Effective テキストフレーム プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、effective テキストフレーム プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) クラスには、effective テキストフレームの書式設定プロパティが含まれます。

以下の例は、effective テキストフレームの書式設定プロパティを取得する方法を示しています。
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


## **Effective テキスト スタイル プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、effective テキスト スタイル プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) クラスには、effective テキスト スタイルのプロパティが含まれます。

以下の例は、effective テキスト スタイルのプロパティを取得する方法を示しています。
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


## **Effective フォント 高さの取得**

Aspose.Slides for Python via .NET を使用すると、effective フォント 高さを取得できます。以下の例は、プレゼンテーション構造の異なるレベルでローカル フォント 高さを設定したときに、テキスト部分の effective フォント 高さがどのように変化するかを示しています。
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


## **Effective テーブル 塗りつぶし フォーマットの取得**

Aspose.Slides for Python via .NET を使用すると、テーブルの論理的な部分ごとの effective 塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) クラスには、effective 塗りつぶし書式プロパティが含まれます。セルの書式は常に行の書式より優先され、行は列より優先され、列はテーブル全体より優先されることに注意してください。

したがって、[ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) のプロパティが最終的にテーブル描画に使用されます。以下の例は、テーブルのさまざまなレベルの effective 塗りつぶし書式を取得する方法を示しています。
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

**「スナップショット」か「ライブオブジェクト」かをどのように判断し、effective プロパティを再取得すべきタイミングは？**

EffectiveData オブジェクトは、呼び出し時点で計算された値の不変スナップショットです。シェイプのローカルまたは継承設定を変更した場合、更新された値を得るために effective データを再取得してください。

**レイアウト/マスタースライドを変更すると、すでに取得した effective プロパティに影響しますか？**

はい、ただし再取得した後にのみ反映されます。既に取得した EffectiveData オブジェクトは自動的に更新されないため、レイアウトまたはマスタースライドを変更した後に再度取得してください。

**EffectiveData を介して値を変更できますか？**

できません。EffectiveData は読み取り専用です。ローカルの書式オブジェクト（シェイプ/テキスト/3D など）を変更し、必要に応じて再度 effective 値を取得してください。

**シェイプレベルでもレイアウト/マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**

effective 値はデフォルトのメカニズム（PowerPoint/Aspose.Slides の既定）によって決定されます。その解決された値が EffectiveData スナップショットの一部となります。

**effective フォント値から、どのレベルがサイズやフォント名を提供したか判別できますか？**

直接は判別できません。EffectiveData は最終的な値を返すだけです。出所を確認したい場合は、部分/段落/テキストフレームのローカル値や、レイアウト/マスター/プレゼンテーションのテキストスタイルを確認し、最初に明示的に定義された場所を特定してください。

**EffectiveData の値がローカル値と同じに見えるのはなぜですか？**

ローカル値が最終的な値となり、上位レベルからの継承が不要だった場合です。そのようなケースでは effective 値はローカル値と一致します。

**effective プロパティを使用すべきタイミングと、ローカルプロパティだけで作業すべきタイミングは？**

すべての継承が適用された「実際に描画される」結果が必要なときは EffectiveData を使用します（例: 色、インデント、サイズの整合）。特定のレベルで書式を変更したいときはローカルプロパティを操作し、必要に応じて EffectiveData を再取得して結果を検証してください。