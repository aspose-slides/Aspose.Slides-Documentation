---
title: "Diagram adat táblák testreszabása bemutatókban PHP használatával"
linktitle: "Adat tábla"
type: docs
url: /hu/php-java/chart-data-table/
keywords:
- "diagram adatok"
- "adat tábla"
- "betűtípus tulajdonságok"
- "PowerPoint"
- "bemutató"
- "PHP"
- "Aspose.Slides"
description: "Testreszabhatja a diagram adat táblákat PPT és PPTX fájlokhoz az Aspose.Slides for PHP via Java segítségével, hogy növelje a hatékonyságot és a bemutatók vonzerejét."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan kell dolgozni diagram adat táblákkal az Aspose.Slides-ban. Bemutatja, hogyan jeleníthető meg egy diagram adat táblája, valamint hogyan testreszabható a szöveg formázása betűtípus tulajdonságok, például félkövér stílus és betűmagasság beállításával. A példa bemutatja, hogyan töltsünk be egy bemutatót, adjonunk hozzá diagramot, engedélyezzük a diagram adat tábláját, alkalmazzuk a betűtípus beállításokat, és mentsük el a frissített bemutatót.

Tartalmaz rövid válaszokat a gyakori kérdésekre a diagram adat táblájában a jelmagyarázat kulcsainak megjelenítéséről, az adat tábla export közbeni megőrzéséről, a meglévő bemutatókból vagy sablonokból betöltött diagramokkal való munkáról, valamint arról, hogyan azonosíthatóak azok a diagramok, ahol az adat tábla engedélyezve van.

## **Betűtípus tulajdonságok beállítása diagram adat táblához**
Aspose.Slides for PHP via Java támogatja a sorozat színeiben a kategóriák színének módosítását.  

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztálypéldányt.
1. Adjon hozzá diagramot a diára.
1. állítsa be a diagram táblát.
1. Állítsa be a betűmagasságot.
1. Mentse el a módosított bemutatót.

Az alábbi példakód látható.  

```php
  # Üres bemutató létrehozása
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Megjeleníthetek kis jelmagyarázat kulcsokat az értékek mellett a diagram adat táblájában?**

Igen. Az adat tábla támogatja a [legend keys](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datatable/setshowlegendkey/), és be- vagy kikapcsolhatók.

**Megmarad az adat tábla a bemutató PDF, HTML vagy képek formátumba exportálásakor?**

Igen. Az Aspose.Slides a diagramot a dia részeként rendereli, így a exportált [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/hu/php-java/convert-powerpoint-to-html/)/[image](/slides/hu/php-java/convert-powerpoint-to-png/) tartalmazza a diagramot adat táblájával.

**Támogatottak az adat táblák olyan diagramoknál, amelyek sablonfájlból származnak?**

Igen. Bármely meglévő bemutatóból vagy sablonból betöltött diagram esetén ellenőrizhető és módosítható, hogy az adat tábla [is shown](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/hasdatatable/) a diagram tulajdonságainak használatával.

**Hogyan találhatom meg gyorsan, hogy mely diagramokban van engedélyezve az adat tábla?**

Vizsgálja meg minden diagram azon tulajdonságát, amely jelzi, hogy az adat tábla [is shown](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/hasdatatable/), és járja végig a diákat, hogy azonosítsa azokat a diagramokat, ahol engedélyezve van.