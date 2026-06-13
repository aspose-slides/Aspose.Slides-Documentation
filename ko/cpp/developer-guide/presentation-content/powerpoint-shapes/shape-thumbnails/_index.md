---
title: C++에서 프레젠테이션 도형 썸네일 만들기
linktitle: 도형 썸네일
type: docs
weight: 70
url: /ko/cpp/shape-thumbnails/
keywords:
- 도형 썸네일
- 도형 이미지
- 도형 렌더링
- 도형 렌더링
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 슬라이드에서 고품질 도형 썸네일을 생성하고, 프레젠테이션 썸네일을 쉽게 만들고 내보냅니다."
---
## **소개**

Aspose.Slides는 각 페이지가 슬라이드인 프레젠테이션 파일을 만들 때 사용됩니다. 이러한 슬라이드는 Microsoft PowerPoint로 파일을 열어 볼 수 있습니다. 그러나 경우에 따라 개발자는 도형의 이미지를 이미지 뷰어에서 별도로 확인해야 할 수도 있습니다. 이때 Aspose.Slides를 사용하면 슬라이드 도형의 썸네일 이미지를 생성할 수 있습니다. 이 기능의 사용 방법은 본 문서에 설명되어 있습니다.  
이 문서에서는 다양한 방법으로 슬라이드 썸네일을 생성하는 방법을 설명합니다.

- 슬라이드 내부 도형 썸네일 생성
- 사용자 지정 크기로 슬라이드 도형 썸네일 생성
- 도형 모양의 경계에 맞는 썸네일 생성

## **슬라이드에서 도형 썸네일 생성**
Aspose.Slides for C++를 사용하여任意의 슬라이드에서 도형 썸네일을 생성하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용해 任意의 슬라이드에 대한 참조를 얻습니다.
1. 기본 스케일로 참조된 슬라이드의 도형 썸네일 이미지를 가져옵니다.
1. 썸네일 이미지를 원하는 이미지 형식으로 저장합니다.

아래 예제는 도형 썸네일을 생성하는 방법을 보여 줍니다.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **사용자 정의 스케일 팩터 썸네일 생성**
Aspose.Slides for C++를 사용하여 任意의 슬라이드 도형 썸네일을 생성하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용해 任意의 슬라이드에 대한 참조를 얻습니다.
1. 도형 경계가 포함된 참조 슬라이드의 썸네일 이미지를 가져옵니다.
1. 썸네일 이미지를 원하는 이미지 형식으로 저장합니다.

아래 예제는 사용자 정의 스케일 팩터를 사용해 썸네일을 생성하는 방법을 보여 줍니다.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // X 및 Y 축을 따라 스케일링합니다.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **경계 기반 도형 외관 썸네일 생성**
이 방법을 사용하면 개발자는 도형 외관의 경계 안에서 썸네일을 생성할 수 있습니다. 이는 모든 도형 효과를 고려합니다. 생성된 도형 썸네일은 슬라이드 경계에 제한됩니다. 외관 경계 안에서 任意의 슬라이드 도형 썸네일을 생성하려면 다음 샘플 코드를 사용하십시오.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용해 任意의 슬라이드에 대한 참조를 얻습니다.
1. 외관으로서 도형 경계를 포함한 참조 슬라이드의 썸네일 이미지를 가져옵니다.
1. 썸네일 이미지를 원하는 이미지 형식으로 저장합니다.

아래 예제는 외관 경계 기반 썸네일을 생성하는 방법을 보여 줍니다.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // X 및 Y 축을 따라 스케일링합니다.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**도형 썸네일을 저장할 때 사용할 수 있는 이미지 형식은 무엇입니까?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imageformat/), 기타 형식이 지원됩니다. 도형은 또한 도형 내용을 SVG로 저장하여 [벡터 SVG로 내보낼] 수 있습니다(https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/writeassvg/).

**썸네일을 렌더링할 때 Shape 경계와 Appearance 경계의 차이는 무엇입니까?**

`Shape`는 도형의 기하학을 사용하고, `Appearance`는 [visual effects](/slides/ko/cpp/shape-effect/) (그림자, 흐림 효과 등)을 고려합니다.

**도형이 숨김( hidden)으로 표시되면 어떻게 됩니까? 썸네일에 여전히 표시됩니까?**

숨김 도형은 모델의 일부로 남아 있어 렌더링이 가능합니다. 숨김 플래그는 슬라이드쇼 표시에는 영향을 주지만 도형 이미지 생성은 방해하지 않습니다.

**그룹 도형, 차트, SmartArt 및 기타 복합 객체가 지원됩니까?**

예. [Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/)로 표현되는 모든 객체(예: [GroupShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/chart/), [SmartArt](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/smartart/))는 썸네일 또는 SVG로 저장할 수 있습니다.

**시스템에 설치된 폰트가 텍스트 도형 썸네일 품질에 영향을 줍니까?**

예. 원하지 않는 폰트 대체와 텍스트 레이아웃 변형을 방지하려면 [필요한 폰트를 제공](/slides/ko/cpp/custom-font/)하거나 [폰트 대체를 구성](/slides/ko/cpp/font-substitution/)해야 합니다.