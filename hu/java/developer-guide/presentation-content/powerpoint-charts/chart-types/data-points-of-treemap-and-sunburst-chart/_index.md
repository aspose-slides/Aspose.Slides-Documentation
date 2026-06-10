---
title: "Adatpontok testreszabása Treemap és Sunburst diagramokban Java segítségével"
linktitle: "Adatpontok a Treemap és Sunburst diagramokban"
type: docs
url: /hu/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap diagram
- sunburst diagram
- adatpont
- címke színe
- ág színe
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan kezelheti az adatpontokat a treemap és sunburst diagramokban az Aspose.Slides for Java segítségével, amely kompatibilis a PowerPoint formátumokkal."
---
## **Bevezetés**

A PowerPoint diagramok egyéb típusain kívül létezik két „hierarchikus” típus – **Treemap** és **Sunburst** diagram (más néven Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph vagy Multi Level Pie Chart). Ezek a diagramok hierarchikus adatokat jelenítenek meg, egy fát alkotva – a levelektől az ág tetejéig. A leveleket a sorozat adatpontjai határozzák meg, és minden további beágyazott csoportosítási szint a megfelelő kategória által definiált. Az Aspose.Slides for Java lehetővé teszi a Sunburst Diagram és a Treemap adatpontjainak formázását Java-ban.

Itt egy Sunburst diagram, ahol a Series1 oszlop adatai definiálják a levélcsomókat, míg a többi oszlop hierarchikus adatpontokat definiál:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Kezdjük egy új Sunburst diagram hozzáadásával a prezentációhoz:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Lásd még" %}} 
- [**PowerPoint prezentáció diagramjainak létrehozása vagy frissítése Java-ban**](/slides/hu/java/create-chart/)
{{% /alert %}}

Ha szükség van a diagram adatpontjainak formázására, a következőket kell használnunk:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataPointLevelsManager), [**IChartDataPointLevel**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataPointLevel) osztályok és [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) metódus biztosítja a hozzáférést a Treemap és a Sunburst diagramok adatpontjainak formázásához. A [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataPointLevelsManager) a többszintű kategóriák elérésére szolgál – a [**IChartDataPointLevel**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataPointLevel) objektumok tárolóját képviseli. Alapvetően ez egy burkoló a [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartCategoryLevelsManager) számára, a tulajdonságokkal, amelyek kifejezetten az adatpontokra vonatkoznak. A [**IChartDataPointLevel**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataPointLevel) osztálynak két metódusa van: [**getFormat**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataPointLevel#getFormat--) és [**getDataLabel**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataPointLevel#getLabel--) ami hozzáférést biztosít a megfelelő beállításokhoz.

## **Adatpont értékének megjelenítése**

A „Leaf 4” adatpont értékének megjelenítése:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Adatpont címkéjének és színének beállítása**

Állítsa be a „Branch 1” adatcímkét úgy, hogy a sorozat neve („Series1”) jelenjen meg a kategória neve helyett. Ezután állítsa a szövegszínt sárgára:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Adatpont ágszínének beállítása**

A „Steam 4” ág színének módosítása:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **GYIK**

**Módosíthatom a szegmensek sorrendjét (rendezését) a Sunburst/Treemap diagramokban?**

Nem. A PowerPoint automatikusan rendezi a szegmenseket (általában csökkenő értékek szerint, óramutató járásával megegyező irányban). Az Aspose.Slides ezt a viselkedést tükrözi: a sorrendet közvetlenül nem lehet megváltoztatni; a feldolgozást előzetesen kell elvégezni az adatokon.

**Hogyan befolyásolja a prezentáció témája a szegmensek és címkék színeit?**

A diagram színei öröklik a prezentáció [témát/palettát](/slides/hu/java/presentation-theme/), hacsak nem állítja be kifejezetten a kitöltéseket/fontokat. A konzisztens eredményekhez rögzítse a szilárd kitöltéseket és a szövegformázást a szükséges szinteken.

**Megőrzi a PDF/PNG export a saját ág színeket és címke beállításokat?**

Igen. A prezentáció exportálásakor a diagram beállításai (kitöltések, címkék) megmaradnak a kimeneti formátumokban, mivel az Aspose.Slides a diagram formázásával rendereli őket.

**Kiszámolhatom a címke/elem tényleges koordinátáit egy egyéni átfedés elhelyezéséhez a diagram felett?**

Igen. A diagram elrendezésének ellenőrzése után a tényleges *x* és *y* értékek elérhetők az elemekhez (például egy [DataLabel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/datalabel/)), ami segít a pontos átfedés elhelyezésében.