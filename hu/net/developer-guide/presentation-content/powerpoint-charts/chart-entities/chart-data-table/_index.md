---
title: Diagram adattáblák testreszabása prezentációkban .NET-ben
linktitle: Adattábla
type: docs
url: /hu/net/chart-data-table/
keywords:
- diagram adatok
- adattábla
- betűtulajdonságok
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Diagram adattáblák testreszabása .NET-ben PPT és PPTX formátumokhoz az Aspose.Slides segítségével, a hatékonyság és a megjelenés növelése érdekében a prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagram adattáblákkal az Aspose.Slides-ben. Megmutatja, hogyan jelenítsen meg egy adattáblát egy diagramhoz, és testre szabhatja a szövegformázást betűtípus‑tulajdonságok, például a félkövér stílus és a betűmagasság beállításával. A példában egy prezentáció betöltése, egy diagram hozzáadása, a diagram adattáblájának engedélyezése, betűtulajdonságok alkalmazása, és a frissített prezentáció mentése látható.

Továbbá rövid válaszokat tartalmaz a gyakori kérdésekre, például a diagram adattáblájában a legendakulcsok megjelenítése, az adattábla export közbeni megőrzése, a meglévő prezentációkból vagy sablonokból betöltött diagramok kezelése, valamint az adattáblával ellátott diagramok azonosítása.

## **Betűtulajdonságok beállítása egy diagram adattáblához**
Az Aspose.Slides for .NET támogatja a kategóriák színének módosítását egy sorozat színében.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztálypéldányt.
1. Adjon hozzá egy diagramot a diára.
1. Állítsa be a diagram táblát.
1. Állítsa be a betűmagasságot.
1. Mentse el a módosított prezentációt.

Az alábbi példa bemutatásra kerül.  

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Megjeleníthetek kis legendakulcsokat a diagram adattáblájában az értékek mellett?**

Igen. Az adattábla támogatja a [legend kulcsok](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/datatable/showlegendkey/), és be- vagy kikapcsolhatja őket.

**Megmarad az adattábla a prezentáció PDF, HTML vagy képek formátumba történő exportálásakor?**

Igen. Az Aspose.Slides a diagramot a dia részeként rendereli, így az exportált [PDF](/slides/hu/net/convert-powerpoint-to-pdf/)/[HTML](/slides/hu/net/convert-powerpoint-to-html/)/[image](/slides/hu/net/convert-powerpoint-to-png/) tartalmazza a diagramot adattáblájával együtt.

**Támogatottak az adattáblák olyan diagramoknál, amelyek sablonfájlból származnak?**

Igen. Bármely meglévő prezentációból vagy sablonból betöltött diagram esetén a diagram tulajdonságainak segítségével ellenőrizheti és módosíthatja, hogy egy adattáblát [is shown](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/hasdatatable/) megjelenít‑e.

**Hogyan találhatom meg gyorsan, mely diagramokban van engedélyezve az adattábla?**

Vizsgálja meg minden diagram azon tulajdonságát, amely jelzi, hogy az adattábla [is shown](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/hasdatatable/) megjelenik‑e, és járja végig a diákat a engedélyezett adattáblával rendelkező diagramok azonosításához.