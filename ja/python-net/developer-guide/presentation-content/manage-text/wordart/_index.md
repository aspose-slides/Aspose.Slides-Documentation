---
title: WordArt
type: docs
weight: 110
url: /ja/python-net/wordart/
keywords: "WordArt, Word Art, WordArtの作成, WordArtテンプレート, WordArt効果, シャドウ効果, 表示効果, グロー効果, WordArt変換, 3D効果, 外側シャドウ効果, 内側シャドウ効果, Python, Aspose.Slides for Python via .NET"
description: "PythonまたはAspose.Slides for Python via .NETを使用してPowerPointプレゼンテーションにWordArtと効果を追加、操作、管理します。"
---

## **WordArtとは？**
WordArtまたはWord Artは、テキストに効果を適用して際立たせる機能です。たとえば、WordArtを使えば、テキストをアウトライン化したり、色（またはグラデーション）で塗りつぶしたり、3D効果を追加したりできます。また、テキストの形を歪めたり、曲げたり、伸ばしたりすることもできます。

{{% alert color="primary" %}}

WordArtは、テキストをグラフィックオブジェクトのように扱うことを可能にします。WordArtは、テキストをより魅力的または目立たせるための効果や特別な変更で構成されています。

{{% /alert %}}

**Microsoft PowerPointのWordArt**

Microsoft PowerPointでWordArtを使用するには、定義済みのWordArtテンプレートの1つを選択する必要があります。WordArtテンプレートは、テキストまたはその形に適用される効果のセットです。

**Aspose.SlidesのWordArt**

Aspose.Slides for Python via .NET 20.10では、WordArtのサポートを実装し、その後のAspose.Slides for Python via .NETリリースで機能を改善しました。

Aspose.Slides for Python via .NETを使用すると、Pythonで独自のWordArtテンプレート（効果または効果の組み合わせ）を簡単に作成し、それをテキストに適用できます。

## 簡単なWordArtテンプレートを作成し、テキストに適用する

**Aspose.Slidesの使用**

まず、このPythonコードを使用して簡単なテキストを作成します：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
次に、テキストのフォント高さを大きな値に設定して、効果をより目立たせるためにこのコードを使用します：

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Microsoft PowerPointの使用**

Microsoft PowerPointのWordArt効果メニューに移動します：

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから、定義済みのWordArt効果を選択できます。左側のメニューから、新しいWordArtの設定を指定できます。

これらは利用可能なパラメーターまたはオプションの一部です：

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slidesの使用**

ここでは、SmallGridパターンカラーをテキストに適用し、このコードを使用して1幅の黒いテキスト境界線を追加します：

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

結果のテキスト：

![todo:image_alt_text](image-20200930114108-4.png)

## 他のWordArt効果を適用する

**Microsoft PowerPointの使用**

プログラムのインターフェイスから、テキスト、テキストブロック、形状、または類似の要素にこれらの効果を適用できます：

![todo:image_alt_text](image-20200930114129-5.png)

たとえば、シャドウ、反射、グロー効果はテキストに適用できます。3Dフォーマットと3D回転効果はテキストブロックに適用できます。ソフトエッジプロパティは形状オブジェクトに適用できます（3Dフォーマットプロパティが設定されていない場合でも効果があります）。

### シャドウ効果を適用する

ここでは、テキストに関連するプロパティを設定することを目的としています。このコードを使用して、テキストにシャドウ効果を適用します：

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Aspose.Slides APIは3種類のシャドウをサポートしています：OuterShadow、InnerShadow、PresetShadow。

PresetShadowを使用すると、テキストにシャドウを適用できます（プリセット値を使用）。

**Microsoft PowerPointの使用**

PowerPointでは、1種類のシャドウを使用できます。以下に例を示します：

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slidesの使用**

Aspose.Slidesでは、実際には2種類のシャドウを同時に適用できます：InnerShadowとPresetShadow。

**注意：**

- OuterShadowとPresetShadowを同時に使用すると、OuterShadow効果のみが適用されます。
- OuterShadowとInnerShadowを同時に使用すると、結果または適用される効果はPowerPointのバージョンによって異なります。たとえば、PowerPoint 2013では効果が2重になります。しかし、PowerPoint 2007ではOuterShadow効果のみが適用されます。

### テキストに表示を適用する

このコードサンプルを使用して、テキストに表示を追加します：

```py 
    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5 
    portion.portion_format.effect_format.reflection_effect.distance = 4.72 
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0 
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90 
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100 
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT  
```

### テキストにグロー効果を適用する

このコードを使用して、テキストにグロー効果を適用し、輝かせたり目立たせたりします：

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

操作の結果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

シャドウ、表示、グローのパラメーターを変更できます。効果のプロパティはテキストの各部分に対して個別に設定されます。

{{% /alert %}} 

### WordArtで変換を使用する

このコードを通じて、テキスト全体のブロックに固有のTransformプロパティを使用します：
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

結果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPointとAspose.Slides for Python via .NETの両方に、定義済みの変換タイプがいくつか用意されています。

{{% /alert %}} 

**PowerPointの使用**

定義済みの変換タイプにアクセスするには、**フォーマット** -> **テキスト効果** -> **変換**に進みます。

**Aspose.Slidesの使用**

変換タイプを選択するには、TextShapeType列挙体を使用します。

### テキストおよび形状に3D効果を適用する

このサンプルコードを使用して、テキスト形状に3D効果を設定します：

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

結果のテキストとその形状：

![todo:image_alt_text](image-20200930114816-9.png)

このPythonコードを使用してテキストに3D効果を適用します：

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

操作の結果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

テキストまたはその形状に3D効果を適用する場合、効果の相互作用は特定のルールに基づきます。

テキストとそのテキストを含む形状のシーンを考えてみてください。3D効果は3Dオブジェクトの表現と、そのオブジェクトが置かれるシーンを含みます。

- シーンが図形とテキストの両方に設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。
- 図形に独自のシーンがなく、3D表現を持っている場合、テキストのシーンが使用されます。
- それ以外の場合—形状が最初に3D効果を持たない場合、形状は平坦で、3D効果はテキストにのみ適用されます。

これらの説明は、[ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/)および[ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/)プロパティに関連しています。

{{% /alert %}} 

## **テキストに外側シャドウ効果を適用する**
Aspose.Slides for Python via .NETは、[**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/)および[**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/)クラスを提供しており、TextFrameによって運ばれるテキストにシャドウ効果を適用できます。これらのステップを進めてください：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに長方形のAutoShapeを追加します。
4. AutoShapeに関連付けられたTextFrameにアクセスします。
5. AutoShapeのFillTypeをNoFillに設定します。
6. OuterShadowクラスのインスタンスを生成します。
7. シャドウのBlurRadiusを設定します。
8. シャドウのDirectionを設定します。
9. シャドウのDistanceを設定します。
10. RectangleAlignをTopLeftに設定します。
11. シャドウのPresetColorをBlackに設定します。
12. プレゼンテーションをPPTXファイルとして書き出します。

以下のPythonのサンプルコードは、上記のステップの実装であり、テキストに外側シャドウ効果を適用する方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # スライドの参照を取得
    sld = pres.slides[0]

    # 長方形のAutoShapeを追加
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # 長方形にTextFrameを追加
    ashp.add_text_frame("Aspose TextBox")

    # テキストのシャドウを取得するために形状の塗りつぶしを無効にします
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 外側シャドウを追加し、すべての必要なパラメーターを設定します
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    # プレゼンテーションをディスクに書き込みます
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **形状に内側シャドウ効果を適用する**
次の手順を進めてください：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 長方形のAutoShapeを追加します。
4. InnerShadowEffectを有効にします。
5. 必要なすべてのパラメーターを設定します。
6. ColorTypeをSchemeに設定します。
7. Scheme Colorを設定します。
8. プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして書き出します。

以下のサンプルコード（上記の手順に基づく）は、Pythonで2つの形状の間にコネクタを追加する方法を示します：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # スライドの参照を取得
    slide = presentation.slides[0]

    # 長方形のAutoShapeを追加
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 長方形にTextFrameを追加
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # 内側シャドウ効果を有効にします    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # 必要なすべてのパラメーターを設定します
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # ColorTypeをSchemeに設定
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Scheme Colorを設定
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # プレゼンテーションを保存します
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```