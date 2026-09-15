---
title: Werkende oplossing voor het aanpassen van de grootte van werkbladen
type: docs
weight: 20
url: /nl/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- voorbeeldafbeelding
- afbeeldingsgrootte aanpassen
- Excel
- werkblad
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Los het OLE‑grootteprobleem van Excel‑werkbladen op in presentaties: twee manieren om objectframes consistent te houden—schaal het frame of het blad—over de PPT‑ en PPTX‑formaten."
---
{{% alert color="info" title="Opmerking" %}}

Het is waargenomen dat Excel-werkbladen die als OLE‑objecten in een PowerPoint‑presentatie zijn ingebed via Aspose‑componenten, na de eerste activatie worden geschaald naar een onbepaalde schaal. Dit gedrag zorgt voor een duidelijk visueel verschil in de presentatie tussen de toestand vóór en na de activatie van het OLE‑object. We hebben dit probleem grondig onderzocht en een oplossing geboden, die in dit artikel wordt behandeld.

{{% /alert %}}

## **Achtergrond**

In het artikel [OLE beheren](/slides/nl/python-java/manage-ole/) legden we uit hoe je een OLE‑frame toevoegt aan een PowerPoint‑presentatie met Aspose.Slides for Python via Java. Om het [probleem met objectvoorvertoning](/slides/nl/python-java/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we een afbeelding van het geselecteerde werkbladgebied toegewezen aan het OLE‑objectframe. In de gegenereerde presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de werkbladafbeelding toont, wordt de Excel‑werkmap geactiveerd. Eindgebruikers kunnen gewenste wijzigingen aanbrengen in de daadwerkelijke Excel‑werkmap en vervolgens terugkeren naar de dia door buiten de geactiveerde Excel‑werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia. De schaalfactor varieert afhankelijk van de afmetingen van het OLE‑objectframe en de ingebedde Excel‑werkmap.

## **Oorzaak van grootteaanpassing**

Omdat de Excel‑werkmap een eigen venstergrootte heeft, probeert deze bij de eerste activatie zijn oorspronkelijke grootte te behouden. Het OLE‑objectframe heeft echter zijn eigen grootte. Volgens Microsoft, wanneer de Excel‑werkmap wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte om de juiste verhoudingen te behouden als onderdeel van het inbedproces. De aanpassing gebeurt op basis van de verschillen tussen de Excel‑venstergrootte en de grootte en positie van het OLE‑objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het effect van grootteaanpassing te voorkomen.

- Schaal de OLE‑framegrootte in de PowerPoint‑presentatie zodat deze overeenkomt met de hoogte en breedte van het gewenste aantal rijen en kolommen in het OLE‑frame.
- Houd de OLE‑framegrootte constant en schaalk de afmetingen van de deelnemende rijen en kolommen zodat ze binnen de gekozen OLE‑framegrootte passen.

### **Schaal de OLE‑framegrootte**

In deze benadering leren we hoe we de OLE‑framegrootte van de ingebedde Excel‑werkmap kunnen instellen zodat deze overeenkomt met de cumulatieve grootte van de deelnemende rijen en kolommen in het Excel‑werkblad.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als een OLE‑frame. In dit scenario wordt de grootte van het OLE‑objectframe eerst berekend op basis van de cumulatieve rijhoogtes en kolombreedtes van de deelnemende rijen en kolommen in de werkmap. Vervolgens stellen we de grootte van het OLE‑frame in op deze berekende waarde. Om het rode “EMBEDDED OLE OBJECT”-bericht voor het OLE‑frame in PowerPoint te vermijden, maken we ook een afbeelding van de gewenste delen van de rijen en kolommen in de werkmap en stellen we deze in als de OLE‑frame‑afbeelding.

```python
import jpype
import asposecells
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpile.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpile.JClass("java.io.ByteArrayOutputStream")


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

    # Stel de weergavegrootte in wanneer de werkmap wordt gebruikt als OLE-object in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Haal de breedte en hoogte van de OLE-afbeelding op in points.
        image_io = jpile.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Gebruik de aangepaste werkmap.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Voeg de OLE-afbeelding toe aan de presentatie-bronnen.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Maak het OLE-objectframe aan.
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

### **Schaal de celbereikgrootte**

In deze benadering leren we hoe we de hoogtes van de deelnemende rijen en de breedtes van de deelnemende kolommen kunnen schalen zodat ze overeenkomen met een aangepaste OLE‑framegrootte.

Stel dat we een sjabloon‑Excel‑blad hebben en dit willen toevoegen aan een presentatie als een OLE‑frame. In dit scenario stellen we de grootte van het OLE‑frame in en schalen we de afmetingen van de rijen en kolommen die deelnemen aan het OLE‑frame‑gebied. Daarna slaan we de werkmap op naar een stream om de wijzigingen toe te passen en converteren we deze naar een byte‑array om toe te voegen aan het OLE‑frame. Om het rode “EMBEDDED OLE OBJECT”-bericht voor het OLE‑frame in PowerPoint te vermijden, maken we ook een afbeelding van de gewenste delen van de rijen en kolommen in de werkmap en stellen we deze in als de OLE‑frame‑afbeelding.

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
    # De verwachte breedte en hoogte van het celbereik zijn in punten.
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

    # Stel de weergavegrootte in wanneer de werkmap wordt gebruikt als OLE-object in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Schaaf het celbereik zodat het in het frame past.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Gebruik de aangepaste werkmap.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Voeg de OLE-afbeelding toe aan de bronnen van de presentatie.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Maak het OLE-objectframe aan.
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

## **Conclusie**

{{% alert color="info" title="Opmerking" %}} 

Er zijn twee benaderingen om het probleem met de grootteaanpassing van het werkblad op te lossen. De keuze voor de juiste benadering hangt af van de specifieke eisen en het gebruiksscenario. Beide benaderingen werken op dezelfde manier, of de presentaties nu worden gemaakt vanuit een sjabloon of vanaf nul. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

{{% /alert %}}

## **Veelgestelde vragen**

**Waarom verandert de grootte van een ingebed Excel‑werkblad bij de eerste activatie in PowerPoint?**

Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te behouden bij activatie, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot grootteaanpassing.

**Is het mogelijk dit formaatprobleem volledig te voorkomen?**

Ja. Door het OLE‑frame aan te passen aan de grootte van het Excel‑celbereik of het celbereik te schalen naar de gewenste OLE‑framegrootte, kun je ongewenste grootteaanpassing voorkomen.

**Welke schalingsmethode moet ik gebruiken, OLE‑frame‑schaling of celbereik‑schaling?**

Kies **OLE‑frame‑schaling** als je de oorspronkelijke Excel‑rij‑ en kolomgroottes wilt behouden. Kies **celbereik‑schaling** als je een vaste grootte voor het OLE‑frame in je presentatie wilt.

**Werken deze oplossingen ook als mijn presentatie gebaseerd is op een sjabloon?**

Ja. Beide oplossingen werken voor presentaties die zijn gemaakt vanuit sjablonen en voor presentaties die vanaf nul zijn opgebouwd.

**Is er een limiet aan de grootte van het OLE‑frame bij gebruik van deze methoden?**

Nee. Je kunt het OLE‑objectframe elke gewenste grootte geven, zolang je de schaal correct instelt.

**Is er een manier om de “EMBEDDED OLE OBJECT”‑plaatsvervangende tekst in PowerPoint te vermijden?**

Ja. Door een snapshot van het gewenste Excel‑celbereik te maken en deze in te stellen als de plaatsvervangende afbeelding van het OLE‑frame, kun je een aangepaste voorbeeldafbeelding weergeven in plaats van de standaard plaatsvervanger.

## **Gerelateerde artikelen**

[Een Excel‑grafiek maken en insluiten in een presentatie als OLE‑object](/slides/nl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)