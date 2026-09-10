---
title: Diagramok ábrázolási területeinek testreszabása PowerPoint-prezentációkban Python nyelven
linktitle: Ábrázolási terület
type: docs
url: /hu/python-java/chart-plot-area/
keywords:
- diagram
- ábrázolási terület
- ábrázolási terület szélessége
- ábrázolási terület magassága
- ábrázolási terület mérete
- elrendezési mód
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan testreszabhatja a diagramok ábrázolási területeit PowerPoint-prezentációkban az Aspose.Slides for Python via Java segítségével. Javítsa diáik megjelenését könnyedén."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet dolgozni egy diagram ábrázolási területével az Aspose.Slides-ban. Ismerteti, hogyan lehet lekérni a terület tényleges pozícióját és méretét a diagram elrendezésének érvényesítésével, majd az X, Y, szélesség és magasság értékek kiolvasásával.

Bemutatja továbbá, hogyan lehet konfigurálni az ábrázolási terület elrendezési módját, ha az elrendezés manuálisan van beállítva, a [LayoutTargetType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layouttargettype/) használatával, amely meghatározza, hogy a terület belső régiója vagy a külső régiója (a tengelyekkel és tengelycímkékkel együtt) alapján legyen kiszámítva.

## **A diagram ábrázolási területének szélességének és magasságának lekérése**

Az Aspose.Slides for Python via Java egyszerű API-t biztosít a diagram ábrázolási területének tényleges pozíciójának és méretének leolvasásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Nyissa meg az első diát.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal.
1. Hívja meg a [Chart.validateChartLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#validateChartLayout) metódust a tényleges értékek lekérése előtt.
1. Szerezze meg a diagram elem tényleges X pozícióját (bal), a diagram bal felső sarkához viszonyítva.
1. Szerezze meg a diagram elem tényleges Y pozícióját (felső), a diagram bal felső sarkához viszonyítva.
1. Szerezze meg a diagram elem tényleges szélességét.
1. Szerezze meg a diagram elem tényleges magasságát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **A diagram ábrázolási területének elrendezési módjának beállítása**

Az Aspose.Slides for Python via Java egyszerű API-t kínál a diagram ábrázolási területének elrendezési módjának beállításához. A [setLayoutTargetType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) és a [getLayoutTargetType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) metódusok elérhetők a [ChartPlotArea](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartplotarea/) osztályban. Ha az ábrázolási terület elrendezése manuálisan van meghatározva, ez a beállítás határozza meg, hogy a területet a belseje (a tengelyek és tengelycímkék kizárásával) vagy a külseje (tengelyekkel és tengelycímkékkel együtt) alapján rendezzék el. A [LayoutTargetType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layouttargettype/) felsorolásban két lehetséges érték van definiálva.

- [Inner](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layouttargettype/#Inner) azt jelzi, hogy az ábrázolási terület mérete kizárja a jelölőket és a tengelycímkéket.
- [Outer](https://reference.aspose.com/slides/hu/python-java/aspose.slides/layouttargettype/#Outer) azt jelzi, hogy az ábrázolási terület mérete tartalmazza a jelölőket és a tengelycímkéket.

Az alábbiakban minta kód található.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Milyen egységekben kerülnek visszaadásra a tényleges X, tényleges Y, tényleges szélesség és tényleges magasság?**

Pontban; 1 hüvelyk = 72 pont. Ezek az Aspose.Slides koordináta egységek.

**Hogyan különbözik az ábrázolási terület a diagramterülettől a tartalom tekintetében?**

Az ábrázolási terület a adatok rajzolási régiója (sorozatok, rácsvonalak, trendvonalak stb.); a diagramterület a környező elemeket (cím, jelmagyarázat stb.) is magában foglalja. 3D diagramok esetén az ábrázolási terület magában foglalja a falakat/az aljat és a tengelyeket is.

**Hogyan értelmezhetők az ábrázolási terület X, Y, szélessége és magassága, ha az elrendezés manuális?**

Ezek a diagram teljes méretének tört részei (0–1); ebben a módban az automatikus pozícionálás le van tiltva, és a megadott tört értékek kerülnek felhasználásra.

**Miért változott meg az ábrázolási terület pozíciója a jelmagyarázat hozzáadása vagy mozgatása után?**

A jelmagyarázat a diagram területén kívül helyezkedik el, de befolyásolja az elrendezést és a rendelkezésre álló helyet, ezért az ábrázolási terület elmozdulhat, ha az automatikus pozícionálás aktív. (Ez a PowerPoint diagramok standard viselkedése.)