---
title: Python을 사용한 프레젠테이션에서 이미지 변환 효과 관리
linktitle: 이미지 변환 효과
type: docs
weight: 11
url: /ko/python-java/image-transform-effects/
keywords:
- 이미지 변환
- 그림 효과
- 밝기
- 대비
- 그레이스케일
- 듀오톤
- 색조
- HSL
- 색상 교체
- 흐림
- 투명도
- 알파 효과
- 효과 체인
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 그림 프레임에 대한 이미지 변환 효과를 적용하고, 체인화하고, 검사하고, 제거하며, 검증합니다."
---
## **개요**

Aspose.Slides는 그림 조정을 이미지 변환 작업의 순서가 지정된 컬렉션으로 나타냅니다. 그림 프레임의 경우, 프레임의 [Picture](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picture/)에서 시작하여 [Picture.getImageTransform](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picture/#getImageTransform)를 호출합니다. 반환된 [ImageTransformOperationCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/)을 사용하면 원본 이미지 바이트를 다시 쓰지 않고도 효과를 추가, 열거, 검사, 제거 및 지울 수 있습니다.

이 문서는 밝기와 대비, 색상 변환, 흐림, 투명도, 순서가 지정된 효과 체인, 유효값, 제거 및 PPTX 왕복 검증을 위한 전체 워크플로를 보여줍니다.

## **효과 소유권 및 이미지 재사용 이해**

이미지 리소스와 이를 표시하는 그림은 서로 다른 객체입니다:

- [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/)은 프레젠테이션이 소유한 원본 이미지 데이터를 저장하거나 참조합니다.
- [Picture](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picture/)는 그림 채우기에 속하며 이미지 리소스를 가리키면서 이미지 변환 컬렉션을 저장합니다.
- [PictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/)은 해당 그림 채우기, 기하학, 자르기 설정 및 기타 프레임 수준 서식을 소유하는 슬라이드 도형입니다.

따라서 이미지 변환 작업은 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/)의 바이트를 수정하지 않습니다. 동일한 `PPImage`를 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addPictureFrame) 에 여러 번 전달하면, 각 새 그림 프레임은 자체 `Picture`와 자체 변환 컬렉션을 갖게 됩니다. 한 프레임에 그레이스케일을 적용해도 다른 프레임은 그레이스케일이 되지 않으며, 모든 프레임이 동일한 내장 이미지 리소스를 재사용하더라도 마찬가지입니다.

같은 `Picture.getImageTransform` 모델은 도형이나 슬라이드 배경과 같은 다른 그림 채우기에도 사용됩니다. 아래 예제는 그림 프레임에 초점을 맞춥니다.

## **유효 매개변수 범위 및 단위 사용**

시연된 메서드는 다음과 같은 의미 범위와 단위를 사용합니다. 특정 라이브러리 버전이 즉시 모든 범위 초과 값을 거부하지 않더라도, 대상 프레젠테이션 형식은 저장 시 또는 PowerPoint가 파일을 열 때 범위를 정규화, 생략 또는 거부할 수 있습니다.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100`~`100`, 퍼센트; `0`은 해당 구성 요소를 변경하지 않음. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | 숫자 매개변수 없음. 알파는 변경되지 않음. |
| [addDuotoneEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | 어두운 픽셀과 밝은 픽셀을 위한 두 색상. `java.awt.Color`의 RGB 및 알파 채널은 `0`~`255` 범위. |
| [addTintEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | `hue`는 `0` 이상 `360` 미만, 도 단위; `amount`는 `-100`~`100`, 퍼센트. |
| [addHSLEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | `hue`는 `0` 이상 `360` 미만, 도 단위; `saturation`과 `luminance`는 `-100`~`100`, 퍼센트. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | 교체 색상은 `0`~`255` 범위의 채널 값을 사용. 기존 알파 값은 변경되지 않음. |
| [addBlurEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | `radius`는 음수가 아니며 포인트 단위; `grow`는 흐려진 콘텐츠가 원본 경계를 넘어설 수 있는지 제어하는 부울값. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | 음수가 아닌 퍼센트. 일반적인 불투명도 스케일링은 `0`~`100` 사용: `0`은 완전 투명, `100`은 기존 알파 유지. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0`~`100`, 퍼센트 불투명도. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0`~`100`, 퍼센트 알파 임계값. 임계값 이하 값은 투명, 임계값 이상은 불투명. |

고정 알파 변조의 경우 투명도와 불투명도는 보완 관계에 있습니다. 예를 들어 35% 투명도는 알파 변조값 65%에 해당합니다.

## **밝기와 대비 적용**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect)는 [BrightnessContrast](https://reference.aspose.com/slides/ko/python-java/aspose.slides/brightnesscontrast/) 작업을 반환합니다. 스칼라 설정은 작업 생성 시 제공됩니다. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/ko/python-java/aspose.slides/brightnesscontrast/#getEffective) 은 읽기 전용 계산값을 반환하며, 이를 검사하거나 로그에 기록할 수 있습니다.

다음 예제는 밝기를 15% 증가시키고 대비를 20% 증가시킨 뒤, 내장 이미지를 수정하지 않고 미리보기를 렌더링합니다:

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

[BrightnessContrast](https://reference.aspose.com/slides/ko/python-java/aspose.slides/brightnesscontrast/) 는 Office 2010 그림 효과 확장으로, 표준 DrawingML 밝기 효과보다 이동성이 낮습니다. PPTX 왕복 후에도 밝기와 대비를 편집 가능하게 유지하려면 [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) 를 사용하고 파일을 다시 연 후 결과를 검증하십시오. 형식 제한 섹션에서 이 차이에 대해 자세히 설명합니다.

## **색상 변환 적용**

색상 효과는 동일한 이미지 리소스를 재사용하는 여러 그림 프레임에 독립적으로 적용할 수 있습니다. 다음 예제는 다섯 개의 프레임을 만들고 그레이스케일, 듀오톤, 색조, HSL 조정 및 색상 교체를 적용합니다.

[Duotone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/duotone/) 은 두 개의 독립적으로 편집 가능한 색상 매개변수를 가집니다: `color1`은 어두운 픽셀에, `color2`는 밝은 픽셀에 매핑됩니다. 이는 단일 스칼라 값보다 설정이 복잡한 효과의 좋은 예시입니다.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) 은 알파를 유지하면서 모든 픽셀 색상을 고정 색상으로 교체합니다. 이는 한 소스 색상을 다른 색상으로 매핑하고 소스와 대상 색상 형식을 모두 노출하는 [addColorChangeEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) 와는 다릅니다.

## **흐림, 투명도 및 알파 효과 추가**

[addBlurEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) 은 알파를 포함한 모든 색상 채널에 영향을 줍니다. 흐려진 가장자리가 원본 그림 경계를 넘어설 수 있는 경우 `grow` 를 `True` 로 설정하십시오.

균일한 투명도를 원한다면 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) 를 사용합니다. 이는 기존 알파 값을 모두 곱하므로 부분 투명 픽셀은 비례적으로 차이가 유지됩니다. [addAlphaReplaceEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) 은 모든 픽셀에 하나의 알파 값을 할당하고, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) 은 임계값을 기준으로 알파를 두 단계로 변환합니다.

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

매개변수가 없는 다른 알파 작업으로는 [addAlphaCeilingEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect) (0이 아닌 모든 알파를 완전 불투명하게), [addAlphaFloorEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect) (100% 미만 알파를 완전 투명하게), 그리고 [addAlphaInverseEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect) (알파를 `100% - alpha` 로 변환) 가 있습니다.

## **순서가 지정된 효과 체인 구축**

모든 `add...Effect` 메서드는 새 작업을 컬렉션 끝에 추가합니다. 렌더러는 컬렉션을 순서가 지정된 파이프라인으로 사용합니다: 작업 0의 출력이 작업 1의 입력이 되고, 이렇게 계속됩니다. 따라서 같은 작업을 다른 순서로 배치하면 다른 이미지가 생성될 수 있습니다.

예를 들어, 그레이스케일 뒤에 색조를 적용하면 색상 정보를 먼저 제거하고 그 결과에 색조를 입히게 됩니다. 색조 뒤에 그레이스케일을 적용하면 색조가 다시 사라집니다. 마찬가지로 알파 교체는 이전 작업에서 계산된 알파 값을 덮어쓸 수 있고, 알파 변조는 상대적인 차이를 유지합니다.

다음 예제는 네 개의 작업 체인을 구축하고 PPTX 로 저장한 뒤, 프레젠테이션을 다시 열어 작업 유형과 순서를 확인하고 다시 연 결과를 렌더링합니다:

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

컬렉션은 색상, 알파 및 흐림 작업을 별도 체인으로 제한하는 호환성 매트릭스를 강제하지 않습니다. 이들을 결합할 수 있지만, 결합이 항상 유용한 것은 아닙니다. 고정 색상 교체는 이전 색상 효과가 만든 RGB 변화를 제거하고, 듀오톤 뒤에 그레이스케일을 적용하면 두 선택 색상이 사라집니다; 알파 천장, 바닥, 교체 또는 이중 레벨 작업은 이전에 만든 알파 세부 정보를 삭제할 수 있습니다. 원하는 픽셀 처리 순서에 따라 체인을 구축하고, 항목을 무순서 형식 플래그처럼 취급하지 마십시오.

## **편집 가능한 값과 유효값 검사**

편집 가능한 작업은 `Picture.getImageTransform` 에 저장된 객체입니다. 효과에 따라 직접 쓸 수 있는 멤버를 노출할 수 있습니다. 예를 들어, [Blur](https://reference.aspose.com/slides/ko/python-java/aspose.slides/blur/) 은 `radius`와 `grow` 값을 쓸 수 있게 하고, [AlphaModulateFixed](https://reference.aspose.com/slides/ko/python-java/aspose.slides/alphamodulatefixed/) 은 `amount` 를, [AlphaBiLevel](https://reference.aspose.com/slides/ko/python-java/aspose.slides/alphabilevel/) 은 `threshold` 를 쓸 수 있게 합니다. [Duotone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/duotone/) 과 같은 색상 효과는 변경 가능한 [ColorFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/colorformat/) 객체를 노출합니다.

[BrightnessContrast](https://reference.aspose.com/slides/ko/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tint/) 및 [AlphaReplace](https://reference.aspose.com/slides/ko/python-java/aspose.slides/alphareplace/) 와 같은 일부 작업 클래스는 생성 시 스칼라 값을 쓰기 가능한 속성으로 노출하지 않습니다. 이러한 설정을 변경하려면 작업을 제거하고 원하는 위치에 교체 작업을 추가하십시오.

`getEffective` 로 반환되는 유효 데이터는 계산된 읽기 전용 값입니다. 테마 종속 색상을 해결하고 렌더러가 사용하는 정규화된 값을 읽는 데 유용하지만, 또 다른 편집 표면은 아닙니다. 다음 예제는 체인을 열거하고 해당 API가 제공하는 경우 유효값을 검사합니다:

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

그레이스케일, 알파 천장, 알파 역전과 같은 매개변수가 없는 효과도 유효 데이터 객체를 가지지만 출력할 스칼라 설정이 없습니다. 컬렉션 내 존재와 위치가 중요한 정보입니다.

## **이미지 변환 제거 또는 전체 삭제**

[ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) 를 사용하여 인덱스로 하나의 작업을 제거합니다. 인덱스는 제거 후 이동하므로, 먼저 대상 작업을 찾아 열거가 끝난 뒤 제거하십시오. [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#clear) 를 사용하면 전체 체인을 삭제할 수 있습니다.

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

변환을 제거하거나 전체 삭제해도 그림 서식만 변경됩니다. 재사용되는 [PPImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/ppimage/) 리소스 자체가 삭제되거나 재압축되지는 않습니다.

## **프레젠테이션 형식 및 내보내기 대상 고려**

이미지 변환은 DrawingML 에서 시작되므로 PPTX 가 효과 체인에 가장 적합한 편집 가능한 형식입니다. PPTX 라도 모든 작업이 동일한 이동성을 가지는 것은 아닙니다:

- 밝기, 그레이스케일, 듀오톤, 색조, HSL, 흐림 및 일반 알파 작업과 같은 표준 DrawingML 작업은 PPTX 왕복 시 가장 잘 보존됩니다. 보존이 필요하면 항상 생성된 파일을 다시 열어 컬렉션을 검사하십시오.
- [BrightnessContrast](https://reference.aspose.com/slides/ko/python-java/aspose.slides/brightnesscontrast/) 은 표준 DrawingML 밝기 작업이 아닌 Office 2010 확장입니다. 메모리 내 렌더링에는 사용할 수 있지만, PPTX 저장 후 다시 열었을 때 편집 가능한 [BrightnessContrast](https://reference.aspose.com/slides/ko/python-java/aspose.slides/brightnesscontrast/) 로 남을 보장은 없습니다. 지속적인 밝기·대비 조정을 위해서는 [addLuminanceEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) 를 권장합니다.
- 이진 PPT 형식은 전체 DrawingML 효과 모델보다 오래되었습니다. PPT 로 저장하면 지원되지 않는 작업이 생략되거나 체인이 지원 가능한 하위 집합으로 축소되거나 외관이 근사될 수 있습니다. 복잡한 편집 체인의 검증 형식으로 PPT 를 사용하지 마십시오.
- PNG, JPEG, TIFF, PDF, SVG, HTML 등 시각적 출력물은 지원된 체인을 적용해 렌더링된 모습을 제공합니다. 이러한 출력물에는 편집 가능한 `ImageTransformOperationCollection` 이 포함되지 않으며, 래스터 형식은 결과를 픽셀로 평탄화하고, 문서/벡터 내보내기는 자체 렌더링 표현을 저장합니다.
- 효과는 링크된 이미지를 자체 포함형으로 만들지 않습니다. 링크된 그림을 렌더링하려면 프레젠테이션이 로드될 때 해당 링크 리소스가 사용 가능해야 합니다.

여러 알파 또는 색상 양자화 작업이 결합될 경우, 다양한 프레젠테이션 뷰어가 가장자리를 다르게 렌더링할 수 있습니다. 중요한 출력물의 경우, 제품에 사용되는 동일한 Aspose.Slides 버전으로 편집 가능한 왕복과 최종 내보내기 형식을 모두 테스트하십시오.

## **FAQ**

**이미지 변환 효과가 내장 이미지 데이터를 수정합니까?**

아니요. 작업은 그림 채우기에 사용되는 `Picture` 에 속합니다. 기본 `PPImage` 바이트는 변경되지 않습니다.

**같은 이미지를 재사용하는 두 그림 프레임이 효과를 공유합니까?**

아니요. `PPImage` 재사용은 이미지 데이터 중복을 방지하지만, 각 그림 프레임은 일반적으로 별도의 `Picture` 와 이미지 변환 컬렉션을 가집니다.

**색상, 흐림 및 알파 효과를 결합할 수 있습니까?**

예. 컬렉션은 하나의 순서가 지정된 체인에 이를 모두 허용합니다. 교체 및 임계값 작업이 이전 색상이나 알파 세부 정보를 삭제할 수 있으므로, 각 작업이 이전 작업의 출력에 어떤 영향을 미치는지 고려하십시오.

**왜 유효값은 읽기 전용인가요?**

유효 데이터는 렌더링에 사용되는 계산된 값(색상 해결 포함)을 나타냅니다. 쓰기 가능한 멤버가 있는 경우 변환 컬렉션에 저장된 작업을 편집하고, 그렇지 않다면 작업을 제거하고 새로운 생성 매개변수를 사용해 교체 작업을 추가하십시오.

**어떤 형식이 변환 체인을 보존하는 데 적합합니까?**

PPTX 를 사용하고 파일을 다시 열어 확인하십시오. 레거시 PPT 는 전체 DrawingML 효과 모델을 표현할 수 없으며, 렌더링 내보내기 형식은 편집 가능한 변환 작업이 아닌 외관만 보존합니다.