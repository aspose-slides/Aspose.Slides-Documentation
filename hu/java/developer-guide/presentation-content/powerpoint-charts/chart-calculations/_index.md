---
title: Diagram számítások optimalizálása prezentációkhoz Java-ban
linktitle: Diagram számítások
type: docs
weight: 50
url: /hu/java/chart-calculations/
keywords:
- diagram számítások
- diagram elemek
- elem pozíciója
- valós pozíció
- gyermek elem
- szülő elem
- diagram értékek
- valós érték
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg a diagram számításokat, az adatfrissítéseket és a pontosság szabályozását az Aspose.Slides for Java-ban PPT és PPTX esetén, gyakorlati Java kódpéldákkal."
---
## **Áttekintés**

Az Aspose.Slides API-kat biztosít a diagramok számításával és elrendezési adatainak kezelésével prezentációkban. Ez a cikk bemutatja, hogyan lehet lekérni a diagramelemek tényleges értékeit, beleértve a `IActualLayout`-ot megvalósító elemek valós pozícióját és méretét, valamint a diagram tengelyek tényleges értékeit. Ismerteti továbbá, hogy ezek az értékek a diagramelrendezés érvényesítése után kerülnek feltöltésre.

Ezen felül a cikk bemutatja, hogyan lehet lekérni a szülő diagram elemek tényleges pozícióját, valamint hogyan lehet elrejteni a diagram komponenseit, mint például a címet, tengelyeket, jelmagyarázatot és rácsvonalakat. Ezek az példák segítenek a diagramelrendezési információk megvizsgálásában és a diagramelemek láthatóságának programozott vezérlésében PowerPoint prezentációkban.

## **Diagramelemek tényleges értékeinek kiszámítása**
Az Aspose.Slides for Java egyszerű API-t biztosít ezeknek a tulajdonságoknak a lekéréséhez. Az [IAxis](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAxis) interfész tulajdonságai információt nyújtanak a tengely diagramelem tényleges pozíciójáról ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Szükséges a [IChart.validateChartLayout()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChart#validateChartLayout--) metódust előzőleg meghívni, hogy a tulajdonságok tényleges értékekkel legyenek feltöltve.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szülő diagram elemek tényleges pozíciójának kiszámítása**
Az Aspose.Slides for Java egyszerű API-t biztosít ezeknek a tulajdonságoknak a lekéréséhez. Az [IActualLayout](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IActualLayout) interfész tulajdonságai információt nyújtanak a szülő diagram elem tényleges pozíciójáról ([IActualLayout.getActualX](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IActualLayout#getActualHeight--)). Szükséges a [IChart.validateChartLayout()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChart#validateChartLayout--) metódust előzőleg meghívni, hogy a tulajdonságok tényleges értékekkel legyenek feltöltve.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Diagramelemek elrejtése**
Ez a téma segít megérteni, hogyan lehet információkat elrejteni a diagramról. Az Aspose.Slides for Java használatával elrejtheti a **Címet, Függőleges tengelyt, Vízszintes tengelyt** és a **Rácsvonalakat** a diagramról. Az alábbi kódrészlet bemutatja, hogyan kell használni ezeket a tulajdonságokat.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Diagram cím elrejtése
    chart.setTitle(false);

    ///Érték tengely elrejtése
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Kategória tengely láthatósága
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Jelmagyarázat elrejtése
    chart.setLegend(false);

    //Fő rácsvonalak elrejtése
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Sorvonal színének beállítása
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Külső Excel munkafüzetek használhatók adatforrásként, és ez hogyan befolyásolja az újraszámítást?**

Igen. A diagram hivatkozhat egy külső munkafüzetre: amikor csatlakozik vagy frissíti a külső forrást, a képletek és értékek abból a munkafüzetből kerülnek be, és a diagram a nyitási/szerkesztési műveletek során tükrözi a frissítéseket. Az API lehetővé teszi, hogy [megadja a külső munkafüzet](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) útvonalát, és kezelje a kapcsolt adatokat.

**Számíthatok és megjeleníthetek trendvonalakat anélkül, hogy saját regressziót implementálnék?**

Igen. A [Trendvonalak](/slides/hu/java/trend-line/) (lineáris, exponenciális és egyebek) az Aspose.Slides által kerülnek hozzáadásra és frissítésre; paramétereiket a sorozat adataiból automatikusan újraszámítja a rendszer, így nem kell saját számításokat implementálni.

**Ha egy prezentáció több diagrammal rendelkezik külső hivatkozásokkal, irányíthatom, hogy melyik munkafüzetet használja az egyes diagram a számított értékekhez?**

Igen. Minden diagram saját [külső munkafüzetre](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) hivatkozhat, vagy létrehozhat/lecserélhet egy külső munkafüzetet diagramonként, függetlenül a többitől.