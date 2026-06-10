---
title: A prezentációs diagramok plot területeinek testreszabása Java-ban
linktitle: Plot terület
type: docs
url: /hu/java/chart-plot-area/
keywords:
- diagram
- plot terület
- plot terület szélessége
- plot terület magassága
- plot terület mérete
- elrendezési mód
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan testreszabhatja a diagramok plot területeit PowerPoint prezentációkban az Aspose.Slides for Java segítségével. Javítsa diák megjelenését könnyedén."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a diagram plot területével dolgozni az Aspose.Slides‑ben. Ismerteti, hogyan lehet a diagram elrendezésének validálásával és annak X, Y, szélesség és magasság értékeinek kiolvasásával meghatározni a plot terület tényleges pozícióját és méretét.

Emellett bemutatja, hogyan lehet konfigurálni a plot terület elrendezési módját, ha az elrendezés manuálisan van beállítva, a `LayoutTargetType` használatával meghatározva, hogy a plot területet a belső régió vagy a külső régió (tengelyekkel és tengelycímkékkel együtt) alapján számítsák ki.

## **A diagram plot terület szélességének és magasságának lekérdezése**
Az Aspose.Slides for Java egyszerű API‑t biztosít ehhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Érje el az első diát.  
3. Adjon hozzá diagramot alapértelmezett adatokkal.  
4. Hívja meg a [IChart.validateChartLayout()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChart#validateChartLayout--) metódust a tényleges értékek lekérdezése előtt.  
5. Lekéri a diagram elem tényleges X helyzetét (bal), a diagram bal felső sarkához képest.  
6. Lekéri a diagram elem tényleges felső koordinátáját a diagram bal felső sarkához képest.  
7. Lekéri a diagram elem tényleges szélességét.  
8. Lekéri a diagram elem tényleges magasságát.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **A diagram plot terület elrendezési módjának beállítása**
Az Aspose.Slides for Java egyszerű API‑t biztosít a diagram plot terület elrendezési módjának beállításához. A [**setLayoutTargetType**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) és a [**getLayoutTargetType**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) metódusok hozzá lettek adva a [**ChartPlotArea**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ChartPlotArea) osztályhoz és a [**IChartPlotArea**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartPlotArea) interfészhez. Ha a plot terület elrendezése manuálisan van meghatározva, ez a tulajdonság megadja, hogy a plot területet a belső (tengelyek és tengelycímkék nélkül) vagy a külső (tengelyekkel és tengelycímkékkel együtt) rész alapján kell-e elrendezni. Két lehetséges érték van definiálva a [**LayoutTargetType**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LayoutTargetType) enumerációban.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LayoutTargetType#Inner) – meghatározza, hogy a plot terület mérete a plot terület méretét határozza meg, a jelölőket és tengelycímkéket nem számítva.  
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LayoutTargetType#Outer) – meghatározza, hogy a plot terület mérete a plot területet, a jelölőket és a tengelycímkéket is magában foglalja.

Az alábbiakban példakód található.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Milyen egységben vannak visszaadva a tényleges x, tényleges y, tényleges szélesség és tényleges magasság?**  
Pontokban; 1 hüvelyk = 72 pont. Ezek az Aspose.Slides koordinátaegységek.

**Miben különbözik a Plot Area a Chart Area tartalmát illetően?**  
A Plot Area az adatmegjelenítési régió (sorozatok, rácsvonalak, trendvonalak stb.), míg a Chart Area magában foglalja az azt körülvevő elemeket (cím, jelmagyarázat stb.). 3D diagramok esetén a Plot Area magában foglalja a falakat/alsó felületet és a tengelyeket is.

**Hogyan értelmezhetők a Plot Area x, y, szélesség és magasság értékei, ha az elrendezés manuális?**  
Az értékek a diagram teljes méretének tört részei (0–1); ebben a módban az automatikus pozicionálás ki van kapcsolva, és a beállított törtek kerülnek felhasználásra.

**Miért változott a Plot Area pozíciója a jelmagyarázat hozzáadása/mozgatása után?**  
A jelmagyarázat a diagram területén, a Plot Area‑n kívül helyezkedik el, de befolyásolja az elrendezést és a rendelkezésre álló helyet, ezért a Plot Area eltolódhat, ha automatikus pozicionálás van érvényben. (Ez a PowerPoint diagramok standard viselkedése.)