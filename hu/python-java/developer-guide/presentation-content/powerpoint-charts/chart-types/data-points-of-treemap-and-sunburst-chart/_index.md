---
title: Az adatpontok testreszabása a Treemap és Sunburst diagramokban Pythonban
linktitle: Adatpontok a Treemap és Sunburst diagramokban
type: docs
url: /hu/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap diagram
- sunburst diagram
- hierarchikus diagram
- adatpont
- adatcímke
- ágszín
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre hierarchikus adatokat és testreszabhat szinteket, címkéket és színeket a Treemap és Sunburst diagramokban az Aspose.Slides for Python via Java használatával."
---
## **Áttekintés**

A Treemap és a Sunburst diagramok ugyanazt a hierarchikus adat típust jelenítik meg, de különböző elrendezéseket használnak. A Treemap a hierarchiát egymásba ágyazott téglalapokkal ábrázolja, melyek területe a levélértékeket mutatja. A Sunburst koncentrikus gyűrűket használ: a legfelső szintű csoportok a középpont közelében vannak, a levélkategóriák pedig a külső gyűrűben.

Az Aspose.Slides for Python via Java esetén minden numerikus érték egy [ChartDataPoint](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/). A [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) metódusa hozzáférést biztosít a levélhez és annak szülői csoportjaihoz. Ez a cikk bemutatja ezt a leképezést, és megmutatja, hogyan hozhatók létre és formázhatók mindkét diagramtípus ugyanabból a mintából.

![Treemap diagram a Fogyasztó és Üzleti ágazatokkal](treemap-hierarchy.png)

![Sunburst diagram ugyanazzal a Fogyasztó és Üzleti hierarchiával](sunburst-hierarchy.png)

## **Kategóriák, adatpontok és szintek megértése**

Az alább látható minta három kategória szintet és egy numerikus sorozatot tartalmaz:

| Ágazat | Ág | Levél | Bevétel |
| --- | --- | --- | ---: |
| Fogyasztó | Számítógépek | Laptopok | 12 |
| Fogyasztó | Számítógépek | Asztali gépek | 8 |
| Fogyasztó | Mobil | Telefonok | 15 |
| Fogyasztó | Mobil | Táblagépek | 6 |
| Üzleti | Szolgáltatások | Tanácsadás | 10 |
| Üzleti | Szolgáltatások | Támogatás | 7 |
| Üzleti | Szoftver | Licenc | 11 |
| Üzleti | Szoftver | Előfizetések | 14 |

Minden sor egy levélkategóriát és egy adatpontot hoz létre. A kategória csoportosítási szintek leírják az útvonalat a levélről a szülői elemekig. Az első sor esetén az útvonal: `Consumer > Computers > Laptops`.

Az [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) által visszaadott indexek a levélről felfelé haladnak:

| `getDataPointLevels()` index | Logikai szint | Treemap ábrázolás | Sunburst ábrázolás |
| ---: | --- | --- | --- |
| `0` | Levél | Érték téglalap | Külső gyűrű szegmens |
| `1` | Ág | Szülő téglalap vagy fejléce | Középső gyűrű szegmens |
| `2` | Ágazat | Legfelső szintű téglalap vagy fejléce | Belső gyűrű szegmens |

Ez a sorrend mindkét diagramtípusnál ugyanaz, még ha a vizuális elrendezés eltér is. Egy szülő szegmenst több levél is megoszt. A formázáshoz használja a csoport első adatpontjának megfelelő szintjét. Például a `Consumer` ágazat a `Laptops` ponttal kezdődik, míg a `Software` ág a `Licenses` ponttal. Az ilyen pontokra mutató hivatkozások tárolása egyértelműbb és biztonságosabb, mint a `data_points.get_Item(0)` vagy `data_points.get_Item(6)` formájú magyarázatlan kifejezések használata.

## **Mindkét diagramtípus létrehozása és testreszabása**

Az alábbi teljes példakód az első dián egy Treemap-et, a második dián egy Sunburst-ot hoz létre. Felépíti a hierarchiát, megjeleníti a `Tablets` értékét, rögzített színeket alkalmaz a kiválasztott szintekre, formáz egy ágazatcímkét, és elmenti a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # Adja hozzá a levélkategóriákat. Csoportosítási elemet csak akkor állítanak be, amikor új csoport kezdődik;
        # a következő kategóriák ebben a csoportban maradnak, amíg egy másik elem nincs beállítva.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Mutassa a kategóriát és az értéket a Tabletek levélén.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Formázza a Consumer ágat az ágon lévő első levél útján.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Formázza a Software ágat az ágon lévő első levél útján.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # A ParentLabelLayout befolyásolja a Treemap szülőcímkéket; a Sunburst gyűrűszegmenseket használ.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A kategória- és értéktcellák ugyanazt a munkalap sort használják, ezért a gyűjteménypozícióik továbbra is összehangoltak. Ha egy már létező diagramot módosít, először vizsgálja meg a kategória sorokat, és tárolja a formázni kívánt adatpontokra és szintekre mutató neveket.

## **Viselkedés és gyakorlati megfontolások**

### **Treemap és Sunburst különbségek**

- A Treemap a területet használja az érték, a beágyazott téglalapok pedig a hierarchia közlésére. A [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#setParentLabelLayout) metódus szabályozza, hogyan jelennek meg a szülőcímkék ebben a diagramtípusban.
- A Sunburst a szöget használja az érték, a gyűrűmélység pedig a hierarchia közlésére. A [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#setParentLabelLayout) nem befolyásolja a gyűrűcímkéket.
- Mindkét diagramtípus ugyanazt a kategória csoportosítási szintet és ugyanazt a levél‑szülő sorrendet használja, amelyet a [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) visszaad, ezért az adatépítő és szint‑formázó kód megosztható.
- A szülő értékeket a descendant (leszármazott) levelek alapján számítják ki. Ne adjon meg külön numerikus pontot az ágazatokhoz vagy ágakhoz.

### **Rendezés és szegmens sorrend**

A diagram elrendező motorja határozza meg a téglalapok és gyűrűszegmensek végső elhelyezését. Csoportosítsa a kapcsolódó kategória sorokat együtt, mielőtt hozzáadná őket, de ne számítson egy konkrét téglalappozícióra vagy kiindulási szögre. Ha a sorrend jelentéssel bír, tüntesse fel a címkékben, vagy használjon olyan diagramtípust, amely kifejezett kategória‑tengelyt biztosít.

### **Téma és rögzített színek**

A formázatlan diagramszintek az előadás témájától öröklik a színeket. A példa meghatározott RGB kitöltéseket alkalmaz a kiszámítható kimenet érdekében. Ha a diagramnak a téma‑változásokhoz kell igazodnia, használjon séma‑színeket rögzített RGB‑értékek helyett, és kerüljön minden szint felülírását. Ellenőrizze a címke kontrasztját egy ágazat vagy ág kitöltésének módosítása után is.

### **Címkék és rendelkezésre álló hely**

A PowerPoint elrejtheti vagy csonkolhatja a címkéket, ha egy szegmens túl kicsi. A diagram méretének növelése, a kategória nevek rövidítése vagy a megjelenített címkefields számainak csökkentése általában tisztább eredményt ad. Egy címke kombinálhatja a kategória nevét, a sorozat nevét és az értéket a [DataLabelFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabelformat/) segítségével, de minden mező engedélyezése gyakran nehezíti a hierarchikus diagramok olvasását.

### **Exportálás és renderelés**

A PPTX formátumba mentés szerkeszthető diagramot eredményez. Amikor az Aspose.Slides PDF‑re vagy képre rendereli a prezentációt, a támogatott kitöltések és címke‑beállítások a diagram részeként kerülnek megjelenítésre. A betűtípus‑helyettesítés és a rendelkezésre álló elrendezési tér kisebb eltérései megváltoztathatják a sortörést vagy a címke láthatóságát, ezért telepítse a szükséges betűtípusokat, és ellenőrizze a fontos exportcélokat.

## **Gyakran Ismételt Kérdések**

**Miért befolyásolja egy szülő szint módosítása több levél pontot?**

Egy ágazat vagy ág megosztott vizuális szegmens. A [ChartDataPointLevel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatapointlevel/) ezen a szinten egy levél‑leszármazotton keresztül érhető el, de a formázás a megosztott szülő szegmenshez tartozik, nem csak az adott levélhez.

**Miért hiányzik egy adatcímke?**

Először engedélyezze a szükséges mezőket a címke [DataLabelFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datalabelformat/) objektumán. Ezután ellenőrizze, hogy a szegmensnek elegendő helye van‑e. A Treemap szülő‑címke‑elrendezés, a diagram mérete, a címke hossza, a betűméret és az engedélyezett mezők száma mind hatással van arra, hogy a címke megjeleníthető‑e.

**Beállíthatom a szegmensek pontos sorrendjét vagy koordinátáit?**

A forrás‑sorok sorrendjét és a csoportok összevonását irányíthatja, de a pontos Treemap téglalapok vagy Sunburst szögek meghatározása nem lehetséges. Az elrendező motor a hierarchiából, az értékekből és a rendelkezésre álló térből számítja ki ezeket.

**Miért változnak a színek a prezentáció téma módosítása után?**

A téma‑alapú kitöltések a prezentáció palettájához igazodnak. Alkalmazzon kifejezett RGB színeket azoknál a szinteknél, amelyeknek rögzítve kell maradniuk, vagy használja a séma‑színeket, ha a téma‑váltás preferált.

**Megmarad a saját formázás a PDF és képek exportálásakor?**

Igen, a támogatott diagram‑kitöltések és címke‑beállítások a renderelés során beépülnek. Az egységes eredmény érdekében biztosítsa a szükséges betűtípusok elérhetőségét, és tesztelje a végső export méretét, mivel a címke‑illesztés a layouttól függ.

## **Lásd még**

- [Treemap diagramok létrehozása](/slides/hu/python-java/create-chart/#create-tree-map-charts)
- [Sunburst diagramok létrehozása](/slides/hu/python-java/create-chart/#create-sunburst-charts)
- [Prezentáció diagramok exportálása](/slides/hu/python-java/export-chart/)
- [Prezentáció témák kezelése](/slides/hu/python-java/presentation-theme/)