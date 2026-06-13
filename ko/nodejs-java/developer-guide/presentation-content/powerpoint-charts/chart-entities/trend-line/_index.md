---
title: JavaScript로 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/nodejs-java/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항식 추세선
- 멱 추세선
- 맞춤 추세선
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 차트에 추세선을 빠르게 추가하고 사용자 지정하는 실용적인 가이드로, 청중의 관심을 끌어보세요."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 만들고, 차트 시리즈에 추세선을 추가하며, 지수, 선형, 로그, 이동 평균, 다항식 및 멱형 등의 여러 추세선 유형을 사용하는 방법을 보여줍니다.

또한 라인 도형을 삽입하여 차트에 맞춤 선을 추가하는 방법을 설명하고, 앞으로 및 뒤로 추세선 투영값에 대한 짧은 FAQ와 PDF 또는 SVG로 내보낼 때 및 차트를 이미지로 렌더링할 때 추세선이 보존되는지 여부에 대해 설명합니다.

## **추세선 추가**

Aspose.Slides for Node.js via Java는 다양한 차트 추세선을 관리하기 위한 간단한 API를 제공합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 원하는 유형의 차트를 기본 데이터와 함께 추가합니다(이 예에서는 ChartType.ClusteredColumn 사용).
1. 차트 시리즈 1에 지수 추세선을 추가합니다.
1. 차트 시리즈 1에 선형 추세선을 추가합니다.
1. 차트 시리즈 2에 로그 추세선을 추가합니다.
1. 차트 시리즈 2에 이동 평균 추세선을 추가합니다.
1. 차트 시리즈 3에 다항식 추세선을 추가합니다.
1. 차트 시리즈 3에 멱형 추세선을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 추세선이 포함된 차트를 생성하는 예시입니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 클러스터드 컬럼 차트를 생성합니다
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // 차트 시리즈 1에 지수 추세선을 추가합니다
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // 차트 시리즈 1에 선형 추세선을 추가합니다
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // 차트 시리즈 2에 로그 추세선을 추가합니다
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // 차트 시리즈 2에 이동 평균 추세선을 추가합니다
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // 차트 시리즈 3에 다항식 추세선을 추가합니다
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // 차트 시리즈 3에 멱 추세선을 추가합니다
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // 프레젠테이션 저장
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **맞춤 선 추가**

Aspose.Slides for Node.js via Java는 차트에 맞춤 선을 추가하기 위한 간단한 API를 제공합니다. 프레젠테이션의 선택된 슬라이드에 단순한 직선을 추가하려면 다음 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다
- 인덱스를 사용하여 슬라이드 참조를 가져옵니다
- Shapes 객체가 제공하는 AddChart 메서드를 사용해 새 차트를 생성합니다
- Shapes 객체가 제공하는 AddAutoShape 메서드를 사용해 라인 유형의 AutoShape을 추가합니다
- 도형 선의 색을 설정합니다
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다

다음 코드는 맞춤 선이 포함된 차트를 생성하는 예시입니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**'forward'와 'backward'는 추세선에서 무엇을 의미합니까?**

추세선을 앞으로/뒤로 연장한 길이입니다. 산점도(XY) 차트에서는 축 단위로, 비산점도 차트에서는 카테고리 수로 표시됩니다. 음수 값은 허용되지 않습니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 보존됩니까?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/ko/nodejs-java/render-a-slide-as-an-svg-image/)로 변환하고 차트를 이미지로 렌더링합니다; 차트의 일부인 추세선은 이러한 작업 중에 보존됩니다. 차트 자체의 이미지를 [내보내는](/slides/ko/nodejs-java/create-shape-thumbnails/) 메서드도 제공됩니다.