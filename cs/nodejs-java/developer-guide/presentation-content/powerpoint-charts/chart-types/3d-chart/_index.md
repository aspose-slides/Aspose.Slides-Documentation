---
title: Přizpůsobení 3D grafů v prezentacích pomocí JavaScriptu
linktitle: 3D graf
type: docs
url: /cs/nodejs-java/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvořte 3D grafy v prezentacích PowerPoint pomocí Aspose.Slides pro Node.js přes Java. Nastavte rotaci, výškové proporce, hloubku grafu a rozestupy mezi sériemi pomocí příkladů v JavaScriptu."
---
## **Přehled**

Aspose.Slides pro Node.js přes Java vám umožňuje přizpůsobit zobrazení 3D grafu metodou [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/). Tento článek ukazuje, jak upravit rotaci, výškové proporce, hloubku, pravouhlé osy a rozestupy mezi sériemi a poté uložit prezentaci ve formátu PPTX.

## **Nastavení rotace a hloubky 3D grafu**

Příklad níže vytvoří [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) a pomocí [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) přidá na první snímek seskupený 3D sloupcový graf. Nahradí výchozí série a kategorie dvěma sériemi obsahujícími tři hodnoty každá. Index listu `0` určuje první datový list grafu; řádek `0` obsahuje názvy sérií a sloupec `0` popisky kategorií.

Metody [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) a [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) nastaví rotaci grafu na 40 ° a 270 ° resp. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) nastaví jeho hloubku na 150 % šířky, zatímco [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) zapne pravouhlé osy místo perspektivy. Výsledná prezentace obsahuje vyplněný graf s těmito nastaveními 3D zobrazení.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Úprava výškových proporcí 3D grafu**

Použijte [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) k nastavení výšky 3D grafu jako procenta jeho šířky. Tím se změní proporce 3D scény, aniž by se změnil rozměr objektu grafu na snímku.

Následující příklad vytvoří graf typu [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) s výchozími daty: tři série a čtyři kategorie. Uloží tři prezentace s výškovými proporcemi 50 %, 100 % a 200 %. Pozice, šířka a výška grafu zůstávají pevné. Data, rotace, hloubka, rozestupy sérií a formátování jsou ve všech třech souborech totožné; mění se pouze procento výšky.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Následující obrázky ilustrují stejné nastavení výšky v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint. Menší procento vytváří plochější scénu, vyšší procento vyšší scénu ve stejném objektu grafu. PowerPoint může také upravit intervaly os a umístění popisků tak, aby scéna zapadla.

| Výška: 50% | Výška: 100% | Výška: 200% |
| --- | --- | --- |
| ![3D sloupcový graf s výškou nastavenou na 50 percent šířky jeho grafu](height_percent_50.png) | ![3D sloupcový graf s výškou nastavenou na 100 percent šířky jeho grafu](height_percent_100.png) | ![3D sloupcový graf s výškou nastavenou na 200 percent šířky jeho grafu](height_percent_200.png) |

Tyto metody řídí různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Výška 3D scény jako procento její šířky. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Výška objektu grafu na snímku, v bodech. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Hloubka 3D scény jako procento její šířky. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Rozestup mezi sériemi podél osy hloubky jako procento šířky značky. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně varianty válec, kužel a pyramida, stejně jako 3D čárové, plošné, koláčové a povrchové grafy. Porovnání výše používá ověřený typ `Column3D`. Nastavení nemění vzhled 2D grafu `ClusteredColumn` ani grafu `BubbleWith3D`; tyto názvy jsou členy třídy [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Pro další nastavení vzhledu grafu viz [Chart Formatting](/slides/cs/nodejs-java/chart-formatting/).

## **Úprava mezery mezi sériemi**

Použijte [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) k řízení vzdálenosti mezi datovými sériemi podél osy hloubky 3D grafu, vyjádřené jako procento šířky značky. Používejte hodnoty od **0 do 500**, včetně: `0` odstraní mezeru, vyšší hodnoty mezeru zvětší. Při pevné hloubce grafu zvětšení mezery způsobí tenčí značky podél osy hloubky.

Přístup ke skupině získáte přes [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). Nastavení platí pro každou sérii ve skupině, nejen pro sérii, kterou použijete k přístupu. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) vrací mezeru v hloubce a odráží nastavení nadřazené skupiny.

Toto nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich válcových, kuželových a pyramidových variant, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou série uspořádány v hloubce, seskupeny nebo sesazeny. Pro jasné srovnání mezer mezi oddělenými sériemi použijte `ChartType.Column3D` z třídy [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Tyto metody řídí různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Rozestup mezi sériemi podél osy hloubky jako procento šířky značky. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Rozestup mezi sousedními klastery sloupců nebo pruhů jako procento šířky sloupce nebo pruhu. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Celková hloubka grafu jako procento šířky grafu. |

Následující samostatný příklad používá výchozí data grafu, která obsahují tři série a čtyři kategorie. Uloží dvě prezentace se stejnými daty, rotací, šířkou mezery a hloubkou grafu; mění se pouze hloubka mezery.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Následující obrázky ilustrují stejné nastavení hloubky mezery v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint.

| Hloubka mezery: 0% | Hloubka mezery: 500% |
| --- | --- |
| ![3D sloupcový graf bez mezery mezi sériemi podél osy hloubky](gap_depth_0.png) | ![3D sloupcový graf s 500 procentní mezerou mezi sériemi podél osy hloubky](gap_depth_500.png) |

## **Změna typu 3D série a tvaru pruhu**

V seskupeném válcovém grafu první série začíná válcovým tvarem pruhu. Příklad vytiskne celá čísla vrácená metodami [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) a [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) před a po každé změně. Tabulka uvádí odpovídající názvy konstant.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Změna první série | Typ série | Tvar pruhu |
| --- | --- | --- |
| Vytvoření grafu | `ClusteredCylinder` | `Cylinder` |
| Nastavení typu série na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Nastavení tvaru pruhu na `Box` | `ClusteredColumn3D` | `Box` |

Nastavení tvaru na `Box` také mění typ série na `ClusteredColumn3D`. Pokud váš kód rozhoduje podle typu série, zavolejte `series.getType()` po změně tvaru. Hodnota načtená před přiřazením by stále vedla k větvi `ClusteredCone`.

![Porovnání v PowerPointu ukazující první sérii jako válce, kužele a obdélníkové sloupce zleva doprava](series-shapes.png)

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s dalšími souvisejícími 3D typy dostupnými prostřednictvím třídy [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) v API referenci nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat jako obrázek pomocí [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) nebo [render the entire slide](/slides/cs/nodejs-java/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete rastrový náhled nebo chcete graf vložit do dokumentů, dashboardů nebo webových stránek bez nutnosti PowerPointu.

**Jak výkonná je tvorba a renderování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky udržujte 3D efekty na minimu, vyhněte se těžkým texturám na zdech a ploše grafu, omezte počet datových bodů na sérii, pokud je to možné, a renderujte do výstupu odpovídající velikosti (rozlišení a rozměry), aby vyhověl cílovému displeji nebo tisku.