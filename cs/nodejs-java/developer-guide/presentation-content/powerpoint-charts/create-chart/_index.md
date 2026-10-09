---
title: Vytvoření nebo aktualizace grafů v PowerPoint prezentacích v JavaScriptu
linktitle: Vytvořit nebo aktualizovat grafy
type: docs
weight: 10
url: /cs/nodejs-java/create-chart/
keywords:
- přidat graf
- vytvořit graf
- upravit graf
- změnit graf
- aktualizovat graf
- bodový graf
- koláčový graf
- čárový graf
- stromový mapový graf
- akciový graf
- krabicový a vousový graf
- trychtýřový graf
- sluneční graf
- histogramový graf
- radarový graf
- vícekategoriální graf
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte grafy v PowerPoint prezentacích pomocí Aspose.Slides pro Node.js. Přidávejte, formátujte a upravujte grafy s praktickými ukázkami kódu v JavaScriptu."
---
## **Přehled**

Tento článek poskytuje komplexní návod, jak vytvořit a přizpůsobit grafy pomocí Aspose.Slides. Naučíte se, jak programově přidat graf na snímek, naplnit jej daty a použít různé možnosti formátování, aby vyhovoval vašim konkrétním požadavkům na design. V celém článku podrobné ukázky kódu ilustrují každý krok, od inicializace prezentace a objektu grafu až po konfiguraci sérií, os a legend. Dodržením tohoto návodu získáte solidní pochopení, jak integrovat dynamické vytváření grafů do vašich aplikací a zjednodušit proces tvorby prezentací založených na datech.

## **Vytvoření grafu**

Grafy pomáhají lidem rychle vizualizovat data a získat poznatky, které z tabulky nebo tabulkového kalkulátoru nemusí být okamžitě patrné.

**Proč vytvářet grafy?**

Používáním grafů můžete:

* agregovat, zhušťovat nebo shrnovat velké množství dat na jediném snímku v prezentaci
* odhalit vzorce a trendy v datech
* odhadnout směr a dynamiku dat v čase nebo vzhledem k určité jednotce měření
* zaznamenat odlehlé hodnoty, anomálie, odchylky, chyby, nesmyslná data apod.
* komunikovat nebo prezentovat složitá data

V PowerPointu můžete grafy vytvářet pomocí funkce *Insert*, která poskytuje šablony pro navrhování mnoha typů grafů. Pomocí Aspose.Slides můžete vytvářet jak běžné grafy (založené na populárních typech), tak vlastní grafy.

{{% alert color="info" title="Poznámka" %}}
Pro vytvoření grafů použijte třídu [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) . Pole v této třídě odpovídají různým typům grafů.
{{% /alert %}}

### **Vytvoření seskupených sloupcových grafů**

Tato sekce vysvětluje, jak vytvořit seskupené sloupcové grafy pomocí Aspose.Slides. Naučíte se inicializovat prezentaci, přidat graf a přizpůsobit jeho prvky, jako jsou název, data, řady, kategorie a stylování. Postupujte podle níže uvedených kroků a uvidíte, jak se vytvoří standardní seskupený sloupcový graf:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s některými daty a určete typ `ChartType.ClusteredColumn` .
1. Přidejte grafu název.
1. Získejte přístup k datové tabulce grafu.
1. Vymažte všechny výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data grafu pro řady.
1. Použijte barvu výplně na řady grafu.
1. Přidejte popisky k řadám grafu.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak vytvořit seskupený sloupcový graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistoupí k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Přidá graf s výchozími daty
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Nastaví název grafu
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // Nastaví první řadu tak, aby zobrazovala hodnoty
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Nastaví index pro list dat grafu
    var defaultWorksheetIndex = 0;
    // Získá list dat grafu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Odstraní výchozí vygenerované řady a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Přidá nové řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Přidá nové kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Získá první řadu grafu
    var series = chart.getChartData().getSeries().get_Item(0);
    // Nyní naplní data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Nastaví barvu výplně pro řadu
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Získá druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);
    // Naplní data řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Nastaví barvu výplně pro řadu
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Vytvoří vlastní popisky pro každou kategorii pro novou řadu
    // Nastaví první popisek tak, aby zobrazoval název kategorie
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

### **Vytvoření bodových grafů**

Bodové grafy (známé také jako scatter plots nebo x‑y grafy) se často používají k ověření vzorců nebo k demonstraci korelací mezi dvěma proměnnými.

Použijte bodový graf, když:

* máte spárovaná číselná data
* máte dvě proměnné, které spolu dobře souvisí
* chcete zjistit, zda jsou dvě proměnné navzájem propojené
* máte nezávislou proměnnou, která má pro závislou proměnnou více hodnot

1. Postupujte podle kroků v [Vytvoření seskupených sloupcových grafů](#create-clustered-column-charts) .
2. Ve třetím kroku přidejte graf s některými daty a určete typ grafu jako jeden z následujících:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Representuje bodový graf._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representuje bodový graf spojený křivkami s datovými značkami._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Representuje bodový graf spojený křivkami bez datových značek._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representuje bodový graf spojený úsečkami s datovými značkami._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Representuje bodový graf spojený úsečkami bez datových značek._

Tento kód JavaScript ukazuje, jak vytvořit bodový graf s různými značkami pro každou řadu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var slide = pres.getSlides().get_Item(0);
    // Vytvoří výchozí graf
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Získá index výchozího listu dat grafu
    var defaultWorksheetIndex = 0;
    // Získá list dat grafu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Odstraní demonstrační řady
    chart.getChartData().getSeries().clear();
    // Přidá nové řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Získá první řadu grafu
    var series = chart.getChartData().getSeries().get_Item(0);
    // Přidá nový bod (1:3) do řady
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Přidá nový bod (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Změní typ řady
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Změní značku řady grafu
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Získá druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);
    // Přidá nový bod (5:2) zde
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Přidá nový bod (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Přidá nový bod (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Přidá nový bod (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Změní značku řady grafu
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytvoření koláčových grafů**

Koláčové grafy jsou nejvhodnější pro zobrazení vztahu část‑celku v datech, zejména když data obsahují kategoriální štítky s číselnými hodnotami. Pokud však vaše data obsahují mnoho částí nebo štítků, může být vhodnější použít sloupcový graf.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.Pie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Pie) .
4. Získejte přístup k sešitu dat grafu [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady.
8. Přidejte nové body do grafu a aplikujte vlastní barvy na sektory koláčového grafu.
9. Nastavte popisky pro řady.
10. Povolit čáry ukazatele (leader lines) pro popisky řad.
11. Nastavte úhel rotace pro sektory koláčového grafu.
12. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak vytvořit koláčový graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Přistupuje k prvnímu snímku
    var slides = pres.getSlides().get_Item(0);
    // Přidá graf s výchozími daty
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Nastaví název grafu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Nastaví první řadu, aby zobrazovala hodnoty
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Nastaví index listu dat grafu
    var defaultWorksheetIndex = 0;
    // Získá list dat grafu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Odstraní výchozí vygenerované řady a kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Přidá nové kategorie
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Přidá nové řady
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Naplní data řady
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Nepracuje v nové verzi
    // Přidání nových bodů a nastavení barvy sektoru
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Nastaví okraj sektoru
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Nastaví okraj sektoru
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Nastaví okraj sektoru
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // Vytvoří vlastní popisky pro každou kategorii nové řady
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
    // Nastaví úhel rotace pro sektory koláčového grafu
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Uloží prezentaci s grafem
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytvoření čárových grafů**

Čárové grafy (známé také jako line graphs) jsou nejvhodnější v situacích, kdy chcete zobrazit změny hodnot v čase. Pomocí čárového grafu můžete najednou porovnat velké množství dat, sledovat změny a trendy v čase, zvýraznit anomálie v řadách a další.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a určete typ [ChartType.Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Line) .
1. Získejte přístup k sešitu dat grafu ([ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/)) .
1. Vymažte výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data grafu pro řady.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak vytvořit čárový graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Ve výchozím nastavení jsou body v čárovém grafu spojeny přímými souvislými čarami. Pokud chcete, aby byly body spojeny čárkovanými čarami, můžete specifikovat preferovaný typ čáry následujícím způsobem:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytvoření stromových mapových grafů**

Stromové mapové grafy jsou nejvhodnější pro prodejní data, když chcete zobrazit relativní velikost datových kategorií a rychle upoutat pozornost na položky, které jsou velkými přispěvateli v rámci každé kategorie.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.Treemap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Treemap) .
4. Získejte přístup k sešitu dat grafu [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak vytvořit stromový mapový graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Vytvoření akciových grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#OpenHighLowClose) .
4. Získejte přístup k sešitu dat grafu [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady.
8. Specifikujte formát čar vysokých‑nízkých (high‑low) .
9. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak vytvořit akciový graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
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

### **Vytvoření krabicových a vousových grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#BoxAndWhisker) .
4. Získejte přístup k sešitu dat grafu [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak vytvořit krabicový a vousový graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Vytvoření trychtýřových grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.Funnel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Funnel) .
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak vytvořit trychtýřový graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Vytvoření slunečních grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.Sunburst](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Sunburst) .
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak vytvořit sluneční graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Vytvoření histogramových grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.Histogram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Histogram) .
4. Získejte přístup k sešitu dat grafu [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak vytvořit histogramový graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Vytvoření radarových grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s některými daty a určete preferovaný typ grafu ([ChartType.Radar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#Radar) v tomto případě) .
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak vytvořit radarový graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Vytvoření vícekategoriálních grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a určete typ [ChartType.ClusteredColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ClusteredColumn) .
4. Získejte přístup k sešitu dat grafu [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak vytvořit vícekategoriální graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
    // Přidání řad
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Uložení prezentace s grafem
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytvoření mapových grafů**

Mapové grafy vizualizují geografická data a pomáhají porovnávat hodnoty mezi regiony.

Tento kód JavaScript ukazuje, jak vytvořit mapový graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Vytvoření kombinovaných grafů**

Kombinovaný graf (nebo combo graf) kombinuje dva nebo více typů grafů v jednom diagramu. Tento graf vám umožní zvýraznit, porovnat nebo prozkoumat rozdíly mezi dvěma nebo více datovými sadami, což vám pomůže identifikovat vztahy mezi nimi.

![Kombinovaný graf](combination_chart.png)

Následující kód JavaScript ukazuje, jak vytvořit výše uvedený kombinovaný graf v PowerPoint prezentaci:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

    // Nastaví název grafu.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Nastaví legendu grafu.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Odstraní výchozí vygenerované řady a kategorie.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Přidá nové kategorie.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Přidá první řadu.
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
    // Nastaví vodorovnou osu.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Nastaví svislou osu.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Nastaví barvu hlavních mřížkových čar svislé osy.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Nastaví sekundární vodorovnou osu.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Nastaví sekundární svislou osu.
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

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) představující prezentaci, která obsahuje graf, který chcete aktualizovat.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Projděte všechny tvary a najděte požadovaný graf.
4. Získejte přístup k datové tabulce grafu.
5. Modifikujte řady dat grafu změnou hodnot řad.
6. Přidejte novou řadu a naplňte ji daty.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak aktualizovat graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Přístup k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Získání grafu s výchozími daty
    var chart = sld.getShapes().get_Item(0);
    // Nastavení indexu listu dat grafu
    var defaultWorksheetIndex = 0;
    // Získání pracovního listu dat grafu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Změna názvu kategorie grafu
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Vezmout první řadu grafu
    var series = chart.getChartData().getSeries().get_Item(0);
    // Nyní aktualizace dat řady
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Změna názvu řady
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Vezmout druhou řadu grafu
    series = chart.getChartData().getSeries().get_Item(1);
    // Nyní aktualizace dat řady
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Změna názvu řady
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Nyní přidání nové řady
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Vezmout třetí řadu grafu
    series = chart.getChartData().getSeries().get_Item(2);
    // Nyní naplňování dat řady
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Uložení prezentace s grafem
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení rozsahu dat pro graf**

Chcete‑li zjistit rozsah, který již používá existující graf, podívejte se na [Získání rozsahu dat grafu](/slides/cs/nodejs-java/chart-workbook/#retrieve-a-charts-data-range) .

Pro nastavení rozsahu dat pro graf postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) představující prezentaci, která obsahuje graf.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Projděte všechny tvary a najděte požadovaný graf.
4. Získejte přístup k datům grafu a nastavte rozsah.
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento kód JavaScript ukazuje, jak nastavit rozsah dat pro graf:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
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

Když použijete výchozí značky v grafech, každá řada grafu automaticky získá jiný symbol značky.

Tento kód JavaScript ukazuje, jak automaticky nastavit značku řady grafu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **FAQ**

**Jaké typy grafů jsou podporovány v Aspose.Slides?**

Aspose.Slides podporuje širokou škálu [typů grafů](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/), včetně sloupcových, čárových, koláčových, plošných, bodových, histogramových, radarových a mnoha dalších. Tato flexibilita vám umožní vybrat nejvhodnější typ grafu pro potřeby vizualizace vašich dat.

**Jak přidám nový graf na snímek?**

Nejprve vytvoříte instanci třídy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) , načtete požadovaný snímek pomocí jeho indexu a poté zavoláte metodu pro přidání grafu, přičemž určíte typ grafu a počáteční data. Tento proces integruje graf přímo do vaší prezentace.

**Jak mohu aktualizovat data zobrazovaná v grafu?**

Data grafu můžete aktualizovat tak, že získáte přístup k jeho sešitu dat ([ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/)), vymažete jakékoli výchozí řady a kategorie a poté přidáte vlastní data. To vám umožní programově obnovit graf tak, aby odrážel nejnovější data.

**Je možné přizpůsobit vzhled grafu?**

Ano, Aspose.Slides poskytuje rozsáhlé možnosti přizpůsobení. Můžete měnit barvy, písma, popisky, legendy a další [formátovací prvky](/slides/cs/nodejs-java/chart-entities/) tak, aby vzhled grafu odpovídal vašim konkrétním požadavkům na design.