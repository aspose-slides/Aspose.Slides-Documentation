---
title: Arbetslösning för storleksändring av arbetsblad
type: docs
weight: 40
url: /sv/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- förhandsgranskningsbild
- bildskalning
- Excel
- arbetsblad
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Åtgärda OLE‑storleksändring av Excel‑arbetsblad i presentationer: två sätt att hålla objekt‑ramarna konsekventa—skala ramen eller bladet—över PPT‑ och PPTX‑formaten."
---
{{% alert color="primary" %}} 

Det har observerats att Excel‑arbetsblad inbäddade som OLE‑objekt i en PowerPoint‑presentation via Aspose‑komponenter ändrar storlek till en okänd skala efter den första aktiveringen. Detta beteende skapar en märkbar visuell skillnad i presentationen mellan OLE‑objektets tillstånd före och efter aktivering. Vi har undersökt problemet i detalj och tillhandahåller en lösning, som beskrivs i den här artikeln.

{{% /alert %}} 

## **Background**

I artikeln [Manage OLE](/slides/sv/python-net/manage-ole/) förklarade vi hur man lägger till en OLE‑ram i en PowerPoint‑presentation med Aspose.Slides for Python via .NET. För att åtgärda [object preview issue](/slides/sv/python-net/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi en bild av det markerade arbetsbladsområdet till OLE‑objektramen. I den resulterande presentationen, när du dubbelklickar på OLE‑objektramen som visar arbetsbladsbilden, aktiveras Excel‑arbetsboken. Slutanvändare kan göra önskade ändringar i den faktiska Excel‑arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade Excel‑arbetsboken. Storleken på OLE‑objektramen ändras när användaren återvänder till bilden. Skalningsfaktorn varierar beroende på storleken på OLE‑objektramen och den inbäddade Excel‑arbetsboken. 

## **Cause of Resizing**

Eftersom Excel‑arbetsboken har sin egen fönsterstorlek försöker den behålla sin ursprungliga storlek vid första aktiveringen. Å andra sidan har OLE‑objektramen sin egen storlek. Enligt Microsoft, när Excel‑arbetsboken aktiveras, förhandlar Excel och PowerPoint om storleken för att säkerställa att den behåller korrekta proportioner som en del av inbäddningsprocessen. Storleksändringen sker baserat på skillnaderna mellan Excel‑fönstrets storlek och OLE‑objektramens storlek och position.

## **Working Solution**

Det finns två möjliga lösningar för att undvika storleksändringseffekten.

- Skala OLE‑ramens storlek i PowerPoint‑presentationen så att den matchar höjden och bredden för det önskade antalet rader och kolumner i OLE‑ramen.
- Håll OLE‑ramens storlek konstant och skala storleken på de medverkande raderna och kolumnerna så att de får plats inom den valda OLE‑ramstorleken.

### **Scale the OLE Frame Size**

I detta tillvägagångssätt lär vi oss hur man ställer in OLE‑ramens storlek för det inbäddade Excel‑arbetsbladet så att den matchar den kumulativa storleken av de medverkande raderna och kolumnerna i Excel‑arbetsbladet.

Anta att vi har ett mall‑Excel‑blad och vill lägga till det i en presentation som en OLE‑ram. I detta scenario beräknas storleken på OLE‑objektramen först baserat på de kumulativa radhöjderna och kolumnbredderna för de medverkande raderna och kolumnerna i arbetsboken. Därefter ställer vi in OLE‑ramens storlek till detta beräknade värde. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint, fångar vi också en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använder den som OLE‑ramens bild.

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

    # Ställ in den visade storleken när arbetsboksfilen används som ett OLE‑objekt i PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Hämta bredden och höjden på OLE‑bilden i punkter.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Vi måste använda den modifierade arbetsboken.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Lägg till OLE‑bilden i presentationens resurser.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Skapa OLE‑objektramen.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Scale the Cell Range Size**

I detta tillvägagångssätt lär vi oss hur man skalar höjderna på de medverkande raderna och bredden på de medverkande kolumnerna så att de matchar en anpassad OLE‑ramstorlek.

Anta att vi har ett mall‑Excel‑blad och vill lägga till det i en presentation som en OLE‑ram. I detta scenario ställer vi in OLE‑ramens storlek och skalar storleken på de rader och kolumner som deltar i OLE‑ramens område. Vi sparar sedan arbetsboken till en ström för att tillämpa ändringarna och konverterar den till en byte‑array för att lägga till den i OLE‑ramen. För att undvika det röda meddelandet "EMBEDDED OLE OBJECT" för OLE‑ramen i PowerPoint, fångar vi också en bild av de önskade delarna av raderna och kolumnerna i arbetsboken och använder den som OLE‑ramens bild.

```py
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

    # Ställ in den visade storleken när arbetsboksfilen används som ett OLE‑objekt i PowerPoint.
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

            # Lägg till OLE‑bilden i presentationens resurser.
            ole_image = presentation.images.add_image(image_stream)

            # Skapa OLE‑objektramen.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Conclusion**

{{% alert color="primary" %}}

Det finns två tillvägagångssätt för att åtgärda problemet med arbetsbladsstorlekens förändring. Valet av lämpligt tillvägagångssätt beror på specifika krav och användningsscenario. Båda metoderna fungerar på samma sätt, oavsett om presentationerna skapas från en mall eller från grunden. Dessutom finns det ingen gräns för storleken på OLE‑objektramen i denna lösning.

{{% /alert %}}