---
title: 使用 Java 管理簡報圖表中的引線
linktitle: 引線
type: docs
url: /zh-hant/java/callout/
keywords:
- 圖表引線
- 使用引線
- 資料標籤
- 標籤格式
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中建立並設計引線，提供簡潔的程式碼範例，兼容 PPT 與 PPTX，以自動化簡報工作流程。"
---
## **概述**

本文說明了如何在 Aspose.Slides 中使用圖表資料標籤的引線。它展示了如何使用 `setShowLabelAsDataCallout` 方法將標籤顯示為引線、如何為甜甜圈圖表設定與引線相關的標籤設定，並指出在將簡報匯出為 PDF、HTML5、SVG 和點陣圖影像格式時，會保留引線及其外觀。

## **使用引線**
已在 [DataLabelFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/datalabelformat) 類別與 [IDataLabelFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idatalabelformat) 介面中加入了新方法 [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) 和 [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) 。這些方法決定指定圖表的資料標籤是顯示為資料引線或顯示為資料標籤。

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

## **為甜甜圈圖表設定引線**
Aspose.Slides for Java 提供了為甜甜圈圖表設定系列資料標籤引線形狀的支援。以下提供範例程式碼。

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

**將簡報轉換為 PDF、HTML5、SVG 或影像時，會保留引線嗎？**

是的。引線是圖表呈現的一部分，因此在匯出至 [PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh-hant/java/export-to-html5/)、[SVG](/slides/zh-hant/java/render-a-slide-as-an-svg-image/) 或 [點陣圖影像](/slides/zh-hant/java/convert-powerpoint-to-png/) 時，會與投影片的格式一起保留。

**自訂字型在引線中是否可正常使用，且其外觀在匯出時能保留嗎？**

是的。Aspose.Slides 支援將 [嵌入字型](/slides/zh-hant/java/embedded-font/) 內嵌於簡報，並在匯出為 [PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/) 等格式時控制字型嵌入，確保引線在不同系統上顯示一致。