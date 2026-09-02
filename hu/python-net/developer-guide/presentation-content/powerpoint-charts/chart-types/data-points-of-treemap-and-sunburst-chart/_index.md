---
title: Testreszabja az adatpontokat a Treemap és Sunburst diagramokban Pythonban
linktitle: Adatpontok a Treemap és Sunburst diagramokban
type: docs
url: /hu/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap diagram
- sunburst diagram
- hierarchikus diagram
- adatpont
- adatcímke
- ág színe
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre hierarchikus adatokat, és testreszabhatja a szinteket, címkéket és színeket a Treemap és Sunburst diagramokban az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

A Treemap és a Sunburst diagramok ugyanazt a hierarchikus adatot jelenítik meg, de különböző elrendezéseket használnak. A Treemap a hierarchiát egymásba ágyazott téglalapokként ábrázolja, ahol a terület a levélértékeket jelzi. A Sunburst koncentrikus gyűrűkkel jeleníti meg: a legfelső szintű csoportok a középpont közelében vannak, a levélkategóriák pedig a külső gyűrűben.

Az Aspose.Slides for Python via .NET minden numerikus érték egy [ChartDataPoint](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/). A [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) gyűjteménye hozzáférést biztosít a levélhez és annak szülőcsoportjaihoz. Ez a cikk ismerteti ezt a leképezést, és megmutatja, hogyan hozhatók létre és formázhatók mindkét diagramtípus ugyanabból a mintaadatból.

![Treemap diagram a Consumer és Business ágazatokkal](treemap-hierarchy.png)

![Sunburst diagram a ugyanazzal a Consumer és Business hierarchiával](sunburst-hierarchy.png)

## **A kategóriák, adatpontok és szintek megértése**

Az alább bemutatott példa három kategóriaszintet és egy numerikus sorozatot tartalmaz:

| Ágazat | Alágazat | Levél | Bevétel |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Minden sor egy levélkategóriát és egy adatpontot hoz létre. A kategóriacsoportosítási szintek leírják az útvonalat a levélről a szülői csoportokig. Az első sor esetén az útvonal: `Consumer > Computers > Laptops`.

A [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) indexei az alulról felfelé haladnak:

| `data_point_levels` index | Logikai szint | Treemap ábrázolás | Sunburst ábrázolás |
| ---: | --- | --- | --- |
| `0` | Levél | Érték téglalap | Külső gyűrű szegmens |
| `1` | Alágazat | Szülő téglalap vagy fejléc | Középső gyűrű szegmens |
| `2` | Ágazat | Legfelső téglalap vagy fejléc | Belső gyűrű szegmens |

Ez a sorrend mindkét diagramtípusnál ugyanaz, bár a vizuális elrendezés különbözik. Egy szülő szegmens több levél által megosztott. Formázásához használja az adott csoport első adatpontjának megfelelő szintjét. Például a `Consumer` ágazat a `Laptops` ponttal kezdődik, míg a `Software` alágazat a `Licenses` ponttal, és ezekre a hivatkozásokra építeni sokkal átláthatóbb, mint a `data_points[0]` vagy `data_points[6]` kifejezéseket használni.

## **Mindkét diagramtípus létrehozása és testreszabása**

Az alábbi teljes példa létrehoz egy Treemap diagramot az első dián és egy Sunburst diagramot a második dián. Felépíti a hierarchiát, megjeleníti a `Tablets` értékét, rögzített színeket alkalmaz a kiválasztott szintekre, formáz egy ágazatcímkét, majd elmenti a prezentációt.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Adja hozzá a levélkategóriákat. Egy csoportosítási elem csak akkor kerül beállításra, amikor egy új csoport kezdődik;
    # a következő kategóriák ebben a csoportban maradnak, amíg egy másik elem nem kerül beállításra.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Mutassa a kategóriát és az értéket a Tabletek levélen.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Formázza a Consumer ágat az ágon belüli első levél alapján.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Formázza a Software alágazatot az alágazaton belüli első levél alapján.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # A parent_label_layout a Treemap szülőcímkéket befolyásolja; a Sunburst gyűrűszegmenseket használ.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

A kategória- és értékcellák ugyanabban a munkalap sorban vannak, így a gyűjteményük pozíciója összhangban marad. Ha meglévő diagrammal dolgozik a létrehozás helyett, először vizsgálja meg a kategóriasorokat, és tároljon névvel ellátott hivatkozásokat az adatpontokra és szintekre, amelyeket formázni szeretne.

## **Viselkedés és gyakorlati szempontok**

### **Treemap és Sunburst különbségek**

- A Treemap a területet használja az érték átadására, a beágyazott téglalapokat a hierarchia jelzésére. A [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/parent_label_layout/) tulajdonság szabályozza, hogyan jelennek meg a szülőcímkék ebben a diagramtípusban.
- A Sunburst a szöget használja az érték átadására, a gyűrűmélységet a hierarchia jelzésére. A [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartseries/parent_label_layout/) nem szabályozza a gyűrűcímkéket.
- Mindkét diagramtípus ugyanazokat a kategóriacsoportosítási szinteket és a `data_point_levels` levél‑szülő sorrendet használja, így az adatépítő és szint‑formázó kód megosztható.
- A szülőértékeket a leszármazott levelek alapján számítják ki. Ne adjon hozzá külön numerikus pontokat az ágazatokhoz vagy alágazatokhoz.

### **Rendezés és szegmens sorrend**

A diagram elrendezőmotor határozza meg a téglalapok és gyűrűszegmensek végső elhelyezkedését. Rendezze a kapcsolódó kategóriasorokat egymás után, mielőtt hozzáadná őket, de ne támaszkodjon egy meghatározott téglalappozícióra vagy kiindulási szögre. Ha a sorrend jelentéssel bír, tüntesse fel a címkékben vagy használjon olyan diagramtípust, amelynek van kifejezett kategóriatengelye.

### **Téma és fix színek**

A nem formázott diagramszintek a prezentáció téma színeit öröklik. A példa a kiszámítható kimenet érdekében kifejezett RGB kitöltéseket használ. Ha a diagramnak a téma változásait kell követnie, használjon séma színeket a fix RGB értékek helyett, és kerülje el minden szint felülírását. Emellett ellenőrizze a címke kontrasztját egy ágazat vagy alágazat kitöltésének módosítása után.

### **Címkék és rendelkezésre álló hely**

A PowerPoint elrejtheti vagy csonkolhatja a címkéket, ha egy szegmens túl kicsi. A diagram méretének növelése, a kategórianév rövidítése vagy a megjelenített címkefieldek számának csökkentése általában tisztább eredményt ad. Egy címke tartalmazhatja a kategórianév, sorozatnév és érték kombinációját a [DataLabelFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabelformat/) segítségével, de minden mező engedélyezése gyakran nehezíti a hierarchikus diagramok olvasását.

### **Exportálás és renderelés**

A PPTX mentése megőrzi a diagram szerkeszthetőségét. Amikor az Aspose.Slides a prezentációt PDF‑re vagy képre rendeli, a támogatott kitöltések és címkebeállítások a diagrammal együtt kerülnek renderelésre. A betűtípuscsere és a rendelkezésre álló elrendezési hely kis eltérései megváltoztathatják a sortörést vagy a címke láthatóságát, ezért telepítse a szükséges betűtípusokat, és ellenőrizze a fontos exportcélokat.

## **GYIK**

**Miért befolyásolja egy szülőszint módosítása több levélkategóriát?**

Egy ágazat vagy alágazat egy közös vizuális szegmens. A [ChartDataPointLevel](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatapointlevel/) egy leszármazott levélön keresztül érhető el, de a formázás a megosztott szülőszegmenshez tartozik, nem csak az adott levélhez.

**Miért hiányzik egy adatcímke?**

Először engedélyezze a szükséges mezőket a címke [DataLabelFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datalabelformat/) objektumán. Ezután ellenőrizze, hogy a szegmens rendelkezik‑e elegendő hellyel. A Treemap szülőcímke‑elrendezés, a diagram méretei, a címke hossza, a betűméret és az engedélyezett mezők száma mind befolyásolják, hogy a címke megjelenhet‑e.

**Beállíthatom a szegmensek pontos sorrendjét vagy koordinátáit?**

A forrás‑sorok sorrendjét és a csoportok összefüggő elhelyezését szabályozhatja, de nem adhat meg pontos Treemap téglalapokat vagy Sunburst szögeket. A diagramelrendezőmotor ezeket a hierarchiából, az értékekből és a rendelkezésre álló helyből számítja ki.

**Miért változnak a színek a prezentáció téma módosítása után?**

A téma‑alapú kitöltések úgy vannak tervezve, hogy kövessék a prezentáció palettáját. Használjon kifejezett RGB színeket a rögzítendő szintekhez, vagy tartsa meg a séma színeket, ha a téma változtatása a kívánt megoldás.

**Megmaradnak‑e az egyedi formázások PDF‑ben és képekben?**

Igen, a támogatott diagramkitöltések és címkebeállítások a renderelés során belekerülnek. A konzisztens eredmény érdekében tegye elérhetővé a szükséges betűtípusokat, és tesztelje a végső exportméretet, mivel a címke‑illesztés az elrendezéstől függ.

## **Lásd még**

- [Treemap diagramok létrehozása](/slides/hu/python-net/create-chart/#create-tree-map-charts)
- [Sunburst diagramok létrehozása](/slides/hu/python-net/create-chart/#create-sunburst-charts)
- [Prezentáció diagramok exportálása](/slides/hu/python-net/export-chart/)
- [Prezentáció témák kezelése](/slides/hu/python-net/presentation-theme/)