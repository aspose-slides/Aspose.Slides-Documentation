---
title: Anpassa 3D-diagram i presentationer med PHP
linktitle: 3D-diagram
type: docs
url: /sv/php-java/3d-chart/
keywords:
- 3D-diagram
- rotation
- djup
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa 3D-diagram i PowerPoint-presentationer med Aspose.Slides för PHP via Java. Justera rotation, höjdförhållanden, diagramdjup och avstånd mellan serier med PHP-exempel."
---
## **Översikt**

Aspose.Slides för PHP via Java låter dig anpassa vyn av ett 3D-diagram via metoden [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). Denna artikel visar hur man justerar rotation, höjdförhållanden, djup, vinkelräta axlar och avstånd mellan serier, och sedan sparar presentationen i PPTX-format.

## **Ange rotation och djup för ett 3D-diagram**

Exemplet nedan skapar en [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) och använder [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) för att lägga till ett staplat 3D-kolumndiagram till dess första bild. Det ersätter standardserierna och -kategorierna med två serier som innehåller tre värden vardera. Kalkylbladsindex `0` identifierar diagrammets första dataarbetsblad; rad `0` innehåller serienamnen och kolumn `0` innehåller kategorietiketter.

Metoderna [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) och [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) sätter diagrammets rotation till 40 respektive 270 grader. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) sätter dess djup till 150 % av dess bredd, medan [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) aktiverar vinkelräta axlar istället för perspektiv. Den resulterande presentationen innehåller diagrammet med dessa 3D-vyinställningar.

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

## **Applicera en bildfyllning på en 3D-diagramsida**

Du kan fylla [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) och [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) i ett 3D-diagram var för sig. Ställ in ytan's [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) till `Picture` och tilldela en bild. Ställ både [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) och ytan's [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) till `Stretch` för att sträcka en kopia av bilden över hela ytan.

Spara [arrow.png](arrow.png) bredvid PHP‑skriptet. Exemplet roterar diagrammet och höjer maxvärdet på den vertikala axeln så att golvet syns mellan kolumnerna. Det klonar sedan bilden två gånger och applicerar pilen på en annan yta i varje bild. Alla tre diagrammen behåller samma data, vyvinkel och bakgrund.

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

Microsoft PowerPoint visar de tre bilderna enligt följande.

| Sidovägg | Bakvägg | Golv |
| --- | --- | --- |
| ![Arrow pointing into the chart along the side wall](side-wall.png) | ![Arrow pointing right across the back wall](back-wall.png) | ![Arrow pointing right across the floor between the columns](floor.png) |

## **Justera höjdförhållandena för ett 3D-diagram**

Använd [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) för att ställa in diagrammets höjd som en procent av dess bredd. Detta ändrar proportionerna i 3D‑scenen utan att ändra diagramobjektets storlek på bilden.

Följande exempel skapar ett [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) diagram med standarddata: tre serier och fyra kategorier. Det sparar tre presentationer med höjdförhållanden på 50 %, 100 % och 200 %. Diagrammets position, bredd och höjd förblir oförändrade. Data, rotation, djup, serien mellanrum och formatering är identiska i alla tre filer; endast höjdpersen­tagen ändras.

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

Följande bilder illustrerar samma höjdinställningar i motsvarande .NET‑exempel och exporterades med Microsoft PowerPoint. En mindre procentandel ger en plattare scen, medan en större procentandel ger en högre scen inom samma diagramobjekt. PowerPoint kan även justera axelns tick‑intervall och etikettplacering för att passa scenen.

| Höjd: 50 % | Höjd: 100 % | Höjd: 200 % |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Höjd på 3D‑scenen som en procent av dess bredd. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Höjd på diagramobjektet på bilden, i punkter. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Djup på 3D‑scenen som en procent av dess bredd. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Avstånd mellan serier längs djupaxeln, som en procent av markörens bredd. |

Höjdinställningen påverkar 3D‑stapeldiagram och stapel‑diagram, inklusive cylinder-, kon- och pyramidalvarianterna, samt 3D‑linje-, area‑, paj‑ och ytdiagram. Jämförelsen ovan använder den verifierade `Column3D`‑typen. Inställningen ändrar inte utseendet på ett 2D‑`ClusteredColumn`‑diagram eller ett `BubbleWith3D`‑diagram; dessa namn är medlemmar i klassen [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). För andra diagramutseendeinställningar, se [Chart Formatting](/slides/sv/php-java/chart-formatting/).

## **Justera gapet mellan serier**

Använd [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) för att kontrollera avståndet mellan dataserier längs djupaxeln i ett 3D‑diagram, uttryckt som en procent av markörens bredd. Använd värden från **0 till 500**, inklusive: `0` tar bort gapet, medan högre värden ökar avståndet. Med ett fast diagramdjup gör ett större gap att markörerna blir tunnare längs djupaxeln.

Kom åt gruppen via [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). Inställningen gäller för alla serier i den gruppen, inte bara för den serie som användes för åtkomst. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) returnerar djupgapet och speglar gruppens inställning.

Denna inställning påverkar 3D‑stapeldiagram och stapeldiagram, inklusive deras cylinder-, kon- och pyramidalvarianter, samt 3D‑linje‑ och areadiagram. Utseendet beror på om serierna är arrangerade i djup, grupperade eller staplade. För en tydlig jämförelse av gap mellan separata serier, använd `ChartType::Column3D` från klassen [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Avstånd mellan serier längs djupaxeln, som en procent av markörens bredd. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Avstånd mellan intilliggande stapel‑ eller kolumnkluster, som en procent av stapelns eller kolumnens bredd. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Totalt diagramdjup, som en procent av diagrammets bredd. |

Följande självständiga exempel använder standarddiagramdata, som innehåller tre serier och fyra kategorier. Det sparar två presentationer med identisk data, rotation, gap‑bredd och diagramdjup; endast gap‑djupet ändras.

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

Följande bilder illustrerar samma gap‑djupinställningar i motsvarande .NET‑exempel och exporterades med Microsoft PowerPoint.

| Gap‑djup: 0 % | Gap‑djup: 500 % |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **Ändra 3D‑serietyp och stapelform**

I ett grupperat cylindrisk diagram börjar den första serien med en cylindrisk stapelform. Exemplet skriver ut heltalsvärdena som returneras av [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) och [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) före och efter varje ändring. Tabellen ger de motsvarande konstantnamnen.

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

| Ändring för den första serien | Serietyp | Stapelform |
| --- | --- | --- |
| Skapa diagrammet | `ClusteredCylinder` | `Cylinder` |
| Ställ in serietyp till `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ställ in stapelform till `Box` | `ClusteredColumn3D` | `Box` |

Att sätta formen till `Box` ändrar även serietypen till `ClusteredColumn3D`. Om din kod förgrenar sig på serietypen, anropa [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) efter att du ändrat formen. Ett värde cacheat innan tilldelningen skulle fortfarande välja grenen `ClusteredCone`.

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **FAQ**

**Vilka diagramtyper stödjer 3D‑läge i Aspose.Slides?**

Aspose.Slides stödjer 3D‑varianter av stapeldiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras via klassen [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). För en exakt, uppdaterad lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) i API‑referensen för din installerade version.

**Kan jag få en rasterbild av ett 3D‑diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild med [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) eller [rendera hela bilden](/slides/sv/php-java/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en raster‑förhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att kräva PowerPoint.

**Hur presterar byggandet och rendering av stora 3D‑diagram?**

Prestanda beror på datavolym och visuell komplexitet. För bästa resultat, håll 3D‑effekter minimala, undvik tunga texturer på väggar och plotområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämpligt stor utdata (upplösning och dimensioner) som matchar målvisning eller utskriftsbehov.