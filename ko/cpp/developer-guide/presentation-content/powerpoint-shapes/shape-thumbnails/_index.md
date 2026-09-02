---
title: C++에서 프레젠테이션 도형의 썸네일 생성
linktitle: 도형 썸네일
type: docs
weight: 70
url: /ko/cpp/shape-thumbnails/
keywords:
- 도형 썸네일
- 도형 이미지
- 도형 렌더링
- 도형 렌더링
- 시각적 경계
- 도형 경계
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 슬라이드에서 고품질 도형 썸네일을 생성하고, 프레젠테이션 썸네일을 손쉽게 만들고 내보냅니다."
---
## **소개**

Aspose.Slides는 각 페이지가 슬라이드인 프레젠테이션 파일을 만드는 데 사용됩니다. 이러한 슬라이드는 Microsoft PowerPoint로 프레젠테이션 파일을 열어 볼 수 있습니다. 하지만 때때로 개발자는 도형의 이미지를 이미지 뷰어에서 별도로 보고 싶을 수 있습니다. 이러한 경우 Aspose.Slides를 사용하면 슬라이드 도형의 썸네일 이미지를 생성할 수 있습니다. 이 기능을 사용하는 방법은 본 문서에 설명되어 있습니다.
이 문서는 슬라이드 썸네일을 다양한 방식으로 생성하는 방법을 설명합니다:

- 슬라이드 내부 도형 썸네일 생성
- 사용자 정의 크기로 슬라이드 도형의 썸네일 생성
- 도형 외관 경계 내에서 썸네일 생성

## **슬라이드에서 도형 썸네일 생성**
Aspose.Slides for C++를 사용하여任意의 슬라이드에서 도형 썸네일을 생성하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용하여 任意의 슬라이드에 대한 참조를 얻습니다.
1. 기본 비율로 참조된 슬라이드의 도형 썸네일 이미지를 가져옵니다.
1. 썸네일 이미지를 원하는 이미지 형식으로 저장합니다.

아래 예제는 도형 썸네일을 생성합니다.

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

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용하여 任意의 슬라이드에 대한 참조를 얻습니다.
1. 도형 경계가 포함된 참조 슬라이드의 썸네일 이미지를 가져옵니다.
1. 썸네일 이미지를 원하는 이미지 형식으로 저장합니다.

아래 예제는 사용자 정의 스케일 팩터를 사용하여 썸네일을 생성합니다.

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
이 방법은 도형의 외관 경계 내에서 썸네일을 생성하도록 허용합니다. 도형에 적용된 모든 효과를 고려합니다. 생성된 도형 썸네일은 슬라이드 경계에 제한됩니다. 외관 경계 내에서 任意의 슬라이드 도형 썸네일을 생성하려면 다음 샘플 코드를 사용하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용하여 任意의 슬라이드에 대한 참조를 얻습니다.
1. 외관으로서 도형 경계가 포함된 참조 슬라이드의 썸네일 이미지를 가져옵니다.
1. 썸네일 이미지를 원하는 이미지 형식으로 저장합니다.

아래 예제는 사용자 정의 스케일 팩터를 사용하여 썸네일을 생성합니다.

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

## **도형의 실제 시각적 경계 가져오기**

[IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/)의 프레임 속성—`IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()`, `IShape::get_Height()`—은 프레젠테이션 모델에 저장된 사각형을 설명합니다. 실제로 렌더링되는 콘텐츠는 해당 프레임을 넘어 확장되거나 다른 축 정렬 사각형을 차지할 수 있습니다. 회전, 외곽선, 화살표 머리, 텍스트 레이아웃 및 오버플로우, 생성된 SmartArt 기하학 및 기타 렌더링 효과가 차지하는 영역을 모두 변경할 수 있습니다.

이미지를 만들지 않고 차지하는 영역을 계산하려면 [Shape::GetVisualBounds](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getvisualbounds/)를 사용하십시오. 이 메서드는 슬라이드 좌표계의 [RectangleF](https://reference.aspose.com/slides/ko/cpp/system.drawing/rectanglef/)를 반환합니다. 반환된 사각형은 슬라이드에 클립되지 않으므로 콘텐츠가 슬라이드 원점을 넘어설 경우 좌표가 음수가 될 수 있습니다.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getvisualbounds/)는 현재 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 인터페이스에 선언되어 있지 않습니다. 따라서 슬라이드의 도형 컬렉션에서 얻은 도형을 인터페이스 형식으로 보관하고, 메서드를 호출할 때만 캐스팅하십시오.

다음 예제는 프레임 경계와 시각적 경계를 가져와 비교합니다:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

동일한 [RectangleF](https://reference.aspose.com/slides/ko/cpp/system.drawing/rectanglef/)를 사용하여 인접 도형을 `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()`, `RectangleF::get_Bottom()` 가장자리에 정렬하거나, 생성된 레이아웃에 충분한 공간을 확보하거나, 허용된 영역 밖의 콘텐츠를 감지할 수 있습니다. 시각적 경계는 저장된 프레임이 전체 렌더링 결과를 나타내지 않을 수 있는 SmartArt, 텍스트 상자, 화살표, 그림, 회전된 도형 및 그룹 도형에 특히 유용합니다.

레이아웃이나 검증을 위한 좌표가 필요하고 비트맵이 필요하지 않을 때는 [Shape::GetVisualBounds](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getvisualbounds/)를 사용하고, 도형을 렌더링해야 할 때는 [IShape::GetImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/getimage/)를 사용하십시오. [ShapeThumbnailBounds](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapethumbnailbounds/)에서 `ShapeThumbnailBounds::Shape`는 외곽선 설정을 포함한 도형 경계에서 이미지를 크기 조정하고, `ShapeThumbnailBounds::Appearance`는 도형 외관에서 크기 조정하며 결과를 슬라이드 경계에 제한합니다. 반면 [Shape::GetVisualBounds](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getvisualbounds/)는 계산된 사각형만 반환하고 슬라이드에 클립하지 않습니다.

## **FAQ**

**도형 썸네일을 저장할 때 사용할 수 있는 이미지 형식은 무엇입니까?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imageformat/), 그 외 등. 도형은 형태를 SVG로 저장하여 [벡터 SVG로 내보낼 수도](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/writeassvg/) 있습니다.

**썸네일을 렌더링할 때 Shape 경계와 Appearance 경계의 차이는 무엇입니까?**

`Shape`는 도형의 기하학을 사용하고, `Appearance`는 [시각 효과](/slides/ko/cpp/shape-effect/) (그림자, 광선 등)를 고려합니다.

**도형이 숨김으로 표시된 경우 어떻게 됩니까? 여전히 썸네일로 렌더링됩니까?**

숨김 도형은 모델의 일부로 남아 있으며 렌더링될 수 있습니다. 숨김 플래그는 슬라이드 쇼 표시에만 영향을 미치며 도형 이미지 생성은 방해하지 않습니다.

**그룹 도형, 차트, SmartArt 및 기타 복합 객체가 지원됩니까?**

예. [Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/)로 표현되는 모든 객체(예: [GroupShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/chart/), [SmartArt](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/smartart/))는 썸네일 또는 SVG로 저장할 수 있습니다.

**시스템에 설치된 폰트가 텍스트 도형 썸네일 품질에 영향을 줍니까?**

예. 원치 않는 폰트 대체 및 텍스트 재배치를 방지하려면 [필요한 폰트를 제공](/slides/ko/cpp/custom-font/)하거나 [폰트 대체를 구성](/slides/ko/cpp/font-substitution/)해야 합니다.