---
title: Diagram adatcímkék kezelése prezentációkban Java segítségével
linktitle: Adatcímke
type: docs
url: /hu/java/chart-data-label/
keywords:
- diagram
- adatcímke
- adatpontoság
- százalék
- címke távolság
- címke helye
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és formázhat diagram adatcímkéket PowerPoint prezentációkban az Aspose.Slides for Java használatával, hogy vonzóbb diák legyenek."
---
## **Bevezetés**

A diagram adatcímkéi a diagram adatcsoportról vagy egyes adatpontokról nyújtanak részleteket. Segítik az olvasókat az adatcsoportok gyors azonosításában, és egyszerűbbé teszik a diagramok megértését.

## **Adatpontoság beállítása a diagram adatcímkéiben**

Ez a Java kód bemutatja, hogyan állítható be az adatpontoság egy diagram adatcímkében:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");

    pres.save("output.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Százalék megjelenítése címkeként**
Az Aspose.Slides for Java lehetővé teszi, hogy a megjelenített diagramokon százalékcímkéket állítsunk be. Ez a Java kód demonstrálja a műveletet:

```java
// Létrehozza a Presentation osztály egy példányát
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);
    IChartSeries series;
    double[] total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        IChartCategory cat = chart.getChartData().getCategories().get_Item(k);
    
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + (double) (chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData());
        }
    }
    
    double dataPontPercent = 0f;
    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
    
        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (double) ((series.getDataPoints().get_Item(j).getValue().getData())) / (double) (total_for_Cat[j]) * 100;
    
            IPortion port = new Portion();
            port.setText(String.format("{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8f);
            lbl.getTextFrameForOverriding().setText("");
            IParagraph para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
    
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    
    // Elmenti a diagramot tartalmazó prezentációt
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Százalékjel beállítása a diagram adatcímkékkel**
Ez a Java kód megmutatja, hogyan állítható be a százalékjel egy diagram adatcímkében:

```java
// Létrehozza a Presentation osztály egy példányát
Presentation pres = new Presentation();
try {
    // Lekéri egy dia referenciajét az indexe alapján
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Létrehozza a PercentsStackedColumn diagramot egy dián
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    
    // Beállítja a NumberFormatLinkedToSource értékét false-ra
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    
    chart.getChartData().getSeries().clear();
    int defaultWorksheetIndex = 0;
    
    // Lekéri a diagram adat munkalapját
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    
    // Új sorozatot ad hozzá
    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.80));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    
    // Beállítja a sorozat kitöltőszínét
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Beállítja a LabelFormat tulajdonságait
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Új sorozatot ad hozzá
    IChartSeries series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.70));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.50));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.20));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    
    // Beállítja a kitöltés típusát és színét
    series2.getFormat().getFill().setFillType(FillType.Solid);
    series2.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    
    // A prezentációt lemezre menti
    pres.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Címke távolságának beállítása egy tengelytől**
Ez a Java kód bemutatja, hogyan állítható be a címke távolsága egy kategóriatengelytől, amikor tengelyekkel ábrázolt diagramot használunk:

```java
// Létrehozza a Presentation osztály egy példányát
Presentation pres = new Presentation();
try {
    // Lekéri egy dia referenciajét
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Létrehozza a diagramot a dián
    IChart ch = sld.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    
    // Beállítja a címke távolságát egy tengelytől
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    
    // A prezentációt lemezre menti
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Címke helyének beállítása**

Amikor olyan diagramot hozunk létre, amely nem támaszkodik semmilyen tengelyre, például egy kördiagram, a diagram adatcímkéi túl közel kerülhetnek a széléhez. Ilyen esetben a címke helyét kell módosítani, hogy a vonallal összekötő vonalak egyértelműen megjelenjenek.

Ez a Java kód megmutatja, hogyan állítható be a címke helye egy kördiagramon:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);

    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **GYIK**

**Hogyan akadályozhatom meg, hogy az adatcímkék átfedjék egymást a sűrű diagramokon?**

Használjon automatikus címkeelhelyezést, vonallal összekötő vonalakat és csökkentett betűméretet; szükség esetén rejtsen el bizonyos mezőket (például a kategóriát), vagy csak a szélső/kulcsfontosságú pontoknál jelenítsen meg címkéket.

**Hogyan tilthatom le a címkéket csak a nulla, negatív vagy üres értékeknél?**

Szűrje meg az adatpontokat a címkék engedélyezése előtt, és kapcsolja ki a megjelenítést 0, negatív vagy hiányzó értékek esetén egy definiált szabály szerint.

**Hogyan biztosíthatom a címkék egységes stílusát PDF/képek exportálásakor?**

Állítson be kifejezetten betűkészleteket (család, méret), és ellenőrizze, hogy a betűkészlet elérhető legyen a renderelő oldalon a visszalépés elkerülése érdekében.