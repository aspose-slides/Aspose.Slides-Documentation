---
title: Diagram plot területek testreszabása PowerPoint prezentációkban JavaScript használatával
linktitle: Plot terület
type: docs
url: /hu/nodejs-java/chart-plot-area/
keywords:
- diagram
- plot terület
- plot terület szélessége
- plot terület magassága
- plot terület mérete
- elrendezési mód
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel, hogyan testre szabhatja a diagram plot területeket PowerPoint prezentációkban JavaScript és Aspose.Slides for Node.js használatával. Javítsa diáivalók megjelenését egyszerűen."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagram plot területével az Aspose.Slides-ban. Leírja, hogyan lehet lekérni a plot terület tényleges pozícióját és méretét a diagram elrendezésének érvényesítésével, majd az X, Y, szélesség és magasság értékek kiolvasásával.

Bemutatja továbbá, hogyan konfigurálható a plot terület elrendezési módja manuális elrendezés esetén, a `LayoutTargetType` használatával, amely meghatározza, hogy a plot területet a belső régiója vagy a külső régiója (tengelyekkel és tengelycímkékkel együtt) alapján számítják-e.

## **A diagram plot területének szélességének és magasságának lekérése**

Aspose.Slides for Node.js via Java egyszerű API-t biztosít a . 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Nyissa meg az első diát.
1. Adjon hozzá diagramot az alapértelmezett adatokkal.
1. Hívja meg a [Chart.validateChartLayout()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Chart#validateChartLayout--) metódust a tényleges értékek lekéréséhez.
1. Lekéri a diagram elem tényleges X helyzetét (bal), a diagram bal felső sarkához viszonyítva.
1. Lekéri a diagram elem tényleges felső pozícióját a diagram bal felső sarkához viszonyítva.
1. Lekéri a diagram elem tényleges szélességét.
1. Lekéri a diagram elem tényleges magasságát.

```javascript
// Hozzon létre egy példányt a Presentation osztályból
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **A diagram plot területének elrendezési módjának beállítása**

Aspose.Slides for Node.js via Java egyszerű API-t biztosít a diagram plot területének elrendezési módjának beállításához. A [**setLayoutTargetType**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) és a [**getLayoutTargetType**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) metódusok hozzá lettek adva a [**ChartPlotArea**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartPlotArea) osztályhoz. Ha a plot terület elrendezése manuálisan van meghatározva, akkor ez a tulajdonság azt adja meg, hogy a plot területet a belseje (tengelyek és tengelycímkék nélkül) vagy a külseje (tengelyekkel és tengelycímkékkel együtt) szerint kell elrendezni. Két lehetséges érték létezik, amely a [**LayoutTargetType**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/LayoutTargetType) enumerációban van definiálva.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/LayoutTargetType#Inner) – meghatározza, hogy a plot terület mérete a plot terület méretét határozza meg, a jelölőket és a tengelycímkéket nem tartalmazva.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/LayoutTargetType#Outer) – meghatározza, hogy a plot terület mérete a plot területet, a jelölőket és a tengelycímkéket is tartalmazza.

Az alábbiakban a példakód látható.

```javascript
// Hozzon létre egy példányt a Presentation osztályból
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Milyen mértékegységben térnek vissza a tényleges X, tényleges Y, tényleges szélesség és tényleges magasság értékek?**

Pontban; 1 hüvelyk = 72 pont. Ezek az Aspose.Slides koordinátamértékegységek.

**Miben különbözik a Plot Area a Chart Area tartalmát tekintve?**

A Plot Area a diagram adatmegjelenítési területe (sorozatok, rácsvonalak, trendvonalak stb.); a Chart Area a környező elemeket is tartalmazza (cím, jelmagyarázat stb.). 3D diagramok esetén a Plot Area magában foglalja a falakat/ alapot és a tengelyeket is.

**Hogyan értelmezendők a Plot Area X, Y, szélesség és magasság értékei manuális elrendezés esetén?**

Ezek a diagram teljes méretének (0–1) arányai; ebben a módban az automatikus pozicionálás ki van kapcsolva, és a megadott arányok kerülnek alkalmazásra.

**Miért változott a Plot Area pozíciója a jelmagyarázat hozzáadása/mozgatása után?**

A jelmagyarázat a diagram területén a Plot Area-n kívül helyezkedik el, de befolyásolja az elrendezést és a rendelkezésre álló helyet, ezért a Plot Area eltolódhat, ha az automatikus pozicionálás aktív. (Ez a PowerPoint diagramok szokásos viselkedése.)