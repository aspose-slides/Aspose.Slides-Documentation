---
title: C++를 사용하여 프레젠테이션의 파이 차트 사용자 지정
linktitle: 파이 차트
type: docs
url: /ko/cpp/pie-chart/
keywords:
- 파이 차트
- 차트 관리
- 차트 사용자 지정
- 차트 옵션
- 차트 설정
- 플롯 옵션
- 슬라이스 색상
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 파이 차트를 만들고 사용자 지정하는 방법을 배우고, PowerPoint로 내보내어 몇 초 만에 데이터 스토리텔링을 강화하십시오."
---
## **개요**

이 문서에서는 Aspose.Slides에서 원형 차트를 사용하는 방법을 설명합니다. 원형 차트의 파이오브파이(Pie of Pie) 및 바오브파이(Bar of Pie) 차트에 대한 보조 플롯 옵션을 구성하는 방법과 표준 원형 차트에 대해 자동 슬라이스 색상을 적용하는 방법을 보여줍니다.

예제에서는 차트를 슬라이드에 추가하고, 시리즈 및 레이블 설정을 조정하고, 기본 차트 데이터를 사용자 지정 범주와 값으로 교체하고, 업데이트된 프레젠테이션을 저장하는 등 실용적인 차트 사용자 정의 단계에 중점을 둡니다.

## **파이오브파이 및 바오브파이 차트의 보조 플롯 옵션**

Aspose.Slides for C++는 이제 파이오브파이(Pie of Pie) 또는 바오브파이(Bar of Pie) 차트에 대한 보조 플롯 옵션을 지원합니다. 이 항목에서는 예제를 통해 Aspose.Slides를 사용하여 이러한 옵션을 지정하는 방법을 확인합니다. 속성을 지정하려면 아래 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 객체를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트의 보조 플롯 옵션을 지정합니다.
1. 프레젠테이션을 디스크에 저장합니다.

아래 예제에서는 파이오브파이 차트의 다양한 속성을 설정했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}



## **자동 파이 차트 슬라이스 색상 설정**
Aspose.Slides for C++는 자동 파이 차트 슬라이스 색상을 설정하기 위한 간단한 API를 제공합니다. 샘플 코드는 앞에서 언급한 속성을 적용합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 기본 데이터로 차트를 추가합니다.
1. 차트 제목을 설정합니다.
1. 첫 번째 시리즈를 값 표시로 설정합니다.
1. 차트 데이터 시트의 인덱스를 설정합니다.
1. 차트 데이터 워크시트를 가져옵니다.
1. 기본 생성된 시리즈와 범주를 삭제합니다.
1. 새 범주를 추가합니다.
1. 새 시리즈를 추가합니다.

수정된 프레젠테이션을 PPTX 파일로 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**'Pie of Pie' 및 'Bar of Pie' 변형이 지원됩니까?**

예, 이 라이브러리는 [지원](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/charttype/) 파이 차트에 대한 보조 플롯을 제공하며, 'Pie of Pie' 및 'Bar of Pie' 유형을 포함합니다.

**차트를 이미지(예: PNG)로만 내보낼 수 있습니까?**

예, 전체 프레젠테이션 없이 차트 자체를 이미지(예: PNG)로 [내보낼 수 있습니다](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getimage/).