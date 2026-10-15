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
- as titel
- as positie
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor PHP via Java kunt gebruiken om grafiekassen aan te passen in PowerPoint-presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u grafiekassen kunt aanpassen met Aspose.Slides voor PHP via Java. Het behandelt berekende aswaarden, het wisselen van rijen en kolommen in een grafiek, aszichtbaarheid, intervalinstellingen voor categoriënlabels en tick‑marks, datumcategorieën en -opmaak, titelrotatie, aspositionering, weergave‑eenheden en logaritmische schaal.

## **Maximumwaarden op de verticale as van grafieken ophalen**

Maak een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) aan en voeg een gebiedsgrafiek toe met standaardgegevens. Roep [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) aan voordat u berekende aswaarden leest, zodat de lay‑out van de grafiek up‑to‑date is.

Lees [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) en [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) voor de aslimieten, en [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) en [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) voor de tick‑intervallen. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) en [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) geven tijdseenheidschalen terug, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat de grafiek op.

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

## **Gegevens tussen assen verwisselen**

Gebruik [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) om de rollen van series en categorieën in de grafiekgegevens om te wisselen. Elke voormalige categorie wordt een serie, en elke voormalige serie wordt een categorie. Dit verandert hoe de gegevens worden gegroepeerd; het wisselt niet de horizontale en verticale assen. Het voorbeeld gebruikt [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) om de standaardgegevens te binden aan `Sheet1!A1:D5`, inclusief de koprij en categorie‑kolom, voordat rijen en kolommen worden gewisseld. Het slaat een grafiek op met vier series en drie categorieën.

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

## **De tekenvolgorde van een as omkeren**

Gebruik [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) om een categorie‑ of waardenas om te keren. Bijvoorbeeld, een horizontale staafgrafiek kan projectfasen van boven naar beneden weergeven in dezelfde volgorde als het werkblad: Planning, Ontwikkeling, Testen. Het omkeren van een as verandert de tekenrichting; het sorteert of herschikt de werkblad‑gegevens niet. Ter vergelijking wisselt [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) de rollen van series en categorieën.

Het volgende voorbeeld maakt een horizontale staafgrafiek met drie fasen en één serie. Het slaat een presentatie op met drie dia's: normale volgorde, omgekeerde categorieën en omgekeerde waardes. Elke kopie gebruikt dezelfde dataset, en slechts één as wordt per kopie omgekeerd.

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
    // Behoud de horizontale waardenas onderaan.
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

Het omkeren van een as kan ook de loodrechte as naar de andere kant van de plot verplaatsen. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2 wordt `CrossesType::Maximum` gebruikt op de omgekeerde categorie‑as, waardoor de horizontale waardenas onderaan blijft. Voor een specifiek kruispunt gebruikt u [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Controleer de kruisinginstellingen bij een richtingsverandering, vooral als de grafiek al een aangepast kruispunt heeft. Roep `setPlotOrderReversed` met `false` aan om de normale tekenrichting te herstellen; kruisinginstellingen zijn onafhankelijk.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waardes (dia 3) |
| --- | --- | --- |
| ![Horizontale staafgrafiek met normale categorie‑ en waardenasvolgorde](axis-order-normal.png) | ![Horizontale staafgrafiek met categorieën van boven naar beneden weergegeven](axis-order-categories-reversed.png) | ![Horizontale staafgrafiek met een omgekeerde waardenas en nul rechts](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waardes stijgen van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waardes en werkblad‑rijvolgorde blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waardes stijgen van rechts naar links. De categorie‑as kruist bij nul rechts. |

## **De verticale as voor lijngrafieken uitschakelen**

Roep [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) met `false` aan op de verticale as om deze te verbergen. Het voorbeeld maakt een lijngrafiek met standaardgegevens en slaat deze op met de verticale as verborgen.

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

## **De horizontale as voor lijngrafieken uitschakelen**

Roep [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) met `false` aan op de horizontale as om deze te verbergen. Het voorbeeld maakt een lijngrafiek met standaardgegevens en slaat deze op met de horizontale as verborgen.

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

## **Een categorie‑as wijzigen**

Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) om een datum‑ of tekstcategorie‑as te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een grafiek als eerste vorm op de eerste dia en categoriëncellen die numerieke Excel‑datumnummers bevatten. Het wijzigt de horizontale as naar een datum‑as. Roep [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) aan met `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) met `1`, en [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) met `TimeUnitType::Months` aan om hoofd‑ticks op een‑maand‑intervallen te plaatsen.

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

## **Interval voor categoriënlabel op een categorie‑as regelen**

Wanneer een grafiek veel categorieën heeft, kunt u het aantal zichtbare aslabels verminderen zonder categorieën of gegevenspunten te verwijderen. Roep [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) aan met `false`, en geef vervolgens het gewenste categoriëninterval door aan [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Voor tekstcategorieën in hun normale volgorde begint de telling bij de eerste categorie:

| Interval | Labels in het voorbeeld |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, … Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, … Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, … Categorie 22 |

Een interval van `3` toont elke derde label, waarbij twee labels verborgen blijven tussen de weergegeven labels. Het verwijdert de bijbehorende kolommen niet. Automatische spacing kiest een interval op basis van de beschikbare ruimte; het toont niet per definitie elk label.

Tick‑marks hebben afzonderlijke instellingen. Roep [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) aan met `false` en gebruik [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) om hun interval te bepalen. Bijvoorbeeld, `1` houdt een tick‑mark bij elk categoriëninterval terwijl labels slechts elke derde categorie verschijnen. Gebruik [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) met een zichtbaar stijl zodat u het resultaat kunt zien. Het opnieuw aanzetten van een automatische‑spacing‑setter met `true` laat de grafiek dat interval opnieuw kiezen.

Het volgende zelf‑contained voorbeeld maakt 24 categorieën en één serie, en slaat drie dia's op in `CategoryAxisIntervals.pptx`: automatische spacing, handmatige label‑spacing met onafhankelijke tick‑marks, en herstelde automatische spacing. De twee kopieën behouden de oorspronkelijke grafiekgegevens. Er is geen invoerpresentatie vereist. Horizontale labeltekst maakt het verschil in dichtheid gemakkelijk zichtbaar.

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

    // Dia 2: toon elk derde label, maar behoud een tick mark voor elke categorie.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Dia 3: laat de grafiek opnieuw beide intervallen kiezen.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Automatische spacing (dia 1):** In deze weergave wordt elke tweede categoriëlabel weergegeven en omslaat naar twee regels. Het automatische resultaat kan variëren afhankelijk van grafiekgrootte, lettertypen en renderer.

![Automatische categoriëlabel‑spacing met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige spacing (dia 2):** Elke derde label wordt op één regel weergegeven, terwijl tick‑marks bij elk categoriëninterval blijven. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de automatische weergave zoals hierboven.

![Handmatige categoriëlabel‑interval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **Kies de juiste as en interval**

Gebruik dit categoriëntellingsinterval voor een tekst‑categorie‑as, bijvoorbeeld de categoriënas van een kolom‑, lijn‑, gebieds‑ of staafgrafiek. In een kolomgrafiek is dit de horizontale as. In een horizontale staafgrafiek is de categoriënas verticaal, dus pas deze instellingen toe op de as die teruggegeven wordt door [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Tick‑mark‑spacing geldt ook voor een serie‑as in grafieken die die hebben.

Gebruik geen categoriënlabel‑spacing om de numerieke schaal van een waardenas in te stellen. Op een waardenas specificeert [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) een verschil in waarden: bijvoorbeeld, een hoofd‑unit van `10` produceert ticks bij 0, 10, 20, enz. wanneer de as bij nul start. Een categoriëlabel‑interval van `3` telt categoriënposities, ongeacht hun datawaarden. Spreidings‑ en bubbelgrafieken gebruiken waardenas in plaats van een tekst‑categorie‑as. Voor een datum‑as gebruikt u tijd‑gebaseerde hoofd‑units en schalen zoals beschreven in [Een categorie‑as wijzigen](#een-categorie-as-wijzigen).

## **Datumnotatie voor categoriënaswaarden instellen**

Het voorbeeld vervangt de standaardgrafiekgegevens door vier jaarlijkse waarden. Data worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`), berekend als het aantal dagen sinds 30 december 1899, voor deze data. Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) met `CategoryAxisType::Date`, roep [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) aan met `false`, en geef `yyyy` door aan [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) zodat de categoriënlabels viercijferige jaartallen tonen, onafhankelijk van de celopmaak.

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

## **Rotatiehoek voor een grafiektitel op een as instellen**

Roep [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) aan met `true` op de verticale as, geef de titeltekst op, en gebruik [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) om de titel te draaien. De hoek wordt in graden gemeten; dit voorbeeld slaat een kolomgrafiek op met de titel van de waardenas gedraaid met 90 graden.

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

## **De aspositie op een categorie‑ of waardenas instellen**

Gebruik [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) om te bepalen of de waardenas de categoriënas kruist tussen categorieën of op de tick‑marks van de categorieën. Deze instelling geldt voor categoriënassen. Het voorbeeld stelt dit in op `true` op de horizontale categoriënas van een kolomgrafiek en slaat het resultaat op.

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

## **Weergave‑eenheid op een waardenas instellen**

Gebruik [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) om de labels op een waardenas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) ingesteld op `Millions` wordt een waarde van 60 000 000 weergegeven als 60. Het voorbeeld maakt een kolomgrafiek en past de weergave‑eenheid “Miljoen” toe op de verticale as.

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

## **Een logaritmische waardenas configureren**

Een logaritmische waardenas is nuttig wanneer positieve waarden meerdere tekenscijfers beslaan. Bijvoorbeeld, een dienst kan 10, 100, 1 000, 10 000 en 100 000 verzoeken ontvangen over vijf perioden. Op een lineaire schaal liggen de kleinere waarden dicht bij nul. Een logaritmische schaal maakt hun relatieve groei makkelijker te vergelijken: gelijke afstanden staan voor gelijke verhoudingen i.p.v. gelijke verschillen.

Roep [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) met `true` aan op de waardenas en gebruik [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) om de basis te kiezen. Dit verandert de weergave van de bestaande waarden; het wijzigt de gegevens niet en voegt geen logaritmische trendlijn toe. Een trendlijn geeft een gefitte relatie in de data weer en is een aparte functionaliteit.

### **Kies de waardenas en de basis**

Voor een lijngrafiek of kolomgrafiek wordt de waardenas teruggegeven door [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Voor een horizontale staafgrafiek wordt deze teruggegeven door [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Spreidings‑ en bubbelgrafieken hebben twee waardenas, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categoriënas.

De standaard logaritmische basis is `10`. Voor PPTX‑grafieken mag de basis liggen tussen `2` en `1000`, inclusief; fractionele bases zoals `2.5` worden eveneens ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1 000 en 10 000 gelijkmatig gespreid.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelf‑contained voorbeeld maakt een lijngrafiek met de vijf verzoekaantallen op de eerste dia, klont vervolgens die dia en schakelt een logaritmische waardenas met basis 10 in op de tweede. Beide dia's behouden dezelfde gegevens.

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

**Lineaire schaal (dia 1):** Gelijke verticale afstanden staan voor gelijke verschillen in verzoekaantallen. De grootste waarde domineert de grafiek, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijngrafiek in PowerPoint die vijf verzoekaantallen toont op een lineaire waardenas](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden staan voor gelijke verhoudingen. Elke periode heeft tien keer zoveel verzoeken als de vorige, waardoor de punten een rechte stijgende lijn vormen op de basis‑10 schaal. De aslabels blijven de oorspronkelijke verzoekaantallen weergeven.

![Dezelfde vijf verzoekaantallen in PowerPoint op een logaritmische waardenas met basis 10](value-axis-logarithmic.png)

### **Omgaan met nul en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens vóór het inschakelen. Als nul of negatieve waarden betekenis hebben, behoud dan een lineaire schaal of toon ze apart. Indien het uitsluiten van die waarden passend is voor de analyse, leg dan de reden uit. Vervang ze niet stilletjes door kleine positieve getallen, want dat verandert de betekenis van de gegevens. Elke handmatig geconfigureerde minimum‑ of maximumwaarde voor een logaritmische as moet eveneens positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop de ene as de andere kruist (as‑kruising)?**

Gebruik [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) om het kruisgedrag te selecteren. Om een numerieke kruiswaarde op te geven, gebruik [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Deze instellingen laten u de as‑kruising naar een geschikte basislijn verplaatsen.

**Hoe kan ik tick‑labels positioneren ten opzichte van de as?**

Roep [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) aan met een waarde uit [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tick‑marks zelf te regelen, gebruik [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) of [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); deze staan los van de labelpositionering.