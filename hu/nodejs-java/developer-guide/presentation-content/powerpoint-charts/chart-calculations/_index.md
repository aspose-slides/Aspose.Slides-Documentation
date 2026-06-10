---
title: "Diagram számítások optimalizálása prezentációkhoz JavaScriptben"
linktitle: "Diagram számítások"
type: docs
weight: 50
url: /hu/nodejs-java/chart-calculations/
keywords:
- "diagram számítások"
- "diagram elemek"
- "elem pozíció"
- "valós pozíció"
- "gyermek elem"
- "szülő elem"
- "diagram értékek"
- "valós érték"
- "PowerPoint"
- "prezentáció"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Ismerje meg a diagram számításokat, az adatfrissítéseket és a pontosság szabályozását az Aspose.Slides for Node.js-ben PPT és PPTX esetén, gyakorlati JavaScript kódrészletekkel."
---
## **Áttekintés**

Az Aspose.Slides API-kat biztosít a diagramok számításainak és elrendezési adatainak kezeléséhez a bemutatókban. Ez a cikk bemutatja, hogyan lehet lekérni a diagramelemek tényleges értékeit, beleértve az elemek valós pozícióját és méretét, valamint a diagram tengelyek tényleges értékeit. Továbbá ismerteti, hogy ezek az értékek a diagramelrendezés ellenőrzése után kerülnek feltöltésre.

Ezen felül a cikk bemutatja, hogyan lehet lekérni a szülő diagramelemek tényleges pozícióját, valamint hogyan lehet elrejteni a diagram komponenseket, mint a cím, tengelyek, jelmagyarázat és rácsvonalak. Együtt ezek a példák segítenek a diagramelrendezési információk vizsgálatában és a diagramelemek láthatóságának programozott vezérlésében a PowerPoint‑bemutatókban.

## **Diagramelemek tényleges értékeinek kiszámítása**

Az Aspose.Slides for Node.js via Java egyszerű API-t biztosít ezeknek a tulajdonságoknak a lekéréséhez. Az [Axis](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Axis) osztály tulajdonságai információt nyújtanak a tengely diagramelem tényleges pozíciójáról ([Axis.getActualMaxValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Előzetesen meg kell hívni a [Chart.validateChartLayout()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Chart#validateChartLayout--) metódust, hogy a tulajdonságok tényleges értékekkel legyenek feltöltve.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **A szülő diagramelemek tényleges pozíciójának kiszámítása**

Az Aspose.Slides for Node.js via Java egyszerű API-t biztosít ezeknek a tulajdonságoknak a lekéréséhez. Az `ActualLayout` osztály tulajdonságai információt nyújtanak a szülő diagramelem tényleges pozíciójáról: `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. Előzetesen meg kell hívni a [Chart.validateChartLayout()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Chart#validateChartLayout--) metódust, hogy a tulajdonságok tényleges értékekkel legyenek feltöltve.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Információk elrejtése a diagramról**

Ez a téma segít megérteni, hogyan lehet elrejteni információkat a diagramról. Az Aspose.Slides for Node.js via Java segítségével elrejtheti a **Címet, Függőleges tengelyt, Vízszintes tengelyt** és a **Rácsvonalakat** a diagramról. Az alábbi kódrészlet bemutatja, hogyan használhatók ezek a tulajdonságok.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Diagram címének elrejtése
    chart.setTitle(false);
    // /Érték tengely elrejtése
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Kategória tengely láthatósága
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Jelmagyarázat elrejtése
    chart.setLegend(false);
    // Fő rácsvonalak elrejtése
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Sor vonalszínének beállítása
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Működnek-e külső Excel munkafüzetek adatforrásként, és ez hogyan befolyásolja az újraszámítást?**

Igen. A diagram hivatkozhat egy külső munkafüzetre: amikor csatlakozik vagy frissíti a külső forrást, a képletek és értékek ebből a munkafüzetből származnak, és a diagram tükrözi a frissítéseket a megnyitás/nagy szerkesztési műveletek során. Az API lehetővé teszi, hogy [megadja a külső munkafüzet](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) útvonalát, és kezelje a kapcsolt adatot.

**Kiszámíthatok és megjeleníthetek trendvonalakat anélkül, hogy saját regressziót implementálnék?**

Igen. A [Trendlines](/slides/hu/nodejs-java/trend-line/) (lineáris, exponenciális és egyéb) hozzáadásra és frissítésre kerülnek az Aspose.Slides által; paramétereiket a sorozat adataiból automatikusan újraszámítja a rendszer, így nem szükséges saját számításokat implementálni.

**Ha egy bemutató több diagramot tartalmaz külső hivatkozásokkal, szabályozhatom-e, hogy melyik munkafüzetet használja a diagram a számított értékekhez?**

Igen. Minden diagram saját [külső munkafüzetre](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) mutathat, vagy létrehozhat/cserélhet egy külső munkafüzetet diagramonként függetlenül a többitől.