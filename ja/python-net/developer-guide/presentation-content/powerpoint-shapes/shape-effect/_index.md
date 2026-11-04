---
title: "Python でプレゼンテーションの図形効果を適用する"
linktitle: "図形効果"
type: docs
weight: 30
url: /ja/python-net/shape-effect
keywords:
- 図形効果
- 影効果
- 反射効果
- 光彩効果
- ソフトエッジ効果
- エフェクト形式
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して高度な図形効果で PPT、PPTX、ODP ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **イントロダクション**

PowerPoint の効果は図形を目立たせるために使用できますが、[塗りつぶし](/slides/ja/python-net/shape-formatting/#gradient-fill)や輪郭とは異なります。PowerPoint の効果を使用すると、図形にリアルな反射を付けたり、図形の光彩を広げたりできます。

![Shape effect](shape-effect.png)

PowerPoint には図形に適用できる 6 つの効果があります。1 つまたは複数の効果を図形に適用できます。

効果の組み合わせによって見栄えが異なります。このため、PowerPoint には **プリセット** オプションがあります。プリセットは実質的に 2 つ以上の効果の見栄えの良い組み合わせをあらかじめ定義したものです。プリセットを選択すれば、効果の組み合わせを試す手間を省けます。

Aspose.Slides は [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供し、PowerPoint プレゼンテーションの図形に同じ効果を適用できます。

## **影効果の適用**

Aspose.Slides for Python via .NET は図形の外側影と内側影をサポートします。色、方向、距離、ぼかし半径をカスタマイズしてプレゼンテーションのデザインに合わせられます。

### **外側影の適用**

外側影を使用すると、カードやパネルをスライドの背景から際立たせられます。影が図形の端を超えて伸び、図形がスライド上に浮き上がっているように見えます。色、方向、距離、ぼかし半径を調整してテンプレートの照明やスタイルに合わせます。

この Python コードは矩形に [外側影効果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) を適用する方法を示しています。

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

![Shadow effect](shadow_effect.png)

### **内側影の適用**

テンプレートのビジュアルスタイルを再現する際、内側影を使用してカードやパネルに凹んだ外観を与えます。外側影は図形の外側に影を付けて浮き上がらせ、内側影はエッジ内側を陰影付けします。

[enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) を呼び出し、次に [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) を構成します。ぼかし半径の値を大きくするとエッジが柔らかくなります。

この Python の例は、淡い青色のカードに濃い灰色の内側影を付け、PPTX ファイルとして保存します。

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

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

内側影を削除するには、図形の effect format に対して [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) を呼び出します。

## **反射効果の適用**

Aspose.Slides for Python via .NET で反射効果を適用するには、図形に鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。この効果は図形に洗練された外観を与え、プレゼンテーションの美しさを高めます。簡単なコードで実装でき、複数の要素に素早く適用してデザインの一貫性を保てます。

この Python コードは図形に [反射効果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) を適用する方法を示しています。

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

![Reflection effect](reflection_effect.png)

## **光彩効果の適用**

Aspose.Slides for Python via .NET で図形に光彩効果を適用すると、図形の周囲に柔らかな光のオーラを加え、色やサイズといったプロパティを調整できます。この効果は図形を目立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を追加します。最小限のコードで実装でき、スライド全体の見た目を向上させます。

この Python コードは図形に [光彩効果](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) を適用する方法を示しています。

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

![Glow effect](glow_effect.png)

## **ソフトエッジ効果の適用**

Aspose.Slides for Python via .NET でソフトエッジ効果を適用すると、図形のエッジ周辺に滑らかでぼやけた遷移を作成できます。この効果はより繊細で上品な外観を提供し、柔らかい外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に期待どおりの効果を得られます。

この Python コードは図形に [ソフトエッジ](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) を適用する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Soft edges effect](soft_edges_effect.png)

## **ぼかし効果の適用**

図形のぼかしを使用すると、図形の塗りと輪郭をソフトにしながら、図形は編集可能なままです。図形の effect format で [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) を呼び出します。半径はポイント (1/72 インチ) 単位で測定されます。負の値は使用できず、値が大きいほど強いぼかしになります。半径が 0 の場合は外観は変わりません。

[grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) 設定は効果の表示範囲を制御します。`False` の場合、ぼかしは元の描画範囲（輪郭を含む）にクリップされます。`True` の場合、ぼかしはその範囲を超えて拡張できます。どちらの設定も図形の位置やサイズは変更しません。

以下の比較は、全体で同じ塗り、輪郭、図形サイズを使用しています。上段は `grow = False`、下段は `grow = True` です。

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

この Python の例は、オレンジ色の矩形に濃い青の輪郭を付け、5 ポイントのぼかしを適用し、続いて [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、最後に [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) を呼び出してぼかしなしの図形を保存します。

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

図形のぼかしは塗りと輪郭の両方に影響します。ソフトエッジ効果は図形のエッジをフェードさせ、影のぼかしは影だけを柔らかくします。画像変換効果は画像コンテンツに作用しますが、この例は図形を画像に変換せずに effect format に直接ぼかしを適用しています。

## **FAQ**

**同じ図形に複数の効果を適用できますか？**

はい、影、反射、光彩など異なる効果を組み合わせて、1 つの図形に動的な外観を作れます。

**どの図形に効果を適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形に適用できます。

**グループ化された図形に効果を適用できますか？**

はい、グループ化された図形全体に効果が適用されます。