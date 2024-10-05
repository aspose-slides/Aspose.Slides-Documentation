---
title: シェイプ効果
type: docs
weight: 30
url: /python-net/shape-effect
keywords: "シェイプ効果, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointのシェイプに効果を適用"
---

PowerPointの効果はシェイプを目立たせるために使用できますが、[塗りつぶし](/slides/python-net/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPointの効果を使用すると、シェイプに説得力のある反射を作成したり、シェイプのグローを広げたりできます。

<img src="shape-effect.png" alt="シェイプ効果" style="zoom:50%;" />

* PowerPointにはシェイプに適用できる6つの効果があります。1つ以上の効果をシェイプに適用できます。

* 効果の組み合わせによっては、より良く見えるものがあります。この理由から、PowerPointのオプションには**プリセット**があります。プリセットオプションは、基本的に2つ以上の効果の良好な組み合わせとして知られています。このように、プリセットを選択することで、異なる効果をテストしたり組み合わせたりして良い組み合わせを見つけるための時間を無駄にすることがありません。

Aspose.Slidesは、[EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/)クラスのプロパティとメソッドを提供しており、これを使用してPowerPointプレゼンテーションのシェイプに同じ効果を適用できます。

## **シャドウ効果を適用**

このPythonコードは、長方形に外側のシャドウ効果（`outer_shadow_effect`）を適用する方法を示しています。

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

## **反射効果を適用**

このPythonコードは、シェイプに反射効果を適用する方法を示しています。

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

## **グロー効果を適用**

このPythonコードは、シェイプにグロー効果を適用する方法を示しています。

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

## **ソフトエッジ効果を適用**

このPythonコードは、シェイプにソフトエッジ効果を適用する方法を示しています。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```