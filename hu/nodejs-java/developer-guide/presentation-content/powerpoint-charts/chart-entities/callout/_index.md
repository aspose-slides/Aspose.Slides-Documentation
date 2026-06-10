---
title: Hívások kezelése a bemutató diagramokban JavaScript használatával
linktitle: Hívás
type: docs
url: /hu/nodejs-java/callout/
keywords:
- diagram hívás
- hívás használata
- adatcímke
- címkeformátum
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Hívásokat hoz létre és formáz Aspose.Slides for Node.js via Java-ben, tömör kódpéldákkal, PPT és PPTX kompatibilitással, hogy automatizálja a bemutatók munkafolyamatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet használni a hívásokat a diagram adatcímkéihez az Aspose.Slides-ben. Megmutatja, hogyan kell használni a `setShowLabelAsDataCallout` metódust a címkék hívásként való megjelenítéséhez, hogyan konfigurálható a hívásokkal kapcsolatos címke beállítások egy gyűrű diagramnál, és megjegyzi, hogy a hívások és megjelenésük megmarad, amikor a bemutatókat PDF, HTML5, SVG és raszteres képformátumokra exportálják.

## **Hívások használata**

Új [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) és [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) metódusok kerültek hozzáadásra a [DataLabelFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabelformat) osztályhoz és [DataLabelFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabelformat) osztályhoz. Ezek a metódusok meghatározzák, hogy a megadott diagram adatcímkéje adat‑hívásként vagy egyszerű adatcímkeként jelenik‑e meg.

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

## **Hívás beállítása gyűrű diagramhoz**

Az Aspose.Slides for Node.js via Java támogatja a sorozat adatcímke hívás alakjának beállítását egy gyűrű diagramhoz. Az alábbi példakód látható.  

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

## **GYIK**

**Megmaradnak a hívások a bemutató PDF, HTML5, SVG vagy képek formátumba konvertálásakor?**

Igen. A hívások a diagram megjelenítésének részét képezik, ezért amikor [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/hu/nodejs-java/export-to-html5/), [SVG](/slides/hu/nodejs-java/render-a-slide-as-an-svg-image/) vagy [raszteres képek](/slides/hu/nodejs-java/convert-powerpoint-to-png/) formátumba exportálja a bemutatót, a hívások a dia formázásával együtt megmaradnak.

**Működnek‑e az egyéni betűtípusok a hívásokban, és megőrizhető‑e megjelenésük az exportálás során?**

Igen. Az Aspose.Slides támogatja a [betűtípusok beágyazását](/slides/hu/nodejs-java/embedded-font/) a bemutatóba, és szabályozza a betűtípus beágyazását az olyan exportoknál, mint a [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/), biztosítva, hogy a hívások ugyanúgy nézzenek ki különböző rendszereken.