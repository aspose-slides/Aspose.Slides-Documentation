---
title: C++에서 프레젠테이션 차트 서식 지정
linktitle: 차트 서식 지정
type: docs
weight: 60
url: /ko/cpp/chart-formatting/
keywords:
- 차트 서식 지정
- 차트 포맷팅
- 차트 엔터티
- 차트 속성
- 차트 설정
- 차트 옵션
- 글꼴 속성
- 둥근 테두리
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 차트 서식을 배우고 전문적이고 눈에 띄는 스타일링으로 PowerPoint 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션의 차트를 서식 지정하는 방법을 설명합니다. 축, 눈금선, 제목, 범례, 플롯 영역 및 배경 채우기와 같은 주요 차트 요소를 사용자 지정하여 차트 데이터의 외관과 가독성을 향상시키는 방법을 보여줍니다.

또한 차트 텍스트에 대한 글꼴 속성을 설정하고, 차트 데이터에 사전 설정 및 사용자 지정 숫자 형식을 적용하며, 차트 영역에 둥근 모서리를 활성화하는 방법을 설명합니다. 이러한 예제를 통해 프레젠테이션에서 차트의 시각적 스타일과 데이터 표시를 모두 제어할 수 있습니다.

## **차트 엔터티 서식 지정**
Aspose.Slides for C++를 사용하면 개발자가 처음부터 슬라이드에 사용자 지정 차트를 추가할 수 있습니다. 이 문서에서는 차트 범주 축 및 값 축을 포함한 다양한 차트 엔터티를 서식 지정하는 방법을 설명합니다.

Aspose.Slides for C++는 다양한 차트 엔터티를 관리하고 사용자 지정 값으로 서식 지정하기 위한 간단한 API를 제공합니다.

1. **Presentation** 클래스를 인스턴스화합니다.  
1. 인덱스로 슬라이드 참조를 가져옵니다.  
1. 원하는 차트 유형 중 하나(예: ChartType.LineWithMarkers)를 사용하여 기본 데이터와 함께 차트를 추가합니다.  
1. 차트 값 축에 접근하고 다음 속성을 설정합니다.  
   1. 값 축 주요 눈금선에 대한 **Line format** 설정  
   1. 값 축 보조 눈금선에 대한 **Line format** 설정  
   1. 값 축에 대한 **Number Format** 설정  
   1. 값 축에 대한 **Min, Max, Major and Minor units** 설정  
   1. 값 축 데이터에 대한 **Text Properties** 설정  
   1. 값 축에 대한 **Title** 설정  
   1. 값 축에 대한 **Line Format** 설정  
1. 차트 범주 축에 접근하고 다음 속성을 설정합니다.  
   1. 범주 축 주요 눈금선에 대한 **Line format** 설정  
   1. 범주 축 보조 눈금선에 대한 **Line format** 설정  
   1. 범주 축 데이터에 대한 **Text Properties** 설정  
   1. 범주 축에 대한 **Title** 설정  
   1. 범주 축에 대한 **Label Positioning** 설정  
   1. 범주 축 레이블에 대한 **Rotation Angle** 설정  
1. 차트 범례에 접근하고 **Text Properties**를 설정합니다.  
1. 차트가 겹치지 않도록 차트 범례를 표시합니다.  
1. 차트 **Secondary Value Axis**에 접근하고 다음 속성을 설정합니다.  
   1. 보조 **Value Axis** 활성화  
   1. 보조 값 축에 대한 **Line Format** 설정  
   1. 보조 값 축에 대한 **Number Format** 설정  
   1. 보조 값 축에 대한 **Min, Max, Major and Minor units** 설정  
1. 이제 첫 번째 차트 시리즈를 보조 값 축에 플롯합니다.  
1. 차트 뒤쪽 벽에 채우기 색을 지정합니다.  
1. 차트 플롯 영역에 채우기 색을 지정합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **차트에 대한 글꼴 속성 설정**
Aspose.Slides for C++는 차트에 대한 글꼴 관련 속성을 설정하는 기능을 제공합니다. 차트에 대한 글꼴 속성을 설정하려면 아래 단계를 따르세요.

- **Presentation** 클래스 객체를 인스턴스화합니다.  
- 슬라이드에 차트를 추가합니다.  
- 글꼴 높이를 설정합니다.  
- 수정된 프레젠테이션을 저장합니다.

아래 샘플 예제가 제공됩니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **차트 데이터 테이블에 대한 글꼴 속성 설정**
Aspose.Slides for C++는 시리즈 색상 내 카테고리 색상을 변경하는 기능을 제공합니다.

1. **Presentation** 클래스 객체를 인스턴스화합니다.  
1. 슬라이드에 차트를 추가합니다.  
1. 차트 테이블을 설정합니다.  
1. 글꼴 높이를 설정합니다.  
1. 수정된 프레젠테이션을 저장합니다.

아래 샘플 예제가 제공됩니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **차트 영역 둥근 모서리 설정**
Aspose.Slides for C++는 차트 영역에 대한 설정을 지원합니다. **IChart.HasRoundedCorners** 및 **Chart.HasRoundedCorners** 속성이 Aspose.Slides에 추가되었습니다.

1. **Presentation** 클래스 객체를 인스턴스화합니다.  
1. 슬라이드에 차트를 추가합니다.  
1. 차트의 채우기 유형 및 채우기 색을 설정합니다.  
1. 둥근 모서리 속성을 True로 설정합니다.  
1. 수정된 프레젠테이션을 저장합니다.

아래 샘플 예제가 제공됩니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **숫자 형식 설정**
Aspose.Slides for C++는 차트 데이터 형식을 관리하기 위한 간단한 API를 제공합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화합니다.  
1. 인덱스로 슬라이드 참조를 가져옵니다.  
1. 원하는 차트 유형 중 하나(예: **ChartType.ClusteredColumn**)를 사용하여 기본 데이터와 함께 차트를 추가합니다.  
1. 가능한 사전 설정 값 중에서 사전 설정 숫자 형식을 지정합니다.  
1. 모든 차트 시리즈의 차트 데이터 셀을 순회하면서 차트 데이터 숫자 형식을 설정합니다.  
1. 프레젠테이션을 저장합니다.  
1. 사용자 지정 숫자 형식을 설정합니다.  
1. 모든 차트 시리즈 내부의 차트 데이터 셀을 순회하면서 서로 다른 차트 데이터 숫자 형식을 설정합니다.  
1. 프레젠테이션을 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**사용 가능한 사전 설정 숫자 형식 값 및 해당 인덱스**|
| :- | :- |
|**0**|General|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **FAQ**

**열/영역에 반투명 채우기를 적용하면서 테두리는 불투명하게 유지할 수 있나요?**

예. 채우기 투명도와 외곽선은 별도로 구성됩니다. 이는 격자와 데이터가 밀집된 시각화에서 가독성을 향상시키는 데 유용합니다.

**레이블이 겹칠 때 어떻게 처리해야 하나요?**

글꼴 크기를 줄이거나, 필요하지 않은 레이블 요소(예: 카테고리)를 비활성화하거나, 레이블 오프셋/위치를 조정하거나, 필요한 경우 선택된 포인트에만 레이블을 표시하거나, 형식을 “값 + 범례”로 전환하십시오.

**시리즈에 그라디언트 또는 패턴 채우기를 적용할 수 있나요?**

예. 일반적으로 단색 및 그라디언트/패턴 채우기가 모두 제공됩니다. 실제 사용에서는 그라디언트를 절제해서 사용하고, 격자와 텍스트의 대비를 떨어뜨리는 조합은 피하십시오.