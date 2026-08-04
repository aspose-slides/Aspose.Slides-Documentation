---
title: Diagrammunkafüzetek kezelése prezentációkban Python használatával
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/python-net/chart-workbook/
keywords:
- diagrammunkafüzet
- diagramadat
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
description: "Fedezze fel az Aspose.Slides for Python .NET-en keresztül: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációi adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a diagram munkafüzetekkel dolgozni az Aspose.Slides segítségével. Megmutatja, hogyan lehet a diagram adatokat munkafüzet‑folyamokon keresztül olvasni és írni, a munkafüzet cellákat diagram adatcímkeként használni, a munkalap‑gyűjteményekhez hozzáférni, és meghatározni az adatforrás típusát a diagramértékekhez.

Emellett tárgyalja a külső munkafüzetek diagram adatforrásként való használatát. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz csatolt külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagram adatokat, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides módszereket biztosít a diagramadatokat tartalmazó munkafüzetek (amelyek az Aspose.Cells‑sel szerkesztett diagramadatokat tartalmazzák) olvasására és írására. **Megjegyzés:** A diagramadatoknak ugyanúgy vagy a forráshoz hasonló szerkezetben kell lenniük.

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

## **Munkafüzetcellát beállítása diagramadatcímkeként**

Előfordulhat, hogy a diagramcímkék közvetlenül a mögöttes adatmunkafüzet celláiból származnak. Az Aspose.Slides lehetővé teszi, hogy az adatcímkéket konkrét munkafüzetcellákhoz kössük, így a címke szövege mindig a cella értékét tükrözi. Az alábbi példa bemutatja, hogyan engedélyezhetők a cella‑értékre épülő címkék, és hogyan irányíthatók a kiválasztott címkék egyedi cellákra a diagram munkafüzetében.

1. Hozzon létre egy példányt a [Presentation](https://docs.aspose.com/slides/hu/python-net/api-reference/aspose.slides/presentation/) osztályból.  
2. Szerezzen referenciát a diára index szerint.  
3. Adjon hozzá egy buborékdiagramot mintaadatokkal.  
4. Érje el a diagram sorozatát.  
5. Használjon munkafüzetcellát adatcímkeként.  
6. Mentse a prezentációt.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
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

Az alábbi Python kód bemutatja, hogyan használhatja a `worksheets` tulajdonságot a munkalapgyűjtemény eléréséhez:

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

## **Az adatforrás típusának megadása**

Az alábbi Python kód mutatja, hogyan adhatja meg az adatforrás típusát:

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

## **Nem támogatott beágyazott munkafüzet formátumok észlelése**

Aspose.Slides nem támogatja a néhány diagramba beágyazható Excel bináris munkafüzet (.xlsb) formátumot. A `embedded_workbook_type` tulajdonságot a [ChartData](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/) osztályon és a [WorkbookType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/workbooktype/) felsoroláson együtt használva észlelheti a nem támogatott formátumokat, és kihagyhatja ezeket a diagramokat.

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
            # A beágyazott munkafüzet .xlsb formátumban van, ami nem támogatott.
            continue

        # Olvassa vagy módosítsa a diagram munkafüzete adatait itt.
```

## **Külső munkafüzetek**

Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásaként való használatát.

### **Külső munkafüzetek beállítása**

A [ChartData.set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódus használatával egy külső munkafüzetet rendelhet egy diagram adatforrásaként. Ez a metódus frissítheti a külső munkafüzet elérési útját is, ha az át lett helyezve.

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, ezek a munkafüzetek továbbra is használhatók külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes úttá alakul.

Az alábbi Python kód mutatja, hogyan állíthat be egy külső munkafüzetet:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Az [set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódus `update_chart_data` paramétere azt határozza meg, hogy az Excel munkafüzet be lesz‑tölve-e.

- Ha `update_chart_data` értéke `False`, csak a munkafüzet útvonala frissül; a diagramadatok nem töltődnek be, és nem frissülnek a célnak megfelelő munkafüzetről. Ezt a beállítást akkor használja, ha a cél munkafüzet nem létezik vagy nem érhető el.  
- Ha `update_chart_data` értéke `True`, a diagramadatok beolvasásra és frissítésre kerülnek a cél munkafüzetről.

### **Külső munkafüzetek létrehozása**

A [read_workbook_stream](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódusok használatával akár egy külső munkafüzetet hozhat létre a semmiből, vagy egy belső munkafüzetet alakíthat külsővé.

Az alábbi Python kód bemutatja a külső munkafüzet létrehozási folyamatát:

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

### **A diagram külső adatforrás‑munkafüzete útvonalának lekérése**

Előfordulhat, hogy egy diagram adatai egy külső Excel munkafüzettel vannak összekapcsolva a prezentáció beágyazott adatainak helyett. Az Aspose.Slides segítségével ellenőrizheti a diagram adatforrását, és ha külső munkafüzet, beolvashatja a teljes munkafüzet útvonalát.

1. Hozzon létre egy példányt a [Presentation](https://docs.aspose.com/slides/hu/python-net/api-reference/aspose.slides/presentation/) osztályból.  
2. Szerezzen referenciát a diára a megadott index alapján.  
3. Szerezzen referenciát a diagram alakra.  
4. Szerezze meg a forrást ([ChartDataSourceType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatasourcetype/)), amely a diagram adatforrását képviseli.  
5. Ellenőrizze, hogy a forrástípus egyezik‑e a külső munkafüzet adatforrás típusával.

Az alábbi Python kód bemutatja a műveletet:

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

Külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetekét. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides képes rekonstruálni a diagram munkafüzetét a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/) példányt, majd a prezentáció megnyitása előtt engedélyezze a [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/hu/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) beállítást a [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/spreadsheet_options/) segítségével.

Az alábbi Python példa megnyit egy prezentációt, amelynek diagramja elérhetetlen külső munkafüzettel hivatkozik, és a helyreállított adatokat a [Chart.chart_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/chart_data/) és a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével érheti el:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Olvassa vagy módosítsa a helyreállított munkafüzet adatait itt.
```

Ha a külső munkafüzet nem elérhető és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. A helyreállítást csak akkor engedélyezze, ha a gyorsítótárazott diagramadatok használata elfogadható megoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzeten a prezentáció legutóbbi frissítése után végzett módosításokat.

## **GYIK**

**Meg tudom állapítani, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e kapcsolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/data_source_type/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/); ha a forrás egy külső munkafüzet, akkor beolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, hogy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút úttá konvertálódik. Ez kényelmes a projekt hordozhatósága szempontjából; azonban vegye figyelembe, hogy a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok a hálózati erőforrásokon/megosztott helyeken lévő munkafüzeteket?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafűzetei közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX‑t a prezentáció mentésekor?**

Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/) tárol, és azt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a csatoláskor. Egy gyakori megoldás, hogy előre eltávolítja a védelmet, vagy egy dekódolt másolatot készít (például az [Aspose.Cells](/cells/python-net/) használatával), majd ehhez a másolathoz csatolja.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése a következő adatbetöltéskor minden diagramra kihat.