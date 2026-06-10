---
title: Az adatpontok testreszabása a treemap és sunburst diagramokban Pythonban
linktitle: Adatpontok a treemap és sunburst diagramokban
type: docs
url: /hu/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap diagram
- sunburst diagram
- adatpont
- címke szín
- ág szín
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet adatpontokat a treemap és sunburst diagramokban az Aspose.Slides for Python via .NET segítségével, amely kompatibilis a PowerPoint és OpenDocument formátumokkal."
---
## **Bevezetés**

A PowerPoint egyéb diagramtípusai mellett van két hierarchikus típus—**Treemap** és **Sunburst** (más néven Sunburst grafikon, Sunburst diagram, Radiális diagram, Radiális grafikon vagy több szintű kördiagram). Ezek a diagramok hierarchikus adatokat jelenítenek meg, amelyek fastruktúrában vannak rendezve – a levelektől egy ágra feljebb. A leveleket a sorozat adatpontok határozzák meg, és minden további egymásba ágyazott csoportosítási szintet a megfelelő kategória definiál. Az Aspose.Slides for Python via .NET lehetővé teszi, hogy Pythonban formázza a Sunburst és Treemap diagramok adatpontjait.

Itt egy Sunburst diagram, ahol a Series1 oszlop adatai határozzák meg a levélcsomópontokat, míg a többi oszlop a hierarchikus adatpontokat definiálja:

![Sunburst diagram példa](sunburst_example.png)

Kezdjük egy új Sunburst diagram hozzáadásával a prezentációhoz:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Lásd még" %}}
- [**Sunburst diagramok létrehozása**](/slides/hu/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Ha diagram adatpontokat kell formázni, használja a következő API-kat:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointlevel/), és a [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) tulajdonságot. Ezek hozzáférést biztosítanak a Treemap és Sunburst diagramok adatpontjainak formázásához. A [ChartDataPointLevelsManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) a többszintű kategóriák elérésére szolgál; egy [ChartDataPointLevel](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointlevel/) objektumok tárolóját képviseli. Lényegében a [ChartCategoryLevelsManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartcategorylevelsmanager/) köré épülő burkoló, további, adatpontokra specifikus tulajdonságokkal. A [ChartDataPointLevel](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointlevel/) típus két tulajdonságot tesz közzé – a [format](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointlevel/format/) és a [label](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointlevel/label/) –, amelyek a megfelelő beállításokhoz biztosítanak hozzáférést.

## **Adatpont értékek megjelenítése**

Ez a szakasz bemutatja, hogyan jelenítheti meg az egyes adatpontok értékét a Treemap és Sunburst diagramokban. Megmutatjuk, hogyan engedélyezheti az értékcímkéket a kiválasztott pontokhoz.

A „Leaf 4” adatpont értékének megjelenítése:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Adatpont értéke](data_point_value.png)

## **Címkék és színek beállítása adatpontokhoz**

Ez a szakasz bemutatja, hogyan állíthat be egyéni címkéket és színeket az egyes adatpontokhoz a Treemap és Sunburst diagramokban. Megtanulja, hogyan érhet el egy adott adatpontot, hogyan rendelhet hozzá címkét, és hogyan alkalmazhat szilárd kitöltést a fontos csomópontok kiemeléséhez.

Állítsa be a „Branch 1” adatcímkét úgy, hogy a sorozat nevét („Series1”) jelenítse meg a kategórianév helyett, majd állítsa a szöveg színét sárgára:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Az adatpont címkéje és színe](data_point_color.png)

## **Ág színek beállítása adatpontokhoz**

Használja az ágszíneket a szülő és gyermek csomópontok vizuális csoportosításának vezérlésére a Treemap és Sunburst diagramokban. Ez a szakasz bemutatja, hogyan állíthat be egyéni ágszínt egy adott adatponthoz, hogy fontos részfákat emeljen ki és javítsa a diagram olvashatóságát.

A „Stem 4” ág színének módosítása:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Ág színe](branch_color.png)

## **GYIK**

**Megváltoztathatom a szegmensek sorrendjét (rendezését) a Sunburst/Treemap diagramokban?**

Nem. A PowerPoint automatikusan rendezi a szegmenseket (általában csökkenő értékek szerint, óramutató járásával megegyező irányban). Az Aspose.Slides ezt a viselkedést tükrözi: a sorrendet nem lehet közvetlenül módosítani; előfeldolgozással kell a kívánt sorrendet elérni.

**Hogyan befolyásolja a prezentáció témája a szegmensek és címkék színeit?**

A diagram színei a prezentáció [theme/palette](/slides/hu/python-net/presentation-theme/) öröklik, hacsak nem állít be kifejezetten kitöltéseket/betűtípusokat. A következetes eredmények érdekében rögzítse a szilárd kitöltéseket és a szövegformázást a szükséges szinteken.

**A PDF/PNG exportálás megőrzi a saját ág színeket és címke beállításokat?**

Igen. Amikor a prezentációt exportálja, a diagram beállításai (kitöltések, címkék) megmaradnak a kimeneti formátumokban, mert az Aspose.Slides a diagram formázásával rendereli.

**Kiszámíthatom a címke/elem tényleges koordinátáit egyedi átfedés elhelyezéséhez a diagram felett?**

Igen. Miután a diagram elrendezése ellenőrzésre kerül, az `actual_x`/`actual_y` értékek elérhetők az elemekhez (például egy [DataLabel](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabel/)), ami segít a pontos pozicionálásban.