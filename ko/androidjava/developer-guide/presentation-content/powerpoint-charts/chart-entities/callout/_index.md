---
title: Android에서 프레젠테이션 차트의 콜아웃 관리
linktitle: 콜아웃
type: docs
url: /ko/androidjava/callout/
keywords:
- 차트 콜아웃
- 콜아웃 사용
- 데이터 레이블
- 레이블 형식
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android에서 간결한 Java 코드 예제로 콜아웃을 만들고 스타일을 지정하여 PPT 및 PPTX와 호환되어 프레젠테이션 워크플로를 자동화합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 데이터 레이블에 대한 콜아웃을 사용하는 방법을 설명합니다. `setShowLabelAsDataCallout` 메서드를 사용하여 레이블을 콜아웃으로 표시하는 방법, 도넛 차트에 대한 콜아웃 관련 레이블 설정을 구성하는 방법, 그리고 프레젠테이션을 PDF, HTML5, SVG 및 래스터 이미지 형식으로 내보낼 때 콜아웃과 그 모양이 유지된다는 점을 보여줍니다.

## **콜아웃 사용**
New methods [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) and [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) have been added to [DataLabelFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/datalabelformat) class and [IDataLabelFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idatalabelformat) interface. These methods determine either specified chart's data label will be displayed as data callout or as data label.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400);
    
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    
    pres.save("DisplayCharts.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **도넛 차트에 콜아웃 설정**
Aspose.Slides for Android via Java는 도넛 차트에 대한 시리즈 데이터 레이블 콜아웃 모양을 설정하는 기능을 제공합니다. 아래 예제가 제공됩니다.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, false);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    int seriesIndex = 0;
    while (seriesIndex < 15)
    {
        IChartSeries series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize((byte)20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    int categoryIndex = 0;
    while (categoryIndex < 15)
    {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        int i = 0;
        while (i < chart.getChartData().getSeries().size())
        {
            IChartSeries iCS = chart.getChartData().getSeries().get_Item(i);
            IChartDataPoint dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(LineDashStyle.Solid);
            if (i == chart.getChartData().getSeries().size() - 1)
            {
                IDataLabel lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.LIGHT_GRAY);
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX((float) lbl.getX()+ (float)0.5);
                lbl.setY((float)lbl.getY()+ (float)0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**프레젠테이션을 PDF, HTML5, SVG 또는 이미지로 변환할 때 콜아웃이 유지됩니까?**

예. 콜아웃은 차트 렌더링의 일부이므로 [PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/), [HTML5](/slides/ko/androidjava/export-to-html5/), [SVG](/slides/ko/androidjava/render-a-slide-as-an-svg-image/), 또는 [raster images](/slides/ko/androidjava/convert-powerpoint-to-png/) 로 내보낼 때 슬라이드의 서식과 함께 유지됩니다.

**사용자 지정 글꼴이 콜아웃에서 작동하고 내보낼 때 그 모양을 유지할 수 있습니까?**

예. Aspose.Slides는 프레젠테이션에 [embedding fonts](/slides/ko/androidjava/embedded-font/)을 지원하고 [PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/)와 같은 내보내기 시 글꼴 포함을 제어하여 다양한 시스템에서 콜아웃이 동일하게 표시되도록 합니다.