---
title: Diagram adat táblák testreszabása prezentációkban Python segítségével
linktitle: Adattábla
type: docs
url: /hu/python-java/chart-data-table/
keywords:
- diagram adatok
- adat tábla
- betűtulajdonságok
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Testreszabja a diagram adat táblák betűtípusait, szegélyeit és jelmagyarázat kulcsait PowerPoint prezentációkban az Aspose.Slides for Python via Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy megjelenítse egy diagram adat tábláját, és testreszabja a szövegformázását, a szegélyeket és a jelmagyarázat kulcsait. Ez a cikk bemutatja, hogyan lehet engedélyezni a táblát, formázni a szöveget, vezérelni az egyes szegélytípusokat, és megjeleníteni vagy elrejteni a jelmagyarázat kulcsait. A példák a konfigurált diagramokat PPTX fájlokban mentik.

## **Betűtulajdonságok beállítása**

A diagram adat táblájának megjelenítéséhez adjon át `True` értéket a [setDataTable](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setDataTable). A táblához való hozzáféréshez és a szövegformázás beállításához használja a [getChartDataTable](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#getChartDataTable).

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztály segítségével.
1. Adjon hozzá egy csoportosított oszlopdiagramot az első diára.
1. Engedélyezze a diagram adat tábláját.
1. Engedélyezze a félkövér szöveget a [setFontBold](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setFontBold) segítségével, és adja át a `20` értéket a [setFontHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setFontHeight) metódusnak 20 pontos szöveghez.
1. Mentse el a módosított prezentációt.

Az alábbi példa a munkakönyvtárban lévő `test.pptx` fájlt igényli, amelynek legalább egy diája van. Egy alapértelmezett adatokkal rendelkező diagramot ad hozzá (50, 50) pozícióban, 600 pont szélességgel és 400 pont magassággal. A mentett `output.pptx` a diagramot tartalmazza, adat táblával engedélyezve és a megadott betűtulajdonságok alkalmazva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Adattábla szegélyek testreszabása**

Engedélyezze a táblát a [Chart.setDataTable](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setDataTable) segítségével, és férjen hozzá a [Chart.getChartDataTable](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#getChartDataTable) metóduson keresztül. Háromféle szegélyt irányíthat önállóan:

- [setBorderHorizontal](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datatable/#setBorderHorizontal) vezérli a vízszintes cellaszegélyeket.
- [setBorderVertical](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datatable/#setBorderVertical) vezérli a függőleges cellaszegélyeket.
- [setBorderOutline](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datatable/#setBorderOutline) vezérli a táblázat külső szegélyét.

Adjon át `True` értéket minden metódusnak a szegélyek megjelenítéséhez, vagy `False`-t azok elrejtéséhez. Az alábbi példa egy alapértelmezett adatokkal rendelkező csoportosított oszlopdiagramot hoz létre, megjeleníti a vízszintes szegélyeket és a külső szegélyt, és elrejti a függőleges szegélyeket. Nem igényel bemeneti fájlt. A diagram pozíciója és mérete pontokban van megadva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az alábbi összehasonlítás ugyanazt a diagramadatot és jelmagyarázat kulcs beállítást használja mind a négy esetben. Kiindulva az összes szegély engedélyezett állapotból, az egyes változatok csak egy szegélybeállítást tiltanak le. A bal alsó változat megegyezik a példában szereplő szegélybeállításokkal.

![Diagram adat táblák: minden szegély engedélyezve, vízszintes szegély nélkül, függőleges szegély nélkül és külső szegély nélkül](data-table-borders.png)

## **Jelmagyarázat kulcsok megjelenítése vagy elrejtése**

A jelmagyarázat kulcsok kis színes jelölők a sorok nevei mellett az adat táblában. Segítik az olvasót, hogy összekapcsolja a táblasorokat a diagram sorozatával. Adjon át `True` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datatable/#setShowLegendKey) hívásánál a jelölők megjelenítéséhez, vagy `False`-t azok elrejtéséhez.

A diagram különálló jelmagyarázatát a [Chart.setLegend](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setLegend) vezérli. Ezek a beállítások függetlenek: a különálló jelmagyarázat elrejtése nem rejti el a táblázatban lévő kulcsokat, és a táblázati kulcsok elrejtése sem rejti el a különálló jelmagyarázatot.

Az alábbi példa egy alapértelmezett adatú diagramot hoz létre, engedélyezi az adat tábláját, és megjeleníti benne a jelmagyarázat kulcsokat, miközben elrejti a különálló jelmagyarázatot. Az összes táblázatszegély kifejezetten engedélyezett. Nem szükséges bemeneti prezentáció. Ahhoz, hogy csak a táblázat kulcsait rejtse el, adjon át `False` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datatable/#setShowLegendKey) hívásnál.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az alábbi összehasonlítás ugyanazt a táblát mutatja, egyes esetekben a jelmagyarázat kulcsok engedélyezve, más esetekben letiltva. Az összes szegély engedélyezett marad, és a különálló diagram jelmagyarázat mindkét esetben rejtett.

![Diagram adat táblák: a bal oldalon a jelmagyarázat kulcsok láthatók, a jobb oldalon rejtve](data-table-legend-keys.png)

## **GYIK**

**Megjeleníthetek jelmagyarázat kulcsokat egy diagram adat táblájában?**

Igen. Adjon át `True` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datatable/#setShowLegendKey) hívásakor a jelmagyarázat kulcsok megjelenítéséhez, vagy `False`-t azok elrejtéséhez.

**Megmarad az adat táblázat, amikor a prezentációt PDF‑re, HTML‑re vagy képekre exportálják?**

Igen. Az Aspose.Slides a diagramot és a megjelenített adat táblát a dia részeként rendereli, amikor [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/hu/python-java/convert-powerpoint-to-html/) vagy [képek](/slides/hu/python-java/convert-powerpoint-to-png/) formátumba exportál.

**Dolgozhatok adat táblákkal olyan diagramokban, amelyek sablonból lettek betöltve?**

Igen. Egy létező prezentációból vagy sablonból betöltött diagram esetén használja a [hasDataTable](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#hasDataTable) és a [setDataTable](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setDataTable) metódusokat annak ellenőrzésére vagy módosítására, hogy a diagram adat táblája megjelenik-e.

**Hogyan találhatok diagramokat, amelyeknél az adat táblázat engedélyezve van?**

Iteráljon a diák alakzatain, azonosítsa a diagramokat, és hívja meg azok [hasDataTable](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#hasDataTable) metódusát. A `True` érték azt jelzi, hogy az adat táblázat engedélyezve van.