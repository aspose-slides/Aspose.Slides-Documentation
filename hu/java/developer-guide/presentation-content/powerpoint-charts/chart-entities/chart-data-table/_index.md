---
title: Diagram adat táblák testreszabása prezentációkban Java használatával
linktitle: Adat tábla
type: docs
url: /hu/java/chart-data-table/
keywords:
- diagram adatok
- adat tábla
- betűtípus tulajdonságok
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: Testreszabja a diagram adat táblákat Java-ban PPT és PPTX esetén az Aspose.Slides segítségével, hogy növelje a hatékonyságot és a bemutatók vonzerejét.
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozzunk a diagram adat táblákkal az Aspose.Slides-ban. Megmutatja, hogyan jelenítsünk meg egy diagramhoz adat táblát, és hogyan testreszabjuk a szöveg formázását betűtípus tulajdonságok, például félkövér stílus és betűmagasság beállításával. A példa bemutatja egy prezentáció betöltését, diagram hozzáadását, a diagram adat táblájának engedélyezését, a betűtípus beállítások alkalmazását, és a módosított prezentáció mentését.

Emellett rövid válaszokat tartalmaz a gyakori kérdésekre a legenda kulcsok megjelenítésével a diagram adat táblájában, az adat tábla exportálás közbeni megőrzésével, a meglévő prezentációkból vagy sablonokból betöltött diagramokkal való munkával, valamint a diagramok azonosításával, ahol az adat tábla engedélyezve van.

## **Betűtípus tulajdonságok beállítása a diagram adat táblájához**
Aspose.Slides for Java támogatja a sorozat színeiben lévő kategóriák színének megváltoztatását.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztálypéldányt.
1. Adjon hozzá egy diagramot a diára.
1. Állítsa be a diagram táblát.
1. Állítsa be a betű magasságát.
1. Mentse el a módosított prezentációt.

Az alábbi példakód látható.  

```java
// Üres prezentáció létrehozása
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Megjeleníthetek kis legenda kulcsokat az értékek mellett a diagram adat táblájában?**

Igen. Az adat tábla támogatja a [legend keys](https://reference.aspose.com/slides/hu/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), és be- vagy kikapcsolhatja őket.

**Megőrződik-e az adat tábla a prezentáció PDF, HTML vagy képek formátumba exportálásakor?**

Igen. Az Aspose.Slides a diagramot a dia részeként rendereli, így az exportált [PDF](/slides/hu/java/convert-powerpoint-to-pdf/)/[HTML](/slides/hu/java/convert-powerpoint-to-html/)/[image](/slides/hu/java/convert-powerpoint-to-png/) tartalmazza a diagramot a hozzá tartozó adat táblával.

**Támogatottak-e az adat táblák diagramok esetén, amelyek sablonfájlból származnak?**

Igen. Bármely, egy meglévő prezentációból vagy sablonból betöltött diagram esetén ellenőrizheti és módosíthatja, hogy az adat tábla [is shown](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/#hasDataTable--) a diagram tulajdonságainak segítségével.

**Hogyan találhatom meg gyorsan, hogy egy fájlban mely diagramoknál van engedélyezve az adat tábla?**

Ellenőrizze minden diagram azon tulajdonságát, amely jelzi, hogy az adat tábla [is shown](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/#hasDataTable--) és iteráljon a diákon, hogy azonosítsa azokat a diagramokat, ahol engedélyezve van.