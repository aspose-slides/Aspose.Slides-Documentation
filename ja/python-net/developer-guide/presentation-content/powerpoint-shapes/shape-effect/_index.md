---
title: Python でプレゼンテーションに図形エフェクトを適用
linktitle: 図形エフェクト
type: docs
weight: 30
url: /ja/python-net/shape-effect
keywords:
- 図形エフェクト
- 影エフェクト
- 反射エフェクト
- グローエフェクト
- ソフトエッジエフェクト
- エフェクトフォーマット
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して、PPT、PPTX、ODP ファイルに高度な図形エフェクトを適用し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **はじめに**

PowerPoint のエフェクトは図形を際立たせるために使用できますが、[塗りつぶし](/slides/ja/python-net/shape-formatting/#gradient-fill)や輪郭とは異なります。PowerPoint のエフェクトを使用すると、図形にリアルな反射を作成したり、図形のグローを広げたりすることができます。

![図形エフェクト](shape-effect.png)

PowerPoint には図形に適用できる 6 つのエフェクトが用意されています。1 つまたは複数のエフェクトを図形に適用できます。

エフェクトの組み合わせの中には、他よりも見栄えが良いものがあります。そのため、PowerPoint では **Preset**（プリセット）オプションが用意されています。プリセットオプションは、2 つ以上のエフェクトの見栄えの良い組み合わせをあらかじめ定義したものです。プリセットを選択することで、時間をかけてエフェクトをテストしたり組み合わせたりして、良い組み合わせを見つける手間が省けます。

Aspose.Slides は、[EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供し、PowerPoint プレゼンテーションの図形に同じエフェクトを適用できます。

## **影エフェクトの適用**

Aspose.Slides for Python via .NET は、図形に対して外側シャドウと内側シャドウをサポートしています。色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側シャドウの適用**

外側シャドウを使用すると、カードやパネルをスライドの背景から際立たせることができます。シャドウは図形のエッジの外側まで広がり、図形がスライド上に浮き上がっているように見えます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この Python コードは、矩形に[外側シャドウ エフェクト](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/)を適用する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![シャドウ エフェクト](shadow_effect.png)

### **内側シャドウの適用**

テンプレートのビジュアルスタイルを再現する際は、内側シャドウを使用してカードやパネルに凹んだ外観を与えます。外側シャドウは図形の外側に広がり、浮き上がって見えるのに対し、内側シャドウはエッジの内側を陰影付けします。

[enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) を呼び出し、次に [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) を設定します。ぼかし半径の値が大きいほど、エッジが柔らかくなります。

この Python の例は、ライトブルーのカードにダークグレーの内側シャドウを付け、PPTX ファイルとして保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![内側シャドウ付きのライトブルー矩形](inner_shadow_effect.png)

内側シャドウを削除するには、図形の EffectFormat で [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) を呼び出します。

### **プリセットシャドウの適用、変更、削除**

[enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) を呼び出し、シャドウの[preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) プロパティに [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) の値を設定します。スタイルを切り替えるには、同じ図形のプリセットを変更します。[disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) を呼び出すと、塗りつぶしと輪郭は保持したままシャドウを削除できます。

この例は、1 枚のスライド上で 4 つの段階を横に並べて示しています。各変更前に矩形を複製して結果を比較できるようにしています。両方のシャドウは 10 ポイントオフセットされています。方向 225° は最初のシャドウを矩形の左上に配置し、方向 45° は2 番目のシャドウを右下に配置します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| オリジナル | 最初のプリセット | 2 番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![影なし](preset_shadow_original.png) | ![左上ドロップシャドウ](preset_shadow_top_left.png) | ![右下ドロップシャドウ](preset_shadow_bottom_right.png) | ![削除後の影なし](preset_shadow_removed.png) |

## **反射エフェクトの適用**

Aspose.Slides for Python via .NET で反射エフェクトを適用するには、図形に鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。このエフェクトは、図形に洗練された外観を与え、プレゼンテーションの美しさを向上させます。シンプルなコードで簡単に実装でき、複数の要素に一貫したデザインを素早く適用できます。

この Python コードは、図形に[反射エフェクト](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/)を適用する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![反射エフェクト](reflection_effect.png)

## **グローエフェクトの適用**

Aspose.Slides for Python via .NET でグローエフェクトを適用すると、図形の周囲に柔らかく光るオーラを追加し、色やサイズなどのプロパティを調整できます。このエフェクトは図形を目立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の外観を向上させます。

この Python コードは、図形に[グロー エフェクト](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/)を適用する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![グローエフェクト](glow_effect.png)

## **ソフトエッジエフェクトの適用**

Aspose.Slides for Python via .NET でソフトエッジエフェクトを適用すると、図形のエッジ周辺に滑らかでぼかされた遷移を作成できます。このエフェクトは、より繊細で洗練された外観を加え、柔らかな外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に目的の効果を実現できます。

この Python コードは、図形に[ソフトエッジ](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/)を適用する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![ソフトエッジエフェクト](soft_edges_effect.png)

## **ぼかしエフェクトの適用**

形状ブラーを使用すると、図形の塗りつぶしと輪郭を柔らかくしながら、図形を編集可能なままにできます。図形の EffectFormat で [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) を呼び出します。半径はポイント（1/72 インチ）で測定され、非負の値を指定します。値が大きいほどブラーが強くなります。半径が 0 の場合、外観は変わりません。

[grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) 設定はエフェクトの可視境界を制御します。`False` の場合、ブラーは元の描画境界（輪郭を含む）にクリップされます。`True` の場合、ブラーはその境界を超えて広がることができます。どちらの設定も図形の位置やサイズは変更しません。

以下の比較では、同じ塗りつぶし、輪郭、図形サイズを使用しています。上段は `grow = False`、下段は `grow = True` を使用しています。

![ぼかし半径5ポイントと15ポイント、grow無効・有効の比較（元の矩形）](shape_blur_comparison.png)

この Python の例は、オレンジ色の矩形にダークブルーの輪郭を付け、5 ポイントのブラーを適用し、その後 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) を再度呼び出して 15 ポイントのブラーに更新します。両方のブラー状態を保存し、次に [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) を呼び出してブラーなしの図形を保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

形状ブラーは塗りつぶしと輪郭の両方に影響します。ソフトエッジエフェクトは図形のエッジをフェードさせますが、シャドウブラーはシャドウのみを柔らかくします。画像変換エフェクトは画像コンテンツに作用します。この例は、図形を画像に変換せず、直接図形の EffectFormat にブラーを適用しています。

## **よくある質問**

**同じ図形に複数のエフェクトを適用できますか？**

はい、影、反射、グローなど、さまざまなエフェクトを単一の図形に組み合わせて、よりダイナミックな外観を作成できます。

**どのような図形にエフェクトを適用できますか？**

自動図形、グラフ、表、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形にエフェクトを適用できます。

**グループ化された図形にエフェクトを適用できますか？**

はい、グループ化された図形にエフェクトを適用できます。エフェクトはグループ全体に適用されます。