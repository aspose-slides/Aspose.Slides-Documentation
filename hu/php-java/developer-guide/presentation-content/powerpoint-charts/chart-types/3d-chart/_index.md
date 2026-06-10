---
title: Testreszabott 3D diagramok prezentációkban PHP használatával
linktitle: 3D diagram
type: docs
url: /hu/php-java/3d-chart/
keywords:
- 3D diagram
- forgás
- mélység
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre és testreszabhat 3-D diagramokat az Aspose.Slides for PHP via Java segítségével, PPT és PPTX fájlok támogatásával — növelje prezentációi hatékonyságát még ma."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet testreszabni egy 3D diagramot az Aspose.Slides-ban a `Rotation3D` beállítások, például a `RotationX`, `RotationY`, `DepthPercents` és a `RightAngleAxes` konfigurálásával. Bemutatja a prezentáció létrehozását, egy alapértelmezett adatokkal rendelkező 3D diagram hozzáadását, a szükséges 3D nézetbeállítások alkalmazását, és a módosított prezentáció PPTX fájlként történő mentését.

## **A 3D diagram RotationX, RotationY és DepthPercents tulajdonságainak beállítása**

Az Aspose.Slides for PHP via Java egyszerű API-t biztosít ezen tulajdonságok beállításához. A következő cikk segít a különböző tulajdonságok, például **X,Y Rotation, DepthPercents** stb. beállításában. A mintakód alkalmazza a fent említett tulajdonságok beállítását.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Érje el az első diát.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal.
4. Állítsa be a Rotation3D tulajdonságokat.
5. Írja a módosított prezentációt PPTX fájlba.

```php
    $pres = new Presentation();
    try {
        # Első dia elérése
        $slide = $pres->getSlides()->get_Item(0);
        # Diagram hozzáadása alapértelmezett adatokkal
        $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
        # A diagram adatlap indexének beállítása
        $defaultWorksheetIndex = 0;
        # A diagram adatlapjának lekérése
        $fact = $chart->getChartData()->getChartDataWorkbook();
        # Sorozat hozzáadása
        $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
        $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
        # Kategóriák hozzáadása
        $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
        $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
        $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
        # Rotation3D tulajdonságok beállítása
        $chart->getRotation3D()->setRightAngleAxes(true);
        $chart->getRotation3D()->setRotationX(40);
        $chart->getRotation3D()->setRotationY(270);
        $chart->getRotation3D()->setDepthPercents(150);
        # A második diagram sorozat kivétele
        $series = $chart->getChartData()->getSeries()->get_Item(1);
        # Most a sorozat adatait töltjük fel
        $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
        $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
        $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
        $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
        $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
        $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
        # Overlap érték beállítása
        $series->getParentSeriesGroup()->setOverlap(100);
        # Prezentáció mentése lemezre
        $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
    } finally {
        if (!java_is_null($pres)) {
            $pres->dispose();
        }
    }
```

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides támogatja a oszlopdiagramok 3D változatait, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és a 100% Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/) osztályon keresztül érhet el. A pontos, naprakész lista megtekintéséhez ellenőrizze a [ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/) tagjait az Ön által telepített verzió API referenciajában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [chart API](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage) segítségével, vagy [az egész diát](/slides/hu/php-java/convert-powerpoint-to-png/) PNG vagy JPEG formátumba renderelheti. Ez hasznos, ha pixelpontosságú előnézetre van szüksége, vagy a diagramot dokumentumokba, irányítópultokba vagy weboldalakba szeretné beágyazni PowerPoint nélkül.

**Mennyire teljesítményorientált a nagy 3D diagramok létrehozása és renderelése?**

A teljesítmény az adatmennyiségtől és a vizuális összetettségtől függ. A legjobb eredmény eléréséhez tartsa minimális szinten a 3D effektusokat, kerülje a nehéz textúrák használatát a falakon és a diagramterületeken, korlátozza az egyes sorozatok adatpontjainak számát, ha lehetséges, és rendereljen megfelelő méretű kimenetre (felbontás és méretek), hogy megfeleljen a célkijelző vagy nyomtatási igényeknek.