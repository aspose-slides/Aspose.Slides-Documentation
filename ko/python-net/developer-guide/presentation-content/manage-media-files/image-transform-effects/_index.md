---
title: Python으로 프레젠테이션에서 이미지 변환 효과 관리
linktitle: 이미지 변환 효과
type: docs
weight: 11
url: /ko/python-net/image-transform-effects/
keywords:
- 이미지 변환
- 그림 효과
- 밝기
- 대비
- 회색조
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 그림 프레임의 이미지 변환 효과를 적용하고, 체인화하고, 검사하고, 제거하며, 검증합니다."
---
## **개요**

Aspose.Slides는 그림 조정을 이미지 변환 작업의 순서가 있는 컬렉션으로 표현합니다. 그림 프레임의 경우 프레임의 [Picture](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picture/)을 시작점으로 하고 해당 [image_transform](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picture/image_transform/) 속성에 접근합니다. 반환된 [ImageTransformOperationCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/effects/imagetransformoperationcollection/)을 사용하면 원본 이미지 바이트를 다시 쓰지 않고도 효과를 추가, 열거, 검사, 제거 및 전체 삭제할 수 있습니다.

이 문서는 밝기 및 대비, 색상 변환, 흐림, 투명도, 순서가 있는 효과 체인, 유효값, 제거 및 PPTX 라운드‑트립 검증을 위한 전체 워크플로를 보여줍니다.

## **효과 소유권 및 이미지 재사용 이해**

이미지 리소스와 이를 표시하는 그림은 서로 다른 객체입니다:

- [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)은 프레젠테이션이 소유하는 원본 이미지 데이터를 저장하거나 참조합니다.
- [Picture](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picture/)은 그림 채우기에 속하며 이미지 리소스를 참조하면서 이미지 변환 컬렉션을 저장합니다.
- [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)은 해당 그림 채우기, 기하학, 자르기 설정 및 기타 프레임 수준 서식을 소유하는 슬라이드 형태입니다.

따라서 이미지 변환 작업은 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)의 바이트를 수정하지 않습니다. 동일한 `PPImage`를 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_picture_frame/)에 여러 번 전달하면 각 새 그림 프레임은 자체 `Picture`와 자체 변환 컬렉션을 받습니다. 한 프레임에 회색조를 적용해도 다른 프레임은 회색조가 적용되지 않으며, 모든 프레임이 동일한 임베드된 이미지 리소스를 재사용한다는 점은 변함없습니다.

동일한 `Picture.image_transform` 모델은 도형 또는 슬라이드 배경과 같은 다른 그림 채우기에서도 사용됩니다. 아래 예제는 그림 프레임에 초점을 맞춥니다.

## **유효한 매개변수 범위 및 단위 사용**

시연된 메서드는 다음과 같은 의미론적 범위와 단위를 사용합니다. 특정 라이브러리 버전이 즉시 모든 범위 외 값을 거부하지 않더라도 이러한 범위를 유지하십시오; 대상 프레젠테이션 형식은 저장 시 또는 PowerPoint가 파일을 열 때 데이터를 정규화, 생략 또는 거부할 수 있습니다.

| 작업 | 매개변수 | 유효 범위 및 단위 |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100`부터 `100`까지, 퍼센트; `0`은 해당 구성 요소를 변경하지 않음. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | 없음 | 숫자 매개변수 없음. 알파는 변경되지 않음. |
| [add_duotone_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | 어두운 픽셀과 밝은 픽셀을 위한 두 색상. RGB 및 알파 채널은 `0`부터 `255`까지 사용. |
| [add_tint_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | 색조는 `0`(포함)부터 `360`(제외)까지, 도 단위; 양은 `-100`부터 `100`까지, 퍼센트. |
| [add_hsl_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | 색조는 `0`(포함)부터 `360`(제외)까지, 도 단위; 채도와 명도는 `-100`부터 `100`까지, 퍼센트. |
| [add_color_replace_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | 교체 색상은 각 채널이 `0`부터 `255`까지 값을 가짐. 기존 알파 값은 변경되지 않음. |
| [add_blur_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | 반경은 음수가 아니며 포인트 단위; `grow`는 흐려진 내용이 원본 경계를 넘어설 수 있는지 여부를 제어하는 부울값. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | 음수가 아닌 퍼센트. 일반적인 불투명도 스케일링은 `0`부터 `100`까지 사용: `0`은 완전 투명, `100`은 기존 알파 유지. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0`부터 `100`까지, 퍼센트 불투명도. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0`부터 `100`까지, 퍼센트 알파 임계값. 이 값보다 낮은 것은 투명, 이상은 불투명. |

고정 알파 변조의 경우 투명도와 불투명도는 보완 관계에 있습니다. 예를 들어 35% 투명도는 알파 변조 양 65%에 해당합니다.

## **밝기와 대비 적용**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/)은 [BrightnessContrast](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/brightnesscontrast/) 작업을 반환합니다. 스칼라 설정은 작업 생성 시 제공됩니다. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/brightnesscontrast/get_effective/)은 검사하거나 로그에 기록할 수 있는 계산된 읽기 전용 값을 반환합니다.

다음 예제는 밝기를 15% 증가하고 대비를 20% 증가시킨 뒤, 임베드된 이미지를 수정하지 않고 미리 보기를 렌더링합니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/brightnesscontrast/)은 Office 2010 그림 효과 확장으로, 표준 DrawingML 밝기 효과보다 이식성이 낮습니다. 밝기와 대비를 PPTX 라운드‑트립 후에도 편집 가능하게 유지해야 한다면 [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/)을 사용하고 파일을 다시 열어 결과를 확인하십시오. 형식 제한 섹션에서 이 차이에 대해 더 자세히 설명합니다.

## **색상 변환 적용**

색상 효과는 동일한 이미지 리소스를 재사용하는 서로 다른 그림 프레임에 독립적으로 적용할 수 있습니다. 다음 예제는 다섯 개의 프레임을 만들고 회색조, 듀오톤, 색조, HSL 조정 및 색상 교체를 적용합니다.

[Duotone](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/duotone/)에는 두 개의 독립적으로 편집 가능한 색상 매개변수가 있습니다: `color1`은 어두운 픽셀에, `color2`는 밝은 픽셀에 매핑됩니다. 이는 단일 스칼라 값보다 복잡한 설정을 가진 효과의 좋은 예시입니다.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/)는 알파를 유지하면서 모든 픽셀의 색상을 고정 색상 하나로 교체합니다. 이는 원본 색상을 다른 색으로 매핑하고 소스와 대상 색 형식을 모두 노출하는 [add_color_change_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/)와 다릅니다.

## **흐림, 투명도 및 알파 효과 추가**

[add_blur_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/)는 알파를 포함한 모든 색상 채널에 영향을 줍니다. 흐려진 가장자리가 원본 그림 경계를 넘어설 수 있는 경우 `grow`를 `True`로 설정하십시오.

균일한 투명도를 위해서는 [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/)를 사용합니다. 이 효과는 기존 알파 값을 모두 곱하므로 부분적으로 투명한 픽셀은 비례적으로 차이가 유지됩니다. [add_alpha_replace_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/)는 모든 픽셀에 동일한 알파 값을 할당하고, [add_alpha_bi_level_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/)는 임계값에 따라 알파를 두 단계로 변환합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

매개변수가 없는 다른 알파 작업으로는 [add_alpha_ceiling_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/)가 있으며, 이는 0이 아닌 모든 알파를 완전 불투명하게 만들고, [add_alpha_floor_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/)는 100% 이하 모든 알파를 완전 투명하게 만들며, [add_alpha_inverse_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/)는 알파를 `100% - alpha` 로 변경합니다.

## **순서가 있는 효과 체인 구축**

각 `add_..._effect` 메서드는 컬렉션 끝에 새 작업을 추가합니다. 렌더러는 컬렉션을 순차 파이프라인으로 사용합니다: 작업 0의 출력이 작업 1의 입력이 되고, 이렇게 이어집니다. 따라서 동일한 작업이라도 순서를 바꾸면 다른 이미지가 만들어질 수 있습니다.

예를 들어, 회색조 뒤에 색조를 적용하면 먼저 색상 정보를 제거하고 그 후에 명도 결과에 색조를 입히게 됩니다. 색조 뒤에 회색조를 적용하면 색조가 다시 제거됩니다. 마찬가지로 알파 교체는 이전 작업에서 계산된 알파 값을 덮어쓰고, 알파 변조는 상대적인 차이를 유지합니다.

다음 예제는 네 개의 작업으로 구성된 체인을 만들고, PPTX로 저장한 뒤 프레젠테이션을 다시 열어 작업 유형과 순서를 확인하고, 다시 연 결과를 렌더링합니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

컬렉션은 색상, 알파 및 흐림 작업을 별도의 체인으로 제한하는 호환성 매트릭스를 강제하지 않습니다. 이들을 결합할 수 있지만 조합이 항상 유용한 것은 아닙니다. 고정 색상 교체는 이전 색상 효과가 만든 RGB 변화를 제거하고, 듀오톤 뒤에 회색조를 적용하면 두 선택 색상이 사라집니다. 알파 천장, 바닥, 교체 또는 바이레벨 작업은 이전에 만든 알파 세부 정보를 삭제할 수 있습니다. 체인은 원하는 픽셀 처리 순서에 따라 구축하되, 항목을 순서가 없는 서식 플래그처럼 다루지 마십시오.

## **편집 가능한 값과 유효값 검사**

편집 가능한 작업은 `Picture.image_transform`에 저장된 객체입니다. 효과에 따라 직접 쓸 수 있는 멤버를 노출할 수 있습니다. 예를 들어, [Blur](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/blur/)는 쓰기 가능한 `radius`와 `grow` 속성을, [AlphaModulateFixed](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/alphamodulatefixed/)는 쓰기 가능한 `amount` 속성을, [AlphaBiLevel](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/alphabilevel/)는 쓰기 가능한 `threshold` 속성을 노출합니다. [Duotone](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/duotone/)과 같은 색상 효과는 가변적인 [ColorFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/colorformat/) 객체를 노출합니다.

[BrightnessContrast](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/tint/), [AlphaReplace](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/alphareplace/)와 같은 일부 작업은 생성 시 스칼라 값을 쓰기 가능한 속성으로 노출하지 않습니다. 이러한 설정을 변경하려면 작업을 제거하고 원하는 위치에 교체 작업을 추가하십시오.

`get_effective()`가 반환하는 유효 데이터는 계산된 읽기 전용 값입니다. 테마‑종속 색상을 해석하고 렌더러가 사용하는 정규화된 값을 읽는 데 유용하지만, 또 다른 편집 표면은 아닙니다. 다음 예제는 체인을 열거하고 해당 API가 제공하는 경우 유효값을 검사합니다:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

그레이스케일, 알파 천장, 알파 역전과 같은 매개변수 없는 효과도 유효‑데이터 객체를 가지고 있지만 출력할 스칼라 설정이 없습니다. 컬렉션 내 존재 여부와 위치가 중요한 정보입니다.

## **이미지 변환 제거 또는 전체 삭제**

[ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/)을 사용해 인덱스로 하나의 작업을 제거합니다. 인덱스는 제거 후 이동하므로 먼저 대상 작업을 찾은 뒤 열거가 끝난 뒤 제거하십시오. `clear()`를 사용하면 전체 체인을 삭제할 수 있습니다.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

변환을 제거하거나 전체를 삭제해도 그림 서식만 변경됩니다. 재사용되는 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/) 리소스 자체가 삭제, 재압축 또는 다른 방식으로 변경되지는 않습니다.

## **프레젠테이션 형식 및 내보내기 대상 고려**

이미지 변환은 DrawingML에서 시작되므로 효과 체인에 대해 편집 가능한 형식으로는 PPTX가 선호됩니다. PPTX라도 모든 작업이 동일한 이식성을 보장하는 것은 아닙니다:

- 밝기, 회색조, 듀오톤, 색조, HSL, 흐림 및 일반 알파 작업과 같은 표준 DrawingML 작업은 PPTX 라운드‑트립에서 가장 잘 유지됩니다. 보존이 필요하다면 생성된 파일을 다시 열어 컬렉션을 확인하십시오.
- [BrightnessContrast](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/brightnesscontrast/)은 표준 DrawingML 밝기 작업이 아닌 Office 2010 확장입니다. 메모리 내 렌더링에는 사용할 수 있지만 PPTX 저장·재열 때 편집 가능한 `BrightnessContrast` 작업으로 남는 것이 보장되지 않습니다. 지속적인 밝기·대비 조정에는 [add_luminance_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/)를 선호하십시오.
- 바이너리 PPT 형식은 전체 DrawingML 효과 모델보다 오래되었습니다. PPT로 저장하면 지원되지 않는 작업이 누락되거나 체인이 지원 가능한 하위 집합으로 축소되거나 외관이 근사될 수 있습니다. 복잡한 편집 체인 검증용으로 PPT를 사용하지 마십시오.
- PNG, JPEG, TIFF, PDF, SVG, HTML 등 시각적 출력으로 렌더링하면 지원되는 체인이 렌더링된 모습에 적용됩니다. 이러한 출력물에는 편집 가능한 `ImageTransformOperationCollection`이 포함되지 않으며, 래스터 형식은 결과를 픽셀로 평탄화하고 문서·벡터 내보내기는 자체 렌더링 표현을 저장합니다.
- 효과는 연결된 이미지를 자체 포함형으로 만들지 않습니다. 연결된 그림을 렌더링하려면 프레젠테이션이 로드될 때 해당 연결 리소스가 사용 가능해야 합니다.

특히 여러 알파 또는 색상 양자화 작업이 결합될 경우 다양한 프레젠테이션 뷰어가 가장자리 케이스를 다르게 렌더링할 수 있습니다. 중요한 출력물인 경우 프로덕션에서 사용하는 동일한 Aspose.Slides 버전으로 편집 라운드‑트립과 최종 내보내기 형식을 모두 테스트하십시오.

## **FAQ**

**이미지 변환 효과가 임베드된 이미지 데이터를 수정합니까?**

아니요. 작업은 그림 채우기에 사용되는 `Picture`에 속하며, 기본 `PPImage` 바이트는 변경되지 않습니다.

**동일한 이미지를 재사용하는 두 그림 프레임이 효과를 공유합니까?**

아니요. `PPImage`를 재사용하면 이미지 데이터 중복을 피하지만, 각 그림 프레임은 일반적으로 별개의 `Picture`와 이미지 변환 컬렉션을 가집니다.

**색상, 흐림 및 알파 효과를 결합할 수 있습니까?**

예. 컬렉션은 하나의 순서가 있는 체인으로 이를 허용합니다. 이전 작업의 출력을 기반으로 각 작업이 수행하는 작업을 고려하십시오. 교체 및 임계값 작업은 이전 색상이나 알파 세부 정보를 삭제할 수 있습니다.

**왜 유효값은 읽기 전용입니까?**

유효 데이터는 렌더링에 사용되는 계산된 값이며 해결된 색상을 포함합니다. 쓰기 가능한 멤버가 있는 경우 변환 컬렉션에 저장된 작업을 편집하고, 그렇지 않다면 작업을 제거하고 새 매개변수로 교체하십시오.

**어떤 형식을 사용해야 변환 체인을 보존할 수 있습니까?**

PPTX를 사용하고 파일을 다시 열어 확인하십시오. 레거시 PPT는 전체 DrawingML 효과 모델을 표현할 수 없으며, 렌더링 내보내기 형식은 편집 가능한 변환 작업이 아닌 외관만을 보존합니다.