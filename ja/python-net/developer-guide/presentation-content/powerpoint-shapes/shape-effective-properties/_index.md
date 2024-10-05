---
title: 効果的な図形プロパティ
type: docs
weight: 50
url: /python-net/shape-effective-properties/
keywords: "図形プロパティ, カメラプロパティ, ライトリグ, ベベル形状, テキストフレーム, テキストスタイル, フォント高さ値, テーブルの塗りつぶしフォーマット, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションの効果的な図形プロパティを取得する"
---

このトピックでは、**効果的**および**ローカル**プロパティについて説明します。これらのレベルで値を直接設定する場合

1. ポーションのスライド上でのポーションプロパティ。
2. レイアウトまたはマスター スライド上でのプロトタイプ図形テキストスタイル（ポーションのテキストフレームがある場合）。
3. プレゼンテーションのグローバルテキスト設定。

その場合、それらの値は**ローカル**値と呼ばれます。任意のレベルで、**ローカル**値は定義されるか、省略される可能性があります。しかし、最終的にアプリケーションがポーションがどのように見えるべきかを知る必要があるとき、**効果的**な値を使用します。ローカルフォーマットから**getEffective()**メソッドを使用して効果的な値を取得できます。

次の例は、効果的な値を取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    localTextFrameFormat = shape.text_frame.text_frame_format
    effectiveTextFrameFormat = localTextFrameFormat.get_effective()

    localPortionFormat = shape.text_frame.paragraphs[0].portions[0].portion_format
    effectivePortionFormat = localPortionFormat.get_effective()
```



## **カメラの効果的なプロパティの取得**
Aspose.Slides for Python via .NETは、開発者がカメラの効果的なプロパティを取得できるようにします。この目的のために、**CameraEffectiveData**クラスがAspose.Slidesに追加されています。CameraEffectiveDataクラスは、効果的なカメラプロパティを含む不変オブジェクトを表します。**CameraEffectiveData**クラスのインスタンスは、ThreeDFormatクラスの効果的な値のペアである**ThreeDFormatEffectiveData**クラスの一部として使用されます。

次のコードサンプルは、カメラの効果的なプロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= 効果的なカメラプロパティ =")
	print("タイプ: " + str(threeDEffectiveData.camera.camera_type))
	print("視野: " + str(threeDEffectiveData.camera.field_of_view_angle))
	print("ズーム: " + str(threeDEffectiveData.camera.zoom))
```


## **ライトリグの効果的なプロパティの取得**
Aspose.Slides for Python via .NETは、開発者がライトリグの効果的なプロパティを取得できるようにします。この目的のために、**LightRigEffectiveData**クラスがAspose.Slidesに追加されています。LightRigEffectiveDataクラスは、効果的なライトリグプロパティを含む不変オブジェクトを表します。**LightRigEffectiveData**クラスのインスタンスは、ThreeDFormatクラスの効果的な値のペアである**ThreeDFormatEffectiveData**クラスの一部として使用されます。

次のコードサンプルは、ライトリグの効果的なプロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= 効果的なライトリグプロパティ =")
	print("タイプ: " + str(threeDEffectiveData.light_rig.light_type))
	print("方向: " + str(threeDEffectiveData.light_rig.direction))
```


## **ベベル形状の効果的なプロパティの取得**
Aspose.Slides for Python via .NETは、開発者がベベル形状の効果的なプロパティを取得できるようにします。この目的のために、**ShapeBevelEffectiveData**クラスがAspose.Slidesに追加されています。ShapeBevelEffectiveDataクラスは、効果的な形状の面の浮き彫りプロパティを含む不変オブジェクトを表します。**ShapeBevelEffectiveData**クラスのインスタンスは、ThreeDFormatクラスの効果的な値のペアである**ThreeDFormatEffectiveData**クラスの一部として使用されます。

次のコードサンプルは、ベベル形状の効果的なプロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= 効果的な形状の上面浮き彫りプロパティ =")
	print("タイプ: " + str(threeDEffectiveData.bevel_top.bevel_type))
	print("幅: " + str(threeDEffectiveData.bevel_top.width))
	print("高さ: " + str(threeDEffectiveData.bevel_top.height))
```



## **テキストフレームの効果的なプロパティの取得**
Aspose.Slides for Python via .NETを使用すると、テキストフレームの効果的なプロパティを取得できます。この目的のために、**TextFrameFormatEffectiveData**クラスがAspose.Slidesに追加されており、効果的なテキストフレームの書式設定プロパティを含んでいます。

次のコードサンプルは、効果的なテキストフレームの書式設定プロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	shape = pres.slides[0].shapes[0]

	textFrameFormat = shape.text_frame.text_frame_format
	effectiveTextFrameFormat = textFrameFormat.get_effective()


	print("アンカータイプ: " + str(effectiveTextFrameFormat.anchoring_type))
	print("オートフィットタイプ: " + str(effectiveTextFrameFormat.autofit_type))
	print("テキストの垂直タイプ: " + str(effectiveTextFrameFormat.text_vertical_type))
	print("マージン")
	print("   左: " + str(effectiveTextFrameFormat.margin_left))
	print("   上: " + str(effectiveTextFrameFormat.margin_top))
	print("   右: " + str(effectiveTextFrameFormat.margin_right))
	print("   下: " + str(effectiveTextFrameFormat.margin_bottom))
```



## **テキストスタイルの効果的なプロパティの取得**
Aspose.Slides for Python via .NETを使用すると、テキストスタイルの効果的なプロパティを取得できます。この目的のために、**TextStyleEffectiveData**クラスがAspose.Slidesに追加されており、効果的なテキストスタイルのプロパティを含んでいます。

次のコードサンプルは、効果的なテキストスタイルのプロパティを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    effectiveTextStyle = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effectiveTextStyle.get_level(i)
        print("= スタイルレベル #" + str(i) + " の効果的な段落書式 =")

        print("深さ: " + str(effectiveStyleLevel.depth))
        print("インデント: " + str(effectiveStyleLevel.indent))
        print("配置: " + str(effectiveStyleLevel.alignment))
        print("フォント配置: " + str(effectiveStyleLevel.font_alignment))

```


## **フォント高さ値の取得**
Aspose.Slides for Python via .NETを使用すると、フォント高さの効果的なプロパティを取得できます。以下は、異なるプレゼンテーション構造レベルでローカルフォント高さ値を設定した後、ポーションの効果的なフォント高さ値が変更されることを示すコードです。

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    newShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    newShape.add_text_frame("")
    newShape.text_frame.paragraphs[0].portions.clear()

    portion0 = slides.Portion("最初のポーションを含むサンプルテキスト")
    portion1 = slides.Portion(" と2番目のポーション。")

    newShape.text_frame.paragraphs[0].portions.add(portion0)
    newShape.text_frame.paragraphs[0].portions.add(portion1)

    print("作成直後の効果的なフォント高さ:")
    print("ポーション #0: " + str(portion0.portion_format.get_effective().font_height))
    print("ポーション #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("全体のプレゼンテーションデフォルトフォント高さ設定後の効果的なフォント高さ:")
    print("ポーション #0: " + str(portion0.portion_format.get_effective().font_height))
    print("ポーション #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 40

    print("段落デフォルトフォント高さ設定後の効果的なフォント高さ:")
    print("ポーション #0: " + str(portion0.portion_format.get_effective().font_height))
    print("ポーション #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 55

    print("ポーション #0のフォント高さ設定後の効果的なフォント高さ:")
    print("ポーション #0: " + str(portion0.portion_format.get_effective().font_height))
    print("ポーション #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[1].portion_format.font_height = 18

    print("ポーション #1のフォント高さ設定後の効果的なフォント高さ:")
    print("ポーション #0: " + str(portion0.portion_format.get_effective().font_height))
    print("ポーション #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```


## **テーブルの効果的な塗りつぶしフォーマットの取得**
Aspose.Slides for Python via .NETを使用すると、異なるテーブル論理部分の効果的な塗りつぶしフォーマットを取得できます。この目的のために、**IFillFormatEffectiveData**インターフェースがAspose.Slidesに追加されており、効果的な塗りつぶしフォーマットのプロパティを含んでいます。セルフォーマットは常に行フォーマットよりも優先度が高く、行は列よりも優先度が高く、列はテーブル全体よりも優先度が高くなります。

したがって、最終的に**CellFormatEffectiveData**プロパティは常にテーブルを描画するために使用されます。次のコードサンプルは、異なるテーブル論理部分の効果的な塗りつぶしフォーマットを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
	tbl = pres.slides[0].shapes[0]
	tableFormatEffective = tbl.table_format.get_effective()
	rowFormatEffective = tbl.rows[0].row_format.get_effective()
	columnFormatEffective = tbl.columns[0].column_format.get_effective()
	cellFormatEffective = tbl[0, 0].cell_format.get_effective()

	tableFillFormatEffective = tableFormatEffective.fill_format
	rowFillFormatEffective = rowFormatEffective.fill_format
	columnFillFormatEffective = columnFormatEffective.fill_format
	cellFillFormatEffective = cellFormatEffective.fill_format
```