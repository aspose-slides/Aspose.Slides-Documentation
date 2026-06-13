---
title: .NET에서 프레젠테이션용 3D 차트 맞춤 설정
linktitle: 3D 차트
type: docs
url: /ko/net/3d-chart/
keywords:
- 3D 차트
- 회전
- 깊이
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 PPT 및 PPTX 파일을 지원하는 3D 차트를 생성하고 맞춤 설정하는 방법을 배워 프레젠테이션을 강화하세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 `Rotation3D` 설정인 `RotationX`, `RotationY`, `DepthPercents`, `RightAngleAxes` 등을 구성하여 3D 차트를 사용자 정의하는 방법을 설명합니다. 프레젠테이션을 만들고, 기본 데이터가 포함된 3D 차트를 추가하고, 필요한 3D 보기 설정을 적용한 뒤, 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 단계별로 안내합니다.

## **3D 차트의 RotationX, RotationY 및 DepthPercents 속성 설정**
Aspose.Slides for .NET은 이러한 속성을 설정하기 위한 간단한 API를 제공합니다. 이 문서는 X, Y 회전, **DepthPercents** 등 다양한 속성을 설정하는 방법을 안내합니다. 샘플 코드는 위에서 언급한 속성을 적용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 액세스합니다.
1. 기본 데이터가 포함된 차트를 추가합니다.
1. Rotation3D 속성을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
// Presentation 클래스의 인스턴스를 생성합니다
Presentation presentation = new Presentation();
           
// 첫 번째 슬라이드에 액세스합니다
ISlide slide = presentation.Slides[0];

// 기본 데이터가 있는 차트를 추가합니다
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// 차트 데이터 시트의 인덱스를 설정합니다
int defaultWorksheetIndex = 0;

// 차트 데이터 워크시트를 가져옵니다
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 시리즈를 추가합니다
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// 범주를 추가합니다
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Rotation3D 속성을 설정합니다
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// 두 번째 차트 시리즈를 가져옵니다
IChartSeries series = chart.ChartData.Series[1];

// 이제 시리즈 데이터를 채웁니다
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// OverLap 값을 설정합니다
series.ParentSeriesGroup.Overlap = 100;         

// 프레젠테이션을 디스크에 저장합니다
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides에서 3D 모드를 지원하는 차트 유형은 무엇입니까?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D, 100% Stacked Column 3D 등 컬럼 차트의 3D 변형을 지원하며, 관련 3D 유형은 [ChartType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/charttype/) 열거형을 통해 제공됩니다. 정확하고 최신 목록은 설치된 버전의 API 레퍼런스에서 [ChartType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/charttype/) 멤버를 확인하십시오.

**보고서나 웹용 3D 차트의 래스터 이미지를 얻을 수 있습니까?**

예. 차트를 이미지로 내보내려면 [chart API](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/getimage/)를 사용하거나 전체 슬라이드를 [/slides/ko/net/convert-powerpoint-to-png/]와 같은 경로를 통해 PNG 또는 JPEG와 같은 형식으로 렌더링할 수 있습니다. 이는 픽셀 정확도의 미리보기가 필요하거나 PowerPoint 없이 차트를 문서, 대시보드, 웹 페이지에 삽입하려는 경우에 유용합니다.

**대용량 3D 차트를 구축하고 렌더링하는 성능은 어떻습니까?**

성능은 데이터 양과 시각적 복잡도에 따라 달라집니다. 최상의 결과를 얻으려면 3D 효과를 최소화하고, 벽과 플롯 영역에 무거운 텍스처를 사용하지 않으며, 가능한 경우 시리즈당 데이터 포인트 수를 제한하고, 대상 디스플레이 또는 인쇄 요구에 맞게 적절한 해상도와 크기의 출력으로 렌더링하십시오.