---
title: 管理 Android 簡報圖表中的標註
linktitle: 標註
type: docs
url: /zh-hant/androidjava/callout/
keywords:
- 圖表標註
- 使用標註
- 資料標籤
- 標籤格式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中使用簡潔的 Java 程式範例建立與樣式化標註，支援 PPT 與 PPTX，協助自動化簡報工作流程。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用圖表資料標籤的標註。它展示了如何使用 `setShowLabelAsDataCallout` 方法將標籤顯示為標註、如何為環形圖設定與標註相關的標籤設定，並且指出在將簡報匯出為 PDF、HTML5、SVG 與點陣圖格式時，標註及其外觀會被保留。

## **使用標註**
已在 [DataLabelFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/datalabelformat) 類別和 [IDataLabelFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabelformat) 介面中加入了新方法 [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) 和 [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-)。這些方法決定指定圖表的資料標籤是顯示為資料標註還是顯示為資料標籤。

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

## **為環形圖設定標註**
Aspose.Slides for Android via Java 提供了對環形圖系列資料標籤標註形狀的設定支援。以下提供範例程式碼。

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

## **常見問題**

**將簡報轉換為 PDF、HTML5、SVG 或圖像時，標註會被保留嗎？**

是。標註是圖表呈現的一部分，因此當您匯出為 [PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh-hant/androidjava/export-to-html5/)、[SVG](/slides/zh-hant/androidjava/render-a-slide-as-an-svg-image/) 或 [raster images](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 時，會與投影片的格式一起被保留。

**自訂字型在標註中是否可使用，且其外觀在匯出時能被保留嗎？**

是。Aspose.Slides 支援將 [embedding fonts](/slides/zh-hant/androidjava/embedded-font/) 嵌入簡報，並在匯出如 [PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/) 等格式時控制字型嵌入，確保標註在不同系統上顯示一致。