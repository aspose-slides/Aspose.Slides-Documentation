---
title: Python에서 프레젠테이션 배경 관리
linktitle: 슬라이드 배경
type: docs
weight: 20
url: /ko/python-net/presentation-background/
keywords:
- 프레젠테이션 배경
- 슬라이드 배경
- 단색
- 그라디언트 색상
- 이미지 배경
- 배경 투명도
- 배경 속성
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python용 .NET을 통해 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 파일에서 동적 배경을 설정하는 방법을 배우고, 프레젠테이션을 향상시키는 코드 팁을 얻으세요."
---
## **소개**

단색, 그라디언트 및 이미지는 슬라이드 배경으로 일반적으로 사용됩니다. **일반 슬라이드**(단일 슬라이드) 또는 **마스터 슬라이드**(한 번에 여러 슬라이드에 적용) 배경을 설정할 수 있습니다.

![PowerPoint 배경](powerpoint-background.png)

## **일반 슬라이드에 단색 배경 설정**

Aspose.Slides를 사용하면 프레젠테이션의 특정 슬라이드에 단색을 배경으로 설정할 수 있습니다(프레젠테이션이 마스터 슬라이드를 사용하더라도). 이 변경은 선택한 슬라이드에만 적용됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/backgroundtype/)을 `OWN_BACKGROUND` 로 설정합니다.
3. 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/filltype/)을 `SOLID` 로 설정합니다.
4. [FillFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fillformat/)의 `solid_fill_color` 속성을 사용하여 단색 배경 색상을 지정합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 Python 예제는 일반 슬라이드에 파란색 단색 배경을 설정하는 방법을 보여줍니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 슬라이드의 배경 색상을 파란색으로 설정합니다.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **마스터 슬라이드에 단색 배경 설정**

Aspose.Slides를 사용하면 프레젠테이션의 마스터 슬라이드에 단색을 배경으로 설정할 수 있습니다. 마스터 슬라이드는 모든 슬라이드의 서식을 제어하는 템플릿 역할을 하므로, 마스터 슬라이드 배경에 단색을 선택하면 모든 슬라이드에 적용됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 마스터 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/backgroundtype/) (via `masters`)을 `OWN_BACKGROUND` 로 설정합니다.
3. 마스터 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/filltype/)을 `SOLID` 로 설정합니다.
4. [FillFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fillformat/)의 `solid_fill_color` 속성을 사용하여 단색 배경 색상을 지정합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 Python 예제는 마스터 슬라이드에 숲 초록색 단색 배경을 설정하는 방법을 보여줍니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # 마스터 슬라이드의 배경 색상을 포레스트 그린으로 설정합니다.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드에 그라디언트 배경 설정**

그라디언트는 색상이 점진적으로 변하는 그래픽 효과입니다. 슬라이드 배경으로 사용할 경우 프레젠테이션을 보다 예술적이고 전문적으로 보이게 할 수 있습니다. Aspose.Slides를 사용하면 슬라이드 배경에 그라디언트 색을 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/backgroundtype/)을 `OWN_BACKGROUND` 로 설정합니다.
3. 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/filltype/)을 `GRADIENT` 로 설정합니다.
4. [FillFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fillformat/)의 `gradient_format` 속성을 사용하여 원하는 그라디언트 설정을 구성합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 Python 예제는 슬라이드에 그라디언트 색을 배경으로 설정하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 배경에 그라디언트 효과를 적용합니다.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드 배경에 이미지 설정**

단색 및 그라디언트 채우기에 추가로, Aspose.Slides를 사용하면 이미지를 슬라이드 배경으로 사용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/backgroundtype/)을 `OWN_BACKGROUND` 로 설정합니다.
3. 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/filltype/)을 `PICTURE` 로 설정합니다.
4. 슬라이드 배경으로 사용할 이미지를 로드합니다.
5. 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다.
6. [FillFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fillformat/)의 `picture_fill_format` 속성을 사용하여 이미지를 배경으로 지정합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 Python 예제는 슬라이드 배경에 이미지를 설정하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 배경 이미지 속성을 설정합니다.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # 이미지를 로드합니다.
    with slides.Images.from_file("Tulips.jpg") as image:
        # 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

다음 코드 샘플은 배경 채우기 유형을 타일링된 그림으로 설정하고 타일링 속성을 수정하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # 배경 채우기에 사용되는 이미지를 설정합니다.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # 그림 채우기 모드를 타일로 설정하고 타일 속성을 조정합니다.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
자세히 보기: [**타일 사진을 텍스처로**](/slides/ko/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **배경 이미지 투명도 변경**

슬라이드 배경 이미지의 투명도를 조정하여 슬라이드 내용이 돋보이게 할 수 있습니다. 다음 Python 코드는 슬라이드 배경 이미지의 투명도를 변경하는 방법을 보여줍니다:

```python
transparency_value = 30  # 예시입니다.

# 그림 변환 작업 컬렉션을 가져옵니다.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# 기존 고정 비율 투명도 효과를 찾습니다.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# 새로운 투명도 값을 설정합니다.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **슬라이드 배경 값 가져오기**

Aspose.Slides는 슬라이드의 실제 배경 값을 검색하기 위해 [IBackgroundEffectiveData](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ibackgroundeffectivedata/) 클래스를 제공합니다. 이 클래스는 실제 [FillFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fillformat/) 및 [EffectFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/effectformat/)을 노출합니다.

[BaseSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/) 클래스의 `background` 속성을 사용하여 슬라이드의 실제 배경을 얻을 수 있습니다.

다음 Python 예제는 슬라이드의 실제 배경 값을 가져오는 방법을 보여줍니다:

```python
import aspose.slides as slides

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 마스터, 레이아웃 및 테마를 고려하여 실제 배경을 가져옵니다.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**맞춤형 배경을 초기화하고 테마/레이아웃 배경을 복원할 수 있나요?**

예. 슬라이드의 맞춤형 채우기를 제거하면 배경이 해당 [layout](/slides/ko/python-net/slide-layout/)/[master](/slides/ko/python-net/slide-master/) 슬라이드(즉, [theme background](/slides/ko/python-net/presentation-theme/))에서 다시 상속됩니다.

**프레젠테이션의 테마를 나중에 변경하면 배경은 어떻게 되나요?**

슬라이드에 자체 채우기가 있는 경우 변경되지 않습니다. 배경이 [layout](/slides/ko/python-net/slide-layout/)/[master](/slides/ko/python-net/slide-master/)에서 상속된 경우 새 테마에 맞게 업데이트됩니다.