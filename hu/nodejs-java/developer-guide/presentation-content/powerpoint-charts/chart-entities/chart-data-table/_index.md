---
title: Diagram adat táblák testreszabása prezentációkban JavaScript segítségével
linktitle: Adattábla
type: docs
url: /hu/nodejs-java/chart-data-table/
keywords:
- diagramadat
- adat tábla
- betűtípus tulajdonságok
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides for Node.js via Java segítségével JavaScript-ben testreszabhatja a diagram adat táblákat PPT és PPTX fájlokhoz, növelve a hatékonyságot és a vonzerőt a prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagramadat‑táblákkal az Aspose.Slides-ban. Megmutatja, hogyan jeleníthet meg egy adat‑táblát egy diagramhoz, és hogyan testreszabhatja a szövegformázást betűtípus‑tulajdonságok beállításával, például a félkövér stílus és a betűmagasság megadásával. A példa bemutatja egy prezentáció betöltését, egy diagram hozzáadását, a diagramadat‑tábla engedélyezését, a betűtulajdonságok alkalmazását, és a módosított prezentáció mentését.

Továbbá rövid válaszokat tartalmaz a gyakori kérdésekre, amelyek a diagramadat‑táblában a jelmagyarázat kulcsok megjelenítésével, az adat‑tábla export közbeni megőrzésével, a meglévő prezentációkból vagy sablonokból betöltött diagramok használatával, valamint a data‑táblát engedélyezett diagramok azonosításával kapcsolatosak.

## **Betűtípus‑tulajdonságok beállítása a diagramadat‑táblához**

Az Aspose.Slides for Node.js via Java támogatja a sorozatok színeiben a kategóriák színének módosítását.

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályobjektumot.  
1. Adjon hozzá egy diagramot a diára.  
1. Állítsa be a diagram adat‑táblát.  
1. Állítsa be a betűmagasságot.  
1. Mentse a módosított prezentációt.  

Az alábbi minta‑példát láthatja.  

```javascript
// Üres prezentáció létrehozása
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Megjeleníthetek kis jelmagyarázat‑kulcsokat a diagram adat‑táblájában az értékek mellett?**

Igen. Az adat‑tábla támogatja a [legend keys](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datatable/setshowlegendkey/), és be‑ vagy kikapcsolhatók.

**Megmarad az adat‑tábla a prezentáció PDF, HTML vagy képek formátumba exportálásakor?**

Igen. Az Aspose.Slides a diagramot a dia részeként rendereli, így az exportált [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/hu/nodejs-java/convert-powerpoint-to-png/) tartalmazza a diagramot annak adat‑táblájával együtt.

**Támogatottak az adat‑táblák a sablonfájlból származó diagramok esetén?**

Igen. Bármely, meglévő prezentációból vagy sablonból betöltött diagram esetén ellenőrizhető és módosítható, hogy az adat‑tábla [is shown](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/hasdatatable/) megjelenik‑e a diagram tulajdonságainak használatával.

**Hogyan találhatom meg gyorsan, hogy a fájl mely diagramjai engedélyezik az adat‑táblát?**

Vizsgálja meg minden diagram azon tulajdonságát, amely jelzi, hogy az adat‑tábla [is shown](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/hasdatatable/) megjelenik‑e, és járja be a diákat a bekapcsolt adat‑táblával rendelkező diagramok azonosításához.