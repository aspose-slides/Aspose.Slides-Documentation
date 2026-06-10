---
title: "Felhívások kezelése a prezentációs diagramokban Java használatával"
linktitle: "Felhívás"
type: docs
url: /hu/java/callout/
keywords:
  - "diagram felhívás"
  - "felhívás használata"
  - "adatcímke"
  - "címke formátum"
  - "PowerPoint"
  - "prezentáció"
  - "Java"
  - "Aspose.Slides"
description: "Készítsen és formázzon felhívásokat az Aspose.Slides for Java-ban rövid kódpéldákkal, PPT és PPTX kompatibilitással, a prezentációs munkafolyamatok automatizálásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet használni a felhívásokat a diagram adatcímkéinél az Aspose.Slides-ban. Megmutatja, hogyan kell használni a `setShowLabelAsDataCallout` metódust a címkék felhívásként történő megjelenítéséhez, hogyan kell beállítani a felhívással kapcsolatos címke beállításokat egy gyűrűdiagramhoz, és megjegyzi, hogy a felhívások és megjelenésük megmarad, amikor a prezentációkat PDF, HTML5, SVG és raszteres képformátumokba exportálják.

## **Felhívások használata**

Új módszerek, a [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) és a [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-), kerültek hozzáadásra a [DataLabelFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/datalabelformat) osztályhoz és az [IDataLabelFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idatalabelformat) interfészhez. Ezek a módszerek meghatározzák, hogy a megadott diagram adatcímkéje felhívásként vagy adatcímkeként jelenjen meg.

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

## **Felhívás beállítása egy gyűrűdiagramhoz**

Az Aspose.Slides for Java támogatja a sor adatcímke felhívás alakjának beállítását egy gyűrűdiagramhoz. Az alábbi példa meg van adva.

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

## **GYIK**

**Megmaradnak a felhívások, amikor a prezentációt PDF, HTML5, SVG vagy képformátumba konvertálják?**

Igen. A felhívások a diagram megjelenítésének részei, ezért amikor a [PDF](/slides/hu/java/convert-powerpoint-to-pdf/), [HTML5](/slides/hu/java/export-to-html5/), [SVG](/slides/hu/java/render-a-slide-as-an-svg-image/) vagy a [raszteres képek](/slides/hu/java/convert-powerpoint-to-png/) formátumba exportálja, azok megmaradnak a dia formázásával együtt.

**Működnek a saját betűtípusok a felhívásokban, és megőrizhető-e a megjelenésük exportáláskor?**

Igen. Az Aspose.Slides támogatja a [betűtípusok beágyazását](/slides/hu/java/embedded-font/) a prezentációba, és szabályozza a betűtípus beágyazását az exportálások során, például a [PDF](/slides/hu/java/convert-powerpoint-to-pdf/)-nél, ezáltal biztosítva, hogy a felhívások minden rendszerben ugyanúgy néznek ki.