---
title: Python で WordArt 効果を作成して適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/python-net/wordart/
keywords:
- WordArt
- WordArt を作成
- WordArt テンプレート
- WordArt 効果
- 影効果
- ディスプレイ効果
- 光彩効果
- WordArt 変形
- 3D 効果
- 外側影効果
- 内側影効果
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET で WordArt 効果を作成およびカスタマイズする方法を学びます。このステップバイステップガイドは、開発者が Python でスタイリッシュでプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---

## **WordArt とは？**
WordArt（Word Art）は、テキストに効果を適用して目立たせる機能です。たとえば、テキストにアウトラインを付けたり、色（またはグラデーション）で塗りつぶしたり、3D 効果を加えたりできます。また、テキストの形状を傾けたり、曲げたり、伸ばしたりすることもできます。

{{% alert color="primary" %}} 

WordArt は、テキストをグラフィックオブジェクトのように扱うことができます。WordArt は、テキストをより魅力的または目立たせるために加える効果や特別な加工のことです。 

{{% /alert %}} 

**Microsoft PowerPoint の WordArt**

Microsoft PowerPoint で WordArt を使用するには、事前定義された WordArt テンプレートのいずれかを選択する必要があります。WordArt テンプレートは、テキストまたはその形状に適用される一連の効果です。 

**Aspose.Slides の WordArt**

Aspose.Slides for Python via .NET 20.10 で WordArt のサポートを実装し、その後のリリースで機能を改善しました。 

Aspose.Slides for Python via .NET を使用すると、Python で独自の WordArt テンプレート（単一効果または効果の組み合わせ）を簡単に作成し、テキストに適用できます。 

## シンプルな WordArt テンプレートの作成とテキストへの適用

**Aspose.Slides の使用** 

まず、次の Python コードでシンプルなテキストを作成します: 
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

次に、以下のコードでテキストのフォント高さを大きく設定し、効果を目立たせます:
```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```


**Microsoft PowerPoint の使用**

Microsoft PowerPoint の WordArt 効果メニューに移動します:

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから事前定義された WordArt 効果を選択できます。左側のメニューから新しい WordArt の設定を指定できます。 

利用可能なパラメーターまたはオプションの一部は次のとおりです:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides の使用**

ここでは、SmallGrid パターンカラーをテキストに適用し、幅 1 の黒いテキスト枠線を追加するコードを示します:
```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```


結果のテキスト:

![todo:image_alt_text](image-20200930114108-4.png)

## 他の WordArt 効果の適用

**Microsoft PowerPoint の使用**

プログラムのインターフェイスから、テキスト、テキストブロック、図形、または類似の要素に次の効果を適用できます:

![todo:image_alt_text](image-20200930114129-5.png)

例として、影（Shadow）、反射（Reflection）、光彩（Glow）効果はテキストに適用でき、3D 形式（3D Format）と 3D 回転（3D Rotation）効果はテキストブロックに適用できます。ソフトエッジ（Soft Edges）プロパティは図形オブジェクトに適用でき（3D Format が設定されていなくても効果があります）。

### 影（Shadow）効果の適用

ここではテキストのみのプロパティを設定します。次の Python コードでテキストに影効果を適用します:
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


Aspose.Slides API は、OuterShadow、InnerShadow、PresetShadow の 3 種類の影をサポートしています。 

PresetShadow を使用すると、事前設定値でテキストに影を適用できます。 

**Microsoft PowerPoint の使用**

PowerPoint では 1 種類の影だけを使用できます。例を示します:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides の使用**

Aspose.Slides は、InnerShadow と PresetShadow の 2 種類の影を同時に適用できます。

**注意:**

- OuterShadow と PresetShadow を同時に使用すると、OuterShadow の効果のみが適用されます。 
- OuterShadow と InnerShadow を同時に使用した場合、適用される効果は PowerPoint のバージョンに依存します。たとえば、PowerPoint 2013 では効果が二重に適用されますが、PowerPoint 2007 では OuterShadow のみが適用されます。 

### テキストへのディスプレイ効果の適用

次の Python サンプルでテキストにディスプレイ効果を追加します:
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


### テキストへの光彩（Glow）効果の適用

次のコードでテキストに光彩効果を適用し、輝かせます:
```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```


操作結果:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

影、ディスプレイ、光彩のパラメーターは個別に変更できます。各テキスト部分ごとに効果のプロパティが設定されます。 

{{% /alert %}} 

### WordArt の変形（Transform）使用

次のコードでテキスト全体に対して Transform プロパティ（固有の変形）を使用します:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```


結果:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint と Aspose.Slides for Python via .NET の両方が、事前定義された変形タイプをいくつか提供しています。 

{{% /alert %}} 

**PowerPoint の使用**

事前定義された変形タイプにアクセスするには、**Format** → **TextEffect** → **Transform** の順に選択します。

**Aspose.Slides の使用**

変形タイプを選択するには、`TextShapeType` 列挙型を使用します。 

### テキストおよび図形への 3D 効果の適用

次のサンプルコードでテキスト形状に 3D 効果を設定します:
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


結果のテキストと形状:

![todo:image_alt_text](image-20200930114816-9.png)

次の Python コードでテキストに 3D 効果を適用します:
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


操作結果:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

テキストまたはその形状への 3D 効果の適用と効果間の相互作用は、特定の規則に基づいています。 

テキストとテキストを含む形状のシーンを考えてみてください。3D 効果は 3D オブジェクトの表現と、オブジェクトが配置されたシーンを含みます。 

- 図形とテキストの両方にシーンが設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。 
- 図形に固有のシーンがなく 3D 表現がある場合、テキストのシーンが使用されます。 
- それ以外の場合（図形に元々 3D 効果がない場合）は、図形は平面のままで、3D 効果はテキストのみに適用されます。 

これらの説明は、[ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) と [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) プロパティに関連しています。 

{{% /alert %}} 

## **テキストへの外側影（Outer Shadow）効果の適用**
Aspose.Slides for Python via .NET は、テキストフレームが保持するテキストに影効果を適用できる [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) と [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) クラスを提供します。以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに矩形タイプの AutoShape を追加します。  
4. AutoShape に関連付けられた TextFrame にアクセスします。  
5. AutoShape の FillType を NoFill に設定します。  
6. OuterShadow クラスのインスタンスを作成します。  
7. 影の BlurRadius を設定します。  
8. 影の Direction を設定します。  
9. 影の Distance を設定します。  
10. RectanglelAlign を TopLeft に設定します。  
11. 影の PresetColor を Black に設定します。  
12. プレゼンテーションを書き出して PPTX ファイルに保存します。  

上記手順を実装した Python のサンプルコードは、テキストに外側影効果を適用する方法を示しています:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # スライドの参照を取得
    sld = pres.slides[0]

    # 矩形タイプの AutoShape を追加
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # 矩形に TextFrame を追加
    ashp.add_text_frame("Aspose TextBox")

    # テキストの影を取得できるようにシェイプの塗りを無効化
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 外側の影を追加し、必要なパラメータをすべて設定
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #プレゼンテーションをディスクに保存
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **図形への内側影（Inner Shadow）効果の適用**
以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. スライドの参照を取得します。  
3. 矩形タイプの AutoShape を追加します。  
4. InnerShadowEffect を有効にします。  
5. 必要なすべてのパラメーターを設定します。  
6. ColorType を Scheme に設定します。  
7. Scheme Color を設定します。  
8. プレゼンテーションを書き出して [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルに保存します。  

上記手順に基づくサンプルコードは、Python で 2 つの図形間にコネクタを追加する方法を示しています:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # スライドの参照を取得
    slide = presentation.slides[0]

    # 矩形タイプの AutoShape を追加
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 矩形に TextFrame を追加
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # inner_shadow_effect を有効化    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # 必要なすべてのパラメータを設定
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # ColorType を Scheme として設定
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Scheme カラーを設定
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # プレゼンテーションを保存
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**異なるフォントやスクリプト（例：アラビア語、中国語）でも WordArt 効果を使用できますか？**

はい、Aspose.Slides は Unicode をサポートし、主要なフォントやスクリプトすべてで動作します。影、塗りつぶし、アウトラインなどの WordArt 効果は言語に関係なく適用できますが、フォントの有無や描画はシステムにインストールされているフォントに依存する場合があります。

**スライドマスタの要素に WordArt 効果を適用できますか？**

はい、マスタースライド上の図形（タイトルプレースホルダー、フッター、背景テキストなど）に WordArt 効果を適用できます。マスターのレイアウトを変更すると、関連付けられたすべてのスライドに反映されます。

**WordArt 効果はプレゼンテーションのファイルサイズに影響しますか？**

若干影響します。影、光彩、グラデーション塗りつぶしなどの効果は、追加の書式設定メタデータを含むためファイルサイズがわずかに増加しますが、差は通常は無視できる程度です。

**プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？**

はい、[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) または [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) クラスの `get_image` メソッドを使用して、WordArt を含むスライドを PNG や JPEG などの画像にレンダリングできます。これにより、プレゼンテーション全体を保存またはエクスポートする前に、メモリ上または画面上で結果をプレビューできます。