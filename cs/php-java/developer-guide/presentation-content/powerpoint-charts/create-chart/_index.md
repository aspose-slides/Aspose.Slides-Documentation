---
title: Vytvoření nebo aktualizace grafů v PowerPoint prezentacích v PHP
linktitle: Vytvořit nebo aktualizovat grafy
type: docs
weight: 10
url: /cs/php-java/create-chart/
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
- krabicový a fousový graf
- trychový graf
- sluneční diagram
- histogram
- radarový graf
- vícekategoriální graf
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte grafy v PowerPoint prezentacích pomocí Aspose.Slides pro PHP přes Java. Přidávejte, formátujte a upravujte grafy s praktickými ukázkami kódu."
---
## **Přehled**

Tento článek poskytuje komplexní průvodce, jak vytvářet a přizpůsobovat grafy pomocí Aspose.Slides. Naučíte se, jak programově přidat graf do snímku, naplnit jej daty a použít různé možnosti formátování, aby odpovídaly vašim konkrétním návrhovým požadavkům. V celém článku podrobné ukázky kódu ilustrují každý krok, od inicializace prezentace a objektu grafu po konfiguraci řad, os a legend. Dodržením tohoto průvodce získáte solidní pochopení integrace dynamického generování grafů do vašich aplikací a zjednodušíte proces vytváření prezentací založených na datech.

## **Vytvořit graf**

Grafy pomáhají lidem rychle vizualizovat data a získat poznatky, které nemusí být okamžitě patrné z tabulky nebo tabulkového procesoru. 

**Proč vytvářet grafy?**

Používáním grafů můžete

* agregovat, zhušťovat nebo sumarizovat velké množství dat na jediném snímku v prezentaci
* odhalovat vzory a trendy v datech
* určit směr a dynamiku dat v čase nebo vzhledem k určité jednotce měření 
* odhalovat odlehlé hodnoty, odchylky, chyby, nesmyslná data atd. 
* komunikovat nebo prezentovat složitá data

V PowerPointu můžete vytvářet grafy pomocí funkce vložení, která poskytuje šablony používané k návrhu mnoha typů grafů. Pomocí Aspose.Slides můžete vytvářet běžné grafy (založené na populárních typech grafů) i vlastní grafy. 

{{% alert color="primary" %}} 

Pro vytvoření grafů poskytuje Aspose.Slides třídu [ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ChartType). Pole v této třídě odpovídají různým typům grafů.

{{% /alert %}} 

### **Vytvořit běžné grafy**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Steps:</em> Create PowerPoint Chart </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Steps:</em> Create Presentation Chart </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Chart </strong></a>

_Code Steps:_

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s některými daty a specifikujte požadovaný typ grafu. 
4. Přidejte nadpis pro graf. 
5. Přistupte k listu dat grafu. 
6. Vymažte všechny výchozí řady a kategorie. 
7. Přidejte nové řady a kategorie. 
8. Přidejte nová data do řady grafu. 
9. Přidejte barvu výplně pro řadu grafu. 
10. Přidejte popisky pro řadu grafu. 
11. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak vytvořit běžný graf:

```php
  # Instancuje třídu prezentace, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Přidá graf s jeho výchozími daty
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Nastaví název grafu
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Nastaví první řadu, aby zobrazovala hodnoty
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Nastaví index pro list dat grafu
    $defaultWorksheetIndex = 0;
    # Získá list dat grafu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Smaže výchozí vygenerované řady a kategorie
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Přidá nové řady
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Přidá nové kategorie
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Vezme první řadu grafu
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Nyní naplní data řady
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Nastaví barvu výplně pro řadu
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Vezme druhou řadu grafu
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Naplní data řady
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Nastaví barvu výplně pro řadu
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Vytvoří vlastní popisky pro každou kategorii nové řady
    # Nastaví první popisek, aby zobrazoval název kategorie
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Zobrazí hodnotu pro třetí popisek
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Uloží prezentaci s grafem
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvořit rozptylové grafy**
Rozptylové grafy (také známé jako rozptylové diagramy nebo grafy x‑y) se často používají k ověření vzorů nebo demonstraci korelací mezi dvěma proměnnými. 

Můžete chtít použít rozptylový graf, když 

* máte spárovaná číselná data
* máte 2 proměnné, které spolu dobře souvisejí
* chcete zjistit, zda jsou 2 proměnné navzájem spojené
* máte nezávislou proměnnou, která má pro závislou proměnnou více hodnot

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Steps:</em> Create Scattered Chart </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Steps:</em> Create PowerPoint Scattered Chart </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Scattered Chart </strong></a>

1. Postupujte podle kroků uvedených výše v sekci [Creating Normal Charts](#creating-normal-charts)
2. Ve třetím kroku přidejte graf s některými daty a jako typ uveďte jeden z následujících
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Reprezentuje rozptylový graf s značkami._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Reprezentuje rozptylový graf spojený křivkami, se značkami dat._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Reprezentuje rozptylový graf spojený křivkami, bez značek dat._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Reprezentuje rozptylový graf spojený přímkami, se značkami dat._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Reprezentuje rozptylový graf spojený přímkami, bez značek dat._

Tento PHP kód ukazuje, jak vytvořit rozptylové grafy s různými sériemi značek:

```php
  # Instancuje třídu prezentace, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje k prvnímu snímku
    $slide = $pres->getSlides()->get_Item(0);
    # Vytvoří výchozí graf
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Získá index výchozího listu dat grafu
    $defaultWorksheetIndex = 0;
    # Získá list dat grafu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Smaže ukázkovou řadu
    $chart->getChartData()->getSeries()->clear();
    # Přidá nové řady
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Vezme první řadu grafu
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Přidá nový bod (1:3) do řady
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Přidá nový bod (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Změní typ řady
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Změní značku řady grafu
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Vezme druhou řadu grafu
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Přidá nový bod (5:2) tam
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Přidá nový bod (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Přidá nový bod (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Přidá nový bod (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Změní značku řady grafu
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvořit koláčové grafy**

Koláčové grafy jsou nejvhodnější pro zobrazení vztahu část‑celku v datech, zejména když data obsahují kategoriální štítky s číselnými hodnotami. Pokud však vaše data obsahují mnoho částí nebo štítků, můžete zvážit místo toho sloupcový graf.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Steps:</em> Create Pie Chart </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Steps:</em> Create PowerPoint Pie Chart </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Pie Chart </strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě [ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ChartType).Pie).
4. Přistupte k [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data pro řady grafu.
8. Přidejte nové body pro graf a vlastní barvy pro sektory koláčového grafu.
9. Nastavte popisky pro řady.
10. Nastavte vodící čáry pro popisky řad.
11. Nastavte úhel otočení pro snímky koláčového grafu.
12. Uložte upravenou prezentaci do souboru PPTX.

Tento PHP kód ukazuje, jak vytvořit koláčový graf:

```php
  # Instancuje třídu prezentace, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje k prvnímu snímku
    $slides = $pres->getSlides()->get_Item(0);
    # Přidá graf s výchozími daty
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Nastaví název grafu
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Nastaví první řadu, aby zobrazovala hodnoty
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Nastaví index pro list dat grafu
    $defaultWorksheetIndex = 0;
    # Získá list dat grafu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Smaže výchozí vygenerované řady a kategorie
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Přidá nové kategorie
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Přidá nové řady
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Naplní data řady
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Nepracuje v nové verzi
    # Adding new points and setting sector color
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Nastaví okraj sektoru
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Nastaví okraj sektoru
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Nastaví okraj sektoru
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Vytvoří vlastní popisky pro každou kategorii nové řady
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # Zobrazí vodící čáry pro graf
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Nastaví úhel otočení pro sektory koláčového grafu
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Uloží prezentaci s grafem
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvořit čárové grafy**

Čárové grafy (také známé jako čárové diagramy) jsou nejvhodnější v situacích, kdy chcete ukázat změny hodnot v čase. Pomocí čárového grafu můžete najednou porovnat mnoho dat, sledovat změny a trendy v čase, zvýraznit anomálie v sériích dat apod.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě `ChartType::Line`).
1. Přistupte k datům grafu pomocí IChartDataWorkbook.
1. Vymažte výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data pro řady grafu.
1. Uložte upravenou prezentaci do souboru PPTX.

Tento PHP kód ukazuje, jak vytvořit čárový graf:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ve výchozím nastavení jsou body v čárovém grafu spojeny přímými spojnicemi. Pokud chcete, aby byly body spojeny čárkami, můžete tak učinit následujícím způsobem:

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **Vytvořit stromové mapy**

Stromové mapy jsou nejvhodnější pro prodejní data, když chcete zobrazit relativní velikost kategorií a zároveň rychle upozornit na položky, které jsou velkými přispěvateli do každé kategorie. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Steps:</em> Create Tree Map Chart </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Steps:</em> Create PowerPoint Tree Map Chart </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Tree Map Chart </strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě [ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ChartType).TreeMap).
4. Přistupte k [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data pro řady grafu.
8. Uložte upravenou prezentaci do souboru PPTX

Tento PHP kód ukazuje, jak vytvořit stromovou mapu:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # větev 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # větev 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvořit akciové grafy**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Steps:</em> Create Stock Chart </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Steps:</em> Create PowerPoint Stock Chart </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Stock Chart </strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ChartType).OpenHighLowClose).
4. Přistupte k [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data pro řady grafu.
8. Specifikujte formát HiLowLines.
9. Uložte upravenou prezentaci do souboru PPTX

Ukázkový PHP kód pro vytvoření akciového grafu:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvořit krabicové a fousové grafy**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Steps:</em> Create Box and Whisker Chart </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Steps:</em> Create PowerPoint Box and Whisker Chart </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Box and Whisker Chart </strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ChartType).BoxAndWhisker).
4. Přistupte k [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data pro řady grafu.
8. Uložte upravenou prezentaci do souboru PPTX

Tento PHP kód ukazuje, jak vytvořit krabicový a fousový graf:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvořit trychové grafy**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Steps:</em> Create Funnel Chart </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Steps:</em> Create PowerPoint Funnel Chart </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Funnel Chart </strong></a>


1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ChartType).Funnel).
4. Uložte upravenou prezentaci do souboru PPTX

PHP kód ukazuje, jak vytvořit trychový graf:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvořit sluneční grafy**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Steps:</em> Create Sunburst Chart </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Steps:</em> Create PowerPoint Sunburst Chart </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Sunburst Chart </strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě[ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ChartType).sunburst).
4. Uložte upravenou prezentaci do souboru PPTX

Tento PHP kód ukazuje, jak vytvořit sluneční graf:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # větev 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # větev 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvořit histogramové grafy**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Steps:</em> Create Histogram Chart </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Steps:</em> Create PowerPoint Histogram Chart </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Histogram Chart </strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ChartType).Histogram).
4. Přistupte k [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Uložte upravenou prezentaci do souboru PPTX

Tento PHP kód ukazuje, jak vytvořit histogramový graf:

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **Vytvořit radarové grafy**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Steps:</em> Create Radar Chart </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Steps:</em> Create PowerPoint Radar Chart </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Radar Chart </strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu. 
3. Přidejte graf s některými daty a specifikujte požadovaný typ grafu (`ChartType::Radar`).
4. Uložte upravenou prezentaci do souboru PPTX

Tento PHP kód ukazuje, jak vytvořit radarový graf:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvořit vícekategoriální grafy**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Steps:</em> Create Multi Category Chart </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Steps:</em> Create PowerPoint Multi Category Chart </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Multi Category Chart </strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) .
2. Získejte odkaz na snímek podle jeho indexu. 
3. Přidejte graf s výchozími daty a požadovaným typem ([ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ChartType).ClusteredColumn).
4. Přistupte k [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/).
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data pro řady grafu.
8. Uložte upravenou prezentaci do souboru PPTX.

Tento PHP kód ukazuje, jak vytvořit vícekategoriální graf:

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # Přidání řad
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Uložit prezentaci s grafem
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvořit mapové grafy**

Mapový graf je vizualizace oblasti obsahující data. Mapové grafy jsou nejvhodnější pro porovnávání dat nebo hodnot napříč geografickými regiony.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Steps:</em> Create Map Chart </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Steps:</em> Create PowerPoint Map Chart </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Map Chart </strong></a>

Tento PHP kód ukazuje, jak vytvořit mapový graf:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvořit kombinované grafy**

Kombinovaný graf (nebo combo graf) spojuje dva nebo více typů grafů v jednom diagramu. Tento graf vám umožní zvýraznit, porovnat nebo zkoumat rozdíly mezi dvěma nebo více datovými sadami, což vám pomůže identifikovat vztahy mezi nimi.

![The combination chart](combination_chart.png)

Následující PHP kód ukazuje, jak vytvořit kombinovaný graf zobrazený výše v PowerPoint prezentaci:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Nastavit název grafu.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Nastavit legendu grafu.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Smazat výchozí vygenerované řady a kategorie.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Přidat nové kategorie.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Přidat první řadu.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // Nastavit vodorovnou osu.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Nastavit svislou osu.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Nastavit barvu hlavních mřížkových čar svislé osy.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Nastavit sekundární vodorovnou osu.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Nastavit sekundární svislou osu.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **Aktualizovat grafy**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Steps:</em> Update PowerPoint Chart </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Steps:</em> Update Presentation Chart </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Steps:</em> Update PowerPoint Presentation Chart </strong></a>

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation), která představuje prezentaci obsahující graf, který chcete aktualizovat.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Projděte všechny tvary a najděte požadovaný graf.
4. Přistupte k listu dat grafu.
5. Modifikujte data řady grafu změnou hodnot řad.
6. Přidejte novou řadu a naplňte ji daty.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak aktualizovat graf:

```php
  $pres = new Presentation();
  try {
    # Přístup k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Získání grafu s výchozími daty
    $chart = $sld->getShapes()->get_Item(0);
    # Nastavení indexu listu dat grafu
    $defaultWorksheetIndex = 0;
    # Získání listu dat grafu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Změna názvu kategorie grafu
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Vybrání první řady grafu
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Nyní aktualizace dat řady
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Modifikace názvu řady

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Vybrání druhé řady grafu
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Nyní aktualizace dat řady
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Modifikace názvu řady

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Nyní přidání nové řady
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Vybrání třetí řady grafu
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Nyní naplňování dat řady
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Uložení prezentace s grafem
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavit rozsah dat pro graf**

Pro nastavení rozsahu dat pro graf postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation), která představuje prezentaci obsahující graf.
2. Získejte odkaz na snímek podle jeho indexu.
3. Projděte všechny tvary a najděte požadovaný graf.
4. Přistupte k datům grafu a nastavte rozsah.
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak nastavit rozsah dat pro graf:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Používat výchozí značky v grafech**
Když použijete výchozí značku v grafech, každá řada grafu získá automaticky jiný výchozí symbol značky.

Tento PHP kód ukazuje, jak automaticky nastavit značku řady grafu:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # Vyberte druhou řadu grafu
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Nyní naplňování dat řady
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Jaké typy grafů podporuje Aspose.Slides?**

Aspose.Slides podporuje širokou škálu [typů grafů](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/), včetně sloupcových, čárových, koláčových, plošných, rozptylových, histogramových, radarových a mnoha dalších. Tato flexibilita vám umožňuje vybrat nejvhodnější typ grafu pro vaše potřeby vizualizace dat.

**Jak přidám nový graf do snímku?**

Pro přidání grafu nejprve vytvoříte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) , načtete požadovaný snímek podle jeho indexu a poté zavoláte metodu pro přidání grafu, kde specifikujete typ grafu a počáteční data. Tento proces integruje graf přímo do vaší prezentace.

**Jak mohu aktualizovat data zobrazovaná v grafu?**

Data grafu můžete aktualizovat přístupem k jeho sešitu dat ([ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/)), vymazáním výchozích řad a kategorií a následným přidáním vlastních dat. To vám umožní obnovit graf tak, aby odrážel nejnovější data.

**Je možné přizpůsobit vzhled grafu?**

Ano, Aspose.Slides poskytuje rozsáhlé možnosti přizpůsobení. Můžete měnit barvy, písma, popisky, legendy a další [formatting elements](/slides/cs/php-java/chart-entities/), aby vzhled grafu odpovídal vašim konkrétním návrhovým požadavkům.