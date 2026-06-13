---
title: C++를 사용한 프레젠테이션에서 3D 차트 사용자 지정
linktitle: 3D 차트
type: docs
url: /ko/cpp/3d-chart/
keywords:
- 3D 차트
- 회전
- 깊이
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 3D 차트를 만들고 사용자 지정하는 방법을 배우고, PPT 및 PPTX 파일을 지원하여 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서는 `Rotation3D` 설정인 `RotationX`, `RotationY`, `DepthPercents`, `RightAngleAxes` 등을 구성하여 Aspose.Slides에서 3D 차트를 사용자 지정하는 방법을 설명합니다. 프레젠테이션을 생성하고, 기본 데이터가 있는 3D 차트를 추가하고, 필요한 3D 보기 설정을 적용한 다음, 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 안내합니다.

## **3D 차트의 RotationX, RotationY 및 DepthPercents 속성 설정**
Aspose.Slides for C++는 이러한 속성을 설정하기 위한 간단한 API를 제공합니다. 다음 문서는 X, Y 회전 및 **DepthPercents** 등 다양한 속성을 설정하는 방법을 안내합니다. 샘플 코드는 위에서 언급한 속성을 적용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에 접근합니다.
3. 기본 데이터가 포함된 차트를 추가합니다.
4. Rotation3D 속성을 설정합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **자주 묻는 질문**

**Aspose.Slides에서 3D 모드를 지원하는 차트 유형은 무엇입니까?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D, 100% Stacked Column 3D 등 컬럼 차트의 3D 변형과 [ChartType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/charttype/) 열거형을 통해 노출되는 관련 3D 유형을 지원합니다. 정확하고 최신 목록은 설치된 버전의 API 참고 문서에서 [ChartType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/charttype/) 멤버를 확인하십시오.

**보고서나 웹용으로 3D 차트의 래스터 이미지를 얻을 수 있습니까?**

네. 차트를 [chart API](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getimage/)를 사용해 이미지로 내보내거나 전체 슬라이드를 [render the entire slide](/slides/ko/cpp/convert-powerpoint-to-png/)와 같은 형식(PNG 또는 JPEG 등)으로 변환할 수 있습니다. 이는 픽셀 정확도의 미리보기가 필요하거나 PowerPoint 없이 차트를 문서, 대시보드, 웹 페이지에 삽입하려는 경우에 유용합니다.

**대용량 3D 차트를 구축하고 렌더링하는 성능은 어떻습니까?**

성능은 데이터 양과 시각적 복잡도에 따라 달라집니다. 최상의 결과를 얻으려면 3D 효과를 최소화하고, 벽 및 플롯 영역에 무거운 텍스처를 사용하지 않으며, 가능하면 시리즈당 데이터 포인트 수를 제한하고, 대상 디스플레이 또는 인쇄 요구에 맞는 적절한 해상도와 크기로 출력하도록 렌더링하십시오.