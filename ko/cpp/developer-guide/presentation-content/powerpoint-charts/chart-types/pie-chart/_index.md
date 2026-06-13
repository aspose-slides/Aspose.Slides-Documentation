---
title: 프레젠테이션에서 С++를 사용하여 파이 차트 사용자 지정
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
- С++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 С++에서 파이 차트를 만들고 사용자 지정하는 방법을 배우세요. PowerPoint로 내보낼 수 있어 데이터를 몇 초 만에 스토리텔링 할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 파이 차트를 사용하는 방법을 설명합니다. 파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션을 구성하는 방법과 일반 파이 차트에 대한 자동 슬라이스 색상 지정 방법을 보여줍니다.

예제는 슬라이드에 차트를 추가하고, 시리즈 및 레이블 설정을 조정하고, 기본 차트 데이터를 사용자 지정 카테고리와 값으로 교체하고, 업데이트된 프레젠테이션을 저장하는 등 실용적인 차트 사용자 지정 단계에 중점을 둡니다.

## **파이 오브 파이 및 바 오브 파이 차트용 보조 플롯 옵션**
Aspose.Slides for C++는 이제 파이 오브 파이 또는 바 오브 파이 차트에 대한 보조 플롯 옵션을 지원합니다. 이 항목에서는 예제를 통해 Aspose.Slides를 사용하여 이러한 옵션을 지정하는 방법을 살펴봅니다. 속성을 지정하려면 아래 단계를 따르세요.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 개체를 인스턴스화합니다.
2. 슬라이드에 차트를 추가합니다.
3. 차트의 보조 플롯 옵션을 지정합니다.
4. 프레젠테이션을 디스크에 기록합니다.

아래 예제에서는 파이 오브 파이 차트의 다양한 속성을 설정했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **자동 파이 차트 슬라이스 색상 설정**
Aspose.Slides for C++는 자동 파이 차트 슬라이스 색상을 설정하기 위한 간단한 API를 제공합니다. 아래 샘플 코드는 앞서 언급한 속성을 적용합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에 접근합니다.
3. 기본 데이터를 사용하여 차트를 추가합니다.
4. 차트 제목을 설정합니다.
5. 첫 번째 시리즈에 값 표시를 설정합니다.
6. 차트 데이터 시트의 인덱스를 설정합니다.
7. 차트 데이터 워크시트를 가져옵니다.
8. 기본 생성된 시리즈와 카테고리를 삭제합니다.
9. 새 카테고리를 추가합니다.
10. 새 시리즈를 추가합니다.

수정된 프레젠테이션을 PPTX 파일로 기록합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**'Pie of Pie' 및 'Bar of Pie' 변형이 지원됩니까?**

네, 라이브러리는 [지원](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/charttype/) 파이 차트용 보조 플롯을 제공하며, 여기에는 'Pie of Pie' 및 'Bar of Pie' 유형이 포함됩니다.

**차트만 이미지(PNG 등)로 내보낼 수 있나요?**

네, 전체 프레젠테이션이 아니라 차트 자체를 이미지(PNG 등)로 [내보낼 수](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getimage/) 있습니다.