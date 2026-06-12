---
title: Přidání čar trendu do diagramů v prezentacích na Androidu
linktitle: Trendová čára
type: docs
url: /cs/androidjava/trend-line/
keywords:
- diagram
- čára trendu
- exponenciální čára trendu
- lineární čára trendu
- logaritmická čára trendu
- čára trendu s klouzavým průměrem
- polynomiální čára trendu
- čára trendu mocninná
- vlastní čára trendu
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Rychle přidejte a přizpůsobte čáry trendu v diagramech PowerPoint pomocí Aspose.Slides pro Android prostřednictvím Javy — praktický průvodce, jak zaujmout vaše publikum."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat do diagramů v prezentacích čáry trendu. Ukazuje, jak vytvořit diagram, přidat čáry trendu do sérií diagramu a pracovat s několika typy čar trendu, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomiální a mocninné.

Také popisuje, jak do diagramu přidat vlastní čáru vložením tvaru čáry, a obsahuje krátké FAQ o hodnotách projekce čáry trendu dopředu a dozadu a o tom, zda jsou čáry trendu zachovány při exportu do PDF nebo SVG a při vykreslování diagramů jako obrázky.

## **Přidání čáry trendu**
Aspose.Slides pro Android prostřednictvím Java poskytuje jednoduché API pro správu různých čar trendu v diagramech:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte diagram s výchozími daty a libovolným požadovaným typem (v tomto příkladu se používá ChartType.ClusteredColumn).
4. Přidání exponenciální čáry trendu pro sérii 1 diagramu.
5. Přidání lineární čáry trendu pro sérii 1 diagramu.
6. Přidání logaritmické čáry trendu pro sérii 2 diagramu.
7. Přidání čáry trendu klouzavého průměru pro sérii 2 diagramu.
8. Přidání polynomiální čáry trendu pro sérii 3 diagramu.
9. Přidání mocninné čáry trendu pro sérii 3 diagramu.
10. Zapište upravenou prezentaci do souboru PPTX.

Následující kód se používá k vytvoření diagramu s čarami trendu.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Vytvoření seskupeného sloupcového diagramu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Přidání exponenciální čáry trendu pro sérii 1 diagramu
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Přidání lineární čáry trendu pro sérii 1 diagramu
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Přidání logaritmické čáry trendu pro sérii 2 diagramu
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Přidání čáry trendu s klouzavým průměrem pro sérii 2 diagramu
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Přidání polynomiální čáry trendu pro sérii 3 diagramu
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Přidání mocninné čáry trendu pro sérii 3 diagramu
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Ukládání prezentace
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidání vlastní čáry**
Aspose.Slides pro Android prostřednictvím Java poskytuje jednoduché API pro přidání vlastních čar do diagramu. Chcete-li přidat jednoduchou rovnou čáru do vybraného snímku prezentace, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Vytvořte nový diagram pomocí metody AddChart, která je poskytována objektem Shapes.
- Přidejte AutoShape typu Line pomocí metody AddAutoShape, která je poskytována objektem Shapes.
- Nastavte barvu čar tvaru.
- Zapište upravenou prezentaci jako soubor PPTX

Následující kód se používá k vytvoření diagramu s vlastními čarami.

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

**Co znamenají 'forward' a 'backward' u čáry trendu?**

Jedná se o délky čáry trendu projekované dopředu/dozadu: u rozptylových (XY) diagramů – v jednotkách osy; u nediskrétních diagramů – v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Bude čára trendu zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace do [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/cs/androidjava/render-a-slide-as-an-svg-image/) a vykresluje diagramy do obrázků; čáry trendu jako součást diagramu jsou při těchto operacích zachovány. K dispozici je také metoda pro [export obrázku diagramu](/slides/cs/androidjava/create-shape-thumbnails/) samotného.