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
description: "Vytvářejte 3D grafy v prezentacích PowerPoint pomocí Aspose.Slides pro Android prostřednictvím Javy. Nastavujte rotaci, výškové poměry, hloubku grafu a rozestupy mezi řadami pomocí příkladů v Javě."
---
## **Přehled**

Aspose.Slides for Android via Java vám umožňuje přizpůsobit zobrazení 3D grafu pomocí metody [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--). Tento článek demonstruje, jak upravit rotaci, výškové poměry, hloubku, pravoúhlé osy a rozestupy mezi řadami a poté uložit prezentaci ve formátu PPTX.

## **Nastavení rotace a hloubky 3D grafu**

Příklad níže vytváří [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) a pomocí [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) přidá na první snímek vrstvený 3D sloupcový graf. Nahrazuje výchozí řady a kategorie dvěma řadami, z nichž každá obsahuje tři hodnoty. Index listu `0` určuje první datový list grafu; řádek `0` obsahuje názvy řad a sloupec `0` obsahuje štítky kategorií.

Metody [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) a [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) nastaví rotaci grafu na 40 a 270 stupňů. [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) určuje jeho hloubku na 150 % šířky, zatímco [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) povolí pravoúhlé osy namísto perspektivy. Výsledná prezentace obsahuje graf s těmito nastaveními 3D zobrazení.

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

## **Použití obrázkového výplně na povrchu 3D grafu**

3D graf má tři povrchy, které můžete vyplnit nezávisle: [side wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--), [back wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) a [floor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--). Nastavte [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) povrchu na `Picture` a přiřaďte obrázek. Nastavte jak [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-), tak [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) na `Stretch`, aby se na povrchu zobrazila jedna kopie obrázku.

Uložte [arrow.png](arrow.png) do pracovního adresáře. Příklad otáčí graf a zvyšuje maximální hodnotu na svislé ose, aby byla podlaha viditelná mezi sloupci. Poté duplikuje snímek dvakrát a na každém snímku použije šipku na jiný povrch. Všechny tři grafy zachovávají stejné data, úhel pohledu a pozadí.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
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

    IPPImage arrow = presentation.getImages().addImage(image);

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
| ![Šipka ukazující do grafu podél boční stěny](side-wall.png) | ![Šipka ukazující doprava přes zadní stěnu](back-wall.png) | ![Šipka ukazující doprava po podlaze mezi sloupci](floor.png) |

## **Upravení výškových poměrů 3D grafu**

Použijte [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) k nastavení výšky 3D grafu jako procenta jeho šířky. Tím změníte poměry 3D scény, aniž byste měnili velikost objektu grafu na snímku.

Následující příklad vytváří graf typu [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) s výchozími daty: tři řady a čtyři kategorie. Uloží tři prezentace s výškovými poměry 50 %, 100 % a 200 %. Pozice, šířka a výška grafu zůstávají pevné. Data, rotace, hloubka, rozestup řad a formátování jsou ve všech třech souborech identické; mění se jen výškové procento.

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

Následující obrázky ilustrují stejná výšková nastavení v ekvivalentním .NET příkladu a byly exportovány pomocí Microsoft PowerPoint. Menší procento vytvoří plošší scénu, zatímco větší procento vytvoří vyšší scénu ve stejném objektu grafu. PowerPoint může také upravit intervaly značek os a umístění popisků, aby se scéna vešla.

| Výška: 50% | Výška: 100% | Výška: 200% |
| --- | --- | --- |
| ![3D sloupcový graf s výškou nastavenou na 50 % své šířky](height_percent_50.png) | ![3D sloupcový graf s výškou nastavenou na 100 % své šířky](height_percent_100.png) | ![3D sloupcový graf s výškou nastavenou na 200 % své šířky](height_percent_200.png) |

Tyto metody řídí různé aspekty grafu:

| Metoda | Účinek |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Výška 3D scény jako procento její šířky. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Výška objektu grafu na snímku v bodech. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Hloubka 3D scény jako procento její šířky. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Rozestup mezi řadami podél osy hloubky jako procento šířky značky. |

Nastavení výšky ovlivňuje 3D sloupcové a pruhové grafy, včetně variant válec, kužel a pyramida, stejně jako 3D čárové, plošné, koláčové a povrchové grafy. Porovnání výše používá ověřený typ `Column3D`. Nastavení nemění vzhled 2D grafu `ClusteredColumn` ani grafu `BubbleWith3D`; tyto názvy jsou členy třídy [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Pro další nastavení vzhledu grafu viz [Chart Formatting](/slides/cs/androidjava/chart-formatting/).

## **Úprava mezery mezi řadami**

Použijte [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) k řízení vzdálenosti mezi řadami dat podél osy hloubky 3D grafu, vyjádřené jako procento šířky značky. Používejte hodnoty od **0 do 500**, včetně: `0` odstraní mezeru, vyšší hodnoty mezery zvětší. Při pevné hloubce grafu zvětšení mezery způsobí tenčí značky podél osy hloubky.

Přístup ke skupině získáte pomocí [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--). Nastavení se aplikuje na každou řadu ve skupině, nejen na řadu použité pro přístup. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) vrací hloubkovou mezeru a odráží nastavení nadřazené skupiny.

Toto nastavení ovlivňuje 3D sloupcové a pruhové grafy, včetně jejich válec, kužel a pyramida variant, stejně jako 3D čárové a plošné grafy. Vzhled závisí na tom, zda jsou řady uspořádány do hloubky, shluků nebo vrstev. Pro jasné srovnání mezer mezi samostatnými řadami použijte `ChartType.Column3D` ze třídy [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

Tyto metody řídí různé aspekty grafu:

| Metoda | Účinek |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Rozestup mezi řadami podél osy hloubky jako procento šířky značky. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Rozestup mezi sousedními shluky sloupců nebo pruhů jako procento šířky sloupce nebo pruhu. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Celková hloubka grafu jako procento šířky grafu. |

Následující samostatný příklad používá výchozí data grafu, která obsahují tři řady a čtyři kategorie. Uloží dvě prezentace se stejnými daty, rotací, šířkou mezery a hloubkou grafu; mění se pouze hloubka mezery.

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

| Hloubka mezery: 0% | Hloubka mezery: 500% |
| --- | --- |
| ![3D sloupcový graf bez mezery mezi řadami podél osy hloubky](gap_depth_0.png) | ![3D sloupcový graf s 500 % mezerou mezi řadami podél osy hloubky](gap_depth_500.png) |

## **Změna typu 3D řady a tvaru pruhu**

V shlukovaném válcovém grafu první řada začíná válcovým tvarem pruhu. Příklad vypisuje celočíselné hodnoty vrácené metodami [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) a [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) před a po každé změně. Tabulka uvádí odpovídající názvy konstant.

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

Nastavení tvaru na `Box` také změní typ řady na `ClusteredColumn3D`. Pokud váš kód přepíná podle typu řady, zavolejte `series.getType()` po změně tvaru. Hodnota uložená před přiřazením by stále vybrala větev `ClusteredCone`.

![Porovnání v PowerPointu ukazující první řadu jako válcové, kuželové a obdélníkové sloupce zleva doprava](series-shapes.png)

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s souvisejícími 3D typy vystavenými třídou [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Pro úplný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) v API referenci nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat do obrázku pomocí [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) nebo [render the entire slide](/slides/cs/androidjava/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete rastrový náhled nebo chcete vložit graf do dokumentů, nástěnek nebo webových stránek bez nutnosti PowerPointu.

**Jaká je výkonnost vytváření a vykreslování velkých 3D grafů?**

Výkonnost závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky udržujte 3D efekty na minimu, vyhýbejte se těžkým texturám na zdech a ploše grafu, omezte počet datových bodů v řadě, pokud je to možné, a renderujte do vhodně dimenzovaného výstupu (rozlišení a rozměry), který odpovídá cílovému displeji nebo tisku.