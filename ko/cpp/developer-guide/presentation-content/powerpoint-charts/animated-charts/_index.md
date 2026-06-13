---
title: C++에서 PowerPoint 차트 애니메이션
linktitle: 애니메이션 차트
type: docs
weight: 80
url: /ko/cpp/animated-charts/
keywords:
- 차트
- 애니메이션 차트
- 차트 애니메이션
- 차트 시리즈
- 차트 카테고리
- 시리즈 요소
- 카테고리 요소
- 효과 추가
- 효과 유형
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 멋진 애니메이션 차트를 만들세요. PPT 및 PPTX 파일에서 동적 비주얼로 프레젠테이션을 강화하고 지금 바로 시작하세요."
---
## **소개**

Aspose.Slides는 차트 요소의 애니메이션을 지원합니다. **Series**, **Categories**, **Series Elements**, **Categories Elements**는 [ISequence::AddEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/isequence/addeffect/) 메서드와 두 개의 열거형 [EffectChartMajorGroupingType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effectchartmajorgroupingtype/) 및 [EffectChartMinorGroupingType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effectchartminorgroupingtype/)을 사용하여 애니메이션할 수 있습니다.

## **차트 시리즈 애니메이션**
차트 시리즈를 애니메이션하려면, 아래에 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체에 대한 참조를 가져옵니다.
1. 시리즈에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **시리즈 요소의 애니메이션**
시리즈 요소에 애니메이션을 적용하려면, 아래에 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체에 대한 참조를 가져옵니다.
1. 시리즈 요소에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **차트 카테고리 애니메이션**
차트 카테고리를 애니메이션하려면, 아래에 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체에 대한 참조를 가져옵니다.
1. 카테고리에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **카테고리 요소의 애니메이션**
카테고리 요소에 애니메이션을 적용하려면, 아래에 나열된 단계에 따라 코드를 작성하십시오:

1. 프레젠테이션을 로드합니다.
1. 차트 객체에 대한 참조를 가져옵니다.
1. 카테고리 요소에 애니메이션을 적용합니다.
1. 프레젠테이션 파일을 디스크에 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **FAQ**

**차트가 일반 도형과 마찬가지로 다양한 효과 유형(예: 들어오기, 강조, 나가기)을 지원합니까?**

예. 차트는 도형으로 취급되므로, 들어오기, 강조, 나가기 등을 포함한 표준 애니메이션 효과 유형을 지원하며, 슬라이드 타임라인 및 애니메이션 시퀀스를 통해 완전한 제어가 가능합니다.

**차트 애니메이션을 슬라이드 전환과 결합할 수 있습니까?**

예. [Transitions](/slides/ko/cpp/slide-transition/)은 슬라이드에 적용되고, 애니메이션 효과는 슬라이드의 객체에 적용됩니다. 두 가지를 동일한 프레젠테이션에서 함께 사용할 수 있으며 각각 독립적으로 제어할 수 있습니다.

**차트 애니메이션이 PPTX로 저장할 때 보존됩니까?**

예. [save to PPTX](/slides/ko/cpp/save-presentation/) 시, 모든 애니메이션 효과와 순서가 프레젠테이션의 기본 애니메이션 모델에 포함되어 있기 때문에 보존됩니다.

**프레젠테이션에서 기존 차트 애니메이션을 읽어 수정할 수 있습니까?**

예. [API](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/)는 슬라이드 타임라인, 시퀀스 및 효과에 대한 접근을 제공하므로, 기존 차트 애니메이션을 검사하고 처음부터 모두 다시 만들 필요 없이 조정할 수 있습니다.

**Aspose.Slides를 사용하여 차트 애니메이션이 포함된 비디오를 만들 수 있습니까?**

예. [export a presentation to video](/slides/ko/cpp/convert-powerpoint-to-video/)를 사용하면 애니메이션을 보존하면서 타이밍 및 기타 내보내기 설정을 구성하여 결과 클립이 애니메이션 재생을 반영하도록 할 수 있습니다.