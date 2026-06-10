---
title: A prezentációs diagramok ábrázolási területeinek testreszabása PHP-ben
linktitle: Ábrázolási terület
type: docs
url: /hu/php-java/chart-plot-area/
keywords:
- diagram
- ábrázolási terület
- ábrázolási terület szélessége
- ábrázolási terület magassága
- ábrázolási terület mérete
- elrendezési mód
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Fedezze fel, hogyan testreszabhatja a diagramok ábrázolási területeit PowerPoint-prezentációkban az Aspose.Slides for PHP via Java segítségével. Javítsa a diák megjelenését könnyedén."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk egy diagram ábrázolási területével az Aspose.Slides-ban. Ismerteti, hogyan lehet a tényleges pozíciót és méretet meghatározni az ábrázolási terület esetében a diagram elrendezésének validálásával, majd az X, Y, szélesség és magasság értékek kiolvasásával.

Szintén bemutatja, hogyan lehet beállítani az ábrázolási terület elrendezési módját manuális elrendezés esetén, a `LayoutTargetType` használatával meghatározva, hogy az ábrázolási területet a belső vagy a külső régió (a tengelyekkel és tengelycímkékkel együtt) alapján számítja-e.

## **A diagram ábrázolási területének szélességének és magasságának lekérése**
Az Aspose.Slides for PHP via Java egyszerű API-t biztosít a .

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Nyissa meg az első diát.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal.
4. Hívja meg a [Chart.validateChartLayout](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/validatechartlayout/) metódust a tényleges értékek lekérése előtt.
5. Lekéri a diagram elem tényleges X helyzetét (bal) a diagram bal felső sarkához képest.
6. Lekéri a diagram elem tényleges felső pozícióját a diagram bal felső sarkához képest.
7. Lekéri a diagram elem tényleges szélességét.
8. Lekéri a diagram elem tényleges magasságát.

```php
  # Hozzon létre egy példányt a Presentation osztályból
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A diagram ábrázolási területének elrendezési módjának beállítása**
Az Aspose.Slides for PHP via Java egyszerű API-t nyújt a diagram ábrázolási területének elrendezési módjának beállításához. A [**setLayoutTargetType**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) és a [**getLayoutTargetType**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) metódusok hozzá lettek adva a [**ChartPlotArea**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ChartPlotArea) osztályhoz. Ha az ábrázolási terület elrendezése manuálisan van meghatározva, ez a tulajdonság megadja, hogy a területet a belső (tengelyek és tengelycímkék nélkül) vagy a külső (tengelyekkel és tengelycímkékkel együtt) alapján kell-e elrendezni. Két lehetséges érték van, amely a [**LayoutTargetType**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LayoutTargetType) felsorolásban van definiálva.

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LayoutTargetType#Inner) – azt határozza meg, hogy a plot terület mérete határozza meg a plot terület méretét, a jelölőket és tengelycímkéket nem tartalmazva.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/LayoutTargetType#Outer) – azt határozza meg, hogy a plot terület mérete határozza meg a plot terület méretét, a jelölőket és a tengelycímkéket is.

Az alábbiakban példakód található.

```php
  # Hozzon létre egy példányt a Presentation osztályból
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Milyen egységben térnek vissza a tényleges x, tényleges y, tényleges szélesség és tényleges magasság értékek?**

Pontokban; 1 hüvelyk = 72 pont. Ezek az Aspose.Slides koordináta egységek.

**Miben különbözik a Plot Area a Chart Area-tól a tartalom tekintetében?**

A Plot Area a adatok rajzolási területe (sorozatok, hálóvonalak, trendvonalak stb.); a Chart Area tartalmazza a környező elemeket (cím, jelmagyarázat stb.). 3D diagramok esetén a Plot Area tartalmazza a falakat/alkalmat és a tengelyeket is.

**Hogyan értelmeződnek a Plot Area x, y, szélesség és magasság értékei manuális elrendezés esetén?**

Ezek a diagram teljes méretének tört részei (0–1); ebben a módban az automatikus pozícionálás le van tiltva, és a megadott törteket használja.

**Miért változott meg a Plot Area pozíciója a jelmagyarázat hozzáadása/átmozgatása után?**

A jelmagyarázat a diagram területén, a Plot Area-n kívül helyezkedik el, de befolyásolja az elrendezést és a rendelkezésre álló helyet, ezért a Plot Area eltolódhat, ha az automatikus pozícionálás aktív. (Ez a PowerPoint-diagramok szokásos viselkedése.)