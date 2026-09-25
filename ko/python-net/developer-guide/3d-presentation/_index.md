---
title: Python을 사용하여 프레젠테이션에 3D 효과 만들기
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
- 3D 그라디언트
- 3D 텍스트
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 압출, 채우기 및 3D 텍스트를 구성합니다."
---
## **Overview**

Aspose.Slides for Python via .NET는 도형 및 텍스트에 대해 PowerPoint 스타일 3D 서식을 만들고, 편집하고, 유지하며, 렌더링할 수 있습니다. 이 문서에서는 회전, 압출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기, 그리고 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" title="참고" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함되지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D Formatting Concepts**

도형에 3D 서식을 적용하려면 [Shape.three_d_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/three_d_format/) 속성을 사용합니다. 이 속성은 해당 도형의 3D 장면을 제어하는 [ThreeDFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/)을 노출합니다.

텍스트의 경우 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/three_d_format/) 속성을 사용합니다. 이는 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 속성은 다음과 같습니다.

| 속성 | 제어하는 내용 | 사용 시점 |
|---|---|---|
| [camera](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/camera/) | 시점, 미리 설정된 카메라 유형, 회전, 줌 및 원근. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 프리셋에 맞춥니다. |
| [light_rig](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/light_rig/) | 조명 프리셋, 방향 및 조명 회전. | 3D 표면의 하이라이트와 그림자 모습을 변경합니다. |
| [material](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/material/) | 평면, 매트, 플라스틱, 금속 등 표면 재질. | 동일한 형태를 더 평평하게, 부드럽게, 광택 있게 또는 금속처럼 보이게 합니다. |
| [extrusion_height](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/extrusion_height/) | 도형이 앞면으로부터 뒤쪽으로 얼마나 뻗어 있는지. | 평면 도형을 눈에 보이는 두께가 있는 3D 객체로 바꿉니다. |
| [extrusion_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/extrusion_color/) | 압출된 측면의 색상. | 깊이를 가시화하거나 측면 색을 앞면 채우기와 맞춥니다. |
| [depth](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/depth/) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 베벨 및 재질 설정과 함께 도형이나 텍스트의 깊이를 미세 조정합니다. |
| [bevel_top](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/bevel_top/) 및 [bevel_bottom](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/bevel_bottom/) | 앞면과 뒷면의 올려진 또는 둥근 모서리. | 날카로운 평면 대신 부드럽거나 몰딩된 모서리를 추가합니다. |
| [contour_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/contour_color/) 및 [contour_width](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/contour_width/) | 3D 객체 주변의 외곽선. | 렌더링된 출력에서 객체 경계를 강조합니다. |

## **Create a 3D Shape**

도형이 설득력 있게 3D처럼 보이려면 보통 네 가지 설정이 필요합니다.

- 카메라 설정, 기본 앞쪽 보기가 압출을 숨길 수 있기 때문에.
- 조명 설정, 조명이 면과 측면을 읽히게 만들기 때문에.
- 재질 설정, 표면이 빛이 어떻게 렌더링되는지에 영향을 주기 때문에.
- 압출 또는 깊이 설정, 평면 도형에 두께가 필요하기 때문에.

다음 예제는 사각형을 만들고 앞면에 텍스트를 추가한 뒤 3D 서식을 적용합니다. 카메라 회전 값은 도이고, 압출 높이는 100포인트입니다. 예제는 슬라이드를 PNG 이미지로 기본 크기의 두 배로 렌더링하고 프레젠테이션을 PPTX로 저장합니다.

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

렌더링된 슬라이드 이미지는 사각형을 두꺼운 3D 블록으로 보여 줍니다:

![렌더링된 파란색 3D 사각형, 앞면에 흰색 3D 텍스트] (img_01_01.png)

## **Rotate a Shape with the Camera**

PowerPoint에서 3D 회전은 3‑D 회전 창에서 설정합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전과 일치합니다.

![PowerPoint 3‑D 회전 창, X, Y, Z 회전 값이 강조 표시됨] (img_02_01.png)

Aspose.Slides에서는 [ThreeDFormat.camera](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/camera/)를 통해 카메라에 접근합니다. 이 예제는 사각형을 만들고 정사영 앞쪽 보기를 선택한 뒤 X, Y, Z 회전을 각각 20°, 30°, 40°로 설정합니다. 파일을 저장하지 않고 메모리 내에서 도형을 구성합니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

시청자가 객체를 보는 방식을 변경해야 할 때 카메라를 사용합니다. 이는 슬라이드의 2D 도형 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점을 변경합니다.

## **Add Extrusion and Depth**

압출은 앞면 뒤로 도형을 확장시켜 두껍게 보이게 합니다. PowerPoint에서 깊이 조절은 이 가시적인 두께를 설정하고, 색상 조절은 측면 면의 색을 지정합니다.

![PowerPoint 깊이 조절이 압출 색 및 압출 높이 속성에 매핑됨] (img_02_02.png)

두께를 위해 [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/extrusion_height/)을, 측면 색을 위해 [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/extrusion_color/)을 설정합니다. 이 예제는 사각형에 100포인트 압출과 보라색 측면을 부여하고 카메라를 회전시켜 두께를 드러냅니다. 파일을 저장하지 않고 메모리 내에서 도형을 구성합니다:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

[ThreeDFormat.depth](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/depth/) 속성은 3D 도형의 깊이를 설정합니다. [extrusion_height](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/extrusion_height/) 속성은 이 예제와 같이 압출 효과의 높이를 제어합니다.

## **Use Gradient or Picture Fills with 3D Effects**

3D 서식은 도형 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 압출 설정을 사용할 수 있습니다.

이 예제는 앞면에 파란색‑주황색 그라디언트를 적용하고 150포인트 압출에 어두운 주황색을 사용합니다. 그라디언트 정지는 0과 100에서 시작과 끝을 표시합니다. 카메라 회전 값은 도이며, 슬라이드는 기본 크기의 두 배인 PNG 이미지로 렌더링됩니다:

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

![그라디언트 채우기와 주황색 압출이 적용된 3D 사각형 렌더링] (img_02_03.png)

그림 채우기를 사용하려면 이미지 파일을 프레젠테이션에 추가하고 도형 채우기에 할당합니다. 이 예제는 작업 디렉터리에 "image.jpg"라는 파일이 존재한다고 가정합니다. 그림을 사각형에 맞게 늘이고 150포인트 압출을 적용하며 카메라 회전을 도 단위로 설정합니다. 파일을 저장하거나 렌더링하지 않고 메모리 내에서 도형을 구성합니다:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

![앞면에 사진 채우기와 주황색 압출이 적용된 3D 사각형 렌더링] (img_02_04.png)

## **Apply 3D Formatting to Text**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 문자 자체에 압출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 주황‑흰색 격자 패턴 텍스트를 만들고 위쪽 아치를 적용한 뒤 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/three_d_format/)을 통해 3D 설정을 구성합니다. 압출 높이와 깊이는 포인트 단위이며, 조명 회전은 도 단위입니다. 도형 채우기와 외곽선은 숨겨져 텍스트만 보이게 합니다. 예제는 기본 슬라이드 크기의 두 배인 PNG 이미지로 렌더링하고 프레젠테이션을 PPTX로 저장합니다:

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

![아치형 WordArt 변환, 주황색 패턴 채우기 및 어두운 압출이 적용된 3D 텍스트 렌더링] (img_02_05.png)

## **Keep Text Flat on a 3D Shape**

텍스트를 읽기 쉽게 유지하면서 도형의 3D 외관을 보존하려면 [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/keep_text_flat/)을 [TextFrame.text_frame_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/text_frame_format/)을 통해 설정합니다. 값이 `True`이면 텍스트가 3D 장면에서 제외됩니다. `False`이면 텍스트가 장면에 포함되어 3D 방향을 따릅니다.

이 설정은 도형의 3D 서식을 제거하지 않습니다: 카메라, 조명, 재질 및 압출은 [Shape.three_d_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/three_d_format/)을 통해 계속 구성됩니다. 또한 일반 회전과는 다릅니다. [Shape.rotation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/rotation/)은 슬라이드 평면에서 도형을 회전시키고, [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/rotation_angle/)은 텍스트가 자신의 경계 상자 내에서 커스텀 회전하도록 제어합니다. 텍스트를 3D 장면에서 제외해도 이 각도들은 초기화되지 않습니다.

다음 자체 포함 예제는 텍스트가 있는 파란 사각형을 만들고 원본 옆에 복제합니다. 두 도형 모두 동일한 3D 서식을 갖지만 텍스트 설정만 다릅니다: 왼쪽은 `False`, 오른쪽은 `True`. 카메라 각도는 도이며 압출 높이는 40포인트입니다. 예제는 프레젠테이션을 PPTX로 저장하고 비교 슬라이드를 기본 크기의 두 배인 PNG로 렌더링합니다:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

왼쪽에서는 텍스트가 3D 방향을 따릅니다. 오른쪽에서는 텍스트가 평면을 유지해 읽기 쉬워집니다. 두 사각형 모두 동일한 가시적 압출과 3D 방향을 유지합니다.

![좌측은 keep_text_flat이 False, 우측은 True인 3D 사각형 나란히] (keep_text_flat.png)

## **Export and Rendering Behavior**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 2D 결과로 래스터화되거나 출력에 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/python-net/convert-powerpoint-to-png/)로 렌더링하거나, [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/python-net/convert-powerpoint-to-html/)로 내보내거나, [비디오 변환](/slides/ko/python-net/convert-powerpoint-to-video/)용 프레임을 생성할 때 적용됩니다.

다음 사항을 기억하세요:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 내보낸 후에는 사용자가 객체를 회전시킬 수 없습니다.
- 최종 외관은 카메라, 라이트 릭, 재질, 압출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인해야 하면 [effective shape properties](/slides/ko/python-net/shape-effective-properties/)를 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 렌더링되어 저장되며 편집 가능한 3D 설정은 보존되지 않습니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 도형과 텍스트에 대한 PowerPoint 3D 효과를 만들고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 인터랙티브 3D 씬으로 만들어 사용자가 회전할 수 있게 하지는 않습니다. PPTX에서는 형식이 지원되는 경우 3D 서식이 PowerPoint에서 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이점은 무엇인가요?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 일반 PowerPoint 도형이나 텍스트에 적용되는 회전, 압출, 베벨, 조명, 재질 등의 서식입니다. 이 문서는 3D 효과에 대해 설명합니다.

**보이는 3D 도형을 만들려면 어떤 설정이 필요하나요?**

최소한 카메라 회전과 압출 또는 깊이를 설정해야 합니다. 실제로는 라이트 릭과 재질도 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예. 도형 본문에는 [Shape.three_d_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/three_d_format/)을, 텍스트에는 [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/three_d_format/)을 사용합니다.

**이미지, PDF, HTML, 비디오 프레임으로 내보낼 때 3D 효과가 표시되나요?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 결과물은 렌더링된 모습이며, 편집 가능한 3D 객체는 아닙니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있나요?**

예. [Shape Effective Properties](/slides/ko/python-net/shape-effective-properties/)에 설명된 효율적 서식 API를 사용하여 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽을 수 있습니다.