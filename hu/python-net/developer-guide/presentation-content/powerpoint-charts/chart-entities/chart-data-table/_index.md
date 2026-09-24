---
title: Diagram adat táblák testreszabása bemutatókban Pythonban
linktitle: Adattábla
type: docs
url: /hu/python-net/chart-data-table/
keywords:
- diagram adatok
- adattábla
- betűtípus beállítások
- PowerPoint
- bemutató
- Python
- Aspose.Slides
description: "Testreszabja a diagram adat táblák betűtípusait, szegélyeit és jelmagyarázat kulcsait PowerPoint bemutatókban az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET lehetővé teszi egy diagram adat táblázatának megjelenítését, valamint a szöveg formázásának, a szegélyeknek és a jelmagyarázat kulcsainak testreszabását. Ez a cikk bemutatja, hogyan engedélyezhető a táblázat, hogyan formázható a szöveg, hogyan szabályozható mindhárom szegélytípus, valamint hogyan jeleníthetők meg vagy rejthetők el a jelmagyarázat kulcsai. A példák a beállított diagramokat PPTX fájlokba mentik.

## **Betűtípus tulajdonságok beállítása**

A diagram adat táblázatának megjelenítéséhez állítsa a [has_data_table](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/has_data_table/) tulajdonságot `True`‑ra. A [chart_data_table](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/chart_data_table/) segítségével érheti el a táblázatot és konfigurálhatja a szöveg formázását.

1. Töltse be a bemutatót a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály használatával.
1. Hozzon létre egy csoportos oszlopdiagramot az első dián.
1. Engedélyezze a diagram adat táblázatát.
1. Állítsa be a félkövér szöveget a [font_bold](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/font_bold/) segítségével, és a [font_height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/font_height/) értékét `20`‑ra a 20 pontos szöveghez.
1. Mentse a módosított bemutatót.

Az alábbi példa a munkakönyvtárban található `test.pptx` fájlt igényli, amelynek legalább egy diája van. Egy diagramot ad hozzá alapértelmezett adatokkal a (50, 50) pozícióban, 600 pont szélességgel és 400 pont magassággal. A mentett `output.pptx` tartalmazza a diagramot, amelynek adat táblázata engedélyezve van, és a megadott betűtípus beállítások alkalmazva lettek.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Az adat táblázat szegélyeinek testreszabása**

Engedélyezze a táblázatot a [Chart.has_data_table](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/has_data_table/) segítségével, és érje el azt a [Chart.chart_data_table](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/chart_data_table/) útján. Három szegélytípust szabályozhat függetlenül:

- [has_border_horizontal](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datatable/has_border_horizontal/) vezérli a vízszintes cellaszegélyeket.
- [has_border_vertical](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datatable/has_border_vertical/) vezérli a függőleges cellaszegélyeket.
- [has_border_outline](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datatable/has_border_outline/) vezérli a táblázat külső szegélyét.

Állítsa az egyes tulajdonságokat `True`‑ra a szegélyek megjelenítéséhez, vagy `False`‑ra a rejtésükhöz. Az alábbi példa egy csoportos oszlopdiagramot hoz létre alapértelmezett adatokkal, megjeleníti a vízszintes és a külső szegélyeket, a függőleges szegélyeket pedig elrejti. Bemeneti fájlra nincs szükség. A diagram pozíciója és mérete pontokban van megadva.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

Az összehasonlítás ugyanazt a diagramadatot és jelmagyarázat kulcs beállítást használja mind a négy esetben. Kiindulva az összes szegély engedélyezett állapotból, minden további változat egyetlen szegélybeállítást kapcsol ki. A bal alsó változat egyezik a példában szereplő szegélybeállításokkal.

![Diagram adat táblázatok teljes szegéllyel, vízszintes szegély nélkül, függőleges szegély nélkül és külső szegély nélkül](data-table-borders.png)

## **Jelmagyarázat kulcsok megjelenítése vagy elrejtése**

A jelmagyarázat kulcsok kis színes jelölők, amelyek a sorok nevei mellett jelennek meg az adat táblázatban. Segítik az olvasót a táblázati sorok és a diagram sorozatok közötti összekapcsolásban. Állítsa a [show_legend_key](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datatable/show_legend_key/) tulajdonságot `True`‑ra a kulcsok megjelenítéséhez, vagy `False`‑ra azok elrejtéséhez.

A diagram különálló jelmagyarázatát a [Chart.has_legend](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/has_legend/) vezérli. Ezek a beállítások függetlenek: a különálló jelmagyarázat elrejtése nem rejti el a táblázaton belüli kulcsokat, és a táblázat kulcsainak elrejtése nem befolyásolja a különálló jelmagyarázatot.

Az alábbi példa egy diagramot hoz létre alapértelmezett adatokkal, engedélyezi annak adat táblázatát, és megjeleníti a jelmagyarázat kulcsokat, miközben elrejti a különálló jelmagyarázatot. Az összes táblázati szegély explicit módon engedélyezett. Bemeneti bemutató nem szükséges. Ha csak a táblázat kulcsait szeretné elrejteni, állítsa a `data_table.show_legend_key` értékét `False`‑ra.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

Az összehasonlítás ugyanazt a táblázatot mutatja, a jelmagyarázat kulcsok engedélyezett és tiltott állapotban. Minden szegély továbbra is engedélyezett, és a különálló diagramjelmagyarázat mindkét esetben rejtett.

![Diagram adat táblázatok a bal oldalon látható jelmagyarázat kulcsokkal és a jobb oldalon elrejtve](data-table-legend-keys.png)

## **GYIK**

**Megjeleníthetem a jelmagyarázat kulcsokat egy diagram adat táblázatában?**

Igen. Állítsa a [show_legend_key](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datatable/show_legend_key/) tulajdonságot `True`‑ra a jelmagyarázat kulcsok megjelenítéséhez, vagy `False`‑ra azok elrejtéséhez.

**Megmarad-e az adat táblázat, ha a bemutatót PDF‑be, HTML‑be vagy képekbe exportálom?**

Igen. Az Aspose.Slides a diagramot és a megjelenített adat táblázatot a dia részeként rendereli, amikor a [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/hu/python-net/convert-powerpoint-to-html/) vagy [images](/slides/hu/python-net/convert-powerpoint-to-png/) formátumba exportálja.

**Munkához használhatom-e a adat táblázatokat olyan diagramokkal, amelyeket sablonból töltöttem be?**

Igen. Egy meglévő bemutatóból vagy sablonból betöltött diagram esetén használja a [has_data_table](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/has_data_table/) tulajdonságot az adat táblázat megjelenítésének ellenőrzésére vagy módosítására.

**Hogyan találhatok olyan diagramokat, amelyeknél a adat táblázat engedélyezve van?**

Iteráljon a diákon lévő alakzatokon, azonosítsa a diagramokat, és ellenőrizze azok [has_data_table](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/has_data_table/) tulajdonságát. A `True` érték azt jelzi, hogy az adat táblázat engedélyezve van.