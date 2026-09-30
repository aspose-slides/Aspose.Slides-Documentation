---
title: Diagrammagyarázatok testreszabása prezentációkban Python segítségével
linktitle: Diagrammagyarázat
type: docs
url: /hu/python-net/chart-legend/
keywords:
- diagrammagyarázat
- magyarázat pozíció
- betűméret
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Testreszabott diagrammagyarázatok az Aspose.Slides for Python via .NET segítségével a PowerPoint prezentációk optimalizálásához, egyedi legenda formázással."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET lehetőséget biztosít a diagrammagyarázatok testreszabására a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet elhelyezni és méretezni a magyarázatot, beállítani a teljes magyarázat betűméretét, formázni egy egyedi magyarázati bejegyzést, valamint elrejteni vagy visszaállítani a kiválasztott bejegyzéseket.

Az GYIK a kapcsolódó viselkedéseket tárgyalja, többek között a magyarázat számára fenntartott helyet, a többsoros címkék megjelenítését, valamint a formázás öröklését a prezentáció témájából.

## **Legenda elhelyezése**

Használd a legenda [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), és [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) tulajdonságait a pozíció és méret meghatározásához a diagram méreteinek tört részeként.

Ez a példa egy prezentációt hoz létre, és az első diára egy klaszterezett oszlopdiagramot ad hozzá alapértelmezett adatokkal. A kívánt legenda eltolások és méretek a diagram szélességével és magasságával való osztásával relatív értékekké alakulnak: a legenda a diagram bal‑felső sarkától 50 ponttal van eltolva, és 100 × 100 pont méretű.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Fejezd ki a legenda pozícióját és méretét a diagramhoz képest.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **A legenda betűméretének beállítása**

Használd a legenda [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) tulajdonságát a szövegformázás eléréséhez, és állítsd be a [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) értékét pontban.

Ez a példa egy diagramot hoz létre alapértelmezett adatokkal, és a legenda szövegét 20 pontra állítja. Emellett letiltja a függőleges tengely automatikus határait, és a tartományt -5‑től 10‑ig állítja.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyedi legenda bejegyzés betűméretének beállítása**

Használd a legenda [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) gyűjteményét egy adott bejegyzés formázásához. A bejegyzés indexek nullától indulnak, így az `1` index a második bejegyzést jelöli.

Ez a példa egy klaszterezett oszlopdiagramot hoz létre, amelynek alapértelmezett adatai legalább két sorozatot tartalmaznak. A második legenda bejegyzést vastag, dőlt, 20 pontos kék szöveggel formázza.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyedi legenda bejegyzések elrejtése**

Egy segédsorozat kizárásához a legendából, miközben az adat látható marad, állítsd be a [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) értékét `True`‑ra a [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/) segítségével. Ez csak a kiválasztott legenda bejegyzést rejti el; a sorozatot vagy annak adatpontjait nem távolítja el. Ezzel szemben a [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) `False`‑ra állítása az egész legendát elrejti.

Az alábbi példa egy több sorozatos klaszterezett oszlopdiagramot hoz létre alapértelmezett adatokkal. Elrejti a második sorozat legenda bejegyzését (index `1`), és menti a prezentációt. Ezután visszaállítja a bejegyzést a [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) `False`‑ra állításával, és egy második másolatot ment. A oszlopok mindkét fájlban láthatóak maradnak.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Visszaállítja ugyanazt a bejegyzést a diagram adatait megváltoztatás nélkül.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

Az alábbi összehasonlítás ugyanazt a diagramot mutatja, minden bejegyzés láthatóval és a második bejegyzés elrejtve. A második sorozat oszlopai változatlanok maradnak.

![Összehasonlítás egy diagramról, ahol az összes legenda bejegyzés látható, és ahol a 2. sorozat el van rejtve a legendában; minden oszlop látható marad.](hide-legend-entry.png)

Oszlop-, oszlop- és vonaldiagramokban a legenda bejegyzések a sorozatokat azonosítják. Torta diagramokban egyedi adatpontokat (szeleteket) jelölnek, ezért a kiválasztott szeletnél használd a [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/)‑t. Az API ezt a adatpont‑tulajdonságot dokumentálja a `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` és `BAR_OF_PIE` diagramtípusoknál. Ne feltételezd, hogy ez a gyűrűdiagramokra is vonatkozik, amelyek nincsenek ebben a listában.

## **GYIK**

**Beállíthatom, hogy a diagram helyet foglaljon a legenda számára ahelyett, hogy átfedné?**

Igen. Állítsd a [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) értékét `False`‑ra, hogy a legenda számára helyet foglaljon, ahelyett, hogy a diagram területét átfedné.

**Létrehozhatok többsoros legenda címkéket?**

Igen. Hosszú címkék sortördelnek, ha a rendelkezésre álló szélesség nem elegendő. Sorozatneveknél is használhatsz újsor karaktereket a sortörés kéréséhez.

**Hogyan tudom, hogy a legenda kövesse a prezentáció téma színsémáját?**

Hagyd a legenda színeit, kitöltéseit és betűtípusait beállítás nélkül, hogy örökölje a téma formázását. Az explicit formázás felülírja a megfelelő téma beállításokat.