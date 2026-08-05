---
title: C++를 사용한 프레젠테이션에서 버블 차트 사용자 지정
linktitle: 버블 차트
type: docs
url: /ko/cpp/bubble-chart/
keywords:
- 버블 차트
- 버블 크기
- 크기 스케일링
- 크기 표현
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint에서 강력한 버블 차트를 만들고 맞춤 설정하여 데이터 시각화를 쉽게 향상시키세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 버블 차트를 사용하는 방법을 보여줍니다. 여기서는 `set_BubbleSizeScale` 메서드를 통해 버블 크기를 조정하고 `set_BubbleSizeRepresentation` 메서드를 통해 버블 크기 값이 표시되는 방식을 제어하는 두 가지 특정 사용자 지정 옵션을 다룹니다.

예제에서는 버블 차트를 만들고, 크기 스케일링을 조정하며, 버블 크기 표현을 너비 사용으로 전환하는 방법을 보여줍니다. 또한 이 문서에는 “버블 3D 효과” 차트 유형 지원 여부를 명확히 하고, 실제 차트 제한이 성능 및 대상 PowerPoint 버전에 따라 달라짐을 언급하며, 내보내기가 Aspose.Slides 렌더링 엔진을 통해 차트 외관을 유지한다는 내용을 포함한 짧은 FAQ 섹션이 포함되어 있습니다.

## **버블 차트 크기 스케일링**
Aspose.Slides for C++은 버블 차트 크기 스케일링을 지원합니다. Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** 및 **IChartSeriesGroup.BubbleSizeScale** 속성이 추가되었습니다. 아래 예제 코드가 제공됩니다. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **데이터를 버블 차트 크기로 표현**
새로운 **get_BubbleSizeRepresentation()** 메서드가 **IChartSeries** 및 **ChartSeries** 클래스에 추가되었습니다. **BubbleSizeRepresentation**은 버블 차트에서 버블 크기 값이 어떻게 표시되는지를 지정합니다. 가능한 값은 **BubbleSizeRepresentationType.Area**와 **BubbleSizeRepresentationType.Width**입니다. 따라서 **BubbleSizeRepresentationType** 열거형이 추가되어 데이터를 버블 차트 크기로 표현하는 가능한 방법을 지정합니다. 아래에 샘플 코드가 제공됩니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**“버블 3-D 효과” 차트가 지원되며 일반 차트와 어떻게 다른가요?**

예. 별도의 차트 유형인 “Bubble with 3-D”가 있습니다. 이 유형은 버블에 3-D 스타일을 적용하지만 추가 축은 없습니다; 데이터는 X‑Y‑S(크기) 형태를 유지합니다. 해당 유형은 [chart type](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/charttype/) 열거형에서 사용할 수 있습니다.

**버블 차트에서 시리즈와 포인트 수에 제한이 있나요?**

API 레벨에서는 명확한 제한이 없으며, 제약은 성능 및 대상 PowerPoint 버전에 따라 결정됩니다. 가독성과 렌더링 속도를 위해 포인트 수를 적절하게 유지하는 것이 권장됩니다.

**내보내기가 버블 차트의 외관에 어떤 영향을 미칩니까 (PDF, 이미지)?**

지원되는 형식으로 내보내면 차트의 외관이 유지됩니다; 렌더링은 Aspose.Slides 엔진에 의해 수행됩니다. 래스터/벡터 형식의 경우 일반 차트 그래픽 렌더링 규칙(해상도, 안티앨리어싱)이 적용되므로 인쇄를 위해 충분한 DPI를 선택하십시오.