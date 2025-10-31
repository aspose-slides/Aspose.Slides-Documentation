---
title: Python を使用したプレゼンテーションでシェイプ効果を適用する
linktitle: シェイプ効果
type: docs
weight: 30
url: /ja/python-net/shape-effect
keywords:
- シェイプ効果
- 影効果
- 反射効果
- 輝き効果
- ソフトエッジ効果
- 効果フォーマット
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して高度なシェイプ効果で PPT、PPTX、ODP ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---

PowerPoint の効果はシェイプを目立たせるために使用できますが、[塗りつぶし](/slides/ja/python-net/shape-formatting/#gradient-fill)やアウトラインとは異なります。PowerPoint の効果を使用すると、シェイプに説得力のある反射を作成したり、シェイプの光彩を広げたりすることができます。

<img src="shape-effect.png" alt="シェイプ効果" style="zoom:50%;" />

* PowerPoint はシェイプに適用できる 6 つの効果を提供します。シェイプに 1 つまたは複数の効果を適用できます。  
* 効果の組み合わせの中には、他よりも見栄えが良いものがあります。そのため、PowerPoint では **プリセット** オプションが用意されています。プリセットは実質的に 2 つ以上の効果の見栄えの良い組み合わせです。プリセットを選択すれば、時間をかけてさまざまな効果をテストしたり組み合わせたりして最適な組み合わせを見つける手間が省けます。

Aspose.Slides は [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) クラスの下にプロパティとメソッドを提供し、PowerPoint プレゼンテーションのシェイプに同じ効果を適用できるようにします。

## **影効果の適用**

以下の Python コードは、外側の影効果 (`outer_shadow_effect`) を矩形に適用する方法を示しています：

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

## **反射効果の適用**

以下の Python コードは、シェイプに反射効果を適用する方法を示しています：

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

## **光彩効果の適用**

以下の Python コードは、シェイプに光彩効果を適用する方法を示しています：

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

## **ソフトエッジ効果の適用**

以下の Python コードは、シェイプにソフトエッジ効果を適用する方法を示しています：

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

**同じシェイプに複数の効果を適用できますか？**

はい、影、反射、光彩などの異なる効果を単一のシェイプに組み合わせて、より動的な外観を作成できます。

**どのシェイプに効果を適用できますか？**

オートシェイプ、チャート、表、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまなシェイプに効果を適用できます。

**グループ化されたシェイプに効果を適用できますか？**

はい、グループ化されたシェイプにも効果を適用できます。効果はグループ全体に適用されます。