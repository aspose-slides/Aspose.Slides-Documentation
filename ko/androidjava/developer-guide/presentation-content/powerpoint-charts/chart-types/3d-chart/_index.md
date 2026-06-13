---
title: Android에서 프레젠테이션용 3D 차트 맞춤 설정
linktitle: 3D 차트
type: docs
url: /ko/androidjava/3d-chart/
keywords:
- 3D 차트
- 회전
- 깊이
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java에서 PPT 및 PPTX 파일을 지원하는 3D 차트를 생성하고 맞춤 설정하는 방법을 배우고, 오늘 바로 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서는 `Rotation3D` 설정(예: `RotationX`, `RotationY`, `DepthPercents`, `RightAngleAxes`)을 구성하여 Aspose.Slides에서 3D 차트를 사용자 지정하는 방법을 설명합니다. 프레젠테이션을 만들고 기본 데이터가 포함된 3D 차트를 추가한 다음 필요한 3D 뷰 설정을 적용하고 수정된 프레젠테이션을 PPTX 파일로 저장하는 과정을 단계별로 안내합니다.

## **3D 차트의 RotationX, RotationY 및 DepthPercents 속성 설정**
Aspose.Slides for Android via Java는 이러한 속성을 설정하기 위한 간단한 API를 제공합니다. 이 문서는 **X, Y 회전, DepthPercents** 등 다양한 속성을 설정하는 방법을 안내합니다. 아래 샘플 코드는 앞에서 언급한 속성을 적용하는 예제입니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 액세스합니다.
1. 기본 데이터를 사용해 차트를 추가합니다.
1. Rotation3D 속성을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```java
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드에 액세스
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 기본 데이터가 있는 차트를 추가
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // 차트 데이터 시트의 인덱스 설정
    int defaultWorksheetIndex = 0;
    
    // 차트 데이터 워크시트 가져오기
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // 시리즈 추가
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // 카테고리 추가
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Rotation3D 속성 설정
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // 두 번째 차트 시리즈 가져오기
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // 이제 시리즈 데이터를 채우고 있음
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Overlap 값 설정
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // 프레젠테이션을 디스크에 저장
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Aspose.Slides에서 3D 모드를 지원하는 차트 유형은 무엇인가요?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D, 100% Stacked Column 3D 등 막대 차트의 3D 변형 및 [ChartType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/charttype/) 클래스에서 노출되는 관련 3D 유형을 지원합니다. 정확하고 최신 목록은 사용 중인 버전의 API 레퍼런스에 있는 [ChartType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/charttype/) 멤버를 확인하세요.

**보고서나 웹용으로 3D 차트의 래스터 이미지를 얻을 수 있나요?**

네. 차트를 이미지로 내보내려면 [chart API](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)를 사용하거나 전체 슬라이드를 PNG 또는 JPEG와 같은 형식으로 [/slides/ko/androidjava/convert-powerpoint-to-png/](/slides/ko/androidjava/convert-powerpoint-to-png/) 변환하여 내보낼 수 있습니다. 이는 픽셀 정확도가 필요한 미리보기나 차트를 문서, 대시보드, 웹 페이지에 삽입하려는 경우에 유용합니다.

**대용량 3D 차트를 빌드하고 렌더링하는 성능은 어떤가요?**

성능은 데이터 양과 시각적 복잡도에 따라 달라집니다. 최적의 결과를 위해 3D 효과를 최소화하고, 벽과 플롯 영역에 무거운 텍스처를 사용하지 않으며, 가능하면 시리즈당 데이터 포인트 수를 제한하고, 대상 디스플레이나 인쇄 요구에 맞는 적절한 해상도와 크기의 출력으로 렌더링하는 것이 좋습니다.