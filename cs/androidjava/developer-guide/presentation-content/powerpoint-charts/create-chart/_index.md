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
- čárový graf
- mapový graf
- akciový graf
- box a whisker graf
- trychtýřový graf
- sunburst graf
- histogramový graf
- radarový graf
- vícekategoriový graf
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte grafy v PowerPoint prezentacích pomocí Aspose.Slides pro Android. Přidejte, formátujte a upravujte grafy s praktickými příklady kódu v jazyce Java."
---
## **Přehled**

Tento článek poskytuje komplexní průvodce, jak vytvářet a přizpůsobovat grafy pomocí Aspose.Slides. Naučíte se, jak programově přidat graf do snímku, naplnit jej daty a použít různé možnosti formátování tak, aby odpovídaly vašim konkrétním požadavkům na design. V celém článku podrobné ukázky kódu ilustrují každý krok, od inicializace prezentace a objektu grafu až po konfiguraci sérií, os a legend. Dodržením tohoto průvodce získáte pevné pochopení, jak integrovat dynamické generování grafů do vašich aplikací, což zjednoduší proces vytváření prezentací řízených daty.

## **Vytvoření grafu**
Grafy pomáhají lidem rychle vizualizovat data a získat přehledy, které nemusí být okamžitě zřejmé z tabulky nebo tabulkového procesoru. 

**Proč vytvářet grafy?**

Používáním grafů můžete

* agregovat, zhušťovat nebo shrnovat velké množství dat na jediném snímku v prezentaci
* odhalovat vzory a trendy v datech
* odhadovat směr a dynamiku dat v čase nebo vzhledem ke konkrétní měrné jednotce
* identifikovat odlehlé hodnoty, aberrace, odchylky, chyby, nesmyslná data atd.
* komunikovat nebo prezentovat složitá data

V PowerPointu můžete vytvářet grafy pomocí funkce vložení, která poskytuje šablony pro návrh mnoha typů grafů. Pomocí Aspose.Slides můžete vytvářet běžné grafy (založené na populárních typech grafů) i vlastní grafy. 

{{% alert color="info" %}} 

Aby vám umožnil vytvářet grafy, Aspose.Slides poskytuje třídu [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType). Polia pod touto třídou odpovídají různým typům grafů.

{{% /alert %}} 

### **Vytvořit běžné grafy**

_Kroky: Vytvořit graf_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint graf v Javě</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Kroky:</em> Vytvořit graf v prezentaci v Javě</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s grafem v Javě</strong></a>

Kódu kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte graf s nějakými daty a zadejte preferovaný typ grafu. 
4. Přidejte název grafu. 
5. Získejte přístup k pracovním listu s daty grafu.
6. Vymažte všechny výchozí série a kategorie.
7. Přidejte nové série a kategorie.
8. Přidejte nová data grafu pro série grafu.
9. Přidejte barvu výplně pro série grafu.
10. Přidejte popisky pro série grafu. 
11. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód vám ukazuje, jak vytvořit běžný graf:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Přidá graf s výchozími daty
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Nastaví název grafu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Nastaví index pro datový list grafu
    int defaultWorksheetIndex = 0;
    
    // Získá pracovní list s daty grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Odstraní výchozí generované série a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Přidá nové série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Přidá nové kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Získá první sérii grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Nyní vyplní data série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Nastaví barvu výplně pro sérii
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Získá druhou sérii grafu
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Vyplní data série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Nastaví barvu výplně pro sérii
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Create vlastní popisky pro každou kategorii nové série
    // Nastaví první popisek, aby zobrazoval název kategorie
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
Rozptýlené grafy (také známé jako rozptýlené diagramy nebo x‑y grafy) se často používají ke kontrole vzorů nebo demonstraci korelací mezi dvěma proměnnými. 

Můžete chtít použít rozptýlený graf, když 

* máte spárovaná číselná data
* máte 2 proměnné, které spolu dobře souvisí
* chcete zjistit, zda jsou 2 proměnné související
* máte nezávislou proměnnou, která má více hodnot pro závislou proměnnou

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Kroky:</em> Vytvořit rozptýlený graf v Javě</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint rozptýlený graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s rozptýleným grafem v Javě</strong></a>

1. Prosím, následujte kroky uvedené výše v [Vytvoření běžných grafů](#creating-normal-charts)
2. Pro třetí krok, přidejte graf s nějakými daty a zadejte typ grafu jako jeden z následujících
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Representuje rozptýlený graf se značkami._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representuje rozptýlený graf spojený křivkami, se značkami dat._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Representuje rozptýlený graf spojený křivkami, bez značek dat._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representuje rozptýlený graf spojený úsečkami, se značkami dat._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Representuje rozptýlený graf spojený úsečkami, bez značek dat._

Tento Java kód vám ukazuje, jak vytvořit rozptýlené grafy s různými sériemi značek: 

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);

    // Vytvoří výchozí graf
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Získá výchozí index pracovního listu s daty grafu
    int defaultWorksheetIndex = 0;
    
    // Získá pracovní list s daty grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Odstraní ukázkové série
    chart.getChartData().getSeries().clear();
    
    // Přidá nové série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Získá první sérii grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Přidá nový bod (1:3) do série
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Přidá nový bod (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Změní typ série
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Změní značku série grafu
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Získá druhou sérii grafu
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Přidá nový bod (5:2) tam
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Přidá nový bod (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Přidá nový bod (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Přidá nový bod (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Změní značku série grafu
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit koláčové grafy**

Koláčové grafy jsou nejvhodnější pro zobrazení vztahu část‑celku v datech, zejména když data obsahují kategoriální štítky s číselnými hodnotami. Pokud však data obsahují mnoho částí nebo štítků, můžete zvážit použití sloupcového grafu.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Kroky:</em> Vytvořit koláčový graf v Javě</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint koláčový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s koláčovým grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).Pie).
4. Získejte přístup k datovému sešitu grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Vymažte výchozí série a kategorie.
6. Přidejte nové série a kategorie.
7. Přidejte nová data pro série grafu.
8. Přidejte nové body pro graf a přizpůsobte barvy sektoru koláčového grafu.
9. Nastavte popisky pro série.
10. Nastavte čáry vodítek pro popisky sérií.
11. Nastavte úhel otáčení pro slajdy s koláčovým grafem.
12. Uložte upravenou prezentaci jako soubor PPTX

Tento Java kód vám ukazuje, jak vytvořit koláčový graf:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Přidá graf s výchozími daty
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Nastaví název grafu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Nastaví index pro datový list grafu
    int defaultWorksheetIndex = 0;
    
    // Získá pracovní list s daty grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Odstraní výchozí generované série a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Přidá nové kategorie
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Přidá nové série
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Vyplní data série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Nepracuje v nové verzi
    // Přidávání nových bodů a nastavení barvy sektoru
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
    
    // Vytvoří vlastní popisky pro každou kategorii nové série
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

### **Vytvořit čárové grafy**

Čárové grafy (také známé jako čárové diagramy) jsou nejvhodnější v situacích, kdy chcete ukázat změny hodnot v průběhu času. Pomocí čárového grafu můžete najednou porovnat velké množství dat, sledovat změny a trendy v čase, zvýraznit odchylky v datových sériích atd.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě `ChartType.Line`).
1. Uložte upravenou prezentaci jako soubor PPTX

Tento Java kód vám ukazuje, jak vytvořit čárový graf:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ve výchozím nastavení jsou body v čárovém grafu spojeny přímými souvislými čarami. Pokud chcete, aby byly body spojeny pomlčkami, můžete zadat preferovaný typ čáry takto:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit mapové grafy (Tree Map)**

Mapové grafy jsou nejvhodnější pro prodejní data, když chcete zobrazit relativní velikost datových kategorií a (současně) rychle upozornit na položky, které jsou velkými přispěvateli do každé kategorie. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Kroky:</em> Vytvořit mapový graf v Javě</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint mapový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s mapovým grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).TreeMap).
4. Získejte přístup k datovému sešitu grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Vymažte výchozí série a kategorie.
6. Přidejte nové série a kategorie.
7. Přidejte nová data pro série grafu.
8. Uložte upravenou prezentaci jako soubor PPTX

Tento Java kód vám ukazuje, jak vytvořit mapový graf:

```java
import com.aspose.slides.*;

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

### **Vytvořit akciové grafy (Stock)**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Kroky:</em> Vytvořit akciový graf v Javě</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint akciový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s akciovým grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).OpenHighLowClose).
4. Získejte přístup k datovému sešitu grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Vymažte výchozí série a kategorie.
6. Přidejte nové série a kategorie.
7. Přidejte nová data pro série grafu.
8. Určete formát HiLowLines.
9. Uložte upravenou prezentaci jako soubor PPTX

Ukázkový Java kód používaný k vytvoření akciového grafu:

```java
import com.aspose.slides.*;

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

### **Vytvořit grafy Box and Whisker**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Kroky:</em> Vytvořit Box and Whisker graf v Javě</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint Box and Whisker graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s Box and Whisker grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).BoxAndWhisker).
4. Získejte přístup k datovému sešitu grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Vymažte výchozí série a kategorie.
6. Přidejte nové série a kategorie.
7. Přidejte nová data pro série grafu.
8. Uložte upravenou prezentaci jako soubor PPTX

Tento Java kód vám ukazuje, jak vytvořit Box and Whisker graf:

```java
import com.aspose.slides.*;

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

### **Vytvořit trychtýřové grafy (Funnel)**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Kroky:</em> Vytvořit trychtýřový graf v Javě</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint trychtýřový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s trychtýřovým grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).Funnel).
4. Uložte upravenou prezentaci jako soubor PPTX

Java kód vám ukazuje, jak vytvořit trychtýřový graf:

```java
import com.aspose.slides.*;

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

### **Vytvořit sluneční paprsek (Sunburst) grafy**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Kroky:</em> Vytvořit Sunburst graf v Javě</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint Sunburst graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s Sunburst grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).sunburst).
4. Uložte upravenou prezentaci jako soubor PPTX

Tento Java kód vám ukazuje, jak vytvořit Sunburst graf:

```java
import com.aspose.slides.*;

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
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).Histogram).
4. Získejte přístup k datovému sešitu grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Vymažte výchozí série a kategorie.
6. Přidejte nové série a kategorie.
7. Uložte upravenou prezentaci jako soubor PPTX

Tento Java kód vám ukazuje, jak vytvořit histogramový graf:

```java
import com.aspose.slides.*;

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

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit radiační (Radar) grafy**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Kroky:</em> Vytvořit Radar graf v Javě</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint Radar graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s Radar grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Přidejte graf s nějakými daty a zadejte preferovaný typ grafu (`ChartType.Radar` v tomto případě).
4. Uložte upravenou prezentaci jako soubor PPTX

Tento Java kód vám ukazuje, jak vytvořit Radar graf:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit vícekategoriové grafy**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Kroky:</em> Vytvořit vícekategoriový graf v Javě</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint vícekategoriový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s vícekategoriovým grafem v Javě</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartType).ClusteredColumn).
4. Získejte přístup k datovému sešitu grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Vymažte výchozí série a kategorie.
6. Přidejte nové série a kategorie.
7. Přidejte nová data pro série grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód vám ukazuje, jak vytvořit vícekategoriový graf:

```java
import com.aspose.slides.*;

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

    // Přidání sérií
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

Mapový graf je vizualizace oblasti obsahující data. Mapové grafy jsou nejvhodnější pro porovnání dat nebo hodnot napříč geografickými regiony.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Kroky:</em> Vytvořit mapový graf v Javě</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint mapový graf v Javě</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s mapovým grafem v Javě</strong></a>

Tento Java kód vám ukazuje, jak vytvořit mapový graf:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvořit kombinované grafy**

Kombinovaný graf (nebo combo graf) kombinuje dva nebo více typů grafů v jednom diagramu. Tento graf vám umožní zvýraznit, porovnat nebo prověřit rozdíly mezi dvěma nebo více datovými sadami, což pomáhá identifikovat vztahy mezi nimi.

![Kombinovaný graf](combination_chart.png)

Následující Java kód ukazuje, jak vytvořit kombinovaný graf zobrazený výše v PowerPoint prezentaci:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Nastaví název grafu.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Nastaví legendu grafu.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Odstraní výchozí generované série a kategorie.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Přidá nové kategorie.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Přidá první sérii.
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
    // Nastaví vodorovnou osu.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Nastaví svislou osu.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Nastaví barvu hlavních mřížkových čar svislé osy.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Nastaví sekundární vodorovnou osu.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Nastaví sekundární svislou osu.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
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

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) představující prezentaci obsahující graf, který chcete aktualizovat.
2. Získejte referenci na snímek pomocí jeho indexu.
3. Prohledejte všechny tvary a najděte požadovaný graf.
4. Získejte přístup k datovému listu grafu.
5. Modifikujte data sérií grafu změnou hodnot sérií.
6. Přidejte novou sérii a naplňte ji daty.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód vám ukazuje, jak aktualizovat graf:

```java
import com.aspose.slides.*;

// Otevře prezentaci, která obsahuje graf k aktualizaci
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Získá první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Získá graf ze snímku
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Nastavení indexu listu s daty grafu
    int defaultWorksheetIndex = 0;

    // Získání pracovního listu s daty grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Změna názvu kategorie grafu
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Získá první sérii grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Nyní aktualizuje data série
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Úprava názvu série
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Získá druhou sérii grafu
    series = chart.getChartData().getSeries().get_Item(1);

    // Nyní aktualizuje data série
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Úprava názvu série
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Nyní přidává novou sérii
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Získá třetí sérii grafu
    series = chart.getChartData().getSeries().get_Item(2);

    // Nyní vyplňuje data série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Uloží prezentaci s grafem
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavit datový rozsah pro graf**

Pro nastavení datového rozsahu grafu postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) představující prezentaci obsahující graf.
2. Získejte referenci na snímek pomocí jeho indexu.
3. Prohledejte všechny tvary a najděte požadovaný graf.
4. Získejte přístup k datům grafu a nastavte rozsah.
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód vám ukazuje, jak nastavit datový rozsah pro graf:

```java
import com.aspose.slides.*;

// Otevře prezentaci, která obsahuje graf
Presentation pres = new Presentation("ExistingChart.pptx");
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
Když použijete výchozí značku v grafech, každá série grafu získá automaticky odlišný výchozí symbol značky.

Tento Java kód vám ukazuje, jak automaticky nastavit značku série grafu:

```java
import com.aspose.slides.*;

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
    // Získá druhou sérii grafu
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Nyní vyplňuji data série
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

## **Často kladené otázky**

### Jaké typy grafů podporuje Aspose.Slides?

Aspose.Slides podporuje širokou škálu [typů grafů](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/), včetně sloupcových, čárových, koláčových, oblastních, rozptýlených, histogramových, radaru a mnoha dalších. Tato flexibilita vám umožňuje vybrat nejvhodnější typ grafu pro vaše potřeby vizualizace dat.

### Jak přidám nový graf do snímku?

Pro přidání grafu nejprve vytvoříte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) reprezentující prezentaci, získáte požadovaný snímek podle jeho indexu a poté zavoláte metodu pro přidání grafu, kde specifikujete typ grafu a počáteční data. Tento proces integruje graf přímo do vaší prezentace.

### Jak mohu aktualizovat data zobrazovaná v grafu?

Data grafu můžete aktualizovat přístupem k jeho datovému sešitu ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/)), vymazáním výchozích sérií a kategorií a následným přidáním vlastních dat. To vám umožní obnovit graf tak, aby odrážel nejnovější data.

### Je možné přizpůsobit vzhled grafu?

Ano, Aspose.Slides poskytuje rozsáhlé možnosti přizpůsobení. Můžete měnit barvy, písma, popisky, legendy a další [formátovací prvky](/slides/cs/androidjava/chart-entities/), aby vzhled grafu odpovídal vašim specifickým požadavkům na design.