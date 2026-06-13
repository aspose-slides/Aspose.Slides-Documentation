---
title: Java를 사용한 프레젠테이션의 파이 차트 사용자 지정
linktitle: 파이 차트
type: docs
url: /ko/java/pie-chart/
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
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 파이 차트를 만들고 사용자 지정하는 방법을 배우고, PowerPoint로 내보내어 몇 초 만에 데이터 스토리텔링을 강화하세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 원형 차트를 사용하는 방법을 설명합니다. 원형 차트의 파이 오브 파이(Pie of Pie)와 바 오브 파이(Bar of Pie) 차트에 대한 보조 플롯 옵션을 구성하는 방법과 표준 원형 차트에 자동 슬라이스 색상을 적용하는 방법을 보여줍니다.

예제에서는 차트를 슬라이드에 추가하고, 시리즈 및 레이블 설정을 조정하며, 기본 차트 데이터를 사용자 지정 카테고리와 값으로 교체하고, 업데이트된 프레젠테이션을 저장하는 등 실용적인 차트 사용자 지정 단계에 중점을 둡니다.

## **파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션**

Aspose.Slides for Java는 이제 파이 오브 파이(Pie of Pie) 또는 바 오브 파이(Bar of Pie) 차트에 대한 보조 플롯 옵션을 지원합니다. 이 항목에서는 Aspose.Slides를 사용하여 해당 옵션을 지정하는 방법을 보여줍니다. 속성을 지정하려면 다음을 수행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스 객체를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트의 보조 플롯 옵션을 지정합니다.
1. 프레젠테이션을 디스크에 저장합니다.

아래 예제에서는 파이 오브 파이 차트의 다양한 속성을 설정했습니다.

```java
// Presentation 클래스 인스턴스 생성
Presentation pres = new Presentation();
try {
    // 슬라이드에 차트 추가
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // 다양한 속성 설정
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // 프레젠테이션을 디스크에 저장
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **자동 파이 차트 슬라이스 색상 설정**

Aspose.Slides for Java는 자동 파이 차트 슬라이스 색상을 설정하기 위한 간단한 API를 제공합니다. 샘플 코드는 앞서 언급한 속성을 적용합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 기본 데이터와 함께 차트를 추가합니다.
1. 차트 제목을 설정합니다.
1. 첫 번째 시리즈를 값 표시로 설정합니다.
1. 차트 데이터 시트의 인덱스를 설정합니다.
1. 차트 데이터 워크시트를 가져옵니다.
1. 기본 생성된 시리즈와 카테고리를 삭제합니다.
1. 새 카테고리를 추가합니다.
1. 새 시리즈를 추가합니다.

수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```java
// Presentation 클래스 인스턴스 생성
Presentation pres = new Presentation();
try {
    // 기본 데이터로 차트 추가
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // 차트 제목 설정
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 첫 번째 시리즈를 값 표시로 설정
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // 차트 데이터 시트 인덱스 설정
    int defaultWorksheetIndex = 0;

    // 차트 데이터 워크시트 가져오기
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // 기본 생성된 시리즈와 카테고리 삭제
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 새 카테고리 추가
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // 새 시리즈 추가
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // 이제 시리즈 데이터 채우기
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**'파이 오브 파이'와 '바 오브 파이' 변형이 지원됩니까?**

예, 라이브러리는 '파이 오브 파이' 및 '바 오브 파이' 유형을 포함한 원형 차트에 대한 보조 플롯을 [지원](https://reference.aspose.com/slides/ko/java/com.aspose.slides/charttype/)합니다.

**차트만 이미지(예: PNG)로 내보낼 수 있나요?**

예, 전체 프레젠테이션 없이 차트 자체를 이미지(예: PNG)로 [내보낼 수 있습니다](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getImage-int-float-float-).