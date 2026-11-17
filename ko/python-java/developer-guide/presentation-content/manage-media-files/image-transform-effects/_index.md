---
title: Python으로 프레젠테이션에서 이미지 변환 효과 관리
linktitle: 이미지 변환 효과
type: docs
weight: 11
url: /ko/python-java/image-transform-effects/
keywords:
- 이미지 변환
- 사진 효과
- 밝기
- 대비
- 그레이스케일
- 듀오톤
- 틴트
- HSL
- 색상 교체
- 블러
- 투명도
- 알파 효과
- 효과 체인
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 사진 프레임에 대한 이미지 변환 효과를 적용, 체인 구성, 검사, 제거 및 검증합니다."
---
## **개요**

Aspose.Slides는 사진 조정을 이미지 변환 작업의 순서가 지정된 컬렉션으로 나타냅니다. 사진 프레임의 경우 프레임의 [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/)으로 시작하고 [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform)을 호출합니다. 반환된 [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/)을 사용하면 원본 이미지 바이트를 다시 쓰지 않고도 효과를 추가, 열거, 검사, 제거 및 삭제할 수 있습니다.

이 문서에서는 밝기 및 대비, 색상 변환, 흐림, 투명도, 순서가 지정된 효과 체인, 유효값, 제거, PPTX 라운드트립 검증을 위한 전체 워크플로를 보여줍니다.

## **효과 소유권 및 이미지 재사용 이해**

이미지 리소스와 이를 표시하는 사진은 서로 다른 객체입니다.

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/)은 프레젠테이션이 소유하는 원본 이미지 데이터를 저장하거나 참조합니다.
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/)은 사진 채우기에 속하고 이미지 리소스를 참조하면서 이미지 변환 컬렉션을 저장합니다.
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/)은 해당 사진 채우기, 기하학, 잘라내기 설정 및 기타 프레임 수준 서식을 소유하는 슬라이드 형태입니다.

따라서 이미지 변환 작업은 [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/)의 바이트를 수정하지 않습니다. 동일한 `PPImage`가 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame)에 여러 번 전달될 경우, 각 새 사진 프레임은 자체 `Picture`와 자체 변환 컬렉션을 받습니다. 한 프레임에 그레이스케일을 적용해도 다른 프레임은 그레이스케일이 적용되지 않으며, 모든 프레임이 동일한 임베디드 이미지 리소스를 재사용합니다.

같은 `Picture.getImageTransform` 모델은 도형이나 슬라이드 배경과 같은 다른 사진 채우기에서도 사용됩니다. 아래 예제는 사진 프레임에 초점을 맞춥니다.

## **유효 매개변수 범위 및 단위 사용**

시연된 메서드는 다음과 같은 의미 범위와 단위를 사용합니다. 특정 라이브러리 버전이 즉시 모든 범위 초과 값을 차단하지 않더라도 이 범위 내 값을 유지하십시오. 대상 프레젠테이션 형식이 저장 시 또는 PowerPoint가 파일을 열 때 잘못된 데이터를 정규화, 삭제 또는 거부할 수 있기 때문입니다.

| 작업 | 매개변수 | 유효 범위 및 단위 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100`부터 `100`까지, 백분율; `0`은 해당 구성 요소를 변경하지 않음. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | 숫자 매개변수 없음. 알파는 변경되지 않음. |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | 어두운 픽셀과 밝은 픽셀에 대한 두 색상. `java.awt.Color`의 RGB 및 알파 채널은 `0`부터 `255`까지 사용. |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | 색조는 `0` 포함부터 `360` 미포함까지, 도 단위; 양은 `-100`부터 `100`까지, 백분율. |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | 색조는 `0` 포함부터 `360` 미포함까지, 도 단위; 채도와 명도는 `-100`부터 `100`까지, 백분율. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | 교체 색상은 채널 값이 `0`부터 `255`까지. 기존 알파 값은 변경되지 않음. |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | 반경은 0 이상이며 포인트 단위; `grow`는 흐려진 내용이 원본 경계 밖으로 확장될 수 있는지 제어하는 Boolean. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | 0 이상의 백분율. 일반 불투명도 스케일링은 `0`부터 `100`까지 사용: `0`은 완전 투명, `100`은 기존 알파 유지. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0`부터 `100`까지, 백분율 불투명도. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0`부터 `100`까지, 백분율 알파 임계값. 임계값 이하인 값은 투명, 임계값 이상은 불투명. |

고정 알파 변조의 경우 투명도와 불투명도는 상보적입니다. 예를 들어 35% 투명도는 알파 변조 값 65%에 해당합니다.

## **밝기 및 대비 적용**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) 은 [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) 작업을 반환합니다. 스칼라 설정은 작업 생성 시 제공됩니다. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) 은 계산된 읽기 전용 값을 반환하며 검사하거나 기록할 수 있습니다.

다음 예제는 밝기를 15%, 대비를 20% 증가시킨 뒤, 임베디드 이미지를 변경하지 않고 미리보기를 렌더링합니다.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) 은 Office 2010 사진 효과 확장이며 표준 DrawingML 명도 효과보다 이동성이 낮습니다. 밝기와 대비를 PPTX 라운드트립 후에도 편집 가능하게 유지하려면 [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect)를 사용하고 파일을 다시 연 후 결과를 검증하십시오. 형식 제한 섹션에서 이 구분을 더 자세히 설명합니다.

## **색상 변환 적용**

색상 효과는 동일한 이미지 리소스를 재사용하는 서로 다른 사진 프레임에 독립적으로 적용할 수 있습니다. 다음 예제는 다섯 개 프레임을 만들고 그레이스케일, 듀오톤, 틴트, HSL 조정 및 색상 교체를 적용합니다.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) 은 두 개의 독립적으로 편집 가능한 색상 매개변수 `color1`(어두운 픽셀)과 `color2`(밝은 픽셀)를 가집니다. 이는 단일 스칼라 값보다 복잡한 설정을 가진 효과의 좋은 예시입니다.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) 은 알파를 유지하면서 모든 픽셀 색상을 고정 색상으로 교체합니다. 이는 한 원본 색상을 다른 색상으로 매핑하고 원본 및 대상 색상 형식을 모두 노출하는 [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) 와 다릅니다.

### **명도 임계값 적용**

명도 임계값은 스캔한 페이지의 미세한 흔적을 배경과 구분하기 쉽게 합니다. [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) 은 중간 회색 음영을 유지합니다. [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) 은 명도를 검정 또는 백색으로 매핑하고, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) 은 불투명도에 임계값을 적용합니다.

명도 임계값 범위는 0%에서 100%까지, 포함입니다. 임계값 이하 픽셀은 검정이 되고, 임계값 이상 픽셀은 백색이 됩니다. 임계값을 높이면 더 많은 음영이 검정이 됩니다(임계값 이하가 더 많아짐).

[grayscale-swatches.png](grayscale-swatches.png) 파일을 작업 디렉터리로 다운로드하십시오. 각 레이블은 0~255 스케일에서 원본 회색 수준을 나타냅니다. 예제는 원본을 두 복사본과 나란히 배치하고 각 복사본의 임계값을 프레젠테이션에 저장합니다.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720.0, 150.0, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    image_data = Path("grayscale-swatches.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    frames = []
    for index, caption in enumerate(("Original", "Threshold 20%", "Threshold 60%")):
        x = 12 + 240 * index
        label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36)
        label.getTextFrame().setText(caption)
        frame = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image)
        frames.append(frame)

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20.0)
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60.0)

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

출력 프레젠테이션을 PowerPoint에서 열어 세 프레임을 비교하십시오. 레이블 96은 약 38% 명도(255 중 96)이며 20% 임계값에서는 백색, 60% 임계값에서는 검정이 됩니다.

![원본 그레이스케일 스와치와 명도 임계값 20% 및 60%에서의 흑백 결과](luminance-threshold.png)

## **흐림, 투명도 및 알파 효과 추가**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) 은 알파를 포함한 모든 색상 채널에 영향을 미칩니다. 흐린 가장자리가 원본 사진 경계를 넘어설 수 있으면 `grow` 를 `True` 로 설정하십시오.

균일한 투명도를 위해 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) 를 사용합니다. 이것은 기존 알파 값을 모두 곱하므로 부분 투명 픽셀은 비례적으로 차이를 유지합니다. [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) 은 모든 픽셀에 하나의 알파 값을 할당합니다. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) 은 임계값에 따라 알파를 두 수준으로 변환합니다.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

매개변수가 없는 다른 알파 작업에는 [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect) (0이 아닌 모든 알파를 완전 불투명으로), [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect) (100% 미만 알파를 완전 투명으로), [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect) (알파를 `100% - alpha` 로 변환) 이 있습니다.

## **순서가 지정된 효과 체인 구축**

각 `add...Effect` 메서드는 새로운 작업을 컬렉션 끝에 추가합니다. 렌더러는 컬렉션을 순서가 지정된 파이프라인으로 사용합니다: 작업 0의 출력이 작업 1의 입력이 되고, 이런 식으로 진행됩니다. 따라서 같은 작업이라도 순서를 바꾸면 다른 이미지가 생성될 수 있습니다.

예를 들어, 그레이스케일 후 틴트는 색상 정보를 먼저 제거하고 그 후에 명도 결과를 재색칠합니다. 틴트 후 그레이스케일은 틴트를 다시 제거합니다. 마찬가지로 알파 교체는 이전 작업에서 계산된 알파 값을 덮어쓸 수 있고, 알파 변조는 상대적 차이를 유지합니다.

다음 예제는 네 단계 체인을 만들고 PPTX 로 저장한 뒤 프레젠테이션을 다시 열어 작업 유형과 순서를 확인하고 다시 연 결과를 렌더링합니다.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

컬렉션은 색상, 알파 및 흐림 작업을 별도 체인으로 제한하는 호환성 매트릭스를 강제하지 않습니다. 결합은 가능하지만 항상 유용한 것은 아닙니다. 고정 색상 교체는 이전 색상 효과가 만든 RGB 변화를 제거하고, 듀오톤 후 그레이스케일은 두 선택 색상을 제거하며, 알파 천장, 바닥, 교체 또는 이레벨 작업은 이전에 만든 알파 세부 정보를 삭제할 수 있습니다. 원하는 픽셀 처리 순서에 따라 체인을 구축하고, 항목을 무순서 서식 플래그처럼 취급하지 마십시오.


<!-- visual-explanation:image-transform-effects:start -->
[![동일 이미지가 그레이스케일 후 틴트, 그리고 틴트 후 그레이스케일을 통과합니다. 두 최종 그레이스케일 이미지의 톤이 다릅니다.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Aspose.Slides for .NET 26.11 렌더에서 220° 틴트를 25% 적용하면 그레이스케일 이미지가 변경되지 않습니다. 동일한 틴트를 그레이스케일 전에 적용하면 다른 톤이 생성됩니다.*
<!-- visual-explanation:image-transform-effects:end -->

## **편집 가능 및 유효값 검사**

편집 가능한 작업은 `Picture.getImageTransform` 에 저장된 객체입니다. 효과에 따라 직접 쓰기 가능한 멤버를 노출할 수 있습니다. 예를 들어, [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) 은 쓰기 가능한 `radius`와 `grow` 값을, [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) 은 쓰기 가능한 `amount` 를, [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) 은 쓰기 가능한 `threshold` 를 노출합니다. [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) 과 같은 색상 효과는 가변 [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/) 객체를 노출합니다.

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/), [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/) 와 같은 일부 작업 클래스는 생성 스칼라를 쓰기 가능한 속성으로 노출하지 않습니다. 이러한 설정을 변경하려면 작업을 제거하고 원하는 위치에 교체 작업을 추가하십시오.

`getEffective` 로 반환된 유효 데이터는 계산된 읽기 전용 값입니다. 테마 의존 색상을 해결하고 렌더러가 사용하는 정규화 값을 읽는 데 유용하지만 또 다른 편집 표면은 아닙니다. 다음 예제는 체인을 열거하고 해당 API가 제공하는 경우 유효값을 검사합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

그레이스케일, 알파 천장, 알파 역전과 같은 매개변수 없는 효과도 유효 데이터 객체를 가지지만 출력할 스칼라 설정이 없습니다. 컬렉션 내 존재와 위치가 중요한 정보입니다.

## **이미지 변환 제거 또는 삭제**

[ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) 을 사용하여 인덱스로 하나의 작업을 제거하십시오. 인덱스는 제거 후 이동하므로 먼저 대상 작업을 찾고 열거가 끝난 뒤 제거하십시오. [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) 을 사용하면 전체 체인을 삭제할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

변환을 제거하거나 삭제해도 사진 서식만 변경됩니다. 재사용되는 [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) 리소스는 삭제, 재압축 혹은 다른 방식으로 변경되지 않습니다.

## **프레젠테이션 형식 및 내보내기 대상 고려**

이미지 변환은 DrawingML에서 시작되므로 효과 체인에 가장 적합한 편집 형식은 PPTX 입니다. PPTX 라도 모든 작업이 동일한 이동성을 가지는 것은 아닙니다.

- 명도, 그레이스케일, 듀오톤, 틴트, HSL, 흐림 및 일반 알파 작업과 같은 표준 DrawingML 작업은 PPTX 라운드트립에서 살아남을 확률이 가장 높습니다. 지속성이 요구될 경우 생성된 파일을 다시 열어 컬렉션을 검사하십시오.
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) 은 표준 DrawingML 명도 작업이 아닌 Office 2010 확장입니다. 메모리 내 렌더링에는 사용할 수 있지만 PPTX 저장·재열기 후에도 편집 가능한 [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) 로 남을 보장은 없습니다. 지속적인 밝기·대비 조정에는 [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) 사용을 권장합니다.
- 이진 PPT 형식은 전체 DrawingML 효과 모델보다 오래되었습니다. PPT 로 저장하면 지원되지 않는 작업이 누락되거나 체인이 지원되는 하위 집합으로 축소되거나 외관이 근사될 수 있습니다. 복잡한 편집 체인의 검증 형식으로 PPT 를 사용하지 마십시오.
- PNG, JPEG, TIFF, PDF, SVG, HTML 등 시각 출력은 지원되는 체인을 렌더링된 모양에 적용합니다. 이러한 출력에는 편집 가능한 `ImageTransformOperationCollection` 이 포함되지 않으며, 래스터 형식은 결과를 픽셀로 평탄화하고, 문서/벡터 내보내기는 자체 렌더링 표현을 저장합니다.
- 효과는 연결된 이미지를 자체 포함형으로 만들지 않습니다. 연결된 사진을 렌더링하려면 프레젠테이션이 로드될 때 연결된 리소스가 여전히 접근 가능해야 합니다.

다양한 프레젠테이션 소비자는 특히 여러 알파 또는 색상 양자화 작업이 결합된 경우 가장자리 경우를 다르게 렌더링할 수 있습니다. 중요한 출력의 경우 같은 Aspose.Slides 버전을 사용해 편집 가능한 라운드트립과 최종 내보내기 형식 모두를 테스트하십시오.

## **FAQ**

**이미지 변환 효과가 임베디드 이미지 데이터를 수정합니까?**

아니요. 작업은 사진 채우기에 사용되는 `Picture` 에 귀속됩니다. 기본 `PPImage` 바이트는 변경되지 않습니다.

**동일한 이미지를 재사용하는 두 사진 프레임이 효과를 공유합니까?**

아니요. `PPImage` 를 재사용하면 이미지 데이터 중복을 방지하지만 각 사진 프레임은 일반적으로 별도의 `Picture`와 이미지 변환 컬렉션을 가집니다.

**색상, 흐림 및 알파 효과를 결합할 수 있습니까?**

예. 컬렉션은 하나의 순서가 지정된 체인에 모두 수용합니다. 이전 작업의 출력을 기반으로 각 작업이 무엇을 하는지 고려하십시오. 교체 및 임계값 작업은 이전 색상이나 알파 세부 정보를 삭제할 수 있습니다.

**왜 유효값은 읽기 전용입니까?**

유효 데이터는 렌더링에 사용되는 계산된 값(색상 해결 포함)을 나타냅니다. 쓰기 가능한 멤버가 있는 경우 변환 컬렉션에 저장된 작업을 편집하십시오; 그렇지 않다면 작업을 제거하고 새로운 생성 매개변수로 교체하십시오.

**어떤 형식으로 변환 체인을 보존해야 합니까?**

PPTX 를 사용하고 파일을 다시 열어 확인하십시오. 레거시 PPT 는 전체 DrawingML 효과 모델을 표현할 수 없으며, 렌더링된 내보내기 형식은 편집 가능한 변환 작업이 아니라 외관만 보존합니다.