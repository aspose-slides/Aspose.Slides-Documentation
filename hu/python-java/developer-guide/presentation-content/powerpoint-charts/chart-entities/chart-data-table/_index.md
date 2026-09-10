---
title: Diagram adat táblák testreszabása prezentációkban Python használatával
linktitle: Adattábla
type: docs
url: /hu/python-java/chart-data-table/
keywords:
- diagram adatok
- adat tábla
- betűtípus tulajdonságok
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Testreszabja a diagram adat táblákat Pythonban PPT és PPTX számára az Aspose.Slides for Python via Java segítségével, hogy növelje a hatékonyságot és a vonzerőt a prezentációkban."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan kell dolgozni diagram adat táblákkal az Aspose.Slides-ban. Bemutatja, hogyan jeleníthető meg egy diagram adat táblája, és testreszabható a szöveg formázása betűtípus tulajdonságok, például félkövér stílus és betűmagasság beállításával. A példa bemutatja egy prezentáció létrehozását, egy diagram hozzáadását, a diagram adat táblájának engedélyezését, a betűtípus beállítások alkalmazását, valamint a módosított prezentáció mentését.

Emellett rövid válaszokat tartalmaz a gyakori kérdésekre a diagram adat táblájában a jelmagyarázat kulcsainak megjelenítésével, az adat tábla exportálás közbeni megőrzésével, meglévő prezentációkból vagy sablonokból betöltött diagramokkal való munkavégzéssel, valamint azoknak a diagramoknak az azonosításával, amelyeknél az adat tábla engedélyezve van.

## **Betűtípus tulajdonságok beállítása egy diagram adat táblához**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy megjelenítse egy diagram adat tábláját, és megváltoztassa a benne lévő szöveg betűtípus tulajdonságait.

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályt.
1. Adjon hozzá egy diagramot a diára.
1. Jelenítse meg a diagram adat tábláját.
1. Állítsa be a félkövér stílusát és a betűmagasságot az adat tábla szövegéhez.
1. Mentse el a módosított prezentációt.

A következő példa bemutatja ezeket a lépéseket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Üres prezentáció létrehozása.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Megjeleníthetek kis jelmagyarázat kulcsokat az értékek mellett a diagram adat táblájában?**

Igen. Az adat tábla támogatja a [legend keys](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datatable/#setShowLegendKey) funkciót, és be- vagy kikapcsolható.

**Megmarad az adat tábla a prezentáció PDF, HTML vagy képek formátumba történő exportálásakor?**

Igen. Az Aspose.Slides a diagramot a dia részeként rendereli, ezért a exportált [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/hu/python-java/convert-powerpoint-to-html/)/[image](/slides/hu/python-java/convert-powerpoint-to-png/) tartalmazza a diagramot az adat táblájával.

**Támogatottak az adat táblák olyan diagramoknál, amelyek sablonfájlból származnak?**

Igen. Bármely, meglévő prezentációból vagy sablonból betöltött diagram esetén ellenőrizhető és módosítható, hogy az adat tábla [is shown](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#hasDataTable) legyen a diagram tulajdonságainak használatával.

**Hogyan találhatom meg gyorsan, mely diagramoknál van engedélyezve az adat tábla egy fájlban?**

Vizsgálja meg minden diagram azon tulajdonságát, amely jelzi, hogy az adat tábla [is shown](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#hasDataTable), és iteráljon a diákon, hogy azonosítsa azokat a diagramokat, ahol engedélyezve van.