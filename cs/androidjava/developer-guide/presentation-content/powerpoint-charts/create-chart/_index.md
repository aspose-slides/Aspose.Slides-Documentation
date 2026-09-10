---
title: Vytvořit nebo aktualizovat grafy v prezentacích PowerPoint na Androidu
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
- bodový graf
- koláčový graf
- čárový graf
- stromová mapa
- akciový graf
- krabicový a vousatý graf
- trychtýřový graf
- sluneční graf
- histogramový graf
- radiální graf
- vícekategoriální graf
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte grafy v prezentacích PowerPoint pomocí Aspose.Slides pro Android. Přidávejte, formátujte a upravujte grafy s praktickými příklady kódu v jazyce Java."
---
## **Přehled**

Tento článek poskytuje komplexního průvodce, jak vytvářet a přizpůsobovat grafy pomocí Aspose.Slides. Naučíte se, jak programově přidat graf do snímku, naplnit jej daty a použít různé možnosti formátování, aby odpovídal vašim konkrétním požadavkům na design. V celém článku podrobné ukázky kódu ilustrují každý krok, od inicializace prezentace a objektu grafu po konfiguraci řad, os a legend. Dodržením tohoto průvodce získáte solidní pochopení, jak integrovat dynamické generování grafů do vašich aplikací a zjednodušit proces vytváření datově řízených prezentací.

## **Vytvoření grafu**

Grafy pomáhají lidem rychle vizualizovat data a získat postřehy, které nemusí být okamžitě patrné z tabulky nebo tabulkového procesoru.

**Proč vytvářet grafy?**

Pomocí grafů můžete:

* agregovat, zhušťovat nebo sumarizovat velké množství dat na jednom snímku v prezentaci
* odhalit vzory a trendy v datech
* odvodit směr a dynamiku dat v čase nebo vzhledem k určité jednotce měření
* odhalit odlehlé hodnoty, aberrace, odchylky, chyby, nesmyslná data apod.
* komunikovat nebo prezentovat složitá data

V PowerPointu můžete vytvářet grafy pomocí funkce *Vložit*, která poskytuje šablony pro navrhování mnoha typů grafů. Pomocí Aspose.Slides můžete vytvářet jak běžné grafy (založené na populárních typech grafů), tak i vlastní grafy.

{{% alert color="info" title="Note" %}}

K vytvoření grafů použijte třídu [ChartType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/). Pole v této třídě odpovídají různým typům grafů.

{{% /alert %}}

### **Vytvoření sloupcových seskupených grafů**

Tato sekce vysvětluje, jak vytvořit sloupcové seskupené grafy pomocí Aspose.Slides. Naučíte se inicializovat prezentaci, přidat graf a přizpůsobit jeho prvky, jako jsou název, data, řady, kategorie a stylování. Postupujte podle níže uvedených kroků a uvidíte, jak se generuje standardní sloupcový seskupený graf:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s nějakými daty a určete typ `ChartType.ClusteredColumn`.
1. Přidejte název do grafu.
1. Přistupte k pracovním listům dat grafu.
1. Vymažte všechny výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data grafu pro řady grafu.
1. Použijte barvu výplně pro řady grafu.
1. Přidejte popisky k řadám grafu.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód demonstruje, jak vytvořit sloupcový seskupený graf:

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
    
    // Nastaví index pro list dat grafu
    int defaultWorksheetIndex = 0;
    
    // Získá pracovní list dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Smaže výchozí generované řady a kategorie
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
    
    // Nastaví barvu výplně pro řadu
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Získá druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Naplní data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Nastaví barvu výplně pro řadu
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Vytvoří vlastní popisky pro každou kategorii pro novou řadu
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

### **Vytvoření bodových grafů**

Bodové grafy (také známé jako rozptylové grafy nebo x‑y grafy) se často používají k vyhledání vzorců nebo ukázání korelací mezi dvěma proměnnými.

Použijte bodový graf, když:

* máte spárovaná číselná data
* máte dvě proměnné, které spolu dobře souvisejí
* chcete zjistit, zda jsou dvě proměnné propojené
* máte nezávislou proměnnou s více hodnotami pro závislou proměnnou

1. Postupujte podle kroků v [Create Clustered Column Charts](#create-clustered-column-charts).
2. Ve třetím kroku přidejte graf s nějakými daty a určete typ grafu jako jeden z následujících:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Representuje bodový graf._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representuje bodový graf spojený zakřivenými čarami s datovými značkami._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Representuje bodový graf spojený zakřivenými čarami bez datových značek._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representuje bodový graf spojený přímými čarami s datovými značkami._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Representuje bodový graf spojený přímými čarami bez datových značek._

Tento Java kód ukazuje, jak vytvořit bodový graf s různými značkami pro každou řadu:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);

    // Vytvoří výchozí graf
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Získá index výchozího pracovního listu dat grafu
    int defaultWorksheetIndex = 0;
    
    // Získá pracovní list dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Smaže demonstrační řady
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

### **Vytvoření koláčových grafů**

Koláčové grafy se nejlépe používají pro zobrazení vztahu část‑celku v datech, zejména když data obsahují kategorické štítky s číselnými hodnotami. Pokud však data obsahují mnoho částí nebo štítků, můžete zvážit použití sloupcového grafu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.Pie](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#Pie).
4. Přistupte k sešitu dat grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady grafu.
8. Přidejte nové body do grafu a aplikujte vlastní barvy pro sektory koláčového grafu.
9. Nastavte popisky pro řady.
10. Povolte čáry popisků pro řady.
11. Nastavte úhel otáčení pro sektory koláčového grafu.
12. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit koláčový graf:

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
    
    // Nastaví index pro list dat grafu
    int defaultWorksheetIndex = 0;
    
    // Získá pracovní list dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Smaže výchozí generované řady a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Přidá nové kategorie
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Přidá novou řadu
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Naplní data řady
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Nepracuje v nové verzi
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
    
    // Vytvoří vlastní popisky pro každou kategorii pro novou řadu
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
    
    // Nastaví úhel otáčení pro sektory koláčového grafu
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Uloží prezentaci s grafem
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvoření čárových grafů**

Čárové grafy (také známé jako čárové diagramy) jsou nejvhodnější v situacích, kdy chcete zobrazit změny hodnot v čase. Pomocí čárového grafu můžete najednou porovnat velké množství dat, sledovat změny a trendy v čase, zvýraznit anomálie v řadách dat a další.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a určete typ [ChartType.Line](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#Line).
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit čárový graf:

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

Ve výchozím nastavení jsou body v čárovém grafu spojeny přímými souvislými čarami. Pokud chcete, aby byly body spojeny čárkami, můžete zadat preferovaný typ čáry následovně:

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

### **Vytvoření stromových mapových grafů**

Stromové mapové grafy jsou nejvhodnější pro prodejní data, když chcete zobrazit relativní velikost kategorií dat a rychle upoutat pozornost na položky, které jsou velkými přispěvateli v rámci každé kategorie.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.Treemap](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#Treemap) .
4. Přistupte k sešitu dat grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit stromovou mapu:

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

### **Vytvoření akciových grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#OpenHighLowClose) .
4. Přistupte k sešitu dat grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady grafu.
8. Určete formát čar vysoký‑nízký.
9. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit akciový graf:

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

### **Vytvoření krabicových a vousatých grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#BoxAndWhisker) .
4. Přistupte k sešitu dat grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit krabicový a vousatý graf:

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

### **Vytvoření trychytých (funnel) grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.Funnel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#Funnel) .
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit trychtýřový graf:

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

### **Vytvoření slunečních (sunburst) grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.Sunburst](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#Sunburst) .
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit sluneční graf:

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

### **Vytvoření histogramových grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.Histogram](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#Histogram) .
4. Přistupte k sešitu dat grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit histogramový graf:

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

### **Vytvoření radiálních (radar) grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s nějakými daty a určete požadovaný typ grafu ([ChartType.Radar](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#Radar) v tomto případě).
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit radiální graf:

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

### **Vytvoření vícekategoriálních grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.ClusteredColumn](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/#ClusteredColumn) .
4. Přistupte k sešitu dat grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit vícekategoriální graf:

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

### **Vytvoření mapových grafů**

Mapové grafy vizualizují geografická data a pomáhají porovnávat hodnoty napříč regiony.

Tento Java kód ukazuje, jak vytvořit mapový graf:

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

### **Vytvoření kombinovaných grafů**

Kombinovaný graf (nebo combo graf) spojuje dva nebo více typů grafů v jediném diagramu. Tento graf vám umožní zvýraznit, porovnat nebo prozkoumat rozdíly mezi dvěma či více sadami dat, což pomáhá identifikovat vztahy mezi nimi.

![The combination chart](combination_chart.png)

Následující Java kód ukazuje, jak vytvořit kombinovaný graf zobrazený výše v prezentaci PowerPoint:

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

    // Nastavit název grafu.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Nastavit legendu grafu.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Smazat výchozí generované řady a kategorie.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Přidat nové kategorie.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Přidat první řadu.
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
    // Nastavit vodorovnou osu.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Nastavit svislou osu.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Nastavit barvu hlavních čar mřížky svislé osy.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Nastavit sekundární vodorovnou osu.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Nastavit sekundární svislou osu.
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

## **Aktualizace grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) představující prezentaci, která obsahuje graf, který chcete aktualizovat.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Procházejte všechny tvary a najděte požadovaný graf.
4. Přistupte k pracovním listům dat grafu.
5. Modifikujte řady dat grafu změnou hodnot řad.
6. Přidejte novou řadu a naplňte její data.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak aktualizovat graf:

```java
import com.aspose.slides.*;

// Otevře prezentaci, která obsahuje graf k aktualizaci
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Přistupuje k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);

    // Získá graf ze snímku
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Nastavení indexu listu dat grafu
    int defaultWorksheetIndex = 0;

    // Získání pracovního listu dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Změna názvu kategorie grafu
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Vezměte první řadu grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Nyní aktualizuje data řady
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Modifikace názvu řady
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Vezměte druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);

    // Nyní aktualizuje data řady
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Modifikace názvu řady
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Nyní přidává novou řadu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Vezměte třetí řadu grafu
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

## **Nastavení rozsahu dat pro graf**

Pro nastavení rozsahu dat pro graf postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) představující prezentaci, která obsahuje graf.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Procházejte všechny tvary a najděte požadovaný graf.
4. Přistupte k datům grafu a nastavte rozsah.
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak nastavit rozsah dat pro graf:

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

## **Použití výchozích značek v grafech**

Když používáte výchozí značky v grafech, každá řada grafu automaticky získá jiný symbol značky.

Tento Java kód ukazuje, jak automaticky nastavit značku řady grafu:

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
    //Vezměte druhou řadu grafu
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //Nyní naplňujeme data řady
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

## **Časté otázky**

**Jaké typy grafů podporuje Aspose.Slides?**

Aspose.Slides podporuje širokou škálu [typů grafů](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/), včetně sloupcových, čárových, koláčových, plošných, bodových, histogramových, radiálních a mnoha dalších. Tato flexibilita vám umožní vybrat nejvhodnější typ grafu pro vaše potřeby vizualizace dat.

**Jak přidám nový graf do snímku?**

Pro přidání grafu nejprve vytvoříte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) , získáte požadovaný snímek pomocí jeho indexu a poté zavoláte metodu pro přidání grafu, kde zadáte typ grafu a počáteční data. Tento proces integruje graf přímo do vaší prezentace.

**Jak mohu aktualizovat data zobrazovaná v grafu?**

Data grafu můžete aktualizovat přístupem k jeho sešitu dat ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/)), vymazáním výchozích řad a kategorií a následným přidáním vlastních dat. To vám umožní obnovit graf tak, aby odrážel nejnovější data.

**Je možné přizpůsobit vzhled grafu?**

Ano, Aspose.Slides poskytuje rozsáhlé možnosti přizpůsobení. Můžete měnit barvy, písma, popisky, legendy a další [formátovací prvky](/slides/cs/androidjava/chart-entities/), abyste graf přizpůsobili konkrétním požadavkům na design.