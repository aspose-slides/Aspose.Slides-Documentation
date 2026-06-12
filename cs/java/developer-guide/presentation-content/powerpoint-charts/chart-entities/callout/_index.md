---
title: Správa výběrů v grafech prezentace pomocí Javy
linktitle: Výběr
type: docs
url: /cs/java/callout/
keywords:
- výběr grafu
- použití výběru
- popisek dat
- formát popisku
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvářejte a stylujte výběry v Aspose.Slides pro Javu pomocí stručných ukázek kódu, kompatibilních s PPT a PPTX k automatizaci pracovních postupů prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s výběry pro popisky dat v grafech v Aspose.Slides. Ukazuje, jak použít metodu `setShowLabelAsDataCallout` k zobrazení popisků jako výběry, jak nakonfigurovat nastavení popisků souvisejících s výběrem pro kruhový graf a poznamenává, že výběry a jejich vzhled jsou zachovány při exportu prezentací do formátů PDF, HTML5, SVG a rastrových obrázků.

## **Používání výběrů**
Do třídy [DataLabelFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/datalabelformat) a rozhraní [IDataLabelFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idatalabelformat) byly přidány nové metody [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) a [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-). Tyto metody určují, zda bude popisek dat v daném grafu zobrazen jako výběr nebo jako běžný popisek.

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

## **Nastavení výběru pro kruhový graf**
Aspose.Slides pro Java poskytuje podporu pro nastavení tvaru výběru popisků řady pro kruhový graf. Níže je uveden ukázkový příklad.

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

## **Často kladené otázky**

**Jsou výběry zachovány při převodu prezentace do PDF, HTML5, SVG nebo obrázků?**

Ano. Výběry jsou součástí vykreslování grafu, takže při exportu do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/), [HTML5](/slides/cs/java/export-to-html5/), [SVG](/slides/cs/java/render-a-slide-as-an-svg-image/) nebo [rastrových obrázků](/slides/cs/java/convert-powerpoint-to-png/) jsou zachovány spolu s formátováním snímku.

**Fungují v výběrech vlastní fonty a lze jejich vzhled zachovat při exportu?**

Ano. Aspose.Slides podporuje [vkládání fontů](/slides/cs/java/embedded-font/) do prezentace a řídí vložení fontů během exportu, například do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/), čímž zajišťuje, že výběry vypadají stejně na různých systémech.