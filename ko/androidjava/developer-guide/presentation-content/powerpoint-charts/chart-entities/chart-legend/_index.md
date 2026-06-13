---
title: 안드로이드에서 프레젠테이션의 차트 범례 사용자 지정
linktitle: 차트 범례
type: docs
url: /ko/androidjava/chart-legend/
keywords:
- 차트 범례
- 범례 위치
- 글꼴 크기
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 차트 범례를 사용자 지정하고 맞춤형 범례 서식으로 PowerPoint 프레젠테이션을 최적화합니다."
---
## **개요**

Aspose.Slides는 PowerPoint 프레젠테이션에서 차트 범례를 사용자 지정할 수 있는 옵션을 제공합니다. 이 문서에서는 범례의 위치와 크기를 지정하고, 범례 전체의 글꼴 크기를 설정하며, 개별 범례 항목에 서식을 적용하는 방법을 보여줍니다.

또한 FAQ에서 여러 관련 동작을 다루며, 범례를 위한 공간을 확보하기 위해 오버레이 모드를 사용하지 않는 방법, 긴 범례 레이블을 자동 줄바꿈하거나 강제 줄바꿈을 허용하는 방법, 명시적인 텍스트 및 채우기 설정이 없을 때 범례 서식이 프레젠테이션 테마에서 상속되도록 하는 방법을 설명합니다.

## **범례 위치 지정**
범례 속성을 설정하려면 아래 단계를 따라 주세요:

- [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
- 슬라이드에 대한 참조를 가져옵니다.
- 슬라이드에 차트를 추가합니다.
- 범례의 속성을 설정합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 차트 범례의 위치와 크기를 설정합니다.

```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    // 슬라이드에 대한 참조를 가져옵니다
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 슬라이드에 클러스터형 열 차트를 추가합니다
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // 범례 속성을 설정합니다
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **범례의 글꼴 크기 설정**
Aspose.Slides for Android via Java를 사용하면 개발자가 범례의 글꼴 크기를 설정할 수 있습니다. 아래 단계를 따라 주세요:

- [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 글꼴 크기를 설정합니다.
- 최소 축 값을 설정합니다.
- 최대 축 값을 설정합니다.
- 프레젠테이션을 디스크에 저장합니다.

```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **개별 범례 항목의 글꼴 크기 설정**
Aspose.Slides for Android via Java를 사용하면 개발자가 개별 범례 항목의 글꼴 크기를 설정할 수 있습니다. 아래 단계를 따라 주세요:

- [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 범례 항목에 접근합니다.
- 글꼴 크기를 설정합니다.
- 최소 축 값을 설정합니다.
- 최대 축 값을 설정합니다.
- 프레젠테이션을 디스크에 저장합니다.

```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**범례가 차트 위에 겹치지 않도록 자동으로 공간을 할당하도록 설정할 수 있나요?**

예. 비오버레이 모드([setOverlay(false)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/legend/#setOverlay-boolean-))를 사용하면 플롯 영역이 범례를 수용하도록 축소됩니다.

**다중 행 범례 레이블을 만들 수 있나요?**

예. 공간이 충분하지 않을 경우 긴 레이블이 자동으로 줄바꿈되며, 시리즈 이름에 개행 문자를 넣어 강제 줄바꿈을 지원합니다.

**범례가 프레젠테이션 테마의 색 구성표를 따르게 하려면 어떻게 해야 하나요?**

범례나 텍스트에 명시적인 색상/채우기/글꼴을 지정하지 마세요. 그러면 테마에서 상속받아 디자인이 변경될 때 올바르게 업데이트됩니다.