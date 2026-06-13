---
title: "JavaScript를 사용하여 프레젠테이션에서 차트 범례 맞춤 설정"
linktitle: "차트 범례"
type: docs
url: /ko/nodejs-java/chart-legend/
keywords:
- "차트 범례"
- "범례 위치"
- "글꼴 크기"
- "PowerPoint"
- "프레젠테이션"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 차트 범례를 맞춤 설정하고, 맞춤형 범례 서식으로 PowerPoint 프레젠테이션을 최적화합니다."
---
## **Overview**

Aspose.Slides는 PowerPoint 프레젠테이션에서 차트 범례를 사용자 지정할 옵션을 제공합니다. 이 문서에서는 범례의 위치와 크기를 지정하고, 전체 범례의 글꼴 크기를 설정하며, 개별 범례 항목에 서식을 적용하는 방법을 보여줍니다.

또한 FAQ에서는 비오버레이 모드를 사용해 플롯 영역이 범례를 위해 공간을 확보하도록 하는 방법, 긴 범례 레이블을 자동으로 줄 바꿈하거나 줄 바꿈 문자를 사용하도록 하는 방법, 텍스트와 채우기 설정을 명시하지 않을 경우 범례 서식이 프레젠테이션 테마에서 상속되도록 하는 방법 등을 다룹니다.

## **Legend Positioning**

In order to set the legend properties. Please follow the steps below:

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
- 슬라이드에 대한 참조를 가져옵니다.
- 슬라이드에 차트를 추가합니다.
- 범례 속성을 설정합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예시에서는 차트 범례의 위치와 크기를 설정했습니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 슬라이드에 대한 참조를 가져옵니다
    var slide = pres.getSlides().get_Item(0);
    // 슬라이드에 클러스터형 열 차트를 추가합니다
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // 범례 속성을 설정합니다
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Font Size of Legend**

Aspose.Slides for Node.js via Java는 개발자가 범례의 글꼴 크기를 설정할 수 있도록 합니다. 아래 단계를 따라 주세요:

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 글꼴 크기를 설정합니다.
- 축 최소값을 설정합니다.
- 축 최대값을 설정합니다.
- 프레젠테이션을 디스크에 저장합니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Font Size of Individual Legend**

Aspose.Slides for Node.js via Java는 개발자가 개별 범례 항목의 글꼴 크기를 설정할 수 있도록 합니다. 아래 단계를 따라 주세요:

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 범례 항목에 접근합니다.
- 글꼴 크기를 설정합니다.
- 축 최소값을 설정합니다.
- 축 최대값을 설정합니다.
- 프레젠테이션을 디스크에 저장합니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**차트가 범례를 오버레이하지 않고 자동으로 공간을 할당하도록 범례를 활성화할 수 있나요?**

예. 비오버레이 모드([setOverlay(false)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/legend/setoverlay/))를 사용합니다. 이 경우 플롯 영역이 축소되어 범례를 수용합니다.

**멀티라인 범례 레이블을 만들 수 있나요?**

예. 공간이 부족할 경우 긴 레이블이 자동으로 줄 바꿈됩니다; 시리즈 이름에 개행 문자를 삽입하면 강제 줄 바꿈도 지원됩니다.

**범례가 프레젠테이션 테마의 색 구성표를 따르도록 하려면 어떻게 해야 하나요?**

범례나 텍스트에 명시적인 색상/채우기/글꼴을 설정하지 마세요. 그러면 테마에서 상속되어 디자인이 변경될 때 올바르게 업데이트됩니다.