---
title: Android에서 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/androidjava/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항식 추세선
- 거듭제곱 추세선
- 사용자 정의 추세선
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 차트에 추세선을 빠르게 추가하고 맞춤 설정하는 실용적인 가이드 — 청중을 사로잡는 방법."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 만들고, 차트 시리즈에 추세선을 추가하며, 지수형, 선형, 로그형, 이동 평균, 다항식 및 거듭제곱 등 여러 추세선 유형을 사용하는 방법을 보여줍니다.

또한 선 모양을 삽입하여 차트에 사용자 정의 선을 추가하는 방법을 설명하고, 추세선의 앞쪽 및 뒤쪽 투영값과 PDF 또는 SVG로 내보낼 때 또는 차트를 이미지로 렌더링할 때 추세선이 보존되는지에 대한 간단한 FAQ를 포함합니다.

## **추세선 추가**
Aspose.Slides for Android via Java는 다양한 차트 추세선을 관리하기 위한 간단한 API를 제공합니다:

1. [프레젠테이션](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 기본 데이터를 사용하여 원하는 유형의 차트를 추가합니다(이 예제에서는 ChartType.ClusteredColumn 사용).
1. 차트 시리즈 1에 지수형 추세선을 추가합니다.
1. 차트 시리즈 1에 선형 추세선을 추가합니다.
1. 차트 시리즈 2에 로그형 추세선을 추가합니다.
1. 차트 시리즈 2에 이동 평균 추세선을 추가합니다.
1. 차트 시리즈 3에 다항식 추세선을 추가합니다.
1. 차트 시리즈 3에 거듭제곱 추세선을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 추세선이 포함된 차트를 만드는 예시입니다.

```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    // 클러스터드 컬럼 차트를 생성합니다
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // 차트 시리즈 1에 지수 추세선을 추가합니다
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // 차트 시리즈 1에 선형 추세선을 추가합니다
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // 차트 시리즈 2에 로그 추세선을 추가합니다
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // 차트 시리즈 2에 이동 평균 추세선을 추가합니다
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // 차트 시리즈 3에 다항식 추세선을 추가합니다
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // 차트 시리즈 3에 거듭제곱 추세선을 추가합니다
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // 프레젠테이션 저장
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **사용자 정의 선 추가**
Aspose.Slides for Android via Java는 차트에 사용자 정의 선을 추가하기 위한 간단한 API를 제공합니다. 프레젠테이션의 선택된 슬라이드에 간단한 기본 선을 추가하려면 다음 단계를 따르세요:

- [프레젠테이션](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다
- 인덱스를 사용하여 슬라이드 참조를 가져옵니다
- Shapes 객체가 제공하는 AddChart 메서드를 사용해 새 차트를 생성합니다
- Shapes 객체가 제공하는 AddAutoShape 메서드를 사용해 선 유형의 AutoShape을 추가합니다
- 도형 선의 색상을 설정합니다
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다

다음 코드는 사용자 정의 선이 포함된 차트를 만드는 예시입니다.

```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**'앞쪽(forward)' 및 '뒤쪽(backward)'은 추세선에서 무엇을 의미하나요?**

추세선을 앞쪽 또는 뒤쪽으로 투영한 길이를 나타냅니다: 산점도(XY) 차트의 경우 축 단위이며, 비산점도 차트의 경우 카테고리 수입니다. 음수 값은 허용되지 않습니다.

**프레젠테이션을 PDF나 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 보존되나요?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/ko/androidjava/render-a-slide-as-an-svg-image/)로 변환하고 차트를 이미지로 렌더링합니다; 차트의 일부인 추세선은 이러한 작업 중에 보존됩니다. 차트 자체의 이미지를 [내보내는](/slides/ko/androidjava/create-shape-thumbnails/) 메서드도 제공됩니다.