---
title: Prezentációs diagramok ábrázolási területeinek testreszabása Androidon
linktitle: Ábrázolási terület
type: docs
url: /hu/androidjava/chart-plot-area/
keywords:
- diagram
- ábrázolási terület
- ábrázolási terület szélessége
- ábrázolási terület magassága
- ábrázolási terület mérete
- elrendezési mód
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan testreszabhatja a diagramok ábrázolási területeit PowerPoint-prezentációkban az Aspose.Slides for Android via Java segítségével. Javítsa diák megjelenését könnyedén."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a diagram ábrázolási területével dolgozni az Aspose.Slides-ban. Ismerteti, hogyan lehet a terület tényleges pozícióját és méretét lekérni a diagram elrendezésének ellenőrzésével, majd a X, Y, szélesség és magasság értékek beolvasásával.  

Azt is bemutatja, hogyan lehet beállítani a terület elrendezési módját, ha az elrendezés manuálisan van megadva, a `LayoutTargetType` használatával meghatározva, hogy a terület a belső régiója vagy a külső régiója, beleértve a tengelyeket és tengelycímkéket, alapján legyen kiszámítva.

## **A diagram ábrázolási területének szélességének és magasságának lekérése**
Az Aspose.Slides for Android via Java egyszerű API-t biztosít a . 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Hozzáférés az első diákhoz.  
3. Diagram hozzáadása alapértelmezett adatokkal.  
4. Hívja meg a [IChart.validateChartLayout()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChart#validateChartLayout--) metódust, hogy a tényleges értékeket lekérje.  
5. Lekéri a diagramelem tényleges X helyzetét (bal), a diagram bal felső sarkához viszonyítva.  
6. Lekéri a diagramelem tényleges felső pozícióját a diagram bal felső sarkához viszonyítva.  
7. Lekéri a diagramelem tényleges szélességét.  
8. Lekéri a diagramelem tényleges magasságát.  

```java
// Hozzon létre egy Presentation osztály példányát
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

## **A diagram ábrázolási területének elrendezési módjának beállítása**
Az Aspose.Slides for Android via Java egyszerű API-t biztosít a diagram ábrázolási területének elrendezési módjának beállításához. A [**setLayoutTargetType**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) és a [**getLayoutTargetType**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) metódusok hozzá lettek adva a [**ChartPlotArea**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ChartPlotArea) osztályhoz és a [**IChartPlotArea**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartPlotArea) interfészhez. Ha a terület elrendezése manuálisan van meghatározva, ez a tulajdonság határozza meg, hogy a terület a belső (nem tartalmazva a tengelyeket és tengelycímkéket) vagy a külső (tartalmazva a tengelyeket és tengelycímkéket) rész alapján legyen elrendezve. Két lehetséges érték van, amely a [**LayoutTargetType**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LayoutTargetType) felsorolásban van definiálva.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LayoutTargetType#Inner) – meghatározza, hogy a terület mérete határozza meg a terület méretét, a jelölők és tengelycímkék nélkül.  
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LayoutTargetType#Outer) – meghatározza, hogy a terület mérete határozza meg a terület, a jelölők és a tengelycímkék méretét.  

Az alábbiakban mintakód található.

```java
// Hozzon létre egy Presentation osztály példányát
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

**Milyen egységben kerülnek vissza a tényleges x, tényleges y, tényleges szélesség és tényleges magasság értékek?**  
Pontban; 1 hüvelyk = 72 pont. Ezek az Aspose.Slides koordinátaegységek.

**Miben különbözik a Plot Area a Chart Area-tól a tartalom tekintetében?**  
A Plot Area a adatok rajzolási területe (sorozatok, rácsvonalak, trendvonalak stb.); a Chart Area magában foglalja a környező elemeket (cím, jelmagyarázat stb.). 3D diagramok esetén a Plot Area magában foglalja a falakat/aldalt és a tengelyeket is.

**Hogyan értelmeződnek a Plot Area x, y, szélesség és magasság értékei, ha az elrendezés kézi?**  
Ezek a diagram teljes méretének tört részei (0–1); ebben a módban az automatikus pozícionálás le van tiltva, és a megadott törtrészek lesznek felhasználva.

**Miért változott meg a Plot Area pozíciója a jelmagyarázat hozzáadása/mozgatása után?**  
A jelmagyarázat a diagramterületen, a Plot Area-n kívül helyezkedik el, de befolyásolja az elrendezést és a rendelkezésre álló helyet, ezért a Plot Area eltolódhat, ha az automatikus pozícionálás aktív. (Ez a PowerPoint-diagramok standard viselkedése.)