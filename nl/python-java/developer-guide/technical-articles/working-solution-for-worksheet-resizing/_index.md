---
title: Werkende oplossing voor werkbladgrootteschaling
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
description: "Los het OLE-grootteprobleem van Excel-werkbladen in presentaties op: twee manieren om objectframes consistent te houden—schaal het frame of het blad—over de PPT- en PPTX-formaten."
---
{{% alert color="info" title="Note" %}}

Excel‑werkbladen die als OLE‑objecten in een PowerPoint‑presentatie zijn ingebed met behulp van Aspose‑componenten, kunnen onverwacht van grootte veranderen na hun eerste activering. Dit gedrag creëert een opvallend visueel verschil tussen het OLE‑object vóór en na activering. Dit artikel legt het probleem uit en beschrijft twee manieren om het op te lossen.

{{% /alert %}}

## **Achtergrond**

In het artikel [Beheer OLE](/slides/nl/python-java/manage-ole/), legden we uit hoe je een OLE‑frame toevoegt aan een PowerPoint‑presentatie met behulp van Aspose.Slides for Python via Java. Om het [probleem met voorbeeldweergave van object](/slides/nl/python-java/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we een afbeelding van het geselecteerde werkbladgebied toegewezen aan het OLE‑objectframe. In de gegenereerde presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de werkbladafbeelding toont, wordt het Excel‑werkboek geactiveerd. Eindgebruikers kunnen naar wens wijzigingen aanbrengen in het daadwerkelijke Excel‑werkboek en vervolgens naar de dia terugkeren door buiten het geactiveerde Excel‑werkboek te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia. De factor waarmee de grootte verandert varieert afhankelijk van de grootte van het OLE‑objectframe en het ingebedde Excel‑werkboek.

## **Oorzaak van de grootteverandering**

Aangezien het Excel‑werkboek zijn eigen venstergrootte heeft, probeert het bij de eerste activering zijn oorspronkelijke grootte te behouden. Het OLE‑objectframe heeft daarentegen zijn eigen afmetingen. Volgens Microsoft onderhandelen Excel en PowerPoint over de grootte wanneer het Excel‑werkboek wordt geactiveerd, om ervoor te zorgen dat de juiste verhoudingen behouden blijven als onderdeel van het insluitingsproces. De grootteverandering treedt op op basis van de verschillen tussen de Excel‑venstergrootte en de afmetingen en positie van het OLE‑objectframe.

## **Werkende oplossing**

Er zijn twee mogelijke oplossingen om het grootte‑veranderingseffect te voorkomen.

- Schaal het OLE‑frame in de PowerPoint‑presentatie zodat het overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen.
- Houd de grootte van het OLE‑frame constant en schaald de geselecteerde rijen en kolommen zodat ze erin passen.

### **Schaal de grootte van het OLE-frame**

Deze aanpak stelt de grootte van het OLE-frame in zodat deze overeenkomt met de totale hoogte en breedte van de geselecteerde rijen en kolommen in het ingebedde Excel‑werkblad.

Het voorbeeld laadt een bestaand Excel‑werkboek en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met behulp van indexen op basis van nul. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definieert het weergegeven bereik. De voorbeeldweergave wordt gerenderd op 96 DPI, en de pixelafmetingen worden omgezet naar punten met 72 punten per inch. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) embed het aangepaste werkboek in een frame met die afmetingen. De voorbeeldweergave wordt toegewezen via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) om de plaatshouder "EMBEDDED OLE OBJECT" in de opgeslagen presentatie te vervangen.

De preview‑helper stelt [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) in op het geselecteerde bereik en verwijdert marges, kopteksten en voetteksten. Met [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) ingeschakeld rendert [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) het bereik als een PNG‑afbeelding. De helper geeft een nieuwe input‑stream terug die de PNG‑afbeelding bevat, gepositioneerd aan het begin voor gebruik in de presentatie.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpage.JClass("java.io.ByteArrayInputStream")
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

    # Stel de weergegeven grootte in wanneer het werkboek wordt gebruikt als OLE-object in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Haal de breedte en hoogte van de OLE-afbeelding op in punten.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Gebruik het aangepaste werkboek.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Voeg de OLE-afbeelding toe aan de presentatieresources.
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

### **Schaal de grootte van het celbereik**

Deze aanpak schaalt de hoogtes van de geselecteerde rijen en de breedtes van de geselecteerde kolommen zodat ze passen bij een aangepast OLE‑frame.

Het voorbeeld laadt een bestaand Excel‑werkboek en selecteert de eerste 10 rijen en 13 kolommen van het eerste werkblad met behulp van indexen op basis van nul. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definieert het weergegeven bereik, en de scale_cell_range‑helper schaalt dat bereik zodat het past in een frame van 400 punten breed en 100 punten hoog. Na het opslaan van het aangepaste werkboek naar een stream, embedt [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) het op de opgegeven grootte. Een preview die wordt gerenderd op 96 DPI wordt toegewezen via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), zodat de opgeslagen presentatie de geselecteerde cellen weergeeft in plaats van de standaardplaatshouder.

De schalings‑helper berekent afzonderlijke breedte‑ en hoogte‑ratio's voor het geselecteerde bereik, waarbij de relatieve breedtes van de kolommen en de relatieve hoogtes van de rijen behouden blijven. De berekende afmetingen worden van punten naar inches geconverteerd voordat ze worden toegepast met [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) en [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch). Het geselecteerde bereik moet een niet‑nul breedte en hoogte hebben.

Deze preview‑helper rendert het vergrote bereik met behulp van [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). Hij beperkt [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) tot dat bereik, verwijdert marges, kopteksten en voetteksten, en geeft een PNG‑stream terug die aan het begin is gepositioneerd.

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

    # Stel de weergegeven grootte in wanneer het werkboek wordt gebruikt als OLE-object in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Schaam het celbereik zodat het in de framegrootte past.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Gebruik het aangepaste werkboek.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Voeg de OLE-afbeelding toe aan de presentatieresources.
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

{{% alert color="info" title="Note" %}} 

Er zijn twee benaderingen om het probleem met het wijzigen van de grootte van het werkblad op te lossen. Kies de benadering die het beste past bij uw eisen en gebruikssituatie. Beide benaderingen werken op dezelfde manier, of de presentaties nu vanaf een sjabloon of helemaal vanaf nul worden gemaakt. Bovendien is er geen limiet aan de grootte van het OLE‑objectframe in deze oplossing.

{{% /alert %}}

## **Veelgestelde vragen**

**Waarom verandert een ingebed Excel‑werkblad van grootte bij de eerste activering in PowerPoint?**

Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te behouden bij activatie, terwijl het OLE‑objectframe in PowerPoint zijn eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat de grootteverandering kan veroorzaken.

**Is het mogelijk om dit grootteveranderingsprobleem volledig te voorkomen?**

Ja. Door het OLE‑frame te schalen zodat het past bij de grootte van het Excel‑celbereik, of door het celbereik te schalen zodat het past bij de gewenste OLE‑framegrootte, kun je ongewenste grootteveranderingen voorkomen.

**Welke schaalsmethode moet ik gebruiken, OLE‑frame schalen of celbereik schalen?**

Select **OLE-frame schalen** if you want to maintain the original Excel row and column sizes. Select **celbereik schalen** if you want a fixed size for the OLE frame in your presentation.

**Werken deze oplossingen als mijn presentatie gebaseerd is op een sjabloon?**

Ja. Beide oplossingen werken voor presentaties die zijn gemaakt op basis van sjablonen en voor presentaties die vanaf nul zijn gemaakt.

**Is er een limiet aan de grootte van het OLE‑frame bij het gebruik van deze methoden?**

Nee. Je kunt het OLE‑objectframe elke gewenste grootte geven, zolang je de schaal correct instelt.

**Is er een manier om de "EMBEDDED OLE OBJECT" plaatshoudertekst in PowerPoint te vermijden?**

Ja. Door een momentopname te maken van het gewenste Excel‑celbereik en deze in te stellen als de plaatshouderafbeelding van het OLE‑frame, kun je een aangepaste preview‑afbeelding tonen in plaats van de standaardplaatshouder.

## **Gerelateerde artikelen**

[Een Excel‑grafiek maken en insluiten in een presentatie als OLE‑object](/slides/nl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑objecten automatisch bijwerken met een MS PowerPoint‑add‑in](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)