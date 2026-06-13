---
title: Java를 사용하여 프레젠테이션 차트에서 호출선 관리
linktitle: 호출선
type: docs
url: /ko/java/callout/
keywords:
- 차트 호출선
- 호출선 사용
- 데이터 레이블
- 레이블 형식
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 간결한 코드 예제로 호출선을 생성하고 스타일을 지정하여 PPT 및 PPTX와 호환되며 프레젠테이션 워크플로를 자동화합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 데이터 레이블에 대한 호출선을 사용하는 방법을 설명합니다. `setShowLabelAsDataCallout` 메서드를 사용하여 레이블을 호출선으로 표시하는 방법, 도넛 차트에 대한 호출선 관련 레이블 설정을 구성하는 방법, 그리고 프레젠테이션을 PDF, HTML5, SVG 및 래스터 이미지 형식으로 내보낼 때 호출선과 그 모양이 보존된다는 점을 안내합니다.

## **호출선 사용**
새 메서드 [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) 및 [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) 가 [DataLabelFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/datalabelformat) 클래스와 [IDataLabelFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idatalabelformat) 인터페이스에 추가되었습니다. 이 메서드들은 지정된 차트의 데이터 레이블을 호출선으로 표시할지 데이터 레이블로 표시할지를 결정합니다.

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

## **도넛 차트에 호출선 설정**
Aspose.Slides for Java는 도넛 차트에 대한 시리즈 데이터 레이블 호출선 모양을 설정하는 기능을 제공합니다. 아래 예제가 제공됩니다.

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

**프레젠테이션을 PDF, HTML5, SVG 또는 이미지로 변환할 때 호출선이 보존되나요?**

예. 호출선은 차트 렌더링의 일부이므로 [PDF](/slides/ko/java/convert-powerpoint-to-pdf/), [HTML5](/slides/ko/java/export-to-html5/), [SVG](/slides/ko/java/render-a-slide-as-an-svg-image/) 또는 [래스터 이미지](/slides/ko/java/convert-powerpoint-to-png/) 로 내보낼 때 슬라이드 서식과 함께 보존됩니다.

**사용자 지정 폰트가 호출선에 적용되고, 내보낼 때 모양이 보존될 수 있나요?**

예. Aspose.Slides는 프레젠테이션에 [폰트 삽입](/slides/ko/java/embedded-font/)을 지원하며, [PDF](/slides/ko/java/convert-powerpoint-to-pdf/) 등 내보내기 시 폰트 삽입을 제어하여 호출선이 다양한 시스템에서도 동일하게 표시되도록 합니다.