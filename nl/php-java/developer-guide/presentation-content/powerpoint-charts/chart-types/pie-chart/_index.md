---
title: Aangepaste taartdiagrammen in presentaties met PHP
linktitle: Taartdiagram
type: docs
url: /nl/php-java/pie-chart/
keywords:
- taartdiagram
- diagram beheren
- diagram aanpassen
- diagramopties
- diagraminstellingen
- plotopties
- segmentkleur
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak en pas taartdiagrammen aan in PHP met Aspose.Slides. Configureer secundaire plots, geef gegevenslabels weer en pas automatische segmentkleuren toe in PowerPoint."
---
## **Overzicht**

Dit artikel legt uit hoe u met taartdiagrammen in Aspose.Slides kunt werken. Het laat zien hoe u secundaire plotopties kunt configureren voor Pie of Pie- en Bar of Pie-diagrammen, en hoe u automatische kleuring van segmenten kunt inschakelen voor een standaard taartdiagram.

De voorbeelden richten zich op taken voor het aanpassen van diagrammen, zoals het toevoegen van een diagram aan een dia, het aanpassen van reeksen‑ en labelinstellingen, het vervangen van standaarddiagramgegevens door aangepaste categorieën en waarden, en het opslaan van de bijgewerkte presentatie.

## **Tweede plotopties voor Pie of Pie- en Bar of Pie-diagrammen**

Aspose.Slides for PHP via Java ondersteunt secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen. Deze opties regelen de grootte van de secundaire plot en hoe gegevenspunten tussen de twee plots worden verdeeld.

Het volgende voorbeeld maakt een Pie of Pie-diagram in een nieuwe presentatie en toont de waarden van gegevenspunten als labels. De [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) methode stelt de grootte van de secundaire plot in op 149% van de hoofdplot. [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) selecteert percentage‑gebaseerde splitsing, en [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) stelt de drempel in op 53%.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // Waarden weergeven en de secundaire plot configureren.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Selecteer categorieën voor de secundaire plot**

Gebruik aangepaste splitsing wanneer u specifieke categorieën in de secundaire plot wilt groeperen, ongeacht hun percentage‑waarden. Bijvoorbeeld, een verkooprapport kan Online en Evenementen samen weergeven zodat lezers deze twee kanalen kunnen vergelijken, ook al vormen ze 35% en 10% van de totale omzet.

Roep [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) aan met [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) en selecteer de punten via [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). De [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) methode van de collectie accepteert een nul‑gebaseerde index in de reeks; gebruik [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) om een gegevenspuntobject toe te voegen. In dit voorbeeld selecteert index 1 Online en het punt op index 3 selecteert Evenementen. Partners wordt ook tijdelijk toegevoegd, daarna uitgesloten met [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // Vervang de standaardgegevens door verkoop per kanaal.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Selecteer Online via zijn nulgebaseerde index en Events via zijn gegevenspuntobject.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Sluit Partners uit van de selectie zonder de brongegevens te verwijderen.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) en Evenementen (10) verschijnen als afzonderlijke segmenten in de secundaire plot. In de primaire plot worden ze weergegeven door één gecombineerd segment met een waarde van 45, naast Retail (40) en Partners (15). Het verwijderen van Partners uit de aangepaste selectie behoudt het in de primaire plot; het verwijdert de categorie of de waarde niet uit de brongegevens van het diagram.

De onderstaande afbeelding toont de opgeslagen presentatie in PowerPoint:

![Pie of Pie diagram met Online en Evenementen in de secundaire plot en hun gecombineerde waarde van 45 in de primaire plot](pie_of_pie_custom.png)

## **Automatische kleuring van taartdiagramsegmenten instellen**

Aspose.Slides for PHP via Java kan automatisch verschillende kleuren toewijzen aan segmenten van een taartdiagram. Het volgende voorbeeld maakt een taartdiagram met een gecentreerde titel en vervangt de standaardgegevens door drie kwartaalcategoriën en hun waarden. De [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) methode toont de waarden 20, 50 en 30 als labels, terwijl [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) een onderscheiden kleur voor elk segment inschakelt.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // Voeg een gecentreerde diagramtitel toe.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // Vervang de standaardgegevens met het eerste werkblad.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // Waarden tonen en verschillende kleuren toewijzen aan de segmenten.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Veelgestelde vragen**

**Worden de Pie of Pie- en Bar of Pie-varianten ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) een secundaire plot voor taartdiagrammen, inclusief de Pie of Pie- en Bar of Pie-typen.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, u kunt [het diagram zelf exporteren als afbeelding](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (bijvoorbeeld PNG) zonder de volledige presentatie te exporteren.