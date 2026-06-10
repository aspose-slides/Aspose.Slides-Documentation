---
title: Treemap és Sunburst diagramok adatpontjainak testreszabása Androidon
linktitle: Treemap és Sunburst diagramok adatpontjai
type: docs
url: /hu/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap diagram
- sunburst diagram
- adatpont
- címke szín
- ágazat szín
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a treemap és sunburst diagramok adatpontjait az Aspose.Slides for Android via Java segítségével, amely kompatibilis a PowerPoint formátumokkal."
---
## **Bevezetés**

A PowerPoint diagramok más típusai közül két „hierarchikus” típus létezik – **Treemap** és **Sunburst** diagram (más néven Sunburst grafikon, Sunburst diagram, Radiális diagram, Radiális grafikon vagy Többszintű kördiagram). Ezek a diagramok hierarchikus adatokat jelenítenek meg egy fa struktúrájában – a levelektől az ág tetejéig. A leveleket a sorozat adatpontjai határozzák meg, és minden további beágyazott csoportosítási szintet a megfelelő kategória definiál. Az Aspose.Slides for Android via Java lehetővé teszi a Sunburst diagram és a Treemap adatpontjainak formázását Java-ban.

Itt egy Sunburst diagram, ahol a Series1 oszlopban lévő adatok határozzák meg a levélcsomópontokat, míg a többi oszlop hierarchikus adatpontokat definiál:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Kezdjük egy új Sunburst diagram hozzáadásával a bemutatóhoz:

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
- [**PowerPoint bemutató diagramok létrehozása vagy frissítése Androidon**](/slides/hu/androidjava/create-chart/)
{{% /alert %}}

Ha szükség van a diagram adatpontjainak formázására, a következőket kell használni:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataPointLevelsManager), [IChartDataPointLevel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataPointLevel) osztályok és [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) metódus biztosítja a hozzáférést a Treemap és Sunburst diagramok adatpontjainak formázásához. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataPointLevelsManager) a több szintű kategóriák elérésére szolgál – ez képviseli a [**IChartDataPointLevel**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataPointLevel) objektumok tárolóját. 
Alapvetően ez egy burkoló a [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartCategoryLevelsManager) számára, a tulajdonságokkal, amelyek kifejezetten az adatpontokra vonatkoznak. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataPointLevel) osztálynak két metódusa van: [**getFormat**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) és [**getDataLabel**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) amelyek hozzáférést biztosítanak a megfelelő beállításokhoz.

## **Adatapont értékének megjelenítése**

A "Leaf 4" adatpont értékének megjelenítése:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Adatapont címke és szín beállítása**

"Branch 1" adatcímkét állítsa be úgy, hogy a sorozat nevét ("Series1") jelenítse meg a kategória neve helyett. Ezután állítsa a szövegszínt sárgára:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Adatapont ágazat színének beállítása**

"Steam 4" ágazat színének megváltoztatása:

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

Nem. A PowerPoint automatikusan rendezi a szegmenseket (általában csökkenő értékek szerint, óramutató járásával megegyező irányban). Az Aspose.Slides ezt a viselkedést tükrözi: a sorrendet közvetlenül nem lehet megváltoztatni; csak az adatok előfeldolgozásával érhető el.

**Hogyan befolyásolja a bemutató téma a szegmensek és címkék színeit?**

A diagram színei öröklik a bemutató [témáját/palettáját](/slides/hu/androidjava/presentation-theme/), hacsak nem állít be kifejezetten kitöltéseket vagy betűtípusokat. A következetes eredmény érdekében rögzítse a szilárd kitöltéseket és a szövegformázást a szükséges szinteken.

**Megőrzik-e a PDF/PNG exportálás során az egyedi ágazati színeket és címke beállításokat?**

Igen. A bemutató exportálásakor a diagram beállításai (kitöltések, címkék) megmaradnak a kimeneti formátumokban, mivel az Aspose.Slides a diagram formázását alkalmazva renderel.

**Kiszámíthatom-e egy címke/elem tényleges koordinátáit egy egyedi átfedés elhelyezéséhez a diagram felett?**

Igen. A diagram elrendezése validálása után az elemek (például egy [DataLabel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/datalabel/)) tényleges *x* és *y* koordinátái elérhetők, ami segít a pontos átfedéselhelyezésben.