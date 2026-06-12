---
title: Spravovat callouty v grafech prezentace pomocí JavaScriptu
linktitle: Výzva
type: docs
url: /cs/nodejs-java/callout/
keywords:
- callout grafu
- použití calloutu
- datový popisek
- formát popisku
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvořte a stylizujte callouty v Aspose.Slides pro Node.js prostřednictvím Java pomocí stručných ukázek kódu, kompatibilní s formáty PPT a PPTX pro automatizaci pracovních postupů prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s callouty pro popisky dat v grafech v Aspose.Slides. Ukazuje, jak použít metodu `setShowLabelAsDataCallout` k zobrazení popisků jako callouty, jak nakonfigurovat nastavení popisků souvisejících s callouty pro prstencový graf a uvádí, že callouty a jejich vzhled jsou zachovány při exportu prezentací do formátů PDF, HTML5, SVG a rastrových obrazových formátů.

## **Používání calloutů**

Byly přidány nové metody [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) a [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) do třídy [DataLabelFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabelformat) a [DataLabelFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabelformat). Tyto metody určují, zda bude popisek dat v daném grafu zobrazen jako data callout nebo jako popisek dat.

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

## **Nastavení calloutu pro prstencový graf**

Aspose.Slides pro Node.js prostřednictvím Java poskytuje podporu pro nastavení tvaru calloutu popisku dat řady pro prstencový graf. Níže je uveden ukázkový příklad.

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

## **Často kladené otázky**

**Jsou callouty zachovány při konverzi prezentace do PDF, HTML5, SVG nebo obrázků?**

Ano. Callouty jsou součástí vykreslování grafu, takže při exportu do [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/cs/nodejs-java/export-to-html5/), [SVG](/slides/cs/nodejs-java/render-a-slide-as-an-svg-image/) nebo [rastrových obrázků](/slides/cs/nodejs-java/convert-powerpoint-to-png/) jsou zachovány spolu s formátováním snímku.

**Fungují vlastní fonty v calloutech a lze jejich vzhled zachovat při exportu?**

Ano. Aspose.Slides podporuje [vkládání fontů](/slides/cs/nodejs-java/embedded-font/) do prezentace a řídí vkládání fontů během exportů, například do [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/), což zajišťuje, že callouty vypadají stejně na různých systémech.