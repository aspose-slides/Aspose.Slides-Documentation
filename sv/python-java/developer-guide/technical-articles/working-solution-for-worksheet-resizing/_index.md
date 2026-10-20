---
title: Arbetslösning för arbetsbladsstorleksändring
type: docs
weight: 20
url: /sv/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildstorleksändring
- Excel
- arbetsblad
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Fixa OLE‑storleksändring av Excel‑arbetsblad i presentationer: två sätt att hålla objektramarna konsekventa—skala ramen eller bladet—för både PPT‑ och PPTX‑format."
---
{{% alert color="info" title="Obs" %}}

Excel‑arbetsblad inbäddade som OLE‑objekt i en PowerPoint‑presentation med Aspose‑komponenter kan ändra storlek oväntat efter sin första aktivering. Detta beteende skapar en märkbar visuell skillnad mellan OLE‑objektet före och efter aktivering. Denna artikel förklarar problemet och beskriver två sätt att åtgärda det.

{{% /alert %}}

## **Bakgrund**

I artikeln [Hantera OLE](/slides/sv/python-java/manage-ole/) förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides för Python via Java. För att åtgärda [objektförhandsgranskningsproblemet](/slides/sv/python-java/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det valda arbetsbladsområdet till OLE‑objektramen. I den resulterande presentationen, när du dubbelklickar på OLE‑objektramen som visar arbetsbladsbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑objektramen förändras när användaren återvänder till bilden. Förstoringsfaktorn varierar beroende på storleken på OLE‑objektramen och den inbäddade Excel‑arbetsboken.

## **Orsak till storleksändring**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktivering. Å andra sidan har OLE‑objektramen sin egen storlek. Enligt Microsoft, när Excel‑arbetsboken aktiveras, förhandlar Excel och PowerPoint storleken för att säkerställa att den behåller rätt proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel‑fönstrets storlek och OLE‑objektramens storlek och position.

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE‑ramen i PowerPoint‑presentationen så att den matchar den totala höjden och bredden på de markerade raderna och kolumnerna.  
- Håll OLE‑ramens storlek konstant och skala de markerade raderna och kolumnerna så att de får plats i den.

### **Skala OLE‑ramens storlek**

Detta tillvägagångssätt sätter OLE‑ramens storlek så att den matchar den totala höjden och bredden på de markerade raderna och kolumnerna i det inbäddade Excel‑arbetsbladet.

Exemplet laddar en befintlig Excel‑arbetsbok och väljer de första 10 raderna och 13 kolumnerna i dess första arbetsblad med nollbaserade index. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definierar det visade intervallet. Förhandsgranskningen renderas med 96 DPI, och dess pixeldimensioner omvandlas till punkter med 72 punkter per tum. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) bäddar in den modifierade arbetsboken i en ram med dessa mått. Förhandsgranskningen tilldelas via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) för att ersätta platshållaren "EMBEDDED OLE OBJECT" i den sparade presentationen.

Förhandsgranskningshjälparen ställer in [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) till det valda intervallet och tar bort marginaler, sidhuvuden och sidfötter. Med [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) aktiverat renderar [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) intervallet som en PNG‑bild. Hjälparen returnerar en ny inmatningsström som innehåller PNG‑bilden, placerad i början för användning i presentationen.

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

    # Ställ in den visade storleken när arbetsboken används som ett OLE‑objekt i PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Hämta bredd och höjd på OLE‑bilden i punkter.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Använd den modifierade arbetsboken.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Lägg till OLE‑bilden i presentationens resurser.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Skapa OLE‑objektramen.
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

### **Skala cellområdess storlek**

Detta tillvägagångssätt skalar höjderna på de markerade raderna och breddarna på de markerade kolumnerna så att de matchar en anpassad OLE‑ramstorlek.

Exemplet laddar en befintlig Excel‑arbetsbok och väljer de första 10 raderna och 13 kolumnerna i dess första arbetsblad med nollbaserade index. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definierar det visade intervallet, och hjälpen `scale_cell_range` skalar detta intervall för att passa en ram som är 400 punkter bred och 100 punkter hög. Efter att den modifierade arbetsboken sparats till en ström, bäddar [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) in den med den angivna storleken. En förhandsgranskning renderad med 96 DPI tilldelas via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), så den sparade presentationen visar de valda cellerna istället för standardplatshållaren.

Skalningshjälpen beräknar separata bredd‑ och höjdratioer för det valda intervallet, vilket bevarar de relativa breddarna på kolumnerna och de relativa höjderna på raderna. Den omvandlar de beräknade dimensionerna från punkter till tum innan de appliceras med [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) och [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch). Det valda intervallet måste ha icke‑noll bredd och höjd.

Denna förhandsgranskningshjälp renderar det ändrade intervallet med [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). Den begränsar [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) till det intervallet, tar bort marginaler, sidhuvuden och sidfötter samt returnerar en PNG‑ström placerad i början.

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
    # Den förväntade bredden och höjden på cellområdet är i punkter.
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

    # Ställ in den visade storleken när arbetsboken används som ett OLE‑objekt i PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Skala cellområdet så att det passar ramens storlek.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Använd den modifierade arbetsboken.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Lägg till OLE‑bilden i presentationens resurser.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Skapa OLE‑objektramen.
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

## **Slutsats**

{{% alert color="info" title="Obs" %}} 

Det finns två tillvägagångssätt för att lösa problemet med arbetsbladsstorleksändring. Välj det tillvägagångssätt som bäst passar dina krav och ditt användningsfall. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen gräns för storleken på OLE‑objektramen i denna lösning.

{{% /alert %}}

## **FAQ**

**Varför ändras storleken på ett inbäddat Excel‑kalkylblad när det aktiveras för första gången i PowerPoint?**

Detta sker eftersom Excel försöker behålla det ursprungliga fönsterstorleken vid aktivering, medan OLE‑objektramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att hålla bildförhållandet, vilket kan leda till storleksändring.

**Är det möjligt att helt förhindra detta storleksändringsproblem?**

Ja. Genom att skala OLE‑ramen så att den passar Excel‑cellområdets storlek eller genom att skala cellområdet så att det passar önskad OLE‑ramstorlek kan du förhindra oönskad storleksändring.

**Vilken skalningsmetod bör jag använda, OLE‑ramskalning eller cellområdesskalning?**

Välj **OLE‑ramskalning** om du vill behålla de ursprungliga Excel‑rad‑ och kolumnstorlekarna. Välj **cellområdesskalning** om du vill ha en fast storlek på OLE‑ramen i din presentation.

**Fungerar dessa lösningar om min presentation är baserad på en mall?**

Ja. Båda lösningarna fungerar för presentationer som skapats från mallar och från grunden.

**Finns det någon gräns för OLE‑ramens storlek när man använder dessa metoder?**

Nej. Du kan göra OLE‑objektramen vilken storlek som helst så länge du anger skalan på rätt sätt.

**Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?**

Ja. Genom att ta ett ögonblicksbild av det önskade Excel‑cellområdet och använda den som OLE‑ramens platshållarbild kan du visa en anpassad förhandsgranskningsbild i stället för standardplatshållaren.

## **Relaterade artiklar**

[Skapa ett Excel‑diagram och bädda in det i en presentation som ett OLE‑objekt](/slides/sv/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Uppdatera OLE‑objekt automatiskt med ett MS PowerPoint‑tillägg](/slides/sv/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)