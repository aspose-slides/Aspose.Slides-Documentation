---
title: Működő megoldás a munkalap átméretezésére
type: docs
weight: 40
url: /hu/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- előnézeti kép
- kép átméretezés
- Excel
- munkalap
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két mód a objektumkeretek egységességének megtartására—keret vagy lap méretezése—mind a PPT, mind a PPTX formátumokban."
---
{{% alert color="info" title="Note" %}}
Az Aspose összetevőket használó PowerPoint-prezentációba OLE‑objektumként beágyazott Excel‑munkalapok első aktiválásuk után váratlanul átméreteződhetnek. Ez a viselkedés észrevehető vizuális különbséget eredményez az OLE‑objektum aktiválás előtti és utáni állapota között. Ez a cikk ismerteti a problémát, és leír két megoldási lehetőséget.
{{% /alert %}} 

## **Háttér**

Az [OLE kezelése](/slides/hu/python-net/manage-ole/) cikkben bemutattuk, hogyan lehet OLE‑keretet hozzáadni egy PowerPoint‑prezentációhoz az Aspose.Slides for Python via .NET használatával. Az [objektum előnézeti probléma](/slides/hu/python-net/object-preview-issue-when-adding-oleobjectframe/) megoldásaként a kijelölt munkalap területének képét rendeltük az OLE‑objektum kerethez. A kimeneti prezentációban, ha duplán kattint a munkalap képet megjelenítő OLE‑objektum keretre, az Excel‑munkafüzet aktiválódik. A végfelhasználók tetszőleges módosítást végezhetnek az aktuális Excel‑munkafüzeten, majd a diára visszatérhetnek a aktivált Excel‑munkafüzeten kívülre kattintva. Az OLE‑objektum keret mérete megváltozik, amikor a felhasználó visszatér a diára. Az átméretezési tényező a OLE‑objektum keret és a beágyazott Excel‑munkafüzet méretétől függ.

## **Az átméretezés oka**

Mivel az Excel‑munkafüzet saját ablakmérettel rendelkezik, az első aktiváláskor megpróbálja megtartani eredeti méretét. Ezzel szemben az OLE‑objektum keretnek megvan a saját mérete. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy biztosítsák a megfelelő arányok megtartását a beágyazási folyamat részeként. Az átméretezés a Excel‑ablak mérete és az OLE‑objektum keret mérete és pozíciója közti eltérések alapján történik.

## **Működő megoldás**

Két lehetséges megoldás létezik az átméretezési hatás elkerülésére.

- Méretezze át az OLE‑keretet a PowerPoint‑prezentációban, hogy a kijelölt sorok és oszlopok teljes magasságával és szélességével megegyezzen.
- Tartsa állandó méretűnek az OLE‑keretet, és méretezze a kijelölt sorokat és oszlopokat, hogy beleilleszkedjen.

### **OLE‑keret méretének méretezése**

Ez a megközelítés beállítja az OLE‑keret méretét, hogy a beágyazott Excel‑munkalapban a kijelölt sorok és oszlopok teljes magasságával és szélességével megegyezzen.

A példa betölti egy meglévő Excel‑munkafüzetet, és kiválasztja az első munkalap első 10 sorát és 13 oszlopát nullától számolt indexekkel. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definiálja a megjelenített tartományt. Az előnézetet 96 DPI-n rendereljük, és a pixelméreteket 72 pont per hüvelyk alapján pontokra konvertáljuk. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) a módosított munkafüzetet egy olyan keretbe ágyazza be, amelynek méretei ezek. Az előnézetet a [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) segítségével rendeli hozzá, hogy a mentett prezentációban a "EMBEDDED OLE OBJECT" helyőrzőt lecserélje.

Az előnézet segédprogram a [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) beállítja a kiválasztott tartományra, és eltávolítja a margókat, fejléceket és lábléceket. A [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) engedélyezésével a [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) PNG képként rendereli a tartományt. A segédprogram visszatekeri a képadatfolyamot, mielőtt azt a prezentációban felhasználásra visszaadná.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

Az alábbi teljes példa kombinálja a segédprogramokat a munkafüzet beágyazásával, és a prezentációt `output.pptx` néven menti.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Állítsa be a megjelenített méretet, amikor a munkafüzet fájlt OLE objektumként használják a PowerPointban.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Szerezze meg az OLE kép szélességét és magasságát pontban.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # A módosított munkafüzetet kell használnunk.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Adja hozzá az OLE képet a prezentáció erőforrásaihoz.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Hozza létre az OLE objektumkeretet.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Cellatartomány méretének méretezése**

Ez a megközelítés a kijelölt sorok magasságát és a kijelölt oszlopok szélességét úgy méretezi, hogy egy egyedi OLE‑keret méretének megfeleljen.

Az példában betöltünk egy meglévő Excel‑munkafüzetet, és nullától számolt indexekkel kiválasztjuk az első munkalap első 10 sorát és 13 oszlopát. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definiálja a megjelenített tartományt, és az alábbi segédprogram ezt a tartományt úgy méretezi, hogy egy 400 pont széles és 100 pont magas keretbe illeszkedjen. A módosított munkafüzetet egy adatfolyamba mentés után a [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) a megadott mérettel ágyazza be. Egy 96 DPI‑n renderelt előnézetet a [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) segítségével rendeljük hozzá, így a mentett prezentáció a kiválasztott cellákat jeleníti meg az alapértelmezett helyőrző helyett.

A méretező segédprogram külön szélesség‑ és magasságrátákat számít ki a kiválasztott tartományra, megőrizve oszlopai relatív szélességét és sorai relatív magasságát. A számított méreteket pontból hüvelykre konvertálja, mielőtt a [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) és a [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/) segítségével alkalmazná. A kijelölt tartománynak nem lehet nulla szélességű vagy magasságú.

```py
import aspose.cells as cells

# <param name="width">A cellatartomány várt szélessége pontban.</param>
# <param name="height">A cellatartomány várt magassága pontban.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

Ez a előnézet segédprogram a [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) segítségével rendereli a méretezett tartományt. A [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) csak erre a tartományra korlátozza, eltávolítja a margókat, fejléceket és lábléceket, és egy PNG adatfolyamot ad vissza, amely az elejére van pozicionálva.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

Az alábbi teljes példa kombinálja a segédprogramokat a munkafüzet beágyazásával, és a prezentációt `output.pptx` néven menti.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">A cellatartomány várt szélessége pontban.</param>
# <param name="height">A cellatartomány várt magassága pontban.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Állítsa be a megjelenített méretet, amikor a munkafüzet fájlt OLE objektumként használják a PowerPointban.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Méretezzük a cellatartományt, hogy illeszkedjen a keret méretéhez.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # A módosított munkafüzetet kell használnunk.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Adja hozzá az OLE képet a prezentáció erőforrásaihoz.
            ole_image = presentation.images.add_image(image_stream)

            # Hozza létre az OLE objektumkeretet.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Következtetés**

{{% alert color="info" title="Note" %}}
Az munkalap átméretezési problémáját két megközelítés oldja meg. Válassza azt a megközelítést, amely a legjobban megfelel az igényeinek és felhasználási esetének. Mindkét megoldás ugyanúgy működik, függetlenül attól, hogy a prezentációt sablonból vagy a semmiből hozza létre. Továbbá ebben a megoldásban nincs korlát az OLE‑objektum keret méretére.
{{% /alert %}}

## **GYIK**

**Miért változik meg a beágyazott Excel‑munkalap mérete, amikor először aktiválják a PowerPointban?**

Ez azért történik, mert az Excel megpróbálja megtartani az eredeti ablakméretét aktiváláskor, míg a PowerPointben az OLE‑objektum keretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet, hogy az arányok helyesek legyenek, ami az átméretezést okozhat.

**Lehet‑e teljesen megakadályozni ezt az átméretezési problémát?**

Igen. Az OLE‑keretet úgy méretezve, hogy illeszkedjen az Excel cellatartomány méretéhez, vagy a cellatartományt úgy méretezve, hogy illeszkedjen a kívánt OLE‑keret méretéhez, megakadályozható a nem kívánt átméretezés.

**Melyik méretezési módszert használjam, OLE‑keret méretezése vagy cellatartomány méretezése?**

Válassza a **OLE frame scaling** lehetőséget, ha az eredeti Excel sor‑ és oszlopszélességeket szeretné megtartani. Válassza a **cell range scaling** lehetőséget, ha a prezentációban fix méretű OLE‑keretet szeretne.

**Fog működni ezek a megoldások, ha a prezentációm sablon alapján készült?**

Igen. Mindkét megoldás működik sablonból és a semmiből létrehozott prezentációknál is.

**Van korlát az OLE‑keret méretére ezen módszerek használatakor?**

Nem. Az OLE‑objektum keretet bármilyen méretűre beállíthatja, amíg a méretezést megfelelően állítja be.

**Van mód elkerülni az "EMBEDDED OLE OBJECT" helyőrző szöveget a PowerPointban?**

Igen. Ha a cél Excel cellatartományról készít felvételt, és azt OLE‑keret helyőrző képeként beállítja, akkor egy egyedi előnézeti képet jeleníthet meg az alapértelmezett helyőrző helyett.