---
title: "Diagram adat táblák testreszabása Pythonban"
linktitle: "Adattábla"
type: docs
url: /hu/python-net/chart-data-table/
keywords:
- "diagramadat"
- "adat tábla"
- "betűtulajdonságok"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Python"
- "Aspose.Slides"
description: "Diagram adat táblák testreszabása Pythonban PPT, PPTX és ODP formátumokhoz az Aspose.Slides segítségével, a hatékonyság és a megjelenés fokozása érdekében a prezentációkban."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan kell használni a diagram adat táblákat az Aspose.Slides-ben. Bemutatja, hogyan jeleníthető meg egy diagram adat táblája, és hogyan testreszabható a szöveg formázása betűtípus tulajdonságok beállításával, például félkövér stílus és betűmagasság. A példa bemutatja egy prezentáció betöltését, diagram hozzáadását, az adat tábla engedélyezését, a betűtulajdonságok alkalmazását és a módosított prezentáció mentését.

Továbbá rövid válaszokat tartalmaz a gyakori kérdésekre a diagram adat táblában lévő jelmagyarázat kulcsok megjelenítésével, az adat tábla exportálás közbeni megőrzésével, a meglévő prezentációkból vagy sablonokból betöltött diagramok kezelésével, valamint az adat tábla engedélyezett diagramok azonosításával kapcsolatban.

## **Betűtulajdonságok beállítása a diagram adat táblához**

Az Aspose.Slides for Python via .NET támogatja a sorozat kategóriáinak színének módosítását.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztálypéldányt.
1. Adjon hozzá egy diagramot a diára.
1. Állítsa be a diagram táblát.
1. Állítsa be a betűmagasságot.
1. Mentse el a módosított prezentációt.

Az alábbi példakód szerepel.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Megjeleníthetek kis jelmagyarázat kulcsokat az értékek mellett a diagram adat táblájában?**

Igen. Az adat tábla támogatja a [legend keys](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datatable/show_legend_key/), és be- vagy kikapcsolhatók.

**Megmarad az adat tábla a prezentáció PDF, HTML vagy képek formátumba exportálásakor?**

Igen. Az Aspose.Slides a diagramot a dia részeként rendereli, így az exportált [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/hu/python-net/convert-powerpoint-to-html/)/[image](/slides/hu/python-net/convert-powerpoint-to-png/) tartalmazza a diagramot az adat táblával együtt.

**Támogatottak az adat táblák a sablonfájlból származó diagramok esetén?**

Igen. Bármely, egy meglévő prezentációból vagy sablonból betöltött diagram esetén ellenőrizhető és módosítható, hogy az adat tábla [megjelenik](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/has_data_table/)‑e a diagram tulajdonságainak segítségével.

**Hogyan találhatom meg gyorsan, mely diagramokban van engedélyezve az adat tábla?**

Ellenőrizze minden diagram azon tulajdonságát, amely jelzi, hogy az adat tábla [megjelenik](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/has_data_table/), majd járja be a diákat, hogy azonosítsa azokat a diagramokat, ahol engedélyezve van.