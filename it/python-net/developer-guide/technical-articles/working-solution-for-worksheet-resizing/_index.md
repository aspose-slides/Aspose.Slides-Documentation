---
title: Soluzione funzionante per il ridimensionamento dei fogli di lavoro
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
description: "Correggi il ridimensionamento OLE dei fogli di lavoro Excel nelle presentazioni: due modi per mantenere i frame degli oggetti coerenti—scala il frame o il foglio—nei formati PPT e PPTX."
---
{{% alert color="primary" %}} 

È stato osservato che i fogli di lavoro Excel incorporati come oggetti OLE in una presentazione PowerPoint tramite componenti Aspose vengono ridimensionati a una scala non identificata dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente nella presentazione tra gli stati pre‑ e post‑attivazione dell'oggetto OLE. Abbiamo esaminato questo problema in dettaglio e fornito una soluzione, che è descritta in questo articolo.

{{% /alert %}} 

## **Contesto**

Nell'articolo [Gestisci OLE](/slides/it/python-net/manage-ole/), abbiamo spiegato come aggiungere un frame OLE a una presentazione PowerPoint utilizzando Aspose.Slides per Python via .NET. Per affrontare il [problema di anteprima dell'oggetto](/slides/it/python-net/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al frame OLE. Nella presentazione risultante, quando si fa doppio clic sul frame OLE che mostra l'immagine del foglio di lavoro, il workbook di Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate al vero workbook di Excel e quindi tornare alla diapositiva facendo clic al di fuori del workbook di Excel attivato. La dimensione del frame OLE cambierà quando l'utente ritorna alla diapositiva. Il fattore di ridimensionamento varierà in base alle dimensioni del frame OLE e del workbook Excel incorporato.

## **Causa del Ridimensionamento**

Poiché il workbook di Excel ha una propria dimensione della finestra, tenta di mantenere la sua dimensione originale alla prima attivazione. D'altro canto, il frame OLE ha una sua dimensione. Secondo Microsoft, quando il workbook di Excel viene attivato, Excel e PowerPoint negoziano le dimensioni per garantire che mantengano le proporzioni corrette come parte del processo di incorporamento. Il ridimensionamento avviene in base alle differenze tra la dimensione della finestra di Excel e la dimensione e la posizione del frame OLE.

## **Soluzione Funzionale**

Esistono due soluzioni possibili per evitare l'effetto di ridimensionamento.

- Ridimensionare la dimensione del frame OLE nella presentazione PowerPoint per corrispondere all'altezza e alla larghezza del numero desiderato di righe e colonne nel frame OLE.  
- Mantenere costante la dimensione del frame OLE e ridimensionare le righe e le colonne partecipanti per adattarle alla dimensione del frame OLE selezionato.  

### **Scala la Dimensione del Frame OLE**

In questo approccio, impareremo come impostare la dimensione del frame OLE del workbook Excel incorporato per corrispondere alla dimensione cumulativa delle righe e colonne partecipanti nel foglio di lavoro Excel.

Supponiamo di avere un foglio Excel modello e di volerlo aggiungere a una presentazione come frame OLE. In questo scenario, la dimensione del frame OLE verrà prima calcolata in base alle altezze cumulative delle righe e alle larghezze cumulative delle colonne delle righe e colonne partecipanti nel workbook. Successivamente, imposteremo la dimensione del frame OLE a questo valore calcolato. Per evitare il messaggio rosso "EMBEDDED OLE OBJECT" per il frame OLE in PowerPoint, cattureremo anche un'immagine delle porzioni desiderate delle righe e colonne nel workbook e la imposteremo come immagine del frame OLE.

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

    # Imposta la dimensione visualizzata quando il file di cartella di lavoro viene utilizzato come oggetto OLE in PowerPoint.
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

### **Scala la Dimensione dell'Intervallo di Celle**

In questo approccio, impareremo come scalare le altezze delle righe partecipanti e la larghezza delle colonne partecipanti per corrispondere a una dimensione personalizzata del frame OLE.

Supponiamo di avere un foglio Excel modello e di volerlo aggiungere a una presentazione come frame OLE. In questo scenario, imposteremo la dimensione del frame OLE e scaleremo la dimensione delle righe e delle colonne che partecipano all'area del frame OLE. Successivamente salveremo il workbook in uno stream per applicare le modifiche e lo convergeremo in un array di byte per aggiungerlo al frame OLE. Per evitare il messaggio rosso "EMBEDDED OLE OBJECT" per il frame OLE in PowerPoint, cattureremo anche un'immagine delle porzioni desiderate delle righe e colonne nel workbook e la imposteremo come immagine del frame OLE.

```py
# <param name="width">La larghezza prevista dell'intervallo di celle in punti.</param>
# <param name="height">L'altezza prevista dell'intervallo di celle in punti.</param>
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

    # Imposta la dimensione visualizzata quando il file di cartella di lavoro viene utilizzato come oggetto OLE in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Scala l'intervallo di celle per adattarlo alle dimensioni del frame.
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

{{% alert color="primary" %}}

Ci sono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. La scelta dell'approccio appropriato dipende dai requisiti specifici e dal caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni vengano create da un modello sia da zero. Inoltre, non vi è alcun limite alla dimensione del frame OLE in questa soluzione.

{{% /alert %}}