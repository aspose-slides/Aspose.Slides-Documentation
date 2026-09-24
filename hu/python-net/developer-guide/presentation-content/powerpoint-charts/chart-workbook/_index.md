---
title: Diagram munkafüzetek kezelése prezentációkban Python segítségével
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/python-net/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adatok
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagram gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Python .NET-en keresztül: könnyedén kezelje a diagram munkafüzeteket a PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációjának adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kell dolgozni diagram munkafüzetekkel az Aspose.Slides-ban. Megmutatja, hogyan lehet olvasni és írni diagram adatokat munkafüzet adatfolyamokon keresztül, a munkafüzet cellákat diagram adatcímkeként használni, elérni a munkalapgyűjteményeket, és megadni az adatforrás típusát a diagramértékekhez.

Emellett kitér a külső munkafüzetek diagram adatforrásként való használatára is. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagram adatokat, ha a munkafüzet rendelkezésre áll.

A hiányzó adatot képviselő munkafüzetcellákhoz lásd a [A üres cellák megjelenítésének vezérlése](/slides/hu/python-net/chart-series/) cikket, amely bemutatja az üres cella és a nulla közti különbséget, valamint egy vonaldiagramot az elérhető megjelenítési módok összehasonlítására.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides módszereket biztosít a diagram adatokat tartalmazó munkafüzetek (amelyek Aspose.Cells‑szel szerkesztett diagram adatokat tartalmaznak) olvasásához és írásához. **Megjegyzés:** A diagram adatokat ugyanúgy vagy a forráshoz hasonló struktúrában kell elrendezni.

A következő Python‑kód egy példa műveletet mutat be:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **Diagram elrendezésének ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet helyettesít egy módosított változattal, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem egyezés azt eredményezheti, hogy a [IChart.validate_chart_layout](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichart/validate_chart_layout/) index‑túl‑tartomány hibával hibázik. Írja ki a meglévő sorozatokat és kategóriákat a frissített munkafüzet visszaírása előtt a diagramba.

```python
# A munkafüzet adatfolyam módosítása után (például az Aspose.Cells használatával)
updated_workbook = chart_data.read_workbook_stream()

# A meglévő adatreferenciák törlése.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

A gyűjtemények törlése biztosítja, hogy a diagram adatstruktúrája összhangban legyen az új munkafüzettel, így a `validate_chart_layout` hibamentesen lefuthat.

## **Munkafüzet cella beállítása diagram adatcímkeként**

Bizonyos esetekben a diagramcímkéknek közvetlenül a háttéradat‑munkafüzet celláiból kell származniuk. Az Aspose.Slides lehetővé teszi, hogy adatcímkéket konkrét munkafüzet‑cellákhoz kössön, így a címkeszöveg mindig a cella aktuális értékét tükrözi. Az alábbi példa megmutatja, hogyan engedélyezhetők a cellából származó értékek címkéként, és hogyan irányíthatók a kiválasztott címkék egyéni cellákra a diagram munkafüzeteiben.

1. Hozzon létre egy példányt a [Presentation](https://docs.aspose.com/slides/hu/python-net/api-reference/aspose.slides/presentation/) osztályból.
1. Kapjon hivatkozást a diára index alapján.
1. Adjon hozzá egy buborékdiagramot mintapéldával.
1. Hozzáférés a diagram sorozatához.
1. Használjon egy munkafüzet‑cellát adatcímkeként.
1. Mentse a prezentációt.

A következő Python‑kód megmutatja, hogyan állítható be egy munkafüzet‑cellát diagram adatcímkeként:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# A Presentation osztály példányosítása, amely egy prezentációfájlt képvisel.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Munkalapok kezelése**

Az alábbi Python‑kód bemutatja, hogyan használható a `worksheets` tulajdonság a munkalapgyűjtemény eléréséhez:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Az adatforrás típusának meghatározása**

Az alábbi Python‑kód megmutatja, hogyan adható meg egy adatforrás‑típus:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Nem támogatott beágyazott munkafűzet‑formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. A `embedded_workbook_type` tulajdonság használatával a [ChartData](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/) osztályon, valamint a [WorkbookType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/workbooktype/) felsorolással felismerhetők a nem támogatott formátumok, és kihagyhatók az érintett diagramok.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # A beágyazott munkafüzet .xlsb formátumban van, amelyet nem támogatunk.
            continue

        # Olvassa vagy módosítsa itt a diagram munkafüzet adatokat.
```

## **Külső munkafüzetek**

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként való használatát.

### **Külső munkafüzetek beállítása**

A [ChartData.set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódus használatával egy külső munkafüzetet rendelhetünk egy diagramhoz adatforrásként. Ez a metódus frissítheti a külső munkafüzet útvonalát is, ha az át lett helyezve.

Bár a távoli helyeken vagy erőforrásokon tárolt munkafüzetek adatainak szerkesztése nem támogatott, ezek a munkafüzetek továbbra is használhatók külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzetről, az automatikusan teljes útvonalra lesz konvertálva.

A következő Python‑kód megmutatja, hogyan állítható be egy külső munkafüzet:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # A False átadása miatt csak az útvonal kerül tárolásra: a cél munkafüzettel még nem kell léteznie.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

A [set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódus `update_chart_data` paramétere határozza meg, hogy az Excel‑munkafüzet be legyen‑töltve.

- Ha `update_chart_data` **False**‑ra van állítva, csak a munkafüzet útvonala frissül; a diagram adat nem töltődik be vagy frissül a cél‑munkafüzetről. Ezt a beállítást akkor használja, ha a cél‑munkafüzet nem létezik vagy nem érhető el.
- Ha `update_chart_data` **True**‑ra (alapértelmezett) van állítva, a diagram adat betöltődik és frissül a cél‑munkafüzetről. Ha a munkafüzetet nem lehet megnyitni, „External workbook is not available” üzenetű kivétel keletkezik.

### **Külső munkafüzetek létrehozása**

A [read_workbook_stream](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódusok használatával vagy teljesen újt hozhat létre külső munkafüzettel, vagy egy belső munkafüzetet alakíthat át külsővé.

Ez a Python‑kód bemutatja a külső munkafüzet létrehozási folyamatát:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **A diagram külső adatforrás‑munkafüzete útvonalának lekérdezése**

Bizonyos esetekben egy diagram adatai egy külső Excel‑munkafüzethez vannak csatolva a prezentáció beágyazott adatainak helyett. Az Aspose.Slides segítségével megvizsgálhatja a diagram adatforrását, és ha az egy külső munkafüzet, kiolvashatja a teljes munkafüzet‑útvonalat.

1. Hozzon létre egy példányt a [Presentation](https://docs.aspose.com/slides/hu/python-net/api-reference/aspose.slides/presentation/) osztályból.
2. Kapjon hivatkozást a diára az indexe alapján.
3. Szerezze meg a diagram alakzat hivatkozását.
4. Szerezze be a forrást ([ChartDataSourceType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatasourcetype/)), amely a diagram adatforrását képviseli.
5. Ellenőrizze, hogy a forrástípus megegyezik‑e a külső munkafüzet adatforrás‑típusával.

A következő Python‑kód bemutatja a műveletet:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Diagramadatok szerkesztése**

Az adatokat külső munkafüzetekben ugyanúgy szerkesztheti, mint belső munkafüzetekben. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagram munkafüzettét a prezentációban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/) példányt, majd engedélyezze a [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/hu/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) beállítást a [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/spreadsheet_options/) segítségével a prezentáció megnyitása előtt.

Az alábbi Python‑példa megnyit egy olyan prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [Chart.chart_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/chart_data/) és a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével éri el:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Olvassa vagy módosítsa itt a helyreállított munkafüzet adatait.
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható visszaesés, mivel a gyorsítótár esetleg nem tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése után végzett módosításokat.

## **FAQ**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e csatolva?**

Igen. A diagram rendelkezik egy [adatforrás típussal](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/data_source_type/) és egy [külső munkafüzet elérési úttal](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/); ha a forrás egy külső munkafüzet, akkor leolvashatja a teljes útvonalat, hogy megbizonyosodjon róla, hogy egy külső fájl van használatban.

**Támogatottak‑e a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. Ez kényelmes a projekt hordozhatósága szempontjából; azonban a prezentáció az abszolút útvonalat tárolja a PPTX‑fájlban.

**Használhatok‑e hálózati erőforrásokon/megosztott helyeken lévő munkafüzeteket?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. A távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak adatforrásként használhatók.

**Felülírja‑e az Aspose.Slides a külső XLSX‑et a prezentáció mentésekor?**

Csak akkor, ha a diagramadatokat szerkesztette. A prezentáció egy [linket a külső fájlhoz](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/) tárol, és ezt használja az adatok olvasásához, így a prezentáció megnyitása és mentése nem érinti a munkafüzetet. Azonban a diagramadatokon (lásd az alábbi **Diagramadatok szerkesztése** részt) keresztül módosított értékek vissza lesznek írva a külső munkafüzetbe a prezentáció mentésekor – ezért dolgozzon másolaton, ha az eredetit érintetlenül kell hagyni.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a csatoláskor. Általános megoldás, hogy előre eltávolítja a védelmet, vagy egy feloldott másolatot (például az [Aspose.Cells](/cells/python-net/) segítségével) készít, és ahhoz csatolja.

**Több diagram hivatkozhat‑e ugyanarra a külső munkafüzetsre?**

Igen. Minden diagram a saját linkjét tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.