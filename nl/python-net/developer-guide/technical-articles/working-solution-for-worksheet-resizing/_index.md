---
title: Werkende oplossing voor werkbladgrootte-aanpassing
type: docs
weight: 40
url: /nl/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- voorbeeldafbeelding
- afbeelding schalen
- Excel
- werkblad
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Los het OLE-grootte-aanpassingsprobleem van Excel-werkbladen in presentaties op: twee manieren om objectframes consistent te houden - het frame of het blad schalen - over de PPT- en PPTX-formaten."
---
{{% alert color="primary" %}} 

Er is geconstateerd dat Excel‑werkbladen die als OLE‑objecten in een PowerPoint‑presentatie via Aspose‑componenten zijn ingebed, na de eerste activatie tot een onbekende schaal worden aangepast. Dit gedrag veroorzaakt een merkbaar visueel verschil in de presentatie tussen de pre‑ en post‑activatiestatus van het OLE‑object. We hebben dit probleem uitvoerig onderzocht en een oplossing geboden, die in dit artikel wordt beschreven.

{{% /alert %}} 

## **Achtergrond**

In het artikel [Manage OLE](/slides/nl/python-net/manage-ole/) hebben we uitgelegd hoe je een OLE‑frame toevoegt aan een PowerPoint‑presentatie met Aspose.Slides for Python via .NET. Om het [object preview issue](/slides/nl/python-net/object-preview-issue-when-adding-oleobjectframe/) op te lossen, hebben we een afbeelding van het geselecteerde werkbladgebied toegewezen aan het OLE‑objectframe. In de gegenereerde presentatie wordt, wanneer je dubbelklikt op het OLE‑objectframe dat de werkbladafbeelding toont, het Excel‑werkboek geactiveerd. Eindgebruikers kunnen vervolgens gewenste wijzigingen aanbrengen in het werkelijke Excel‑werkboek en daarna terugkeren naar de dia door buiten het geactiveerde Excel‑werkboek te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia. De schaalfactor varieert afhankelijk van de grootte van het OLE‑objectframe en het ingesloten Excel‑werkboek. 

## **Oorzaak van de grootte‑aanpassing**

Aangezien het Excel‑werkboek zijn eigen venstergrootte heeft, probeert het bij de eerste activatie zijn oorspronkelijke formaat te behouden. Het OLE‑objectframe heeft echter zijn eigen afmetingen. Volgens Microsoft, wanneer het Excel‑werkboek wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte om ervoor te zorgen dat de juiste verhoudingen worden behouden als onderdeel van het insluitingsproces. De aanpassing gebeurt op basis van de verschillen tussen de Excel‑venstergrootte en de grootte en positie van het OLE‑objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het aanpassingseffect te voorkomen.

- Schaal de grootte van het OLE‑frame in de PowerPoint‑presentatie zodat deze overeenkomt met de hoogte en breedte van het gewenste aantal rijen en kolommen in het OLE‑frame.  
- Houd de grootte van het OLE‑frame constant en schaaf de grootte van de betrokken rijen en kolommen bij zodat ze binnen de gekozen OLE‑frame‑grootte passen.  

### **Grootte van het OLE‑frame schalen**

In deze aanpak leren we hoe we de grootte van het OLE‑frame van het ingesloten Excel‑werkboek kunnen instellen zodat deze overeenkomt met de cumulatieve grootte van de betrokken rijen en kolommen in het Excel‑werkblad.

Stel dat we een sjabloon‑Excel‑sheet hebben en deze willen toevoegen aan een presentatie als OLE‑frame. In dit scenario wordt de grootte van het OLE‑objectframe eerst berekend op basis van de cumulatieve rijhoogtes en kolombreedtes van de betrokken rijen en kolommen in het werkboek. Vervolgens stellen we de grootte van het OLE‑frame in op deze berekende waarde. Om de rode “EMBEDDED OLE OBJECT”‑melding voor het OLE‑frame in PowerPoint te vermijden, maken we ook een afbeelding van de gewenste delen van de rijen en kolommen in het werkboek en stellen we deze in als OLE‑frame‑afbeelding.

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

    # Stel de weergegeven grootte in wanneer het werkboekbestand wordt gebruikt als OLE-object in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Haalt de breedte en hoogte van de OLE-afbeelding op in punten.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # We moeten het aangepaste werkboek gebruiken.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Voeg de OLE-afbeelding toe aan de presentatieresources.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Maak het OLE-objectframe.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Grootte van het celbereik schalen**

In deze aanpak leren we hoe we de hoogtes van de betrokken rijen en de breedtes van de betrokken kolommen kunnen schalen zodat ze passen bij een aangepaste OLE‑frame‑grootte.

Stel dat we een sjabloon‑Excel‑sheet hebben en deze willen toevoegen aan een presentatie als OLE‑frame. In dit scenario stellen we de grootte van het OLE‑frame in en schalen we de grootte van de rijen en kolommen die deelnemen aan het OLE‑frame‑gebied. Daarna slaan we het werkboek op naar een stream om de wijzigingen toe te passen en converteren we het naar een byte‑array om toe te voegen aan het OLE‑frame. Om de rode “EMBEDDED OLE OBJECT”‑melding voor het OLE‑frame in PowerPoint te vermijden, maken we ook een afbeelding van de gewenste delen van de rijen en kolommen in het werkboek en stellen we deze in als OLE‑frame‑afbeelding.

```py
# <param name="width">De verwachte breedte van het celbereik in punten.</param>
# <param name="height">De verwachte hoogte van het celbereik in punten.</param>
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

    # Stel de weergegeven grootte in wanneer het werkboekbestand wordt gebruikt als OLE-object in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Scha al het celbereik zodat het in de frame-grootte past.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # We moeten het aangepaste werkboek gebruiken.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Voeg de OLE-afbeelding toe aan de presentatieresources.
            ole_image = presentation.images.add_image(image_stream)

            # Maak het OLE-objectframe.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Conclusie**

{{% alert color="primary" %}}

Er zijn twee benaderingen om het probleem met het aanpassen van de werkbladgrootte op te lossen. De keuze voor de juiste aanpak hangt af van de specifieke eisen en het gebruiksscenario. Beide benaderingen werken op dezelfde manier, of de presentaties nu vanuit een sjabloon of vanaf nul worden gemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

{{% /alert %}}