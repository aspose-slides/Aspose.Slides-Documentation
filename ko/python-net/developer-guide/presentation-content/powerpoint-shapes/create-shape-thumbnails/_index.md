---
title: Python에서 프레젠테이션 도형 썸네일 만들기
linktitle: 도형 썸네일
type: docs
weight: 70
url: /ko/python-net/create-shape-thumbnails/
keywords:
- 도형 썸네일
- 도형 이미지
- 도형 렌더링
- 도형 렌더링
- 시각적 경계
- 도형 경계
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 고품질 도형 썸네일을 생성하고, 프레젠테이션 썸네일을 쉽게 만들고 내보낼 수 있습니다."
---
## **소개**

Aspose.Slides for Python via .NET는 각 페이지가 슬라이드인 프레젠테이션 파일을 만들 때 사용됩니다. 프레젠테이션 파일을 열어 Microsoft PowerPoint에서 슬라이드를 볼 수 있습니다. 그러나 개발자가 개별 도형의 이미지를 이미지 뷰어에서 별도로 확인해야 할 때가 있습니다. 이 경우 Aspose.Slides를 사용하면 슬라이드 도형의 썸네일 이미지를 생성할 수 있습니다. 이 문서에서는 해당 기능을 사용하는 방법을 설명합니다.

## **슬라이드에서 도형 썸네일 생성**

전체 슬라이드가 아니라 특정 개체의 미리보기가 필요할 때 개별 도형에 대한 썸네일을 렌더링할 수 있습니다. Aspose.Slides를 사용하면 모든 도형을 이미지로 내보낼 수 있어 가벼운 미리보기, 아이콘 또는 후속 처리용 자산을 쉽게 만들 수 있습니다.

任意の 도형에서 썸네일을 생성하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 해당 슬라이드에 있는 도형에 대한 참조를 가져옵니다.
1. 도형의 썸네일 이미지를 렌더링합니다.
1. 원하는 형식으로 썸네일 이미지를 저장합니다.

아래 예제는 도형 썸네일을 생성합니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 열기 위해 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 기본 스케일로 이미지를 생성합니다.
    with shape.get_image() as thumbnail:
        # 이미지를 PNG 형식으로 디스크에 저장합니다.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **사용자 정의 배율을 사용한 썸네일 생성**

이 섹션에서는 Aspose.Slides에서 사용자 정의 배율을 적용해 도형 썸네일을 생성하는 방법을 보여줍니다. 배율을 제어하면 미리보기, 내보내기 또는 고 DPI 디스플레이에 맞게 썸네일 크기를 미세 조정할 수 있습니다.

슬라이드의 任意の 도형에 대한 썸네일을 생성하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스로 슬라이드를 가져옵니다.
1. 해당 슬라이드에서 대상 도형을 가져옵니다.
1. 지정된 배율로 도형의 썸네일 이미지를 렌더링합니다.
1. 원하는 형식으로 썸네일 이미지를 저장합니다.

아래 예제는 사용자 정의 배율을 사용해 썸네일을 생성합니다.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# 프레젠테이션 파일을 열기 위해 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # 정의된 스케일로 이미지를 생성합니다.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # 이미지를 PNG 형식으로 디스크에 저장합니다.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **도형 외관 영역을 사용한 썸네일 생성**

이 섹션에서는 도형의 외관 영역 내에서 썸네일을 생성하는 방법을 보여줍니다. 모든 도형 효과를 고려합니다. 생성된 썸네일은 슬라이드 경계에 의해 제한됩니다.

도형의 외관 영역 내에서 任意の 슬라이드 도형 썸네일을 생성하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스로 슬라이드를 가져옵니다.
1. 해당 슬라이드에서 대상 도형을 가져옵니다.
1. 지정된 경계로 도형의 썸네일 이미지를 렌더링합니다.
1. 원하는 이미지 형식으로 썸네일을 저장합니다.

아래 예제는 사용자 정의 경계를 사용해 썸네일을 생성합니다.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# 프레젠테이션 파일을 열기 위해 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # 외관 경계 기반 도형 이미지를 생성합니다.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # 이미지를 PNG 형식으로 디스크에 저장합니다.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **도형의 실제 시각적 경계 가져오기**

[Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/)의 프레임 속성—`Shape.x`, `Shape.y`, `Shape.width`, `Shape.height`—은 프레젠테이션 모델에 저장된 사각형을 설명합니다. 실제로 렌더링되는 내용은 그 프레임을 넘어설 수 있거나 다른 축에 정렬된 사각형을 차지할 수 있습니다. 회전, 외곽선, 화살표 머리, 텍스트 레이아웃 및 넘침, 자동 생성된 SmartArt 기하학, 기타 렌더링 효과가 차지하는 영역을 변경할 수 있습니다.

이미지를 만들지 않고 차지하는 영역을 계산하려면 [Shape.get_visual_bounds](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_visual_bounds/)를 사용합니다. 이 메서드는 슬라이드 좌표계의 부동 소수점 사각형을 반환합니다. 반환된 사각형은 슬라이드에 클립되지 않으므로 내용이 슬라이드 원점을 벗어나면 좌표가 음수가 될 수 있습니다.

다음 예제는 프레임 경계와 시각적 경계를 가져와 비교합니다.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

동일한 사각형을 사용해 주변 도형을 `left`, `right`, `top`, `bottom` 가장자리에 정렬하거나, 생성된 레이아웃에 충분한 공간을 확보하거나, 허용된 영역 밖의 콘텐츠를 감지할 수 있습니다. 시각적 경계는 저장된 프레임이 전체 렌더링 결과를 나타내지 않을 수 있는 SmartArt, 텍스트 상자, 화살표, 그림, 회전된 도형 및 그룹 도형에 특히 유용합니다.

레이아웃이나 검증을 위한 좌표가 필요하고 비트맵이 필요 없을 때는 [Shape.get_visual_bounds](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_visual_bounds/)를 사용하고, 도형을 렌더링해야 할 때는 [Shape.get_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_image/)를 사용합니다. 또한 [ShapeThumbnailBounds](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapethumbnailbounds/)를 사용하면 `ShapeThumbnailBounds.SHAPE`는 외곽선 설정을 포함해 도형 경계에서 이미지를 크기 조정하고, `ShapeThumbnailBounds.APPEARANCE`는 도형의 외관을 기준으로 크기 조정하며 결과를 슬라이드 경계에 제한합니다. 반면에 `Shape.get_visual_bounds`는 계산된 사각형만 반환하고 슬라이드에 클립하지 않습니다.

## **FAQ**

**도형 썸네일을 저장할 때 사용할 수 있는 이미지 형식은 무엇인가요?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imageformat/) 및 기타 형식이 지원됩니다. 도형은 [SVG 벡터 형식으로 내보내기](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/write_as_svg/)도 가능합니다.

**썸네일을 렌더링할 때 SHAPE와 APPEARANCE 경계의 차이는 무엇인가요?**

`SHAPE`는 도형의 기하학을 사용하고, `APPEARANCE`는 [시각 효과](/slides/ko/python-net/shape-effect/) (그림자, 광택 등)를 고려합니다.

**도형이 숨김으로 표시되면 어떻게 되나요? 여전히 썸네일로 렌더링되나요?**

숨김 도형은 모델의 일부로 남아있으며 렌더링될 수 있습니다. 숨김 플래그는 슬라이드 쇼 표시에는 영향을 주지만 도형 이미지를 생성하는 것을 방지하지는 않습니다.

**그룹 도형, 차트, SmartArt 및 기타 복합 객체도 지원되나요?**

예. [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/)로 표현되는 모든 객체(예: [GroupShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/), [SmartArt](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartart/))는 썸네일 또는 SVG로 저장할 수 있습니다.

**시스템에 설치된 폰트가 텍스트 도형의 썸네일 품질에 영향을 미치나요?**

예. 원하지 않는 폰트 대체 및 텍스트 레이아웃 변형을 방지하려면 [필요한 폰트를 제공](/slides/ko/python-net/custom-font/)하거나 [폰트 대체를 구성](/slides/ko/python-net/font-substitution/)해야 합니다.