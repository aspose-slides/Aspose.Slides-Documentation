---
title: 3D-diagrammen aanpassen in presentaties met PHP
linktitle: 3D-diagram
type: docs
url: /nl/php-java/3d-chart/
keywords:
- 3D-diagram
- rotatie
- diepte
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak 3D-diagrammen in PowerPoint-presentaties met Aspose.Slides for PHP via Java. Pas rotatie, hoogteverhoudingen, diagramdiepte en de afstand tussen series aan met PHP-voorbeelden."
---
## **Overzicht**

Aspose.Slides for PHP via Java stelt u in staat de weergave van een 3D-diagram aan te passen via de [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) methode. Dit artikel toont hoe u rotatie, hoogteverhoudingen, diepte, rechthoekige assen en de afstand tussen series kunt aanpassen, en vervolgens de presentatie opslaat in PPTX-formaat.

## **Instellen van de rotatie en diepte van een 3D-diagram**

Het onderstaande voorbeeld maakt een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) en gebruikt [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) om een gestapeld 3D-kolomdiagram toe te voegen aan de eerste dia. Het vervangt de standaard series en categorieën door twee series met elk drie waarden. Werkbladindex `0` geeft het eerste gegevenswerkblad van het diagram aan; rij `0` bevat de namen van de series, en kolom `0` bevat de categorielabels.

De [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) en [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) methoden stellen de rotatie van het diagram in op respectievelijk 40 en 270 graden. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) stelt de diepte in op 150% van de breedte, terwijl [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) rechthoekige assen inschakelt in plaats van perspectief. De resulterende presentatie bevat het gevulde diagram met deze 3D‑weergave‑instellingen.

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

## **Een afbeeldingvulling toepassen op een 3D-diagramoppervlak**

U kunt de [zijwand](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/) de [achterwand](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) en de [vloer](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) van een 3D-diagram onafhankelijk vullen. Stel het [vullingstype](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) van het oppervlak in op `Picture` en wijs een afbeelding toe. Stel zowel de [afbeeldingvullingsmodus](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) als het [afbeeldingstype](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) van het oppervlak in op `Stretch` zodat één exemplaar van de afbeelding over het oppervlak wordt uitgerekt.

Sla [arrow.png](arrow.png) op naast het PHP‑script. Het voorbeeld roteert het diagram en verhoogt de maximale waarde op de verticale as zodat de vloer zichtbaar is tussen de kolommen. Vervolgens kloont het de dia tweemaal en past de pijl toe op een ander oppervlak op elke dia. Alle drie diagrammen behouden dezelfde gegevens, kijkhoek en achtergrond.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint toont de drie dia's als volgt.

| Zijwand | Achterwand | Vloer |
| --- | --- | --- |
| ![Pijl wijst in het diagram langs de zijwand](side-wall.png) | ![Pijl wijst rechts over de achterwand](back-wall.png) | ![Pijl wijst rechts over de vloer tussen de kolommen](floor.png) |

## **Hoogteverhoudingen van een 3D-diagram aanpassen**

Gebruik [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) om de hoogte van een 3D-diagram in te stellen als een percentage van de breedte. Hiermee verandert u de verhoudingen van de 3D‑scène zonder de grootte van het diagramobject op de dia aan te passen.

Het volgende voorbeeld maakt een [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) diagram met de standaardgegevens: drie series en vier categorieën. Het slaat drie presentaties op met hoogteverhoudingen van 50%, 100% en 200%. De positie, breedte en hoogte van het diagram blijven onveranderd. De gegevens, rotatie, diepte, afstand tussen series en opmaak zijn identiek in alle drie bestanden; alleen het hoogtepercentage verandert.

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

De volgende afbeeldingen illustreren dezelfde hoogte‑instellingen in het equivalente .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint. Een kleiner percentage levert een plattere scène op, terwijl een groter percentage een hogere scène oplevert binnen hetzelfde diagramobject. PowerPoint kan ook de as‑ticintervallen en labelplaatsing aanpassen om de scène passend te maken.

| Hoogte: 50% | Hoogte: 100% | Hoogte: 200% |
| --- | --- | --- |
| ![3D‑kolomdiagram met hoogte ingesteld op 50 % van de breedte](height_percent_50.png) | ![3D‑kolomdiagram met hoogte ingesteld op 100 % van de breedte](height_percent_100.png) | ![3D‑kolomdiagram met hoogte ingesteld op 200 % van de breedte](height_percent_200.png) |

Deze methoden regelen verschillende aspecten van het diagram:

| Methode | Effect |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Hoogte van de 3D‑scène als een percentage van de breedte. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Hoogte van het diagramobject op de dia, in punten. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Diepte van de 3D‑scène als een percentage van de breedte. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Afstand tussen series langs de diepte‑as, als een percentage van de markerbreedte. |

De hoogte‑instelling beïnvloedt 3D‑kolom‑ en staafdiagrammen, inclusief cilinder-, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑, gebieds‑, taart‑ en oppervlak‑diagrammen. De bovenstaande vergelijking maakt gebruik van het geverifieerde type `Column3D`. De instelling verandert niet het uiterlijk van een 2D‑`ClusteredColumn`‑diagram of een `BubbleWith3D`‑diagram; deze namen zijn leden van de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑klasse. Voor andere diagram‑opmaakinstellingen, zie [Diagramopmaak](/slides/nl/php-java/chart-formatting/).

## **De afstand tussen series aanpassen**

Gebruik [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) om de afstand tussen gegevensseries langs de diepte‑as van een 3D‑diagram te regelen, uitgedrukt als een percentage van de markerbreedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de kloof, terwijl hogere waarden de afstand vergroten. Bij een vaste diagramdiepte maakt een grotere kloof de markers dunner langs de diepte‑as.

Benader de groep via [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). De instelling wordt toegepast op elke serie in die groep, niet alleen op de serie die hiervoor werd gebruikt. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) retourneert de diepte‑kloof en weerspiegelt de instelling van de bovenliggende groep.

Deze instelling beïnvloedt 3D‑kolom‑ en staafdiagrammen, inclusief hun cilinder-, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑ en gebiedsdiagrammen. Het uiterlijk hangt af van of de series in diepte, gegroepeerd of gestapeld zijn. Voor een duidelijke vergelijking van kloven tussen afzonderlijke series, gebruik `ChartType::Column3D` van de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑klasse.

Deze methoden regelen verschillende aspecten van het diagram:

| Methode | Effect |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Afstand tussen series langs de diepte‑as, als een percentage van de markerbreedte. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Afstand tussen aangrenzende balk‑ of kolomclusters, als een percentage van de breedte van de balk of kolom. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Totale diagramdiepte, als een percentage van de diagrambreedte. |

Het volgende zelfstandige voorbeeld gebruikt de standaarddiagramgegevens, die drie series en vier categorieën bevatten. Het slaat twee presentaties op met identieke gegevens, rotatie, kloofbreedte en diagramdiepte; alleen de kloofdiepte verandert.

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

De volgende afbeeldingen illustreren dezelfde kloofdiepte‑instellingen in het equivalente .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint.

| Kloofdiepte: 0% | Kloofdiepte: 500% |
| --- | --- |
| ![3D‑kolomdiagram zonder kloof tussen series langs de diepte‑as](gap_depth_0.png) | ![3D‑kolomdiagram met een kloof van 500 % tussen series langs de diepte‑as](gap_depth_500.png) |

## **Het 3D‑serietype en de staafvorm wijzigen**

In een gegroepeerd cilinderdia­gram begint de eerste serie met een cilindrische staafvorm. Het voorbeeld print de gehele getallen die worden geretourneerd door [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) en [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) vóór en na elke wijziging. De tabel geeft de bijbehorende constantenamen weer.

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

| Wijziging van de eerste serie | Serietype | Staafvorm |
| --- | --- | --- |
| Maak het diagram | `ClusteredCylinder` | `Cylinder` |
| Stel het serietype in op `ClusteredCone` | `ClusteredCone` | `Cone` |
| Stel de staafvorm in op `Box` | `ClusteredColumn3D` | `Box` |

Het instellen van de vorm op `Box` wijzigt ook het serietype naar `ClusteredColumn3D`. Als uw code vertakt op basis van het serietype, roep dan [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) aan na het wijzigen van de vorm. Een waarde die vóór de toewijzing is gecached, zou nog steeds de `ClusteredCone`‑vertakking selecteren.

![PowerPoint‑vergelijking die de eerste serie toont als cilinders, kegel​s en rechthoekige kolommen van links naar rechts](series-shapes.png)

## **FAQ**

**Welke diagramtypen ondersteunen de 3D‑modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑typen die via de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑klasse worden blootgelegd. Voor een exacte, actuele lijst, raadpleegt u de leden van [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) in de API‑referentie van uw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D-diagram krijgen voor een rapport of het web?**

Ja. U kunt een diagram exporteren naar een afbeelding met [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) of [de gehele dia renderen](/slides/nl/php-java/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer u een raster‑voorvertoning nodig heeft of het diagram wilt insluiten in documenten, dashboards of webpagina's zonder dat PowerPoint vereist is.

**Hoe presterend is het bouwen en renderen van grote 3D-diagrammen?**

De prestaties hangen af van het datavolume en de visuele complexiteit. Voor optimale resultaten houdt u 3D‑effecten tot een minimum, vermijdt u zware texturen op muren en plot‑gebieden, beperkt u het aantal gegevenspunten per serie waar mogelijk, en rendert u naar een output van passende grootte (resolutie en afmetingen) die overeenkomt met de doel‑weergave of -afdrukbehoeften.