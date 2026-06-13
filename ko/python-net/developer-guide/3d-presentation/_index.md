---
title: Python을 사용한 프레젠테이션 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/python-net/3d-presentation/
keywords:
- 3D 파워포인트
- 3D 프레젠테이션
- 3D 회전
- 3D 깊이
- 3D 압출
- 3D 그라데이션
- 3D 텍스트
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 압출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for Python via .NET는 모양 및 텍스트에 대한 PowerPoint 스타일 3D 서식을 만들고, 편집하고, 보존하고, 렌더링할 수 있습니다. 이 문서에서는 회전, 압출, 베벨, 조명, 재질, 그라데이션 또는 그림 채우기, 그리고 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="primary" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함되지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때, Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

도형에 3D 서식을 적용하려면 [Shape.three_d_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/three_d_format/) 속성을 사용합니다. 이 속성은 해당 도형의 3D 씬을 제어하는 [ThreeDFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/)을 노출합니다.

텍스트의 경우, [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/three_d_format/) 속성을 사용합니다. 이는 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 속성은 다음과 같습니다:

| 속성 | 제어하는 내용 | 사용 시점 |
|---|---|---|
| [camera](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/camera/) | 시점, 사전 설정 카메라 유형, 회전, 줌 및 원근. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 사전 설정에 맞춥니다. |
| [light_rig](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/light_rig/) | 조명 사전 설정, 방향 및 조명 회전. | 3D 표면의 하이라이트와 그림자 표시 방식을 변경합니다. |
| [material](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/material/) | 평면, 매트, 플라스틱, 금속 등 표면 재질. | 동일한 형상의 모습을 더 평평하게, 부드럽게, 광택 있게, 혹은 금속처럼 만들 수 있습니다. |
| [extrusion_height](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/extrusion_height/) | 전면 면으로부터 도형이 뒤로 얼마나 확장되는지. | 평면 도형을 눈에 보이는 두꺼운 3D 객체로 전환합니다. |
| [extrusion_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/extrusion_color/) | 압출된 면의 색상. | 깊이를 보이게 하거나 전면 채우기와 색을 맞춥니다. |
| [depth](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/depth/) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 도형이나 텍스트의 깊이를 미세 조정하며, 특히 베벨 및 재질 설정과 함께 사용합니다. |
| [bevel_top](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/bevel_top/) 및 [bevel_bottom](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/bevel_bottom/) | 전면 및 후면 면의 올려진 또는 둥근 가장자리. | 날카로운 평면 대신 부드럽거나 몰딩된 가장자리를 추가합니다. |
| [contour_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/contour_color/) 및 [contour_width](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/contour_width/) | 3D 객체 둘레의 외곽선 색상. | 렌더링된 출력에서 객체 경계를 강조합니다. |

## **3D 도형 만들기**

- 카메라 설정(기본 전면 뷰가 압출을 숨길 수 있기 때문).
- 조명 설정(조명이 면과 측면을 읽을 수 있게 함).
- 재질 설정(표면이 빛에 어떻게 렌더링되는지 영향을 줌).
- 압출 또는 깊이 설정(평면 도형에 두께가 필요함).

다음 예제는 사각형을 만들고, 전면에 텍스트를 추가하고, 3D 서식을 적용한 뒤, 프레젠테이션을 PPTX로 저장하고 슬라이드를 PNG 이미지로 렌더링합니다.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

렌더링된 슬라이드 이미지는 사각형을 두꺼운 3D 블록으로 보여줍니다:

![전면에 흰색 3D 텍스트가 있는 파란색 3D 사각형 렌더링](img_01_01.png)

## **카메라로 도형 회전하기**

PowerPoint에서 3D 회전은 3‑D 회전 창에서 구성합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전에 해당합니다.

![PowerPoint 3‑D 회전 창에 X, Y, Z 회전 값이 강조된 모습](img_02_01.png)

Aspose.Slides에서는 [ThreeDFormat.camera](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/camera/)를 통해 카메라 유형과 회전을 설정합니다:

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

시청자가 객체를 보는 방식을 변경해야 할 때 카메라를 사용합니다. 이는 슬라이드상의 2D 도형 기하학을 바꾸지는 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 관점을 변경합니다.

## **압출 및 깊이 추가**

압출은 전면 면 뒤로 도형을 확장시켜 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 가시적인 두께를 설정하고, 색상 제어는 측면 면의 색을 설정합니다.

![PowerPoint 깊이 제어가 압출 색상 및 압출 높이 속성에 매핑된 모습](img_02_02.png)

두께는 [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/extrusion_height/)로, 측면 색은 [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/extrusion_color/)으로 설정합니다:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

PowerPoint의 깊이 값을 직접 다루거나 깊이를 베벨, 재질, 텍스트 효과와 결합해야 할 때는 [ThreeDFormat.depth](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/depth/)를 사용합니다. 많은 도형 시나리오에서는 가시적인 압출을 직접 나타내는 [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/extrusion_height/)가 더 명확한 설정입니다.

## **그라데이션 또는 그림 채우기를 3D 효과와 함께 사용하기**

3D 서식은 도형 채우기와 독립적입니다. 전면에 단색, 그라데이션, 패턴 또는 그림 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 압출 설정을 사용할 수 있습니다.

다음 예제는 도형에 그라데이션 채우기를 적용하고 측면에 어두운 압출 색을 지정합니다:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

렌더링된 결과는 전면에 그라데이션을 유지하고 압출을 별도로 렌더링합니다:

![파란색에서 주황색으로 그라데이션 채우기와 주황색 압출이 적용된 3D 사각형 렌더링](img_02_03.png)

그 대신 그림 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기에 할당합니다:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

그림은 전면에 렌더링되고, 압출은 3D 측면 표면으로 렌더링됩니다:

![전면에 사진 채우기와 주황색 압출이 적용된 3D 사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 문자 자체에 압출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 패턴 채우기가 적용된 텍스트를 만들고, WordArt 변환을 적용한 뒤, [TextFrameFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/)에 3D 설정을 구성합니다:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

텍스트는 곡선 형태의 압출된 3D 글자로 렌더링됩니다:

![아치형 WordArt 변환, 주황색 패턴 채우기 및 어두운 압출이 적용된 3D 텍스트 렌더링](img_02_05.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 씬은 2D 결과물로 래스터화되거나 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/python-net/convert-powerpoint-to-png/)로 렌더링하거나, [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/python-net/convert-powerpoint-to-html/)로 내보내거나, [동영상 변환](/slides/ko/python-net/convert-powerpoint-to-video/)을 위한 프레임을 생성할 때 적용됩니다.

중요한 점은 다음과 같습니다:

- 내보낸 이미지와 PDF는 대화형이 아닙니다. 내보낸 후에는 사용자가 객체를 회전할 수 없습니다.
- 최종 모양은 카메라, 라이트 릭, 재질, 압출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인해야 하면 [effective shape properties](/slides/ko/python-net/shape-effective-properties/)를 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정이 아니라 렌더링된 이미지로 저장됩니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 도형과 텍스트에 대한 PowerPoint 3D 효과를 만들고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 인터랙티브 3D 씬으로 만들어 사용자가 회전할 수 있게 하지는 못합니다. PPTX에서는 형식이 지원되는 경우 3D 서식이 PowerPoint에서 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이점은 무엇인가요?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 일반 PowerPoint 도형이나 텍스트에 적용되는 서식으로, 회전, 압출, 베벨, 조명, 재질 등을 포함합니다. 이 문서는 3D 효과에 대해 설명합니다.

**가시적인 3D 도형을 만들려면 어떤 설정이 필요합니까?**

최소한 카메라 회전과 압출 또는 깊이를 설정해야 합니다. 실제로는 라이트 릭과 재질도 설정하여 렌더링된 면에 명확한 하이라이트와 그림자가 나타나도록 합니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예. 도형 본문에는 [Shape.three_d_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/three_d_format/)를, 텍스트에는 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/three_d_format/)를 사용합니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 표시됩니까?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환용 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 결과물은 렌더링된 외관을 포함하지만, 편집 가능한 3D 객체는 아닙니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있나요?**

예. 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽으려면 [Shape Effective Properties](/slides/ko/python-net/shape-effective-properties/)에 설명된 효율적인 서식 API를 사용하십시오.