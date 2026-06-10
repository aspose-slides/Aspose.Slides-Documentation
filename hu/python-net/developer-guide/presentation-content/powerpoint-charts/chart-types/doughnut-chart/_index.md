---
title: Testreszabott gyűrűdiagramok prezentációkban Python használatával
linktitle: Gyűrűdiagram
type: docs
weight: 30
url: /hu/python-net/doughnut-chart/
keywords:
- gyűrűdiagram
- középső rés
- lyuk mérete
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és testreszabhat gyűrűdiagramokat az Aspose.Slides for Python .NET-en keresztül, támogatva a PowerPoint és OpenDocument formátumokat dinamikus prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk gyűrűdiagrammal az Aspose.Slides-ban a diagram egy diára való hozzáadásával, a középső lyuk méretének beállításával és a prezentáció mentésével. A `doughnut_hole_size` beállításra összpontosít, és bemutatja a kódban szükséges alapvető lépéseket a diagram típus testreszabásához.

A cikk tartalmaz egy rövid GYIK-ot is, amely a gyűrűdiagrammal kapcsolatos helyzeteket tárgyalja, például több sorozat használatát több gyűrű létrehozásához, a felrobbant gyűrűdiagramok kezelését, valamint a diagram raszteres kép vagy SVG formátumba történő exportálását.

## **Középső lyuk méretének megadása a gyűrűdiagramon**
A gyűrűdiagram lyukjának méretének meghatározásához kövesse az alábbi lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályt.
- Adjon hozzá gyűrűdiagramot a diára.
- Adja meg a gyűrűdiagram lyukjának méretét.
- Mentse a prezentációt a lemezre.

Az alábbi példában beállítottuk a gyűrűdiagram lyukjának méretét.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Hozzon létre egy Presentation osztály példányt
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Írja a prezentációt lemezre
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Létrehozhatok több szintű gyűrűdiagramot több gyűrűvel?**

Igen. Adjunk hozzá több sorozatot egyetlen gyűrűdiagramhoz – minden sorozat egy külön gyűrűvé válik. A gyűrűk sorrendje a sorozatok gyűjteményben szereplő sorrendjétől függ.

**Támogatott a „felrobbant” gyűrű (különálló szeletekkel)?**

Igen. Van egy Exploded Doughnut [diagramtípus](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/charttype/) és a pontoknál egy explosion tulajdonság; egyes szeleteket szét lehet választani.

**Hogyan szerezhetek képet egy gyűrűdiagramról (PNG/SVG) egy jelentéshez?**

A diagram egy alakzat; renderelhető [raszteres kép](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_image/) formátumba, vagy exportálható [SVG kép](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/write_as_svg/) formátumba.