---
title: Přidání trendových linek do grafů v prezentaci v Javě
linktitle: Trendová linka
type: docs
url: /cs/java/trend-line/
keywords:
- graf
- trendová linka
- exponenciální trendová linka
- lineární trendová linka
- logaritmická trendová linka
- trendová linka klouzavý průměr
- polynomická trendová linka
- mocninná trendová linka
- vlastní trendová linka
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Rychle přidejte a upravte trendové linky v grafech PowerPointu pomocí Aspose.Slides for Java — praktický průvodce, jak zaujmout své publikum."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat trendové linky do grafů v prezentaci. Ukazuje, jak vytvořit graf, přidat trendové linky k sériím grafu a pracovat s několika typy trendových linek, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomické a mocninné.

Také popisuje, jak přidat vlastní čáru do grafu vložením tvaru čáry, a obsahuje stručné FAQ o hodnotách projekce trendové linky dopředu a dozadu a o tom, zda jsou trendové linky zachovány při exportu do PDF nebo SVG a při vykreslování grafů jako obrázků.

## **Přidání trendové linky**
Aspose.Slides for Java poskytuje jednoduché API pro správu různých trendových linek grafu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Získejte referenci snímku podle jeho indexu.
1. Přidejte graf s výchozími daty a libovolným požadovaným typem (v tomto příkladu se používá ChartType.ClusteredColumn).
1. Přidání exponenciální trendové linky pro sérii grafu 1.
1. Přidání lineární trendové linky pro sérii grafu 1.
1. Přidání logaritmické trendové linky pro sérii grafu 2.
1. Přidání trendové linky klouzavý průměr pro sérii grafu 2.
1. Přidání polynomické trendové linky pro sérii grafu 3.
1. Přidání mocninné trendové linky pro sérii grafu 3.
1. Zapište upravenou prezentaci do souboru PPTX.

Následující kód se používá k vytvoření grafu s trendovými linkami.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Vytvoření seskupeného sloupcového grafu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Přidání exponenciální trendové linky pro sérii grafu 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Přidání lineární trendové linky pro sérii grafu 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Přidání logaritmické trendové linky pro sérii grafu 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Přidání trendové linky klouzavý průměr pro sérii grafu 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Přidání polynomické trendové linky pro sérii grafu 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Přidání mocninné trendové linky pro sérii grafu 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Uložení prezentace
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidání vlastní čáry**
Aspose.Slides for Java poskytuje jednoduché API pro přidání vlastních čar do grafu. Pro přidání jednoduché rovné čáry do vybraného snímku prezentace postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
- Získejte referenci snímku pomocí jeho Indexu.
- Vytvořte nový graf pomocí metody AddChart, která je součástí objektu Shapes.
- Přidejte AutoShape typu Line pomocí metody AddAutoShape, která je součástí objektu Shapes.
- Nastavte barvu čar tvaru.
- Zapište upravenou prezentaci jako soubor PPTX

Následující kód se používá k vytvoření grafu s vlastními čarami.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Co znamenají „dopředu“ a „dozadu“ u trendové linky?**

Jedná se o délky trendové linky projekované dopředu/dozadu: u rozptýlených (XY) grafů — v jednotkách osy; u ne‑rozptýlených grafů — v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zůstane trendová linka zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/)/[SVG](/slides/cs/java/render-a-slide-as-an-svg-image/) a vykresluje grafy do obrázků; trendové linky jako součást grafu jsou při těchto operacích zachovány. K dispozici je také metoda pro [export obrázku grafu](/slides/cs/java/create-shape-thumbnails/).