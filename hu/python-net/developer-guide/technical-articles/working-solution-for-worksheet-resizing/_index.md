---
title: Működő megoldás a munkalap átméretezéséhez
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
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két mód a objektumkeretek következetes megtartására – a keret vagy a munkalap skálázásával – a PPT és PPTX formátumokban."
---
{{% alert color="primary" %}} 

Megfigyeltük, hogy az Aspose komponensekkel PowerPoint‑prezentációba beágyazott OLE‑objektumként megjelenő Excel‑munkalapok az első aktiválás után egy meghatározatlan arányra méreteződnek át. Ez a viselkedés észrevehető vizuális különbséget eredményez a prezentációban az OLE‑objektum aktiválás előtti és utáni állapota között. Részletesen kivizsgáltuk a problémát, és megoldást kínálunk, amelyet ebben a cikkben ismertetünk.

{{% /alert %}} 

## **Háttér**

A [OLE kezelése](/slides/hu/python-net/manage-ole/) című cikkben bemutattuk, hogyan adhatunk OLE‑keretet egy PowerPoint‑prezentációhoz az Aspose.Slides for Python via .NET használatával. A [objektum előnézeti probléma](/slides/hu/python-net/object-preview-issue-when-adding-oleobjectframe/) kezelésére egy képet rendeltünk a kiválasztott munkalap‑területből az OLE‑objektumkerethez. A kimeneti prezentációban, ha dupla‑kattintással aktiválja az OLE‑objektumkeretet, amely a munkalap‑képet mutatja, az Excel‑munkafüzet aktiválódik. A végfelhasználók a valódi Excel‑munkafüzetben tetszőleges módosításokat végezhetnek, majd a aktivált Excel‑munkafüzeten kívülre kattintva visszatérhetnek a diára. Az OLE‑objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára. A méretezési arány a OLE‑objektumkeret és a beágyazott Excel‑munkafüzet méretétől függően változik.

## **Méretezés oka**

Mivel az Excel‑munkafüzetnek saját ablakmérete van, az első aktiváláskor megpróbálja megtartani eredeti méretét. Ezzel szemben az OLE‑objektumkeretnek saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy a beágyazási folyamat részeként a megfelelő arányok megmaradjanak. A méretezés a Excel‑ablak mérete és az OLE‑objektumkeret mérete‑pozíciója közötti különbségek alapján történik.

## **Működő megoldás**

Két lehetséges megoldás létezik a méretezési hatás elkerülésére.

- Skálázza az OLE‑keret méretét a PowerPoint‑prezentációban, hogy megegyezzen a kívánt sor‑ és oszlopszám magasságával és szélességével az OLE‑keretben.
- Tartsa állandóan az OLE‑keret méretét, és skálázza a résztvevő sorok és oszlopok méretét, hogy illeszkedjen a kiválasztott OLE‑keret méretéhez.

### **OLE‑keret méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan állítható be a beágyazott Excel‑munkafüzet OLE‑keretmérete úgy, hogy az megegyezzen a munkalapban résztvevő sorok és oszlopok összesített méretével.

Tegyük fel, hogy rendelkezünk egy mintasablonnal, és azt OLE‑keretként szeretnénk hozzáadni egy prezentációhoz. Ebben az esetben az OLE‑objektumkeret méretét először a munkafüzetben részt vevő sorok magasságának és oszlopok szélességének összegzése alapján számoljuk ki. Ezután ezt a kiszámított értéket állítjuk be az OLE‑keret méretének. A PowerPoint‑ban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében a munkafüzetben kiválasztott sor‑ és oszlopszakaszokból képet is rögzítünk, és azt állítjuk be OLE‑keret‑képként.

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Állítsa be a megjelenített méretet, amikor a munkafüzet fájlt OLE objektumként használják PowerPointban.
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

            # Hozzon létre OLE objektumkeretet.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **A cellatartomány méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan skálázhatók a résztvevő sorok magasságai és a résztvevő oszlopok szélességei egy egyedi OLE‑keretmérethez igazodva.

Tegyük fel, hogy rendelkezünk egy mintasablonnal, és azt OLE‑keretként szeretnénk hozzáadni egy prezentációhoz. Ebben az esetben beállítjuk az OLE‑keret méretét, és a keret területébe tartozó sorok és oszlopok méretét skálázzuk. Ezután a munkafüzetet egy adatfolyamba mentjük, hogy alkalmazzuk a változtatásokat, és bájt‑tömbbé konvertáljuk, hogy az OLE‑keretbe felvehessük. A PowerPoint‑ban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében a munkafüzetben kiválasztott sor‑ és oszlopszakaszokból képet is rögzítünk, és azt állítjuk be OLE‑keret‑képként.

```py
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

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Állítsa be a megjelenített méretet, amikor a munkafüzet fájlt OLE objektumként használják PowerPointban.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Skálázza a cellatartományt, hogy illeszkedjen a keretmérethez.
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

            # Hozzon létre OLE objektumkeretet.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Következtetés**

{{% alert color="primary" %}}

Két megközelítés létezik a munkalap‑méretezési probléma megoldására. A megfelelő megközelítés kiválasztása a konkrét követelményektől és felhasználási esettől függ. Mindkét módszer egyformán működik, akár sablonból, akár a semmiből hozunk létre prezentációkat. Emellett a megoldásban nincs korlátozás az OLE‑objektumkeret méretére vonatkozóan.

{{% /alert %}}