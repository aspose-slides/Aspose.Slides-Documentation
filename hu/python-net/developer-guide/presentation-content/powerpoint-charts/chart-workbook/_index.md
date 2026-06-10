---
title: Diagram munkafüzetek kezelése prezentációkban Python segítségével
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/python-net/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adat
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Python-t .NET-en keresztül: könnyedén kezelje a diagram munkafüzeteit PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhatunk diagrammunnevekkel (chart workbooks) az Aspose.Slides-ben. Bemutatja, hogyan lehet olvasni és írni diagramadatokat munkafüzet‑folyamokon keresztül, a munkafüzet‑cellákat diagramadat‑címkeként használni, a munkalap‑gyűjteményekhez hozzáférni, valamint a diagramértékek adatforrás‑típusát megadni.

Továbbá kitér a külső munkafüzetek diagramadat‑forrásként való használatára. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz csatolt külső munkafüzet útvonalát, és hogyan szerkeszthetünk diagramadatokat, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides módszereket biztosít a diagramadat‑munkafüzetek (amelyek Aspose.Cells‑szel szerkesztett diagramadatokat tartalmaznak) olvasására és írására. **Megjegyzés:** A diagramadatoknak ugyanúgy kell szervezve lenniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Az alábbi Python‑kód egy minta műveletet mutat be:

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

## **WorkBook cellát beállítani diagramadat‑címkeként**

Néha olyan diagramcímkékre van szükség, amelyek közvetlenül a mögöttes adatmunkafüzet celláiból származnak. Az Aspose.Slides lehetővé teszi, hogy adatcímkéket konkrét munkafüzet‑cellákhoz kötve a címke szövege mindig a cella értékét tükrözze. Az alábbi példa megmutatja, hogyan engedélyezhetők cella‑érték‑címkék, és hogyan irányíthatók a kiválasztott címkék egyéni cellákra a diagram munkafüzetében.

1. Hozzon létre egy példányt a [Presentation](https://docs.aspose.com/slides/hu/python-net/api-reference/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást a diára index alapján.
1. Adjon hozzá egy buborékdiagramot mintaadatokkal.
1. Hozzáférés a diagram sorozatokhoz.
1. Használjon munkafüzet‑cellát adatcímkeként.
1. Mentse el a prezentációt.

Az alábbi Python‑kód megmutatja, hogyan állítható be egy munkafüzet‑cellát diagramadat‑címkeként:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
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

Az alábbi Python‑kód bemutatja, hogyan használhatja a `worksheets` tulajdonságot a munkalap‑gyűjtemény eléréséhez:

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

## **Nem támogatott beágyazott munkafüzet‑formátumok felismerése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. Használhatja az `embedded_workbook_type` tulajdonságot a [ChartData](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/) osztályon, együtt a [WorkbookType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/workbooktype/) felsorolással, hogy felismerje a nem támogatott formátumokat, és kihagyja az érintett diagramokat.

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
            # Beágyazott munkafüzet .xlsb formátumban van, amely nem támogatott.
            continue

        # Itt olvassa vagy módosíthatja a diagram munkafüzet adatait.
```

## **Külső munkafüzetek**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként való használatát.

### **Külső munkafüzetek beállítása**

A [ChartData.set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódus használatával egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ez a metódus frissítheti a külső munkafüzet útvonalát is, ha az áthelyezésre kerül.

Bár nem szerkesztheti a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait, továbbra is használhatja ezeket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá konvertálódik.

Az alábbi Python‑kód megmutatja, hogyan állítható be egy külső munkafüzet:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

A `update_chart_data` paraméter a [set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódusban határozza meg, hogy az Excel‑munkafüzet betöltődjön‑e.

- Ha `update_chart_data` értéke `False`, csak a munkafüzet útvonala frissül; a diagramadatok nem töltődnek be vagy frissülnek a célmunkafüzetből. Ezt a beállítást akkor használja, ha a célmunkafüzet nem létezik vagy nem érhető el.
- Ha `update_chart_data` értéke `True`, a diagramadatok beolvasásra és frissítésre kerülnek a célmunkafüzetből.

### **Külső munkafüzetek létrehozása**

A [read_workbook_stream](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódusok használatával vagy egy új külső munkafüzetet hozhat létre teljesen vagy egy belső munkafüzetet alakíthat át külsővé.

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

Néha a diagram adatai egy külső Excel‑munkafüzethez vannak csatolva a prezentáció beágyazott adatai helyett. Az Aspose.Slides segítségével ellenőrizheti a diagram adatforrását, és ha külső munkafüzetről van szó, kiolvashatja a teljes munkafüzet‑útvonalat.

1. Hozzon létre egy példányt a [Presentation](https://docs.aspose.com/slides/hu/python-net/api-reference/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást a diára index szerint.
1. Szerezzen hivatkozást a diagram alakzatára.
1. Szerezze meg a forrást ([ChartDataSourceType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatasourcetype/)), amely a diagram adatforrását képviseli.
1. Ellenőrizze, hogy a forrástípus egyezik‑e a külső munkafüzettel.

Az alábbi Python‑kód bemutatja a műveletet:

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

A külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetekét. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzettel van‑e összekötve?**

Igen. A diagramnak van egy [data source type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/data_source_type/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/); ha a forrás egy külső munkafüzet, leolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, külső fájlt használ‑e.

**Támogatottak‑e a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. Ez a projekt hordozhatóságát segíti; azonban vegye figyelembe, hogy a prezentáció az abszolút útvonalat tárolja a PPTX‑fájlban.

**Használhatok‑e munkafüzeteket hálózati erőforrásokon/megosztott meghajtókon?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja‑e a külső XLSX‑et a prezentáció mentésekor?**

Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/) tárol, és ezt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszó‑védett?**

Az Aspose.Slides nem fogad el jelszót a hivatkozáskor. Általános megoldás, hogy a védelmet előzetesen eltávolítja, vagy egy visszafejtett másolatot (például a [Aspose.Cells](/cells/python-net/) használatával) készít, és arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.