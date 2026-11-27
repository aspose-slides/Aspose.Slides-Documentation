---
title: 파이썬으로 프레젠테이션에서 도형 효과 적용
linktitle: 도형 효과
type: docs
weight: 30
url: /ko/python-net/shape-effect
keywords:
- 도형 효과
- 그림자 효과
- 반사 효과
- 발광 효과
- 부드러운 가장자리 효과
- 효과 형식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 고급 도형 효과로 PPT, PPTX 및 ODP 파일을 변환—몇 초 만에 인상적이고 전문적인 슬라이드를 만들 수 있습니다."
---
## **소개**

PowerPoint의 효과는 도형을 돋보이게 하는 데 사용할 수 있지만, [채우기](/slides/ko/python-net/shape-formatting/#gradient-fill) 또는 외곽선과는 다릅니다. PowerPoint 효과를 사용하면 도형에 설득력 있는 반사 효과를 만들거나, 도형의 발광을 퍼뜨리는 등 다양한 효과를 만들 수 있습니다.

![도형 효과](shape-effect.png)

PowerPoint는 도형에 적용할 수 있는 6가지 효과를 제공합니다. 하나 이상의 효과를 도형에 적용할 수 있습니다.

일부 효과 조합은 다른 조합보다 더 보기 좋습니다. 이러한 이유로 PowerPoint에는 **프리셋** 옵션이 있습니다. 프리셋 옵션은 기본적으로 두 개 이상의 효과를 조합한 잘 보이는 조합을 미리 정의한 것입니다. 프리셋을 선택하면 다양한 효과를 시험하거나 조합하여 멋진 조합을 찾는 데 시간을 들일 필요가 없습니다.

Aspose.Slides는 [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) 클래스 아래에 속성 및 메서드를 제공하여 PowerPoint 프레젠테이션의 도형에 동일한 효과를 적용할 수 있습니다.

## **그림자 효과 적용**

Aspose.Slides for Python via .NET는 도형에 외부 및 내부 그림자를 지원합니다. 색상, 방향, 거리 및 흐림 반경을 사용자 지정하여 프레젠테이션 디자인에 맞출 수 있습니다.

### **외부 그림자 적용**

외부 그림자를 사용하면 카드 또는 패널을 슬라이드 배경에 대비해 돋보이게 할 수 있습니다. 그림자는 도형 가장자리를 넘어 확장되어 도형이 슬라이드 위로 떠 있는 듯한 인상을 줍니다. 색상, 방향, 거리 및 흐림 반경을 조정하여 템플릿의 조명 및 스타일에 맞출 수 있습니다.

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

#### **도형 회전 시 그림자 방향 제어**

기본적으로 [OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/) 은 `True` 이며, 그림자가 도형과 함께 회전합니다. 서로 다른 회전 각도를 가진 도형이 같은 방향에서 빛을 받는 것처럼 보이게 하려면 이 속성을 `False` 로 설정하고 그림자에 동일한 [direction](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/) 을 적용합니다.

예제에서는 회색 그림자를 오른쪽으로 42포인트 오프셋(`direction = 0`)한 두 개의 화살표를 생성합니다. 그런 다음 슬라이드를 복제하고 두 화살표를 시계 방향으로 90° 회전시킵니다.

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

두 번째 슬라이드에서 왼쪽 화살표는 그림자를 아래쪽으로 드리우고, 오른쪽 화살표는 여전히 오른쪽으로 그림자를 드리웁니다. 두 그림자 모두 설정된 방향은 0° 로 유지됩니다.

![90° 회전 전후의 PowerPoint 렌더링. 두 그림자는 처음에 오른쪽에 있었으며, 회전 후 왼쪽 화살표 아래로 그림자가 이동하고 오른쪽 화살표 오른쪽에 남아 있습니다.](arrow-shadow-rotation.png)

### **내부 그림자 적용**

템플릿의 시각 스타일을 재현할 때, 내부 그림자를 사용하여 카드나 패널에 움푹 들어간 모습을 부여할 수 있습니다. 외부 그림자는 도형 외부로 확장되어 도형이 떠 있는 것처럼 보이게 하고, 내부 그림자는 가장자리 내부를 음영 처리합니다.

먼저 [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/) 을 호출한 다음 [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/) 를 구성합니다. 더 큰 blur-radius 값은 더 부드러운 가장자리를 만듭니다.

다음 Python 예제는 연한 파란색 카드에 어두운 회색 내부 그림자를 적용하고 PPTX 파일로 저장합니다:

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

![내부 그림자가 있는 연한 파란색 사각형](inner_shadow_effect.png)

내부 그림자를 제거하려면 도형의 효과 형식에서 [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) 을 호출합니다.

### **프리셋 그림자 적용, 변경 및 제거**

[enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) 을 호출하고 그림자의 [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) 속성을 [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/) 값으로 설정합니다. 스타일을 전환하려면 같은 도형에서 프리셋을 변경합니다. [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) 을 호출하면 채우기와 외곽선을 유지한 채 그림자를 제거합니다.

다음 예제는 하나의 슬라이드에 네 단계가 나란히 표시됩니다. 각 변경 전에 사각형을 복제하여 결과를 비교할 수 있도록 합니다. 두 그림자는 각각 10포인트 오프셋됩니다. 방향이 225°이면 첫 번째 그림자는 사각형 위쪽 왼쪽에 배치되고, 45°이면 두 번째 그림자는 아래쪽 오른쪽에 배치됩니다.

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
| ![그림자 없음](preset_shadow_original.png) | ![왼쪽 위 그림자](preset_shadow_top_left.png) | ![오른쪽 아래 그림자](preset_shadow_bottom_right.png) | ![제거 후 그림자 없음](preset_shadow_removed.png) |

## **반사 효과 적용**

Aspose.Slides for Python via .NET에서 반사 효과를 적용하려면 도형에 거울과 같은 반사를 추가하고 거리, 투명도, 크기 등의 매개변수를 조정할 수 있습니다. 이 효과는 도형에 더욱 세련되고 정교한 외관을 부여하여 프레젠테이션의 미적 품질을 향상시킵니다. 간단한 코드로 쉽게 구현할 수 있어 여러 요소에 일관된 디자인을 빠르게 적용할 수 있습니다.

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

## **발광 효과 적용**

Aspose.Slides for Python via .NET에서 도형에 발광 효과를 적용하려면 색상과 크기와 같은 속성을 조정하여 부드럽고 빛나는 오라를 도형 주위에 추가할 수 있습니다. 이 효과는 도형을 돋보이게 하고 프레젠테이션에 매력적이고 눈에 띄는 시각 요소를 추가합니다. 최소한의 코드로 쉽게 구현할 수 있어 슬라이드 전체의 외관을 향상시킵니다.

다음 Python 코드는 도형에 [발광 효과](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/)를 적용하는 방법을 보여줍니다:

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

![발광 효과](glow_effect.png)

## **부드러운 가장자리 효과 적용**

Aspose.Slides for Python via .NET에서 부드러운 가장자리 효과를 적용하면 도형 가장자리 주위에 매끄럽고 흐릿한 전환을 만들 수 있습니다. 이 효과는 보다 은은하고 정교한 모습을 추가하여 부드럽고 부드러운 외관이 필요한 디자인에 적합합니다. 원하는 효과를 얻기 위해 반경과 같은 매개변수를 쉽게 조정하여 프레젠테이션의 다양한 도형에 적용할 수 있습니다.

다음 Python 코드는 도형에 [부드러운 가장자리](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/)를 적용하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![부드러운 가장자리 효과](soft_edges_effect.png)

## **블러 효과 적용**

도형 블러를 사용하면 도형을 편집 가능하게 유지하면서 채우기와 외곽선을 부드럽게 할 수 있습니다. 도형의 효과 형식에서 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) 을 호출합니다. 반경은 포인트(1/72인치) 단위이며, 음수가 아닌 값을 사용하고 값이 클수록 블러가 강해집니다. 반경이 0이면 외관이 변경되지 않습니다.

[grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) 설정은 효과의 보이는 경계를 제어합니다. `False` 인 경우 블러가 원래 그려진 경계(외곽선 포함) 내에 한정됩니다. `True` 인 경우 블러가 해당 경계 밖으로 확장될 수 있습니다. 어느 설정도 도형의 위치나 크기를 변경하지 않습니다.

아래 비교에서는 동일한 채우기, 외곽선 및 도형 크기를 사용합니다. 상단 행은 `grow = False` 를, 하단 행은 `grow = True` 를 사용합니다.

![원본 사각형을 블러 반경 5포인트와 15포인트, grow 비활성 및 활성 상태로 비교](shape_blur_comparison.png)

다음 Python 예제는 주황색 사각형에 짙은 파란색 외곽선을 추가하고 5포인트 블러를 적용한 뒤, 다시 [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) 을 호출하여 15포인트 블러로 업데이트합니다. 두 블러 상태를 저장한 후 [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) 을 호출하여 블러가 없는 도형을 저장합니다.

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

도형 블러는 채우기와 외곽선을 동시에 영향을 줍니다. 부드러운 가장자리 효과는 도형의 가장자리를 흐리게 하고, 그림자 블러는 그림자만 부드럽게 합니다. 이미지 변환 효과는 이미지 내용에 적용되며, 이 예제는 도형을 이미지로 변환하지 않고 도형의 효과 형식에 직접 블러를 적용합니다.

## **FAQ**

**같은 도형에 여러 효과를 적용할 수 있나요?**

예, 그림자, 반사, 발광 등 다양한 효과를 하나의 도형에 결합하여 보다 동적인 외관을 만들 수 있습니다.

**어떤 도형에 효과를 적용할 수 있나요?**

오토쉐이프, 차트, 표, 그림, SmartArt 개체, OLE 개체 등 다양한 도형에 효과를 적용할 수 있습니다.

**그룹화된 도형에 효과를 적용할 수 있나요?**

예, 그룹화된 도형에도 효과를 적용할 수 있습니다. 효과는 그룹 전체에 적용됩니다.