---
title: C++을 사용한 Treemap 및 Sunburst 차트 데이터 포인트 사용자 지정
linktitle: Treemap 및 Sunburst 차트의 데이터 포인트
type: docs
url: /ko/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- 트리맵 차트
- 선버스트 차트
- 데이터 포인트
- 라벨 색상
- 브랜치 색상
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 형식과 호환되는 treemap 및 sunburst 차트의 데이터 포인트 관리 방법을 알아보세요."
---
## **소개**

다른 유형의 PowerPoint 차트 중에서 두 개의 “계층형” 차트가 있습니다 - **Treemap** 및 **Sunburst** 차트(다른 이름으로 Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph 또는 Multi Level Pie Chart). 이 차트들은 트리 구조로 정리된 계층형 데이터를 표시합니다 - 잎에서부터 가지의 꼭대기까지. 잎은 시리즈 데이터 포인트로 정의되며, 이후 각 중첩 그룹 수준은 해당 카테고리로 정의됩니다. Aspose.Slides for C++를 사용하면 C++에서 Sunburst 차트와 Treemap 차트의 데이터 포인트를 서식 지정할 수 있습니다.

다음은 Sunburst 차트이며, Series1 열의 데이터가 잎 노드를 정의하고 다른 열은 계층형 데이터 포인트를 정의합니다:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

프레젠테이션에 새 Sunburst 차트를 추가해 보겠습니다:



``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="See also" %}} 
- [**Creating Sunburst Chart**](/slides/ko/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}


차트의 데이터 포인트를 서식 지정해야 하는 경우 다음을 사용해야 합니다:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapointlevel/) 클래스와 [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) 메서드는 Treemap 및 Sunburst 차트의 데이터 포인트를 서식 지정할 수 있는 접근을 제공합니다.
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)는 다중 수준 카테고리에 접근하기 위해 사용됩니다 - 이는 [**IChartDataPointLevel**](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapointlevel/) 객체들의 컨테이너를 나타냅니다. 
기본적으로 이는 [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartcategorylevelsmanager/)에 대한 래퍼이며 데이터 포인트에 특화된 속성이 추가되었습니다. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapointlevel/) 클래스에는 두 개의 메서드가 있습니다: [**get_Format()**](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/)와 [**get_Label()**](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/)로, 각각 해당 설정에 접근할 수 있습니다.

## **데이터 포인트 값 표시**
"Leaf 4" 데이터 포인트의 값을 표시합니다:

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **데이터 포인트 라벨 및 색상 설정**
"Branch 1" 데이터 라벨을 카테고리 이름 대신 시리즈 이름("Series1")이 표시되도록 설정하고, 텍스트 색상을 노란색으로 지정합니다:



``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **데이터 포인트 브랜치 색상 설정**

"Stem 4" 브랜치의 색상을 변경합니다:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Sunburst/Treemap에서 세그먼트 순서(정렬)를 변경할 수 있나요?**

아니요. PowerPoint는 세그먼트를 자동으로 정렬합니다(보통 값이 큰 순서대로 시계 방향). Aspose.Slides도 이 동작을 그대로 따르며, 직접 순서를 변경할 수 없습니다; 데이터를 미리 처리하여 원하는 순서를 구현해야 합니다.

**프레젠테이션 테마가 세그먼트와 라벨 색상에 어떤 영향을 줍니까?**

차트 색상은 프레젠테이션의 [theme/palette](/slides/ko/cpp/presentation-theme/)을 상속합니다. 명시적으로 채우기/폰트를 설정하지 않으면 테마 색상이 적용됩니다. 일관된 결과를 원한다면 필요한 수준에서 고정 색상 및 텍스트 서식을 지정하십시오.

**PDF/PNG로 내보낼 때 사용자 지정 브랜치 색상과 라벨 설정이 유지되나요?**

예. 프레젠테이션을 내보낼 때 차트 설정(채우기, 라벨 등)은 출력 형식에 그대로 보존됩니다. Aspose.Slides는 차트 서식이 적용된 상태로 렌더링합니다.

**차트 위에 사용자 지정 오버레이를 배치하기 위해 라벨/요소의 실제 좌표를 계산할 수 있나요?**

예. 차트 레이아웃 검증이 완료되면 요소(예: [DataLabel](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/datalabel/))에 대해 실제 X와 실제 Y 좌표를 얻을 수 있어, 정확한 오버레이 위치 지정에 활용할 수 있습니다.