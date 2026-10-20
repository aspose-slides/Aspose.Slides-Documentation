---
title: Werkende oplossing voor het aanpassen van de grootte van een werkblad
type: docs
weight: 40
url: /nl/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- preview-afbeelding
- afbeeldingsgrootte aanpassen
- Excel
- werkblad
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Los het OLE-grootteprobleem van Excel-werkbladen in presentaties op: twee manieren om objectframes consistent te houden — schaal het frame of het blad — in zowel PPT- als PPTX-formaten."
---
{{% alert color="info" title="Note" %}}

Excel-werkbladen die als OLE-objecten in een PowerPoint‑presentatie zijn ingesloten met Aspose‑componenten, kunnen onverwacht van grootte veranderen na hun eerste activering. Dit gedrag veroorzaakt een opvallend visueel verschil tussen het OLE‑object vóór en na activering. Dit artikel legt het probleem uit en beschrijft twee manieren om het op te lossen.

{{% /alert %}} 

## **Achtergrond**

In het artikel [Manage OLE](/slides/nl/python-net/manage-ole/) legden we uit hoe je een OLE‑frame toevoegt aan een PowerPoint‑presentatie met Aspose.Slides for Python via .NET. Om het [object preview issue](/slides/nl/python-net/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we een afbeelding van het gekozen werkbladgebied toegewezen aan het OLE‑objectframe. In de uitvoer‑presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de werkbladafbeelding weergeeft, wordt de Excel‑werkmap geactiveerd. Eindgebruikers kunnen eventuele gewenste wijzigingen aanbrengen in de daadwerkelijke Excel‑werkmap en vervolgens terugkeren naar de dia door buiten de geactiveerde Excel‑werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia. De schaalfactor varieert afhankelijk van de grootte van het OLE‑objectframe en de ingesloten Excel‑werkmap. 

## **Oorzaak van het formaat wijzigen**

Aangezien de Excel‑werkmap zijn eigen venstergrootte heeft, probeert hij bij de eerste activering zijn oorspronkelijke grootte te behouden. Aan de andere kant heeft het OLE‑objectframe zijn eigen afmetingen. Volgens Microsoft onderhandelen Excel en PowerPoint over de grootte wanneer de Excel‑werkmap wordt geactiveerd, om de juiste verhoudingen te behouden als onderdeel van het insluitingsproces. Het formaat wordt aangepast op basis van de verschillen tussen de Excel‑venstergrootte en de afmetingen en positie van het OLE‑objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het formaat‑wijzigings effect te vermijden.

- Schaal het OLE‑frame in de PowerPoint‑presentatie zodat het overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen.
- Houd de grootte van het OLE‑frame constant en schaal de geselecteerde rijen en kolommen zodat ze erin passen.

### **Schaal de OLE‑frame‑grootte**

Deze methode stelt de grootte van het OLE‑frame in op de totale hoogte en breedte van de geselecteerde rijen en kolommen in het ingesloten Excel‑werkblad.

Het voorbeeld laadt een bestaande Excel‑werkmap en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met nul‑gebaseerde indexen. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definieert het weergegeven bereik. De preview wordt gerenderd op 96 DPI en de pixelafmetingen worden omgezet naar punten met 72 punten per inch. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) embedde de aangepaste werkmap in een frame met die afmetingen. De preview wordt toegewezen via [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) om de “EMBEDDED OLE OBJECT”‑plaatsaanduiding in de opgeslagen presentatie te vervangen.

De preview‑helper stelt [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) in op het geselecteerde bereik en verwijdert marges, kopteksten en voetteksten. Met [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) ingeschakeld, renderen [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) het bereik als een PNG‑afbeelding. De helper zet de afbeeldings‑stream terug naar het begin voordat deze wordt geretourneerd voor gebruik in de presentatie.

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

Het volledige voorbeeld hieronder combineert de helpers met werkmap‑insluiting en slaat de presentatie op als `output.pptx`.

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

    # Stel de weergegeven grootte in wanneer het werkboekbestand wordt gebruikt als OLE-object in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Haal de breedte en hoogte van de OLE-afbeelding op in punten.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # We moeten het aangepaste werkboek gebruiken.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Voeg de OLE-afbeelding toe aan de presentatie-resources.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Maak het OLE-objectframe.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Schaal de celbereik‑grootte**

Deze methode schaalt de hoogtes van de geselecteerde rijen en de breedtes van de geselecteerde kolommen zodat ze overeenkomen met een aangepaste OLE‑frame‑grootte.

Het voorbeeld laadt een bestaande Excel‑werkmap en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met nul‑gebaseerde indexen. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definieert het weergegeven bereik, en de helper hieronder schaalt dat bereik zodat het past in een frame van 400 punten breed en 100 punten hoog. Na het opslaan van de aangepaste werkmap naar een stream, embedde [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) deze op de opgegeven grootte. Een preview gerenderd op 96 DPI wordt toegewezen via [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), zodat de opgeslagen presentatie de geselecteerde cellen toont in plaats van de standaardplaatsaanduiding.

De schaal‑helper berekent afzonderlijke breedte‑ en hoogteratio’s voor het geselecteerde bereik, waarbij de relatieve breedtes van de kolommen en de relatieve hoogtes van de rijen worden behouden. De berekende afmetingen worden omgezet van punten naar inches voordat ze worden toegepast met [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) en [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). Het geselecteerde bereik moet een niet‑nul breedte en hoogte hebben.

```py
import aspose.cells as cells

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

Deze preview‑helper rendert het geschaalde bereik met [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Het beperkt [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) tot dat bereik, verwijdert marges, kopteksten en voetteksten, en retourneert een PNG‑stream die zich aan het begin bevindt.

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

Het volledige voorbeeld hieronder combineert de helpers met werkmap‑insluiting en slaat de presentatie op als `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

    # Stel de weergegeven grootte in wanneer het werkboekbestand wordt gebruikt als OLE-object in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Schaal het celbereik zodat het in de framegrootte past.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # We moeten het aangepaste werkboek gebruiken.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Voeg de OLE-afbeelding toe aan de presentatie-resources.
            ole_image = presentation.images.add_image(image_stream)

            # Maak het OLE-objectframe.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Conclusie**

{{% alert color="info" title="Note" %}}

Er zijn twee benaderingen om het formaat‑wijzingsprobleem van het werkblad op te lossen. Kies de benadering die het beste past bij uw eisen en gebruikssituatie. Beide benaderingen werken op dezelfde manier, of de presentaties nu vanuit een sjabloon of vanaf nul worden gemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

{{% /alert %}}

## **FAQ**

**Waarom verandert een ingesloten Excel‑werkblad van grootte bij de eerste activering in PowerPoint?**

Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te behouden bij activering, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat tot de grootte‑aanpassing kan leiden.

**Is het mogelijk om dit formaat‑wijzingsprobleem volledig te voorkomen?**

Ja. Door het OLE‑frame te schalen zodat het past bij de Excel‑celbereik‑grootte of door het celbereik te schalen naar de gewenste OLE‑frame‑grootte, kun je ongewenste formaatwijzigingen voorkomen.

**Welke schaalmethode moet ik gebruiken, OLE‑frame‑schaal of celbereik‑schaal?**

Kies **OLE‑frame‑schaal** als je de oorspronkelijke Excel‑rij‑ en kolomgroottes wilt behouden. Kies **celbereik‑schaal** als je een vaste grootte voor het OLE‑frame in je presentatie wilt.

**Werken deze oplossingen als mijn presentatie op een sjabloon is gebaseerd?**

Ja. Beide oplossingen werken voor presentaties die vanuit sjablonen of vanaf nul zijn gemaakt.

**Is er een limiet aan de grootte van het OLE‑frame bij het gebruik van deze methoden?**

Nee. Je kunt het OLE‑objectframe elke gewenste grootte geven, zolang je de schaal correct instelt.

**Is er een manier om de tekst “EMBEDDED OLE OBJECT” in PowerPoint te vermijden?**

Ja. Door een snapshot van het doel‑Excel‑celbereik te maken en deze in te stellen als de plaatsaanduidingsafbeelding van het OLE‑frame, kun je een aangepaste preview‑afbeelding weergeven in plaats van de standaardplaatsaanduiding.