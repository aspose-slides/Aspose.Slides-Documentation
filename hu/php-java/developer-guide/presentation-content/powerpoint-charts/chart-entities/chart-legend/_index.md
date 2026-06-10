---
title: Prezentációk diagram jelmagyarázatának testreszabása PHP használatával
linktitle: Diagram jelmagyarázat
type: docs
url: /hu/php-java/chart-legend/
keywords:
- diagram jelmagyarázat
- jelmagyarázat pozíció
- betűméret
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Testreszabhatja a diagram jelmagyarázatokat az Aspose.Slides for PHP via Java segítségével, hogy a PowerPoint prezentációkat a megfelelő jelmagyarázati formázással optimalizálja."
---
## **Áttekintés**

Az Aspose.Slides lehetőséget biztosít a diagram jelmagyarázatának testreszabására a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet elhelyezni és méretezni egy jelmagyarázatot, hogyan állítható be a teljes jelmagyarázat betűmérete, és hogyan formázható egyedi jelmagyarázati bejegyzés.  

Továbbá a GyIK-ben több kapcsolódó viselkedést is tárgyal, többek között a nem‑átfedés mód használatát, amely lehetővé teszi, hogy a diagramterület helyet biztosítson a jelmagyarázatnak, a hosszú jelmagyarázati címkék sortörésre vagy sortöréssel történő megtörésére, valamint azt, hogy a jelmagyarázat formázása öröklődjön a prezentáció sablonjából, ha nem kerülnek beállításra explicit szöveg‑ vagy kitöltési értékek.

## **Jelmagyarázat elhelyezése**
A jelmagyarázat tulajdonságainak beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
- Szerezze meg a dia referenciáját.
- Diagram hozzáadása a diára.
- A jelmagyarázat tulajdonságainak beállítása.
- A prezentáció mentése PPTX fájlként.

Az alábbi példában beállítottuk a diagram jelmagyarázatának pozícióját és méretét.

```php
  # Hozzon létre egy példányt a Presentation osztályból
  $pres = new Presentation();
  try {
    # Szerezze meg a dia referenciáját
    $slide = $pres->getSlides()->get_Item(0);
    # Adjon hozzá egy csoportosított oszlopdiagramot a diára
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Állítsa be a jelmagyarázat tulajdonságait
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Mentse a prezentációt a lemezre
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A jelmagyarázat betűméretének beállítása**
Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára, hogy beállítsák a jelmagyarázat betűméretét. Kövesse az alábbi lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályt.
- Alapértelmezett diagram létrehozása.
- A betűméret beállítása.
- Minimum tengelyérték beállítása.
- Maximum tengelyérték beállítása.
- A prezentáció írása a lemezre.

```php
  # Hozzon létre egy példányt a Presentation osztályból
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Egyéni jelmagyarázat betűméretének beállítása**
Az Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára, hogy egyedi jelmagyarázati bejegyzések betűméretét állítsák be. Kövesse az alábbi lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályt.
- Alapértelmezett diagram létrehozása.
- Hozzáférés a jelmagyarázati bejegyzéshez.
- A betűméret beállítása.
- Minimum tengelyérték beállítása.
- Maximum tengelyérték beállítása.
- A prezentáció írása a lemezre.

```php
  # Hozzon létre egy példányt a Presentation osztályból
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Engedélyezhetem a jelmagyarázatot úgy, hogy a diagram automatikusan helyet biztosítson számára az átfedés helyett?**

Igen. Használja a nem‑átfedés módot ([setOverlay(false)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/legend/setoverlay/)); ebben az esetben a diagramterület összezsugorodik, hogy helyet biztosítson a jelmagyarázatnak.

**Készíthetek több soros jelmagyarázati címkéket?**

Igen. A hosszú címkék automatikusan megtörnek, ha nincs elég hely; a sorok kényszerített megtörése a sorozat nevében lévő újsor karakterekkel támogatott.

**Hogyan tehetem, hogy a jelmagyarázat a prezentáció sablonjának színsémáját kövesse?**

Ne állítson be explicit színeket/kitöltéseket/betűtípusokat a jelmagyarázathoz vagy a szövegéhez. Ebben az esetben azok a sablonból öröklődnek, és a tervezés módosulásakor megfelelően frissülnek.