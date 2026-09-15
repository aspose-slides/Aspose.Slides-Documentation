---
title: Lösning för att förhindra arbetsbladsstorleksändring
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
description: "Fixa Excel‑arbetsblads OLE‑storleksändring i presentationer: två sätt att hålla objektramarna konsekventa—skala ramen eller bladet—i PPT‑ och PPTX‑format."
---
{{% alert color="info" title="Obs" %}}

Det har observerats att Excel‑arbetsblad som bäddas in som OLE‑objekt i en PowerPoint‑presentation via Aspose‑komponenter ändras till en ospecificerad skala efter den första aktiveringen. Detta beteende skapar en märkbar visuell skillnad i presentationen mellan OLE‑objektets tillstånd före och efter aktivering. Vi har undersökt detta problem i detalj och tillhandahåller en lösning, som behandlas i den här artikeln.

{{% /alert %}}

## **Bakgrund**

I artikeln [Hantera OLE](/slides/sv/python-java/manage-ole/) förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides för Python via Java. För att åtgärda [objektförhandsgranskningsproblemet](/slides/sv/python-java/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det valda arbetsbladsområdet till OLE‑objektets ram. I den genererade presentationen, när du dubbelklickar på OLE‑objektramen som visar arbetsbladsbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑objektramen kommer att ändras när användaren återvänder till bilden. Storleksändringsfaktorn varierar beroende på storleken på OLE‑objektramen och den inbäddade Excel‑arbetsboken.

## **Orsak till storleksändring**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE‑objektramen sin egen storlek. Enligt Microsoft, när Excel‑arbetsboken aktiveras, förhandlar Excel och PowerPoint om storleken för att säkerställa att den behåller korrekta proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel‑fönstrets storlek och OLE‑objektrammens storlek och position.

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE‑ramens storlek i PowerPoint‑presentationen så att den matchar höjden och bredden för önskat antal rader och kolumner i OLE‑ramen.
- Behåll OLE‑ramens storlek konstant och skala storleken på de medverkande raderna och kolumnerna så att de passar inom den valda OLE‑ramens storlek.

### **Skala OLE‑ramens storlek**

I detta tillvägagångssätt kommer vi att lära oss hur man sätter OLE‑ramens storlek för den inbäddade Excel‑arbetsboken så att den matchar den kumulativa storleken på de medverkande raderna och kolumnerna i Excel‑arbetsbladet.

Anta att vi har ett mall‑Excel‑ark och vill lägga till det i en presentation som en OLE‑ram. I detta scenario beräknas storleken på OLE‑objektramen först baserat på de kumulativa radhöjderna och kolumnbreddarna för de medverkande raderna och kolumnerna i arbetsboken. Därefter sätter vi OLE‑ramens storlek till detta beräknade värde. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint kommer vi också att fånga en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE‑ramens bild.

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

    # Ange den visade storleken när arbetsboken används som ett OLE‑objekt i PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Hämta bredden och höjden på OLE‑bilden i punkter.
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

### **Skala cellområdets storlek**

I detta tillvägagångssätt kommer vi att lära oss hur man skalar höjderna på de medverkande raderna och bredden på de medverkande kolumnerna för att matcha en anpassad OLE‑ramstorlek.

Anta att vi har ett mall‑Excel‑ark och vill lägga till det i en presentation som en OLE‑ram. I detta scenario kommer vi att sätta OLE‑ramens storlek och skala storleken på de rader och kolumner som deltar i OLE‑ramens område. Vi sparar sedan arbetsboken till en ström för att tillämpa ändringarna och konverterar den till en byte‑array för att lägga till den i OLE‑ramen. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint kommer vi också att fånga en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använda den som OLE‑ramens bild.

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

    # Ange den visade storleken när arbetsboken används som ett OLE‑objekt i PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Skala cellområdet för att passa ramens storlek.
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

Det finns två tillvägagångssätt för att åtgärda problemet med att arbetsbladet ändrar storlek. Valet av lämpligt tillvägagångssätt beror på de specifika kraven och användningsfallet. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen begränsning för OLE‑objektets ramstorlek i denna lösning.

{{% /alert %}}

## **Vanliga frågor**

**Varför ändrar ett inbäddat Excel‑arbetsblad storlek när det aktiveras för första gången i PowerPoint?**

Detta händer eftersom Excel försöker behålla det ursprungliga fönsterstorleken vid aktivering, medan OLE‑objektramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att behålla bildförhållandet, vilket kan orsaka storleksändring.

**Är det möjligt att helt förhindra detta storleksändringsproblem?**

Ja. Genom att skala OLE‑ramen för att passa Excel‑cellområdets storlek eller skala cellområdet för att passa den önskade OLE‑ramen kan du förhindra oönskad storleksändring.

**Vilken skaleringsmetod bör jag använda, OLE‑ramskalning eller cellområdesskalning?**

Välj **OLE‑ramskalning** om du vill behålla de ursprungliga Excel‑rad‑ och kolumnstorlekarna. Välj **cellområdesskalning** om du vill ha en fast storlek på OLE‑ramen i din presentation.

**Fungerar dessa lösningar om min presentation är baserad på en mall?**

Ja. Båda lösningarna fungerar för presentationer som skapats från mallar och från grunden.

**Finns det någon begränsning för OLE‑ramens storlek när man använder dessa metoder?**

Nej. Du kan göra OLE‑objektramen i vilken storlek som helst så länge du sätter skalan på rätt sätt.

**Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?**

Ja. Genom att ta en bild av mål‑Excel‑cellområdet och använda den som OLE‑ramens platshållarbilder, kan du visa en anpassad förhandsgranskningsbild i stället för standardplatshållaren.

## **Relaterade artiklar**

[Skapa ett Excel‑diagram och bädda in det i en presentation som ett OLE‑objekt](/slides/sv/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)