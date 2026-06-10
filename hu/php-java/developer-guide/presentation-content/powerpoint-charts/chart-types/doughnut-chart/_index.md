---
title: Testreszabott fánkdiagramok prezentációkban PHP használatával
linktitle: Fánkdiagram
type: docs
weight: 30
url: /hu/php-java/doughnut-chart/
keywords:
- fánkdiagram
- középső rés
- lyuk mérete
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat fánkdiagramokat az Aspose.Slides PHP számára Java útján, támogatva a PowerPoint formátumokat a dinamikus prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk fánkdiagrammal az Aspose.Slides-ban úgy, hogy a diagramot egy diára helyezzük, beállítjuk a középső lyuk méretét, és elmentjük a prezentációt. A `setDoughnutHoleSize` metódusra összpontosít, és bemutatja az alapvető lépéseket, amelyek a diagramtípus kódon belüli testreszabásához szükségesek.

Rövid GYIK‑ot is tartalmaz, amely a kapcsolódó fánkdiagram‑szcenáriókat tárgyalja, például több sorozat használatát több gyűrű létrehozásához, a széteső fánkdiagramok kezelését és a diagram exportálását raszterkép vagy SVG formátumba.

## **A középső lyuk méretének megadása egy fánkdiagramon**

A fánkdiagram lyukméretének megadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) objektumot.
1. Adjon hozzá fánkdiagramot a diára.
1. Adja meg a lyuk méretét a fánkdiagramon.
1. Írja a prezentációt lemezre.

Az alább bemutatott példában beállítottuk a lyuk méretét a fánkdiagramon.

```php
  # Hozzon létre egy Presentation osztály példányt
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Írja a prezentációt lemezre
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Létrehozhatok több szintű fánkot több gyűrűvel?**

Igen. Adjon hozzá több sorozatot egyetlen fánkdiagramhoz — minden sorozat külön gyűrűvé válik. A gyűrűk sorrendje a sorozatok kollekcióban betöltött sorrendje alapján alakul.

**Támogatott a „széteső” fánk (különálló szeletekkel)?**

Igen. Létezik egy Exploded Doughnut [chart type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/) és egy robbanás tulajdonság az adatpontokon; egyes szeleteket szétválaszthat.

**Hogyan szerezhetek képet egy fánk diagramról (PNG/SVG) egy jelentéshez?**

A diagram egy alakzat; renderelheti egy [raster image](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage) vagy exportálhatja a diagramot egy [SVG image](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#writeAsSvg) formátumba.