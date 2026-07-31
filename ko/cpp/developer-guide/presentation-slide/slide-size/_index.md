---
title: C++로 프레젠테이션 슬라이드 크기 변경
linktitle: 슬라이드 크기
type: docs
weight: 70
url: /ko/cpp/slide-size/
keywords:
- 슬라이드 크기
- 가로세로 비율
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
- 축소 안 함
- 맞춤 보장
- 최대화
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: C++와 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 빠르게 크기 조정하는 방법을 배우고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화하십시오.
---
## **소개**

Aspose.Slides는 인쇄와 화면 표시 모두에 중요한 PowerPoint 프레젠테이션에서 슬라이드 크기와 가로세로 비율을 조정할 수 있는 포괄적인 도구를 제공합니다.  

대표적인 슬라이드 크기와 비율:

- **표준 (4:3 비율)**: 오래된 화면 및 장치에 적합합니다.
- **와이드스크린 (16:9 비율)**: 최신 프로젝터 및 디스플레이에 권장됩니다.

프레젠테이션 전체에 일관성을 유지하십시오. 하나의 슬라이드 크기와 비율이 모든 슬라이드에 적용됩니다. 최적의 결과를 위해 프레젠테이션을 만들기 시작할 때 슬라이드 크기를 설정하여 문제를 방지하십시오.

{{% alert color="primary" %}} 
기본적으로 Aspose.Slides로 만든 프레젠테이션은 표준 4:3 비율을 사용합니다.
{{% /alert %}}

## **프레젠테이션에서 슬라이드 크기 변경**

다음 샘플 코드는 Aspose.Slides를 사용하여 C++에서 프레젠테이션의 슬라이드 크기를 변경하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **프레젠테이션에서 사용자 정의 슬라이드 크기 지정**

공통 슬라이드 크기(4:3 및 16:9)가 작업에 적합하지 않다고 판단되면 특정하거나 고유한 슬라이드 크기를 사용할 수 있습니다. 예를 들어, 프레젠테이션을 사용자 정의 페이지 레이아웃에 전체 크기로 인쇄하거나 특정 화면 유형에 표시하려는 경우, 사용자 정의 크기 설정을 사용하면 도움이 됩니다.  

다음 샘플 코드는 C++용 Aspose.Slides를 사용하여 프레젠테이션의 사용자 정의 슬라이드 크기를 지정하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 용지 크기
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **크기 조정 후 슬라이드 내용 처리**

프레젠테이션의 슬라이드 크기를 변경하면 슬라이드 내용(예: 이미지 또는 객체)이 왜곡될 수 있습니다. 기본적으로 객체는 새 슬라이드 크기에 맞게 자동으로 크기가 조정됩니다. 하지만 프레젠테이션의 슬라이드 크기를 변경할 때 Aspose.Slides가 슬라이드 내용에 대해 어떻게 처리할지 설정할 수 있습니다.  

목표에 따라 다음 설정 중 하나를 사용할 수 있습니다:

- `DoNotScale`

  슬라이드의 객체를 크기 조정하지 않으려면 이 설정을 사용하십시오.

- `EnsureFit`

  작은 슬라이드 크기로 축소하고 Aspose.Slides가 슬라이드 객체를 축소하여 모두 슬라이드에 맞추도록 하려면(이렇게 하면 내용 손실을 방지) 이 설정을 사용하십시오.

- `Maximize`

  큰 슬라이드 크기로 확대하고 Aspose.Slides가 슬라이드 객체를 확대하여 새 슬라이드 크기에 비례하도록 하려면 이 설정을 사용하십시오.

다음 샘플 코드는 프레젠테이션 슬라이드 크기를 변경할 때 `Maximize` 설정을 사용하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

**Can I set a custom slide size using units other than inches (for example, points or millimeters)?**  

예. Aspose.Slides는 내부적으로 포인트를 사용하며, 1 포인트는 1/72 인치에 해당합니다. 밀리미터나 센티미터와 같은 단위를 포인트로 변환한 뒤 변환된 값을 사용하여 슬라이드 너비와 높이를 지정할 수 있습니다.

**Will a very large custom slide size affect performance and memory usage during rendering?**  

예. 큰 슬라이드 차원(포인트 단위)과 높은 렌더링 배율을 함께 사용하면 메모리 사용량이 증가하고 처리 시간이 길어집니다. 실용적인 슬라이드 크기를 목표로 하고, 원하는 출력 품질을 얻기 위해 필요한 경우에만 렌더링 배율을 조정하십시오.

**Can I define one non-standard slide size and then merge slides from presentations that have different sizes?**  

다른 슬라이드 크기를 가진 상태에서는 [프레젠테이션 병합](/slides/ko/cpp/merge-presentation/)을 할 수 없습니다—먼저 한 프레젠테이션을 다른 프레젠테이션에 맞게 크기를 조정하십시오. 슬라이드 크기를 변경할 때는 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidesizescaletype/) 옵션을 사용하여 기존 콘텐츠 처리 방식을 선택할 수 있습니다. 크기를 맞춘 후에는 포맷을 유지하면서 슬라이드를 병합할 수 있습니다.

**Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?**  

예. Aspose.Slides는 [전체 슬라이드](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slide/getimage/) 및 [선택한 도형](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getimage/)에 대한 썸네일을 렌더링할 수 있습니다. 생성된 이미지들은 현재 슬라이드 크기와 가로세로 비율을 반영하여 일관된 프레이밍과 기하학을 보장합니다.