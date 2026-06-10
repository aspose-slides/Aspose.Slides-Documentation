---
title: Androidon a prezentációs diagramok felhívásainak kezelése
linktitle: Felhívás
type: docs
url: /hu/androidjava/callout/
keywords:
- diagram felhívás
- felhívás használata
- adatcímke
- címkeformátum
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Hozzon létre és formázzon felhívásokat az Aspose.Slides for Android-ban rövid Java kódpéldákkal, PPT és PPTX kompatibilitással a prezentációs munkafolyamatok automatizálásához."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan kell használni a felhívásokat a diagram adatcímkéknél az Aspose.Slides-ben. Bemutatja, hogyan kell használni a `setShowLabelAsDataCallout` metódust a címkék felhívásként való megjelenítéséhez, hogyan kell konfigurálni a felhívással kapcsolatos címke‑beállításokat egy gyűrű diagramhoz, és megjegyzi, hogy a felhívások és megjelenésük megmaradnak, amikor a prezentációkat PDF, HTML5, SVG és raszteres képformátumokra exportálják.

## **Felhívások használata**
Új [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) és [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) metódusok lettek hozzáadva a [DataLabelFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/datalabelformat) osztályhoz és a [IDataLabelFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatalabelformat) interfészhez. Ezek a metódusok meghatározzák, hogy a megadott diagram adatcímkéje adatfelhívásként vagy adatcímkeként jelenik meg.

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

## **Felhívás beállítása gyűrű diagramhoz**
Az Aspose.Slides for Android Java segítségével támogatja a sor adatcímke felhívás alakjának beállítását egy Gyűrű diagramhoz. Az alábbi mintapélda van megadva.

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

**Megmaradnak a felhívások a prezentáció PDF, HTML5, SVG vagy képek formátumba konvertálásakor?**

Igen. A felhívások a diagram renderelésének részét képezik, ezért amikor [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/), [HTML5](/slides/hu/androidjava/export-to-html5/), [SVG](/slides/hu/androidjava/render-a-slide-as-an-svg-image/) vagy [raszteres képek](/slides/hu/androidjava/convert-powerpoint-to-png/) formátumba exportál, azok a dia formázásával együtt megmaradnak.

**Művészeti betűtípusok működnek a felhívásokban, és megőrizhető-e megjelenésük exportáláskor?**

Igen. Az Aspose.Slides támogatja a [betűtípusok beágyazását](/slides/hu/androidjava/embedded-font/) a prezentációba, és szabályozza a betűtípus beágyazását az exportálások során, például [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/), biztosítva, hogy a felhívások különböző rendszereken is azonosak legyenek.