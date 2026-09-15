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
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két módja annak, hogy az objektumkereteket konzisztens módon tartsa — skálázza a keretet vagy a lapot — a PPT és PPTX formátumok között."
---
{{% alert color="info" title="Note" %}}

Megfigyeltük, hogy az Excel munkalapok, amelyeket OLE objektumként ágyaznak be egy PowerPoint‑prezentációba az Aspose komponenseken keresztül, az első aktiválás után nem meghatározott méretarányra átméreteződnek. Ez a viselkedés észrevehető vizuális különbséget eredményez a prezentációban az OLE objektum aktiválás előtti és utáni állapota között. Alaposan kivizsgáltuk ezt a problémát, és megoldást nyújtottunk, amely ebben a cikkben szerepel.

{{% /alert %}}

## **Háttér**

Az [Manage OLE](/slides/hu/python-java/manage-ole/) című cikkben bemutattuk, hogyan adhatunk OLE keretet egy PowerPoint‑prezentációhoz az Aspose.Slides for Python via Java segítségével. A [object preview issue](/slides/hu/python-java/object-preview-issue-when-adding-oleobjectframe/) megoldásaként egy képet rendeltünk a kiválasztott munkalap területéről az OLE objektum keretéhez. A kimeneti prezentációban, ha duplán rákattint a munkalap képet megjelenítő OLE objektum keretre, az Excel munkafüzet aktiválódik. A végfelhasználó tetszőleges módosítást végezhet az Excel munkafüzeten, majd kattintással visszatér a diára, amikor az aktivált Excel munkafüzeten kívülre kattint. Az OLE objektum keret mérete megváltozik, amikor a felhasználó visszatér a diára. Az átméretezési tényező a OLE objektum keret és a beágyazott Excel munkafüzet méretétől függ.

## **Átméretezés oka**

Mivel az Excel munkafüzetnek saját ablakmérete van, az első aktiváláskor megpróbálja megtartani eredeti méretét. Ezzel szemben az OLE objektum keretnek saját mérete van. A Microsoft szerint, amikor az Excel munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy a beágyazási folyamat részeként a megfelelő arányok megmaradjanak. Az átméretezés az Excel ablakmérete és az OLE objektum keret mérete‑pozíciója közti különbségen alapul.

## **Működő megoldás**

Két lehetséges megoldás létezik az átméretezési hatás elkerülésére.

- Skálázza az OLE keret méretét a PowerPoint‑prezentációban, hogy az egyezzen a kívánt sor‑ és oszlopszám magasságával és szélességével az OLE keretben.
- Tartsa állandó méretűnek az OLE keretet, és skálázza a részt vevő sorok és oszlopok méretét, hogy azok beleférjenek a kiválasztott OLE keret méretébe.

### **OLE keret méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan állítsuk be a beágyazott Excel munkafüzet OLE keret méretét úgy, hogy az egyezzen a munkalap részt vevő sorainak és oszlopainak összegzett méretével.

Tegyük fel, hogy van egy sablon Excel‑lapunk, és OLE keretként szeretnénk hozzáadni egy prezentációhoz. Ebben a szcenárióban az OLE objektum keret méretét először a munkafüzet részt vevő sorainak magasságának és oszlopainak szélességének összegzése alapján számítjuk ki. Ezután a számított értékre állítjuk be az OLE keret méretét. Annak érdekében, hogy elkerüljük a piros „EMBEDDED OLE OBJECT” üzenetet az OLE keretnél a PowerPointban, a munkafüzetben a kívánt sor‑ és oszloptartományok képét is rögzítjük, és azt állítjuk be OLE keret képének.

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

    # Állítsa be a megjelenített méretet, amikor a munkafüzet OLE objektumként van használva a PowerPointban.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Szerezze meg az OLE kép szélességét és magasságát pontokban.
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

### **Cellatartomány méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan skálázzuk a részt vevő sorok magasságát és oszlopok szélességét, hogy azok illeszkedjenek egy egyéni OLE keret méretéhez.

Tegyük fel, hogy van egy sablon Excel‑lapunk, és OLE keretként szeretnénk hozzáadni egy prezentációhoz. Ebben a szcenárióban beállítjuk az OLE keret méretét, majd skálázzuk a keret területébe tartozó sorok és oszlopok méretét. Ezután a munkafüzetet egy stream‑be mentjük a változások alkalmazásához, és byte‑tömbbé konvertáljuk, hogy hozzáadhassuk az OLE kerethez. Annak érdekében, hogy elkerüljük a piros „EMBEDDED OLE OBJECT” üzenetet az OLE keretnél a PowerPointban, a munkafüzetben a kívánt sor‑ és oszloptartományok képét is rögzítjük, és azt állítjuk be OLE keret képének.

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
    # A cell-tartomány várható szélessége és magassága pontban van.
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

    # Állítsa be a megjelenített méretet, amikor a munkafüzet OLE objektumként van használva a PowerPointban.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Skálázza a cella-tartományt, hogy illeszkedjen a keret méretéhez.
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

## **Következtetés**

{{% alert color="info" title="Note" %}} 

Két megközelítés létezik a munkalap átméretezési probléma megoldására. Az megfelelő megközelítés kiválasztása a konkrét követelményektől és felhasználási esettől függ. Mindkét módszer egyformán működik, legyen szó sablonból vagy semmiből kiinduló prezentációról. Emellett nincs korlátozás az OLE objektum keret méretére ebben a megoldásban.

{{% /alert %}}

## **GYIK**

**Miért változik méretben egy beágyazott Excel munkalap, amikor először aktiválják PowerPointban?**

Ez azért történik, mert az Excel megpróbálja megtartani az eredeti ablakméretét aktiváláskor, míg a PowerPoint‑ban az OLE objektum keretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet, hogy megőrizzék az arányt, ami átméretezést eredményezhet.

**Lehetséges-e teljesen megakadályozni ezt az átméretezési problémát?**

Igen. Az OLE keret skálázásával az Excel cellatartomány méretéhez, vagy a cellatartomány skálázásával az kívánt OLE keret méretéhez megakadályozható a nem kívánt átméretezés.

**Melyik skálázási módszert használjam, OLE keret skálázást vagy cellatartomány skálázást?**

Válassza az **OLE keret skálázást**, ha az eredeti Excel sor‑ és oszlopszélességeket szeretné megtartani. Válassza a **cellatartomány skálázást**, ha a prezentációban egy rögzített OLE keretméretet kíván.

**Működnek-e ezek a megoldások, ha a prezentáció sablon alapján készült?**

Igen. Mindkét megoldás működik sablonból és a semmiből kiinduló prezentációk esetén egyaránt.

**Van-e korlátozás az OLE keret méretére ezen módszerek alkalmazásakor?**

Nem. Az OLE objektum keretet tetszőleges méretűre állíthatja, amíg a skálázást megfelelően beállítja.

**Létezik-e módja annak, hogy elkerüljük a „EMBEDDED OLE OBJECT” helykitöltő szöveget a PowerPointban?**

Igen. A célzott Excel cellatartomány pillanatfelvételét beállítva OLE keret helykitöltő képeként, egy saját előnézeti képet jeleníthet meg az alapértelmezett helykitöltő helyett.

## **Kapcsolódó cikkek**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/hu/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)