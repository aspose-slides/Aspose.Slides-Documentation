---
title: Python을 사용하여 프레젠테이션에 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/python-net/shape-effect
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 글로우 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 고급 도형 효과로 PPT, PPTX 및 ODP 파일을 변환하고, 몇 초 만에 눈에 띄고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 할 수 있지만, [채우기](/slides/ko/python-net/shape-formatting/#gradient-fill) 또는 외곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 설득력 있는 반사 효과를 만들거나 도형의 빛남을 확산시키는 등 다양한 작업을 할 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 여섯 가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint에는 **프리셋** 옵션이 있습니다. 프리셋 옵션은 기본적으로 두 개 이상의 효과를 조합한 보기 좋은 조합을 의미합니다. 따라서 프리셋을 선택하면 다양한 효과를 시험하거나 결합하여 좋은 조합을 찾는 데 시간을 낭비하지 않아도 됩니다.

Aspose.Slides는 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있도록 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) 클래스에 속성 및 메서드를 제공합니다.

## **그림자 효과 적용**

Aspose.Slides for Python via .NET는 도형에 대한 외부 그림자와 내부 그림자를 지원합니다. 색상, 방향, 거리 및 블러 반경을 사용자 지정하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

외부 그림자는 카드나 패널을 슬라이드 배경에 대비되게 돋보이게 합니다. 그림자가 도형의 가장자리를 넘어 확장되어 도형이 슬라이드 위에 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 블러 반경을 조정하여 템플릿의 조명 및 스타일에 맞추세요.

다음 Python 코드는 사각형에 [외부 그림자 효과](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/)를 적용하는 방법을 보여줍니다:

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

![그림자 효과](shadow_effect.png)

### **내부 그림자 적용**

템플릿의 시각적 스타일을 재현할 때는 카드나 패널에 움푹 들어간 모양을 주기 위해 내부 그림자를 사용합니다. 외부 그림자는 도형 외부로 확장되어 도형이 떠 있는 듯하게 만들고, 내부 그림자는 가장자리 내부를 음영 처리합니다.

먼저 [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/)를 호출하고, 다음으로 [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/)를 구성합니다. 블러 반경 값이 클수록 가장자리가 부드러워집니다.

다음 Python 예제는 연한 파란색 카드에 짙은 회색 내부 그림자를 적용하고 PPTX 파일로 저장합니다:

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

![내부 그림자가 있는 연파란 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 EffectFormat에서 [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/)를 호출합니다.

### **프리셋 그림자 적용, 변경 및 제거**

먼저 [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/)를 호출하고, 그림자의 [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) 속성을 [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) 값으로 설정합니다. 동일한 도형에서 프리셋을 변경하여 스타일을 전환할 수 있습니다. 그림자를 제거하되 채우기와 외곽선을 유지하려면 [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/)를 호출합니다.

이 예제는 한 슬라이드에 네 단계의 결과를 나란히 보여줍니다. 각 변경 전에 사각형을 복제하여 결과를 비교할 수 있습니다. 두 그림자 모두 10포인트 만큼 오프셋됩니다. 225° 방향은 첫 번째 그림자를 사각형 위쪽 왼쪽에 배치하고, 45° 방향은 두 번째 그림자를 아래쪽 오른쪽에 배치합니다.

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

| 원본 | 첫 번째 프리셋 | 두 번째 프리셋 | 제거 후 |
| :---: | :---: | :---: | :---: |
| ![그림자 없음](preset_shadow_original.png) | ![좌상단 그림자](preset_shadow_top_left.png) | ![우하단 그림자](preset_shadow_bottom_right.png) | ![제거 후 그림자 없음](preset_shadow_removed.png) |

## **반사 효과 적용**

Aspose.Slides for Python via .NET에서 반사 효과를 적용하려면 도형에 거울처럼 반사된 모습을 추가하고 거리, 투명도, 크기와 같은 매개변수를 조정하면 됩니다. 이 효과는 도형에 보다 세련되고 정교한 외관을 부여하여 프레젠테이션의 미적 품질을 향상시킵니다. 간단한 코드로 손쉽게 구현할 수 있어 여러 요소에 일관된 디자인을 빠르게 적용할 수 있습니다.

다음 Python 코드는 도형에 [반사 효과](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/)를 적용하는 방법을 보여줍니다:

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

![반사 효과](reflection_effect.png)

## **글로우 효과 적용**

Aspose.Slides for Python via .NET에서 도형에 글로우 효과를 적용하려면 색상 및 크기와 같은 속성을 조정하여 도형 주변에 부드럽고 빛나는 오라를 추가할 수 있습니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 추가합니다. 최소한의 코드로 손쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

다음 Python 코드는 도형에 [글로우 효과](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/)를 적용하는 방법을 보여줍니다:

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

![글로우 효과](glow_effect.png)

## **소프트 엣지 효과 적용**

Aspose.Slides for Python via .NET에서 소프트 엣지 효과를 적용하려면 도형 가장자리 주변에 부드럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 미묘하고 정제된 모양을 제공하여 부드러운 외관이 필요한 디자인에 적합합니다. 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 원하는 효과를 적용할 수 있습니다.

다음 Python 코드는 도형에 [소프트 엣지](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/)를 적용하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![소프트 엣지 효과](soft_edges_effect.png)

## **블러 효과 적용**

도형 블러를 사용하면 도형을 편집 가능한 상태로 유지하면서 채우기와 외곽선을 부드럽게 만들 수 있습니다. 도형의 EffectFormat에서 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/)를 호출합니다. 반경은 포인트(1/72인치) 단위이며, 0보다 큰 값을 사용하면 값이 클수록 블러가 강해집니다. 반경이 0이면 외관이 변하지 않습니다.

[grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) 설정은 효과의 보이는 경계를 제어합니다. `False`인 경우 블러가 외곽선을 포함한 원래 그려진 경계에 클리핑됩니다. `True`인 경우 블러가 그 경계를 넘어 확장될 수 있습니다. 두 설정 모두 도형의 위치나 크기를 변경하지 않습니다.

아래 비교는 전체적으로 동일한 채우기, 외곽선 및 도형 크기를 사용합니다. 상단 행은 `grow = False`를 사용하고, 하단 행은 `grow = True`를 사용합니다.

![grow 비활성화 및 활성화 상태에서 5와 15 포인트 블러 반경을 비교한 원본 사각형](shape_blur_comparison.png)

다음 Python 예제는 주황색 사각형에 짙은 파란색 외곽선을 적용하고, 5포인트 블러를 적용한 뒤 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/)를 다시 호출하여 15포인트 블러로 업데이트합니다. 두 블러 상태를 저장한 다음 [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/)를 호출하여 블러가 없는 도형을 저장합니다.

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

도형 블러는 채우기와 외곽선을 함께 영향을 줍니다. 소프트 엣지 효과는 도형 가장자리를 흐리게 하고, 그림자 블러는 그림자만 부드럽게 합니다. 이미지 변환 효과는 이미지 콘텐츠에 작용하지만, 이 예제는 도형을 이미지로 변환하지 않고 바로 도형의 EffectFormat에 블러를 적용합니다.

## **FAQ**

**동일한 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 글로우와 같은 다양한 효과를 하나의 도형에 결합하여 보다 역동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

자동 도형, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 전체 그룹에 적용됩니다.