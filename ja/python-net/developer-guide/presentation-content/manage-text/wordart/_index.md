---
title: PythonでWordArt効果を作成して適用する
linktitle: ワードアート
type: docs
weight: 110
url: /ja/python-net/wordart/
keywords:
- ワードアート
- ワードアートを作成
- ワードアートテンプレート
- ワードアート効果
- 影効果
- 反射効果
- 光彩効果
- ワードアート変形
- 3D 効果
- 外側影効果
- 内側影効果
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET で WordArt 効果を作成およびカスタマイズします。このステップバイステップガイドは、開発者が Python でプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---
## **概要**

WordArt 効果を使用すると、塗りつぶし、アウトライン、影、反射、光彩、変形、3D 書式設定でテキストを装飾できます。本記事では、Microsoft Office をインストールせずに、Aspose.Slides for Python via .NET を使用して PowerPoint プレゼンテーションでこれらの効果を作成およびカスタマイズする方法を説明します。

## **シンプルなWordArtテンプレートを作成し、テキストに適用する**

以下の例では、テキスト、フォント、パターン塗りつぶし、アウトラインを設定してシンプルな WordArt スタイルを構築します。

各例は新しいプレゼンテーションを作成し、最初のスライドに矩形を追加します。入力ファイルは不要です。最初の例ではテキストを「Aspose.Slides」に設定します。図形の位置とサイズはポイント単位で測定されます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

フォントを Arial Black、サイズ 36 ポイントに設定して書式を目立たせます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

前景色をダークオレンジ、背景を白にした [SMALL_GRID](https://reference.aspose.com/slides/ja/python-net/aspose.slides/patternstyle/) パターンを適用し、幅 1 ポイントの黒いテキストアウトラインを追加します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

結果のテキスト:

![The simple WordArt template](WordArt_template.png)

## **その他のWordArt効果を適用する**

以下の例は、影、反射、光彩、変形、3D 効果をテキストに適用する方法を示します。

### **外側影効果を適用する**

外側影はテキストの背後に影を配置して奥行きを付加します。色、方向、距離、ぼかし半径、スケール、歪みをカスタマイズできます。

この例は [enable_outer_shadow_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) を呼び出し、ぼかし半径 4 ポイント、方向 230 度、距離 30 ポイントの黒い影を設定します。スケール 100 は影のサイズを保持し、水平歪みで 20 度傾けます。アルファ変換で不透明度を 32% に設定します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

結果のテキスト:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 外側影とプリセット影を同時に使用すると、外側影のみが適用されます。
- 外側影と内側影を同時に使用した場合、効果は PowerPoint のバージョンに依存します。たとえば PowerPoint 2013 では効果が二重になり、PowerPoint 2007 では外側影のみが適用されます。
{{% /alert %}}

### **反射効果を適用する**

反射はテキストの鏡像コピーを作成します。位置、スケール、ぼかし、透明度を調整して外観を制御できます。

この例は [enable_reflection_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides/effectformat/enable_reflection_effect/) を呼び出し、スケール -100% で垂直方向に反転させます。ぼかし半径 0.5 ポイント、距離 4.72 ポイントを使用します。透明度は 0% から 60% の位置で 60% から 0.9% に減少します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

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

結果のテキスト:

![The Reflection effect](reflection_effect.png)

### **光彩効果を適用する**

光彩はテキストの周囲に柔らかな色付き輪郭を追加します。色、透明度、半径を調整して効果を制御できます。

この例は [enable_glow_effect](https://reference.aspose.com/slides/ja/python-net/aspose.slides/effectformat/enable_glow_effect/) を呼び出し、透明度 54%、半径 7 ポイントの赤い光彩を適用します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

結果のテキスト:

![The Glow effect](glow_effect.png)

### **WordArt 変形を適用する**

WordArt の変形はテキストブロックを曲げたり、伸ばしたり、歪めたりします。

[transform](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/transform/) を [ARCH_UP_POUR](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textshapetype/) に設定すると、テキストフレーム全体が上向きにカーブします。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

結果のテキスト:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via .NET には、事前定義された多数の [変形タイプ](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textshapetype/) が用意されています。
{{% /alert %}}

### **図形とテキストに 3D 効果を適用する**

図形またはそのテキストに 3D 効果を適用できます。ベベル、押し出し、照明、カメラ設定が最終的な外観を制御します。

以下の例は [ThreeDFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/) を使用して、矩形に円形ベベル、オレンジ色の押し出し、濃い赤の輪郭を追加します。ベベルサイズ、押し出し高さ、輪郭幅、深さはすべてポイント単位です。プラスチック素材、Z 軸周りに 40 度回転したバランス照明、遠近カメラが外観を定義します。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

結果の図形:

![The shape 3D effect](shape_3D_effect.png)

この例は [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframeformat/three_d_format/) を使用してテキストにも同様の 3D 書式を適用します。小さなベベルが文字のエッジを形作り、押し出しと照明がテキストに奥行きを与えます。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

結果のテキスト:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
テキストまたはその図形に 3D 効果を適用する際のルールと、これらの効果間の相互作用は特定の規則に従います。テキストとそれを含む図形の両方がシーンを持つ場合を考えてみましょう。3D 効果はオブジェクトの 3D 表現と、そのオブジェクトが配置されるシーンの両方を含みます。

- 図形とテキストの両方にシーンが設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。
- 図形にシーンがなく 3D 表現だけがある場合、テキストのシーンが使用されます。
- 図形に 3D 効果がまったくない場合、平面として扱われ、3D 効果はテキストのみに適用されます。

これらの動作は [ThreeDFormat.light_rig](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/light_rig/) と [ThreeDFormat.camera](https://reference.aspose.com/slides/ja/python-net/aspose.slides/threedformat/camera/) プロパティに関連しています。
{{% /alert %}}

テキストを平坦に保ちつつ、図形の 3D 書式設定を残す方法については、[Keep Text Flat on a 3D Shape](/slides/ja/python-net/3d-presentation/) を参照してください。設定の比較と完全な Python サンプルが掲載されています。

## **FAQ**

**異なるフォントやスクリプト（例：アラビア語、中国語）でも WordArt 効果を使用できますか？**

はい、Aspose.Slides for Python via .NET は Unicode をサポートし、主要なフォントとスクリプトすべてで動作します。影、塗りつぶし、アウトラインなどの WordArt 効果は言語に関係なく適用できますが、フォントの可用性とレンダリングはシステムにインストールされているフォントに依存する場合があります。

**スライドマスタ要素に WordArt 効果を適用できますか？**

はい、マスタースライド上の図形（タイトルプレースホルダー、フッター、背景テキストなど）にも WordArt 効果を適用できます。マスター レイアウトに加えた変更は、関連するすべてのスライドに反映されます。

**WordArt 効果はプレゼンテーションのファイルサイズに影響しますか？**

わずかに影響します。影、光彩、グラデーション塗りつぶしなどの効果は、追加の書式メタデータが加わるためファイルサイズをほんの少し増加させますが、差は通常は無視できる程度です。

**プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？**

はい、[Slide.get_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/) を使用して WordArt を含むスライドを画像（PNG、JPEG など）にレンダリングしたり、[Shape.get_image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_image/) で個々の図形を画像化したりできます。これにより、保存やエクスポートを行う前にメモリ上または画面上で結果をプレビューできます。