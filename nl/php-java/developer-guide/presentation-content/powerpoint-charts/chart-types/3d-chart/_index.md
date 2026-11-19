---
title: Aangepaste 3D‑grafieken in presentaties met PHP
linktitle: 3D‑grafiek
type: docs
url: /nl/php-java/3d-chart/
keywords:
- 3D‑grafiek
- rotatie
- diepte
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak 3D‑grafieken in PowerPoint‑presentaties met Aspose.Slides voor PHP via Java. Pas rotatie, hoogte‑verhoudingen, grafiekdiepte en de afstand tussen series aan met PHP‑voorbeelden."
---
## **Overzicht**

Aspose.Slides for PHP via Java stelt je in staat om de weergave van een 3D‑grafiek aan te passen via de [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) methode. Dit artikel laat zien hoe je rotatie, hoogte‑verhoudingen, diepte, rechtshoekige assen en de afstand tussen series kunt aanpassen, en vervolgens de presentatie opslaat in PPTX‑formaat.

## **Stel de rotatie en diepte van een 3D‑grafiek in**

Het voorbeeld hieronder maakt een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) aan en gebruikt [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) om een gestapelde 3D‑kolomgrafiek toe te voegen aan de eerste dia. Het vervangt de standaardseries en -categorieën door twee series met elk drie waarden. Werkblad‑index `0` identificeert het eerste gegevens‑werkblad van de grafiek; rij `0` bevat de serienamen en kolom `0` bevat de categorielabels.

De [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX)‑ en [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY)‑methoden stellen de rotatie van de grafiek in op respectievelijk 40 en 270 graden. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) stelt de diepte in op 150 % van de breedte, terwijl [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) rechtshoekige assen inschakelt in plaats van perspectief. De resulterende presentatie bevat de gevulde grafiek met deze 3D‑weergave‑instellingen.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Pas de hoogteverhoudingen van een 3D‑grafiek aan**

Gebruik [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) om de hoogte van een 3D‑grafiek in te stellen als een percentage van de breedte. Dit wijzigt de verhoudingen van de 3D‑scene zonder de grafiek‑objectgrootte op de dia te veranderen.

Het volgende voorbeeld maakt een [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) grafiek met de standaardgegevens: drie series en vier categorieën. Het slaat drie presentaties op met hoogteverhoudingen van 50 %, 100 % en 200 %. De positie, breedte en hoogte van de grafiek blijven onveranderd. De gegevens, rotatie, diepte, seriesafstand en opmaak zijn identiek in alle drie de bestanden; alleen het hoogte‑percentage verandert.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

De onderstaande afbeeldingen illustreren dezelfde hoogte‑instellingen in het equivalente .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint. Een kleiner percentage levert een plattere scene op, terwijl een groter percentage een hogere scene oplevert binnen hetzelfde grafiekobject. PowerPoint kan ook de as‑tic‑intervallen en label‑plaatsing aanpassen om de scene te laten passen.

| Hoogte: 50% | Hoogte: 100% | Hoogte: 200% |
| --- | --- | --- |
| ![3D kolomgrafiek met hoogte ingesteld op 50 procent van de breedte](height_percent_50.png) | ![3D kolomgrafiek met hoogte ingesteld op 100 procent van de breedte](height_percent_100.png) | ![3D kolomgrafiek met hoogte ingesteld op 200 procent van de breedte](height_percent_200.png) |

Deze methoden regelen verschillende aspecten van de grafiek:

| Methode | Effect |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Hoogte van de 3D‑scene als percentage van de breedte. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Hoogte van het grafiekobject op de dia, in punten. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Diepte van de 3D‑scene als percentage van de breedte. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Afstand tussen series langs de diepte‑as, als percentage van de markerbreedte. |

De hoogte‑instelling beïnvloedt 3D‑kolom‑ en staafgrafieken, inclusief cilindervarianten, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑, vlak‑, taart‑ en oppervlakte‑grafieken. De vergelijking hierboven maakt gebruik van het geverifieerde `Column3D`‑type. De instelling wijzigt niet het uiterlijk van een 2D‑`ClusteredColumn`‑grafiek of een `BubbleWith3D`‑grafiek; deze namen zijn leden van de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑klasse. Zie voor andere grafiek‑opmaakinstellingen [Chart Formatting](/slides/nl/php-java/chart-formatting/).

## **Pas de afstand tussen series aan**

Gebruik [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) om de afstand tussen gegevens‑series langs de diepte‑as van een 3D‑grafiek te regelen, uitgedrukt als percentage van de markerbreedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de ruimte, terwijl grotere waarden de afstand vergroten. Bij een vaste grafiekladte maakt een grotere ruimte de markers dunner langs de diepte‑as.

Toegang tot de groep vindt plaats via [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). De instelling geldt voor elke serie in die groep, niet alleen voor de serie waarmee toegang wordt verkregen. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) geeft de diepte‑gap terug en weerspiegelt de instelling van de bovenliggende groep.

Deze instelling beïnvloedt 3D‑kolom‑ en staafgrafieken, inclusief hun cilindrische, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑ en vlakgrafieken. Het uiterlijk hangt af van of de series in diepte, gegroepeerd of gestapeld zijn. Voor een duidelijke vergelijking van gaten tussen afzonderlijke series, gebruik `ChartType::Column3D` uit de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑klasse.

Deze methoden regelen verschillende aspecten van de grafiek:

| Methode | Effect |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Afstand tussen series langs de diepte‑as, als percentage van de markerbreedte. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Afstand tussen aangrenzende balk‑ of kolomclusters, als percentage van de balk‑ of kolombreedte. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Totale grafiekladte, als percentage van de grafiekbreedte. |

Het volgende zelfstandige voorbeeld gebruikt de standaardgrafiekgegevens, die drie series en vier categorieën bevatten. Het slaat twee presentaties op met identieke gegevens, rotatie, gat‑breedte en grafiekladte; alleen de gat‑diepte verandert.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

De onderstaande afbeeldingen illustreren dezelfde gat‑diepte‑instellingen in het equivalente .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint.

| Gatdiepte: 0% | Gatdiepte: 500% |
| --- | --- |
| ![3D kolomgrafiek zonder gat tussen series langs de diepte‑as](gap_depth_0.png) | ![3D kolomgrafiek met een gat van 500 procent tussen series langs de diepte‑as](gap_depth_500.png) |

## **Wijzig het 3D‑serietype en de balkvorm**

In een gegroepeerde cilindergrafiek begint de eerste serie met een cilindrische balkvorm. Het voorbeeld print de gehele getallen die worden geretourneerd door [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) en [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) voor en na elke wijziging. De tabel geeft de bijbehorende constante namen weer.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Wijziging van de eerste serie | Serietype | Balkvorm |
| --- | --- | --- |
| Grafiek maken | `ClusteredCylinder` | `Cylinder` |
| Stel serietype in op `ClusteredCone` | `ClusteredCone` | `Cone` |
| Stel de balkvorm in op `Box` | `ClusteredColumn3D` | `Box` |

Het instellen van de vorm op `Box` wijzigt ook het serietype naar `ClusteredColumn3D`. Als je code vertakt op het serietype, roep dan [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) aan nadat je de vorm hebt gewijzigd. Een waarde die vóór de toewijzing is gecached, zou nog steeds de `ClusteredCone`‑tak selecteren.

![PowerPoint‑vergelijking die de eerste serie toont als cilinders, kegels en rechthoekige kolommen van links naar rechts](series-shapes.png)

## **FAQ**

**Welke grafiektype­s ondersteunen de 3D‑modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomgrafieken, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑typen die beschikbaar worden gesteld via de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑klasse. Voor een exacte, actuele lijst, raadpleeg de leden van [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) in de API‑referentie van de geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D‑grafiek krijgen voor een rapport of voor het web?**

Ja. Je kunt een grafiek exporteren naar een afbeelding met [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) of de volledige dia [renderen](/slides/nl/php-java/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer je een raster‑preview nodig hebt of de grafiek wilt insluiten in documenten, dashboards of webpagina’s zonder PowerPoint.

**Hoe presteert het bouwen en renderen van grote 3D‑grafieken?**

De prestaties hangen af van de hoeveelheid gegevens en de visuele complexiteit. Voor optimale resultaten houd je 3D‑effecten minimaal, vermijd je zware texturen op wanden en plot‑gebieden, beperk je het aantal datapunten per serie waar mogelijk, en render je naar een passend formaat (resolutie en afmetingen) voor het doelapparaat of de afdruk.