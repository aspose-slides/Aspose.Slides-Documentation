---
title: Pythonでプレゼンテーションに形状効果を適用する
linktitle: 形状効果
type: docs
weight: 30
url: /ja/python-net/shape-effect
keywords:
- 形状効果
- 影効果
- 反射効果
- 光彩効果
- ソフトエッジ効果
- 効果形式
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して高度な形状効果で PPT、PPTX、ODP ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **はじめに**

PowerPoint の効果は形状を目立たせるために使用できますが、[塗りつぶし](/slides/ja/python-net/shape-formatting/#gradient-fill)や輪郭とは異なります。PowerPoint の効果を使用すると、形状にリアルな反射を作成したり、形状の発光を広げたりすることができます。

![形状効果](shape-effect.png)

PowerPoint には形状に適用できる 6 つの効果が用意されています。1 つまたは複数の効果を形状に適用できます。

効果の組み合わせの中には、他よりも見栄えが良いものがあります。このため、PowerPoint では **Preset** のオプションが用意されています。Preset オプションは、実質的に 2 つ以上の効果の見栄えの良い既知の組み合わせです。このように、プリセットを選択すれば、さまざまな効果をテストしたり組み合わせたりして良い組み合わせを見つけるために時間を無駄にする必要がありません。

Aspose.Slides は、PowerPoint プレゼンテーションの形状に同じ効果を適用できるように、[EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供します。

## **影効果の適用**

Aspose.Slides for Python via .NET は、形状に対する外側と内側の影をサポートしています。影の色、方向、距離、ぼかし半径をカスタマイズして、プレゼンテーションのデザインに合わせることができます。

### **外側の影を適用する**

外側の影を使用して、カードやパネルをスライドの背景に対して際立たせます。影は形状のエッジを超えて広がり、形状がスライド上に浮き上がっているように見えます。影の色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この Python コードは、矩形に[外側の影効果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/)を適用する方法を示しています:
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

![影効果](shadow_effect.png)

#### **形状が回転したときの影の方向の制御**

デフォルトでは、[OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/) は `True` で、影は形状と一緒に回転します。異なる回転角の形状を同じ方向から照らされたように見せるには、このプロパティを `False` に設定し、影に同じ[方向](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/) を指定します。

この例では、右方向に 42 ポイントオフセットした灰色の影を持つ矢印を 2 本作成します（`direction = 0`）。その後、スライドを複製し、両方の矢印を時計回りに 90° 回転させます。
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    before = presentation.slides[0]

    left = before.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 55, 130, 110, 60)
    left.fill_format.fill_type = slides.FillType.SOLID
    left.fill_format.solid_fill_color.color = slides.Color.steel_blue
    left.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    left.effect_format.enable_outer_shadow_effect()
    shadow = left.effect_format.outer_shadow_effect
    shadow.shadow_color.color = slides.Color.gray
    shadow.direction = 0
    shadow.distance = 42
    shadow.blur_radius = 0
    shadow.rotate_shadow_with_shape = True

    right = before.shapes.add_clone(left)
    right.x = 395
    right.effect_format.outer_shadow_effect.rotate_shadow_with_shape = False

    after = presentation.slides.add_clone(before)
    for arrow in after.shapes:
        arrow.rotation = 90

    presentation.save("arrow_shadows.pptx", slides.export.SaveFormat.PPTX)
```

2 枚目のスライドでは、左側の矢印の影は下方向に落ち、右側の矢印の影は依然として右方向に落ちます。両方の影の設定された方向は 0° のままです。

![90° 回転前後の PowerPoint 表示。両方の影は右側から開始し、回転後、左矢印の影は下に移動し、右矢印の影は右側のままです。](arrow-shadow-rotation.png)

### **内側の影を適用する**

テンプレートのビジュアルスタイルを再現する際には、内側の影を使用してカードやパネルに凹んだ外観を付けます。外側の影は形状の外側に広がり、浮き上がって見えるのに対し、内側の影はエッジ内部を影付けします。

まず [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) を呼び出し、次に [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) を設定します。ぼかし半径の値が大きいほど、エッジは柔らかくなります。

この Python の例は、淡い青色のカードに濃い灰色の内側の影を付け、PPTX ファイルとして保存します:
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

![内側の影付き淡青色の矩形](inner_shadow_effect.png)

内側の影を削除するには、形状の EffectFormat で [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) を呼び出します。

### **プリセット影の適用、変更、削除**

[enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) を呼び出し、影の[preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) プロパティに [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) の値を設定します。スタイルを切り替えるには、同じ形状のプリセットを変更します。[disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) を呼び出すと、塗りつぶしと輪郭は保持したまま影を削除できます。

この例は、1 つのスライド上に 4 つの段階を横に並べて示します。各変更前に矩形をクローンして結果を比較できるようにしています。両方の影は 10 ポイントオフセットです。225° の方向は最初の影を矩形の左上に配置し、45° の方向は二番目の影を右下に配置します。
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

| 元 | 最初のプリセット | 2 番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![影なし](preset_shadow_original.png) | ![左上ドロップ影](preset_shadow_top_left.png) | ![右下ドロップ影](preset_shadow_bottom_right.png) | ![削除後の影なし](preset_shadow_removed.png) |

## **反射効果の適用**

Aspose.Slides for Python via .NET で反射効果を適用するには、形状に鏡のような反射を追加し、距離、透明度、サイズなどのパラメータを調整できます。この効果は、形状により洗練された外観を与えることでプレゼンテーションの美観を向上させます。シンプルなコードで簡単に実装でき、複数の要素に迅速に適用してデザインの一貫性を保つことができます。

この Python コードは、形状に[反射効果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/)を適用する方法を示しています:
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

![反射効果](reflection_effect.png)

## **光彩効果の適用**

Aspose.Slides for Python via .NET で形状に光彩効果を適用するには、形状の周囲に柔らかい光るオーラを追加し、色やサイズなどのプロパティを調整できます。この効果は形状を際立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の外観を向上させます。

この Python コードは、形状に[光彩効果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/)を適用する方法を示しています:
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

![光彩効果](glow_effect.png)

## **ソフトエッジ効果の適用**

Aspose.Slides for Python via .NET でソフトエッジ効果を適用すると、形状のエッジ周辺に滑らかでぼやけた移行を作成できます。この効果は、より微妙で洗練された外観を加え、柔らかい外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな形状に希望の効果を得られます。

この Python コードは、形状に[ソフトエッジ](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/)を適用する方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![ソフトエッジ効果](soft_edges_effect.png)

## **ぼかし効果の適用**

形状ぼかしを使用すると、形状の塗りと輪郭を柔らかくしながら、形状を編集可能なままにできます。形状の EffectFormat で [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) を呼び出します。半径はポイント (1/72 インチ) で測定され、非負の値を使用し、値が大きいほど強いぼかしになります。半径が 0 の場合、外観は変わりません。

[grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) 設定は効果の可視範囲を制御します。`False` の場合、ぼかしは元の描画範囲（輪郭を含む）内にクリップされます。`True` の場合、ぼかしはその範囲を超えて拡張できます。どちらの設定も形状の位置やサイズは変更しません。

以下の比較は、同一の塗り、輪郭、および形状サイズを使用しています。上段は `grow = False`、下段は `grow = True` です。

![ぼかし半径5ポイントと15ポイント、grow 無効・有効の比較](shape_blur_comparison.png)

この Python の例は、オレンジ色の矩形に濃い青色の輪郭を付け、5 ポイントのぼかしを適用し、次に [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、その後 [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) を呼び出してぼかしのない形状を保存します。
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

形状ぼかしは塗りと輪郭の両方に影響します。ソフトエッジ効果は形状のエッジだけをフェードさせ、影ぼかしは影だけを柔らかくします。画像変換効果は画像コンテンツに対して動作しますが、この例では形状を画像に変換せず、直接形状の EffectFormat にぼかしを適用しています。

## **FAQ**

**同じ形状に複数の効果を適用できますか？**

はい、影、反射、光彩などの異なる効果を組み合わせて、1 つの形状に適用し、より動的な外観を作り出すことができます。

**どのような形状に効果を適用できますか？**

自動図形、グラフ、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな形状に効果を適用できます。

**グループ化された形状に効果を適用できますか？**

はい、グループ化された形状にも効果を適用できます。効果はグループ全体に適用されます。