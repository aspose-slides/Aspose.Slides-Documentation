---
title: Fungerande lösning för arbetsbladsstorleksändring
type: docs
weight: 40
url: /sv/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildstorleksändring
- Excel
- arbetsblad
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lös OLE-storleksändring av Excel-arbetsblad i presentationer: två sätt att hålla objektramarna konsekventa - skala ramen eller bladet - över PPT- och PPTX-formaten."
---
{{% alert color="info" title="Note" %}}
Excel‑ark som är inbäddade som OLE‑objekt i en PowerPoint‑presentation med Aspose‑komponenter kan ändra storlek oväntat efter sin första aktivering. Detta beteende skapar en märkbart visuell skillnad mellan OLE‑objektet före och efter aktivering. Denna artikel förklarar problemet och beskriver två sätt att åtgärda det.
{{% /alert %}} 

## **Bakgrund**

I artikeln [Hantera OLE](/slides/sv/python-net/manage-ole/), förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides för Python via .NET. För att åtgärda [objektförhandsgranskningsproblemet](/slides/sv/python-net/object-preview-issue-when-adding-oleobjectframe/), tilldelade vi en bild av det valda arbetsbladsområdet till OLE‑objektramen. I den resulterande presentationen, när du dubbelklickar på OLE‑objektramen som visar arbetsbladsbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑objektramen ändras när användaren återvänder till bilden. Förstoringsfaktorn varierar beroende på storleken av OLE‑objektramen och den inbäddade Excel‑arbetsboken. 

## **Orsak till storleksändring**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE‑objektramen sin egen storlek. Enligt Microsoft förhandlar Excel och PowerPoint om storleken när Excel‑arbetsboken aktiveras för att säkerställa att den behåller korrekta proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel‑fönstrets storlek och OLE‑ramens storlek och position. 

## **Fungerande lösning**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE‑ramen i PowerPoint‑presentationen så att den matchar den totala höjden och bredden på de valda raderna och kolumnerna.
- Behåll OLE‑ramens storlek konstant och skala de valda raderna och kolumnerna så att de får plats i den.

### **Skala OLE‑ramens storlek**

Detta tillvägagångssätt sätter OLE‑ramens storlek så att den matchar den totala höjden och bredden på de valda raderna och kolumnerna i det inbäddade Excel‑arbetsbladet.

Exemplet laddar en befintlig Excel‑arbetsbok och väljer de första 10 raderna och 13 kolumnerna i dess första arbetsblad med nollbaserade index. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definierar det visade intervallet. Förhandsgranskningen renderas med 96 DPI och dess pixeldimensioner konverteras till punkter med 72 punkter per tum. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) bäddar in den modifierade arbetsboken i en ram med dessa dimensioner. Förhandsgranskningen tilldelas via [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) för att ersätta platshållaren "EMBEDDED OLE OBJECT" i den sparade presentationen.

Förhandsgranskningshjälpen sätter [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) till det valda intervallet och tar bort marginaler, sidhuvuden och sidfötter. Med [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) aktiverat renderar [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) intervallet som en PNG‑bild. Hjälpen spolar tillbaka bildströmmen innan den returneras för användning i presentationen.

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

Det fullständiga exemplet nedan kombinerar hjälpfunktionerna med arbetsbäddning och sparar presentationen som `output.pptx`.

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

    # Ställ in den visade storleken när arbetsboksfilen används som ett OLE-objekt i PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Hämta bredden och höjden på OLE-bilden i punkter.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Vi måste använda den modifierade arbetsboken.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Lägg till OLE-bilden i presentationens resurser.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Skapa OLE-objektramen.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Skala cellintervallens storlek**

Detta tillvägagångssätt skalar höjderna på de valda raderna och bredden på de valda kolumnerna för att matcha en anpassad OLE‑ramstorlek.

Exemplet laddar en befintlig Excel‑arbetsbok och väljer de första 10 raderna och 13 kolumnerna i dess första arbetsblad med nollbaserade index. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definierar det visade intervallet, och hjälpen nedan skalar det intervallet för att passa en ram som är 400 punkter bred och 100 punkter hög. Efter att den modifierade arbetsboken sparats till en ström bäddar [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) in den med den angivna storleken. En förhandsgranskning renderad med 96 DPI tilldelas via [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), så den sparade presentationen visar de valda cellerna istället för standardplatshållaren.

Skaleringshjälpen beräknar separata bredd‑ och höjdratioer för det valda intervallet, och behåller de relativa bredden på dess kolumner samt de relativa höjderna på dess rader. Den konverterar de beräknade dimensionerna från punkter till tum innan de appliceras med [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) och [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). Det valda intervallet måste ha en bredd och höjd som är skilda från noll.

```py
import aspose.cells as cells

# <param name="width">Den förväntade bredden på cellintervallet i punkter.</param>
# <param name="height">Den förväntade höjden på cellintervallet i punkter.</param>
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

Denna förhandsgranskningshjälp renderar det omförändrade intervallet med [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Den begränsar [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) till det intervallet, tar bort marginaler, sidhuvuden och sidfötter, och returnerar en PNG‑ström placerad i början.

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

Det fullständiga exemplet nedan kombinerar hjälpfunktionerna med arbetsbäddning och sparar presentationen som `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">Den förväntade bredden på cellintervallet i punkter.</param>
# <param name="height">Den förväntade höjden på cellintervallet i punkter.</param>
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

    # Ställ in den visade storleken när arbetsboksfilen används som ett OLE-objekt i PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Skala cellintervallet för att passa ramens storlek.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Vi måste använda den modifierade arbetsboken.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Lägg till OLE-bilden i presentationens resurser.
            ole_image = presentation.images.add_image(image_stream)

            # Skapa OLE-objektramen.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Slutsats**

{{% alert color="info" title="Note" %}}
Det finns två tillvägagångssätt för att lösa problemet med arbetsbladsstorleksändring. Välj det tillvägagångssätt som bäst passar dina krav och ditt användningsfall. Båda tillvägagångssätten fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen gräns för storleken på OLE‑objektramen i den här lösningen.
{{% /alert %}}

## **Vanliga frågor**

**Varför ändrar ett inbäddat Excel‑arbetsblad storlek när det aktiveras för första gången i PowerPoint?**

Detta händer eftersom Excel försöker behålla den ursprungliga fönsterstorleken vid aktivering, medan OLE‑objektramen i PowerPoint har sina egna dimensioner. PowerPoint och Excel förhandlar om storleken för att bibehålla bildförhållandet, vilket kan orsaka storleksändringen.

**Kan man helt undvika detta storleksändringsproblem?**

Ja. Genom att skala OLE‑ramen så att den passar Excel‑cellintervallens storlek eller skala cellintervallet så att det passar den önskade OLE‑ramstorleken kan du förhindra oönskad storleksändring.

**Vilken skalningsmetod bör jag använda, OLE‑ramskala eller cellintervallskala?**

Välj **OLE frame scaling** om du vill behålla de ursprungliga Excel‑rad- och kolumnstorlekarna. Välj **cell range scaling** om du vill ha en fast storlek på OLE‑ramen i din presentation.

**Fungerar dessa lösningar om min presentation är baserad på en mall?**

Ja. Båda lösningarna fungerar för presentationer skapade från mallar och från grunden.

**Finns det någon gräns för storleken på OLE‑ramen när man använder dessa metoder?**

Nej. Du kan göra OLE‑objektramen i vilken storlek som helst så länge du ställer in skalan på rätt sätt.

**Finns det ett sätt att undvika platshållartexten "EMBEDDED OLE OBJECT" i PowerPoint?**

Ja. Genom att ta en skärmdump av mål‑Excel‑cellintervallet och sätta den som OLE‑ramens platshållarbild kan du visa en anpassad förhandsgranskningsbild i stället för standardplatshållaren.