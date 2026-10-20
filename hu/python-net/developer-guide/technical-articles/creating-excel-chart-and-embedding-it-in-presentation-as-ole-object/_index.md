---
title: Excel-diagramok létrehozása és beágyazása bemutatókba OLE-objektumként
type: docs
weight: 50
url: /hu/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel diagram
- diagram beágyazása
- OLE objektum
- PowerPoint
- bemutató
- Python
- Python via .NET
- Aspose.Slides
description: "Excel-diagram létrehozása az Aspose.Cells for Python via .NET segítségével, és a munkafüzet beágyazása egy PowerPoint bemutatóba az Aspose.Slides használatával, diagram előnézettel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre Excel oszlopdiagramot az Aspose.Cells for Python via .NET segítségével, és ágyazhatjuk be a munkafüzetet egy PowerPoint-prezentációba az Aspose.Slides for Python via .NET segítségével. A beágyazott munkafüzet tartalmazza a forrásadatokat és a diagramot is. Egy külön PNG előnézet jeleníti meg a diagramot a dián, mielőtt az OLE‑objektum aktiválódik.

Az eredmény egy beágyazott Excel objektum, nem natív PowerPoint diagram. A munkafüzet OLE‑n keresztüli szerkesztéséhez szükség van egy asztali alkalmazásra, amely támogatja az OLE aktiválást, és kompatibilis Excel telepítéssel.

## **Előfeltételek**

Telepítse az `aspose-cells-python` és `aspose-slides` csomagokat a Python környezetébe. A Microsoft Office nem szükséges a prezentáció előállításához ezekkel a könyvtárakkal.

Nem igényel bemeneti fájlt: a példa memóriában hozza létre az adatokat és a diagramot, majd a `OutputChart.pptx` fájlt a jelenlegi munkakönyvtárba írja. Licencet kell alkalmazni mindkét termékre, ha nem értékelő módban fut.

## **A beágyazás működése**

1. Hozzon létre egy munkafüzetet egy adat munkalappal és egy diagramlappal.  
2. Tegye a diagramlapot aktívvá, hogy a munkafüzet a diagramon nyíljon meg.  
3. Állítsa be a munkafüzet OLE megjelenítési tartományát, és renderelje a diagramot PNG‑be.  
4. Mentse a munkafüzetet XLSX formátumban memóriában, és ágyazza be ezeket a bájtokat egy diára.  
5. Rendelje hozzá a PNG‑t az OLE‑objektum előnézeteként, és mentse a prezentációt PPTX formátumban.

A munkafüzet megjelenítési tartománya és a dián lévő keret különböző szerepeket tölt be. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) null‑alapú kezdő/ész sor‑ és oszlopindexeket vár. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) ezzel szemben a felső sort, bal oszlopot, alsó sort és jobb oszlopot veszi. A példa a 55‑ös sorindexet és a 25‑ös oszlopindexet használja a jobb‑alsó határokhoz; ezek az értékek elrendezési beállítások, nem az adatsorok vagy oszlopok száma.

A diakeret pontokban van megadva. A példa a dián belül igazítja, és középre helyezi, miközben megtartja a PNG arányait, ahelyett, hogy nyújtaná az előnézetet a teljes diára.

## **Diagram létrehozása és beágyazása**

A következő teljes példa a `DataSheet` munkalapot négy sor és öt oszlop értékkel tölti fel. Minden sor egy diagram sorozattá válik. A `ChartSheet` kerül kiválasztásra aktív munkalapként a munkafüzet mentése előtt.

A munkafüzet kifejezetten XLSX formátumban van mentve, ami megegyezik a `xlsx` kiterjesztéssel, amelyet az [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) kap. A PNG közvetlenül a streamből kerül betöltésre köztes bitmap konverzió nélkül. A [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) használatával történő hozzárendelés felülírja az alapértelmezett OLE helyőrzőt.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Renderelje a diagram előnézetét, és külön sorosítsa a szerkeszthető munkafüzetet.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Illessze az előnézetet a diára az arányok megváltoztatása nélkül.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Várható eredmény**

`OutputChart.pptx` egy diát tartalmaz, amely beágyazott Excel munkafüzetet és egy diagram előnézetet tartalmaz. A munkafüzet az eredeti adatokat és egy négy sorozatú oszlopdiagramot tartalmaz. Az előnézet a dián középen helyezkedik el, és megőrzi arányait.

![Excel oszlopdiagram megjelenítve egy beágyazott munkafüzet előnézeteként](excel-chart-ole-preview.png)

Egy kompatibilis asztali PowerPoint környezetben, ahol az Excel elérhető, dupla kattintással aktiválható és szerkeszthető a beágyazott munkafüzet. Az aktiválás és szerkesztés a host alkalmazás OLE támogatásától és biztonsági beállításaitól függ.

## **GYIK**

**Miért szükséges egy előnézeti kép?**  
A beágyazott munkafüzet és a dia előnézete különálló tartalom. Adjunk meg egy diagramképet, hogy a dia a diagramot mutassa az alapértelmezett „EMBEDDED OLE OBJECT” helyőrző helyett. Lásd [Objektum előnézeti probléma OleObjectFrame hozzáadásakor](/slides/hu/python-net/object-preview-issue-when-adding-oleobjectframe/).

**Frissül automatikusan az előnézet, ha a kódban módosítom a munkafüzetet?**  
Az előnézetet tekintse egy pillanatképként. Ha programozottan frissíti a munkafüzet adatait, újra kell generálni a diagramképét, és cserélni kell az előnézetet, valamint a beágyazott munkafüzet adatait.

**Használhatok‑e XLS‑et XLSX helyett?**  
Igen. Mentse a munkafüzetet XLS formátumban, és használja az `xls` kiterjesztést a beágyazott adatként. A kiterjesztésnek meg kell egyeznie a tényleges munkafüzet formátummal; a kiterjesztés csak módosítása nem konvertálja az adatot.

**Miért változhat az objektum mérete az aktiválás után?**  
A host alkalmazás frissítheti az OLE‑objektum megjelenését, amikor aktiválja a munkafüzetet. A munkafüzet OLE megjelenítési tartománya és a diakeret méretei is számítanak. Lásd [OLE objektumok automatikus átméretezése PowerPoint prezentációkban](/slides/hu/python-net/working-solution-for-worksheet-resizing/).

## **Kapcsolódó szakaszok**

- [OLE objektumok automatikus átméretezése PowerPoint prezentációkban](/slides/hu/python-net/working-solution-for-worksheet-resizing/)
- [Objektum előnézeti probléma OleObjectFrame hozzáadásakor](/slides/hu/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [OLE objektumok kezelése](/slides/hu/python-net/manage-ole/)