---
title: Vytvoření nebo aktualizace grafů PowerPoint prezentace v PHP
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
- čarový graf
- graf stromové mapy
- akciový graf
- krabicový a fousový graf
- trychtýřový graf
- sluneční graf
- histogram
- radarový graf
- vícekategoriový graf
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: Vytvářejte a přizpůsobujte grafy v PowerPoint prezentacích pomocí Aspose.Slides pro PHP přes Java. Přidávejte, formátujte a upravujte grafy s praktickými ukázkami kódu.
---
## **Přehled**

Tento článek poskytuje komplexní průvodce, jak vytvořit a přizpůsobit grafy pomocí Aspose.Slides. Naučíte se, jak programově přidat graf do snímku, naplnit jej daty a použít různé možnosti formátování tak, aby odpovídal vašim konkrétním návrhovým požadavkům. V celém článku jsou podrobné ukázky kódu, které ilustrují každý krok, od inicializace prezentace a objektu grafu až po konfiguraci řad, os a legend. Dodržováním tohoto návodu získáte pevné pochopení toho, jak integrovat dynamické generování grafů do vašich aplikací a zjednodušit proces vytváření prezentací založených na datech.

## **Vytvoření grafu**

Grafy pomáhají lidem rychle vizualizovat data a získat poznatky, které z tabulky nebo tabulkového procesoru nemusí být okamžitě zřejmé.

**Proč vytvářet grafy?**

Pomocí grafů můžete:

* agregovat, zkrátit nebo shrnout velké množství dat na jediném snímku v prezentaci
* odhalit vzory a trendy v datech
* odvodit směr a dynamiku dat v čase nebo vzhledem k určité měrné jednotce
* identifikovat odlehlé hodnoty, anomálie, odchylky, chyby, nesmyslná data apod.
* komunikovat nebo prezentovat složitá data

V PowerPointu můžete grafy vytvořit pomocí funkce *Insert*, která poskytuje šablony pro navrhování mnoha typů grafů. Pomocí Aspose.Slides můžete vytvářet jak běžné grafy (založené na populárních typech grafů), tak vlastní grafy.

{{% alert color="info" title="Poznámka" %}}
Pro vytváření grafů použijte třídu [ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/). Pole v této třídě odpovídají různým typům grafů.
{{% /alert %}}

### **Vytvoření sloupcových grafů se seskupením**

Tato část vysvětluje, jak vytvořit sloupcové grafy se seskupením pomocí Aspose.Slides. Naučíte se inicializovat prezentaci, přidat graf a přizpůsobit jeho prvky, jako je název, data, řady, kategorie a stylování. Postupujte podle níže uvedených kroků a uvidíte, jak je generován standardní sloupcový graf se seskupením:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s některými daty a specifikujte typ `ChartType::ClusteredColumn` .
1. Přidejte název grafu.
1. Přistupte k datovému listu grafu.
1. Vymažte všechny výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data grafu pro řady grafu.
1. Použijte barvu výplně na řady grafu.
1. Přidejte popisky k řadám grafu.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit sloupcový graf se seskupením:

```php
  # Vytvoří instanci třídy prezentace, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Přidá graf s výchozími daty
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Nastaví název grafu
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Nastaví první řadu, aby zobrazovala hodnoty
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Nastaví index pro list s daty grafu
    $defaultWorksheetIndex = 0;
    # Získá list s daty grafu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Smaže výchozí generované řady a kategorie
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
    # Nyní vyplní data řady
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Nastaví barvu výplně pro řadu
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Vezme druhou řadu grafu
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Vyplní data řady
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Nastaví barvu výplně pro řadu
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Vytvoří vlastní štítky pro každou kategorii pro novou řadu
    # Nastaví první štítek, aby zobrazoval název kategorie
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Zobrazí hodnotu pro třetí štítek
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

### **Vytvoření rozptylových grafů**

Rozptylové grafy (také známé jako scatter ploty nebo x‑y grafy) se často používají k ověření vzorů nebo demonstraci korelací mezi dvěma proměnnými.

Použijte rozptylový graf, když:

* máte spárovaná číselná data
* máte dvě proměnné, které spolu dobře souvisejí
* chcete zjistit, zda jsou dvě proměnné navzájem související
* máte nezávislou proměnnou, která má pro závislou proměnnou více hodnot

1. Postupujte podle kroků v sekci [Create Clustered Column Charts](#create-clustered-column-charts) .
2. Pro třetí krok přidejte graf s některými daty a jako typ grafu zvolte jeden z následujících:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Reprezentuje rozptylový graf s značkami._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Reprezentuje rozptylový graf spojený křivkami se značkami._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Reprezentuje rozptylový graf spojený křivkami bez značek._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Reprezentuje rozptylový graf spojený úsečkami se značkami._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Reprezentuje rozptylový graf spojený úsečkami bez značek._

Tento PHP kód ukazuje, jak vytvořit rozptylový graf s různými značkami pro každou řadu:

```php
  # Vytvoří instanci třídy prezentace, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Přistupuje k prvnímu snímku
    $slide = $pres->getSlides()->get_Item(0);
    # Vytvoří výchozí graf
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Získá index výchozího listu s daty grafu
    $defaultWorksheetIndex = 0;
    # Získá list s daty grafu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Smaže demonstrační řadu
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

### **Vytvoření koláčových grafů**

Koláčové grafy jsou nejvhodnější pro zobrazení vztahu část‑celku v datech, zejména když data obsahují kategoriální štítky s číselnými hodnotami. Pokud však vaše data obsahují mnoho částí nebo štítků, zvažte místo toho sloupcový graf.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType::Pie](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#Pie) .
4. Přistupte k sešitu s daty grafu [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady grafu.
8. Přidejte nové body do grafu a použijte vlastní barvy pro sektory koláčového grafu.
9. Nastavte popisky pro řady.
10. Povolení čar vedoucích k popiskům řad.
11. Nastavte úhel otočení pro sektory koláčového grafu.
12. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak vytvořit koláčový graf:

```php
  # Vytvoří instanci třídy prezentace, která představuje soubor PPTX
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
    # Nastaví index pro list s daty grafu
    $defaultWorksheetIndex = 0;
    # Získá list s daty grafu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Smaže výchozí generované řady a kategorie
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Přidá nové kategorie
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Přidá nové řady
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Vyplní data řady
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Nefunguje v nové verzi
    # Přidává nové body a nastavuje barvu sektoru
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
    # Vytvoří vlastní štítky pro každou kategorii pro novou řadu
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
    # Zobrazí řídící čáry pro graf
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

### **Vytvoření čarových grafů**

Čarové grafy (také známé jako čárové diagramy) jsou nejvhodnější v situacích, kdy chcete ukázat změny hodnot v čase. Pomocí čarového grafu můžete najednou porovnat velké množství dat, sledovat změny a trendy v čase, zvýraznit anomálie v řadách dat a další.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a specifikujte typ [ChartType::Line](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#Line) .
1. Přistupte k sešitu s daty grafu ([ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/)) .
1. Vymažte výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data grafu pro řady grafu.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak vytvořit čarový graf:

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

Ve výchozím nastavení jsou body v čarovém grafu spojeny rovným spojitým spojením. Pokud chcete, aby byly body spojeny pomlčkami, můžete určit preferovaný typ čáry následovně:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvoření grafů stromových map**

Grafy stromových map jsou nejvhodnější pro prodejní data, kdy chcete zobrazit relativní velikost kategorií a rychle upozornit na položky, které jsou velkými přispěvateli v rámci každé kategorie.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType::Treemap](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#Treemap) .
4. Přistupte k sešitu s daty grafu [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak vytvořit graf stromové mapy:

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

### **Vytvoření akciových grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#OpenHighLowClose) .
4. Přistupte k sešitu s daty grafu [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady grafu.
8. Specifikujte formát čar high‑low.
9. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak vytvořit akciový graf:

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
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvoření krabicových a whisker grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#BoxAndWhisker) .
4. Přistupte k sešitu s daty grafu [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak vytvořit krabicový a whisker graf:

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

### **Vytvoření trychytých grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType::Funnel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#Funnel) .
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak vytvořit trychtýřový graf:

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

### **Vytvoření slunečních grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType::Sunburst](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#Sunburst) .
4. Uložte upravenou prezentaci jako soubor PPTX.

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

### **Vytvoření histogramových grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType::Histogram](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#Histogram) .
4. Přistupte k sešitu s daty grafu [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Uložte upravenou prezentaci jako soubor PPTX.

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

### **Vytvoření radiálních grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s některými daty a specifikujte preferovaný typ grafu ([ChartType::Radar](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#Radar) v tomto případě) .
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak vytvořit radiální graf:

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

### **Vytvoření více‑kategoriových grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ [ChartType::ClusteredColumn](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/#ClusteredColumn) .
4. Přistupte k sešitu s daty grafu [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/) .
5. Vymažte výchozí řady a kategorie.
6. Přidejte nové řady a kategorie.
7. Přidejte nová data grafu pro řady grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak vytvořit více‑kategoriový graf:

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
    # Uložení prezentace s grafem
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Vytvoření mapových grafů**

Mapové grafy vizualizují geografická data a pomáhají porovnávat hodnoty napříč regiony.

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

### **Vytvoření kombinovaných grafů**

Kombinovaný graf (nebo combo graf) kombinuje dva nebo více typů grafů v jednom diagramu. Tento graf vám umožní zvýraznit, porovnat nebo analyzovat rozdíly mezi dvěma nebo více datovými sadami a pomůže vám identifikovat vztahy mezi nimi.

![Kombinovaný graf](combination_chart.png)

Následující PHP kód ukazuje, jak vytvořit kombinovaný graf zobrazený výše v prezentaci PowerPoint:

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

    // Smazat výchozí generované řady a kategorie.
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

## **Aktualizace grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) představující prezentaci obsahující graf, který chcete aktualizovat.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Projděte všechny tvary a najděte požadovaný graf.
4. Přistupte k listu dat grafu.
5. Modifikujte řady dat grafu změnou jejich hodnot.
6. Přidejte novou řadu a vyplňte její data.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak aktualizovat graf:

```php
  $pres = new Presentation();
  try {
    # Přístup k prvnímu snímku
    $sld = $pres->getSlides()->get_Item(0);
    # Získat graf s výchozími daty
    $chart = $sld->getShapes()->get_Item(0);
    # Nastavení indexu listu s daty grafu
    $defaultWorksheetIndex = 0;
    # Získání listu s daty grafu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Změna názvu kategorie grafu
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Vyberte první řadu grafu
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Nyní aktualizujeme data řady
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Úprava názvu řady

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Vezměte druhou řadu grafu
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Nyní aktualizujeme data řady
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Úprava názvu řady

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Nyní přidáváme novou řadu
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Vezměte třetí řadu grafu
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Nyní vyplňujeme data řady
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

## **Nastavení datového rozsahu pro graf**

Pro nastavení datového rozsahu grafu postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) představující prezentaci obsahující graf.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Projděte všechny tvary a najděte požadovaný graf.
4. Přistupte k datům grafu a nastavte rozsah.
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód ukazuje, jak nastavit datový rozsah pro graf:

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

## **Použití výchozích značek v grafech**

Když používáte výchozí značky v grafech, každá řada grafu automaticky získá jiný symbol značky.

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
    # Vezměte druhou řadu grafu
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Nyní vyplňujeme data řady
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

Aspose.Slides podporuje širokou škálu [chart types](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/), včetně sloupcových, čarových, koláčových, oblastních, rozptylových, histogramových, radiálních a mnoha dalších. Tato flexibilita vám umožní vybrat nejvhodnější typ grafu pro vaše potřeby vizualizace dat.

**Jak přidám nový graf na snímek?**

Pro přidání grafu nejprve vytvoříte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) , získáte požadovaný snímek pomocí jeho indexu a následně zavoláte metodu pro přidání grafu, kde specifikujete typ grafu a počáteční data. Tento proces integruje graf přímo do vaší prezentace.

**Jak mohu aktualizovat data zobrazovaná v grafu?**

Data grafu můžete aktualizovat tím, že přistoupíte k jeho sešitu dat ([ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/)), vymažete výchozí řady a kategorie a poté přidáte vlastní data. Tím můžete graf osvěžit tak, aby odrážel nejnovější informace.

**Je možné přizpůsobit vzhled grafu?**

Ano, Aspose.Slides poskytuje rozsáhlé možnosti přizpůsobení. Můžete měnit barvy, písma, popisky, legendy a další [formatting elements](/slides/cs/php-java/chart-entities/) tak, aby vzhled grafu odpovídal vašim konkrétním návrhovým požadavkům.