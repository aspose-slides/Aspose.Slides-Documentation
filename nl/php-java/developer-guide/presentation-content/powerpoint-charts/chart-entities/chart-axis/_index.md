---
title: Grafiekassen aanpassen in presentaties met PHP
linktitle: Grafiekas
type: docs
url: /nl/php-java/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as-eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumnotatie
- as-titel
- aspositie
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor PHP via Java kunt gebruiken om grafiekassen aan te passen in PowerPoint-presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u grafiekassen kunt aanpassen met Aspose.Slides voor PHP via Java. Het behandelt berekende aswaarden, het wisselen van rijen en kolommen in een grafiek, aszichtbaarheid, categorie‑label‑ en tick‑mark‑intervallen, datumcategorieën en opmaak, titelrotatie, aspositionering, weergave‑eenheden en logaritmische schaling.

## **Maximale waarden ophalen op de verticale as van grafieken**

Maak een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) en voeg een gebiedsgrafiek toe met standaardgegevens. Roep [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) aan voordat u berekende aswaarden uitleest, zodat de grafieklayout actueel is.

Lees [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) en [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) voor de aslimieten, en [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) en [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) voor de tick‑intervallen. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) en [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) bieden tijd‑eenheid schalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat de grafiek op.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gegevens tussen assen uitwisselen**

Gebruik [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) om de rollen van reeksen en categorieën in grafiekgegevens uit te wisselen. Elke vorige categorie wordt een reeks, en elke vorige reeks wordt een categorie. Dit verandert hoe de gegevens worden gegroepeerd; het wisselt de horizontale en verticale assen niet uit. Het voorbeeld gebruikt [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) om de standaardgegevens te binden aan `Sheet1!A1:D5`, inclusief de koprij en de categorie‑kolom, vóór het wisselen van rijen en kolommen. Het slaat een grafiek op met vier reeksen en drie categorieën.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Volgorde van plotten van een as omkeren**

Gebruik [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) om een categorie‑ of waardenas om te keren. Bijvoorbeeld, een horizontale staafgrafiek kan projectfasen van boven naar beneden tonen in dezelfde volgorde als het werkblad: Planning, Ontwikkeling, Testen. Het omkeren van een as wijzigt de plotrichting; het sorteert of herschikt de werkboekgegevens niet. Ter vergelijking, [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) wisselt de rollen van reeksen en categorieën.

Het volgende voorbeeld maakt een horizontale staafgrafiek met drie fasen en één reeks. Het slaat een presentatie op met drie dia's: normale volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde dataset, en slechts één as wordt op elke kopie omgekeerd.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // Dia 2: toon de eerste categorie bovenaan.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // Houd de horizontale waardenas onderaan.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // Dia 3: keer alleen de horizontale numerieke schaal om.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het omkeren van een as kan ook de loodrechte as naar de tegenoverliggende kant van de plot verplaatsen. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2 houdt het aanroepen met `CrossesType::Maximum` op de omgekeerde categorie‑as de horizontale waardenas onderaan. Voor een specifiek kruispunt, gebruik [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Controleer de kruisinginstellingen bij het wijzigen van de richting, vooral als de grafiek al een aangepast kruispunt heeft. Roep `setPlotOrderReversed` aan met `false` om de normale plotrichting te herstellen; kruisinginstellingen zijn onafhankelijk.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontale staafgrafiek met normale categorie‑ en waardenas volgorde](axis-order-normal.png) | ![Horizontale staafgrafiek met categorieën weergegeven van boven naar beneden](axis-order-categories-reversed.png) | ![Horizontale staafgrafiek met een omgekeerde waardenas en nul aan de rechterkant](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden nemen toe van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waarden en werkboek‑rijvolgorde blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden nemen toe van rechts naar links. De categorie‑as kruist bij nul aan de rechterkant. |

## **Verticale as uitschakelen voor lijngrafieken**

Roep [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) aan met `false` op de verticale as om deze te verbergen. Het voorbeeld maakt een lijngrafiek met standaardgegevens en slaat deze op met de verticale as verborgen.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Horizontale as uitschakelen voor lijngrafieken**

Roep [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) aan met `false` op de horizontale as om deze te verbergen. Het voorbeeld maakt een lijngrafiek met standaardgegevens en slaat deze op met de horizontale as verborgen.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Rasterlijnen van grafiek tonen of verbergen**

Roep [getShowMajorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowmajorgridlines/) en [getShowMinorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowminorgridlines/) aan om te controleren welke rasterlijnen een as weergeeft. Om kleine rasterlijnen te tonen, gebruik [getMinorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getminorgridlinesformat/) en stel de lijnvulling in op een egale, zichtbare kleur. Om ze te verbergen, stel de vulling in op [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/). Gebruik [getMajorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getmajorgridlinesformat/) om de lijnvulling voor grote rasterlijnen op dezelfde manier te wijzigen. Het wijzigen van de vulling behoudt de aszichtbaarheid en tick‑markeringen.

De verticale as van deze gegroepeerde kolomgrafiek toont aanvankelijk alleen grote rasterlijnen. Het voorbeeld toont de kleine rasterlijnen in donkeroranje, verbergt ze vervolgens opnieuw voordat de presentatie wordt opgeslagen. Het drukt de rasterlijnoverzichtelijkheid bij elke stap af.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
    $axis = $chart->getAxes()->getVerticalAxis();
    printf("Initial: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill = $axis->getMinorGridLinesFormat()->getLine()->getFillFormat();
    $minorFill->setFillType(FillType::Solid);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $minorFill->getSolidFillColor()->setColor($darkOrange);
    printf("Enabled: minor=%s\n", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill->setFillType(FillType::NoFill);
    printf("Hidden: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $presentation->save("ChartGridlines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Kleine rasterlijnen ingeschakeld | Kleine rasterlijnen verborgen |
| --- | --- |
| ![Oranje kleine rasterlijnen tussen de grote rasterlijnen op de verticale as](minor-gridlines-enabled.png) | ![Dezelfde kolomgrafiek met alleen grote rasterlijnen zichtbaar](minor-gridlines-hidden.png) |

## **Categorie-as wijzigen**

Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) om een datum‑ of tekst‑categorieas te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een grafiek als het eerste object op de eerste dia en categoriecellen die numerieke Excel‑datumnummers bevatten. Het wijzigt de horizontale as naar een datumas. Het aanroepen van [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) met `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) met `1` en [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) met `TimeUnitType::Months` plaatst grote ticks met een‑maandintervallen.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Bepaal het type categorie‑as op basis van gegevens**

Roep [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistypeautomatically/) aan na het vullen van de categorieën, en lees vervolgens [getCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getcategoryaxistype/) om de selectie te inspecteren. Dit is handig wanneer dezelfde grafiek ofwel tekstlabels of numerieke datums ontvangt. De methode bepaalt het type bij aanroep; hij zet geen permanente modus aan die latere gegevenswijzigingen opnieuw evalueert. Roep hem opnieuw aan na het vervangen van de categorieën.

Het volgende voorbeeld maakt een grafiek met tekstcategorieën en drukt `true` af wanneer het geselecteerde type `CategoryAxisType::Text` is. Vervolgens vervangt het de categoriecellen door datums en roept de methode opnieuw aan, waarbij `true` wordt afgedrukt wanneer het geselecteerde type `CategoryAxisType::Date` is. Datums worden opgeslagen als numerieke OLE‑Automation‑waarden, berekend als het aantal dagen sinds 30 december 1899, in plaats van datum‑strings. [setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) bepaalt hoe die waarden worden weergegeven; het converteert geen tekst naar numerieke datums. Voor meer informatie over categoriecellen, zie [Chart Workbook](/slides/nl/php-java/chart-workbook/).

Gebruik automatische bepaling wanneer de invoer bekend tekstcategorieën of numerieke datums bevat, zoals in dit voorbeeld. Voor gewone numerieke labels, gemengde categorieën of lege gegevens, roep expliciet [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) aan om de beoogde betekenis te corresponderen. Louter numerieke waarden bepalen niet dat de categorieën datums vertegenwoordigen.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $seriesName = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());
    $labels = ["First", "Second", "Third"];

    for ($i = 0; $i < count($labels); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $labels[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Text ? "true" : "false") . PHP_EOL;

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);
    $dates = [gmmktime(0, 0, 0, 1, 1, 2026), gmmktime(0, 0, 0, 1, 2, 2026), gmmktime(0, 0, 0, 2, 1, 2026)];

    for ($i = 0; $i < count($dates); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0);
        $categoryCell->setValue((float)(($dates[$i] - $baseDate) / 86400));
        $categoryCell->setCustomNumberFormat("yyyy-mm-dd");
    }

    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Date ? "true" : "false") . PHP_EOL;

    $presentation->save("AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Intervallen van categorie‑aslabels beheren**

Wanneer een grafiek veel categorieën heeft, kunt u het aantal zichtbare aslabels reduceren zonder categorieën of gegevenspunten te verwijderen. Roep [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) aan met `false`, en geef vervolgens het gewenste categorie‑interval door aan [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Voor tekstcategorieën in hun normale volgorde begint de telling bij de eerste categorie:

| Interval | Labels weergegeven in het voorbeeld |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, ... Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, ... Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, ... Categorie 22 |

Een interval van `3` toont elk derde label, waarbij twee labels tussen de weergegeven labels verborgen blijven. Het verwijdert de overeenkomstige kolommen niet. Automatische spacing kiest een interval op basis van de beschikbare ruimte; het toont niet noodzakelijk elk label.

Tick‑marks hebben aparte instellingen. Roep [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) aan met `false` en gebruik [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) om hun interval in te stellen. Bijvoorbeeld, `1` behoudt een tick‑mark op elk categorie‑interval terwijl labels slechts elke derde categorie verschijnen. Gebruik [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) met een zichtbaar stijl zodat u het resultaat kunt zien. Het opnieuw aanroepen van een automatische‑spacing‑setter met `true` laat de grafiek het interval opnieuw kiezen.

Het volgende zelfstandige voorbeeld maakt 24 categorieën en één reeks, en slaat vervolgens drie dia's op in `CategoryAxisIntervals.pptx`: automatische spacing, handmatige label‑spacing met onafhankelijke tick‑marks, enhersteld automatische spacing. De twee kopieën behouden de oorspronkelijke grafiekgegevens. Er is geen invoer‑presentatie nodig. Horizontale labeltekst maakt het verschil in dichtheid gemakkelijk zichtbaar.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // Dia 2: toon elk derde label, maar behoud een tick‑mark voor elke categorie.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Dia 3: laat de grafiek beide intervallen opnieuw kiezen.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Automatische spacing (dia 1):** In deze weergave wordt elk tweede categorielabel weergegeven en wordt het op twee regels afgebroken. Het automatische resultaat kan variëren afhankelijk van de grafiekgrootte, lettertypen en de renderer.

![Automatische categorie‑label‑spacing met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige spacing (dia 2):** Elk derde label wordt op één regel weergegeven, terwijl tick‑marks behouden blijven bij elk categorie‑interval. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de bovenstaande automatische weergave.

![Handmatige categorie‑label‑interval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **Kies de juiste as en interval**

Gebruik dit categorie‑aantal‑interval voor een tekst‑categorieas, zoals de categorieas van een kolom‑, lijn‑, area‑ of staafgrafiek. In een kolomgrafiek is het de horizontale as. In een horizontale staafgrafiek is de categorieas verticaal, dus pas deze instellingen toe op de as die wordt geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Tick‑mark‑spacing is ook van toepassing op een reeksen‑as in grafieken die er een hebben.

Gebruik de categorie‑label‑spacing niet om de numerieke schaal van een waardenas in te stellen. Op een waardenas specificeert [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) een verschil in waarden: bijvoorbeeld, een grote eenheid van `10` produceert ticks op 0, 10, 20, enzovoort wanneer de as bij nul begint. Een categorie‑label‑interval van `3` telt in plaats daarvan categorie‑posities, ongeacht hun gegevenswaarden. Scatter‑ en bubbelsgrafieken gebruiken waardenassen in plaats van een tekst‑categorieas. Voor een datumas, gebruik tijdgebaseerde grote eenheden en schalen zoals beschreven in [Change a Category Axis](#change-a-category-axis).

## **Datumformaat voor categorie‑aswaarden instellen**

Het voorbeeld vervangt de standaardgrafiekgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`), berekend als het aantal dagen sinds 30 december 1899 voor deze datums. Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) met `CategoryAxisType::Date`, roep [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) aan met `false`, en geef `yyyy` door aan [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) zodat de categorielabels viercijferige jaartallen weergeven, onafhankelijk van de celopmaak.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Rotatiehoek instellen voor een grafiektitel van de as**

Roep [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) aan met `true` op de verticale as, geef de titeltekst op, en gebruik [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) om de titel te roteren. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomgrafiek op met de waardenas‑titel geroteerd met 90 graden.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Aspositie instellen op een categorie‑ of waardenas**

Gebruik [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) om te bepalen of de waardenas de categorieas tussen categorieën of op categorie‑tick‑marks kruist. Deze instelling is van toepassing op categorieassen. Het voorbeeld zet het op `true` op de horizontale categorieas van een kolomgrafiek en slaat het resultaat op.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Weergave‑eenheid instellen op een grafiek‑waardenas**

Gebruik [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) om de labels op een waardenas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) ingesteld op `Millions` wordt een waarde van 60.000.000 weergegeven als 60. Het voorbeeld maakt een kolomgrafiek en past de miljoenen‑weergave‑eenheid toe op de verticale as.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Logaritmische waardenas configureren**

Een logaritmische waardenas is nuttig wanneer positieve waarden zich over meerdere groottegraden uitspreiden. Bijvoorbeeld, een service kan 10, 100, 1.000, 10.000 en 100.000 aanvragen ontvangen over vijf perioden. Op een lineaire schaal lijken de kleinere waarden dicht bij elkaar rond nul. Een logaritmische schaal maakt hun relatieve groei makkelijker te vergelijken: gelijke afstanden vertegenwoordigen gelijke verhoudingen in plaats van gelijke verschillen.

Roep [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) aan met `true` op de waardenas en gebruik [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) om de basis te kiezen. Dit wijzigt hoe de bestaande waarden worden weergegeven; het verandert de gegevens niet en voegt geen logaritmische trendlijn toe. Een trendlijn vertegenwoordigt een aangepaste relatie in de gegevens en is een apart kenmerk.

### **Kies de waardenas en de basis**

Voor een lijn‑ of kolomgrafiek wordt de waardenas geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Voor een horizontale staafgrafiek wordt deze geretourneerd door [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Scatter‑ en bubbelsgrafieken hebben twee waardenassen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categorieas.

De standaard logaritmische basis is `10`. Voor PPTX‑grafieken kunt u een basis gebruiken van `2` tot en met `1000`, inclusief; fractionele bases zoals `2.5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1.000 en 10.000 gelijkmatig verdeeld.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelfstandige voorbeeld maakt een lijngrafiek met de vijf aanvraag‑aantallen op de eerste dia, kloont vervolgens die dia en schakelt een logaritmische waardenas met basis‑10 in op de tweede. Beide dia's behouden dezelfde gegevens.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Behoud de eerste dia lineair en wijzig alleen de schaal van de waardenas van de kopie.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Lineaire schaal (dia 1):** Gelijke verticale afstanden vertegenwoordigen gelijke verschillen in aanvraag‑aantallen. De grootste waarde domineert de grafiek, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijngrafiek in PowerPoint die vijf aanvraag‑aantallen toont op een lineaire waardenas](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden vertegenwoordigen gelijke verhoudingen. Elke periode heeft tien keer zoveel aanvragen als de vorige, dus de punten vormen een rechte stijgende lijn op de basis‑10 schaal. De aslabels tonen nog steeds de oorspronkelijke aanvraag‑aantallen.

![Dezelfde vijf aanvraag‑aantallen in PowerPoint op een logaritmische waardenas met basis‑10](value-axis-logarithmic.png)

### **Omgaan met nul‑ en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat u deze inschakelt. Als nul‑ of negatieve waarden betekenisvol zijn, behoud dan een lineaire schaal of Toon ze afzonderlijk. Als het weglaten van die waarden geschikt is voor de analyse, leg dan de reden uit. Vervang ze niet stilletjes door kleine positieve getallen, want dat verandert de betekenis van de gegevens. Elke handmatig geconfigureerde minimum‑ of maximumwaarde voor een logaritmische as moet ook positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) om het kruisinggedrag te selecteren. Om een numerieke kruisingwaarde op te geven, gebruik [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Deze instellingen stellen u in staat de as‑kruising naar een geschikt nulpunt te verplaatsen.

**Hoe kan ik tick‑labels positioneren ten opzichte van de as?**

Roep [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) aan met behulp van [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tick‑marks zelf te regelen, gebruik [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) of [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); deze staan los van de labelpositionering.