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
- 塗りつぶし フォーマット
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET が正確な PowerPoint および OpenDocument のレンダリングのためにシェイプの有効プロパティを計算し適用する方法を紹介します。"
---

## **概要**

このトピックでは、**有効** プロパティと **ローカル** プロパティの概念を学びます。以下のレベルで値が直接設定された場合:

1. スライド上のテキスト部分プロパティ
2. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイル (テキストフレームがある場合)
3. プレゼンテーション全体のテキスト設定

これらの値は **ローカル** 値と呼ばれます。任意のレベルで **ローカル** 値は定義されても、未定義のままでも構いません。アプリケーションがテキスト部分の表示方法を決定する必要があるときは、**有効** 値を使用します。有効値はローカルフォーマットの `get_effective` メソッドを呼び出すことで取得できます。

以下の例は、テキストフレーム フォーマットとテキスト部分フォーマットの有効値を取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **有効カメラ プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、有効カメラ プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) クラスは、これらのプロパティを保持するイミュータブル オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) のインスタンスは、[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) クラスの有効値を提供します。

以下の例は、有効カメラ プロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= 有効カメラ プロパティ =")
	print("Type:", str(three_d_effective_data.camera.camera_type))
	print("Field of view:", str(three_d_effective_data.camera.field_of_view_angle))
	print("Zoom:", str(three_d_effective_data.camera.zoom))
```

## **有効ライト リグ プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、ライト リグの有効プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) クラスは、これらのプロパティを保持するイミュータブル オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) のインスタンスは、[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) クラスの有効値を提供します。

以下の例は、有効ライト リグ プロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= 有効ライト リグ プロパティ =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```

## **有効シェイプ ベベル プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、シェイプ ベベルの有効プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) クラスは、シェイプのフェイスリリーフ (ベベル) プロパティを保持するイミュータブル オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) のインスタンスは、[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) クラスの有効値を提供します。

以下の例は、シェイプ ベベルの有効プロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= シェイプ上部フェイスリリーフ (ベベル) の有効プロパティ =")
	print("Type:", str(three_d_effective_data.bevel_top.bevel_type))
	print("Width:", str(three_d_effective_data.bevel_top.width))
	print("Height:", str(three_d_effective_data.bevel_top.height))
```

## **有効テキスト フレーム プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、テキスト フレームの有効プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) クラスは、有効なテキスト フレーム書式設定プロパティを保持しています。

以下の例は、有効テキスト フレーム 書式設定プロパティを取得する方法を示しています。

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

## **有効テキスト スタイル プロパティの取得**

Aspose.Slides for Python via .NET を使用すると、テキスト スタイルの有効プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) クラスは、有効なテキスト スタイル プロパティを保持しています。

以下の例は、有効テキスト スタイル プロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    effective_text_style = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effective_text_style.get_level(i)
        print(f"= スタイルレベル #{str(i)} の有効段落書式 =")

        print("Depth:", str(effectiveStyleLevel.depth))
        print("Indent:", str(effectiveStyleLevel.indent))
        print("Alignment:", str(effectiveStyleLevel.alignment))
        print("Font alignment:", str(effectiveStyleLevel.font_alignment))
```

## **有効フォント 高さの取得**

Aspose.Slides for Python via .NET を使用すると、有効フォント 高さを取得できます。以下の例は、プレゼンテーション構造の異なるレベルでローカル フォント 高さを設定したときに、テキスト部分の有効フォント 高さがどのように変化するかを示しています。

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

    print("作成直後の有効フォント高さ:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("プレゼンテーション全体のデフォルトフォント高さを設定した後の有効フォント高さ:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("段落のデフォルトフォント高さを設定した後の有効フォント高さ:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[0].portion_format.font_height = 55

    print("Portion #0 のフォント高さを設定した後の有効フォント高さ:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[1].portion_format.font_height = 18

    print("Portion #1 のフォント高さを設定した後の有効フォント高さ:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```

## **有効テーブル 塗りつぶし フォーマットの取得**

Aspose.Slides for Python via .NET を使用すると、テーブルのさまざまな論理パーツに対する有効な塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) クラスは、有効な塗りつぶし書式プロパティを保持しています。セルの書式は常に行の書式より優先され、行は列の書式より優先され、列はテーブル全体の書式より優先されます。

したがって、最終的にテーブルを描画する際に使用されるのは [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) のプロパティです。以下の例は、テーブルの各レベルの有効塗りつぶし書式を取得する方法を示しています。

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

**「スナップショット」か「ライブオブジェクト」かを判断する方法、そして有効プロパティを再取得すべきタイミングは？**

EffectiveData オブジェクトは、呼び出し時点で計算された値のイミュータブルなスナップショットです。シェイプのローカルまたは継承設定を変更した場合は、再度 EffectiveData を取得して更新された値を取得してください。

**レイアウト/マスタースライドを変更した場合、すでに取得した有効プロパティに影響はありますか？**

はい、ただし再取得したときにのみ反映されます。既に取得した EffectiveData オブジェクトは自動で更新されません—レイアウトやマスターを変更した後に再度取得してください。

**EffectiveData を通じて値を変更できますか？**

できません。EffectiveData は読み取り専用です。ローカルの書式オブジェクト (シェイプ/テキスト/3D など) を変更し、必要に応じて再度有効値を取得してください。

**シェイプレベルでもレイアウト/マスターでも全体設定でもプロパティが設定されていない場合は？**

有効値はデフォルトのメカニズム (PowerPoint/Aspose.Slides のデフォルト) によって決定されます。その解決された値が EffectiveData のスナップショットに含まれます。

**有効フォント値から、どのレベルがサイズやフォント名を提供したか判断できますか？**

直接はできません。EffectiveData は最終的な値だけを返します。どのレベルが最初に明示的に定義されたかを知りたい場合は、ポーション/段落/テキストフレームのローカル値や、レイアウト/マスター/プレゼンテーションのテキストスタイルを確認してください。

**有効データの値がローカル値と同じに見えるのはなぜですか？**

ローカル値が最終的な値となり、上位レベルからの継承が不要だったためです。その場合、有効値はローカル値と一致します。

**有効プロパティを使用すべきタイミングと、ローカルプロパティだけで作業すべきタイミングは？**

すべての継承が適用された「描画結果」を必要とする場合 (例: 色・インデント・サイズの整合) は EffectiveData を使用してください。特定のレベルで書式を変更したい場合はローカルプロパティを操作し、必要に応じて再度 EffectiveData を取得して結果を確認してください。