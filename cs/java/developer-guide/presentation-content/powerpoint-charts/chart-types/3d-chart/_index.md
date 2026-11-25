---
title: Přizpůsobení 3D grafů v prezentacích pomocí Java
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
description: "Vytvořte 3D grafy v PowerPoint prezentacích pomocí Aspose.Slides pro Java. Upravte rotaci, výškové proporce, hloubku grafu a mezery mezi sériemi pomocí příkladů v Java."
---
## **Přehled**

Aspose.Slides pro Java vám umožňuje přizpůsobit zobrazení 3D grafu pomocí metody [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . Tento článek ukazuje, jak upravit rotaci, proporce výšky, hloubku, pravouhlé osy a mezery mezi sériemi a poté uložit prezentaci ve formátu PPTX.

## **Nastavte rotaci a hloubku 3D grafu**

Níže uvedený příklad vytvoří [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) a pomocí [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) přidá do jejího prvního snímku sloupcový 3D graf se seskupením. Nahradí výchozí série a kategorie dvěma sériemi, z nichž každá obsahuje tři hodnoty. Index listu `0` identifikuje první datový list grafu; řádek `0` obsahuje názvy sérií a sloupec `0` názvy kategorií.

Metody [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) a [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) nastaví rotaci grafu na 40 ° a 270 °. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) nastaví jeho hloubku na 150 % šířky, zatímco [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) povolí pravouhlé osy místo perspektivy. Výsledná prezentace obsahuje naplněný graf s těmito nastaveními 3D zobrazení.

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

## **Použijte vyplnění obrázkem na povrch 3D grafu**

3D graf má tři povrchy, které můžete vyplnit nezávisle: [boční stěnu](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--), [zadní stěnu](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) a [podlahu](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--). Nastavte pro povrch [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) na `Picture` a přiřaďte obrázek. Nastavte jak [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-), tak [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) povrchu na `Stretch`, aby se jedna kopie obrázku roztáhla po celém povrchu.

Uložte soubor [arrow.png](arrow.png) do pracovního adresáře. Příklad otáčí graf a zvyšuje maximální hodnotu na svislé ose, aby byla podlaha viditelná mezi sloupci. Poté duplikuje snímek dvakrát a na každém snímku použije šipku na jiný povrch. Všechny tři grafy si zachovávají stejná data, úhel pohledu i pozadí.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint zobrazuje tři snímky následovně.

| Boční stěna | Zadní stěna | Podlaha |
| --- | --- | --- |
| ![Šipka ukazující do grafu podél boční stěny](side-wall.png) | ![Šipka ukazující doprava přes zadní stěnu](back-wall.png) | ![Šipka ukazující doprava přes podlahu mezi sloupci](floor.png) |

## **Upravte výškové proporce 3D grafu**

Pomocí [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) nastavíte výšku 3D grafu jako procento jeho šířky. Tím změníte proporce 3D scény, aniž byste měnili velikost objektu grafu na snímku.

Následující příklad vytvoří graf typu [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) s výchozími daty: tři série a čtyři kategorie. Uloží tři prezentace s výškovými proporcemi 50 %, 100 % a 200 %. Pozice, šířka i výška grafu zůstávají pevné. Data, rotace, hloubka, mezera mezi sériemi a formátování jsou ve všech třech souborech shodné; mění se jen výškové procento.

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

Následující obrázky ilustrují stejná nastavení výšky v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint. Menší procento vytváří plošší scénu, zatímco větší procento dává vyšší scénu ve stejném objektu grafu. PowerPoint může také upravit intervaly značek os a umístění popisků, aby scénu přizpůsobil.

| Výška: 50 % | Výška: 100 % | Výška: 200 % |
| --- | --- | --- |
| ![3D sloupcový graf s výškou nastavenou na 50 % šířky](height_percent_50.png) | ![3D sloupcový graf s výškou nastavenou na 100 % šířky](height_percent_100.png) | ![3D sloupcový graf s výškou nastavenou na 200 % šířky](height_percent_200.png) |

Tyto metody řídí různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Výška 3D scény jako procento její šířky. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Výška objektu grafu na snímku v bodech. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Hloubka 3D scény jako procento její šířky. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Mezery mezi sériemi podél osy hloubky jako procento šířky značky. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně variant válec, kužel a pyramid, stejně jako 3D čárové, plošné, koláčové a povrchové grafy. Porovnání výše používá ověřený typ `Column3D`. Nastavení nemění vzhled 2D grafu `ClusteredColumn` ani grafu `BubbleWith3D`; tyto názvy jsou členy třídy [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Pro další nastavení vzhledu grafu viz [Chart Formatting](/slides/cs/java/chart-formatting/).

## **Upravte mezeru mezi sériemi**

Použijte [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) k řízení vzdálenosti mezi datovými sériemi podél osy hloubky 3D grafu, vyjádřené jako procento šířky značky. Používejte hodnoty od **0 do 500** včetně: `0` odstraní mezeru, vyšší hodnoty mezeru zvětší. Při pevné hloubce grafu zvětšení mezery způsobí, že značky budou podél osy hloubky tenčí.

Skupinu získáte přes [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--). Nastavení se uplatní na všechny série ve skupině, ne jen na tu, přes kterou přístup provedete. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) vrací mezery v hloubce a odráží nastavení nadřazené skupiny.

Toto nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich válec, kužel a pyramid variant, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou série uspořádány v hloubce, seskupeny nebo vrstveny. Pro přehledné porovnání mezer mezi oddělenými sériemi použijte `ChartType.Column3D` ze třídy [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

Tyto metody řídí různé aspekty grafu:

| Metoda | Efekt |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Mezery mezi sériemi podél osy hloubky jako procento šířky značky. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Mezery mezi sousedními skupinami sloupků nebo pruhů jako procento šířky sloupku nebo pruhu. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Celková hloubka grafu jako procento šířky grafu. |

Následující samostatný příklad používá výchozí data grafu, která obsahují tři série a čtyři kategorie. Uloží dvě prezentace se stejnými daty, rotací, šířkou mezery a hloubkou grafu; mění se jen hloubka mezery.

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

Následující obrázky ilustrují stejná nastavení hloubky mezery v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint.

| Hloubka mezery: 0 % | Hloubka mezery: 500 % |
| --- | --- |
| ![3D sloupcový graf bez mezery mezi sériemi podél osy hloubky](gap_depth_0.png) | ![3D sloupcový graf s 500 % mezerou mezi sériemi podél osy hloubky](gap_depth_500.png) |

## **Změňte typ 3D série a tvar sloupce**

V grafu se seskupeným válcem první série začíná tvarem válcového sloupce. Příklad vypisuje celá čísla vrácená metodami [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) a [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) před a po každé změně. Tabulka uvádí odpovídající názvy konstant.

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
| Vytvoření grafu | `ClusteredCylinder` | `Cylinder` |
| Nastavit typ série na `ClusteredCone` | `ClusteredCone` | `Cone` |
| Nastavit tvar sloupce na `Box` | `ClusteredColumn3D` | `Box` |

Nastavení tvaru na `Box` také mění typ série na `ClusteredColumn3D`. Pokud ve svém kódu podmíněně pracujete s typem série, zavolejte `series.getType()` po změně tvaru. Hodnota uložená v mezipaměti před přiřazením by stále vedla k větvi `ClusteredCone`.

![Porovnání v PowerPointu ukazující první sérii jako válce, kužele a obdélníkové sloupce zleva doprava](series-shapes.png)

## **FAQ**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s souvisejícími 3D typy, které jsou dostupné přes třídu [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) v API referenci vaší nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat jako obrázek pomocí [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) nebo [vykreslit celý snímek](/slides/cs/java/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete rastrový náhled nebo chcete graf vložit do dokumentů, řídicích panelů či webových stránek bez nutnosti PowerPointu.

**Jaké jsou výkonové charakteristiky při tvorbě a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro dosažení nejlepších výsledků udržujte 3D efekty na minimu, vyhněte se těžkým texturám na zdech a ploše grafu, omezte počet datových bodů na sérii, pokud je to možné, a vykreslujte do vhodně velkého výstupu (rozlišení a rozměry) podle cílového zařízení nebo tisku.