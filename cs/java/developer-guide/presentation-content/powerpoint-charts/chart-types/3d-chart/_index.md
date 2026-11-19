---
title: Přizpůsobení 3D grafů v prezentacích pomocí Javy
linktitle: 3D graf
type: docs
url: /cs/java/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvořte 3D grafy v prezentacích PowerPoint pomocí Aspose.Slides pro Javu. Upravit rotaci, poměry výšky, hloubku grafu a mezery mezi sériemi pomocí příkladů v Javě."
---
## **Přehled**

Aspose.Slides for Java vám umožňuje přizpůsobit zobrazení 3D grafu pomocí metody [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . Tento článek ukazuje, jak upravit rotaci, poměry výšky, hloubku, osy pod pravým úhlem a mezery mezi sériemi a poté uložit prezentaci ve formátu PPTX.

## **Nastavení rotace a hloubky 3D grafu**

Níže uvedený příklad vytvoří objekt [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) a pomocí metody [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) přidá do první snímku seskupený 3D sloupcový graf. Nahradí výchozí série a kategorie dvěma sériemi, z nichž každá obsahuje tři hodnoty. Index listu `0` identifikuje první datový list grafu; řádek `0` obsahuje názvy sérií a sloupec `0` obsahuje popisky kategorií.

Metody [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) a [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) nastaví rotaci grafu na 40 a 270 stupňů. Metoda [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) nastaví jeho hloubku na 150 % šířky, zatímco [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) povolí osy pod pravým úhlem místo perspektivy. Výsledná prezentace obsahuje graf s těmito nastaveními 3D zobrazení.

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

## **Úprava poměrů výšky 3D grafu**

Použijte [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) k nastavení výšky 3D grafu jako procenta jeho šířky. Tím se změní poměry 3D scény, aniž by se změnila velikost objektu grafu na snímku.

Následující příklad vytvoří graf typu [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) s výchozími daty: tři série a čtyři kategorie. Uloží tři prezentace s poměry výšky 50 %, 100 % a 200 %. Pozice, šířka a výška grafu zůstávají pevně dané. Data, rotace, hloubka, mezery mezi sériemi a formátování jsou ve všech třech souborech stejné; mění se pouze procento výšky.

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

Následující obrázky ilustrují stejná nastavení výšky v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint. Menší procento produkuje plošší scénu, vyšší procento vyšší scénu ve stejném objektu grafu. PowerPoint může také upravit intervaly osových značek a umístění popisků, aby scénu přizpůsobil.

| Výška: 50% | Výška: 100% | Výška: 200% |
| --- | --- | --- |
| ![3D sloupcový graf s výškou nastavenou na 50 percent své šířky](height_percent_50.png) | ![3D sloupcový graf s výškou nastavenou na 100 percent své šířky](height_percent_100.png) | ![3D sloupcový graf s výškou nastavenou na 200 percent své šířky](height_percent_200.png) |

Tyto metody řídí různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Výška 3D scény jako procento její šířky. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Výška objektu grafu na snímku v bodech. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Hloubka 3D scény jako procento její šířky. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Mezera mezi sériemi podél osy hloubky jako procento šířky značky. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně variant válcových, kuželových a pyramidových, stejně jako 3D čárové, plošné, koláčové a povrchové grafy. Porovnání výše používá ověřený typ `Column3D`. Nastavení nemění vzhled 2D grafu `ClusteredColumn` ani grafu `BubbleWith3D`; tyto názvy jsou členy třídy [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Další nastavení vzhledu grafu naleznete v [Chart Formatting](/slides/cs/java/chart-formatting/).

## **Úprava mezery mezi sériemi**

Použijte [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) k řízení vzdálenosti mezi datovými sériemi podél osy hloubky 3D grafu, vyjádřené jako procento šířky značky. Použijte hodnoty od **0 do 500**, včetně: `0` odstraní mezeru, vyšší hodnoty mezeru zvětší. Při pevné hloubce grafu zvětšuje větší mezera tenkost značek podél osy hloubky.

Přístup ke skupině získáte pomocí [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . Nastavení se vztahuje na všechny série v této skupině, nejen na sérii, přes kterou byl přístup získán. Metoda [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) vrací aktuální mezery a odráží nastavení nadřazené skupiny.

Toto nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich válcových, kuželových a pyramidových variant, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou série uspořádány v hloubce, seskupeny nebo vrstveny. Pro jasné srovnání mezer mezi samostatnými sériemi použijte `ChartType.Column3D` ze třídy [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

Tyto metody řídí různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Mezera mezi sériemi podél osy hloubky jako procento šířky značky. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Mezera mezi sousedními sloupci nebo pruhy jako procento šířky sloupce či pruhu. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Celková hloubka grafu jako procento šířky grafu. |

Níže uvedený samostatný příklad používá výchozí data grafu, která obsahují tři série a čtyři kategorie. Uloží dvě prezentace se stejnými daty, rotací, šířkou mezery a hloubkou grafu; mění se jen hloubka mezery.

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

Následující obrázky ukazují stejná nastavení mezery v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint.

| Mezera hloubky: 0% | Mezera hloubky: 500% |
| --- | --- |
| ![3D sloupcový graf bez mezery mezi sériemi podél osy hloubky](gap_depth_0.png) | ![3D sloupcový graf s mezery 500 percent mezi sériemi podél osy hloubky](gap_depth_500.png) |

## **Změna typu 3D série a tvaru sloupce**

V grafu seskupených válcových sloupců první série začíná cylindrickým tvarem sloupce. Příklad tiskne celá čísla vrácená metodami [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) a [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) před a po každé změně. Tabulka uvádí odpovídající konstantní názvy.

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

| Změna první série | Typ série | Tvar sloupce |
| --- | --- | --- |
| Vytvořit graf | `ClusteredCylinder` | `Cylinder` |
| Nastavit typ série na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Nastavit tvar sloupce na `Box` | `ClusteredColumn3D` | `Box` |

Nastavení tvaru na `Box` také mění typ série na `ClusteredColumn3D`. Pokud váš kód provádí rozhodování podle typu série, zavolejte `series.getType()` po změně tvaru. Hodnota uložená před přiřazením by stále vedla k větvi `ClusteredCone`.

![Porovnání v PowerPointu ukazující první sérii jako válce, kužele a obdélníkové sloupce zleva doprava](series-shapes.png)

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s souvisejícími 3D typy vystavenými prostřednictvím třídy [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) v referenční dokumentaci API vaší nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat do obrázku pomocí [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) nebo [renderovat celý snímek](/slides/cs/java/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete rastrový náhled nebo chcete vložit graf do dokumentů, řídicích panelů nebo webových stránek bez nutnosti PowerPointu.

**Jak výkonná je tvorba a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky držte 3D efekty na minimu, vyhněte se těžkým texturám na zdech a ploše grafu, omezte počet datových bodů na sérii, pokud je to možné, a renderujte do vhodně dimenzovaného výstupu (rozlišení a rozměry), který odpovídá cílovému zobrazovacímu zařízení nebo tisku.