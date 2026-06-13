---
title: JavaScript를 사용한 프레젠테이션 차트 호출 관리
linktitle: 호출
type: docs
url: /ko/nodejs-java/callout/
keywords:
- 차트 호출
- 호출 사용
- 데이터 레이블
- 레이블 형식
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java에서 호출을 생성하고 스타일링하며, 간결한 코드 예제를 제공하고 PPT 및 PPTX와 호환되어 프레젠테이션 작업 흐름을 자동화합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 데이터 레이블에 대한 호출(Callout) 사용 방법을 설명합니다. `setShowLabelAsDataCallout` 메서드를 사용하여 레이블을 호출로 표시하는 방법, 도넛 차트에 대한 호출 관련 레이블 설정을 구성하는 방법, 그리고 프레젠테이션을 PDF, HTML5, SVG 및 래스터 이미지 형식으로 내보낼 때 호출과 그 모양이 유지된다는 점을 알려줍니다.

## **호출 사용**

새 메서드 [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) 및 [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-)가 [DataLabelFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabelformat) 클래스에 추가되었습니다. 이러한 메서드는 지정된 차트의 데이터 레이블을 데이터 호출로 표시할지 데이터 레이블로 표시할지를 결정합니다.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 500, 400);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    pres.save("DisplayCharts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **도넛 차트에 호출 설정**

Aspose.Slides for Node.js via Java는 도넛 차트의 시리즈 데이터 레이블 호출 모양 설정을 지원합니다. 아래 예제가 제공됩니다.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Doughnut, 10, 10, 500, 500, false);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    var seriesIndex = 0;
    while (seriesIndex < 15) {
        var series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize(20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    var categoryIndex = 0;
    while (categoryIndex < 15) {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        var i = 0;
        while (i < chart.getChartData().getSeries().size()) {
            var iCS = chart.getChartData().getSeries().get_Item(i);
            var dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
            if (i == (chart.getChartData().getSeries().size() - 1)) {
                var lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new aspose.slides.FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX(lbl.getX() + 0.5);
                lbl.setY(lbl.getY() + 0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**프레젠테이션을 PDF, HTML5, SVG 또는 이미지로 변환할 때 호출이 유지됩니까?**

예. 호출은 차트 렌더링의 일부이므로 [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/ko/nodejs-java/export-to-html5/), [SVG](/slides/ko/nodejs-java/render-a-slide-as-an-svg-image/), 혹은 [raster images](/slides/ko/nodejs-java/convert-powerpoint-to-png/) 로 내보낼 때 슬라이드 서식과 함께 유지됩니다.

**사용자 지정 글꼴이 호출에 적용되고, 내보낼 때 모양이 유지될 수 있나요?**

예. Aspose.Slides는 프레젠테이션에 [임베딩 글꼴](/slides/ko/nodejs-java/embedded-font/)을 지원하며, [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/)와 같은 내보내기 시 글꼴 임베딩을 제어하여 호출이 다양한 시스템에서도 동일하게 표시되도록 합니다.