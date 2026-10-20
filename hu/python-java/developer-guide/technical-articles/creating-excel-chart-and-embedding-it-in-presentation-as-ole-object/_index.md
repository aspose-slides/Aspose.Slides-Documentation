---
title: Excel diagramok létrehozása és beágyazása prezentációkba OLE objektumként
type: docs
weight: 30
url: /hu/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel diagram
- diagram beágyazása
- OLE objektum
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Excel diagram létrehozása az Aspose.Cells for Python via Java segítségével, és a munkafüzet beágyazása PowerPoint prezentációba az Aspose.Slides használatával, diagram előnézettel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhat létre Excel oszlopdiagramot az Aspose.Cells for Python via Java segítségével, és ágyazhatja be a munkafüzetet egy PowerPoint előadásba az Aspose.Slides for Python via Java segítségével. A beágyazott munkafüzet tartalmazza a forrásadatokat és a diagramot is. Egy külön PNG előnézet jeleníti meg a diagramot a dián az OLE objektum aktiválása előtt.

Az eredmény egy beágyazott Excel objektum, nem natív PowerPoint diagram. A munkafüzet OLE-on keresztüli szerkesztéséhez szükség van egy asztali alkalmazásra, amely támogatja az OLE aktiválást, és kompatibilis Excel telepítésre.

## **Előfeltételek**

Telepítse az `aspose-cells` és `aspose-slides-java` Python csomagokat valamint egy kompatibilis Java futtatókörnyezetet. Importálja mindkét csomagot a JVM indítása előtt, hogy a Java könyvtáraik elérhetők legyenek a JPype számára. A Microsoft Office nem szükséges a bemutató generálásához ezekkel a könyvtárakkal.

Nem szükséges bemeneti fájl: a példa memóriában hozza létre az adatokat és a diagramot, majd a `OutputChart.pptx` fájlt a jelenlegi munkakönyvtárba írja. Alkalmazzon licenceket mindkét termékre, ha értékelő módon kívül futtatja.

## **Hogyan működik a beágyazás**

1. Hozzon létre egy munkafüzetet egy adat munkalappal és egy diagramlapbal.
1. Tegye a diagramlapot aktívvá, hogy a munkafüzet a diagramon nyíljon meg.
1. Állítsa be a munkafüzet OLE megjelenítési tartományát, és renderelje a diagramot PNG formátumba.
1. Mentse a munkafüzetet XLSXként memóriában, és ágyazza be ezeket a bájtokat egy diára.
1. Rendelje hozzá a PNG-t az OLE objektum előnézeteként, és mentse a bemutatót PPTX formátumban.

A munkafüzet megjelenítési tartománya és a dián lévő keret külön szerepet tölt be. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) nulla alapú kezdő/​záró sor- és oszlopindexet vár. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) ehelyett a felső sor, bal oszlop, alsó sor és jobb oszlop értékét veszi. A példa a 55‑os sorindexet és a 25‑ös oszlopindexet használja alsó‑jobb határként; ezek az értékek elrendezési döntések, nem az adat sorok vagy oszlopok száma.

A diaképkazetta pontokat használ. A példa a dián belül elhelyezi és középre igazítja, miközben megőrzi a PNG képarányát, ahelyett, hogy a előnézetet a dia kitöltésére nyújtaná.

## **Diagram létrehozása és beágyazása**

A következő teljes példa négy sor és öt oszlop értékkel tölti fel a `DataSheet`-et. Minden sor egy diagram sorozattá válik. A `ChartSheet` aktív munkalapként van kiválasztva a munkafüzet mentése előtt.

A munkafüzet kifejezetten XLSX formátumban van mentve, amely megfelel a `xlsx` kiterjesztésnek, amelyet a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) kap. A Java bájt‑tömb áramlatok a munkafüzetet és a képet memóriában tartják, és a Java API‑k által igényelt bájt‑tömböket biztosítják. A PNG közvetlenül a bájtjaiból van betöltve köztes bitmap átalakítás nélkül. A [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) használatával történő hozzárendelés lecseréli az alapértelmezett OLE helyőrzőt.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Renderelje a diagram előnézetét, és külön sorosítsa a szerkeszthető munkafüzetet.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Illessze a előnézetet a diába az arányok megváltoztatása nélkül.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Várt eredmény**

`OutputChart.pptx` egy diát tartalmaz beágyazott Excel munkafüzettel és egy diagram előnézettel. A munkafüzet az eredeti adatokat és egy négy sorozatos oszlopdiagramot tartalmaz. Az előnézet a dián középre van igazítva és megtartja arányait.

![Excel oszlopdiagram, amely a beágyazott munkafüzet előnézeteként jelenik meg](excel-chart-ole-preview.png)

Kompatibilis asztali PowerPoint környezetben, ahol az Excel elérhető, kattintson duplán az objektumra a beágyazott munkafüzet aktiválásához és szerkesztéséhez. Az aktiválás és szerkesztés a gazdaalkalmazás OLE támogatásától és biztonsági beállításaitól függ.

## **GYIK**

**Miért szükséges az előnézeti kép?**

A beágyazott munkafüzet és a diájának előnézete különálló tartalom. Adjon meg egy diagramképet, hogy a dia a diagramot jelenítse meg az alapértelmezett „EMBEDDED OLE OBJECT” helyőrző helyett. Lásd [Objektum előnézet probléma OleObjectFrame hozzáadásakor](/slides/hu/python-java/object-preview-issue-when-adding-oleobjectframe/).

**Frissül automatikusan az előnézet, ha a kódban módosítom a munkafüzetet?**

Kezelje az előnézetet pillanatképként. Amikor programozottan frissíti a munkafüzet adatait, generálja újra a diagram képet, és cserélje le az előnézetet, valamint a beágyazott munkafüzet adatait.

**Használhatok XLS-t XLSX helyett?**

Igen. Mentse a munkafüzetet XLS formátumban, és használja az `xls` kiterjesztést beágyazott adatként. A kiterjesztésnek meg kell egyeznie a tényleges munkafüzet formátummal; a kiterjesztés önmagában nem konvertálja az adatot.

**Miért változhat meg az objektum mérete aktiválás után?**

A gazdaalkalmazás frissítheti az OLE objektum megjelenését, amikor aktiválja a munkafüzetet. A munkafüzet OLE megjelenítési tartománya és a diakeret méretei egyaránt számítanak. Lásd [Működő megoldás a diagram átméretezésére PPTX-ben](/slides/hu/python-java/working-solution-for-chart-resizing-in-pptx/).

## **Kapcsolódó szakaszok**

- [Működő megoldás a diagram átméretezésére PPTX-ben](/slides/hu/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Objektum előnézet probléma OleObjectFrame hozzáadásakor](/slides/hu/python-java/object-preview-issue-when-adding-oleobjectframe/)