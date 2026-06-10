---
title: Diagram adat táblák testreszabása prezentációkban Androidon
linktitle: Adattábla
type: docs
url: /hu/androidjava/chart-data-table/
keywords:
- diagram adat
- adat tábla
- betűtípus tulajdonságok
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Testreszabhatja a diagram adat táblákat Java-ban a PPT és PPTX fájlokhoz az Aspose.Slides for Android segítségével, hogy növelje a hatékonyságot és a prezentációk vonzerejét."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat a diagram adat táblákkal az Aspose.Slides-ben. Bemutatja, hogyan jeleníthet meg egy adat táblát egy diagramhoz, és testreszabhatja annak szövegformázását betűtípus tulajdonságok, például félkövér stílus és betűmagasság beállításával. A példa bemutatja egy prezentáció betöltését, diagram hozzáadását, a diagram adat táblájának engedélyezését, a betűtípus beállításainak alkalmazását, és a módosított prezentáció mentését.

## **Betűtípus tulajdonságok beállítása egy diagram adat táblához**
Az Aspose.Slides for Android via Java támogatja a sorozat színeiben a kategóriák színének megváltoztatását.  

1. Példányosítson egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályobjektumot.
1. Adjon hozzá diagramot a diára.
1. Állítsa be a diagram táblát.
1. Állítsa be a betűmagasságot.
1. Mentse a módosított prezentációt.

Az alábbi példát tekintse meg.  

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

## **FAQ**

**Megjeleníthetek kis legendakulcsokat az értékek mellett a diagram adat táblájában?**

Igen. Az adat táblázat támogatja a [legendakulcsokat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), és be- vagy kikapcsolhatja őket.

**Megmarad az adat táblázat a prezentáció PDF, HTML vagy képek formátumba történő exportálásakor?**

Igen. Az Aspose.Slides a diagramot a dia részének tekinti, így az exportált [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/hu/androidjava/convert-powerpoint-to-html/)/[image](/slides/hu/androidjava/convert-powerpoint-to-png/) tartalmazza a diagramot adat táblájával együtt.

**Támogatottak-e az adat táblák a sablonfájlból származó diagramok esetén?**

Igen. Bármely diagram esetén, amely meglévő prezentációból vagy sablonból van betöltve, ellenőrizheti és módosíthatja, hogy az adat táblázat [meg van-e jelen](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/#hasDataTable--) a diagram tulajdonságainál.

**Hogyan találhatom meg gyorsan, mely diagramokban van engedélyezve az adat táblázat?**

Vizsgálja meg minden diagram azon tulajdonságát, amely jelzi, hogy az adat táblázat [meg van-e jelen](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/#hasDataTable--), és járja be a diákat, hogy azonosítsa a táblázattal rendelkező diagramokat.