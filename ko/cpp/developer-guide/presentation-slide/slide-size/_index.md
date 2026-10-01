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
- 사용자 지정 슬라이드 크기
- 특수 슬라이드 크기
- 고유 슬라이드 크기
- 전체 크기 슬라이드
- 화면 유형
- 크기 조정 안 함
- 맞춤 보장
- 최대화
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++와 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 빠르게 크기 조정하는 방법을 배우고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화하세요."
---
## **소개**

Aspose.Slides는 PowerPoint 프레젠테이션에서 슬라이드 크기와 가로 세로 비율을 조정하기 위한 포괄적인 도구를 제공하며, 이는 인쇄와 화면 표시 모두에 중요합니다. 

인기 슬라이드 크기 및 비율:

- **표준 (4:3 비율)**: 오래된 화면 및 장치에 이상적입니다.
- **와이드스크린 (16:9 비율)**: 최신 프로젝터와 디스플레이에 권장됩니다.

프레젠테이션 전체에 일관성을 유지하려면 모든 슬라이드에 동일한 슬라이드 크기와 비율을 적용해야 합니다. 최적의 결과를 얻으려면 프레젠테이션을 만들기 시작할 때 슬라이드 차원을 설정하여 복잡함을 피하세요.

{{% alert color="info" %}} 
기본적으로 Aspose.Slides로 만든 프레젠테이션은 표준 4:3 가로 세로 비율을 사용합니다.
{{% /alert %}}

노트 및 핸드아웃 페이지는 일반 슬라이드와 별도의 차원을 가집니다. 크기와 방향을 변경하려면 [Notes Page Size](/slides/ko/cpp/notes-size/)를 참조하세요.

## **프레젠테이션에서 슬라이드 크기 변경**

 이 샘플 코드는 C++에서 Aspose.Slides를 사용하여 프레젠테이션의 슬라이드 크기를 변경하는 방법을 보여줍니다:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **프레젠테이션에서 사용자 지정 슬라이드 크기 지정**

일반적인 슬라이드 크기(4:3 및 16:9)가 작업에 적합하지 않다면 특정하거나 고유한 슬라이드 크기를 사용할 수 있습니다. 예를 들어, 프레젠테이션을 사용자 지정 페이지 레이아웃에 전체 크기로 인쇄하거나 특정 화면 유형에 표시하려는 경우, 프레젠테이션에 사용자 지정 크기 설정을 적용하면 도움이 됩니다. 

이 샘플 코드는 C++에서 Aspose.Slides를 사용하여 프레젠테이션에 사용자 지정 슬라이드 크기를 지정하는 방법을 보여줍니다:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 용지 크기
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **크기 조정 후 슬라이드 내용 처리**

프레젠테이션의 슬라이드 크기를 변경하면 슬라이드 내용(예: 이미지 또는 개체)이 왜곡될 수 있습니다. 기본적으로 개체는 새로운 슬라이드 크기에 맞게 자동으로 크기가 조정됩니다. 그러나 프레젠테이션의 슬라이드 크기를 변경할 때 Aspose.Slides가 슬라이드 내용에 대해 어떻게 처리할지 결정하는 설정을 지정할 수 있습니다.

목표에 따라 다음 설정 중 하나를 사용할 수 있습니다:

- `DoNotScale`

  슬라이드의 개체 크기를 조정하지 않으려면 이 설정을 사용합니다.

- `EnsureFit`

  더 작은 슬라이드 크기로 축소하고 모든 개체가 슬라이드에 맞도록 Aspose.Slides가 축소하도록 하려면(내용 손실을 방지) 이 설정을 사용합니다. 

- `Maximize`

  더 큰 슬라이드 크기로 확대하고 개체를 새 슬라이드 크기에 비례하도록 확대하려면 이 설정을 사용합니다. 

이 샘플 코드는 프레젠테이션 슬라이드 크기를 변경할 때 `Maximize` 설정을 사용하는 방법을 보여줍니다:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

### 인치를 제외한 단위(예: 포인트 또는 밀리미터)로 사용자 지정 슬라이드 크기를 설정할 수 있나요?

예. Aspose.Slides는 내부적으로 포인트를 사용하며, 1포인트는 1/72인치에 해당합니다. 밀리미터나 센티미터와 같은 단위를 포인트로 변환한 후 슬라이드 너비와 높이를 정의할 수 있습니다.

### 매우 큰 사용자 지정 슬라이드 크기가 렌더링 중 성능 및 메모리 사용량에 영향을 미치나요?

예. 포인트 단위로 큰 슬라이드 치수와 높은 렌더링 배율을 결합하면 메모리 소비가 증가하고 처리 시간이 길어집니다. 실용적인 슬라이드 크기를 목표로 하고, 필요한 출력 품질을 달성하기 위해 렌더링 배율만 조정하세요.

### 하나의 비표준 슬라이드 크기를 정의한 뒤, 다른 크기의 프레젠테이션에서 슬라이드를 병합할 수 있나요?

다른 슬라이드 크기를 가진 상태에서는 [merge presentations](/slides/ko/cpp/merge-presentation/)를 할 수 없습니다 — 먼저 한 프레젠테이션을 다른 프레젠테이션에 맞게 크기 조정해야 합니다. 슬라이드 크기를 변경할 때 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidesizescaletype/) 옵션을 통해 기존 내용 처리 방식을 선택할 수 있습니다. 크기를 맞춘 후에는 서식을 유지하면서 슬라이드를 병합할 수 있습니다.

### 개별 도형이나 슬라이드의 특정 영역에 대한 썸네일을 생성할 수 있으며, 새 슬라이드 크기를 반영하나요?

예. Aspose.Slides는 [entire slides]((https://reference.aspose.com/slides/ko/cpp/aspose.slides/slide/getimage/))뿐만 아니라 [selected shapes]((https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getimage/))에 대한 썸네일도 렌더링할 수 있습니다. 생성된 이미지는 현재 슬라이드 크기와 가로 세로 비율을 반영하여 일관된 프레이밍과 기하학을 보장합니다.