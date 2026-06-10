---
title: "Adatpontok testreszabása Treemap és Sunburst diagramokban PHP használatával"
linktitle: "Adatpontok Treemap és Sunburst diagramokban"
type: docs
url: /hu/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap diagram
- sunburst diagram
- adatpont
- címke szín
- ág szín
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti az adatpontokat treemap és sunburst diagramokban az Aspose.Slides for PHP via Java segítségével, amely kompatibilis a PowerPoint formátumokkal."
---
## **Bevezetés**

A PowerPoint diagramok más típusai közül léteznek két „hierarchikus” típus – **Treemap** és **Sunburst** diagram (más néven Sunburst Graph, Sunburst Diagram, Radiális diagram, Radiális grafikon vagy Többszintű kördiagram). Ezek a diagramok hierarchikus adatokat jelenítenek meg fa struktúrában – a levelektől az ág tetejéig. A leveleket a sorozat adatpontok határozzák meg, és minden további beágyazott csoportosítási szint a megfelelő kategória által definiált. Az Aspose.Slides for PHP via Java lehetővé teszi a Sunburst és Treemap diagram adatpontjainak formázását.

Itt egy Sunburst diagram, ahol a Series1 oszlop adatai határozzák meg a levél csomópontokat, míg a többi oszlop a hierarchikus adatpontokat definiálja:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Kezdjük egy új Sunburst diagram hozzáadásával a prezentációhoz:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="See also" %}} 
- [**PowerPoint prezentáció diagramok létrehozása vagy frissítése PHP‑ban**](/slides/hu/php-java/create-chart/)
{{% /alert %}}

Ha szükség van a diagram adatpontjainak formázására, a következőket kell használni:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointlevelsmanager/), [**ChartDataPointLevel**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointlevel/) osztályok és [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) metódus biztosítja a Treemap és Sunburst diagramok adatpontjainak formázásához való hozzáférést. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointlevelsmanager/) a több szintű kategóriák elérésére szolgál – ez a [**ChartDataPointLevel**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointlevel/) objektumok tárolóját képviseli. Alapvetően egy burkoló a [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartcategorylevelsmanager/) számára, amely a adatpontokra vonatkozó speciális tulajdonságokat tartalmaz. A [**ChartDataPointLevel**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointlevel/) osztálynak két metódusa van: [**getFormat**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointlevel/#getFormat) és [**getDataLabel**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointlevel/#getLabel), amelyek hozzáférést biztosítanak a megfelelő beállításokhoz.

## **Adatpont értékének megjelenítése**
A „Leaf 4” adatpont értékének megjelenítése:

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Adatpont címkéjének és színének beállítása**
Állítsa be a „Branch 1” adatcímkét úgy, hogy a sorozat neve („Series1”) jelenjen meg a kategória neve helyett. Ezután állítsa a szövegszínt sárgára:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Adatpont ág színének beállítása**
A „Steam 4” ág színének módosítása:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **GYIK**

**Módosíthatom a szegmensek sorrendjét (rendezését) a Sunburst/Treemap diagramokban?**

Nem. A PowerPoint automatikusan rendezi a szegmenseket (általában csökkenő értékek szerint, óramutató járásával megegyező irányban). Az Aspose.Slides ezt a viselkedést tükrözi: nem változtatható meg közvetlenül a sorrend; ezt az adatfeldolgozás előkészítésével érhetjük el.

**Hogyan befolyásolja a prezentáció témája a szegmensek és címkék színeit?**

A diagram színei a prezentáció [témáját/palettáját](/slides/hu/php-java/presentation-theme/) öröklik, hacsak nem állítja be kifejezetten a kitöltéseket/fontokat. A következetes eredmény érdekében rögzítse a szilárd kitöltéseket és a szövegformázást a szükséges szinteken.

**Megőrzi a PDF/PNG exportálás a saját ág színeket és a címkék beállításait?**

Igen. A prezentáció exportálásakor a diagram beállításai (kitöltések, címkék) megmaradnak a kimeneti formátumokban, mivel az Aspose.Slides a diagram formázását alkalmazva renderel.

**Képes vagyok kiszámolni egy címke/elem tényleges koordinátáit egyedi átfedés elhelyezéséhez a diagram felett?**

Igen. A diagram elrendezésének ellenőrzése után a tényleges *x* és *y* koordináták elérhetők az elemekhez (például egy [DataLabel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datalabel/)), ami segít a pontos átfedéspozícionálásban.