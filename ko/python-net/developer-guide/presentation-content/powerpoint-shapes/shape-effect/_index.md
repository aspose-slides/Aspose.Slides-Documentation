---
title: Python으로 프레젠테이션에서 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/python-net/shape-effect
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 광채 효과
- 부드러운 가장자리 효과
- 효과 서식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 고급 도형 효과로 PPT, PPTX 및 ODP 파일을 변환하고, 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/python-net/shape-formatting/#gradient-fill) 또는 외곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 설득력 있는 반사 효과를 만들거나, 도형의 광채를 퍼뜨리는 등 다양한 작업을 할 수 있습니다.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint는 도형에 적용할 수 있는 6가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.  
* 일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint는 **Preset** 아래 옵션을 제공합니다. 프리셋 옵션은 본질적으로 두 개 이상의 효과를 조합한 잘 어울리는 조합입니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 조합하는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 [EffectFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/effectformat/) 클래스의 속성과 메서드를 제공합니다.

## **그림자 효과 적용**

다음 Python 코드는 사각형에 외부 그림자 효과(`outer_shadow_effect`)를 적용하는 방법을 보여줍니다:

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

## **반사 효과 적용**

다음 Python 코드는 도형에 반사 효과를 적용하는 방법을 보여줍니다:

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

## **광채 효과 적용**

다음 Python 코드는 도형에 광채 효과를 적용하는 방법을 보여줍니다:

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

## **부드러운 가장자리 효과 적용**

다음 Python 코드는 도형에 부드러운 가장자리 효과를 적용하는 방법을 보여줍니다:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **자주 묻는 질문**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 광채와 같은 다양한 효과를 단일 도형에 결합하여 보다 역동적인 모습을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동도형, 차트, 표, 이미지, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.