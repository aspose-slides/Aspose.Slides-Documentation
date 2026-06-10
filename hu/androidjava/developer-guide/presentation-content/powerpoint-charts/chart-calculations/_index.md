---
title: Diagram számítások optimalizálása Android bemutatókhoz
linktitle: Diagram számítások
type: docs
weight: 50
url: /hu/androidjava/chart-calculations/
keywords:
- diagram számítások
- diagram elemek
- elem pozíció
- valódi pozíció
- gyermek elem
- szülő elem
- diagram értékek
- valódi érték
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Értse meg a diagram számításokat, az adatfrissítéseket és a pontosság szabályozását az Aspose.Slides for Androidban PPT és PPTX fájlokhoz, gyakorlati Java kódrészletekkel."
---
## **Áttekintés**

Az Aspose.Slides API-kat biztosít a diagramok számításainak és elrendezési adatainak kezelésére a bemutatókban. Ez a cikk bemutatja, hogyan lehet lekérdezni a diagramelemek tényleges értékeit, beleértve a `IActualLayout`-ot megvalósító elemek valós pozícióját és méretét, valamint a diagram tengelyek tényleges értékeit. Emellett elmagyarázza, hogy ezek az értékek a diagramelrendezés ellenőrzése után kerülnek kitöltésre.

Továbbá a cikk bemutatja, hogyan lehet lekérni a szülő diagramelemek tényleges pozícióját, valamint hogyan lehet elrejteni a diagram komponenseket, például a címet, tengelyeket, jelmagyarázatot és rácsvonalakat. Ezek a példák együtt segítenek a diagramelrendezési információk vizsgálatában és a diagramelemek láthatóságának programozott vezérlésében a PowerPoint‑bemutatókban.

## **A diagramelemek tényleges értékeinek kiszámítása**
Az Aspose.Slides for Android via Java egyszerű API-t biztosít ezeknek a tulajdonságoknak a lekéréséhez. A [IAxis](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAxis) interfész tulajdonságai információt nyújtanak a tengely diagramelem tényleges pozíciójáról ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). A tulajdonságok tényleges értékekkel való feltöltéséhez előzetesen meg kell hívni a [IChart.validateChartLayout()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChart#validateChartLayout--) metódust.

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

## **A szülő diagramelemek tényleges pozíciójának kiszámítása**
Az Aspose.Slides for Android via Java egyszerű API-t biztosít ezeknek a tulajdonságoknak a lekéréséhez. A [IActualLayout](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IActualLayout) interfész tulajdonságai információt nyújtanak a szülő diagramelem tényleges pozíciójáról ([IActualLayout.getActualX](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). A tulajdonságok tényleges értékekkel való feltöltéséhez előzetesen meg kell hívni a [IChart.validateChartLayout()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChart#validateChartLayout--) metódust.

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
Ez a téma segít megérteni, hogyan lehet elrejteni a diagram adatait. Az Aspose.Slides for Android via Java használatával elrejtheti a **címet, függőleges tengelyt, vízszintes tengelyt** és a **rácsvonalakat** a diagramról. Az alábbi kódpélda bemutatja, hogyan kell használni ezeket a tulajdonságokat.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //diagram címének elrejtése
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

    //Sorozat vonalszín beállítása
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Működnek külső Excel munkafüzetek adatforrásként, és ez hogyan befolyásolja az újraszámítást?**

Igen. A diagram hivatkozhat egy külső munkafüzettel: amikor csatlakozik vagy frissíti a külső forrást, a képletek és értékek a munkafüzetből kerülnek be, és a diagram a nyitási/szerkesztési műveletek során tükrözi a frissítéseket. Az API lehetővé teszi, hogy [megadja a külső munkafüzet](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) útvonalát és kezelje a kapcsolt adatokat.

**Számíthatok és megjeleníthetek trendvonalakat anélkül, hogy magam implementálnám a regressziót?**

Igen. A [Trendvonalak](/slides/hu/androidjava/trend-line/) (lineáris, exponenciális és egyéb) az Aspose.Slides által kerülnek hozzáadásra és frissítésre; paramétereik automatikusan újraszámítódnak a sorozat adataiból, így nem kell saját számításokat implementálnia.

**Ha egy bemutató több diagramot tartalmaz külső hivatkozásokkal, vezérelhetem, hogy melyik munkafüzetet használja egyes diagramok a számított értékekhez?**

Igen. Minden diagram saját [külső munkafüzetre](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) mutathat, vagy létrehozhat/lecserélhet egy külső munkafüzetet diagramonként a többitől függetlenül.