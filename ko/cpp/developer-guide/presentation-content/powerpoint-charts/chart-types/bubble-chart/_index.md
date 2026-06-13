---
title: 프레젠테이션에서 С++를 사용하여 버블 차트 맞춤화
linktitle: 버블 차트
type: docs
url: /ko/cpp/bubble-chart/
keywords:
- 버블 차트
- 버블 크기
- 크기 스케일링
- 크기 표현
- 파워포인트
- 프레젠테이션
- С++
- Aspose.Slides
description: "Aspose.Slides for С++를 사용하여 파워포인트에서 강력한 버블 차트를 만들고 맞춤화하여 데이터 시각화를 쉽게 향상시키세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 버블 차트를 사용하는 방법을 보여줍니다. `set_BubbleSizeScale` 메서드를 통해 버블 크기를 조정하고, `set_BubbleSizeRepresentation` 메서드를 통해 버블 크기 값이 표시되는 방식을 제어하는 두 가지 맞춤 옵션을 다룹니다.

예제에서는 버블 차트를 생성하고, 크기 스케일을 조정하며, 버블 크기 표현을 너비로 전환하는 방법을 보여줍니다. 또한 이 문서에는 “Bubble with 3-D” 차트 유형에 대한 지원을 명확히 하고, 실제 차트 제한이 성능 및 대상 PowerPoint 버전에 따라 달라진다는 점을 언급하며, 내보내기가 Aspose.Slides 렌더링 엔진을 통해 차트 모양을 유지한다는 내용을 포함한 짧은 FAQ 섹션이 포함되어 있습니다.

## **버블 차트 크기 스케일링**
Aspose.Slides for C++는 버블 차트 크기 스케일링을 지원합니다. Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** 및 **IChartSeriesGroup.BubbleSizeScale** 속성이 추가되었습니다. 아래에 샘플 예제가 제공됩니다. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **데이터를 버블 차트 크기로 표시**
새로운 **get_BubbleSizeRepresentation()** 메서드가 **IChartSeries** 및 **ChartSeries** 클래스에 추가되었습니다. **BubbleSizeRepresentation**은 버블 차트에서 버블 크기 값이 어떻게 표시되는지를 지정합니다. 가능한 값은 **BubbleSizeRepresentationType.Area**와 **BubbleSizeRepresentationType.Width**입니다. 이에 따라 데이터를 버블 차트 크기로 표시하는 가능한 방법을 정의하는 **BubbleSizeRepresentationType** 열거형이 추가되었습니다. 아래에 샘플 코드가 제공됩니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **자주 묻는 질문**

**"3D 효과가 있는 버블 차트"가 지원되며, 일반 차트와는 어떻게 다른가요?**

예. 별도의 차트 유형인 "Bubble with 3-D"가 있습니다. 이 유형은 버블에 3D 스타일을 적용하지만 추가 축은 추가되지 않으며, 데이터는 X-Y-S(크기) 형태를 유지합니다. 해당 유형은 [chart type](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/charttype/) 열거형에서 사용할 수 있습니다.

**버블 차트에서 시리즈 및 데이터 포인트 수에 제한이 있나요?**

API 수준에서는 명확한 제한이 없으며, 제한은 성능 및 대상 PowerPoint 버전에 따라 결정됩니다. 가독성과 렌더링 속도를 위해 적절한 데이터 포인트 수를 유지하는 것이 권장됩니다.

**내보내기가 버블 차트의 모양에 어떤 영향을 미치나요(PDF, 이미지 등)?**

지원되는 형식으로 내보낼 경우 차트의 모양이 유지됩니다. 렌더링은 Aspose.Slides 엔진에서 수행됩니다. 래스터/벡터 형식의 경우 일반적인 차트 그래픽 렌더링 규칙(해상도, 안티앨리어싱)이 적용되므로 인쇄 시 충분한 DPI를 선택하십시오.