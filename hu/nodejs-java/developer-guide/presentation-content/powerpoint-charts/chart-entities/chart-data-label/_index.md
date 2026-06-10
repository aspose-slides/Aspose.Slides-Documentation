---
title: Kezelje a diagram adatcímkéket bemutatókban JavaScript használatával
linktitle: Adatcímke
type: docs
url: /hu/nodejs-java/chart-data-label/
keywords:
- diagram
- adatcímke
- adat pontosság
- százalék
- címke távolság
- címke helye
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg, hogyan adjon hozzá és formázzon diagram adatcímkéket PowerPoint bemutatókban JavaScript és Aspose.Slides for Node.js via Java segítségével, hogy vonzóbb diákat készítsen."
---
## **Bevezetés**

Az adatcímkék egy diagramon a diagram adat sorozatáról vagy egyedi adatpontokról adnak részleteket. Segítik az olvasókat gyorsan azonosítani az adat sorozatokat, és megkönnyítik a diagramok megértését.

## **Az adat pontosságának beállítása a diagram adatcímkéiben**

Ez a JavaScript kód megmutatja, hogyan állítható be az adat pontossága egy diagram adatcímkében:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Százalék megjelenítése címkeként**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy százalékos címkéket állíts be a megjelenített diagramokon. Ez a JavaScript kód bemutatja a műveletet:

```javascript
// Létrehoz egy példányt a Presentation osztályból
var pres = new aspose.slides.Presentation();
try {
    // Lekéri az első diát
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);
    var series;
    var total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (var k = 0; k < chart.getChartData().getCategories().size(); k++) {
        var cat = chart.getChartData().getCategories().get_Item(k);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData();
        }
    }
    var dataPontPercent = 0.0;
    for (var x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
        for (var j = 0; j < series.getDataPoints().size(); j++) {
            var lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (series.getDataPoints().get_Item(j).getValue().getData() / total_for_Cat[j]) * 100;
            var port = new aspose.slides.Portion();
            port.setText(java.callStaticMethodSync("java.lang.String", "format", "{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8.0);
            lbl.getTextFrameForOverriding().setText("");
            var para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    // Elmenti a diagramot tartalmazó bemutatót
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Százalékjel beállítása a diagram adatcímkéknél**

Ez a JavaScript kód megmutatja, hogyan állítható be a százalékjel egy diagram adatcímkéhez:

```javascript
// Létrehoz egy példányt a Presentation osztályból
var pres = new aspose.slides.Presentation();
try {
    // Lekéri egy dia hivatkozását az indexe alapján
    var slide = pres.getSlides().get_Item(0);
    // Létrehozza a PercentsStackedColumn diagramot egy dián
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    // Beállítja a NumberFormatLinkedToSource értékét hamisra
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    chart.getChartData().getSeries().clear();
    var defaultWorksheetIndex = 0;
    // Lekéri a diagram adat munkalapját
    var workbook = chart.getChartData().getChartDataWorkbook();
    // Új sorozatot ad hozzá
    var series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    // Beállítja a sorozat kitöltőszínét
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Beállítja a LabelFormat tulajdonságait
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Új sorozatot ad hozzá
    var series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.7));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.5));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.2));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    // Beállítja a kitöltés típusát és színét
    series2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    // Kiírja a bemutatót a lemezre
    pres.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Címketávolság beállítása a tengelytől**

Ez a JavaScript kód megmutatja, hogyan állítható be a címke távolsága egy kategória tengelytől, ha olyan diagrammal dolgozol, amely tengelyek alapján van ábrázolva:

```javascript
// Létrehoz egy példányt a Presentation osztályból
var pres = new aspose.slides.Presentation();
try {
    // Lekéri egy dia hivatkozását
    var sld = pres.getSlides().get_Item(0);
    // Létrehozza a diagramot a dián
    var ch = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    // Beállítja a címke távolságát egy tengelytől
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    // Kiírja a bemutatót a lemezre
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Címke helyének módosítása**

Ha olyan diagramot hozol létre, amely nem támaszkodik semmilyen tengelyre, például kördiagram, a diagram adatcímkéi túl közel kerülhetnek a széléhez. Ilyen esetben a címke helyét kell módosítani, hogy a vezető vonalak jól láthatók legyenek.

Ez a JavaScript kód megmutatja, hogyan állítható be a címke helye egy kördiagramon:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    var series = chart.getChartData().getSeries();
    var label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71);
    label.setY(0.04);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **GYIK**

**Hogyan akadályozhatom meg az adatcímkék átfedését sűrű diagramokon?**

Használj automatikus címkeelhelyezést, vezető vonalakat és kisebb betűméretet; szükség esetén rejts el néhány mezőt (például a kategóriát), vagy csak a kiemelt/kulcsfontosságú pontokhoz jeleníts meg címkéket.

**Hogyan tilthatom le a címkéket csak a nullás, negatív vagy üres értékeknél?**

Szűrd a adatpontokat a címkék engedélyezése előtt, és kapcsold ki a megjelenítést a 0, negatív vagy hiányzó értékeknél egy meghatározott szabály alapján.

**Hogyan biztosíthatom a következetes címkestílust PDF/képek exportálásakor?**

Állítsd be kifeexplicit módon a betűtípusokat (család, méret), és ellenőrizd, hogy a betűtípus elérhető-e a renderelő oldalon, hogy elkerüld a helyettesítést.