---
title: Přizpůsobení 3D grafů v prezentacích pomocí PHP
linktitle: 3D graf
type: docs
url: /cs/php-java/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvořte 3D grafy v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java. Nastavte rotaci, výškové poměry, hloubku grafu a rozestupy mezi sériemi s příklady v PHP."
---
## **Přehled**

Aspose.Slides for PHP via Java vám umožňuje přizpůsobit pohled 3D grafu pomocí metody [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). Tento článek ukazuje, jak upravit rotaci, výškové poměry, hloubku, pravoúhlé osy a rozestupy mezi sériemi a poté uložit prezentaci ve formátu PPTX.

## **Nastavení rotace a hloubky 3D grafu**

Níže uvedený příklad vytváří [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) a pomocí [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) přidává do jeho prvního snímku seskupený 3D sloupcový graf. Nahrazuje výchozí série a kategorie dvěma sériemi obsahujícími po třech hodnotách. Index listu `0` určuje první datový list grafu; řádek `0` obsahuje názvy sérií a sloupec `0` obsahuje popisky kategorií.

Metody [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) a [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) nastavují rotaci grafu na 40 ° a 270 °. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) nastavuje jeho hloubku na 150 % šířky, zatímco [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) povoluje pravoúhlé osy místo perspektivy. Výsledná prezentace obsahuje vyplněný graf s těmito nastaveními 3D zobrazení.

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

## **Úprava výškových poměrů 3D grafu**

Použijte [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) k nastavení výšky 3D grafu jako procenta jeho šířky. Tím změníte poměry 3D scény, aniž byste měnili velikost objektu grafu na snímku.

Následující příklad vytváří graf typu [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) s výchozími daty: tři série a čtyři kategorie. Uloží tři prezentace s výškovými poměry 50 %, 100 % a 200 %. Pozice, šířka a výška grafu zůstávají pevné. Data, rotace, hloubka, mezery mezi sériemi a formátování jsou ve všech třech souborech identické; mění se pouze procento výšky.

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

Následující obrázky ilustrují stejné nastavení výšky v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint. Menší procento vytváří plošší scénu, větší procento vyšší scénu ve stejném objektu grafu. PowerPoint může také upravit intervaly osy a umístění popisků, aby scénu přizpůsobil.

| Výška: 50% | Výška: 100% | Výška: 200% |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

Tyto metody řídí různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Výška 3D scény jako procento její šířky. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Výška objektu grafu na snímku v bodech. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Hloubka 3D scény jako procento její šířky. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Rozestup mezi sériemi podél osy hloubky jako procento šířky značky. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně válec, kužel a pyramida, stejně jako 3D čárové, plošné, koláčové a povrchové grafy. Porovnání výše používá ověřený typ `Column3D`. Nastavení nemění vzhled 2D grafu `ClusteredColumn` ani grafu `BubbleWith3D`; tyto názvy jsou součástí třídy [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Pro další nastavení vzhledu grafu viz [Chart Formatting](/slides/cs/php-java/chart-formatting/).

## **Úprava mezery mezi sériemi**

Použijte [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) ke kontrole vzdálenosti mezi datovými sériemi podél osy hloubky 3D grafu, vyjádřené jako procento šířky značky. Používejte hodnoty od **0 do 500**, včetně: `0` odstraní mezeru, vyšší hodnoty zvětší rozestup. Při pevné hloubce grafu zvětšuje se mezera, což ztenčuje značky podél osy hloubky.

Přístup ke skupině získáte přes [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). Nastavení se vztahuje na každou sérii v této skupině, nejen na sérii, přes kterou byl přístup získán. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) vrací mezery v hloubce a odráží nastavení nadřazené skupiny.

Toto nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich variant válcových, kuželových a pyramidových, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou série uspořádány v hloubce, seskupeny nebo nasčítány. Pro přehledné srovnání mezer mezi samostatnými sériemi použijte `ChartType::Column3D` ze třídy [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Tyto metody řídí různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Rozestup mezi sériemi podél osy hloubky jako procento šířky značky. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Rozestup mezi sousedními shluky pruhů nebo sloupců jako procento šířky pruhu nebo sloupce. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Celková hloubka grafu jako procento šířky grafu. |

Následující samostatný příklad používá výchozí data grafu, která obsahují tři série a čtyři kategorie. Uloží dvě prezentace se stejnými daty, rotací, šířkou mezery a hloubkou grafu; mění se pouze hloubka mezery.

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

Následující obrázky ilustrují stejné nastavení mezery v hloubce v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint.

| Mezera v hloubce: 0% | Mezera v hloubce: 500% |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **Změna typu 3D série a tvaru pruhu**

V seskupeném válcovém grafu první série začíná válcovým tvarem pruhu. Příklad vypisuje celočíselné hodnoty vrácené metodami [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) a [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) před a po každé změně. Tabulka uvádí odpovídající názvy konstant.

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

| Změna první série | Typ série | Tvar pruhu |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

Nastavení tvaru na `Box` také mění typ série na `ClusteredColumn3D`. Pokud váš kód podmíněně rozhoduje podle typu série, zavolejte [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) po změně tvaru. Hodnota načtená před přiřazením by stále vedla k větvi `ClusteredCone`.

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **Časté dotazy**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s příbuznými 3D typy vystavenými třídou [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) v referenční dokumentaci API vaší nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat jako obrázek pomocí [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) nebo [render the entire slide](/slides/cs/php-java/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete rastrový náhled nebo chcete graf vložit do dokumentů, dashboardů či webových stránek bez nutnosti PowerPointu.

**Jak výkonná je tvorba a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky udržujte 3D efekty na minima, vyhýbejte se těžkým texturám na stěnách a ploše grafu, omezte počet datových bodů na sérii, pokud je to možné, a renderujte do vhodně dimenzovaného výstupu (rozlišení a rozměry) odpovídajícího cílovému zobrazení nebo tisku.