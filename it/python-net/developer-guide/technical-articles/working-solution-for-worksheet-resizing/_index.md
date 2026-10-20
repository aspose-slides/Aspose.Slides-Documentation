---
title: Soluzione funzionante per il ridimensionamento del foglio di lavoro
type: docs
weight: 40
url: /it/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- immagine di anteprima
- ridimensionamento immagine
- Excel
- foglio di lavoro
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Correggi il ridimensionamento OLE del foglio di lavoro Excel nelle presentazioni: due modi per mantenere i frame degli oggetti coerenti—scala il frame o il foglio—nei formati PPT e PPTX."
---
{{% alert color="info" title="Nota" %}}
I fogli di lavoro di Excel incorporati come oggetti OLE in una presentazione PowerPoint utilizzando componenti Aspose possono ridimensionarsi in modo inaspettato dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente tra l'oggetto OLE prima e dopo l'attivazione. Questo articolo spiega il problema e descrive due modi per affrontarlo.
{{% /alert %}} 

## **Contesto**

Nell'articolo [Gestisci OLE](/slides/it/python-net/manage-ole/), abbiamo spiegato come aggiungere un frame OLE a una presentazione PowerPoint utilizzando Aspose.Slides per Python via .NET. Per affrontare il [problema di anteprima dell'oggetto](/slides/it/python-net/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al frame dell'oggetto OLE. Nella presentazione di output, quando si fa doppio clic sul frame OLE che mostra l'immagine del foglio, la cartella di lavoro di Excel viene attivata. Gli utenti finali possono apportare qualsiasi modifica desiderata alla cartella di lavoro di Excel reale e poi tornare alla diapositiva facendo clic al di fuori della cartella di lavoro Excel attivata. La dimensione del frame OLE cambierà quando l'utente tornerà alla diapositiva. Il fattore di ridimensionamento varierà a seconda delle dimensioni del frame OLE e della cartella di lavoro di Excel incorporata.

## **Causa del ridimensionamento**

Poiché la cartella di lavoro di Excel ha una propria dimensione della finestra, cerca di mantenere le sue dimensioni originali al primo avvio. D'altra parte, il frame dell'oggetto OLE ha le proprie dimensioni. Secondo Microsoft, quando la cartella di lavoro di Excel è attivata, Excel e PowerPoint negoziano la dimensione per garantire che mantenga le proporzioni corrette come parte del processo di incorporamento. Il ridimensionamento avviene in base alle differenze tra la dimensione della finestra di Excel e le dimensioni e la posizione del frame dell'oggetto OLE.

## **Soluzione funzionante**

Esistono due soluzioni possibili per evitare l'effetto di ridimensionamento.

- Scala il frame OLE nella presentazione PowerPoint per corrispondere all'altezza e alla larghezza totale delle righe e colonne selezionate.
- Mantieni costante la dimensione del frame OLE e scala le righe e colonne selezionate per adattarle al suo interno.

### **Scala la dimensione del frame OLE**

Questo approccio imposta la dimensione del frame OLE per corrispondere all'altezza e alla larghezza totale delle righe e colonne selezionate nel foglio di lavoro Excel incorporato.

L'esempio carica una cartella di lavoro Excel esistente e seleziona le prime 10 righe e 13 colonne del suo primo foglio di lavoro usando indici a base zero. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definisce l'intervallo visualizzato. L'anteprima è renderizzata a 96 DPI e le sue dimensioni in pixel vengono convertite in punti usando 72 punti per pollice. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) incorpora la cartella di lavoro modificata in un frame con quelle dimensioni. L'anteprima è assegnata tramite [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) per sostituire il segnaposto "EMBEDDED OLE OBJECT" nella presentazione salvata.

L'helper di anteprima imposta [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) sull'intervallo selezionato e rimuove margini, intestazioni e piè di pagina. Con [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) abilitato, [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) rende l'intervallo come immagine PNG. L'helper riavvolge lo stream dell'immagine prima di restituirlo per l'uso nella presentazione.

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

L'esempio completo di seguito combina gli helper con l'incorporamento della cartella di lavoro e salva la presentazione come `output.pptx`.

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

    # Imposta la dimensione visualizzata quando il file della cartella di lavoro è usato come oggetto OLE in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Ottieni la larghezza e l'altezza dell'immagine OLE in punti.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # È necessario utilizzare la cartella di lavoro modificata.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Aggiungi l'immagine OLE alle risorse della presentazione.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Crea il frame dell'oggetto OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Scala la dimensione dell'intervallo di celle**

Questo approccio scala le altezze delle righe selezionate e le larghezze delle colonne selezionate per corrispondere a una dimensione personalizzata del frame OLE.

L'esempio carica una cartella di lavoro Excel esistente e seleziona le prime 10 righe e 13 colonne del suo primo foglio di lavoro usando indici a base zero. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definisce l'intervallo visualizzato, e l'helper sottostante scala quell'intervallo per adattarlo a un frame largo 400 punti e alto 100 punti. Dopo aver salvato la cartella di lavoro modificata in uno stream, [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) la incorpora nella dimensione specificata. Un'anteprima renderizzata a 96 DPI è assegnata tramite [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), così la presentazione salvata visualizza le celle selezionate invece del segnaposto predefinito.

L'helper di scaling calcola rapporti di larghezza e altezza separati per l'intervallo selezionato, preservando le larghezze relative delle colonne e le altezze relative delle righe. Converte le dimensioni calcolate da punti a pollici prima di applicarle con [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) e [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). L'intervallo selezionato deve avere larghezza e altezza diverse da zero.

```py
import aspose.cells as cells

# <param name="width">Larghezza prevista dell'intervallo di celle in punti.</param>
# <param name="height">Altezza prevista dell'intervallo di celle in punti.</param>
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

Questo helper di anteprima renderizza l'intervallo ridimensionato usando [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Limita [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) a quell'intervallo, rimuove margini, intestazioni e piè di pagina, e restituisce uno stream PNG posizionato all'inizio.

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

L'esempio completo di seguito combina gli helper con l'incorporamento della cartella di lavoro e salva la presentazione come `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">Larghezza prevista dell'intervallo di celle in punti.</param>
# <param name="height">Altezza prevista dell'intervallo di celle in punti.</param>
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

    # Imposta la dimensione visualizzata quando il file della cartella di lavoro è usato come oggetto OLE in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Scala l'intervallo di celle per adattarlo alla dimensione del frame.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # È necessario utilizzare la cartella di lavoro modificata.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Aggiungi l'immagine OLE alle risorse della presentazione.
            ole_image = presentation.images.add_image(image_stream)

            # Crea il frame dell'oggetto OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Conclusione**

{{% alert color="info" title="Nota" %}}
Esistono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. Scegli l'approccio che meglio si adatta ai tuoi requisiti e caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni siano create da un modello sia da zero. Inoltre, non vi è alcun limite alla dimensione del frame OLE in questa soluzione.
{{% /alert %}}

## **Domande frequenti**

**Perché un foglio di lavoro Excel incorporato cambia dimensione al primo attivarsi in PowerPoint?**

Questo accade perché Excel tenta di mantenere le dimensioni originali della finestra quando viene attivato, mentre il frame dell'oggetto OLE in PowerPoint ha proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere il rapporto di aspetto, il che può causare il ridimensionamento.

**È possibile evitare completamente questo problema di ridimensionamento?**

Sì. Scalando il frame OLE per adattarlo alle dimensioni dell'intervallo di celle Excel o scalando l'intervallo di celle per adattarlo alle dimensioni desiderate del frame OLE, è possibile evitare ridimensionamenti indesiderati.

**Quale metodo di scaling dovrei usare, scaling del frame OLE o scaling dell'intervallo di celle?**

Seleziona **OLE frame scaling** se vuoi mantenere le dimensioni originali delle righe e colonne di Excel. Seleziona **cell range scaling** se desideri una dimensione fissa per il frame OLE nella tua presentazione.

**Queste soluzioni funzioneranno se la mia presentazione è basata su un modello?**

Sì. Entrambe le soluzioni funzionano per le presentazioni create da modelli e da zero.

**Esiste un limite alle dimensioni del frame OLE quando si usano questi metodi?**

No. È possibile impostare il frame OLE a qualsiasi dimensione, purché la scala sia impostata correttamente.

**C'è un modo per evitare il testo segnaposto "EMBEDDED OLE OBJECT" in PowerPoint?**

Sì. Catturando un'istantanea dell'intervallo di celle Excel di destinazione e impostandola come immagine segnaposto del frame OLE, è possibile visualizzare un'immagine di anteprima personalizzata al posto del segnaposto predefinito.