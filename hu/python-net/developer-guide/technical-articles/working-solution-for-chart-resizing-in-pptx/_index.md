---
title: Működő megoldás a diagram átméretezésére PPTX-ben
type: docs
weight: 60
url: /hu/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezés
- Excel diagram
- OLE objektum
- diagram beágyazása
- PowerPoint
- prezentáció
- Python a .NET-en keresztül
- Python
- Aspose.Slides
description: "Javítsa a PPTX-ben előforduló váratlan diagram átméretezést, ha beágyazott Excel OLE objektumokat használ az Aspose.Slides for Python via .NET segítségével. Állítson be rögzített diagramméreteket, hogy a diagram és az OLE keret méretei konzisztens maradjanak."
---
## **Áttekintés**

Az Aspose komponensekkel létrehozott PowerPoint‑prezentációkba beágyazott OLE objektumként megjelenő Excel-diagramok az első aktiválásuk után méretet változtathatnak. Ez észrevehető különbséget okozhat a diagram megjelenése között aktiválás előtt és után. Ez a cikk elmagyarázza, miért történik az átméretezés, és bemutatja, hogyan lehet megakadályozni azt a diagram rögzített méretének az OLE‑kerethez való illesztésével.

A [Excel-diagramok létrehozása és beágyazása OLE objektumként a prezentációkba](/slides/hu/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) részben elmagyaráztuk, hogyan hozhatunk létre egy Excel-diagramot az Aspose.Cells for Python via .NET segítségével, és hogyan ágyazhatjuk be egy PowerPoint‑prezentációba az Aspose.Slides for Python via .NET használatával. A [objektum előnézeti probléma](/slides/hu/python-net/object-preview-issue-when-adding-oleobjectframe/) kezelésére a diagram képét a diagram OLE objektumkerethez rendeltük. A kimeneti prezentációban, amikor dupla‑klikkelsz a diagramképet megjelenítő OLE objektumkereten, az Excel-diagram aktiválódik. A felhasználók szerkeszthetik a beágyazott Excel‑munkafüzetet, majd a diára visszatérhetnek az aktivált munkafüzeten kívülre kattintva. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára, és az átméretezési arány a OLE objektumkeret és a beágyazott Excel‑munkafüzet eredeti méreteitől függ.

## **Az átméretezés oka**

A beágyazott Excel‑munkafüzetnek saját ablakmérete van, amelyet az Excel megpróbál megtartani, amikor az objektum először aktiválódik. A dián lévő OLE keret függetlenül definiált méretekkel rendelkezik. Amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik az objektum méretét, hogy megőrizzék arányait az beágyazási folyamat részeként. A munkafüzetablak és az OLE keret közötti különbségek ezért okozhatják az objektum átméretezését.

## **Működő megoldás**

Illessze a diagram méretét az OLE kerethez a dián, és tartsa a diagramdimenziókat függetlenül a munkafüzetablaktól. Ez a megoldás új prezentációval vagy meglévő sablonnal egyaránt működik.

A példa az Aspose.Cells for Python via .NET és az Aspose.Slides for Python via .NET használatát igényli. Egy egyszerű oszlopdiagramot hoz létre egy aktív diagramlapon, és beágyazza a munkafüzetet XLS formátumban. Nem rendel diagramelőnézeti képet; a diagram akkor válik láthatóvá, amikor a OLE objektum aktiválódik a PowerPointban.

A példa egy új prezentációt hoz létre 9,5 × 4‑hüvelykes OLE kerettel, amely 0,5 hüvelykre van pozicionálva a bal élről, és 1 hüvelykre a tetejétől. A dia koordinátái és méretei pontokban vannak (72 pont hüvelykenként). Meglévő prezentáció esetén lásd a [Sablon használata](#use-a-template) részt.

## **Rögzített diagramméret beállítása**

Állítsa a [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) értékét **false**‑ra, hogy a diagramdimenziók függetlenek legyenek a munkafüzetablaktól. Állítsa be a [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) méreteit a [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) és a [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/) segítségével, a pontokat pixelekké konvertálva 96 pixel per hüvelyk alapján: egy 684 × 288 pont méretű keret 912 × 384 pixel méretű diagramnak felel meg. Állítsa a [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) értékét a [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/) **CUSTOM** értékére. A példa a [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) segítségével ágyazza be a munkafüzetet, és 9,5 × 4‑hüvelykes OLE kerettel menti a prezentációt.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Diak koordinátái és méretei pontban vannak (72 pont hüvelykenként).
    width = 684.0  # 9,5 hüvelyk.
    height = 288.0  # 4 hüvelyk.

    chart.size_with_window = False
    # Pontok átkonvertálása diagrampixelekké 96 pixel per hüvelyk alapján.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Sablon használata**

A méretezési logika ugyanaz egy meglévő prezentáció esetén is. A példa adaptálásához:

1. Töltse be a sablonprezentációt egy üres prezentáció létrehozása helyett.  
1. Ellenőrizze, hogy az első dián legalább három alakzat található, majd használja a 2. indexű alakzatot helykitöltőként.  
1. Vegye a keret szélességét és magasságát ebből az alakzatból, a 684 × 288 rögzített értékek helyett. Tartsa változatlanul a méretezési számításokat.  
1. Adja hozzá az OLE keretet a helykitöltő pozíciójához a 36 × 72 rögzített koordináták helyett.  
1. Távolítsa el a helykitöltőt a prezentáció mentése előtt.

## **GYIK**

**Miért változik a beágyazott Excel-diagram mérete a PowerPointban történő aktiválás után?**

Ez azért történik, mert az Excel megpróbálja a kezdeti aktiváláskor visszaállítani az eredeti ablakméretet, míg a PowerPoint OLE‑keretének saját dimenziói vannak. A PowerPoint és az Excel egyeztetik a méretet az arányok megtartása érdekében, ami az átméretezést eredményezheti.

**Hogyan tarthatom konzisztensnek a diagram és az OLE‑keret méretét?**

Állítson be rögzített diagramdimenziókat, amelyek megegyeznek az OLE‑keret méretével, és használjon egy egyéni diagramnyomtatási méretet a munkafüzet beágyazása előtt. A fenti példa a szükséges beállításokat és egységkonverziókat mutatja be.

**Elégséges a munkafüzet-ablak méretének illesztése?**

A munkafüzet‑ablak méretének csak önmagában történő illesztése nem biztos, hogy megbízhatóan megakadályozza az OLE‑keret méretének változását aktiválás után. Használjon rögzített diagramdimenziókat, ahogy a példában látható.

**Működik ez a megoldás sablonalapú és új prezentációk esetén is?**

Igen. Sablon esetén a helykitöltő méreteit és pozícióját használja. Új prezentáció esetén a keret méretét és pozícióját adja meg közvetlenül.

**Használhatom ezt a példát más táblázatkezelő programokkal létrehozott diagramokkal?**

A példa egy Aspose.Cells‑el létrehozott Excel‑munkafüzetet használ. Nem mutat be aktiválási viselkedést más táblázatkezelő programok esetén.

## **Kapcsolódó szakaszok**

- [Excel-diagramok létrehozása és beágyazása OLE objektumként a prezentációkba](/slides/hu/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE objektumok automatikus frissítése PowerPoint‑kiegészítő használatával](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)