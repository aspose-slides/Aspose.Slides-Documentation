---
title: Diagram adat táblák testreszabása prezentációkban JavaScript használatával
linktitle: Adattábla
type: docs
url: /hu/nodejs-java/chart-data-table/
keywords:
- diagram adatok
- adat tábla
- betűtípus tulajdonságok
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Testreszabja a diagram adat tábla betűtípusait, szegélyeit és jelmagyarázat kulcsait PowerPoint prezentációkban az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy megjelenítse egy diagram adat tábláját, és testreszabja annak szövegformázását, szegélyeit és a jelmagyarázat kulcsait. Ez a cikk bemutatja, hogyan lehet engedélyezni a táblát, formázni a szöveget, vezérelni minden szegélytípust, valamint megjeleníteni vagy elrejteni a jelmagyarázat kulcsait. A példák a beállított diagramokat PPTX fájlokba mentik.

## **Betűtípus tulajdonságok beállítása**

A diagram adat táblájának megjelenítéséhez adja át a `true` értéket a [setDataTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/setdatatable/) metódusnak. A táblához és a szövegformázás beállításához használja a [getChartDataTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/getchartdatatable/) függvényt.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztállyal.  
1. Adjon hozzá egy csoportosított oszlopdiagramot az első diára.  
1. Engedélyezze a diagram adat tábláját.  
1. Engedélyezze a félkövér szöveget a [setFontBold](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setfontbold) metódussal, és adja át a `20` értéket a [setFontHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setfontheight) metódusnak a 20 pontos szöveghez.  
1. Mentse a módosított prezentációt.

A következő példa `input.pptx` fájlt igényel a munkakönyvtárban, amely legalább egy diát tartalmaz. Egy alapértelmezett adatokkal rendelkező diagramot ad hozzá a (50, 50) pozícióban, 600 pont szélességgel és 400 pont magassággal. A mentett `output.pptx` tartalmazza a diagramot a engedélyezett adat táblával és a megadott betűtípus beállításokkal.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Adattábla szegélyek testreszabása**

Engedélyezze a táblát a [Chart.setDataTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/setdatatable/) segítségével, és érje el azt a [Chart.getChartDataTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/getchartdatatable/) metódussal. Három típusú szegélyt vezérelhet függetlenül:

- [setBorderHorizontal](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datatable/setborderhorizontal/) vezérli a vízszintes cellaszegélyeket.  
- [setBorderVertical](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datatable/setbordervertical/) vezérli a függőleges cellaszegélyeket.  
- [setBorderOutline](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datatable/setborderoutline/) vezérli a tábla külső szegélyét.

Adjon át `true` értéket minden módszernek a szegélyek megjelenítéséhez, vagy `false`-t azok elrejtéséhez. A következő példa egy alapértelmezett adatokkal rendelkező csoportosított oszlopdiagramot hoz létre, megjeleníti a vízszintes és a külső szegélyt, és elrejti a függőleges szegélyeket. Nem igényel bemeneti fájlt. A diagram pozíciója és mérete pontokban van megadva.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alábbi összehasonlítás ugyanazt a diagramadatot és jelmagyarázat kulcs beállítást használja mind a négy esetben. Kiindulva a minden szegély engedélyezett állapotból, az egyes további változatok csak egy szegély beállítást kapcsolnak ki. A bal alsó változat megfelel a példában szereplő szegélybeállításoknak.

![Diagram adat táblák minden szegéllyel engedélyezve, vízszintes szegélyek nélkül, függőleges szegélyek nélkül és külső szegély nélkül](data-table-borders.png)

## **Jelmagyarázat kulcsok megjelenítése vagy elrejtése**

A jelmagyarázat kulcsok kis színes jelölők a sorozatnevek mellett az adat táblában. Segítik az olvasót, hogy minden táblasort a diagram sorozatához kapcsolja. Adjon át `true` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datatable/setshowlegendkey/) metódusnak a jelölők megjelenítéséhez, vagy `false`-t azok elrejtéséhez.

A diagram különálló jelmagyarázata a [Chart.setLegend](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/setlegend/) segítségével szabályozható. Ezek a beállítások függetlenek: a különálló jelmagyarázat elrejtése nem rejti el a táblán belüli kulcsokat, és a táblán lévő kulcsok elrejtése nem rejti el a különálló jelmagyarázatot.

A következő példa egy alapértelmezett adatokkal rendelkező diagramot hoz létre, engedélyezi az adat tábláját, és megjeleníti a jelmagyarázat kulcsokat benne, miközben elrejti a különálló jelmagyarázatot. Az összes táblaszegély explicit módon engedélyezett. Bemutató bemeneti fájl nem szükséges. A táblán lévő kulcsok csak elrejtéséhez adja át `false` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datatable/setshowlegendkey/) metódusnak.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alábbi összehasonlítás ugyanazt a táblát mutatja a jelmagyarázat kulcsok engedélyezett és letiltott állapotban. Az összes szegély engedélyezve marad, és a különálló diagram jelmagyarázat mindkét esetben rejtve van.

![Diagram adat táblák a bal oldalon megjelenített jelmagyarázat kulcsokkal és a jobb oldalon rejtve](data-table-legend-keys.png)

## **GYIK**

**Megjeleníthetek jelmagyarázat kulcsokat a diagram adat táblájában?**

Igen. Adjon át `true` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datatable/setshowlegendkey/) metódusnak a jelmagyarázat kulcsok megjelenítéséhez, vagy `false`-t azok elrejtéséhez.

**Megmarad az adat tábla a prezentáció PDF, HTML vagy képek formátumba exportálásakor?**

Igen. Az Aspose.Slides a diagramot és a megjelenített adat táblát a dia részeként rendereli exportáláskor a [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/) vagy [images](/slides/hu/nodejs-java/convert-powerpoint-to-png/) formátumba.

**Dolgozhatok adat táblákkal a sablonból betöltött diagramokban?**

Igen. Egy meglévő prezentációból vagy sablonból betöltött diagram esetén használja a [hasDataTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/hasdatatable/) és a [setDataTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/setdatatable/) metódusokat annak ellenőrzésére vagy módosítására, hogy az adat tábla megjelenik-e.

**Hogyan találhatom meg a diagramokat, amelyeknél az adat tábla engedélyezve van?**

Iteráljon végig minden dia alakzatain, azonosítsa a diagramokat, és hívja meg azok [hasDataTable](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/hasdatatable/) metódusát. A `true` érték azt jelzi, hogy az adat tábla engedélyezve van.