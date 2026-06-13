---
title: 차트
type: docs
weight: 60
url: /ko/cpp/examples/elements/chart/
keywords:
- 코드 예제
- 차트
- PowerPoint
- 오픈문서
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++용 Aspose.Slides로 차트를 마스터하세요: C++ 예제로 PPT, PPTX 및 ODP에 차트를 생성, 서식 지정, 데이터 바인딩 및 내보내기합니다."
---
다양한 차트 유형을 **Aspose.Slides for C++**로 추가, 액세스, 제거 및 업데이트하는 예제입니다. 아래 스니펫은 기본 차트 작업을 보여줍니다.

## **차트 추가**

이 메서드는 첫 번째 슬라이드에 간단한 영역 차트를 추가합니다.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 첫 번째 슬라이드에 간단한 영역 차트를 추가합니다.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **차트 액세스**

차트를 만든 후에는 shape 컬렉션을 통해 차트를 검색할 수 있습니다.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // 슬라이드의 첫 번째 차트에 액세스합니다.
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IChart>(shape))
        {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **차트 제거**

다음 코드는 슬라이드에서 차트를 제거합니다.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // 차트를 제거합니다.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **차트 데이터 업데이트**

제목과 같은 차트 속성을 변경할 수 있습니다.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // 차트 제목을 변경합니다.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```