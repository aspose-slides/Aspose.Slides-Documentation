---
title: "Python에서 PowerPoint 도형 서식 지정"
linktitle: "도형 서식 지정"
type: docs
weight: 20
url: /ko/python-net/shape-formatting/
keywords:
- "도형 포맷"
- "선 포맷"
- "스케치 효과"
- "도형 선 스케치"
- "조인 스타일 포맷"
- "그라디언트 채우기"
- "패턴 채우기"
- "그림 채우기"
- "텍스처 채우기"
- "단색 채우기"
- "도형 투명도"
- "흑백 도형 렌더링"
- "그레이스케일 도형 렌더링"
- "도형 회전"
- "3D 베벨 효과"
- "3D 회전 효과"
- "포맷 재설정"
- "PowerPoint"
- "프레젠테이션"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides를 사용하여 Python에서 PowerPoint 도형을 포맷하는 방법을 배우세요—PPT, PPTX 및 ODP 파일에 대해 채우기, 선 및 효과 스타일을 정밀하고 완벽하게 제어할 수 있습니다."
---
## **소개**

PowerPoint에서 윤곽선, 채우기 및 효과를 조정하여 도형을 포맷합니다. Aspose.Slides for Python via .NET를 사용하면 투명도, 회전 및 3D 포맷을 포함한 이러한 설정을 프로그래밍 방식으로 제어할 수 있습니다.

![PowerPoint의 도형 포맷 옵션](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET는 PowerPoint에서 사용할 수 있는 동일한 옵션을 사용하여 도형을 포맷할 수 있는 클래스와 속성을 제공합니다.

## **선 포맷**

[Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/)을 사용하여 도형의 윤곽선을 제어합니다. 이 예제는 파란색 점선 윤곽선을 가진 채우기 없는 사각형을 만듭니다. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/)은 두께가 다른 복합선을 선택하고, [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/)는 너비를 7포인트로 설정하며, [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/)은 대시 패턴을 선택합니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![프레젠테이션에 포맷된 선](formatted-lines.png)

### **사용자 정의 선 대시 패턴 설정**

미리 정의된 선 스타일이 필요한 대시 길이와 간격을 제공하지 않을 때는 [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/)을 사용하십시오(예: 브랜드 윤곽선 또는 기술 다이어그램). 패턴을 할당하면 자동으로 [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/)이 [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)으로 설정됩니다.

목록 항목은 대시와 간격 길이를 교대로 지정하며 대시부터 시작합니다. 각 값은 선 너비의 배수입니다: `[4, 2]`를 3포인트 너비에 적용하면 12포인트 대시와 6포인트 간격이 생성됩니다. 완전한 대시‑간격 구간을 정의하려면 유한하고 음수가 아닌 값을 쌍으로 사용하십시오. 예제에서는 모든 대시와 간격이 보이도록 양수를 사용합니다.

이 예제는 동일한 길이와 평평한 캡을 가진 파란색 선 다섯 개를 만듭니다. 처음 세 개는 3포인트 너비에서 패턴을 비교하고, 네 번째는 첫 번째 패턴을 두 배 너비로 반복하여 대시와 간격 길이를 모두 두 배로 늘립니다. 다섯 번째는 사용자 정의 패턴을 단색 선으로 전환합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # 마지막 선을 실선 스타일로 되돌립니다.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

미리 정의된 점선 스타일로 돌아가려면 [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)을 [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/)에 할당하십시오. 선택된 스타일이 선의 모양을 제어합니다.

PowerPoint에서 위에서 아래 순서대로 표시된 결과: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; 그리고 **Solid, 3 pt**.

![세 가지 사용자 정의 대시 패턴, 첫 번째 패턴을 사용한 더 굵은 선, 그리고 PowerPoint의 단색 선](custom-dash-patterns.png)

### **선 캡 설정**

[LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/)을 사용하여 열린 선의 양끝을 설정합니다. [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) 열거형은 세 가지 명시적 캡 스타일을 제공합니다.

- `FLAT`: 스트로크가 끝점에서 멈춥니다.
- `ROUND`: 반원형 캡이 끝점 너비의 절반만큼 끝을 넘어갑니다.
- `SQUARE`: 정사각형 캡이 끝점 너비의 절반만큼 끝을 넘어갑니다.

열거형에는 `NOT_DEFINED`도 포함되어 있어, 명시적인 캡 스타일이 할당되지 않았음을 의미합니다.

캡은 선 끝에 기호를 추가하는 화살표와, 선 분할점 사이의 코너를 제어하는 조인과는 다릅니다. 이 예제는 [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) 및 [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/)을 사용해 화살표를 비활성화하고 캡 모양만을 비교합니다.

다음 예제는 가로 20포인트 너비의 동일한 수평 선 세 개를 만듭니다. 위에서 아래 순서대로 평평한 캡, 둥근 캡, 정사각형 캡을 사용합니다. 끝점은 동일한 가로 좌표를 가지며, 둥근 캡과 정사각형 캡은 각 끝점에서 10포인트씩 확장됩니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint에서 위에서 아래 순서대로 표시된 결과: **Flat**, **Round**, **Square**.

![PowerPoint에서 동일한 굵기의 선에 적용된 평평한, 둥근 및 정사각형 캡](line-caps.png)

## **도형 선에 스케치 효과 적용**

스케치 효과는 도형 선을 손으로 그린 듯하게 보이게 합니다. [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/)을 사용해 선 설정에 접근하고, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/)을 사용해 스케치 설정에 접근하며, [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/)을 사용해 [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 열거형에서 값을 선택합니다.

다음 Python 코드는 [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 효과를 적용하고, 명시적으로 할당된 값을 읽으며, [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/)으로 효과를 제거하는 방법을 보여줍니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

[SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/)이 반환하는 값은 도형에 직접 할당된 설정을 나타냅니다. 선 포맷이 테마, 마스터 슬라이드 또는 레이아웃 슬라이드에서 상속될 수 있는 경우에는 [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/)을 사용하고, [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/)에 접근한 뒤 [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/)을 읽으십시오. 유효값은 상속이 해결된 후 실제 적용된 포맷을 반영합니다. 이 예제는 첫 번째 슬라이드에 최소 하나의 도형이 있는 기존 프레젠테이션을 필요로 하며 두 값을 모두 출력합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **조인 스타일 포맷**

다음은 세 가지 조인 유형 옵션입니다:

* Round
* Miter
* Bevel

조인 스타일은 코너에서 두 윤곽선 세그먼트가 만나는 방식을 제어합니다. 둥근 코너에는 **Round**, 뾰족한 코너에는 **Miter**, 평평한 코너에는 **Bevel**을 사용하십시오.

![프레젠테이션의 조인 스타일](join-style-powerpoint.png)

이 예제는 파란색 윤곽선(너비 15포인트)이 있는 검은색 사각형 세 개를 만들고, 각각 [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/)을 [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/)의 miter, bevel, round 값으로 설정하여 코너가 어떻게 그려지는지 비교합니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **뾰족한 코너에서 Miter 조인 제한**

[LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/)을 사용하고, [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/)을 [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/)로 설정하여 뾰족한 코너가 확장될 수 있는 거리를 제한합니다.

제한값은 조인의 내부와 외부 코너 사이 거리와 선 너비의 비율입니다. 예를 들어 값이 `8`이면 뾰족한 길이가 선 너비의 최대 8배까지 허용되며, 이는 포인트 단위가 아닙니다. 코너가 제한을 초과하면 PowerPoint는 해당 코너를 베벨 조인으로 바꿉니다. 큰 제한값은 더 뾰족한 포인트를 허용합니다. 이 설정은 miter 조인에만 적용되며, 코너가 두 제한 모두 내에 있으면 눈에 보이는 효과는 없습니다.

이 예제는 윤곽선이 20포인트인 동일한 무채색 삼각형 두 개를 만듭니다. 왼쪽 삼각형은 제한값 `2`를, 오른쪽은 `8`을 사용합니다. 각 삼각형은 가로 80포인트, 세로 160포인트이며, 상단 코너의 miter‑length‑to‑line‑width 비율은 약 `4.12`입니다. 따라서 PowerPoint는 왼쪽 꼭짓점을 베벨 처리하고 오른쪽 꼭짓점을 유지합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint에서의 결과: 왼쪽은 **Miter limit 2**, 오른쪽은 **miter limit 8**.

![PowerPoint에서 miter 제한 2가 적용된 베벨 꼭짓점과 miter 제한 8이 적용된 뾰족한 꼭짓점](miter-limits.png)

## **그라디언트 채우기**

그라디언트 채우기는 도형 전체에 색상을 혼합합니다. 이 예제는 [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/)을 사용해 빨간색에서 보라색으로 45도 각도의 선형 그라디언트로 타원을 채웁니다. [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) 메서드는 그라디언트 시작과 끝에 해당하는 0과 1 위치에 색상 중지를 배치합니다. 기존 중지를 삭제하면 두 색상만 사용됩니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![그라디언트 채우기가 적용된 타원](gradient-fill.png)

내보낸 이미지에서 그라디언트가 PowerPoint와 다르게 보이는 경우, [Choose a Gradient Rendering Style](/slides/ko/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)를 참조하십시오. 프레젠테이션에 저장된 그라디언트 채우기를 변경하지 않고 렌더링 스타일만 선택할 수 있습니다.

### **선형 그라디언트 각도 설정**

[GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/)을 사용해 [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) 채우기의 방향을 제어합니다. 각도는 도 단위이며 시계 방향으로 증가합니다: `0`은 왼쪽에서 오른쪽, `90`은 위에서 아래, `180`은 오른쪽에서 왼쪽, `270`은 아래에서 위로 그립니다. 소수 각도도 지원됩니다. `[0, 360)` 범위를 벗어나는 유한 각도는 한 바퀴로 정규화됩니다; 예를 들어 `-45`는 `315`가 되고 `360`은 `0`이 됩니다.

이 예제는 동일한 빨강, 초록, 파랑 중지를 위치 `0`, `0.5`, `1`에 배치한 직사각형 여섯 개를 만듭니다. 스케일을 비활성화하여 각도가 직사각형 비율과 무관하게 비교될 수 있도록 합니다. 각도는 첫 번째 행에서 왼쪽부터 차례로 `0`, `45`, `90`, 두 번째 행에서는 `135`, `180`, `270`입니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint에서의 결과:

![위쪽 행에 0°, 45°, 90°, 아래쪽 행에 135°, 180°, 270° 선형 그라디언트](linear-gradient-angles.png)

### **도형에 선형 그라디언트 스케일 적용**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/)은 [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) 값을 받습니다. `FALSE`로 명시적으로 설정하면 도형 비율이 변경되어도 기하학적 그라디언트 각도가 유지되고, `TRUE`로 설정하면 그라디언트가 도형의 너비와 높이에 맞춰 스케일됩니다. 스케일링이 활성화된 경우, 정사각형이 아닌 도형에서는 보이는 각도가 할당된 각도와 다를 수 있습니다.

다음 예제는 `45`도 각도와 앞에서 사용한 동일한 색상 중지를 사용합니다. 왼쪽 열은 `FALSE`, 오른쪽 열은 `TRUE`를 사용합니다. 각 열에는 넓은 직사각형 위에 높은 직사각형이 있습니다. 두 번째 직사각형의 너비와 높이를 변경하여 채우기가 크기 조정에 어떻게 반응하는지 보여줍니다(색상 중지는 동일하게 유지).

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint에서의 결과: 왼쪽은 스케일 비활성화, 오른쪽은 스케일 활성화:

![좌측에 linear_gradient_scaled FALSE, 우측에 TRUE가 적용된 45도 그라디언트를 가진 넓은 직사각형과 높은 직사각형 비교](linear-gradient-scaling.png)

스케일이 비활성화되면 두 직사각형 모두 대각선 색상 밴드가 동일한 방향을 유지합니다. 스케일이 활성화되면 밴드가 도형 비율에 맞게 늘어납니다. 이는 템플릿의 그라디언트를 다른 크기의 도형에 적용할 때 도움이 됩니다. 정사각형에서는 스케일을 활성화해도 이 `45`도 그라디언트의 모양이 바뀌지 않습니다.

각도와 스케일 설정은 선형 그라디언트에만 적용됩니다. [GradientShape.RADIAL]이나 [GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) 채우기는 제어하지 않습니다.

### **그라디언트 방향과 각도 결합**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/)은 [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/) 열거형에서 그라디언트 스타일을 선택합니다; 숫자 각도의 대체가 아닙니다. 선형 그라디언트의 경우, 코너 스타일을 변경하면 [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/)을 바꾸지 않고 색상이 배포되는 영역을 바꿀 수 있습니다. 각도나 스케일을 비교할 때는 방향을 변경하지 마십시오.

다음 예제는 동일한 설정을 순서를 바꿔 적용합니다. 두 직사각형은 동일하게 보이며, 방향을 각도 전에 설정하든 후에 설정하든 결과는 변하지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **패턴 채우기**

패턴 채우기는 점, 줄무늬 또는 체크와 같은 두 색상 디자인을 적용합니다. 이 예제는 [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/)을 사용해 격자 패턴을 선택하고, [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/)으로 연한 회색 배경을 지정하며, [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/)으로 노란색 패턴 색을 지정합니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![패턴 채우기가 적용된 직사각형](pattern-fill.png)

## **그림 채우기**

그림 채우기는 도형 내부에 이미지를 삽입합니다. 이 예제는 로컬 이미지를 필요로 하며, [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/)을 사용해 프레젠테이션의 이미지 컬렉션에 로드합니다. [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/)을 타일링 모드로 설정하면 이미지가 직사각형 내부에 반복됩니다. 아래에 사용된 원본 이미지는 다음과 같습니다:

![연꽃 사진](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![그림 채우기가 적용된 도형](picture-fill.png)

### **텍스처로 타일 그림 사용**

타일링된 그림을 텍스처로 설정하고 타일링 동작을 사용자 지정하려면 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) 클래스의 다음 속성을 사용할 수 있습니다:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): `TILE` 또는 `STRETCH` 중 하나를 설정합니다.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): 도형 내부에서 타일 정렬을 지정합니다.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): 타일을 수평, 수직 또는 두 방향 모두 뒤집을지 제어합니다.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): 도형 원점에서 타일의 수평 오프셋(포인트)을 설정합니다.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): 도형 원점에서 타일의 수직 오프셋(포인트)을 설정합니다.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): 타일의 수평 스케일을 백분율로 정의합니다.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): 타일의 수직 스케일을 백분율로 정의합니다.

이 예제는 로컬 이미지를 필요로 하며, 원본 크기의 50%로 반복하도록 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)을 구성합니다. `‑32`포인트 오프셋은 타일을 수평 및 수직으로 이동시키고, 오른쪽 아래 정렬 및 양방향 플립은 반복 텍스처가 배치되는 방식을 결정합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![타일 옵션](tile-options.png)

## **단색 채우기**

단색 채우기는 도형에 단일 색상을 적용합니다. 이 예제는 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)을 단색 채우기 모드로 설정하고, [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/)을 통해 노란색을 할당한 뒤 직사각형을 프레젠테이션에 저장합니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![단색 채우기가 적용된 도형](solid-color-fill.png)

## **슬라이드 배경을 도형 채우기로 사용**

슬라이드 배경과 일치하도록 도형을 설정하려면 [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/)을 사용하십시오(예: 프레젠테이션 템플릿). 먼저 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)을 [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)으로 설정해 명시적 채우기를 제거합니다. 이 조합을 사용하면 도형이 스타일 채우기가 아닌 슬라이드 배경을 사용합니다. 플래그만 활성화해도 기존 명시적 채우기는 제거되지 않습니다.

이는 [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)과는 다릅니다. 배경 채우기는 도형 뒤의 객체들을 슬라이드 배경 영역으로 가리게 하고, 무채색은 해당 객체들을 보이게 합니다. 그라디언트는 도형 내부가 아니라 슬라이드와 정렬됩니다.

다음 예제는 슬라이드가 상속하는 마스터 배경을 만들고, 세 직사각형 뒤에 마젠타 밴드를 배치합니다. 왼쪽 직사각형은 배경을 사용하고, 가운데 직사각형은 채우기 없음, 오른쪽 직사각형은 배경 채우기에서 명시적 주황색 채우기로 전환합니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # 마스터에서 그라디언트를 상속합니다.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # 이 개체를 먼저 추가하여 사각형 뒤에 나타나도록 합니다.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # 명시적 채우기를 적용하기 전에 배경 채우기를 비활성화합니다.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

결과(왼쪽→오른쪽): **배경 채우기**, **채우기 없음**, **명시적 채우기**. 마젠타 밴드는 왼쪽과 오른쪽 직사각형에 의해 가려지지만 가운데 직사각형을 통해서는 보입니다.

![마젠타 밴드 위에 배경 채우기, 채우기 없음 및 명시적 주황색 채우기](background-fill.png)

동일한 동작은 슬라이드에 직접 정의되었거나 레이아웃에서 상속된 배경에도 적용됩니다. 도형은 슬라이드의 해석된 배경을 사용합니다; 이 예제는 슬라이드와 레이아웃 배경을 모두 정의하지 않아 마스터가 제공하도록 합니다.

## **투명도 설정**

단색 채우기의 경우 색상의 알파 구성 요소가 불투명도를 제어합니다: 0은 완전 투명, 255는 완전 불투명합니다. 이 예제는 알파 값을 128로 설정해 노란색 직사각형을 약 50% 투명하게 만들어 아래에 있는 직사각형이 보이도록 합니다. 색상은 [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/)을 통해 할당됩니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![투명한 도형](shape-transparency.png)

## **도형 회전**

[Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/)을 사용해 슬라이드 평면에서 도형을 회전합니다. 각도는 도 단위이며, 이 예제는 직사각형을 시계 방향으로 5도 회전시킨 뒤 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![도형 회전](shape-rotation.png)

## **3D 베벨 효과 추가**

[Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/)을 사용해 도형에 깊이와 베벨 가장자리를 부여합니다. 이 예제는 녹색 타원을 만들고 주황색 윤곽선을 적용한 뒤, [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/)을 4포인트로 설정하고, [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/)을 사용해 너비와 높이가 6포인트인 원형 상단 베벨을 적용합니다. 정면 직각 카메라와 3점 조명이 베벨을 가시화합니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![3D 베벨 효과](3D-bevel-effect.png)

## **3D 회전 효과 추가**

도형의 3D 뷰는 카메라 설정으로 제어됩니다. 이 예제는 [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/)을 사용해 위도, 경도 및 회전 각도를 각각 40°, 35°, 20°로 설정합니다. [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/)을 통해 등각 카메라를 선택하고, [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/)을 사용해 균형 조명을 적용한 뒤 포맷된 직사각형을 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![3D 회전 효과](3D-rotation-effect.png)

## **도형의 흑백 렌더링 제어**

[Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) 속성은 프레젠테이션을 흑백 모드로 보거나 처리할 때 개별 도형이 어떻게 렌더링되는지를 지정합니다. 이 속성만으로 흑백 표시가 활성화되지는 않으며, 일반 색상 모드에서 도형의 채우기, 선 또는 기타 포맷이 변경되지는 않습니다.

[BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) 열거형의 값을 사용해 원하는 동작을 선택하십시오. 예를 들어 `AUTOMATIC`은 렌더링 애플리케이션이 변환을 선택하도록 하고, `GRAY`와 `LIGHT_GRAY`는 회색을 사용하며, `BLACK_WHITE`는 검정과 흰색만 사용하고, `BLACK`과 `WHITE`는 단일 색상을 강제하고, `COLOR`는 일반 색상을 유지하며, `HIDDEN`은 흑백 모드에서 도형을 생략합니다. `NOT_DEFINED`는 도형 수준 모드가 할당되지 않았음을 의미합니다.

이 예제는 주황색 직사각형을 만들고 [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/)을 회색으로 설정합니다. 저장된 도형은 일반 색상 표시에서는 주황색 채우기를 유지하고, 흑백 표시를 지원하는 애플리케이션에서는 회색으로 표시됩니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

일반 색상 모드에서는 직사각형이 주황색 채우기를 유지합니다. 흑백 표시 워크플로에서는 `GRAY` 모드가 적용되어 회색으로 표시됩니다. 이를 통해 전체 색상 슬라이드를 보존하면서 인쇄, 미리 보기 또는 흑백 표시 설정을 따르는 워크플로에 대해 별도 외관을 정의할 수 있습니다.

## **포맷 재설정**

[Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/)을 사용해 슬라이드 자리표시자의 위치, 크기 및 포맷을 해당 레이아웃 자리표시자와 일치하도록 복원합니다. 이 예제는 레이아웃에 연결된 자리표시자가 있는 기존 프레젠테이션을 필요로 하며, 저장하기 전에 모든 슬라이드를 재설정합니다. 대응되는 레이아웃 자리표시자가 없는 도형은 재설정되지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**도형 포맷이 최종 프레젠테이션 파일 크기에 영향을 줍니까?**

색상, 선 스타일 및 효과 설정은 일반적으로 삽입된 이미지 및 미디어에 비해 데이터가 거의 추가되지 않습니다. 그림 채우기는 이미지가 프레젠테이션에 저장되기 때문에 파일 크기를 증가시킬 수 있습니다.

**동일한 포맷을 공유하는 도형을 식별하여 그룹화하려면 어떻게 해야 하나요?**

각 도형의 핵심 포맷 속성(채우기, 선, 효과 설정)을 비교하십시오. 모든 해당 값이 일치하면 스타일을 동일하게 간주하고 논리적으로 해당 도형을 그룹화하면 이후 스타일 관리가 간소화됩니다.

**맞춤형 도형 스타일을 별도 파일에 저장해 다른 프레젠테이션에서 재사용할 수 있나요?**

예. 원하는 스타일이 적용된 샘플 도형을 템플릿 슬라이드 파일이나 .POTX 템플릿에 저장합니다. 새 프레젠테이션을 만들 때 템플릿을 열고 필요한 스타일 도형을 복제한 뒤 필요에 따라 포맷을 다시 적용합니다.