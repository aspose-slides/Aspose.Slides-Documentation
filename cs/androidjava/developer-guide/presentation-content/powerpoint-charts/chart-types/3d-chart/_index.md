---
title: Přizpůsobení 3D grafů v prezentacích na Androidu
linktitle: 3D graf
type: docs
url: /cs/androidjava/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvářejte 3D grafy v prezentacích PowerPoint pomocí Aspose.Slides pro Android přes Java. Nastavujte rotaci, výškové proporce, hloubku grafu a mezery mezi řadami pomocí příkladů v jazyce Java."
---
## **Přehled**

Aspose.Slides for Android via Java umožňuje přizpůsobit zobrazení 3D grafu pomocí metody [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) . Tento článek ukazuje, jak upravit rotaci, výškové proporce, hloubku, pravouhlé osy a mezery mezi řadami a poté uložit prezentaci ve formátu PPTX.

## **Nastavení rotace a hloubky 3D grafu**

Níže uvedený příklad vytvoří [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) a pomocí [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) přidá do jejího prvního snímku sloupcový 3D graf se zásobníkem. Nahradí výchozí řady a kategorie dvěma řadami, každá se třemi hodnotami. Index listu `0` určuje první datový list grafu; řádek `0` obsahuje názvy řad a sloupec `0` názvy kategorií.

Metody [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) a [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) nastaví rotaci grafu na 40 a 270 stupňů. [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) určuje jeho hloubku na 150 % šířky, zatímco [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) povolí pravouhlé osy místo perspektivy. Výsledná prezentace obsahuje graf s těmito nastaveními 3D zobrazení.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Úprava výškových proporcí 3D grafu**

Pomocí [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) lze nastavit výšku 3D grafu jako procento jeho šířky. Tím se změní proporce 3D scény, aniž by se měnila velikost objektu grafu na snímku.

Následující příklad vytvoří graf typu [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) s výchozími daty: tři řady a čtyři kategorie. Uloží tři prezentace s výškovými proporcemi 50 %, 100 % a 200 %. Pozice, šířka a výška grafu zůstávají pevné. Data, rotace, hloubka, mezera mezi řadami a formátování jsou ve všech třech souborech stejné; mění se pouze procento výšky.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Následující obrázky ukazují stejná nastavení výšky v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint. Menší procento vytváří plošší scénu, zatímco větší procento vytváří vyšší scénu ve stejném objektu grafu. PowerPoint může také upravit intervaly os a umístění popisků, aby scéna lépe zapadla.

| Výška: 50% | Výška: 100% | Výška: 200% |
| --- | --- | --- |
| ![3D sloupcový graf s výškou nastavenou na 50 procent šířky](height_percent_50.png) | ![3D sloupcový graf s výškou nastavenou na 100 procent šířky](height_percent_100.png) | ![3D sloupcový graf s výškou nastavenou na 200 procent šířky](height_percent_200.png) |

Tyto metody ovlivňují různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Výška 3D scény jako procento její šířky. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Výška objektu grafu na snímku v bodech. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Hloubka 3D scény jako procento její šířky. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Mezera mezi řadami podél osy hloubky, jako procento šířky značky. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně variant válcových, kuželových a pyramídových, stejně jako 3D čárové, plošné, koláčové a povrchové grafy. Porovnání výše používá ověřený typ `Column3D`. Nastavení nemění vzhled 2D grafu `ClusteredColumn` ani grafu `BubbleWith3D`; tyto názvy jsou členy třídy [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Pro další nastavení vzhledu grafu viz [Chart Formatting](/slides/cs/androidjava/chart-formatting/).

## **Úprava mezery mezi řadami**

Pomocí [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) lze řídit vzdálenost mezi datovými řadami podél osy hloubky 3D grafu, vyjádřenou jako procento šířky značky. Použijte hodnoty **0 až 500** včetně: `0` odstraní mezeru, vyšší hodnoty mezeru zvětší. Při pevné hloubce grafu zvětšení mezery ztenčí značky podél osy hloubky.

Přístup ke skupině získáte pomocí [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--). Nastavení se vztahuje na všechny řady v této skupině, nejen na řadu, která k ní přistupuje. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) vrací mezerní hloubku a odráží nastavení nadřazené skupiny.

Toto nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich válcových, kuželových a pyramídových variant, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou řady uspořádány v hloubce, seskupené nebo zásobníkové. Pro jasné srovnání mezer mezi oddělenými řadami použijte `ChartType.Column3D` ze třídy [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

Tyto metody ovlivňují různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Mezera mezi řadami podél osy hloubky, jako procento šířky značky. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Mezera mezi sousedními pruhy nebo sloupci, jako procento šířky pruhu nebo sloupce. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Celková hloubka grafu jako procento šířky grafu. |

Následující samostatný příklad používá výchozí data grafu, která obsahují tři řady a čtyři kategorie. Uloží dvě prezentace se stejnými daty, rotací, šířkou mezery a hloubkou grafu; mění se jen mezerní hloubka.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Následující obrázky ukazují stejná nastavení mezerní hloubky v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint.

| Mezerní hloubka: 0% | Mezerní hloubka: 500% |
| --- | --- |
| ![3D sloupcový graf bez mezery mezi řadami podél osy hloubky](gap_depth_0.png) | ![3D sloupcový graf s 500 procentní mezerou mezi řadami podél osy hloubky](gap_depth_500.png) |

## **Změna typu řady 3D a tvaru pruhu**

U seskupeného válcového grafu první řada začíná válcovým tvarem pruhu. Příklad vytiskne celočíselné hodnoty vrácené metodami [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) a [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) před a po každé změně. Tabulka uvádí odpovídající názvy konstant.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Změna první řady | Typ řady | Tvar pruhu |
| --- | --- | --- |
| Vytvoření grafu | `ClusteredCylinder` | `Cylinder` |
| Nastavení typu řady na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Nastavení tvaru pruhu na `Box` | `ClusteredColumn3D` | `Box` |

Nastavení tvaru na `Box` také mění typ řady na `ClusteredColumn3D`. Pokud váš kód provádí podmínky na základě typu řady, zavolejte `series.getType()` po změně tvaru. Hodnota uložená před přiřazením by stále vedla k větvi `ClusteredCone`.

![Porovnání v PowerPointu ukazující první řadu jako válcové, kuželové a pravoúhlé sloupce zleva doprava](series-shapes.png)

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s příbuznými 3D typy zpřístupněnými prostřednictvím třídy [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) v API referenci nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat jako obrázek pomocí [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) nebo [vyrendrovat celý snímek](/slides/cs/androidjava/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete rastrový náhled nebo chcete graf vložit do dokumentů, dashboardů či webových stránek bez nutnosti PowerPointu.

**Jak výkonná je tvorba a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky udržujte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a ploše grafu, omezte počet datových bodů na řadu, pokud je to možné, a vykreslujte do vhodně velkého výstupu (rozlišení a rozměry), aby odpovídal cílovému zobrazení nebo tisku.