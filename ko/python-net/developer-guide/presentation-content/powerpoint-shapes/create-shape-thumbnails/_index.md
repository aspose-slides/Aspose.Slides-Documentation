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
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET을 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 고품질 도형 썸네일을 생성하고 프레젠테이션 썸네일을 쉽고 빠르게 만들고 내보낼 수 있습니다."
---
## **소개**

Aspose.Slides for Python via .NET는 각 페이지가 슬라이드인 프레젠테이션 파일을 만드는 데 사용됩니다. 프레젠테이션 파일을 열어 Microsoft PowerPoint에서 슬라이드를 볼 수 있습니다. 그러나 개발자는 때때로 이미지 뷰어에서 도형의 이미지를 별도로 확인해야 할 수 있습니다. 이러한 경우 Aspose.Slides는 슬라이드 도형에 대한 썸네일 이미지를 생성할 수 있습니다. 이 문서에서는 이 기능을 사용하는 방법을 설명합니다.

## **슬라이드에서 도형 썸네일 생성**

전체 슬라이드가 아닌 특정 개체의 미리보기가 필요할 때 개별 도형에 대한 썸네일을 렌더링할 수 있습니다. Aspose.Slides를 사용하면 모든 도형을 이미지로 내보낼 수 있어 가벼운 미리보기, 아이콘 또는 후속 처리용 자산을 손쉽게 만들 수 있습니다.

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

## **사용자 지정 스케일링 팩터로 썸네일 생성**

이 섹션에서는 Aspose.Slides에서 사용자 정의 스케일링 팩터를 사용해 도형 썸네일을 생성하는 방법을 보여줍니다. 스케일을 제어함으로써 미리보기, 내보내기 또는 고 DPI 디스플레이에 맞게 썸네일 크기를 미세 조정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 해당 슬라이드에서 대상 도형을 가져옵니다.
1. 지정된 스케일로 도형의 썸네일 이미지를 렌더링합니다.
1. 원하는 형식으로 썸네일 이미지를 저장합니다.

아래 예제는 사용자 정의 스케일링 팩터를 사용해 썸네일을 생성합니다.

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

## **도형 외관 경계 사용하여 썸네일 생성**

이 섹션에서는 도형의 외관 경계 내에서 썸네일을 생성하는 방법을 보여줍니다. 모든 도형 효과를 고려합니다. 생성된 썸네일은 슬라이드 경계에 제한됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 해당 슬라이드에서 대상 도형을 가져옵니다.
1. 지정된 경계로 도형의 썸네일 이미지를 렌더링합니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

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

## **FAQ**

**도형 썸네일을 저장할 때 사용할 수 있는 이미지 형식은 무엇입니까?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imageformat/), 등이며, 도형은 도형의 내용을 SVG로 저장하여 [벡터 SVG로 내보낼 수도 있습니다](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/write_as_svg/) .

**썸네일을 렌더링할 때 SHAPE 경계와 APPEARANCE 경계의 차이점은 무엇입니까?**

`SHAPE`는 도형의 기하학을 사용하고, `APPEARANCE`는 [시각 효과](/slides/ko/python-net/shape-effect/) (그림자, 글로우 등)를 고려합니다.

**도형이 숨김으로 표시된 경우 어떻게 되나요? 여전히 썸네일로 렌더링됩니까?**

숨김 도형은 모델의 일부로 남아 있으며 렌더링할 수 있습니다. 숨김 플래그는 슬라이드쇼 표시에는 영향을 주지만 도형 이미지를 생성하는 것을 방해하지는 않습니다.

**그룹 도형, 차트, SmartArt 및 기타 복합 객체가 지원됩니까?**

예. [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/)으로 표현되는 모든 객체( [GroupShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/), [SmartArt](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartart/) 포함)는 썸네일 또는 SVG로 저장할 수 있습니다.

**시스템에 설치된 글꼴이 텍스트 도형의 썸네일 품질에 영향을 줍니까?**

예. 원하지 않는 폰트 대체 및 텍스트 재배치를 방지하려면 [필요한 글꼴을 제공](/slides/ko/python-net/custom-font/)하거나 [글꼴 대체를 구성](/slides/ko/python-net/font-substitution/)해야 합니다.