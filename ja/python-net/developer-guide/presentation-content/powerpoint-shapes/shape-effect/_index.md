---
title: Pythonでプレゼンテーションに形状エフェクトを適用する
linktitle: 形状エフェクト
type: docs
weight: 30
url: /ja/python-net/shape-effect
keywords:
- 形状エフェクト
- シャドウエフェクト
- リフレクションエフェクト
- グローエフェクト
- ソフトエッジエフェクト
- エフェクトフォーマット
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して高度な形状エフェクトで PPT、PPTX、ODP ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---

PowerPoint のエフェクトは図形を目立たせるために使用できますが、[fills](/slides/ja/python-net/shape-formatting/#gradient-fill) やアウトラインとは異なります。PowerPoint のエフェクトを使用すると、図形にリアルな反射を作成したり、図形のグローを広げたりすることができます。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint は図形に適用できる 6 つのエフェクトを提供します。1 つまたは複数のエフェクトを図形に適用できます。  
* エフェクトの組み合わせによって見栄えが変わります。このため、PowerPoint には **Preset** オプションがあります。Preset は実質的に 2 つ以上のエフェクトの見栄えの良い既知の組み合わせです。プリセットを選択すれば、さまざまなエフェクトをテストしたり組み合わせて最適な組み合わせを探す手間が省けます。

Aspose.Slides は [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) クラスの下にプロパティとメソッドを提供し、PowerPoint プレゼンテーションの図形に同じエフェクトを適用できます。

## **シャドウ効果の適用**

この Python コードは、矩形に外部シャドウ効果(`outer_shadow_effect`)を適用する方法を示しています。
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **リフレクション効果の適用**

この Python コードは、図形にリフレクション効果を適用する方法を示しています。
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```


## **グロー効果の適用**

この Python コードは、図形にグロー効果を適用する方法を示しています。
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```


## **ソフト エッジ効果の適用**

この Python コードは、図形にソフト エッジを適用する方法を示しています。
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**同じ図形に複数のエフェクトを適用できますか？**

はい、シャドウ、リフレクション、グローなどの異なるエフェクトを組み合わせて、1 つの図形に動的な外観を付与できます。

**どのような図形にエフェクトを適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形にエフェクトを適用できます。

**グループ化された図形にエフェクトを適用できますか？**

はい、グループ化された図形全体にエフェクトが適用されます。