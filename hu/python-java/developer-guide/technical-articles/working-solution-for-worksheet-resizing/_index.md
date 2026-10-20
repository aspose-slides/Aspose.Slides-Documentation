---
title: Működő megoldás a munkalap átméretezéséhez
type: docs
weight: 20
url: /hu/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- előnézeti kép
- kép átméretezése
- Excel
- munkalap
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két mód a objektumkeretek konzisztens megtartására—a keret vagy a munkalap skálázása—mind a PPT, mind a PPTX formátumokban."
---
{{% alert color="info" title="Note" %}}
Az Aspose komponensekkel PowerPoint‑prezentációba beágyazott OLE objektumként megjelenő Excel‑munkalapok első aktiválásuk után váratlanul átméreteződhetnek. Ez a viselkedés észrevehető vizuális különbséget eredményez az OLE objektum aktiválás előtti és utáni állapota között. Ez a cikk ismerteti a problémát, és leír két megoldási módot.
{{% /alert %}}

## **Háttér**

A [Manage OLE](/slides/hu/python-java/manage-ole/) cikkben elmagyaráztuk, hogyan lehet OLE keretet hozzáadni egy PowerPoint‑prezentációhoz az Aspose.Slides for Python via Java segítségével. Az [object preview issue](/slides/hu/python-java/object-preview-issue-when-adding-oleobjectframe/) megoldásához a kiválasztott munkalap területének képét rendeltük az OLE objektum keretéhez. A kimeneti prezentációban, ha duplán kattint a munkalap képet mutató OLE objektum keretére, az Excel‑munkafüzet aktiválódik. A végfelhasználók a tényleges Excel‑munkafüzeten bármilyen módosítást elvégezhetnek, majd a diára visszatérhetnek a aktivált Excel‑munkafüzeten kívülre kattintva. Az OLE objektum keret mérete megváltozik, amikor a felhasználó visszatér a diára. Az átméretezési tényező a OLE objektum keret és a beágyazott Excel‑munkafüzet méretétől függ.

## **Az átméretezés oka**

Mivel az Excel‑munkafüzettel saját ablakmérete van, az első aktiváláskor megpróbálja megtartani eredeti méretét. Ezzel szemben az OLE objektum keretnek is saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy a beágyazási folyamat részeként a helyes arányok megmaradjanak. Az átméretezés az Excel‑ablak mérete és az OLE objektum keret mérete és pozíciója közti különbségen alapul.

## **Működő megoldás**

Két lehetséges megoldás létezik az átméretezési hatás elkerülésére.

- Mérje skálára az OLE keretet a PowerPoint‑prezentációban, hogy megegyezzen a kiválasztott sorok és oszlopok teljes magasságával és szélességével.
- Tartsa állandó méretűnek az OLE keretet, és skálázza a kiválasztott sorokat és oszlopokat, hogy beleférjenek.

### **OLE keret méretének skálázása**

Ez a megközelítés beállítja az OLE keret méretét, hogy megegyezzen a beágyazott Excel‑munkalapban a kiválasztott sorok és oszlopok teljes magasságával és szélességével.

A példa betölt egy meglévő Excel‑munkafüzetet, és a nulla‑alapú indexekkel kiválasztja az első munkalap első 10 sorát és 13 oszlopát. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definiálja a megjelenített tartományt. Az előnézet 96 DPI‑n kerül renderelésre, pixelméretei 72 pont per hüvelyk alapján pontokra konvertálásra kerülnek. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) a módosított munkafüzetet egy ezeknek a méreteknek megfelelő keretbe ágyazza be. Az előnézetet a [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) segítségével rendeljük hozzá, hogy a mentett prezentációban a „EMBEDDED OLE OBJECT” helyőrzőt helyettesítsük.

Az előnézetsegéd beállítja a [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) a kiválasztott tartományra, és eltávolítja a margókat, fejléceket és lábléceket. Az [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) engedélyezésével a [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) PNG‑képként rendereli a tartományt. A segéd egy új bemeneti streamet ad vissza, amely a PNG‑képet tartalmazza, az elején pozicionálva a prezentációban való felhasználáshoz.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Állítsa be a megjelenített méretet, amikor a munkafüzet OLE objektumként van használva PowerPointban.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Szerezze meg az OLE kép szélességét és magasságát pontban.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Használja a módosított munkafüzetet.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Adja hozzá az OLE képet a prezentáció erőforrásaihoz.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Hozza létre az OLE objektum keretet.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **A cellatartomány méretének skálázása**

Ez a megközelítés a kiválasztott sorok magasságát és a kiválasztott oszlopok szélességét úgy skálázza, hogy megfeleljen egy egyéni OLE keret méretének.

A példa betölt egy meglévő Excel‑munkafüzetet, és a nulla‑alapú indexekkel kiválasztja az első munkalap első 10 sorát és 13 oszlopát. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definiálja a megjelenített tartományt, és a scale_cell_range segéd ezt a tartományt olyan keretre méretezi, amely 400 pont széles és 100 pont magas. A módosított munkafüzet streambe mentése után a [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) a megadott mérettel ágyazza be. A 96 DPI‑n renderelt előnézet a [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) segítségével van hozzárendelve, így a mentett prezentáció a kiválasztott cellákat jeleníti meg az alapértelmezett helyőrző helyett.

A skálázó segéd külön szélesség‑ és magasságarányt számol a kiválasztott tartományra, megőrizve az oszlopok relatív szélességét és a sorok relatív magasságát. A számított méreteket pontból hüvelykre konvertálja, mielőtt a [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) és a [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch) segítségével alkalmazná. A kiválasztott tartománynak nem nulla szélességűnek és magasságúnak kell lennie.

Ez az előnézetsegéd a [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) segítségével rendereli a átméretezett tartományt. A [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) csak erre a tartományra korlátozza, eltávolítja a margókat, fejléceket és lábléceket, és egy PNG‑streamet ad vissza, amely az elején helyezkedik el.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # A cellatartomány várható szélessége és magassága pontban van megadva.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Állítsa be a megjelenített méretet, amikor a munkafüzet OLE objektumként van használva PowerPointban.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Skálázza a cellatartományt a keret méretéhez.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Használja a módosított munkafüzetet.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Adja hozzá az OLE képet a prezentáció erőforrásaihoz.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Hozza létre az OLE objektum keretet.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **Összegzés**

{{% alert color="info" title="Note" %}} 
Két megközelítés létezik a munkalap átméretezési probléma megoldására. Válassza azt a megközelítést, amely legjobban megfelel az igényeinek és felhasználási esetének. Mindkét megközelítés ugyanúgy működik, akár sablonból, akár a semmiből készült prezentációk esetén. Emellett nincs korlátozás az OLE objektum keret méretére ebben a megoldásban.
{{% /alert %}}

## **GYIK**

**Miért változik méretben egy beágyazott Excel‑munkalap, amikor először aktiválják PowerPointban?**  
Ez azért történik, mert az Excel megpróbálja megtartani az eredeti ablakméretet aktiváláskor, míg a PowerPointban az OLE objektum keretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet a képarány megőrzése érdekében, ami az átméretezést okozhat.

**Lehet teljesen megakadályozni ezt az átméretezési problémát?**  
Igen. Az OLE keret skálázásával az Excel cellatartomány méretéhez, vagy a cellatartomány skálázásával a kívánt OLE keret méretéhez megakadályozható a nem kívánt átméretezés.

**Melyik skálázási módszert használjam, az OLE keret skálázását vagy a cellatartomány skálázását?**  
Válassza az **OLE keret skálázását**, ha az eredeti Excel sor- és oszlopszélességeket szeretné megtartani. Válassza a **cellatartomány skálázását**, ha fix méretű OLE keretet kíván a prezentációjában.

**Működnek ezek a megoldások, ha a prezentációm sablonon alapul?**  
Igen. Mindkét megoldás működik sablonból és a semmiből létrehozott prezentációk esetén is.

**Van korlátozás az OLE keret méretére, ha ezeket a módszereket használjuk?**  
Nem. Az OLE objektum keretet tetszőleges méretűre állíthatja, amíg a skálát megfelelően beállítja.

**Van mód a PowerPointban az "EMBEDDED OLE OBJECT" helyőrző szöveg elkerülésére?**  
Igen. A célnak megfelelő Excel cellatartomány pillanatképének elkészítésével és azt az OLE keret helyőrző képeként beállítva megjeleníthet egy egyedi előnézeti képet az alapértelmezett helyőrző helyett.

## **Kapcsolódó cikkek**

[Excel-diagram létrehozása és OLE objektumként való beágyazása egy prezentációba](/slides/hu/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE-objektumok automatikus frissítése MS PowerPoint bővítmény használatával](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)