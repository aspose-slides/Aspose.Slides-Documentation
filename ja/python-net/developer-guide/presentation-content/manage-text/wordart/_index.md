---
title: PythonでWordArt効果を作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/python-net/wordart/
keywords:
- WordArt
- WordArtの作成
- WordArtテンプレート
- WordArt効果
- 陰影効果
- 表示効果
- 輝き効果
- WordArt変形
- 3D効果
- 外側陰影効果
- 内側陰影効果
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NETでWordArt効果を作成およびカスタマイズする方法を学びます。このステップバイステップガイドは、開発者がPythonでスタイリッシュでプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---

## **WordArtとは？**
WordArt（またはWord Art）は、テキストに効果を適用して目立たせる機能です。たとえば、WordArtを使用するとテキストに輪郭を付けたり、色（またはグラデーション）で塗りつぶしたり、3D効果を追加したりできます。また、テキストの形状を歪めたり、曲げたり、伸ばしたりすることも可能です。

{{% alert color="primary" %}} 
WordArtはテキストをグラフィックオブジェクトのように扱うことができます。WordArtは、テキストをより魅力的または目立たせるために加えられる効果や特別な加工で構成されています。 
{{% /alert %}} 

**Microsoft PowerPoint の WordArt**

Microsoft PowerPointでWordArtを使用するには、事前定義されたWordArtテンプレートのいずれかを選択する必要があります。WordArtテンプレートは、テキストまたはその形状に適用される効果のセットです。

**Aspose.Slides の WordArt**

Aspose.Slides for Python via .NET 20.10では、WordArtのサポートを実装し、以降のリリースで機能の改善を行いました。

Aspose.Slides for Python via .NETを使用すれば、Pythonで独自のWordArtテンプレート（単一の効果または複数の効果の組み合わせ）を簡単に作成し、テキストに適用できます。

## シンプルなWordArtテンプレートを作成しテキストに適用する

**Aspose.Slides の使用** 

まず、以下のPythonコードでシンプルなテキストを作成します。 

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

次に、以下のコードでテキストのフォント高さを大きく設定し、効果をより目立たせます。

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Microsoft PowerPoint の使用**

Microsoft PowerPointのWordArt効果メニューに移動します：

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから事前定義されたWordArt効果を選択できます。左側のメニューで新しいWordArtの設定を指定できます。

以下は利用可能なパラメータまたはオプションの一部です。

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides の使用**

ここでは、SmallGridパターンの色をテキストに適用し、幅1の黒いテキスト枠線を追加するコードです。

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

## その他のWordArt効果の適用

**Microsoft PowerPoint の使用**

プログラムのインターフェイスから、テキスト、テキストブロック、シェイプ、または類似の要素にこれらの効果を適用できます：

![todo:image_alt_text](image-20200930114129-5.png)

例として、Shadow、Reflection、Glow効果はテキストに適用でき、3D Format と 3D Rotation 効果はテキストブロックに適用できます。Soft Edges プロパティは Shape オブジェクトに適用可能で（3D Format プロパティが設定されていなくても効果があります）。

### 影効果の適用

ここでは、テキストにのみ関連するプロパティを設定します。以下のPythonコードでテキストに影効果を適用します。

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

Aspose.Slides APIは、OuterShadow、InnerShadow、PresetShadowの3種類の影をサポートしています。

PresetShadowを使用すると、事前設定された値でテキストに影を適用できます。

**Microsoft PowerPoint の使用**

PowerPointでは1種類の影を使用できます。以下は例です。

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides の使用**

Aspose.Slidesでは、実際にInnerShadowとPresetShadowの2種類の影を同時に適用できます。

**注意点:**

- OuterShadow と PresetShadow を同時に使用すると、OuterShadow の効果のみが適用されます。
- OuterShadow と InnerShadow を同時に使用した場合、適用される効果は PowerPoint のバージョンに依存します。たとえば PowerPoint 2013 では効果が倍になる一方、PowerPoint 2007 では OuterShadow の効果が適用されます。

### テキストへのディスプレイ効果の適用

以下のPythonサンプルコードでテキストにディスプレイ効果を追加します。

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

### テキストへのグロー効果の適用

以下のコードでテキストにグロー効果を適用し、光らせたり目立たせたりします。

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

操作の結果:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
影、ディスプレイ、グローのパラメータは変更可能です。効果のプロパティはテキストの各ポーションごとに個別に設定されます。 
{{% /alert %}} 

### WordArt の変形の使用

以下のコードで、テキスト全体に固有の Transform プロパティを使用します。

```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

結果:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint と Aspose.Slides for Python via .NET の両方が、いくつかの事前定義された変形タイプを提供しています。 
{{% /alert %}} 

**PowerPoint の使用**

事前定義された変形タイプにアクセスするには、**Format** → **TextEffect** → **Transform** の順に進みます。

**Aspose.Slides の使用**

変形タイプを選択するには、TextShapeType 列挙体を使用します。

### テキストとシェイプへの3D効果の適用

以下のサンプルコードでテキストシェイプに3D効果を設定します。

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

結果のテキストとそのシェイプ:

![todo:image_alt_text](image-20200930114816-9.png)

以下のPythonコードでテキストに3D効果を適用します。

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

操作の結果:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
テキストまたはそのシェイプへの3D効果の適用と、効果間の相互作用は特定のルールに基づいています。

テキストとそのテキストを含むシェイプのシーンを考えてみましょう。3D効果は3Dオブジェクトの表現と、オブジェクトが配置されたシーンを含みます。

- シェイプとテキストの両方にシーンが設定されている場合、シェイプのシーンが優先され、テキストのシーンは無視されます。
- シェイプに独自のシーンがなく3D表現がある場合、テキストのシーンが使用されます。
- それ以外の場合、つまりシェイプ自体に3D効果がない場合、シェイプは平面のままで、3D効果はテキストにのみ適用されます。

これらの説明は、[ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) および [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) プロパティに関連しています。 
{{% /alert %}} 

## **テキストへの外側陰影効果の適用**
Aspose.Slides for Python via .NET は、テキストフレームに含まれるテキストに陰影効果を適用できる [**IOuterShadow**]（https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/） および [**IInnerShadow**]（https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/） クラスを提供します。以下の手順に従ってください：

1. Presentation クラスのインスタンスを作成します。
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
12. プレゼンテーションを PPTX ファイルとして保存します。

以下のPythonサンプルコードは、上記手順の実装例で、テキストに外側陰影効果を適用する方法を示しています。

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

    # テキストの陰影を取得するためにシェイプの塗りつぶしを無効化
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 外側陰影を追加し、必要なパラメータをすべて設定
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    # プレゼンテーションをディスクに保存
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **シェイプへの内側陰影効果の適用**
以下の手順に従ってください。

1. Presentation クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 矩形タイプの AutoShape を追加します。
4. InnerShadowEffect を有効にします。
5. 必要なパラメータをすべて設定します。
6. ColorType を Scheme に設定します。
7. Scheme Color を設定します。
8. プレゼンテーションを PPTX ファイルとして保存します。

以下のサンプルコード（上記手順に基づく）は、Pythonでシェイプに内側陰影効果を追加する方法を示します。

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

    # 必要なパラメータをすべて設定
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # ColorType を Scheme に設定
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Scheme Color を設定
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # プレゼンテーションを保存
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**異なるフォントやスクリプト（例：アラビア語、中国語）でWordArt効果を使用できますか？**

はい、Aspose.Slides はUnicodeをサポートしており、主要なフォントやスクリプトすべてで動作します。影、塗り、輪郭などのWordArt効果は言語に関係なく適用できますが、フォントの利用可否や描画はシステムフォントに依存する場合があります。

**スライドマスタ要素にWordArt効果を適用できますか？**

はい、マスタースライド上のシェイプ（タイトルプレースホルダー、フッター、背景テキストなど）にもWordArt効果を適用できます。マスターのレイアウトを変更すると、関連付けられたすべてのスライドに反映されます。

**WordArt効果はプレゼンテーションのファイルサイズに影響しますか？**

若干影響します。影やグロー、グラデーション塗りなどのWordArt効果は、追加の書式メタデータを伴うためファイルサイズがわずかに増加しますが、差は通常は無視できる程度です。

**プレゼンテーションを保存せずにWordArt効果の結果をプレビューできますか？**

はい、[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) や [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) クラスの`get_image`メソッドを使用して、WordArtを含むスライドを画像（PNG、JPEG など）としてレンダリングできます。これにより、保存やエクスポート前にメモリ上または画面上で結果をプレビューできます。