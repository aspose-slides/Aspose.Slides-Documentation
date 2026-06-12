---
title: Vytvořit nebo aktualizovat grafy v PowerPoint prezentaci na Androidu
linktitle: Vytvořit nebo aktualizovat grafy
type: docs
weight: 10
url: /cs/androidjava/create-chart/
keywords:
- přidat graf
- vytvořit graf
- upravit graf
- změnit graf
- aktualizovat graf
- rozptýlený graf
- koláčový graf
- spojnicový graf
- graf stromové mapy
- akciový graf
- krabicový a fousový graf
- trychový graf
- sluneční paprskový graf
- histogramový graf
- radiový graf
- graf s více kategoriemi
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte grafy v PowerPoint prezentacích pomocí Aspose.Slides pro Android. Přidávejte, formátujte a upravujte grafy s praktickými ukázkami kódu v jazyce Java."
---
## **Přehled**

Tento článek poskytuje komplexní průvodce, jak pomocí Aspose.Slides vytvářet a přizpůsobovat grafy. Naučíte se, jak programově přidat graf do snímku, naplnit jej daty a použít různé možnosti formátování tak, aby odpovídaly vašim specifickým požadavkům na design. V celém článku podrobné ukázky kódu ilustrují každý krok, od inicializace prezentace a objektu grafu po konfiguraci sérií, os a legend. Dodržením tohoto průvodce získáte solidní pochopení toho, jak integrovat dynamické generování grafů do vašich aplikací a zjednodušit tvorbu prezentací řízených daty.

## **Vytvořit graf**
Grafy pomáhají lidem rychle vizualizovat data a získávat postřehy, které nemusí být okamžitě zřejmé z tabulky nebo kalkulační tabulky. 

**Proč vytvářet grafy?**

Pomocí grafů můžete

* agregovat, zhušťovat nebo sumarizovat velké množství dat na jednom snímku v prezentaci
* odhalovat vzorce a trendy v datech
* odhadovat směr a dynamiku dat v čase nebo vzhledem k určité jednotce měření
* odhalovat odlehlé hodnoty, odchylky, chyby, nesmyslná data atd.
* komunikovat nebo prezentovat složitá data

V PowerPointu můžete grafy vytvářet pomocí funkce Vložit, která poskytuje šablony pro návrh mnoha typů grafů. Pomocí Aspose.Slides můžete vytvářet běžné grafy (založené na populárních typech) i vlastní grafy. 

{{% alert color="primary" %}} 

Aby bylo možné vytvářet grafy, Aspose.Slides poskytuje třídu [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType). Pole v této třídě odpovídají různým typům grafů.

{{% /alert %}} 

### **Vytvořit běžné grafy**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint graf v Javě</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Kroky:</em> Vytvořit graf v prezentaci v Javě</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s grafem v Javě</strong></a>

_Code Steps:_

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s některými daty a uveďte požadovaný typ grafu. 
4. Přidejte název grafu. 
5. Přístup k pracovním listům dat grafu. 
6. Vymažte všechny výchozí řady a kategorie. 
7. Přidejte nové řady a kategorie. 
8. Přidejte nová data pro řady grafu. 
9. Přidejte barvu výplně pro řady grafu. 
10. Přidejte popisky pro řady grafu. 
11. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit běžný graf:

```java
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistoupí k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Přidá graf s výchozími daty
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Nastaví název grafu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // Nastaví první řadu, aby zobrazovala hodnoty
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Nastaví index pro datový list grafu
    int defaultWorksheetIndex = 0;
    
    // Získá pracovní list dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Odstraní výchozí generované řady a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Přidá nové řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Přidá nové kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Získá první řadu grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Nyní naplní data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Nastaví výplňovou barvu pro řadu
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Získá druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Naplní data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Nastaví výplňovou barvu pro řadu
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // Vytvoří vlastní popisky pro každou kategorii nové řady
    // Nastaví první popisek tak, aby zobrazoval název kategorie
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Zobrazí hodnotu pro třetí popisek
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Uloží prezentaci s grafem
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit rozptýlené grafy**
Rozptýlené grafy (také známé jako rozptylové diagramy nebo grafy x‑y) se často používají k ověření vzorců nebo k demonstraci korelací mezi dvěma proměnnými. 

Můžete chtít použít rozptýlený graf, když 

* máte párová číselná data
* máte 2 proměnné, které spolu dobře souvisejí
* chcete zjistit, zda jsou 2 proměnné propojené
* máte nezávislou proměnnou s více hodnotami pro závislou proměnnou

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Kroky:</em> Vytvořit rozptýlený graf v Javě</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint rozptýlený graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s rozptýleným grafem v Javě</strong></a>

1. Postupujte podle kroků uvedených výše v [Vytvoření běžných grafů](#creating-normal-charts)
2. Pro třetí krok, Přidejte graf s některými daty a uveďte typ grafu jako jeden z následujících
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Představuje rozptýlený graf s značkami._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Představuje rozptýlený graf spojovaný křivkami se značkami._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Představuje rozptýlený graf spojovaný křivkami bez značek._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Představuje rozptýlený graf spojovaný úsečkami se značkami._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Představuje rozptýlený graf spojovaný úsečkami bez značek._

Tento Java kód ukazuje, jak vytvořit rozptýlené grafy s různými sériemi značek: 

```java
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistoupí k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);

    // Vytvoří výchozí graf
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Získá index výchozího pracovního listu dat grafu
    int defaultWorksheetIndex = 0;
    
    // Získá pracovní list dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Odstraní ukázkovou řadu
    chart.getChartData().getSeries().clear();
    
    // Přidá nové řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Získá první řadu grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Přidá nový bod (1:3) do řady
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Přidá nový bod (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Změní typ řady
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Změní značku řady grafu
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Získá druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Přidá nový bod (5:2) tam
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Přidá nový bod (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Přidá nový bod (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Přidá nový bod (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Změní značku řady grafu
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit koláčové grafy**

Koláčové grafy se nejlépe používají k zobrazení vztahu část‑celkem v datech, zejména když data obsahují kategoriální štítky s číselnými hodnotami. Pokud však vaše data obsahují mnoho částí nebo štítků, možná budete raději použít sloupcový graf.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Kroky:</em> Vytvořit koláčový graf v Javě</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint koláčový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s koláčovým grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).Pie).
4. Přístup k datům grafu pomocí [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data do řad grafu.
8. Přidejte nové body do grafu a přizpůsobte barvy sektorů koláčového grafu.
9. Nastavte popisky pro řady.
10. Nastavte čáry ukazatele pro popisky řad.
11. Nastavte úhel otočení koláčového grafu.
12. Uložte upravenou prezentaci do souboru PPTX

Tento Java kód ukazuje, jak vytvořit koláčový graf:

```java
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistoupí k prvnímu snímku
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Přidá graf s výchozími daty
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Nastaví název grafu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Nastaví první řadu, aby zobrazovala hodnoty
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Nastaví index pro datový list grafu
    int defaultWorksheetIndex = 0;
    
    // Získá pracovní list dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Odstraní výchozí generované řady a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Přidá nové kategorie
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Přidá nové řady
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Naplní data řady
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Nefunguje v nové verzi
    // Přidání nových bodů a nastavení barvy sektoru
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Nastaví okraj sektoru
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Nastaví okraj sektoru
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Nastaví okraj sektoru
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Vytvoří vlastní popisky pro každou kategorii nové řady
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Zobrazí vodící čáry pro graf
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Nastaví úhel otočení pro sektory koláčového grafu
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Uloží prezentaci s grafem
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit spojnicové grafy**

Spojnicové grafy (také známé jako spojnicové diagramy) se nejlépe hodí v situacích, kdy chcete zobrazit změny hodnot v čase. Pomocí spojnicového grafu můžete porovnávat velké objemy dat najednou, sledovat změny a trendy v čase, zvýrazňovat odchylky v sériích dat atd.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě `ChartType.Line`).
1. Přístup k datům grafu pomocí IChartDataWorkbook.
1. Vymažte výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data do řad grafu.
1. Uložte upravenou prezentaci do souboru PPTX

Tento Java kód ukazuje, jak vytvořit spojnicový graf:

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ve výchozím nastavení jsou body na spojnicovém grafu spojeny rovnými souvislými čarami. Pokud chcete, aby byly body spojeny čárkovanou čarou, můžete specifikovat požadovaný typ čáry takto:

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **Vytvořit grafy stromové mapy**

Grafy stromové mapy jsou nejvhodnější pro prodejní data, kdy chcete zobrazit relativní velikost kategorií a zároveň rychle upozornit na položky, které významně přispívají do každé kategorie. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Kroky:</em> Vytvořit graf stromové mapy v Javě</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint graf stromové mapy v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s grafem stromové mapy v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).TreeMap).
4. Přístup k datům grafu pomocí [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data do řad grafu.
8. Uložte upravenou prezentaci do souboru PPTX

Tento Java kód ukazuje, jak vytvořit graf stromové mapy:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //větev 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //větev 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit akciové grafy**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Kroky:</em> Vytvořit akciový graf v Javě</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint akciový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s akciovým grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).OpenHighLowClose).
4. Přístup k datům grafu pomocí [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data do řad grafu.
8. Specifikujte formát HiLowLines.
9. Uložte upravenou prezentaci do souboru PPTX

Ukázkový Java kód pro vytvoření akciového grafu:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));

    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));

    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));

    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit krabicové a fousové grafy**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Kroky:</em> Vytvořit krabicový a fousový graf v Javě</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint krabicový a fousový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s krabicovým a fousovým grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).BoxAndWhisker).
4. Přístup k datům grafu pomocí [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data do řad grafu.
8. Uložte upravenou prezentaci do souboru PPTX

Tento Java kód ukazuje, jak vytvořit krabicový a fousový graf:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit trychové grafy**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Kroky:</em> Vytvořit trychový graf v Javě</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint trychový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s trychovým grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).Funnel).
4. Uložte upravenou prezentaci do souboru PPTX

Java kód ukazuje, jak vytvořit trychový graf:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit sluneční paprskové grafy**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Kroky:</em> Vytvořit sluneční paprskový graf v Javě</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint sluneční paprskový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s slunečním paprskovým grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).sunburst).
4. Uložte upravenou prezentaci do souboru PPTX

Tento Java kód ukazuje, jak vytvořit sluneční paprskový graf:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //větev 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //větev 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit histogramové grafy**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Kroky:</em> Vytvořit histogramový graf v Javě</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint histogramový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s histogramovým grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).Histogram).
4. Přístup k datům grafu pomocí [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Uložte upravenou prezentaci do souboru PPTX

Tento Java kód ukazuje, jak vytvořit histogramový graf:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit radiové grafy**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Kroky:</em> Vytvořit radiový graf v Javě</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint radiový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s radiovým grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu. 
3. Přidejte graf s některými daty a uveďte požadovaný typ grafu (`ChartType.Radar` v tomto případě).
4. Uložte upravenou prezentaci do souboru PPTX

Tento Java kód ukazuje, jak vytvořit radiový graf:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit grafy s více kategoriemi**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Kroky:</em> Vytvořit graf s více kategoriemi v Javě</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint graf s více kategoriemi v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s grafem s více kategoriemi v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu. 
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).ClusteredColumn).
4. Přístup k datům grafu pomocí [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data do řad grafu.
8. Uložte upravenou prezentaci do souboru PPTX.

Tento Java kód ukazuje, jak vytvořit graf s více kategoriemi:

```java
Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));

    // Přidání řady
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Uložit prezentaci s grafem
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit mapové grafy**

Mapový graf je vizualizace oblasti obsahující data. Mapové grafy jsou nejvhodnější pro porovnávání dat nebo hodnot napříč geografickými regiony.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Kroky:</em> Vytvořit mapový graf v Javě</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint mapový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s mapovým grafem v Javě</strong></a>

Tento Java kód ukazuje, jak vytvořit mapový graf:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit kombinované grafy**

Kombinovaný graf (nebo combo graf) kombinuje dva nebo více typů grafů v jednom diagramu. Tento graf vám umožní zvýraznit, porovnat nebo zkoumat rozdíly mezi dvěma nebo více datovými sadami, což vám pomůže identifikovat vztahy mezi nimi.

![The combination chart](combination_chart.png)

Následující Java kód ukazuje, jak vytvořit kombinovaný graf zobrazený výše v PowerPoint prezentaci:

```java
static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Nastavte název grafu.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Nastavte legendu grafu.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Odstraňte výchozí vygenerované řady a kategorie.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Přidejte nové kategorie.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Přidejte první řadu.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // Nastavte vodorovnou osu.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Nastavte svislou osu.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Nastavte barvu hlavních svislých mřížkových čar.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Nastavte sekundární vodorovnou osu.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Nastavte sekundární svislou osu.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```

## **Aktualizovat grafy**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Kroky:</em> Aktualizovat PowerPoint graf v Javě</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Kroky:</em> Aktualizovat graf v prezentaci v Javě</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Kroky:</em> Aktualizovat PowerPoint prezentaci s grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation), která představuje prezentaci obsahující graf, který chcete aktualizovat.
2. Získejte odkaz na snímek pomocí jeho Indexu.
3. Projděte všechny tvary a najděte požadovaný graf.
4. Přístup k pracovním listům dat grafu.
5. Upravit data řad grafu změnou hodnot řad.
6. Přidejte novou řadu a naplňte ji daty.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak aktualizovat graf:

```java
Presentation pres = new Presentation();
try {
    // Získat první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Získat graf s výchozími daty
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Nastavení indexu listu dat grafu
    int defaultWorksheetIndex = 0;

    // Získání pracovního listu dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Změna názvu kategorie grafu
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Získat první řadu grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Nyní aktualizuje data řady
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Modifikace názvu řady
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Získat druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);

    // Nyní aktualizuje data řady
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Modifikace názvu řady
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Nyní přidává novou řadu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Získat třetí řadu grafu
    series = chart.getChartData().getSeries().get_Item(2);

    // Nyní naplňuje data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Uložit prezentaci s grafem
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavit datový rozsah pro graf**

Pro nastavení datového rozsahu pro graf postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation), která představuje prezentaci obsahující graf.
2. Získejte odkaz na snímek podle jeho indexu.
3. Projděte všechny tvary a najděte požadovaný graf.
4. Přístup k datům grafu a nastavení rozsahu.
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak nastavit datový rozsah pro graf:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Použít výchozí značky v grafech**
Když použijete výchozí značku v grafech, každá řada grafu získá jiný výchozí symbol značky automaticky.

Tento Java kód ukazuje, jak automaticky nastavit značku řady grafu:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Získat druhou řadu grafu
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Nyní naplňuji data řady
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené dotazy**

**Jaké typy grafů podporuje Aspose.Slides?**

Aspose.Slides podporuje širokou škálu [chart types](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/), včetně sloupcových, spojnicových, koláčových, plošných, rozptylových, histogramových, radiových a mnoha dalších. Tato flexibilita vám umožní vybrat nejvhodnější typ grafu pro vaše potřeby vizualizace dat.

**Jak přidat nový graf do snímku?**

Pro přidání grafu nejprve vytvoříte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) , načtete požadovaný snímek podle jeho indexu a poté zavoláte metodu pro přidání grafu, přičemž specifikujete typ grafu a počáteční data. Tento proces integruje graf přímo do vaší prezentace.

**Jak mohu aktualizovat data zobrazovaná v grafu?**

Data grafu můžete aktualizovat přístupem k jeho datovému sešitu ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/)), vymazáním výchozích řad a kategorií a následným přidáním vlastních dat. To vám umožní obnovit graf tak, aby odrážel nejnovější data.

**Je možné přizpůsobit vzhled grafu?**

Ano, Aspose.Slides poskytuje rozsáhlé možnosti přizpůsobení. Můžete měnit barvy, písma, popisky, legendy a další [formatting elements](/slides/cs/androidjava/chart-entities/) tak, aby vzhled grafu odpovídal vašim konkrétním požadavkům na design.