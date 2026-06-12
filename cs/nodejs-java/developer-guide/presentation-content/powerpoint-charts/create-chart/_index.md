---
title: Vytvoření nebo aktualizace grafů PowerPoint prezentace v JavaScriptu
linktitle: Vytvoření nebo aktualizace grafů
type: docs
weight: 10
url: /cs/nodejs-java/create-chart/
keywords:
- přidat graf
- vytvořit graf
- upravit graf
- změnit graf
- aktualizovat graf
- rozptylový graf
- výsečový graf
- čárový graf
- stromový mapový graf
- akciový graf
- krabicový a fousový graf
- trychtýřový graf
- sluneční paprskový graf
- histogramový graf
- radarový graf
- graf s více kategoriemi
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvořte a přizpůsobte grafy v PowerPoint prezentacích pomocí Aspose.Slides pro Node.js. Přidejte, formátujte a upravujte grafy s praktickými ukázkami kódu v JavaScriptu."
---
## **Přehled**

Tento článek poskytuje komplexní průvodce, jak vytvářet a přizpůsobovat grafy pomocí Aspose.Slides. Naučíte se, jak programově přidat graf do snímku, naplnit jej daty a použít různé možnosti formátování, aby graf odpovídal vašim konkrétním návrhovým požadavkům. V celém článku podrobné ukázky kódu ilustrují každý krok, od inicializace prezentace a objektu grafu po konfiguraci řad, os a legend. Dodržováním tohoto průvodce získáte solidní pochopení integrace dynamické tvorby grafů do vašich aplikací, což zjednoduší proces vytváření prezentací řízených daty.

## **Vytvoření grafu**
Grafy pomáhají rychle vizualizovat data a získávat poznatky, které nemusí být okamžitě patrné z tabulky nebo tabulkového kalkulátoru. 


**Proč vytvářet grafy?**

Používáním grafů můžete

* agregovat, zhušťovat nebo shrnout velké množství dat na jediném snímku v prezentaci
* odhalovat vzory a trendy v datech
* odhadnout směr a dynamiku dat v čase nebo vzhledem k určité jednotce měření 
* identifikovat odlehlé hodnoty, odchylky, chyby, nesmyslná data atd. 
* komunikovat nebo prezentovat složitá data

V PowerPointu můžete vytvářet grafy pomocí funkce vložení, která poskytuje šablony pro návrh mnoha typů grafů. Pomocí Aspose.Slides můžete vytvářet běžné grafy (založené na populárních typech grafů) i vlastní grafy. 

{{% alert color="primary" %}} 

Aby vám Aspose.Slides umožnil vytvářet grafy, poskytuje třídu [ChartType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartType). Pole v této třídě odpovídají různým typům grafů.

{{% /alert %}} 

### **Vytváření normálních grafů**

_Kroky: Vytvořit graf_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint graf v JavaScriptu</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Kroky:</em> Vytvořit graf prezentace v JavaScriptu</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s grafem v JavaScriptu</strong></a>

_Kroky kódu:_

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte graf s některými daty a zvolte preferovaný typ grafu. 
4. Přidejte název grafu. 
5. Získejte přístup k pracovním listům dat grafu. 
6. Vymažte všechny výchozí řady a kategorie. 
7. Přidejte nové řady a kategorie. 
8. Přidejte nová data pro řadu grafu. 
9. Přidejte barvu výplně pro řadu grafu. 
10. Přidejte popisky pro řadu grafu. 
11. Uložte upravenou prezentaci jako soubor PPTX. 

Tento JavaScriptový kód vám ukazuje, jak vytvořit normální graf:

```javascript
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Přidá graf s výchozími daty
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Nastaví název grafu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // Nastaví, aby první série zobrazovala hodnoty
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Nastaví index listu dat grafu
    var defaultWorksheetIndex = 0;
    // Získá pracovní list dat grafu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Odstraní výchozí generované série a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Přidá nové série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Přidá nové kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Vezme první řadu grafu
    var series = chart.getChartData().getSeries().get_Item(0);
    // Nyní naplní data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Nastaví barvu výplně pro řadu
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Vezme druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);
    // Naplní data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Nastaví barvu výplně pro řadu
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Vytvoří vlastní popisky pro každou kategorii pro novou řadu
    // Nastaví první popisek, aby zobrazoval název kategorie
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Zobrazí hodnotu pro třetí popisek
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Uloží prezentaci s grafem
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření rozptylových grafů**
Rozptylové grafy (také známé jako rozptylové diagramy nebo x‑y grafy) se často používají k ověření vzorů nebo demonstraci korelací mezi dvěma proměnnými. 

Můžete chtít použít rozptylový graf, když 

* máte spárovaná číselná data
* máte 2 proměnné, které dobře spolu souvisejí
* chcete zjistit, zda jsou 2 proměnné propojené
* máte nezávislou proměnnou s více hodnotami pro závislou proměnnou

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Kroky:</em> Vytvořit rozptylový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint rozptylový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s rozptylovým grafem v JavaScriptu</strong></a>

1. Postupujte podle kroků uvedených v [Vytváření normálních grafů](#creating-normal-charts)
2. Ve třetím kroku přidejte graf s některými daty a jako typ grafu zvolte jeden z následujících
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Representuje Scatter Chart._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representuje Scatter Chart spojený křivkami s datovými značkami._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Representuje Scatter Chart spojený křivkami bez datových značek._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representuje Scatter Chart spojený úsečkami s datovými značkami._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Representuje Scatter Chart spojený úsečkami bez datových značek._

Tento JavaScriptový kód vám ukazuje, jak vytvořit rozptylové grafy s různými sériemi značek:

```javascript
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var slide = pres.getSlides().get_Item(0);
    // Vytvoří výchozí graf
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Získá výchozí index pracovního listu dat grafu
    var defaultWorksheetIndex = 0;
    // Získá pracovní list dat grafu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Odstraní ukázkovou sérii
    chart.getChartData().getSeries().clear();
    // Přidá nové série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Vezme první sérii grafu
    var series = chart.getChartData().getSeries().get_Item(0);
    // Přidá nový bod (1:3) do série
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Přidá nový bod (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Změní typ série
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Změní značku série grafu
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Vezme druhou sérii grafu
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
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření výsečových grafů**

Výsečové grafy se nejlépe používají k zobrazení vztahu část‑celku v datech, zejména když data obsahují kategorické štítky s číselnými hodnotami. Pokud však vaše data obsahují mnoho částí nebo štítků, může být vhodnější použít sloupcový graf.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Kroky:</em> Vytvořit výsečový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint výsečový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s výsečovým grafem v JavaScriptu</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě [ChartType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartType).Pie).
4. Získejte přístup k [ChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data pro řadu grafu.
8. Přidejte nové body a vlastní barvy pro sektory výsečového grafu.
9. Nastavte popisky pro řady.
10. Nastavte čáry vodítek pro popisky řad.
11. Nastavte úhel otočení výsečových snímků.
12. Uložte upravenou prezentaci do souboru PPTX

Tento JavaScriptový kód vám ukazuje, jak vytvořit výsečový graf:

```javascript
// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var slides = pres.getSlides().get_Item(0);
    // Přidá graf s výchozími daty
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Nastaví název grafu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Nastaví první sérii k zobrazení hodnot
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Nastaví index listu dat grafu
    var defaultWorksheetIndex = 0;
    // Získá pracovní list dat grafu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Odstraní výchozí generované série a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Přidá nové kategorie
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Přidá nové série
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Naplní data série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Nepracuje v nové verzi
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Nastaví okraj sektoru
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Nastaví okraj sektoru
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Nastaví okraj sektoru
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // Vytvoří vlastní popisky pro každou kategorii nové série
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Zobrazí vodící čáry pro graf
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Nastaví úhel otočení sektorů výsečového grafu
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Uloží prezentaci s grafem
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření spojnicových grafů**

Spojnicové grafy (také známé jako čárové diagramy) se nejlépe hodí v situacích, kdy chcete demonstrovat změny hodnot v čase. Pomocí spojnicového grafu můžete najednou srovnávat velké množství dat, sledovat změny a trendy v čase, zdůraznit anomálie v sériích dat atd.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě `ChartType.Line`).
1. Získejte přístup k IChartDataWorkbook.
1. Vymažte výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data pro řadu grafu.
1. Uložte upravenou prezentaci do souboru PPTX

Tento JavaScriptový kód vám ukazuje, jak vytvořit spojnicový graf:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ve výchozím nastavení jsou body na spojnicovém grafu spojeny přímými souvislými čarami. Pokud chcete, aby byly body spojeny čárkovanými čarami, můžete specifikovat preferovaný typ čárky takto:

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **Vytváření stromových mapových grafů**

Stromové mapové grafy se nejlépe používají pro prodejní data, když chcete zobrazit relativní velikost kategorií a zároveň rychle upoutat pozornost na položky, které výrazně přispívají k jednotlivým kategoriím. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Kroky:</em> Vytvořit stromový mapový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint stromový mapový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s stromovým mapovým grafem v JavaScriptu</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě [ChartType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartType).TreeMap).
4. Získejte přístup k [ChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data pro řadu grafu.
8. Uložte upravenou prezentaci do souboru PPTX

Tento JavaScriptový kód vám ukazuje, jak vytvořit stromový mapový graf:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // větev 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
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
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření akciových grafů**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Kroky:</em> Vytvořit akciový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint akciový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s akciovým grafem v JavaScriptu</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartType).OpenHighLowClose).
4. Získejte přístup k [ChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data pro řadu grafu.
8. Specifikujte formát HiLowLines.
9. Uložte upravenou prezentaci do souboru PPTX

Ukázkový JavaScriptový kód pro vytvoření akciového grafu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření krabicových a fousových grafů**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Kroky:</em> Vytvořit krabicový a fousový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint krabicový a fousový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s krabicovým a fousovým grafem v JavaScriptu</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartType).BoxAndWhisker).
4. Získejte přístup k [ChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data pro řadu grafu.
8. Uložte upravenou prezentaci do souboru PPTX

Tento JavaScriptový kód vám ukazuje, jak vytvořit krabicový a fousový graf:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
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
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření trychtýřových grafů**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Kroky:</em> Vytvořit trychtýřový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint trychtýřový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s trychtýřovým grafem v JavaScriptu</strong></a>


1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartType).Funnel).
4. Uložte upravenou prezentaci do souboru PPTX

JavaScriptový kód vám ukazuje, jak vytvořit trychtýřový graf:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření slunečních paprskových grafů**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Kroky:</em> Vytvořit sluneční paprskový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint sluneční paprskový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci se slunečním paprskovým grafem v JavaScriptu</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě [ChartType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartType).sunburst).
4. Uložte upravenou prezentaci do souboru PPTX

Tento JavaScriptový kód vám ukazuje, jak vytvořit sluneční paprskový graf:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // větev 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
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
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření histogramových grafů**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Kroky:</em> Vytvořit histogramový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint histogramový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s histogramovým grafem v JavaScriptu</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartType).Histogram).
4. Získejte přístup k [ChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Uložte upravenou prezentaci do souboru PPTX

Tento JavaScriptový kód vám ukazuje, jak vytvořit histogramový graf:

```javascript
var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Vytváření radiových grafů**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Kroky:</em> Vytvořit radiový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint radiový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s radiovým grafem v JavaScriptu</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte referenci na snímek podle jeho indexu. 
3. Přidejte graf s některými daty a specifikujte preferovaný typ grafu (`ChartType.Radar` v tomto případě).
4. Uložte upravenou prezentaci do souboru PPTX

Tento JavaScriptový kód vám ukazuje, jak vytvořit radiový graf:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření grafů s více kategoriemi**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Kroky:</em> Vytvořit graf s více kategoriemi v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint graf s více kategoriemi v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s grafem s více kategoriemi v JavaScriptu</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte referenci na snímek podle jeho indexu. 
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartType).ClusteredColumn).
4. Získejte přístup k [ChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data pro řadu grafu.
8. Uložte upravenou prezentaci do souboru PPTX.

Tento JavaScriptový kód vám ukazuje, jak vytvořit graf s více kategoriemi:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Uložit prezentaci s grafem
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření mapových grafů**

Mapový graf je vizualizace oblasti obsahující data. Mapové grafy se nejlépe používají k porovnání dat nebo hodnot napříč geografickými regiony.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Kroky:</em> Vytvořit mapový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint mapový graf v JavaScriptu</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Kroky:</em> Vytvořit PowerPoint prezentaci s mapovým grafem v JavaScriptu</strong></a>

Tento JavaScriptový kód vám ukazuje, jak vytvořit mapový graf:

```javascript
let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření kombinovaných grafů**

Kombinovaný graf (nebo combo graf) kombinuje dva nebo více typů grafů v jednom diagramu. Tento graf vám umožní zvýraznit, porovnat nebo prozkoumat rozdíly mezi dvěma nebo více datovými sadami, což pomáhá identifikovat vztahy mezi nimi.

![Kombinovaný graf](combination_chart.png)

Následující JavaScriptový kód ukazuje, jak vytvořit výše uvedený kombinovaný graf v PowerPoint prezentaci:

```js
function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Nastavte název grafu.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Nastavte legendu grafu.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Odstraňte výchozí generované řady a kategorie.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Přidejte nové kategorie.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Přidejte první řadu.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Nastavte vodorovnou osu.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Nastavte svislou osu.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Nastavte barvu hlavních mřížek svislé osy.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Nastavte sekundární vodorovnou osu.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Nastavte sekundární svislou osu.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Aktualizace grafů**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Kroky:</em> Aktualizovat PowerPoint graf v JavaScriptu</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Kroky:</em> Aktualizovat graf prezentace v JavaScriptu</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Kroky:</em> Aktualizovat PowerPoint prezentaci s grafem v JavaScriptu</strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation), která představuje prezentaci obsahující graf, který chcete aktualizovat.
2. Získejte referenci na snímek pomocí jeho Indexu.
3. Procházejte všechny tvary a najděte požadovaný graf.
4. Získejte přístup k pracovnímu listu dat grafu.
5. Modifikujte data řady grafu změnou hodnot řad.
6. Přidejte novou řadu a naplňte data v ní.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód vám ukazuje, jak aktualizovat graf:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přístup k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Získat graf s výchozími daty
    var chart = sld.getShapes().get_Item(0);
    // Nastavení indexu listu dat grafu
    var defaultWorksheetIndex = 0;
    // Získání pracovního listu dat grafu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Změna názvu kategorie grafu
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Vzít první řadu grafu
    var series = chart.getChartData().getSeries().get_Item(0);
    // Nyní aktualizace dat řady
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Úprava názvu řady
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Vzít druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);
    // Nyní aktualizace dat řady
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Úprava názvu řady
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Nyní přidání nové řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Vzít třetí řadu grafu
    series = chart.getChartData().getSeries().get_Item(2);
    // Nyní naplňování dat řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Uložit prezentaci s grafem
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení datového rozsahu pro grafy**

Pro nastavení datového rozsahu pro graf postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation), která představuje prezentaci obsahující graf.
2. Získejte referenci na snímek podle jeho indexu.
3. Procházejte všechny tvary a najděte požadovaný graf.
4. Získejte přístup k datům grafu a nastavte rozsah.
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód vám ukazuje, jak nastavit datový rozsah pro graf:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Použití výchozích značek v grafech**
Když použijete výchozí značku v grafech, každá řada grafu získá automaticky odlišný výchozí symbol značky.

Tento JavaScriptový kód vám ukazuje, jak automaticky nastavit značku řady grafu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
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
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Nyní naplňuji data řady
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Jaké typy grafů podporuje Aspose.Slides?**

Aspose.Slides podporuje širokou škálu typů grafů, včetně sloupcových, čárových, výsečových, plochých, rozptylových, histogramových, radiových a mnoha dalších. Tato flexibilita vám umožní vybrat nejvhodnější typ grafu pro potřeby vizualizace vašich dat.

**Jak přidám nový graf do snímku?**

Pro přidání grafu nejprve vytvoříte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) , získáte požadovaný snímek pomocí jeho indexu a poté zavoláte metodu pro přidání grafu, přičemž specifikujete typ grafu a počáteční data. Tento proces integruje graf přímo do vaší prezentace.

**Jak mohu aktualizovat data zobrazená v grafu?**

Data grafu můžete aktualizovat přístupem k jeho pracovnímu listu ([ChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/)), vymazáním výchozích řad a kategorií a následným přidáním vlastních dat. To vám umožní programově obnovit graf tak, aby odrážel nejnovější data.

**Je možné přizpůsobit vzhled grafu?**

Ano, Aspose.Slides poskytuje rozsáhlé možnosti přizpůsobení. Můžete měnit barvy, písma, popisky, legendy a další formátovací prvky tak, aby vzhled grafu odpovídal vašim specifickým návrhovým požadavkům.