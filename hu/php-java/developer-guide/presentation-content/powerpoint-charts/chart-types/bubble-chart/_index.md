---
title: Buborékdiagramok testreszabása előadásokban PHP használatával
linktitle: Buborékdiagram
type: docs
url: /hu/php-java/bubble-chart/
keywords:
- buborékdiagram
- buborékméret
- méret skálázás
- méret ábrázolás
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Készítsen és testreszabjon hatékony buborékdiagramokat a PowerPointban az Aspose.Slides for PHP via Java segítségével, hogy egyszerűen javítsa adatvizualizációját."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a buborékdiagramokkal az Aspose.Slides-ban. Két konkrét testreszabási lehetőséget tárgyal: a buborékméretek skálázását a `setBubbleSizeScale` metódussal, valamint a buborékméret értékek ábrázolásának vezérlését a `setBubbleSizeRepresentation` metódussal.

A példák azt mutatják be, hogyan hozhat létre egy buborékdiagramot, állíthatja be a méret skálázását, és válthat a buborékméret ábrázolására úgy, hogy a szélességet használja. A cikk egy rövid GYIK szekciót is tartalmaz, amely tisztázza a “Buborék 3‑D‑vel” diagramtípus támogatását, megjegyzi, hogy a gyakorlati diagramkorlátok a teljesítménytől és a célnak megfelelő PowerPoint‑verziótól függenek, és elmagyarázza, hogy az exportálás megőrzi a diagram megjelenését az Aspose.Slides renderelőmotorja által.

## **Buborékdiagram méretezése**
Az Aspose.Slides for PHP via Java támogatja a buborékdiagram méretezését. Az Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) és [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) metódusok hozzá lettek adva. Az alábbi mintapélda látható.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adatok ábrázolása buborékdiagram méretekkel**
A [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) és a [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) metódusok hozzá lettek adva a [ChartSeries](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/) osztályokhoz és a kapcsolódó osztályokhoz. A **BubbleSizeRepresentation** meghatározza, hogyan vannak a buborékméret értékek ábrázolva a buborékdiagramon. Lehetséges értékek: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/BubbleSizeRepresentationType#Area) és [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Ennek megfelelően a [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/BubbleSizeRepresentationType) felsorolt típus került bevezetésre a lehetséges ábrázolási módok megadásához. Az alábbiakban látható egy mintakód.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Támogatott a “buborékdiagram 3‑D‑effekttel”, és miben különbözik a szokásostól?**

Igen. Létezik egy külön diagramtípus, a “Bubble with 3‑D”. 3‑D‑stílust alkalmaz a buborékokra, de nem ad hozzá további tengelyt; az adatok továbbra is X‑Y‑S (méret) formában maradnak. A típus elérhető a [chart type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/) osztályban.

**Van korlátozás a sorok és pontok számát illetően egy buborékdiagramon?**

Az API szintjén nincs szigorú korlát; a korlátokat a teljesítmény és a célnak megfelelő PowerPoint‑verzió határozza meg. Ajánlott a pontok számát ésszerűen tartani az olvashatóság és a renderelési sebesség érdekében.

**Hogyan befolyásolja az exportálás egy buborékdiagram megjelenését (PDF, képek)?**

A támogatott formátumokba történő exportálás megőrzi a diagram megjelenését; a renderelést az Aspose.Slides motor végzi. Raszteres/vektoralapú formátumok esetén általános diagramgrafikai renderelési szabályok érvényesek (felbontás, anti‑aliasing), ezért nyomtatáshoz megfelelő DPI‑t válasszon.