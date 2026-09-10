---
title: Vytvořit nebo aktualizovat grafy v PowerPoint prezentacích v Javě
linktitle: Vytvořit nebo aktualizovat grafy
type: docs
weight: 10
url: /cs/java/create-chart/
keywords:
- přidat graf
- vytvořit graf
- upravit graf
- změnit graf
- aktualizovat graf
- rozptylový graf
- koláčový graf
- čárový graf
- stromová mapa
- akciový graf
- box-whisker graf
- trychterný graf
- paprskový graf
- histogramový graf
- radiový graf
- graf s více kategoriemi
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte grafy v PowerPoint prezentacích pomocí Aspose.Slides pro Java. Přidávejte, formátujte a upravujte grafy s praktickými ukázkami kódu v Javě."
---
## **Přehled**

Tento článek poskytuje komplexní průvodce, jak vytvářet a přizpůsobovat grafy pomocí Aspose.Slides. Naučíte se, jak programově přidat graf do snímku, naplnit jej daty a použít různé možnosti formátování tak, aby vyhovovaly vašim specifickým návrhovým požadavkům. V celém článku podrobné ukázky kódu ilustrují každý krok, od inicializace prezentace a objektu grafu po konfiguraci řad, os a legend. Dodržením tohoto průvodce získáte solidní pochopení integrace dynamického generování grafů do vašich aplikací a zefektivníte proces vytváření datově řízených prezentací.

## **Vytvoření grafu**

Grafy pomáhají lidem rychle vizualizovat data a získat poznatky, které nemusí být ihned zřejmé z tabulky nebo listu kalkulací.

**Proč vytvářet grafy?**

Pomocí grafů můžete:

* agregovat, zhušťovat nebo shrnout velké množství dat na jediném snímku v prezentaci
* odhalit vzory a trendy v datech
* odvodit směr a dynamiku dat v čase nebo vzhledem k určité jednotce měření
* zaznamenat odlehlé hodnoty, aberace, odchylky, chyby, nesmyslná data atd.
* komunikovat nebo prezentovat složitá data

V PowerPointu můžete grafy vytvářet pomocí funkce *Insert*, která poskytuje šablony pro navrhování mnoha typů grafů. Pomocí Aspose.Slides můžete vytvářet jak běžné grafy (založené na populárních typech), tak vlastní grafy.

{{% alert color="info" title="Poznámka" %}}
Pro vytváření grafů použijte třídu [ChartType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/). Pole v této třídě odpovídají různým typům grafů.
{{% /alert %}}

### **Vytvoření sloupcových grafů se seskupením**

Tato sekce vysvětluje, jak pomocí Aspose.Slides vytvořit sloupcové grafy se seskupením. Naučíte se inicializovat prezentaci, přidat graf a přizpůsobit jeho prvky, jako je název, data, řady, kategorie a stylování. Postupujte podle níže uvedených kroků a uvidíte, jak se generuje standardní sloupcový graf se seskupením:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) class.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s některými daty a specifikujte typ `ChartType.ClusteredColumn`.
4. Přidejte grafu název.
5. Získejte přístup k datovému listu grafu.
6. Vymažte všechny výchozí řady a kategorie.
7. Přidejte nové řady a kategorie.
8. Přidejte nová data do řady grafu.
9. Aplikujte výplňovou barvu na řadu grafu.
10. Přidejte štítky k řadě grafu.
11. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód demonstruje, jak vytvořit sloupcový graf se seskupením:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytváří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Přidá graf s výchozími daty
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Nastavuje název grafu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Nastavuje index pro datový list grafu
    int defaultWorksheetIndex = 0;
    
    // Získává list dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Odstraňuje výchozí vygenerované řady a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Přidává nové řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Přidává nové kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Získává první řadu grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Nyní naplňuje data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Nastavuje barvu výplně pro řadu
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Získává druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Naplní data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Nastavuje barvu výplně pro řadu
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Vytvořte vlastní popisky pro každou kategorii pro novou řadu
    // Nastavuje první popisek tak, aby zobrazoval název kategorie
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Zobrazuje hodnotu pro třetí popisek
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Ukládá prezentaci s grafem
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvoření rozptylových grafů**

Rozptylové grafy (také známé jako scatter plots nebo grafy x‑y) se často používají k ověření vzorů nebo demonstraci korelací mezi dvěma proměnnými.

Použijte rozptylový graf, když:

* máte spárovaná číselná data
* máte dvě proměnné, které dobře spolu souvisí
* chcete zjistit, zda jsou dvě proměnné vzájemně související
* máte nezávislou proměnnou, která má pro závislou proměnnou více hodnot

1. Postupujte podle kroků v [Vytvoření sloupcových grafů se seskupením](#create-clustered-column-charts).
2. Ve třetím kroku přidejte graf s některými daty a specifikujte typ grafu jako jeden z následujících:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Reprezentuje rozptylový graf._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Reprezentuje rozptylový graf spojený křivkami s datovými značkami._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Reprezentuje rozptylový graf spojený křivkami bez datových značek._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Reprezentuje rozptylový graf spojený přímkami s datovými značkami._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Reprezentuje rozptylový graf spojený přímkami bez datových značek._

Tento Java kód ukazuje, jak vytvořit rozptylový graf s různými značkami pro každou řadu:

```java
import com.aspose.slides.*;

// Vytváří instanci třídy prezentace, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);

    // Vytvoří výchozí graf
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Získává výchozí index listu dat grafu
    int defaultWorksheetIndex = 0;
    
    // Získává list dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Odstraňuje demonstrační řadu
    chart.getChartData().getSeries().clear();
    
    // Přidává nové řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Získává první řadu grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Přidává nový bod (1:3) do řady
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Přidává nový bod (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Mění typ řady
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Mění značku řady grafu
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Získává druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Přidává nový bod (5:2) zde
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Přidává nový bod (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Přidává nový bod (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Přidává nový bod (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Mění značku řady grafu
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvoření koláčových grafů**

Koláčové grafy jsou nejvhodnější pro zobrazení vztahu část‑celku v datech, zejména když data obsahují kategoriové štítky s číselnými hodnotami. Pokud však vaše data obsahují mnoho částí nebo štítků, můžete zvážit použití sloupcového grafu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType.Pie](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#Pie).
4. Získejte přístup k sešitu dat grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data do řady grafu.
8. Přidejte nové body do grafu a aplikujte vlastní barvy na sektory koláčového grafu.
9. Nastavte štítky pro řady.
10. Aktivujte čáry vodítek pro štítky řad.
11. Nastavte úhlový posun sektorů koláčového grafu.
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
    
    // Nastavuje název grafu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Nastavuje index pro list dat grafu
    int defaultWorksheetIndex = 0;
    
    // Získává list dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Odstraňuje výchozí vygenerované řady a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Přidává nové kategorie
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Přidává nové řady
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Naplní data řady
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
	
    // Nastavuje okraj sektoru
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Nastavuje okraj sektoru
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Nastavuje okraj sektoru
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Vytváří vlastní popisky pro každou kategorii pro novou řadu
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
    
    // Zobrazuje vodící čáry pro graf
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Nastavuje úhel otáčení sektorů koláčového grafu
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Ukládá prezentaci s grafem
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvoření čárových grafů**

Čárové grafy (také známé jako line graphs) jsou nejvhodnější v situacích, kdy chcete demonstrovat změny hodnot v čase. Pomocí čárového grafu můžete najednou porovnat velké množství dat, sledovat změny a trendy v průběhu času, zvýraznit anomálie v řadách a další.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType.Line](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#Line).
4. Uložte upravenou prezentaci jako soubor PPTX.

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

Ve výchozím nastavení jsou body v čárovém grafu spojeny přímými souvislými čarami. Pokud chcete, aby byly body spojeny čárkami, můžete specifikovat požadovaný typ čáry takto:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Vytvoření mapových grafů (Tree Map)**

Mapové grafy jsou nejvhodnější pro prodejní data, když chcete ukázat relativní velikost kategorií a rychle upoutat pozornost na položky, které jsou velkými přispěvateli v každé kategorii.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType.Treemap](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#Treemap).
4. Získejte přístup k sešitu dat grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data do řady grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit mapový graf:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    // větev 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    // větev 2
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

### **Vytvoření akciových grafů (Stock)**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#OpenHighLowClose).
4. Získejte přístup k sešitu dat grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data do řady grafu.
8. Specifikujte formát čar high‑low.
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

### **Vytvoření krabicových a brčových grafů (Box and Whisker)**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#BoxAndWhisker).
4. Získejte přístup k sešitu dat grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data do řady grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit krabicový a brčový graf:

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

### **Vytvoření trychterných grafů (Funnel)**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType.Funnel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#Funnel).
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit trychterný graf:

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

### **Vytvoření paprskových grafů (Sunburst)**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType.Sunburst](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#Sunburst).
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit paprskový graf:

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

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType.Histogram](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#Histogram).
4. Získejte přístup k sešitu dat grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/).
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

### **Vytvoření radiových grafů (Radar)**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s některými daty a specifikujte preferovaný typ grafu ([ChartType.Radar](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#Radar) v tomto případě).
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit radiový graf:

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

### **Vytvoření grafů s více kategoriemi**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType.ClusteredColumn](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/#ClusteredColumn).
4. Získejte přístup k sešitu dat grafu [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data do řady grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit graf s více kategoriemi:

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

    // Přidání série
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

Mapové grafy vizualizují geografická data a pomáhají porovnávat hodnoty mezi regiony.

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

Kombinovaný graf (nebo combo graf) kombinuje dva nebo více typů grafů v jednom diagramu. Tento graf vám umožní zvýraznit, porovnat nebo prozkoumat rozdíly mezi dvěma nebo více sadami dat, čímž pomáhá identifikovat vztahy mezi nimi.

![Kombinační graf](combination_chart.png)

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

    // Odstranit výchozí vygenerované řady a kategorie.
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

    // Nastavit barvu hlavních mřížkových čar vertikální osy.
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

## **Aktualizace grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class, která představuje prezentaci obsahující graf, který chcete aktualizovat.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Procházejte všechny tvary a najděte požadovaný graf.
4. Získejte přístup k datovému listu grafu.
5. Modifikujte řadu dat grafu změnou hodnot řady.
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

    // Nastavuje index listu dat grafu
    int defaultWorksheetIndex = 0;

    // Získává list dat grafu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Mění název kategorie grafu
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Vezme první řadu grafu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Nyní aktualizuje data řady
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Mění název řady
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Vezme druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);

    // Nyní aktualizuje data řady
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Mění název řady
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Nyní přidává novou řadu
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Vezme třetí řadu grafu
    series = chart.getChartData().getSeries().get_Item(2);

    // Nyní naplňuje data řady
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

## **Nastavení rozsahu dat pro graf**

Pro nastavení rozsahu dat pro graf postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class, která představuje prezentaci obsahující graf.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Procházejte všechny tvary a najděte požadovaný graf.
4. Získejte přístup k datům grafu a nastavte rozsah.
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

Když v grafech používáte výchozí značky, každá řada grafu automaticky získá jiný symbol značky.

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
    // Vezměte druhou řadu grafu
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Nyní vyplňuji data řady
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

**Jaké typy grafů podporuje Aspose.Slides?**

Aspose.Slides podporuje širokou škálu [typů grafů](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/), včetně sloupcových, čárových, koláčových, oblastních, rozptylových, histogramových, radiových a mnoha dalších. Tato flexibilita vám umožní vybrat nejvhodnější typ grafu pro vaše potřeby vizualizace dat.

**Jak přidám nový graf do snímku?**

Pro přidání grafu nejprve vytvoříte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), získáte požadovaný snímek pomocí jeho indexu a poté zavoláte metodu pro přidání grafu, přičemž specifikujete typ grafu a počáteční data. Tento proces integruje graf přímo do vaší prezentace.

**Jak mohu aktualizovat data zobrazovaná v grafu?**

Data grafu můžete aktualizovat přístupem k jeho sešitu dat ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/)), vymazáním výchozích řad a kategorií a následným přidáním vlastních dat. To vám umožní obnovit graf tak, aby odrážel nejnovější data.

**Je možné přizpůsobit vzhled grafu?**

Ano, Aspose.Slides poskytuje rozsáhlé možnosti přizpůsobení. Můžete měnit barvy, písma, štítky, legendy a další [formátovací prvky](/slides/cs/java/chart-entities/), abyste graf upravili podle konkrétních návrhových požadavků.