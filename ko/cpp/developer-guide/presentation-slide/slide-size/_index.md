---
title: C++에서 프레젠테이션 슬라이드 크기 변경
linktitle: 슬라이드 크기
type: docs
weight: 70
url: /ko/cpp/slide-size/
keywords:
- 슬라이드 크기
- 가로 세로 비율
- 표준
- 와이드스크린
- 4:3
- 16:9
- 슬라이드 크기 설정
- 슬라이드 크기 변경
- 맞춤 슬라이드 크기
- 특수 슬라이드 크기
- 고유 슬라이드 크기
- 전체 크기 슬라이드
- 스크린 유형
- 크기 조정 안 함
- 맞게 맞추기
- 최대화
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
descriptions: "C++와 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 빠르게 크기 조정하는 방법을 배우고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화하십시오."
---
## **Introduction**

Aspose.Slides는 인쇄와 화면 표시 모두에 중요한 PowerPoint 프레젠테이션에서 슬라이드 크기와 가로 세로 비율을 조정하는 포괄적인 도구를 제공합니다.

Popular Slide Sizes and Ratios:

- **Standard (4:3 Aspect Ratio)**: 오래된 화면 및 장치에 적합합니다.
- **Widescreen (16:9 Aspect Ratio)**: 최신 프로젝터 및 디스플레이에 권장됩니다.

프레젠테이션 전체에 일관성을 유지하십시오. 하나의 슬라이드 크기와 가로 세로 비율이 모든 슬라이드에 적용됩니다. 최적의 결과를 위해 프레젠테이션을 만들기 시작할 때 슬라이드 차원을 설정하여 복잡함을 방지하십시오.

{{% alert color="primary" %}} 
By default, presentations created with Aspose.Slides use the standard 4:3 aspect ratio.
{{% /alert %}}

## **Change the Slide Size in Presentations**

 This sample code shows you how to change the slide size in a presentation in C++ using Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Specify Custom Slide Sizes in Presentations**

일반적인 슬라이드 크기(4:3 및 16:9)가 작업에 적합하지 않은 경우 특정하거나 고유한 슬라이드 크기를 사용할 수 있습니다. 예를 들어, 사용자 지정 페이지 레이아웃에 맞게 프레젠테이션에서 전체 크기의 슬라이드를 인쇄하거나 특정 화면 유형에 프레젠테이션을 표시하려는 경우, 맞춤 크기 설정을 활용하면 도움이 됩니다.

This sample code shows you how to use Aspose.Slides for C++ to specify a custom slide size for a presentation in C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 용지 크기
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Handle Slide Content After Resizing**

프레젠테이션의 슬라이드 크기를 변경하면 슬라이드 내용(예: 이미지 또는 개체)이 왜곡될 수 있습니다. 기본적으로 개체는 새 슬라이드 크기에 맞게 자동으로 크기가 조정됩니다. 그러나 프레젠테이션의 슬라이드 크기를 변경할 때 Aspose.Slides가 슬라이드의 내용에 어떻게 처리할지 지정하는 설정을 선택할 수 있습니다.

목표에 따라 다음 설정 중 하나를 사용할 수 있습니다:

- `DoNotScale`

  슬라이드에 있는 개체를 크기 조정하지 않으려면 이 설정을 사용합니다.

- `EnsureFit`

  작은 슬라이드 크기로 축소하면서 모든 개체가 슬라이드에 맞도록 Aspose.Slides가 축소하도록 하려면(내용 손실을 방지) 이 설정을 사용합니다.

- `Maximize`

  큰 슬라이드 크기로 확대하면서 개체를 새 슬라이드 크기에 비례하도록 확대하려면 이 설정을 사용합니다.

This sample code shows you how to use the `Maximize` setting when changing the size of a presentation’s slide:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

**Can I set a custom slide size using units other than inches (for example, points or millimeters)?**

예. Aspose.Slides는 내부적으로 포인트를 사용하며, 1 포인트는 1/72인치에 해당합니다. 밀리미터 또는 센티미터와 같은 단위를 포인트로 변환한 후 해당 값을 슬라이드 너비와 높이로 사용할 수 있습니다.

**Will a very large custom slide size affect performance and memory usage during rendering?**

예. 포인트 단위의 슬라이드 크기가 크고 렌더링 스케일이 높을수록 메모리 사용량이 증가하고 처리 시간이 길어집니다. 실용적인 슬라이드 크기를 목표로 하고, 원하는 출력 품질을 달성하기 위해 필요한 경우에만 렌더링 스케일을 조정하십시오.

**Can I define one non-standard slide size and then merge slides from presentations that have different sizes?**

다른 슬라이드 크기를 가진 상태에서는 [merge presentations](/slides/ko/cpp/merge-presentation/)할 수 없습니다—먼저 한 프레젠테이션의 크기를 다른 프레젠테이션에 맞게 조정하십시오. 슬라이드 크기를 변경할 때는 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidesizescaletype/) 옵션을 통해 기존 콘텐츠 처리 방식을 선택할 수 있습니다. 크기를 맞춘 후에는 서식을 유지하면서 슬라이드를 병합할 수 있습니다.

**Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?**

예. Aspose.Slides는 [entire slides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slide/getimage/)와 [selected shapes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getimage/)에 대한 썸네일을 렌더링할 수 있습니다. 생성된 이미지에는 현재 슬라이드 크기와 가로 세로 비율이 반영되어 일관된 프레임과 기하학을 보장합니다.