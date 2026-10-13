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
- as eigenschappen
- maximumwaarde
- minimumwaarde
- aslijn
- datumnotatie
- as titel
- aspositie
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor PHP via Java kunt gebruiken om grafiekassen in PowerPoint‑presentaties aan te passen voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe je grafiekassen kunt aanpassen met Aspose.Slides voor PHP via Java. Het behandelt berekende aswaarden, het wisselen van rijen en kolommen in grafieken, de zichtbaarheid van assen, categorie‑label‑ en tik‑mark‑intervallen, datumcategorieën en -opmaak, titelrotatie, aspositionering, weergave‑eenheden en logaritmische schaling.

## **Maximale waarden op de verticale as van grafieken ophalen**

Maak een [Presentatie](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) aan en voeg een oppervlakte‑grafiek toe met standaardgegevens. Roep [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) aan voordat je berekende aswaarden leest, zodat de grafieklay‑out up‑to‑date is.

Lees [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) en [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) voor de aslimieten, en [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) en [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) voor de tik‑intervallen. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) en [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) bieden tijd‑eenheidschalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat de grafiek op.

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

## **Gegevens tussen assen wisselen**

Gebruik [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) om de rollen van reeksen en categorieën in grafiekgegevens om te wisselen. Elke voormalige categorie wordt een reeks en elke voormalige reeks wordt een categorie. Dit verandert hoe de gegevens worden gegroepeerd; het wisselt niet de horizontale en verticale assen. Het voorbeeld gebruikt [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) om de standaardgegevens te koppelen aan `Sheet1!A1:D5`, inclusief de koprij en categoriekolom, vóór het wisselen van rijen en kolommen. Het slaat een grafiek op met vier reeksen en drie categorieën.

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

## **Verticale as uitschakelen voor lijndiagrammen**

Roep [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) aan met `false` op de verticale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de verticale as verborgen.

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

## **Horizontale as uitschakelen voor lijndiagrammen**

Roep [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) aan met `false` op de horizontale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de horizontale as verborgen.

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

## **Een categorieas wijzigen**

Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) om een datum‑ of tekst‑categorieas te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een grafiek als het eerste object op de eerste dia en categorie‑cellen die numerieke Excel‑datumnummers bevatten. Het verandert de horizontale as in een datumas. Door [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) aan te roepen met `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) met `1`, en [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) met `TimeUnitType::Months` worden de grote tikken op één‑maand‑intervallen geplaatst.

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

## **Intervallen van categorie‑as‑labels beheren**

Wanneer een grafiek veel categorieën heeft, kun je het aantal zichtbare as‑labels verminderen zonder categorieën of datapunten te verwijderen. Roep [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) aan met `false` en geef vervolgens het gewenste categorieverloop door aan [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Voor tekstcategorieën in hun normale volgorde begint de telling bij de eerste categorie:

| Interval | Labels weergegeven in het voorbeeld |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, ... Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, ... Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, ... Categorie 22 |

Een interval van `3` toont elk derde label, waarbij twee labels tussen de weergegeven labels verborgen blijven. Het verwijdert de overeenkomstige kolommen niet. Automatische tussenruimte kiest een interval op basis van de beschikbare ruimte; het toont niet noodzakelijk elk label.

Tick marks have separate controls. Call [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) with `false` and use [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) to set their interval. For example, `1` keeps a tick mark at every category interval while labels appear only every third category. Use [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) with a visible style so you can see the result. The automatic‑spacing setter with `true` again lets the chart choose that interval again.

Het volgende zelfstandige voorbeeld maakt 24 categorieën en één reeks, en slaat vervolgens drie dia's op in `CategoryAxisIntervals.pptx`: automatische tussenruimte, handmatige label‑tussenruimte met onafhankelijke tijkstippen, en herstelde automatische tussenruimte. De twee kopieën behouden de oorspronkelijke grafiekgegevens. Er is geen invoer‑presentatie vereist. Horizontale labeltekst maakt het verschil in dichtheid duidelijk zichtbaar.

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

    // Dia 2: toon elk derde label, maar behoud een tijkstreep voor elke categorie.
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

**Automatische tussenruimte (dia 1):** In deze weergave wordt elk tweede categorie‑label weergegeven en wordt op twee regels afgebroken. Het automatische resultaat kan variëren met grafiekgrootte, lettertypen en de renderer.

![Automatische categorie‑label‑tussenruimte met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige tussenruimte (dia 2):** Elk derde label wordt op één regel weergegeven, terwijl tijkstippen bij elk categorieverloop blijven. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de bovenstaande automatische weergave.

![Handmatig categorie‑label‑interval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **Kies de juiste as en het juiste interval**

Gebruik dit categorie‑telling‑interval voor een tekst‑categorieas, zoals de categorieas van een kolom‑, lijn‑, vlak‑ of staafgrafiek. In een kolomgrafiek is dit de horizontale as. In een horizontale staafgrafiek is de categorieas verticaal, dus pas deze instellingen toe op de as die wordt geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Het interval tussen tijkstippen geldt ook voor een serieas in grafieken die die hebben.

Gebruik de tussenruimte van categorie‑labels niet om de numerieke schaal van een waardenas in te stellen. Op een waardenas specificeert [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) een verschil in waarden: bijvoorbeeld, een grote eenheid van `10` produceert tikken bij 0, 10, 20, enzovoort wanneer de as bij nul begint. Een categorie‑label‑interval van `3` telt in plaats daarvan categorie‑posities, ongeacht hun datavariabelen. Spreidings‑ en bubbelgrafieken gebruiken waardenassen in plaats van een tekst‑categorieas. Voor een datumas, gebruik tijd‑gebaseerde grote eenheden en schalen zoals beschreven in [Wijzig een categorieas](#change-a-category-axis).

## **Het datumformaat voor categorie‑as‑waarden instellen**

Het voorbeeld vervangt de standaardgrafiekgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`), berekend als het aantal dagen sinds 30 december 1899 voor deze datums. Gebruik [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) met `CategoryAxisType::Date`, roep [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) aan met `false`, en geef `yyyy` door aan [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) zodat de categorie‑labels viercijferige jaartallen weergeven, onafhankelijk van de opmaak van de cellen.

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

## **Een rotatiehoek voor een grafiekas‑titel instellen**

Roep [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) aan met `true` op de verticale as, geef titeltekst op, en gebruik [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) om de titel te roteren. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomgrafiek op met de titel van de waardenas geroteerd met 90 graden.

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

Gebruik [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) om te bepalen of de waardenas de categorieas doorkruist tussen categorieën of op categorietikken. Deze instelling is van toepassing op categorie‑assen. Het voorbeeld stelt dit in op `true` voor de horizontale categorieas van een kolomgrafiek en slaat het resultaat op.

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

## **De weergave‑eenheid op een waardenas van een grafiek instellen**

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

## **Een logaritmische waardenas configureren**

Een logaritmische waardenas is nuttig wanneer positieve waarden zich over meerdere orde‑van‑groottes uitstrekken. Bijvoorbeeld, een dienst kan 10, 100, 1.000, 10.000 en 100.000 verzoeken ontvangen over vijf periodes. Op een lineaire schaal lijken de kleinere waarden dicht bij nul te liggen. Een logaritmische schaal maakt hun relatieve groei gemakkelijker te vergelijken: gelijke afstanden staan voor gelijke verhoudingen in plaats van gelijke verschillen.

Roep [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) aan met `true` op de waardenas en gebruik [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) om de basis te kiezen. Dit verandert de weergave van de bestaande waarden; het verandert de gegevens niet en voegt geen logaritmische trendlijn toe. Een trendlijn vertegenwoordigt een aangepaste relatie in de gegevens en is een afzonderlijke functie.

### **Kies de waardenas en de basis**

Voor een lijn‑ of kolomgrafiek wordt de waardenas geretourneerd door [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Voor een horizontale staafgrafiek wordt deze geretourneerd door [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Spreidings‑ en bubbelgrafieken hebben twee waardenassen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaling toe op een categorieas.

De standaard logaritmische basis is `10`. Voor PPTX‑grafieken gebruik je een basis van `2` tot en met `1000`; fractionele bases zoals `2,5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1.000 en 10.000 gelijkmatig verdeeld.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelfstandige voorbeeld maakt een lijndiagram met de vijf verzoektelling op de eerste dia, kloont vervolgens die dia en stelt een base‑10 logaritmische waardenas in op de tweede. Beide dia's behouden dezelfde gegevens.

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

**Lineaire schaal (dia 1):** Gelijke verticale afstanden vertegenwoordigen gelijke verschillen in verzoektelling. De grootste waarde domineert de grafiek, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijndiagram in PowerPoint dat vijf verzoektelling toont op een lineaire waardenas](value-axis-linear.png)

**Logarithmische schaal (dia 2):** Gelijke verticale afstanden vertegenwoordigen gelijke verhoudingen. Elke periode heeft tien keer zoveel verzoeken als de vorige, waardoor de punten een rechte stijgende lijn vormen op de base‑10 schaal. De as‑labels tonen nog steeds de oorspronkelijke verzoektelling.

![Dezelfde vijf verzoektelling in PowerPoint op een base‑10 logaritmische waardenas](value-axis-logarithmic.png)

### **Omgaan met nul‑ en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat je deze activeert. Als nul‑ of negatieve waarden betekenisvol zijn, houd dan een lineaire schaal aan of toon ze afzonderlijk. Als het weglaten van die waarden passend is voor de analyse, leg dan de omissie uit. Vervang ze niet stilletjes door kleine positieve getallen, omdat dit de betekenis van de gegevens verandert. Elke handmatig geconfigureerde minimum‑ of maximumwaarde voor een logaritmische as moet ook positief zijn.

## **Veelgestelde vragen**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) om het kruiskruispuntgedrag te selecteren. Om een numerieke kruiswaarde op te geven, gebruik je [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Deze instellingen stellen je in staat de as‑kruising naar een geschikt referentieniveau te verplaatsen.

**Hoe kan ik tijklabels positioneren ten opzichte van de as?**

Roep [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) aan met [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tijkstippen zelf te regelen, gebruik je [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) of [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); deze staan los van de labelpositionering.