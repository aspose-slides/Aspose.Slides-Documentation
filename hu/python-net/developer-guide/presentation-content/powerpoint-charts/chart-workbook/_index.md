---
title: Diagrammunkafüzetek kezelése prezentációkban Python segítségével
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
description: "Fedezze fel az Aspose.Slides-t Python számára .NET-en keresztül: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a diagrammunkafüzetekkel dolgozni az Aspose.Slides‑ben. Megmutatja, hogyan lehet a diagramadatokat munkafüzet‑folyamokon keresztül olvasni és írni, a munkafüzet‑cellákat diagramcímkeként használni, a munkalap‑gyűjteményekhez hozzáférni, és megadni az adatforrás típusát a diagramértékekhez.

Továbbá tárgyalja a külső munkafüzetek diagramadat‑forrásként való használatát. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolódó külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagramadatokat, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides módszereket biztosít a diagramadat‑munkafüzetek (amelyek Aspose.Cells‑szel szerkesztett diagramadatokat tartalmaznak) olvasására és írására. **Megjegyzés:** A diagramadatoknak ugyanúgy vagy hasonló szerkezetben kell felépülniük, mint a forrásban.

A következő Python‑kód egy példaműveletet mutat be:

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

### **Diagramelrendezés ellenőrzése munkafüzet módosítása után**

Amikor egy beágyazott munkafüzetet egy módosítottra cserélünk, a diagram megtartja az eredeti sorozat‑ és kategóriagyűjteményeit. Ez a nem egyezés [IChart.validate_chart_layout](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichart/validate_chart_layout/) hibához vezethet, amely index‑kívül‑tartományi hibát dob. Írja ki a meglévő sorozatokat és kategóriákat, mielőtt az új munkafüzetet visszaírná a diagramba.

```python
# A munkafüzet adatfolyam módosítása után (pl. Aspose.Cells használatával)
updated_workbook = chart_data.read_workbook_stream()

# Létező adat hivatkozások tisztítása.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

A gyűjtemények törlése biztosítja, hogy a diagram adatstruktúrája egyezzen az új munkafüzettel, lehetővé téve a `validate_chart_layout` hibamentes befejezését.

## **Munkafüzetcellát használni diagramadatcímkeként**

Néha olyan diagramcímkékre van szükség, amelyek közvetlenül a mögöttes adatmunkafüzet celláiból származnak. Az Aspose.Slides lehetővé teszi, hogy adatcímkéket adott munkafüzetcellákhoz kössön, így a címkeszöveg mindig a cella értékét tükrözi. Az alábbi példa megmutatja, hogyan lehet cellából származó címkéket engedélyezni, és a kiválasztott címkéket egyéni cellákra mutatni a diagram munkafüzetében.

1. Hozzon létre egy példányt a [Presentation](https://docs.aspose.com/slides/hu/python-net/api-reference/aspose.slides/presentation/) osztályból.  
1. Szerezze be a diát index alapján.  
1. Adjon hozzá egy buborékdiagramot mintaadatokkal.  
1. Hozzáférés a diagram sorozatához.  
1. Használjon egy munkafüzetcellát adatcímkeként.  
1. Mentse a prezentációt.

A következő Python‑kód mutatja, hogyan állíthat be egy munkafüzetcellát diagramadatcímkeként:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Példányosítsa a Presentation osztályt, amely egy prezentációfájlt képvisel.
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

Az alábbi Python‑kód bemutatja, hogyan használja a `worksheets` tulajdonságot a munkalap‑gyűjtemény eléréséhez:

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

## **Adatforrás típusának megadása**

Az alábbi Python‑kód mutatja, hogyan adhatja meg az adatforrás típusát:

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

## **Nem támogatott beágyazott munkafüzet formátumok felismerése**

Az Aspose.Slides nem támogatja a néhány diagramhoz beágyazható Excel bináris munkafüzet (.xlsb) formátumot. Használhatja a `embedded_workbook_type` tulajdonságot a [ChartData](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/) osztályon, valamint a [WorkbookType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/workbooktype/) felsorolást az nem támogatott formátumok felismeréséhez és azok a diagramok kihagyásához.

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
            # A beágyazott munkafüzet .xlsb formátumban van, amely nem támogatott.
            continue

        # Olvassa vagy módosítsa itt a diagram munkafüzet adatát.
```

## **Külső munkafüzetek**

Az Aspose.Slides támogatja a külső munkafüzetek diagramadat‑forrásként való használatát.

### **Külső munkafüzetek beállítása**

A [ChartData.set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódus használatával egy külső munkafüzetet rendelhet a diagram adatforrásaként. Ez a metódus frissítheti a külső munkafüzet útvonalát is, ha azt áthelyezték.

Bár a távoli helyeken vagy erőforrásokon tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja ezeket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá konvertálódik.

Az alábbi Python‑kód mutatja, hogyan állíthat be egy külső munkafüzetet:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Adja meg a False értéket, így csak az útvonal kerül tárolásra: a cél munkafüzettnek még nem kell léteznie.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

A [set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódus `update_chart_data` paramétere határozza meg, hogy az Excel‑munkafüzet be lesz‑töltve-e.

- Ha az `update_chart_data` értéke `False`, csak a munkafüzet útvonala frissül; a diagramadatot nem töltik be, és nem frissítik a célmunkafüzetről. Ezt a beállítást használja, ha a célmunkafüzet nem létezik vagy nem érhető el.  
- Ha az `update_chart_data` értéke `True` (az alapértelmezett), a diagramadat be‑ és frissül a célmunkafüzetről. Ha a munkafüzetet nem lehet megnyitni, a rendszer „External workbook is not available” üzenetű kivételt dob.

### **Külső munkafüzetek létrehozása**

A [read_workbook_stream](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódusok használatával akár teljesen új külső munkafüzetet hozhat létre, vagy egy belső munkafüzetet alakíthat át külsővé.

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

### **Külső adatforrás munkafüzet útvonalának lekérése diagramhoz**

Néha egy diagram adatai egy külső Excel‑munkafüzethez vannak kapcsolva a prezentáció beágyazott adatai helyett. Az Aspose.Slides segítségével megvizsgálhatja a diagram adatforrását, és ha külső munkafüzetről van szó, kiolvashatja a teljes munkafüzeter útvonalát.

1. Hozzon létre egy példányt a [Presentation](https://docs.aspose.com/slides/hu/python-net/api-reference/aspose.slides/presentation/) osztályból.  
1. Szerezze be a diát index szerint.  
1. Szerezze be a diagram alakzatot.  
1. Szerezze meg a forrást ([ChartDataSourceType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatasourcetype/)), amely a diagram adatforrását jelöli.  
1. Ellenőrizze, hogy a forrás típusa megegyezik‑e a külső munkafüzet adatforrás típusával.

Az alábbi Python‑kód demonstrálja a műveletet:

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

Ugyanúgy szerkesztheti a külső munkafüzetek adatait, mint a belső munkafüzetekét. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram olyan külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides rekonstruálhatja a diagram munkafüzetét a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/), majd a [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/spreadsheet_options/) segítségével engedélyezze a [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/hu/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) beállítást, mielőtt megnyitná a prezentációt.

Az alábbi Python‑példa megnyit egy prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [Chart.chart_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/chart_data/) és a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével éri el:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Olvassa vagy módosítsa itt a helyreállított munkafüzet adatait.
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárból származó diagramadatok használata elfogadható tartalékmegoldás, mivel a gyorsítótár esetleg nem tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése óta történt változtatásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram egy külső vagy beágyazott munkafüzethez van-e kapcsolva?**  
Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/data_source_type/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/); ha a forrás egy külső munkafüzet, kiolvashatja a teljes útvonalat, hogy megbizonyosodjon a külső fájl használatáról.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút útvonalra konvertálódik. Ez praktikus a projektek hordozhatóságához; azonban a prezentáció az abszolút útvonalat tárolja a PPTX‑fájlban.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztott meghajtókon?**  
Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként alkalmazhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**  
Csak akkor, ha a diagram adatát szerkesztette. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/) tárol, és ezt használja az adatok olvasásához, így a prezentáció megnyitása és mentése nem módosítja a munkafüzetet. Azonban a diagramon keresztül módosított értékek (lásd a **Diagramadatok szerkesztése** részt fent) visszaírásra kerülnek a külső munkafüzetbe a prezentáció mentésekor – dolgozzon egy másolaton, ha az eredetit érintetlenül kell hagyni.

**Mit kell tennem, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad jelszót a hivatkozás létrehozásakor. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat előkészítése (például az [Aspose.Cells](/cells/python-net/) használatával), majd a másolatra való hivatkozás.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése a következő adatbetöltéskor minden diagramon megjelenik.