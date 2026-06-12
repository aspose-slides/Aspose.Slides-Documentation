---
title: Přidání trendových čar do grafů v prezentacích v JavaScriptu
linktitle: Trendová čára
type: docs
url: /cs/nodejs-java/trend-line/
keywords:
- graf
- trendová čára
- exponenciální trendová čára
- lineární trendová čára
- logaritmická trendová čára
- čára trendu s klouzavým průměrem
- polynomiální trendová čára
- mocninná trendová čára
- vlastní trendová čára
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Rychle přidejte a přizpůsobte trendové čáry v grafech PowerPointu pomocí JavaScriptu a Aspose.Slides pro Node.js přes Java — praktický průvodce, jak zaujmout své publikum."
---
## **Přehled**

Tento článek vysvětluje, jak přidat čáry trendu do diagramů v prezentacích pomocí Aspose.Slides. Ukazuje, jak vytvořit diagram, přidat čáry trendu do řad diagramu a pracovat s několika typy čar trendu, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomiální a mocninné.

Také popisuje, jak přidat vlastní čáru do diagramu vložením tvaru čáry, a obsahuje krátkou FAQ o hodnotách projekce čáry trendu dopředu a dozadu a o tom, zda jsou čáry trendu zachovány při exportu do PDF nebo SVG a při vykreslování diagramů jako obrázků.

## **Přidání čáry trendu**

Aspose.Slides pro Node.js přes Java poskytuje jednoduché API pro správu různých čar trendu v diagramech:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte referenci snímku podle jeho indexu.
3. Přidejte diagram s výchozími daty a libovolným požadovaným typem (v tomto příkladu se používá ChartType.ClusteredColumn).
4. Přidání exponenciální čáry trendu pro řadu diagramu 1.
5. Přidání lineární čáry trendu pro řadu diagramu 1.
6. Přidání logaritmické čáry trendu pro řadu diagramu 2.
7. Přidání čáry trendu s klouzavým průměrem pro řadu diagramu 2.
8. Přidání polynomiální čáry trendu pro řadu diagramu 3.
9. Přidání mocninné čáry trendu pro řadu diagramu 3.
10. Zapište upravenou prezentaci do souboru PPTX.

Následující kód se používá k vytvoření diagramu s čarami trendu.

```javascript
// Vytvořte instanci třídy Presentation class
var pres = new aspose.slides.Presentation();
try {
    // Vytvoření sloupcového seskupeného grafu
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Přidání exponenciální čáry trendu pro řadu grafu 1
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Přidání lineární čáry trendu pro řadu grafu 1
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Přidání logaritmické čáry trendu pro řadu grafu 2
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Přidání čáry trendu s klouzavým průměrem pro řadu grafu 2
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Přidání polynomiální čáry trendu pro řadu grafu 3
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Přidání mocninné čáry trendu pro řadu grafu 3
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Uložení prezentace
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Přidání vlastní čáry**

Aspose.Slides pro Node.js přes Java poskytuje jednoduché API pro přidání vlastních čar do diagramu. Chcete-li přidat jednoduchou přímou čáru do vybraného snímku prezentace, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
- Získejte referenci snímku pomocí jeho Indexu.
- Vytvořte nový diagram pomocí metody AddChart, která je součástí objektu Shapes.
- Přidejte AutoShape typu Čára pomocí metody AddAutoShape, která je součástí objektu Shapes.
- Nastavte barvu čar tvaru.
- Zapište upravenou prezentaci jako soubor PPTX

Následující kód se používá k vytvoření diagramu s vlastními čarami.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Co znamenají 'forward' a 'backward' u čáry trendu?**

Jedná se o délky čáry trendu projektované dopředu/dozadu: u rozptýlených (XY) diagramů v jednotkách osy; u jiných diagramů v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Bude čára trendu zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace do [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/cs/nodejs-java/render-a-slide-as-an-svg-image/) a vykresluje diagramy jako obrázky; čáry trendu jako součást diagramu jsou během těchto operací zachovány. K dispozici je také metoda pro [export obrázku diagramu](/slides/cs/nodejs-java/create-shape-thumbnails/).